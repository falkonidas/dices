Public Class gameClass

    Private WithEvents dice1 As dice = New dice
    Private WithEvents dice2 As dice = New dice
    Private WithEvents dice3 As dice = New dice
    Private WithEvents dice4 As dice = New dice
    Private WithEvents dice5 As dice = New dice
    Private dices As List(Of dice) = New List(Of dice) From {dice1, dice2, dice3, dice4, dice5}

    Private rollDicesRules As rolldicesRules = New rolldicesRules
    Private scoreTable As New scoreTable

    Public Sub holdDice(ByVal id)
        Me.dices(id).setHold()
    End Sub

    Public Sub startGame()
        scoreTable.setupTable()
        rollDicesRules.getDices(dices)
        rollDicesRules.preGameOrPreScore = False
        rollDicesRules.enableHoldingDices()
        rollDicesRules.enableRolling()
        rollDices()
    End Sub

    Public Sub continueGameAfterScoring()
        rollDicesRules.preGameOrPreScore = False
        rollDicesRules.rollCounter = 0
        rollDicesRules.enableRolling()
        rollDicesRules.enableHoldingDices()
        rollDicesRules.unholdDices()
        rollDices()
    End Sub

    Public Sub writeScore(ByVal row)
        scoreTable.writeScore(row)
    End Sub

    Public Sub disableRolling()
        rollDicesRules.disableRolling()
    End Sub
    Public Function getTableCellEmpty(ByVal row)
        Return scoreTable.scoreTableCells(row).empty
    End Function
    Public Sub rollDices()
        rollDicesRules.getDices(dices)
        rollDicesRules.rollDices()

        scoreTable.scoreRules.getDices(dices)
        scoreTable.updateScoreTableView()

        searchForGameOver()
    End Sub

    Public Sub searchForGameOver()
        Dim counter = 0
        For Each cell In scoreTable.scoreTableCells
            If cell.empty = True Then
                counter += 1
            End If
        Next
        If counter = 0 Then
            rollDicesRules.disableHoldingDices()
            rollDicesRules.disableRolling()
            Form1.Button5.Enabled = True
            Form1.DataGridView1.Enabled = False
            MessageBox.Show("Game over, your score = " & scoreTable.scoreTableCells(16).getScore)
        End If

    End Sub


    Public Sub updateRollButton() Handles dice1.diceStateChanged, dice2.diceStateChanged, dice3.diceStateChanged, dice4.diceStateChanged, dice5.diceStateChanged
        rollDicesRules.getDices(dices)
        rollDicesRules.checkDicesHold()
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
