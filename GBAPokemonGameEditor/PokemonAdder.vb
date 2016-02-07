Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class PokemonAdder
    Private Sub PokemonAdder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If header = "BPEE" Then

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = True
            TabControl1.SelectedIndex = 1

            MsgBox("Not implemented yet!")
            End

        ElseIf header = "BPRE" Then

            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = False
            TabControl1.SelectedIndex = 0

            Label1.Text = "Number of Pokemon in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1
            Label2.Text = "Number of Dex entries in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1


            Label6.Text = "Seen flags location: " & Hex(CInt("&H" & TextBox3.Text))
            Label7.Text = "Caught flags location: " & Hex((("&H" & TextBox3.Text) + Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))

        Else

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = False

            MsgBox("Not supported.")
            Me.Close()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If System.IO.File.Exists((LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini") = True Then

            MsgBox("An INI for this ROM has been detected! Values will be updated as needed.")

        Else

            MsgBox("INI not found! One will now be created for this ROM in the same location as the ROM. Keep the ini with the ROM so that PGE can know the location of the data.")

            File.Copy(AppPath & "ini\roms.ini", (LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini", True)


        End If

        'Install's JPAN's save hack.

        If CheckBox1.Checked And GetString(GetINIFileLocation(), header, "JPANSaveHack", "False") = "False" Then

            Dim SaveRoutine As String = "2168FF231B015B189888002809D004280AD00D280CD00D2D1CDD012008BC9846F0BDCC21084A06E096218900074A02E0BA210901064A043B18681060043A04390029F8D1E7E70000C8C0030220C30302C0CE030200480047719E0D08FFFFFFFFFF273F01CF19F880BE88002E08D0042E09D00D2E0BD000000048004723990D08CC23084A06E096239B00074A02E0BA231B01064A043F10683860043A043B002BF8D1E9E7C8C0030220C30302C0CE03020000240F0000F00FF00FF00FE01FF00FD02F980D0000F00FF00FF00FE01FF00FD02FF00FC03FF00FB04FF00FA05FF00F906FF00F807F5004"
            Dim SaveTable As String = "0000240F0000F00FF00FF00FE01FF00FD02F980D0000F00FF00FF00FE01FF00FD02FF00FC03FF00FB04FF00FA05FF00F906FF00F807F5004"
            Dim SaveRoutineOffset As String = ""

            SaveRoutineOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(SaveRoutine) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, SaveRoutineOffset, SaveRoutine)
            WriteHEX(LoadedROM, &H3FEC94, SaveTable)

            WriteHEX(LoadedROM, &HD9EDC, "00480047" & ReverseHEX(Hex((SaveRoutineOffset) + &H8000001)))
            WriteHEX(LoadedROM, &HD991E, "3847")
            WriteHEX(LoadedROM, &HD995C, ReverseHEX(Hex((SaveRoutineOffset) + &H8000061)))


            'Enable the hack in the ini file.
            WriteString(GetINIFileLocation(), header, "JPANSaveHack", "True")

        End If

        'This makes the Pokedex work with the save hack.

        If CheckBox1.Checked Then

            'Disable LR help menu
            WriteHEX(LoadedROM, &H13B8C2, "1DE0")

            'Makes game be able to read the new location of the SEEN flags.

            WriteHEX(LoadedROM, &H104B10, ReverseHEX(VB.Right("00000000" & Hex(CInt("&H" & TextBox3.Text)), 8)))
            WriteHEX(LoadedROM, &H104B00, "0000")
            WriteHEX(LoadedROM, &H104B02, "0000")

            'Makes game be able to read the new location of the CAUGHT flags.

            WriteHEX(LoadedROM, &H104B5C, ReverseHEX(VB.Right("00000000" & Hex((("&H" & TextBox3.Text) + Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8))), 8)))
            WriteHEX(LoadedROM, &H104B16, "0000")
            WriteHEX(LoadedROM, &H104B18, "0000")
            WriteHEX(LoadedROM, &H104B1A, "0000")
            WriteHEX(LoadedROM, &H104B26, "16E0")

            'This makes both of the above bypass redundant SEEN flags.??
            WriteHEX(LoadedROM, &H104B34, "0FE0")

            'This makes the game write to the New SEEN flags.
            WriteHEX(LoadedROM, &H104B94, ReverseHEX(VB.Right("00000000" & Hex(CInt("&H" & TextBox3.Text)), 8)))
            WriteHEX(LoadedROM, &H104B6A, "011C")
            WriteHEX(LoadedROM, &H104B6C, "0000")
            WriteHEX(LoadedROM, &H104B78, "1AE0")

            'This makes the game write to the New CAUGHT flags.
            WriteHEX(LoadedROM, &H104BB8, ReverseHEX(VB.Right("00000000" & Hex((("&H" & TextBox3.Text) + Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8))), 8)))
            WriteHEX(LoadedROM, &H104BA2, "011C")
            WriteHEX(LoadedROM, &H104BA4, "0000")

            'Makes the game clear the flags properly when the player selects New Game at the main menu.
            WriteHEX(LoadedROM, &H549D0, ReverseHEX(VB.Right("00000000" & Hex(CInt("&H" & TextBox3.Text)), 8)))
            WriteHEX(LoadedROM, &H549B0, "201C0000")
            WriteHEX(LoadedROM, &H549B6, Hex(Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))
            WriteHEX(LoadedROM, &H549B7, "22")
            WriteHEX(LoadedROM, &H549BC, "201C")
            WriteHEX(LoadedROM, &H549BE, Hex(Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))
            WriteHEX(LoadedROM, &H549BF, "30")
            WriteHEX(LoadedROM, &H549C2, Hex(Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))
            WriteHEX(LoadedROM, &H549C3, "22")


        End If


        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Arrow

        Label1.Text = "Number of Pokemon in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1
        Label2.Text = "Number of Dex entries in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1

        MsgBox("Pokemon added successfully!")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.pokecommunity.com/showthread.php?t=318569")
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If e.KeyChar = "0" Then
            Exit Sub
        End If

        If e.KeyChar = "1" Then
            Exit Sub
        End If

        If e.KeyChar = "2" Then
            Exit Sub
        End If

        If e.KeyChar = "3" Then
            Exit Sub
        End If

        If e.KeyChar = "4" Then
            Exit Sub
        End If

        If e.KeyChar = "5" Then
            Exit Sub
        End If

        If e.KeyChar = "6" Then
            Exit Sub
        End If

        If e.KeyChar = "6" Then
            Exit Sub
        End If

        If e.KeyChar = "7" Then
            Exit Sub
        End If

        If e.KeyChar = "8" Then
            Exit Sub
        End If

        If e.KeyChar = "9" Then
            Exit Sub
        End If

        If e.KeyChar = "A" Then
            Exit Sub
        End If

        If e.KeyChar = "B" Then
            Exit Sub
        End If

        If e.KeyChar = "C" Then
            Exit Sub
        End If

        If e.KeyChar = "D" Then
            Exit Sub
        End If

        If e.KeyChar = "E" Then
            Exit Sub
        End If

        If e.KeyChar = "F" Then
            Exit Sub
        End If

        If e.KeyChar = "a" Then
            e.KeyChar = "A"
            Exit Sub
        End If

        If e.KeyChar = "b" Then
            e.KeyChar = "B"
            Exit Sub
        End If

        If e.KeyChar = "c" Then
            e.KeyChar = "C"
            Exit Sub
        End If

        If e.KeyChar = "d" Then
            e.KeyChar = "D"
            Exit Sub
        End If

        If e.KeyChar = "e" Then
            e.KeyChar = "E"
            Exit Sub
        End If

        If e.KeyChar = "f" Then
            e.KeyChar = "F"
            Exit Sub
        End If

        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            Exit Sub
        End If

        e.KeyChar = ""

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            TextBox3.Text = 0
        End If

        Label6.Text = "Seen flags location: " & Hex(CInt("&H" & TextBox3.Text))
        Label7.Text = "Caught flags location: " & Hex((("&H" & TextBox3.Text) + Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

        If TextBox2.Text = "" Then
            TextBox2.Text = 0
        End If

        If TextBox3.Text <> "" Then

            Label6.Text = "Seen flags location: " & Hex(CInt("&H" & TextBox3.Text))
            Label7.Text = "Caught flags location: " & Hex((("&H" & TextBox3.Text) + Math.Ceiling((((GetString(GetINIFileLocation(), header, "NumberOfDexEntries", "")) - 1) + TextBox2.Text) / 8)))

        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            TextBox3.Enabled = True
        End If

        If CheckBox1.Checked = False Then
            TextBox3.Enabled = False
        End If

    End Sub
End Class