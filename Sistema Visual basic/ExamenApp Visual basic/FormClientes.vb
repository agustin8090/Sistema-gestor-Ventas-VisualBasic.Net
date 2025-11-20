Imports System.Text.RegularExpressions
Public Class FormClientes
    Private clienteNegocio As New ClienteNegocio()

    Private Sub txtboxNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtboxNombre.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnCargarCliente_Click(sender As Object, e As EventArgs) Handles btnCargarCliente.Click
        btnCargarCliente.Enabled = False
        Dim cliente As New Cliente()
        If String.IsNullOrWhiteSpace(txtboxNombre.Text) OrElse
            String.IsNullOrWhiteSpace(txtboxTelefono.Text) OrElse
            String.IsNullOrWhiteSpace(txtboxCorreo.Text) Then

            MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnCargarCliente.Enabled = True
            Return

        End If

        cliente.ID = 0
        cliente.Nombre = txtboxNombre.Text
        cliente.Telefono = txtboxTelefono.Text
        cliente.Correo = txtboxCorreo.Text

        Task.Run(Sub()
                     Try
                         ' Llamar al método de la capa de negocio
                         clienteNegocio.GuardarCliente(cliente)

                         ' Vuelve al hilo de la interfaz de usuario para mostrar el mensaje
                         Me.Invoke(Sub()
                                       MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       ' Habilita el botón de nuevo
                                       btnCargarCliente.Enabled = True
                                       CargarTabla()
                                       txtboxNombre.Text = ""
                                       txtboxTelefono.Text = ""
                                       txtboxCorreo.Text = ""
                                   End Sub)
                     Catch ex As Exception
                         ' Vuelve al hilo de la interfaz de usuario para mostrar el error
                         Me.Invoke(Sub()
                                       MessageBox.Show("Error al guardar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       ' Habilita el botón de nuevo
                                       btnCargarCliente.Enabled = True
                                   End Sub)
                     End Try
                 End Sub)
    End Sub

    Private Sub FormClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarTabla()
        dgvClientes.ClearSelection()
        dgvClientes.AllowUserToAddRows = False


    End Sub



    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        btnModificar.Enabled = False
        Dim cliente As New Cliente()
        If String.IsNullOrWhiteSpace(txtboxNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxTelefono.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxCorreo.Text) Then

            MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnModificar.Enabled = True
            Return
        End If
        Dim id As Integer
        If Not Integer.TryParse(dgvClientes.CurrentRow.Cells("ID").Value, id) Then
            MessageBox.Show("El id no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If

        cliente.ID = id
        cliente.Nombre = txtboxNombre.Text
        cliente.Telefono = txtboxTelefono.Text
        cliente.Correo = txtboxCorreo.Text
        Task.Run(Sub()
                     Try
                         clienteNegocio.GuardarCliente(cliente)

                         Me.Invoke(Sub()
                                       MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       btnModificar.Enabled = True
                                       CargarTabla()
                                       txtboxNombre.Text = ""
                                       txtboxTelefono.Text = ""
                                       txtboxCorreo.Text = ""
                                       dgvClientes.ClearSelection()
                                   End Sub)
                     Catch ex As Exception
                         Me.Invoke(Sub()
                                       MessageBox.Show("Error al guardar el cliente: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       btnModificar.Enabled = True
                                   End Sub)
                     End Try
                 End Sub)
    End Sub

    Private filaseleccionada As Boolean = False
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellClick
        If e.RowIndex >= 0 AndAlso Not dgvClientes.Rows(e.RowIndex).IsNewRow Then
            filaseleccionada = True

        End If

        If Not dgvClientes.CurrentRow Is Nothing Then
            txtboxNombre.Text = dgvClientes.CurrentRow.Cells("Cliente").Value.ToString()
            txtboxTelefono.Text = dgvClientes.CurrentRow.Cells("Telefono").Value.ToString()
            txtboxCorreo.Text = dgvClientes.CurrentRow.Cells("Correo").Value.ToString()
            btnModificar.Enabled = True

        End If
    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cliente As New Cliente()
        Dim id As Integer
        Try
            If Not filaseleccionada OrElse dgvClientes.CurrentRow Is Nothing OrElse dgvClientes.CurrentRow.IsNewRow Then
                MessageBox.Show("Porfavor seleccione un cliente valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Integer.TryParse(dgvClientes.CurrentRow.Cells("ID").Value, id) Then
                Throw New Exception("Id no valido")

            End If

            cliente.ID = id
            clienteNegocio.EliminarCliente(cliente.ID)
            MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            CargarTabla()
            txtboxCorreo.Text = ""
            txtboxNombre.Text = ""
            txtboxTelefono.Text = ""
            dgvClientes.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el cliente:" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVolverMenu_Click(sender As Object, e As EventArgs) Handles btnVolverMenu.Click
        Dim F As New Form1
        F.Show()
        Me.Close()
    End Sub

    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        Dim filtro As String = ""
        Dim valor As String = txtboxBuscarpor.Text
        If ComboBox1.SelectedItem IsNot Nothing Then
            filtro = ComboBox1.SelectedItem.ToString()
        End If

        Select Case filtro
            Case "Nombre"
                Dim resultado As DataTable = clienteNegocio.BuscarCliente(valor, Nothing, Nothing)
                dgvClientes.DataSource = resultado

            Case "Telefono"
                Dim resultado As DataTable = clienteNegocio.BuscarCliente(Nothing, valor, Nothing)
                dgvClientes.DataSource = resultado

            Case "Correo"
                Dim resultado As DataTable = clienteNegocio.BuscarCliente(Nothing, Nothing, valor)
                dgvClientes.DataSource = resultado

            Case Else
                Dim resultado As DataTable = clienteNegocio.ListarClientes()
                dgvClientes.DataSource = resultado
        End Select

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs)
        CargarTabla()

    End Sub

    Private Sub CargarTabla()
        Try
            Dim tablita As DataTable = clienteNegocio.ListarClientes()
            dgvClientes.DataSource = tablita
            dgvClientes.ClearSelection()

            dgvClientes.CurrentCell = Nothing
            filaseleccionada = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtboxCorreo_TextChanged(sender As Object, e As EventArgs) Handles txtboxCorreo.TextChanged

    End Sub

    Private Sub dgvClientes_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvClientes.RowPostPaint
        Using b As New SolidBrush(dgvClientes.RowHeadersDefaultCellStyle.ForeColor)
            ' Dibuja el número de la fila. Se suma 1 al RowIndex porque este es 0-based.
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub txtboxTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtboxTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dgvClientes.ClearSelection()
        If dgvClientes.CurrentRow IsNot Nothing Then
            dgvClientes.CurrentCell = Nothing
        End If
        txtboxNombre.Text = ""
        txtboxTelefono.Text = ""
        txtboxCorreo.Text = ""
    End Sub
End Class