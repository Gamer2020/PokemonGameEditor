Imports VB = Microsoft.VisualBasic

Public Class PokedexOrderEditor
    Dim Offset1 As Integer
    Dim Offset2 As Integer
    Dim Offset3 As Integer
    Private Sub PokedexOrderEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Offset1 = Int32.Parse((GetString(GetINIFileLocation(), header, "NationalDexTable", "")), System.Globalization.NumberStyles.HexNumber)

        Offset2 = Int32.Parse((GetString(GetINIFileLocation(), header, "SecondDexTable", "")), System.Globalization.NumberStyles.HexNumber)

        If header2 = "BPE" Then

            Offset3 = Int32.Parse((GetString(GetINIFileLocation(), header, "HoenntoNationalDex", "")), System.Globalization.NumberStyles.HexNumber)

        End If

        Dim LoopVar As Integer

        ListBox1.Items.Clear()

        LoopVar = 0

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            ListBox1.Items.Add(GetPokemonName(LoopVar))

        End While

        If header2 = "BPE" Then
            GroupBox4.Enabled = True
        Else
            GroupBox4.Enabled = False
        End If

        ListBox1.SelectedIndex = 0

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        i = ListBox1.SelectedIndex

        'makes i be the list index so that the location of the pokemon's dex number can be calculated

        ListBox2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Offset1 + (i * 2), 2))), System.Globalization.NumberStyles.HexNumber)
        'loads the pokemon's dex number into the listbox
        ListBox3.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Offset2 + (i * 2), 2))), System.Globalization.NumberStyles.HexNumber)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        i = ListBox1.SelectedIndex
        'makes i be the list index so that the location of the pokemon's dex number can be calculated
        WriteHEX(LoadedROM, Offset1 + (i * 2), ReverseHEX(VB.Right("0000" & Hex(ListBox2.SelectedIndex), 4)))
        WriteHEX(LoadedROM, Offset2 + (i * 2), ReverseHEX(VB.Right("0000" & Hex(ListBox3.SelectedIndex), 4)))
        If header2 = "BPE" And ListBox3.SelectedIndex < (GetString(GetINIFileLocation(), header, "NumberOfRegionDex", "") + 1) Then
            WriteHEX(LoadedROM, Offset3 + ((ListBox3.SelectedIndex - 1) * 2), ReverseHEX(VB.Right("0000" & Hex(ListBox4.SelectedIndex), 4)))
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged

        If header2 = "BPE" And ListBox3.SelectedIndex < (GetString(GetINIFileLocation(), header, "NumberOfRegionDex", "") + 1) Then

            ListBox4.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Offset3 + ((ListBox3.SelectedIndex - 1) * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            GroupBox4.Enabled = True

        Else
            GroupBox4.Enabled = False
        End If

    End Sub
End Class