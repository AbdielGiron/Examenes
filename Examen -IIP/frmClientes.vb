Public Class frmClientes
    Dim conexion As conexion = New conexion()
    Private tablaclientes As New DataTable
    Private Sub limpiar()
        txtCliente.Clear()
        txtApellido.ResetText()
        txtNombre.Clear()
        txtDireccion.Clear()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If Me.ValidateChildren And txtCliente.Text <> String.Empty And txtNombre.Text <> String.Empty And txtApellido.Text <> String.Empty And txtDireccion.Text <> String.Empty Then

                Dim codigoCliente As Integer
                Dim nombre, apellido, direccion As String
                codigoCliente = txtCliente.Text
                nombre = txtNombre.Text
                apellido = txtApellido.Text
                direccion = txtDireccion.Text
                If conexion.AgregarCliente(codigoCliente, nombre, apellido, direccion) Then
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
            tablaclientes = conexion.consultarClientes()
            If tablaclientes.Rows.Count <> 0 Then
                dgvClientes.DataSource = tablaclientes
            Else
                dgvClientes.DataSource = Nothing
            End If
        Catch ex As Exception
            MsgBox("ERROR")
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Try
            If Me.ValidateChildren And txtCliente.Text <> String.Empty And txtNombre.Text <> String.Empty And txtApellido.Text <> String.Empty And txtDireccion.Text <> String.Empty Then
                Dim codigoCliente As Integer
                Dim nombre, apellido, direccion As String
                codigoCliente = txtCliente.Text
                nombre = txtNombre.Text
                apellido = txtApellido.Text
                direccion = txtDireccion.Text

                If conexion.modificarCliente(codigoCliente, nombre, apellido, direccion) Then
                    MsgBox("cliente Modificada correctamente")
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
            If Me.ValidateChildren And txtCliente.Text <> String.Empty Then
                Dim codigoCliente As Integer
                codigoCliente = txtCliente.Text
                If conexion.EliminarCliente(codigoCliente) Then
                    MsgBox("Cliente Eliminado Exitosamente")
                Else
                    MsgBox("No existe esa cliente")
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
                txtCliente.Enabled = True
                txtNombre.Enabled = True
                txtApellido.Enabled = True
                txtDireccion.Enabled = True
            Case 1
                btnAgregar.Enabled = False
                btnConsultar.Enabled = True
                btnModificar.Enabled = False
                btnEliminar.Enabled = False
                txtCliente.Enabled = False
                txtNombre.Enabled = False
                txtApellido.Enabled = False
                txtDireccion.Enabled = False
            Case 2
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = True
                btnEliminar.Enabled = False
                txtCliente.Enabled = True
                txtNombre.Enabled = True
                txtApellido.Enabled = True
                txtDireccion.Enabled = True
            Case 3
                btnAgregar.Enabled = False
                btnConsultar.Enabled = False
                btnModificar.Enabled = False
                btnEliminar.Enabled = True
                txtCliente.Enabled = True
                txtNombre.Enabled = False
                txtApellido.Enabled = False
                txtDireccion.Enabled = False
            Case Else
                MsgBox("ERROR")
        End Select
    End Sub

    Private Sub txtCliente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCliente.Validating
        If DirectCast(sender, MaskedTextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub

    Private Sub txtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNombre.Validating, txtDireccion.Validating, txtApellido.Validating
        If DirectCast(sender, TextBox).Text.Length > 0 Then
            Me.ErrorProvider.SetError(sender, "")
        Else
            Me.ErrorProvider.SetError(sender, "Es un campo obligatorio")
        End If
    End Sub
End Class