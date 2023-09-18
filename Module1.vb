Imports System.Collections.Generic
Imports Humanizer

Module Module1

    Sub Main()

        Dim n As Integer = 1

        For i As Integer = 1 To 110000000 Step n
            Dim s As String = i.ToWords
            Dim j As Integer = WordsToNumbers.ConvertToNumbers(s)

            If j <> i Then Stop
        Next

        Console.ReadLine()

    End Sub

End Module

Class WordsToNumbers
    Private Shared numberTable As Dictionary(Of String, Long) = New Dictionary(Of String, Long) From {
        {"zero", 0},
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
        {"ten", 10},
        {"eleven", 11},
        {"twelve", 12},
        {"thirteen", 13},
        {"fourteen", 14},
        {"fifteen", 15},
        {"sixteen", 16},
        {"seventeen", 17},
        {"eighteen", 18},
        {"nineteen", 19},
        {"twenty", 20},
        {"thirty", 30},
        {"forty", 40},
        {"fifty", 50},
        {"sixty", 60},
        {"seventy", 70},
        {"eighty", 80},
        {"ninety", 90},
        {"hundred", 100},
        {"thousand", 1000},
        {"lakh", 100000},
        {"million", 1000000},
        {"billion", 1000000000},
        {"trillion", 1000000000000},
        {"quadrillion", 1000000000000000},
        {"quintillion", 1000000000000000000}
    }

    Public Shared Function ConvertToNumbers(ByVal numberString As String) As Long

        Dim parts() As String = numberString.Split({" "c, "-"c}, StringSplitOptions.RemoveEmptyEntries)
        Dim acc As Long = 0, total As Long = 0L
        Dim isNegative As Boolean = False

        For Each part As String In parts
            Dim value As Long = 0

            If part.Equals("and", StringComparison.InvariantCultureIgnoreCase) Then
                Continue For
            End If

            If part.Equals("minus", StringComparison.InvariantCultureIgnoreCase) Then
                isNegative = True
            ElseIf numberTable.ContainsKey(part) Then
                value = numberTable(part)
            End If

            If value = 100 Then
                acc *= value ' Multiply by 100 for "hundred"
            ElseIf value >= 1000 Then
                total += acc * value
                acc = 0
            Else
                acc += value
            End If
        Next

        Return (total + acc) * (If(isNegative, -1, 1))
    End Function
End Class
