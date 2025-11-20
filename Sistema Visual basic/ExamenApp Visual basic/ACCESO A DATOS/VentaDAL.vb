Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Runtime.InteropServices
Public Class VentaDAL
    Private conexion As New AccesoDatos()

    Public Function InsertarVenta(venta As Venta) As Integer

        Dim query As String = "INSERT INTO ventas ( IDCliente, Fecha, Total) OUTPUT INSERTED.ID VALUES ( @IDCliente, @Fecha, @Total)"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
                command.Parameters.AddWithValue("@Fecha", venta.Fecha)
                command.Parameters.AddWithValue("@Total", venta.Total)
                Dim nuevoid As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return nuevoid
            End Using

        End Using
    End Function

    Public Sub EliminarVenta(id As Integer)
        Dim query As String = "DELETE FROM ventas WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()

                End Using
            End If
        End Using
    End Sub

    Public Sub ModificarVenta(ventas As Venta)
        Dim query As String = "UPDATE ventas SET IDCliente=@IDCliente, Fecha=@Fecha, Total=@Total WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IDCliente", ventas.IDCliente)
                    command.Parameters.AddWithValue("@Fecha", ventas.Fecha)
                    command.Parameters.AddWithValue("@Total", ventas.Total)
                    command.Parameters.AddWithValue("@ID", ventas.ID)

                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Function ListarVenta() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM ventas"
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


    Public Sub ActualizarTabla(id As Integer, nuevototal As Single)
        Dim query As String = "UPDATE ventas SET Total=@Total WHERE ID=@ID "
        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using Command As New SqlCommand(query, connection)
                Command.Parameters.AddWithValue("@Total", nuevototal)
                Command.Parameters.AddWithValue("@ID", id)
                Command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    ' En tu clase VentaDAL
    Public Function BuscarVentasPorCliente(idCliente As Integer) As DataTable
        Dim tabla As New DataTable()
        ' Modifica la consulta para que devuelva los ítems de venta
        Dim query As String = "SELECT IDVenta, IDProducto, PrecioUnitario, Cantidad, ID FROM ventasitems WHERE IDVenta IN (SELECT ID FROM ventas WHERE IDCliente = @IDCliente)"

        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDCliente", idCliente)

                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function
    Public Function BuscarVentasPorID(idVenta As Integer) As DataTable
        Dim tabla As New DataTable()
        Dim query As String = "SELECT vi.*, v.ID AS IDVenta FROM ventasitems vi INNER JOIN ventas v ON vi.IDVenta = v.ID WHERE v.ID = @ID"

        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", idVenta)
                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

End Class
