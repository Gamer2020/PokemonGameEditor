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

        Dim FrontAnimationTable As String = ""
        Dim BackAnimTable As String = ""
        Dim AnimDelayTable As String = ""
        Dim EggMoveList As String = ""

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

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "False".ToLower() Then
            lvlupattacks = GetString(INIFileName, "Pokemon", "LevelUpAttacksOriginal", "2102FFFF0000")
        ElseIf GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "True".ToLower() Then
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

            FrontAnimationTable = GetString(INIFileName, "Pokemon", "FrontAnimationTable", "1")
            BackAnimTable = GetString(INIFileName, "Pokemon", "BackAnimTable", "1")
            AnimDelayTable = GetString(INIFileName, "Pokemon", "AnimDelayTable", "1")

            SkipVar = "32"
        End If

        NationalDexNumber = GetString(INIFileName, "Pokemon", "NationalDexNumber", "0")
        SecondDexNumber = GetString(INIFileName, "Pokemon", "SecondDexNumber", "0")

        If Int32.Parse(NationalDexNumber) < Int32.Parse(GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then
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

        Dim alreadyInsertedAtk As Boolean = False
        If Pokemonedit.CheckBox1.Checked Then
            If Pokemonedit.AtkStrings.Count > 0 Then
                Dim countNum As Integer = 0
                For Each oldAtk As String In Pokemonedit.AtkStrings
                    If String.Compare(lvlupattacks, oldAtk) = 0 Then
                        alreadyInsertedAtk = True
                        lvlupattacksoffset = Pokemonedit.AtkOffsets(countNum)
                        Exit For
                    End If

                    countNum += 1
                Next
            End If
        End If

        If Not alreadyInsertedAtk Then
            lvlupattacksoffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(lvlupattacks) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))
            Pokemonedit.AtkStrings.Add(lvlupattacks)
            Pokemonedit.AtkOffsets.Add(lvlupattacksoffset)
            WriteHEX(LoadedROM, lvlupattacksoffset, lvlupattacks)
        End If

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 4), ReverseHEX(Hex(((lvlupattacksoffset)) + &H8000000)))

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) + ((PokemonIndex - 1) * (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))), MoveTutorCompatibility)
        End If

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TMHMCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))), TMHMCompatibility)

        If Int32.Parse(NationalDexNumber) < Int32.Parse(GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then

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

                Dim alreadyInserted As Boolean = False
                If Pokemonedit.CheckBox1.Checked Then
                    Dim countNum As Integer = 0
                    If Pokemonedit.DexDescps.Count > 0 Then
                        For Each desc As String In Pokemonedit.DexDescps
                            If String.Compare(PokedexDescription, desc) = 0 Then
                                alreadyInserted = True
                                PokedexDescriptionOff = Pokemonedit.DexOffsets(countNum)
                            End If

                            countNum += 1
                        Next
                    End If
                End If


                If Not alreadyInserted Then
                    PokedexDescriptionOff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(PokedexDescription)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                    Pokemonedit.DexDescps.Add(PokedexDescription)
                    Pokemonedit.DexOffsets.Add(PokedexDescriptionOff)

                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, PokedexDescription, ("&H" & Hex(PokedexDescriptionOff)) + 1, False)

                    FileClose(FileNum)
                End If

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (NationalDexNumber * SkipVar), ReverseHEX(Hex(Val("&H" & (Hex(PokedexDescriptionOff))) + &H8000000)))

                WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "FrontAnimationTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex - 1), (Hex(Val(FrontAnimationTable))))
                WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "BackAnimTable", "")), System.Globalization.NumberStyles.HexNumber)) + (1) + (PokemonIndex - 1), (Hex(Val(BackAnimTable))))
                WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "AnimDelayTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex - 1), (Hex(Val(AnimDelayTable))))

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

        Try
            SynchSprite(BackSprite, ONormalBackBitmap, OShinyBackBitmap)
        Catch
            SynchSpriteOverflow(BackSprite, ONormalBackBitmap, OShinyBackBitmap)
        End Try

        If LoadAnimationFlag = True Then
            Try
                SynchSprite2(AnimationNormalSprite, ONormalFrontBitmapAnimation, OShinyFrontBitmapAnimation)
            Catch
                SynchSprite2Overflow(AnimationNormalSprite, ONormalFrontBitmapAnimation, OShinyFrontBitmapAnimation)
            End Try
            SaveAnimationSpriteToFreeSpace(PokemonIndex, AnimationNormalSprite)
        Else
            Try
                SynchSprite(FrontSprite, ONormalFrontBitmap, OShinyFrontBitmap)
            Catch
                SynchSpriteOverflow(FrontSprite, ONormalFrontBitmap, OShinyFrontBitmap)
            End Try
            SaveFrontSpriteToFreeSpace(PokemonIndex, FrontSprite, FrontPalette)
        End If

        mainbitmap.Dispose()
        SaveBackSpriteToFreeSpace(PokemonIndex, BackSprite, BackPalette)

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

    Private Sub SynchSpriteOverflow(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
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
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, FrontPalette(GetClosestColorFromPalette(NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9))))), FrontPalette))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(FrontPalette, FrontPalette(GetClosestColorFromPalette(NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9))))), FrontPalette))))
                        Dim num5 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, BackPalette(GetClosestColorFromPalette(ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9))))), BackPalette))))
                        Dim num6 As Byte = CByte(Array.IndexOf(Of Color)(BackPalette, BackPalette(GetClosestColorFromPalette(ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9))))), BackPalette))))
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

    Private Sub SynchSprite2Overflow(ByRef SpriteArray As Byte(), ByRef NormalSprite As Bitmap, ByRef ShinySprite As Bitmap)
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
                        Dim index As Byte = CByte(Math.Abs(Array.IndexOf(Of Color)(AnimationNormalPalette, AnimationNormalPalette(GetClosestColorFromPalette(NormalSprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9))))), AnimationNormalPalette)))))
                        Dim num2 As Byte = CByte(Math.Abs(Array.IndexOf(Of Color)(AnimationNormalPalette, AnimationNormalPalette(GetClosestColorFromPalette(NormalSprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9))))), AnimationNormalPalette)))))
                        Dim num5 As Byte = CByte(Math.Abs(Array.IndexOf(Of Color)(AnimationShinyPalette, AnimationShinyPalette(GetClosestColorFromPalette(ShinySprite.GetPixel(((num8 * 8) + (num10 * 2)), CInt(Math.Round(CDbl(((i * 8) + num9))))), AnimationShinyPalette)))))
                        Dim num6 As Byte = CByte(Math.Abs(Array.IndexOf(Of Color)(AnimationShinyPalette, AnimationShinyPalette(GetClosestColorFromPalette(ShinySprite.GetPixel((((num8 * 8) + (num10 * 2)) + 1), CInt(Math.Round(CDbl(((i * 8) + num9))))), AnimationShinyPalette)))))
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

        Dim importimg As New Bitmap(filename)


        If importimg.Height <> &H40 Or importimg.Width <> &H20 Then

            MsgBox("Image dimensions must be 32 by 64! Aborting...")
            Exit Sub
        End If

        Dim palval As Integer

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * 4)

        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber)

        Dim hexstring As String = ""
        'Dim ImgNewOffset
        'Dim ImgBytes As Byte()
        'Dim ImgString As String

        Dim individualPalettes As Boolean = False

        Try
            pOffset = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable2", ""), System.Globalization.NumberStyles.HexNumber)
            individualPalettes = True
        Catch

        End Try

        Dim iconpals(Pokemonedit.IconPalCount - 1)() As Color

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                Dim indexvar As Integer = 0

                fs.Position = sOffset
                sOffset = r.ReadInt32 - &H8000000

                If Not individualPalettes Then

                    fs.Position = pOffset

                    Do
                        iconpals(indexvar) = LoadPaletteFromROM(fs)
                        indexvar += 1
                    Loop While (indexvar <= 2)

                Else

                    Dim pTable As Integer = pOffset

                    Do
                        fs.Position = pTable + (8 * indexvar)
                        pOffset = r.ReadInt32 - &H8000000
                        fs.Position = pOffset
                        iconpals(indexvar) = LoadPaletteFromROM(fs)
                        indexvar += 1
                    Loop While (indexvar <= Pokemonedit.IconPalCount - 1)


                End If

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

    Public Sub ImportTrainerSprite(filename As String, Index As Integer)

        Dim SpritePAl() As Color

        Dim importimg As New Bitmap(filename)

        Dim Loadedimg As Bitmap = New Bitmap(&H40, &H40)

        If importimg.Height <> &H40 Or importimg.Width <> &H40 Then

            MsgBox("Image dimensions must be 64 by 64! Aborting...")
            Exit Sub
        End If

        Dim hexstring As String = ""

        BitmapBLT(importimg, Loadedimg, 0, 0, 0, 0, &H40, &H40, Color.FromArgb(&HFF, 200, 200, &HA8))

        SpritePAl = GetBitmapPalette(Loadedimg)

        ConvertBitmapToPalette(Loadedimg, SpritePAl, True)

        SaveTrainerSpriteToFreeSpace(Index, SaveBitmapToArray(Loadedimg, SpritePAl), SpritePAl)

    End Sub

    Public Sub ImportPokemonIconNewOffset(filename As String, PokemonIndex As Integer)

        Dim importimg As New Bitmap(filename)


        If importimg.Height <> &H40 Or importimg.Width <> &H20 Then

            MsgBox("Image dimensions must be 32 by 64! Aborting...")
            Exit Sub
        End If

        Dim palval As Integer

        Dim sOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable", ""), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * 4)

        Dim pOffset As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPals", ""), System.Globalization.NumberStyles.HexNumber)

        Dim hexstring As String = ""
        Dim ImgNewOffset
        'Dim ImgBytes As Byte()
        'Dim ImgString As String

        Dim individualPalettes As Boolean = False

        Try
            pOffset = Int32.Parse(GetString(GetINIFileLocation(), header, "IconPointerTable2", ""), System.Globalization.NumberStyles.HexNumber)
            individualPalettes = True
        Catch

        End Try

        Dim iconpals(Pokemonedit.IconPalCount - 1)() As Color

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                Dim indexvar As Integer = 0

                If Not individualPalettes Then

                    fs.Position = pOffset

                    Do
                        iconpals(indexvar) = LoadPaletteFromROM(fs)
                        indexvar += 1
                    Loop While (indexvar <= 2)

                Else

                    Dim pTable As Integer = pOffset

                    Do
                        fs.Position = pTable + (8 * indexvar)
                        pOffset = r.ReadInt32 - &H8000000
                        fs.Position = pOffset
                        iconpals(indexvar) = LoadPaletteFromROM(fs)
                        indexvar += 1
                    Loop While (indexvar <= Pokemonedit.IconPalCount - 1)


                End If

                fs.Close()
                r.Close()

            End Using
        End Using

        palval = GetClosestPalette(importimg, iconpals)

        ConvertBitmapToPalette(importimg, iconpals(palval), True)
        'ImgBytes = ConvertStringToByteArray(CompressLz77String(ConvertByteArrayToString(SaveBitmapToArray(importimg, iconpals(palval)))))
        'ImgString = ByteArrayToHexString(ImgBytes)
        hexstring = ByteArrayToHexString(SaveBitmapToArray(importimg, iconpals(palval)))
        ImgNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(hexstring) / 2)), "&H" & GetString(GetINIFileLocation(), header, "B00000", "B00000"))
        WriteHEX(LoadedROM, ImgNewOffset, hexstring)

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber) + PokemonIndex, Hex(palval))
        WriteHEX(LoadedROM, sOffset, ReverseHEX(Hex((ImgNewOffset) + &H8000000)))
    End Sub

    Public Sub ImportItem(DataPath As String, ItemIndex As Integer, Optional Individual As Boolean = False)

        Dim iniPath As String = ""

        If Not Individual Then
            iniPath = DataPath & "\" & ItemIndex & ".ini"
        Else
            iniPath = DataPath
        End If

        Dim ItemBaseOff As String = Int32.Parse((GetString(GetINIFileLocation(), header, "ItemData", "")), System.Globalization.NumberStyles.HexNumber)

        'If System.IO.File.Exists(iniPath) Then

        Dim ItemName As String = INI.GetString(iniPath, "Item", "ItemName", "IniProblem")
        Dim ItemText As String = INI.GetString(iniPath, "Item", "ItemText", "IniProblem")
        Dim Price As String = INI.GetString(iniPath, "Item", "Price", "0")
        Dim HoldEffect As String = INI.GetString(iniPath, "Item", "HoldEffect", "0")
        Dim Value As String = INI.GetString(iniPath, "Item", "Value", "0")
        Dim ItemDescp As String = INI.GetString(iniPath, "Item", "ItemDescp", "IniProblem\x")
        Dim Mystery1 As String = INI.GetString(iniPath, "Item", "Mystery1", "0")
        Dim Mystery2 As String = INI.GetString(iniPath, "Item", "Mystery2", "0")
        Dim Pocket As String = INI.GetString(iniPath, "Item", "Pocket", "1")
        Dim ItemType As String = INI.GetString(iniPath, "Item", "ItemType", "0")
        Dim FieldUsagePointer As String = INI.GetString(iniPath, "Item", "FieldUsagePointer", "FE821")
        Dim BattleUsagePointer As String = INI.GetString(iniPath, "Item", "BattleUsagePointer", "F8000000")
        Dim BUText As String = INI.GetString(iniPath, "Item", "BUText", "0")
        Dim ExtraParam As String = INI.GetString(iniPath, "Item", "ExtraParam", "00000000")

        ChangeItemName(ItemIndex, ItemName)

        'Description
        Dim alreadyInserted As Boolean = False
        Dim countNum As Integer = 0
        Dim newtextoff As String = ""
        If ItemEditor.itemDescs.Count > 0 Then
            For Each desc As String In ItemEditor.itemDescs
                If String.Compare(desc, ItemDescp) = 0 Then
                    alreadyInserted = True
                    newtextoff = ItemEditor.itemDescOffsets(countNum)
                End If

                countNum += 1
            Next
        End If

        If Not alreadyInserted Then
            ItemEditor.itemDescs.Add(ItemDescp)

            Dim destowrite As String = Asc2Sapp(Replace(ItemDescp, vbCrLf, "\n") & "\x")
            Dim DescpByteLength As Integer = ItemDescp.Length

            DescpByteLength = ItemDescp.Length - (ItemDescp.Split("[").Length - 1) - (ItemDescp.Split("]").Length - 1) - 1
            If DescpByteLength < 1 Then
                DescpByteLength = (destowrite & " ").Length
                'destowrite = Asc2Sapp(Replace("?????", vbCrLf, "\n") & "\x")
            End If

            newtextoff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, DescpByteLength, "&H" & GetString(GetINIFileLocation(), header, "B00000", "B00000"))
            ItemEditor.itemDescOffsets.Add(newtextoff)

            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite & " ", ("&H" & Hex(newtextoff)) + 1, False)
            FileClose(FileNum)
        End If

        Dim ItemHex1 As String = ""
        Dim ItemHex2 As String = ""

        ItemHex1 += ReverseHEX(VB.Right("0000" & Hex(ItemIndex), 4))
        ItemHex1 += ReverseHEX(VB.Right("0000" & Hex(Price), 4))
        ItemHex1 += VB.Right("00" & Hex(HoldEffect), 2)
        ItemHex1 += VB.Right("00" & Hex(Value), 2)
        ItemHex1 += VB.Right("00000000" & ReverseHEX(Hex(Int32.Parse(((newtextoff))) + &H8000000)), 8)
        ItemHex1 += VB.Right("00" & Hex(Mystery1), 2)
        ItemHex1 += VB.Right("00" & Hex(Mystery2), 2)
        ItemHex1 += VB.Right("00" & Hex(Pocket), 2)
        ItemHex1 += VB.Right("00" & Hex(ItemType), 2)
        ItemHex1 += VB.Right("00000000" & ReverseHEX(Hex(Int32.Parse(((FieldUsagePointer)), System.Globalization.NumberStyles.HexNumber) + &H8000000)), 8)
        ItemHex1 += VB.Right("00" & Hex(BUText), 2)
        '3 Bytes Skipped Over
        ItemHex2 += VB.Right("00000000" & ReverseHEX(Hex(Int32.Parse(((BattleUsagePointer)), System.Globalization.NumberStyles.HexNumber) + &H8000000)), 8)
        ItemHex2 += VB.Right("00000000" & ReverseHEX(ExtraParam), 8)

        WriteHEX(LoadedROM, ((ItemBaseOff) + 14) + (ItemIndex * 44), ItemHex1) '(ItemBaseOff) + 14---32
        '                                                                       (ItemBaseOff) + 33---35
        WriteHEX(LoadedROM, ((ItemBaseOff) + 36) + (ItemIndex * 44), ItemHex2) '(ItemBaseOff) + 36---43

    End Sub

    Public Sub ImportItemPicture(pngpath As String, ItemIndex As String, Optional Individual As Boolean = False)
        'Dim ItemPalette As Color() = New Color(&H11 - 1) {}
        Dim mainbitmap As New Bitmap(pngpath)
        Dim ItemBitmap As Bitmap = New Bitmap(&H18, &H18)
        Dim ItemPicDataOff As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber)

        If mainbitmap.Height = 24 And mainbitmap.Width = 24 Then

        Else
            MsgBox("The dimensions of the file " & pngpath & " do not seem correct. Aborting...")
            Exit Sub
        End If

        BitmapBLT(mainbitmap, ItemBitmap, 0, 0, 0, 0, &H18, &H18, Color.FromArgb(&HFF, 200, 200, &HA8))
        Dim ItemPalette As Color() = GetBitmapPaletteNoLimit(ItemBitmap)

        While ItemPalette.Count() > 16
            Dim BufferPal As New List(Of Color)

            For looper = 1 To ItemPalette.Count() - 1
                BufferPal.Add(ItemPalette(looper))
            Next

            BufferPal = RemoveOneColor(BufferPal)
            BufferPal.InsertRange(0, {ItemPalette(0)})

            ItemPalette = BufferPal.ToArray()

        End While

        ConvertBitmapToPalette(ItemBitmap, ItemPalette, True)

        While ItemPalette.Count < 16
            Dim BufferList As List(Of Color) = ItemPalette.ToList()
            BufferList.Add(Color.FromArgb(&HFFFFFF))
            ItemPalette = BufferList.ToArray()
        End While

        Dim Sprite As Byte() = SaveBitmapToArray(ItemBitmap, ItemPalette)

        Dim ImgString As String
        Dim PalString As String

        Dim ImgBytes As Byte()
        Dim PalBytes As Byte()

        Dim ImgNewOffset As String = ""
        Dim PalNewOffset As String = ""

        ImgBytes = ConvertStringToByteArray(CompressLz77String(ConvertByteArrayToString(Sprite)))
        PalBytes = ConvertStringToByteArray(CompressLz77String(ConvertPaletteToString(ItemPalette)))

        ImgString = ByteArrayToHexString(ImgBytes)
        PalString = ByteArrayToHexString(PalBytes)
        Dim alreadyInsertedPic As Boolean = False
        If ItemEditor.itemPics.Count > 0 Then
            Dim countNum As Integer = 0
            For Each oldPic As String In ItemEditor.itemPics
                If String.Compare(ImgString, oldPic) = 0 Then
                    alreadyInsertedPic = True
                    ImgNewOffset = ItemEditor.itemPicOffsets(countNum)
                    Exit For
                End If

                countNum += 1
            Next
        End If

        Dim alreadyInsertedPal As Boolean = False
        If ItemEditor.itemPals.Count > 0 Then
            Dim countNum As Integer = 0
            For Each oldPal As String In ItemEditor.itemPals
                If String.Compare(PalString, oldPal) = 0 Then
                    alreadyInsertedPal = True
                    PalNewOffset = ItemEditor.itemPalOffsets(countNum)
                    Exit For
                End If

                countNum += 1
            Next
        End If


        If Not alreadyInsertedPic Then
            ImgNewOffset = Convert.ToInt32(SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(ImgString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "B00000", "B00000")))
            ItemEditor.itemPics.Add(ImgString)
            ItemEditor.itemPicOffsets.Add(ImgNewOffset)
        End If

        WriteHEX(LoadedROM, Int32.Parse(ImgNewOffset), ImgString)

        If Not alreadyInsertedPal Then
            PalNewOffset = Convert.ToInt32(SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(PalString) / 2)), "&H" & GetString(GetINIFileLocation(), header, "B00000", "B00000")))
            ItemEditor.itemPals.Add(PalString)
            ItemEditor.itemPalOffsets.Add(PalNewOffset)
        End If

        WriteHEX(LoadedROM, Int32.Parse(PalNewOffset), PalString)

        WriteHEX(LoadedROM, (ItemPicDataOff + (ItemIndex * 8)), ReverseHEX(Hex(Int32.Parse(((ImgNewOffset))) + &H8000000)))
        WriteHEX(LoadedROM, (ItemPicDataOff + (ItemIndex * 8) + 4), ReverseHEX(Hex(Int32.Parse(((PalNewOffset))) + &H8000000)))

        mainbitmap.Dispose()

    End Sub

    Public Function RemoveOneColor(pal As List(Of Color)) As List(Of Color)
        RemoveOneColor = New List(Of Color)

        Dim colorDiffs As List(Of List(Of Integer)) = New List(Of List(Of Integer))

        Dim looper As Integer = 0
        For col = 0 To pal.Count() - 1
            Dim innerloop As Integer = 0
            colorDiffs.Add(New List(Of Integer))

            For innerCol = 0 To pal.Count() - 1
                Dim testColDiff As Integer = 99999
                If innerCol > col Then
                    If Not col = innerCol Then
                        testColDiff = GetColorDifference(pal(col), pal(innerCol))
                    End If
                End If
                colorDiffs(looper).Add(testColDiff)

                innerloop += 1
            Next

            looper += 1
        Next

        looper = 0
        Dim oldDiff As Integer = 99999
        Dim colorsToCombine As Integer() = {0, 0}
        For Each diffList As List(Of Integer) In colorDiffs
            Dim innerloop As Integer = 0

            For Each diff As Integer In diffList
                If diff < oldDiff Then
                    oldDiff = diff
                    colorsToCombine = {looper, innerloop}
                End If

                innerloop += 1
            Next

            looper += 1
        Next

        pal.RemoveAt(colorsToCombine(1))

        RemoveOneColor = pal

        Return RemoveOneColor

    End Function

    Public Function GetLongString(ByVal strFilename As String, ByVal Section As String,
      ByVal Key As String, ByVal [Default] As String) As String

        GetLongString = ""

        Dim intCharCount As Integer
        Dim objResult As New System.Text.StringBuilder(1000)
        intCharCount = GetPrivateProfileString(Section, Key,
           [Default], objResult, objResult.Capacity, strFilename)
        If intCharCount > 0 Then GetLongString =
           Left(objResult.ToString, intCharCount)


        'This should probably be commented out if used for another program!
        If LoadedROM <> "" Then
            If GetLongString = "" And GetINIFileLocation() = strFilename Then
                OutPutError("Error! " & Key & " is missing for ROM " & Section & "!")
            End If
        End If

    End Function

    Private Declare Ansi Function GetPrivateProfileString _
      Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
      (ByVal lpApplicationName As String,
      ByVal lpKeyName As String, ByVal lpDefault As String,
      ByVal lpReturnedString As System.Text.StringBuilder,
      ByVal nSize As Integer, ByVal lpFileName As String) _
      As Integer

    Public Sub ImportTutorMoves(filename)
        Dim newMoves As String = GetLongString(filename, "TUTR", "TutorMoves", "")
        Dim moveTable As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)
        Dim looper As Integer = 0
        Dim maxAtacks As Integer = Int32.Parse(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "0"))

        While newMoves.Length > looper * 4 And looper < maxAtacks
            WriteHEX(LoadedROM, moveTable + (2 * looper), VB.Right("0000" & newMoves.Substring(looper * 4, 4), 4))
            looper += 1
        End While

    End Sub

    Public Sub ImportTMHMINI(Filepath As String)

        Dim TMHMAttacks As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "TMData", "")), System.Globalization.NumberStyles.HexNumber)
        WriteHEX(LoadedROM, TMHMAttacks, GetString(Filepath, "TMHM", "TMHMData", ""))
        Dim TMList As String = GetLongString(Filepath, "TMHM", "TMHMData", "")
        Dim LoopVar As Integer = 0
        Dim LoopLength As Integer = 0

        If TMHMEditor.CheckBox1.Checked Then
            LoopLength = Int32.Parse((Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", "")))) - 8
        Else
            LoopLength = Int32.Parse((Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", ""))))
        End If

        While LoopVar < LoopLength And LoopVar + 4 < TMList.Length = True

            If TMList.Length > (LoopVar * 4) Then
                WriteHEX(LoadedROM, TMHMAttacks + LoopVar * 2, TMList.Substring(LoopVar * 4, 4))
            Else
                WriteHEX(LoadedROM, TMHMAttacks + LoopVar * 2, "0000")
            End If

            LoopVar += 1

        End While

    End Sub
End Module
