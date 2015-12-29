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
    'I figured it would be easier to just overlay to pictureboxes.
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


End Module
