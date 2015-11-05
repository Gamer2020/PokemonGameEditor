Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class ItemEditor

    Dim ItemBaseOff As Integer
    Dim ItemPicDataOff As Integer

    Private Sub ItemEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Enabled = True
            ItmPlPntrTextBox.Enabled = True
            ItmRpntBttn.Enabled = True

            ItemPicDataOff = Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber)

        Else

            ItmImgPntrTextBox.Enabled = False
            ItmPlPntrTextBox.Enabled = False
            ItmRpntBttn.Enabled = False

        End If

        ItemBaseOff = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "ItemData", "")), System.Globalization.NumberStyles.HexNumber)


        Dim LoopVar As Integer

        LoopVar = 0

        ItemListComboBox.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfItems", "")) = True
            ItemListComboBox.Items.Add(GetItemName(LoopVar))

            LoopVar = LoopVar + 1

        End While

        ItemListComboBox.SelectedIndex = 0

    End Sub

    Private Sub ItemListComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemListComboBox.SelectedIndexChanged

        ChangeNameTextBox.Text = GetItemName(ItemListComboBox.SelectedIndex)

        IndexTextBox.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 14) + (ItemListComboBox.SelectedIndex * 44), 2))), System.Globalization.NumberStyles.HexNumber)
        PriceTextBox.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 16) + (ItemListComboBox.SelectedIndex * 44), 2))), System.Globalization.NumberStyles.HexNumber)
        HoldEffectTextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 18) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)
        ValueTextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 19) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)
        DescribPointTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 20) + (ItemListComboBox.SelectedIndex * 44), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        MysteryValue1TextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 24) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)
        MysteryValue2TextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 25) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)
        PocketComboBox.SelectedIndex = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 26) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)
        TypeTextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 27) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)

        FieldUsagePTTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 28) + (ItemListComboBox.SelectedIndex * 44), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BattleUsagePTTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 36) + (ItemListComboBox.SelectedIndex * 44), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        BUTextBox.Text = Int32.Parse((((ReadHEX(LoadedROM, ((ItemBaseOff) + 32) + (ItemListComboBox.SelectedIndex * 44), 1)))), System.Globalization.NumberStyles.HexNumber)


        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim ItemDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, ItemDescp, Int32.Parse(((DescribPointTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + 1, True)
        ItemDescp = Sapp2Asc(ItemDescp)
        ItemDescp = Mid$(ItemDescp, 1, InStr(1, ItemDescp, "\x"))
        ItemDescp = Replace(ItemDescp, "\n", vbCrLf)
        ItemDescp = Replace(RTrim$(ItemDescp), "\", "")
        DsrptnTextBox.Text = ItemDescp
        DsrptnTextBox.MaxLength = Len(ItemDescp)

        FileClose(FileNum)

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            ItmPlPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPicDataOff + (ItemListComboBox.SelectedIndex * 8) + 4, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

            GetAndDrawItemPic(ItemImagePictureBox, ItemListComboBox.SelectedIndex)

        Else

        End If

    End Sub

    Private Sub SaveBttn_Click(sender As Object, e As EventArgs) Handles SaveBttn.Click

        Dim listvar As Integer

        Dim LoopVar As Integer

        listvar = ItemListComboBox.SelectedIndex

        ChangeItemName(listvar, ChangeNameTextBox.Text)

        WriteHEX(LoadedROM, ((ItemBaseOff) + 14) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(IndexTextBox.Text), 4)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 16) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(PriceTextBox.Text), 4)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 18) + (listvar * 44), Hex(HoldEffectTextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 19) + (listvar * 44), Hex(ValueTextBox.Text))

        WriteHEX(LoadedROM, ((ItemBaseOff) + 24) + (listvar * 44), Hex(MysteryValue1TextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 25) + (listvar * 44), Hex(MysteryValue1TextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 26) + (listvar * 44), Hex(PocketComboBox.SelectedIndex))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 27) + (listvar * 44), Hex(TypeTextBox.Text))

        WriteHEX(LoadedROM, ((ItemBaseOff) + 28) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((FieldUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 36) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((BattleUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 32) + (listvar * 44), Hex(BUTextBox.Text))

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

        Else

        End If

        LoopVar = 0

        ItemListComboBox.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfItems", "")) = True
            ItemListComboBox.Items.Add(GetItemName(LoopVar))

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
        DsrptnTextBox.Text = ItemDescp
        DsrptnTextBox.MaxLength = Len(ItemDescp)

        FileClose(FileNum)
    End Sub
End Class