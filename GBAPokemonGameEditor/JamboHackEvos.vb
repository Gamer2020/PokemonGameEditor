

Public Class JamboHackEvos
    Public EvoDatajj As Long
    Private Sub JamboHackEvos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LoopVar As Integer
        LoopVar = 0

        ComboBox2.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfMapLabels", "")) = True


            ComboBox2.Items.Add(GetMapLabelName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        ComboBox3.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAttacks", "")) + 1 = True


            ComboBox3.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        PKMNames.Items.Clear()
        EvoPKMNames.Items.Clear()
        ComboBox1.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))
            ComboBox1.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 0

        ' Item1.Items.Clear()
        '  Item2.Items.Clear()
        EvoItem.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfItems", "")) = True
            '   Item1.Items.Add(GetItemName(LoopVar))
            '   Item2.Items.Add(GetItemName(LoopVar))
            EvoItem.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1



        End While

        PKMNames.SelectedIndex = 0
    End Sub

    Private Sub PKMNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PKMNames.SelectedIndexChanged
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            GetAndDrawFrontPokemonPic(PictureBox1, PKMNames.SelectedIndex + 1)
        End If
        EvoSlots.SelectedIndex = -1
        EvoSlots.SelectedIndex = 0

    End Sub

    Private Sub EvoSlots_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoSlots.SelectedIndexChanged
        EvoDatajj = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonEvolutions", "")), System.Globalization.NumberStyles.HexNumber)

        EvoTypes.SelectedIndex = -1
        EvoTypes.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)

        If EvoTypes.SelectedIndex = 0 Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoPKMNames.SelectedIndex = -1
            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

        ElseIf EvoTypes.SelectedIndex = 1 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 2 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 3 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 4 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 5 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 6 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""


            EvoItem.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 7 Then

            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoItem.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True

        ElseIf EvoTypes.SelectedIndex = 8 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 9 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 10 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 11 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True

        ElseIf EvoTypes.SelectedIndex = 12 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 13 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoItem.SelectedIndex = -1

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoLevel.Enabled = True
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 14 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 15 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 16 Then

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            TextBox1.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
            TextBox2.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            TextBox1.Enabled = True
            TextBox1.Enabled = True

        ElseIf EvoTypes.SelectedIndex = 17 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""


            If header2 = "BPR" Or header2 = "BPG" Then
                ComboBox2.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))) - 88
                EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
                EvoPKMNames.Enabled = True
                ComboBox2.Enabled = True

            ElseIf header2 = "BPE" Then
                ComboBox2.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
                EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
                EvoPKMNames.Enabled = True
                ComboBox2.Enabled = True
            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                ComboBox2.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
                EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
                EvoPKMNames.Enabled = True
                ComboBox2.Enabled = True
            End If
        ElseIf EvoTypes.SelectedIndex = 18 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            ComboBox3.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            ComboBox3.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 19 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoItem.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 20 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            ComboBox1.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 21 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoLevel.Enabled = True
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 22 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""


            EvoLevel.Enabled = True
            EvoLevel.Text = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 23 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            EvoItem.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2))))
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 24 Then
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoItem.Enabled = False

            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""

            ComboBox1.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))) - 1
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = True
        ElseIf EvoTypes.SelectedIndex > 24 Then
            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoPKMNames.SelectedIndex = -1
            ComboBox1.Enabled = False
            ComboBox1.SelectedIndex = -1
            ComboBox2.Enabled = False
            ComboBox2.SelectedIndex = -1
            ComboBox3.Enabled = False
            ComboBox3.SelectedIndex = -1
            TextBox1.Enabled = False
            TextBox1.Text = ""
            TextBox2.Enabled = False
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub EvoTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoTypes.SelectedIndexChanged
        If EvoTypes.SelectedIndex = 0 Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        ElseIf EvoTypes.SelectedIndex = 1 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        ElseIf EvoTypes.SelectedIndex = 2 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        ElseIf EvoTypes.SelectedIndex = 3 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 4 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 5 Then

            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 6 Then

            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 7 Then

            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        ElseIf EvoTypes.SelectedIndex = 8 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 9 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 10 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 11 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        ElseIf EvoTypes.SelectedIndex = 12 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 13 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 14 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 15 Then
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 16 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True
        ElseIf EvoTypes.SelectedIndex = 17 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = True
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 18 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 19 Then
            EvoItem.Enabled = True
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 20 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 21 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 22 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = True
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 23 Then
            EvoItem.Enabled = True
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex = 24 Then
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoPKMNames.Enabled = True
            ComboBox1.Enabled = True
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
        ElseIf EvoTypes.SelectedIndex > 24 Then
            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False

        End If
    End Sub

    Private Sub EvoPKMNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoPKMNames.SelectedIndexChanged
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            If EvoPKMNames.SelectedIndex + 1 > 0 Then
                GetAndDrawFrontPokemonPic(EvoPokePic, EvoPKMNames.SelectedIndex + 1)
            Else
                EvoPokePic.Image = Nothing
            End If
        End If
    End Sub

    Private Sub EvoItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoItem.SelectedIndexChanged
        If EvoItem.SelectedIndex > -1 Then
            If header2 = "BPR" Or header2 = "BPG" Then

                GetAndDrawItemPic(EvoItemPic, EvoItem.SelectedIndex)

            ElseIf header2 = "BPE" Then

                GetAndDrawItemPic(EvoItemPic, EvoItem.SelectedIndex)

            ElseIf header2 = "AXP" Or header2 = "AXV" Then



            End If

        Else
            EvoItemPic.Image = Nothing
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        EvoDatajj = Val(GetString(AppPath & "ini\roms.ini", header, "PokemonEvolutions", ""))


        If EvoTypes.SelectedIndex = 0 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
        ElseIf EvoTypes.SelectedIndex = 1 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

        ElseIf EvoTypes.SelectedIndex = 2 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

        ElseIf EvoTypes.SelectedIndex = 3 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

        ElseIf EvoTypes.SelectedIndex = 4 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 5 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

        ElseIf EvoTypes.SelectedIndex = 6 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoItem.SelectedIndex)))

        ElseIf EvoTypes.SelectedIndex = 7 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoItem.SelectedIndex)))

        ElseIf EvoTypes.SelectedIndex = 8 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 9 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 10 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 11 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

        ElseIf EvoTypes.SelectedIndex = 12 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 13 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 14 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf EvoTypes.SelectedIndex = 15 Then
            'Writes the evolution type
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
        ElseIf EvoTypes.SelectedIndex = 16 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox1.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox2.Text)))

        ElseIf EvoTypes.SelectedIndex = 17 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            If header2 = "BPR" Or header2 = "BPG" Then
                WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex + 88)))
            ElseIf header2 = "BPE" Then
                WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            End If

        ElseIf EvoTypes.SelectedIndex = 18 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(ComboBox3.SelectedIndex))))
        ElseIf EvoTypes.SelectedIndex = 19 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoItem.SelectedIndex)))
        ElseIf EvoTypes.SelectedIndex = 20 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox1.SelectedIndex + 1)))
        ElseIf EvoTypes.SelectedIndex = 21 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))
        ElseIf EvoTypes.SelectedIndex = 22 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))
        ElseIf EvoTypes.SelectedIndex = 23 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoItem.SelectedIndex)))
        ElseIf EvoTypes.SelectedIndex = 24 Then
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(Val(EvoPKMNames.SelectedIndex) + 1)))

            WriteHEX(LoadedROM, (EvoDatajj) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox1.SelectedIndex + 1)))
        ElseIf EvoTypes.SelectedIndex > 24 Then
            'nothing
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            If ComboBox1.SelectedIndex + 1 > 0 Then
                GetAndDrawFrontPokemonPic(PictureBox2, ComboBox1.SelectedIndex + 1)
            Else
                PictureBox2.Image = Nothing
            End If
        End If
    End Sub
End Class