Imports System
Imports System.IO
Imports System.Text
Imports System.Media
Imports VB = Microsoft.VisualBasic

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

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisableCryImage", "0") = "1" Then
            cryImage = New Bitmap(128, 128)
        Else

            cryImage = New Bitmap(cry.Data.Length, 128)

            Using g = Graphics.FromImage(cryImage)
                For i As Integer = 1 To cry.Data.Length - 1
                    g.DrawLine(Pens.Green, i - 1, 64 + cry.Data(i - 1), i, 64 + cry.Data(i))
                Next
            End Using


        End If

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

    Public Function ImportCry(filename As String, CryToLoad As Cry) As Cry

       'If Cry.Offset = 0 Then
        '    Return
        'End If

        ' load a wave file
        Using reader = New BinaryReader(File.OpenRead(filename))
            ' read RIFF header
            If reader.ReadUInt32() <> &H46464952 Then
                Throw New Exception("This is not a WAVE file!")
            End If
            If reader.ReadInt32() + 8 <> reader.BaseStream.Length Then
                Throw New Exception("Invalid file length!")
            End If
            If reader.ReadUInt32() <> &H45564157 Then
                Throw New Exception("This is not a WAVE file!")
            End If

            ' read fmt chunk
            If reader.ReadUInt32() <> &H20746D66 Then
                Throw New Exception("Expected fmt chunk!")
            End If
            If reader.ReadInt32() <> 16 Then
                Throw New Exception("Invalid fmt chunk!")
            End If
            If reader.ReadInt16() <> 1 Then
                ' only PCM format allowed
                Throw New Exception("Cry must be in PCM format!")
            End If
            If reader.ReadInt16() <> 1 Then
                ' only 1 channel allowed
                Throw New Exception("Cry cannot have more than one channel!")
            End If
            CryToLoad.SampleRate = reader.ReadInt32()
            If reader.ReadInt32() <> CryToLoad.SampleRate Then
                Throw New Exception("Invalid fmt chunk!")
            End If
            reader.ReadUInt16()
            Dim bitsPerSample = reader.ReadUInt16()
            If bitsPerSample <> 8 Then
                ' for now, only 8 bit PCM data
                Throw New Exception("Cries must be 8-bit WAVE files! Got {bitsPerSample}-bit instead.")
            End If

            ' data chunk
            If reader.ReadUInt32() <> &H61746164 Then
                Throw New Exception("Expected data chunk!!")
            End If
            Dim dataSize = reader.ReadInt32()

            CryToLoad.Data = New SByte(dataSize - 1) {}
            For i As Integer = 0 To dataSize - 1
                ' read 8-bit unsigned PCM and convert to GBA signed form
                CryToLoad.Data(i) = CSByte(reader.ReadByte() - 128)
            Next
        End Using

        ' resetting some other properties just in case
        CryToLoad.Looped = False
        CryToLoad.LoopStart = 0

        Return CryToLoad

    End Function


    Public Function SaveCry(crytosave As Cry, cryTable As Integer) As Boolean

        If crytosave.Offset = 0 Then
            Return False
        End If
        'var lookup = new byte[] { 0x0, 0x1, 0x4, 0x9, 0x10, 0x19, 0x24, 0x31, 0xC0, 0xCF, 0xDC, 0xE7, 0xF0, 0xF7, 0xFC, 0xFF };
        Dim lookup = New SByte() {0, 1, 4, 9, 16, 25, _
            36, 49, -64, -49, -36, -25, _
            -16, -9, -4, -1}

        crytosave.Compressed = False

        ' copy cry data to be written
        Dim data = New List(Of Byte)()
        If crytosave.Compressed Then

            MsgBox("This should not be enabled!")
            End

            '' data is compressed in blocks of 1 + 0x20 bytes at a time
            '' first byte is normal signed PCM data
            '' following 0x20 bytes are compressed based on previous value
            '' (for a value not in lookup table, closest value will be chosen instead)
            ''Console.WriteLine("compressed");

            '' each block has 0x40 samples
            'Dim blockCount = crytosave.Data.Length / &H40
            'If crytosave.Data.Length Mod &H40 > 0 Then
            '    blockCount += 1
            'End If

            '' truncates the length of the last block
            '' so we don't waste space
            'Dim lastBlockSize = crytosave.Data.Length - crytosave.Data.Length / &H40 * &H40
            'If lastBlockSize = 0 Then
            '    lastBlockSize = &H21
            'Else
            '    lastBlockSize = 1 + (lastBlockSize / 2) + (If(lastBlockSize Mod 2 = 0, 0, 1))
            'End If

            'Dim blocks = New Byte(blockCount - 1)() {}
            'For n As Integer = 0 To blockCount - 1
            '    ' create new block
            '    If n < blockCount - 1 Then
            '        blocks(n) = New Byte(32) {}
            '    Else
            '        blocks(n) = New Byte(lastBlockSize - 1) {}
            '    End If

            '    Dim i As Integer = n * &H40
            '    Dim k As Integer = 0

            '    If i < crytosave.Data.Length Then
            '        ' set first value
            '        blocks(n)(k) = BitConverter.GetBytes(crytosave.Data(i))(0)
            '    End If

            '    k = k + 1

            '    Dim pcm As SByte

            '    If i < crytosave.Data.Length Then

            '        pcm = crytosave.Data(i)

            '    End If

            '    i = i + 1

            '    Dim j As Integer = 1
            '    While j < &H40 And i < crytosave.Data.Length
            '        ' get current sample
            '        Dim sample As SByte = crytosave.Data(i)

            '        i = i + 1

            '        ' difference between previous sample and this
            '        Dim diff As Integer = sample - pcm

            '        ' check for a perfect match in lookup table
            '        Dim lookupI = -1
            '        For x As Integer = 0 To 15
            '            If lookup(x) = diff Then
            '                lookupI = x
            '                Exit For
            '            End If
            '        Next

            '        ' search for the closest match in the table
            '        If lookupI = -1 Then
            '            Dim bestDiff As Integer = 255
            '            For x As Integer = 0 To 15
            '                If Math.Abs(CInt(lookup(x)) - diff) < bestDiff Then
            '                    lookupI = x
            '                    bestDiff = Math.Abs(lookup(x) - diff)
            '                End If
            '            Next
            '        End If

            '        ' set value in block
            '        ' on an odd value, increase position in block
            '        If j Mod 2 = 0 Then
            '            blocks(n)(k) = blocks(n)(k) Or CByte(lookupI << 4)
            '        Else
            '            blocks(n)(k) = blocks(n)(k) Or CByte(lookupI)

            '            k = k + 1

            '        End If

            '        ' set previous
            '        pcm = sample
            '        j += 1
            '    End While
            'Next

            'For n As Integer = 0 To blockCount - 1
            '    data.AddRange(blocks(n))
            'Next
        Else
            ' uncompressed, copy directly to data
            'Console.WriteLine("uncompressed");
            For Each s As SByte In crytosave.Data
                data.Add(CByte(s And &HFF))
            Next
        End If

        ' determine if cry requires repointing
        If crytosave.Size < data.Count Then

            Dim result As DialogResult = MessageBox.Show("The Cry will be written to free space and the pointer will be repointed. Would you like to do that?",
                              "Repoint?",
                              MessageBoxButtons.YesNo)

            If (result = DialogResult.Yes) Then

                Dim result2 As DialogResult = MessageBox.Show("Fill the old cry with free space?",
                  "Delete old cry?",
                  MessageBoxButtons.YesNo)

                If (result2 = DialogResult.Yes) Then

                    WriteHEX(LoadedROM, crytosave.Offset, MakeFreeSpaceString(crytosave.Size + 16))

                End If

                ' set new cry offset
                crytosave.Offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, data.Count, "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            Else

                Return False

            End If

        End If

        ' write cry


        WriteHEX(LoadedROM, crytosave.Offset, ReverseHEX(VB.Right("0000" & CUShort(If(crytosave.Compressed, 1, 0)), 4)))
        WriteHEX(LoadedROM, crytosave.Offset + 2, ReverseHEX(VB.Right("0000" & CUShort(If(crytosave.Looped, &H4000, 0)), 4)))
        WriteHEX(LoadedROM, crytosave.Offset + 4, ReverseHEX(VB.Right("00000000" & (crytosave.SampleRate << 10), 8)))
        WriteHEX(LoadedROM, crytosave.Offset + 8, ReverseHEX(VB.Right("00000000" & (crytosave.LoopStart), 8)))
        WriteHEX(LoadedROM, crytosave.Offset + 12, ReverseHEX(VB.Right("00000000" & (crytosave.Data.Length - 1), 8)))

        'WriteHEX(LoadedROM, crytosave.Offset, ReverseHEX(VB.Right("0000" & CUShort(If(crytosave.Compressed, 1, 0)), 4)))
        'WriteHEX(LoadedROM, crytosave.Offset + 2, ReverseHEX(VB.Right("0000" & CUShort(If(crytosave.Looped, &H4000, 0)), 4)))
        'WriteHEX(LoadedROM, crytosave.Offset + 4, ReverseHEX(VB.Right("00000000" & (crytosave.SampleRate << 10), 8)))
        'WriteHEX(LoadedROM, crytosave.Offset + 8, ReverseHEX(VB.Right("00000000" & (crytosave.LoopStart), 8)))
        'WriteHEX(LoadedROM, crytosave.Offset + 12, ReverseHEX(VB.Right("00000000" & (crytosave.Data.Length - 1), 8)))

        Dim tempbuff As String = ByteArrayToHexString(data.ToArray)

        WriteHEX(LoadedROM, crytosave.Offset + 16, tempbuff)

        ' write cry table entry

        'WriteHEX(LoadedROM, cryTable + (crytosave.Index * 12), ReverseHEX(If(crytosave.Compressed, "00003C20", "00003C00")))
        'WriteHEX(LoadedROM, cryTable + (crytosave.Index * 12) + 4, ReverseHEX(VB.Right("00000000" & Hex(crytosave.Offset), 8)))
        'WriteHEX(LoadedROM, cryTable + (crytosave.Index * 12) + 8, "FF00FF")


        'rom.WriteUInt16(CUShort(If(Cry.Compressed, 1, 0)))
        'rom.WriteUInt16(CUShort(If(Cry.Looped, &H4000, 0)))
        'rom.WriteInt32(Cry.SampleRate << 10)
        'rom.WriteInt32(Cry.LoopStart)
        'rom.WriteInt32(Cry.Data.Length - 1)
        'rom.WriteBytes(data.ToArray())

        '' write cry table entry
        'rom.Seek(cryTable + Cry.Index * 12)
        'rom.WriteUInt32(If(Cry.Compressed, &H3C20UI, &H3C00UI))
        'rom.WritePointer(Cry.Offset)
        'rom.WriteUInt32(&HFF00FFUI)

        '' write growl table entry
        'rom.Seek(growlTable + Cry.Index * 12)
        'rom.WriteUInt32(If(Cry.Compressed, &H3C30UI, &H3C00UI))
        '' !!! not sure if 00 should be used for uncompressed
        'rom.WritePointer(Cry.Offset)
        'rom.WriteUInt32(&HFF00FFUI)
        Return True
    End Function

End Module
