Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class Pokemonedit
    Dim baseoff As Integer
    Dim FrontSpritePointers As Integer
    Dim BackSpritePointers As Integer
    Dim NormalPalPointers As Integer
    Dim ShinyPalPointers As Integer
    Dim AnimationPointers As Integer
    Dim IconPointers As Integer
    Dim IconPalTable As Integer
    Dim EvoData As Integer
    Dim TMHMAttacks As Integer
    Dim TMHMCompoLoc As Integer
    Dim AttackTable As Integer
    Dim FootPrintTable As Integer
    Dim CryTable As Integer
    Dim CryTable2 As Integer
    Dim MTattacks As Integer
    Dim MTCompoLoc As Integer

    Private Sub Pokemonedit_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub



    Private Sub Pokemonedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim LoopVar As Integer

        LoopVar = 0

        EvoTypes.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfEvolutionTypes", "") + 1) = True

            EvoTypes.Items.Add(GetString(AppPath & "ini\roms.ini", header, "EvolutionName" & LoopVar, ""))

            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        EvoSlots.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfEvolutionsPerPokemon", "")) = True

            LoopVar = LoopVar + 1

            EvoSlots.Items.Add("Evolution " & (LoopVar))

        End While

        LoopVar = 0

        NewAt.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAttacks", "")) + 1 = True


            NewAt.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        PKMNames.Items.Clear()
        EvoPKMNames.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 0

        Item1.Items.Clear()
        Item2.Items.Clear()
        EvoItem.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfItems", "")) = True
            Item1.Items.Add(GetItemName(LoopVar))
            Item2.Items.Add(GetItemName(LoopVar))
            EvoItem.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1



        End While

        LoopVar = 0

        Ab1.Items.Clear()
        Ab2.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAbilities", "")) = True

            Ab1.Items.Add(GetAbilityName(LoopVar))
            Ab2.Items.Add(GetAbilityName(LoopVar))

            LoopVar = LoopVar + 1



        End While

        TMHMLoad()
        MTLoad()

        PKMNames.SelectedIndex = 0

        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub Baseload()

        baseoff = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonData", "")), System.Globalization.NumberStyles.HexNumber)

        HpBase.Text = Int32.Parse(((ReadHEX(LoadedROM, (baseoff) + 28 + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        AtBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 1) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        DefBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 2) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        SpeedBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 3) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        SpAttBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 4) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        SpDefBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 5) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        CatchBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 8) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        RunBase.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 24) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Item1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 12) + (i * 28), 2))), System.Globalization.NumberStyles.HexNumber)
        Item2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 14) + (i * 28), 2))), System.Globalization.NumberStyles.HexNumber)
        Type1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 6) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Type2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 7) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Ab1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 22) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Ab2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 23) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Ev1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 10) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Ev2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 11) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        EggType1.SelectedIndex = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 20) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber))
        EggType2.SelectedIndex = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 21) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber))
        Bexp.Text = Int32.Parse(((ReadHEX(LoadedROM, ((baseoff) + 28 + 9) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)
        Grate.SelectedIndex = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 19) + 28 + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber))

        If ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "00" Then

            SHVal.Enabled = False
            SH1.Checked = True
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 0

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "05" Then

            SHVal.Enabled = False
            SH1.Checked = True
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 1

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "0A" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 2

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "0F" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 3

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "14" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 4

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "19" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 5

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "1E" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 6

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "23" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 7

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "28" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 8

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "50" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 9

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1))) = "78" Then

            SH1.Checked = True
            SHVal.Enabled = False
            SHCombo1.Enabled = True
            SHCombo1.SelectedIndex = 10

        Else

            SH2.Checked = True
            SHCombo1.Enabled = False
            SHVal.Enabled = True
            SHVal.Text = ((ReadHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), 1)))

        End If

        If Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber) < 10 Then

            Rght1.Checked = True

            Clr1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)

        ElseIf Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber) > 10 Then

            Lft1.Checked = True
            Clr1.SelectedIndex = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), 1))), System.Globalization.NumberStyles.HexNumber)) - 128

        End If

        If ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "00" Then

            HPVal.Enabled = False
            HP1.Checked = True
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 0

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "23" Then

            HPVal.Enabled = False
            HP1.Checked = True
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 1

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "46" Then

            HP1.Checked = True
            HPVal.Enabled = False
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 2

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "5A" Then

            HP1.Checked = True
            HPVal.Enabled = False
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 3

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "64" Then

            HP1.Checked = True
            HPVal.Enabled = False
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 4

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "8C" Then

            HP1.Checked = True
            HPVal.Enabled = False
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 5

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) = "FF" Then

            HP1.Checked = True
            HPVal.Enabled = False
            HPCombo1.Enabled = True
            HPCombo1.SelectedIndex = 6

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1))) <> "00" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "23" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "46" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "5A" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "64" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "8C" And ((ReadHEX(LoadedROM, (("&H" & baseoff) + 18) + (i * 28), 1))) <> "FF" Then
            HP2.Checked = True
            HPCombo1.Enabled = False
            HPVal.Enabled = True
            HPVal.Text = ((ReadHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), 1)))

        End If

        If ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "00" Then

            GVal.Enabled = False
            G1.Checked = True
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 0

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "1F" Then

            GVal.Enabled = False
            G1.Checked = True
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 1

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "3F" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 2

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "59" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 3

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "7F" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 4

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "A5" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 5

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "BF" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 6

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "DF" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 7

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "FE" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 8

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) = "FF" Then

            G1.Checked = True
            GVal.Enabled = False
            GCombo1.Enabled = True
            GCombo1.SelectedIndex = 9

        ElseIf ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1))) <> "00" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "1F" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "3F" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "59" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "7F" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "A5" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "BF" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "DF" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "FE" And ((ReadHEX(LoadedROM, ((baseoff) + 16) + (i * 28), 1))) <> "FF" Then
            G2.Checked = True
            GCombo1.Enabled = False
            GVal.Enabled = True
            GVal.Text = ((ReadHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), 1)))

        End If

    End Sub

    Private Sub BaseSave()

        WriteHEX(LoadedROM, (baseoff) + 28 + (i * 28), Hex(HpBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 1) + (i * 28), Hex(AtBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 2) + (i * 28), Hex(DefBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 3) + (i * 28), Hex(SpeedBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 4) + (i * 28), Hex(SpAttBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 5) + (i * 28), Hex(SpDefBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 8) + (i * 28), Hex(CatchBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 24) + (i * 28), Hex(RunBase.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 12) + (i * 28), ReverseHEX(VB.Right("0000" & Hex(Item1.SelectedIndex), 4)))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 14) + (i * 28), ReverseHEX(VB.Right("0000" & Hex(Item2.SelectedIndex), 4)))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 6) + (i * 28), Hex(Type1.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 7) + (i * 28), Hex(Type2.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 22) + (i * 28), Hex(Ab1.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 23) + (i * 28), Hex(Ab2.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 10) + (i * 28), Hex(Ev1.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 11) + (i * 28), Hex(Ev2.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 20) + (i * 28), Hex(EggType1.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 21) + (i * 28), Hex(EggType2.SelectedIndex))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 9) + (i * 28), Hex(Bexp.Text))
        WriteHEX(LoadedROM, ((baseoff) + 28 + 19) + (i * 28), Hex(Grate.SelectedIndex))

        If SH1.Checked = True Then

            If SHCombo1.SelectedIndex = 0 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "00")

            ElseIf SHCombo1.SelectedIndex = 1 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "05")

            ElseIf SHCombo1.SelectedIndex = 2 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "0A")

            ElseIf SHCombo1.SelectedIndex = 3 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "0F")

            ElseIf SHCombo1.SelectedIndex = 4 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "14")

            ElseIf SHCombo1.SelectedIndex = 5 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "19")

            ElseIf SHCombo1.SelectedIndex = 6 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "1E")

            ElseIf SHCombo1.SelectedIndex = 7 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "23")

            ElseIf SHCombo1.SelectedIndex = 8 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "28")

            ElseIf SHCombo1.SelectedIndex = 9 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "50")

            ElseIf SHCombo1.SelectedIndex = 10 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), "78")

            End If

        ElseIf SH2.Checked = True Then

            WriteHEX(LoadedROM, ((baseoff) + 28 + 17) + (i * 28), SHVal.Text)

        End If

        If Rght1.Checked = True Then

            WriteHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), Hex(Clr1.SelectedIndex))

        ElseIf Lft1.Checked = True Then

            WriteHEX(LoadedROM, ((baseoff) + 28 + 25) + (i * 28), Hex(128 + Clr1.SelectedIndex))

        End If

        If HP1.Checked = True Then

            If HPCombo1.SelectedIndex = 0 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "00")

            ElseIf HPCombo1.SelectedIndex = 1 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "23")

            ElseIf HPCombo1.SelectedIndex = 2 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "46")

            ElseIf HPCombo1.SelectedIndex = 3 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "5A")

            ElseIf HPCombo1.SelectedIndex = 4 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "64")

            ElseIf HPCombo1.SelectedIndex = 5 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "8C")

            ElseIf HPCombo1.SelectedIndex = 6 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), "FF")

            End If

        ElseIf HP2.Checked = True Then

            WriteHEX(LoadedROM, ((baseoff) + 28 + 18) + (i * 28), HPVal.Text)

        End If

        If G1.Checked = True Then

            If GCombo1.SelectedIndex = 0 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "00")

            ElseIf GCombo1.SelectedIndex = 1 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "1F")

            ElseIf GCombo1.SelectedIndex = 2 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "3F")

            ElseIf GCombo1.SelectedIndex = 3 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "59")

            ElseIf GCombo1.SelectedIndex = 4 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "7F")

            ElseIf GCombo1.SelectedIndex = 5 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "A5")

            ElseIf GCombo1.SelectedIndex = 6 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "BF")

            ElseIf GCombo1.SelectedIndex = 7 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "DF")

            ElseIf GCombo1.SelectedIndex = 8 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "FE")

            ElseIf GCombo1.SelectedIndex = 9 Then

                WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), "FF")

            End If

        ElseIf G2.Checked = True Then

            WriteHEX(LoadedROM, ((baseoff) + 28 + 16) + (i * 28), GVal.Text)

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        i = PKMNames.SelectedIndex
        BaseSave()
        EvoSave()
        TMHMCOMSave()
        MTComSave()
    End Sub



    Private Sub MediaLoad()
        FrontSpritePointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonFrontSprites", "")), System.Globalization.NumberStyles.HexNumber)
        BackSpritePointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonBackSprites", "")), System.Globalization.NumberStyles.HexNumber)
        NormalPalPointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonNormalPal", "")), System.Globalization.NumberStyles.HexNumber)
        ShinyPalPointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonShinyPal", "")), System.Globalization.NumberStyles.HexNumber)
        IconPointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "IconPointerTable", "")), System.Globalization.NumberStyles.HexNumber)
        IconPalTable = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber)
        FootPrintTable = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "FootPrintTable", "")), System.Globalization.NumberStyles.HexNumber)
        CryTable = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "CryTable", "")), System.Globalization.NumberStyles.HexNumber)
        CryTable2 = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "CryConversionTable", "")), System.Globalization.NumberStyles.HexNumber)

        FrontPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (FrontSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BackPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (BackSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        ShinyPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (ShinyPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        NormalPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (NormalPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

        IconPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (IconPointers) + (4) + (i * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        IconPal.SelectedIndex = Int32.Parse(((ReadHEX(LoadedROM, (IconPalTable) + (1) + (i), 1))), System.Globalization.NumberStyles.HexNumber)

        FootPrintPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (FootPrintTable) + (4) + (i * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


        'cry stuff with conversion table support
        If (i + 1) < 251 Then
            GroupBox21.Enabled = True
            CryPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (CryTable) + (4) + (i * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            CryConver.Text = ""

            CryConver.Enabled = False
            Button13.Enabled = False
        ElseIf (i + 1) > 251 And (i + 1) <= 276 Then

            GroupBox21.Enabled = False
            CryPointer.Text = ""
            CryConver.Text = ""
        End If
        If (i + 1) > 276 Then
            GroupBox21.Enabled = True
            CryConver.Enabled = True
            Button13.Enabled = True

            ' MsgBox((CryTable2) + ((i - 276) * 2))
            CryConver.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            CryPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable) + (4)) + ((CryConver.Text) * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        End If


        Button2.Enabled = False
        AnimationPointer.Text = ""
        AnimationPointer.Enabled = False
        AniPic.Image = Nothing
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then


            If header2 = "BPE" Then
                Button2.Enabled = True
                AnimationPointer.Enabled = True

                AnimationPointers = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonAnimations", "")), System.Globalization.NumberStyles.HexNumber)
                AnimationPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AnimationPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

                GetAndDrawAnimationPokemonPic(AniPic, i + 1)
            End If
            GetAndDrawFrontPokemonPic(FrntPic, i + 1)
            GetAndDrawBackPokemonPic(BckPic, i + 1)
            GetAndDrawFrontPokemonPic(EvoBasePokePic, i + 1)
            GetAndDrawPokemonIconPic(IconPicBox, i, IconPal.SelectedIndex)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If header2 = "BPE" Then
            i = PKMNames.SelectedIndex
            WriteHEX(LoadedROM, (AnimationPointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((AnimationPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

                GetAndDrawAnimationPokemonPic(AniPic, i + 1)
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        i = PKMNames.SelectedIndex

        WriteHEX(LoadedROM, (FrontSpritePointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((FrontPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, (BackSpritePointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((BackPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, (ShinyPalPointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((ShinyPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, (NormalPalPointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((NormalPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            GetAndDrawFrontPokemonPic(FrntPic, i + 1)
            GetAndDrawBackPokemonPic(BckPic, i + 1)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        i = PKMNames.SelectedIndex
        WriteHEX(LoadedROM, (IconPointers) + (4) + (i * 4), ReverseHEX(Hex(Int32.Parse(((IconPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        WriteHEX(LoadedROM, (IconPalTable) + (1) + (i), (Hex(Val(IconPal.SelectedIndex))))

        GetAndDrawPokemonIconPic(IconPicBox, i, IconPal.SelectedIndex)
    End Sub

    Private Sub EvoSlots_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoSlots.SelectedIndexChanged
        Dim loopy As Integer = 0

        EvoData = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonEvolutions", "")), System.Globalization.NumberStyles.HexNumber)



        'Reset the evolution stuff!

        EvoTypes.SelectedIndex = -1
        EvoPKMNames.Enabled = False
        EvoItem.Enabled = False
        EvoPKMNames.Enabled = False
        EvoLevel.Enabled = False
        EvoItem.SelectedIndex = -1
        EvoLevel.Text = ""
        EvoPKMNames.SelectedIndex = -1

        'attack
        ComboBox3.Enabled = False
        ComboBox3.SelectedIndex = -1
        'map name
        ComboBox2.Enabled = False
        ComboBox2.SelectedIndex = -1
        'bank and map
        TextBox1.Enabled = False
        TextBox1.Text = ""
        TextBox2.Enabled = False
        TextBox2.Text = ""
        'species
        ComboBox1.Enabled = False
        ComboBox1.SelectedIndex = -1


        EvoTypes.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)


        'This will enable the right stuff

        If (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoPKMNames.SelectedIndex = -1

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            EvoLevel.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            EvoItem.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            ComboBox3.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)
            ComboBox3.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            If header2 = "BPR" Or header2 = "BPG" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber) - 88
                ComboBox2.Enabled = True

            ElseIf header2 = "BPE" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox2.Enabled = True
            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox2.Enabled = True
            End If

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            ComboBox1.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)
            ComboBox1.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            TextBox1.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox2.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)

            TextBox1.Enabled = True
            TextBox2.Enabled = True

        End If
    End Sub

    Private Sub SH1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SHCombo1.Enabled = True
        SHVal.Enabled = False
    End Sub

    Private Sub SH2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SHCombo1.Enabled = False
        SHVal.Enabled = True
    End Sub

    Private Sub HP1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HP1.CheckedChanged
        HPCombo1.Enabled = True
        HPVal.Enabled = False
    End Sub

    Private Sub HP2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HP2.CheckedChanged
        HPCombo1.Enabled = False
        HPVal.Enabled = True
    End Sub

    Private Sub G1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G1.CheckedChanged
        GCombo1.Enabled = True
        GVal.Enabled = False
    End Sub

    Private Sub G2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles G2.CheckedChanged
        GCombo1.Enabled = False
        GVal.Enabled = True
    End Sub

    Private Sub EvoSave()

        If (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoItem.SelectedIndex)), 4)))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(ComboBox3.SelectedIndex)), 4)))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))

            If header2 = "BPR" Or header2 = "BPG" Then
                WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex + 88)))
            ElseIf header2 = "BPE" Then
                WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            End If

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(ComboBox1.SelectedIndex)), 4)))

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            WriteHEX(LoadedROM, (EvoData) + (40) + (0) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (40) + (4) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (2) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox1.Text)))
            WriteHEX(LoadedROM, (EvoData) + (40) + (3) + ((PKMNames.SelectedIndex) * 40) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox2.Text)))

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

                EvoItemPic.Image = Nothing

            End If

        Else
            EvoItemPic.Image = Nothing
        End If

    End Sub

    Private Sub Item1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item1.SelectedIndexChanged
        If header2 = "BPR" Or header2 = "BPG" Then

            GetAndDrawItemPic(HeldItem1, Item1.SelectedIndex)

        ElseIf header2 = "BPE" Then

            GetAndDrawItemPic(HeldItem1, Item1.SelectedIndex)

        ElseIf header2 = "AXP" Or header2 = "AXV" Then

            HeldItem1.Image = Nothing

        End If
    End Sub

    Private Sub Item2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item2.SelectedIndexChanged
        If header2 = "BPR" Or header2 = "BPG" Then

            GetAndDrawItemPic(HeldItem2, Item2.SelectedIndex)

        ElseIf header2 = "BPE" Then

            GetAndDrawItemPic(HeldItem2, Item2.SelectedIndex)

        ElseIf header2 = "AXP" Or header2 = "AXV" Then

            HeldItem2.Image = Nothing

        End If
    End Sub


    Private Sub PKMNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PKMNames.SelectedIndexChanged
        i = PKMNames.SelectedIndex


        Baseload()

        MediaLoad()

        TMHMCOMLoad()

        LearnableMoveLoad()

        MTComLoad()

        CurPKMName.Text = GetPokemonName(PKMNames.SelectedIndex + 1)

        EvoSlots.SelectedIndex = -1
        EvoSlots.SelectedIndex = 0
        lvlupattacks.SelectedIndex = 0
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        SaveFileDialog.FileName = ""
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "PGEPKM"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter = _
            "(*.pgepkm)|*.pgepkm*"

        'SaveFileDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        SaveFileDialog.ShowHelp = False
        'SaveFileDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        'SaveFileDialog.ReadOnlyChecked = False

        SaveFileDialog.Title = "Save as"

        ' Only accept valid Win32 file names?
        SaveFileDialog.ValidateNames = True


        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            'MsgBox(SaveFileDialog.FileName)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Name", CurPKMName.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "HP", HpBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Attack", AtBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Defense", DefBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Speed", SpeedBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Sp.Attack", SpAttBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Sp.Defense", SpDefBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "CatchRate", CatchBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "RunRate", RunBase.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "BaseEXP", Bexp.Text)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Ability1", Ab1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Ability2", Ab2.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "HeldItem1", Item1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "HeldItem2", Item2.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Type1", Type1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Type2", Type2.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "GrowthRate", Grate.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "EV1", Ev1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "EV2", Ev2.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "Color", Clr1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "EggType1", EggType1.SelectedIndex)
            WriteString(SaveFileDialog.FileName, "Pokemon", "EggType2", EggType2.SelectedIndex)

            If SH1.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "SHcheck", "0")
                WriteString(SaveFileDialog.FileName, "Pokemon", "StepsToHatch", SHCombo1.SelectedIndex)
            ElseIf SH2.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "SHcheck", "1")
                WriteString(SaveFileDialog.FileName, "Pokemon", "StepsToHatch", SHVal.Text)
            End If

            If HP1.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "HPcheck", "0")
                WriteString(SaveFileDialog.FileName, "Pokemon", "Happiness", HPCombo1.SelectedIndex)
            ElseIf HP2.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "HPcheck", "1")
                WriteString(SaveFileDialog.FileName, "Pokemon", "Happiness", HPVal.Text)
            End If
            If G1.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "Gcheck", "0")
                WriteString(SaveFileDialog.FileName, "Pokemon", "Gender", GCombo1.SelectedIndex)
            ElseIf G2.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "Gcheck", "1")
                WriteString(SaveFileDialog.FileName, "Pokemon", "Gender", GVal.Text)
            End If

            If Rght1.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "Face", "0")

            ElseIf Lft1.Checked = True Then
                WriteString(SaveFileDialog.FileName, "Pokemon", "Face", "1")

            End If

            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < 58 = True
                WriteString(SaveFileDialog.FileName, "Pokemon", "TMHM" & (LoopVar + 1), TMHMCom.GetItemChecked(LoopVar))
                LoopVar = LoopVar + 1
            End While

            'MsgBox("Exported!")
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "PGEPKM"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter = _
            "(*.pgepkm)|*.pgepkm*"

        fileOpenDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        fileOpenDialog.ShowHelp = False
        fileOpenDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        fileOpenDialog.ReadOnlyChecked = False

        fileOpenDialog.Title = "Select PGEPKM file to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' MsgBox(fileOpenDialog.FileName)
            'GetString(AppPath & "GBAPGESettings.ini", "Settings", "FirstRun", "Yes")

            CurPKMName.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Name", "")
            HpBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "HP", "")
            AtBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Attack", "")
            DefBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Defense", "")
            SpeedBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Speed", "")
            SpAttBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Sp.Attack", "")
            SpDefBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "Sp.Defense", "")
            CatchBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "CatchRate", "")
            RunBase.Text = GetString(fileOpenDialog.FileName, "Pokemon", "RunRate", "")
            Bexp.Text = GetString(fileOpenDialog.FileName, "Pokemon", "BaseEXP", "")
            Ab1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "Ability1", "")
            Ab2.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "Ability2", "")
            Item1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "HeldItem1", "")
            Item2.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "HeldItem2", "")
            Type1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "Type1", "")
            Type2.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "Type2", "")
            Grate.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "GrowthRate", "")
            Ev1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "EV1", "")
            Ev2.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "EV2", "")
            Clr1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "Color", "")
            EggType1.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "EggType1", "")
            EggType2.SelectedIndex = GetString(fileOpenDialog.FileName, "Pokemon", "EggType2", "")

            If GetString(fileOpenDialog.FileName, "Pokemon", "SHcheck", "0") = "0" Then

                GetString(fileOpenDialog.FileName, "Pokemon", "StepsToHatch", SHCombo1.SelectedIndex)
                SH1.Checked = True
                SH2.Checked = False
            ElseIf GetString(fileOpenDialog.FileName, "Pokemon", "SHcheck", "0") = "1" Then

                GetString(fileOpenDialog.FileName, "Pokemon", "StepsToHatch", SHVal.Text)
                SH1.Checked = False
                SH2.Checked = True
            End If

            If GetString(fileOpenDialog.FileName, "Pokemon", "HPcheck", "0") = "0" Then
                GetString(fileOpenDialog.FileName, "Pokemon", "Happiness", HPCombo1.SelectedIndex)
                HP1.Checked = True
                HP2.Checked = False
            ElseIf GetString(fileOpenDialog.FileName, "Pokemon", "HPcheck", "0") = "1" Then
                GetString(fileOpenDialog.FileName, "Pokemon", "Happiness", HPVal.Text)
                HP1.Checked = False
                HP2.Checked = True
            End If

            If GetString(fileOpenDialog.FileName, "Pokemon", "Gcheck", "0") = "0" Then
                GetString(fileOpenDialog.FileName, "Pokemon", "Gender", GCombo1.SelectedIndex)
                G1.Checked = True
                G2.Checked = False
            ElseIf GetString(fileOpenDialog.FileName, "Pokemon", "Gcheck", "0") = "1" Then
                GetString(fileOpenDialog.FileName, "Pokemon", "Gender", GVal.Text)
                G1.Checked = False
                G2.Checked = True
            End If

            If GetString(fileOpenDialog.FileName, "Pokemon", "Face", "0") = 0 Then

                Rght1.Checked = True
                Lft1.Checked = False

            ElseIf GetString(fileOpenDialog.FileName, "Pokemon", "Face", "1") = 1 Then

                Rght1.Checked = False
                Lft1.Checked = True

            End If


            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < 58 = True
                TMHMCom.SetItemChecked(LoopVar, GetString(fileOpenDialog.FileName, "Pokemon", "TMHM" & (LoopVar + 1), "1"))
                LoopVar = LoopVar + 1
            End While
        End If
    End Sub

    Private Sub TMHMLoad()
        Dim LoopVar As Integer

        TMHMAttacks = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "TMData", "")), System.Globalization.NumberStyles.HexNumber)

        TMHMCom.Items.Clear()


        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then

            LoopVar = 0

            While LoopVar < 58 = True

                If LoopVar > 49 Then
                    TMHMCom.Items.Add("HM" & LoopVar - 49 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1

                ElseIf LoopVar < 9 Then

                    TMHMCom.Items.Add("TM" & "0" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1
                Else

                    TMHMCom.Items.Add("TM" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1
                End If
            End While
        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then

            LoopVar = 0

            While LoopVar < 104 = True

                If LoopVar > 94 Then
                    TMHMCom.Items.Add("HM" & LoopVar - 94)

                    LoopVar = LoopVar + 1

                ElseIf LoopVar < 9 Then

                    TMHMCom.Items.Add("TM" & "0" & LoopVar + 1)

                    LoopVar = LoopVar + 1
                Else

                    TMHMCom.Items.Add("TM" & LoopVar + 1)

                    LoopVar = LoopVar + 1
                End If
            End While

        End If
    End Sub

    Public Sub TMHMCOMLoad()

        i = PKMNames.SelectedIndex

        TMHMCompoLoc = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "TMHMCompatibility", "")), System.Globalization.NumberStyles.HexNumber)

        Dim blah As Integer
        Dim howmanyzeros As Integer
        Dim whichtmbyte As Integer
        Dim howmanytmschecked As Integer
        Dim looper As Integer
        Dim curposition As Integer
        Dim binarythebitch As String
        Dim curchar As String

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then
            whichtmbyte = 0

            While whichtmbyte < 8

                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, 1))), System.Globalization.NumberStyles.HexNumber)
                binarythebitch = (Convert.ToString(blah, 2))

                If whichtmbyte = 7 Then

                    howmanytmschecked = 0


                    ' MsgBox((Convert.ToString(blah, 2)))

                    If Len(binarythebitch) > 2 Then
                        MsgBox("Did you mess with the TM/HM data? Contact Gamer2020!")
                    ElseIf Len(binarythebitch) = 2 Then


                        curchar = GetChar(binarythebitch, 1)

                        If curchar = "1" Then
                            TMHMCom.SetItemChecked(57, True)

                        ElseIf curchar = "0" Then
                            TMHMCom.SetItemChecked(57, False)

                        End If

                        curchar = GetChar(binarythebitch, 2)

                        If curchar = "1" Then
                            TMHMCom.SetItemChecked(56, True)

                        ElseIf curchar = "0" Then
                            TMHMCom.SetItemChecked(56, False)

                        End If


                    ElseIf Len(binarythebitch) < 2 Then

                        TMHMCom.SetItemChecked(57, False)

                        curchar = GetChar(binarythebitch, 1)

                        If curchar = "1" Then
                            TMHMCom.SetItemChecked(56, True)

                        ElseIf curchar = "0" Then
                            TMHMCom.SetItemChecked(56, False)

                        End If


                    End If



                    whichtmbyte = whichtmbyte + 1
                Else
                    howmanytmschecked = 0


                    ' MsgBox((Convert.ToString(blah, 2)))

                    howmanyzeros = (8 - Len(binarythebitch))

                    For looper = 1 To howmanyzeros
                        TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

                        howmanytmschecked = howmanytmschecked + 1

                    Next looper

                    For curposition = 1 To Len(Convert.ToString(blah, 2))

                        ' Len(Convert.ToString(blah, 2))

                        curchar = GetChar(binarythebitch, curposition)

                        If curchar = "1" Then
                            TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, True)

                            howmanytmschecked = howmanytmschecked + 1

                        ElseIf curchar = "0" Then
                            TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

                            howmanytmschecked = howmanytmschecked + 1

                        End If
                    Next curposition
                    whichtmbyte = whichtmbyte + 1
                End If
            End While
        End If


        'seperate
        'seperate
        'seperate
        'seperate

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then

            whichtmbyte = 0

            While whichtmbyte < 13

                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMCompoLoc + 13 + (i * 13) + whichtmbyte, 1))), System.Globalization.NumberStyles.HexNumber)
                binarythebitch = (Convert.ToString(blah, 2))

                howmanytmschecked = 0




                howmanyzeros = (8 - Len(binarythebitch))

                For looper = 1 To howmanyzeros
                    TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

                    howmanytmschecked = howmanytmschecked + 1

                Next looper

                For curposition = 1 To Len(Convert.ToString(blah, 2))

                    ' Len(Convert.ToString(blah, 2))

                    curchar = GetChar(binarythebitch, curposition)

                    If curchar = "1" Then
                        TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, True)

                        howmanytmschecked = howmanytmschecked + 1

                    ElseIf curchar = "0" Then
                        TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

                        howmanytmschecked = howmanytmschecked + 1

                    End If
                Next curposition
                whichtmbyte = whichtmbyte + 1

            End While

        End If

    End Sub

    Public Sub TMHMCOMSave()
        i = PKMNames.SelectedIndex

        Dim whichtmbyte As Integer
        'Dim howmanytmschecked As Integer
        Dim looper As Integer
        Dim binarytowrite As String
        Dim bytetowrite As String

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then

            whichtmbyte = 0

            While whichtmbyte < 8

                If whichtmbyte = 7 Then

                    binarytowrite = ""
                    For looper = 0 To 1

                        If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
                            binarytowrite = "1" & binarytowrite

                        ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
                            binarytowrite = "0" & binarytowrite

                        End If

                    Next looper
                    bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
                    WriteHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, bytetowrite)

                    whichtmbyte = whichtmbyte + 1
                Else

                    binarytowrite = ""
                    For looper = 0 To 7

                        If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
                            binarytowrite = "1" & binarytowrite

                        ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
                            binarytowrite = "0" & binarytowrite

                        End If

                    Next looper
                    bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
                    WriteHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, bytetowrite)

                    whichtmbyte = whichtmbyte + 1
                End If
            End While
        End If


        'separate
        'separate
        'separate

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then

             whichtmbyte = 0

            While whichtmbyte < 13

                binarytowrite = ""
                    For looper = 0 To 7

                        If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
                            binarytowrite = "1" & binarytowrite

                        ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
                            binarytowrite = "0" & binarytowrite

                        End If

                    Next looper
                    bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
                WriteHEX(LoadedROM, TMHMCompoLoc + 13 + (i * 13) + whichtmbyte, bytetowrite)

                    whichtmbyte = whichtmbyte + 1

            End While

        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        FolderBrowserDialog.Description = "Select folder to export all this games Pokemon as PGEPKM to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True
            'MsgBox(FolderBrowserDialog.SelectedPath)
            CreateDirectory(FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs")
            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", "")) - 1 = True
                PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1
                Me.Refresh()
                Me.Enabled = False
                'TabControl1.Refresh()
                'CurPKMName.Refresh()


                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Name", CurPKMName.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "HP", HpBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Attack", AtBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Defense", DefBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Speed", SpeedBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Sp.Attack", SpAttBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Sp.Defense", SpDefBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "CatchRate", CatchBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "RunRate", RunBase.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "BaseEXP", Bexp.Text)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Ability1", Ab1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Ability2", Ab2.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "HeldItem1", Item1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "HeldItem2", Item2.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Type1", Type1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Type2", Type2.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "GrowthRate", Grate.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "EV1", Ev1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "EV2", Ev2.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Color", Clr1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "EggType1", EggType1.SelectedIndex)
                WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "EggType2", EggType2.SelectedIndex)

                If SH1.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "SHcheck", "0")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "StepsToHatch", SHCombo1.SelectedIndex)
                ElseIf SH2.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "SHcheck", "1")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "StepsToHatch", SHVal.Text)
                End If

                If HP1.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "HPcheck", "0")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Happiness", HPCombo1.SelectedIndex)
                ElseIf HP2.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "HPcheck", "1")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Happiness", HPVal.Text)
                End If
                If G1.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Gcheck", "0")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Gender", GCombo1.SelectedIndex)
                ElseIf G2.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Gcheck", "1")
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Gender", GVal.Text)
                End If

                If Rght1.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Face", "0")

                ElseIf Lft1.Checked = True Then
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "Face", "1")

                End If

                Dim LoopVarthing As Integer

                LoopVarthing = 0

                While LoopVarthing < 58 = True
                    WriteString((FolderBrowserDialog.SelectedPath & "\ExportedPGEPKMs\" & (LoopVar) & " - " & GetPokemonName(LoopVar) & ".pgepkm"), "Pokemon", "TMHM" & (LoopVarthing + 1), TMHMCom.GetItemChecked(LoopVarthing))
                    LoopVarthing = LoopVarthing + 1
                End While
                ProgressBar.Value = (LoopVar / (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", ""))) * 100
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        i = PKMNames.SelectedIndex
        WriteHEX(LoadedROM, (FootPrintTable) + (4) + (i * 4), ReverseHEX(Hex(Int32.Parse(((FootPrintPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

    End Sub

    Private Sub LearnableMoveLoad()

        Dim blah As Integer
        Dim binarythebitch As String
        Dim at As String
        Dim lvl As String
        'Dim loopme As Integer
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 0 Then

            AttackTable = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)

            LvlUpAttPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

                binarythebitch = Convert.ToString(blah, 2)

                While Len(binarythebitch) < 16

                    binarythebitch = "0" & binarythebitch

                End While

                lvl = Mid(binarythebitch, 1, 7)

                at = Mid(binarythebitch, 8, 9)

                lvl = Convert.ToInt32(lvl, 2)

                at = Convert.ToInt32(at, 2)
                lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))
                Looper = Looper + 1
            End While
        End If


        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 1 Then
            AttackTable = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)

            LvlUpAttPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 3) = GetString(AppPath & "ini\roms.ini", header, "JamboLearnableMovesTerm", "") = False

                lvl = Int32.Parse(((ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3) + 2, 1))), System.Globalization.NumberStyles.HexNumber)

                at = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 2))), System.Globalization.NumberStyles.HexNumber)
                lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))
                Looper = Looper + 1
            End While
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim blah As Integer
        Dim binarythebitch As String
        Dim at As String
        Dim lvl As String

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 0 Then
            i = PKMNames.SelectedIndex
            WriteHEX(LoadedROM, (AttackTable) + (4) + (i * 4), ReverseHEX(Hex(Int32.Parse(((LvlUpAttPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

                binarythebitch = Convert.ToString(blah, 2)

                While Len(binarythebitch) < 16

                    binarythebitch = "0" & binarythebitch

                End While
                ' MsgBox(binarythebitch)
                lvl = Mid(binarythebitch, 1, 7)

                at = Mid(binarythebitch, 8, 9)

                lvl = Convert.ToInt32(lvl, 2)

                at = Convert.ToInt32(at, 2)
                lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))
                Looper = Looper + 1
            End While
        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 1 Then
            i = PKMNames.SelectedIndex
            WriteHEX(LoadedROM, (AttackTable) + (4) + (i * 4), ReverseHEX(Hex(Val("&H" & (LvlUpAttPointer.Text)) + &H8000000)))
            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 3) = GetString(AppPath & "ini\roms.ini", header, "JamboLearnableMovesTerm", "") = False

                lvl = Int32.Parse(((ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3) + 2, 1))), System.Globalization.NumberStyles.HexNumber)

                at = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 2))), System.Globalization.NumberStyles.HexNumber)
                lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))
                Looper = Looper + 1
            End While
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        i = PKMNames.SelectedIndex



        If (i + 1) < 251 Then
            WriteHEX(LoadedROM, (CryTable) + (4) + (i * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        ElseIf (i + 1) > 251 And (i + 1) < 276 Then

            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 276 Then

            WriteHEX(LoadedROM, (CryTable) + (4) + (((Int32.Parse(("&H" & ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        End If
    End Sub

    Private Sub Jambo51HackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jambo51HackToolStripMenuItem.Click
        JamboHackEvos.Show()
    End Sub

    Private Sub MTLoad()
        Dim LoopVar As Integer
        MTattacks = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)

        MTCom.Items.Clear()

        LoopVar = 0
        If header2 = "BPE" Then
            MTCom.Enabled = True
            While LoopVar < 32
                MTCom.Items.Add(GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTattacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))
                LoopVar = LoopVar + 1

            End While
        ElseIf header2 = "BPR" Or header2 = "BPE" Then
            MTCom.Enabled = True

            While LoopVar < 16
                MTCom.Items.Add(GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTattacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))
                LoopVar = LoopVar + 1

            End While
        Else
            MTCom.Enabled = False
        End If


    End Sub
    Private Sub MTComLoad()
        Dim LoopVar As Integer
        Dim binarythebitch As String
        Dim emloop As Integer
        Dim blah As Integer
        Dim curchar As String
        MTCompoLoc = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber)


        If header2 = "BPE" Then
            For emloop = 0 To 1
                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTCompoLoc + 4 + (PKMNames.SelectedIndex * 4) + (emloop * 2), 2))), System.Globalization.NumberStyles.HexNumber)
                binarythebitch = (Convert.ToString(blah, 2))
                While Len(binarythebitch) < 16

                    binarythebitch = "0" & binarythebitch

                End While
                LoopVar = 0

                While LoopVar < 16
                    curchar = GetChar(binarythebitch, LoopVar + 1)


                    If curchar = "1" Then
                        MTCom.SetItemChecked((emloop * 16) + 15 - LoopVar, True)


                    ElseIf curchar = "0" Then

                        MTCom.SetItemChecked((emloop * 16) + 15 - LoopVar, False)
                    End If

                    LoopVar = LoopVar + 1
                End While
            Next emloop

        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTCompoLoc + 2 + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)
            binarythebitch = (Convert.ToString(blah, 2))
            While Len(binarythebitch) < 16

                binarythebitch = "0" & binarythebitch

            End While
            LoopVar = 0

            While LoopVar < 16
                curchar = GetChar(binarythebitch, LoopVar + 1)


                If curchar = "1" Then
                    MTCom.SetItemChecked(15 - LoopVar, True)


                ElseIf curchar = "0" Then

                    MTCom.SetItemChecked(15 - LoopVar, False)
                End If

                LoopVar = LoopVar + 1
            End While
        Else
        End If

    End Sub
    Private Sub MTComSave()
        i = PKMNames.SelectedIndex

        Dim looper As Integer
        Dim binarytowrite As String
        Dim bytetowrite As String

        Dim LoopVar As Integer
        Dim binarythebitch As String
        Dim emloop As Integer
        Dim blah As Integer
        Dim curchar As String

        If header2 = "BPE" Then
            For emloop = 0 To 1
                binarytowrite = ""
                For looper = 0 To 15

                    If MTCom.GetItemChecked((emloop * 16) + 15 - looper) = True Then
                        binarytowrite = binarytowrite & "1"

                    ElseIf MTCom.GetItemChecked((emloop * 16) + 15 - looper) = False Then
                        binarytowrite = binarytowrite & "0"

                    End If

                Next looper

                bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
                WriteHEX(LoadedROM, MTCompoLoc + 4 + (PKMNames.SelectedIndex * 4) + (emloop * 2), ReverseHEX(bytetowrite))
            Next emloop

        ElseIf header2 = "BPR" Or header2 = "BPG" Then
            binarytowrite = ""
                For looper = 0 To 15

                If MTCom.GetItemChecked((0 * 16) + 15 - looper) = True Then
                    binarytowrite = binarytowrite & "1"

                ElseIf MTCom.GetItemChecked((0 * 16) + 15 - looper) = False Then
                    binarytowrite = binarytowrite & "0"

                End If

                Next looper

                bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
            WriteHEX(LoadedROM, MTCompoLoc + 2 + (PKMNames.SelectedIndex * 2) + (0 * 2), ReverseHEX(bytetowrite))

        Else
        End If
    End Sub

    Private Sub lvlupattacks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvlupattacks.SelectedIndexChanged

        Dim blah As Integer
        Dim binarythebitch As String
        Dim at As String
        Dim lvl As String
        Dim pointer As String
        'Dim loopme As Integer

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 0 Then

            pointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            binarythebitch = Convert.ToString(blah, 2)

            While Len(binarythebitch) < 16

                binarythebitch = "0" & binarythebitch

            End While
            ' MsgBox(binarythebitch)
            lvl = Mid(binarythebitch, 1, 7)

            at = Mid(binarythebitch, 8, 9)

            lvl = Convert.ToInt32(lvl, 2)

            at = Convert.ToInt32(at, 2)
            'lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))

            AtLvl.Text = lvl
            NewAt.SelectedIndex = at
        End If
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 1 Then

            pointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvl = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 3) + 2, 1))), System.Globalization.NumberStyles.HexNumber)

            at = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 3), 2))), System.Globalization.NumberStyles.HexNumber)

            AtLvl.Text = lvl
            NewAt.SelectedIndex = at
        End If

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        InputAttacks.ShowDialog()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        'Start of new function.
        Dim holder As String
        Dim bytetowrite As String
        Dim at As String
        Dim lvl As String
        Dim pointer As String
        Dim temp As Integer
        'Dim loopme As Integer

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 0 Then
            holder = lvlupattacks.SelectedIndex
            pointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvl = AtLvl.Text
            at = NewAt.SelectedIndex

            temp = Int32.Parse(Hex(lvl), System.Globalization.NumberStyles.HexNumber)
            lvl = Convert.ToString(temp, 2)

            temp = Int32.Parse(Hex(at), System.Globalization.NumberStyles.HexNumber)
            at = Convert.ToString(temp, 2)

            While Len(lvl) < 7

                lvl = "0" & lvl

            End While

            While Len(at) < 9

                at = "0" & at

            End While
            bytetowrite = lvl & at
            bytetowrite = Convert.ToInt32(bytetowrite, 2)
            bytetowrite = ReverseHEX(Hex(bytetowrite))
            WriteHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 2), bytetowrite)
        End If


        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = 1 Then
            holder = lvlupattacks.SelectedIndex
            pointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvl = Hex(AtLvl.Text)
            at = ReverseHEX(VB.Right("0000" & Hex(NewAt.SelectedIndex), 4))



            WriteHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 3), at)
            WriteHEX(LoadedROM, Int32.Parse((pointer), System.Globalization.NumberStyles.HexNumber) + (lvlupattacks.SelectedIndex * 3) + 2, lvl)
        End If
        LearnableMoveLoad()

        lvlupattacks.SelectedIndex = holder
    End Sub

    Private Sub ChangePKMName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePKMName.Click
        i = PKMNames.SelectedIndex
        Dim tempy As Integer
        tempy = i

        ChangePokemonName(i + 1, CurPKMName.Text)

        Dim LoopVar As Integer

        LoopVar = 0

        PKMNames.Items.Clear()
        EvoPKMNames.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))


        End While

        PKMNames.SelectedIndex = tempy
    End Sub

    Private Sub IconPal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IconPal.SelectedIndexChanged
        i = PKMNames.SelectedIndex
        GetAndDrawPokemonIconPic(IconPicBox, i, IconPal.SelectedIndex)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        i = PKMNames.SelectedIndex



        If (i + 1) < 251 Then
            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 251 And (i + 1) < 276 Then

            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 276 Then

            WriteHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), ReverseHEX(VB.Right("0000" & Hex(CryConver.Text), 4)))

            CryPointer.Text = Hex(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, ((CryTable) + (4)) + ((CryConver.Text) * 12), 4)), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        End If
    End Sub

    Private Sub CryPointer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CryPointer.TextChanged

    End Sub

    Private Sub EvoTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EvoTypes.SelectedIndexChanged

        EvoPKMNames.Enabled = False
        EvoItem.Enabled = False
        EvoPKMNames.Enabled = False
        EvoLevel.Enabled = False
        EvoItem.SelectedIndex = -1
        EvoLevel.Text = ""
        EvoPKMNames.SelectedIndex = -1
        'attack
        ComboBox3.Enabled = False
        ComboBox3.SelectedIndex = -1
        'map name
        ComboBox2.Enabled = False
        ComboBox2.SelectedIndex = -1
        'bank and map
        TextBox1.Enabled = False
        TextBox1.Text = ""
        TextBox2.Enabled = False
        TextBox2.Text = ""
        'species
        ComboBox1.Enabled = False
        ComboBox1.SelectedIndex = -1

        If (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoPKMNames.SelectedIndex = -1

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            EvoPKMNames.SelectedIndex = 0
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            EvoLevel.Text = "1"

            EvoPKMNames.SelectedIndex = 0
             EvoPKMNames.Enabled = True
            EvoLevel.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            EvoPKMNames.Enabled = True
            EvoPKMNames.SelectedIndex = 0
            EvoItem.SelectedIndex = 1
            EvoItem.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            EvoPKMNames.Enabled = True
            EvoPKMNames.SelectedIndex = 0

            ComboBox3.SelectedIndex = 0
            ComboBox3.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            EvoPKMNames.Enabled = True
            EvoPKMNames.SelectedIndex = 0

            ComboBox2.SelectedIndex = 0
            ComboBox2.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            EvoPKMNames.Enabled = True
            EvoPKMNames.SelectedIndex = 0

            ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = True

        ElseIf (GetString(AppPath & "ini\roms.ini", header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            EvoPKMNames.Enabled = True
            EvoPKMNames.SelectedIndex = 0

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Enabled = True
            TextBox2.Enabled = True

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            If ComboBox1.SelectedIndex + 1 > 0 Then
                GetAndDrawFrontPokemonPic(PictureBox2, ComboBox1.SelectedIndex + 1)
            Else
                PictureBox2.Image = Nothing
            End If
        End If
    End Sub
End Class