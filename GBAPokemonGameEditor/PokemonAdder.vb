Imports System.IO

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


        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Arrow

        Label1.Text = "Number of Pokemon in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1

        MsgBox("Pokemon added successfully!")

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.pokecommunity.com/showthread.php?t=318569")
    End Sub
End Class