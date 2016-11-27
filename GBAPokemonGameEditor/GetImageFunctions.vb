Imports System
Imports System.IO

Module GetImageFunctions

    Public Function DrawBlockToTile(ByVal Destination As Bitmap, ByVal Source As Bitmap, ByVal BlockNum As Integer, ByVal yflip As Integer, ByVal xflip As Integer, ByVal Tile As Integer, ByVal section As Integer) As Bitmap
        Dim Output As Bitmap = Destination
        Dim PixelColor As Color

        Dim HeightLoop As Integer
        Dim HeightCounter As Integer

        Dim TileAgain As Integer

        Dim xdes As Integer
        Dim ydes As Integer
        Dim xsrc As Integer
        Dim ysrc As Integer
        Dim x As Integer
        Dim y As Integer

        'For destination


        HeightLoop = Tile
        HeightCounter = 0

        While HeightLoop > 7

            HeightLoop = HeightLoop - 8
            HeightCounter = HeightCounter + 1

        End While

        ydes = (HeightCounter * 16) '+ (section * 8)

        xdes = ((Tile - (HeightCounter * 8)) * 16) '+ (section * 8)

        If section = 1 Then
            xdes = xdes + 8
        ElseIf section = 2 Then
            ydes = ydes + 8
        ElseIf section = 3 Then
            xdes = xdes + 8
            ydes = ydes + 8
        End If

        'For the source
        If BlockNum < 512 Then

            TileAgain = BlockNum

        Else

            TileAgain = BlockNum - 512

        End If

        HeightLoop = TileAgain
        HeightCounter = 0

        While HeightLoop > 15

            HeightLoop = HeightLoop - 16
            HeightCounter = HeightCounter + 1

        End While

        ysrc = HeightCounter * 8

        xsrc = (TileAgain - (HeightCounter * 16)) * 8


        If xflip = 0 And yflip = 0 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes) + x, (ydes) + y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 1 And yflip = 0 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes + 7) - x, (ydes) + y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 0 And yflip = 1 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes) + x, (ydes + 7) - y, PixelColor)

                Next y

            Next x
        End If

        If xflip = 1 And yflip = 1 Then

            For x = 0 To 7
                For y = 0 To 7
                    PixelColor = Source.GetPixel((xsrc) + x, (ysrc) + y)

                    Output.SetPixel((xdes + 7) - x, (ydes + 7) - y, PixelColor)

                Next y

            Next x
        End If
        DrawBlockToTile = Output
    End Function

    Public Sub GetAndDrawItemPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) + 4
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 24, 24, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawFrontPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetFrontPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetFrontPokemonPicToBitmap = bSprite

    End Function

    Public Function GetShinyFrontPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetShinyFrontPokemonPicToBitmap = bSprite

    End Function

    Public Function GetFrontPokemonPicToByteArray(ByVal index As Integer) As Byte()
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using
        bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        LoadBitmapFromArray(Image, Palette32, bSprite, 64, 64)
        'bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        GetFrontPokemonPicToByteArray = SaveBitmapToArray(bSprite, Palette32)

    End Function

    Public Sub GetAndDrawFrontPokemonPicBLACK(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
                Palette32(1) = Color.Black
                Palette32(2) = Color.Black
                Palette32(3) = Color.Black
                Palette32(4) = Color.Black
                Palette32(5) = Color.Black
                Palette32(6) = Color.Black
                Palette32(7) = Color.Black
                Palette32(8) = Color.Black
                Palette32(9) = Color.Black
                Palette32(10) = Color.Black
                Palette32(11) = Color.Black
                Palette32(12) = Color.Black
                Palette32(13) = Color.Black
                Palette32(14) = Color.Black
                Palette32(15) = Color.Black
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawFrontPokemonPicShiny(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonFrontSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawBackPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetBackPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetBackPokemonPicToBitmap = bSprite

    End Function

    Public Function GetNormalBackPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, ShowBackcolor)
        GetNormalBackPokemonPicToBitmap = bSprite

    End Function

    Public Sub GetAndDrawBackPokemonPicNormal(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonBackSprites", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawAnimationPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetNormalAnimationPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, ShowBackcolor)
        GetNormalAnimationPokemonPicToBitmap = bSprite

    End Function

    Public Function GetShinyAnimationPokemonPicToBitmap(ByVal index As Integer, Optional ShowBackcolor As Boolean = True) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, ShowBackcolor)
        GetShinyAnimationPokemonPicToBitmap = bSprite

    End Function

    Public Function GetAnimationPicToByteArray(ByVal index As Integer) As Byte()
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonNormalPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using
        bSprite = LoadSprite(Image, Palette32, 64, 128, 0)
        LoadBitmapFromArray(Image, Palette32, bSprite, 64, 128)
        'bSprite = LoadSprite(Image, Palette32, 64, 64, 0)
        GetAnimationPicToByteArray = SaveBitmapToArray(bSprite, Palette32)

    End Function

    Public Sub GetAndDrawAnimationPokemonPicShiny(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonAnimations", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "PokemonShinyPal", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawShadowAnimationPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowFronts", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 128, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawBackShadowPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowBacks", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawShadowFrontPokemonPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowFronts", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon front sprites, + 8 = Bulbasaur.
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ShadowPals", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8) 'Pointer to Pokemon normal palettes, + 8 = Bulbasaur.
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function LoadPalette(ByVal Bits() As Byte) As Color()
        Dim Temp As UShort
        Dim Colors(15) As Color
        Dim C1 As Byte
        Dim C2 As Byte
        Dim R As UShort, G As UShort, B As UShort
        Dim i As Byte

        For i = 0 To &H1F Step 2
            C1 = Bits(i)
            C2 = Bits(i + 1)
            Temp = C2 * &H100 + C1

            R = (Temp And &H1F) * &H8
            G = (Temp And &H3E0) / &H4
            B = (Temp And &H7C00) / &H80

            Colors(i / 2) = Color.FromArgb(&HFF, R, G, B)
        Next

        LoadPalette = Colors
    End Function

    Public Function LoadSprite(ByRef Bits() As Byte, ByVal Palette() As Color, Optional ByVal Width As Integer = 64, Optional ByVal Height As Integer = 64, Optional ByVal ShowBackColor As Boolean = True) As Bitmap
        On Error GoTo ErrorHandle
        Dim x1 As Integer, y1 As Integer
        Dim x2 As Integer, y2 As Integer
        Dim bmpTiles As New Bitmap(Width, Height)
        Dim Temp As Byte
        Dim i As Integer

        For y1 = 0 To Height - 8 Step 8
            For x1 = 0 To Width - 8 Step 8
                For y2 = 0 To 7
                    For x2 = 0 To 7 Step 2
                        Temp = Bits(i)
                        If ShowBackColor = True Then
                            bmpTiles.SetPixel(x1 + x2 + 1, y1 + y2, Palette((Temp And &HF0) / &H10))
                            bmpTiles.SetPixel(x1 + x2, y1 + y2, Palette(Temp And &HF))
                        Else

                            ' If Temp And &HF0 <> 0 Then
                            If Palette((Temp And &HF0) / &H10) <> Palette(0) Then


                                'MsgBox(Temp And &HF0)
                                ' MsgBox("hit")
                                bmpTiles.SetPixel(x1 + x2 + 1, y1 + y2, Palette((Temp And &HF0) / &H10))

                            End If
                            If Palette((Temp And &HF)) <> Palette(0) Then
                                ' If Temp And &HF <> 0 Then
                                '  MsgBox("hit")

                                bmpTiles.SetPixel(x1 + x2, y1 + y2, Palette((Temp And &HF)))

                            End If
                        End If
                        i = i + 1
                    Next
                Next
            Next
        Next

        LoadSprite = bmpTiles
ErrorHandle:
    End Function

    Public Sub GetAndDrawPokemonIconPic(ByVal picBox As PictureBox, ByVal index As Integer, ByVal palindex As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber) + (palindex * 32)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Image)
                Image = Temp

                ReDim Temp(&HFFF)
                'fs.Position = pOffset
                'pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 32, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetAndDrawPokemonIconToBitmap(ByVal index As Integer, ByVal palindex As Integer, Optional ShowBackColor As Boolean = False) As Bitmap

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber) + (palindex * 32)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Image)
                Image = Temp

                ReDim Temp(&HFFF)
                'fs.Position = pOffset
                'pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                'LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Temp)
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 32, 64, ShowBackColor)
        GetAndDrawPokemonIconToBitmap = bSprite

    End Function

    Public Function Load2BPSprite16By16(ByRef Bits() As Byte, ByVal Palette() As Color) As Bitmap

        Dim bmpTiles As New Bitmap(16, 16)

        Dim sideways As Integer = 0
        Dim updown As Integer = 0
        Dim bittrack As Integer = 0
        Dim bytetrack As Integer = 0
        Dim curbit As String
        Dim bitsarray As BitArray
        Dim CurSquare As Integer = 0

        While updown < 16
            While sideways < 8

                bitsarray = New BitArray({Bits(bytetrack)})

                curbit = bitsarray(bittrack)

                If curbit = "False" Then

                    If CurSquare = 0 Then

                        bmpTiles.SetPixel(sideways, updown, Palette(0))

                    End If

                    If CurSquare = 1 Then

                        bmpTiles.SetPixel((CurSquare * 8) + sideways, updown - (CurSquare * 8), Palette(0))

                    End If

                    If CurSquare = 2 Then

                        bmpTiles.SetPixel(sideways, updown + (8), Palette(0))

                    End If

                    If CurSquare = 3 Then

                        bmpTiles.SetPixel((8) + sideways, updown, Palette(0))

                    End If

                ElseIf curbit = "True"

                    If CurSquare = 0 Then

                        bmpTiles.SetPixel(sideways, updown, Palette(1))

                    End If

                    If CurSquare = 1 Then

                        bmpTiles.SetPixel((CurSquare * 8) + sideways, updown - (CurSquare * 8), Palette(1))

                    End If

                    If CurSquare = 2 Then

                        bmpTiles.SetPixel(sideways, updown + (8), Palette(1))

                    End If

                    If CurSquare = 3 Then

                        bmpTiles.SetPixel((8) + sideways, updown, Palette(1))

                    End If

                End If
                bittrack = bittrack + 1
                If bittrack = 8 Then
                    bittrack = 0
                    bytetrack = bytetrack + 1
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

        Load2BPSprite16By16 = bmpTiles
ErrorHandle:
    End Function

    Public Sub GetAndDrawPokemonFootPrint(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "FootPrintTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim Temp(&HFF) As Byte
        Dim Image(&HFF) As Byte
        Dim Palette32(1) As Color
        Dim bSprite As Bitmap

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFF)
                Image = Temp
            End Using
        End Using

        Palette32(0) = Color.Transparent
        Palette32(1) = Color.Black

        bSprite = Load2BPSprite16By16(Image, Palette32)
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Function GetPokemonFootPrintToBitmap(ByVal index As Integer) As Bitmap
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "FootPrintTable", ""), System.Globalization.NumberStyles.HexNumber) + ((index * 4))
        Dim Temp(&HFF) As Byte
        Dim Image(&HFF) As Byte
        Dim Palette32(1) As Color
        Dim bSprite As Bitmap

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFF)
                Image = Temp
            End Using
        End Using

        Palette32(0) = Color.Transparent
        Palette32(1) = Color.Black

        bSprite = Load2BPSprite16By16(Image, Palette32)
        GetPokemonFootPrintToBitmap = bSprite

    End Function

    Public Sub GetAndDrawTrainerPicBLACK(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerImageTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerPaletteTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)
                Palette32(1) = Color.Black
                Palette32(2) = Color.Black
                Palette32(3) = Color.Black
                Palette32(4) = Color.Black
                Palette32(5) = Color.Black
                Palette32(6) = Color.Black
                Palette32(7) = Color.Black
                Palette32(8) = Color.Black
                Palette32(9) = Color.Black
                Palette32(10) = Color.Black
                Palette32(11) = Color.Black
                Palette32(12) = Color.Black
                Palette32(13) = Color.Black
                Palette32(14) = Color.Black
                Palette32(15) = Color.Black
            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub

    Public Sub GetAndDrawTrainerPic(ByVal picBox As PictureBox, ByVal index As Integer)
        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerImageTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "TrainerPaletteTable", ""), System.Globalization.NumberStyles.HexNumber) + (index * 8)
        Dim Temp(&HFFF) As Byte
        Dim Image(&HFFFF) As Byte
        Dim Palette15(&HFFF) As Byte
        Dim Palette32() As Color
        Dim bSprite As Bitmap
        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000
                fs.Position = sOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Image)

                ReDim Temp(&HFFF)
                fs.Position = pOffset
                pOffset = r.ReadInt32 - &H8000000
                fs.Position = pOffset
                r.Read(Temp, 0, &HFFF)
                LZ77UnComp(Temp, Palette15)

                Palette32 = LoadPalette(Palette15)

            End Using
        End Using


        bSprite = LoadSprite(Image, Palette32, 64, 64, GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0"))
        picBox.Image = bSprite
        picBox.Refresh()

    End Sub


End Module
