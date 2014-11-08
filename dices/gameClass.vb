Public Class gameClass

    Public preGameOrPreScore As Boolean = True

    Public WithEvents dice1 As dice = New dice
    Public WithEvents dice2 As dice = New dice
    Public WithEvents dice3 As dice = New dice
    Public WithEvents dice4 As dice = New dice
    Public WithEvents dice5 As dice = New dice
    Public dices As List(Of dice) = New List(Of dice) From {dice1, dice2, dice3, dice4, dice5}

    Public rollController As rollController = New rollController

    Public Sub rollDices()
        rollController.getDices(dices)
        rollController.rollDices()

        getUpperScore(1)
        getUpperScore(2)
        getUpperScore(3)
        getUpperScore(4)
        getUpperScore(5)
        getUpperScore(6)
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

    Public Sub getChanceScore()
        Dim score = dice1.getDots + dice2.getDots + dice3.getDots + dice4.getDots + dice5.getDots
        Form1.DataGridView1.Rows(15).Cells(1).Value = score
    End Sub


    Public Sub updateView() Handles dice1.diceStateChanged, dice2.diceStateChanged, dice3.diceStateChanged, dice4.diceStateChanged, dice5.diceStateChanged

        game.rollController.getDices(game.dices)
        game.rollController.checkDicesHold()

        Form1.PictureBox1.Image = dice1.getImage
        Form1.PictureBox2.Image = dice2.getImage
        Form1.PictureBox3.Image = dice3.getImage
        Form1.PictureBox4.Image = dice4.getImage
        Form1.PictureBox5.Image = dice5.getImage

        Form1.PictureBox1.BorderStyle = If(dice1.getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox2.BorderStyle = If(dice2.getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox3.BorderStyle = If(dice3.getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox4.BorderStyle = If(dice4.getHold, BorderStyle.Fixed3D, BorderStyle.None)
        Form1.PictureBox5.BorderStyle = If(dice5.getHold, BorderStyle.Fixed3D, BorderStyle.None)

    End Sub

End Class
