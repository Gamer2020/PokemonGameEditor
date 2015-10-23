Public Class AbilityEdit
    Dim AbilityDesc As Integer

    Private Sub AbilityEdit_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub

    Private Sub AbilityEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loopvar As Integer

        loopvar = 0

        ListBox1.Items.Clear()

        While loopvar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAbilities", "")) = True

            ListBox1.Items.Add(GetAbilityName(loopvar))


            loopvar = loopvar + 1



        End While

        ListBox1.SelectedIndex = 0
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        AbilityIndexTextBox.Text = ListBox1.SelectedIndex

        AbilityDesc = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

        TextBox1.Text = GetAbilityName(ListBox1.SelectedIndex)

        TextBox2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AbilityDesc) + (ListBox1.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, Int32.Parse(((TextBox2.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        TextBox3.Text = DexDescp
        TextBox3.MaxLength = Len(DexDescp)

        FileClose(FileNum)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChangeAbilityName(ListBox1.SelectedIndex, TextBox1.Text)

        Dim loopvar As Integer

        loopvar = 0

        ListBox1.Items.Clear()

        While loopvar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAbilities", "")) = True

            ListBox1.Items.Add(GetAbilityName(loopvar))


            loopvar = loopvar + 1



        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WriteHEX(LoadedROM, (AbilityDesc) + (ListBox1.SelectedIndex * 4), ReverseHEX(Hex(Val("&H" & (TextBox2.Text)) + &H8000000)))

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, Int32.Parse(((TextBox2.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        TextBox3.Text = DexDescp
        TextBox3.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub
End Class