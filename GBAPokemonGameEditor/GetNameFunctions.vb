Option Strict Off
Option Explicit Off

Module GetNameFunctions

    Public Function GetAbilityName(ByVal Index As Integer)
        Dim offvar As Integer

        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "AbilityNames", "")), System.Globalization.NumberStyles.HexNumber)

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

        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "ItemData", "")), System.Globalization.NumberStyles.HexNumber)

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

        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonNames", "")), System.Globalization.NumberStyles.HexNumber)

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
        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "MapLabelData", "")), System.Globalization.NumberStyles.HexNumber)

        If header2 = "BPR" Or header2 = "BPG" Then
            offvar = "&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offvar + (4 * Index), 4))) - &H8000000)
        Else

            offvar = "&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offvar + (8 * Index), 4))) - &H8000000)
        End If

        If header3 = "J" Then

            'FileNum = FreeFile()
            'FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            'Dim JapPokeName As String = "xxxxxx"
            'FileGet(FileNum, JapPokeName, offvar + 1 + (6 * Index))
            'b$ = Sapp2Asc(JapPokeName, True)
            'While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            'b$ = LSet(b$, Len(b$) - 1)
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

        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

        Else

            FileNum = FreeFile()
            FileOpen(FileNum, LoadedROM, OpenMode.Binary)
            Dim AbilityName As String = "xxxxxxxxxxxxx"
            'MsgBox("dim abilityname")
            FileGet(FileNum, AbilityName, offvar + 1 + (13 * Index))
            'MsgBox("filget")
            b$ = Sapp2Asc(AbilityName, False)
            While InStr(1, b$, "\x") : b$ = LSet(b$, Len(b$) - 1) : End While
            b$ = LSet(b$, Len(b$) - 1)


        End If
        FileClose(FileNum)
        GetAttackName = b$
    End Function

    Public Function GetBattleFrontierTrainerName(ByVal Index As Integer) As String
        Dim offvar As Integer
        Dim stringvar As String
        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber)

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

        offvar = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "TrainerClasses", "")), System.Globalization.NumberStyles.HexNumber)

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
End Module
