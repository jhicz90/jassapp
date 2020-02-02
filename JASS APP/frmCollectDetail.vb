Public Class frmCollectDetail
    Dim dsUsersInAccount As DataSet = Nothing
    Public vIdServiceLine As String = Nothing
    Public vIdInternalLine As String = Nothing
    Public vNameLine As String = Nothing
    Public vDataReceipt(1) As String
    Private vDebitAmount, vDebtAmount As Decimal
    Private Sub frmCollectDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCollect

        dsUsersInAccount = listUsersInAccount(vIdInternalLine)

        If Not dsUsersInAccount.HasErrors Then
            cbxUsersInAccount.DataSource = dsUsersInAccount.Tables(0)
            cbxUsersInAccount.ValueMember = "iduser"
            cbxUsersInAccount.DisplayMember = "fullname"
        Else
            cbxUsersInAccount.Enabled = False
        End If

        If cbxUsersInAccount.Items.Count > 0 Then
            cbxUsersInAccount.Enabled = True
        Else
            cbxUsersInAccount.Enabled = False
        End If


        getAccountCollect(vIdServiceLine, vIdInternalLine, dtgAccountYear)
        Dim dataAccount() As String = getAccount(vIdServiceLine, vIdInternalLine)

        txtCodLine.Text = dataAccount(3)
        txtCodAccount.Text = dataAccount(2)
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
        If e.RowIndex <> -1 Then
            getAccountCollectCharge(dtgAccountYear.Item(0, e.RowIndex).Value, dtgAccountMounth)
            dtgAccountMounth.Focus()
            'If dtgAccountMounth.Rows.Count > 0 Then
            '    dtgAccountMounth.Item(5, dtgAccountMounth.Rows.GetFirstRow(0)).Selected = True
            'End If
        End If
    End Sub

    Private Sub dtgAccountMounth_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountMounth.CellContentClick
        If e.RowIndex <> -1 Then
            If dtgAccountMounth.Columns(e.ColumnIndex).Name = "clmOpcionMes" Then
                If dtgAccountMounth.Item(5, e.RowIndex).Value = False And dtgAccountMounth.Item(9, e.RowIndex).Value > 0 Then
                    dtgAccountMounth.Item(5, e.RowIndex).Value = True
                Else
                    dtgAccountMounth.Item(5, e.RowIndex).Value = False
                End If
                vDebtAmount = selectCharge(dtgAccountMounth)
                txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
            End If
        End If
    End Sub

    Private Sub dtgAccountMounth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgAccountMounth.KeyPress
        If e.KeyChar = ChrW(Keys.Space) And dtgAccountMounth.SelectedRows(0).Index <> -1 Then
            If dtgAccountMounth.Item(5, dtgAccountMounth.SelectedRows(0).Index).Value = False And dtgAccountMounth.Item(9, dtgAccountMounth.SelectedRows(0).Index).Value > 0 Then
                dtgAccountMounth.Item(5, dtgAccountMounth.SelectedRows(0).Index).Value = True
            Else
                dtgAccountMounth.Item(5, dtgAccountMounth.SelectedRows(0).Index).Value = False
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

    Private Sub btnSeePayments_Click(sender As Object, e As EventArgs) Handles btnSeePayments.Click
        showAccountReceipts(vIdInternalLine)
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If Val(txtMountPay.Text) > 0 And Val(txtSaldo.Text) > 0 Then
            Dim concepts(12) As String
            Dim data(7) As String

            data(0) = getLine(vIdServiceLine)(1)
            data(1) = vDataReceipt(1)
            data(2) = cbxUsersInAccount.Text
            data(3) = getUser(cbxUsersInAccount.SelectedValue)(5)
            data(4) = getLine(vIdServiceLine)(5)
            data(5) = Strings.Left(My.Settings.vUserNameLogin, 10)
            data(6) = Format(DateAndTime.Today, "dd/MM/yyyy") & " " & Format(DateAndTime.TimeOfDay, "hh:mm tt")
            data(7) = vDataReceipt(0)

            concepts = payAccount(dtgAccountMounth, Val(txtMountPay.Text), vIdInternalLine, data(7), data(1), data(2))

            getAccountCollect(vIdServiceLine, vIdInternalLine, dtgAccountYear)
            showPrintReceipt(data, concepts)
            cleanAll()
        End If
    End Sub
End Class