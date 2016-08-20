
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

        'If Not CryToLoad.Compressed Then
        '    ' uncompressed, 1 sample per 1 byte of size
        '    CryToLoad.Data = New SByte(CryToLoad.Size - 1) {}
        '    For i As Integer = 0 To CryToLoad.Size - 1
        '        CryToLoad.Data(i) = ledrom.ReadSByte()
        '    Next
        'Else
        '    ' compressed, a bit of a hassle
        '    Dim lookup = New SByte() {0, 1, 4, 9, 16, 25, _
        '        36, 49, -64, -49, -36, -25, _
        '        -16, -9, -4, -1}
        '    Dim start = ledrom.Position

        '    Dim alignment As Integer = 0, size As Integer = 0
        '    Dim pcmLevel As SByte = 0

        '    Dim data = New List(Of SByte)()
        '    While True
        '        If alignment = 0 Then
        '            pcmLevel = ledrom.ReadSByte()
        '            data.Add(pcmLevel)

        '            alignment = &H20
        '        End If

        '        Dim input = ledrom.ReadByte()
        '        If alignment < &H20 Then
        '            ' first nybble
        '            pcmLevel += lookup(input >> 4)
        '            data.Add(pcmLevel)
        '        End If

        '        ' second nybble
        '        pcmLevel += lookup(input And &HF)
        '        data.Add(pcmLevel)

        '        ' exit when currentSize >= cry.Size
        '        size += 2
        '        If size >= CryToLoad.Size Then
        '            Exit While
        '        End If

        '        alignment -= 1
        '    End While

        '    CryToLoad.Data = data.ToArray()
        '    ' bytes needed to recompress
        '    CryToLoad.Size = ledrom.Position - start
        'End If

        Return CryToLoad
    End Function

End Module
