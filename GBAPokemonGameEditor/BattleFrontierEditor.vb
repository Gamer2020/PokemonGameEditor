Imports VB = Microsoft.VisualBasic

Public Class BattleFrontierEditor

    Private Sub BattleFrontierEditor_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MainFrm.Visible = True
    End Sub

    Private Sub BattleFrontierEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If header2 = "BPE" Then

            ComboBox9.Items.Clear()

            ComboBox9.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGENatures.txt"))


            ComboBox10.Items.Clear()

            ComboBox10.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGENatures.txt"))


            ComboBox19.Items.Clear()

            ComboBox19.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGENatures.txt"))


            ComboBox28.Items.Clear()

            ComboBox28.Items.AddRange(IO.File.ReadAllLines(AppPath & "txt\PGENatures.txt"))

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

        LoopVar = 0

        ListBox6.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfSlateportBattleTentTrainers", "")) = True


            ListBox6.Items.Add(GetSlateportBattleTentTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        ListBox9.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfVerdanturfBattleTentTrainers", "")) = True


            ListBox9.Items.Add(GetVerdanturfBattleTentTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        ListBox12.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfFallarborBattleTentTrainers", "")) = True


            ListBox12.Items.Add(GetFallarborBattleTentTrainerName(LoopVar))


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

        ListBox4.Items.Clear()
        ComboBox17.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfSlateportBattleTentPokemon", "")) = True

            ListBox4.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox17.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            LoopVar = LoopVar + 1
        End While

        LoopVar = 0

        ListBox7.Items.Clear()
        ComboBox26.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfVerdanturfBattleTentPokemon", "")) = True

            ListBox7.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox26.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            LoopVar = LoopVar + 1
        End While

        LoopVar = 0

        ListBox10.Items.Clear()
        ComboBox35.Items.Clear()


        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfFallarborBattleTentPokemon", "")) = True


            ListBox10.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox35.Items.Add(LoopVar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            LoopVar = LoopVar + 1
        End While

        LoopVar = 0

        ComboBox2.Items.Clear()
        ComboBox16.Items.Clear()
        ComboBox25.Items.Clear()
        ComboBox34.Items.Clear()
        ComboBox37.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            ComboBox2.Items.Add(GetPokemonName(LoopVar))
            ComboBox16.Items.Add(GetPokemonName(LoopVar))
            ComboBox25.Items.Add(GetPokemonName(LoopVar))
            ComboBox34.Items.Add(GetPokemonName(LoopVar))
            ComboBox37.Items.Add(GetPokemonName(LoopVar))

        End While

        LoopVar = 1

        ComboBox4.Items.Clear()
        ComboBox5.Items.Clear()
        ComboBox6.Items.Clear()
        ComboBox7.Items.Clear()

        ComboBox11.Items.Clear()
        ComboBox12.Items.Clear()
        ComboBox13.Items.Clear()
        ComboBox14.Items.Clear()

        ComboBox20.Items.Clear()
        ComboBox21.Items.Clear()
        ComboBox22.Items.Clear()
        ComboBox23.Items.Clear()

        ComboBox29.Items.Clear()
        ComboBox30.Items.Clear()
        ComboBox31.Items.Clear()
        ComboBox32.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox4.Items.Add(GetAttackName(LoopVar))
            ComboBox5.Items.Add(GetAttackName(LoopVar))
            ComboBox6.Items.Add(GetAttackName(LoopVar))
            ComboBox7.Items.Add(GetAttackName(LoopVar))

            ComboBox11.Items.Add(GetAttackName(LoopVar))
            ComboBox12.Items.Add(GetAttackName(LoopVar))
            ComboBox13.Items.Add(GetAttackName(LoopVar))
            ComboBox14.Items.Add(GetAttackName(LoopVar))

            ComboBox20.Items.Add(GetAttackName(LoopVar))
            ComboBox21.Items.Add(GetAttackName(LoopVar))
            ComboBox22.Items.Add(GetAttackName(LoopVar))
            ComboBox23.Items.Add(GetAttackName(LoopVar))

            ComboBox29.Items.Add(GetAttackName(LoopVar))
            ComboBox30.Items.Add(GetAttackName(LoopVar))
            ComboBox31.Items.Add(GetAttackName(LoopVar))
            ComboBox32.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        LoopVar = 0

        ComboBox3.Items.Clear()
        ComboBox15.Items.Clear()
        ComboBox24.Items.Clear()
        ComboBox33.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfBattlefrontierHeldItems", "")) + 1 = True


            ComboBox3.Items.Add(GetItemName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierHeldItems", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 2)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox15.Items.Add(GetItemName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierHeldItems", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 2)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox24.Items.Add(GetItemName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierHeldItems", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 2)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox33.Items.Add(GetItemName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, ((Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierHeldItems", "")), System.Globalization.NumberStyles.HexNumber)) + (LoopVar * 2)), 2))), System.Globalization.NumberStyles.HexNumber)))



            LoopVar = LoopVar + 1

        End While

        Dim curbytes As String
        Dim counter As Integer = 0

        ListBox13.Items.Clear()

        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox13.Items.Add(GetPokemonName(Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox13.SelectedIndex = 0

        'Tab 1
        ListBox1.SelectedIndex = 0
        ListBox2.SelectedIndex = 0

        'Tab 2
        ListBox6.SelectedIndex = 0
        ListBox4.SelectedIndex = 0

        'Tab 3
        ListBox9.SelectedIndex = 0
        ListBox7.SelectedIndex = 0

        'Tab 4
        ListBox12.SelectedIndex = 0
        ListBox10.SelectedIndex = 0


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

        Dim hpbit As String = ""
        Dim attackbit As String = ""
        Dim defensebit As String = ""
        Dim speedbit As String = ""
        Dim specialattackbit As String = ""
        Dim specialdefensebit As String = ""
        Dim evspreadwritevar As String = ""

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

    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged
        TextBox6.Text = GetSlateportBattleTentTrainerName(ListBox6.SelectedIndex)
        TextBox5.Text = Hex("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + (52 * ListBox6.SelectedIndex), 4))))
        TextBox4.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox5.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox4.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox5.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox4.Text, System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox5.SelectedIndex = 0
    End Sub

    Private Sub ListBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox9.SelectedIndexChanged
        TextBox9.Text = GetVerdanturfBattleTentTrainerName(ListBox9.SelectedIndex)
        TextBox8.Text = Hex("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + (52 * ListBox9.SelectedIndex), 4))))
        TextBox7.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox8.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox7.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox8.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox7.Text, System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox8.SelectedIndex = 0
    End Sub

    Private Sub ListBox12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox12.SelectedIndexChanged
        TextBox12.Text = GetFallarborBattleTentTrainerName(ListBox12.SelectedIndex)
        TextBox11.Text = Hex("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + (52 * ListBox12.SelectedIndex), 4))))
        TextBox10.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox11.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox10.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox11.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox10.Text, System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox11.SelectedIndex = 0
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim indexsave As Integer
        indexsave = ListBox9.SelectedIndex
        ChangeVerdanturfBattleTentName(ListBox9.SelectedIndex, TextBox9.Text)
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * indexsave)), ReverseHEX(Hex((Int32.Parse((TextBox8.Text), System.Globalization.NumberStyles.HexNumber)))))
        Dim LoopVar As Integer

        LoopVar = 0

        ListBox9.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfVerdanturfBattleTentTrainers", "")) = True


            ListBox9.Items.Add(GetVerdanturfBattleTentTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        ListBox9.SelectedIndex = -0
        ListBox9.SelectedIndex = indexsave
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim indexsave As Integer
        indexsave = ListBox6.SelectedIndex
        ChangeSlateportBattleTentName(ListBox6.SelectedIndex, TextBox6.Text)
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * indexsave)), ReverseHEX(Hex((Int32.Parse((TextBox5.Text), System.Globalization.NumberStyles.HexNumber)))))
        Dim LoopVar As Integer

        LoopVar = 0

        ListBox6.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfSlateportBattleTentTrainers", "")) = True


            ListBox6.Items.Add(GetSlateportBattleTentTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        ListBox6.SelectedIndex = -0
        ListBox6.SelectedIndex = indexsave
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        Dim indexsave As Integer
        indexsave = ListBox12.SelectedIndex
        ChangeFallarborBattleTentName(ListBox12.SelectedIndex, TextBox12.Text)
        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * indexsave)), ReverseHEX(Hex((Int32.Parse((TextBox11.Text), System.Globalization.NumberStyles.HexNumber)))))
        Dim LoopVar As Integer

        LoopVar = 0

        ListBox12.Items.Clear()

        While LoopVar < (GetString(GetINIFileLocation(), header, "NumberOfFallarborBattleTentTrainers", "")) = True


            ListBox12.Items.Add(GetFallarborBattleTentTrainerName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        ListBox12.SelectedIndex = -0
        ListBox12.SelectedIndex = indexsave
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), ReverseHEX(Hex((Int32.Parse((TextBox4.Text), System.Globalization.NumberStyles.HexNumber)) + &H8000000)))

        TextBox4.Text = Hex(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))), System.Globalization.NumberStyles.HexNumber))) - &H8000000)

        ListBox5.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox4.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox5.Items.Add((Val("&H" & curbytes)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox4.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox5.SelectedIndex = 0
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), ReverseHEX(Hex((Int32.Parse((TextBox7.Text), System.Globalization.NumberStyles.HexNumber)) + &H8000000)))

        TextBox7.Text = Hex(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))), System.Globalization.NumberStyles.HexNumber))) - &H8000000)

        ListBox8.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox7.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox8.Items.Add((Val("&H" & curbytes)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox7.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox8.SelectedIndex = 0
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), ReverseHEX(Hex((Int32.Parse((TextBox10.Text), System.Globalization.NumberStyles.HexNumber)) + &H8000000)))

        TextBox10.Text = Hex(((Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))), System.Globalization.NumberStyles.HexNumber))) - &H8000000)

        ListBox11.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox10.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox11.Items.Add((Val("&H" & curbytes)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox10.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox11.SelectedIndex = 0
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox4, (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox5.SelectedIndex * 2), 2))))) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
        ComboBox17.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox5.SelectedIndex * 2), 2))))
    End Sub

    Private Sub ListBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox8.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox6, (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox8.SelectedIndex * 2), 2))))) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
        ComboBox26.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox8.SelectedIndex * 2), 2))))
    End Sub

    Private Sub ListBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox11.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox8, (Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox11.SelectedIndex * 2), 2))))) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
        ComboBox35.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox11.SelectedIndex * 2), 2))))
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ListBox4.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox5.SelectedIndex * 2), 2))))
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ListBox7.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox8.SelectedIndex * 2), 2))))
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        ListBox10.SelectedIndex = Val("&H" & (ReverseHEX(ReadHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox11.SelectedIndex * 2), 2))))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim indexmemory As Integer

        indexmemory = ListBox5.SelectedIndex

        WriteHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox5.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox17.SelectedIndex), 4)))
        TextBox4.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)
        ListBox5.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox4.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox5.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox4.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox5.SelectedIndex = indexmemory
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim indexmemory As Integer

        indexmemory = ListBox8.SelectedIndex

        WriteHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox8.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox17.SelectedIndex), 4)))
        TextBox7.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)
        ListBox8.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox7.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox8.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox7.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox8.SelectedIndex = indexmemory
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim indexmemory As Integer

        indexmemory = ListBox11.SelectedIndex

        WriteHEX(LoadedROM, ("&H" & Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)) + (ListBox11.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox35.SelectedIndex), 4)))
        TextBox10.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)
        ListBox11.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox10.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox11.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox10.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox11.SelectedIndex = indexmemory
    End Sub

    Private Sub ComboBox16_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox16.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox3, ComboBox16.SelectedIndex + 1)
    End Sub

    Private Sub ComboBox25_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox25.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox5, ComboBox25.SelectedIndex + 1)
    End Sub

    Private Sub ComboBox34_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox34.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox7, ComboBox34.SelectedIndex + 1)
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        'species
        ComboBox16.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16)), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'attacks
        ComboBox14.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 2), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox13.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 4), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox12.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 6), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox11.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 8), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'items
        ComboBox15.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 10), 1))), System.Globalization.NumberStyles.HexNumber)

        'Nature
        ComboBox10.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 12), 1))), System.Globalization.NumberStyles.HexNumber)

        'EVs
        Dim EVSpreadIntVar As Integer
        Dim EVSpreadVar As String
        Dim hpbit As String
        Dim attackbit As String
        Dim defensebit As String
        Dim speedbit As String
        Dim specialattackbit As String
        Dim specialdefensebit As String

        EVSpreadIntVar = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox4.SelectedIndex * 16) + 11), 1)))), System.Globalization.NumberStyles.HexNumber)

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
            CheckedListBox2.SetItemCheckState("0", CheckState.Unchecked)
        ElseIf hpbit = "1"
            CheckedListBox2.SetItemCheckState("0", CheckState.Checked)
        End If

        If attackbit = "0" Then
            CheckedListBox2.SetItemCheckState("1", CheckState.Unchecked)
        ElseIf attackbit = "1"
            CheckedListBox2.SetItemCheckState("1", CheckState.Checked)
        End If

        If defensebit = "0" Then
            CheckedListBox2.SetItemCheckState("2", CheckState.Unchecked)
        ElseIf defensebit = "1"
            CheckedListBox2.SetItemCheckState("2", CheckState.Checked)
        End If

        If speedbit = "0" Then
            CheckedListBox2.SetItemCheckState("3", CheckState.Unchecked)
        ElseIf speedbit = "1"
            CheckedListBox2.SetItemCheckState("3", CheckState.Checked)
        End If

        If specialattackbit = "0" Then
            CheckedListBox2.SetItemCheckState("4", CheckState.Unchecked)
        ElseIf specialattackbit = "1"
            CheckedListBox2.SetItemCheckState("4", CheckState.Checked)
        End If

        If specialdefensebit = "0" Then
            CheckedListBox2.SetItemCheckState("5", CheckState.Unchecked)
        ElseIf specialdefensebit = "1"
            CheckedListBox2.SetItemCheckState("5", CheckState.Checked)
        End If
    End Sub

    Private Sub ListBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox7.SelectedIndexChanged
        'species
        ComboBox25.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16)), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'attacks
        ComboBox23.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 2), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox22.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 4), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox21.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 6), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox20.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 8), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'items
        ComboBox24.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 10), 1))), System.Globalization.NumberStyles.HexNumber)

        'Nature
        ComboBox19.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 12), 1))), System.Globalization.NumberStyles.HexNumber)

        'EVs
        Dim EVSpreadIntVar As Integer
        Dim EVSpreadVar As String
        Dim hpbit As String
        Dim attackbit As String
        Dim defensebit As String
        Dim speedbit As String
        Dim specialattackbit As String
        Dim specialdefensebit As String

        EVSpreadIntVar = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox7.SelectedIndex * 16) + 11), 1)))), System.Globalization.NumberStyles.HexNumber)

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
            CheckedListBox3.SetItemCheckState("0", CheckState.Unchecked)
        ElseIf hpbit = "1"
            CheckedListBox3.SetItemCheckState("0", CheckState.Checked)
        End If

        If attackbit = "0" Then
            CheckedListBox3.SetItemCheckState("1", CheckState.Unchecked)
        ElseIf attackbit = "1"
            CheckedListBox3.SetItemCheckState("1", CheckState.Checked)
        End If

        If defensebit = "0" Then
            CheckedListBox3.SetItemCheckState("2", CheckState.Unchecked)
        ElseIf defensebit = "1"
            CheckedListBox3.SetItemCheckState("2", CheckState.Checked)
        End If

        If speedbit = "0" Then
            CheckedListBox3.SetItemCheckState("3", CheckState.Unchecked)
        ElseIf speedbit = "1"
            CheckedListBox3.SetItemCheckState("3", CheckState.Checked)
        End If

        If specialattackbit = "0" Then
            CheckedListBox3.SetItemCheckState("4", CheckState.Unchecked)
        ElseIf specialattackbit = "1"
            CheckedListBox3.SetItemCheckState("4", CheckState.Checked)
        End If

        If specialdefensebit = "0" Then
            CheckedListBox3.SetItemCheckState("5", CheckState.Unchecked)
        ElseIf specialdefensebit = "1"
            CheckedListBox3.SetItemCheckState("5", CheckState.Checked)
        End If
    End Sub

    Private Sub ListBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox10.SelectedIndexChanged
        'species
        ComboBox34.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16)), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'attacks
        ComboBox32.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 2), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox31.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 4), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox30.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 6), 2))), System.Globalization.NumberStyles.HexNumber) - 1
        ComboBox29.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 8), 2))), System.Globalization.NumberStyles.HexNumber) - 1

        'items
        ComboBox33.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 10), 1))), System.Globalization.NumberStyles.HexNumber)

        'Nature
        ComboBox28.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 12), 1))), System.Globalization.NumberStyles.HexNumber)

        'EVs
        Dim EVSpreadIntVar As Integer
        Dim EVSpreadVar As String
        Dim hpbit As String
        Dim attackbit As String
        Dim defensebit As String
        Dim speedbit As String
        Dim specialattackbit As String
        Dim specialdefensebit As String

        EVSpreadIntVar = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox10.SelectedIndex * 16) + 11), 1)))), System.Globalization.NumberStyles.HexNumber)

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
            CheckedListBox4.SetItemCheckState("0", CheckState.Unchecked)
        ElseIf hpbit = "1"
            CheckedListBox4.SetItemCheckState("0", CheckState.Checked)
        End If

        If attackbit = "0" Then
            CheckedListBox4.SetItemCheckState("1", CheckState.Unchecked)
        ElseIf attackbit = "1"
            CheckedListBox4.SetItemCheckState("1", CheckState.Checked)
        End If

        If defensebit = "0" Then
            CheckedListBox4.SetItemCheckState("2", CheckState.Unchecked)
        ElseIf defensebit = "1"
            CheckedListBox4.SetItemCheckState("2", CheckState.Checked)
        End If

        If speedbit = "0" Then
            CheckedListBox4.SetItemCheckState("3", CheckState.Unchecked)
        ElseIf speedbit = "1"
            CheckedListBox4.SetItemCheckState("3", CheckState.Checked)
        End If

        If specialattackbit = "0" Then
            CheckedListBox4.SetItemCheckState("4", CheckState.Unchecked)
        ElseIf specialattackbit = "1"
            CheckedListBox4.SetItemCheckState("4", CheckState.Checked)
        End If

        If specialdefensebit = "0" Then
            CheckedListBox4.SetItemCheckState("5", CheckState.Unchecked)
        ElseIf specialdefensebit = "1"
            CheckedListBox4.SetItemCheckState("5", CheckState.Checked)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim indexmemory As Integer
        Dim indexmemory2 As Integer
        Dim indexmemory3 As Integer
        Dim loopvar As Integer

        indexmemory = ListBox4.SelectedIndex
        indexmemory2 = ComboBox17.SelectedIndex
        indexmemory3 = ListBox5.SelectedIndex

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16)), ReverseHEX(VB.Right("0000" & Hex(ComboBox16.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 10), Hex(ComboBox15.SelectedIndex))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox14.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 4), ReverseHEX(VB.Right("0000" & Hex(ComboBox13.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 6), ReverseHEX(VB.Right("0000" & Hex(ComboBox12.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 8), ReverseHEX(VB.Right("0000" & Hex(ComboBox11.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox4.SelectedIndex * 16) + 12), Hex(ComboBox10.SelectedIndex))

        Dim hpbit As String = ""
        Dim attackbit As String = ""
        Dim defensebit As String = ""
        Dim speedbit As String = ""
        Dim specialattackbit As String = ""
        Dim specialdefensebit As String = ""
        Dim evspreadwritevar As String = ""

        If CheckedListBox2.GetItemCheckState(0) = CheckState.Unchecked Then

            hpbit = 0

        ElseIf CheckedListBox2.GetItemCheckState(0) = CheckState.Checked Then

            hpbit = 1

        End If

        If CheckedListBox2.GetItemCheckState(1) = CheckState.Unchecked Then

            attackbit = 0

        ElseIf CheckedListBox2.GetItemCheckState(1) = CheckState.Checked Then

            attackbit = 1

        End If

        If CheckedListBox2.GetItemCheckState(2) = CheckState.Unchecked Then

            defensebit = 0

        ElseIf CheckedListBox2.GetItemCheckState(2) = CheckState.Checked Then

            defensebit = 1

        End If

        If CheckedListBox2.GetItemCheckState(3) = CheckState.Unchecked Then

            speedbit = 0

        ElseIf CheckedListBox2.GetItemCheckState(3) = CheckState.Checked Then

            speedbit = 1

        End If

        If CheckedListBox2.GetItemCheckState(4) = CheckState.Unchecked Then

            specialattackbit = 0

        ElseIf CheckedListBox2.GetItemCheckState(4) = CheckState.Checked Then

            specialattackbit = 1

        End If

        If CheckedListBox2.GetItemCheckState(5) = CheckState.Unchecked Then

            specialdefensebit = 0

        ElseIf CheckedListBox2.GetItemCheckState(5) = CheckState.Checked Then

            specialdefensebit = 1

        End If

        evspreadwritevar = specialdefensebit & specialattackbit & speedbit & defensebit & attackbit & hpbit

        evspreadwritevar = Convert.ToInt32(evspreadwritevar, 2)

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox4.SelectedIndex * 16) + 11), Hex(evspreadwritevar))

        'Everything past here loads stuff
        loopvar = 0

        ListBox4.Items.Clear()
        ComboBox17.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfSlateportBattleTentPokemon", "")) = True

            ListBox4.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox17.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            loopvar = loopvar + 1
        End While

        TextBox4.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "SlateportBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox6.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox5.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox4.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox5.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "SlateportBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox4.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox4.SelectedIndex = indexmemory
        ComboBox17.SelectedIndex = indexmemory2
        ListBox5.SelectedIndex = indexmemory3
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim indexmemory As Integer
        Dim indexmemory2 As Integer
        Dim indexmemory3 As Integer
        Dim loopvar As Integer

        indexmemory = ListBox7.SelectedIndex
        indexmemory2 = ComboBox26.SelectedIndex
        indexmemory3 = ListBox8.SelectedIndex

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16)), ReverseHEX(VB.Right("0000" & Hex(ComboBox25.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 10), Hex(ComboBox24.SelectedIndex))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox23.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 4), ReverseHEX(VB.Right("0000" & Hex(ComboBox22.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 6), ReverseHEX(VB.Right("0000" & Hex(ComboBox21.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 8), ReverseHEX(VB.Right("0000" & Hex(ComboBox20.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox7.SelectedIndex * 16) + 12), Hex(ComboBox19.SelectedIndex))

        Dim hpbit As String = ""
        Dim attackbit As String = ""
        Dim defensebit As String = ""
        Dim speedbit As String = ""
        Dim specialattackbit As String = ""
        Dim specialdefensebit As String = ""
        Dim evspreadwritevar As String = ""

        If CheckedListBox3.GetItemCheckState(0) = CheckState.Unchecked Then

            hpbit = 0

        ElseIf CheckedListBox3.GetItemCheckState(0) = CheckState.Checked Then

            hpbit = 1

        End If

        If CheckedListBox3.GetItemCheckState(1) = CheckState.Unchecked Then

            attackbit = 0

        ElseIf CheckedListBox3.GetItemCheckState(1) = CheckState.Checked Then

            attackbit = 1

        End If

        If CheckedListBox3.GetItemCheckState(2) = CheckState.Unchecked Then

            defensebit = 0

        ElseIf CheckedListBox3.GetItemCheckState(2) = CheckState.Checked Then

            defensebit = 1

        End If

        If CheckedListBox3.GetItemCheckState(3) = CheckState.Unchecked Then

            speedbit = 0

        ElseIf CheckedListBox3.GetItemCheckState(3) = CheckState.Checked Then

            speedbit = 1

        End If

        If CheckedListBox3.GetItemCheckState(4) = CheckState.Unchecked Then

            specialattackbit = 0

        ElseIf CheckedListBox3.GetItemCheckState(4) = CheckState.Checked Then

            specialattackbit = 1

        End If

        If CheckedListBox3.GetItemCheckState(5) = CheckState.Unchecked Then

            specialdefensebit = 0

        ElseIf CheckedListBox3.GetItemCheckState(5) = CheckState.Checked Then

            specialdefensebit = 1

        End If

        evspreadwritevar = specialdefensebit & specialattackbit & speedbit & defensebit & attackbit & hpbit

        evspreadwritevar = Convert.ToInt32(evspreadwritevar, 2)

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox7.SelectedIndex * 16) + 11), Hex(evspreadwritevar))

        'Everything past here loads stuff
        loopvar = 0

        ListBox7.Items.Clear()
        ComboBox26.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfVerdanturfBattleTentPokemon", "")) = True

            ListBox7.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox26.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            loopvar = loopvar + 1
        End While

        TextBox7.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox9.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox8.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox7.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox8.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "VerdanturfBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox7.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox7.SelectedIndex = indexmemory
        ComboBox26.SelectedIndex = indexmemory2
        ListBox8.SelectedIndex = indexmemory3
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim indexmemory As Integer
        Dim indexmemory2 As Integer
        Dim indexmemory3 As Integer
        Dim loopvar As Integer

        indexmemory = ListBox10.SelectedIndex
        indexmemory2 = ComboBox35.SelectedIndex
        indexmemory3 = ListBox11.SelectedIndex

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16)), ReverseHEX(VB.Right("0000" & Hex(ComboBox34.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 10), Hex(ComboBox33.SelectedIndex))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox32.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 4), ReverseHEX(VB.Right("0000" & Hex(ComboBox31.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 6), ReverseHEX(VB.Right("0000" & Hex(ComboBox30.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 8), ReverseHEX(VB.Right("0000" & Hex(ComboBox29.SelectedIndex + 1), 4)))

        WriteHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (ListBox10.SelectedIndex * 16) + 12), Hex(ComboBox28.SelectedIndex))

        Dim hpbit As String = ""
        Dim attackbit As String = ""
        Dim defensebit As String = ""
        Dim speedbit As String = ""
        Dim specialattackbit As String = ""
        Dim specialdefensebit As String = ""
        Dim evspreadwritevar As String = ""

        If CheckedListBox4.GetItemCheckState(0) = CheckState.Unchecked Then

            hpbit = 0

        ElseIf CheckedListBox4.GetItemCheckState(0) = CheckState.Checked Then

            hpbit = 1

        End If

        If CheckedListBox4.GetItemCheckState(1) = CheckState.Unchecked Then

            attackbit = 0

        ElseIf CheckedListBox4.GetItemCheckState(1) = CheckState.Checked Then

            attackbit = 1

        End If

        If CheckedListBox4.GetItemCheckState(2) = CheckState.Unchecked Then

            defensebit = 0

        ElseIf CheckedListBox4.GetItemCheckState(2) = CheckState.Checked Then

            defensebit = 1

        End If

        If CheckedListBox4.GetItemCheckState(3) = CheckState.Unchecked Then

            speedbit = 0

        ElseIf CheckedListBox4.GetItemCheckState(3) = CheckState.Checked Then

            speedbit = 1

        End If

        If CheckedListBox4.GetItemCheckState(4) = CheckState.Unchecked Then

            specialattackbit = 0

        ElseIf CheckedListBox4.GetItemCheckState(4) = CheckState.Checked Then

            specialattackbit = 1

        End If

        If CheckedListBox4.GetItemCheckState(5) = CheckState.Unchecked Then

            specialdefensebit = 0

        ElseIf CheckedListBox4.GetItemCheckState(5) = CheckState.Checked Then

            specialdefensebit = 1

        End If

        evspreadwritevar = specialdefensebit & specialattackbit & speedbit & defensebit & attackbit & hpbit

        evspreadwritevar = Convert.ToInt32(evspreadwritevar, 2)

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + ((ListBox10.SelectedIndex * 16) + 11), Hex(evspreadwritevar))

        'Everything past here loads stuff
        loopvar = 0

        ListBox10.Items.Clear()
        ComboBox35.Items.Clear()

        While loopvar < (GetString(GetINIFileLocation(), header, "NumberOfFallarborBattleTentPokemon", "")) = True

            ListBox10.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))
            ComboBox35.Items.Add(loopvar & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (loopvar * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            loopvar = loopvar + 1
        End While

        TextBox10.Text = Hex((("&H" & (ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "FallarborBattleTentTrainers", "")), System.Globalization.NumberStyles.HexNumber) + ((52 * ListBox12.SelectedIndex) + 48), 4))))) - &H8000000)

        ListBox11.Items.Clear()

        Dim curbytes As String
        Dim counter As Integer = 0


        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(TextBox10.Text, System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox11.Items.Add((Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)) & " - " & GetPokemonName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (Int32.Parse(((GetString(GetINIFileLocation(), header, "FallarborBattleTentPokemon", ""))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber) * 16)), 2))), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((TextBox10.Text), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox10.SelectedIndex = indexmemory
        ComboBox35.SelectedIndex = indexmemory2
        ListBox11.SelectedIndex = indexmemory3
    End Sub

    Private Sub ComboBox37_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox37.SelectedIndexChanged
        GetAndDrawAnimationPokemonPic(PictureBox9, ComboBox37.SelectedIndex + 1)
    End Sub

    Private Sub ListBox13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox13.SelectedIndexChanged
        ComboBox37.SelectedIndex = Int32.Parse(ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox13.SelectedIndex * 2), 2)), System.Globalization.NumberStyles.HexNumber) - 1
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        Dim indexmem As Integer


        Dim curbytes As String
        Dim counter As Integer = 0

        indexmem = ListBox13.SelectedIndex

        WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber) + (ListBox13.SelectedIndex * 2), ReverseHEX(VB.Right("0000" & Hex(ComboBox37.SelectedIndex + 1), 4)))

        ListBox13.Items.Clear()

        curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber), 2))

        While curbytes <> "FFFF"

            ListBox13.Items.Add(GetPokemonName(Int32.Parse((curbytes), System.Globalization.NumberStyles.HexNumber)))

            counter = counter + 1

            curbytes = ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "BattleFrontierBanList", "")), System.Globalization.NumberStyles.HexNumber) + (counter * 2), 2))

        End While

        ListBox13.SelectedIndex = indexmem
    End Sub
End Class