Option Strict Off
Option Explicit On
Module HexFunctions
    '           ------------------------------------------------
    '         ----------------------------------------------------
    '       --------------------------------------------------------
    '      |----------HEX Editing Functions by: Darthatron----------|
    '       --------------------------------------------------------
    '      |--When using these functions I must be credited fully.--|
    '      |--Check on Darthatron.Com for updates of this function--|
    '      |--as these are merely the BETA forms and may need some--|
    '      |--updates. If you find any bugs, please email them to:--|
    '      |--info@darthatron.com, thankyou:  Regards, Darthatron.--|
    '       --------------------------------------------------------
    '         ----------------------------------------------------
    '           ------------------------------------------------
    '           ------------------------------------------------
    '           ----------You can't handle the truth!!----------
    '           ------------------------------------------------
    '           ------------------------------------------------
    '         ----------------------------------------------------
    '       --------------------------------------------------------
    '      |----------Update 001:     Sunday 18th May 2008----------|
    '       --------------------------------------------------------
    '      |----Pretty much just fixed the WriteHEX Function, it----|
    '      |----------should be reasonably faster now.  :)----------|
    '       --------------------------------------------------------
    '         ----------------------------------------------------
    '           ------------------------------------------------

    Public Function ReverseHEX(ByRef HEXData As String) As String
        Dim iNum As Integer
        Dim HEXHolder As String = ""
        If Len(HEXData) / 2 <> Int(Len(HEXData) / 2) Then HEXData = "0" & HEXData

        For iNum = 0 To Len(HEXData) + 1
            If Len(HEXData) <= 1 Then GoTo EndNow
            HEXHolder = HEXHolder & Right(HEXData, 2)
            HEXData = Left(HEXData, Len(HEXData) - 2)
        Next iNum
EndNow:
        ReverseHEX = HEXHolder
    End Function

    Public Function ReadHEX(ByRef FilePath As String, ByRef Start As Integer, ByRef Length As Integer) As String
        On Error GoTo ErrHandle
        Dim iFile As Integer
        Dim bytHex As Byte
        Dim sHex As String
        Dim i As Integer
        Start = Start + 1
        iFile = FreeFile
        sHex = ""
        i = 0
        FileOpen(iFile, FilePath, OpenMode.Binary)
        For i = Start To (Start + Length - 1)
            'UPGRADE_WARNING: Get was upgraded to FileGet and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FileGet(iFile, bytHex, i)
            sHex = sHex & Right("00" & Hex(bytHex), 2)
        Next i
        FileClose(iFile)
        ReadHEX = sHex
        Exit Function
ErrHandle:
        MsgBox(Err.Description, MsgBoxStyle.OKOnly, "Error: " & Err.Number)
    End Function

    Public Function WriteHEX(ByRef FilePath As String, ByRef Start As Integer, ByRef Data As String) As Object
        On Error GoTo ErrHandle
        Dim iFile As Integer
        Dim sPost As Integer
        Dim bytHex As Byte
        ' Start = Start + 1
        iFile = FreeFile
        sPost = 0

        If Len(Data) <> Int(Len(Data) / 2) * 2 Then Data = "0" & Data

        FileOpen(iFile, FilePath, OpenMode.Binary)

        Do While Len(Data) > 0
            bytHex = Int32.Parse((Mid(Data, 1, 2)), System.Globalization.NumberStyles.HexNumber)
            'UPGRADE_WARNING: Put was upgraded to FilePut and has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            FilePut(iFile, bytHex, Start + 1 + sPost)
            Data = Right(Data, Len(Data) - 2)
            sPost = sPost + 1
        Loop
        FileClose(iFile)
        Exit Function
ErrHandle:
        MsgBox(Err.Description, MsgBoxStyle.OKOnly, "Error: " & Err.Number)
    End Function
End Module