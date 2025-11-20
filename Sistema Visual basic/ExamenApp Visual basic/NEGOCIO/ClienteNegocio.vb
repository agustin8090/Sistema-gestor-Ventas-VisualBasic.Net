Imports System.Data

Public Class ClienteNegocio

    Private clienteDAL As New ClienteDAL()
    Public Sub GuardarCliente(cliente As Cliente)
        If String.IsNullOrWhiteSpace(cliente.Nombre) Then
            Throw New Exception("El nombre del cliente es obligatorio")
        End If

        'VALIDACION PARA CARGAR CLIENTE
        If cliente.ID = 0 Then
            If Not clienteDAL.ValidarCorreoValido(cliente.Correo) Then
                Throw New Exception("El correo no es valido")
            End If
            If clienteDAL.ValidacionTelefono(cliente.Telefono) Then
                Throw New Exception("El telefono ya fue ingresado")
            End If
            If clienteDAL.ValidacionCorreo(cliente.Correo) Then
                Throw New Exception("El correo ya fue ingresado")
            End If
            clienteDAL.InsertarCliente(cliente)


        Else
            'VALIDACION PARA MODIFICAR CLIENTES
            If Not clienteDAL.ValidarCorreoValido(cliente.Correo) Then
                Throw New Exception("El correo no es valido")
            End If
            If clienteDAL.validarTelefonoModificar(cliente.Telefono, cliente.ID) Then
                Throw New Exception("El telefono ya fue ingresado")
            End If
            If clienteDAL.ValidarCorreoModificar(cliente.Correo, cliente.ID) Then
                Throw New Exception("El correo ya fue ingresado")
            End If
            clienteDAL.ModificarCliente(cliente)
        End If

    End Sub

    Public Sub EliminarCliente(id As Integer)
        clienteDAL.EliminarCliente(id)
    End Sub

    Public Function ListarClientes() As DataTable
        Return clienteDAL.ListarClientes()
    End Function

    Public Function BuscarCliente(cliente As String, telefono As String, correo As String) As DataTable

        Return clienteDAL.BuscarCliente(cliente, telefono, correo)

    End Function
End Class
