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
    Dim CryTable3 As Integer
    Dim MTattacks As Integer
    Dim MTCompoLoc As Integer

    Dim DexDescripLength1 As Integer
    Dim DexDescripLength2 As Integer

    Private Sub Pokemonedit_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub



    Private Sub Pokemonedit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' ledrom = New ROM(LoadedROM)

        Type1.Items.Clear()
        Type2.Items.Clear()

        Type1.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGETypeList.txt"))
        Type2.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGETypeList.txt"))

        BackgroundBox.Image = Image.FromFile(AppPath & "img\BattlePreviewBackground.png")

        Dim LoopVar As Integer

        LoopVar = 0

        EvoTypes.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfEvolutionTypes", "") + 1) = True

            EvoTypes.Items.Add(GetString(GetINIFileLocation(), header, "EvolutionName" & LoopVar, ""))

            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        EvoSlots.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")) = True

            LoopVar = LoopVar + 1

            EvoSlots.Items.Add("Evolution " & (LoopVar))

        End While

        LoopVar = 0

        NewAt.Items.Clear()

        ComboBox3.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            NewAt.Items.Add(GetAttackName(LoopVar))
            ComboBox3.Items.Add(GetAttackName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        PKMNames.Items.Clear()
        EvoPKMNames.Items.Clear()
        ComboBox1.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))
            ComboBox1.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 0

        Item1.Items.Clear()
        Item2.Items.Clear()
        EvoItem.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True
            Item1.Items.Add(GetItemName(LoopVar))
            Item2.Items.Add(GetItemName(LoopVar))
            EvoItem.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1



        End While

        LoopVar = 0

        Ab1.Items.Clear()
        Ab2.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

            Ab1.Items.Add(GetAbilityName(LoopVar))
            Ab2.Items.Add(GetAbilityName(LoopVar))

            LoopVar = LoopVar + 1



        End While

        If header2 = "BPR" Or header2 = "BPG" Then
            ItmAnmtn.Enabled = True
            ItmAnmtn.Text = ""
        Else
            ItmAnmtn.Enabled = False
            ItmAnmtn.Text = ""
        End If


        If header2 = "AXP" Or header2 = "AXV" Then
            Pointer2.Enabled = True
            Description2.Enabled = True
        Else
            Pointer2.Enabled = False
            Description2.Enabled = False
        End If

        TMHMLoad()
        MTLoad()

        PKMNames.SelectedIndex = 0

        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub Baseload()

        baseoff = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonData", "")), System.Globalization.NumberStyles.HexNumber)

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
        PadBase.Text = ((ReadHEX(LoadedROM, ((baseoff) + 28 + 26) + (i * 28), 2)))

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
        WriteHEX(LoadedROM, ((baseoff) + 28 + 26) + (i * 28), (PadBase.Text))

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
        DexDataSave()
        SaveSpritePosition()

        If header2 = "BPR" Or header2 = "BPG" Then

            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ItemAnimationTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 5), ItmAnmtn.Text)
            ItmAnmtn.Text = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ItemAnimationTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 5), 5)

        Else

            ItmAnmtn.Enabled = False

        End If

    End Sub



    Private Sub MediaLoad()

        i = PKMNames.SelectedIndex

        FrontSpritePointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonFrontSprites", "")), System.Globalization.NumberStyles.HexNumber)
        BackSpritePointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonBackSprites", "")), System.Globalization.NumberStyles.HexNumber)
        NormalPalPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonNormalPal", "")), System.Globalization.NumberStyles.HexNumber)
        ShinyPalPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonShinyPal", "")), System.Globalization.NumberStyles.HexNumber)
        IconPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "IconPointerTable", "")), System.Globalization.NumberStyles.HexNumber)
        IconPalTable = Int32.Parse((GetString(GetINIFileLocation(), header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber)
        FootPrintTable = Int32.Parse((GetString(GetINIFileLocation(), header, "FootPrintTable", "")), System.Globalization.NumberStyles.HexNumber)
        CryTable = Int32.Parse((GetString(GetINIFileLocation(), header, "CryTable", "")), System.Globalization.NumberStyles.HexNumber)
        CryTable2 = Int32.Parse((GetString(GetINIFileLocation(), header, "CryConversionTable", "")), System.Globalization.NumberStyles.HexNumber)
        CryTable3 = Int32.Parse((GetString(GetINIFileLocation(), header, "CryTable2", "")), System.Globalization.NumberStyles.HexNumber)

        FrontPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (FrontSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BackPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (BackSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        ShinyPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (ShinyPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        NormalPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (NormalPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

        IconPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (IconPointers) + (4) + (i * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        IconPal.SelectedIndex = Int32.Parse(((ReadHEX(LoadedROM, (IconPalTable) + (1) + (i), 1))), System.Globalization.NumberStyles.HexNumber)

        FootPrintPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (FootPrintTable) + (4) + (i * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


        'cry stuff with conversion table support
        If (i + 1) < 252 Then
            GroupBox21.Enabled = True
            GroupBox34.Enabled = True
            GroupBox35.Enabled = True


            CryPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (CryTable) + (4) + (i * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            CryConver.Text = ""
            CryPointer2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (CryTable3) + (4) + (i * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            CryComp1.Text = Hex(Int32.Parse(((ReadHEX(LoadedROM, (CryTable) + (i * 12), 1))), System.Globalization.NumberStyles.HexNumber))
            CryComp2.Text = Hex(Int32.Parse(((ReadHEX(LoadedROM, (CryTable3) + (i * 12), 1))), System.Globalization.NumberStyles.HexNumber))

            crynorm = LoadCry(i, CryTable)
            crygrowl = LoadCry(i, CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

            'Label53.Text = "Sample Rate: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer.Text) + (4), 4)))), System.Globalization.NumberStyles.HexNumber)) >> 10) & " Hz"
            'Label54.Text = "Sample Rate: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer2.Text) + (4), 4)))), System.Globalization.NumberStyles.HexNumber)) >> 10) & " Hz"

            'Label55.Text = "Size: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer.Text) + (12), 4)))), System.Globalization.NumberStyles.HexNumber)) + 1) & " samples"
            'Label56.Text = "Size: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer2.Text) + (12), 4)))), System.Globalization.NumberStyles.HexNumber)) + 1) & " samples"

            CryConver.Enabled = False
            Button13.Enabled = False


        ElseIf (i + 1) > 251 And (i + 1) <= 276 Then

            GroupBox21.Enabled = False
            GroupBox34.Enabled = False
            GroupBox35.Enabled = False
            CryPointer.Text = ""
            CryPointer2.Text = ""
            CryConver.Text = ""

            CryComp1.Text = ""
            CryComp2.Text = ""

            Label53.Text = "Sample Rate: " & 0 & " Hz"
            Label54.Text = "Sample Rate: " & 0 & " Hz"

            Label55.Text = "Size: 0 samples"
            Label56.Text = "Size: 0 samples"

            chkCompressed1.Checked = False
            chkCompressed2.Checked = False

            'pSample.Image.Dispose()
            'pSample2.Image.Dispose()

        End If


        If (i + 1) > 276 Then
            GroupBox21.Enabled = True
            CryConver.Enabled = True
            Button13.Enabled = True
            GroupBox34.Enabled = True
            GroupBox35.Enabled = True

            ' MsgBox((CryTable2) + ((i - 276) * 2))
            CryConver.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            CryPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable) + (4)) + ((CryConver.Text) * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            CryPointer2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable3) + (4)) + ((CryConver.Text) * 12), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            crynorm = LoadCry(CryConver.Text, CryTable)
            crygrowl = LoadCry(CryConver.Text, CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        End If


        Button2.Enabled = False
        AnimationPointer.Text = ""
        AnimationPointer.Enabled = False
        AniPic.Image = Nothing
        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then


            If header2 = "BPE" Then
                Button2.Enabled = True
                AnimationPointer.Enabled = True

                AnimationPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAnimations", "")), System.Globalization.NumberStyles.HexNumber)
                AnimationPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AnimationPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

                GetAndDrawAnimationPokemonPic(AniPic, i + 1)
                GetAndDrawAnimationPokemonPicShiny(AniPic2, i + 1)
            End If
            GetAndDrawFrontPokemonPic(FrntPic, i + 1)
            GetAndDrawBackPokemonPic(BckPic2, i + 1)
            GetAndDrawFrontPokemonPicShiny(FrntPic2, i + 1)
            GetAndDrawBackPokemonPicNormal(BckPic, i + 1)

            'GetAndDrawFrontPokemonPic(EvoBasePokePic, i + 1)
            GetAndDrawPokemonIconPic(IconPicBox, i + 1, IconPal.SelectedIndex)
            GetAndDrawPokemonFootPrint(PictureBox1, i + 1)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If header2 = "BPE" Then
            i = PKMNames.SelectedIndex
            WriteHEX(LoadedROM, (AnimationPointers) + (8) + (i * 8), ReverseHEX(Hex(Int32.Parse(((AnimationPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

                GetAndDrawAnimationPokemonPic(AniPic, i + 1)
                GetAndDrawAnimationPokemonPicShiny(AniPic2, i + 1)
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
            GetAndDrawBackPokemonPic(BckPic2, i + 1)
            GetAndDrawFrontPokemonPicShiny(FrntPic2, i + 1)
            GetAndDrawBackPokemonPicNormal(BckPic, i + 1)
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        i = PKMNames.SelectedIndex
        WriteHEX(LoadedROM, (IconPointers) + (4) + (i * 4), ReverseHEX(Hex(Int32.Parse(((IconPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        WriteHEX(LoadedROM, (IconPalTable) + (1) + (i), (Hex(Val(IconPal.SelectedIndex))))

        GetAndDrawPokemonIconPic(IconPicBox, i + 1, IconPal.SelectedIndex)
    End Sub

    Private Sub EvoSlots_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EvoSlots.SelectedIndexChanged
        Dim loopy As Integer = 0

        EvoData = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonEvolutions", "")), System.Globalization.NumberStyles.HexNumber)



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
        'value
        TextBox6.Text = ""
        TextBox6.Enabled = False


        EvoTypes.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)


        'This will enable the right stuff

        If (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoPKMNames.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            EvoPKMNames.SelectedIndex = -1

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            EvoLevel.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            EvoItem.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoItem.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            ComboBox3.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)
            ComboBox3.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            If header2 = "BPR" Or header2 = "BPG" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber) - 88
                ComboBox2.Enabled = True

            ElseIf header2 = "BPE" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox2.Enabled = True
            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox2.Enabled = True
            End If

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            ComboBox1.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            ComboBox1.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True

            TextBox1.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox2.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (3) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)

            TextBox1.Enabled = True
            TextBox2.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbasedonvalue" Then

            EvoPKMNames.SelectedIndex = -1
            EvoPKMNames.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber) - 1
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False

            TextBox6.Enabled = True
            TextBox6.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), 2)))), System.Globalization.NumberStyles.HexNumber)

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

        If (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(EvoLevel.Text)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (3) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex("00")))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoItem.SelectedIndex)), 4)))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(ComboBox3.SelectedIndex)), 4)))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))

            If header2 = "BPR" Or header2 = "BPG" Then
                WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex + 88)))
            ElseIf header2 = "BPE" Then
                WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            ElseIf header2 = "AXP" Or header2 = "AXV" Then
                WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(ComboBox2.SelectedIndex)))

            End If

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(ComboBox1.SelectedIndex) + 1), 4)))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox1.Text)))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (3) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(Hex(TextBox2.Text)))

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbasedonvalue" Then

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (0) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), Hex(EvoTypes.SelectedIndex))
            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (4) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(EvoPKMNames.SelectedIndex) + 1), 4)))

            WriteHEX(LoadedROM, (EvoData) + (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", ""))) + (2) + ((PKMNames.SelectedIndex) * (8 * (GetString(GetINIFileLocation(), header, "NumberOfEvolutionsPerPokemon", "")))) + (EvoSlots.SelectedIndex * 8), ReverseHEX(VB.Right("0000" & Hex(Val(TextBox6.Text)), 4)))

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

        Me.Enabled = False

        i = PKMNames.SelectedIndex
        PokemonListIndex.Text = PKMNames.SelectedIndex + 1


        Baseload()

        MediaLoad()

        TMHMCOMLoad()

        LearnableMoveLoad()

        MTComLoad()

        LoadDexData()

        LoadSpritePosition()

        CurPKMName.Text = GetPokemonName(PKMNames.SelectedIndex + 1)

        If header2 = "BPR" Or header2 = "BPG" Then

            ItmAnmtn.Text = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ItemAnimationTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 5), 5)
        Else
            ItmAnmtn.Enabled = False
        End If

        EvoSlots.SelectedIndex = -1
        EvoSlots.SelectedIndex = 0
        lvlupattacks.SelectedIndex = 0

        Me.Enabled = True

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".ini"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "ini"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.ini)|*.ini*"

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

            ExportPokemonINI(SaveFileDialog.FileName, (PKMNames.SelectedIndex + 1))

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "ini"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.ini)|*.ini*"

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

        fileOpenDialog.Title = "Select ini file to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            ImportPokemonINI(fileOpenDialog.FileName, (PKMNames.SelectedIndex + 1))

            Dim refreshvar As Integer

            refreshvar = PKMNames.SelectedIndex

            If PKMNames.SelectedIndex = 0 Then
                PKMNames.SelectedIndex = PKMNames.SelectedIndex + 1
            Else
                PKMNames.SelectedIndex = PKMNames.SelectedIndex - 1
            End If

            PKMNames.Items.Insert(refreshvar, GetPokemonName(refreshvar + 1))
            EvoPKMNames.Items.Insert(refreshvar, GetPokemonName(refreshvar + 1))
            ComboBox1.Items.Insert(refreshvar, GetPokemonName(refreshvar + 1))

            PKMNames.Items.RemoveAt(refreshvar + 1)
            EvoPKMNames.Items.RemoveAt(refreshvar + 1)
            ComboBox1.Items.RemoveAt(refreshvar + 1)

            PKMNames.SelectedIndex = refreshvar

        End If
    End Sub

    Private Sub TMHMLoad()
        Dim LoopVar As Integer

        TMHMAttacks = Int32.Parse((GetString(GetINIFileLocation(), header, "TMData", "")), System.Globalization.NumberStyles.HexNumber)

        TMHMCom.Items.Clear()

        LoopVar = 0

        While LoopVar < (Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", ""))) = True

            If LoopVar > ((Val(GetString(GetINIFileLocation(), header, "TotalTMs", ""))) - 1) Then
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


    End Sub

    Public Sub TMHMCOMLoad()

        i = PKMNames.SelectedIndex

        TMHMCompoLoc = Int32.Parse((GetString(GetINIFileLocation(), header, "TMHMCompatibility", "")), System.Globalization.NumberStyles.HexNumber)

        Dim blah As Integer
        Dim howmanyzeros As Integer
        Dim whichtmbyte As Integer
        Dim howmanytmschecked As Integer
        Dim looper As Integer
        Dim curposition As Integer
        Dim binarythebitch As String
        Dim curchar As String

        'If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then
        '    whichtmbyte = 0

        '    While whichtmbyte < 8

        '        blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, 1))), System.Globalization.NumberStyles.HexNumber)
        '        binarythebitch = (Convert.ToString(blah, 2))

        '        If whichtmbyte = 7 Then

        '            howmanytmschecked = 0


        '            ' MsgBox((Convert.ToString(blah, 2)))

        '            If Len(binarythebitch) > 2 Then
        '                MsgBox("Did you mess with the TM/HM data? Contact Gamer2020!")
        '            ElseIf Len(binarythebitch) = 2 Then


        '                curchar = GetChar(binarythebitch, 1)

        '                If curchar = "1" Then
        '                    TMHMCom.SetItemChecked(57, True)

        '                ElseIf curchar = "0" Then
        '                    TMHMCom.SetItemChecked(57, False)

        '                End If

        '                curchar = GetChar(binarythebitch, 2)

        '                If curchar = "1" Then
        '                    TMHMCom.SetItemChecked(56, True)

        '                ElseIf curchar = "0" Then
        '                    TMHMCom.SetItemChecked(56, False)

        '                End If


        '            ElseIf Len(binarythebitch) < 2 Then

        '                TMHMCom.SetItemChecked(57, False)

        '                curchar = GetChar(binarythebitch, 1)

        '                If curchar = "1" Then
        '                    TMHMCom.SetItemChecked(56, True)

        '                ElseIf curchar = "0" Then
        '                    TMHMCom.SetItemChecked(56, False)

        '                End If


        '            End If



        '            whichtmbyte = whichtmbyte + 1
        '        Else
        '            howmanytmschecked = 0


        '            ' MsgBox((Convert.ToString(blah, 2)))

        '            howmanyzeros = (8 - Len(binarythebitch))

        '            For looper = 1 To howmanyzeros
        '                TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

        '                howmanytmschecked = howmanytmschecked + 1

        '            Next looper

        '            For curposition = 1 To Len(Convert.ToString(blah, 2))

        '                ' Len(Convert.ToString(blah, 2))

        '                curchar = GetChar(binarythebitch, curposition)

        '                If curchar = "1" Then
        '                    TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, True)

        '                    howmanytmschecked = howmanytmschecked + 1

        '                ElseIf curchar = "0" Then
        '                    TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

        '                    howmanytmschecked = howmanytmschecked + 1

        '                End If
        '            Next curposition
        '            whichtmbyte = whichtmbyte + 1
        '        End If
        '    End While
        'End If


        'seperate
        'seperate
        'seperate
        'seperate

        '  If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then

        whichtmbyte = 0

        While whichtmbyte < (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))

            blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMCompoLoc + (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))) + (i * (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))) + whichtmbyte, 1))), System.Globalization.NumberStyles.HexNumber)
            binarythebitch = (Convert.ToString(blah, 2))

            howmanytmschecked = 0




            howmanyzeros = (8 - Len(binarythebitch))

            For looper = 1 To howmanyzeros
                'TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)

                'howmanytmschecked = howmanytmschecked + 1
                binarythebitch = "0" & binarythebitch

            Next looper

            For curposition = 1 To Len(binarythebitch)

                ' Len(Convert.ToString(blah, 2))

                curchar = GetChar(binarythebitch, curposition)

                If curchar = "1" Then


                    If (((7 + (8 * whichtmbyte)) - howmanytmschecked) < (Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", "")))) Then
                        TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, True)
                    End If
                    howmanytmschecked = howmanytmschecked + 1

                ElseIf curchar = "0" Then

                    If (((7 + (8 * whichtmbyte)) - howmanytmschecked) < (Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", "")))) Then
                        TMHMCom.SetItemChecked((7 + (8 * whichtmbyte)) - howmanytmschecked, False)
                    End If
                    howmanytmschecked = howmanytmschecked + 1

                End If
            Next curposition
            whichtmbyte = whichtmbyte + 1

        End While

        ' End If

    End Sub

    Public Sub TMHMCOMSave()
        i = PKMNames.SelectedIndex

        Dim whichtmbyte As Integer
        'Dim howmanytmschecked As Integer
        Dim looper As Integer
        Dim binarytowrite As String
        Dim bytetowrite As String

        'If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then

        '    whichtmbyte = 0

        '    While whichtmbyte < 8

        '        If whichtmbyte = 7 Then

        '            binarytowrite = ""
        '            For looper = 0 To 1

        '                If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
        '                    binarytowrite = "1" & binarytowrite

        '                ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
        '                    binarytowrite = "0" & binarytowrite

        '                End If

        '            Next looper
        '            bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
        '            WriteHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, bytetowrite)

        '            whichtmbyte = whichtmbyte + 1
        '        Else

        '            binarytowrite = ""
        '            For looper = 0 To 7

        '                If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
        '                    binarytowrite = "1" & binarytowrite

        '                ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
        '                    binarytowrite = "0" & binarytowrite

        '                End If

        '            Next looper
        '            bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
        '            WriteHEX(LoadedROM, TMHMCompoLoc + 8 + (i * 8) + whichtmbyte, bytetowrite)

        '            whichtmbyte = whichtmbyte + 1
        '        End If
        '    End While
        'End If


        'separate
        'separate
        'separate

        ' If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then

        whichtmbyte = 0

        While whichtmbyte < (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))

            binarytowrite = ""
            For looper = 0 To 7



                If (((8 * whichtmbyte) + looper) < TMHMCom.Items.Count) Then

                    If TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = True Then
                        binarytowrite = "1" & binarytowrite

                    ElseIf TMHMCom.GetItemChecked((8 * whichtmbyte) + looper) = False Then
                        binarytowrite = "0" & binarytowrite

                    End If
                Else

                    binarytowrite = "0" & binarytowrite

                End If
            Next looper
            bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
            WriteHEX(LoadedROM, TMHMCompoLoc + (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", ""))) + (i * (Val(GetString(GetINIFileLocation(), header, "TMHMLenPerPoke", "")))) + whichtmbyte, bytetowrite)

            whichtmbyte = whichtmbyte + 1

        End While

        '  End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        FolderBrowserDialog.Description = "Select folder to export all Pokemon to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Pokemon") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Pokemon")
            End If

            Dim LoopVar As Integer

            LoopVar = 0
            Me.Enabled = False

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                '  PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                ExportPokemonINI(FolderBrowserDialog.SelectedPath & "\Pokemon\" & LoopVar & ".ini", LoopVar)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        i = PKMNames.SelectedIndex
        WriteHEX(LoadedROM, (FootPrintTable) + (4) + (i * 4), ReverseHEX(Hex(Int32.Parse(((FootPrintPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        GetAndDrawPokemonFootPrint(PictureBox1, i + 1)
    End Sub

    Private Sub LearnableMoveLoad()

        Dim blah As Integer
        Dim binarythebitch As String
        Dim at As String
        Dim lvl As String

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then

            AttackTable = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)

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

        ElseIf GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "True" Then
            AttackTable = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)

            LvlUpAttPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (4) + (PKMNames.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 3) = GetString(GetINIFileLocation(), header, "JamboLearnableMovesTerm", "") = False

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

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then
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

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "True" Then
            i = PKMNames.SelectedIndex
            WriteHEX(LoadedROM, (AttackTable) + (4) + (i * 4), ReverseHEX(Hex(Val("&H" & (LvlUpAttPointer.Text)) + &H8000000)))
            lvlupattacks.Items.Clear()

            Dim Looper As Integer

            Looper = 0

            While ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 3) = GetString(GetINIFileLocation(), header, "JamboLearnableMovesTerm", "") = False

                lvl = Int32.Parse(((ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3) + 2, 1))), System.Globalization.NumberStyles.HexNumber)

                at = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((LvlUpAttPointer.Text), System.Globalization.NumberStyles.HexNumber) + (Looper * 3), 2))), System.Globalization.NumberStyles.HexNumber)
                lvlupattacks.Items.Add(lvl & " - " & GetAttackName(at))
                Looper = Looper + 1
            End While
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        i = PKMNames.SelectedIndex



        If (i + 1) < 252 Then

            WriteHEX(LoadedROM, (CryTable) + (4) + (i * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            ' WriteHEX(LoadedROM, (CryTable3) + (4) + (i * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer2.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            WriteHEX(LoadedROM, (CryTable) + (i * 12), (Hex(Int32.Parse(((CryComp1.Text)), System.Globalization.NumberStyles.HexNumber))))
            'WriteHEX(LoadedROM, (CryTable3) + (i * 12), (Hex(Int32.Parse(((CryComp2.Text)), System.Globalization.NumberStyles.HexNumber))))

            crynorm = LoadCry(i, CryTable)
            crygrowl = LoadCry(i, CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        ElseIf (i + 1) > 251 And (i + 1) < 276 Then

            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 276 Then

            WriteHEX(LoadedROM, (CryTable) + (4) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            ' WriteHEX(LoadedROM, (CryTable3) + (4) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer2.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            WriteHEX(LoadedROM, (CryTable) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), (Hex(Int32.Parse(((CryComp1.Text)), System.Globalization.NumberStyles.HexNumber))))
            'WriteHEX(LoadedROM, (CryTable3) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), (Hex(Int32.Parse(((CryComp2.Text)), System.Globalization.NumberStyles.HexNumber))))

            crynorm = LoadCry(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))), CryTable)
            crygrowl = LoadCry(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))), CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        End If
    End Sub

    Private Sub MTLoad()
        Dim LoopVar As Integer

        MTCom.Items.Clear()

        LoopVar = 0
        If header2 = "BPE" Then
            MTattacks = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)

            MTCom.Enabled = True
            While LoopVar < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))
                MTCom.Items.Add(GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTattacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))
                LoopVar = LoopVar + 1

            End While
        ElseIf header2 = "BPR" Or header2 = "BPE" Then
            MTattacks = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)

            MTCom.Enabled = True

            While LoopVar < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))
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

        'If header2 = "BPE" Then
        If header2 = "BPE" Or header2 = "BPR" Or header2 = "BPG" Then
            MTCompoLoc = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber)


            For emloop = 0 To (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 16) - 1)
                blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTCompoLoc + (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) + (PKMNames.SelectedIndex * (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))) + (emloop * 2), 2))), System.Globalization.NumberStyles.HexNumber)
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

            'ElseIf header2 = "BPR" Or header2 = "BPG" Then
            '    MTCompoLoc = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorCompatibility", "")), System.Globalization.NumberStyles.HexNumber)

            '    blah = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, MTCompoLoc + 2 + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)
            '    binarythebitch = (Convert.ToString(blah, 2))
            '    While Len(binarythebitch) < 16

            '        binarythebitch = "0" & binarythebitch

            '    End While
            '    LoopVar = 0

            '    While LoopVar < 16
            '        curchar = GetChar(binarythebitch, LoopVar + 1)


            '        If curchar = "1" Then
            '            MTCom.SetItemChecked(15 - LoopVar, True)


            '        ElseIf curchar = "0" Then

            '            MTCom.SetItemChecked(15 - LoopVar, False)
            '        End If

            '        LoopVar = LoopVar + 1
            '    End While
        Else
        End If

    End Sub
    Private Sub MTComSave()
        i = PKMNames.SelectedIndex

        Dim looper As Integer
        Dim binarytowrite As String
        Dim bytetowrite As String

        ' Dim LoopVar As Integer
        ' Dim binarythebitch As String
        Dim emloop As Integer
        'Dim blah As Integer
        'Dim curchar As String

        'If header2 = "BPE" Then
        If header2 = "BPE" Or header2 = "BPR" Or header2 = "BPG" Then
            For emloop = 0 To (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 16) - 1)
                binarytowrite = ""
                For looper = 0 To 15

                    If MTCom.GetItemChecked((emloop * 16) + 15 - looper) = True Then
                        binarytowrite = binarytowrite & "1"

                    ElseIf MTCom.GetItemChecked((emloop * 16) + 15 - looper) = False Then
                        binarytowrite = binarytowrite & "0"

                    End If

                Next looper

                bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
                WriteHEX(LoadedROM, MTCompoLoc + (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8)) + (PKMNames.SelectedIndex * (((Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", ""))) / 8))) + (emloop * 2), ReverseHEX(VB.Right("0000" & bytetowrite, 4)))
            Next emloop

            'ElseIf header2 = "BPR" Or header2 = "BPG" Then
            '    binarytowrite = ""
            '        For looper = 0 To 15

            '        If MTCom.GetItemChecked((0 * 16) + 15 - looper) = True Then
            '            binarytowrite = binarytowrite & "1"

            '        ElseIf MTCom.GetItemChecked((0 * 16) + 15 - looper) = False Then
            '            binarytowrite = binarytowrite & "0"

            '        End If

            '        Next looper

            '        bytetowrite = Hex(Convert.ToInt32(binarytowrite, 2))
            '    WriteHEX(LoadedROM, MTCompoLoc + 2 + (PKMNames.SelectedIndex * 2) + (0 * 2), ReverseHEX(bytetowrite))

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

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then

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
        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "True" Then

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
        Dim holder As String = ""
        Dim bytetowrite As String
        Dim at As String
        Dim lvl As String
        Dim pointer As String
        Dim temp As Integer
        'Dim loopme As Integer

        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then
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


        If GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "True" Then
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
        ComboBox1.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))
            ComboBox1.Items.Add(GetPokemonName(LoopVar))


        End While

        PKMNames.SelectedIndex = tempy
    End Sub

    Private Sub IconPal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IconPal.SelectedIndexChanged
        i = PKMNames.SelectedIndex
        GetAndDrawPokemonIconPic(IconPicBox, i + 1, IconPal.SelectedIndex)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        i = PKMNames.SelectedIndex



        If (i + 1) < 252 Then
            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 251 And (i + 1) < 276 Then

            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 276 Then

            WriteHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), ReverseHEX(VB.Right("0000" & Hex(CryConver.Text), 4)))

            CryPointer.Text = Hex(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, ((CryTable) + (4)) + ((CryConver.Text) * 12), 4)), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            CryPointer2.Text = Hex(Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, ((CryTable3) + (4)) + ((CryConver.Text) * 12), 4)), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            'Label53.Text = "Sample Rate: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer.Text) + (4), 4)))), System.Globalization.NumberStyles.HexNumber)) >> 10) & " Hz"
            'Label54.Text = "Sample Rate: " & ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ("&H" & CryPointer2.Text) + (4), 4)))), System.Globalization.NumberStyles.HexNumber)) >> 10) & " Hz"

            crynorm = LoadCry(CryConver.Text, CryTable)
            crygrowl = LoadCry(CryConver.Text, CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        End If
    End Sub

    Private Sub CryPointer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EvoTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EvoTypes.SelectedIndexChanged

        EvoPKMNames.Enabled = False
        EvoItem.Enabled = False
        EvoLevel.Enabled = False
        EvoItem.SelectedIndex = -1
        EvoLevel.Text = ""
        'EvoPKMNames.SelectedIndex = -1
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
        'value
        TextBox6.Enabled = False
        TextBox6.Text = ""

        If (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "none" Then

            EvoPKMNames.Enabled = False
            EvoItem.Enabled = False
            EvoLevel.Enabled = False
            EvoItem.SelectedIndex = -1
            EvoLevel.Text = ""
            'EvoPKMNames.SelectedIndex = -1

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbutnoparms" Then

            'EvoPKMNames.SelectedIndex = 0
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "level" Then

            EvoLevel.Text = "1"

            'EvoPKMNames.SelectedIndex = 0
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "item" Then

            EvoPKMNames.Enabled = True
            'EvoPKMNames.SelectedIndex = 0
            EvoItem.SelectedIndex = 1
            EvoItem.Enabled = True
            EvoLevel.Enabled = False

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "attack" Then

            EvoPKMNames.Enabled = True
            'EvoPKMNames.SelectedIndex = 0

            ComboBox3.SelectedIndex = 0
            ComboBox3.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "mapname" Then

            EvoPKMNames.Enabled = True
            'EvoPKMNames.SelectedIndex = 0

            ComboBox2.SelectedIndex = 0
            ComboBox2.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "species" Then

            EvoPKMNames.Enabled = True
            'EvoPKMNames.SelectedIndex = 0

            ComboBox1.SelectedIndex = 0
            ComboBox1.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "bankandmap" Then

            EvoPKMNames.Enabled = True
            'EvoPKMNames.SelectedIndex = 0

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Enabled = True
            TextBox2.Enabled = True

        ElseIf (GetString(GetINIFileLocation(), header, "Evolution" & EvoTypes.SelectedIndex & "Param", "0")) = "evolvesbasedonvalue" Then

            'EvoPKMNames.SelectedIndex = 0
            EvoPKMNames.Enabled = True
            EvoLevel.Enabled = False
            TextBox6.Enabled = True

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

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        FolderBrowserDialog.Description = "Select folder to import Pokemon from:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            Dim LoopVar As Integer

            LoopVar = 0

            Me.Enabled = False

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                'PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".ini") Then
                    ImportPokemonINI(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".ini", LoopVar)
                End If

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            LoopVar = 0

            PKMNames.Items.Clear()
            EvoPKMNames.Items.Clear()

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


                LoopVar = LoopVar + 1

                PKMNames.Items.Add(GetPokemonName(LoopVar))
                EvoPKMNames.Items.Add(GetPokemonName(LoopVar))


            End While

            PKMNames.SelectedIndex = 0

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Text = "Please wait..."
        Me.UseWaitCursor = True
        ProgressBar.Value = 0
        ProgressBar.Visible = True

        Dim LoopVar As Integer

        LoopVar = 0
        Me.Enabled = False

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
            'PKMNames.SelectedIndex = LoopVar

            LoopVar = LoopVar + 1
            Me.Refresh()


            ChangePokemonName(LoopVar, DecapString(GetPokemonName(LoopVar)))

            ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
        End While

        LoopVar = 0

        PKMNames.Items.Clear()
        EvoPKMNames.Items.Clear()
        ComboBox1.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            PKMNames.Items.Add(GetPokemonName(LoopVar))
            EvoPKMNames.Items.Add(GetPokemonName(LoopVar))
            ComboBox1.Items.Add(GetPokemonName(LoopVar))


        End While

        PKMNames.SelectedIndex = 0

        Me.Text = "Pokemon Editor"
        Me.UseWaitCursor = False
        Me.Enabled = True
        ProgressBar.Visible = False
        Me.BringToFront()
    End Sub

    Public Sub LoadDexData()

        TextBox3.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

        TextBox4.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SecondDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

        If Convert.ToInt32(TextBox3.Text) < Convert.ToInt32(GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And Convert.ToInt32(TextBox3.Text) > 0 Then

            GroupBox32.Enabled = True
            GroupBox29.Enabled = True
            GroupBox31.Enabled = True
            GroupBox30.Enabled = True

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

            Pointer1.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + +12 + (TextBox3.Text * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            Hght.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 12 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Wght.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 2 + 12 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

            Scale1.Text = ""
            Scale2.Text = ""

            If header2 = "AXP" Or header2 = "AXV" Then

                Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

                Pointer2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 8 + +12 + (TextBox3.Text * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
                EnglishRSDescpLoad()
            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 30 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 32 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


                EnglishFRLGEDescpLoad()
            ElseIf header2 = "BPE" Then

                Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 22 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 24 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 26 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
                Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 28 + (TextBox3.Text * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


                EnglishFRLGEDescpLoad()
            End If

            TextBox5.Text = GetPokedexTypeName(TextBox3.Text)

            If header2 = "BPE" And TextBox4.Text < (GetString(GetINIFileLocation(), header, "NumberOfRegionDex", "") + 1) Then
                TextBox7.Enabled = True

                TextBox7.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "HoenntoNationalDex", "")), System.Globalization.NumberStyles.HexNumber) + ((TextBox4.Text - 1) * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            Else
                TextBox7.Enabled = False
            End If

        Else

            GroupBox32.Enabled = False
            GroupBox29.Enabled = False
            GroupBox31.Enabled = False
            GroupBox30.Enabled = False

        End If




    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(TextBox3.Text), 4)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SecondDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(TextBox4.Text), 4)))

        If header2 = "BPE" And TextBox4.Text < (GetString(GetINIFileLocation(), header, "NumberOfRegionDex", "") + 1) Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "HoenntoNationalDex", "")), System.Globalization.NumberStyles.HexNumber) + ((TextBox4.Text - 1) * 2), ReverseHEX(VB.Right("0000" & Hex(TextBox7.Text), 4)))
        End If

        LoadDexData()

    End Sub

    Private Sub Hght_TextChanged(sender As Object, e As EventArgs) Handles Hght.TextChanged
        If Val(Hght.Text) > 304 Then Hght.Text = 304
        If Val(Hght.Text) < 0 Then Hght.Text = 0

        Label30.Text = Val(Hght.Text) / 10

        Label29.Text = Val(Label30.Text) * 3.281
    End Sub

    Private Sub Wght_TextChanged(sender As Object, e As EventArgs) Handles Wght.TextChanged
        If Val(Wght.Text) > 21474 Then Wght.Text = 21474
        If Val(Wght.Text) < 0 Then Wght.Text = 0

        Label28.Text = Val(Wght.Text) / 10

        Label27.Text = Val(Label28.Text) * 2.2
    End Sub

    Private Sub EnglishRSDescpLoad()
        Description1.Text = ""
        Description2.Text = ""

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength1 = Len(DexDescp)

        Description1.Text = DexDescp
        ' Description1.MaxLength = Len(DexDescp)

        DexDescp = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer2.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength2 = Len(DexDescp)

        Description2.Text = DexDescp
        'Description2.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub

    Private Sub EnglishFRLGEDescpLoad()

        Description1.Text = ""
        Description2.Text = ""

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)

        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength1 = Len(DexDescp)

        Description1.Text = DexDescp
        ' Description1.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub

    Private Sub Scale1_TextChanged(sender As Object, e As EventArgs) Handles Scale1.TextChanged

        If Scale1.Text = "" Then

        ElseIf Scale1.Text <> 0 Then

            Dim PokePoint As Point

            GetAndDrawFrontPokemonPicBLACK(RSEDexPoke, PKMNames.SelectedIndex + 1)
            RSEDexPoke.Height = (64 * 256 / Scale1.Text)
            RSEDexPoke.Width = (64 * 256 / Scale1.Text)

            PokePoint.X = 15
            If (64 - RSEDexPoke.Height) > 0 Then
                PokePoint.Y = 123 + (64 - RSEDexPoke.Height)
            Else
                PokePoint.Y = 123
            End If
            RSEDexPoke.Location = PokePoint

            RSEDexPoke.SizeMode = PictureBoxSizeMode.StretchImage

        End If

    End Sub

    Private Sub Scale2_TextChanged(sender As Object, e As EventArgs) Handles Scale2.TextChanged

        If Scale2.Text = "" Then
        ElseIf Scale2.Text <> 0 Then

            Dim TrainerPoint As Point

            GetAndDrawTrainerPicBLACK(RSEDexTrainer, (GetString(GetINIFileLocation(), header, "DexSizeTrainerSprite", "")))
            RSEDexTrainer.Height = (64 * 256 / Scale2.Text)
            RSEDexTrainer.Width = (64 * 256 / Scale2.Text)

            TrainerPoint.X = RSEDexPoke.Location.X + RSEDexPoke.Width
            TrainerPoint.Y = 123 + (64 - RSEDexTrainer.Height)
            RSEDexTrainer.Location = TrainerPoint

            RSEDexTrainer.SizeMode = PictureBoxSizeMode.StretchImage

        End If

    End Sub

    Private Sub RSEDexPoke_LocationChanged(sender As Object, e As EventArgs) Handles RSEDexPoke.LocationChanged
        Dim TrainerPoint As Point
        TrainerPoint.X = RSEDexPoke.Location.X + RSEDexPoke.Width
        TrainerPoint.Y = 123 + (64 - RSEDexTrainer.Height)
        RSEDexTrainer.Location = TrainerPoint
    End Sub

    Private Sub Description1_TextChanged(sender As Object, e As EventArgs) Handles Description1.TextChanged
        Label38.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
        Label38.ForeColor = Color.Black

        If Len(Description1.Text) > DexDescripLength1 Then
            Label38.Text = Label38.Text & " Requires repoint!"

            Label38.ForeColor = Color.Red

        End If
    End Sub

    Private Sub Description2_TextChanged(sender As Object, e As EventArgs) Handles Description2.TextChanged
        Label37.Text = "Length: " & Len(Description2.Text) & "/" & DexDescripLength2
        Label37.ForeColor = Color.Black

        If Len(Description2.Text) > DexDescripLength2 Then
            Label37.Text = Label37.Text & " Requires repoint!"

            Label37.ForeColor = Color.Red

        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim indexbuff As Integer = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

        If header3 = "J" Then

            If header2 = "AXP" Or header2 = "AXV" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End

            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End
            ElseIf header2 = "BPE" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End
            End If

        Else
            If header2 = "AXP" Or header2 = "AXV" Then

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & ((Pointer1.Text))) + &H8000000)))
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 8 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & ((Pointer2.Text))) + &H8000000)))

                EnglishRSDescpLoad()

            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & ((Pointer1.Text))) + &H8000000)))

                EnglishFRLGEDescpLoad()

            ElseIf header2 = "BPE" Then
                WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & ((Pointer1.Text))) + &H8000000)))

                EnglishFRLGEDescpLoad()

            End If
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim indexbuff As Integer = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)
        Dim Y As String

        Dim Var1 As String
        Dim Var2 As String
        Dim filler As Byte = &H0

        If header2 = "AXP" Or header2 = "AXV" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultR As DialogResult = MessageBox.Show("The text for the first box will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultR = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Label38.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label38.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label38.Text = Label38.Text & " Requires repoint!"

                        Label38.ForeColor = Color.Red

                    End If

                End If

            Else
                FileNum = FreeFile()

                Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var1, False)

                FileClose(FileNum)
            End If


            If DexDescripLength2 < Len(Description2.Text) Then

                Dim resultR2 As DialogResult = MessageBox.Show("The text for the second box will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultR2 = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description2.Text, vbCrLf, "\n") & "\x")

                    Var2 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var2 + 1), False)

                    FileClose(FileNum)

                    Pointer2.Text = Hex(Var2)

                    Label37.Text = "Length: " & Len(Description2.Text) & "/" & DexDescripLength2
                    Label37.ForeColor = Color.Black

                    If Len(Description2.Text) > DexDescripLength2 Then
                        Label37.Text = Label37.Text & " Requires repoint!"

                        Label37.ForeColor = Color.Red

                    End If

                End If

            Else

                FileNum = FreeFile()

                Var2 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 8 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description2.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var2, False)

                FileClose(FileNum)

            End If

            Button18.PerformClick()

        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultBPR As DialogResult = MessageBox.Show("The text will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultBPR = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Button18.PerformClick()

                    Label38.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label38.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label38.Text = Label38.Text & " Requires repoint!"

                        Label38.ForeColor = Color.Red

                    End If

                End If

            Else
                FileNum = FreeFile()

                Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var1, False)

                FileClose(FileNum)

            End If

        ElseIf header2 = "BPE" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultBPE As DialogResult = MessageBox.Show("The text will be written to free space and the pointer will be repointed. Would you like to do that?",
  "Repoint?",
  MessageBoxButtons.YesNo)

                If (resultBPE = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Button18.PerformClick()

                    Label38.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label38.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label38.Text = Label38.Text & " Requires repoint!"

                        Label38.ForeColor = Color.Red

                    End If

                End If

            Else

                FileNum = FreeFile()

                Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber) + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var1, False)

                FileClose(FileNum)

            End If

        End If



    End Sub

    Public Sub DexDataSave()

        Dim indexbuff As Integer = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber) + (PKMNames.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

        Dim offset1 As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber)


        If indexbuff < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) And indexbuff <> 0 Then

            If header2 = "AXP" Or header2 = "AXV" Then

                WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

                WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 30 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 32 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

                WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 30 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 32 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

            ElseIf header2 = "BPE" Then

                WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

                WriteHEX(LoadedROM, offset1 + 22 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 24 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
                WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

            End If

            ChangePokedexTypeName(indexbuff, TextBox5.Text)

        End If
    End Sub

    Public Sub LoadSpritePosition()

        PlayerYSelect.Value = ByteToSignedInt("&H" & (ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PlayerYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 4 + 1 + (PKMNames.SelectedIndex * 4), 1)))
        EnemyYSelect.Value = ByteToSignedInt("&H" & (ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 4 + 1 + (PKMNames.SelectedIndex * 4), 1)))
        EnemyAltitudeSelect.Value = ByteToSignedInt("&H" & (ReadHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyAltitudeTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PKMNames.SelectedIndex * 1), 1)))

        DrawBatttlePositionGraphics()

    End Sub

    Public Sub SaveSpritePosition()

        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "PlayerYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 4 + 1 + (PKMNames.SelectedIndex * 4), SignedIntToHex(PlayerYSelect.Value))
        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyYTable", "")), System.Globalization.NumberStyles.HexNumber)) + 4 + 1 + (PKMNames.SelectedIndex * 4), SignedIntToHex(EnemyYSelect.Value))
        WriteHEX(LoadedROM, (Int32.Parse((GetString(GetINIFileLocation(), header, "EnemyAltitudeTable", "")), System.Globalization.NumberStyles.HexNumber)) + 1 + (PKMNames.SelectedIndex * 1), SignedIntToHex(EnemyAltitudeSelect.Value))

    End Sub

    Public Sub DrawBatttlePositionGraphics()

        BackgroundBox.Image.Dispose()
        BackgroundBox.Image = Image.FromFile(AppPath & "img\BattlePreviewBackground.png")

        Dim bgBox As PictureBox
        Dim imagedraw As Bitmap
        Dim height As Integer = (&H40 - PlayerYSelect.Value)
        If (height > &H40) Then
            height = &H40
        End If

        If (EnemyAltitudeSelect.Value <> 0) Then
            bgBox = BackgroundBox
            imagedraw = DirectCast(BackgroundBox.Image, Bitmap)
            BitmapBLT(Image.FromFile(AppPath & "img\BattlePreviewShadow.png"), imagedraw, 160, &H41, 0, 0, &H20, 8)
            BackgroundBox.Image = imagedraw
        End If

        bgBox = BackgroundBox
        imagedraw = DirectCast(BackgroundBox.Image, Bitmap)
        BitmapBLT(GetFrontPokemonPicToBitmap(PKMNames.SelectedIndex + 1, False), imagedraw, &H90, (8 + EnemyYSelect.Value - EnemyAltitudeSelect.Value), 0, 0, &H40, &H40)
        BackgroundBox.Image = imagedraw
        bgBox = BackgroundBox
        imagedraw = DirectCast(BackgroundBox.Image, Bitmap)
        BitmapBLT(GetNormalBackPokemonPicToBitmap(PKMNames.SelectedIndex + 1, False), imagedraw, 40, (&H30 + PlayerYSelect.Value), 0, 0, &H40, height)
        BackgroundBox.Image = imagedraw

    End Sub

    Private Sub PlayerYSelect_ValueChanged(sender As Object, e As EventArgs) Handles PlayerYSelect.ValueChanged
        DrawBatttlePositionGraphics()
    End Sub

    Private Sub EnemyYSelect_ValueChanged(sender As Object, e As EventArgs) Handles EnemyYSelect.ValueChanged
        DrawBatttlePositionGraphics()
    End Sub

    Private Sub EnemyAltitudeSelect_ValueChanged(sender As Object, e As EventArgs) Handles EnemyAltitudeSelect.ValueChanged
        DrawBatttlePositionGraphics()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
            "(*.png)|*.png*"

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

        fileOpenDialog.Title = "Select Sprite Sheet to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = "Please wait..."
            Me.Enabled = False

            ImportAseriesSheet(fileOpenDialog.FileName, PKMNames.SelectedIndex + 1)

            'Dim refreshvar As Integer

            'refreshvar = PKMNames.SelectedIndex

            'If PKMNames.SelectedIndex = 0 Then
            '    PKMNames.SelectedIndex = PKMNames.SelectedIndex + 1
            '    Me.Enabled = False
            'Else
            '    PKMNames.SelectedIndex = PKMNames.SelectedIndex - 1
            '    Me.Enabled = False
            'End If

            'PKMNames.SelectedIndex = refreshvar

            i = PKMNames.SelectedIndex

            FrontSpritePointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonFrontSprites", "")), System.Globalization.NumberStyles.HexNumber)
            BackSpritePointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonBackSprites", "")), System.Globalization.NumberStyles.HexNumber)
            NormalPalPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonNormalPal", "")), System.Globalization.NumberStyles.HexNumber)
            ShinyPalPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonShinyPal", "")), System.Globalization.NumberStyles.HexNumber)

            FrontPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (FrontSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            BackPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (BackSpritePointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            ShinyPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (ShinyPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            NormalPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (NormalPalPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))


            GetAndDrawFrontPokemonPic(FrntPic, i + 1)
            GetAndDrawBackPokemonPic(BckPic2, i + 1)
            GetAndDrawFrontPokemonPicShiny(FrntPic2, i + 1)
            GetAndDrawBackPokemonPicNormal(BckPic, i + 1)

            DrawBatttlePositionGraphics()


            If header2 = "BPE" Then
                Button2.Enabled = True
                AnimationPointer.Enabled = True

                AnimationPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAnimations", "")), System.Globalization.NumberStyles.HexNumber)
                AnimationPointer.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AnimationPointers) + (8) + (i * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

                GetAndDrawAnimationPokemonPic(AniPic, i + 1)
                GetAndDrawAnimationPokemonPicShiny(AniPic2, i + 1)

            End If

            If Scale1.Text = "" Then

            ElseIf Scale1.Text <> 0 Then

                Dim PokePoint As Point

                GetAndDrawFrontPokemonPicBLACK(RSEDexPoke, PKMNames.SelectedIndex + 1)
                RSEDexPoke.Height = (64 * 256 / Scale1.Text)
                RSEDexPoke.Width = (64 * 256 / Scale1.Text)

                PokePoint.X = 15
                If (64 - RSEDexPoke.Height) > 0 Then
                    PokePoint.Y = 123 + (64 - RSEDexPoke.Height)
                Else
                    PokePoint.Y = 123
                End If
                RSEDexPoke.Location = PokePoint

                RSEDexPoke.SizeMode = PictureBoxSizeMode.StretchImage

            End If

            Me.Text = "Pokemon Editor"
            Me.Enabled = True
        End If

    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".png"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.png)|*.png*"

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

            ExportAseriesSheet(SaveFileDialog.FileName, PKMNames.SelectedIndex + 1)

        End If

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".png"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.png)|*.png*"

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

            ExportPokemonIcon(SaveFileDialog.FileName, (PKMNames.SelectedIndex + 1))

        End If

    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
                   "(*.png)|*.png*"

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

        fileOpenDialog.Title = "Select Icon to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = "Please wait..."
            Me.Enabled = False

            ImportPokemonIcon(fileOpenDialog.FileName, PKMNames.SelectedIndex + 1)

            i = PKMNames.SelectedIndex

            IconPointers = Int32.Parse((GetString(GetINIFileLocation(), header, "IconPointerTable", "")), System.Globalization.NumberStyles.HexNumber)
            IconPalTable = Int32.Parse((GetString(GetINIFileLocation(), header, "IconPalTable", "")), System.Globalization.NumberStyles.HexNumber)

            IconPointer.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (IconPointers) + (4) + (i * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            IconPal.SelectedIndex = Int32.Parse(((ReadHEX(LoadedROM, (IconPalTable) + (1) + (i), 1))), System.Globalization.NumberStyles.HexNumber)

            GetAndDrawPokemonIconPic(IconPicBox, i + 1, IconPal.SelectedIndex)

            Me.Text = "Pokemon Editor"
            Me.Enabled = True
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".png"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.png)|*.png*"

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

            ExportPokemonFootprint(SaveFileDialog.FileName, (PKMNames.SelectedIndex + 1))

        End If
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "png"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
                   "(*.png)|*.png*"

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

        fileOpenDialog.Title = "Select Footprint to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = "Please wait..."
            Me.Enabled = False

            ImportPokemonFootPrint(fileOpenDialog.FileName, PKMNames.SelectedIndex + 1)

            GetAndDrawPokemonFootPrint(PictureBox1, PKMNames.SelectedIndex + 1)

            Me.Text = "Pokemon Editor"
            Me.Enabled = True
        End If
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        FolderBrowserDialog.Description = "Select folder to export all Sprite Sheets to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Sprites") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Sprites")
            End If

            Dim LoopVar As Integer

            LoopVar = 0
            Me.Enabled = False
            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                '  PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1


                ExportAseriesSheet(FolderBrowserDialog.SelectedPath & "\Sprites\" & LoopVar & ".png", LoopVar)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        FolderBrowserDialog.Description = "Select folder to import Sprite Sheets from:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            Dim LoopVar As Integer

            LoopVar = 0

            Me.Enabled = False

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                'PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png") Then
                    ImportAseriesSheet(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png", LoopVar)
                ElseIf System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & VB.Right("000" & LoopVar, 3) & ".png") Then
                    ImportAseriesSheet(FolderBrowserDialog.SelectedPath & "\" & VB.Right("000" & LoopVar, 3) & ".png", LoopVar)
                End If

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            PKMNames.SelectedIndex = 1
            PKMNames.SelectedIndex = 0

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        FolderBrowserDialog.Description = "Select folder to export all Icons to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Icons") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Icons")
            End If

            Dim LoopVar As Integer

            LoopVar = 0
            Me.Enabled = False
            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                '  PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1


                ExportPokemonIcon(FolderBrowserDialog.SelectedPath & "\Icons\" & LoopVar & ".png", LoopVar)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        FolderBrowserDialog.Description = "Select folder to import Icons from:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            Dim LoopVar As Integer

            LoopVar = 0

            Me.Enabled = False

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                'PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png") Then
                    ImportPokemonIcon(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png", LoopVar)
                ElseIf System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & VB.Right("000" & LoopVar, 3) & ".png") Then
                    ImportPokemonIcon(FolderBrowserDialog.SelectedPath & "\" & VB.Right("000" & LoopVar, 3) & ".png", LoopVar)
                End If

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            PKMNames.SelectedIndex = 1
            PKMNames.SelectedIndex = 0

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        FolderBrowserDialog.Description = "Select folder to import Footprints from:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            Dim LoopVar As Integer

            LoopVar = 0

            Me.Enabled = False

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                'PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png") Then
                    ImportPokemonFootPrint(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".png", LoopVar)
                End If

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            PKMNames.SelectedIndex = 1
            PKMNames.SelectedIndex = 0

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        FolderBrowserDialog.Description = "Select folder to export all Footprints to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Footprints") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Footprints")
            End If

            Dim LoopVar As Integer

            LoopVar = 0
            Me.Enabled = False
            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                '  PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1


                ExportPokemonFootprint(FolderBrowserDialog.SelectedPath & "\Footprints\" & LoopVar & ".png", LoopVar)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        i = PKMNames.SelectedIndex



        If (i + 1) < 252 Then

            'WriteHEX(LoadedROM, (CryTable) + (4) + (i * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            WriteHEX(LoadedROM, (CryTable3) + (4) + (i * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer2.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            'WriteHEX(LoadedROM, (CryTable) + (i * 12), (Hex(Int32.Parse(((CryComp1.Text)), System.Globalization.NumberStyles.HexNumber))))
            WriteHEX(LoadedROM, (CryTable3) + (i * 12), (Hex(Int32.Parse(((CryComp2.Text)), System.Globalization.NumberStyles.HexNumber))))

            crynorm = LoadCry(i, CryTable)
            crygrowl = LoadCry(i, CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        ElseIf (i + 1) > 251 And (i + 1) < 276 Then

            MsgBox("This shoudln't be enabled! report it!")
        ElseIf (i + 1) > 276 Then

            'WriteHEX(LoadedROM, (CryTable) + (4) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            WriteHEX(LoadedROM, (CryTable3) + (4) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), ReverseHEX(Hex(Int32.Parse(((CryPointer2.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            'WriteHEX(LoadedROM, (CryTable) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), (Hex(Int32.Parse(((CryComp1.Text)), System.Globalization.NumberStyles.HexNumber))))
            WriteHEX(LoadedROM, (CryTable3) + (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))) * 12), (Hex(Int32.Parse(((CryComp2.Text)), System.Globalization.NumberStyles.HexNumber))))

            crynorm = LoadCry(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))), CryTable)
            crygrowl = LoadCry(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((CryTable2)) + ((i - 276) * 2), 2))), System.Globalization.NumberStyles.HexNumber))), CryTable3)

            Label53.Text = "Sample Rate: " & crynorm.SampleRate & " Hz"
            Label54.Text = "Sample Rate: " & crygrowl.SampleRate & " Hz"


            Label55.Text = "Size: " & crynorm.Data.Length & " samples"
            Label56.Text = "Size: " & crygrowl.Data.Length & " samples"

            chkCompressed1.Checked = crynorm.Compressed
            chkCompressed2.Checked = crygrowl.Compressed

            pSample.Image = GetCryImage(crynorm)
            pSample2.Image = GetCryImage(crygrowl)

        End If
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        PlayCry(crynorm)
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        PlayCry(crygrowl)
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".wav"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "wav"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.wav)|*.wav*"

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

            ExportCry(SaveFileDialog.FileName, crynorm)

        End If
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        SaveFileDialog.FileName = (PKMNames.SelectedIndex + 1) & ".wav"
        'SaveFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        SaveFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        SaveFileDialog.DefaultExt = "wav"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        SaveFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        SaveFileDialog.Filter =
            "(*.wav)|*.wav*"

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

            ExportCry(SaveFileDialog.FileName, crygrowl)

        End If
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "wav"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter =
                   "(*.wav)|*.wav*"

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

        fileOpenDialog.Title = "Select Cry to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = "Please wait..."
            Me.Enabled = False

            crynorm = ImportCry(fileOpenDialog.FileName, crynorm)

            SaveCry(crynorm, CryTable)

            'ImportPokemonFootPrint(fileOpenDialog.FileName, PKMNames.SelectedIndex + 1)

            'GetAndDrawPokemonFootPrint(PictureBox1, PKMNames.SelectedIndex + 1)

            Me.Text = "Pokemon Editor"
            Me.Enabled = True
        End If
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        FolderBrowserDialog.Description = "Select folder to export all Cries to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Cries") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Cries")
            End If

            Dim LoopVar As Integer

            LoopVar = 0
            Me.Enabled = False
            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True
                PKMNames.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1

                ExportCry(FolderBrowserDialog.SelectedPath & "\Cries\" & LoopVar & ".wav", crynorm)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfPokemon", ""))) * 100
                Me.Refresh()
            End While

            Me.Text = "Pokemon Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click

    End Sub

    Private Sub chkCompressed1_CheckedChanged(sender As Object, e As EventArgs) Handles chkCompressed1.CheckedChanged

    End Sub
End Class