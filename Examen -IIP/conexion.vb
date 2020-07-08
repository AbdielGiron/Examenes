Imports System.Data.SqlClient
Public Class conexion

    Public conexion As SqlConnection = New SqlConnection("Data Source=DESKTOP-TSL1SID;Initial Catalog=TiendaMessi;Integrated Security=True")

    Public Sub abrirConexion()
        Try
            conexion.Open()
        Catch ex As Exception
            MessageBox.Show("No se pudo Conectar: " + ex.ToString)
            End
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Function consultarVentas()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("consultarTablaVentas", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim tablaVentas As New DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(tablaVentas)
                Return tablaVentas
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        Finally
            conexion.Close()

        End Try
    End Function
    Public Function consultarClientes()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("consultarTablaClientes", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim tablaClientes As New DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(tablaClientes)
                Return tablaClientes
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        Finally
            conexion.Close()

        End Try
    End Function
    Public Function consultarProductos()
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("consultarTablaProductos", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            If cmd.ExecuteNonQuery Then
                Dim tablaProductos As New DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(tablaProductos)
                Return tablaProductos
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        Finally
            conexion.Close()

        End Try
    End Function
    Public Function consultarVentasIndividual(codigoVenta As Integer)

        Try
            conexion.Open()
            Dim cmd As New SqlCommand("consultarVentaIndividual", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idventa", codigoVenta)
            If cmd.ExecuteNonQuery = False Then
                Dim tablaVentas As New DataTable
                Dim adaptador As New SqlDataAdapter(cmd)
                adaptador.Fill(tablaVentas)
                Return tablaVentas
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.Message)

        Finally
            conexion.Close()

        End Try
    End Function

    Public Function AgregarVenta(Venta As Integer, fechaVenta As String, precio As Integer, cantidad As Integer, Cliente As Integer, Producto As Integer) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ingresarVenta", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idventa ", Venta)
            cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta)
            cmd.Parameters.AddWithValue("@precio", precio)
            cmd.Parameters.AddWithValue("@cantidad", cantidad)
            cmd.Parameters.AddWithValue("@idCliente", Cliente)
            cmd.Parameters.AddWithValue("@idProducto", Producto)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function AgregarCliente(codigoCliente As Integer, nombre As String, apellido As String, direccion As String) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ingresarClientes", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idCliente ", codigoCliente)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@direccion", direccion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function AgregarProducto(codigoProducto As Integer, nombre As String, descripcion As String) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("ingresarProducto", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idProducto", codigoProducto)
            cmd.Parameters.AddWithValue("@nombreProducto", nombre)
            cmd.Parameters.AddWithValue("@descripcion", descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function modificarCliente(codigoCliente As Integer, nombre As String, apellido As String, direccion As String) As Boolean

        Try
            conexion.Open()
            Dim cmd As New SqlCommand("actualizarTablaClientes", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idCliente", codigoCliente)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@apellido", apellido)
            cmd.Parameters.AddWithValue("@direccion", direccion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function modificarProductos(codigoProducto As Integer, nombre As String, descripcion As String) As Boolean

        Try
            conexion.Open()
            Dim cmd As New SqlCommand("actualizarProducto", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idProducto", codigoProducto)
            cmd.Parameters.AddWithValue("@nombreProducto", nombre)
            cmd.Parameters.AddWithValue("@descripcion", descripcion)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

    Public Function modificarVenta(venta As Integer, precio As Integer, cantidad As Integer, producto As Integer) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("actualizarTablaVentas", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idventa", venta)
            cmd.Parameters.AddWithValue("@precio", precio)
            cmd.Parameters.AddWithValue("@cantidad", cantidad)
            cmd.Parameters.AddWithValue("@idProducto", producto)

            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function

    Public Function EliminarVenta(codigoVenta As String) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("eliminarVenta", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("idventa", codigoVenta)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function EliminarCliente(codigoCliente As String) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("eliminarCliente", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("idCliente", codigoCliente)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function
    Public Function EliminarProductos(codigoProducto As String) As Boolean
        Try
            conexion.Open()
            Dim cmd As New SqlCommand("eliminarProducto", conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("idProducto", codigoProducto)
            If cmd.ExecuteNonQuery Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            conexion.Close()

        End Try

    End Function


End Class
