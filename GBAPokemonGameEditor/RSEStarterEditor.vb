Option Strict Off
Option Explicit On
Imports System.IO.Directory
Imports System.Windows.Forms.Application
Imports System.Net
Imports VB = Microsoft.VisualBasic

Public Class RSEStarterEditor



    Private Sub RSEStarterEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim LoopVar As Integer

        LoopVar = 0

        Starter1.Items.Clear()
        Starter2.Items.Clear()
        Starter3.Items.Clear()
        Opponent.Items.Clear()

        While LoopVar < (GetString(AppPath & "ini\roms.ini", header, "NumberOfPokemon", "")) - 1 = True


            LoopVar = LoopVar + 1

            Starter1.Items.Add(GetPokemonName(LoopVar))
            Starter2.Items.Add(GetPokemonName(LoopVar))
            Starter3.Items.Add(GetPokemonName(LoopVar))
            Opponent.Items.Add(GetPokemonName(LoopVar))

        End While

        If header2 = "BPE" Then

            If ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 4) = "90214900" Then

                Opponent.SelectedIndex = 288 - 1

            Else

                Opponent.SelectedIndex = ((Int32.Parse(((ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 1))), System.Globalization.NumberStyles.HexNumber) + (Int32.Parse((ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, 1)), System.Globalization.NumberStyles.HexNumber))) - 1)
            End If

            Starter1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 2))), System.Globalization.NumberStyles.HexNumber) - 1
            Starter2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, 2))), System.Globalization.NumberStyles.HexNumber) - 1
            Starter3.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 4, 2))), System.Globalization.NumberStyles.HexNumber) - 1

            OpponentLevel.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), 1))), System.Globalization.NumberStyles.HexNumber)
            StarterLevel.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), 1))), System.Globalization.NumberStyles.HexNumber)



        ElseIf header2 = "AXV" Or header2 = "AXP" Then

            If ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 4) = "8F214900" Then

                Opponent.SelectedIndex = 286 - 1

            Else

                Opponent.SelectedIndex = (Int32.Parse((ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 1)), System.Globalization.NumberStyles.HexNumber) + Int32.Parse((ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, 1)), System.Globalization.NumberStyles.HexNumber)) - 1

            End If

            Starter1.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber), 2))), System.Globalization.NumberStyles.HexNumber) - 1
            Starter2.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, 2))), System.Globalization.NumberStyles.HexNumber) - 1
            Starter3.SelectedIndex = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 4, 2))), System.Globalization.NumberStyles.HexNumber) - 1

            OpponentLevel.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), 1))), System.Globalization.NumberStyles.HexNumber)
            StarterLevel.Text = Int32.Parse((ReverseHEX(ReadHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), 1))), System.Globalization.NumberStyles.HexNumber)
        Else
            MsgBox("Not supported. Use a script editor.")


            Me.Close()
        End If
    End Sub

    Private Sub Opponent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opponent.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(OpoPic, Opponent.SelectedIndex + 1)
    End Sub

    Private Sub Starter1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Starter1.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(Start1Pic, Starter1.SelectedIndex + 1)
    End Sub

    Private Sub Starter2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Starter2.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(Start2Pic, Starter2.SelectedIndex + 1)
    End Sub

    Private Sub Starter3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Starter3.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(Start3Pic, Starter3.SelectedIndex + 1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Opponent.SelectedIndex + 1 > 510 Then
            MsgBox("This pokemon can not be selected as what you ecounter. The number is too high. ASM hack the value in.")
            Exit Sub
        End If


        If Opponent.SelectedIndex + 1 > 255 Then

            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), "FF")
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 1, "21")
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, Hex(Opponent.SelectedIndex - 255 + 1))
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 3, "31")

        ElseIf Opponent.SelectedIndex + 1 < 255 Then
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber), Hex(Opponent.SelectedIndex + 1))
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 1, "21")
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, "00")
            WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 3, "31")

        End If
        WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterEncounterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), Hex(OpponentLevel.Text))
        WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemonLevel", ""), System.Globalization.NumberStyles.HexNumber), Hex(StarterLevel.Text))

        WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber), ReverseHEX(VB.Right("0000" & Hex(Starter1.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 2, ReverseHEX(VB.Right("0000" & Hex(Starter2.SelectedIndex + 1), 4)))
        WriteHEX(LoadedROM, Int32.Parse(GetString(AppPath & "ini\roms.ini", header, "StarterPokemon", ""), System.Globalization.NumberStyles.HexNumber) + 4, ReverseHEX(VB.Right("0000" & Hex(Starter3.SelectedIndex + 1), 4)))

    End Sub
End Class