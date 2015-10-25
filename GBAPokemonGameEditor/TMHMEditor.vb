Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic
Public Class TMHMEditor
    Dim TMHMAttacks As Integer
    Private Sub TMHMEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LoopVar As Integer

        TMHMAttacks = Int32.Parse((GetString(AppPath & "ini\roms.ini", header, "TMData", "")), System.Globalization.NumberStyles.HexNumber)

        TMHMList.Items.Clear()


        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then

            LoopVar = 0

            While LoopVar < 58 = True

                If LoopVar > 49 Then
                    TMHMList.Items.Add("HM" & LoopVar - 49 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1

                ElseIf LoopVar < 9 Then

                    TMHMList.Items.Add("TM" & "0" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1
                Else

                    TMHMList.Items.Add("TM" & LoopVar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((LoopVar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    LoopVar = LoopVar + 1
                End If
            End While
        End If

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 1 Then
            MsgBox("I'm sorry but this does not support Jambo51's TM/HM hack yet.")

        End If

        AttackList.Items.Clear()

        LoopVar = 0

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfAttacks", "")) + 1 = True


            AttackList.Items.Add(GetAttackName(LoopVar))


            LoopVar = LoopVar + 1

        End While

        TMHMList.SelectedIndex = 0

    End Sub

    Private Sub TMHMList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TMHMList.SelectedIndexChanged
        AttackList.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((TMHMList.SelectedIndex) * 2), 2))), System.Globalization.NumberStyles.HexNumber)
    End Sub

    Private Sub SvBttn_Click(sender As Object, e As EventArgs) Handles SvBttn.Click
        Dim indexbuf As Integer
        Dim loopvar As Integer

        indexbuf = TMHMList.SelectedIndex

        WriteHEX(LoadedROM, TMHMAttacks + ((indexbuf) * 2), ReverseHEX(VB.Right("0000" & Hex(AttackList.SelectedIndex), 4)))

        TMHMList.Items.Clear()

        If GetString(AppPath & "GBAPGESettings.ini", "Settings", "jamboTMextensionHack", "0") = 0 Then

            loopvar = 0

            While loopvar < 58 = True

                If loopvar > 49 Then
                    TMHMList.Items.Add("HM" & loopvar - 49 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    loopvar = loopvar + 1

                ElseIf loopvar < 9 Then

                    TMHMList.Items.Add("TM" & "0" & loopvar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    loopvar = loopvar + 1
                Else

                    TMHMList.Items.Add("TM" & loopvar + 1 & " - " & GetAttackName(Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, TMHMAttacks + ((loopvar) * 2), 2))), System.Globalization.NumberStyles.HexNumber)))

                    loopvar = loopvar + 1
                End If
            End While
        End If

        TMHMList.SelectedIndex = indexbuf

    End Sub
End Class