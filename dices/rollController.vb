Public Class rollController
    Public dices As New List(Of dice)
    Public rollCounter As New Integer
    Public Event dicesRolled()

    Public Sub rollDices()
        For Each dice In dices
            dice.roll()
        Next
        RaiseEvent dicesRolled()
    End Sub

    Public Sub enableRolling()
        Form1.Button1.Enabled = True
    End Sub

    Public Sub disableRolling()
        Form1.Button1.Enabled = False
    End Sub

    Public Sub getDices(ByVal dices As List(Of dice))
        Me.dices = dices
    End Sub

    Public Sub enableHoldingDices()
        For Each dice In Me.dices
            dice.enabled = True
        Next
    End Sub

    Public Sub disableHoldingDices()
        For Each dice In Me.dices
            dice.enabled = False
        Next
        For Each dice In game.dices
            dice.enabled = False
        Next
    End Sub

    Public Sub checkDicesHold()
        Dim counter As Integer
        For Each dice In dices
            If dice.getHold = True Then counter += 1
        Next

        If game.preGameOrPrescore = False Then
            If counter = 5 Then
                disableRolling()
            Else
                enableRolling()
            End If
        End If

    End Sub

    Private Sub incrementRollCounter() Handles Me.dicesRolled
        Me.rollCounter += 1
        If rollCounter = 3 Then
            game.preGameOrPrescore = True
            disableRolling()
            unholdDices()
            disableHoldingDices()
        End If
    End Sub

    Public Sub returnDices()
        game.dices = Me.dices
        Me.dices.Clear()
    End Sub

    Public Sub unholdDices()
        For Each dice In Me.dices
            dice.unhold()
        Next
    End Sub
End Class
