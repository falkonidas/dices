Public Class Form1
    Dim game = New gameClass
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'prepare datagrid
        DataGridView1.Rows.Add(New String() {"Aces", ""})
        DataGridView1.Rows.Add(New String() {"Twos", ""})
        DataGridView1.Rows.Add(New String() {"Threes", ""})
        DataGridView1.Rows.Add(New String() {"Fours", ""})
        DataGridView1.Rows.Add(New String() {"Fives", ""})
        DataGridView1.Rows.Add(New String() {"Sixes", ""})
        DataGridView1.Rows.Add(New String() {"Prem", ""})
        DataGridView1.Rows.Add(New String() {"Upper Total", ""})
        DataGridView1.Rows.Add(New String() {"3 of a kind", ""})
        DataGridView1.Rows.Add(New String() {"4 of a kind", ""})
        DataGridView1.Rows.Add(New String() {"Full house", ""})
        DataGridView1.Rows.Add(New String() {"Small Straight", ""})
        DataGridView1.Rows.Add(New String() {"Large Straight", ""})
        DataGridView1.Rows.Add(New String() {"Yahtzee", ""})
        DataGridView1.Rows.Add(New String() {"Chance", ""})
        DataGridView1.Rows.Add(New String() {"Lower Total", ""})
        DataGridView1.Rows.Add(New String() {"Grand Total", ""})

        DataGridView1.Width = DataGridView1.Columns.GetColumnsWidth(0) + 1
        DataGridView1.Height = DataGridView1.Rows.GetRowsHeight(0) + 18

        game.disableRolling()

        DataGridView1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'roll dices
        game.rollDices()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        'hold dice1
        game.holdDice(0)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        'hold dice2
        game.holdDice(1)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        'hold dice3
        game.holDdice(2)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        'hold dice4
        game.holDdice(3)
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        'hold dice5
        game.holDdice(4)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'startgame
        DataGridView1.Enabled = True
        game.startGame()
        Button5.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 1 AndAlso {0, 1, 2, 3, 4, 5, 8, 9, 10, 11, 12, 13, 14}.Contains(e.RowIndex) Then

            If game.getTableCellEmpty(e.RowIndex) = True Then
                game.writeScore(e.RowIndex)
                game.continueGameAfterScoring()
            End If
        End If

    End Sub

    Private Sub DataGridView1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.MouseLeave
        DataGridView1.ClearSelection()
    End Sub

    Private Sub DataGridView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseMove
        Dim hit As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)
        If hit.RowIndex > -1 And hit.ColumnIndex Then
            DataGridView1.Rows(hit.RowIndex).Cells(hit.ColumnIndex).Selected = True
        End If

        If hit.ColumnIndex = 1 AndAlso hit.RowIndex > -1 Then
            DataGridView1.Cursor = Cursors.Hand
        Else
            DataGridView1.Cursor = Cursors.Default
            DataGridView1.ClearSelection()
        End If
    End Sub

End Class
