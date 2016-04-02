Imports VB = Microsoft.VisualBasic
Module ChangeImageFunctions
    Public Sub SaveFrontSpriteToFreeSpace(Pokemonindex As Integer, Sprite As Byte(), pallete As Color())
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (Pokemonindex * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (Pokemonindex * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.

        Dim ImgString As String
        Dim PalString As String

        Dim ImgBytes As Byte()
        Dim PalBytes As Byte()

        Dim ImgNewOffset As String
        Dim PalNewOffset As String

        ImgBytes = ConvertStringToByteArray(CompressLz77String(ConvertByteArrayToString(Sprite)))
        PalBytes = ConvertStringToByteArray(CompressLz77String(ConvertPaletteToString(pallete)))

        ImgString = ByteArrayToHexString(ImgBytes)
        PalString = ByteArrayToHexString(PalBytes)

        ImgNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(ImgString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, ImgNewOffset, ImgString)

        WriteHEX(LoadedROM, sOffset, ReverseHEX(Hex((ImgNewOffset) + &H8000000)))

        PalNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(PalString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, PalNewOffset, PalString)

        WriteHEX(LoadedROM, pOffset, ReverseHEX(Hex((PalNewOffset) + &H8000000)))

    End Sub

    Public Sub SaveBackSpriteToFreeSpace(Pokemonindex As Integer, Sprite As Byte(), pallete As Color())
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (Pokemonindex * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (Pokemonindex * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.

        Dim ImgString As String
        Dim PalString As String

        Dim ImgBytes As Byte()
        Dim PalBytes As Byte()

        Dim ImgNewOffset As String
        Dim PalNewOffset As String

        ImgBytes = ConvertStringToByteArray(CompressLz77String(ConvertByteArrayToString(Sprite)))
        PalBytes = ConvertStringToByteArray(CompressLz77String(ConvertPaletteToString(pallete)))

        ImgString = ByteArrayToHexString(ImgBytes)
        PalString = ByteArrayToHexString(PalBytes)

        ImgNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(ImgString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, ImgNewOffset, ImgString)

        WriteHEX(LoadedROM, sOffset, ReverseHEX(Hex((ImgNewOffset) + &H8000000)))

        PalNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(PalString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, PalNewOffset, PalString)

        WriteHEX(LoadedROM, pOffset, ReverseHEX(Hex((PalNewOffset) + &H8000000)))

    End Sub

    Public Sub SaveAnimationSpriteToFreeSpace(Pokemonindex As Integer, Sprite As Byte())
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (Pokemonindex * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.

        Dim ImgString As String

        Dim ImgBytes As Byte()

        Dim ImgNewOffset As String


        ImgBytes = ConvertStringToByteArray(CompressLz77String(ConvertByteArrayToString(Sprite)))

        ImgString = ByteArrayToHexString(ImgBytes)

        ImgNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(ImgString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, ImgNewOffset, ImgString)

        WriteHEX(LoadedROM, sOffset, ReverseHEX(Hex((ImgNewOffset) + &H8000000)))


    End Sub

    Public Function ConvertFootPrintImageToHexString(Image As Bitmap) As String

        Dim OutPutBuffer0 As String = ""
        Dim OutPutBuffer1 As String = ""
        Dim OutPutBuffer2 As String = ""
        Dim OutPutBuffer3 As String = ""
        Dim BitBuffer0 As String = ""
        Dim BitBuffer1 As String = ""
        Dim BitBuffer2 As String = ""
        Dim BitBuffer3 As String = ""
        Dim Palette2 As Color

        Dim sideways As Integer = 0
        Dim updown As Integer = 0
        Dim CurSquare As Integer = 0

        Palette2 = Image.GetPixel(sideways, updown)

        While updown < 16
            While sideways < 8

                If CurSquare = 0 Then

                    If Image.GetPixel(sideways, updown) = Palette2 Then
                        BitBuffer0 = BitBuffer0 & 0
                    Else
                        BitBuffer0 = BitBuffer0 & 1

                    End If

                End If

                If CurSquare = 1 Then

                    If Image.GetPixel((CurSquare * 8) + sideways, updown - (CurSquare * 8)) = Palette2 Then
                        BitBuffer1 = BitBuffer1 & 0
                    Else
                        BitBuffer1 = BitBuffer1 & 1

                    End If

                End If

                If CurSquare = 2 Then

                    If Image.GetPixel(sideways, updown + (8)) = Palette2 Then
                        BitBuffer2 = BitBuffer2 & 0
                    Else
                        BitBuffer2 = BitBuffer2 & 1

                    End If

                End If

                If CurSquare = 3 Then

                    If Image.GetPixel((8) + sideways, updown) = Palette2 Then
                        BitBuffer3 = BitBuffer3 & 0
                    Else

                        BitBuffer3 = BitBuffer3 & 1

                    End If

                End If

                If Len(BitBuffer0) = 8 Then
                    OutPutBuffer0 = OutPutBuffer0 & VB.Right("00" & Hex(Convert.ToInt32(BitBuffer0, 2)), 2)
                    BitBuffer0 = ""
                End If

                If Len(BitBuffer1) = 8 Then
                    OutPutBuffer1 = OutPutBuffer1 & VB.Right("00" & Hex(Convert.ToInt32(BitBuffer1, 2)), 2)
                    BitBuffer1 = ""
                End If

                If Len(BitBuffer2) = 8 Then
                    OutPutBuffer2 = OutPutBuffer2 & VB.Right("00" & Hex(Convert.ToInt32(BitBuffer2, 2)), 2)
                    BitBuffer2 = ""
                End If

                If Len(BitBuffer3) = 8 Then
                    OutPutBuffer3 = OutPutBuffer3 & VB.Right("00" & Hex(Convert.ToInt32(BitBuffer3, 2)), 2)
                    BitBuffer3 = ""
                End If

                sideways = sideways + 1
            End While

            sideways = 0

            If updown = 7 And CurSquare = 0 Then
                CurSquare = CurSquare + 1
            End If

            If updown = 15 And CurSquare = 1 Then
                CurSquare = CurSquare + 1
                updown = -1
            End If

            If updown = 7 And CurSquare = 2 Then
                CurSquare = CurSquare + 1

            End If

            If updown = 15 And CurSquare = 3 Then
                CurSquare = CurSquare + 1
            End If

            updown = updown + 1

        End While


        ConvertFootPrintImageToHexString = OutPutBuffer1 & OutPutBuffer0 & OutPutBuffer3 & OutPutBuffer2
    End Function

End Module
