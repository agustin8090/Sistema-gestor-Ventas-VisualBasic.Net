<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVentas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.datepicker = New System.Windows.Forms.DateTimePicker()
        Me.dgvVentas = New System.Windows.Forms.DataGridView()
        Me.VentasitemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PruebademoDataSetventas = New ExamenApp_Visual_basic.pruebademoDataSetventas()
        Me.PruebademodatasetVentasitems = New ExamenApp_Visual_basic.pruebademodatasetVentasitems()
        Me.ProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductosTableAdapter = New ExamenApp_Visual_basic.pruebademodatasetVentasitemsTableAdapters.productosTableAdapter()
        Me.VentasitemsTableAdapter = New ExamenApp_Visual_basic.pruebademoDataSetventasTableAdapters.ventasitemsTableAdapter()
        Me.PruebademoDataSetEleccionClientes = New ExamenApp_Visual_basic.pruebademoDataSetEleccionClientes()
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ClientesTableAdapter = New ExamenApp_Visual_basic.pruebademoDataSetEleccionClientesTableAdapters.clientesTableAdapter()
        Me.cmboxClientes = New System.Windows.Forms.ComboBox()
        Me.PruebademoDataSetventas1 = New ExamenApp_Visual_basic.pruebademoDataSetventas()
        Me.PruebademoDataSetventas1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PruebademoDataSetventas1BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbl = New System.Windows.Forms.Label()
        Me.txtboxtotal = New System.Windows.Forms.TextBox()
        Me.btnCargarItems = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnEdicion = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBuscarVentas = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGuardarCambios = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.eliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.IDVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDProducto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VentasitemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetventas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademodatasetVentasitems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetEleccionClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetventas1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetventas1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSetventas1BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha:"
        '
        'datepicker
        '
        Me.datepicker.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datepicker.Location = New System.Drawing.Point(94, 64)
        Me.datepicker.Name = "datepicker"
        Me.datepicker.Size = New System.Drawing.Size(223, 22)
        Me.datepicker.TabIndex = 4
        '
        'dgvVentas
        '
        Me.dgvVentas.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVentas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVentas.AutoGenerateColumns = False
        Me.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.eliminar, Me.IDVenta, Me.ID, Me.IDProducto, Me.PrecioUnitario, Me.Cantidad})
        Me.dgvVentas.DataSource = Me.VentasitemsBindingSource
        Me.dgvVentas.GridColor = System.Drawing.Color.CadetBlue
        Me.dgvVentas.Location = New System.Drawing.Point(25, 156)
        Me.dgvVentas.Name = "dgvVentas"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Snow
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVentas.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVentas.Size = New System.Drawing.Size(583, 247)
        Me.dgvVentas.TabIndex = 6
        '
        'VentasitemsBindingSource
        '
        Me.VentasitemsBindingSource.DataMember = "ventasitems"
        Me.VentasitemsBindingSource.DataSource = Me.PruebademoDataSetventas
        '
        'PruebademoDataSetventas
        '
        Me.PruebademoDataSetventas.DataSetName = "pruebademoDataSetventas"
        Me.PruebademoDataSetventas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PruebademodatasetVentasitems
        '
        Me.PruebademodatasetVentasitems.DataSetName = "pruebademodatasetVentasitems"
        Me.PruebademodatasetVentasitems.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductosBindingSource
        '
        Me.ProductosBindingSource.DataMember = "productos"
        Me.ProductosBindingSource.DataSource = Me.PruebademodatasetVentasitems
        '
        'ProductosTableAdapter
        '
        Me.ProductosTableAdapter.ClearBeforeFill = True
        '
        'VentasitemsTableAdapter
        '
        Me.VentasitemsTableAdapter.ClearBeforeFill = True
        '
        'PruebademoDataSetEleccionClientes
        '
        Me.PruebademoDataSetEleccionClientes.DataSetName = "pruebademoDataSetEleccionClientes"
        Me.PruebademoDataSetEleccionClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "clientes"
        Me.ClientesBindingSource.DataSource = Me.PruebademoDataSetEleccionClientes
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'cmboxClientes
        '
        Me.cmboxClientes.DataSource = Me.ClientesBindingSource
        Me.cmboxClientes.DisplayMember = "Cliente"
        Me.cmboxClientes.FormattingEnabled = True
        Me.cmboxClientes.Location = New System.Drawing.Point(94, 37)
        Me.cmboxClientes.Name = "cmboxClientes"
        Me.cmboxClientes.Size = New System.Drawing.Size(221, 21)
        Me.cmboxClientes.TabIndex = 1
        Me.cmboxClientes.ValueMember = "ID"
        '
        'PruebademoDataSetventas1
        '
        Me.PruebademoDataSetventas1.DataSetName = "pruebademoDataSetventas"
        Me.PruebademoDataSetventas1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PruebademoDataSetventas1BindingSource
        '
        Me.PruebademoDataSetventas1BindingSource.DataSource = Me.PruebademoDataSetventas1
        Me.PruebademoDataSetventas1BindingSource.Position = 0
        '
        'PruebademoDataSetventas1BindingSource1
        '
        Me.PruebademoDataSetventas1BindingSource1.DataSource = Me.PruebademoDataSetventas1
        Me.PruebademoDataSetventas1BindingSource1.Position = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.Location = New System.Drawing.Point(395, 126)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(48, 20)
        Me.lbl.TabIndex = 8
        Me.lbl.Text = "Total:"
        '
        'txtboxtotal
        '
        Me.txtboxtotal.Enabled = False
        Me.txtboxtotal.Location = New System.Drawing.Point(479, 130)
        Me.txtboxtotal.Name = "txtboxtotal"
        Me.txtboxtotal.Size = New System.Drawing.Size(155, 20)
        Me.txtboxtotal.TabIndex = 9
        '
        'btnCargarItems
        '
        Me.btnCargarItems.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarItems.Location = New System.Drawing.Point(34, 406)
        Me.btnCargarItems.Name = "btnCargarItems"
        Me.btnCargarItems.Size = New System.Drawing.Size(87, 32)
        Me.btnCargarItems.TabIndex = 10
        Me.btnCargarItems.Text = "Agregar"
        Me.btnCargarItems.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Location = New System.Drawing.Point(141, 90)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(105, 29)
        Me.btnCargar.TabIndex = 11
        Me.btnCargar.Text = "Cargar cliente"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'btnEdicion
        '
        Me.btnEdicion.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdicion.Location = New System.Drawing.Point(170, 408)
        Me.btnEdicion.Name = "btnEdicion"
        Me.btnEdicion.Size = New System.Drawing.Size(137, 32)
        Me.btnEdicion.TabIndex = 12
        Me.btnEdicion.Text = "Modo Edicion"
        Me.btnEdicion.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.ClientesBindingSource
        Me.ComboBox1.DisplayMember = "Cliente"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(623, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(165, 21)
        Me.ComboBox1.TabIndex = 13
        Me.ComboBox1.ValueMember = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(497, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 17)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Filtrar Ventas por:"
        '
        'btnBuscarVentas
        '
        Me.btnBuscarVentas.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarVentas.Location = New System.Drawing.Point(674, 28)
        Me.btnBuscarVentas.Name = "btnBuscarVentas"
        Me.btnBuscarVentas.Size = New System.Drawing.Size(68, 27)
        Me.btnBuscarVentas.TabIndex = 15
        Me.btnBuscarVentas.Text = "Buscar"
        Me.btnBuscarVentas.UseVisualStyleBackColor = True
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Location = New System.Drawing.Point(533, 411)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(75, 29)
        Me.btnlimpiar.TabIndex = 16
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(674, 390)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 51)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Volver al menú"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCambios.Location = New System.Drawing.Point(339, 409)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(149, 31)
        Me.btnGuardarCambios.TabIndex = 18
        Me.btnGuardarCambios.Text = "Guardar Cambios"
        Me.btnGuardarCambios.UseVisualStyleBackColor = True
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = "Borrar"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        '
        'eliminar
        '
        Me.eliminar.HeaderText = "Borrar"
        Me.eliminar.MinimumWidth = 20
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Width = 40
        '
        'IDVenta
        '
        Me.IDVenta.DataPropertyName = "IDVenta"
        Me.IDVenta.HeaderText = "IDVenta"
        Me.IDVenta.MinimumWidth = 20
        Me.IDVenta.Name = "IDVenta"
        Me.IDVenta.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 38
        '
        'IDProducto
        '
        Me.IDProducto.DataPropertyName = "IDProducto"
        Me.IDProducto.HeaderText = "Producto"
        Me.IDProducto.MinimumWidth = 40
        Me.IDProducto.Name = "IDProducto"
        Me.IDProducto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IDProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IDProducto.Width = 200
        '
        'PrecioUnitario
        '
        Me.PrecioUnitario.DataPropertyName = "PrecioUnitario"
        Me.PrecioUnitario.HeaderText = "PrecioUnitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Cantidad
        '
        Me.Cantidad.DataPropertyName = "Cantidad"
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'FormVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnGuardarCambios)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btnBuscarVentas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnEdicion)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnCargarItems)
        Me.Controls.Add(Me.txtboxtotal)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.dgvVentas)
        Me.Controls.Add(Me.datepicker)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmboxClientes)
        Me.Name = "FormVentas"
        Me.Text = "Gestion de Ventas"
        CType(Me.dgvVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VentasitemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetventas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademodatasetVentasitems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetEleccionClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetventas1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetventas1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSetventas1BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents datepicker As DateTimePicker
    Friend WithEvents dgvVentas As DataGridView
    Friend WithEvents PruebademodatasetVentasitems As pruebademodatasetVentasitems
    Friend WithEvents ProductosBindingSource As BindingSource
    Friend WithEvents ProductosTableAdapter As pruebademodatasetVentasitemsTableAdapters.productosTableAdapter
    Friend WithEvents PruebademoDataSetventas As pruebademoDataSetventas
    Friend WithEvents VentasitemsBindingSource As BindingSource
    Friend WithEvents VentasitemsTableAdapter As pruebademoDataSetventasTableAdapters.ventasitemsTableAdapter
    Friend WithEvents PruebademoDataSetEleccionClientes As pruebademoDataSetEleccionClientes
    Friend WithEvents ClientesBindingSource As BindingSource
    Friend WithEvents ClientesTableAdapter As pruebademoDataSetEleccionClientesTableAdapters.clientesTableAdapter
    Friend WithEvents cmboxClientes As ComboBox
    Friend WithEvents PruebademoDataSetventas1 As pruebademoDataSetventas
    Friend WithEvents PruebademoDataSetventas1BindingSource As BindingSource
    Friend WithEvents PruebademoDataSetventas1BindingSource1 As BindingSource
    Friend WithEvents lbl As Label
    Friend WithEvents txtboxtotal As TextBox
    Friend WithEvents btnCargarItems As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents btnEdicion As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnBuscarVentas As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnGuardarCambios As Button
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents eliminar As DataGridViewButtonColumn
    Friend WithEvents IDVenta As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents IDProducto As DataGridViewComboBoxColumn
    Friend WithEvents PrecioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As DataGridViewTextBoxColumn
End Class
