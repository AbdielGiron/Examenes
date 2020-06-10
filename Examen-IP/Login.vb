Public Class Login
    Dim usuario, contraseña As String

    Private Sub CrearUsuario_Click(sender As Object, e As EventArgs) Handles LabelCrearUsuario.Click
        Try
            usuario = InputBox("Ingrese el Nombre de Usuario", "Creacion de Usuario", MessageBoxIcon.Information)
            contraseña = InputBox("Ingrese la contraseña  de Usuario", "Creacion de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click

        Try
            If Me.ValidateChildren And txtUsuario.Text = "" And txtContraseña.Text = "" Then
                If txtUsuario.Text = "" And txtContraseña.Text = "" Then
                    MessageBox.Show("ERROR AL INGRESAR LOS DATOS", "INGRESO DEL PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else

                    If (txtUsuario.Text = "Administrador" Or txtUsuario.Text = "administrador") And txtContraseña.Text = "SinHacer2020" Then
                        Me.Hide()
                        Menu_Principal.Show()
                    Else
                        MsgBox("El Usuaio Ingresado no existe", "iniciar Sesion ", MessageBoxButtons.OK)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
