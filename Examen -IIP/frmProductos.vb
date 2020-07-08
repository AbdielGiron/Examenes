Public Class frmProductos
    Dim conexion As conexion = New conexion()
    Private tablaProductos As New DataTable
    Private Sub limpiar()
        txtProducto.Clear()
        txtNombre.Clear()
        txtDescripcion.Clear()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If Me.ValidateChildren And txtProducto.Text <> String.Empty And txtNombre.Text <> String.Empty And txtDescripcion.Text <> String.Empty Then

                Dim codigoProducto As Integer
                Dim nombre, descripcion As String
                codigoProducto = txtProducto.Text
                nombre = txtNombre.Text
                descripcion = txtDescripcion.Text
                If conexion.AgregarProducto(codigoProducto, nombre, descripcion) Then
                    MsgBox("Producto ingresado correctamente")
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
            tablaProductos = conexion.consultarProductos()
            If tablaProductos.Rows.Count <> 0 Then
                dgvProductos.DataSource = tablaProductos
            Else
                dgvProductos.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try
            If Me.ValidateChildren And txtProducto.Text <> String.Empty And txtNombre.Text <> String.Empty And txtDescripcion.Text <> String.Empty Then
                Dim codigoProducto As Integer
                Dim nombre, descripcion As String
                codigoProducto = txtProducto.Text
                nombre = txtNombre.Text
                descripcion = txtDescripcion.Text

                If conexion.modificarProductos(codigoProducto, nombre, descripcion) Then
                    MsgBox("Producto Modificado correctamente")
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
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Me.ValidateChildren And txtProducto.Text <> String.Empty Then
                Dim codigoProducto As Integer
                codigoProducto = txtProducto.Text
                If conexion.EliminarProductos(codigoProducto) Then
                    MsgBox("Producto Eliminado Exitosamente")
                Else
                    MsgBox("No existe ese producto")
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
                txtProducto.Enabled = True
                txtNombre.Enabled = True
                txtDescripcion.Enabled = True
            Case 1
                btnAgregar.Enabled = False
                btnConsultar.Enabled = True
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtProducto.Enabled = False
                txtNombre.Enabled = False
                txtDescripcion.Enabled = False
            Case 2
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = True
                btnEliminar.Enabled = False
                txtProducto.Enabled = True
                txtNombre.Enabled = True
                txtDescripcion.Enabled = True
            Case 3
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = True
                txtProducto.Enabled = True
                txtNombre.Enabled = False
                txtDescripcion.Enabled = False
            Case Else
                MsgBox("ERROR")
        End Select
    End Sub

    Private Sub txtProducto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProducto.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtDescripcion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating, txtDescripcion.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub
End Class