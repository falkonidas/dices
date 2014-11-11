Public Class scoreTableCell
    ReadOnly index As Integer
    Private possibleScore As Integer
    Private writtenScore As Integer
    Public empty As Boolean
    Public writable As Boolean
    Sub New(ByVal id)
        Me.index = id
    End Sub
    Public ReadOnly Property id() As Integer
        Get
            Return index
        End Get
    End Property

    Public Sub setPosScore(ByVal scoreFunction As Integer)
        Me.possibleScore = scoreFunction
    End Sub

    Public Function getPosScore()
        Return possibleScore
    End Function

    Public Sub writeScore(ByVal scoreFunction As Integer)
        Me.writtenScore = scoreFunction
    End Sub

    Public Function getScore()
        Return Me.writtenScore
    End Function
End Class