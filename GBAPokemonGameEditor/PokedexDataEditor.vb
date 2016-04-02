Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Public Class PokedexDataEditor
    Dim offset1 As Integer
    Dim DexDescripLength1 As Integer
    Dim DexDescripLength2 As Integer

    Private Sub PokedexDataEditor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub EnglishRSDescpLoad()
        Description1.Text = ""
        Description2.Text = ""

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)
        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength1 = Len(DexDescp)

        Description1.Text = DexDescp
        ' Description1.MaxLength = Len(DexDescp)

        DexDescp = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer2.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength2 = Len(DexDescp)

        Description2.Text = DexDescp
        'Description2.MaxLength = Len(DexDescp)

        FileClose(FileNum)
    End Sub

    Private Sub EnglishFRLGEDescpLoad()

        Description1.Text = ""
        Description2.Text = ""

        FileNum = FreeFile()
        FileOpen(FileNum, LoadedROM, OpenMode.Binary)

        Dim DexDescp As String = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"

        FileGet(FileNum, DexDescp, ("&H" & (Pointer1.Text)) + 1, True)
        DexDescp = Sapp2Asc(DexDescp)
        DexDescp = Mid$(DexDescp, 1, InStr(1, DexDescp, "\x"))
        DexDescp = Replace(DexDescp, "\n", vbCrLf)
        DexDescp = Replace(RTrim$(DexDescp), "\", "")

        DexDescripLength1 = Len(DexDescp)

        Description1.Text = DexDescp
        ' Description1.MaxLength = Len(DexDescp)

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

        If header2 = "AXP" Or header2 = "AXV" Then

            Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 26 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 28 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 30 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 32 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)

            Pointer2.Text = Hex(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 8 + +12 + (ListBox1.SelectedIndex * SkipVar), 4))), System.Globalization.NumberStyles.HexNumber) - &H8000000)
            EnglishRSDescpLoad()
        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 26 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 28 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 30 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 32 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


            EnglishFRLGEDescpLoad()
        ElseIf header2 = "BPE" Then

            Scale1.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 22 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_1.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 24 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Scale2.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 26 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)
            Offset_2.Text = Int16.Parse((ReverseHEX(ReadHEX(LoadedROM, offset1 + 28 + (ListBox1.SelectedIndex * SkipVar), 2))), System.Globalization.NumberStyles.HexNumber)


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

        Dim indexbuff As Integer = ListBox1.SelectedIndex

        offset1 = Int32.Parse((GetString(GetINIFileLocation(), header, "PokedexData", "")), System.Globalization.NumberStyles.HexNumber)


        If header2 = "AXP" Or header2 = "AXV" Then

            WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

            WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 30 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 32 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

            WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 30 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 32 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        ElseIf header2 = "BPE" Then

            WriteHEX(LoadedROM, offset1 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Hght.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 2 + 12 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Wght.Text), 4)))

            WriteHEX(LoadedROM, offset1 + 22 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 24 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_1.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 26 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Scale2.Text), 4)))
            WriteHEX(LoadedROM, offset1 + 28 + (indexbuff * SkipVar), ReverseHEX(VB.Right("0000" & Hex(Offset_2.Text), 4)))

        End If

        ChangePokedexTypeName(indexbuff, Type1.Text)

        ListBox1.Items.Clear()

        Dim varloop As Integer = 0

        While varloop < (GetString(GetINIFileLocation(), header, "NumberOfDexEntries", ""))


            ListBox1.Items.Add(VB.Right("0000" & (varloop), 4) & ". " & GetPokedexTypeName(varloop))
            varloop = varloop + 1
        End While

        ListBox1.SelectedIndex = indexbuff

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim indexbuff As Integer = ListBox1.SelectedIndex

        If header3 = "J" Then

            If header2 = "AXP" Or header2 = "AXV" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End

            ElseIf header2 = "BPR" Or header2 = "BPG" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End
            ElseIf header2 = "BPE" Then
                MessageBox.Show("Support for this language has not been added yet!")
                End
            End If

        Else
            If header2 = "AXP" Or header2 = "AXV" Then

                WriteHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & (VB.Right("000000" & (Pointer1.Text), 6))) + &H8000000)))
                WriteHEX(LoadedROM, offset1 + 8 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & (VB.Right("000000" & (Pointer2.Text), 6))) + &H8000000)))

                EnglishRSDescpLoad()

            ElseIf header2 = "BPR" Or header2 = "BPG" Then

                WriteHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & (VB.Right("000000" & (Pointer1.Text), 6))) + &H8000000)))

                EnglishFRLGEDescpLoad()

            ElseIf header2 = "BPE" Then
                WriteHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), ReverseHEX(Hex(Val("&H" & (VB.Right("000000" & (Pointer1.Text), 6))) + &H8000000)))

                EnglishFRLGEDescpLoad()

            End If

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim indexbuff As Integer = ListBox1.SelectedIndex
        Dim Y As String

        Dim Var1 As String
        Dim Var2 As String
        Dim filler As Byte = &H0

        If header2 = "AXP" Or header2 = "AXV" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultR As DialogResult = MessageBox.Show("The text for the first box will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultR = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Label1.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label1.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label1.Text = Label1.Text & " Requires repoint!"

                        Label1.ForeColor = Color.Red

                    End If

                End If

            Else
                FileNum = FreeFile()

                Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var1, False)

                FileClose(FileNum)
            End If


            If DexDescripLength2 < Len(Description2.Text) Then

                Dim resultR2 As DialogResult = MessageBox.Show("The text for the second box will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultR2 = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description2.Text, vbCrLf, "\n") & "\x")

                    Var2 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var2 + 1), False)

                    FileClose(FileNum)

                    Pointer2.Text = Hex(Var2)

                    Label2.Text = "Length: " & Len(Description2.Text) & "/" & DexDescripLength2
                    Label2.ForeColor = Color.Black

                    If Len(Description2.Text) > DexDescripLength2 Then
                        Label2.Text = Label2.Text & " Requires repoint!"

                        Label2.ForeColor = Color.Red

                    End If

                End If

            Else

                FileNum = FreeFile()

                Var2 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offset1 + 8 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description2.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var2, False)

                FileClose(FileNum)

            End If

            Button1.PerformClick()

        ElseIf header2 = "BPR" Or header2 = "BPG" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultBPR As DialogResult = MessageBox.Show("The text will be written to free space and the pointer will be repointed. Would you like to do that?",
                  "Repoint?",
                  MessageBoxButtons.YesNo)

                If (resultBPR = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Button1.PerformClick()

                    Label1.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label1.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label1.Text = Label1.Text & " Requires repoint!"

                        Label1.ForeColor = Color.Red

                    End If

                End If

            Else
                FileNum = FreeFile()

                Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

                FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                FilePut(FileNum, Y, Var1, False)

                FileClose(FileNum)

            End If

        ElseIf header2 = "BPE" Then

            If DexDescripLength1 < Len(Description1.Text) Then

                Dim resultBPE As DialogResult = MessageBox.Show("The text will be written to free space and the pointer will be repointed. Would you like to do that?",
  "Repoint?",
  MessageBoxButtons.YesNo)

                If (resultBPE = DialogResult.Yes) Then

                    Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

                    Var1 = SearchFreeSpaceFourAligned(LoadedROM, &HFF, (Len(Y & " ")), "&H" & GetString(GetINIFileLocation(), header, "StartSearchingForSpaceOffset", "800000"))


                    FileNum = FreeFile()

                    FileOpen(FileNum, LoadedROM, OpenMode.Binary)

                    FilePut(FileNum, Y & " ", "&H" & Hex(Var1 + 1), False)

                    FileClose(FileNum)

                    Pointer1.Text = Hex(Var1)

                    Button1.PerformClick()

                    Label1.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
                    Label1.ForeColor = Color.Black

                    If Len(Description1.Text) > DexDescripLength1 Then
                        Label1.Text = Label1.Text & " Requires repoint!"

                        Label1.ForeColor = Color.Red

                    End If

                End If

            Else

                FileNum = FreeFile()

            Var1 = ("&H" & Hex(Val("&H" & ReverseHEX(ReadHEX(LoadedROM, offset1 + 4 + 12 + (indexbuff * SkipVar), 4))) - &H8000000)) + 1

            FileOpen(FileNum, LoadedROM, OpenMode.Binary)

            Y = Asc2Sapp(Replace(Description1.Text, vbCrLf, "\n") & "\x")

            FilePut(FileNum, Y, Var1, False)

            FileClose(FileNum)

            End If

        End If



    End Sub

    Private Sub Description1_TextChanged(sender As Object, e As EventArgs) Handles Description1.TextChanged
        Label1.Text = "Length: " & Len(Description1.Text) & "/" & DexDescripLength1
        Label1.ForeColor = Color.Black

        If Len(Description1.Text) > DexDescripLength1 Then
            Label1.Text = Label1.Text & " Requires repoint!"

            Label1.ForeColor = Color.Red

        End If

    End Sub

    Private Sub Description2_TextChanged(sender As Object, e As EventArgs) Handles Description2.TextChanged
        Label2.Text = "Length: " & Len(Description2.Text) & "/" & DexDescripLength2
        Label2.ForeColor = Color.Black

        If Len(Description2.Text) > DexDescripLength2 Then
            Label2.Text = Label2.Text & " Requires repoint!"

            Label2.ForeColor = Color.Red

        End If

    End Sub

End Class