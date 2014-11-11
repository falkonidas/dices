Public Class scoreTable

    Public scoreController As scoreController = New scoreController

    Dim aces As New scoreTableCell(0) With {.empty = True, .writable = True}
    Dim twos As New scoreTableCell(1) With {.empty = True, .writable = True}
    Dim threes As New scoreTableCell(2) With {.empty = True, .writable = True}
    Dim fours As New scoreTableCell(3) With {.empty = True, .writable = True}
    Dim fives As New scoreTableCell(4) With {.empty = True, .writable = True}
    Dim sixes As New scoreTableCell(5) With {.empty = True, .writable = True}

    Dim prem As New scoreTableCell(6) With {.empty = False, .writable = False}
    Dim upperTotal As New scoreTableCell(7) With {.empty = False, .writable = False}

    Dim threeOfKind As New scoreTableCell(8) With {.empty = True, .writable = True}
    Dim fourOfKind As New scoreTableCell(9) With {.empty = True, .writable = True}
    Dim fullHouse As New scoreTableCell(10) With {.empty = True, .writable = True}
    Dim smallStraight As New scoreTableCell(11) With {.empty = True, .writable = True}
    Dim largeStraight As New scoreTableCell(12) With {.empty = True, .writable = True}
    Dim yahtzee As New scoreTableCell(13) With {.empty = True, .writable = True}
    Dim chance As New scoreTableCell(14) With {.empty = True, .writable = True}

    Dim lowerTotal As New scoreTableCell(15) With {.empty = False, .writable = False}
    Dim grandTotal As New scoreTableCell(16) With {.empty = False, .writable = False}

    Public scoreTableCells As List(Of scoreTableCell) = New List(Of scoreTableCell) From {aces, twos, threes, fours, _
        fives, sixes, prem, upperTotal, threeOfKind, fourOfKind, fullHouse, smallStraight, largeStraight, yahtzee, chance, _
         lowerTotal, grandTotal}

    Public Sub getPossibleScores()
        aces.setPosScore(scoreController.getUpperScore(1))
        twos.setPosScore(scoreController.getUpperScore(2))
        threes.setPosScore(scoreController.getUpperScore(3))
        fours.setPosScore(scoreController.getUpperScore(4))
        fives.setPosScore(scoreController.getUpperScore(5))
        sixes.setPosScore(scoreController.getUpperScore(6))
        threeOfKind.setPosScore(scoreController.get3ofKindScore())
        fourOfKind.setPosScore(scoreController.get4ofKindScore())
        fullHouse.setPosScore(scoreController.getFullHouse())
        smallStraight.setPosScore(scoreController.getSmallStraight())
        largeStraight.setPosScore(scoreController.getLargeStraight())
        yahtzee.setPosScore(scoreController.getYahtzee())
        chance.setPosScore(scoreController.getChanceScore())
    End Sub

    Public Sub setupTable()
        For Each cell In scoreTableCells
            'cell.writtenScore = Nothing
            cell.writeScore(Nothing)
            cell.empty = True
            cell.writable = True
        Next
        scoreTableCells(6).empty = False
        scoreTableCells(7).empty = False
        scoreTableCells(15).empty = False
        scoreTableCells(16).empty = False
        scoreTableCells(6).writable = False
        scoreTableCells(7).writable = False
        scoreTableCells(15).writable = False
        scoreTableCells(16).writable = False
    End Sub

    Public Function writeScore(ByVal row As Integer) As Integer
        Select Case row
            Case 0
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(1))
                End If

            Case 1
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(2))
                End If

            Case 2
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(3))
                End If

            Case 3
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(4))
                End If

            Case 4
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(5))
                End If

            Case 5
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getUpperScore(6))
                End If


            Case 8
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.get3ofKindScore())
                End If

            Case 9
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.get4ofKindScore())
                End If

            Case 10
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getFullHouse())
                End If

            Case 11
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getSmallStraight())
                End If

            Case 12
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getLargeStraight())
                End If

            Case 13
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getYahtzee())
                End If

            Case 14
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreController.getChanceScore())
                End If
        End Select

        scoreTableCells(row).writable = False
        scoreTableCells(row).empty = False

        Return Nothing
    End Function
    Public Sub updateScoreTableView()

        getPossibleScores()

        For Each cell In scoreTableCells
            If cell.empty = True Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.DarkGray
                Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getPosScore()
            ElseIf cell.empty = False Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.Black
                Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getScore
            End If

            If cell.id = 6 Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.Black
                If scoreTableCells(0).getScore + scoreTableCells(1).getScore + scoreTableCells(2).getScore + scoreTableCells(3).getScore + scoreTableCells(4).getScore + scoreTableCells(5).getScore > 63 Then
                    scoreTableCells(6).writeScore(35)
                    Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getScore
                End If
            End If

            If cell.id = 7 Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.Black
                cell.writeScore(scoreTableCells(0).getScore + scoreTableCells(1).getScore + scoreTableCells(2).getScore + scoreTableCells(3).getScore + scoreTableCells(4).getScore + scoreTableCells(5).getScore + scoreTableCells(6).getScore)
                Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getScore
            End If

            If cell.id = 15 Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.Black
                cell.writeScore(scoreTableCells(8).getScore + scoreTableCells(9).getScore + scoreTableCells(10).getScore + scoreTableCells(11).getScore + scoreTableCells(12).getScore + scoreTableCells(13).getScore + scoreTableCells(14).getScore)
                Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getScore
            End If

            If cell.id = 16 Then
                Form1.DataGridView1.Rows(cell.id).Cells(1).Style.ForeColor = Color.Black
                cell.writeScore(scoreTableCells(7).getScore + scoreTableCells(15).getScore)
                Form1.DataGridView1.Rows(cell.id).Cells(1).Value = cell.getScore
            End If
        Next

    End Sub

End Class
