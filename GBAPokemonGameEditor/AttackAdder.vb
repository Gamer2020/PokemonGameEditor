Option Strict Off
Option Explicit On
Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class AttackAdder
    Private Sub AttackExpander_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If header = "BPEE" Then

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = True
            TabControl1.SelectedIndex = 1

            Label4.Text = "Number of attacks in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1


        ElseIf header = "BPRE" Then

            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = False
            TabControl1.SelectedIndex = 0

            Label1.Text = "Number of attacks in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1

        Else

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = False

            MsgBox("Not supported.")
            Me.Close()

        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.pokecommunity.com/showthread.php?t=263479")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim countervar As Integer

        Dim AttackDataBuffer As String
        Dim AttackDataNewOffset As String

        Dim AttackNamesBuffer As String
        Dim AttackNamesNewOffset As String

        Dim AttackAnimationTableBuffer As String
        Dim AttackAnimationTableNewOffset As String

        Dim AttackDescriptionTableBuffer As String
        Dim AttackDescriptionTableNewOffset As String

        If System.IO.File.Exists((LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini") = True Then

            MsgBox("An INI for this ROM has been detected! Values will be updated as needed.")

        Else

            MsgBox("INI not found! One will now be created for this ROM in the same location as the ROM. Keep the ini with the ROM so that PGE can know the location of the data.")

            File.Copy(AppPath & "ini\roms.ini", (LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini", True)


        End If

        Cursor = Cursors.WaitCursor

        'Attack Data

        AttackDataBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 12)

        'Deletes old data

        If CheckBox2.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackDataBuffer) / 2)))
        End If

        'MsgBox((Len(AttackDataBuffer) / 2))

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AttackDataBuffer = AttackDataBuffer & "000000000000000000000000"

        End While

        'MsgBox(((Len(AttackDataBuffer) / 2) / 12))

        AttackDataNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackDataBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        ' MsgBox(Hex(AttackDataNewOffset))

        ' MsgBox((Len(AttackDataBuffer) / 2) / 12)

        ' WriteString(GetINIFileLocation(), header, "NumberOfAttacks", ((Len(AttackDataBuffer) / 2) / 12) - 1)

        WriteHEX(LoadedROM, AttackDataNewOffset, AttackDataBuffer)

        WriteString(GetINIFileLocation(), header, "AttackData", Hex(AttackDataNewOffset))

        'Repoint Attack Data

        WriteHEX(LoadedROM, &H0001CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H00E3D8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0128CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H012BA4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H015060, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H015FBC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0160F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H016238, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H016368, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0176D8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H017990, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H019544, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0197A4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H019BF0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01A0D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01A6E8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01A740, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01AA40, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01AB0C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01AC00, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01ACDC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01ADB8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01AE8C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01AFF8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01CF00, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01D098, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01D29C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01D934, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01D9D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DA90, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DBF0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DC6C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DDB4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DE68, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01DF88, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E100, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E1A8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E288, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E4D8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E680, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E768, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E7F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E830, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01E910, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EA9C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EAFC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01ED30, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EDB4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EDE4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EE94, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01EFC8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01F030, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01F0C4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01F258, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01F53C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H01F750, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H021158, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H021190, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02334C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H023490, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02393C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H023B14, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H023C20, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H023C9C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H023E6C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0240C4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H025CFC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H026100, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02704C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H027468, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0286A0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H028744, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H028A6C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H028B4C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H029434, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0296AC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0297F4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02A180, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02A1F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02A27C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02AD00, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02AE18, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02AE50, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02BAC0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02BE84, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02C6C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02D014, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02E8B4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02E9F4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H02EA9C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0309C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H033B40, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H038670, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0386BC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03941C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H039468, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03962C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0398C4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03A194, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E94C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E9D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03EC3C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03ECE8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03ED3C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03ED60, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03F254, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03F3B4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03F510, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04105C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C7D90, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C7E00, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C7F34, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C7F5C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C80AC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8414, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8924, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8970, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8BD4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8CBC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8F2C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C8FA4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C9030, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C9084, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C946C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C9498, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0C94C4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E5380, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E53CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E543C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1334D8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133528, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1335AC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1336F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133878, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H136950, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H136A64, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H136AB4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))

        WriteHEX(LoadedROM, &H11510, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H116C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H3E8F8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H3E9A0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H40EE0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))


        'Attack Names


        AttackNamesBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 13)

        'Deletes old data

        If CheckBox2.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackNamesBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AttackNamesBuffer = AttackNamesBuffer & "ACACACACACACACFF0000000000"

        End While


        AttackNamesNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackNamesBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackNamesNewOffset, AttackNamesBuffer)

        WriteString(GetINIFileLocation(), header, "AttackNames", Hex(AttackNamesNewOffset))

        ''Repoint Attack Names

        WriteHEX(LoadedROM, &H000148, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0308A4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04EF84, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H06BE8C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H09B524, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0BD830, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0BFAA4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0CC914, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D764C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D7EE0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D8500, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E4E58, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E51F0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H10D9C0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1140F0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H11C5A8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H11C6E4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1256BC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H125948, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H125A2C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H125BE4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H125CE0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H125FF8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H12606C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H126128, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1261FC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H12627C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1267F0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H126880, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H126E64, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H131E14, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H13695C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))

        'Repoint Field Move names

        WriteHEX(LoadedROM, &H45A6A8, ReverseHEX(Hex((AttackNamesNewOffset + (148 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6B0, ReverseHEX(Hex((AttackNamesNewOffset + (15 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6B8, ReverseHEX(Hex((AttackNamesNewOffset + (19 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6C0, ReverseHEX(Hex((AttackNamesNewOffset + (70 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6C8, ReverseHEX(Hex((AttackNamesNewOffset + (57 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6D0, ReverseHEX(Hex((AttackNamesNewOffset + (249 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6D8, ReverseHEX(Hex((AttackNamesNewOffset + (127 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6E0, ReverseHEX(Hex((AttackNamesNewOffset + (100 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6E8, ReverseHEX(Hex((AttackNamesNewOffset + (91 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6F0, ReverseHEX(Hex((AttackNamesNewOffset + (208 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A6F8, ReverseHEX(Hex((AttackNamesNewOffset + (135 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H45A700, ReverseHEX(Hex((AttackNamesNewOffset + (230 * 13)) + &H8000000)))

        ''Attack Animations


        AttackAnimationTableBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackAnimationTable", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 4)

        ''Deletes old data

        If CheckBox2.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackAnimationTable", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackAnimationTableBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AttackAnimationTableBuffer = AttackAnimationTableBuffer & "346F1C08"

        End While


        AttackAnimationTableNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackAnimationTableBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackAnimationTableNewOffset, AttackAnimationTableBuffer)

        WriteString(GetINIFileLocation(), header, "AttackAnimationTable", Hex(AttackAnimationTableNewOffset))

        'Repoint Attack Animation Table

        WriteHEX(LoadedROM, &H725D0, ReverseHEX(Hex((AttackAnimationTableNewOffset) + &H8000000)))

        ''Attack Descriptions


        AttackDescriptionTableBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", ""))) * 4)

        ''Deletes old data

        If CheckBox2.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackDescriptionTableBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox1.Text
            countervar = countervar + 1

            AttackDescriptionTableBuffer = AttackDescriptionTableBuffer & "34284808"

        End While


        AttackDescriptionTableNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackDescriptionTableBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackDescriptionTableNewOffset, AttackDescriptionTableBuffer)

        WriteString(GetINIFileLocation(), header, "AttackDescriptionTable", Hex(AttackDescriptionTableNewOffset))

        'Repoint Attack Description Table

        WriteHEX(LoadedROM, &HE5440, ReverseHEX(Hex((AttackDescriptionTableNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H137BC8, ReverseHEX(Hex((AttackDescriptionTableNewOffset) + &H8000000)))


        'Only limiter in ROM patch

        WriteHEX(LoadedROM, &HD75FC, "00000000000013E0")

        'Move Table hack stuff
        If CheckBox1.Checked And GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "False".ToLower() Then

            'Converts the table to the new format

            Dim pokeloopcounter As Integer = 1
            Dim AttackTable As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)
            Dim CurLvlUpAttPointer As String = ""
            Dim newmovesoffset As String = ""

            Dim CurAttacksLooper As Integer

            Dim TempLoadBuff As Integer
            Dim binarybuffer As String
            Dim at As String
            Dim lvl As String

            Dim CurPokeAttacksBuff As String


            MsgBox("Movesets will now be converted. This will take a while...")

            While (pokeloopcounter < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")))

                CurLvlUpAttPointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (pokeloopcounter * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

                CurAttacksLooper = 0
                CurPokeAttacksBuff = ""

                While ReadHEX(LoadedROM, Int32.Parse((CurLvlUpAttPointer), System.Globalization.NumberStyles.HexNumber) + (CurAttacksLooper * 2), 2) = "FFFF" = False

                    TempLoadBuff = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((CurLvlUpAttPointer), System.Globalization.NumberStyles.HexNumber) + (CurAttacksLooper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

                    binarybuffer = Convert.ToString(TempLoadBuff, 2)

                    While Len(binarybuffer) < 16

                        binarybuffer = "0" & binarybuffer

                    End While

                    lvl = Mid(binarybuffer, 1, 7)

                    at = Mid(binarybuffer, 8, 9)

                    lvl = Convert.ToInt32(lvl, 2)

                    at = Convert.ToInt32(at, 2)

                    lvl = VB.Right("00" & Hex(lvl), 2)
                    at = ReverseHEX(VB.Right("0000" & Hex(at), 4))


                    CurPokeAttacksBuff = CurPokeAttacksBuff & at & lvl

                    CurAttacksLooper = CurAttacksLooper + 1
                End While

                If CurAttacksLooper = 0 Then
                    CurPokeAttacksBuff = CurPokeAttacksBuff & "0100" & "01"
                End If

                'deletes the old moves

                If CheckBox2.Checked Then
                    WriteHEX(LoadedROM, Int32.Parse(CurLvlUpAttPointer, System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((CurAttacksLooper * 2)))
                End If

                CurPokeAttacksBuff = CurPokeAttacksBuff & "0000FF00"

                newmovesoffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(CurPokeAttacksBuff) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                WriteHEX(LoadedROM, (AttackTable) + (pokeloopcounter * 4), ReverseHEX(Hex((newmovesoffset) + &H8000000)))

                WriteHEX(LoadedROM, newmovesoffset, CurPokeAttacksBuff)

                pokeloopcounter = pokeloopcounter + 1
            End While

            'Write the routines

            Dim routine1 As String = "494689001148401800680F4E063637787900C9194318997854468C4203D0FF290BD00137F4E7084A01373770597809021878084310800249084702480047C04665EB030873EB030822400202" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine2 As String = "8178FF22914225D01202FF32914600235800C0181949891909684718B8785446A04217DC7978387809020143404600930C1C00F017F8FF25009B484504D14046211C00F013F8009B0133032178188078A842DDD101B038BC9846A146AA46F0BC01BC0047F0B581B0024F3847F0B5024F3847C046B5E8030843EC0308" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine3 As String = "00253D4EB9008A19136898780591FF2868D09146049303226A4304995018171C017843781B020B43807803990135AC4688424BDC002468460188181C814211D005982D4946186B463D1C02330134032C08DC3068281801784078000208431A888242F2D1042C31D1002454451CDA4946086838180178407800020843029A1288824211D005991C4A8E18029B3D1C02330134544508DA3068281801784078000208431A888242F2D154450FD1504601300006000E82466200029952184C4620683818017840780002084310806546132D08DC4946086803216943091808888878FF2898D1504606B038BC9846A146AA46F0BC02BC0847C046" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine4 As String = "F0B557464E464546E0B48FB0061C00208246301C41210022524B00F0A1F80004040C301C382100224E4B00F099F80006000E0C90CE204000844201D1002087E00025A4000E946C46291C0D31301C0022444B00F085F8208002340135032DF3DD0025414B0E9AD11808688078FF286ED089466C4608340D944946086803226A43101880780C9C211C171C0135AC46884252DC002448460068017840780002084369460988814211D00E982F4946186B463D1C02330134032C08DC3068281801784078000208431A888242F2D1042C33D1002454451EDA49460868381801784078000201430D980288081C02A9824211D00E9A1D4816180B1C3D1C02330134544508DA3068281801784078000208431A888242F2D154450FD1504601300006000E824662000D9CA218494608683818017840780002084310806546132D07DC4A4610680321694309188878FF2894D150460FB038BC9846A146AA46F0BC02BC08471847C046E9FB0308" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine5 As String = "0321484319684018817801480047C04605EB0308"
            Dim routine6 As String = "F0B50E1C0004002500241049800B401802689078FF2812D0131C291C481C0006050E490089191A78587800021043088003330134132C02DC9878FF28EDD1281CF0BC02BC0847C046" & ReverseHEX(Hex(AttackTable + &H8000000))

            Dim routine1offset As String = ""
            Dim routine2offset As String = ""
            Dim routine3offset As String = ""
            Dim routine4offset As String = ""
            Dim routine5offset As String = ""
            Dim routine6offset As String = ""

            routine1offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine1) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine1offset, routine1)

            WriteHEX(LoadedROM, &H3EB20, "18490847")
            WriteHEX(LoadedROM, &H3EB84, ReverseHEX(Hex((routine1offset) + &H8000001)))

            routine2offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine2) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine2offset, routine2)

            WriteHEX(LoadedROM, &H3EA10, "00490847" & ReverseHEX(Hex((routine2offset) + &H8000001)))

            routine3offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine3) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine3offset, routine3)

            WriteHEX(LoadedROM, &H43CD0, "00490847" & ReverseHEX(Hex((routine3offset) + &H8000001)))

            routine4offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine4) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine4offset, routine4)

            WriteHEX(LoadedROM, &H43E2C, "004B1847" & ReverseHEX(Hex((routine4offset) + &H8000001)))


            routine5offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine5) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine5offset, routine5)

            WriteHEX(LoadedROM, &H3EAD4, "8078C046C046C046C046")
            WriteHEX(LoadedROM, &H3EB04, "FF29")
            WriteHEX(LoadedROM, &H3EAE2, "5446C046")
            WriteHEX(LoadedROM, &H3EB18, "081CC046")
            WriteHEX(LoadedROM, &H3EAFC, "00490847" & ReverseHEX(Hex((routine5offset) + &H8000001)))

            WriteHEX(LoadedROM, &H43DD4, routine6)

            'Enable the hack in the ini file.
            WriteString(GetINIFileLocation(), header, "MoveTableHack", "True")

        End If

        'Updates the number of attacks
        WriteString(GetINIFileLocation(), header, "NumberOfAttacks", CInt((GetString(GetINIFileLocation(), header, "NumberOfAttacks", ""))) + CInt(TextBox1.Text))

        Label1.Text = "Number of attacks in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1

        Cursor = Cursors.Arrow

        MsgBox("Attacks added successfully!")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim countervar As Integer

        Dim AttackDataBuffer As String
        Dim AttackDataNewOffset As String

        Dim AttackNamesBuffer As String
        Dim AttackNamesNewOffset As String

        Dim AttackAnimationTableBuffer As String
        Dim AttackAnimationTableNewOffset As String

        Dim AttackDescriptionTableBuffer As String
        Dim AttackDescriptionTableNewOffset As String

        Dim ContestDataBuffer As String
        Dim ContestDataNewOffset As String

        If System.IO.File.Exists((LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini") = True Then

            MsgBox("An INI for this ROM has been detected! Values will be updated as needed.")

        Else

            MsgBox("INI not found! One will now be created for this ROM in the same location as the ROM. Keep the ini with the ROM so that PGE can know the location of the data.")

            File.Copy(AppPath & "ini\roms.ini", (LoadedROM).Substring(0, LoadedROM.Length - 4) & ".ini", True)


        End If

        Cursor = Cursors.WaitCursor

        'Attack Data

        AttackDataBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 12)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackData", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackDataBuffer) / 2)))
        End If



        countervar = 0

        While countervar < TextBox2.Text
            countervar = countervar + 1

            AttackDataBuffer = AttackDataBuffer & "000000000000000000000000"

        End While

        AttackDataNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackDataBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackDataNewOffset, AttackDataBuffer)

        WriteString(GetINIFileLocation(), header, "AttackData", Hex(AttackDataNewOffset))

        'Repoint Attack Data

        WriteHEX(LoadedROM, &H0001CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H033CE8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03A3F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03A738, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03D2A0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E3F4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E528, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E678, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03E858, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H03FCF0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0400C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H041CF4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H041FA0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0423D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0429C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H042FDC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H043034, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H043334, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H043400, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0434F4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0435D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0436AC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H043780, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0438F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H045784, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04591C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H045B20, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0461D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04626C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04632C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04648C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046508, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046650, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046798, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046910, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0469B8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046A98, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046CE8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046E70, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046F58, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H046FE0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047020, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047100, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04728C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0472EC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047520, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0475A4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0475D4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047684, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0477B8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047820, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0478B4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047A48, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047CF8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H047F90, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H049A08, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H049A40, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04BD08, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04BE4C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04C2F8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04C4D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04C5DC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04C658, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04C828, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04CAD0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04E9F0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04EDFC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H04FE70, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H05028C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0514C0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H051564, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H051894, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H051974, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0521BC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H052434, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H05257C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H052F08, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H052F78, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H053004, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H053A88, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H053BA0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H053BD8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H054894, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H054C58, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H055478, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H055EE0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H057AA0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H057BE0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H057CB8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H059C1C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H05D454, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H05D4CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0620B0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H062100, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H062EF4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H062F40, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H063154, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H063404, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H063E80, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0691DC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H069260, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0694CC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H069578, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0695D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0695F4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H069A8C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H069BEC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H069D48, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H06B9A0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DEAC8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H131CC8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H131D38, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H131E6C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H131F40, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H132090, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1323F8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H132A38, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H132A84, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H132CE8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H132DD0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133088, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1330EC, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133180, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1331D4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H13361C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133648, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H133674, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H17E324, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H17F1A4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H17F264, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H18FFF8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H193FB4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1AE384, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1AE3D0, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1AE454, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1BDB60, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3C94, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3CD4, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C4058, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C4464, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C453C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1D2A2C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000)))

        WriteHEX(LoadedROM, &H38850, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H389F8, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H69188, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H69230, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))
        WriteHEX(LoadedROM, &H6B82C, ReverseHEX(Hex((AttackDataNewOffset) + &H8000000 + 4)))


        'Attack Names

        AttackNamesBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 13)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackNames", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackNamesBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox2.Text
            countervar = countervar + 1

            AttackNamesBuffer = AttackNamesBuffer & "ACACACACACACACFF0000000000"

        End While


        AttackNamesNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackNamesBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackNamesNewOffset, AttackNamesBuffer)

        WriteString(GetINIFileLocation(), header, "AttackNames", Hex(AttackNamesNewOffset))

        'Repoint Attack Names

        WriteHEX(LoadedROM, &H000148, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H059B14, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H079B54, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H09B18C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D85F8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D8F34, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D9A90, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D9E50, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D9F38, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DD4CC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E0C1C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F1900, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F2F8C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F3260, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F3330, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F378C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F4278, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F457C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F4758, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F47E0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F480C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F4830, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0F4870, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0FE014, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H11EB9C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H139908, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H13ACB4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H13ACE4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H14E554, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H14EF94, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H14F730, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H160B54, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H160DFC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H161048, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H16136C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H16481C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1930B4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1A0618, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1A10D8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1A10F0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1AB3F8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B6AB0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B6CB0, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B6E60, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B6F4C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B71C4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B7280, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B7354, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B73D4, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B78FC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B798C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B7EE8, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1B976C, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3BEC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3FCC, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C4050, ReverseHEX(Hex((AttackNamesNewOffset) + &H8000000)))

        'Repoint Field Move names

        WriteHEX(LoadedROM, &H615CA8, ReverseHEX(Hex((AttackNamesNewOffset + (148 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CA0, ReverseHEX(Hex((AttackNamesNewOffset + (15 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CC8, ReverseHEX(Hex((AttackNamesNewOffset + (19 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CB8, ReverseHEX(Hex((AttackNamesNewOffset + (70 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CC0, ReverseHEX(Hex((AttackNamesNewOffset + (57 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CB0, ReverseHEX(Hex((AttackNamesNewOffset + (249 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CD8, ReverseHEX(Hex((AttackNamesNewOffset + (127 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CD0, ReverseHEX(Hex((AttackNamesNewOffset + (291 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CE0, ReverseHEX(Hex((AttackNamesNewOffset + (100 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CE8, ReverseHEX(Hex((AttackNamesNewOffset + (91 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CF0, ReverseHEX(Hex((AttackNamesNewOffset + (290 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615CF8, ReverseHEX(Hex((AttackNamesNewOffset + (208 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615D00, ReverseHEX(Hex((AttackNamesNewOffset + (135 * 13)) + &H8000000)))
        WriteHEX(LoadedROM, &H615D08, ReverseHEX(Hex((AttackNamesNewOffset + (230 * 13)) + &H8000000)))


        'Attack Animations


        AttackAnimationTableBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackAnimationTable", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 4)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackAnimationTable", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackAnimationTableBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox2.Text
            countervar = countervar + 1

            AttackAnimationTableBuffer = AttackAnimationTableBuffer & "98932C08"

        End While


        AttackAnimationTableNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackAnimationTableBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackAnimationTableNewOffset, AttackAnimationTableBuffer)

        WriteString(GetINIFileLocation(), header, "AttackAnimationTable", Hex(AttackAnimationTableNewOffset))

        'Repoint Attack Animation Table

        WriteHEX(LoadedROM, &HA3A44, ReverseHEX(Hex((AttackAnimationTableNewOffset) + &H8000000)))

        'Attack Descriptions

        AttackDescriptionTableBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", ""))) * 4)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "AttackDescriptionTable", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(AttackDescriptionTableBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox2.Text
            countervar = countervar + 1

            AttackDescriptionTableBuffer = AttackDescriptionTableBuffer & "C1816108"

        End While


        AttackDescriptionTableNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(AttackDescriptionTableBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, AttackDescriptionTableNewOffset, AttackDescriptionTableBuffer)

        WriteString(GetINIFileLocation(), header, "AttackDescriptionTable", Hex(AttackDescriptionTableNewOffset))

        'Repoint Attack Description Table

        WriteHEX(LoadedROM, &H1C3EFC, ReverseHEX(Hex((AttackDescriptionTableNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1D2AC8, ReverseHEX(Hex((AttackDescriptionTableNewOffset) + &H8000000)))

        'Contest Data


        ContestDataBuffer = ReadHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveData", "")), System.Globalization.NumberStyles.HexNumber), ((GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1) * 8)

        'Deletes old data

        If CheckBox3.Checked Then
            WriteHEX(LoadedROM, Int32.Parse((GetString(GetINIFileLocation(), header, "ContestMoveData", "")), System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((Len(ContestDataBuffer) / 2)))
        End If

        countervar = 0

        While countervar < TextBox2.Text
            countervar = countervar + 1

            ContestDataBuffer = ContestDataBuffer & "0000000000000000"

        End While


        ContestDataNewOffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(ContestDataBuffer) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

        WriteHEX(LoadedROM, ContestDataNewOffset, ContestDataBuffer)

        WriteString(GetINIFileLocation(), header, "ContestMoveData", Hex(ContestDataNewOffset))

        'Repoint contest data

        WriteHEX(LoadedROM, &H0D85F0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0D9B1C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DB318, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DB3F0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DB45C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DB4D8, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DD10C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DD2D0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DD4D0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0DDA18, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E5468, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E59AC, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E5BC8, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E5E58, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E5EB0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E6204, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E629C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E67B0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H0E697C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H156F3C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H157010, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H15710C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1571E0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H15729C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H157408, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H157B30, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H158104, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1583B4, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H161414, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1614AC, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C247C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3E98, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C3F2C, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C44D0, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1C4564, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))
        WriteHEX(LoadedROM, &H1D2BC4, ReverseHEX(Hex((ContestDataNewOffset) + &H8000000)))

        'Only limiter in ROM patch

        WriteHEX(LoadedROM, &H14E504, "00000000000013E0")

        'contest limiters

        WriteHEX(LoadedROM, &HD8F0C, "0000000000000000")
        WriteHEX(LoadedROM, &HDE83A, "00000000000000E0")

        'Move Table hack stuff
        If CheckBox4.Checked And GetString(GetINIFileLocation(), header, "MoveTableHack", "False").ToLower() = "False".ToLower() Then

            'Converts the table to the new format

            Dim pokeloopcounter As Integer = 1
            Dim AttackTable As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "PokemonAttackTable", "")), System.Globalization.NumberStyles.HexNumber)
            Dim CurLvlUpAttPointer As String = ""
            Dim newmovesoffset As String = ""

            Dim CurAttacksLooper As Integer

            Dim TempLoadBuff As Integer
            Dim binarybuffer As String
            Dim at As String
            Dim lvl As String

            Dim CurPokeAttacksBuff As String


            MsgBox("Movesets will now be converted. This will take a while...")

            While (pokeloopcounter < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")))

                CurLvlUpAttPointer = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, (AttackTable) + (pokeloopcounter * 4), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

                CurAttacksLooper = 0
                CurPokeAttacksBuff = ""

                While ReadHEX(LoadedROM, Int32.Parse((CurLvlUpAttPointer), System.Globalization.NumberStyles.HexNumber) + (CurAttacksLooper * 2), 2) = "FFFF" = False

                    TempLoadBuff = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse((CurLvlUpAttPointer), System.Globalization.NumberStyles.HexNumber) + (CurAttacksLooper * 2), 2))), System.Globalization.NumberStyles.HexNumber)

                    binarybuffer = Convert.ToString(TempLoadBuff, 2)

                    While Len(binarybuffer) < 16

                        binarybuffer = "0" & binarybuffer

                    End While

                    lvl = Mid(binarybuffer, 1, 7)

                    at = Mid(binarybuffer, 8, 9)

                    lvl = Convert.ToInt32(lvl, 2)

                    at = Convert.ToInt32(at, 2)

                    lvl = VB.Right("00" & Hex(lvl), 2)
                    at = ReverseHEX(VB.Right("0000" & Hex(at), 4))


                    CurPokeAttacksBuff = CurPokeAttacksBuff & at & lvl

                    CurAttacksLooper = CurAttacksLooper + 1
                End While

                If CurAttacksLooper = 0 Then
                    CurPokeAttacksBuff = CurPokeAttacksBuff & "0100" & "01"
                End If

                'deletes the old moves

                If CheckBox3.Checked Then
                    WriteHEX(LoadedROM, Int32.Parse(CurLvlUpAttPointer, System.Globalization.NumberStyles.HexNumber), MakeFreeSpaceString((CurAttacksLooper * 2)))
                End If

                CurPokeAttacksBuff = CurPokeAttacksBuff & "0000FF00"

                newmovesoffset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(CurPokeAttacksBuff) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

                WriteHEX(LoadedROM, (AttackTable) + (pokeloopcounter * 4), ReverseHEX(Hex((newmovesoffset) + &H8000000)))

                WriteHEX(LoadedROM, newmovesoffset, CurPokeAttacksBuff)

                pokeloopcounter = pokeloopcounter + 1
            End While

            'Write the routines

            Dim routine1 As String = "494689001148401800680F4E063637787900C9194318997854468C4203D0FF290BD00137F4E7084A01373770597809021878084310800249084702480047C046F593060803940608E2440202" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine2 As String = "8178FF22914225D01202FF32914600235800C0181949891909684718B8785446A04217DC7978387809020143404600930C1C00F017F8FF25009B484504D14046211C00F013F8009B0133032178188078A842DDD101B038BC9846A146AA46F0BC01BC0047F0B581B0024F3847F0B5024F3847C04645910608D3940608" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine3 As String = "00253D4EB9008A19136898780591FF2868D09146049303226A4304995018171C017843781B020B43807803990135AC4688424BDC002468460188181C814211D005982D4946186B463D1C02330134032C08DC3068281801784078000208431A888242F2D1042C31D1002454451CDA4946086838180178407800020843029A1288824211D005991C4A8E18029B3D1C02330134544508DA3068281801784078000208431A888242F2D154450FD1504601300006000E82466200029952184C4620683818017840780002084310806546132D08DC4946086803216943091808888878FF2898D1504606B038BC9846A146AA46F0BC02BC0847C046" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine4 As String = "F0B557464E464546E0B48FB0061C00208246301C41210022524B00F0A1F80004040C301C382100224E4B00F099F80006000E0C90CE204000844201D1002087E00025A4000E946C46291C0D31301C0022444B00F085F8208002340135032DF3DD0025414B0E9AD11808688078FF286ED089466C4608340D944946086803226A43101880780C9C211C171C0135AC46884252DC002448460068017840780002084369460988814211D00E982F4946186B463D1C02330134032C08DC3068281801784078000208431A888242F2D1042C33D1002454451EDA49460868381801784078000201430D980288081C02A9824211D00E9A1D4816180B1C3D1C02330134544508DA3068281801784078000208431A888242F2D154450FD1504601300006000E824662000D9CA218494608683818017840780002084310806546132D07DC4A4610680321694309188878FF2894D150460FB038BC9846A146AA46F0BC02BC08471847C04619A50608" & ReverseHEX(Hex(AttackTable + &H8000000))
            Dim routine5 As String = "0321484319684018817801480047C04695930608"
            Dim routine6 As String = "F0B50E1C0004002500241049800B401802689078FF2812D0131C291C481C0006050E490089191A78587800021043088003330134132C02DC9878FF28EDD1281CF0BC02BC0847C046" & ReverseHEX(Hex(AttackTable + &H8000000))

            Dim routine1offset As String = ""
            Dim routine2offset As String = ""
            Dim routine3offset As String = ""
            Dim routine4offset As String = ""
            Dim routine5offset As String = ""
            Dim routine6offset As String = ""

            routine1offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine1) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine1offset, routine1)

            WriteHEX(LoadedROM, &H693B0, "18490847")
            WriteHEX(LoadedROM, &H69414, ReverseHEX(Hex((routine1offset) + &H8000001)))

            routine2offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine2) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine2offset, routine2)

            WriteHEX(LoadedROM, &H692A0, "00490847" & ReverseHEX(Hex((routine2offset) + &H8000001)))

            routine3offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine3) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine3offset, routine3)

            WriteHEX(LoadedROM, &H6E100, "00490847" & ReverseHEX(Hex((routine3offset) + &H8000001)))

            routine4offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine4) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine4offset, routine4)

            WriteHEX(LoadedROM, &H6E25C, "004B1847" & ReverseHEX(Hex((routine4offset) + &H8000001)))


            routine5offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine5) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine5offset, routine5)

            WriteHEX(LoadedROM, &H69364, "8078C046C046C046C046")
            WriteHEX(LoadedROM, &H69394, "FF29")
            WriteHEX(LoadedROM, &H69372, "5446C046")
            WriteHEX(LoadedROM, &H693A8, "081CC046")
            WriteHEX(LoadedROM, &H6938C, "00490847" & ReverseHEX(Hex((routine5offset) + &H8000001)))

            WriteHEX(LoadedROM, &H6E204, routine6)


            '    'Enable the hack in the ini file.
            WriteString(GetINIFileLocation(), header, "MoveTableHack", "True")

        End If

        'Updates the number of attacks
        WriteString(GetINIFileLocation(), header, "NumberOfAttacks", CInt((GetString(GetINIFileLocation(), header, "NumberOfAttacks", ""))) + CInt(TextBox2.Text))

        Label4.Text = "Number of attacks in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1

        Cursor = Cursors.Arrow

        MsgBox("Attacks added successfully!")
    End Sub

End Class