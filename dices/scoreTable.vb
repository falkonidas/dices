Public Class scoreTable

    Public scoreRules As scoreRules = New scoreRules

    Private aces As New scoreTableCell(0) With {.empty = True, .writable = True}
    Private twos As New scoreTableCell(1) With {.empty = True, .writable = True}
    Private threes As New scoreTableCell(2) With {.empty = True, .writable = True}
    Private fours As New scoreTableCell(3) With {.empty = True, .writable = True}
    Private fives As New scoreTableCell(4) With {.empty = True, .writable = True}
    Private sixes As New scoreTableCell(5) With {.empty = True, .writable = True}

    Private prem As New scoreTableCell(6) With {.empty = False, .writable = False}
    Private upperTotal As New scoreTableCell(7) With {.empty = False, .writable = False}

    Private threeOfKind As New scoreTableCell(8) With {.empty = True, .writable = True}
    Private fourOfKind As New scoreTableCell(9) With {.empty = True, .writable = True}
    Private fullHouse As New scoreTableCell(10) With {.empty = True, .writable = True}
    Private smallStraight As New scoreTableCell(11) With {.empty = True, .writable = True}
    Private largeStraight As New scoreTableCell(12) With {.empty = True, .writable = True}
    Private yahtzee As New scoreTableCell(13) With {.empty = True, .writable = True}
    Private chance As New scoreTableCell(14) With {.empty = True, .writable = True}

    Private lowerTotal As New scoreTableCell(15) With {.empty = False, .writable = False}
    Private grandTotal As New scoreTableCell(16) With {.empty = False, .writable = False}

    Public scoreTableCells As List(Of scoreTableCell) = New List(Of scoreTableCell) From {aces, twos, threes, fours, _
        fives, sixes, prem, upperTotal, threeOfKind, fourOfKind, fullHouse, smallStraight, largeStraight, yahtzee, chance, _
         lowerTotal, grandTotal}

    Public Sub getPossibleScores()
        aces.setPosScore(scoreRules.getUpperScore(1))
        twos.setPosScore(scoreRules.getUpperScore(2))
        threes.setPosScore(scoreRules.getUpperScore(3))
        fours.setPosScore(scoreRules.getUpperScore(4))
        fives.setPosScore(scoreRules.getUpperScore(5))
        sixes.setPosScore(scoreRules.getUpperScore(6))
        threeOfKind.setPosScore(scoreRules.get3ofKindScore())
        fourOfKind.setPosScore(scoreRules.get4ofKindScore())
        fullHouse.setPosScore(scoreRules.getFullHouse())
        smallStraight.setPosScore(scoreRules.getSmallStraight())
        largeStraight.setPosScore(scoreRules.getLargeStraight())
        yahtzee.setPosScore(scoreRules.getYahtzee())
        chance.setPosScore(scoreRules.getChanceScore())
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
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(1))
                End If

            Case 1
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(2))
                End If

            Case 2
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(3))
                End If

            Case 3
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(4))
                End If

            Case 4
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(5))
                End If

            Case 5
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getUpperScore(6))
                End If


            Case 8
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.get3ofKindScore())
                End If

            Case 9
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.get4ofKindScore())
                End If

            Case 10
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getFullHouse())
                End If

            Case 11
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getSmallStraight())
                End If

            Case 12
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getLargeStraight())
                End If

            Case 13
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getYahtzee())
                End If

            Case 14
                If scoreTableCells(row).writable = True Then
                    scoreTableCells(row).writeScore(scoreRules.getChanceScore())
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
