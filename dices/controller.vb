Public MustInherit Class controller
    Protected dices As New List(Of dice)
    Public Sub getDices(ByVal dices As List(Of dice))
        Me.dices = dices
    End Sub
End Class
