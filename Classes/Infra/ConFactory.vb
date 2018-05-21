Imports System.Data
Imports System.Data.SqlClient

Public Class ConFactory

    Private Const databaseName As String = "Teste"
    Private Const user As String = "sa"
    Private Const password As String = "a@DU&72Si"
    Private Const server As String = "RODRIGO\SOFTEC,1433"

    Public Function getConnection() As SqlConnection
        Dim connection As New SqlClient.SqlConnectionStringBuilder
        connection.DataSource = server
        connection.UserID = user
        connection.Password = password
        connection.InitialCatalog = databaseName
        Return New SqlConnection(connection.ConnectionString)
    End Function

End Class
