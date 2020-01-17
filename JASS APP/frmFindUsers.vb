Imports System.ComponentModel

Public Class frmFindUsers
    Public vFrmGet As Integer = 0
    Dim dsRates As DataSet = Nothing
    Private Sub frmFindUsers_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconSearch

        txtFind.Text = ""
        txtFind.Focus()

        dsRates = listRates()

        If Not dsRates.HasErrors Then
            cbxRates.DataSource = dsRates.Tables(0)
            cbxRates.ValueMember = "ID_RATE"
            cbxRates.DisplayMember = "NAME_RATE"
        End If

        'vFrmGet: Cuando es 1 es para buscar sin ingresar tarifa, cuando es 2 es para buscar e ingresar tarifa
        Select Case vFrmGet
            Case 1
                lblRates.Visible = False
                cbxRates.Visible = False
                txtPriceRate.Visible = False
                lblRatePrice.Visible = False
            Case 2
                lblRates.Visible = True
                cbxRates.Visible = True
                txtPriceRate.Visible = True
                lblRatePrice.Visible = True
            Case Else
                lblRates.Visible = False
                cbxRates.Visible = False
                txtPriceRate.Visible = False
                lblRatePrice.Visible = False
        End Select

        newFind()
    End Sub

    Public Sub newFind()
        txtFind.Text = ""
        cbxCrit.SelectedIndex = 0
        cbxRates.SelectedIndex = 0
    End Sub
    Private Sub cbxRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedIndexChanged
        If IsNumeric(cbxRates.SelectedValue.ToString) Then
            Dim dataPrice() As String = getPriceRate(cbxRates.SelectedValue.ToString)
            txtPriceRate.Text = Math.Round(Convert.ToDouble(dataPrice(0)), 2).ToString
            If Convert.ToBoolean(dataPrice(2)) = True Then
                txtPriceRate.ReadOnly = False
                txtPriceRate.Text = 0
            Else
                txtPriceRate.ReadOnly = True
            End If
        End If
    End Sub
    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        If Trim(txtFind.Text) <> "" And Trim(txtFind.Text).Length > 2 Then
            listUsers(txtFind.Text, cbxCrit.SelectedIndex, dtgUsers)
        Else
            dtgUsers.Rows.Clear()
        End If
    End Sub

    Private Sub cbxCrit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCrit.SelectedIndexChanged
        If Trim(txtFind.Text) <> "" And Trim(txtFind.Text).Length > 2 Then
            listUsers(txtFind.Text, cbxCrit.SelectedIndex, dtgUsers)
        Else
            dtgUsers.Rows.Clear()
        End If
    End Sub

    Private Sub dtgUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgUsers.CellContentClick
        If dtgUsers.Columns(e.ColumnIndex).Name = "clmOptions" Then
            Dim dataUser(7) As String
            dataUser(0) = dtgUsers.Item(0, e.RowIndex).Value 'Codigo
            dataUser(1) = dtgUsers.Item(2, e.RowIndex).Value 'Doc
            dataUser(2) = dtgUsers.Item(3, e.RowIndex).Value 'Nombres
            dataUser(3) = dtgUsers.Item(4, e.RowIndex).Value 'Apellidos
            dataUser(4) = dtgUsers.Item(5, e.RowIndex).Value 'Tipo usuario
            dataUser(5) = dtgUsers.Item(6, e.RowIndex).Value 'Direccion
            dataUser(6) = dtgUsers.Item(7, e.RowIndex).Value 'Celular
            dataUser(7) = dtgUsers.Item(8, e.RowIndex).Value 'Telefono

            Select Case vFrmGet
                Case 1
                    frmNewline.userFound(True, dataUser)
                Case 2
                    frmEditLine.userFound(True, dataUser, cbxRates.SelectedValue, Convert.ToDouble(txtPriceRate.Text))
                Case Else
                    Close()
            End Select
            Close()
        End If
    End Sub
    Private Sub frmFindUsers_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub

    Private Sub txtFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And dtgUsers.Rows.Count > 0 Then
            Dim dataUser(7) As String
            dataUser(0) = dtgUsers.Item(0, 0).Value 'Codigo
            dataUser(1) = dtgUsers.Item(2, 0).Value 'Doc
            dataUser(2) = dtgUsers.Item(3, 0).Value 'Nombres
            dataUser(3) = dtgUsers.Item(4, 0).Value 'Apellidos
            dataUser(4) = dtgUsers.Item(5, 0).Value 'Tipo usuario
            dataUser(5) = dtgUsers.Item(6, 0).Value 'Direccion
            dataUser(6) = dtgUsers.Item(7, 0).Value 'Celular
            dataUser(7) = dtgUsers.Item(8, 0).Value 'Telefono

            Select Case vFrmGet
                Case 1
                    frmNewline.userFound(True, dataUser)
                Case 2
                    frmEditLine.userFound(True, dataUser, cbxRates.SelectedValue, Convert.ToDouble(txtPriceRate.Text))
                Case Else
                    Close()
            End Select
            Close()
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            Close()
        End If
    End Sub
End Class