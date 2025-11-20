<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClientes
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
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnVolverMenu = New System.Windows.Forms.Button()
        Me.txtboxNombre = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtboxTelefono = New System.Windows.Forms.TextBox()
        Me.lblCorreo = New System.Windows.Forms.Label()
        Me.txtboxCorreo = New System.Windows.Forms.TextBox()
        Me.btnCargarCliente = New System.Windows.Forms.Button()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Correo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PruebademoDataSet = New ExamenApp_Visual_basic.pruebademoDataSet()
        Me.ClientesTableAdapter = New ExamenApp_Visual_basic.pruebademoDataSetTableAdapters.clientesTableAdapter()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblbuscar = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtboxBuscarpor = New System.Windows.Forms.TextBox()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PruebademoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(26, 92)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(145, 20)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre y Apellido:"
        '
        'btnVolverMenu
        '
        Me.btnVolverMenu.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVolverMenu.Location = New System.Drawing.Point(658, 387)
        Me.btnVolverMenu.Name = "btnVolverMenu"
        Me.btnVolverMenu.Size = New System.Drawing.Size(111, 51)
        Me.btnVolverMenu.TabIndex = 1
        Me.btnVolverMenu.Text = "Volver al menú"
        Me.btnVolverMenu.UseVisualStyleBackColor = True
        '
        'txtboxNombre
        '
        Me.txtboxNombre.Location = New System.Drawing.Point(171, 94)
        Me.txtboxNombre.Name = "txtboxNombre"
        Me.txtboxNombre.Size = New System.Drawing.Size(126, 20)
        Me.txtboxNombre.TabIndex = 2
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.Location = New System.Drawing.Point(95, 143)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(74, 20)
        Me.lblTelefono.TabIndex = 3
        Me.lblTelefono.Text = "Telefono:"
        '
        'txtboxTelefono
        '
        Me.txtboxTelefono.Location = New System.Drawing.Point(171, 145)
        Me.txtboxTelefono.Name = "txtboxTelefono"
        Me.txtboxTelefono.Size = New System.Drawing.Size(126, 20)
        Me.txtboxTelefono.TabIndex = 4
        '
        'lblCorreo
        '
        Me.lblCorreo.AutoSize = True
        Me.lblCorreo.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorreo.Location = New System.Drawing.Point(108, 189)
        Me.lblCorreo.Name = "lblCorreo"
        Me.lblCorreo.Size = New System.Drawing.Size(60, 20)
        Me.lblCorreo.TabIndex = 5
        Me.lblCorreo.Text = "Correo:"
        '
        'txtboxCorreo
        '
        Me.txtboxCorreo.Location = New System.Drawing.Point(171, 189)
        Me.txtboxCorreo.Name = "txtboxCorreo"
        Me.txtboxCorreo.Size = New System.Drawing.Size(126, 20)
        Me.txtboxCorreo.TabIndex = 6
        '
        'btnCargarCliente
        '
        Me.btnCargarCliente.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargarCliente.Location = New System.Drawing.Point(12, 275)
        Me.btnCargarCliente.Name = "btnCargarCliente"
        Me.btnCargarCliente.Size = New System.Drawing.Size(102, 28)
        Me.btnCargarCliente.TabIndex = 7
        Me.btnCargarCliente.Text = "Cargar"
        Me.btnCargarCliente.UseVisualStyleBackColor = True
        '
        'dgvClientes
        '
        Me.dgvClientes.AutoGenerateColumns = False
        Me.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Cliente, Me.Telefono, Me.Correo})
        Me.dgvClientes.DataSource = Me.ClientesBindingSource
        Me.dgvClientes.Location = New System.Drawing.Point(355, 92)
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.Size = New System.Drawing.Size(414, 240)
        Me.dgvClientes.TabIndex = 8
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Width = 35
        '
        'Cliente
        '
        Me.Cliente.DataPropertyName = "Cliente"
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        '
        'Telefono
        '
        Me.Telefono.DataPropertyName = "Telefono"
        Me.Telefono.HeaderText = "Telefono"
        Me.Telefono.Name = "Telefono"
        '
        'Correo
        '
        Me.Correo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Correo.DataPropertyName = "Correo"
        Me.Correo.HeaderText = "Correo"
        Me.Correo.Name = "Correo"
        '
        'ClientesBindingSource
        '
        Me.ClientesBindingSource.DataMember = "clientes"
        Me.ClientesBindingSource.DataSource = Me.PruebademoDataSet
        '
        'PruebademoDataSet
        '
        Me.PruebademoDataSet.DataSetName = "pruebademoDataSet"
        Me.PruebademoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ClientesTableAdapter
        '
        Me.ClientesTableAdapter.ClearBeforeFill = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(120, 275)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(102, 28)
        Me.btnModificar.TabIndex = 9
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(238, 275)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(93, 28)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblbuscar
        '
        Me.lblbuscar.AutoSize = True
        Me.lblbuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbuscar.Location = New System.Drawing.Point(442, 5)
        Me.lblbuscar.Name = "lblbuscar"
        Me.lblbuscar.Size = New System.Drawing.Size(123, 17)
        Me.lblbuscar.TabIndex = 12
        Me.lblbuscar.Text = "Buscar cliente por:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Nombre", "Telefono", "Correo"})
        Me.ComboBox1.Location = New System.Drawing.Point(563, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(76, 21)
        Me.ComboBox1.TabIndex = 13
        '
        'txtboxBuscarpor
        '
        Me.txtboxBuscarpor.Location = New System.Drawing.Point(645, 6)
        Me.txtboxBuscarpor.Name = "txtboxBuscarpor"
        Me.txtboxBuscarpor.Size = New System.Drawing.Size(143, 20)
        Me.txtboxBuscarpor.TabIndex = 14
        '
        'btnbuscar
        '
        Me.btnbuscar.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnbuscar.Location = New System.Drawing.Point(673, 32)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(75, 29)
        Me.btnbuscar.TabIndex = 15
        Me.btnbuscar.Text = "Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Location = New System.Drawing.Point(391, 338)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 20)
        Me.btnLimpiar.TabIndex = 16
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'FormClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.txtboxBuscarpor)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.lblbuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.dgvClientes)
        Me.Controls.Add(Me.btnCargarCliente)
        Me.Controls.Add(Me.txtboxCorreo)
        Me.Controls.Add(Me.lblCorreo)
        Me.Controls.Add(Me.txtboxTelefono)
        Me.Controls.Add(Me.lblTelefono)
        Me.Controls.Add(Me.txtboxNombre)
        Me.Controls.Add(Me.btnVolverMenu)
        Me.Controls.Add(Me.lblNombre)
        Me.Name = "FormClientes"
        Me.Text = "Gestion de clientes"
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PruebademoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombre As Label
    Friend WithEvents btnVolverMenu As Button
    Friend WithEvents txtboxNombre As TextBox
    Friend WithEvents lblTelefono As Label
    Friend WithEvents txtboxTelefono As TextBox
    Friend WithEvents lblCorreo As Label
    Friend WithEvents txtboxCorreo As TextBox
    Friend WithEvents btnCargarCliente As Button
    Friend WithEvents dgvClientes As DataGridView
    Friend WithEvents PruebademoDataSet As pruebademoDataSet
    Friend WithEvents ClientesBindingSource As BindingSource
    Friend WithEvents ClientesTableAdapter As pruebademoDataSetTableAdapters.clientesTableAdapter
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Telefono As DataGridViewTextBoxColumn
    Friend WithEvents Correo As DataGridViewTextBoxColumn
    Friend WithEvents lblbuscar As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents txtboxBuscarpor As TextBox
    Friend WithEvents btnbuscar As Button
    Friend WithEvents btnLimpiar As Button
End Class
