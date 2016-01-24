Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Public Class movetutor2


    Dim Offset As Integer
    'Dim Offset2 As Long

    Private Sub movetutor2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            Offset = Int32.Parse((GetString(GetINIFileLocation(), header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)


            Dim loopything As String = 0

            Dim curattack As String

            Combo1.Items.Clear() 'Clears the combo boxes

            While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1)


                curattack = GetAttackName(loopything)

                Combo1.Items.Add(curattack) 'adds the attacks to the comboboxes

                loopything = loopything + 1
            End While

            loopything = 0

            ListBox1.Items.Clear()

            While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))

                ListBox1.Items.Add(GetAttackName(Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * loopything), 2)))), System.Globalization.NumberStyles.HexNumber)))

                loopything = loopything + 1
            End While


            Me.Cursor = Cursors.Arrow

            ListBox1.SelectedIndex = 0


        Else

            'If the ROM is not supported this code will run
            Combo1.Enabled = False

            Button2.Enabled = False

            Combo1.Items.Clear() 'Clears the combo boxes


            MsgBox("Unsupported ROM!")
            'Lets the person know the ROM isn't supported.
            End

        End If
   
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim indexbuff As Integer

        indexbuff = ListBox1.SelectedIndex

        WriteHEX(LoadedROM, Offset + (2 * ListBox1.SelectedIndex), ReverseHEX(VB.Right("0000" & Hex(Combo1.SelectedIndex), 4)))

        Dim loopything As String = 0

        ListBox1.Items.Clear()

        While loopything < (Val(GetString(GetINIFileLocation(), header, "NumberOfMoveTutorAttacks", "")))

            ListBox1.Items.Add(GetAttackName(Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * loopything), 2)))), System.Globalization.NumberStyles.HexNumber)))

            loopything = loopything + 1
        End While


        Me.Cursor = Cursors.Arrow

        ListBox1.SelectedIndex = indexbuff

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Combo1.SelectedIndex = ((Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + (2 * ListBox1.SelectedIndex), 2)))), System.Globalization.NumberStyles.HexNumber)))
    End Sub
End Class