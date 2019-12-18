Public Class frmCollectDetail
    Public vCodLine As String = Nothing
    Public vCodAccount As String = Nothing
    Public vNameLine As String = Nothing
    Private vDebitAmount, vDebtAmount As Decimal
    Private Sub frmCollectDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCollect

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
    End Sub

    Private Sub CollectInit()
        dtgAccountYear.ClearSelection()
        dtgAccountMounth.ClearSelection()
    End Sub

    Private Sub dtgAccountYear_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountYear.CellContentClick

    End Sub

    Private Sub dtgAccountYear_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountYear.CellClick
        getAccountCollectCharge(vCodAccount, dtgAccountMounth)
    End Sub

    Private Sub dtgAccountMounth_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountMounth.CellContentClick
        If dtgAccountMounth.Columns(e.ColumnIndex).Name = "clmOpcionMes" Then
            If dtgAccountMounth.Item(e.ColumnIndex, e.RowIndex).Value = True Then
                dtgAccountMounth.Item(e.ColumnIndex, e.RowIndex).Value = False
            Else
                dtgAccountMounth.Item(e.ColumnIndex, e.RowIndex).Value = True
            End If
            vDebtAmount = selectCharge(dtgAccountMounth)
            txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
        End If
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        vDebtAmount = selectCharge(dtgAccountMounth, True)
        txtSaldo.Text = Format(vDebtAmount, "###,##0.00")
        txtMountPay.Text = Format(0, "###,##0.00")
        txtCash.Text = Format(0, "###,##0.00")
        txtChanging.Text = Format(0, "###,##0.00")
    End Sub

    Private Sub txtMountPay_LostFocus(sender As Object, e As EventArgs) Handles txtMountPay.LostFocus
        txtMountPay.Text = Format(CDec(txtMountPay.Text), "###,##0.00")
    End Sub

    Private Sub txtCash_LostFocus(sender As Object, e As EventArgs) Handles txtCash.LostFocus
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
    End Sub

    Private Sub txtCash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCash.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
End Class