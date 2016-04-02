Imports System.IO.Directory
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

        Dim indexbuff As Integer

        indexbuff = AbilityList.SelectedIndex

        ChangeAbilityName(AbilityList.SelectedIndex, TextBox1.Text)

        Dim loopvar As Integer

        loopvar = 0

        AbilityList.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

            AbilityList.Items.Add(GetAbilityName(loopvar))


            loopvar = loopvar + 1



        End While

        AbilityList.SelectedIndex = -1
        AbilityList.SelectedIndex = indexbuff

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
        CurrentAbilityDescripLength = Len(DexDescp)
        TextBox3.Text = DexDescp


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

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Me.Text = "Please wait..."
        Me.UseWaitCursor = True
        ProgressBar.Value = 0
        ProgressBar.Visible = True

        Dim LoopVar As Integer

        LoopVar = 0

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) - 1 = True
            AbilityList.SelectedIndex = LoopVar

            LoopVar = LoopVar + 1
            Me.Refresh()
            Me.Enabled = False

            ChangeAbilityName(LoopVar, DecapString(GetAbilityName(LoopVar)))

            ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) * 100
        End While


        LoopVar = 0

        AbilityList.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

            AbilityList.Items.Add(GetAbilityName(LoopVar))


            LoopVar = LoopVar + 1



        End While

        AbilityList.SelectedIndex = 0

        Me.Text = "Ability Editor"
        Me.UseWaitCursor = False
        Me.Enabled = True
        ProgressBar.Visible = False
        Me.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog.FileName = (AbilityList.SelectedIndex) & ".ini"
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

            ExportAbilityINI(SaveFileDialog.FileName, (AbilityList.SelectedIndex))

        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        FolderBrowserDialog.Description = "Select folder to export all Abilities to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Abilities") = False Then
                CreateDirectory(FolderBrowserDialog.SelectedPath & "\Abilities")
            End If

            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) - 1 = True
                LoopVar = LoopVar + 1
                AbilityList.SelectedIndex = LoopVar

                Me.Refresh()
                Me.Enabled = False

                ExportAbilityINI(FolderBrowserDialog.SelectedPath & "\Abilities\" & LoopVar & ".ini", LoopVar)

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) * 100
            End While

            Me.Text = "Ability Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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

            ImportAbilityINI(fileOpenDialog.FileName, (AbilityList.SelectedIndex))

            Dim refreshvar As Integer

            refreshvar = AbilityList.SelectedIndex

            If AbilityList.SelectedIndex = 0 Then
                AbilityList.SelectedIndex = AbilityList.SelectedIndex + 1
            Else
                AbilityList.SelectedIndex = AbilityList.SelectedIndex - 1
            End If

            AbilityList.Items.Insert(refreshvar, GetAbilityName(refreshvar))

            AbilityList.Items.RemoveAt(refreshvar + 1)

            AbilityList.SelectedIndex = refreshvar

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FolderBrowserDialog.Description = "Select folder to import Abilities from:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar.Value = 0
            ProgressBar.Visible = True

            Dim LoopVar As Integer

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) - 1 = True
                LoopVar = LoopVar + 1

                AbilityList.SelectedIndex = LoopVar

                Me.Refresh()
                Me.Enabled = False

                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".ini") Then
                    ImportAbilityINI(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".ini", LoopVar)
                End If

                ProgressBar.Value = (LoopVar / (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) * 100
            End While

            LoopVar = 0

            AbilityList.Items.Clear()

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) = True

                AbilityList.Items.Add(GetAbilityName(LoopVar))


                LoopVar = LoopVar + 1



            End While

            AbilityList.SelectedIndex = 0

            Me.Text = "Ability Editor"
            Me.UseWaitCursor = False
            Me.Enabled = True
            ProgressBar.Visible = False
            Me.BringToFront()
        End If
    End Sub
End Class