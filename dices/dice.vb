Public Class dice
    Private isHold As Boolean = False
    Private Shared rnd As New Random
    Private rolledDots As Integer
    Private viewImage As Image
    Sub New()

    End Sub
    Public Sub roll()
        If Me.isHold = False Then
            Me.rolledDots = rnd.Next(1, 7)
            setImage(Me.rolledDots)
        End If
    End Sub

    Public Sub setHold(ByVal sender As Object)
        isHold = If(CBool(isHold), False, True)
        diceUpdateView(sender)
    End Sub

    Public Function getHold()
        Return isHold
    End Function

    Public Function getImage()
        Return viewImage
    End Function

    Public Function getdots()
        Return rolledDots
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
    Private Sub diceUpdateView(ByVal sender As Object)
        sender.BorderStyle = If(Me.isHold, BorderStyle.Fixed3D, BorderStyle.None)
    End Sub
End Class
