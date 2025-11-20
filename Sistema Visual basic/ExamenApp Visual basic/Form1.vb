

Imports System.Security.Cryptography

Public Class Form1

    'DISEÑO
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuración del formulario
        Me.Text = "Menú Principal"
        Me.BackColor = Color.White
        Me.Size = New Size(800, 500)

        '  lateral
        Dim panelMenu As New Panel()
        panelMenu.Dock = DockStyle.Left
        panelMenu.Width = 200
        panelMenu.BackColor = Color.LightGray
        Me.Controls.Add(panelMenu)

        ' Botón Clientes
        Dim btnClientes As New Button()
        btnClientes.Text = "Clientes"
        EstiloBoton(btnClientes)
        btnClientes.Top = 50

        AddHandler btnClientes.Click, AddressOf BtnClientes_Click
        panelMenu.Controls.Add(btnClientes)

        ' Botón Productos
        Dim btnProductos As New Button()
        btnProductos.Text = "Productos"
        EstiloBoton(btnProductos)
        btnProductos.Top = 110
        AddHandler btnProductos.Click, AddressOf BtnProductos_Click
        panelMenu.Controls.Add(btnProductos)

        ' Botón Ventas
        Dim btnVentas As New Button()
        btnVentas.Text = "Ventas"
        EstiloBoton(btnVentas)
        btnVentas.Top = 170
        panelMenu.Controls.Add(btnVentas)
        AddHandler btnVentas.Click, AddressOf btnVentas_Click

    End Sub

    'ACCION BOTONES
    '-------------------------------------------------------------
    Private Sub BtnProductos_Click(sender As Object, e As EventArgs)
        Dim frp As New FormProductos()
        frp.Show()
        Me.Hide()
    End Sub
    Private Sub btnVentas_Click(sender As Object, e As EventArgs)
        Dim frv As New FormVentas()
        frv.Show()
        Me.Hide()
    End Sub

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs)
        Dim frc As New FormClientes()
        frc.Show()
        Me.Hide()
    End Sub

    '---------------------------------------------------------------------------
    Private Sub EstiloBoton(btn As Button)
            btn.Width = 160
            btn.Height = 40
            btn.Left = 20
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.BackColor = Color.White
            btn.ForeColor = Color.SteelBlue
            btn.Font = New Font("Segoe UI", 11, FontStyle.Bold)

            ' Evento hover
            AddHandler btn.MouseEnter, Sub(sender, e) btn.BackColor = Color.LightGray
            AddHandler btn.MouseLeave, Sub(sender, e) btn.BackColor = Color.White
        End Sub


    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class
