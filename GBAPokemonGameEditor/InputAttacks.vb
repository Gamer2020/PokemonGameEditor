Public Class InputAttacks

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim looper As Integer
        Dim offsettowrite As String = ""

        If CheckBox2.Checked = True Then

            If CheckBox1.Checked = True Then
                offsettowrite = Hex(SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((TextBox2.Text * 3) + Len(GetString(AppPath & "ini\roms.ini", header, "JamboLearnableMovesTerm", "")) + 1), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000")))
            ElseIf CheckBox1.Checked = False Then
                offsettowrite = Hex(SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((TextBox2.Text * 2) + 3), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000")))
            End If

        ElseIf CheckBox2.Checked = False
            offsettowrite = TextBox1.Text
        End If


        If CheckBox1.Checked = True Then
            looper = 0

            While looper < TextBox2.Text

                WriteHEX(LoadedROM, ("&H" & offsettowrite) + (looper * 3), "010001")

                looper = looper + 1
            End While
            WriteHEX(LoadedROM, ("&H" & offsettowrite) + (looper * 3), GetString(AppPath & "ini\roms.ini", header, "JamboLearnableMovesTerm", "") & "00")

        ElseIf CheckBox1.Checked = False Then
            looper = 0

            While looper < TextBox2.Text

                WriteHEX(LoadedROM, ("&H" & offsettowrite) + (looper * 2), "0102")

                looper = looper + 1
            End While
            WriteHEX(LoadedROM, ("&H" & offsettowrite) + (looper * 2), "FFFF00")

        End If

        TextBox1.Text = offsettowrite

        MsgBox("Attacks inserted!")

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = True Then
            TextBox1.ReadOnly = True
        End If

        If CheckBox2.Checked = False Then
            TextBox1.ReadOnly = False
        End If

    End Sub
End Class