Public Class gameClass

    Public preGameOrPreScore As Boolean = True

    Public WithEvents dice1 As dice = New dice
    Public WithEvents dice2 As dice = New dice
    Public WithEvents dice3 As dice = New dice
    Public WithEvents dice4 As dice = New dice
    Public WithEvents dice5 As dice = New dice
    Public dices As List(Of dice) = New List(Of dice) From {dice1, dice2, dice3, dice4, dice5}

    Public WithEvents rollController As rollController = New rollController
    Public scoreController As scoreController = New scoreController

    Public Event roll()

    Public Sub rollDices()
        RaiseEvent roll()

        rollController.getDices(dices)
        rollController.rollDices()

        scoreController.getDices(dices)

        scoreController.scoreTable.updateScoreTableView()
        searchForGameOver()
    End Sub

    Public Sub searchForGameOver()
        Dim counter = 0
        For Each cell In game.scoreController.scoreTable.scoreTableCells
            If cell.empty = True Then
                counter += 1
            End If
        Next
        If counter = 0 Then
            game.rollController.disableHoldingDices()
            game.rollController.disableRolling()
            Form1.Button5.Enabled = True
            MessageBox.Show("Game over, your score = " & game.scoreController.scoreTable.scoreTableCells(16).writtenScore)
        End If

    End Sub

    Public Sub updateRollButton() Handles dice1.diceStateChanged, dice2.diceStateChanged, dice3.diceStateChanged, dice4.diceStateChanged, dice5.diceStateChanged
        game.rollController.getDices(game.dices)
        game.rollController.checkDicesHold()
    End Sub

    Public Sub updateDicesView() Handles dice1.diceStateChanged, dice2.diceStateChanged, dice3.diceStateChanged, dice4.diceStateChanged, dice5.diceStateChanged
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
