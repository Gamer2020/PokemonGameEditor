Imports VB = Microsoft.VisualBasic

Public Class BattleFrontierEditor

    Private Sub BattleFrontierEditor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub

    Private Sub BattleFrontierEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If header2 = "BPE" Then

            ComboBox9.Items.Clear()

            ComboBox9.Items.AddRange(IO.File.ReadAllLines(AppPath & "PGENatures.txt"))

            bfload()

        Else
            MsgBox("This ROM is not supported!!!")
            End
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        TextBox1.Text = GetBattleFrontierTrainerName(ListBox1.SelectedIndex)
        TextBox3.Text = Hex("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + (52 * ListBox1.SelectedIndex), 4))))
        TextBox2.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox3.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox2.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox3.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox2.Text, System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox3.SelectedIndex = 0

    End Sub
    Private Sub bfload()

        Dim LoopVar As Integer

        LoopVar = 0

        ListBox1.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfBattleFrontierTrainers", "")) = True


            ListBox1.Items.Add(GetBattleFrontierTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        'LoopVar = 0

        'ComboBox1.Items.Clear()

        '     While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfTrainerClasses", "")) + 1 = True


        '            ComboBox1.Items.Add(GetTrainerClass(LoopVar))
        '           LoopVar = LoopVar + 1
        '      End While



        LoopVar = 0

        ListBox2.Items.Clear()
        ComboBox8.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfBattleFrontierPokemon", "")) = True

            ListBox2.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox8.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            LoopVar = LoopVar + 1
        End While

        LoopVar = 0

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            ComboBox2.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 1

        ComboBox4.Items.Clear()
        ComboBox5.Items.Clear()
        ComboBox6.Items.Clear()
        ComboBox7.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox4.Items.Add(GetAttackName(LoopVar))
            ComboBox5.Items.Add(GetAttackName(LoopVar))
            ComboBox6.Items.Add(GetAttackName(LoopVar))
            ComboBox7.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        ComboBox3.Items.Clear()


        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfBattlefrontierHeldItems", "")) + 1 = True


            ComboBox3.Items.Add(GetItemName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierHeldItems", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 2)), 2))), System.Globalization.NumberStyles.HexNumber)))



            LoopVar = LoopVar + 1

        End While
        ListBox1.SelectedIndex = 0
        ListBox2.SelectedIndex = 0
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        'species
        ComboBox2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16)), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'attacks
        ComboBox4.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 2), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox5.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 4), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox6.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 6), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox7.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 8), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'items
        ComboBox3.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 10), 1))), System.Globalization.NumberStyles.HexNumber)

        'Nature
        ComboBox9.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 12), 1))), System.Globalization.NumberStyles.HexNumber)

        'EVs
        Dim EVSpreadIntVar As Integer
        Dim EVSpreadVar As String
        Dim hpbit As String
        Dim attackbit As String
        Dim defensebit As String
        Dim speedbit As String
        Dim specialattackbit As String
        Dim specialdefensebit As String

        EVSpreadIntVar = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox2.SelectedIndex * 16) + 11), 1)))), System.Globalization.NumberStyles.HexNumber)

        EVSpreadVar = Convert.ToString(EVSpreadIntVar, 2)

        While Len(EVSpreadVar) < 8

            EVSpreadVar = "0" & EVSpreadVar

        End While

        hpbit = Mid(EVSpreadVar, 8, 1)
        attackbit = Mid(EVSpreadVar, 7, 1)
        defensebit = Mid(EVSpreadVar, 6, 1)
        speedbit = Mid(EVSpreadVar, 5, 1)
        specialattackbit = Mid(EVSpreadVar, 4, 1)
        specialdefensebit = Mid(EVSpreadVar, 3, 1)

        If hpbit = "0" Then
            CheckedListBox1.SetItemCheckState("0", CheckState.Unchecked)
        ElseIf hpbit = "1"
            CheckedListBox1.SetItemCheckState("0", CheckState.Checked)
        End If

        If attackbit = "0" Then
            CheckedListBox1.SetItemCheckState("1", CheckState.Unchecked)
        ElseIf attackbit = "1"
            CheckedListBox1.SetItemCheckState("1", CheckState.Checked)
        End If

        If defensebit = "0" Then
            CheckedListBox1.SetItemCheckState("2", CheckState.Unchecked)
        ElseIf defensebit = "1"
            CheckedListBox1.SetItemCheckState("2", CheckState.Checked)
        End If

        If speedbit = "0" Then
            CheckedListBox1.SetItemCheckState("3", CheckState.Unchecked)
        ElseIf speedbit = "1"
            CheckedListBox1.SetItemCheckState("3", CheckState.Checked)
        End If

        If specialattackbit = "0" Then
            CheckedListBox1.SetItemCheckState("4", CheckState.Unchecked)
        ElseIf specialattackbit = "1"
            CheckedListBox1.SetItemCheckState("4", CheckState.Checked)
        End If

        If specialdefensebit = "0" Then
            CheckedListBox1.SetItemCheckState("5", CheckState.Unchecked)
        ElseIf specialdefensebit = "1"
            CheckedListBox1.SetItemCheckState("5", CheckState.Checked)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim indexsave As Integer
        indexsave = ListBox1.SelectedIndex
        ChangeBattleFrontierTrainerName(ListBox1.SelectedIndex, TextBox1.Text)
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * indexsave)), ReverseHEX(Hex((Int32.Parse((TextBox3.Text), System.Globalization.NumberStyles.HexNumber)))))
        Dim LoopVar As Integer

        LoopVar = 0

        ListBox1.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfBattleFrontierTrainers", "")) = True


            ListBox1.Items.Add(GetBattleFrontierTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        ListBox1.SelectedIndex = -0
        ListBox1.SelectedIndex = indexsave
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), ReverseHEX(Hex((Int32.Parse((TextBox2.Text), System.Globalization.NumberStyles.HexNumber)) + &H8000000)))

        TextBox2.Text = Hex(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))), System.Globalization.NumberStyles.HexNumber))) - &H8000000)

        ListBox3.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox2.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox3.Items.Add((Val("&H" & curbytes)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox2.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox3.SelectedIndex = 0
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ListBox2.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox3.SelectedIndex * 2), 2))))
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox1, ComboBox2.SelectedIndex + 1)
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox2, (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox3.SelectedIndex * 2), 2))))) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
        ComboBox8.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox3.SelectedIndex * 2), 2))))
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim indexmemory As Integer

        indexmemory = ListBox3.SelectedIndex

        WriteHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox3.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox8.SelectedIndex), 4)))
        TextBox2.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)
        ListBox3.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox2.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox3.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox2.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox3.SelectedIndex = indexmemory

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim indexmemory As Integer
        Dim indexmemory2 As Integer
        Dim indexmemory3 As Integer
        Dim loopvar As Integer

        indexmemory = ListBox2.SelectedIndex
        indexmemory2 = ComboBox8.SelectedIndex
        indexmemory3 = ListBox3.SelectedIndex

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16)), ReverseHEX(VB.Right("0000" & Hex(ComboBox2.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 10), Hex(ComboBox3.SelectedIndex))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox4.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 4), ReverseHEX(VB.Right("0000" & Hex(ComboBox5.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 6), ReverseHEX(VB.Right("0000" & Hex(ComboBox6.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 8), ReverseHEX(VB.Right("0000" & Hex(ComboBox7.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox2.SelectedIndex * 16) + 12), Hex(ComboBox9.SelectedIndex))

        Dim hpbit As String
        Dim attackbit As String
        Dim defensebit As String
        Dim speedbit As String
        Dim specialattackbit As String
        Dim specialdefensebit As String
        Dim evspreadwritevar As String

        If CheckedListBox1.GetItemCheckState(0) = CheckState.Unchecked Then

            hpbit = 0

        ElseIf CheckedListBox1.GetItemCheckState(0) = CheckState.Checked Then

            hpbit = 1

        End If

        If CheckedListBox1.GetItemCheckState(1) = CheckState.Unchecked Then

            attackbit = 0

        ElseIf CheckedListBox1.GetItemCheckState(1) = CheckState.Checked Then

            attackbit = 1

        End If

        If CheckedListBox1.GetItemCheckState(2) = CheckState.Unchecked Then

            defensebit = 0

        ElseIf CheckedListBox1.GetItemCheckState(2) = CheckState.Checked Then

            defensebit = 1

        End If

        If CheckedListBox1.GetItemCheckState(3) = CheckState.Unchecked Then

            speedbit = 0

        ElseIf CheckedListBox1.GetItemCheckState(3) = CheckState.Checked Then

            speedbit = 1

        End If

        If CheckedListBox1.GetItemCheckState(4) = CheckState.Unchecked Then

            specialattackbit = 0

        ElseIf CheckedListBox1.GetItemCheckState(4) = CheckState.Checked Then

            specialattackbit = 1

        End If

        If CheckedListBox1.GetItemCheckState(5) = CheckState.Unchecked Then

            specialdefensebit = 0

        ElseIf CheckedListBox1.GetItemCheckState(5) = CheckState.Checked Then

            specialdefensebit = 1

        End If

        evspreadwritevar = specialdefensebit & specialattackbit & speedbit & defensebit & attackbit & hpbit

        evspreadwritevar = Convert.ToInt32(evspreadwritevar, 2)

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox2.SelectedIndex * 16) + 11), Hex(evspreadwritevar))

        'Everything past here loads stuff
        loopvar = 0

        ListBox2.Items.Clear()
        ComboBox8.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfBattleFrontierPokemon", "")) = True

            ListBox2.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox8.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            loopvar = LoopVar + 1
        End While

        TextBox2.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox1.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox3.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox2.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox3.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "BattleFrontierPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox2.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox2.SelectedIndex = indexmemory
        ComboBox8.SelectedIndex = indexmemory2
        ListBox3.SelectedIndex = indexmemory3
    End Sub
End Class