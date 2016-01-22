Public Class AbilityEdit
    Dim AbilityDesc As Integer
    Dim CurrentAbilityDescripLength As Integer

    Private Sub AbilityEdit_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub

    Private Sub AbilityEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loopvar As Integer

        loopvar = 0

        AbilityList.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

            AbilityList.Items.Add(GetAbilityName(loopvar))


            loopvar = loopvar + 1



        End While

        AbilityList.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChangeAbilityName(AbilityList.SelectedIndex, TextBox1.Text)

        Dim loopvar As Integer

        loopvar = 0

        AbilityList.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

            AbilityList.Items.Add(GetAbilityName(loopvar))


            loopvar = loopvar + 1



        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WriteHEX(LoadedROM, (AbilityDesc) + (AbilityList.SelectedIndex * 4), ReverseHEX(Hex(Val("&H" & (TextBox2.Text)) + &H8000000)))

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

    Private Sub AbilityList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AbilityList.SelectedIndexChanged
        AbilityIndexTextBox.Text = AbilityList.SelectedIndex

        AbilityDesc = Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)

        TextBox1.Text = GetAbilityName(AbilityList.SelectedIndex)

        TextBox2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AbilityDesc) + (AbilityList.SelectedIndex * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, Int32.Parse(((TextBox2.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        CurrentAbilityDescripLength = Len(DexDescp)
        TextBox3.Text = DexDescp

        FileClose(FileNum)



    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Label21.Text = "Length: " & Len(TextBox3.Text) & "/" & CurrentAbilityDescripLength
        Label21.ForeColor = Color.Black

        If Len(TextBox3.Text) > CurrentAbilityDescripLength Then
            Label21.Text = Label21.Text & " Requires repoint!"

            Label21.ForeColor = Color.Red

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim curdespoff As String

        Dim destowrite As String

        curdespoff = Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, (AbilityDesc) + (AbilityList.SelectedIndex * 4), 4))) - &H8000000)

        destowrite = Asc2Sapp(Replace(TextBox3.Text, vbCrLf, "\n") & "\x")



        If Len(TextBox3.Text) > CurrentAbilityDescripLength Then


            Dim result As DialogResult = MessageBox.Show("The text will be written to free space and the pointer will be repointed. Would you like to do that?",
                              "Repoint?",
                              MessageBoxButtons.YesNo)

            If (result = DialogResult.Yes) Then

                Dim newtextoff As String

                newtextoff = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(destowrite & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                FileNum = FreeFile()

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                FilePut(FileNum, destowrite & " ", ("&H" & Hex(newtextoff)) + 1, False)

                FileClose(FileNum)

                TextBox2.Text = Hex(newtextoff)

                Button2.PerformClick()

                Label21.Text = "Length: " & Len(TextBox3.Text) & "/" & CurrentAbilityDescripLength
                Label21.ForeColor = Color.Black

                If Len(TextBox3.Text) > CurrentAbilityDescripLength Then
                    Label21.Text = Label21.Text & " Requires repoint!"

                    Label21.ForeColor = Color.Red

                End If

            Else

            End If

        Else


            FileNum = FreeFile()

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            FilePut(FileNum, destowrite, ("&H" & curdespoff) + 1, False)

            FileClose(FileNum)

            TextBox2.Text = curdespoff

        End If
    End Sub
End Class