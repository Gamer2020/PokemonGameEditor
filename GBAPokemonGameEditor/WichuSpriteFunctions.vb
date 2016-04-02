Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Linq

'The following functions were extracted from A-series. All credit goes to it's programmer Wichu!

Module WichuSpriteFunctions

    Public Sub BitmapBLT(ByRef srcBitmap As Bitmap, ByRef destBitmap As Bitmap, ByVal destX As Integer, ByVal destY As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim num As Integer = 0
        Dim i As Integer = 0
        Do While (num < width)
            Do While (i < height)
                If ((((((((((srcX + num) >= 0) And ((srcY + i) >= 0)) And ((destX + num) >= 0)) And ((destY + i) >= 0)) And ((srcX + num) < srcBitmap.Width)) And ((srcY + i) < srcBitmap.Height)) And ((destX + num) < destBitmap.Width)) And ((destY + i) < destBitmap.Height)) AndAlso (srcBitmap.GetPixel((srcX + num), (srcY + i)).A >= &H80)) Then
                    destBitmap.SetPixel((destX + num), (destY + i), srcBitmap.GetPixel((srcX + num), (srcY + i)))
                End If
                i += 1
            Loop
            num += 1
            i = 0
        Loop
    End Sub

    Public Sub BitmapBLT(ByRef srcBitmap As Bitmap, ByRef destBitmap As Bitmap, ByVal destX As Integer, ByVal destY As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal width As Integer, ByVal height As Integer, ByRef bgcolor As Color)
        Dim num As Integer = 0
        Dim i As Integer = 0
        Do While (num < width)
            Do While (i < height)
                If (((((((((srcX + num) >= 0) And ((srcY + i) >= 0)) And ((destX + num) >= 0)) And ((destY + i) >= 0)) And ((srcX + num) < srcBitmap.Width)) And ((srcY + i) < srcBitmap.Height)) And ((destX + num) < destBitmap.Width)) And ((destY + i) < destBitmap.Height)) Then
                    If (srcBitmap.GetPixel((srcX + num), (srcY + i)).A >= &H80) Then
                        destBitmap.SetPixel((destX + num), (destY + i), srcBitmap.GetPixel((srcX + num), (srcY + i)))
                    Else
                        destBitmap.SetPixel((destX + num), (destY + i), bgcolor)
                    End If
                End If
                i += 1
            Loop
            num += 1
            i = 0
        Loop
    End Sub

    Public Sub ClearBitmap(ByRef bitmap As Bitmap)
        FillBitmap(bitmap, Color.Transparent)
    End Sub

    Public Function ColorToRGB16(ByRef ARGBColor As Color) As UInt16
        Dim num4 As UInt16 = CByte((ARGBColor.R >> 3))
        Dim num3 As UInt16 = CByte((ARGBColor.G >> 3))
        Dim num As UInt16 = CByte((ARGBColor.B >> 3))
        Return CUShort((CUShort((num4 + CUShort((num3 << 5)))) + CUShort((num << 10))))
    End Function

    Public Sub ConvertBitmapToPalette(ByRef sprite As Bitmap, ByRef palette As Color(), ByVal AutoTransparency As Boolean)
        Dim pixel As Color
        Dim destinationArray As Color() = New Color(((palette.Length - 2) + 1) - 1) {}
        If AutoTransparency Then
            Array.Copy(palette, 1, destinationArray, 0, (palette.Length - 1))
            pixel = sprite.GetPixel(0, 0)
        End If
        Dim num3 As Integer = (sprite.Width - 1)
        Dim i As Integer = 0
        Do While (i <= num3)
            Dim num4 As Integer = (sprite.Height - 1)
            Dim j As Integer = 0
            Do While (j <= num4)
                Dim col As Color = sprite.GetPixel(i, j)
                If AutoTransparency Then
                    If (col = pixel) Then
                        sprite.SetPixel(i, j, palette(0))
                    Else
                        sprite.SetPixel(i, j, destinationArray(GetClosestColorFromPalette(col, destinationArray)))
                    End If
                Else
                    sprite.SetPixel(i, j, palette(GetClosestColorFromPalette(col, palette)))
                End If
                j += 1
            Loop
            i += 1
        Loop
    End Sub

    Public Function ConvertPaletteToByteArray(ByRef palette As Color()) As Byte()
        Dim buffer2 As Byte() = New Byte(&H20 - 1) {}
        Dim index As Integer = 0
        Do
            Dim num As Integer = ColorToRGB16(palette(index))
            buffer2((index * 2)) = CByte((num And &HFF))
            buffer2(((index * 2) + 1)) = CByte(((num >> 8) And &HFF))
            index += 1
        Loop While (index <= 15)
        Return buffer2
    End Function

    Public Function ConvertPaletteToString(ByRef palette As Color()) As String
        Dim str2 As String = ""
        Dim index As Integer = 0
        Do
            Dim num As UInt16 = ColorToRGB16(palette(index))
            str2 = (str2 & Conversions.ToString(Strings.Chr((num And &HFF))) & Conversions.ToString(Strings.Chr((CUShort((num >> 8)) And &HFF))))
            index += 1
        Loop While (index <= 15)
        Return str2
    End Function

    Public Sub CopyBitmap(ByRef srcBitmap As Bitmap, ByRef destBitmap As Bitmap)
        Dim x As Integer = 0
        Dim i As Integer = 0
        Do While (x < destBitmap.Width)
            Do While (i < destBitmap.Height)
                Dim pixel As Color = srcBitmap.GetPixel(x, i)
                If (pixel.A > &H7F) Then
                    destBitmap.SetPixel(x, i, pixel)
                End If
                i += 1
            Loop
            x += 1
            i = 0
        Loop
    End Sub

    Public Sub FillBitmap(ByRef bitmap As Bitmap, ByRef color As Color)
        Dim x As Integer = 0
        Dim i As Integer = 0
        Do While (x < bitmap.Width)
            Do While (i < bitmap.Height)
                bitmap.SetPixel(x, i, color)
                i += 1
            Loop
            x += 1
            i = 0
        Loop
    End Sub

    Public Sub FillRect(ByRef bitmap As Bitmap, ByRef color As Color, ByVal ox As Integer, ByVal oy As Integer, ByVal width As Integer, ByVal height As Integer)
        Dim num As Integer = 0
        Dim num2 As Integer = 0
        If (width > (bitmap.Width - ox)) Then
            width = (bitmap.Width - ox)
        End If
        If (height > (bitmap.Width - oy)) Then
            height = (bitmap.Width - oy)
        End If
        Do While (num < width)
            Do While (num2 < height)
                bitmap.SetPixel((num + ox), (num2 + oy), color)
                num2 += 1
            Loop
            num += 1
            num2 = 0
        Loop
    End Sub

    Public Function GetBitmapPalette(ByRef sprite As Bitmap) As Color()
        Dim source As Color() = New Color(&H10 - 1) {}
        Dim index As Byte = 0
        Dim num4 As Integer = (sprite.Width - 1)
        Dim i As Integer = 0
        Do While (i <= num4)
            Dim num5 As Integer = (sprite.Height - 1)
            Dim j As Integer = 0
            Do While (j <= num5)
                Dim pixel As Color = sprite.GetPixel(i, j)
                If Not Enumerable.Contains(Of Color)(source, pixel) Then
                    source(index) = pixel
                    index = CByte((index + 1))
                End If
                If (index > 15) Then
                    Return source
                End If
                j += 1
            Loop
            i += 1
        Loop
        Return source
    End Function

    Public Function GetBottom(ByRef bitmap As Bitmap) As Integer
        Dim num As Integer
        Dim height As Integer = bitmap.Height
        Dim i As Integer = 1
        Do While (i <= height)
            Dim num5 As Integer = (bitmap.Height - 1)
            Dim j As Integer = 0
            Do While (j <= num5)
                If (bitmap.GetPixel(j, (bitmap.Height - i)).A > 0) Then
                    Return (bitmap.Height - i)
                End If
                j += 1
            Loop
            i += 1
        Loop
        Return num
    End Function

    Public Function GetClosestColorFromPalette(ByRef col As Color, ByRef palette As Color()) As Byte
        Dim num2 As Integer
        Dim num As Integer = &H2FD
        col = QuantizeColor(col)
        Dim num6 As Integer = (palette.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num6)
            Dim colorDifference As Integer = GetColorDifference(col, palette(i))
            If (colorDifference < num) Then
                num = colorDifference
                num2 = i
            End If
            i += 1
        Loop
        Return CByte(num2)
    End Function

    Public Function GetClosestIndexedPixel(ByRef sprite As Bitmap, ByRef palette As Color(), ByVal x As UInt32, ByVal y As UInt32) As Byte
        Dim num As Byte
        Return num
    End Function

    Public Function GetClosestPalette(ByRef sprite As Bitmap, ByRef palettes As Color()()) As Byte
        Dim num2 As Byte
        Dim bitmapPalette As Color() = GetBitmapPalette(sprite)
        Dim num As Integer = -1
        Dim num7 As Integer = (palettes.Length - 1)
        Dim i As Integer = 0
        Do While (i <= num7)
            Dim num4 As Integer = 0
            Dim num8 As Integer = (bitmapPalette.Length - 1)
            Dim j As Integer = 0
            Do While (j <= num8)
                num4 = (num4 + GetColorDifference(bitmapPalette(j), palettes(i)(GetClosestColorFromPalette(bitmapPalette(j), palettes(i)))))
                j += 1
            Loop
            If ((num4 < num) Or (num < 0)) Then
                num = num4
                num2 = CByte(i)
            End If
            i += 1
        Loop
        Return num2
    End Function

    Public Function GetColorDifference(ByRef color1 As Color, ByRef color2 As Color) As Integer
        Dim r As Integer = color1.R
        Dim g As Integer = color1.G
        Dim b As Integer = color1.B
        r = (r - color2.R)
        g = (g - color2.G)
        b = (b - color2.B)
        Return (((r * r) + (g * g)) + (b * b))
    End Function

    Public Function GetIndexedPixel(ByRef sprite As Bitmap, ByRef palette As Color(), ByVal x As UInt32, ByVal y As UInt32) As Byte
        Dim num As Byte
        Return num
    End Function

    Public Function GetNumColors(ByRef sprite As Bitmap) As Byte
        Dim source As Color() = New Color(&H10 - 1) {}
        Dim index As Byte = 0
        Dim num5 As Integer = (sprite.Width - 1)
        Dim i As Integer = 0
        Do While (i <= num5)
            Dim num6 As Integer = (sprite.Height - 1)
            Dim j As Integer = 0
            Do While (j <= num6)
                Dim pixel As Color = sprite.GetPixel(i, j)
                If Not Enumerable.Contains(Of Color)(source, pixel) Then
                    source(index) = pixel
                    index = CByte((index + 1))
                End If
                If (index > 15) Then
                    Return &H10
                End If
                j += 1
            Loop
            i += 1
        Loop
        Return index
    End Function

    Public Function GetQuantizedPixel(ByRef sprite As Bitmap, ByVal x As UInt32, ByVal y As UInt32) As Color
        Return QuantizeColor(sprite.GetPixel(CInt(x), CInt(y)))
    End Function

    Public Function GetTop(ByRef bitmap As Bitmap) As Integer
        Dim num As Integer
        Dim num4 As Integer = (bitmap.Height - 1)
        Dim i As Integer = 0
        Do While (i <= num4)
            Dim num5 As Integer = (bitmap.Height - 1)
            Dim j As Integer = 0
            Do While (j <= num5)
                If (bitmap.GetPixel(j, i).A > 0) Then
                    Return i
                End If
                j += 1
            Loop
            i += 1
        Loop
        Return num
    End Function

    Public Sub LoadBitmapFromArray(ByRef ary As Byte(), ByRef palette As Color(), ByRef bitmap As Bitmap, ByVal width As Integer, ByVal height As Integer)
        Dim num7 As Double = ((CDbl(bitmap.Height) / 8) - 1)
        Dim i As Double = 0
        Do While (i <= num7)
            Dim num8 As Double = ((CDbl(bitmap.Width) / 8) - 1)
            Dim j As Double = 0
            Do While (j <= num8)
                Dim num5 As Integer = 0
                Do
                    Dim num6 As Integer = 0
                    Do
                        If ((((i * 8) + num5) < height) And ((((j * 8) + (num6 * 2)) + 1) < width)) Then
                            Dim num2 As Integer
                            Dim num As Byte = ary(num2)
                            bitmap.SetPixel(CInt(Math.Round(CDbl((((j * 8) + (num6 * 2)) + 1)))), CInt(Math.Round(CDbl(((i * 8) + num5)))), palette(CByte((num >> 4))))
                            bitmap.SetPixel(CInt(Math.Round(CDbl(((j * 8) + (num6 * 2))))), CInt(Math.Round(CDbl(((i * 8) + num5)))), palette((num And 15)))
                            num2 += 1
                        Else
                            bitmap.SetPixel(CInt(Math.Round(CDbl((((j * 8) + (num6 * 2)) + 1)))), CInt(Math.Round(CDbl(((i * 8) + num5)))), Color.Transparent)
                            bitmap.SetPixel(CInt(Math.Round(CDbl(((j * 8) + (num6 * 2))))), CInt(Math.Round(CDbl(((i * 8) + num5)))), Color.Transparent)
                        End If
                        num6 += 1
                    Loop While (num6 <= 3)
                    num5 += 1
                Loop While (num5 <= 7)
                j += 1
            Loop
            i += 1
        Loop
    End Sub

    Public Sub LoadBitmapFromArray(ByRef ary As Byte(), ByVal offset As UInt32, ByRef palette As Color(), ByRef bitmap As Bitmap, ByVal width As Integer, ByVal height As Integer)
        Dim index As Integer = CInt(offset)
        Dim num7 As Double = ((CDbl(bitmap.Height) / 8) - 1)
        Dim i As Double = 0
        Do While (i <= num7)
            Dim num8 As Double = ((CDbl(bitmap.Width) / 8) - 1)
            Dim j As Double = 0
            Do While (j <= num8)
                Dim num5 As Integer = 0
                Do
                    Dim num6 As Integer = 0
                    Do
                        If ((((i * 8) + num5) < height) And ((((j * 8) + (num6 * 2)) + 1) < width)) Then
                            Dim num As Byte = ary(index)
                            bitmap.SetPixel(CInt(Math.Round(CDbl((((j * 8) + (num6 * 2)) + 1)))), CInt(Math.Round(CDbl(((i * 8) + num5)))), palette(CByte((num >> 4))))
                            bitmap.SetPixel(CInt(Math.Round(CDbl(((j * 8) + (num6 * 2))))), CInt(Math.Round(CDbl(((i * 8) + num5)))), palette((num And 15)))
                            index += 1
                        Else
                            bitmap.SetPixel(CInt(Math.Round(CDbl((((j * 8) + (num6 * 2)) + 1)))), CInt(Math.Round(CDbl(((i * 8) + num5)))), Color.Transparent)
                            bitmap.SetPixel(CInt(Math.Round(CDbl(((j * 8) + (num6 * 2))))), CInt(Math.Round(CDbl(((i * 8) + num5)))), Color.Transparent)
                        End If
                        num6 += 1
                    Loop While (num6 <= 3)
                    num5 += 1
                Loop While (num5 <= 7)
                j += 1
            Loop
            i += 1
        Loop
    End Sub

    'Public Function LoadLz77CompressedPalette(ByRef Stream As FileStream, ByVal message As Boolean) As Color()
    '    Dim colorArray2 As Color() = New Color(&H10 - 1) {}
    '    Dim buffer As Byte() = RomFunctions.UncompressLZ77(Stream, message)
    '    If (buffer.Length <> 0) Then
    '        Dim index As Integer = 0
    '        Do
    '            Dim num As Integer = buffer(((index * 2) + 1))
    '            num = (num << 8)
    '            num = (num Or buffer((index * 2)))
    '            colorArray2(index) = .RGB16ToColor(num)
    '            index += 1
    '        Loop While (index <= 15)
    '    End If
    '    Return colorArray2
    'End Function

    'Public Sub LoadLz77CompressedSprite(ByRef Stream As FileStream, ByVal offset As Integer, ByVal palette As Color(), ByRef bitmap As Bitmap)
    '    Dim ary As Byte() = RomFunctions.UncompressLZ77(Stream)
    '    LoadBitmapFromArray(ary, palette, bitmap, &H40, CInt(Math.Round(CDbl((CDbl(ary.Length) / 32)))))
    'End Sub

    Public Function LoadPaletteFromROM(ByRef streaminput As FileStream) As Color()
        Dim colorArray2 As Color() = New Color(&H10 - 1) {}
        Dim index As Integer = 0
        Do
            Dim streamvar As Stream = streaminput
            streamvar = DirectCast(streamvar, FileStream)
            colorArray2(index) = RGB16ToColor(Conversions.ToInteger(GetWord(streamvar)))
            index += 1
        Loop While (index <= 15)
        Return colorArray2
    End Function

    Public Function QuantizeColor(ByRef col As Color) As Color
        If (col.A < &H80) Then
            Return Color.FromArgb(&HFF, &H70, &HC0, 160)
        End If
        Dim r As Byte = col.R
        Dim g As Byte = col.G
        Dim b As Byte = col.B
        r = CByte((r >> 3))
        g = CByte((g >> 3))
        b = CByte((b >> 3))
        r = CByte((r << 3))
        g = CByte((g << 3))
        b = CByte((b << 3))
        Return Color.FromArgb(&HFF, r, g, b)
    End Function

    Public Function RGB16ToColor(ByVal RGB16 As Integer) As Color
        Dim red As Byte = CByte(((RGB16 And &H1F) << 3))
        Dim green As Byte = CByte((((RGB16 >> 5) And &H1F) << 3))
        Dim blue As Byte = CByte((((RGB16 >> 10) And &H1F) << 3))
        Return Color.FromArgb(&HFF, red, green, blue)
    End Function

    Public Function SaveBitmapToArray(ByRef bitmap As Bitmap, ByRef palette As Color()) As Object
        Dim buffer As Byte() = New Byte((CInt(Math.Round(CDbl(((CDbl((bitmap.Height * bitmap.Width)) / 2) - 1)))) + 1) - 1) {}
        Dim num8 As Double = ((CDbl(bitmap.Height) / 8) - 1)
        Dim i As Double = 0
        Do While (i <= num8)
            Dim num9 As Double = ((CDbl(bitmap.Width) / 8) - 1)
            Dim j As Double = 0
            Do While (j <= num9)
                Dim num6 As Integer = 0
                Do
                    Dim num7 As Integer = 0
                    Do
                        Dim num3 As Integer
                        Dim index As Byte = CByte(Array.IndexOf(Of Color)(palette, bitmap.GetPixel(CInt(Math.Round(CDbl(((j * 8) + (num7 * 2))))), CInt(Math.Round(CDbl(((i * 8) + num6)))))))
                        Dim num2 As Byte = CByte(Array.IndexOf(Of Color)(palette, bitmap.GetPixel(CInt(Math.Round(CDbl((((j * 8) + (num7 * 2)) + 1)))), CInt(Math.Round(CDbl(((i * 8) + num6)))))))
                        buffer(num3) = CByte((CByte((num2 << 4)) Or index))
                        num3 += 1
                        num7 += 1
                    Loop While (num7 <= 3)
                    num6 += 1
                Loop While (num6 <= 7)
                j += 1
            Loop
            i += 1
        Loop
        Return buffer
    End Function

    Public Sub TransparentBitmap(ByRef bitmap As Bitmap)
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim pixel As Color = bitmap.GetPixel(0, 0)
        Do While (x < bitmap.Width)
            Do While (y < bitmap.Height)
                If (bitmap.GetPixel(x, y) = pixel) Then
                    bitmap.SetPixel(x, y, Color.Transparent)
                End If
                y += 1
            Loop
            x += 1
            y = 0
        Loop
    End Sub


End Module
