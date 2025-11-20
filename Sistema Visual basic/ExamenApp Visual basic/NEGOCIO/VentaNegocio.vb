Public Class VentaNegocio
    Private ventaDAL As New VentaDAL
    Public Function GuardarVenta(venta As Venta) As Integer
        If venta.IDCliente <= 0 Then
            Throw New Exception("El ID del cliente es obligatorio para registrar la venta")
        End If

        If venta.ID = 0 Then
            Dim nuevoid As Integer = ventaDAL.InsertarVenta(venta)
            Return nuevoid
        Else
            ventaDAL.ModificarVenta(venta)
            Return venta.ID
        End If
    End Function

    Public Sub EliminarVenta(id As Integer)
        ventaDAL.EliminarVenta(id)
    End Sub

    Public Function ListarVenta() As DataTable
        Return ventaDAL.ListarVenta()
    End Function

    Public Sub ActualizarTabla(id As Integer, nuevototal As Single)
        ventaDAL.ActualizarTabla(id, nuevototal)
    End Sub
    Public Function BuscarVentasPorCliente(idCliente As Integer) As DataTable
        Return ventaDAL.BuscarVentasPorCliente(idCliente)
    End Function
    Public Function BuscarVentasPorID(idVenta As Integer) As DataTable
        Dim ventaDAL As New VentaDAL()
        Return ventaDAL.BuscarVentasPorID(idVenta)
    End Function

End Class
