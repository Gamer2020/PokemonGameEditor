Imports System
Imports System.IO
Imports System.Text
Imports System.Media

'These functions are based off the ones found in this project: https://github.com/doom-desire/Cry-Editor
'Credit goes to doom-desire for these functions.

Module CryFunctions

    Structure Cry
        Public Index As Integer
        Public Offset As Integer

        Public Compressed As Boolean
        Public Looped As Boolean
        Public SampleRate As Integer
        Public LoopStart As Integer
        Public Size As Integer

        Public Data As SByte()
    End Structure

    Public Function LoadCry(index As Integer, cryTable As Integer) As Cry

        Dim CryToLoad As New Cry

        'If ledrom Is Nothing Then
        '    Return False
        'End If

        ' load cry table entry
        'ledrom.Seek(cryTable + index * 12)

        'Dim someValue = ledrom.ReadInt32()
        'Dim cryOffset = ledrom.ReadPointer()
        'Dim cryShape = ledrom.ReadInt32()

        Dim someValue = Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryTable) + (index * 12), 4))), System.Globalization.NumberStyles.HexNumber)
        Dim cryOffset = (Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryTable) + (index * 12) + 4, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        Dim cryShape = Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryTable) + (index * 12) + 8, 4))), System.Globalization.NumberStyles.HexNumber)


        'If cryOffset = 0 Then
        '    Return False
        'End If

        ' load cry data
        'ledrom.Seek(cryOffset)

        CryToLoad.Offset = cryOffset
        CryToLoad.Index = index


        'CryToLoad.Compressed = ledrom.ReadUInt16() = &H1
        'CryToLoad.Looped = ledrom.ReadUInt16() = &H4000
        'CryToLoad.SampleRate = ledrom.ReadInt32() >> 10
        'CryToLoad.LoopStart = ledrom.ReadInt32()
        'CryToLoad.Size = ledrom.ReadInt32() + 1

        CryToLoad.Compressed = Int16.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryOffset) + 0, 2))), System.Globalization.NumberStyles.HexNumber) = &H1
        CryToLoad.Looped = Int16.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryOffset) + 2, 2))), System.Globalization.NumberStyles.HexNumber) = &H4000
        CryToLoad.SampleRate = Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryOffset) + 4, 4))), System.Globalization.NumberStyles.HexNumber) >> 10
        CryToLoad.LoopStart = Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryOffset) + 8, 4))), System.Globalization.NumberStyles.HexNumber)
        CryToLoad.Size = Int32.Parse(ReverseHEX((ReadHEX(LoadedROM, (cryOffset) + 12, 4))), System.Globalization.NumberStyles.HexNumber) + 1

        If Not CryToLoad.Compressed Then
            ' uncompressed, 1 sample per 1 byte of size
            CryToLoad.Data = New SByte(CryToLoad.Size - 1) {}
            For g As Integer = 0 To CryToLoad.Size - 1

                CryToLoad.Data(g) = ByteToSignedInt("&H" & (ReadHEX(LoadedROM, (cryOffset) + 16 + g, 1)))
            Next
        Else
            ' compressed, a bit of a hassle
            Dim lookup = New SByte() {0, 1, 4, 9, 16, 25, _
                36, 49, -64, -49, -36, -25, _
                -16, -9, -4, -1}

            Dim start = (cryOffset) + 16
            Dim offtrack = (cryOffset) + 16

            Dim alignment As Integer = 0, size As Integer = 0
            Dim pcmLevel As SByte = 0

            Dim data = New List(Of SByte)()

            While True

                If alignment = 0 Then

                    pcmLevel = ByteToSignedInt("&H" & (ReadHEX(LoadedROM, offtrack, 1)))
                    offtrack = offtrack + 1
                    data.Add(pcmLevel)

                    alignment = &H20
                End If

                Dim input As Byte = ("&H" & (ReadHEX(LoadedROM, offtrack, 1)))
                offtrack = offtrack + 1

                If alignment < &H20 Then
                    ' first nybble
                    pcmLevel += lookup(input >> 4)
                    data.Add(pcmLevel)
                End If

                ' second nybble
                pcmLevel += lookup(input And &HF)
                data.Add(pcmLevel)

                ' exit when currentSize >= cry.Size
                size += 2
                If size >= CryToLoad.Size Then
                    Exit While
                End If

                alignment -= 1
            End While

            CryToLoad.Data = data.ToArray()
            ' bytes needed to recompress
            CryToLoad.Size = offtrack - start
        End If

        Return CryToLoad
    End Function

    Public Function GetCryImage(cry As Cry) As Bitmap

        Dim cryImage As Bitmap


        cryImage = New Bitmap(cry.Data.Length, 128)

        Using g = Graphics.FromImage(cryImage)
            For i As Integer = 1 To cry.Data.Length - 1
                g.DrawLine(Pens.Green, i - 1, 64 + cry.Data(i - 1), i, 64 + cry.Data(i))
            Next
        End Using

        Return cryImage

    End Function


    Public Sub PlayCry(cry As Cry)
        ' TODO: we could do this in another thread :O
        If cry.Offset = 0 Then
            Exit Sub
        End If

        Using stream = New MemoryStream()
            ' "save" the cry to a memorystream
            Using writer As BinaryWriter = New BinaryWriter(stream, Encoding.ASCII, True)
                ' RIFF header
                writer.Write(Encoding.ASCII.GetBytes("RIFF"))
                writer.Write(0)
                writer.Write(Encoding.ASCII.GetBytes("WAVE"))

                ' fmt chunk
                writer.Write(Encoding.ASCII.GetBytes("fmt "))
                writer.Write(16)
                writer.Write(CUShort(1))
                writer.Write(CUShort(1))
                writer.Write(cry.SampleRate)
                writer.Write(cry.SampleRate)
                writer.Write(CUShort(1))
                writer.Write(CUShort(8))

                ' data chunk
                writer.Write(Encoding.ASCII.GetBytes("data"))
                writer.Write(cry.Data.Length)
                For Each sample As SByte In cry.Data
                    writer.Write(CByte(sample + &H80))
                Next

                ' fix header
                writer.Seek(4, SeekOrigin.Begin)
                writer.Write(CInt(writer.BaseStream.Length) - 8)

            End Using

            ' play it via a soundplayer
            stream.Seek(0L, SeekOrigin.Begin)
            Using player = New SoundPlayer(stream)
                player.Load()
                player.Play()
            End Using
        End Using
    End Sub


    Public Sub ExportCry(filename As String, cry As Cry)
        If Cry.Offset = 0 Then
            Return
        End If

        ' http://www-mmsp.ece.mcgill.ca/documents/audioformats/wave/wave.html
        ' http://soundfile.sapp.org/doc/WaveFormat/
        Using writer = New BinaryWriter(File.Create(filename))
            ' RIFF header
            writer.Write(Encoding.ASCII.GetBytes("RIFF"))
            ' file ID
            writer.Write(0)
            ' file size placeholder
            writer.Write(Encoding.ASCII.GetBytes("WAVE"))
            ' format
            ' fmt chunk
            writer.Write(Encoding.ASCII.GetBytes("fmt "))
            ' chunk ID
            writer.Write(16)
            ' chunk size, 16 for PCM
            writer.Write(CUShort(1))
            ' format: 1 = wave_format_pcm
            writer.Write(CUShort(1))
            ' channel count
            writer.Write(Cry.SampleRate)
            ' sample rate
            ' * 1 * 8 / 8
            writer.Write(Cry.SampleRate)
            ' SampleRate * NumChannels * BitsPerSample/8
            ' * 8 / 8
            writer.Write(CUShort(1))
            ' NumChannels * BitsPerSample/8
            writer.Write(CUShort(8))
            ' bits per sample
            ' data chunk
            writer.Write(Encoding.ASCII.GetBytes("data"))
            ' chunk ID
            writer.Write(Cry.Data.Length)
            ' chunk size
            For Each sample As SByte In cry.Data
                writer.Write(CByte(sample + &H80))
            Next
            ' wave PCM is unsigned unlike GBA PCM which is
            ' fix header
            writer.Seek(4, SeekOrigin.Begin)
            writer.Write(CInt(writer.BaseStream.Length) - 8)
        End Using
    End Sub

End Module
