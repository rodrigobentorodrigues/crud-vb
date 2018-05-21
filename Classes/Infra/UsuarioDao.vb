Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class UsuarioDao

    Private conFactory As ConFactory
    Private connection As SqlConnection

    Public Sub New()
        Me.conFactory = New ConFactory
        Me.connection = conFactory.getConnection
        Me.connection.Open()
    End Sub

    Public Sub insertUser(ByVal usuario As Usuario)
        Dim sqlInsert As String = "INSERT INTO usuario (nome, idade) VALUES (@nome, @idade)"
        Dim sqlCommand As New SqlCommand(sqlInsert, connection)
        sqlCommand.Parameters.AddWithValue("@nome", usuario.getNome)
        sqlCommand.Parameters.AddWithValue("@idade", usuario.getIdade)
        sqlCommand.ExecuteNonQuery()
    End Sub

    Public Sub updateUser(ByVal usuario As Usuario)
        Dim sqlUpdate As String = "UPDATE usuario SET nome = @nome, idade = @idade WHERE id = @id"
        Dim sqlCommand As New SqlCommand(sqlUpdate, connection)
        sqlCommand.Parameters.AddWithValue("@nome", usuario.getNome)
        sqlCommand.Parameters.AddWithValue("@idade", usuario.getIdade)
        sqlCommand.Parameters.AddWithValue("@id", usuario.getId)
        sqlCommand.ExecuteNonQuery()
    End Sub

    Public Sub removeUser(ByVal id As Integer)
        Dim sqlDelete As String = "DELETE FROM usuario WHERE id = @id"
        Dim sqlCommand As New SqlCommand(sqlDelete, connection)
        sqlCommand.Parameters.AddWithValue("@id", id)
        sqlCommand.ExecuteNonQuery()
    End Sub

    Public Function listAllUsers() As List(Of Usuario)
        Dim users As New List(Of Usuario)
        Dim sqlQuery As String = "SELECT * FROM usuario"
        Dim sqlCommand As New SqlCommand(sqlQuery, connection)
        Dim linhas As SqlDataReader = sqlCommand.ExecuteReader()
        While linhas.Read
            Dim id As Integer = linhas(0)
            Dim nome As String = linhas(1)
            Dim idade As String = linhas(2)
            Dim user As New Usuario(id, nome, idade)
            users.Add(user)
        End While
        linhas.Close()
        Return users
    End Function

    Public Function getUser(ByVal id As Integer) As Usuario
        Dim sqlSearch As String = "SELECT * FROM usuario WHERE id = @id"
        Dim sqlCommand As New SqlCommand(sqlSearch, connection)
        sqlCommand.Parameters.AddWithValue("@id", id)
        Dim valor As SqlDataReader = sqlCommand.ExecuteReader()
        Dim user As Usuario = Nothing
        While valor.Read
            user = New Usuario(valor(0), valor(1), valor(2))
        End While
        valor.Close()
        Return user
    End Function

End Class
