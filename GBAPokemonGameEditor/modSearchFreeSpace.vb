Option Explicit On
Imports VB = Microsoft.VisualBasic

Module modSearchFreeSpace


    '06/22/2013 - This code has been ported to VB.Net by Gamer2020

    ' Copyright © 2009 HackMew
    ' ------------------------------
    ' Feel free to create derivate works from it, as long as you clearly give me credits of my code and
    ' make available the source code of derivative programs or programs where you used parts of my code.
    ' Redistribution is allowed at the same conditions.

    'Private Const sMyName As String = "modSearchFreeSpace"

    'This function wasn't working so I made my own.
    'Private Declare Sub RtlFillMemory Lib "kernel32" (ByVal pDest As Byte, ByVal nLen As Long, ByVal Fill As Byte)

    Public Function SearchFreeSpace(ByVal FileName As String, ByVal FreeSpaceByte As Byte, ByVal NeededBytes As Long, Optional ByVal StartOffset As Long = 0&, Optional ByVal ChunkSize As Long = 65536, Optional ByVal Accuracy As Byte = 0) As Long
        'Const sThis As String = "SearchFreeSpace"
        Dim iFileNum As Long
        Dim lFileLen As Long
        Dim lOffset As Long
        Dim lIncrement As Long
        Dim bBuffer() As Byte
        Dim bSearch() As Byte
        Dim i As Long
        Dim loopy As Integer



        On Error GoTo LocalHandler

        ' Check if NeededBytes and ChunkSize
        ' are higher than zero
        If (NeededBytes + ChunkSize) Then

            ' Set the increment
            lIncrement = ChunkSize \ (CLng(Accuracy) + 1&)

            ' Allocate the buffer and the search pattern
            ReDim bBuffer(ChunkSize - 1&)
            ReDim bSearch(NeededBytes - 1&)

            ' Fill the search pattern with the
            ' FreeSpaceByte when it's not 0
            'This function wasn't working so I made my own.

            'If FreeSpaceByte Then
            'RtlFillMemory(bSearch(0), NeededBytes, FreeSpaceByte)
            'End If



            loopy = 0

            'just a simple loop to fill the buffer.
            While loopy < NeededBytes

                bSearch(loopy) = bSearch(loopy) & FreeSpaceByte

                loopy = loopy + 1

            End While

            ' Get the next free number
            iFileNum = FreeFile()

            ' Open the file
            'Open FileName For Binary As iFileNum
            FileOpen(iFileNum, FileName, OpenMode.Binary)
            ' Get the file length
            lFileLen = LOF(iFileNum)

            ' Ensure the file is not empty
            If lFileLen Then

                ' Check if the StartOffset is valid
                If (lFileLen - StartOffset) Then

                    ' Loop through the file
                    For i = 0& To (lFileLen - StartOffset) \ ChunkSize

                        ' Get a file chunk at the current offset
                        'Get #iFileNum, StartOffset + 1&, bBuffer
                        FileGet(iFileNum, bBuffer, StartOffset + 1&)

                        ' Search the needed space
                        'lOffset = InStrB(bBuffer, bSearch)
                        lOffset = InStr(bBuffer(0), bSearch(0))

                        ' Was there enough space?
                        If lOffset Then

                            ' Yeah, stop searching
                            lOffset = lOffset + StartOffset - 1&
                            Exit For

                        End If

                        ' Increment the offset
                        StartOffset = StartOffset + lIncrement

                    Next i

                End If

            End If

            FileClose(iFileNum)

            ' Make sure the offset isn't past the EOF
            If lOffset < lFileLen Then
                SearchFreeSpace = lOffset
            End If

        End If
        Exit Function

LocalHandler:

        'insert error handler here

        'Select Case GlobalHandler(sThis, sMyName)
        '    Case vbRetry
        ' Resume
        '  Case vbAbort
        ' Quit()
        '   Case Else
        ' Resume Next
        ' End Select

    End Function

    Public Function SearchFreeSpaceFourAligned(ByVal FileName As String, ByVal FreeSpaceByte As Byte, ByVal NeededBytes As Long, Optional ByVal StartOffset As Long = 0) As Long

        Dim SearchIncrement As String
        Dim CurSearchOffset As String

        CurSearchOffset = Hex(SearchFreeSpace(FileName, FreeSpaceByte, NeededBytes, StartOffset, 100))

        SearchIncrement = 1

        While (((CurSearchOffset(CurSearchOffset.Length - 1)) <> "0") AndAlso ((CurSearchOffset(CurSearchOffset.Length - 1)) <> "4") AndAlso ((CurSearchOffset(CurSearchOffset.Length - 1)) <> "8") AndAlso ((CurSearchOffset(CurSearchOffset.Length - 1)) <> "C"))

            CurSearchOffset = Hex(SearchFreeSpace(FileName, FreeSpaceByte, NeededBytes, (StartOffset) + SearchIncrement))

            SearchIncrement = SearchIncrement + 1

        End While

        Return "&H" & CurSearchOffset

    End Function

End Module
