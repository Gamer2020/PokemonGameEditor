Module LZ77
    Public LastStructSize As Integer

    Public Function Inc(ByVal variable As Long, Optional ByVal value As Integer = 1)
        Inc = variable
        variable = variable + value
    End Function

    Private Function Dec(ByVal Source As Long)
        Dec = Source
        Source = Source - 1
    End Function

    'Decompress LZ77 data with the below function.
    Public Function LZ77UnComp(ByVal Source() As Byte, ByVal Dest() As Byte) As Integer
        On Error Resume Next
        Dim header As Integer
        header = (Source(0) Or (Source(1) * CInt(256)) Or (Source(2) * CInt(2 ^ 16)) Or (Source(3) * CInt(2 ^ 24)))
        Dim i As Integer
        Dim j As Integer
        Dim xIn As Integer = 4
        Dim xOut As Integer = 0
        Dim length As Integer
        Dim Offset As Integer
        Dim windowOffset As Integer
        Dim xLen As Integer = header \ 256
        Dim retLen As Integer = xLen
        Dim d As Byte
        Dim data As Integer
        retLen = xLen
        Do While xLen > 0
            d = Source(xIn)
            xIn = xIn + 1
            For i = 0 To 7
                If (d And &H80) <> 0 Then
                    data = ((Source(xIn) * (2 ^ 8)) Or Source(xIn + 1))

                    xIn = xIn + 2
                    length = (data \ 4096) + 3 '(2 ^ 12)) + 3
                    Offset = (data And &HFFF)
                    windowOffset = xOut - Offset - 1
                    For j = 0 To length - 1
                        dest(xOut) = dest(windowOffset)
                        xOut = xOut + 1
                        windowOffset = windowOffset + 1

                        xLen = xLen - 1
                        If xLen = 0 Then
                            LZ77UnComp = retLen
                            Exit Function
                        End If
                    Next j
                Else
                    dest(xOut) = Source(xIn)
                    xOut = xOut + 1
                    xIn = xIn + 1

                    xLen = xLen - 1
                    If xLen = 0 Then
                        LZ77UnComp = retLen
                        Exit Function
                    End If
                End If
                d = (d * 2) Mod 256
            Next i
        Loop
        LZ77UnComp = retLen
        LastStructSize = xIn
    End Function

    'Compress data to the LZ77 format with the below function.
    Public Function LZ77Comp(ByVal decmpsize As Integer, ByVal Source() As Byte, ByVal dest() As Byte) As Integer
        Dim i As Integer
        Dim j As Integer
        Dim xIn As Integer
        Dim xOut As Integer

        Dim length As Integer
        Dim Offset As Integer
        Dim tmplen As Integer
        Dim tmpoff As Integer
        Dim tmpxin As Integer
        Dim tmpxout As Integer
        Dim bufxout As Integer
        Dim ctrl As Byte
        Dim xdata(0 To 7, 0 To 1) As Byte
        On Error GoTo endme
        dest(0) = &H10  'unknown byte?
        dest(1) = (decmpsize Mod 256)
        dest(2) = ((decmpsize \ 256) Mod 256)
        dest(3) = ((decmpsize \ (2 ^ 16)) Mod 256)

        Do While (decmpsize > tmpxin)
            ctrl = 0
            For i = 7 To 0 Step -1
                If (xIn < &H1000) Then
                    j = xIn
                Else
                    j = &H1000
                End If
                length = 0
                Offset = 0
                Do While (j > 1)
                    tmpxin = xIn
                    tmpxout = (xIn - j)
                    Do While Source(Inc(tmpxin)) = Source(Inc(tmpxout))
                        If (tmpxin >= decmpsize) Then Exit Do
                    Loop
                    tmplen = (tmpxin - xIn - 1)
                    tmpoff = (tmpxin - tmpxout - 1)
                    If (tmplen > length) Then
                        length = tmplen
                        Offset = tmpoff
                    End If
                    If (length >= &H12) Then Exit Do
                    Inc(j, -1)
                Loop
                If (length >= 3) Then
                    ctrl = ctrl Or (1 * (2 ^ i))
                    If (length >= &H12) Then length = &H12
                    xdata(i, 0) = (((length - 3) * (2 ^ 4)) Or (Offset \ 256))
                    xdata(i, 1) = (Offset Mod 256)
                    Inc(xIn, length)
                    Inc(bufxout, 2)
                Else
                    xdata(i, 0) = Source(Inc(xIn))
                    Inc(bufxout)
                End If
            Next i
            dest(Inc(xOut) + 4) = ctrl
            For i = 7 To 0 Step -1
                dest(Inc(xOut) + 4) = xdata(i, 0)
                If ((ctrl And &H80) <> 0) Then dest(Inc(xOut) + 4) = xdata(i, 1)
                ctrl = (ctrl * 2) Mod 256
                If (decmpsize < tmpxin) Then Exit For
            Next i
        Loop
endme:
        LZ77Comp = xOut + 4
    End Function
End Module
