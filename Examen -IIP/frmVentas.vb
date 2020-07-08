Public Class frmVentas

    Dim conexion As conexion = New conexion()
    Private tablaVentas As New DataTable
    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.abrirConexion()
    End Sub
    Private Sub limpiar()
        txtVenta.Clear()
        txtfecha.ResetText()
        txtPrecio.Clear()
        txtCantidad.Clear()
        txtCliente.Clear()
        txtProducto.Clear()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click


        Try
            If Me.ValidateChildren And txtVenta.Text <> String.Empty And txtPrecio.Text <> String.Empty And txtCantidad.Text <> String.Empty And txtCliente.Text <> String.Empty And txtProducto.Text <> String.Empty Then

                Dim Venta, precio, cantidad, Cliente, Producto As Integer
                Dim fechaVenta As String
                Venta = txtVenta.Text
                fechaVenta = txtfecha.Value.ToString
                precio = txtPrecio.Text
                cantidad = txtCantidad.Text
                Cliente = txtCliente.Text
                Producto = txtProducto.Text
                If conexion.AgregarVenta(Venta, fechaVenta, precio, cantidad, Cliente, Producto) Then
                    MsgBox("Ingresado correctamente")
                Else
                    MsgBox("ERROR")
                End If
            Else
                MsgBox("Es necesario llenar todos los campos")
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
        limpiar()
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Try
            tablaVentas = conexion.consultarVentas()
            If tablaVentas.Rows.Count <> 0 Then
                dgvVentas.DataSource = tablaVentas
            Else
                dgvVentas.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Me.ValidateChildren And txtVenta.Text <> String.Empty Then
                Dim codigoVenta As Integer
                codigoVenta = txtVenta.Text
                If conexion.EliminarVenta(codigoVenta) Then
                    MsgBox("Venta Eliminada Exitosamente")
                Else
                    MsgBox("No existe esa venta")
                End If
            Else
                MsgBox("Es necesario llenar todos los campos")
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try

        limpiar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try
            If Me.ValidateChildren And txtVenta.Text <> String.Empty And txtPrecio.Text <> String.Empty And txtCantidad.Text <> String.Empty And txtProducto.Text <> String.Empty Then
                Dim venta, precio, cantidad, producto As Integer
                venta = txtVenta.Text
                precio = txtPrecio.Text
                cantidad = txtCantidad.Text
                producto = txtProducto.Text
                If conexion.modificarVenta(venta, precio, cantidad, producto) Then
                    MsgBox("Venta Modificada correctamente")
                Else
                    MsgBox("ERROR")
                End If
            Else
                MsgBox("Es necesario llenar todos los campos")
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
        limpiar()
    End Sub

    Private Sub cmbOpciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOpciones.SelectedIndexChanged

        Select Case cmbOpciones.SelectedIndex
            Case 0
                btnAgregar.Enabled = True
                btnConsultar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtVenta.Enabled = True
                txtfecha.Enabled = True
                txtPrecio.Enabled = True
                txtCantidad.Enabled = True
                txtCliente.Enabled = True
                txtProducto.Enabled = True

            Case 1
                btnAgregar.Enabled = False
                btnConsultar.Enabled = True
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtVenta.Enabled = False
                txtfecha.Enabled = False
                txtPrecio.Enabled = False
                txtCantidad.Enabled = False
                txtCliente.Enabled = False
                txtProducto.Enabled = False
            Case 2
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = True
                btnEliminar.Enabled = False
                txtVenta.Enabled = True
                txtfecha.Enabled = False
                txtPrecio.Enabled = True
                txtCantidad.Enabled = True
                txtCliente.Enabled = False
                txtProducto.Enabled = True
            Case 3
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = True
                txtVenta.Enabled = True
                txtfecha.Enabled = False
                txtPrecio.Enabled = False
                txtCantidad.Enabled = False
                txtCliente.Enabled = False
                txtProducto.Enabled = False
            Case Else
                MsgBox("ERROR")
        End Select
    End Sub

    Private Sub txtPrecio_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVenta.Validating, txtPrecio.Validating, txtCantidad.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProducto.Validating, txtCliente.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub cmbOpciones_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbOpciones.Validating
        If DirectCast(sender, ComboBox).Text <> " " Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If

    End Sub
End Class