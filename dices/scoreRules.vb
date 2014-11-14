Public Class scoreRules
    Inherits dicesRules

    Public Function getUpperScore(ByVal dots As Integer)
        Dim score As Integer
        For Each dice In Me.dices
            If dice.getDots = dots Then
                score += dots
            End If
        Next
        Return score
    End Function

    Public Function get3ofKindScore()
        Dim score As Integer
        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("111") OrElse dotsString.Contains("222") OrElse dotsString.Contains("333") _
            OrElse dotsString.Contains("444") OrElse dotsString.Contains("555") OrElse dotsString.Contains("666") Then

            score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        End If
        Return score

    End Function

    Public Function get4ofKindScore()
        Dim score As Integer
        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("1111") OrElse dotsString.Contains("2222") OrElse dotsString.Contains("3333") _
            OrElse dotsString.Contains("4444") OrElse dotsString.Contains("5555") OrElse dotsString.Contains("6666") Then

            score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        End If
        Return score
    End Function

    Public Function getFullHouse()

        Dim score As Integer
        Dim countlist As New List(Of Integer) From {0, 0, 0, 0, 0, 0}

        For Each dice In Me.dices
            countlist(dice.getDots - 1) += 1
        Next

        If countlist.Contains(3) AndAlso countlist.Contains(2) Then
            score = 25
        End If
        Return score
    End Function

    Public Function getSmallStraight()
        Dim score As Integer

        Dim straight1 = New HashSet(Of Integer) From {1, 2, 3, 4}
        Dim straight2 = New HashSet(Of Integer) From {2, 3, 4, 5}
        Dim straight3 = New HashSet(Of Integer) From {3, 4, 5, 6}

        Dim dotsSet As New HashSet(Of Integer)

        For Each dice In Me.dices
            dotsSet.Add(dice.getDots)
        Next

        If straight1.IsSubsetOf(dotsSet) OrElse straight2.IsSubsetOf(dotsSet) OrElse straight3.IsSubsetOf(dotsSet) Then
            score = 30
        End If
        Return score
    End Function

    Public Function getLargeStraight()
        Dim score As Integer
        Dim straight1 = New HashSet(Of Integer) From {1, 2, 3, 4, 5}
        Dim straight2 = New HashSet(Of Integer) From {2, 3, 4, 5, 6}
        Dim dotsSet As New HashSet(Of Integer)

        For Each dice In Me.dices
            dotsSet.Add(dice.getDots)
        Next

        If straight1.SetEquals(dotsSet) OrElse straight2.SetEquals(dotsSet) Then
            score = 40
        End If
        Return score

    End Function

    Public Function getYahtzee()
        Dim score As Integer

        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("11111") OrElse dotsString.Contains("22222") OrElse dotsString.Contains("33333") _
            OrElse dotsString.Contains("44444") OrElse dotsString.Contains("55555") OrElse dotsString.Contains("66666") Then
            score = 50
        End If
        Return score
    End Function
    Public Function getChanceScore()
        Dim score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        Return score
    End Function

    Public Sub updateUpperScoreTotal()
        Dim score As Integer
        For i = 0 To 5
            score += Form1.DataGridView1.Rows(i).Cells(1).Value
        Next

        Form1.DataGridView1.Rows(7).Cells(1).Value = score
    End Sub

    Private Function dicesDotsToString()
        Dim dicesScores As New List(Of Integer)
        For Each dice In Me.dices
            dicesScores.Add(dice.getDots)
        Next
        dicesScores.Sort()
        Dim dotsString As String = String.Join("", dicesScores)
        Return dotsString
    End Function
End Class
