Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic
Public Class TMHMEditor
    Dim TMHMAttacks As Integer
    Dim TMHMString As String
    Private Sub TMHMEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillTMHMData()

    End Sub

    Private Sub TMHMList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TMHMList.SelectedIndexChanged
        AttackList.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((TMHMList.SelectedIndex) * 2), 2))), System.Globalization.NumberStyles.HexNumber)
    End Sub

    Private Sub SvBttn_Click(sender As Object, e As EventArgs) Handles SvBttn.Click
        Dim indexbuf As Integer
        Dim loopvar As Integer

        indexbuf = TMHMList.SelectedIndex

        WriteHEX(LoadedROM, TMHMAttacks + ((indexbuf) * 2), ReverseHEX(VB.Right("0000" & Hex(AttackList.SelectedIndex), 4)))

        TMHMList.Items.Clear()

        loopvar = 0

        While loopvar < (Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", ""))) = True

            If loopvar > ((Val(GetString(GetINIFileLocation(), header, "TotalTMs", ""))) - 1) Then
                TMHMList.Items.Add("HM" & loopvar - 49 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                loopvar = loopvar + 1

            ElseIf loopvar < 9 Then

                TMHMList.Items.Add("TM" & "0" & loopvar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                loopvar = loopvar + 1
            Else

                TMHMList.Items.Add("TM" & loopvar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                loopvar = loopvar + 1
            End If
        End While


        TMHMList.SelectedIndex = indexbuf

    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SaveFileDialog.FileName = ("TMHMs") & ".ini"
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

            ExportTMHMINI(SaveFileDialog.FileName, TMHMString)

        End If
    End Sub

    Private Sub Import_Click(sender As Object, e As EventArgs) Handles Button2.Click

        OpenFileDialog.FileName = ""
        OpenFileDialog.CheckFileExists = True

        ' Check to ensure that the selected path exists.  Dialog box displays 
        ' a warning otherwise.
        OpenFileDialog.CheckPathExists = True

        ' Get or set default extension. Doesn't include the leading ".".
        OpenFileDialog.DefaultExt = "ini"

        ' Return the file referenced by a link? If False, simply returns the selected link
        ' file. If True, returns the file linked to the LNK file.
        OpenFileDialog.DereferenceLinks = True

        ' Just as in VB6, use a set of pairs of filters, separated with "|". Each 
        ' pair consists of a description|file spec. Use a "|" between pairs. No need to put a
        ' trailing "|". You can set the FilterIndex property as well, to select the default
        ' filter. The first filter is numbered 1 (not 0). The default is 1. 
        OpenFileDialog.Filter =
            "(*.ini)|*.ini*"

        OpenFileDialog.Multiselect = False

        ' Restore the original directory when done selecting
        ' a file? If False, the current directory changes
        ' to the directory in which you selected the file.
        ' Set this to True to put the current folder back
        ' where it was when you started.
        ' The default is False.
        '.RestoreDirectory = False

        ' Show the Help button and Read-Only checkbox?
        OpenFileDialog.ShowHelp = False
        OpenFileDialog.ShowReadOnly = False

        ' Start out with the read-only check box checked?
        ' This only make sense if ShowReadOnly is True.
        OpenFileDialog.ReadOnlyChecked = False

        OpenFileDialog.Title = "Select ini file to import"

        ' Only accept valid Win32 file names?
        OpenFileDialog.ValidateNames = True


        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            ImportTMHMINI(OpenFileDialog.FileName)

            FillTMHMData()

        End If
    End Sub

    Private Sub FillTMHMData()
        TMHMString = ""

        Dim LoopVar As Integer

        TMHMAttacks = Int32.Parse((GetString(GetINIFileLocation(), header, "TMData", "")), System.Globalization.NumberStyles.HexNumber)

        TMHMList.Items.Clear()


        LoopVar = 0

        While LoopVar < (Val(GetString(GetINIFileLocation(), header, "TotalTMsPlusHMs", ""))) = True

            If LoopVar > ((Val(GetString(GetINIFileLocation(), header, "TotalTMs", ""))) - 1) Then

                TMHMList.Items.Add("HM" & LoopVar - ((Val(GetString(GetINIFileLocation(), header, "TotalTMs", ""))) - 1) & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            ElseIf LoopVar < 9 Then

                TMHMList.Items.Add("TM" & "0" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            Else

                TMHMList.Items.Add("TM" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            End If

            TMHMString = TMHMString & ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2)
            LoopVar = LoopVar + 1
        End While


        AttackList.Items.Clear()

        LoopVar = 0

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            AttackList.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        TMHMList.SelectedIndex = 0
    End Sub

End Class