Public Class Form1
    'Dim game = New gameClass
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        game.rollController.disableHoldingDices()
        game.rollController.disableRolling()

        DataGridView1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'roll dices
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'startgame
        DataGridView1.Enabled = True
        For Each cell In game.scoreController.scoreTable.scoreTableCells
            cell.writtenScore = Nothing
            cell.empty = True
            cell.writable = True
        Next
        game.scoreController.scoreTable.scoreTableCells(6).empty = False
        game.scoreController.scoreTable.scoreTableCells(7).empty = False
        game.scoreController.scoreTable.scoreTableCells(15).empty = False
        game.scoreController.scoreTable.scoreTableCells(16).empty = False
        game.scoreController.scoreTable.scoreTableCells(6).writable = False
        game.scoreController.scoreTable.scoreTableCells(7).writable = False
        game.scoreController.scoreTable.scoreTableCells(15).writable = False
        game.scoreController.scoreTable.scoreTableCells(16).writable = False


        game.preGameOrPreScore = False
        game.rollController.getDices(game.dices)
        game.rollController.enableHoldingDices()
        game.rollController.enableRolling()
        game.rollDices()
        Button5.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = 1 AndAlso {0, 1, 2, 3, 4, 5, 8, 9, 10, 11, 12, 13, 14}.Contains(e.RowIndex) Then

            If game.scoreController.scoreTable.scoreTableCells(e.RowIndex).empty = True Then
                game.scoreController.scoreTable.writeScore(e.RowIndex)

                game.preGameOrPreScore = False

                game.rollController.rollCounter = 0
                game.rollController.enableRolling()
                game.rollController.enableHoldingDices()
                game.rollController.unholdDices()

                game.rollDices()
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

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
