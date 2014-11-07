Public Class rollCup
    Public dices As New List(Of dice)
    Sub New()
        For i = 0 To 5
            dices.Add(New dice)
        Next
    End Sub
    Public Sub rollDices()
        For Each dice In dices
            dice.roll()
        Next
        dicesUpdateView(Me.dices)
    End Sub

    Private Sub dicesUpdateView(ByVal dices As List(Of dice))
        Form1.PictureBox1.Image = dices(0).getImage
        Form1.PictureBox2.Image = dices(1).getImage
        Form1.PictureBox3.Image = dices(2).getImage
        Form1.PictureBox4.Image = dices(3).getImage
        Form1.PictureBox5.Image = dices(4).getImage
    End Sub
End Class
