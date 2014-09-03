Option Strict Off
Option Explicit Off

Module modTextSapp
    Public Function Asc2Sapp(ByVal asciistring As String) As String
        o = ""

        Dim m As Boolean
        For i = 1 To Len(asciistring)
            m = False
            If Len(asciistring) - (i - 1) > 3 Then
                Select Case Mid(asciistring, i, 4)
                    Case "[Lv]" : Y = &H34 : m = True
                    Case "[PK]" : Y = &H53 : m = True
                    Case "[MN]" : Y = &H54 : m = True
                    Case "[PO]" : Y = &H55 : m = True
                    Case "[Ke]" : Y = &H56 : m = True
                    Case "[BL]" : Y = &H57 : m = True
                    Case "[OC]" : Y = &H58 : m = True
                    Case "" & "" & "" & "" : Y = &HFB : m = True
                        'Case StrDup(1, 10) : Y = &HFB : m = True
                        'Case StrDup(1, &HD) : Y = &HFB : m = True
                        'Case StrDup(1, &HA) : Y = &HFB : m = True
                End Select
                If m = True Then
                    i = i + 3
                Else
                    If Mid(asciistring, i, 2) = "\h" And IsHex(Mid(asciistring, i + 2, 2)) = True Then
                        Y = Val("&H" & Mid(asciistring, i + 2, 2))
                        i = i + 3
                        m = True
                    End If
                End If
            End If
            If Len(asciistring) - (i - 1) > 2 And m = False Then
                Select Case Mid(asciistring, i, 3)
                    Case "[K]" : Y = &H59 : m = True
                    Case "[U]" : Y = &H79 : m = True
                    Case "[D]" : Y = &H7A : m = True
                    Case "[L]" : Y = &H7B : m = True
                    Case "[R]" : Y = &H7C : m = True
                    Case "[.]" : Y = &HB0 : m = True
                    Case "[""]" : Y = &HB1 : m = True
                    Case "[']" : Y = &HB3 : m = True
                    Case "[m]" : Y = &HB5 : m = True
                    Case "[f]" : Y = &HB6 : m = True
                    Case "[p]" : Y = &HB7 : m = True
                    Case "[x]" : Y = &HB9 : m = True
                    Case "[>]" : Y = &HEF : m = True
                    Case "[u]" : Y = &HF7 : m = True
                    Case "[d]" : Y = &HF8 : m = True
                    Case "[l]" : Y = &HF9 : m = True
                End Select
                If m = True Then i = i + 2
            End If

            If Len(asciistring) - (i - 1) > 1 And m = False Then
                Select Case Mid(asciistring, i, 2)
                    Case "\l" : Y = &HFA : m = True
                    Case "\p" : Y = &HFB : m = True
                    Case "\c" : Y = &HFC : m = True
                    Case "\v" : Y = &HFD : m = True
                    Case "\n" : Y = &HFE : m = True
                    Case "\x" : Y = &HFF : m = True
                    Case "" & "" : Y = &HFE : m = True
                        'Case StrDup(1, &HD) : Y = &HFE : m = True
                        'Case StrDup(1, &HA) : Y = &HFE : m = True
                End Select
                If m = True Then i = i + 1
            End If

            If m = False Then
                Select Case Mid(asciistring, i, 1)
                    Case " " : Y = &H0 : m = True
                    Case "À" : Y = &H1 : m = True
                    Case "Á" : Y = &H2 : m = True
                    Case "Â" : Y = &H3 : m = True
                    Case "Ç" : Y = &H4 : m = True
                    Case "È" : Y = &H5 : m = True
                    Case "É" : Y = &H6 : m = True
                    Case "Ê" : Y = &H7 : m = True
                    Case "Ë" : Y = &H8 : m = True
                    Case "Ì" : Y = &H9 : m = True
                    Case "Î" : Y = &HB : m = True
                    Case "Ï" : Y = &HC : m = True
                    Case "Ò" : Y = &HD : m = True
                    Case "Ó" : Y = &HE : m = True
                    Case "Ô" : Y = &HF : m = True
                    Case "Œ" : Y = &H10 : m = True
                    Case "Ù" : Y = &H11 : m = True
                    Case "Ú" : Y = &H12 : m = True
                    Case "Û" : Y = &H13 : m = True
                    Case "ß" : Y = &H15 : m = True
                    Case "à" : Y = &H16 : m = True
                    Case "á" : Y = &H17 : m = True
                    Case "ç" : Y = &H19 : m = True
                    Case "è" : Y = &H1A : m = True
                    Case "é" : Y = &H1B : m = True
                    Case "ê" : Y = &H1C : m = True
                    Case "ë" : Y = &H1D : m = True
                    Case "ì" : Y = &H1E : m = True
                    Case "î" : Y = &H20 : m = True
                    Case "ï" : Y = &H21 : m = True
                    Case "ò" : Y = &H22 : m = True
                    Case "ó" : Y = &H23 : m = True
                    Case "œ" : Y = &H24 : m = True
                    Case "ù" : Y = &H25 : m = True
                    Case "ú" : Y = &H26 : m = True
                    Case "°" : Y = &H28 : m = True
                    Case "ª" : Y = &H29 : m = True
                    Case "+" : Y = &H2C : m = True
                    Case "&" : Y = &H2D : m = True
                    Case "=" : Y = &H35 : m = True
                    Case "¿" : Y = &H51 : m = True
                    Case "¡" : Y = &H52 : m = True
                    Case "Í" : Y = &H5A : m = True
                    Case "%" : Y = &H5B : m = True
                    Case "(" : Y = &H5C : m = True
                    Case ")" : Y = &H5D : m = True
                    Case "â" : Y = &H68 : m = True
                    Case "í" : Y = &H6F : m = True
                    Case "0" : Y = &HA1 : m = True
                    Case "1" : Y = &HA2 : m = True
                    Case "2" : Y = &HA3 : m = True
                    Case "3" : Y = &HA4 : m = True
                    Case "4" : Y = &HA5 : m = True
                    Case "5" : Y = &HA6 : m = True
                    Case "6" : Y = &HA7 : m = True
                    Case "7" : Y = &HA8 : m = True
                    Case "8" : Y = &HA9 : m = True
                    Case "9" : Y = &HAA : m = True
                    Case "!" : Y = &HAB : m = True
                    Case "?" : Y = &HAC : m = True
                    Case "." : Y = &HAD : m = True
                    Case "-" : Y = &HAE : m = True
                    Case "·" : Y = &HAF : m = True
                    Case "," : Y = &HB8 : m = True
                    Case """" : Y = &HB2 : m = True
                    Case "'" : Y = &HB4 : m = True
                    Case "/" : Y = &HBA : m = True
                    Case "A" : Y = &HBB : m = True
                    Case "B" : Y = &HBC : m = True
                    Case "C" : Y = &HBD : m = True
                    Case "D" : Y = &HBE : m = True
                    Case "E" : Y = &HBF : m = True
                    Case "F" : Y = &HC0 : m = True
                    Case "G" : Y = &HC1 : m = True
                    Case "H" : Y = &HC2 : m = True
                    Case "I" : Y = &HC3 : m = True
                    Case "J" : Y = &HC4 : m = True
                    Case "K" : Y = &HC5 : m = True
                    Case "L" : Y = &HC6 : m = True
                    Case "M" : Y = &HC7 : m = True
                    Case "N" : Y = &HC8 : m = True
                    Case "O" : Y = &HC9 : m = True
                    Case "P" : Y = &HCA : m = True
                    Case "Q" : Y = &HCB : m = True
                    Case "R" : Y = &HCC : m = True
                    Case "S" : Y = &HCD : m = True
                    Case "T" : Y = &HCE : m = True
                    Case "U" : Y = &HCF : m = True
                    Case "V" : Y = &HD0 : m = True
                    Case "W" : Y = &HD1 : m = True
                    Case "X" : Y = &HD2 : m = True
                    Case "Y" : Y = &HD3 : m = True
                    Case "Z" : Y = &HD4 : m = True
                    Case "a" : Y = &HD5 : m = True
                    Case "b" : Y = &HD6 : m = True
                    Case "c" : Y = &HD7 : m = True
                    Case "d" : Y = &HD8 : m = True
                    Case "e" : Y = &HD9 : m = True
                    Case "f" : Y = &HDA : m = True
                    Case "g" : Y = &HDB : m = True
                    Case "h" : Y = &HDC : m = True
                    Case "i" : Y = &HDD : m = True
                    Case "j" : Y = &HDE : m = True
                    Case "k" : Y = &HDF : m = True
                    Case "l" : Y = &HE0 : m = True
                    Case "m" : Y = &HE1 : m = True
                    Case "n" : Y = &HE2 : m = True
                    Case "o" : Y = &HE3 : m = True
                    Case "p" : Y = &HE4 : m = True
                    Case "q" : Y = &HE5 : m = True
                    Case "r" : Y = &HE6 : m = True
                    Case "s" : Y = &HE7 : m = True
                    Case "t" : Y = &HE8 : m = True
                    Case "u" : Y = &HE9 : m = True
                    Case "v" : Y = &HEA : m = True
                    Case "w" : Y = &HEB : m = True
                    Case "x" : Y = &HEC : m = True
                    Case "y" : Y = &HED : m = True
                    Case "z" : Y = &HEE : m = True
                    Case ":" : Y = &HF0 : m = True
                    Case "Ä" : Y = &HF1 : m = True
                    Case "Ö" : Y = &HF2 : m = True
                    Case "Ü" : Y = &HF3 : m = True
                    Case "ä" : Y = &HF4 : m = True
                    Case "ö" : Y = &HF5 : m = True
                    Case "ü" : Y = &HF6 : m = True

                        'This whole thing auto-converted from TBL file
                    Case "あ" : Y = &H1 '"a"
                    Case "い" : Y = &H2 '"i"
                    Case "う" : Y = &H3 '"u"
                    Case "え" : Y = &H4 '"e"
                    Case "お" : Y = &H5 '"o"
                    Case "か" : Y = &H6 '"ka"
                    Case "き" : Y = &H7 '"ki"
                    Case "く" : Y = &H8 '"ku"
                    Case "け" : Y = &H9 '"ke"
                    Case "こ" : Y = &HA '"ko"
                    Case "さ" : Y = &HB '"sa"
                    Case "し" : Y = &HC '"shi"
                    Case "す" : Y = &HD '"su"
                    Case "せ" : Y = &HE '"se"
                    Case "そ" : Y = &HF '"so"
                    Case "た" : Y = &H10 '"ta"
                    Case "ち" : Y = &H11 '"chi"
                    Case "つ" : Y = &H12 '"tsu"
                    Case "て" : Y = &H13 '"te"
                    Case "と" : Y = &H14 '"to"
                    Case "な" : Y = &H15 '"na"
                    Case "に" : Y = &H16 '"ni"
                    Case "ぬ" : Y = &H17 '"nu"
                    Case "ね" : Y = &H18 '"ne"
                    Case "の" : Y = &H19 '"no"
                    Case "は" : Y = &H1A '"ha"
                    Case "ひ" : Y = &H1B '"hi"
                    Case "ふ" : Y = &H1C '"fu"
                    Case "へ" : Y = &H1D '"he"
                    Case "ほ" : Y = &H1E '"ho"
                    Case "ま" : Y = &H1F '"ma"
                    Case "み" : Y = &H20 '"mi"
                    Case "む" : Y = &H21 '"mu"
                    Case "め" : Y = &H22 '"me"
                    Case "も" : Y = &H23 '"mo"
                    Case "や" : Y = &H24 '"ya"
                    Case "ゆ" : Y = &H25 '"yu"
                    Case "よ" : Y = &H26 '"yo"        
                    Case "ら" : Y = &H27 '"ra"
                    Case "り" : Y = &H28 '"ri"
                    Case "る" : Y = &H29 '"ru"
                    Case "れ" : Y = &H2A '"re"
                    Case "ろ" : Y = &H2B '"ro"
                    Case "わ" : Y = &H2C '"wa"
                    Case "を" : Y = &H2D '"wo"
                    Case "ん" : Y = &H2E '"n"
                    Case "ぁ" : Y = &H2F '"la"
                    Case "ぃ" : Y = &H30  '"li"
                    Case "ぅ" : Y = &H31 '"lu"
                    Case "ぇ" : Y = &H32 '"le"
                    Case "ぉ" : Y = &H33 '"lo"
                    Case "ゃ" : Y = &H34 '"lya"
                    Case "ゅ" : Y = &H35 '"lyu"
                    Case "ょ" : Y = &H36 '"lyo"
                    Case "が" : Y = &H37 '"ga"
                    Case "ぎ" : Y = &H38 '"gi"
                    Case "ぐ" : Y = &H39 '"gu"
                    Case "げ" : Y = &H3A '"ge"
                    Case "ご" : Y = &H3B '"go"
                    Case "ざ" : Y = &H3C '"za"
                    Case "じ" : Y = &H3D '"ji"
                    Case "ず" : Y = &H3E '"zu"
                    Case "ぜ" : Y = &H3F '"ze"
                    Case "ぞ" : Y = &H40 '"zo"
                    Case "だ" : Y = &H41 '"da"
                    Case "ぢ" : Y = &H42 '"dji"
                    Case "づ" : Y = &H43 '"dzu"
                    Case "で" : Y = &H44 '"de"
                    Case "ど" : Y = &H45 '"do"
                    Case "ば" : Y = &H46 '"ba"
                    Case "び" : Y = &H47 '"bi"
                    Case "ぶ" : Y = &H48 '"bu"
                    Case "べ" : Y = &H49 '"be"
                    Case "ぼ" : Y = &H4A '"bo"
                    Case "ぱ" : Y = &H4B '"pa"
                    Case "ぴ" : Y = &H4C '"pi"
                    Case "ぷ" : Y = &H4D '"pu"
                    Case "ぺ" : Y = &H4E '"pe"
                    Case "ぽ" : Y = &H4F '"po"
                    Case "っ" : Y = &H50 '"ltsu"
                    Case "ア" : Y = &H51 '"A"
                    Case "イ" : Y = &H52 '"I"
                    Case "ウ" : Y = &H53 '"U"
                    Case "エ" : Y = &H54 '"E"
                    Case "オ" : Y = &H55 '"O"
                    Case "カ" : Y = &H56 '"KA"
                    Case "キ" : Y = &H57 '"KI"
                    Case "ク" : Y = &H58 '"KU"
                    Case "ケ" : Y = &H59 '"KE"
                    Case "コ" : Y = &H5A '"KO"
                    Case "サ" : Y = &H5B '"SA"
                    Case "シ" : Y = &H5C '"SHI"
                    Case "ス" : Y = &H5D '"SU"
                    Case "セ" : Y = &H5E '"SE"
                    Case "ソ" : Y = &H5F '"SO"
                    Case "タ" : Y = &H60  '"TA"
                    Case "チ" : Y = &H61  '"CHI"
                    Case "ツ" : Y = &H62 '"TSU"
                    Case "テ" : Y = &H63 '"TE"
                    Case "ト" : Y = &H64 '"TO"
                    Case "ナ" : Y = &H65  '"NA"
                    Case "ニ" : Y = &H66 '"NI"
                    Case "ヌ" : Y = &H67 '"NU"
                    Case "ネ" : Y = &H68 '"NE"
                    Case "ノ" : Y = &H69 '"NO"
                    Case "ハ" : Y = &H6A '"HA"
                    Case "ヒ" : Y = &H6B '"HI"
                    Case "フ" : Y = &H6C '"FU"
                    Case "ヘ" : Y = &H6D '"HE"
                    Case "ホ" : Y = &H6E '"HO"
                    Case "マ" : Y = &H6F '"MA"
                    Case "ミ" : Y = &H70  '"MI"
                    Case "ム" : Y = &H71 '"MU"
                    Case "メ" : Y = &H72 '"ME"
                    Case "モ" : Y = &H73 '"MO"
                    Case "ヤ" : Y = &H74 '"YA"
                    Case "ユ" : Y = &H75 '"YU"
                    Case "ヨ" : Y = &H76 '"YO"
                    Case "ラ" : Y = &H77 '"RA"
                    Case "リ" : Y = &H78 '"RI"
                    Case "ル" : Y = &H79 '"RU"
                    Case "レ" : Y = &H7A '"RE"
                    Case "ロ" : Y = &H7B '"RO"
                    Case "ワ" : Y = &H7C '"WA"
                    Case "ヲ" : Y = &H7D '"WO"
                    Case "ン" : Y = &H7E '"N"
                    Case "ァ" : Y = &H7F '"LA"
                    Case "ィ" : Y = &H80 '"LI"
                    Case "ゥ" : Y = &H81 '"LU"
                    Case "ェ" : Y = &H82 '"LE"
                    Case "ォ" : Y = &H83  '"LO"
                    Case "ャ" : Y = &H84 '"LYA"
                    Case "ュ" : Y = &H85  '"LYU"
                    Case "ョ" : Y = &H86 '"LYO"
                    Case "ガ" : Y = &H87 '"GA"
                    Case "ギ" : Y = &H88 '"GI"
                    Case "グ" : Y = &H89  '"GU"
                    Case "ゲ" : Y = &H8A '"GE"
                    Case "ゴ" : Y = &H8B '"GO"
                    Case "ザ" : Y = &H8C  '"ZA"
                    Case "ジ" : Y = &H8D '"JI"
                    Case "ズ" : Y = &H8E  '"ZU"
                    Case "ゼ" : Y = &H8F  '"ZE"
                    Case "ゾ" : Y = &H90 '"ZO"
                    Case "ダ" : Y = &H91 '"DA"
                    Case "ヂ" : Y = &H92 '"DJI"
                    Case "ヅ" : Y = &H93 '"DZU"
                    Case "デ" : Y = &H94  '"DE"
                    Case "ド" : Y = &H95 '"DO"
                    Case "バ" : Y = &H96  '"BA"
                    Case "ビ" : Y = &H97 '"BI"
                    Case "ブ" : Y = &H98 '"BU"
                    Case "ベ" : Y = &H99 '"BE"
                    Case "ボ" : Y = &H9A  '"BO"
                    Case "パ" : Y = &H9B  '"PA"
                    Case "ピ" : Y = &H9C  '"PI"
                    Case "プ" : Y = &H9D  '"PU"
                    Case "ペ" : Y = &H9E '"PE"
                    Case "ポ" : Y = &H9F  '"PO"
                    Case "ッ" : Y = &HA0  '"LTSU"
                End Select
            End If
            If m = False Then Y = &H0
            o = o & Chr(Y)
        Next i
        Asc2Sapp = o
    End Function

    Public Function Sapp2Asc(ByVal sappstring As String, Optional ByVal japanese As Boolean = False) As String
        Dim Y As String
        Dim n As Boolean
        o = ""
        For i = 1 To Len(sappstring)
            X = IIf(Mid(sappstring, i, 1) = "", 0, Asc(Mid(sappstring, i, 1)))
            If n = True Then
                Y = "\h" & IIf(Len(Hex(X)) < 2, "0" & Hex(X), Hex(X))
                n = False
            Else
                If japanese Then
                    Select Case X

                        'This whole thing auto-converted from TBL file
                        Case &H0 : Y = " "
                        Case &H1 : Y = "あ" '"a"
                        Case &H2 : Y = "い" '"i"
                        Case &H3 : Y = "う" '"u"
                        Case &H4 : Y = "え" '"e"
                        Case &H5 : Y = "お" '"o"
                        Case &H6 : Y = "か" '"ka"
                        Case &H7 : Y = "き" '"ki"
                        Case &H8 : Y = "く" '"ku"
                        Case &H9 : Y = "け" '"ke"
                        Case &HA : Y = "こ" '"ko"
                        Case &HB : Y = "さ" '"sa"
                        Case &HC : Y = "し" '"shi"
                        Case &HD : Y = "す" '"su"
                        Case &HE : Y = "せ" '"se"
                        Case &HF : Y = "そ" '"so"
                        Case &H10 : Y = "た" '"ta"
                        Case &H11 : Y = "ち" '"chi"
                        Case &H12 : Y = "つ" '"tsu"
                        Case &H13 : Y = "て" '"te"
                        Case &H14 : Y = "と" '"to"
                        Case &H15 : Y = "な" '"na"
                        Case &H16 : Y = "に" '"ni"
                        Case &H17 : Y = "ぬ" '"nu"
                        Case &H18 : Y = "ね" '"ne"
                        Case &H19 : Y = "の" '"no"
                        Case &H1A : Y = "は" '"ha"
                        Case &H1B : Y = "ひ" '"hi"
                        Case &H1C : Y = "ふ" '"fu"
                        Case &H1D : Y = "へ" '"he"
                        Case &H1E : Y = "ほ" '"ho"
                        Case &H1F : Y = "ま" '"ma"
                        Case &H20 : Y = "み" '"mi"
                        Case &H21 : Y = "む" '"mu"
                        Case &H22 : Y = "め" '"me"
                        Case &H23 : Y = "も" '"mo"
                        Case &H24 : Y = "や" '"ya"
                        Case &H25 : Y = "ゆ" '"yu"
                        Case &H26 : Y = "よ" '"yo"        
                        Case &H27 : Y = "ら" '"ra"
                        Case &H28 : Y = "り" '"ri"
                        Case &H29 : Y = "る" '"ru"
                        Case &H2A : Y = "れ" '"re"
                        Case &H2B : Y = "ろ" '"ro"
                        Case &H2C : Y = "わ" '"wa"
                        Case &H2D : Y = "を" '"wo"
                        Case &H2E : Y = "ん" '"n"
                        Case &H2F : Y = "ぁ" '"la"
                        Case &H30 : Y = "ぃ" '"li"
                        Case &H31 : Y = "ぅ" '"lu"
                        Case &H32 : Y = "ぇ" '"le"
                        Case &H33 : Y = "ぉ" '"lo"
                        Case &H34 : Y = "ゃ" '"lya"
                        Case &H35 : Y = "ゅ" '"lyu"
                        Case &H36 : Y = "ょ" '"lyo"
                        Case &H37 : Y = "が" '"ga"
                        Case &H38 : Y = "ぎ" '"gi"
                        Case &H39 : Y = "ぐ" '"gu"
                        Case &H3A : Y = "げ" '"ge"
                        Case &H3B : Y = "ご" '"go"
                        Case &H3C : Y = "ざ" '"za"
                        Case &H3D : Y = "じ" '"ji"
                        Case &H3E : Y = "ず" '"zu"
                        Case &H3F : Y = "ぜ" '"ze"
                        Case &H40 : Y = "ぞ" '"zo"
                        Case &H41 : Y = "だ" '"da"
                        Case &H42 : Y = "ぢ" '"dji"
                        Case &H43 : Y = "づ" '"dzu"
                        Case &H44 : Y = "で" '"de"
                        Case &H45 : Y = "ど" '"do"
                        Case &H46 : Y = "ば" '"ba"
                        Case &H47 : Y = "び" '"bi"
                        Case &H48 : Y = "ぶ" '"bu"
                        Case &H49 : Y = "べ" '"be"
                        Case &H4A : Y = "ぼ" '"bo"
                        Case &H4B : Y = "ぱ" '"pa"
                        Case &H4C : Y = "ぴ" '"pi"
                        Case &H4D : Y = "ぷ" '"pu"
                        Case &H4E : Y = "ぺ" '"pe"
                        Case &H4F : Y = "ぽ" '"po"
                        Case &H50 : Y = "っ" '"ltsu"
                        Case &H51 : Y = "ア" '"A"
                        Case &H52 : Y = "イ" '"I"
                        Case &H53 : Y = "ウ" '"U"
                        Case &H54 : Y = "エ" '"E"
                        Case &H55 : Y = "オ" '"O"
                        Case &H56 : Y = "カ" '"KA"
                        Case &H57 : Y = "キ" '"KI"
                        Case &H58 : Y = "ク" '"KU"
                        Case &H59 : Y = "ケ" '"KE"
                        Case &H5A : Y = "コ" '"KO"
                        Case &H5B : Y = "サ" '"SA"
                        Case &H5C : Y = "シ" '"SHI"
                        Case &H5D : Y = "ス" '"SU"
                        Case &H5E : Y = "セ" '"SE"
                        Case &H5F : Y = "ソ" '"SO"
                        Case &H60 : Y = "タ" '"TA"
                        Case &H61 : Y = "チ" '"CHI"
                        Case &H62 : Y = "ツ" '"TSU"
                        Case &H63 : Y = "テ" '"TE"
                        Case &H64 : Y = "ト" '"TO"
                        Case &H65 : Y = "ナ" '"NA"
                        Case &H66 : Y = "ニ" '"NI"
                        Case &H67 : Y = "ヌ" '"NU"
                        Case &H68 : Y = "ネ" '"NE"
                        Case &H69 : Y = "ノ" '"NO"
                        Case &H6A : Y = "ハ" '"HA"
                        Case &H6B : Y = "ヒ" '"HI"
                        Case &H6C : Y = "フ" '"FU"
                        Case &H6D : Y = "ヘ" '"HE"
                        Case &H6E : Y = "ホ" '"HO"
                        Case &H6F : Y = "マ" '"MA"
                        Case &H70 : Y = "ミ" '"MI"
                        Case &H71 : Y = "ム" '"MU"
                        Case &H72 : Y = "メ" '"ME"
                        Case &H73 : Y = "モ" '"MO"
                        Case &H74 : Y = "ヤ" '"YA"
                        Case &H75 : Y = "ユ" '"YU"
                        Case &H76 : Y = "ヨ" '"YO"
                        Case &H77 : Y = "ラ" '"RA"
                        Case &H78 : Y = "リ" '"RI"
                        Case &H79 : Y = "ル" '"RU"
                        Case &H7A : Y = "レ" '"RE"
                        Case &H7B : Y = "ロ" '"RO"
                        Case &H7C : Y = "ワ" '"WA"
                        Case &H7D : Y = "ヲ" '"WO"
                        Case &H7E : Y = "ン" '"N"
                        Case &H7F : Y = "ァ" '"LA"
                        Case &H80 : Y = "ィ" '"LI"
                        Case &H81 : Y = "ゥ" '"LU"
                        Case &H82 : Y = "ェ" '"LE"
                        Case &H83 : Y = "ォ" '"LO"
                        Case &H84 : Y = "ャ" '"LYA"
                        Case &H85 : Y = "ュ" '"LYU"
                        Case &H86 : Y = "ョ" '"LYO"
                        Case &H87 : Y = "ガ" '"GA"
                        Case &H88 : Y = "ギ" '"GI"
                        Case &H89 : Y = "グ" '"GU"
                        Case &H8A : Y = "ゲ" '"GE"
                        Case &H8B : Y = "ゴ" '"GO"
                        Case &H8C : Y = "ザ" '"ZA"
                        Case &H8D : Y = "ジ" '"JI"
                        Case &H8E : Y = "ズ" '"ZU"
                        Case &H8F : Y = "ゼ" '"ZE"
                        Case &H90 : Y = "ゾ" '"ZO"
                        Case &H91 : Y = "ダ" '"DA"
                        Case &H92 : Y = "ヂ" '"DJI"
                        Case &H93 : Y = "ヅ" '"DZU"
                        Case &H94 : Y = "デ" '"DE"
                        Case &H95 : Y = "ド" '"DO"
                        Case &H96 : Y = "バ" '"BA"
                        Case &H97 : Y = "ビ" '"BI"
                        Case &H98 : Y = "ブ" '"BU"
                        Case &H99 : Y = "ベ" '"BE"
                        Case &H9A : Y = "ボ" '"BO"
                        Case &H9B : Y = "パ" '"PA"
                        Case &H9C : Y = "ピ" '"PI"
                        Case &H9D : Y = "プ" '"PU"
                        Case &H9E : Y = "ペ" '"PE"
                        Case &H9F : Y = "ポ" '"PO"
                        Case &HA0 : Y = "ッ" '"LTSU"
                        Case &HA1 : Y = "0"
                        Case &HA2 : Y = "1"
                        Case &HA3 : Y = "2"
                        Case &HA4 : Y = "3"
                        Case &HA5 : Y = "4"
                        Case &HA6 : Y = "5"
                        Case &HA7 : Y = "6"
                        Case &HA8 : Y = "7"
                        Case &HA9 : Y = "8"
                        Case &HAA : Y = "9"
                        Case &HAB : Y = "!"
                        Case &HAC : Y = "?"
                        Case &HAD : Y = "."
                        Case &HAE : Y = "ー"
                        Case &HAF : Y = "ｷ"
                        Case &HFA : Y = "\l"
                        Case &HFB : Y = "\p"
                        Case &HFC : Y = "\c" : n = True
                        Case &HFD : Y = "\v" : n = True
                        Case &HFE : Y = "\n"
                        Case &HFF : Y = "\x"

                        Case &H7C : Y = " "
                        Case &H80 : Y = ""
                        Case Else : Y = "\h" & IIf(Len(Hex(X)) < 2, "0" & Hex(X), Hex(X))
                    End Select
                Else
                    Select Case X
                        Case &H0 : Y = " "
                        Case &H1 : Y = "À"
                        Case &H2 : Y = "Á"
                        Case &H3 : Y = "Â"
                        Case &H4 : Y = "Ç"
                        Case &H5 : Y = "È"
                        Case &H6 : Y = "É"
                        Case &H7 : Y = "Ê"
                        Case &H8 : Y = "Ë"
                        Case &H9 : Y = "Ì"
                        Case &HB : Y = "Î"
                        Case &HC : Y = "Ï"
                        Case &HD : Y = "Ò"
                        Case &HE : Y = "Ó"
                        Case &HF : Y = "Ô"
                        Case &H10 : Y = "Œ"
                        Case &H11 : Y = "Ù"
                        Case &H12 : Y = "Ú"
                        Case &H13 : Y = "Û"
                        Case &H15 : Y = "ß"
                        Case &H16 : Y = "à"
                        Case &H17 : Y = "á"
                        Case &H19 : Y = "ç"
                        Case &H1A : Y = "è"
                        Case &H1B : Y = "é"
                        Case &H1C : Y = "ê"
                        Case &H1D : Y = "ë"
                        Case &H1E : Y = "ì"
                        Case &H20 : Y = "î"
                        Case &H21 : Y = "ï"
                        Case &H22 : Y = "ò"
                        Case &H23 : Y = "ó"
                        Case &H24 : Y = "œ"
                        Case &H25 : Y = "ù"
                        Case &H26 : Y = "ú"
                        Case &H28 : Y = "°"
                        Case &H29 : Y = "ª"
                        Case &H2B : Y = "&"
                        Case &H2C : Y = "+"
                        Case &H2D : Y = "&"
                        Case &H34 : Y = "[Lv]"
                        Case &H35 : Y = "="
                        Case &H51 : Y = "¿"
                        Case &H52 : Y = "¡"
                        Case &H53 : Y = "[PK]"
                        Case &H54 : Y = "[MN]"
                        Case &H55 : Y = "[PO]"
                        Case &H56 : Y = "[Ke]"
                        Case &H57 : Y = "[BL]"
                        Case &H58 : Y = "[OC]"
                        Case &H59 : Y = "[K]"
                        Case &H5A : Y = "Í"
                        Case &H5B : Y = "%"
                        Case &H5C : Y = "("
                        Case &H5D : Y = ")"
                        Case &H68 : Y = "â"
                        Case &H6F : Y = "í"
                        Case &H79 : Y = "[U]"
                        Case &H7A : Y = "[D]"
                        Case &H7B : Y = "[L]"
                        Case &H7C : Y = "[R]"
                        Case &HA1 : Y = "0"
                        Case &HA2 : Y = "1"
                        Case &HA3 : Y = "2"
                        Case &HA4 : Y = "3"
                        Case &HA5 : Y = "4"
                        Case &HA6 : Y = "5"
                        Case &HA7 : Y = "6"
                        Case &HA8 : Y = "7"
                        Case &HA9 : Y = "8"
                        Case &HAA : Y = "9"
                        Case &HAB : Y = "!"
                        Case &HAC : Y = "?"
                        Case &HAD : Y = "."
                        Case &HAE : Y = "-"
                        Case &HAF : Y = "·"
                        Case &HB0 : Y = "[.]"
                        Case &HB1 : Y = "[""]"
                        Case &HB2 : Y = """"
                        Case &HB3 : Y = "[']"
                        Case &HB4 : Y = "'"
                        Case &HB5 : Y = "♂"
                        Case &HB6 : Y = "♀"
                        Case &HB7 : Y = "[p]"
                        Case &HB8 : Y = ","
                        Case &HB9 : Y = "[x]"
                        Case &HBA : Y = "/"
                        Case &HBB : Y = "A"
                        Case &HBC : Y = "B"
                        Case &HBD : Y = "C"
                        Case &HBE : Y = "D"
                        Case &HBF : Y = "E"
                        Case &HC0 : Y = "F"
                        Case &HC1 : Y = "G"
                        Case &HC2 : Y = "H"
                        Case &HC3 : Y = "I"
                        Case &HC4 : Y = "J"
                        Case &HC5 : Y = "K"
                        Case &HC6 : Y = "L"
                        Case &HC7 : Y = "M"
                        Case &HC8 : Y = "N"
                        Case &HC9 : Y = "O"
                        Case &HCA : Y = "P"
                        Case &HCB : Y = "Q"
                        Case &HCC : Y = "R"
                        Case &HCD : Y = "S"
                        Case &HCE : Y = "T"
                        Case &HCF : Y = "U"
                        Case &HD0 : Y = "V"
                        Case &HD1 : Y = "W"
                        Case &HD2 : Y = "X"
                        Case &HD3 : Y = "Y"
                        Case &HD4 : Y = "Z"
                        Case &HD5 : Y = "a"
                        Case &HD6 : Y = "b"
                        Case &HD7 : Y = "c"
                        Case &HD8 : Y = "d"
                        Case &HD9 : Y = "e"
                        Case &HDA : Y = "f"
                        Case &HDB : Y = "g"
                        Case &HDC : Y = "h"
                        Case &HDD : Y = "i"
                        Case &HDE : Y = "j"
                        Case &HDF : Y = "k"
                        Case &HE0 : Y = "l"
                        Case &HE1 : Y = "m"
                        Case &HE2 : Y = "n"
                        Case &HE3 : Y = "o"
                        Case &HE4 : Y = "p"
                        Case &HE5 : Y = "q"
                        Case &HE6 : Y = "r"
                        Case &HE7 : Y = "s"
                        Case &HE8 : Y = "t"
                        Case &HE9 : Y = "u"
                        Case &HEA : Y = "v"
                        Case &HEB : Y = "w"
                        Case &HEC : Y = "x"
                        Case &HED : Y = "y"
                        Case &HEE : Y = "z"
                        Case &HEF : Y = "[>]"
                        Case &HF0 : Y = ":"
                        Case &HF1 : Y = "Ä"
                        Case &HF2 : Y = "Ö"
                        Case &HF3 : Y = "Ü"
                        Case &HF4 : Y = "ä"
                        Case &HF5 : Y = "ö"
                        Case &HF6 : Y = "ü"
                        Case &HF7 : Y = "[u]"
                        Case &HF8 : Y = "[d]"
                        Case &HF9 : Y = "[l]"
                        Case &HFA : Y = "\l"
                        Case &HFB : Y = "\p"
                        Case &HFC : Y = "" 'n = True
                        Case &HFD : Y = "\v" 'n = True
                        Case &HFE : Y = "\n"
                        Case &HFF : Y = "\x"
                        Case Else : Y = "\h" & IIf(Len(Hex(X)) < 2, "0" & Hex(X), Hex(X))
                    End Select
                End If
            End If
            o = o & Y
        Next i
        Sapp2Asc = o
    End Function

    'Public Function Sapp2AscTabled(ByVal sappstring As String, Optional japanese As Boolean) As String
    '  Dim mytable(256) As String
    '  Dim i As String
    '  Dim a As Integer, b As Integer, c As Integer
    '  Dim ff As Integer
    '  ff = FreeFile
    '  Open "obsidian.tbl" For Input As ff
    '  While Not EOF(ff)
    '    Line Input #ff, i
    '    c = Val("&H" & Left(i, 2))
    '    mytable(c) = Mid(i, 4)
    '  Wend
    '  Close #ff
    '  i = ""
    '  For a = 1 To Len(sappstring)
    '    c = Asc(Mid(sappstring, a, 1))
    '    If mytable(c) = "" Then
    '      i = i & "\h" & Right("  " & Hex(c), 2)
    '    Else
    '      i = i & mytable(c)
    '    End If
    '  Next a
    '  Sapp2Asc = i
    'End Function

    Private Function IsHex(ByVal hexstring As String) As Boolean
        Dim z As Boolean
        Dim Y As Byte
        For i = 1 To Len(hexstring)
            Y = Asc(Mid(hexstring, i, 1))
            z = IIf((Y > 47 And Y < 58) Or (Y > 64 And Y < 71) Or (Y > 96 And Y < 103), True, False)
            If z = False Then Exit For
        Next i
        IsHex = z
    End Function

    Private Function Hex2(ByVal indec As Long, Optional ByVal digits As Byte = 2) As String
        X = Hex(indec)
        Do While Len(X) < digits
            X = "0" & X
        Loop
        Hex2 = X
    End Function

    Public Function NameAsc2Sapp(ByVal asciistring As String) As String
        o = ""

        Dim m As Boolean
        For i = 1 To Len(asciistring)
            m = False

            If m = False Then
                Select Case Mid(asciistring, i, 1)
                    Case " " : Y = &H0 : m = True
                    Case "À" : Y = &H1 : m = True
                    Case "Á" : Y = &H2 : m = True
                    Case "Â" : Y = &H3 : m = True
                    Case "Ç" : Y = &H4 : m = True
                    Case "È" : Y = &H5 : m = True
                    Case "É" : Y = &H6 : m = True
                    Case "Ê" : Y = &H7 : m = True
                    Case "Ë" : Y = &H8 : m = True
                    Case "Ì" : Y = &H9 : m = True
                    Case "Î" : Y = &HB : m = True
                    Case "Ï" : Y = &HC : m = True
                    Case "Ò" : Y = &HD : m = True
                    Case "Ó" : Y = &HE : m = True
                    Case "Ô" : Y = &HF : m = True
                    Case "Œ" : Y = &H10 : m = True
                    Case "Ù" : Y = &H11 : m = True
                    Case "Ú" : Y = &H12 : m = True
                    Case "Û" : Y = &H13 : m = True
                    Case "ß" : Y = &H15 : m = True
                    Case "à" : Y = &H16 : m = True
                    Case "á" : Y = &H17 : m = True
                    Case "ç" : Y = &H19 : m = True
                    Case "è" : Y = &H1A : m = True
                    Case "é" : Y = &H1B : m = True
                    Case "ê" : Y = &H1C : m = True
                    Case "ë" : Y = &H1D : m = True
                    Case "ì" : Y = &H1E : m = True
                    Case "î" : Y = &H20 : m = True
                    Case "ï" : Y = &H21 : m = True
                    Case "ò" : Y = &H22 : m = True
                    Case "ó" : Y = &H23 : m = True
                    Case "œ" : Y = &H24 : m = True
                    Case "ù" : Y = &H25 : m = True
                    Case "ú" : Y = &H26 : m = True
                    Case "°" : Y = &H28 : m = True
                    Case "ª" : Y = &H29 : m = True
                    Case "+" : Y = &H2C : m = True
                    Case "&" : Y = &H2D : m = True
                    Case "=" : Y = &H35 : m = True
                    Case "¿" : Y = &H51 : m = True
                    Case "¡" : Y = &H52 : m = True
                    Case "Í" : Y = &H5A : m = True
                    Case "%" : Y = &H5B : m = True
                    Case "(" : Y = &H5C : m = True
                    Case ")" : Y = &H5D : m = True
                    Case "â" : Y = &H68 : m = True
                    Case "í" : Y = &H6F : m = True
                    Case "0" : Y = &HA1 : m = True
                    Case "1" : Y = &HA2 : m = True
                    Case "2" : Y = &HA3 : m = True
                    Case "3" : Y = &HA4 : m = True
                    Case "4" : Y = &HA5 : m = True
                    Case "5" : Y = &HA6 : m = True
                    Case "6" : Y = &HA7 : m = True
                    Case "7" : Y = &HA8 : m = True
                    Case "8" : Y = &HA9 : m = True
                    Case "9" : Y = &HAA : m = True
                    Case "!" : Y = &HAB : m = True
                    Case "?" : Y = &HAC : m = True
                    Case "." : Y = &HAD : m = True
                    Case "-" : Y = &HAE : m = True
                    Case "·" : Y = &HAF : m = True
                    Case "," : Y = &HB8 : m = True
                    Case """" : Y = &HB2 : m = True
                    Case "'" : Y = &HB4 : m = True
                    Case "/" : Y = &HBA : m = True
                    Case "A" : Y = &HBB : m = True
                    Case "B" : Y = &HBC : m = True
                    Case "C" : Y = &HBD : m = True
                    Case "D" : Y = &HBE : m = True
                    Case "E" : Y = &HBF : m = True
                    Case "F" : Y = &HC0 : m = True
                    Case "G" : Y = &HC1 : m = True
                    Case "H" : Y = &HC2 : m = True
                    Case "I" : Y = &HC3 : m = True
                    Case "J" : Y = &HC4 : m = True
                    Case "K" : Y = &HC5 : m = True
                    Case "L" : Y = &HC6 : m = True
                    Case "M" : Y = &HC7 : m = True
                    Case "N" : Y = &HC8 : m = True
                    Case "O" : Y = &HC9 : m = True
                    Case "P" : Y = &HCA : m = True
                    Case "Q" : Y = &HCB : m = True
                    Case "R" : Y = &HCC : m = True
                    Case "S" : Y = &HCD : m = True
                    Case "T" : Y = &HCE : m = True
                    Case "U" : Y = &HCF : m = True
                    Case "V" : Y = &HD0 : m = True
                    Case "W" : Y = &HD1 : m = True
                    Case "X" : Y = &HD2 : m = True
                    Case "Y" : Y = &HD3 : m = True
                    Case "Z" : Y = &HD4 : m = True
                    Case "a" : Y = &HD5 : m = True
                    Case "b" : Y = &HD6 : m = True
                    Case "c" : Y = &HD7 : m = True
                    Case "d" : Y = &HD8 : m = True
                    Case "e" : Y = &HD9 : m = True
                    Case "f" : Y = &HDA : m = True
                    Case "g" : Y = &HDB : m = True
                    Case "h" : Y = &HDC : m = True
                    Case "i" : Y = &HDD : m = True
                    Case "j" : Y = &HDE : m = True
                    Case "k" : Y = &HDF : m = True
                    Case "l" : Y = &HE0 : m = True
                    Case "m" : Y = &HE1 : m = True
                    Case "n" : Y = &HE2 : m = True
                    Case "o" : Y = &HE3 : m = True
                    Case "p" : Y = &HE4 : m = True
                    Case "q" : Y = &HE5 : m = True
                    Case "r" : Y = &HE6 : m = True
                    Case "s" : Y = &HE7 : m = True
                    Case "t" : Y = &HE8 : m = True
                    Case "u" : Y = &HE9 : m = True
                    Case "v" : Y = &HEA : m = True
                    Case "w" : Y = &HEB : m = True
                    Case "x" : Y = &HEC : m = True
                    Case "y" : Y = &HED : m = True
                    Case "z" : Y = &HEE : m = True
                    Case ":" : Y = &HF0 : m = True
                    Case "Ä" : Y = &HF1 : m = True
                    Case "Ö" : Y = &HF2 : m = True
                    Case "Ü" : Y = &HF3 : m = True
                    Case "ä" : Y = &HF4 : m = True
                    Case "ö" : Y = &HF5 : m = True
                    Case "ü" : Y = &HF6 : m = True
                    Case "♂" : Y = &HB5 : m = True
                    Case "♀" : Y = &HB6 : m = True

                        'This whole thing auto-converted from TBL file
                    Case "あ" : Y = &H1 '"a"
                    Case "い" : Y = &H2 '"i"
                    Case "う" : Y = &H3 '"u"
                    Case "え" : Y = &H4 '"e"
                    Case "お" : Y = &H5 '"o"
                    Case "か" : Y = &H6 '"ka"
                    Case "き" : Y = &H7 '"ki"
                    Case "く" : Y = &H8 '"ku"
                    Case "け" : Y = &H9 '"ke"
                    Case "こ" : Y = &HA '"ko"
                    Case "さ" : Y = &HB '"sa"
                    Case "し" : Y = &HC '"shi"
                    Case "す" : Y = &HD '"su"
                    Case "せ" : Y = &HE '"se"
                    Case "そ" : Y = &HF '"so"
                    Case "た" : Y = &H10 '"ta"
                    Case "ち" : Y = &H11 '"chi"
                    Case "つ" : Y = &H12 '"tsu"
                    Case "て" : Y = &H13 '"te"
                    Case "と" : Y = &H14 '"to"
                    Case "な" : Y = &H15 '"na"
                    Case "に" : Y = &H16 '"ni"
                    Case "ぬ" : Y = &H17 '"nu"
                    Case "ね" : Y = &H18 '"ne"
                    Case "の" : Y = &H19 '"no"
                    Case "は" : Y = &H1A '"ha"
                    Case "ひ" : Y = &H1B '"hi"
                    Case "ふ" : Y = &H1C '"fu"
                    Case "へ" : Y = &H1D '"he"
                    Case "ほ" : Y = &H1E '"ho"
                    Case "ま" : Y = &H1F '"ma"
                    Case "み" : Y = &H20 '"mi"
                    Case "む" : Y = &H21 '"mu"
                    Case "め" : Y = &H22 '"me"
                    Case "も" : Y = &H23 '"mo"
                    Case "や" : Y = &H24 '"ya"
                    Case "ゆ" : Y = &H25 '"yu"
                    Case "よ" : Y = &H26 '"yo"        
                    Case "ら" : Y = &H27 '"ra"
                    Case "り" : Y = &H28 '"ri"
                    Case "る" : Y = &H29 '"ru"
                    Case "れ" : Y = &H2A '"re"
                    Case "ろ" : Y = &H2B '"ro"
                    Case "わ" : Y = &H2C '"wa"
                    Case "を" : Y = &H2D '"wo"
                    Case "ん" : Y = &H2E '"n"
                    Case "ぁ" : Y = &H2F '"la"
                    Case "ぃ" : Y = &H30  '"li"
                    Case "ぅ" : Y = &H31 '"lu"
                    Case "ぇ" : Y = &H32 '"le"
                    Case "ぉ" : Y = &H33 '"lo"
                    Case "ゃ" : Y = &H34 '"lya"
                    Case "ゅ" : Y = &H35 '"lyu"
                    Case "ょ" : Y = &H36 '"lyo"
                    Case "が" : Y = &H37 '"ga"
                    Case "ぎ" : Y = &H38 '"gi"
                    Case "ぐ" : Y = &H39 '"gu"
                    Case "げ" : Y = &H3A '"ge"
                    Case "ご" : Y = &H3B '"go"
                    Case "ざ" : Y = &H3C '"za"
                    Case "じ" : Y = &H3D '"ji"
                    Case "ず" : Y = &H3E '"zu"
                    Case "ぜ" : Y = &H3F '"ze"
                    Case "ぞ" : Y = &H40 '"zo"
                    Case "だ" : Y = &H41 '"da"
                    Case "ぢ" : Y = &H42 '"dji"
                    Case "づ" : Y = &H43 '"dzu"
                    Case "で" : Y = &H44 '"de"
                    Case "ど" : Y = &H45 '"do"
                    Case "ば" : Y = &H46 '"ba"
                    Case "び" : Y = &H47 '"bi"
                    Case "ぶ" : Y = &H48 '"bu"
                    Case "べ" : Y = &H49 '"be"
                    Case "ぼ" : Y = &H4A '"bo"
                    Case "ぱ" : Y = &H4B '"pa"
                    Case "ぴ" : Y = &H4C '"pi"
                    Case "ぷ" : Y = &H4D '"pu"
                    Case "ぺ" : Y = &H4E '"pe"
                    Case "ぽ" : Y = &H4F '"po"
                    Case "っ" : Y = &H50 '"ltsu"
                    Case "ア" : Y = &H51 '"A"
                    Case "イ" : Y = &H52 '"I"
                    Case "ウ" : Y = &H53 '"U"
                    Case "エ" : Y = &H54 '"E"
                    Case "オ" : Y = &H55 '"O"
                    Case "カ" : Y = &H56 '"KA"
                    Case "キ" : Y = &H57 '"KI"
                    Case "ク" : Y = &H58 '"KU"
                    Case "ケ" : Y = &H59 '"KE"
                    Case "コ" : Y = &H5A '"KO"
                    Case "サ" : Y = &H5B '"SA"
                    Case "シ" : Y = &H5C '"SHI"
                    Case "ス" : Y = &H5D '"SU"
                    Case "セ" : Y = &H5E '"SE"
                    Case "ソ" : Y = &H5F '"SO"
                    Case "タ" : Y = &H60  '"TA"
                    Case "チ" : Y = &H61  '"CHI"
                    Case "ツ" : Y = &H62 '"TSU"
                    Case "テ" : Y = &H63 '"TE"
                    Case "ト" : Y = &H64 '"TO"
                    Case "ナ" : Y = &H65  '"NA"
                    Case "ニ" : Y = &H66 '"NI"
                    Case "ヌ" : Y = &H67 '"NU"
                    Case "ネ" : Y = &H68 '"NE"
                    Case "ノ" : Y = &H69 '"NO"
                    Case "ハ" : Y = &H6A '"HA"
                    Case "ヒ" : Y = &H6B '"HI"
                    Case "フ" : Y = &H6C '"FU"
                    Case "ヘ" : Y = &H6D '"HE"
                    Case "ホ" : Y = &H6E '"HO"
                    Case "マ" : Y = &H6F '"MA"
                    Case "ミ" : Y = &H70  '"MI"
                    Case "ム" : Y = &H71 '"MU"
                    Case "メ" : Y = &H72 '"ME"
                    Case "モ" : Y = &H73 '"MO"
                    Case "ヤ" : Y = &H74 '"YA"
                    Case "ユ" : Y = &H75 '"YU"
                    Case "ヨ" : Y = &H76 '"YO"
                    Case "ラ" : Y = &H77 '"RA"
                    Case "リ" : Y = &H78 '"RI"
                    Case "ル" : Y = &H79 '"RU"
                    Case "レ" : Y = &H7A '"RE"
                    Case "ロ" : Y = &H7B '"RO"
                    Case "ワ" : Y = &H7C '"WA"
                    Case "ヲ" : Y = &H7D '"WO"
                    Case "ン" : Y = &H7E '"N"
                    Case "ァ" : Y = &H7F '"LA"
                    Case "ィ" : Y = &H80 '"LI"
                    Case "ゥ" : Y = &H81 '"LU"
                    Case "ェ" : Y = &H82 '"LE"
                    Case "ォ" : Y = &H83  '"LO"
                    Case "ャ" : Y = &H84 '"LYA"
                    Case "ュ" : Y = &H85  '"LYU"
                    Case "ョ" : Y = &H86 '"LYO"
                    Case "ガ" : Y = &H87 '"GA"
                    Case "ギ" : Y = &H88 '"GI"
                    Case "グ" : Y = &H89  '"GU"
                    Case "ゲ" : Y = &H8A '"GE"
                    Case "ゴ" : Y = &H8B '"GO"
                    Case "ザ" : Y = &H8C  '"ZA"
                    Case "ジ" : Y = &H8D '"JI"
                    Case "ズ" : Y = &H8E  '"ZU"
                    Case "ゼ" : Y = &H8F  '"ZE"
                    Case "ゾ" : Y = &H90 '"ZO"
                    Case "ダ" : Y = &H91 '"DA"
                    Case "ヂ" : Y = &H92 '"DJI"
                    Case "ヅ" : Y = &H93 '"DZU"
                    Case "デ" : Y = &H94  '"DE"
                    Case "ド" : Y = &H95 '"DO"
                    Case "バ" : Y = &H96  '"BA"
                    Case "ビ" : Y = &H97 '"BI"
                    Case "ブ" : Y = &H98 '"BU"
                    Case "ベ" : Y = &H99 '"BE"
                    Case "ボ" : Y = &H9A  '"BO"
                    Case "パ" : Y = &H9B  '"PA"
                    Case "ピ" : Y = &H9C  '"PI"
                    Case "プ" : Y = &H9D  '"PU"
                    Case "ペ" : Y = &H9E '"PE"
                    Case "ポ" : Y = &H9F  '"PO"
                    Case "ッ" : Y = &HA0  '"LTSU"
                End Select
            End If
            If m = False Then Y = &H0
            o = o & Chr(Y)
        Next i
        NameAsc2Sapp = o
    End Function

End Module
