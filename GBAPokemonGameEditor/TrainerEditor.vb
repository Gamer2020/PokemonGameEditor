Public Class TrainerEditor

    Private Sub TrainerEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LoopVar As Integer

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

        PicNumericUpDown.Value = 1
        PicNumericUpDown.Value = 0
        PicNumericUpDown.Maximum = (GetString(GetINIFileLocation(), header, "NumberOfTrainerImages", ""))

        offvar = Int32.Parse((GetString(GetINIFileLocation(), header, "TrainerTable", "")), System.Globalization.NumberStyles.HexNumber)

        offvar = offvar + (40 * (TrainerListComboBox.SelectedIndex + 1))

        TNameTextBox.Text = GetTrainerName(TrainerListComboBox.SelectedIndex + 1)

        PicNumericUpDown.Value = "&H" & ReadHEX(LoadedROM, offvar + 3, 1)

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
End Class