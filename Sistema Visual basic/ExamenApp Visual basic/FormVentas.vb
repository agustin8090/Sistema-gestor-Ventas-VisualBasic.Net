Public Class FormVentas
    Private Sub FormVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ClientesTableAdapter.Fill(Me.PruebademoDataSetEleccionClientes.clientes)

        Me.ProductosTableAdapter.Fill(Me.PruebademodatasetVentasitems.productos)

        Dim productos As New ProductoNegocio
        Dim clientes As New ClienteNegocio
        Try

            Dim tablaProductos As DataTable = productos.ListarProducto()
            Dim combocolumna As DataGridViewComboBoxColumn = CType(dgvVentas.Columns("IDProducto"), DataGridViewComboBoxColumn)
            combocolumna.DataSource = productos.ListarProducto()
            combocolumna.DisplayMember = "Nombre"
            combocolumna.ValueMember = "ID"
            dgvVentas.Enabled = False
            btnGuardarCambios.Visible = False
            btnEdicion.Enabled = False
            btnCargarItems.Enabled = False
            dgvVentas.CurrentCell = Nothing


        Catch ex As Exception
            MessageBox.Show("Error al cargar los productos en el ComboBox: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub dgvVentas_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellValueChanged
        Dim productos As New ProductoNegocio

        If dgvVentas.Columns(e.ColumnIndex).Name = "IDProducto" Then

            If e.RowIndex >= 0 AndAlso dgvVentas.Rows(e.RowIndex).Cells("IDProducto").Value IsNot DBNull.Value Then

                Dim idproducto As Integer = Convert.ToInt32(dgvVentas.Rows(e.RowIndex).Cells("IDProducto").Value)
                Dim tablaproducto As DataTable = productos.BuscarProductoporID(idproducto)
                If tablaproducto IsNot Nothing AndAlso tablaproducto.Rows.Count > 0 Then

                    Dim precio As Single = Convert.ToSingle(tablaproducto.Rows(0)("Precio"))
                    dgvVentas.Rows(e.RowIndex).Cells("PrecioUnitario").Value = precio

                End If
            End If
        End If
    End Sub

    'sirve para aplicar los cambios del cell valuechanged de manera instantanea
    Private Sub dgvVentas_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvVentas.CurrentCellDirtyStateChanged
        If dgvVentas.IsCurrentCellDirty Then
            dgvVentas.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim venta As New Venta()
        Dim ventanegocio As New VentaNegocio
        venta.IDCliente = cmboxClientes.SelectedValue
        venta.Fecha = datepicker.Value

        Try
            'guardamos el value del combo box que muestra el nombre del cliente(value=id) junto con la fecha seleccionada
            idventaactual = ventanegocio.GuardarVenta(venta)
            MessageBox.Show("Venta #" & idventaactual.ToString() & "iniciada. Agregue los items a continuacion", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvVentas.Enabled = True
            btnCargarItems.Enabled = True
            'dgvVentas.DataSource = Nothing
            'dgvVentas.Rows.Clear()
            txtboxtotal.Clear()

        Catch ex As Exception

            MessageBox.Show("Error al registrar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private idventaactual As Integer

    Private Sub btncargaritems_click(sender As Object, e As EventArgs) Handles btnCargarItems.Click
        Dim totalVenta As Single = 0.0
        Dim ventaitemn As New VentaItemNegocio()
        Dim ventanegocio As New VentaNegocio()

        Try
            If dgvVentas.Rows.Count <= 1 OrElse (dgvVentas.Rows.Count = 1 AndAlso dgvVentas.Rows(0).IsNewRow) Then
                ventanegocio.EliminarVenta(idventaactual)
                MessageBox.Show("No se han agregado ítems a la venta. La venta ha sido eliminada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnlimpiar_Click(sender, e)
                Return
            End If

            ' Usamos un bucle For para ser más seguro al recorrer las filas
            For i As Integer = 0 To dgvVentas.Rows.Count - 1
                Dim fila As DataGridViewRow = dgvVentas.Rows(i)

                If Not fila.IsNewRow Then
                    ' Validaciones para evitar DBNull
                    If fila.Cells("IDProducto").Value IsNot DBNull.Value AndAlso fila.Cells("Cantidad").Value IsNot DBNull.Value Then
                        Dim ventaitem As New Ventaitem()
                        ventaitem.IDVenta = idventaactual
                        ventaitem.IDProducto = Convert.ToInt32(fila.Cells("IDProducto").Value)
                        ventaitem.Cantidad = Convert.ToSingle(fila.Cells("Cantidad").Value)
                        ventaitem.PrecioUnitario = Convert.ToSingle(fila.Cells("PrecioUnitario").Value)
                        ventaitem.PrecioTotal = ventaitem.PrecioUnitario * ventaitem.Cantidad
                        totalVenta += ventaitem.PrecioTotal

                        ' Si el ID es 0 o nulo, es un nuevo ítem y lo guardamos
                        If fila.Cells("ID").Value Is DBNull.Value OrElse Convert.ToInt32(fila.Cells("ID").Value) = 0 Then
                            ventaitemn.GuardarVentaItem(ventaitem)
                        Else
                            ' Si el ID existe, actualizamos
                            Dim idItem As Integer = Convert.ToInt32(fila.Cells("ID").Value)
                            ventaitemn.ActualizarVentaItem(idItem, ventaitem)
                        End If
                    End If
                End If
            Next

            ventanegocio.ActualizarTabla(idventaactual, totalVenta)

            MessageBox.Show("Carga exitosa. Venta #" & idventaactual.ToString() & " guardada con todos sus ítems.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnlimpiar_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error al registrar la venta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ventanegocio.EliminarVenta(idventaactual)
        End Try
    End Sub

    Private Sub dgvVentas_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles dgvVentas.DefaultValuesNeeded
        e.Row.Cells("IDVenta").Value = idventaactual

    End Sub




    Private Sub dgvVentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellContentClick

        If dgvVentas.Columns(e.ColumnIndex).Name = "eliminar" AndAlso e.RowIndex >= 0 Then
            ' Pregunta al usuario antes de eliminar
            Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro que quieres eliminar esta fila?", "Confirmar Elección", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                Try
                    ' Verificamos si la celda ID tiene un valor. Si no, es un ítem NUEVO.
                    If dgvVentas.Rows(e.RowIndex).Cells("ID").Value IsNot DBNull.Value AndAlso Convert.ToInt32(dgvVentas.Rows(e.RowIndex).Cells("ID").Value) > 0 Then
                        ' Si tiene un ID, lo borramos de la base de datos
                        Dim idventaitem As Integer = Convert.ToInt32(dgvVentas.Rows(e.RowIndex).Cells("ID").Value)
                        Dim ventaitemN As New VentaItemNegocio()
                        ventaitemN.EliminarVentaItem(idventaitem)
                        MessageBox.Show("Ítem eliminado de la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        ' Si es un ítem nuevo, solo lo borramos de la grilla en memoria
                        MessageBox.Show("Ítem eliminado de la grilla (no estaba guardado).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Borramos la fila de la grilla
                    dgvVentas.Rows.RemoveAt(e.RowIndex)

                Catch ex As Exception
                    MessageBox.Show("Error al eliminar el ítem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub


    Private Sub btnBuscarVentas_Click(sender As Object, e As EventArgs) Handles btnBuscarVentas.Click

        Try
            'sacamos ID del cliente seleccionado
            If cmboxClientes.SelectedValue Is Nothing Then
                MessageBox.Show("Por favor, selecciona un cliente para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim idCliente As Integer = Convert.ToInt32(cmboxClientes.SelectedValue)

            '  Llama a la capa de negocio para obtener las ventas de ese cliente
            Dim ventanegocio As New VentaNegocio()
            Dim tablaVentas As DataTable = ventanegocio.BuscarVentasPorCliente(idCliente)

            '  Muestra los resultados en el DataGridView
            dgvVentas.DataSource = tablaVentas

            MessageBox.Show("Búsqueda finalizada. Se encontraron " & tablaVentas.Rows.Count.ToString() & " ventas para el cliente seleccionado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgvVentas.Enabled = True


            btnCargarItems.Enabled = False
            btnCargar.Enabled = False
            btnEdicion.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al buscar las ventas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click
        cmboxClientes.SelectedIndex = 0
        datepicker.Value = Date.Now

        ' Reinicia el TextBox del total
        txtboxtotal.Text = 0.0

        dgvVentas.DataSource = Nothing
        dgvVentas.Rows.Clear()

        ' Deshabilita la grilla de nuevo, para que el usuario no pueda cargar items sin una venta principal
        dgvVentas.Enabled = False
        btnCargar.Enabled = True
        btnCargarItems.Enabled = False
        btnEdicion.Enabled = False

        MessageBox.Show("El formulario ha sido limpiado y está listo para una nueva venta.", "Formulario Reiniciado", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnEdicion.Click
        '
        dgvVentas.ReadOnly = False

        ' deshabilitamos las columnas q no pueden ser modificadas
        dgvVentas.Columns("IDVenta").ReadOnly = True
        'dgvVentas.Columns("IDProducto").ReadOnly = True

        ' ocultamos boton edicion para que solo muestre el GUARDAR CAMBIOS 
        btnEdicion.Visible = False
        btnGuardarCambios.Visible = True

        MessageBox.Show("Modo de edición activado. Puedes realizar cambios en la Cantidad, Precio Y Producto.", "Modificar Venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnGuardarCambios_Click(sender As Object, e As EventArgs) Handles btnGuardarCambios.Click
        Dim totalVenta As Single = 0.0
        Dim ventaitemn As New VentaItemNegocio()
        Dim ventanegocio As New VentaNegocio()
        Dim idventaactuall As Integer = 0

        Try
            For Each fila As DataGridViewRow In dgvVentas.Rows
                If Not fila.IsNewRow Then
                    Dim ventaitem As New Ventaitem()
                    ' Obtiene el ID del ítem de venta. Este es clave para el UPDATE
                    Dim idItem As Integer = Convert.ToInt32(fila.Cells("ID").Value)
                    If idventaactuall = 0 Then

                        idventaactuall = Convert.ToInt32(fila.Cells("IDVenta").Value)
                    End If
                    ventaitem.IDVenta = Convert.ToInt32(fila.Cells("IDVenta").Value)
                    ventaitem.IDProducto = Convert.ToInt32(fila.Cells("IDProducto").Value)
                    ventaitem.Cantidad = Convert.ToSingle(fila.Cells("Cantidad").Value)
                    ventaitem.PrecioUnitario = Convert.ToSingle(fila.Cells("PrecioUnitario").Value)
                    ventaitem.PrecioTotal = ventaitem.PrecioUnitario * ventaitem.Cantidad

                    totalVenta += ventaitem.PrecioTotal

                    '  llamar a la capa de negocio para actualizar el ítem
                    ventaitemn.ActualizarVentaItem(idItem, ventaitem)
                End If
            Next

            ' Actualiza el total final de la venta principal
            ventanegocio.ActualizarTabla(idventaactuall, totalVenta)

            MessageBox.Show("Cambios guardados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Deshabilita el modo de edición y oculta el botón de Guardar
            dgvVentas.ReadOnly = True
            btnEdicion.Visible = True
            btnGuardarCambios.Visible = False

        Catch ex As Exception
            MessageBox.Show("Error al guardar los cambios: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvVentas_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles dgvVentas.RowPostPaint
        Using b As New SolidBrush(dgvVentas.RowHeadersDefaultCellStyle.ForeColor)

            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvVentas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVentas.CellClick
        If e.RowIndex >= 0 Then
            'VALIDACIONES   
            ' revisa si la celda IDVenta de la fila seleccionada no está vacía para q no salte error
            If dgvVentas.Rows(e.RowIndex).Cells("IDVenta").Value IsNot DBNull.Value Then
                Dim idVentaSeleccionada As Integer = Convert.ToInt32(dgvVentas.Rows(e.RowIndex).Cells("IDVenta").Value)
                Dim totalVenta As Single = 0.0

                For Each fila As DataGridViewRow In dgvVentas.Rows
                    ' revisa que no sea la fila nueva vacía y que la celda IDVenta no sea nula
                    If Not fila.IsNewRow AndAlso fila.Cells("IDVenta").Value IsNot DBNull.Value Then
                        Dim idVentaFila As Integer = Convert.ToInt32(fila.Cells("IDVenta").Value)

                        ' ahora si la fila seleccionado es parte de la misma venta
                        If idVentaFila = idVentaSeleccionada Then
                            ' VALIDAMOS SUS CELDAS PRECIOUNITARIO Y CANTIDAD, PARA DESPUES PODER HACER EL CALCULO TOTAL
                            If fila.Cells("PrecioUnitario").Value IsNot DBNull.Value AndAlso fila.Cells("Cantidad").Value IsNot DBNull.Value Then
                                Dim precio As Single = Convert.ToSingle(fila.Cells("PrecioUnitario").Value)
                                Dim cantidad As Integer = Convert.ToInt32(fila.Cells("Cantidad").Value)

                                totalVenta += precio * cantidad
                            End If
                        End If
                    End If
                Next

                ' Actualiza el txtbox del total solo si el ID de venta pasa todas las validaciones
                txtboxtotal.Text = totalVenta.ToString("N2")
            Else
                ' Si la celda IDVenta es nula (como en una nueva venta), limpia el txtbox
                txtboxtotal.Text = "0.00"
            End If
        End If
    End Sub

End Class