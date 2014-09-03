Option Strict Off
Option Explicit Off
Imports VB = Microsoft.VisualBasic
Public Class movetutor2


    Dim Offset As Integer
    'Dim Offset2 As Long

    Private Sub movetutor2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        If header2 = "BPR" Or header2 = "BPG" Or header2 = "BPE" Then

            Combo1.Enabled = True 'enables the combo boxes
            Combo2.Enabled = True
            Combo3.Enabled = True
            Combo4.Enabled = True
            Combo5.Enabled = True
            Combo6.Enabled = True
            Combo7.Enabled = True
            Combo8.Enabled = True
            Combo9.Enabled = True
            Combo10.Enabled = True
            Combo11.Enabled = True
            Combo12.Enabled = True
            Combo13.Enabled = True
            Combo14.Enabled = True
            Combo15.Enabled = True
            Combo16.Enabled = True

            If header2 = "BPE" Then

                ComboBox1.Enabled = True 'enables the ComboBox boxes
                ComboBox2.Enabled = True
                ComboBox3.Enabled = True
                ComboBox4.Enabled = True
                ComboBox5.Enabled = True
                ComboBox6.Enabled = True
                ComboBox7.Enabled = True
                ComboBox8.Enabled = True
                ComboBox9.Enabled = True
                ComboBox10.Enabled = True
                ComboBox11.Enabled = True
                ComboBox12.Enabled = True
                ComboBox13.Enabled = True
                ComboBox14.Enabled = True
                ComboBox15.Enabled = True
                ComboBox16.Enabled = True
            End If

            Button2.Enabled = True

            Combo1.Items.Clear() 'Clears the combo boxes
            Combo2.Items.Clear()
            Combo3.Items.Clear()
            Combo4.Items.Clear()
            Combo5.Items.Clear()
            Combo6.Items.Clear()
            Combo7.Items.Clear()
            Combo8.Items.Clear()
            Combo9.Items.Clear()
            Combo10.Items.Clear()
            Combo11.Items.Clear()
            Combo12.Items.Clear()
            Combo13.Items.Clear()
            Combo14.Items.Clear()
            Combo15.Items.Clear()
            Combo16.Items.Clear()

            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox5.Items.Clear()
            ComboBox6.Items.Clear()
            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            ComboBox9.Items.Clear()
            ComboBox10.Items.Clear()
            ComboBox11.Items.Clear()
            ComboBox12.Items.Clear()
            ComboBox13.Items.Clear()
            ComboBox14.Items.Clear()
            ComboBox15.Items.Clear()
            ComboBox16.Items.Clear()

            Offset = Int32.Parse((GetString("ini\roms.ini", header, "MoveTutorAttacks", "")), System.Globalization.NumberStyles.HexNumber)


            Dim loopything As String = 0

            Dim curattack As String

            While loopything < (Val(GetString("ini\roms.ini", header, "NumberOfAttacks", "")) + 1)


                curattack = GetAttackName(loopything)

                Combo1.Items.Add(curattack) 'adds the attacks to the comboboxes
                Combo2.Items.Add(curattack)
                Combo3.Items.Add(curattack)
                Combo4.Items.Add(curattack)
                Combo5.Items.Add(curattack)
                Combo6.Items.Add(curattack)
                Combo7.Items.Add(curattack)
                Combo8.Items.Add(curattack)
                Combo9.Items.Add(curattack)
                Combo10.Items.Add(curattack)
                Combo11.Items.Add(curattack)
                Combo12.Items.Add(curattack)
                Combo13.Items.Add(curattack)
                Combo14.Items.Add(curattack)
                Combo15.Items.Add(curattack)
                Combo16.Items.Add(curattack)

                If header2 = "BPE" Then

                    ComboBox1.Items.Add(curattack)
                    ComboBox2.Items.Add(curattack)
                    ComboBox3.Items.Add(curattack)
                    ComboBox4.Items.Add(curattack)
                    ComboBox5.Items.Add(curattack)
                    ComboBox6.Items.Add(curattack)
                    ComboBox7.Items.Add(curattack)
                    ComboBox8.Items.Add(curattack)
                    ComboBox9.Items.Add(curattack)
                    ComboBox10.Items.Add(curattack)
                    ComboBox11.Items.Add(curattack)
                    ComboBox12.Items.Add(curattack)
                    ComboBox13.Items.Add(curattack)
                    ComboBox14.Items.Add(curattack)
                    ComboBox15.Items.Add(curattack)
                    ComboBox16.Items.Add(curattack)
                End If
                loopything = loopything + 1
            End While


            Combo1.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 1, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo3.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 3, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo4.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 5, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo5.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 7, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo6.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 9, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo7.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 11, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo8.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 13, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo9.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 15, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo10.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 17, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo11.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 19, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo12.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 21, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo13.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 23, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo14.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 25, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo15.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 27, 2)))), System.Globalization.NumberStyles.HexNumber)
            Combo16.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 29, 2)))), System.Globalization.NumberStyles.HexNumber)

            If header2 = "BPE" Then

                ComboBox1.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 31, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox2.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 33, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox3.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 35, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox4.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 37, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox5.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 39, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox6.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 41, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox7.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 43, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox8.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 45, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox9.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 47, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox10.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 49, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox11.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 51, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox12.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 53, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox13.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 55, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox14.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 57, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox15.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 59, 2)))), System.Globalization.NumberStyles.HexNumber)
                ComboBox16.SelectedIndex = Int32.Parse(((ReverseHEX(ReadHEX(LoadedROM, Offset + 61, 2)))), System.Globalization.NumberStyles.HexNumber)

            End If

            Me.Cursor = Cursors.Arrow
            'MainFrm.Visible = False

        Else
Label2:
            'If the ROM is not supported this code will run
            Combo1.Enabled = False
            Combo2.Enabled = False
            Combo3.Enabled = False
            Combo4.Enabled = False
            Combo5.Enabled = False
            Combo6.Enabled = False
            Combo7.Enabled = False
            Combo8.Enabled = False
            Combo9.Enabled = False
            Combo10.Enabled = False
            Combo11.Enabled = False
            Combo12.Enabled = False
            Combo13.Enabled = False
            Combo14.Enabled = False
            Combo15.Enabled = False
            Combo16.Enabled = False

            Button2.Enabled = False

            Combo1.Items.Clear() 'Clears the combo boxes
            Combo2.Items.Clear()
            Combo3.Items.Clear()
            Combo4.Items.Clear()
            Combo5.Items.Clear()
            Combo6.Items.Clear()
            Combo7.Items.Clear()
            Combo8.Items.Clear()
            Combo9.Items.Clear()
            Combo10.Items.Clear()
            Combo11.Items.Clear()
            Combo12.Items.Clear()
            Combo13.Items.Clear()
            Combo14.Items.Clear()
            Combo15.Items.Clear()
            Combo16.Items.Clear()

            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            ComboBox5.Enabled = False
            ComboBox6.Enabled = False
            ComboBox7.Enabled = False
            ComboBox8.Enabled = False
            ComboBox9.Enabled = False
            ComboBox10.Enabled = False
            ComboBox11.Enabled = False
            ComboBox12.Enabled = False
            ComboBox13.Enabled = False
            ComboBox14.Enabled = False
            ComboBox15.Enabled = False
            ComboBox16.Enabled = False

            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            ComboBox3.Items.Clear()
            ComboBox4.Items.Clear()
            ComboBox5.Items.Clear()
            ComboBox6.Items.Clear()
            ComboBox7.Items.Clear()
            ComboBox8.Items.Clear()
            ComboBox9.Items.Clear()
            ComboBox10.Items.Clear()
            ComboBox11.Items.Clear()
            ComboBox12.Items.Clear()
            ComboBox13.Items.Clear()
            ComboBox14.Items.Clear()
            ComboBox15.Items.Clear()
            ComboBox16.Items.Clear()

            MsgBox("Unsupported ROM!")
            'Lets the person know the ROM isn't supported.
            End
        End If
   
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If header3 = "J" Then
            MessageBox.Show("Support for this language has not been added yet!")
            End

        Else

            WriteHEX(LoadedROM, Offset - 1, ReverseHEX(VB.Right("0000" & Hex(Combo1.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 2, ReverseHEX(VB.Right("0000" & Hex(Combo2.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 4, ReverseHEX(VB.Right("0000" & Hex(Combo3.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 6, ReverseHEX(VB.Right("0000" & Hex(Combo4.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 8, ReverseHEX(VB.Right("0000" & Hex(Combo5.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 10, ReverseHEX(VB.Right("0000" & Hex(Combo6.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 12, ReverseHEX(VB.Right("0000" & Hex(Combo7.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 14, ReverseHEX(VB.Right("0000" & Hex(Combo8.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 16, ReverseHEX(VB.Right("0000" & Hex(Combo9.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 18, ReverseHEX(VB.Right("0000" & Hex(Combo10.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 20, ReverseHEX(VB.Right("0000" & Hex(Combo11.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 22, ReverseHEX(VB.Right("0000" & Hex(Combo12.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 24, ReverseHEX(VB.Right("0000" & Hex(Combo13.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 26, ReverseHEX(VB.Right("0000" & Hex(Combo14.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 28, ReverseHEX(VB.Right("0000" & Hex(Combo15.SelectedIndex), 4)))
            WriteHEX(LoadedROM, Offset - 1 + 30, ReverseHEX(VB.Right("0000" & Hex(Combo16.SelectedIndex), 4)))

            If header2 = "BPE" Then
                WriteHEX(LoadedROM, Offset - 1 + 32, ReverseHEX(VB.Right("0000" & Hex(ComboBox1.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 34, ReverseHEX(VB.Right("0000" & Hex(ComboBox2.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 36, ReverseHEX(VB.Right("0000" & Hex(ComboBox3.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 38, ReverseHEX(VB.Right("0000" & Hex(ComboBox4.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 40, ReverseHEX(VB.Right("0000" & Hex(ComboBox5.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 42, ReverseHEX(VB.Right("0000" & Hex(ComboBox6.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 44, ReverseHEX(VB.Right("0000" & Hex(ComboBox7.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 46, ReverseHEX(VB.Right("0000" & Hex(ComboBox8.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 48, ReverseHEX(VB.Right("0000" & Hex(ComboBox9.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 50, ReverseHEX(VB.Right("0000" & Hex(ComboBox10.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 52, ReverseHEX(VB.Right("0000" & Hex(ComboBox11.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 54, ReverseHEX(VB.Right("0000" & Hex(ComboBox12.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 56, ReverseHEX(VB.Right("0000" & Hex(ComboBox13.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 58, ReverseHEX(VB.Right("0000" & Hex(ComboBox14.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 60, ReverseHEX(VB.Right("0000" & Hex(ComboBox15.SelectedIndex), 4)))
                WriteHEX(LoadedROM, Offset - 1 + 62, ReverseHEX(VB.Right("0000" & Hex(ComboBox16.SelectedIndex), 4)))
            End If

        End If
    End Sub


End Class