Imports VB = Microsoft.VisualBasic

Public Class TradeEditor
    Private Sub TradeEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim loopvar As Integer

        loopvar = 0

        ComboBox3.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfItems", "")) = True

            ComboBox3.Items.Add(GetItemName(loopvar))

            loopvar = loopvar + 1

        End While

        loopvar = 0

        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) = True

            ComboBox1.Items.Add(GetPokemonName(loopvar))
            ComboBox2.Items.Add(GetPokemonName(loopvar))

            loopvar = loopvar + 1

        End While

        ListBox1.Items.Clear()

        loopvar = 0

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfTrades", "0")) = True

            loopvar = loopvar + 1

            ListBox1.Items.Add("Trade " & loopvar)

        End While

        ListBox1.SelectedIndex = 0

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(PictureBox2, ComboBox2.SelectedIndex)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(PictureBox1, ComboBox1.SelectedIndex)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        ComboBox2.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (12), 2)), System.Globalization.NumberStyles.HexNumber)
        ComboBox1.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (56), 2)), System.Globalization.NumberStyles.HexNumber)

        TextBox1.Text = GetTradeNickName(ListBox1.SelectedIndex)
        TextBox2.Text = GetTradeOTName(ListBox1.SelectedIndex)

        ComboBox3.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (40), 2)), System.Globalization.NumberStyles.HexNumber)

        TextBox3.Text = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (24), 2)), System.Globalization.NumberStyles.HexNumber)

        NumericUpDown1.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (14), 1)), System.Globalization.NumberStyles.HexNumber)
        NumericUpDown2.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (15), 1)), System.Globalization.NumberStyles.HexNumber)
        NumericUpDown3.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (16), 1)), System.Globalization.NumberStyles.HexNumber)
        NumericUpDown4.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (17), 1)), System.Globalization.NumberStyles.HexNumber)
        NumericUpDown5.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (18), 1)), System.Globalization.NumberStyles.HexNumber)
        NumericUpDown6.Value = Int32.Parse((ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (19), 1)), System.Globalization.NumberStyles.HexNumber)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (12), ReverseHEX(VB.Right("0000" & Hex(ComboBox2.SelectedIndex), 4)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (56), ReverseHEX(VB.Right("0000" & Hex(ComboBox1.SelectedIndex), 4)))

        ChangeTradeNickName(ListBox1.SelectedIndex, TextBox1.Text)
        ChangeTradeOTName(ListBox1.SelectedIndex, TextBox2.Text)

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (40), ReverseHEX(VB.Right("0000" & Hex(ComboBox3.SelectedIndex), 4)))

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (24), ReverseHEX(VB.Right("0000" & Hex(TextBox3.Text), 4)))

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (14), (VB.Right("00" & Hex(NumericUpDown1.Value), 2)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (15), (VB.Right("00" & Hex(NumericUpDown2.Value), 2)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (16), (VB.Right("00" & Hex(NumericUpDown3.Value), 2)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (17), (VB.Right("00" & Hex(NumericUpDown4.Value), 2)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (18), (VB.Right("00" & Hex(NumericUpDown5.Value), 2)))
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "TradeData", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 60) + (19), (VB.Right("00" & Hex(NumericUpDown6.Value), 2)))


    End Sub
End Class