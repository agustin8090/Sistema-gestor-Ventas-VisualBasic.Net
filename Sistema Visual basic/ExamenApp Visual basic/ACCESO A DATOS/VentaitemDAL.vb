Imports System.Data.SqlClient
Public Class VentaitemDAL
    Private conexion As New AccesoDatos()
    Public Sub InsertarVentaItem(ventaitem As Ventaitem)
        Dim query As String = "INSERT INTO ventasitems (IDVenta,IDProducto, PrecioUnitario,Cantidad, PrecioTotal)
VALUES ( @IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @PrecioTotal)"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)

                    command.Parameters.AddWithValue("@IDVenta", ventaitem.IDVenta)
                    command.Parameters.AddWithValue("@IDProducto", ventaitem.IDProducto)
                    command.Parameters.AddWithValue("@PrecioUnitario", ventaitem.PrecioUnitario)
                    command.Parameters.AddWithValue("@Cantidad", ventaitem.Cantidad)
                    command.Parameters.AddWithValue("@PrecioTotal", ventaitem.PrecioTotal)
                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Sub EliminarVentaItem(id As Integer)
        Dim query As String = "DELETE FROM ventasitems WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", id)
                    command.ExecuteNonQuery()

                End Using
            End If
        End Using
    End Sub

    Public Sub ModificarVentaItem(ventaitem As Ventaitem)
        Dim query As String = "UPDATE ventasitems SET IDVenta=@IDVenta, IDProducto=@IDProducto, PrecioUnitario=@PrecioUnitario,
Cantidad=@Cantidad, PrecioTotal=@PrecioTotal WHERE ID=@ID"
        Using connection As SqlConnection = conexion.GetOpenConnection()
            If connection IsNot Nothing Then
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", ventaitem.ID)
                    command.Parameters.AddWithValue("@IDVenta", ventaitem.IDVenta)
                    command.Parameters.AddWithValue("@IDProducto", ventaitem.IDProducto)
                    command.Parameters.AddWithValue("@PrecioUnitario", ventaitem.PrecioUnitario)
                    command.Parameters.AddWithValue("@Cantidad", ventaitem.Cantidad)
                    command.Parameters.AddWithValue("@PrecioTotal", ventaitem.PrecioTotal)
                    command.ExecuteNonQuery()
                End Using
            End If
        End Using
    End Sub

    Public Function ListarVentaItem() As DataTable
        Dim dt As New DataTable()
        Dim query As String = "SELECT * FROM ventasitems"
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
    Public Sub ActualizarVentaItem(idItem As Integer, item As Ventaitem)
        Dim query As String = "UPDATE ventasitems SET IDProducto = @IDProducto, Cantidad = @Cantidad, PrecioUnitario = @PrecioUnitario, PrecioTotal = @PrecioTotal WHERE ID = @ID"

        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                command.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                command.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                command.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                command.Parameters.AddWithValue("@ID", idItem)

                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function BuscarVentaItemsPorIDVenta(idVenta As Integer) As DataTable
        Dim tabla As New DataTable()
        Dim query As String = "SELECT * FROM ventasitems WHERE IDVenta = @IDVenta"

        Using connection As SqlConnection = conexion.GetOpenConnection()
            Using command As New SqlCommand(query, connection)
                ' Asocia el parámetro del ID de la venta
                command.Parameters.AddWithValue("@IDVenta", idVenta)

                Using adapter As New SqlDataAdapter(command)
                    adapter.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function
End Class
