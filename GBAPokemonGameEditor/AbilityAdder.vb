Option Strict Off
Option Explicit On
Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class AbilityAdder
    Private Sub AbilityAdder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If header = "BPEE" Then

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = True
            TabControl1.SelectedIndex = 1

            Label4.Text = "Number of abilities in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))


        ElseIf header = "BPRE" Then

            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = False
            TabControl1.SelectedIndex = 0

            Label1.Text = "Number of abilities in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))

        Else

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = False

            MsgBox("Not supported.")
            Me.Close()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim countervar As Integer

        Dim AbilitiesNamesBuffer As String
        Dim AbilitiesNamesNewOffset As String

        Dim AbilitiesDescriptionTableBuffer As String
        Dim AbilitiesDescriptionTableNewOffset As String

        If System.IO.File.Exists((LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini") = True Then

            MsgBox("An INI for this ROM has been detected! Values will be updated as needed.")

        Else

            MsgBox("INI not found! One will now be created for this ROM in the same location as the ROM. Keep the ini with the ROM so that PGE can know the location of the data.")

            File.Copy(AppPath & "ini\roms.ini", (LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini", True)

        End If

        Cursor = Cursors.WaitCursor

        'Ability Names

        AbilitiesNamesBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityNames", "")), System.Globalization.NumberStyles.HexNumber), (GetString(GetINIFileLocation(), header, "NumberOfAbilities", "")) * 13)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityNames", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AbilitiesNamesBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AbilitiesNamesBuffer = AbilitiesNamesBuffer & "ACACACACACACACFF0000000000"

        End While


        AbilitiesNamesNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AbilitiesNamesBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AbilitiesNamesNewOffset, AbilitiesNamesBuffer)

        WriteString(GetINIFileLocation(), header, "AbilityNames", Hex(AbilitiesNamesNewOffset))

        'Repoint ability Names

        WriteHEX(LoadedROM, &H1C0, ReverseHEX(Hex((AbilitiesNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &HD8004, ReverseHEX(Hex((AbilitiesNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &HD8624, ReverseHEX(Hex((AbilitiesNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1367A0, ReverseHEX(Hex((AbilitiesNamesNewOffset) + &H8000000)))

        'ability Descriptions

        AbilitiesDescriptionTableBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) * 4)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AbilityDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AbilitiesDescriptionTableBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AbilitiesDescriptionTableBuffer = AbilitiesDescriptionTableBuffer & "C4F32408"

        End While


        AbilitiesDescriptionTableNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AbilitiesDescriptionTableBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AbilitiesDescriptionTableNewOffset, AbilitiesDescriptionTableBuffer)

        WriteString(GetINIFileLocation(), header, "AbilityDescriptionTable", Hex(AbilitiesDescriptionTableNewOffset))

        'Repoint Abilities Description Table

        WriteHEX(LoadedROM, &H1C4, ReverseHEX(Hex((AbilitiesDescriptionTableNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1367A8, ReverseHEX(Hex((AbilitiesDescriptionTableNewOffset) + &H8000000)))


        'Updates the number of Abilities
        WriteString(GetINIFileLocation(), header, "NumberOfAbilities", CInt((GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))) + CInt(TextBox1.Text))

        Label1.Text = "Number of abilities in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAbilities", ""))

        Cursor = Cursors.Arrow

        MsgBox("Abilities expanded successfully!")

    End Sub
End Class