Public Class frmAccount
    Public vCodLine As String = Nothing
    Public vCodAccount As String = "new"
    Dim dsRates As DataSet = Nothing
    Private Sub frmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconEditpipe

        loadAccount(vCodLine, vCodAccount)
    End Sub

    Private Sub loadAccount(vCodLine As String, vCodAccount As String)
        dsRates = listRates()

        If Not dsRates.HasErrors Then
            cbxRates.DataSource = dsRates.Tables(0)
            cbxRates.ValueMember = "ID_RATE"
            cbxRates.DisplayMember = "NAME_RATE"
        End If

        If vCodAccount <> "new" Then
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
            tabDataAccount.Enabled = True
            tabDataAccount.Visible = True
            Text = "Cuenta de Servicio"
        Else
            txtCodAccount.Text = ""
            txtCodLine.Text = vCodLine
            txtDateCreated.Text = ""
            txtDateUpdated.Text = ""
            tabDataAccount.Enabled = False
            tabDataAccount.Visible = False
            Text = "Nueva Cuenta de Servicio"
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vCodAccount <> "new" Then
            'Update account
        Else
            vCodAccount = saveAccountNew(vCodLine, cbxRates.SelectedValue, Val(txtPriceRate.Text))
            loadAccount(vCodLine, vCodAccount)
        End If
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        showNewUser("new", vCodAccount, 3)
        listUserAccount(vCodLine, vCodAccount, dtgUsersAccount)
    End Sub
End Class