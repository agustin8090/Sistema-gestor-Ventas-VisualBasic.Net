Imports System.Data.SqlClient
Imports ExamenApp_Visual_basic.pruebademoDataSetProductoTableAdapters
Public Class ProductoDAL
    Private conexion As New AccesoDatos()
    Public Sub InsertarProducto(producto As Producto)
        Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)

                    command.Parameters.AddWithValue("@Nombre", producto.Nombre)
                    command.Parameters.AddWithValue("@Precio", producto.Precio)
                    command.Parameters.AddWithValue("@Categoria", producto.Categoria)
                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Sub EliminarProducto(id As Integer)
        Dim query As String = "DELETE FROM productos WHERE ID= @ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Sub ModificarProducto(producto As Producto)
        Dim query As String = "UPDATE productos SET Nombre=@Nombre, Precio=@Precio, Categoria=@Categoria WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre)
                    command.Parameters.AddWithValue("@Precio", producto.Precio)
                    command.Parameters.AddWithValue("@Categoria", producto.Categoria)
                    command.Parameters.AddWithValue("@ID", producto.ID)

                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Function ListarProducto() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM productos"
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

    Public Function ValidarNombreProducto(Nombre As String) As Boolean
        Dim query As String = "SELECT COUNT (*) FROM productos WHERE Nombre=@Nombre"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Nombre", Nombre)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function

    Public Function validarNombreProductoModificar(nombre As String, id As Integer) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM productos WHERE Nombre=@Nombre AND ID<>@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Nombre", nombre)
                    command.Parameters.AddWithValue("@ID", id)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar)
                    Return count > 0
                End Using
            End If
        End Using
    End Function

    Public Function BuscarProducto(nombre As String, precio As Single, categoria As String) As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM productos WHERE 1=1"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)
                If Not String.IsNullOrWhiteSpace(nombre) Then
                    query &= "AND Nombre LIKE @Nombre"
                    command.Parameters.AddWithValue("@Nombre", "%" & nombre & "%")
                End If
                If precio <> 0 Then
                    query &= "AND Precio = @Precio"
                    command.Parameters.AddWithValue("@Precio", precio)

                End If
                If Not String.IsNullOrWhiteSpace(categoria) Then
                    query &= "AND Categoria LIKE @Categoria"
                    command.Parameters.AddWithValue("@Categoria", "%" & categoria & "%")
                End If
                command.CommandText = query
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Public Function BuscarProductoPorID(id As Integer) As DataTable
        Dim dt As New DataTable()
        Dim producto As New Producto()
        Dim query As String = "SELECT * FROM productos WHERE ID=@ID "
        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using Command As New SqlCommand(query, connection)
                Command.Parameters.AddWithValue("@ID", id)
                Dim adapter As New SqlDataAdapter(Command)
                adapter.Fill(dt)
            End Using
            End Using

        Return dt
    End Function

End Class
