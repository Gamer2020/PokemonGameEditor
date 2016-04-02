Imports System.IO
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic
Module ImportDataFunctions

    Private FrontPalette As Color() = New Color(&H11 - 1) {}
    Private BackPalette As Color() = New Color(&H11 - 1) {}

    Private FrontSprite As Byte()
    Private BackSprite As Byte()

    Private AnimationNormalPalette As Color() = New Color(&H11 - 1) {}
    Private AnimationShinyPalette As Color() = New Color(&H11 - 1) {}

    Private AnimationNormalSprite As Byte()
    Private AnimationShinySprite As Byte()

    Public Sub ImportPokemonINI(INIFileName As String, PokemonIndex As Integer)

        'Declare vars

        Dim BaseStats As String

        Dim PlayerY As String
        Dim EnemyY As String
        Dim EnemyAlt As String

        Dim ItemAnimation As String = ""

        Dim EvolutionData As String

        Dim lvlupattacksoffset As String = ""
        Dim lvlupattacks As String = ""

        Dim MoveTutorCompatibility As String = ""

        Dim TMHMCompatibility As String

        Dim NationalDexNumber As String
        Dim SecondDexNumber As String

        Dim Pointer1 As String = ""
        Dim PokedexDescription As String = ""
        Dim PokedexDescriptionOff As String = ""
        Dim Hght As String = ""
        Dim Wght As String = ""
        Dim Scale1 As String = ""
        Dim Scale2 As String = ""
        Dim Offset_1 As String = ""
        Dim Offset_2 As String = ""
        Dim PokedexType As String = ""


        'Load data

        ChangePokemonName(PokemonIndex, GetString(INIFileName, "Pokemon", "PokemonName", "?"))

        BaseStats = GetString(INIFileName, "Pokemon", "BaseStats", "2D31312D41410C032D400001000000001F1446030107410000030000")

        PlayerY = GetString(INIFileName, "Pokemon", "PlayerY", "00")
        EnemyY = GetString(INIFileName, "Pokemon", "EnemyY", "00")
        EnemyAlt = GetString(INIFileName, "Pokemon", "EnemyAlt", "00")

        If header2 = "BPR" Or header2 = "BPG" Then
            ItemAnimation = GetString(INIFileName, "Pokemon", "ItemAnimation", "161B301629")
        End If

        EvolutionData = GetString(INIFileName, "Pokemon", "EvolutionData", MakeFreeSpaceString((8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))), "00"))

        If (Len(EvolutionData) / 2) > (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) Then
            EvolutionData = EvolutionData.Remove((8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) * 2)
        End If

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then
            lvlupattacks = GetString(INIFileName, "Pokemon", "LevelUpAttacksOriginal", "2102FFFF0000")
        ElseIf GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "True" Then
            lvlupattacks = GetString(INIFileName, "Pokemon", "LevelUpAttacksJambo51", "2100010000FF00")
        End If

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then
            MoveTutorCompatibility = GetString(INIFileName, "Pokemon", "MoveTutorCompatibility", MakeFreeSpaceString((((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)), "00"))

            If (Len(MoveTutorCompatibility) / 2) > (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) Then
                MoveTutorCompatibility = MoveTutorCompatibility.Remove((((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8) * 2))
            End If

        End If

        TMHMCompatibility = GetString(INIFileName, "Pokemon", "TMHMCompatibility", MakeFreeSpaceString((Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))), "00"))

        If (Len(TMHMCompatibility) / 2) > (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))) Then
            TMHMCompatibility = TMHMCompatibility.Remove((Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))) * 2)
        End If

        If header2 = "AXP" Or header2 = "AXV" Then
            SkipVar = "36"
        ElseIf header2 = "BPR" Or header2 = "BPG" Then
            SkipVar = "36"
        ElseIf header2 = "BPE" Then
            SkipVar = "32"
        End If

        NationalDexNumber = GetString(INIFileName, "Pokemon", "NationalDexNumber", "0")
        SecondDexNumber = GetString(INIFileName, "Pokemon", "SecondDexNumber", "0")

        If NationalDexNumber < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then
            PokedexDescription = Asc2Sapp(GetString(INIFileName, "Pokemon", "PokedexDescription", "Description\x")) & " "
            Hght = GetString(INIFileName, "Pokemon", "Hght", "1")
            Wght = GetString(INIFileName, "Pokemon", "Wght", "1")
            Scale1 = GetString(INIFileName, "Pokemon", "Scale1", "256")
            Scale2 = GetString(INIFileName, "Pokemon", "Scale2", "256")
            Offset_1 = GetString(INIFileName, "Pokemon", "Offset_1", "0")
            Offset_2 = GetString(INIFileName, "Pokemon", "Offset_2", "0")
            PokedexType = GetString(INIFileName, "Pokemon", "PokedexType", "Seed")
        End If

        'Write data to ROM.

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonData", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 28), BaseStats)

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PlayerYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PokemonIndex * 4), PlayerY)
        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PokemonIndex * 4), EnemyY)
        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyAltitudeTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 1), EnemyAlt)

        If header2 = "BPR" Or header2 = "BPG" Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ItemAnimationTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 5), ItemAnimation)
        End If

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonEvolutions", "")), System.Globalization.NumberStyles.HexNumber)) + ((PokemonIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))), EvolutionData)

        lvlupattacksoffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(lvlupattacks) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, lvlupattacksoffset, lvlupattacks)

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 4), ReverseHEX(Hex(((lvlupattacksoffset)) + &H8000000)))

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) + ((PokemonIndex - 1) * (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))), MoveTutorCompatibility)
        End If

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TMHMCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))), TMHMCompatibility)

        If NationalDexNumber < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then

            If header2 = "AXP" Or header2 = "AXV" Then

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 2 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght), 4)))

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2), 4)))

            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 2 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght), 4)))

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2), 4)))


                PokedexDescriptionOff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(PokedexDescription)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                FileNum = FreeFile()

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FilePut(FileNum, PokedexDescription, ("&H" & Hex(PokedexDescriptionOff)) + 1, False)

                FileClose(FileNum)

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(Hex(Val("&H" & (Hex(PokedexDescriptionOff))) + &H8000000)))


            ElseIf header2 = "BPE" Then

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 2 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght), 4)))

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 22 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 24 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2), 4)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2), 4)))


                PokedexDescriptionOff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(PokedexDescription)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                FileNum = FreeFile()

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FilePut(FileNum, PokedexDescription, ("&H" & Hex(PokedexDescriptionOff)) + 1, False)

                FileClose(FileNum)

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(Hex(Val("&H" & (Hex(PokedexDescriptionOff))) + &H8000000)))


            End If

            ChangePokedexTypeName(NationalDexNumber, PokedexType)

        End If

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 2), ReverseHEX(VB.Right("0000" & Hex(NationalDexNumber), 4)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SecondDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 2), ReverseHEX(VB.Right("0000" & Hex(SecondDexNumber), 4)))

    End Sub

    Public Sub ImportAbilityINI(INIFileName As String, AbilityIndex As Integer)

        Dim AbilityDescriptionTable As Integer
        Dim CurAbilityDescriptionPointer As String
        Dim destowrite As String

        AbilityDescriptionTable = Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

        CurAbilityDescriptionPointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AbilityDescriptionTable) + (AbilityIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim AbDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, AbDescp, Int32.Parse(((CurAbilityDescriptionPointer)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        AbDescp = Sapp2Asc(AbDescp)
        AbDescp = Mid$(AbDescp, 1, InStr(1, AbDescp, "\x"))
        'AbDescp = Replace(AbDescp, "\n", vbCrLf)
        'AbDescp = Replace(RTrim$(AbDescp), "\", "")
        AbDescp = AbDescp & "x"
        FileClose(FileNum)

        ChangeAbilityName(AbilityIndex, GetString(INIFileName, "Ability", "AbilityName", "STENCH"))

        If Len(Asc2Sapp(AbDescp)) < Len(Asc2Sapp(GetString(INIFileName, "Ability", "AbilityDescription", "Description"))) Then

            destowrite = Asc2Sapp(GetString(INIFileName, "Ability", "AbilityDescription", "Description"))


            Dim newtextoff As String

            newtextoff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(destowrite & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite & " ", ("&H" & Hex(newtextoff)) + 1, False)

            FileClose(FileNum)

            WriteHEX(LoadedROM, (AbilityDescriptionTable) + (AbilityIndex * 4), ReverseHEX(Hex(Val("&H" & Hex(newtextoff)) + &H8000000)))

        Else

            destowrite = Asc2Sapp(GetString(INIFileName, "Ability", "AbilityDescription", "Description"))

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite, ("&H" & CurAbilityDescriptionPointer) + 1, False)

            FileClose(FileNum)

        End If

    End Sub

    Public Sub ImportAttackINI(INIFileName As String, AttackIndex As Integer)

        Dim AttackData As String
        Dim AttackDescriptionTable As Integer
        Dim CurAttackDescriptionPointer As String
        Dim destowrite As String
        Dim ContestMoveData As String

        AttackDescriptionTable = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

        CurAttackDescriptionPointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackDescriptionTable) + ((AttackIndex - 1) * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim ATDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, ATDescp, Int32.Parse(((CurAttackDescriptionPointer)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        ATDescp = Sapp2Asc(ATDescp)
        ATDescp = Mid$(ATDescp, 1, InStr(1, ATDescp, "\x"))
        'AbDescp = Replace(AbDescp, "\n", vbCrLf)
        'ATDescp = Replace(RTrim$(ATDescp), "\", "")
        ATDescp = ATDescp & "x"
        FileClose(FileNum)

        ChangeAttackName(AttackIndex, GetString(INIFileName, "Attack", "AttackName", "?"))

        AttackData = GetString(INIFileName, "Attack", "AttackData", "002800642300000033000000")

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber)) + (AttackIndex * 12), AttackData)


        If Len(Asc2Sapp(ATDescp)) < Len(Asc2Sapp(GetString(INIFileName, "Attack", "AttackDescription", "Description"))) Then

            destowrite = Asc2Sapp(GetString(INIFileName, "Attack", "AttackDescription", "Description"))


            Dim newtextoff As String

            newtextoff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(destowrite & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite & " ", ("&H" & Hex(newtextoff)) + 1, False)

            FileClose(FileNum)

            WriteHEX(LoadedROM, (AttackDescriptionTable) + ((AttackIndex - 1) * 4), ReverseHEX(Hex(Val("&H" & Hex(newtextoff)) + &H8000000)))

        Else

            destowrite = Asc2Sapp(GetString(INIFileName, "Attack", "AttackDescription", "Description"))

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite, ("&H" & CurAttackDescriptionPointer) + 1, False)

            FileClose(FileNum)

        End If


        If header2 = "AXP" Or header2 = "AXV" Or header2 = "BPE" Then

            ContestMoveData = GetString(INIFileName, "Attack", "ContestData", "0000000000000000")

            WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveData", "")), System.Globalization.NumberStyles.HexNumber)) + (AttackIndex * 8), ContestMoveData)

        Else
        End If

    End Sub

    Public Sub ImportAseriesSheet(FileName As String, PokemonIndex As Integer)

        Dim mainbitmap As New Bitmap(FileName)

        FrontSprite = GetFrontPokemonPicToByteArray(PokemonIndex)
        BackSprite = GetFrontPokemonPicToByteArray(PokemonIndex)

        Dim ONormalBackBitmap As Bitmap = New Bitmap(&H40, &H40)
        Dim ONormalFrontBitmap As Bitmap = New Bitmap(&H40, &H40)
        Dim OShinyBackBitmap As Bitmap = New Bitmap(&H40, &H40)
        Dim OShinyFrontBitmap As Bitmap = New Bitmap(&H40, &H40)

        Dim LoadAnimationFlag As Boolean = False

        Dim ONormalBackBitmapAnimation As Bitmap = New Bitmap(&H40, &H40)
        Dim ONormalFrontBitmapAnimation As Bitmap = New Bitmap(&H40, &H80)
        Dim OShinyBackBitmapAnimation As Bitmap = New Bitmap(&H40, &H40)
        Dim OShinyFrontBitmapAnimation As Bitmap = New Bitmap(&H40, &H80)

        If header2 = "BPE" Then

            AnimationNormalSprite = GetAnimationPicToByteArray(PokemonIndex)
            AnimationShinySprite = GetAnimationPicToByteArray(PokemonIndex)

            If mainbitmap.Height = 64 And mainbitmap.Width = 256 Then

                'MsgBox("The Animation seems to be missing. Sheet will be loaded without animations.")

            ElseIf mainbitmap.Height = 128 And mainbitmap.Width = 256 Then
                LoadAnimationFlag = True
            Else

                MsgBox("The dimensions of the file" & FileName & " does not seem correct. Aborting...")
                Exit Sub

            End If

        Else
            If mainbitmap.Height = 64 And mainbitmap.Width = 256 Then
            ElseIf mainbitmap.Height = 128 And mainbitmap.Width = 256 Then

                'MsgBox("Sheet contains animation. The animation will not be loaded for this ROM.")

            Else
                MsgBox("The dimensions of the file" & FileName & " does not seem correct. Aborting...")
                Exit Sub
            End If
        End If

        BitmapBLT(mainbitmap, ONormalFrontBitmap, 0, 0, 0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
        BitmapBLT(mainbitmap, OShinyFrontBitmap, 0, 0, &H40, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
        BitmapBLT(mainbitmap, ONormalBackBitmap, 0, 0, &H80, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
        BitmapBLT(mainbitmap, OShinyBackBitmap, 0, 0, &HC0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

        If LoadAnimationFlag = True Then
            BitmapBLT(mainbitmap, ONormalFrontBitmapAnimation, 0, 0, 0, 0, &H40, &H80, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, OShinyFrontBitmapAnimation, 0, 0, &H40, 0, &H40, &H80, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, ONormalBackBitmapAnimation, 0, 0, &H80, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))
            BitmapBLT(mainbitmap, OShinyBackBitmapAnimation, 0, 0, &HC0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

        End If

        'synchpals

        Dim num As Byte
        Dim palcolor As Color
        Dim flag As Boolean = False

        Array.Clear(FrontPalette, 0, &H10)
        Array.Clear(BackPalette, 0, &H10)

        If LoadAnimationFlag = True Then
            Array.Clear(AnimationNormalPalette, 0, &H10)
            Array.Clear(AnimationShinyPalette, 0, &H10)

        End If

        Dim num11 As Integer = ((1 * &H40) - 1)
        Dim ivar As UInteger = 0
        Do While (ivar <= num11)
            Dim num3 As UInteger = 0
            Do
                palcolor = GetQuantizedPixel(ONormalFrontBitmap, num3, ivar)
                If Not Enumerable.Contains(Of Color)(FrontPalette, palcolor) Then
                    FrontPalette(num) = palcolor
                    BackPalette(num) = GetQuantizedPixel(OShinyFrontBitmap, num3, ivar)
                    num = ((num + 1))
                    If (num > 15) Then
                        flag = True
                        Exit Do
                    End If
                End If
                num3 += 1
            Loop While (num3 <= &H3F)
            If flag Then
                Exit Do
            End If
            ivar += 1
        Loop

        Dim num12 As Integer = ((1 * &H40) - 1)
        Dim j As UInteger = 0
        Do While (j <= num12)
            Dim num5 As UInteger = 0
            Do
                palcolor = GetQuantizedPixel(ONormalBackBitmap, num5, j)
                If Not Enumerable.Contains(Of Color)(FrontPalette, palcolor) Then
                    FrontPalette(num) = palcolor
                    BackPalette(num) = GetQuantizedPixel(OShinyBackBitmap, num5, j)
                    num = ((num + 1))
                    If (num > 15) Then
                        flag = True
                        Exit Do
                    End If
                End If
                num5 += 1
            Loop While (num5 <= &H3F)
            If flag Then
                Exit Do
            End If
            j += 1
        Loop

        Dim num13 As Integer = ((1 * &H40) - 1)
        Dim k As UInteger = 0
        Do While (k <= num13)
            Dim num7 As UInteger = 0
            Do
                palcolor = GetQuantizedPixel(OShinyFrontBitmap, num7, k)
                If Not Enumerable.Contains(Of Color)(BackPalette, palcolor) Then
                    BackPalette(num) = palcolor
                    FrontPalette(num) = GetQuantizedPixel(ONormalFrontBitmap, num7, k)
                    num = CByte((num + 1))
                    If (num > 15) Then
                        flag = True
                        Exit Do
                    End If
                End If
                num7 += 1
            Loop While (num7 <= &H3F)
            If flag Then
                Exit Do
            End If
            k += 1
        Loop

        Dim num14 As Integer = ((1 * &H40) - 1)
        Dim m As UInteger = 0
        Do While (m <= num14)
            Dim num9 As UInteger = 0
            Do
                palcolor = GetQuantizedPixel(OShinyBackBitmap, num9, m)
                If Not Enumerable.Contains(Of Color)(BackPalette, palcolor) Then
                    BackPalette(num) = palcolor
                    FrontPalette(num) = GetQuantizedPixel(ONormalBackBitmap, num9, m)
                    num = CByte((num + 1))
                    If (num > 15) Then
                        flag = True
                        Exit Do
                    End If
                End If
                num9 += 1
            Loop While (num9 <= &H3F)
            If flag Then
                Exit Do
            End If
            m += 1
        Loop

        Dim n As Integer = num
        Do While (n <= 15)
            FrontPalette(n) = Color.Black
            BackPalette(n) = Color.Black
            n += 1
        Loop

        If LoadAnimationFlag = True Then
            AnimationNormalPalette = FrontPalette
            AnimationShinyPalette = BackPalette
        End If

        ConvertBitmapToPalette(ONormalFrontBitmap, FrontPalette, True)
        ConvertBitmapToPalette(OShinyFrontBitmap, BackPalette, True)
        ConvertBitmapToPalette(ONormalBackBitmap, FrontPalette, True)
        ConvertBitmapToPalette(OShinyBackBitmap, BackPalette, True)

        If LoadAnimationFlag = True Then
            ConvertBitmapToPalette(ONormalFrontBitmapAnimation, AnimationNormalPalette, True)
            ConvertBitmapToPalette(OShinyFrontBitmapAnimation, AnimationShinyPalette, True)
            ConvertBitmapToPalette(ONormalBackBitmapAnimation, AnimationNormalPalette, True)
            ConvertBitmapToPalette(OShinyBackBitmapAnimation, AnimationShinyPalette, True)
        End If

        SynchSprite(FrontSprite, ONormalFrontBitmap, OShinyFrontBitmap)
        SynchSprite(BackSprite, ONormalBackBitmap, OShinyBackBitmap)

        If LoadAnimationFlag = True Then
            SynchSprite2(AnimationNormalSprite, ONormalFrontBitmapAnimation, OShinyFrontBitmapAnimation)
        End If

        mainbitmap.Dispose()

        SaveFrontSpriteToFreeSpace(PokemonIndex, FrontSprite, FrontPalette)
        SaveBackSpriteToFreeSpace(PokemonIndex, BackSprite, BackPalette)

        If LoadAnimationFlag = True Then
            SaveAnimationSpriteToFreeSpace(PokemonIndex, AnimationNormalSprite)
        End If

    End Sub

    Private Sub SynchSprite(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
        Dim num11 As Double = ((CDbl(SpriteArray.Length) / 256) - 1)
        Dim i As Double = 0
        Do While (i <= num11)
            Dim num8 As Integer = 0
            Do
                Dim num9 As Integer = 0
                Do
                    Dim num10 As Integer = 0
                    Do
                        Dim num3 As Byte
                        Dim num4 As UInt32
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num5 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num6 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        If (num5 > index) Then
                            num3 = num5
                        Else
                            num3 = index
                        End If
                        If (num6 > num2) Then
                            num3 = CByte((num3 Or CByte((num6 << 4))))
                        Else
                            num3 = CByte((num3 Or CByte((num2 << 4))))
                        End If
                        SpriteArray(num4) = num3
                        Dim addvar As UInteger = 1
                        num4 = (num4 + addvar)
                        num10 += 1
                    Loop While (num10 <= 3)
                    num9 += 1
                Loop While (num9 <= 7)
                num8 += 1
            Loop While (num8 <= 7)
            i += 1
        Loop
    End Sub

    Private Sub SynchSprite2(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
        Dim num11 As Double = ((CDbl(SpriteArray.Length) / 256) - 1)
        Dim i As Double = 0
        Do While (i <= num11)
            Dim num8 As Integer = 0
            Do
                Dim num9 As Integer = 0
                Do
                    Dim num10 As Integer = 0
                    Do
                        Dim num3 As Byte
                        Dim num4 As UInt32
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(AnimationNormalPalette, NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(AnimationNormalPalette, NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num5 As Byte = CByte(Array.IndexOf(Of Color)(AnimationShinyPalette, ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        Dim num6 As Byte = CByte(Array.IndexOf(Of Color)(AnimationShinyPalette, ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9)))))))
                        If (num5 > index) Then
                            num3 = num5
                        Else
                            num3 = index
                        End If
                        If (num6 > num2) Then
                            num3 = CByte((num3 Or CByte((num6 << 4))))
                        Else
                            num3 = CByte((num3 Or CByte((num2 << 4))))
                        End If
                        SpriteArray(num4) = num3
                        Dim addvar As UInteger = 1
                        num4 = (num4 + addvar)
                        num10 += 1
                    Loop While (num10 <= 3)
                    num9 += 1
                Loop While (num9 <= 7)
                num8 += 1
            Loop While (num8 <= 7)
            i += 1
        Loop
    End Sub

    Public Sub ImportPokemonIcon(filename As String, PokemonIndex As Integer)

        Dim iconpals(2)() As Color

        Dim importimg As New Bitmap(filename)


        If importimg.Height <> &H40 Or importimg.Width <> &H20 Then

            MsgBox("Image dimensions must be 32 by 64! Aborting...")
            Exit Sub
        End If

        Dim palval As Integer

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * 4)

        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber)

        Dim hexstring As String = ""

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000

                fs.Position = pOffset

                Dim indexvar As Integer = 0

                Do
                    iconpals(indexvar) = LoadPaletteFromROM(fs)
                    indexvar += 1
                Loop While (indexvar <= 2)

                fs.Close()
                r.Close()

            End Using
        End Using

        palval = GetClosestPalette(importimg, iconpals)

        ConvertBitmapToPalette(importimg, iconpals(palval), True)

        hexstring = ByteArrayToHexString(SaveBitmapToArray(importimg, iconpals(palval)))

        WriteHEX(LoadedROM, sOffset, hexstring)

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber) + PokemonIndex, Hex(palval))

    End Sub

    Public Sub ImportPokemonFootPrint(filename As String, PokemonIndex As Integer)

        Dim importimg As New Bitmap(filename)


        If importimg.Height <> 16 Or importimg.Width <> 16 Then

            MsgBox("Image dimensions must be 16 by 16! Aborting...")
            Exit Sub
        End If


        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "FootPrintTable", ""), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * 4)

        Dim hexstring As String = ""

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000


                fs.Close()
                r.Close()

            End Using
        End Using

        hexstring = ConvertFootPrintImageToHexString(importimg)

        WriteHEX(LoadedROM, sOffset, hexstring)


    End Sub

End Module
