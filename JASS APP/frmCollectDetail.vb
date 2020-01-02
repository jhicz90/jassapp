Public Class frmCollectDetail
    Dim dsUsersInAccount As DataSet = Nothing
    Public vCodLine As String = Nothing
    Public vCodAccount As String = Nothing
    Public vNameLine As String = Nothing
    Public vDataReceipt(1) As String
    Private vDebitAmount, vDebtAmount As Decimal
    Private Sub frmCollectDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCollect

        dsUsersInAccount = listUsersInAccount(vCodAccount)

        If Not dsUsersInAccount.HasErrors Then
            cbxUsersInAccount.DataSource = dsUsersInAccount.Tables(0)
            cbxUsersInAccount.ValueMember = "iduser"
            cbxUsersInAccount.DisplayMember = "fullname"
        Else
            cbxUsersInAccount.Enabled = False
        End If

        getAccountCollect(vCodLine, vCodAccount, dtgAccountYear)

        txtCodLine.Text = vCodLine
        txtCodAccount.Text = vCodAccount
        txtNameLine.Text = vNameLine

        txtDebitAccount.Text = Format(vDebitAmount, "###,##0.00")
        If vDebitAmount > 0 Then
            chkDebitUse.Enabled = True
        Else
            chkDebitUse.Enabled = False
        End If

        CollectInit()

        vDataReceipt = lastCodReceipt()
        txtCodNumReceipt.Text = vDataReceipt(1)
    End Sub

    Private Sub CollectInit()
        dtgAccountYear.ClearSelection()
        dtgAccountMounth.ClearSelection()
    End Sub

    Private Sub cleanAll()
        vDebtAmount = selectCharge(dtgAccountMounth, True)
        txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
        txtMountPay.Text = Format(0, "###,##0.00")
        txtCash.Text = Format(0, "###,##0.00")
        txtChanging.Text = Format(0, "###,##0.00")
        vDataReceipt = lastCodReceipt()
        txtCodNumReceipt.Text = vDataReceipt(1)
    End Sub

    Private Sub dtgAccountYear_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountYear.CellClick
        getAccountCollectCharge(vCodAccount, dtgAccountMounth)
    End Sub

    Private Sub dtgAccountMounth_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountMounth.CellContentClick
        If dtgAccountMounth.Columns(e.ColumnIndex).Name = "clmOpcionMes" Then
            If dtgAccountMounth.Item(4, e.RowIndex).Value = False And dtgAccountMounth.Item(8, e.RowIndex).Value > 0 Then
                dtgAccountMounth.Item(4, e.RowIndex).Value = True
            Else
                dtgAccountMounth.Item(4, e.RowIndex).Value = False
            End If
            vDebtAmount = selectCharge(dtgAccountMounth)
            txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
        End If
    End Sub

    Private Sub dtgAccountMounth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgAccountMounth.KeyPress
        If e.KeyChar = ChrW(Keys.Space) Then
            If dtgAccountMounth.Item(4, dtgAccountMounth.CurrentRow.Index).Value = False And dtgAccountMounth.Item(8, dtgAccountMounth.CurrentRow.Index).Value > 0 Then
                dtgAccountMounth.Item(4, dtgAccountMounth.CurrentRow.Index).Value = True
            Else
                dtgAccountMounth.Item(4, dtgAccountMounth.CurrentRow.Index).Value = False
            End If
            vDebtAmount = selectCharge(dtgAccountMounth)
            txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
        ElseIf e.KeyChar = ChrW(Keys.Enter) Then
            txtMountPay.Focus()
        End If
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        cleanAll()
    End Sub

    Private Sub txtMountPay_LostFocus(sender As Object, e As EventArgs) Handles txtMountPay.LostFocus
        If txtMountPay.Text = "" Then
            txtMountPay.Text = "0"
        End If

        txtMountPay.Text = Format(CDec(txtMountPay.Text), "###,##0.00")
    End Sub

    Private Sub txtCash_LostFocus(sender As Object, e As EventArgs) Handles txtCash.LostFocus
        If txtCash.Text = "" Then
            txtCash.Text = "0"
        End If

        txtCash.Text = Format(CDec(txtCash.Text), "###,##0.00")

        If Val(txtCash.Text) > 0 Then
            txtChanging.Text = Format(CDec(txtCash.Text) - CDec(txtMountPay.Text), "###,##0.00")
        Else
            txtChanging.Text = Format(0, "###,##0.00")
        End If
    End Sub

    Private Sub txtMountPay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMountPay.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            txtCash.Focus()
        End If
    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If

        If e.KeyChar = ChrW(Keys.Enter) Then
            chkChangingUse.Focus()
        End If
    End Sub

    Private Sub chkChangingUse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles chkChangingUse.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnPay.Focus()
        End If
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If Val(txtMountPay.Text) > 0 And Val(txtSaldo.Text) > 0 Then
            Dim concepts(12) As String
            Dim data(6) As String

            data(0) = vCodLine
            data(1) = vDataReceipt(1)
            data(2) = cbxUsersInAccount.Text
            data(3) = getUser(cbxUsersInAccount.SelectedValue)(5)
            data(4) = getLine(vCodLine)(5)
            data(5) = Strings.Left(frmMain.userNameLogin, 10)
            data(6) = Date.Today
            concepts = payAccount(dtgAccountMounth, Val(txtMountPay.Text), vCodLine, vCodAccount)

            getAccountCollectCharge(vCodAccount, dtgAccountMounth)
            getAccountCollect(vCodLine, vCodAccount, dtgAccountYear)
            showPrintReceipt(data, concepts)
            cleanAll()
        End If
    End Sub
End Class