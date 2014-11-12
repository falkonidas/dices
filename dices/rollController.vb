Public Class rollController
    Inherits controller
    Public preGameOrPreScore As Boolean = True
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

    Public Sub enableHoldingDices()
        For Each dice In Me.dices
            dice.setEnabled(True)
        Next
    End Sub

    Public Sub disableHoldingDices()
        For Each dice In Me.dices
            dice.setEnabled(False)
        Next
    End Sub

    Public Sub checkDicesHold()

        Dim counter As Integer

        For Each dice In dices
            If dice.getHold = True Then counter += 1
        Next
        If preGameOrPreScore = False Then
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
            preGameOrPreScore = True
            disableRolling()
            unholdDices()
            disableHoldingDices()
        End If
    End Sub

    Public Sub unholdDices()
        For Each dice In Me.dices
            dice.unhold()
        Next
    End Sub
End Class
