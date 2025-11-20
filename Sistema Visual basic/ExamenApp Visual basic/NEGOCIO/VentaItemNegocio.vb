Public Class VentaItemNegocio
    Private ventaitemDAL As New VentaitemDAL
    Public Sub GuardarVentaItem(ventaitem As Ventaitem)
        If ventaitem.IDVenta <= 0 OrElse ventaitem.IDProducto <= 0 Then
            Throw New Exception("El ID de venta e ID de producto son obligatorios")
        End If

        If ventaitem.PrecioUnitario <= 0 OrElse ventaitem.Cantidad <= 0 Then
            Throw New Exception("El precio Unitario/Cantidad debe ser mayor 0")
        End If

        If ventaitem.ID = 0 Then
            ventaitemDAL.InsertarVentaItem(ventaitem)
        Else
            ventaitemDAL.ModificarVentaItem(ventaitem)
        End If
    End Sub

    Public Sub EliminarVentaItem(id As Integer)
        ventaitemDAL.EliminarVentaItem(id)
    End Sub

    Public Function ListarVentaItem() As DataTable
        Return ventaitemDAL.ListarVentaItem()
    End Function

    Public Sub ActualizarVentaItem(idItem As Integer, item As Ventaitem)
        ventaitemDAL.ActualizarVentaItem(idItem, item)
    End Sub

    Public Function BuscarVentaItemsPorIDVenta(idVenta As Integer) As DataTable
        Return ventaitemDAL.BuscarVentaItemsPorIDVenta(idVenta)
    End Function
End Class
