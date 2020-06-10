Public Class Menu_Principal
    Private Sub abrirformEnPanel(Of Miform As {Form, New})()
        Dim formulario As Form
        formulario = PanelFormularios.Controls.OfType(Of Miform)().FirstOrDefault()
        If formulario Is Nothing Then
            formulario = New Miform()
            formulario.TopLevel = False
            formulario.FormBorderStyle = BorderStyle.None
            formulario.Dock = DockStyle.Fill
            PanelFormularios.Controls.Add(formulario)
            PanelFormularios.Tag = formulario
            formulario.Show()
            formulario.BringToFront()

        Else
            formulario.BringToFront()
        End If
    End Sub

    Private Sub btnIngresarPaciente_Click(sender As Object, e As EventArgs) Handles btnIngresarPaciente.Click
        abrirformEnPanel(Of IngresoPaciente)()
        btnIngresarPaciente.BackColor = Color.FromArgb(12, 61, 92)
    End Sub

    Private Sub btnRegistros_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

    End Sub
End Class