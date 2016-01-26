Imports VB = Microsoft.VisualBasic

Public Class EggMoveEditor
    Private Sub EggMoveEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim Looper As Integer
        Dim CurEntry As Integer

        ListBox1.Items.Clear()

        Looper = 0

        While ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "EggMoveTable", "")), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

            CurEntry = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            If CurEntry > 20000 Then

                ListBox1.Items.Add(GetPokemonName(CurEntry - 20000))

            Else

                ListBox1.Items.Add("     " & GetAttackName(CurEntry))

            End If
            Looper = Looper + 1
        End While


        Looper = 0

        ComboBox1.Items.Clear()

        While Looper < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            Looper = Looper + 1

            ComboBox1.Items.Add(GetPokemonName(Looper))

        End While


        Looper = 0

        ComboBox2.Items.Clear()

        While Looper < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox2.Items.Add(GetAttackName(Looper))


            Looper = Looper + 1

        End While
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ListBox1.SelectedIndex = 0

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(FrntPic, ComboBox1.SelectedIndex + 1)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim CurEntry As Integer

        CurEntry = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)

        If CurEntry > 20000 Then

            ComboBox1.SelectedIndex = ((CurEntry - 20000) - 1)

        Else

            ComboBox2.SelectedIndex = CurEntry

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim IndexBuff As Integer = ListBox1.SelectedIndex

        Dim Looper As Integer
        Dim CurEntry As Integer

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox1.SelectedIndex + 20001), 4)))

        ListBox1.Items.Clear()

        Looper = 0

        While ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "EggMoveTable", "")), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

            CurEntry = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            If CurEntry > 20000 Then

                ListBox1.Items.Add(GetPokemonName(CurEntry - 20000))

            Else

                ListBox1.Items.Add("     " & GetAttackName(CurEntry))

            End If
            Looper = Looper + 1
        End While

        ListBox1.SelectedIndex = IndexBuff

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim IndexBuff As Integer = ListBox1.SelectedIndex

        Dim Looper As Integer
        Dim CurEntry As Integer

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox2.SelectedIndex), 4)))

        ListBox1.Items.Clear()

        Looper = 0

        While ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "EggMoveTable", "")), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2) = "FFFF" = False

            CurEntry = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

            If CurEntry > 20000 Then

                ListBox1.Items.Add(GetPokemonName(CurEntry - 20000))

            Else

                ListBox1.Items.Add("     " & GetAttackName(CurEntry))

            End If
            Looper = Looper + 1
        End While

        ListBox1.SelectedIndex = IndexBuff
    End Sub
End Class