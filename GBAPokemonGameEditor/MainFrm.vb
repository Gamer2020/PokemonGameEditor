Option Strict Off
Option Explicit On
Imports System.IO
Imports System.Windows.Forms.Application
Imports System.Net


Public Class MainFrm

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next



        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0") = "0" Then

            TransparentBackgroundsToolStripMenuItem.CheckState = CheckState.Checked

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0") = "1" Then

            Jambo51MoveTableHackToolStripMenuItem.CheckState = CheckState.Checked

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = "1" Then

            UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.CheckState = CheckState.Checked

        End If


        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0") = "1" Then

            DisablePokemonImageLoadingToolStripMenuItem.CheckState = CheckState.Checked

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "OsisLinux", "0") = "1" Then

            LinuxToolStripMenuItem.CheckState = CheckState.Checked

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "") <> "" Then

            Button27.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName0", "")
            Button27.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath1", "") <> "" Then

            Button28.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName1", "")
            Button28.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath2", "") <> "" Then

            Button29.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName2", "")
            Button29.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath3", "") <> "" Then

            Button30.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName3", "")
            Button30.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath4", "") <> "" Then

            Button31.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName4", "")
            Button31.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath5", "") <> "" Then

            Button37.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName5", "")
            Button37.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath6", "") <> "" Then

            Button38.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName6", "")
            Button38.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath7", "") <> "" Then

            Button39.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName7", "")
            Button39.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath8", "") <> "" Then

            Button40.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName8", "")
            Button40.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath9", "") <> "" Then

            Button41.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName9", "")
            Button41.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath10", "") <> "" Then

            Button42.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName10", "")
            Button42.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath11", "") <> "" Then

            Button43.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName11", "")
            Button43.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath12", "") <> "" Then

            Button44.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName12", "")
            Button44.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath13", "") <> "" Then

            Button45.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName13", "")
            Button45.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath14", "") <> "" Then

            Button46.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName14", "")
            Button46.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath15", "") <> "" Then

            Button47.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName15", "")
            Button47.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath16", "") <> "" Then

            Button48.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName16", "")
            Button48.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath17", "") <> "" Then

            Button49.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName17", "")
            Button49.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath18", "") <> "" Then

            Button50.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName18", "")
            Button50.Enabled = True

        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath19", "") <> "" Then

            Button51.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName19", "")
            Button51.Enabled = True

        End If

        If (My.Application.CommandLineArgs.Count > 0) Then


            '   MessageBox.Show(My.Application.CommandLineArgs(0))

            If IO.Path.GetExtension(My.Application.CommandLineArgs(0)) = ".gba" Or IO.Path.GetExtension(My.Application.CommandLineArgs(0)) = ".GBA" Then

                LoadedROM = My.Application.CommandLineArgs(0)

                HandleOpenedROM()
            Else

                MessageBox.Show("File must end with a .gba extension.")

            End If

        End If

    End Sub

    Private Sub MainFrm_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String


            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)

            If MyFiles.Length > 1 Then
                MessageBox.Show("One file only please...")
            End If

            'MessageBox.Show(MyFiles.Length)

            ' MessageBox.Show(IO.Path.GetExtension(MyFiles(0)))

            If IO.Path.GetExtension(MyFiles(0)) = ".gba" Or IO.Path.GetExtension(MyFiles(0)) = ".GBA" Then

                LoadedROM = MyFiles(0)

                HandleOpenedROM()
            Else

                MessageBox.Show("File must end with a .gba extension.")

            End If

            ' Loop through the array and add the files to the list.
            'For i = 0 To MyFiles.Length - 1
            'ListBox1.Items.Add(MyFiles(i))
            'Next
        End If

    End Sub

    Private Sub MainFrm_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        fileOpenDialog.FileName = ""
        fileOpenDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        fileOpenDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        fileOpenDialog.DefaultExt = "GBA"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        fileOpenDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        fileOpenDialog.Filter = _
            "(*.gba)|*.gba*"

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

        fileOpenDialog.Title = "Select ROM to open:"

        ' Only accept valid Win32 file names?
        fileOpenDialog.ValidateNames = True


        If fileOpenDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            LoadedROM = fileOpenDialog.FileName

            HandleOpenedROM()

        End If
    End Sub

    Private Sub HandleOpenedROM()
        FileNum = FreeFile()

        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        'Opens the ROM as binary
        FileGet(FileNum, header, &HAD, True)
        header2 = Mid(header, 1, 3)
        header3 = Mid(header, 4, 1)
        FileClose(FileNum)

        'MsgBox(GetINIFileLocation())

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Or header2 = "AXP" Or header2 = "AXV" Then
            If header3 = "J" Then
                Label2.Text = ""
                LoadedROM = ""
                Button5.Enabled = False
                Button6.Enabled = False
                Button7.Enabled = False
                Button25.Enabled = False
                Button26.Enabled = False
                Button32.Enabled = False
                Button33.Enabled = False
                Button34.Enabled = False
                Button35.Enabled = False
                Button1.Enabled = False
                MessageBox.Show("I haven't added Jap support out of pure lazziness. I will though if it get's highly Demanded.")
            Else

                Label2.Text = header & " - " & GetString(GetINIFileLocation(), header, "ROMName", "")

                Button5.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                Button25.Enabled = True
                Button26.Enabled = True
                Button24.Enabled = True
                Button32.Enabled = True
                Button33.Enabled = True
                Button34.Enabled = True
                Button35.Enabled = True
                Button1.Enabled = True
            End If
        Else
            Label2.Text = ""
            LoadedROM = ""
            Button5.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            Button25.Enabled = False
            Button26.Enabled = False
            Button24.Enabled = False
            Button32.Enabled = False
            Button33.Enabled = False
            Button34.Enabled = False
            Button35.Enabled = False
            Button1.Enabled = False
            MessageBox.Show("Not one of the Pokemon games...")

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpenToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        'AboutBox1.ShowDialog()
        If System.IO.File.Exists(AppPath & "license.rtf") = True Then
            Process.Start(AppPath & "license.rtf")
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        movetutor2.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        PokedexOrderEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ' Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        Pokemonedit.Show()
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub TransparentBackgroundsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransparentBackgroundsToolStripMenuItem.Click
        If TransparentBackgroundsToolStripMenuItem.CheckState = CheckState.Checked Then

            TransparentBackgroundsToolStripMenuItem.CheckState = CheckState.Unchecked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "1")

        ElseIf TransparentBackgroundsToolStripMenuItem.CheckState = CheckState.Unchecked Then

            TransparentBackgroundsToolStripMenuItem.CheckState = CheckState.Checked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "TransparentImages", "0")

        End If
    End Sub


    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Me.Cursor = Cursors.WaitCursor
        'Me.Visible = False
        AttackEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Jambo51MoveTableHackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jambo51MoveTableHackToolStripMenuItem.Click
        If Jambo51MoveTableHackToolStripMenuItem.CheckState = CheckState.Checked Then

            Jambo51MoveTableHackToolStripMenuItem.CheckState = CheckState.Unchecked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "0")

        ElseIf Jambo51MoveTableHackToolStripMenuItem.CheckState = CheckState.Unchecked Then

            Jambo51MoveTableHackToolStripMenuItem.CheckState = CheckState.Checked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "MoveTableHack", "1")

        End If
    End Sub



    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        AbilityEdit.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DisablePokemonImageLoadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisablePokemonImageLoadingToolStripMenuItem.Click
        If DisablePokemonImageLoadingToolStripMenuItem.CheckState = CheckState.Checked Then

            DisablePokemonImageLoadingToolStripMenuItem.CheckState = CheckState.Unchecked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "0")

        ElseIf DisablePokemonImageLoadingToolStripMenuItem.CheckState = CheckState.Unchecked Then

            DisablePokemonImageLoadingToolStripMenuItem.CheckState = CheckState.Checked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "DisablePKMImages", "1")

        End If
    End Sub

    Private Sub UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.Click
        If UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.CheckState = CheckState.Checked Then

            UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.CheckState = CheckState.Unchecked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0")

        ElseIf UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.CheckState = CheckState.Unchecked Then

            UseJambo51sTMHMExtensionHackIfYouDontKnowWhatThisIsDontUseItToolStripMenuItem.CheckState = CheckState.Checked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "1")

        End If
    End Sub

    Private Sub AddOrRemoveProgramsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddOrRemoveProgramsToolStripMenuItem.Click
        AddOrRemovePrograms.ShowDialog()
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        'If GetString(AppPath & "GBAPGESettings.ini", "Settings", "OSisLinux", "0") = "1" Then

        '   If (IO.Path.GetExtension(GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "")) = ".jar") Then


        ' If LoadedROM = "" Then
        'Shell(" java -jar " & """" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "") & """", vbNormalFocus)
        'Else


        '        If System.IO.File.Exists(LoadedROM) = True Then
        '             Shell(" java -jar " & """" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
        ' End If
        '      End If

        '   Else

        '   End If
        ' Else
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath0", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
        '  End If

    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath1", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath1", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath2", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath2", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath3", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath3", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath4", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath4", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        RSEStarterEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        PokedexDataEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        'Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        BattleFrontierEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EditRomsiniToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditRomsiniToolStripMenuItem.Click
        Process.Start(AppPath & "ini\roms.ini")
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath5", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath5", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath6", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath6", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath7", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath7", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath8", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath8", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath9", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath9", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath10", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath10", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath11", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath11", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath12", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath12", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath13", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath13", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath14", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath14", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath15", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath15", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath16", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath16", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath17", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath17", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath18", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath18", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        If LoadedROM = "" Then
            Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath19", "") & """", vbNormalFocus)
        Else


            If System.IO.File.Exists(LoadedROM) = True Then
                Shell("""" & GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath19", "") & """" & " " & """" & LoadedROM & """", vbNormalFocus)
            End If
        End If
    End Sub

    Private Sub LinuxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LinuxToolStripMenuItem.Click
        If LinuxToolStripMenuItem.CheckState = CheckState.Checked Then

            LinuxToolStripMenuItem.CheckState = CheckState.Unchecked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "OSisLinux", "0")

        ElseIf LinuxToolStripMenuItem.CheckState = CheckState.Unchecked Then

            LinuxToolStripMenuItem.CheckState = CheckState.Checked

            WriteString(AppPath & "GBAPGESettings.ini", "Settings", "OSisLinux", "1")

        End If
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        Me.Cursor = Cursors.WaitCursor
        ItemEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        Me.Cursor = Cursors.WaitCursor
        TMHMEditor.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        AttackExpander.Show()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
