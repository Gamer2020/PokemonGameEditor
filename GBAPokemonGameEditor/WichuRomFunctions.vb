Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text

'The following functions were extracted from A-series. All credit goes to it's programmer Wichu!

Module WichuRomFunctions
    Public Function CompressLz77(ByRef data As Byte()) As Collection
        Dim position As Integer = 0
        Dim length As Integer = data.Length
        Dim collection3 As New Collection
        Dim collection As New Collection
        collection.Add(&H10, Nothing, Nothing, Nothing)
        collection.Add((length And &HFF), Nothing, Nothing, Nothing)
        collection.Add(((length >> 8) And &HFF), Nothing, Nothing, Nothing)
        collection.Add(((length >> &H10) And &HFF), Nothing, Nothing, Nothing)
        Do While (position < length)
            Dim item As Byte = 0
            collection3.Clear()
            Dim num4 As Integer = 0
            Do
                Dim numArray As Integer() = Lz77Search(data, position)
                If (numArray(0) > 2) Then
                    collection3.Add(((((numArray(0) - 3) And 15) << 4) Or (((numArray(1) - 1) >> 8) And 15)), Nothing, Nothing, Nothing)
                    collection3.Add(((numArray(1) - 1) And &HFF), Nothing, Nothing, Nothing)
                    position = (position + numArray(0))
                    item = CByte((item Or (CInt(1) << (7 - num4))))
                Else
                    If (numArray(0) < 0) Then
                        Exit Do
                    End If
                    collection3.Add(data(position), Nothing, Nothing, Nothing)
                    position += 1
                End If
                num4 += 1
            Loop While (num4 <= 7)
            collection.Add(item, Nothing, Nothing, Nothing)
            Dim count As Integer = collection3.Count
            Dim i As Integer = 1
            Do While (i <= count)
                collection.Add(RuntimeHelpers.GetObjectValue(collection3.Item(i)), Nothing, Nothing, Nothing)
                i += 1
            Loop
        Loop
        Return collection
    End Function

    Public Function CompressLz77String(ByRef srcString As String) As String
        Dim length As Integer = 1
        Dim num3 As UInt32 = Len(CStr(srcString))
        Dim str2 As String = (ChrW(16) & Conversions.ToString(Strings.Chr(CInt((num3 And &HFF)))) & Conversions.ToString(Strings.Chr(CInt(((num3 >> 8) And &HFF)))) & Conversions.ToString(Strings.Chr(CInt(((num3 >> &H10) And &HFF)))))
        Do While (length <= num3)
            Dim charCode As Byte = 0
            Dim str3 As String = ""
            Dim num5 As Integer = 0
            Do
                If (length > num3) Then
                    Exit Do
                End If
                Dim num6 As Integer = &H12
                Dim num4 As Integer = Strings.InStr(1, Strings.Left(srcString, length), Strings.Mid(srcString, length, num6), CompareMethod.Binary)
                If ((num4 > 0) And ((length + num6) <= num3)) Then
                    num4 = (length - num4)
                    str3 = (str3 & Conversions.ToString(Strings.Chr(((((num6 - 3) And 15) << 4) + (((num4 - 1) >> 8) And 15)))) & Conversions.ToString(Strings.Chr(((num4 - 1) And &HFF))))
                    length = (length + num6)
                    charCode = CByte((charCode Or (CInt(1) << (7 - num5))))
                Else
                    str3 = (str3 & Strings.Mid(srcString, length, 1))
                    length += 1
                End If
                num5 += 1
            Loop While (num5 <= 7)
            str2 = (str2 & Conversions.ToString(Strings.Chr(charCode)) & str3)
        Loop
        Do While ((str2.Length Mod 4) > 0)
            str2 = (str2 & ChrW(0))
        Loop
        Return str2
    End Function

    Public Function ConvertByteArrayToString(ByRef ary As Byte()) As String
        Dim str2 As String = ""
        Dim num2 As Integer = (ary.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            str2 = (str2 & Conversions.ToString(Strings.Chr(ary(i))))
            i += 1
        Loop
        Return str2
    End Function

    Public Function ConvertCollectionToByteArray(ByRef col As Collection) As Byte()
        Dim buffer2 As Byte() = New Byte(((col.Count - 1) + 1) - 1) {}
        Dim count As Integer = col.Count
        Dim i As Integer = 1
        Do While (i <= count)
            buffer2((i - 1)) = Conversions.ToByte(col.Item(i))
            i += 1
        Loop
        Return buffer2
    End Function

    Public Function ConvertStringToByteArray(ByRef str As String) As Byte()
        Dim buffer2 As Byte() = New Byte(((str.Length - 1) + 1) - 1) {}
        Dim num2 As Integer = (str.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num2)
            buffer2(i) = CByte(Strings.Asc(Strings.Mid(str, (i + 1), 1)))
            i += 1
        Loop
        Return buffer2
    End Function

    Public Function FindNextFreeSpace(ByRef Stream As FileStream, ByVal length As Integer) As Integer
        Do While (Stream.Position < Stream.Length)
            Dim num As Byte = CByte(Stream.ReadByte)
            If ((num = 0) Or (num = &HFF)) Then
                Dim num3 As Integer = 1
                Dim num4 As Integer = CInt((Stream.Position - 1))
                Do While ((num3 < length) And (Stream.Position < Stream.Length))
                    num = CByte(Stream.ReadByte)
                    If ((num <> &HFF) And (num <> 0)) Then
                        Exit Do
                    End If
                    num3 += 1
                Loop
                If (num3 = length) Then
                    Return num4
                End If
            End If
            Do While ((Stream.Position Mod 4) > 0)
                Stream.ReadByte()
            Loop
        Loop
        Return -1
    End Function

    Public Function FromRSChar(ByVal ch As Byte) As Object
        Dim array As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &HFE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &HAB, 0, 0, &HB7, &H5B, 0, 180, &H5C, &H5D, &HB9, &H2E, &HB8, &HAE, &HAD, &HBA, &HA1, &HA2, &HA3, &HA4, &HA5, &HA6, &HA7, &HA8, &HA9, 170, 240, &H36, 0, &H35, 0, &HAC, 0, &HBB, &HBC, &HBD, 190, &HBF, &HC0, &HC1, &HC2, &HC3, &HC4, &HC5, &HC6, &HC7, 200, &HC9, &HCA, &HCB, &HCC, &HCD, &HCE, &HCF, &HD0, &HD1, 210, &HD3, &HD4, 0, 0, 0, 0, 0, &HB3, &HD5, &HD6, &HD7, &HD8, &HD9, &HDA, &HDB, 220, &HDD, &HDE, &HDF, &HE0, &HE1, &HE2, &HE3, &HE4, &HE5, 230, &HE7, &HE8, &HE9, &HEA, &HEB, &HEC, &HED, &HEE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &H52, 0, 0, 0, 0, 0, 0, 0, 0, &H2B, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &H2A, 0, 0, 0, 0, &H51, 1, 2, 0, 0, &HF1, 0, 0, 4, 5, 6, 7, 8, 9, 90, 11, 12, 0, 20, 13, 14, 15, 0, &HF2, 0, 0, &H11, &H12, &H13, &HF3, 0, 0, &H15, &H16, &H17, &H68, 0, &HF4, 0, 0, &H19, &H1A, &H1B, &H1C, &H1D, 30, &H6F, &H20, &H21, 0, &H29, &H22, &H23, &H24, 0, &HF5, 0, 0, &H26, &H27, 40, &HF6, 0, 0, 0, 0}
        'Dim index As Integer = array.IndexOf(Of Byte)(array, ch)
        Dim index As Integer = array.IndexOf(array, ch)
        If (index = -1) Then
            index = 0
        End If
        Return Strings.Chr(index)
    End Function

    Public Function GetDoublePointerTable(ByRef Stream As FileStream, ByVal length As Integer) As UInt32()
        Dim numArray2 As UInt32() = New UInt32(((length - 1) + 1) - 1) {}
        Dim num3 As Integer = (length - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim streamvar As Stream = Stream
            streamvar = DirectCast(streamvar, FileStream)
            Dim num As UInt32 = Conversions.ToUInteger(GetDWord(streamvar))
            If (num > &H8000000) Then
                numArray2(i) = (num - &H8000000)
                streamvar.Seek(4, SeekOrigin.Current)
            End If
            i += 1
        Loop
        Return numArray2
    End Function

    Public Function GetDWord(ByRef streaminput As Stream) As Object
        Dim num As UInt32 = streaminput.ReadByte
        num = (num Or (Convert.ToUInt32(streaminput.ReadByte) << 8))
        num = (num Or (Convert.ToUInt32(streaminput.ReadByte) << &H10))
        Return (num Or (Convert.ToUInt32(streaminput.ReadByte) << &H18))
    End Function

    Public Function GetGameCode(ByRef filename As String) As String
        Dim stream As New FileStream(filename, FileMode.Open)
        Dim reader As New StreamReader(stream, Encoding.ASCII)
        Dim str As String = ""
        stream.Seek(&HAC, SeekOrigin.Begin)
        Dim num As Integer = 0
        Do
            str = (str & Conversions.ToString(Strings.Chr(reader.Read)))
            num += 1
        Loop While (num <= 3)
        reader.Close()
        stream.Close()
        Return str
    End Function

    Public Function GetLz77UncompressedLength(ByRef stream As FileStream) As Integer
        Dim num2 As Integer = 0
        If (stream.ReadByte <> &H10) Then
            Interaction.MsgBox("Data is not LZ77 compressed!", MsgBoxStyle.ApplicationModal, Nothing)
            Return 0
        End If
        num2 = (stream.ReadByte + (stream.ReadByte << 8))
        Return (num2 + (stream.ReadByte << &H10))
    End Function

    Public Function GetSinglePointerTable(ByRef streaminput As FileStream, ByVal length As Integer) As UInt32()
        Dim numArray2 As UInt32() = New UInt32(((length - 1) + 1) - 1) {}
        Dim num3 As Integer = (length - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim stream As Stream = streaminput
            stream = DirectCast(stream, FileStream)
            Dim num As UInt32 = Conversions.ToUInteger(GetDWord(stream))
            If (num > &H8000000) Then
                numArray2(i) = (num - (&H8000000))
            End If
            i += 1
        Loop
        Return numArray2
    End Function

    Public Function GetWord(ByRef stream As Stream) As Object
        Dim num As UInt16 = CUShort(stream.ReadByte)
        Return CUShort((num Or CUShort((Convert.ToUInt16(stream.ReadByte) << 8))))
    End Function

    Public Function LoadString(ByRef Stream As FileStream, ByVal length As Integer) As Object
        Dim chArray As Char() = New Char(((length - 1) + 1) - 1) {}
        Dim flag As Boolean = False
        Dim num3 As Integer = (length - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim ch As Byte = CByte(Stream.ReadByte)
            If Not flag Then
                Select Case ch
                    Case &HFF
                        flag = True
                        Continue Do
                    Case 0
                        chArray(i) = "?"c
                        Continue Do
                End Select
                chArray(i) = Conversions.ToChar(FromRSChar(ch))
            End If
            i += 1
        Loop
        Return Convert.ToString(New String(chArray))
    End Function

    Public Function Lz77Search(ByRef data As Byte(), ByVal position As Integer) As Integer()
        Dim length As Integer = data.Length
        Dim numArray2 As Integer() = New Integer(2 - 1) {}
        Dim collection As New Collection
        If ((position < 3) Or ((length - position) < 3)) Then
            numArray2(0) = 0
            numArray2(1) = 0
            Return numArray2
        End If
        If (position >= length) Then
            numArray2(0) = -1
            numArray2(1) = 0
            Return numArray2
        End If
        Dim num4 As Integer = &H1000
        If (num4 > position) Then
            num4 = position
        End If
        Dim num6 As Integer = (num4 - 1)
        Dim i As Integer = 0
        Do While (i <= num6)
            If (data(((position - i) - 1)) = data(position)) Then
                collection.Add((i + 1), Nothing, Nothing, Nothing)
            End If
            i += 1
        Loop
        If (collection.Count = 0) Then
            numArray2(0) = 0
            numArray2(1) = 0
            Return numArray2
        End If
        Dim left As Byte = 0
        Dim flag As Boolean = False
        Do While (left < &H12)
            left = CByte((left + 1))
            Dim j As Integer
            For j = 0 To collection.Count - 1
                If ((position + left) >= data.Length) Then
                    flag = True
                ElseIf (data((position + left)) <> data(Conversions.ToInteger(Operators.AddObject(Operators.SubtractObject(position, collection.Item((j + 1))), Operators.ModObject(left, collection.Item((j + 1))))))) Then
                    If (collection.Count > 1) Then
                        collection.Remove(CInt((j + 1)))
                        j -= 1
                    Else
                        flag = True
                    End If
                End If
                If flag Then
                    Exit For
                End If
            Next j
            If flag Then
                Exit Do
            End If
        Loop
        numArray2(0) = left
        numArray2(1) = Conversions.ToInteger(collection.Item(1))
        Return numArray2
    End Function

    Public Sub SetDWord(ByRef stream As Stream, ByVal dword As UInt32)
        stream.WriteByte(CByte((dword And &HFF)))
        stream.WriteByte(CByte(((dword >> 8) And &HFF)))
        stream.WriteByte(CByte(((dword >> &H10) And &HFF)))
        stream.WriteByte(CByte(((dword >> 0) And &HFF)))
    End Sub

    Public Sub SetOffset(ByRef stream As Stream, ByVal offset As UInt32)
        stream.WriteByte(CByte((offset And &HFF)))
        stream.WriteByte(CByte(((offset >> 8) And &HFF)))
        stream.WriteByte(CByte(((offset >> &H10) And &HFF)))
        stream.WriteByte(8)
    End Sub

    Public Sub SetWord(ByRef stream As Stream, ByVal word As UInt16)
        stream.WriteByte(CByte((word And &HFF)))
        stream.WriteByte(CByte((CUShort((word >> 8)) And &HFF)))
    End Sub

    Public Sub ToNextValidOffset(ByRef Stream As FileStream)
        Do While ((Stream.Position Mod 4) > 0)
            Stream.ReadByte()
        Loop
    End Sub

    Public Function ToRSChar(ByVal [chr] As Char) As Object
        Dim buffer As Byte() = New Byte() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &HFE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &HAB, 0, 0, &HB7, &H5B, 0, 180, &H5C, &H5D, &HB9, &H2E, &HB8, &HAE, &HAD, &HBA, &HA1, &HA2, &HA3, &HA4, &HA5, &HA6, &HA7, &HA8, &HA9, 170, 240, &H36, 0, &H35, 0, &HAC, 0, &HBB, &HBC, &HBD, 190, &HBF, &HC0, &HC1, &HC2, &HC3, &HC4, &HC5, &HC6, &HC7, 200, &HC9, &HCA, &HCB, &HCC, &HCD, &HCE, &HCF, &HD0, &HD1, 210, &HD3, &HD4, 0, 0, 0, 0, 0, &HB3, &HD5, &HD6, &HD7, &HD8, &HD9, &HDA, &HDB, 220, &HDD, &HDE, &HDF, &HE0, &HE1, &HE2, &HE3, &HE4, &HE5, 230, &HE7, &HE8, &HE9, &HEA, &HEB, &HEC, &HED, &HEE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &H52, 0, 0, 0, 0, 0, 0, 0, 0, &H2B, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, &H2A, 0, 0, 0, 0, &H51, 1, 2, 0, 0, &HF1, 0, 0, 4, 5, 6, 7, 8, 9, 90, 11, 12, 0, 20, 13, 14, 15, 0, &HF2, 0, 0, &H11, &H12, &H13, &HF3, 0, 0, &H15, &H16, &H17, &H68, 0, &HF4, 0, 0, &H19, &H1A, &H1B, &H1C, &H1D, 30, &H6F, &H20, &H21, 0, &H29, &H22, &H23, &H24, 0, &HF5, 0, 0, &H26, &H27, 40, &HF6, 0, 0, 0, 0}
        Return buffer(Strings.Asc([chr]))
    End Function

    Public Function UncompressLZ77(ByRef Stream As FileStream) As Byte()
        Return UncompressLZ77(Stream, True)
    End Function

    Public Function UncompressLZ77(ByRef Stream As FileStream, ByVal message As Boolean) As Byte()
        Dim num7 As UInt32
        Dim array As Byte() = New Byte(0 - 1) {}
        If (Stream.ReadByte <> &H10) Then
            If message Then
                Interaction.MsgBox("Data is not LZ77 compressed!", MsgBoxStyle.ApplicationModal, Nothing)
            End If
            Return array
        End If
        Dim num6 As UInt32 = Stream.ReadByte
        num6 = (num6 + (Stream.ReadByte << 8))
        num6 = (num6 + (Stream.ReadByte << &H10))
        If (num6 > &H2404) Then
            If message Then
                Interaction.MsgBox("Invalid LZ77 offset", MsgBoxStyle.ApplicationModal, Nothing)
            End If
            Return array
        End If
        array.Resize(Of Byte)(array, CInt(num6))
        Do While (num7 < num6)
            Dim num3 As Byte = CByte(Stream.ReadByte)
            Dim num8 As Integer = 0
            Do
                If ((num3 And &H80) > 0) Then
                    Dim num2 As UInt32 = Stream.ReadByte
                    Dim num5 As UInt32 = Stream.ReadByte
                    Dim num4 As UInt32 = ((((num2 << 8) + num5) And &HFFF) + CULng(1))
                    Dim num As UInt32 = (CULng(3) + ((num2 >> 4) And 15))
                    If (num4 > num7) Then
                        Return array
                    End If
                    Dim num10 As Long = (num - 1)
                    Dim i As Long = 0
                    Do While (i <= num10)
                        If ((num7 + i) >= num6) Then
                            Exit Do
                        End If
                        array(CInt((num7 + i))) = array(CInt(((num7 - num4) + (i Mod CULng(num4)))))
                        i = (i + 1)
                    Loop
                    num7 = (num7 + num)
                Else
                    array(num7) = CByte(Stream.ReadByte)

                    num7 = (num7 + 1)
                End If
                If (num7 >= num6) Then
                    Return array
                End If
                num3 = CByte((num3 << 1))
                num8 += 1
            Loop While (num8 <= 7)
        Loop
        Return array
    End Function
End Module
