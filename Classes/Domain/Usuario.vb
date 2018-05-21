Public Class Usuario

    Private id As Integer
    Private nome As String
    Private idade As Integer

    Public Sub New(ByVal nome As String, ByVal idade As Integer)
        Me.nome = nome
        Me.idade = idade
    End Sub

    Public Sub New(ByVal id As Integer, ByVal nome As String, ByVal idade As Integer)
        Me.id = id
        Me.nome = nome
        Me.idade = idade
    End Sub

    Public Function getId() As Integer
        Return Me.id
    End Function

    Public Function getNome() As String
        Return Me.nome
    End Function

    Public Function getIdade() As Integer
        Return Me.idade
    End Function

    Public Sub setId(ByVal id As Integer)
        Me.id = id
    End Sub

    Public Sub setNome(ByVal nome As String)
        Me.nome = nome
    End Sub

    Public Sub setIdade(ByVal idade As Integer)
        Me.idade = idade
    End Sub

End Class
