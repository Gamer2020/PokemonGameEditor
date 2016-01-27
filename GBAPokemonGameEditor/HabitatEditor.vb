Imports VB = Microsoft.VisualBasic

Public Class HabitatEditor
    Private Sub HabitatEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If header2 = "BPR" Or header2 = "BPG" Then

            Dim Looper As Integer

            ListBox1.Items.Clear()

            ListBox1.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGEHabitats.txt"))


            Looper = 0

            ComboBox1.Items.Clear()

            While Looper < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


                Looper = Looper + 1

                ComboBox1.Items.Add(GetPokemonName(Looper))

            End While

            ListBox1.SelectedIndex = 0

        Else
            MsgBox("ROM not supported!")
            End
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim Looper As Integer

        TextBox2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        TextBox1.Text = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber))

        ListBox2.Items.Clear()

        Looper = 0

        While Looper < TextBox1.Text

            ListBox2.Items.Add("Page " & (Looper + 1))

            Looper = Looper + 1
        End While

        ListBox2.SelectedIndex = 0

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim Looper As Integer

        Dim pagepointer As String

        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        TextBox3.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
        TextBox4.Text = (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber))

        ListBox3.Items.Clear()

        Looper = 0

        While Looper < TextBox4.Text

            ListBox3.Items.Add(GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((TextBox3.Text), System.Globalization.NumberStyles.HexNumber)) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            Looper = Looper + 1
        End While

        ListBox3.SelectedIndex = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Looper As Integer

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox1.SelectedIndex * 8), ReverseHEX(VB.Right("00000000" & Hex(TextBox1.Text), 8)))

        Looper = 0

        ListBox2.Items.Clear()

        While Looper < TextBox1.Text

            ListBox2.Items.Add("Page " & (Looper + 1))

            Looper = Looper + 1
        End While

        ListBox2.SelectedIndex = 0

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), ReverseHEX(Hex(Int32.Parse(((TextBox2.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        Dim indexbuff As Integer

        indexbuff = ListBox2.SelectedIndex

        ListBox2.SelectedIndex = -1

        ListBox2.SelectedIndex = indexbuff

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(FrntPic, ComboBox1.SelectedIndex + 1)
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Dim pagepointer As String
        Dim pokemonpointer As String


        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        ComboBox1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pokemonpointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox3.SelectedIndex * 2), 2))), System.Globalization.NumberStyles.HexNumber) - 1

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pagepointer As String
        Dim pokemonpointer As String

        Dim Looper As Integer

        Dim indexbuff As Integer = ListBox3.SelectedIndex


        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        WriteHEX(LoadedROM, (Int32.Parse((pokemonpointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox3.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox1.SelectedIndex + 1), 4)))

        ListBox3.Items.Clear()

        Looper = 0

        While Looper < (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber))

            ListBox3.Items.Add(GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pokemonpointer), System.Globalization.NumberStyles.HexNumber)) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            Looper = Looper + 1
        End While


        ListBox3.SelectedIndex = indexbuff

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pagepointer As String
        Dim pokemonpointer As String

        Dim Looper As Integer

        Dim indexbuff As Integer = ListBox3.SelectedIndex

        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        WriteHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), ReverseHEX(Hex(Int32.Parse(((TextBox3.Text)), System.Globalization.NumberStyles.HexNumber) + &H8000000)))

        ListBox3.Items.Clear()

        Looper = 0

        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


        While Looper < (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber))

            ListBox3.Items.Add(GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pokemonpointer), System.Globalization.NumberStyles.HexNumber)) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            Looper = Looper + 1
        End While


        ListBox3.SelectedIndex = indexbuff
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pagepointer As String
        Dim pokemonpointer As String

        Dim Looper As Integer

        Dim indexbuff As Integer = ListBox3.SelectedIndex

        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        WriteHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox2.SelectedIndex * 8), ReverseHEX(VB.Right("00000000" & Hex(TextBox4.Text), 8)))

        ListBox3.Items.Clear()

        Looper = 0

        pagepointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "HabitatTable", ""))), System.Globalization.NumberStyles.HexNumber)) + (ListBox1.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        pokemonpointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)


        While Looper < (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pagepointer), System.Globalization.NumberStyles.HexNumber)) + 4 + (ListBox2.SelectedIndex * 8), 4))), System.Globalization.NumberStyles.HexNumber))

            ListBox3.Items.Add(GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse((pokemonpointer), System.Globalization.NumberStyles.HexNumber)) + (Looper * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

            Looper = Looper + 1
        End While


        ListBox3.SelectedIndex = indexbuff
    End Sub
End Class