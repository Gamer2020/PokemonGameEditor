Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class ItemEditor

    Dim ItemBaseOff As Integer
    Dim ItemPicDataOff As Integer
    Dim CurrentItemDescripLength As Integer

    Public Shared itemDescs As List(Of String)
    Public Shared itemDescOffsets As List(Of String)
    Public Shared itemPics As List(Of String)
    Public Shared itemPicOffsets As List(Of String)
    Public Shared itemPals As List(Of String)
    Public Shared itemPalOffsets As List(Of String)

    Private Sub ItemEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Enabled = True
            ItmPlPntrTextBox.Enabled = True
            ItmRpntBttn.Enabled = True

            ItemPicDataOff = Int32.Parse(GetString(GetINIFileLocation(), header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber)

        Else

            ItmImgPntrTextBox.Enabled = False
            ItmPlPntrTextBox.Enabled = False
            ItmRpntBttn.Enabled = False

        End If

        ItemBaseOff = Int32.Parse((GetString(GetINIFileLocation(), header, "ItemData", "")), System.Globalization.NumberStyles.HexNumber)


        Dim LoopVar As Integer

        LoopVar = 0

        ItemListComboBox.Items.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True
            ItemListComboBox.Items.Add(GetItemName(LoopVar))
            ComboBox1.Items.Add(GetItemName(LoopVar))
            ComboBox2.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        ItemListComboBox.SelectedIndex = 0
        ComboBox1.SelectedIndex = 1
        ComboBox2.SelectedIndex = Int32.Parse(GetString(GetINIFileLocation(), header, "NumberOfItems", "")) - 1

        itemDescs = New List(Of String)
        itemDescOffsets = New List(Of String)
        itemPics = New List(Of String)
        itemPicOffsets = New List(Of String)
        itemPals = New List(Of String)
        itemPalOffsets = New List(Of String)

    End Sub

    Private Sub ItemListComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemListComboBox.SelectedIndexChanged

        ChangeNameTextBox.Text = GetItemName(ItemListComboBox.SelectedIndex)

        Dim ItemHex As String = ReadHEX(LoadedROM, ((ItemBaseOff) + 14) + (ItemListComboBox.SelectedIndex * 44), 30)

        IndexTextBox.Text = Int32.Parse((ReverseHEX(ItemHex.Substring(0, 4))), System.Globalization.NumberStyles.HexNumber)
        PriceTextBox.Text = Int32.Parse((ReverseHEX(ItemHex.Substring(4, 4))), System.Globalization.NumberStyles.HexNumber)
        HoldEffectTextBox.Text = Int32.Parse((((ItemHex.Substring(8, 2)))), System.Globalization.NumberStyles.HexNumber)
        ValueTextBox.Text = Int32.Parse((((ItemHex.Substring(10, 2)))), System.Globalization.NumberStyles.HexNumber)
        DescribPointTextBox.Text = Hex(Int32.Parse((ReverseHEX(ItemHex.Substring(12, 8))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        MysteryValue1TextBox.Text = Int32.Parse((((ItemHex.Substring(20, 2)))), System.Globalization.NumberStyles.HexNumber)
        MysteryValue2TextBox.Text = Int32.Parse((((ItemHex.Substring(22, 2)))), System.Globalization.NumberStyles.HexNumber)
        PocketComboBox.SelectedIndex = Int32.Parse((((ItemHex.Substring(24, 2)))), System.Globalization.NumberStyles.HexNumber)
        TypeTextBox.Text = Int32.Parse((((ItemHex.Substring(26, 2)))), System.Globalization.NumberStyles.HexNumber)

        FieldUsagePTTextBox.Text = Hex(Int32.Parse((ReverseHEX(ItemHex.Substring(28, 8))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BattleUsagePTTextBox.Text = Hex(Int32.Parse((ReverseHEX(ItemHex.Substring(44, 8))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BUTextBox.Text = Int32.Parse((((ItemHex.Substring(36, 2)))), System.Globalization.NumberStyles.HexNumber)

        ExtParTxt.Text = ReverseHEX(ItemHex.Substring(52, 8))

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim ItemDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, ItemDescp, Int32.Parse(((DescribPointTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        ItemDescp = Sapp2Asc(ItemDescp)
        ItemDescp = Mid$(ItemDescp, 1, InStr(1, ItemDescp, "\x"))
        ItemDescp = Replace(ItemDescp, "\n", vbCrLf)
        ItemDescp = Replace(RTrim$(ItemDescp), "\", "")

        CurrentItemDescripLength = Len(ItemDescp)
        DsrptnTextBox.Text = ItemDescp

        FileClose(FileNum)

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            ItmPlPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8) + 4, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            GetAndDrawItemPic(ItemImagePictureBox, ItemListComboBox.SelectedIndex)

        Else

        End If

    End Sub

    Private Sub SaveBttn_Click(sender As Object, e As EventArgs) Handles SaveBttn.Click

        Dim listvar As Integer = ItemListComboBox.SelectedIndex
        Dim LoopVar As Integer

        ChangeItemName(listvar, ChangeNameTextBox.Text)

        Dim ItemHex1 As String = ""
        Dim ItemHex2 As String = ""
        Dim ItemHex3 As String = ""

        ItemHex1 += ReverseHEX(VB.Right("0000" & Hex(IndexTextBox.Text), 4))
        ItemHex1 += ReverseHEX(VB.Right("0000" & Hex(PriceTextBox.Text), 4))
        ItemHex1 += VB.Right("00" & Hex(HoldEffectTextBox.Text), 2)
        ItemHex1 += VB.Right("00" & Hex(ValueTextBox.Text), 2)
        '4 Bytes Skipped Over - Desc Pointer
        ItemHex2 += VB.Right("00" & Hex(MysteryValue1TextBox.Text), 2)
        ItemHex2 += VB.Right("00" & Hex(MysteryValue2TextBox.Text), 2)
        ItemHex2 += VB.Right("00" & Hex(PocketComboBox.SelectedIndex), 2)
        ItemHex2 += VB.Right("00" & Hex(TypeTextBox.Text), 2)
        ItemHex2 += VB.Right("00000000" & ReverseHEX(Hex(Int32.Parse(((FieldUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)), 8)
        ItemHex2 += VB.Right("00" & Hex(BUTextBox.Text), 2)
        '3 Bytes Skipped Over
        ItemHex3 += VB.Right("00000000" & ReverseHEX(Hex(Int32.Parse(((BattleUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)), 8)
        ItemHex3 += VB.Right("00000000" & ReverseHEX(ExtParTxt.Text), 8)

        WriteHEX(LoadedROM, ((ItemBaseOff) + 14) + (listvar * 44), ItemHex1) '(ItemBaseOff) + 14---19
        '                                                                     (ItemBaseOff) + 20---23
        WriteHEX(LoadedROM, ((ItemBaseOff) + 24) + (listvar * 44), ItemHex2) '(ItemBaseOff) + 24---32
        '                                                                     (ItemBaseOff) + 33---35
        WriteHEX(LoadedROM, ((ItemBaseOff) + 36) + (listvar * 44), ItemHex3) '(ItemBaseOff) + 36---43

        'WriteHEX(LoadedROM, ((ItemBaseOff) + 14) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(IndexTextBox.Text), 4)))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 16) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(PriceTextBox.Text), 4)))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 18) + (listvar * 44), Hex(HoldEffectTextBox.Text))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 19) + (listvar * 44), Hex(ValueTextBox.Text))

        'WriteHEX(LoadedROM, ((ItemBaseOff) + 24) + (listvar * 44), Hex(MysteryValue1TextBox.Text))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 25) + (listvar * 44), Hex(MysteryValue2TextBox.Text))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 26) + (listvar * 44), Hex(PocketComboBox.SelectedIndex))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 27) + (listvar * 44), Hex(TypeTextBox.Text))

        'WriteHEX(LoadedROM, ((ItemBaseOff) + 28) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((FieldUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 36) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((BattleUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        'WriteHEX(LoadedROM, ((ItemBaseOff) + 32) + (listvar * 44), Hex(BUTextBox.Text))

        'WriteHEX(LoadedROM, ((ItemBaseOff) + 40) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(ExtParTxt.Text))

        'If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

        'Else

        'End If

        LoopVar = 0

        ItemListComboBox.Items.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True
            ItemListComboBox.Items.Add(GetItemName(LoopVar))
            ComboBox1.Items.Add(GetItemName(LoopVar))
            ComboBox2.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        ItemListComboBox.SelectedIndex = listvar

    End Sub

    Private Sub ItmRpntBttn_Click(sender As Object, e As EventArgs) Handles ItmRpntBttn.Click
        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            WriteHEX(LoadedROM, (ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8)), ReverseHEX(Hex(Int32.Parse(((ItmImgPntrTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            WriteHEX(LoadedROM, (ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8) + 4), ReverseHEX(Hex(Int32.Parse(((ItmPlPntrTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            GetAndDrawItemPic(ItemImagePictureBox, ItemListComboBox.SelectedIndex)

        Else

        End If
    End Sub

    Private Sub DscrpRpntBttn_Click(sender As Object, e As EventArgs) Handles DscrpRpntBttn.Click

        WriteHEX(LoadedROM, ((ItemBaseOff) + 20) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((DescribPointTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim ItemDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, ItemDescp, Int32.Parse(((DescribPointTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        ItemDescp = Sapp2Asc(ItemDescp)
        ItemDescp = Mid$(ItemDescp, 1, InStr(1, ItemDescp, "\x"))
        ItemDescp = Replace(ItemDescp, "\n", vbCrLf)
        ItemDescp = Replace(RTrim$(ItemDescp), "\", "")
        CurrentItemDescripLength = Len(DsrptnTextBox.Text)
        DsrptnTextBox.Text = ItemDescp


        FileClose(FileNum)
    End Sub

    Private Sub DsrptnTextBox_TextChanged(sender As Object, e As EventArgs) Handles DsrptnTextBox.TextChanged
        Label21.Text = "Length: " & Len(DsrptnTextBox.Text) & "/" & CurrentItemDescripLength
        Label21.ForeColor = Color.Black

        If Len(DsrptnTextBox.Text) > CurrentItemDescripLength Then
            Label21.Text = Label21.Text & " Requires repoint!"

            Label21.ForeColor = Color.Red

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim curdespoff As String

        Dim destowrite As String

        curdespoff = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 20) + (ItemListComboBox.SelectedIndex * 44), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        destowrite = Asc2Sapp(Replace(DsrptnTextBox.Text, vbCrLf, "\n") & "\x")



        If Len(DsrptnTextBox.Text) > CurrentItemDescripLength Then


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

                DescribPointTextBox.Text = Hex(newtextoff)

                DscrpRpntBttn.PerformClick()



                Label21.Text = "Length: " & Len(DsrptnTextBox.Text) & "/" & CurrentItemDescripLength
                Label21.ForeColor = Color.Black

                If Len(DsrptnTextBox.Text) > CurrentItemDescripLength Then
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

            DescribPointTextBox.Text = curdespoff

        End If
    End Sub

    Private Sub ExportAll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FolderBrowserDialog.Description = "Select folder to export Items to:"

        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            If ComboBox1.SelectedIndex > ComboBox2.SelectedIndex Then

                Dim tempBox1 As Integer = ComboBox1.SelectedIndex

                ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
                ComboBox2.SelectedIndex = tempBox1

            End If

            Me.Text = "Please wait..."
            Me.UseWaitCursor = True

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Items") = False Then
                System.IO.Directory.CreateDirectory(FolderBrowserDialog.SelectedPath & "\Items")
            End If

            If System.IO.Directory.Exists(FolderBrowserDialog.SelectedPath & "\Items\ItemPics") = False Then
                System.IO.Directory.CreateDirectory(FolderBrowserDialog.SelectedPath & "\Items\ItemPics")
            End If

            Dim LoopVar As Integer

            LoopVar = ComboBox1.SelectedIndex - 1

            Me.Enabled = False
            ProgressBar1.Value = 0

            While LoopVar < ComboBox2.SelectedIndex = True
                '  PKMNaItemImportExportss.SelectedIndex = LoopVar

                LoopVar = LoopVar + 1



                ExportItemINI(FolderBrowserDialog.SelectedPath, LoopVar)

                ProgressBar1.Value = ((LoopVar - ComboBox1.SelectedIndex) / (ComboBox2.SelectedIndex - ComboBox1.SelectedIndex)) * 100
                ProgressBar1.Invalidate()
                ProgressBar1.Update()

            End While

            Me.Enabled = True
            Me.UseWaitCursor = False
            ProgressBar1.Value = 0
            Me.BringToFront()
        End If
    End Sub

    Private Sub ImportAll(sender As Object, e As EventArgs) Handles Button2.Click
        Dim listvar As Integer = ItemListComboBox.SelectedIndex

        FolderBrowserDialog.Description = "Select ini file to import Items from:"
        If FolderBrowserDialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            If ComboBox1.SelectedIndex > ComboBox2.SelectedIndex Then

                Dim tempBox1 As Integer = ComboBox1.SelectedIndex

                ComboBox1.SelectedIndex = ComboBox2.SelectedIndex
                ComboBox2.SelectedIndex = tempBox1

            End If

            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ProgressBar1.Value = 0

            Dim LoopVar As Integer

            LoopVar = ComboBox1.SelectedIndex - 1

            Me.Enabled = False

            While LoopVar < ComboBox2.SelectedIndex = True

                'While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) - 2 = True

                LoopVar = LoopVar + 1

                If LoopVar = 377 Then

                    LoopVar = 378

                    If LoopVar < ComboBox2.SelectedIndex Then
                        Exit While
                    End If

                End If

                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & LoopVar & ".ini") Then
                    ImportItem(FolderBrowserDialog.SelectedPath, LoopVar)
                ElseIf System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\" & VB.Right("000" & LoopVar, 3) & ".ini") And LoopVar < 1000 Then
                    ImportItem(FolderBrowserDialog.SelectedPath, LoopVar)
                End If

                If System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\ItemPics\" & LoopVar & ".png") Then
                    ImportItemPicture(FolderBrowserDialog.SelectedPath & "\ItemPics\" & LoopVar & ".png", LoopVar)
                ElseIf System.IO.File.Exists(FolderBrowserDialog.SelectedPath & "\ItemPics\" & VB.Right("000" & LoopVar, 3) & ".png") And LoopVar < 1000 Then
                    ImportItemPicture(FolderBrowserDialog.SelectedPath & "\ItemPics\" & VB.Right("000" & LoopVar, 3) & ".png", LoopVar)
                End If

                ProgressBar1.Value = ((LoopVar - ComboBox1.SelectedIndex) / (ComboBox2.SelectedIndex - ComboBox1.SelectedIndex)) * 100
                ProgressBar1.Invalidate()
                ProgressBar1.Update()

                'If CheckBox1.Checked And LoopVar = 346 Then
                'LoopVar = 377
                'End If

            End While

            'ItemImportExports.WriteNewFile(Convert.ToString(ItemImportExports.romString))

            ItemListComboBox.SelectedIndex = 1
            ItemListComboBox.SelectedIndex = 0
            Me.UseWaitCursor = False
            ProgressBar1.Value = 0
            Me.BringToFront()

            RefreshItems(listvar)

        End If

        Me.Text = "Item Editor"
        Me.Enabled = True
        Me.BringToFront()
    End Sub

    Private Sub ExportSingleItem(sender As Object, e As EventArgs) Handles Button4.Click
        Dim listvar As Integer = ItemListComboBox.SelectedIndex
        SaveFileDialog.FileName = (listvar) & ".ini"
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

        SaveFileDialog.ValidateNames = True


        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ExportItemINI(SaveFileDialog.FileName, listvar, True)
            Me.UseWaitCursor = False
            Me.Enabled = True
        End If

        RefreshItems(listvar)
    End Sub

    Private Sub RefreshItems(listvar)
        Dim LoopVar As Integer = 0

        ItemListComboBox.Items.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "") - 1) = True
            ItemListComboBox.Items.Add(GetItemName(LoopVar))
            ComboBox1.Items.Add(GetItemName(LoopVar))
            ComboBox2.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        ItemListComboBox.SelectedIndex = listvar
    End Sub

    Private Sub ExportSinglePicture(sender As Object, e As EventArgs) Handles Button7.Click
        Dim listvar As Integer = ItemListComboBox.SelectedIndex
        SaveFileDialog.FileName = (listvar) & ".png"
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
            "(*.png)|*.png*"

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

        SaveFileDialog.ValidateNames = True


        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ExportItemPicture(SaveFileDialog.FileName, listvar)
            Me.UseWaitCursor = False
            Me.Enabled = True
        End If

        RefreshItems(listvar)
    End Sub

    Private Sub ImportSinglePicture(sender As Object, e As EventArgs) Handles Button5.Click
        Dim listvar As Integer = ItemListComboBox.SelectedIndex
        OpenFileDialog.Title = "Select Image to import"

        ' Only accept valid Win32 file names?
        OpenFileDialog.ValidateNames = False
        If Not OpenFileDialog.FileName.Contains(".png") Then
            OpenFileDialog.FileName = OpenFileDialog.FileName & ".png"
        End If


        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ImportItemPicture(OpenFileDialog.FileName, listvar, True)
            Me.UseWaitCursor = False
            Me.Enabled = True
        End If

        RefreshItems(listvar)
    End Sub

    Private Sub ImportSingleItem(sender As Object, e As EventArgs) Handles Button3.Click
        Dim listvar As Integer = ItemListComboBox.SelectedIndex
        OpenFileDialog.Title = "Select Item to import"

        ' Only accept valid Win32 file names?
        OpenFileDialog.ValidateNames = True


        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Text = "Please wait..."
            Me.UseWaitCursor = True
            ImportItem(OpenFileDialog.FileName, listvar, True)
            Me.UseWaitCursor = False
            Me.Enabled = True
        End If

        RefreshItems(listvar)
    End Sub

End Class