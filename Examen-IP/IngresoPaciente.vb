Public Class IngresoPaciente

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim ID, total As Integer
        total = Val(txtTotal.Text)
        Dim Atlántida, Choluteca, Colón, Comayagua, Copán, Cortés, ElParaísoFrancisco, Morazán, GraciasaDios, Intibucá, IslasdelaBahía, LaPaz, Lempira, Ocotepeque, Olancho, SantaBárbara, Valle, Yoro As Integer

        Try
            If Me.ValidateChildren And txtNombre.Text <> String.Empty And cmbDepartamento.Text <> String.Empty And txtMunicipio.Text <> String.Empty And (chkPositivo.Checked = True Or chkNegativo.Checked = True) And (CheckBox1.Checked = True Or CheckBox2.Checked = True Or CheckBox3.Checked = True Or CheckBox4.Checked = True Or CheckBox5.Checked = True Or CheckBox6.Checked = True) Then
                ID += total + 1
                If chkPositivo.Checked = True Then

                    listBoxID.Items.Add(ID)
                    ListBoxNombre.Items.Add(txtNombre.Text)
                    ListBoxEdad.Items.Add(txtEdad.Text)
                    ListBoxMunicipio.Items.Add(txtMunicipio.Text)
                    ListBoxDepartamento.Items.Add(cmbDepartamento.SelectedItem.ToString)
                    ListBoxResultado.Items.Add("Positivo")
                Else
                    listBoxID.Items.Add(ID)
                    ListBoxNombre.Items.Add(txtNombre.Text)
                    ListBoxEdad.Items.Add(txtEdad.Text)
                    ListBoxMunicipio.Items.Add(txtMunicipio.Text)
                    ListBoxDepartamento.Items.Add(cmbDepartamento.SelectedItem.ToString)
                    ListBoxResultado.Items.Add("Negativo")
                End If

                If CheckBox1.Checked = True Then
                    ListBoxEstado.Items.Add("Recuperado")
                End If
                If CheckBox2.Checked = True Then
                    ListBoxEstado.Items.Add("Asintomatico")
                End If
                If CheckBox3.Checked = True Then
                    ListBoxEstado.Items.Add("Hospitalizado")
                End If
                If CheckBox4.Checked = True Then
                    ListBoxEstado.Items.Add("Muerto")
                End If
                If CheckBox5.Checked = True Then
                    ListBoxEstado.Items.Add("Estable")
                End If
                If CheckBox6.Checked = True Then
                    ListBoxEstado.Items.Add("UCI")
                End If


                Select Case cmbDepartamento.SelectedIndex
                    Case 1
                        Atlántida += 1
                    Case 2
                        Choluteca += 1
                    Case 3
                        Colón
                    Case 4
                        Comayagua
                    Case 5
                        Copán
                    Case 6
                        Cortés
                    Case 7
                        ElParaísoFrancisco
                    Case 8
                        Morazán
                    Case 9
                        GraciasaDios
                    Case 10
                        Intibucá
                    Case 11
                        IslasdelaBahí
                    Case 12
                    Case 13
                    Case 14
                    Case 15
                    Case 16
                    Case 17
                    Case 18



                End Select


                MessageBox.Show("Se ha registrado Exitosamente", "INGRESO DEL PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNombre.Clear()
                txtEdad.Clear()
                cmbDepartamento.SelectedIndex = False
                txtMunicipio.Clear()
                cmbDepartamento.Text = ""
                chkPositivo.Checked = False
                chkNegativo.Checked = False
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False
                CheckBox4.Checked = False
                CheckBox5.Checked = False
                CheckBox6.Checked = False


            Else
                MessageBox.Show("ERROR AL INGRESAR LOS DATOS", "INGRESO DEL PACIENTE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        txtTotal.Text = ID
    End Sub

    Private Sub chkPositivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPositivo.CheckedChanged
        If chkPositivo.Checked = True Then
            chkNegativo.Enabled = False
            CheckBox3.Checked = True
            CheckBox4.Checked = True
            CheckBox5.Checked = True
            CheckBox6.Checked = True

        Else
            chkNegativo.Enabled = True
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
        End If
    End Sub

    Private Sub chkNegativo_CheckedChanged(sender As Object, e As EventArgs) Handles chkNegativo.CheckedChanged
        If chkNegativo.Checked = True Then
            chkPositivo.Enabled = False
            CheckBox1.Checked = False
            CheckBox2.Checked = False
        Else
            chkPositivo.Enabled = True
            CheckBox1.Checked = True
            CheckBox2.Checked = True
        End If
    End Sub

End Class