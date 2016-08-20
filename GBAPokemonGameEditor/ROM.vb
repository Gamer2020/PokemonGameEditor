Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Text


Public Class ROM
    'Implements IDisposable
    Private buffer As Byte()
    Private pos As Integer = 0
    Private m_filePath As String
    Private fileWatcher As FileSystemWatcher
    Private ignoreChange As Boolean

    Private disposed As Boolean

    Public Sub New(filePath As String)
        Try
            ' read contents of file into buffer
            Using fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                buffer = New Byte(fs.Length - 1) {}
                fs.Read(buffer, 0, buffer.Length)
            End Using

            ' create file watcher to monitor ROM being modified
            fileWatcher = New FileSystemWatcher()
            fileWatcher.Path = Path.GetDirectoryName(filePath)
            fileWatcher.Filter = "*.gba"

            AddHandler fileWatcher.Changed, AddressOf OnSourceFileChanged
            AddHandler fileWatcher.Renamed, AddressOf OnSourceFileRenamed

            fileWatcher.EnableRaisingEvents = True
        Catch
            Throw New Exception("Unable to open {filePath}!")
        End Try

        Me.m_filePath = filePath
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Dispose()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Sub Dispose()
        If disposed Then
            Return
        End If
        disposed = True

        fileWatcher.Dispose()
        buffer = Nothing
    End Sub

    Public Sub Save()
        If String.IsNullOrEmpty(m_filePath) Then
            Return
        End If

        Using fs = File.Open(m_filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)
            fs.Write(buffer, 0, buffer.Length)
        End Using

        ignoreChange = True
    End Sub

    Public Sub Seek(offset As Integer)
        If offset < 0 OrElse offset > buffer.Length Then
            Throw New IndexOutOfRangeException()
        End If

        pos = offset
    End Sub

    Public Sub Skip(bytes As Integer)
        pos += bytes

        If pos < 0 OrElse pos > buffer.Length Then
            Throw New IndexOutOfRangeException()
        End If
    End Sub

#Region "Read"

    Public Function ReadByte() As Byte
        Return buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1))
    End Function

    Public Function PeekByte() As Byte
        Return buffer(pos)
    End Function

    Public Function ReadSByte() As SByte
        Return CSByte(ReadByte())
    End Function

    Public Function ReadUInt16() As UShort
        Return CUShort(buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 8))
    End Function

    Public Function ReadInt32() As Integer
        Return buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 8) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 16) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 24)
    End Function

    Public Function ReadUInt32() As UInteger
        Return CUInt(buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 8) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 16) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 24))
    End Function

    Public Function ReadUInt64() As ULong
        Return CULng(buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 8) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 16) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 24) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 32) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 40) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 48) Or (buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) << 56))
    End Function

    Public Function ReadBytes(count As Integer) As Byte()
        Dim b = New Byte(count - 1) {}
        For i As Integer = 0 To count - 1
            b(i) = buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1))
        Next
        Return b
    End Function

    ' Read a UTF8 encoded string
    Public Function ReadString(length As Integer) As String
        Return Encoding.UTF8.GetString(ReadBytes(length))
    End Function

    Public Function ReadPointer() As Integer
        ' read value
        Dim ptr = ReadInt32()

        ' return on blank pointer
        If ptr = 0 Then
            Return 0
        End If

        ' a pointer must be between 0x0 and 0x1FFFFFF to be valid on the GBA
        ' ROM pointer format is OFFSET | 0x8000000, so 0x8000000 <= POINTER <= 0x9FFFFFF
        If ptr < &H8000000 OrElse ptr > &H9FFFFFF Then
            Throw New Exception(String.Format("Bad pointer at 0x{0:X6}", pos - 4))
        End If

        ' easy way to extract
        Return ptr And &H1FFFFFF
    End Function

    ' read a GBA string
    'Public Function ReadText(length As Integer, Optional encoding As CharacterEncoding = CharacterEncoding.English) As String
    '    Return TextTable.GetString(ReadBytes(length), encoding)
    'End Function

    'Public Function ReadTextTable(stringLength As Integer, tableSize As Integer, Optional encoding As CharacterEncoding = CharacterEncoding.English) As String()
    '    Dim table = New String(tableSize - 1) {}
    '    For i As Integer = 0 To tableSize - 1
    '        table(i) = ReadText(stringLength, encoding)
    '    Next

    '    Return table
    'End Function



#End Region

#Region "Write"

    Public Sub WriteByte(value As Byte)
        buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = value
    End Sub

    Public Sub WriteSByte(value As SByte)
        WriteByte(CByte(value))
    End Sub

    Public Sub WriteUInt16(value As UShort)
        buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = CByte(value)
        buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = CByte(value >> 8)
    End Sub

    Public Sub WriteInt32(value As Integer)
        For i As Integer = 0 To 3
            buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = CByte(value >> (i * 8))
        Next
    End Sub

    Public Sub WriteUInt32(value As UInteger)
        For i As Integer = 0 To 3
            buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = CByte(value >> (i * 8))
        Next
    End Sub

    Public Sub WriteUInt64(value As ULong)
        For i As Integer = 0 To 7
            buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = CByte(value >> (i * 8))
        Next
    End Sub

    Public Sub WriteBytes(bytes As Byte())
        For i As Integer = 0 To bytes.Length - 1
            buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = bytes(i)
        Next
    End Sub

    ' Write a byte value count number of times
    Public Sub WriteBytes(value As Byte, count As Integer)
        For i As Integer = 0 To count - 1
            buffer(System.Math.Max(System.Threading.Interlocked.Increment(pos), pos - 1)) = value
        Next
    End Sub

    Public Sub WritePointer(offset As Integer)
        If offset > &H1FFFFFF Then
            Throw New Exception(String.Format("Offset 0x{0:X6} too large for a ROM pointer (0 <= offset <= 0x1FFFFFF)!"))
        End If

        WriteInt32(offset Or &H8000000)
    End Sub

    ' Write a UTF8 encoded string
    Public Sub WriteString(str As String)
        WriteBytes(Encoding.UTF8.GetBytes(str))
    End Sub

#End Region

#Region "Search"

    Public Function FindFreeSpace(length As Integer, Optional freespace As Byte = &HFF, Optional startOffset As Integer = 0, Optional alignment As Integer = 1) As Integer
        ' The simpest freespace finder I could think of
        If alignment > 1 AndAlso startOffset Mod alignment <> 0 Then
            startOffset += alignment - (startOffset Mod alignment)
        End If

        Dim i As Integer = startOffset
        While i < buffer.Length - length
            Dim match As Boolean = True
            For j As Integer = 0 To length - 1
                If buffer(i + j) <> freespace Then
                    match = False
                    Exit For
                End If
            Next

            If match Then
                Return i
            End If
            i += alignment
        End While
        Return -1
    End Function

#End Region

#Region "Properties"

    Public ReadOnly Property FilePath() As String
        Get
            Return m_filePath
        End Get
    End Property

    Public ReadOnly Property Length() As Integer
        Get
            Return buffer.Length
        End Get
    End Property

    Public Property Position() As Integer
        Get
            Return pos
        End Get
        Set(value As Integer)
            pos = value

            If pos < 0 OrElse pos > buffer.Length Then
                Throw New IndexOutOfRangeException()
            End If
        End Set
    End Property

    Public ReadOnly Property EndOfStream() As Boolean
        Get
            Return pos >= buffer.Length
        End Get
    End Property

    ' ROM specific properties
    ' TODO: better to store these as existing strings

    Public ReadOnly Property Name() As String
        Get
            Return Encoding.UTF8.GetString(buffer, &HA0, 12)
        End Get
    End Property

    Public ReadOnly Property Code() As String
        Get
            Return Encoding.UTF8.GetString(buffer, &HAC, 4)
        End Get
    End Property

    Public ReadOnly Property Maker() As String
        Get
            Return Encoding.UTF8.GetString(buffer, &HB0, 2)
        End Get
    End Property

#End Region

    Private Sub OnSourceFileChanged(sender As Object, e As FileSystemEventArgs)
        Console.WriteLine("ROM {e.FullPath} changed {e.ChangeType}.")
        If ignoreChange Then
            ignoreChange = False
            Return
        End If

        If e.FullPath = m_filePath Then
            Console.WriteLine("Reloading buffer...")
            Using fs = File.Open(m_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                If buffer.Length <> fs.Length Then
                    buffer = New Byte(fs.Length - 1) {}
                End If

                fs.Read(buffer, 0, buffer.Length)
            End Using
        End If
    End Sub

    Private Sub OnSourceFileRenamed(sender As Object, e As RenamedEventArgs)
        Console.WriteLine("{e.OldFullPath} renamed to {e.FullPath}!")

        If e.OldFullPath = m_filePath Then
            m_filePath = e.FullPath
        End If
    End Sub
End Class

