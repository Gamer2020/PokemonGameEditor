Imports VB = Microsoft.VisualBasic
Public Class PokedexListEditor
    Private Sub PokedexListEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LoopVar As Integer

        If header2 = "BPE" Or header2 = "BPR" Or header2 = "BPG" Then


            If header2 <> "BPE" Then
                GroupBox4.Enabled = True
            Else
                GroupBox4.Enabled = False
            End If

            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


                LoopVar = LoopVar + 1

                ComboBox1.Items.Add(GetPokemonName(LoopVar))
                ComboBox2.Items.Add(GetPokemonName(LoopVar))
                ComboBox3.Items.Add(GetPokemonName(LoopVar))
                ComboBox4.Items.Add(GetPokemonName(LoopVar))

            End While


            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            ListBox4.Items.Clear()

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


                ListBox1.Items.Add(GetPokemonName(PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexAlphabetTable", "")), System.Globalization.NumberStyles.HexNumber) + (LoopVar * 2), 2))), System.Globalization.NumberStyles.HexNumber))))

                If header2 <> "BPE" Then
                    ListBox4.Items.Add(GetPokemonName((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexTypeTable", "")), System.Globalization.NumberStyles.HexNumber) + (LoopVar * 2), 2))), System.Globalization.NumberStyles.HexNumber))))

                End If

                LoopVar = LoopVar + 1

            End While

            LoopVar = 0

            While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1

                ListBox2.Items.Add(GetPokemonName(PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexLightestTable", "")), System.Globalization.NumberStyles.HexNumber) + (LoopVar * 2), 2))), System.Globalization.NumberStyles.HexNumber))))
                ListBox3.Items.Add(GetPokemonName(PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexSmallestTable", "")), System.Globalization.NumberStyles.HexNumber) + (LoopVar * 2), 2))), System.Globalization.NumberStyles.HexNumber))))


                LoopVar = LoopVar + 1
            End While

            ListBox1.SelectedIndex = 0
            ListBox2.SelectedIndex = 0
            ListBox3.SelectedIndex = 0

            If header2 <> "BPE" Then
                ListBox4.SelectedIndex = 0
            End If

        Else

            MsgBox("Not supported!")

            Me.Close()
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        ComboBox1.SelectedIndex = (PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexAlphabetTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber))) - 1


    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ComboBox2.SelectedIndex = ((PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexLightestTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)))) - 1
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        ComboBox3.SelectedIndex = ((PokedexNumbertoSpecies(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexSmallestTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox3.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)))) - 1
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        ComboBox4.SelectedIndex = (((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexTypeTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber)))) - 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexAlphabetTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox1.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(SpeciestoDexNum(ComboBox1.SelectedIndex + 1)), 4)))

        Dim refreshvar As Integer
        Dim refreshvar2 As Integer

        refreshvar = ListBox1.SelectedIndex
        refreshvar2 = ComboBox1.SelectedIndex

        If ListBox1.SelectedIndex = 0 Then
            ListBox1.SelectedIndex = ListBox1.SelectedIndex + 1
        Else
            ListBox1.SelectedIndex = ListBox1.SelectedIndex - 1
        End If

        ListBox1.Items.Insert(refreshvar, GetPokemonName(refreshvar2 + 1))

        ListBox1.Items.RemoveAt(refreshvar + 1)

        ListBox1.SelectedIndex = refreshvar

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexLightestTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(SpeciestoDexNum(ComboBox2.SelectedIndex + 1)), 4)))

        Dim refreshvar As Integer
        Dim refreshvar2 As Integer

        refreshvar = ListBox2.SelectedIndex
        refreshvar2 = ComboBox2.SelectedIndex

        If ListBox2.SelectedIndex = 0 Then
            ListBox2.SelectedIndex = ListBox2.SelectedIndex + 1
        Else
            ListBox2.SelectedIndex = ListBox2.SelectedIndex - 1
        End If

        ListBox2.Items.Insert(refreshvar, GetPokemonName(refreshvar2 + 1))

        ListBox2.Items.RemoveAt(refreshvar + 1)

        ListBox2.SelectedIndex = refreshvar

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexSmallestTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox3.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(SpeciestoDexNum(ComboBox3.SelectedIndex + 1)), 4)))

        Dim refreshvar As Integer
        Dim refreshvar2 As Integer

        refreshvar = ListBox3.SelectedIndex
        refreshvar2 = ComboBox3.SelectedIndex

        If ListBox3.SelectedIndex = 0 Then
            ListBox3.SelectedIndex = ListBox3.SelectedIndex + 1
        Else
            ListBox3.SelectedIndex = ListBox3.SelectedIndex - 1
        End If

        ListBox3.Items.Insert(refreshvar, GetPokemonName(refreshvar2 + 1))

        ListBox3.Items.RemoveAt(refreshvar + 1)

        ListBox3.SelectedIndex = refreshvar

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexTypeTable", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex((ComboBox4.SelectedIndex + 1)), 4)))

        Dim refreshvar As Integer
        Dim refreshvar2 As Integer

        refreshvar = ListBox4.SelectedIndex
        refreshvar2 = ComboBox4.SelectedIndex

        If ListBox4.SelectedIndex = 0 Then
            ListBox4.SelectedIndex = ListBox4.SelectedIndex + 1
        Else
            ListBox4.SelectedIndex = ListBox4.SelectedIndex - 1
        End If

        ListBox4.Items.Insert(refreshvar, GetPokemonName(refreshvar2 + 1))

        ListBox4.Items.RemoveAt(refreshvar + 1)

        ListBox4.SelectedIndex = refreshvar

    End Sub
End Class