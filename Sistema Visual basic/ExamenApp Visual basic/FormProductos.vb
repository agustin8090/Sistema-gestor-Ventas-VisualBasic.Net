Imports System.Diagnostics.Eventing.Reader

Public Class FormProductos
    Private productonegocio As New ProductoNegocio()


    Private Sub FormProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cargarTabla()
        DataGridView1.ClearSelection()
        DataGridView1.AllowUserToAddRows = False


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        btnGuardar.Enabled = False
        Dim producto As New Producto()

        If String.IsNullOrWhiteSpace(txtboxNombre.Text) OrElse
            String.IsNullOrWhiteSpace(txtboxPrecio.Text) OrElse
            String.IsNullOrWhiteSpace(txtboxCategoria.Text) Then

            MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnGuardar.Enabled = True
            Return
        End If

        Dim precio As Single
        If Not Single.TryParse(txtboxPrecio.Text, precio) Then
            MessageBox.Show("El precio no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnGuardar.Enabled = True
            Return
        End If


        producto.Nombre = txtboxNombre.Text
        producto.Precio = precio
        producto.Categoria = txtboxCategoria.Text

        Task.Run(Sub()
                     Try
                         ' Llamar al método de la capa de negocio
                         productonegocio.GuardarProducto(producto)


                         ' Vuelve al hilo de la interfaz de usuario para mostrar el mensaje
                         Me.Invoke(Sub()
                                       MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       ' Habilita el botón de nuevo
                                       btnGuardar.Enabled = True
                                       cargarTabla()
                                       txtboxNombre.Text = ""
                                       txtboxPrecio.Text = ""
                                       txtboxCategoria.Text = ""
                                       DataGridView1.ClearSelection()
                                   End Sub)
                     Catch ex As Exception
                         ' Vuelve al hilo de la interfaz de usuario para mostrar el error
                         Me.Invoke(Sub()
                                       MessageBox.Show("Error al guardar el Producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       ' Habilita el botón de nuevo
                                       btnGuardar.Enabled = True
                                   End Sub)
                     End Try
                 End Sub)
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        btnModificar.Enabled = False
        Dim producto As New Producto()
        If String.IsNullOrWhiteSpace(txtboxNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxPrecio.Text) OrElse
           String.IsNullOrWhiteSpace(txtboxCategoria.Text) Then

            MessageBox.Show("Seleccione el producto a modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnModificar.Enabled = True
            Return
        End If

        '///////////////////////////////////////////////////////////////////////////////////////
        Dim id As Integer
        Dim precio As Single

        If Not Integer.TryParse(DataGridView1.CurrentRow.Cells("ID").Value.ToString(), id) OrElse
         Not Single.TryParse(txtboxPrecio.Text, precio) Then

            MessageBox.Show("El id o precio no son validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            btnModificar.Enabled = True
            Return
        End If
        producto.ID = id
        producto.Nombre = txtboxNombre.Text
        producto.Precio = precio
        producto.Categoria = txtboxCategoria.Text
        '///////////////////////////////////////////////////////////////////////////////////////
        Task.Run(Sub()
                     Try
                         ' Llamar al método de la capa de negocio
                         productonegocio.GuardarProducto(producto)


                         ' Vuelve al hilo de la interfaz de usuario para mostrar el mensaje
                         Me.Invoke(Sub()
                                       MessageBox.Show("Producto Modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                       ' Habilita el botón de nuevo
                                       btnModificar.Enabled = True
                                       cargarTabla()
                                       txtboxNombre.Text = ""
                                       txtboxPrecio.Text = ""
                                       txtboxCategoria.Text = ""
                                       DataGridView1.ClearSelection()

                                   End Sub)
                     Catch ex As Exception
                         ' Vuelve al hilo de la interfaz de usuario para mostrar el error
                         Me.Invoke(Sub()
                                       MessageBox.Show("Error al Modificar el Producto: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                       ' Habilita el botón de nuevo
                                       btnModificar.Enabled = True
                                   End Sub)
                     End Try
                 End Sub)

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnVolverMenu.Click
        Form1.Show()
        Me.Hide()
    End Sub


    Private filaseleccionada As Boolean = False
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso Not DataGridView1.Rows(e.RowIndex).IsNewRow Then
            filaseleccionada = True

        End If

        If Not DataGridView1.CurrentRow Is Nothing Then

            txtboxNombre.Text = DataGridView1.CurrentRow.Cells("Nombre").Value.ToString()
            txtboxPrecio.Text = DataGridView1.CurrentRow.Cells("Precio").Value.ToString()
            txtboxCategoria.Text = DataGridView1.CurrentRow.Cells("Categoria").Value.ToString()

            btnModificar.Enabled = True

        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id As Integer
        Dim producto As New Producto()
        Try
            If Not filaseleccionada OrElse DataGridView1.CurrentRow Is Nothing OrElse DataGridView1.CurrentRow.IsNewRow Then
                MessageBox.Show("Por favor seleccione un producto válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Not Integer.TryParse(DataGridView1.CurrentRow.Cells("ID").Value, id) Then
                Throw New Exception("El id seleccionado no es valido")
            End If

            producto.ID = id
            productonegocio.EliminarProducto(producto.ID)
            MessageBox.Show("Producto eliminado exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cargarTabla()
            txtboxNombre.Text = ""
            txtboxPrecio.Text = ""
            txtboxCategoria.Text = ""
            DataGridView1.ClearSelection()
            'filaseleccionada = False
        Catch ex As Exception
            MessageBox.Show("Error al eliminar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim filtro As String = ""

        If ComboBox1.SelectedItem IsNot Nothing Then
            filtro = ComboBox1.SelectedItem.ToString()
        End If
        Dim valor As String = txtboxBuscar.Text

        Select Case filtro
            Case "Nombre"
                Dim resultado As DataTable = productonegocio.BuscarProducto(valor, Nothing, Nothing)
                DataGridView1.DataSource = resultado

            Case "Precio"
                Dim precio As Single
                If Single.TryParse(valor, precio) Then
                    Dim resultado As DataTable = productonegocio.BuscarProducto(Nothing, valor, Nothing)
                    DataGridView1.DataSource = resultado
                End If
            Case "Categoria"
                Dim resultado As DataTable = productonegocio.BuscarProducto(Nothing, Nothing, valor)
                DataGridView1.DataSource = resultado

            Case Else
                Dim resultado As DataTable = productonegocio.ListarProducto()
                DataGridView1.DataSource = resultado

        End Select

    End Sub

    Private Sub cargarTabla()
        Try
            Dim tablita As DataTable = productonegocio.ListarProducto()
            DataGridView1.DataSource = tablita
            DataGridView1.ClearSelection()
            DataGridView1.CurrentCell = Nothing
            filaseleccionada = False

        Catch ex As Exception
            MessageBox.Show("Error al cargar la tabla de productos" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Using b As New SolidBrush(DataGridView1.RowHeadersDefaultCellStyle.ForeColor)
            ' Dibuja el número de la fila. Se suma 1 al RowIndex porque este es 0-based.
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub txtboxCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtboxCategoria.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        DataGridView1.ClearSelection()
        If DataGridView1.CurrentRow IsNot Nothing Then
            DataGridView1.CurrentCell = Nothing
        End If
        txtboxCategoria.Text = ""
        txtboxNombre.Text = ""
        txtboxPrecio.Text = ""

    End Sub
End Class