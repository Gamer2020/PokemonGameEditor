Option Strict Off
Option Explicit On
Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class AttackExpander
    Private Sub AttackExpander_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If header2 = "BPE" Then

            TabControl1.TabPages(0).Enabled = False
            TabControl1.TabPages(1).Enabled = True


            MsgBox("Not added yet!")

            Me.Close()

        ElseIf header2 = "BPR" Then

            TabControl1.TabPages(0).Enabled = True
            TabControl1.TabPages(1).Enabled = False

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

        WriteHEX(LoadedROM, &HD75FC, "000000000000")

        'Move Table hack stuff
        If CheckBox1.Checked And GetString(GetINIFileLocation(), header, "MoveTableHack", "False") = "False" Then

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
            Dim routine3 As String = "6A0052190499501880780399171C0135AC46884249DC0024814214D00124644205982B4946186B46023B3D1C02330134032C08DC3068281802784078000210431A889042F2D1042C2FD1002454451CDA494608683818027841780902114302980288914211D00599194A8E18029B3D1C02330134544508DA3068281802784078000210431A889042F2D154450DD15046013082466200029952184C4620683818017840780002084310806546494608686900491909188878FF28A1D1504606B038BC9846A146AA46F0BC02BC0847C046" & ReverseHEX(Hex(AttackTable + &H8000000))

            Dim routine1offset As String = ""
            Dim routine2offset As String = ""
            Dim routine3offset As String = ""

            routine1offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine1) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine1offset, routine1)

            WriteHEX(LoadedROM, &H3EB20, "18490847")
            WriteHEX(LoadedROM, &H3EB84, ReverseHEX(Hex((routine1offset) + &H8000001)))

            routine2offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine2) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine2offset, routine2)

            WriteHEX(LoadedROM, &H3EA10, "00490847" & ReverseHEX(Hex((routine2offset) + &H8000001)))

            routine3offset = SearchFreeSpaceFourAligned(LoadedROM, &HFF, ((Len(routine3) / 2)), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))

            WriteHEX(LoadedROM, routine3offset, routine3)

            WriteHEX(LoadedROM, &H43CE8, "004A1047" & ReverseHEX(Hex((routine3offset) + &H8000001)))

            'Enable the hack in the ini file.
            WriteString(GetINIFileLocation(), header, "MoveTableHack", "True")

        End If

        'Updates the number of attacks
        WriteString(GetINIFileLocation(), header, "NumberOfAttacks", CInt((GetString(GetINIFileLocation(), header, "NumberOfAttacks", ""))) + CInt(TextBox1.Text))

        Label1.Text = "Number of attacks in ROM: " & (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1

        Cursor = Cursors.Arrow

        MsgBox("Attacks expanded successfully!")

    End Sub
End Class