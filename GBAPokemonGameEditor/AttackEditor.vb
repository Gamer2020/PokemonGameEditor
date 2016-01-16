Public Class AttackEditor
    Dim AttackDesc As Integer
    Dim AttackData As Integer
    Dim AttackAni As Integer
    Dim ContestMoveData As Integer
    Dim ContestMoveEffectData As Integer
    Dim CurrentAttackDescripLength As Integer

    Private Sub AttackEditor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub

    Private Sub AttackEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim LoopVar As Integer
        LoopVar = 1

        ComboBox1.Items.Clear()

        ComboBox1.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGETypeList.txt"))

        ComboBox3.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox3.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While
        ComboBox3.SelectedIndex = 0


    End Sub


    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim blah As Integer
        Dim binarythebitch As String
        AttackDesc = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber)
        AttackData = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber)
        AttackAni = Int32.Parse((GetString(GetINIFileLocation(), header, "AttackAnimationTable", "")), System.Globalization.NumberStyles.HexNumber)

        AnimationPointer.Text = Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, (AttackAni) + (ComboBox3.SelectedIndex * 4) + 4, 4))) - &H8000000)

        AttackListIndex.Text = ComboBox3.SelectedIndex + 1

        TextBox1.Text = GetAttackName(ComboBox3.SelectedIndex + 1)

        TextBox6.Text = Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, (AttackDesc) + (ComboBox3.SelectedIndex * 4), 4))) - &H8000000)

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim AttackDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, AttackDescp, Int32.Parse(((TextBox6.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        AttackDescp = Sapp2Asc(AttackDescp)
        AttackDescp = Mid$(AttackDescp, 1, InStr(1, AttackDescp, "\x"))
        AttackDescp = Replace(AttackDescp, "\n", vbCrLf)
        AttackDescp = Replace(RTrim$(AttackDescp), "\", "")

        CurrentAttackDescripLength = Len(AttackDescp)
        TextBox7.Text = AttackDescp

        ' Label21.Text = "Length:" & CurrentAttackDescripLength & " / " & CurrentAttackDescripLength

        FileClose(FileNum)

        Effects.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        BasePower.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 1) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        ComboBox1.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 2) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox2.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 3) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox3.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 4) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox4.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 5) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 6) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox5.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 7) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        ComboBox7.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 9) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)
        ComboBox8.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 10) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)

        Dim bita As String
        Dim bitb As String
        Dim bitc As String
        Dim bitd As String
        Dim bite As String
        Dim bitf As String

        blah = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((AttackData) + 12 + 8) + (ComboBox3.SelectedIndex * 12), 1)))), System.Globalization.NumberStyles.HexNumber)

        binarythebitch = Convert.ToString(blah, 2)

        While Len(binarythebitch) < 8

            binarythebitch = "0" & binarythebitch

        End While

        bita = Mid(binarythebitch, 8, 1)

        bitb = Mid(binarythebitch, 7, 1)

        bitc = Mid(binarythebitch, 6, 1)

        bitd = Mid(binarythebitch, 5, 1)

        bite = Mid(binarythebitch, 4, 1)

        bitf = Mid(binarythebitch, 3, 1)

        If bita = 0 Then
            CheckBox1.Checked = False
        ElseIf bita = 1 Then
            CheckBox1.Checked = True
        End If

        If bitb = 0 Then
            CheckBox2.Checked = False
        ElseIf bitb = 1 Then
            CheckBox2.Checked = True
        End If

        If bitc = 0 Then
            CheckBox3.Checked = False
        ElseIf bitc = 1 Then
            CheckBox3.Checked = True
        End If

        If bitd = 0 Then
            CheckBox4.Checked = False
        ElseIf bitd = 1 Then
            CheckBox4.Checked = True
        End If

        If bite = 0 Then
            CheckBox5.Checked = False
        ElseIf bite = 1 Then
            CheckBox5.Checked = True
        End If

        If bitf = 0 Then
            CheckBox6.Checked = False
        ElseIf bitf = 1 Then
            CheckBox6.Checked = True
        End If

        If header2 = "AXP" Or header2 = "AXV" Or header2 = "BPE" Then
            ComboBox4.Enabled = True
            ComboBox5.Enabled = True
            TextBox9.Enabled = True
            TextBox8.Enabled = True
            ComboBox6.Enabled = True
            TextBox11.Enabled = True
            TextBox10.Enabled = True
            TextBox12.Enabled = True
            TextBox13.Enabled = True
            Button5.Enabled = True
            ContestMoveData = Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveData", "")), System.Globalization.NumberStyles.HexNumber)
            ContestMoveEffectData = Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveEffectData", "")), System.Globalization.NumberStyles.HexNumber)


            ComboBox4.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 0) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            ComboBox5.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 1) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox9.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 2) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox8.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 3) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox12.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 4) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox13.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveData) + 8 + 5) + (ComboBox3.SelectedIndex * 8), 1)))), System.Globalization.NumberStyles.HexNumber)

            ComboBox6.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 0) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox11.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 1) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)
            TextBox10.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 2) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)
        Else
            ComboBox4.Enabled = False
            ComboBox5.Enabled = False
            TextBox9.Enabled = False
            TextBox8.Enabled = False
            TextBox12.Enabled = False
            TextBox13.Enabled = False
            ComboBox6.Enabled = False
            TextBox11.Enabled = False
            TextBox10.Enabled = False
            Button5.Enabled = False

            ComboBox4.SelectedIndex = -1
            ComboBox5.SelectedIndex = -1
            TextBox9.Text = ""
            TextBox8.Text = ""
            TextBox12.Text = ""
            TextBox13.Text = ""
            ComboBox6.SelectedIndex = -1
            TextBox11.Text = ""
            TextBox10.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tempy As Integer
        tempy = ComboBox3.SelectedIndex

        ChangeAttackName(ComboBox3.SelectedIndex + 1, TextBox1.Text)

        Dim LoopVar As Integer

        LoopVar = 1

        ComboBox3.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox3.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        ComboBox3.SelectedIndex = tempy
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        WriteHEX(LoadedROM, ((AttackData) + 12) + (ComboBox3.SelectedIndex * 12), Hex(Effects.SelectedIndex))
       WriteHEX(LoadedROM, ((AttackData) + 12 + 1) + (ComboBox3.SelectedIndex * 12), Hex(BasePower.Text))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 2) + (ComboBox3.SelectedIndex * 12), Hex(ComboBox1.SelectedIndex))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 3) + (ComboBox3.SelectedIndex * 12), Hex(TextBox2.Text))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 4) + (ComboBox3.SelectedIndex * 12), Hex(TextBox3.Text))
       WriteHEX(LoadedROM, ((AttackData) + 12 + 5) + (ComboBox3.SelectedIndex * 12), Hex(TextBox4.Text))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 6) + (ComboBox3.SelectedIndex * 12), Hex(ComboBox2.SelectedIndex))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 7) + (ComboBox3.SelectedIndex * 12), Hex(TextBox5.Text))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 9) + (ComboBox3.SelectedIndex * 12), Hex(ComboBox7.SelectedIndex))
        WriteHEX(LoadedROM, ((AttackData) + 12 + 10) + (ComboBox3.SelectedIndex * 12), Hex(ComboBox8.SelectedIndex))

        Dim bita As String = ""
        Dim bitb As String = ""
        Dim bitc As String = ""
        Dim bitd As String = ""
        Dim bite As String = ""
        Dim bitf As String = ""
        Dim thingtowrite As String

        If CheckBox1.Checked = False Then
            bita = 0
        ElseIf CheckBox1.Checked = True Then
            bita = 1
        End If

        If CheckBox2.Checked = False Then
            bitb = 0
        ElseIf CheckBox2.Checked = True Then
            bitb = 1
        End If

        If CheckBox3.Checked = False Then
            bitc = 0
        ElseIf CheckBox3.Checked = True Then
            bitc = 1
        End If

        If CheckBox4.Checked = False Then
            bitd = 0
        ElseIf CheckBox4.Checked = True Then
            bitd = 1
        End If

        If CheckBox5.Checked = False Then
            bite = 0
        ElseIf CheckBox5.Checked = True Then
            bite = 1
        End If

        If CheckBox6.Checked = False Then
            bitf = 0
        ElseIf CheckBox6.Checked = True Then
            bitf = 1
        End If
        thingtowrite = bitf & bite & bitd & bitc & bitb & bita
        thingtowrite = Convert.ToInt32(thingtowrite, 2)

        WriteHEX(LoadedROM, ((AttackData) + 12 + 8) + (ComboBox3.SelectedIndex * 12), Hex(thingtowrite))

        If header2 = "AXP" Or header2 = "AXV" Or header2 = "BPE" Then
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 0) + (ComboBox3.SelectedIndex * 8), Hex(ComboBox4.SelectedIndex))
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 1) + (ComboBox3.SelectedIndex * 8), Hex(ComboBox5.SelectedIndex))
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 2) + (ComboBox3.SelectedIndex * 8), Hex(TextBox9.Text))
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 3) + (ComboBox3.SelectedIndex * 8), Hex(TextBox8.Text))
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 4) + (ComboBox3.SelectedIndex * 8), Hex(TextBox12.Text))
            WriteHEX(LoadedROM, ((ContestMoveData) + 8 + 5) + (ComboBox3.SelectedIndex * 8), Hex(TextBox13.Text))

        Else
            'Does nothing for these games.
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        WriteHEX(LoadedROM, (AttackDesc) + (0) + (ComboBox3.SelectedIndex * 4), ReverseHEX(Hex(Int32.Parse(((TextBox6.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim AttackDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, AttackDescp, Int32.Parse(((TextBox6.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        AttackDescp = Sapp2Asc(AttackDescp)
        AttackDescp = Mid$(AttackDescp, 1, InStr(1, AttackDescp, "\x"))
        AttackDescp = Replace(AttackDescp, "\n", vbCrLf)
        AttackDescp = Replace(RTrim$(AttackDescp), "\", "")
        CurrentAttackDescripLength = Len(AttackDescp)
        TextBox7.Text = AttackDescp
        TextBox7.MaxLength = Len(AttackDescp)

        FileClose(FileNum)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        WriteHEX(LoadedROM, (AttackAni) + (4) + (ComboBox3.SelectedIndex * 4), ReverseHEX(Hex(Int32.Parse(((AnimationPointer.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
    End Sub


    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged

        ComboBox6.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 0) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox11.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 1) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)
        TextBox10.Text = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, ((ContestMoveEffectData) + 2) + (ComboBox4.SelectedIndex * 4), 1)))), System.Globalization.NumberStyles.HexNumber)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        WriteHEX(LoadedROM, ((ContestMoveEffectData) + 0) + (ComboBox4.SelectedIndex * 4), Hex(ComboBox6.SelectedIndex))
        WriteHEX(LoadedROM, ((ContestMoveEffectData) + 1) + (ComboBox4.SelectedIndex * 4), Hex(TextBox11.Text))
        WriteHEX(LoadedROM, ((ContestMoveEffectData) + 2) + (ComboBox4.SelectedIndex * 4), Hex(TextBox10.Text))
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        Label21.Text = "Length: " & Len(TextBox7.Text) & "/" & CurrentAttackDescripLength
        Label21.ForeColor = Color.Black

        If Len(TextBox7.Text) > CurrentAttackDescripLength Then
            Label21.Text = Label21.Text & " Requires repoint!"

            Label21.ForeColor = Color.Red

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim curdespoff As String

        Dim destowrite As String

        curdespoff = Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, (AttackDesc) + (ComboBox3.SelectedIndex * 4), 4))) - &H8000000)

        destowrite = Asc2Sapp(Replace(TextBox7.Text, vbCrLf, "\n") & "\x")



        If Len(TextBox7.Text) > CurrentAttackDescripLength Then


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

                TextBox6.Text = Hex(newtextoff)

                Button2.PerformClick()

                Label21.Text = "Length: " & Len(TextBox7.Text) & "/" & CurrentAttackDescripLength
                Label21.ForeColor = Color.Black

                If Len(TextBox7.Text) > CurrentAttackDescripLength Then
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

            TextBox6.Text = curdespoff

        End If

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
    End Sub
End Class