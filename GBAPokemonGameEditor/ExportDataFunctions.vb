Imports VB = Microsoft.VisualBasic
Module ExportDataFunctions
    Public Sub ExportPokemonINI(INIFileName As String, PokemonIndex As Integer)

        'Declare vars

        Dim BaseStats As String

        Dim PlayerY As String
        Dim EnemyY As String
        Dim EnemyAlt As String

        Dim ItemAnimation As String = ""

        Dim EvolutionData As String

        Dim LevelUpAttacksOriginal As String = ""
        Dim LevelUpAttacksJambo51 As String = ""
        Dim CurAttackListOffset As String
        Dim at As String
        Dim lvl As String
        Dim Looper As Integer
        Dim TempLoadBuff As Integer
        Dim binarybuffer As String

        Dim MoveTutorCompatibility As String = ""

        Dim TMHMCompatibility As String

        Dim NationalDexNumber As String
        Dim SecondDexNumber As String

        Dim Pointer1 As String = ""
        Dim Pointer2 As String = ""
        Dim Pointer1Description As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Dim Pointer2Description As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
        Dim PokedexDescription As String = ""
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

        'Fill vars with proper data

        BaseStats = ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonData", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 28), 28)

        PlayerY = ((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PlayerYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PokemonIndex * 4), 1)))
        EnemyY = ((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PokemonIndex * 4), 1)))
        EnemyAlt = ((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyAltitudeTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 1), 1)))

        If header2 = "BPR" Or header2 = "BPG" Then
            ItemAnimation = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ItemAnimationTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 5), 5)
        End If

        EvolutionData = ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonEvolutions", "")), System.Globalization.NumberStyles.HexNumber)) + ((PokemonIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))), (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))))


        CurAttackListOffset = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "False".ToLower() Then

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

                LevelUpAttacksOriginal = LevelUpAttacksOriginal & ((ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2)))

                Looper = Looper + 1
            End While

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

                TempLoadBuff = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

                binarybuffer = Convert.ToString(TempLoadBuff, 2)

                While Len(binarybuffer) < 16

                    binarybuffer = "0" & binarybuffer

                End While

                lvl = Mid(binarybuffer, 1, 7)

                at = Mid(binarybuffer, 8, 9)

                lvl = Convert.ToInt32(lvl, 2)

                at = Convert.ToInt32(at, 2)

                lvl = VB.Right("00" & Hex(lvl), 2)
                at = ReverseHEX(VB.Right("0000" & Hex(at), 4))


                LevelUpAttacksJambo51 = LevelUpAttacksJambo51 & at & lvl

                Looper = Looper + 1
            End While


        ElseIf GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "True".ToLower() Then

            Looper = 0

            Dim temp As Integer

            While ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 3) = GetString(GetINIFileLocation(), header, "JamboLearnableMovesTerm", "") = False

                lvl = Int32.Parse(((ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 3) + 2, 1))), System.Globalization.NumberStyles.HexNumber)

                at = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((CurAttackListOffset), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 2))), System.Globalization.NumberStyles.HexNumber)

                LevelUpAttacksJambo51 = LevelUpAttacksJambo51 & ReverseHEX(VB.Right("0000" & Hex(at), 4)) & VB.Right("00" & Hex(lvl), 2)
                Looper = Looper + 1

                temp = lvl

                lvl = Convert.ToString(temp, 2)

                temp = at

                at = Convert.ToString(temp, 2)

                While Len(lvl) < 7

                    lvl = "0" & lvl

                End While

                While Len(at) < 9

                    at = "0" & at

                End While

                If Len(at) > 9 Then
                    at = "111111111"
                End If

                If Len(lvl) > 7 Then
                    lvl = "1111111"
                End If

                LevelUpAttacksOriginal = LevelUpAttacksOriginal & ReverseHEX(VB.Right("0000" & Hex(Convert.ToInt32(lvl & at, 2)), 4))

            End While


        End If

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then
            MoveTutorCompatibility = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) + ((PokemonIndex - 1) * (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))), ((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))
        End If

        TMHMCompatibility = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TMHMCompatibility", "")), System.Globalization.NumberStyles.HexNumber) + (PokemonIndex * (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))), (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))))

        NationalDexNumber = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 2), 2)
        SecondDexNumber = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SecondDexTable", "")), System.Globalization.NumberStyles.HexNumber) + ((PokemonIndex - 1) * 2), 2)

        NationalDexNumber = Int32.Parse(ReverseHEX(NationalDexNumber), System.Globalization.NumberStyles.HexNumber)
        SecondDexNumber = Int32.Parse(ReverseHEX(SecondDexNumber), System.Globalization.NumberStyles.HexNumber)

        If header2 = "AXP" Or header2 = "AXV" Then
            SkipVar = "36"
        ElseIf header2 = "BPR" Or header2 = "BPG" Then
            SkipVar = "36"
        ElseIf header2 = "BPE" Then
            SkipVar = "32"
        End If

        If NationalDexNumber < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then

            Pointer1 = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (NationalDexNumber * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            Hght = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 12 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Wght = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 2 + 12 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


            If header2 = "AXP" Or header2 = "AXV" Then

                Scale1 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

                Pointer2 = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 8 + +12 + (NationalDexNumber * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FileGet(FileNum, Pointer1Description, Int32.Parse(((Pointer1)), System.Globalization.NumberStyles.HexNumber) + 1, True)
                Pointer1Description = Sapp2Asc(Pointer1Description)
                Pointer1Description = Mid$(Pointer1Description, 1, InStr(1, Pointer1Description, "\x"))
                Pointer1Description = Pointer1Description & "x"

                FileClose(FileNum)


                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FileGet(FileNum, Pointer2Description, Int32.Parse(((Pointer2)), System.Globalization.NumberStyles.HexNumber) + 1, True)
                Pointer2Description = Sapp2Asc(Pointer2Description)
                Pointer2Description = Mid$(Pointer2Description, 1, InStr(1, Pointer2Description, "\x"))
                Pointer2Description = Pointer2Description & "x"
                PokedexDescription = Pointer1Description & Pointer2Description

                FileClose(FileNum)


            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                Scale1 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FileGet(FileNum, Pointer1Description, Int32.Parse(((Pointer1)), System.Globalization.NumberStyles.HexNumber) + 1, True)
                Pointer1Description = Sapp2Asc(Pointer1Description)
                Pointer1Description = Mid$(Pointer1Description, 1, InStr(1, Pointer1Description, "\x"))
                Pointer1Description = Pointer1Description & "x"
                PokedexDescription = Pointer1Description

                FileClose(FileNum)

            ElseIf header2 = "BPE" Then

                Scale1 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 22 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 24 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2 = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2 = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (NationalDexNumber * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FileGet(FileNum, Pointer1Description, Int32.Parse(((Pointer1)), System.Globalization.NumberStyles.HexNumber) + 1, True)
                Pointer1Description = Sapp2Asc(Pointer1Description)
                Pointer1Description = Mid$(Pointer1Description, 1, InStr(1, Pointer1Description, "\x"))
                Pointer1Description = Pointer1Description & "x"
                PokedexDescription = Pointer1Description

                FileClose(FileNum)


                FrontAnimationTable = (Int32.Parse(((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "FrontAnimationTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex - 1), 1))), System.Globalization.NumberStyles.HexNumber))
                BackAnimTable = (Int32.Parse(((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "BackAnimTable", "")), System.Globalization.NumberStyles.HexNumber)) + (1) + (PokemonIndex - 1), 1))), System.Globalization.NumberStyles.HexNumber))
                AnimDelayTable = (Int32.Parse(((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "AnimDelayTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex - 1), 1))), System.Globalization.NumberStyles.HexNumber))


            End If

            PokedexType = GetPokedexTypeName(NationalDexNumber)

        End If

        'Write values to ini

        WriteString(INIFileName, "Pokemon", "PokemonName", GetPokemonName(PokemonIndex))
        WriteString(INIFileName, "Pokemon", "BaseStats", BaseStats)

        WriteString(INIFileName, "Pokemon", "PlayerY", PlayerY)
        WriteString(INIFileName, "Pokemon", "EnemyY", EnemyY)
        WriteString(INIFileName, "Pokemon", "EnemyAlt", EnemyAlt)

        If header2 = "BPR" Or header2 = "BPG" Then
            WriteString(INIFileName, "Pokemon", "ItemAnimation", ItemAnimation)
        End If

        WriteString(INIFileName, "Pokemon", "EvolutionData", EvolutionData)

        WriteString(INIFileName, "Pokemon", "LevelUpAttacksOriginal", LevelUpAttacksOriginal & "FFFF0000")
        WriteString(INIFileName, "Pokemon", "LevelUpAttacksJambo51", LevelUpAttacksJambo51 & "0000FF00")

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then
            WriteString(INIFileName, "Pokemon", "MoveTutorCompatibility", MoveTutorCompatibility)
        End If

        If header2 = "BPE" Then
            WriteString(INIFileName, "Pokemon", "FrontAnimationTable", FrontAnimationTable)
            WriteString(INIFileName, "Pokemon", "BackAnimTable", BackAnimTable)
            WriteString(INIFileName, "Pokemon", "AnimDelayTable", AnimDelayTable)
        End If

        WriteString(INIFileName, "Pokemon", "TMHMCompatibility", TMHMCompatibility)

        WriteString(INIFileName, "Pokemon", "NationalDexNumber", NationalDexNumber)
        WriteString(INIFileName, "Pokemon", "SecondDexNumber", SecondDexNumber)

        If NationalDexNumber < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And NationalDexNumber <> 0 Then

            WriteString(INIFileName, "Pokemon", "Hght", Hght)
            WriteString(INIFileName, "Pokemon", "Wght", Wght)
            WriteString(INIFileName, "Pokemon", "Scale1", Scale1)
            WriteString(INIFileName, "Pokemon", "Scale2", Scale2)
            WriteString(INIFileName, "Pokemon", "Offset_1", Offset_1)
            WriteString(INIFileName, "Pokemon", "Offset_2", Offset_2)
            WriteString(INIFileName, "Pokemon", "PokedexDescription", PokedexDescription)
            WriteString(INIFileName, "Pokemon", "PokedexType", PokedexType)

        End If

    End Sub

    Public Sub ExportAbilityINI(INIFileName As String, AbilityIndex As Integer)

        Dim AbilityDescription As String
        Dim AbilityDescriptionTable As Integer
        Dim CurAbilityDescriptionPointer As String

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
        AbilityDescription = AbDescp

        FileClose(FileNum)

        WriteString(INIFileName, "Ability", "AbilityName", GetAbilityName(AbilityIndex))
        WriteString(INIFileName, "Ability", "AbilityDescription", AbilityDescription)

    End Sub

    Public Sub ExportAttackINI(INIFileName As String, AttackIndex As Integer)

        Dim AttackData As String
        Dim AttackDescription As String
        Dim AttackDescriptionTable As Integer
        Dim CurAttackDescriptionPointer As String
        Dim ContestData As String

        AttackDescriptionTable = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

        CurAttackDescriptionPointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackDescriptionTable) + ((AttackIndex - 1) * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim ATDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, ATDescp, Int32.Parse(((CurAttackDescriptionPointer)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        ATDescp = Sapp2Asc(ATDescp)
        ATDescp = Mid$(ATDescp, 1, InStr(1, ATDescp, "\x"))
        'AbDescp = Replace(AbDescp, "\n", vbCrLf)
        'AtDescp = Replace(RTrim$(AtDescp), "\", "")
        ATDescp = ATDescp & "x"
        AttackDescription = ATDescp

        FileClose(FileNum)

        AttackData = ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber)) + (AttackIndex * 12), 12)

        WriteString(INIFileName, "Attack", "AttackName", GetAttackName(AttackIndex))
        WriteString(INIFileName, "Attack", "AttackData", AttackData)
        WriteString(INIFileName, "Attack", "AttackDescription", AttackDescription)

        If header2 = "AXP" Or header2 = "AXV" Or header2 = "BPE" Then

            ContestData = ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveData", "")), System.Globalization.NumberStyles.HexNumber)) + (AttackIndex * 8), 8)

            WriteString(INIFileName, "Attack", "ContestData", ContestData)

        Else
        End If

    End Sub

    Public Sub ExportAseriesSheet(FileName As String, PokemonIndex As Integer)

        Dim ExportBitMap As Bitmap

        If header2 = "BPE" Then
            Dim destBitmap As New Bitmap(&H100, &H80)

            BitmapBLT(GetNormalAnimationPokemonPicToBitmap(PokemonIndex), destBitmap, 0, 0, 0, 0, &H40, &H80)
            BitmapBLT(GetShinyAnimationPokemonPicToBitmap(PokemonIndex), destBitmap, &H40, 0, 0, 0, &H40, &H80)
            BitmapBLT(GetNormalBackPokemonPicToBitmap(PokemonIndex), destBitmap, &H80, 0, 0, 0, &H40, &H40)
            BitmapBLT(GetBackPokemonPicToBitmap(PokemonIndex), destBitmap, &HC0, 0, 0, 0, &H40, &H40)

            ExportBitMap = destBitmap

        Else
            Dim destBitmap2 As New Bitmap(&H100, &H40)

            BitmapBLT(GetFrontPokemonPicToBitmap(PokemonIndex), destBitmap2, 0, 0, 0, 0, &H40, &H40)
            BitmapBLT(GetShinyFrontPokemonPicToBitmap(PokemonIndex), destBitmap2, &H40, 0, 0, 0, &H40, &H40)
            BitmapBLT(GetNormalBackPokemonPicToBitmap(PokemonIndex), destBitmap2, &H80, 0, 0, 0, &H40, &H40)
            BitmapBLT(GetBackPokemonPicToBitmap(PokemonIndex), destBitmap2, &HC0, 0, 0, 0, &H40, &H40)

            ExportBitMap = destBitmap2

        End If

        ExportBitMap.Save(FileName)
        ExportBitMap.Dispose()


    End Sub

    Public Sub ExportPokemonIcon(filename As String, PokemonIndex As Integer)

        Dim bitout As Bitmap = GetAndDrawPokemonIconToBitmap(PokemonIndex, Int32.Parse(((ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber)) + (PokemonIndex), 1))), System.Globalization.NumberStyles.HexNumber), True)

        bitout.Save(filename)

    End Sub

    Public Sub ExportPokemonFootprint(filename As String, PokemonIndex As Integer)

        Dim bitout As Bitmap = GetPokemonFootPrintToBitmap(PokemonIndex)

        bitout.Save(filename)

    End Sub

    Public Sub ExportTrainerSprite(filename As String, Index As Integer)

        Dim bitout As Bitmap = GetAndDrawTrainerSpriteToBitmap(Index, True)

        bitout.Save(filename)

    End Sub

End Module
