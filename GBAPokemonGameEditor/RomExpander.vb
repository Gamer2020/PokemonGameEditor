Imports System.IO
Public Class RomExpander
    Private Sub RomExpander_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Button1.Enabled = False

        Dim fileinfo As New FileInfo(LoadedROM)

        Label1.Text = "File Size: " & fileinfo.Length & " bytes"

        If fileinfo.Length < "33554432" Then
            Button1.Enabled = True
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileinfo As New FileInfo(LoadedROM)
        Dim Temp(33554431 - fileinfo.Length) As Byte

        MemSet(Temp, &HFF)

        Dim s As New System.IO.FileStream(LoadedROM, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
        s.Write(Temp, 0, Temp.Length)
        s.Close()

        Dim fileinfo2 As New FileInfo(LoadedROM)

        Label1.Text = "File Size: " & fileinfo2.Length & " bytes"

        Button1.Enabled = False

        MsgBox("ROM expanded!")
    End Sub

    Public Shared Sub MemSet(array As Byte(), value As Byte)

        Dim block As Integer = 32, index As Integer = 0
        Dim length As Integer = Math.Min(block, array.Length)

        'Fill the initial array
        While index < length

            array(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1) - 1) = value
        End While

        length = array.Length
        While index < length
            Buffer.BlockCopy(array, 0, array, index, Math.Min(block, length - index))
            index += block
            block *= 2
        End While

    End Sub
End Class