Public MustInherit Class dicesRules
    Protected dices As New List(Of dice)
    Public Sub getDices(ByVal dices As List(Of dice))
        Me.dices = dices
    End Sub
End Class
