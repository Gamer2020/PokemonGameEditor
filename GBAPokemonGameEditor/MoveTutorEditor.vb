Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Public Class MoveTutorEditor


    Dim Offset As Integer
    'Dim Offset2 As Long

    Private Sub movetutor2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            Offset = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)


            Dim loopything As String = 0

            Dim curattack As String

            Combo1.Items.Clear() 'Clears the combo boxes

            While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1)


                curattack = GetAttackName(loopything)

                Combo1.Items.Add(curattack) 'adds the attacks to the comboboxes

                loopything = loopything + 1
            End While

            loopything = 0

            ListBox1.Items.Clear()

            While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))

                ListBox1.Items.Add(GetAttackName(Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * loopything), 2)))), System.Globalization.NumberStyles.HexNumber)))

                loopything = loopything + 1
            End While


            Me.Cursor = Cursors.Arrow

            ListBox1.SelectedIndex = 0


        Else

            'If the ROM is not supported this code will run
            Combo1.Enabled = False

            Button2.Enabled = False

            Combo1.Items.Clear() 'Clears the combo boxes


            MsgBox("Unsupported ROM!")
            'Lets the person know the ROM isn't supported.
            End

        End If
   
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim indexbuff As Integer

        indexbuff = ListBox1.SelectedIndex

        WriteHEX(LoadedROM, Offset + (2 * ListBox1.SelectedIndex), ReverseHEX(VB.Right("0000" & Hex(Combo1.SelectedIndex), 4)))

        Dim loopything As String = 0

        ListBox1.Items.Clear()

        While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))

            ListBox1.Items.Add(GetAttackName(Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * loopything), 2)))), System.Globalization.NumberStyles.HexNumber)))

            loopything = loopything + 1
        End While


        Me.Cursor = Cursors.Arrow

        ListBox1.SelectedIndex = indexbuff

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Combo1.SelectedIndex = ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * ListBox1.SelectedIndex), 2)))), System.Globalization.NumberStyles.HexNumber)))
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

            ImportTutorMoves(fileOpenDialog.FileName)

            movetutor2_Load(Me, EventArgs.Empty)

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SaveFileDialog.FileName = "TutorMoves.ini"
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

            ExportTutorMoves(SaveFileDialog.FileName)

        End If
    End Sub
End Class