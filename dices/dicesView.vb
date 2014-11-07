Public Class dicesView
    Public Sub updateView(ByVal dices As List(Of dice))
        Form1.PictureBox1.Image = dices(0).getImage
        Form1.PictureBox2.Image = dices(1).getImage
        Form1.PictureBox3.Image = dices(2).getImage
        Form1.PictureBox4.Image = dices(3).getImage
        Form1.PictureBox5.Image = dices(4).getImage

        Form1.PictureBox1.BorderStyle = If(dices(0).getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox2.BorderStyle = If(dices(1).getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox3.BorderStyle = If(dices(2).getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox4.BorderStyle = If(dices(3).getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox5.BorderStyle = If(dices(4).getHold, BorderStyle.Fixed3D, BorderStyle.None)
    End Sub
End Class
