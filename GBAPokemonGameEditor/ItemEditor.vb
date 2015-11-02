Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class ItemEditor

    Dim ItemBaseOff As Integer
    Dim ItemPicOff As Integer
    Dim ItemPalOff As Integer

    Private Sub ItemEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Enabled = True
            ItmPlPntrTextBox.Enabled = True
            ItmRpntBttn.Enabled = True

            ItemPicOff = Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber)
            ItemPalOff = Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "ItemIMGData", ""), System.Globalization.NumberStyles.HexNumber)

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

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            ItmImgPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPicOff + (ItemListComboBox.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            ItmPlPntrTextBox.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ItemPalOff + (ItemListComboBox.SelectedIndex * 8) + 4, 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

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

            '           MsgBox(ReverseHEX(Hex(Int32.Parse(((ItmImgPntrTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            '          WriteHEX(LoadedROM, (ItemPicOff), ReverseHEX(Hex(Int32.Parse(((ItmImgPntrTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
            '          WriteHEX(LoadedROM, (ItemPalOff), ReverseHEX(Hex(Int32.Parse(((ItmPlPntrTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

            GetAndDrawItemPic(ItemImagePictureBox, ItemListComboBox.SelectedIndex)

        Else

        End If
    End Sub
End Class