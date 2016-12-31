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

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True
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

        ExtParTxt.Text = ReverseHEX(ReadHEX(LoadedROM, ((ItemBaseOff) + 40) + (ItemListComboBox.SelectedIndex * 44), 4))

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

        Dim listvar As Integer

        Dim LoopVar As Integer

        listvar = ItemListComboBox.SelectedIndex

        ChangeItemName(listvar, ChangeNameTextBox.Text)

        WriteHEX(LoadedROM, ((ItemBaseOff) + 14) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(IndexTextBox.Text), 4)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 16) + (listvar * 44), ReverseHEX(VB.Right("0000" & Hex(PriceTextBox.Text), 4)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 18) + (listvar * 44), Hex(HoldEffectTextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 19) + (listvar * 44), Hex(ValueTextBox.Text))

        WriteHEX(LoadedROM, ((ItemBaseOff) + 24) + (listvar * 44), Hex(MysteryValue1TextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 25) + (listvar * 44), Hex(MysteryValue2TextBox.Text))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 26) + (listvar * 44), Hex(PocketComboBox.SelectedIndex))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 27) + (listvar * 44), Hex(TypeTextBox.Text))

        WriteHEX(LoadedROM, ((ItemBaseOff) + 28) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((FieldUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 36) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(Hex(Int32.Parse(((BattleUsagePTTextBox.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))
        WriteHEX(LoadedROM, ((ItemBaseOff) + 32) + (listvar * 44), Hex(BUTextBox.Text))

        WriteHEX(LoadedROM, ((ItemBaseOff) + 40) + (ItemListComboBox.SelectedIndex * 44), ReverseHEX(ExtParTxt.Text))

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

        Else

        End If

        LoopVar = 0

        ItemListComboBox.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True
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
End Class