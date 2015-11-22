Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Public Class PokedexDataEditor
    Dim offset1 As Integer

    Private Sub PokedexDataEditor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub EnglishRSDescpLoad()

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        Description1.Text = DexDescp
        Description1.MaxLength = Len(DexDescp)

        DexDescp = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer2.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        Description2.Text = DexDescp
        Description2.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub

    Private Sub EnglishFRLGEDescpLoad()

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)

        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")
        Description1.Text = DexDescp
        Description1.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub
    Private Sub PokedexDataEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Or header2 = "AXP" Or header2 = "AXV" Then

           

            If header2 = "AXP" Or header2 = "AXV" Then
                Pointer2.Enabled = True
                Description2.Enabled = True
            Else
                Pointer2.Enabled = False
                Description2.Enabled = False
            End If

            ListBox1.Items.Clear()

            offset1 = Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber)

            Dim varloop As Integer = 0

            While varloop < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", ""))


                ListBox1.Items.Add(VB.Right("0000" & (varloop), 4) & ". " & GetPokedexTypeName(varloop))
                varloop = varloop + 1
            End While

            ListBox1.SelectedIndex = 0

        Else

            MsgBox("Unsupported ROM! Check the ReadMe!")
            'Lets the person know the ROM isn't supported.

            Me.Close()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        If header3 = "J" Then

            If header2 = "AXP" Or header2 = "AXV" Then
                SkipVar = "36"
            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                SkipVar = "36"
            ElseIf header2 = "BPE" Then
                SkipVar = "32"
            End If

        Else
            If header2 = "AXP" Or header2 = "AXV" Then
                SkipVar = "36"
            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                SkipVar = "36"
            ElseIf header2 = "BPE" Then
                SkipVar = "32"
            End If
        End If

        Pointer1.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 4 + +12 + (ListBox1.SelectedIndex * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)

        Hght.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
        Wght.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 2 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
        Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 14 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
        Offset_1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 16 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
        Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 18 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
        Offset_2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 20 + 12 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

        If header2 = "AXP" Or header2 = "AXV" Then
            Pointer2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 8 + +12 + (ListBox1.SelectedIndex * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            EnglishRSDescpLoad()
        ElseIf header2 = "BPR" Or header2 = "BPG" Then
            EnglishFRLGEDescpLoad()
        ElseIf header2 = "BPE" Then
            EnglishFRLGEDescpLoad()
        End If


        Type1.Text = GetPokedexTypeName(ListBox1.SelectedIndex)



    End Sub

    Private Sub Hght_TextChanged(sender As Object, e As EventArgs) Handles Hght.TextChanged
        If Val(Hght.Text) > 304 Then Hght.Text = 304
        If Val(Hght.Text) < 0 Then Hght.Text = 0

        Label16.Text = Val(Hght.Text) / 10

        Label17.Text = Val(Label16.Text) * 3.281
    End Sub

    Private Sub Wght_TextChanged(sender As Object, e As EventArgs) Handles Wght.TextChanged
        If Val(Wght.Text) > 21474 Then Wght.Text = 21474
        If Val(Wght.Text) < 0 Then Wght.Text = 0

        Label18.Text = Val(Wght.Text) / 10

        Label19.Text = Val(Label18.Text) * 2.2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        i = ListBox1.SelectedIndex
        offset1 = Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber)


        If header2 = "AXP" Or header2 = "AXV" Then

            WriteHEX(LoadedROM, offset1 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 14 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 16 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 18 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 20 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            WriteHEX(LoadedROM, offset1 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 14 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 16 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 18 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 20 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        ElseIf header2 = "BPE" Then

            WriteHEX(LoadedROM, offset1 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 10 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 12 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 14 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 16 + 12 + (i * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        End If

        ChangePokedexTypeName(i, Type1.Text)

        ListBox1.Items.Clear()

        Dim varloop As Integer = 0

        While varloop < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", ""))


            ListBox1.Items.Add(VB.Right("0000" & (varloop), 4) & ". " & GetPokedexTypeName(varloop))
            varloop = varloop + 1
        End While
        ListBox1.SelectedIndex = 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class