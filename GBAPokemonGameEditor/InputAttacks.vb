Public Class InputAttacks

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim looper As Integer
        If CheckBox1.Checked = True Then
            looper = 0

            While looper < TextBox2.Text

                WriteHEX(LoadedROM, ("&H" & TextBox1.Text) + (looper * 3), "010001")

                looper = looper + 1
            End While
            WriteHEX(LoadedROM, ("&H" & TextBox1.Text) + (looper * 3), GetString(AppPath & "ini\roms.ini", header, "JamboLearnableMovesTerm", ""))
            Me.Close()
        ElseIf CheckBox1.Checked = False Then
            looper = 0

            While looper < TextBox2.Text

                WriteHEX(LoadedROM, ("&H" & TextBox1.Text) + (looper * 2), "0102")

                looper = looper + 1
            End While
            WriteHEX(LoadedROM, ("&H" & TextBox1.Text) + (looper * 2), "FFFF")
            Me.Close()
        End If

    End Sub
End Class