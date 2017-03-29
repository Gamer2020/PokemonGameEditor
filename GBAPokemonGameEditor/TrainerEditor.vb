Imports VB = Microsoft.VisualBasic
Public Class TrainerEditor

    Private Sub TrainerEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LoopVar As Integer

        LoopVar = 0

        ClassComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainerClasses", "")) = True

            ClassComboBox.Items.Add(GetTrainerClass(LoopVar))
            LoopVar = LoopVar + 1
        End While

        LoopVar = 0

        TnPkmComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True

            LoopVar = LoopVar + 1

            TnPkmComboBox.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 0

        AttackComboBox1.Items.Clear()
        AttackComboBox2.Items.Clear()
        AttackComboBox3.Items.Clear()
        AttackComboBox4.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            AttackComboBox1.Items.Add(GetAttackName(LoopVar))
            AttackComboBox2.Items.Add(GetAttackName(LoopVar))
            AttackComboBox3.Items.Add(GetAttackName(LoopVar))
            AttackComboBox4.Items.Add(GetAttackName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        TnPkmItmComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True

            TnPkmItmComboBox.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While


        LoopVar = 0

        TrainerListComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainers", "")) = True

            LoopVar = LoopVar + 1

            TrainerListComboBox.Items.Add(GetTrainerName(LoopVar))

        End While

        LoopVar = 0

        TrainerItem1.Items.Clear()
        TrainerItem2.Items.Clear()
        TrainerItem3.Items.Clear()
        TrainerItem4.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True

            TrainerItem1.Items.Add(GetItemName(LoopVar))
            TrainerItem2.Items.Add(GetItemName(LoopVar))
            TrainerItem3.Items.Add(GetItemName(LoopVar))
            TrainerItem4.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While


        TrainerListComboBox.SelectedIndex = 0


    End Sub

    Private Sub TrainerListComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TrainerListComboBox.SelectedIndexChanged

        If TrainerListComboBox.SelectedIndex <> -1 Then

            Dim offvar As Integer
            Dim MusicGen As Integer
            Dim MusicGenBin As String

            PicNumericUpDown.Value = 1
            PicNumericUpDown.Value = 0
            PicNumericUpDown.Maximum = (GetString(GetINIFileLocation(), header, "NumberOfTrainerImages", ""))

            offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)

            offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

            TNameTextBox.Text = GetTrainerName(TrainerListComboBox.SelectedIndex + 1)

            PicNumericUpDown.Value = Int32.Parse(ReadHEX(LoadedROM, offvar + 3, 1), System.Globalization.NumberStyles.HexNumber)

            ClassComboBox.SelectedIndex = Int32.Parse(ReadHEX(LoadedROM, offvar + 1, 1), System.Globalization.NumberStyles.HexNumber)

            MusicGen = Int32.Parse(ReadHEX(LoadedROM, offvar + 2, 1), System.Globalization.NumberStyles.HexNumber)

            MusicGenBin = (Convert.ToString(MusicGen, 2))

            'While Len(MusicGenBin) < 8

            '    MusicGenBin = "0" & MusicGenBin

            'End While

            MusicGenBin = VB.Right("00000000" & MusicGenBin, 8)

            If GetChar(MusicGenBin, 1) = "0" Then
                RadioButton1.Checked = True
            ElseIf GetChar(MusicGenBin, 1) = "1" Then
                RadioButton2.Checked = True
            End If

            MusicTextBox.Text = Convert.ToInt32(MusicGenBin.Remove(0, 1), 2)

            TrainerItem1.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar + 16, 2)), System.Globalization.NumberStyles.HexNumber)
            TrainerItem2.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar + 18, 2)), System.Globalization.NumberStyles.HexNumber)
            TrainerItem3.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar + 20, 2)), System.Globalization.NumberStyles.HexNumber)
            TrainerItem4.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar + 22, 2)), System.Globalization.NumberStyles.HexNumber)

            If (ReadHEX(LoadedROM, offvar + 24, 1)) = "00" Then
                DblCheckBox.Checked = False
            ElseIf (ReadHEX(LoadedROM, offvar + 24, 1)) = "01" Then
                DblCheckBox.Checked = True
            End If

            AITextBox.Text = Int32.Parse((ReadHEX(LoadedROM, offvar + 28, 1)), System.Globalization.NumberStyles.HexNumber)

            'Pokemon Tab Stuff

            PointerPokeDataTextBox.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offvar + 36, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))
            PokeNumTextBox.Text = Int32.Parse((ReadHEX(LoadedROM, offvar + 32, 1)), System.Globalization.NumberStyles.HexNumber)
            PokeDataFormatComboBox.SelectedIndex = Int32.Parse(ReadHEX(LoadedROM, offvar, 1), System.Globalization.NumberStyles.HexNumber)

            PkmSlts.Items.Clear()

            While PkmSlts.Items.Count < PokeNumTextBox.Text

                PkmSlts.Items.Add("Pokemon Slot" & (PkmSlts.Items.Count + 1))

            End While

            PkmSlts.SelectedIndex = 0

            CalcPrizeMoney()

            'end of Pokemon Tab Stuff

            TrainerIndexTextBox.Text = TrainerListComboBox.SelectedIndex + 1

        End If

    End Sub

    Private Sub TrainerIndexTextBox_TextChanged(sender As Object, e As EventArgs) Handles TrainerIndexTextBox.TextChanged

        If TrainerIndexTextBox.Text = "" Then
            TrainerIndexTextBox.Text = 1
        End If

        TrainerListComboBox.SelectedIndex = TrainerIndexTextBox.Text - 1

    End Sub

    Private Sub PicNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles PicNumericUpDown.ValueChanged
        GetAndDrawTrainerPic(TrainerPic, PicNumericUpDown.Value)
    End Sub

    Private Sub RnmBttn_Click(sender As Object, e As EventArgs) Handles RnmBttn.Click
        Dim savevar As Integer = TrainerListComboBox.SelectedIndex

        ChangeTrainerName(TrainerListComboBox.SelectedIndex + 1, TNameTextBox.Text)

        Dim LoopVar As Integer

        LoopVar = 0

        TrainerListComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainers", "")) = True

            LoopVar = LoopVar + 1

            TrainerListComboBox.Items.Add(GetTrainerName(LoopVar))



        End While

        TrainerListComboBox.SelectedIndex = savevar

    End Sub

    Private Sub SaveBttn_Click(sender As Object, e As EventArgs) Handles SaveBttn.Click

        Dim offvar As Integer
        Dim MusicGen As Integer
        Dim MusicGenBin As String = ""
        Dim Musictextbx As Integer

        Dim loadedindex As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)

        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        WriteHEX(LoadedROM, offvar + 3, Hex(PicNumericUpDown.Value))

        WriteHEX(LoadedROM, offvar + 1, Hex(ClassComboBox.SelectedIndex))

        WriteHEX(LoadedROM, offvar + 16, ReverseHEX(VB.Right("0000" & Hex(TrainerItem1.SelectedIndex), 4)))
        WriteHEX(LoadedROM, offvar + 18, ReverseHEX(VB.Right("0000" & Hex(TrainerItem2.SelectedIndex), 4)))
        WriteHEX(LoadedROM, offvar + 20, ReverseHEX(VB.Right("0000" & Hex(TrainerItem3.SelectedIndex), 4)))
        WriteHEX(LoadedROM, offvar + 22, ReverseHEX(VB.Right("0000" & Hex(TrainerItem4.SelectedIndex), 4)))

        WriteHEX(LoadedROM, offvar + 32, Hex(PokeNumTextBox.Text))
        WriteHEX(LoadedROM, offvar, Hex(PokeDataFormatComboBox.SelectedIndex))

        If DblCheckBox.Checked = False Then

            WriteHEX(LoadedROM, offvar + 24, "00")

        ElseIf DblCheckBox.Checked = True Then

            WriteHEX(LoadedROM, offvar + 24, "01")

        End If

        WriteHEX(LoadedROM, offvar + 28, Hex(AITextBox.Text))

        Musictextbx = MusicTextBox.Text

        If RadioButton1.Checked = True Then

            MusicGenBin = "0" & VB.Right("0000000" & Convert.ToString(Musictextbx, 2), 7)

        ElseIf RadioButton2.Checked = True Then

            MusicGenBin = "1" & VB.Right("0000000" & Convert.ToString(Musictextbx, 2), 7)

        End If

        MusicGen = Convert.ToInt32(MusicGenBin, 2)

        WriteHEX(LoadedROM, offvar + 2, Hex(MusicGen))

        loadedindex = TrainerListComboBox.SelectedIndex
        TrainerListComboBox.SelectedIndex = -1
        TrainerListComboBox.SelectedIndex = loadedindex

    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        SaveFileDialog.FileName = (PicNumericUpDown.Value) & ".png"
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

            ExportTrainerSprite(SaveFileDialog.FileName, (PicNumericUpDown.Value))

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

        fileOpenDialog.Title = "Select sprite to import"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Me.Text = "Please wait..."
            Me.Enabled = False

            ImportTrainerSprite(fileOpenDialog.FileName, PicNumericUpDown.Value)


            GetAndDrawTrainerPic(TrainerPic, PicNumericUpDown.Value)

            Me.Text = "Trainer Editor"
            Me.Enabled = True
        End If
    End Sub

    Private Sub ClassComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ClassComboBox.SelectedIndexChanged

        Dim offvar As Integer

        Dim looper As Integer = 0

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerMoneyTable", "")), System.Globalization.NumberStyles.HexNumber)

        While ClassComboBox.SelectedIndex <> Int32.Parse(ReadHEX(LoadedROM, offvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber) And 255 <> Int32.Parse(ReadHEX(LoadedROM, offvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber)


            looper = looper + 1

        End While

        MoneyRateTextBox.Text = Int32.Parse(ReadHEX(LoadedROM, offvar + (looper * 4) + 1, 1), System.Globalization.NumberStyles.HexNumber)

        ClssTxtBx.Text = ClassComboBox.SelectedItem
    End Sub

    Private Sub ClssRnmBttn_Click(sender As Object, e As EventArgs) Handles ClssRnmBttn.Click
        Dim savevar As Integer = ClassComboBox.SelectedIndex

        ChangeTrainerClassName(ClassComboBox.SelectedIndex, ClssTxtBx.Text)

        Dim LoopVar As Integer

        LoopVar = 0

        ClassComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainerClasses", "")) = True

            ClassComboBox.Items.Add(GetTrainerClass(LoopVar))

            LoopVar = LoopVar + 1

        End While

        ClassComboBox.SelectedIndex = savevar
    End Sub

    Private Sub RpntPkDtBttn_Click(sender As Object, e As EventArgs) Handles RpntPkDtBttn.Click

        Dim offvar As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)
        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        WriteHEX(LoadedROM, offvar + 36, ReverseHEX(Hex(Int32.Parse(((PointerPokeDataTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        'Pokemon Tab Stuff

        PointerPokeDataTextBox.Text = (Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offvar + 36, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))
        PokeNumTextBox.Text = Int32.Parse((ReadHEX(LoadedROM, offvar + 32, 1)), System.Globalization.NumberStyles.HexNumber)
        PokeDataFormatComboBox.SelectedIndex = Int32.Parse(ReadHEX(LoadedROM, offvar, 1), System.Globalization.NumberStyles.HexNumber)

        PkmSlts.Items.Clear()

        While PkmSlts.Items.Count < PokeNumTextBox.Text

            PkmSlts.Items.Add("Pokemon Slot" & (PkmSlts.Items.Count + 1))

        End While

        PkmSlts.SelectedIndex = 0

        CalcPrizeMoney()

        'end of Pokemon Tab Stuff

    End Sub

    Private Sub TnPkmComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TnPkmComboBox.SelectedIndexChanged

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "0" Then

            If TnPkmComboBox.SelectedIndex + 1 > 0 Then
                GetAndDrawFrontPokemonPic(TnPkmPictureBox, TnPkmComboBox.SelectedIndex + 1)
            Else
                TnPkmPictureBox.Image = Nothing
            End If
        End If

    End Sub

    Private Sub TnPkmItmComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TnPkmItmComboBox.SelectedIndexChanged

        If TnPkmItmComboBox.SelectedIndex > -1 Then
            If header2 = "BPR" Or header2 = "BPG" Then

                GetAndDrawItemPic(TnPkmItmPictureBox, TnPkmItmComboBox.SelectedIndex)

            ElseIf header2 = "BPE" Then

                GetAndDrawItemPic(TnPkmItmPictureBox, TnPkmItmComboBox.SelectedIndex)

            ElseIf header2 = "AXP" Or header2 = "AXV" Then

                TnPkmItmPictureBox.Image = Nothing

            End If

        Else
            TnPkmItmPictureBox.Image = Nothing
        End If

    End Sub

    Private Sub PkmSlts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PkmSlts.SelectedIndexChanged
        Dim offvar As Integer
        Dim offvar2 As Integer
        Dim curtype As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)
        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        offvar2 = ((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offvar + 36, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

        curtype = Int32.Parse(ReadHEX(LoadedROM, offvar, 1), System.Globalization.NumberStyles.HexNumber)

        If curtype = 0 Then

            PkmnEvsTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            PkmLvlTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            TnPkmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber) - 1

            TnPkmItmComboBox.SelectedIndex = -1
            AttackComboBox1.SelectedIndex = -1
            AttackComboBox2.SelectedIndex = -1
            AttackComboBox3.SelectedIndex = -1
            AttackComboBox4.SelectedIndex = -1

            TnPkmItmComboBox.Enabled = False
            AttackComboBox1.Enabled = False
            AttackComboBox2.Enabled = False
            AttackComboBox3.Enabled = False
            AttackComboBox4.Enabled = False

        ElseIf curtype = 1 Then

            PkmnEvsTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            PkmLvlTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            TnPkmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber) - 1

            AttackComboBox1.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox2.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 8 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox3.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 10 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox4.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 12 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)

            TnPkmItmComboBox.SelectedIndex = -1

            TnPkmItmComboBox.Enabled = False
            AttackComboBox1.Enabled = True
            AttackComboBox2.Enabled = True
            AttackComboBox3.Enabled = True
            AttackComboBox4.Enabled = True

        ElseIf curtype = 2 Then

            PkmnEvsTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            PkmLvlTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            TnPkmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber) - 1

            TnPkmItmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)

            AttackComboBox1.SelectedIndex = -1
            AttackComboBox2.SelectedIndex = -1
            AttackComboBox3.SelectedIndex = -1
            AttackComboBox4.SelectedIndex = -1

            TnPkmItmComboBox.Enabled = True
            AttackComboBox1.Enabled = False
            AttackComboBox2.Enabled = False
            AttackComboBox3.Enabled = False
            AttackComboBox4.Enabled = False

        ElseIf curtype = 3 Then

            PkmnEvsTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            PkmLvlTextBox.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            TnPkmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber) - 1

            TnPkmItmComboBox.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox1.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 8 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox2.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 10 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox3.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 12 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)
            AttackComboBox4.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, offvar2 + 14 + (PkmSlts.SelectedIndex * 16), 2)), System.Globalization.NumberStyles.HexNumber)

            TnPkmItmComboBox.Enabled = True
            AttackComboBox1.Enabled = True
            AttackComboBox2.Enabled = True
            AttackComboBox3.Enabled = True
            AttackComboBox4.Enabled = True

        End If

    End Sub

    Private Sub PkmnSvBttn_Click(sender As Object, e As EventArgs) Handles PkmnSvBttn.Click

        Dim offvar As Integer
        Dim offvar2 As Integer
        Dim curtype As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)
        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        offvar2 = ((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offvar + 36, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

        curtype = Int32.Parse(ReadHEX(LoadedROM, offvar, 1), System.Globalization.NumberStyles.HexNumber)

        If curtype = 0 Then

            WriteHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmnEvsTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmLvlTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmComboBox.SelectedIndex + 1), 4)))

        ElseIf curtype = 1 Then

            WriteHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmnEvsTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmLvlTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmComboBox.SelectedIndex + 1), 4)))

            WriteHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox1.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 8 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox2.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 10 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox3.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 12 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox4.SelectedIndex), 4)))

        ElseIf curtype = 2 Then

            WriteHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmnEvsTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmLvlTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmComboBox.SelectedIndex + 1), 4)))

            WriteHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmItmComboBox.SelectedIndex), 4)))

        ElseIf curtype = 3 Then

            WriteHEX(LoadedROM, offvar2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmnEvsTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 2 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(PkmLvlTextBox.Text), 4)))
            WriteHEX(LoadedROM, offvar2 + 4 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmComboBox.SelectedIndex + 1), 4)))

            WriteHEX(LoadedROM, offvar2 + 6 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(TnPkmItmComboBox.SelectedIndex), 4)))

            WriteHEX(LoadedROM, offvar2 + 8 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox1.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 10 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox2.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 12 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox3.SelectedIndex), 4)))
            WriteHEX(LoadedROM, offvar2 + 14 + (PkmSlts.SelectedIndex * 16), ReverseHEX(VB.Right("0000" & Hex(AttackComboBox4.SelectedIndex), 4)))

        End If

    End Sub

    Private Sub SaveMnyRt_Click(sender As Object, e As EventArgs) Handles SaveMnyRt.Click
        Dim offvar As Integer

        Dim looper As Integer = 0

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerMoneyTable", "")), System.Globalization.NumberStyles.HexNumber)

        While ClassComboBox.SelectedIndex <> Int32.Parse(ReadHEX(LoadedROM, offvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber) And 255 <> Int32.Parse(ReadHEX(LoadedROM, offvar + (looper * 4), 1), System.Globalization.NumberStyles.HexNumber)


            looper = looper + 1

        End While

        WriteHEX(LoadedROM, offvar + (looper * 4) + 1, Hex(MoneyRateTextBox.Text))

    End Sub

    Private Sub MoneyRateTextBox_TextChanged(sender As Object, e As EventArgs) Handles MoneyRateTextBox.TextChanged

        CalcPrizeMoney()

    End Sub

    Private Sub CalcPrizeMoney()

        Dim offvar As Integer
        Dim offvar2 As Integer

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)
        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        offvar2 = ((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offvar + 36, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000))

        Dim num As Integer = 0
        Dim num2 As Integer = 8

        If PokeDataFormatComboBox.SelectedIndex <> -1 And MoneyRateTextBox.Text <> "" Then

            If PokeDataFormatComboBox.SelectedIndex = 1 Or PokeDataFormatComboBox.SelectedIndex = 3 Then
                num2 = &H10
            End If
            If (PkmSlts.Items.Count > 0) Then
                num = (4 * Int32.Parse(ReadHEX(LoadedROM, ((((offvar2) + (num2 * PkmSlts.Items.Count)) - num2) + 2), 1), System.Globalization.NumberStyles.HexNumber))
            End If
            Label15.Text = ("Prize Money: " & ((num * MoneyRateTextBox.Text)))

        End If

    End Sub

End Class