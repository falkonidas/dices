Public Class Form1
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        DataGridView1.Rows.Add(New String() {"Aces", ""})
        DataGridView1.Rows.Add(New String() {"Twos", ""})
        DataGridView1.Rows.Add(New String() {"Threes", ""})
        DataGridView1.Rows.Add(New String() {"Fours", ""})
        DataGridView1.Rows.Add(New String() {"Fives", ""})
        DataGridView1.Rows.Add(New String() {"Sixes", ""})
        DataGridView1.Rows.Add(New String() {"Prem", ""})
        DataGridView1.Rows.Add(New String() {"Total", ""})
        DataGridView1.Rows.Add(New String() {"3 of a kind", ""})
        DataGridView1.Rows.Add(New String() {"4 of a kind", ""})
        DataGridView1.Rows.Add(New String() {"Full house", ""})
        DataGridView1.Rows.Add(New String() {"3 of a kind", ""})
        DataGridView1.Rows.Add(New String() {"Small Straight", ""})
        DataGridView1.Rows.Add(New String() {"Large Straight", ""})
        DataGridView1.Rows.Add(New String() {"Yahtzee", ""})
        DataGridView1.Rows.Add(New String() {"Chance", ""})
        DataGridView1.Rows.Add(New String() {"Total", ""})
        DataGridView1.Rows.Add(New String() {"Grand Total", ""})

        DataGridView1.Width = DataGridView1.Columns.GetColumnsWidth(0) + 1
        DataGridView1.Height = DataGridView1.Rows.GetRowsHeight(0) + 18

        game.rollController.disableHoldingDices()
        game.rollController.disableRolling()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        game.rollDices()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        game.dice1.setHold()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        game.dice2.setHold()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        game.dice3.setHold()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        game.dice4.setHold()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        game.dice5.setHold()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        game.preGameOrPrescore = False
        game.rollController.rollCounter = 0
        game.rollController.enableRolling()
        game.rollController.enableHoldingDices()
        game.rollController.unholdDices()
        game.rollDices()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        game.preGameOrPrescore = False
        game.rollController.getDices(game.dices)
        game.rollController.enableHoldingDices()
        game.rollController.enableRolling()
        game.rollDices()
        Button5.Enabled = False
    End Sub
End Class
