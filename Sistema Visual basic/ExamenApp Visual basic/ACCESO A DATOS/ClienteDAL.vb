Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions

Public Class ClienteDAL
    Private conexion As New AccesoDatos()

    Public Sub InsertarCliente(cliente As Cliente)
        Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)"
        Using connection As SqlConnection = conexion.GetOpenConnection() ' Asume que GetOpenConnection() existe y es accesible
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Cliente", cliente.Nombre)
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                    command.Parameters.AddWithValue("@Correo", cliente.Correo)
                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Sub EliminarCliente(id As Integer)
        Dim query As String = "DELETE FROM clientes WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()
                End Using
            End If

        End Using


    End Sub
    Public Sub ModificarCliente(cliente As Cliente)
        Dim query As String = "UPDATE  clientes SET Cliente=@Cliente, Telefono=@Telefono, Correo=@Correo WHERE ID=@ID "
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Cliente", cliente.Nombre)
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                    command.Parameters.AddWithValue("@Correo", cliente.Correo)
                    command.Parameters.AddWithValue("@ID", cliente.ID)
                    command.ExecuteNonQuery()

                End Using
            End If
        End Using
    End Sub
    Public Function ListarClientes() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM clientes"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)

                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(dt)

                    End Using

                End Using
            End If
        End Using
        Return dt
    End Function

    Public Function ValidacionTelefono(telefono As String) As Boolean
        Dim query As String = "SELECT COUNT (*) FROM clientes WHERE Telefono=@Telefono "
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Telefono", telefono)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function


    Public Function ValidacionCorreo(correo As String) As Boolean
        Dim query As String = "SELECT COUNT (*) FROM clientes WHERE Correo=@Correo"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Correo", correo)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function

    Public Function ValidarCorreoModificar(correo As String, id As Integer) As Boolean
        Dim query As String = "SELECT COUNT (*) FROM clientes WHERE Correo=@Correo AND ID<>@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Correo", correo)
                    command.Parameters.AddWithValue("@ID", id)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function

    Public Function validarTelefonoModificar(telefono As String, id As Integer) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM clientes WHERE Telefono=@Telefono AND ID<>@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Telefono", telefono)
                    command.Parameters.AddWithValue("@ID", id)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function

    Public Function BuscarCliente(nombre As String, telefono As String, correo As String) As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM clientes WHERE 1=1"
        Using connection As SqlConnection = conexion.GetOpenConnection()

            Using command As New SqlCommand
                command.Connection = connection
                If Not String.IsNullOrWhiteSpace(nombre) Then
                    query &= "AND Cliente LIKE @Nombre"
                    command.Parameters.AddWithValue("@Nombre", "%" & nombre & "%")

                End If
                If Not String.IsNullOrWhiteSpace(telefono) Then
                    query &= "AND Telefono LIKE @Telefono"
                    command.Parameters.AddWithValue("@Telefono", "%" & telefono & "%")
                End If
                If Not String.IsNullOrWhiteSpace(correo) Then
                    query &= "AND Correo LIKE @Correo"
                    command.Parameters.AddWithValue("@Correo", "%" & correo & "%")
                End If
                command.CommandText = query
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)

            End Using


        End Using
        Return dt
    End Function

    Public Function ValidarCorreoValido(ByVal email As String) As Boolean
        Dim patron As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        Return Regex.IsMatch(email, patron, RegexOptions.IgnoreCase)
    End Function


End Class