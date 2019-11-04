Imports System.ComponentModel

Public Class frmNewuser
    Public vFrmGet As Integer = 0
    Public vCodUser As String = Nothing
    Public vCodRate As Integer = 0
    Public vCodLine As String = Nothing
    Public vPriceRate As Double = 0
    Dim dsRates As DataSet = Nothing
    Dim dsUserTypes As DataSet = Nothing
    Dim dataUserEdited(13) As String
    Public Sub frmNewuser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconAdduser

        dsRates = listRates()

        If Not (dsRates.Equals(Nothing)) Then
            cbxRates.DataSource = dsRates.Tables(0)
            cbxRates.ValueMember = "ID_RATE"
            cbxRates.DisplayMember = "NAME_RATE"
        End If

        dsUserTypes = listUserTypes()

        If Not (dsUserTypes.Equals(Nothing)) Then
            cbxTypeUser.DataSource = dsUserTypes.Tables(0)
            cbxTypeUser.ValueMember = "ID_TYPE_USER"
            cbxTypeUser.DisplayMember = "NAME_TYPE"
        End If

        cbxTypeUser.SelectedIndex = 0
        cbxRates.SelectedIndex = 0

        If vFrmGet = 1 Then
            grpRate.Visible = False
        ElseIf vFrmGet = 2 Then
            grpRate.Visible = True
        ElseIf vFrmGet = 3 Then
            grpRate.Visible = True
        Else
            grpRate.Visible = False
        End If

        If IsNothing(vCodUser) Then
            Close()
        ElseIf vCodUser = "new" Then
            newLine()
        Else
            Dim dataUser() As String = getUser(vCodUser, vCodRate)

            If vCodUser.Length = 0 Then
                Close()
            ElseIf Not IsNothing(dataUser) And vCodUser.Length > 0 Then
                txtCodUser.Text = dataUser(0)
                txtNames.Text = dataUser(1)
                txtSurnames.Text = dataUser(2)
                cbxTypeUser.SelectedValue = dataUser(3)
                txtDocID.Text = dataUser(5)
                txtAddress.Text = dataUser(6)

                If vCodRate = 0 Then
                    chkTitular.Checked = False
                Else
                    chkTitular.Checked = dataUser(12)
                End If

                txtCellphone.Text = dataUser(7)
                txtTelephone.Text = dataUser(8)

                If vCodRate = 0 Then
                    cbxRates.SelectedIndex = 0
                Else
                    cbxRates.SelectedValue = dataUser(11)
                    If dataUser(14) = True Then
                        txtPriceRate.Text = dataUser(15)
                        vPriceRate = Convert.ToDouble(dataUser(15))
                        txtPriceRate.ReadOnly = False
                    End If
                End If

                txtDateCreated.Text = Format(dataUser(9), "Short Date")
                txtDateUpdated.Text = Format(dataUser(10), "Short Date")

                txtNames.Focus()
            End If
        End If
    End Sub

    Public Sub newLine()
        txtCodUser.Text = ""
        txtNames.Text = ""
        txtSurnames.Text = ""
        cbxTypeUser.SelectedIndex = 0
        cbxRates.SelectedIndex = 0
        txtDocID.Text = ""
        cbxTypeUser.SelectedIndex = 0
        txtAddress.Text = ""
        chkTitular.Checked = False
        txtTelephone.Text = ""
        txtCellphone.Text = ""
        txtDateCreated.Text = Format(Today, "Short Date")
        txtDateUpdated.Text = Format(Today, "Short Date")
        grpUser.Focus()
    End Sub

    Private Sub cbxRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedIndexChanged
        If IsNumeric(cbxRates.SelectedValue.ToString) Then
            Dim dataPrice() As String = getPriceRate(cbxRates.SelectedValue.ToString)
            txtPriceRate.Text = Math.Round(Convert.ToDouble(dataPrice(0)), 2).ToString
            If Convert.ToBoolean(dataPrice(2)) = True Then
                txtPriceRate.ReadOnly = False
                If vPriceRate > 0 Then
                    txtPriceRate.Text = vPriceRate
                Else
                    txtPriceRate.Text = 0
                End If
            Else
                txtPriceRate.ReadOnly = True
            End If
        End If
    End Sub
    Private Sub cbxRates_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedValueChanged
        cbxRates_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub cbxTypeUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTypeUser.SelectedIndexChanged
        If IsNumeric(cbxTypeUser.SelectedValue.ToString) Then
            If (cbxTypeUser.SelectedValue > 1) Then
                lblNameSocial.Text = "Razon:"
                lblDoc.Text = "RUC:"
                txtSurnames.Text = ""
                lblSurNames.Visible = False
                txtSurnames.Visible = False
                lblSurNames.Enabled = False
                txtSurnames.Enabled = False
            Else
                lblNameSocial.Text = "Nombres:"
                lblDoc.Text = "DNI:"
                lblSurNames.Visible = True
                txtSurnames.Visible = True
                lblSurNames.Enabled = True
                txtSurnames.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        dataUserEdited(0) = txtCodUser.Text
        dataUserEdited(1) = txtNames.Text
        dataUserEdited(2) = txtSurnames.Text
        dataUserEdited(3) = cbxTypeUser.SelectedValue
        dataUserEdited(4) = txtDocID.Text
        dataUserEdited(5) = txtAddress.Text
        dataUserEdited(6) = txtCellphone.Text
        dataUserEdited(7) = txtTelephone.Text
        dataUserEdited(8) = Format(txtDateCreated.Text, "Short Date")
        dataUserEdited(9) = Format(Today, "Short Date")
        dataUserEdited(10) = cbxRates.SelectedValue 'Codigo de la tarifa
        dataUserEdited(11) = txtPriceRate.Text
        dataUserEdited(12) = vCodLine 'Codigo de la linea si es necesario
        dataUserEdited(13) = chkTitular.Checked

        If vFrmGet = 1 Then
            saveUserNew(dataUserEdited)
            newLine()
        ElseIf vFrmGet = 2 Then
            updateUser(dataUserEdited)
        ElseIf vFrmGet = 3 Then
            saveUserNew(dataUserEdited, True)
            newLine()
        End If

        Close()
    End Sub

    Private Sub frmNewuser_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub
End Class