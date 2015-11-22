Option Strict Off
Option Explicit Off

Module GetNameFunctions

    Public Function GetAbilityName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityNames", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim AbilityName As String = "xxxxxxxxxxxxxx"
            FileGet(FileNum, AbilityName, offvar + 1 + (13 * Index))
            b$ = Sapp2Asc(AbilityName, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetAbilityName = b$
    End Function

    Public Function GetItemName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "ItemData", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim ItemName As String = "xxxxxxxxxxxxxx"
            FileGet(FileNum, ItemName, offvar + 1 + (44 * Index))
            b$ = Sapp2Asc(ItemName, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetItemName = b$
    End Function

    Public Function GetPokemonName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonNames", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim JapPokeName As String = "xxxxxx"
            FileGet(FileNum, JapPokeName, offvar + 1 + (6 * Index))
            b$ = Sapp2Asc(JapPokeName, True)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim PokeName As String = "xxxxxxxxxxx"
            FileGet(FileNum, PokeName, offvar + 1 + (11 * Index))
            b$ = Sapp2Asc(PokeName, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetPokemonName = b$
    End Function

    Public Function GetMapLabelName(ByVal Index As Integer) As String
        Dim offvar As Integer
        Dim stringvar As String
        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "MapLabelData", "")), System.Globalization.NumberStyles.HexNumber)

        If header2 = "BPR" Or header2 = "BPG" Then
            offvar = "&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offvar + (4 * Index), 4))) - &H8000000)
        Else

            offvar = "&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offvar + (8 * Index), 4))) - &H8000000)
        End If

        If header3 = "J" Then

            stringvar = "not supported"

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim LabelName As String = "xxxxxxxxxxxxxxxxxxxxxx"



            FileGet(FileNum, LabelName, offvar + 1)
            stringvar = Sapp2Asc(LabelName, False)
            While InStr(1, stringvar, "\x") : stringvar = LSet(stringvar, Len(stringvar) - 1) : End While
            stringvar = LSet(stringvar, Len(stringvar) - 1)


        End If
        FileClose(FileNum)
        GetMapLabelName = stringvar
    End Function

    Public Function GetAttackName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim AttackName As String = "xxxxxxxxxxxxx"
            FileGet(FileNum, AttackName, offvar + 1 + (13 * Index))
            b$ = Sapp2Asc(AttackName, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetAttackName = b$
    End Function

    Public Function GetBattleFrontierTrainerName(ByVal Index As Integer) As String
        Dim offvar As Integer
        Dim stringvar As String
        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber)

        If header2 = "BPE" Then
            If header3 = "J" Then
            Else
                offvar = offvar + 4 + (Index * 52)
                FileNum = FreeFile()
                FileOpen(FileNum, LoadedROM, OpenMode.Binary)
                Dim LabelName As String = "xxxxxxxx"



                FileGet(FileNum, LabelName, offvar + 1)
                stringvar = Sapp2Asc(LabelName, False)
                While InStr(1, stringvar, "\x") : stringvar = LSet(stringvar, Len(stringvar) - 1) : End While
                stringvar = LSet(stringvar, Len(stringvar) - 1)

            End If

            FileClose(FileNum)
        Else
            MsgBox("What did you do?")
            End
        End If



        GetBattleFrontierTrainerName = stringvar
    End Function

    Public Function GetTrainerClass(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerClasses", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim Name As String = "xxxxxxxxxxxxx"
            FileGet(FileNum, Name, offvar + 1 + (13 * Index))
            b$ = Sapp2Asc(Name, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetTrainerClass = b$
    End Function

    Public Function GetPokedexTypeName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

            If header2 = "AXP" Or header2 = "AXV" Then
                SkipVar = "36"
            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                SkipVar = "36"
            ElseIf header2 = "BPE" Then
                SkipVar = "32"
            End If

        Else
            If header2 = "AXP" Or header2 = "AXV" Then
                SkipVar = "36"
            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                SkipVar = "36"
            ElseIf header2 = "BPE" Then
                SkipVar = "32"
            End If
        End If



        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim PokeType As String = "xxxxxxxxxxxx"
            FileGet(FileNum, PokeType, offvar + 1 + (SkipVar * Index))
            b$ = Sapp2Asc(PokeType, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetPokedexTypeName = b$
    End Function
End Module
