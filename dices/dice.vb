Public Class dice
    Private isHold As Boolean = False
    Private Shared rnd As New Random
    Private rolledDots As Integer
    Private viewImage As Image
    Public Event diceStateChanged()
    Public enabled As Boolean = True

    Public Sub roll()
        If Me.isHold = False Then
            Me.rolledDots = rnd.Next(1, 7)
            setImage(Me.rolledDots)
            RaiseEvent diceStateChanged()
        End If
    End Sub

    Public Sub setHold()
        If enabled = True Then
            isHold = If(CBool(isHold), False, True)
            RaiseEvent diceStateChanged()
        End If
    End Sub

    Public Sub unhold()
        Me.isHold = False
        RaiseEvent diceStateChanged()
    End Sub

    Public Function getHold()
        Return isHold
    End Function

    Public Function getImage()
        Return viewImage
    End Function

    Public Sub clearDots()
        Me.rolledDots = 0
        RaiseEvent diceStateChanged()
    End Sub

    Public Function getDots()
        Return Me.rolledDots
    End Function

    Private Sub setImage(ByVal rolledDots)
        Select Case Me.rolledDots
            Case 1
                viewImage = My.Resources.Resource1.dot1
            Case 2
                viewImage = My.Resources.Resource1.dot2
            Case 3
                viewImage = My.Resources.Resource1.dot3
            Case 4
                viewImage = My.Resources.Resource1.dot4
            Case 5
                viewImage = My.Resources.Resource1.dot5
            Case 6
                viewImage = My.Resources.Resource1.dot6
        End Select
    End Sub

    Public Sub setRolledDots(ByVal dots As Integer)
        Me.rolledDots = dots
        setImage(Me.rolledDots)
    End Sub
End Class
