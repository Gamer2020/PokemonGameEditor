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

        TrainerListComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainers", "")) = True

            LoopVar = LoopVar + 1

            TrainerListComboBox.Items.Add(GetTrainerName(LoopVar))



        End While

        TrainerListComboBox.SelectedIndex = 0


    End Sub

    Private Sub TrainerListComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TrainerListComboBox.SelectedIndexChanged

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

        While Len(MusicGenBin) < 8

            MusicGenBin = "0" & MusicGenBin

        End While

        If GetChar(MusicGenBin, 1) = "0" Then
            RadioButton1.Checked = True
        ElseIf GetChar(MusicGenBin, 1) = "1" Then
            RadioButton2.Checked = True
        End If

        TrainerIndexTextBox.Text = TrainerListComboBox.SelectedIndex + 1
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

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)

        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        WriteHEX(LoadedROM, offvar + 3, Hex(PicNumericUpDown.Value))

        WriteHEX(LoadedROM, offvar + 1, Hex(ClassComboBox.SelectedIndex))

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
End Class