Public Class scoreTable

    Dim aces As New scoreTableCell With {.empty = True, .writable = True, .name = "aces", .index = 0}
    Dim twos As New scoreTableCell With {.empty = True, .writable = True, .name = "twos", .index = 1}
    Dim threes As New scoreTableCell With {.empty = True, .writable = True, .name = "threes", .index = 2}
    Dim fours As New scoreTableCell With {.empty = True, .writable = True, .name = "fours", .index = 3}
    Dim fives As New scoreTableCell With {.empty = True, .writable = True, .name = "fives", .index = 4}
    Dim sixes As New scoreTableCell With {.empty = True, .writable = True, .name = "sixes", .index = 5}

    Dim prem As New scoreTableCell With {.empty = False, .writable = False, .name = "aces", .index = 6}
    Dim upperTotal As New scoreTableCell With {.empty = False, .writable = False, .name = "aces", .index = 7}

    Dim threeOfKind As New scoreTableCell With {.empty = True, .writable = True, .name = "threeOfKind", .index = 8}
    Dim fourOfKind As New scoreTableCell With {.empty = True, .writable = True, .name = "fourOfKind", .index = 9}
    Dim fullHouse As New scoreTableCell With {.empty = True, .writable = True, .name = "fullHouse", .index = 10}
    Dim smallStraight As New scoreTableCell With {.empty = True, .writable = True, .name = "smallStraight", .index = 11}
    Dim largeStraight As New scoreTableCell With {.empty = True, .writable = True, .name = "largeStraight", .index = 12}
    Dim yahtzee As New scoreTableCell With {.empty = True, .writable = True, .name = "yahtzee", .index = 13}
    Dim chance As New scoreTableCell With {.empty = True, .writable = True, .name = "chance", .index = 14}

    Dim lowerTotal As New scoreTableCell With {.empty = False, .writable = False, .name = "aces", .index = 15}
    Dim grandTotal As New scoreTableCell With {.empty = False, .writable = False, .name = "aces", .index = 16}

    Public scoreTableCells As List(Of scoreTableCell) = New List(Of scoreTableCell) From {aces, twos, threes, fours, _
        fives, sixes, prem, upperTotal, threeOfKind, fourOfKind, fullHouse, smallStraight, largeStraight, yahtzee, chance, _
         lowerTotal, grandTotal}

    Public Sub getPossibleScores()
        aces.possibleScore = game.scoreController.getUpperScore(1)
        twos.possibleScore = game.scoreController.getUpperScore(2)
        threes.possibleScore = game.scoreController.getUpperScore(3)
        fours.possibleScore = game.scoreController.getUpperScore(4)
        fives.possibleScore = game.scoreController.getUpperScore(5)
        sixes.possibleScore = game.scoreController.getUpperScore(6)
        threeOfKind.possibleScore = game.scoreController.get3ofKindScore()
        fourOfKind.possibleScore = game.scoreController.get4ofKindScore()
        fullHouse.possibleScore = game.scoreController.getFullHouse()
        smallStraight.possibleScore = game.scoreController.getSmallStraight()
        largeStraight.possibleScore = game.scoreController.getLargeStraight()
        yahtzee.possibleScore = game.scoreController.getYahtzee()
        chance.possibleScore = game.scoreController.getChanceScore()
    End Sub

    Public Function writeScore(ByVal row As Integer) As Integer
        Select Case row
            Case 0
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(1)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 1
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(2)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 2
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(3)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 3
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(4)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 4
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(5)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 5
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getUpperScore(6)
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If


            Case 8
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.get3ofKindScore()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 9
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.get4ofKindScore()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 10
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getFullHouse()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 11
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getSmallStraight()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 12
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getLargeStraight()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 13
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getYahtzee()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If

            Case 14
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writtenScore = game.scoreController.getChanceScore()
                    scoreTableCells(row).writable = False
                    scoreTableCells(row).empty = False
                End If
        End Select
        Return Nothing
    End Function
    Public Sub updateScoreTableView()
        getPossibleScores()
        For Each cell In scoreTableCells
            If cell.empty = True Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.DarkGray
                Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.possibleScore
            ElseIf cell.empty = False Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.Black
                Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.writtenScore
            End If

            If cell.index = 6 Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.Black
                If scoreTableCells(0).writtenScore + scoreTableCells(1).writtenScore + scoreTableCells(2).writtenScore + scoreTableCells(3).writtenScore + scoreTableCells(4).writtenScore + scoreTableCells(5).writtenScore > 63 Then
                    scoreTableCells(6).writtenScore = 35
                    Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.writtenScore
                End If
            End If

            If cell.index = 7 Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.Black
                cell.writtenScore = scoreTableCells(0).writtenScore + scoreTableCells(1).writtenScore + scoreTableCells(2).writtenScore + scoreTableCells(3).writtenScore + scoreTableCells(4).writtenScore + scoreTableCells(5).writtenScore + scoreTableCells(6).writtenScore
                Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.writtenScore
            End If

            If cell.index = 15 Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.Black
                cell.writtenScore = scoreTableCells(8).writtenScore + scoreTableCells(9).writtenScore + scoreTableCells(10).writtenScore + scoreTableCells(11).writtenScore + scoreTableCells(12).writtenScore + scoreTableCells(13).writtenScore + scoreTableCells(14).writtenScore
                Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.writtenScore
            End If

            If cell.index = 16 Then
                Form1.DataGridView1.Rows(cell.index).Cells(1).Style.ForeColor = Color.Black
                cell.writtenScore = scoreTableCells(7).writtenScore + scoreTableCells(15).writtenScore
                Form1.DataGridView1.Rows(cell.index).Cells(1).Value = cell.writtenScore
            End If
        Next

    End Sub
End Class
