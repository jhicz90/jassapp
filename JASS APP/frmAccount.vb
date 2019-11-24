Public Class frmAccount
    Public vCodLine As String = Nothing
    Public vCodAccount As String = "new"
    Dim dsRates As DataSet = Nothing
    Private Sub frmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconEditpipe

        dsRates = listRates()

        If Not dsRates.HasErrors Then
            cbxRates.DataSource = dsRates.Tables(0)
            cbxRates.ValueMember = "ID_RATE"
            cbxRates.DisplayMember = "NAME_RATE"
        End If

        If vCodLine.Equals(Nothing) Or vCodAccount.Equals(Nothing) Then
            MsgBox("Faltan datos de la cuenta", vbCritical, "Aviso")
            Close()
        Else
            Dim dataAccount() As String = getAccount(vCodLine, vCodAccount)

            If IsNothing(dataAccount) Then
                Close()
            Else
                txtCodAccount.Text = dataAccount(0)
                txtCodLine.Text = dataAccount(1)
                cbxRates.SelectedValue = dataAccount(2)
                txtPriceRate.Text = dataAccount(3)
                txtDateCreated.Text = Format(dataAccount(4), "Short Date")
                txtDateUpdated.Text = Format(dataAccount(5), "Short Date")

                listUserAccount(dataAccount(1), dataAccount(0), dtgUsersAccount)
            End If
        End If
    End Sub

    Private Sub cbxRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedIndexChanged
        If IsNumeric(cbxRates.SelectedValue.ToString) Then
            Dim dataPrice() As String = getPriceRate(cbxRates.SelectedValue.ToString)
            txtPriceRate.Text = Math.Round(Convert.ToDouble(dataPrice(0)), 2).ToString
            txtDescRate.Text = dataPrice(1)
            If Convert.ToBoolean(dataPrice(2)) = True Then
                txtPriceRate.ReadOnly = False
                txtPriceRate.Text = 0
            Else
                txtPriceRate.ReadOnly = True
            End If
        End If
    End Sub
End Class