Imports System.IO
Imports VB = Microsoft.VisualBasic

Public Class EggMoveEditor

    Dim EggMoveList As List(Of Integer)

    Private Sub EggMoveEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim Looper As Integer
        Dim CurEntry As Integer

        ListBox1.Items.Clear()

        Looper = 0

        EggMoveList = New List(Of Integer)

        Dim sOffset As Integer = Int32.Parse((GetString(GetINIFileLocation(), header, "EggMoveTable", "")), System.Globalization.NumberStyles.HexNumber)
        Dim EggMoveString As String = ""

        Using fs As New FileStream(LoadedROM, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)

                fs.Position = sOffset

                Do
                    EggMoveString += VB.Right("0000" & Hex(Int32.Parse(r.ReadInt16)), 4)
                Loop While EggMoveString.Substring(EggMoveString.Length - 4, 4).CompareTo("FFFF") <> 0

            End Using
        End Using

        While EggMoveString.Substring(Looper * 4, 4) = "FFFF" = False

            CurEntry = Int32.Parse(EggMoveString.Substring(Looper * 4, 4), System.Globalization.NumberStyles.HexNumber)

            If CurEntry > 20000 Then

                ListBox1.Items.Add(GetPokemonName(CurEntry - 20000))

            Else

                ListBox1.Items.Add("     " & GetAttackName(CurEntry))

            End If

            EggMoveList.Add(CurEntry)
            Looper = Looper + 1
        End While


        Looper = 0

        ComboBox1.Items.Clear()

        While Looper < (GetString(GetINIFileLocation(), header, "NumberOfPokemon", "")) - 1 = True


            Looper = Looper + 1

            ComboBox1.Items.Add(GetPokemonName(Looper))

        End While


        Looper = 0

        ComboBox2.Items.Clear()

        While Looper < (GetString(GetINIFileLocation(), header, "NumberOfAttacks", "")) + 1 = True


            ComboBox2.Items.Add(GetAttackName(Looper))


            Looper = Looper + 1

        End While
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ListBox1.SelectedIndex = 0

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        GetAndDrawFrontPokemonPic(FrntPic, ComboBox1.SelectedIndex + 1)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged() Handles ListBox1.SelectedIndexChanged
        Dim CurEntry As Integer

        CurEntry = EggMoveList(ListBox1.SelectedIndex)

        If CurEntry > 20000 Then

            ComboBox1.SelectedIndex = ((CurEntry - 20000) - 1)

        Else

            ComboBox2.SelectedIndex = CurEntry

            Dim tempLoop As Integer = ListBox1.SelectedIndex
            Dim tempBuffer As Integer = CurEntry


            While tempLoop >= 0 And tempBuffer < 20000
                tempBuffer = EggMoveList(tempLoop)
                tempLoop -= 1
            End While

            If tempBuffer > 20000 Then
                ComboBox1.SelectedIndex = ((tempBuffer - 20000) - 1)
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bufferCombo2 As Integer = ComboBox2.SelectedIndex

        EggMoveList.Insert(ListBox1.SelectedIndex, ComboBox1.SelectedIndex + 20001)
        ReloadEggMoves()
        ComboBox2.SelectedIndex = bufferCombo2

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        EggMoveList.Insert(ListBox1.SelectedIndex, ComboBox2.SelectedIndex)
        ReloadEggMoves()

    End Sub

    Private Sub ReloadEggMoves()
        Dim bufferList As ListBox.ObjectCollection = New ListBox.ObjectCollection(New ListBox)

        Dim Looper As Integer = 0
        Dim AtBottom As Boolean = False
        Dim IndexBuff As Integer = ListBox1.SelectedIndex

        Dim NumberOfVisibleItems As Integer = Math.Ceiling(ListBox1.Height / ListBox1.ItemHeight)
        Dim BottomIndex As Integer = 0 ' last visible index
        If ListBox1.Items.Count - 1 > NumberOfVisibleItems Then
            BottomIndex = ListBox1.TopIndex + NumberOfVisibleItems - 2
        End If

        If BottomIndex >= ListBox1.Items.Count() - 1 Then
            AtBottom = True
        End If

        For Each CurEntry In EggMoveList

            If CurEntry > 20000 Then

                bufferList.Add(GetPokemonName(CurEntry - 20000))

            Else

                bufferList.Add("     " & GetAttackName(CurEntry))

            End If

            Looper = Looper + 1

        Next

        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(bufferList)

        If AtBottom Then
            ListBox1.SelectedIndex = ListBox1.Items.Count() - 1
        End If

        If ListBox1.Items.Count() - 1 >= BottomIndex Then
            ListBox1.SelectedIndex = BottomIndex
        Else
            ListBox1.SelectedIndex = ListBox1.Items.Count() - 1
        End If

        If ListBox1.Items.Count() - 1 >= IndexBuff Then
            ListBox1.SelectedIndex = IndexBuff
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bufferCombo2 As Integer = ComboBox2.SelectedIndex
        EggMoveList(ListBox1.SelectedIndex) = ComboBox1.SelectedIndex + 20001
        ReloadEggMoves()
        ComboBox2.SelectedIndex = bufferCombo2
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        EggMoveList(ListBox1.SelectedIndex) = ComboBox2.SelectedIndex
        ReloadEggMoves()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        ListBox1_SelectedIndexChanged()

        Dim bufferCombo1 As Integer = ComboBox1.SelectedIndex
        Dim bufferCombo2 As Integer = ComboBox2.SelectedIndex

        EggMoveList.RemoveAt(ListBox1.SelectedIndex)
        ReloadEggMoves()

        ComboBox1.SelectedIndex = bufferCombo1
        ComboBox2.SelectedIndex = bufferCombo2

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim bufferString As String = ""
        Dim tempLoop As Integer = 0

        For Each EggMove In EggMoveList

            bufferString += ReverseHEX(VB.Right("0000" & Hex(EggMove), 4))

            tempLoop += 1
        Next

        bufferString += "FFFF"

        WriteHEX(LoadedROM, Int32.Parse(((GetString(GetINIFileLocation(), header, "EggMoveTable", ""))), System.Globalization.NumberStyles.HexNumber), bufferString)

    End Sub
End Class