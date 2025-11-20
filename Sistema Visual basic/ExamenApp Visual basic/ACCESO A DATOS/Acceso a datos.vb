Imports System.Configuration
Imports System.Data.SqlClient

Public Class AccesoDatos
    Public Function GetOpenConnection() As SqlConnection

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("pruebademoDB").ConnectionString
        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        Return connection
    End Function

End Class
