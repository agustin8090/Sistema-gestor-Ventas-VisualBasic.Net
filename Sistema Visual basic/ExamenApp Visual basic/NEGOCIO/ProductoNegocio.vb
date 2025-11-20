Public Class ProductoNegocio
    Private productoDAL As New ProductoDAL

    Public Sub GuardarProducto(producto As Producto)
        If String.IsNullOrWhiteSpace(producto.Nombre) Then
            Throw New Exception("Es obligatorio ingresar el nombre del producto")
        End If

        If producto.ID = 0 Then
            If productoDAL.ValidarNombreProducto(producto.Nombre) Then
                Throw New Exception("No puede ingresar un producto ya existente")
            End If
            productoDAL.InsertarProducto(producto)
        Else

            If productoDAL.validarNombreProductoModificar(producto.Nombre, producto.ID) Then
                Throw New Exception("No puede ingresar un producto ya existente")
            End If
            productoDAL.ModificarProducto(producto)
        End If

    End Sub

    Public Sub EliminarProducto(id As Integer)
        productoDAL.EliminarProducto(id)
    End Sub

    Public Function ListarProducto() As DataTable
        Return productoDAL.ListarProducto()
    End Function

    Public Function BuscarProducto(nombre As String, precio As Single, categoria As String) As DataTable
        Return productoDAL.BuscarProducto(nombre, precio, categoria)
    End Function

    Public Function BuscarProductoporID(id As String) As DataTable
        Return productoDAL.BuscarProductoPorID(id)

    End Function
End Class
