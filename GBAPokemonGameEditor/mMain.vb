Imports System.IO



Module mMain

    Public LoadedROM As String
    Public AppPath As String = System.AppDomain.CurrentDomain.BaseDirectory() & IIf(Right(System.AppDomain.CurrentDomain.BaseDirectory(), 1) = "\", "", "\")
    Public i As Integer
    Public FileNum As Integer
    Public header As String = "xxxx"
    Public header2 As String
    Public header3 As String
    Public lwut As String
    Public SkipVar As Integer
    Public x As Integer

    'For Map Edit
    Public Point2MapBankPointers As String
    Public MapBankPointers As String
    Public HeaderPointer As String
    Public MapBank As String
    Public MapNumber As String
    Public BankOffset As String
    Public HeaderOffset As String
    Public MapData As String
    Public Const TileSetSize As Integer = 16
    Public Const TileSize As Integer = 8 'constant used for tile sizes.
    Public Const TileWidth As Integer = 8
    Public Const TilesPerRow As Integer = 16

    'These are all the buffers for creating the graphics for the tilesets.
    Public TilesBackbuffer As Bitmap
    Public TilesetMapBackbuffer As Bitmap
    Public TilesGraphics As Graphics
    Public TilesetMapGraphics As Graphics
    Public TilesBackbuffer2 As Bitmap
    Public TilesetMapBackbuffer2 As Bitmap
    Public TilesGraphics2 As Graphics
    Public TilesetMapGraphics2 As Graphics

    'These are variables for keeping track of which tile is selected in the tile editor
    Public TileEditorTilesCurrentTile As Integer
    Public TileEditorTilesetCurrentTile As Integer

    'These are arrays that keep track of which tiles go where.
    'There are two because I am using two picture boxes.
    'I do not know how to draw two images and over lay them to the same picturebox.
    'I figured it would be easier to just overlay two pictureboxes.
    'I just noticed that pictureboxes have a background image... Hmm...
    Public TilesetBottomLayer As Integer(,)
    Public TilesetTopLayer As Integer(,)
    Public TilesetHeight As Integer
    Public TilesetWidth As Integer

    'These are the buffers for the actual tileset and it's buffers.
    Public TilesetBackbuffer As Bitmap
    Public MapBackbuffer As Bitmap
    Public TilesetGraphics As Graphics
    Public MapGraphics As Graphics

    'This keeps track of current tiles in the map editor.
    Public MapEditorTilesetCurrentTile As Integer
    Public MapEditorMapCurrentTile As Integer

    'This keeps track of the images for the map.
    'The Map variable is very important cause it is the one used for saving.
    Public Map As Integer(,)
    Public MapTiles1 As Integer(,)
    Public MapTiles2 As Integer(,)


    Public Function GetINIFileLocation()

        If System.IO.File.Exists((LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini") = True Then

            Return (LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini"
        Else

            Return AppPath & "ini\roms.ini"
        End If

    End Function

    Public Function MakeFreeSpaceString(NeededLength As Integer, Optional NeedByteString As String = "FF")

        Dim PrivLoopVar As Integer
        Dim OutBuffThing As String = ""

        PrivLoopVar = 0

        While (PrivLoopVar < NeededLength)

            OutBuffThing = OutBuffThing & NeedByteString

            PrivLoopVar = PrivLoopVar + 1
        End While

        MakeFreeSpaceString = OutBuffThing
    End Function

    Public Function DecapString(input As String) As String

        Dim LoopVar As Integer
        Dim outputstring As String = ""
        Dim capflag As Boolean = True

        LoopVar = 0

        While LoopVar < Len(input)

            LoopVar = LoopVar + 1

            If GetChar(input, LoopVar) = " " Then
                outputstring = outputstring & " "
                capflag = True
            Else
                If capflag = True Then

                    outputstring = outputstring & UCase(GetChar(input, LoopVar))
                    capflag = False

                ElseIf capflag = False

                    outputstring = outputstring & LCase(GetChar(input, LoopVar))

                End If
            End If

        End While

        DecapString = outputstring
    End Function

    Public Sub OutPutError(message As String)

        Dim errorfile As String = AppPath & "errors.txt"

        System.IO.File.AppendAllText(errorfile, message & vbCrLf)

    End Sub

    Public Function ByteToSignedInt(InputByte As Byte) As Integer
        Dim ReturnVar As Integer


        If InputByte > &H7F Then
            Dim BinaryVar As String = (Convert.ToString(InputByte, 2))
            ReturnVar = ((Convert.ToInt32(Mid(BinaryVar, 2, 7), 2)) - 128)
        Else
            ReturnVar = InputByte
        End If

        ByteToSignedInt = ReturnVar

    End Function

    Public Function SignedIntToHex(InputInt As Integer) As String

        Dim ReturnVar As String


        If InputInt < 0 Then

            Dim BinaryVar As String = (Convert.ToString(InputInt + 128, 2))
            BinaryVar = "1" & BinaryVar
            ReturnVar = Hex((Convert.ToInt32(BinaryVar, 2)))

        Else
            ReturnVar = Hex(InputInt)
        End If

        SignedIntToHex = ReturnVar

    End Function

    Public Function ByteArrayToHexString(inputarray As Byte()) As String

        Dim HexString As String = ""

        For Each b As Byte In inputarray
            HexString = HexString & MakeProperByte(b)
        Next

        ByteArrayToHexString = HexString
    End Function

    Public Function MakeProperByte(DaByte As Byte) As String
        Dim OutputByte As String


        If Len(Hex(DaByte)) = 1 Then
            OutputByte = "0" & Hex(DaByte)
        Else
            OutputByte = Hex(DaByte)
        End If

        MakeProperByte = OutputByte

    End Function

    Public Function PokedexNumbertoSpecies(DexNumber As Integer)
        Dim curval As Integer = 0

        Dim bytesloaded As Byte()

        bytesloaded = IO.File.ReadAllBytes(LoadedROM)

        ' If DexNumber = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((DexNumber - 1) * 2), 2))), System.Globalization.NumberStyles.HexNumber) Then
        If DexNumber = Int32.Parse((ReverseHEX(Get2Bytes(bytesloaded, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((DexNumber - 1) * 2)))), System.Globalization.NumberStyles.HexNumber) Then

            curval = DexNumber - 1

        Else
            '  While DexNumber <> Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (curval * 2), 2))), System.Globalization.NumberStyles.HexNumber)
            While DexNumber <> Int32.Parse((ReverseHEX(Get2Bytes(bytesloaded, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (curval * 2)))), System.Globalization.NumberStyles.HexNumber)

                curval = curval + 1
            End While
        End If
        PokedexNumbertoSpecies = curval + 1
    End Function

    Public Function Get2Bytes(bytesin As Byte(), local As Integer) As String

        Get2Bytes = MakeProperByte(bytesin(local)) & MakeProperByte(bytesin(local + 1))

    End Function

    Public Function SpeciestoDexNum(species As Integer)


        SpeciestoDexNum = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((species - 1) * 2), 2))), System.Globalization.NumberStyles.HexNumber)
    End Function

End Module
