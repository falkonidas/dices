Public Class scoreController
    Inherits controller
    Public Sub getScores()
        getUpperScore(1)
        getUpperScore(2)
        getUpperScore(3)
        getUpperScore(4)
        getUpperScore(5)
        getUpperScore(6)
        get3ofKindScore()
        get4ofKindScore()
        getSmallStraight()
        getLargeStraight()
        getYahtzee()
        getChanceScore()
    End Sub

    Public Sub getUpperScore(ByVal dots As Integer)
        Dim score As Integer
        For Each dice In Me.dices
            If dice.getDots = dots Then
                score += dots
            End If
        Next
        Form1.DataGridView1.Rows(dots - 1).Cells(1).Value = score
    End Sub

    Public Sub get3ofKindScore()
        Dim score As Integer
        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("111") OrElse dotsString.Contains("222") OrElse dotsString.Contains("333") _
            OrElse dotsString.Contains("444") OrElse dotsString.Contains("555") OrElse dotsString.Contains("666") Then

            score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        End If

        Form1.DataGridView1.Rows(8).Cells(1).Value = score
    End Sub

    Public Sub get4ofKindScore()
        Dim score As Integer
        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("1111") OrElse dotsString.Contains("2222") OrElse dotsString.Contains("3333") _
            OrElse dotsString.Contains("4444") OrElse dotsString.Contains("5555") OrElse dotsString.Contains("6666") Then

            score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        End If

        Form1.DataGridView1.Rows(9).Cells(1).Value = score
    End Sub


    Public Sub getSmallStraight()
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

        Form1.DataGridView1.Rows(12).Cells(1).Value = score

    End Sub

    Public Sub getLargeStraight()
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

        Form1.DataGridView1.Rows(13).Cells(1).Value = score
    End Sub

    Public Sub getYahtzee()
        Dim score As Integer

        Dim dotsString = dicesDotsToString()

        If dotsString.Contains("11111") OrElse dotsString.Contains("22222") OrElse dotsString.Contains("33333") _
            OrElse dotsString.Contains("44444") OrElse dotsString.Contains("55555") OrElse dotsString.Contains("66666") Then
            score = 50
        End If

        Form1.DataGridView1.Rows(14).Cells(1).Value = score
    End Sub
    Public Sub getChanceScore()
        Dim score = dices(0).getDots + dices(1).getDots + dices(2).getDots + dices(3).getDots + dices(4).getDots
        Form1.DataGridView1.Rows(15).Cells(1).Value = score
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
