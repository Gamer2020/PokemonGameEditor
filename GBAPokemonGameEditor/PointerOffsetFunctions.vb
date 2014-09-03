Module PointerOffsetFunctions

    'Don't even know if these work. Was going to write pointer functions but never did. - Gamer2020
    Public Function Pointer2Offset(ByVal Pointer As String)
        Pointer2Offset = (ReverseHEX((Pointer)) - &H8000000)
    End Function

    Public Function Offset2Pointer(ByVal Offset As Long)
        Offset2Pointer = ReverseHEX(Offset) + &H8000000
    End Function
End Module
