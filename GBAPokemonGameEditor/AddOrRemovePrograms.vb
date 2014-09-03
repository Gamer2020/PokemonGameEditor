Public Class AddOrRemovePrograms

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            End
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WriteString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath" & ListBox1.SelectedIndex, TextBox2.Text)
        WriteString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName" & ListBox1.SelectedIndex, TextBox1.Text)
        Label3.Visible = True
    End Sub

    Private Sub AddOrRemovePrograms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.SelectedIndex = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        OpenFileDialog1.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        OpenFileDialog1.DefaultExt = "exe"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        OpenFileDialog1.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        OpenFileDialog1.Filter = _
            "(*.exe)|*.exe|All files (*.*)|*.*"

        OpenFileDialog1.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        OpenFileDialog1.ShowHelp = False
        OpenFileDialog1.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        OpenFileDialog1.ReadOnlyChecked = False

        OpenFileDialog1.Title = "Select Program:"

        ' Only accept valid Win32 file names?
        OpenFileDialog1.ValidateNames = True


        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            TextBox2.Text = OpenFileDialog1.FileName



        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramName" & ListBox1.SelectedIndex, "")
        TextBox2.Text = GetString(AppPath & "GBAPGESettings.ini", "Settings", "ProgramPath" & ListBox1.SelectedIndex, "")
    End Sub
End Class