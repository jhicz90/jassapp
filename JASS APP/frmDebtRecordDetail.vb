Public Class frmDebtRecordDetail
    Public vIdAccountLine As String = Nothing
    Private Sub frmDebtRecordDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconDebtrecord

        getAccountCollectCharge(vIdAccountLine, dtgAccountMounth)
    End Sub

    Private Sub dtgAccountMounth_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountMounth.CellClick
        If e.RowIndex <> -1 Then
            txtService.Text = dtgAccountMounth.Item(6, e.RowIndex).Value
            txtAmount.Text = dtgAccountMounth.Item(7, e.RowIndex).Value
            txtPayed.Text = dtgAccountMounth.Item(8, e.RowIndex).Value
            txtDebt.Text = dtgAccountMounth.Item(9, e.RowIndex).Value
            txtState.Text = dtgAccountMounth.Item(10, e.RowIndex).Value
            nudAmountNew.Value = dtgAccountMounth.Item(7, e.RowIndex).Value
        End If
    End Sub

    Private Sub btnAddDebtDetail_Click(sender As Object, e As EventArgs) Handles btnAddDebtDetail.Click
        If dtgAccountMounth.Rows.Count > 0 Then
            If dtgAccountMounth.SelectedRows(0).Index <> -1 Then
                updDetail(dtgAccountMounth.Item(1, dtgAccountMounth.SelectedRows(0).Index).Value, dtgAccountMounth.Item(0, dtgAccountMounth.SelectedRows(0).Index).Value, nudAmountNew.Value)
                getAccountCollectCharge(vIdAccountLine, dtgAccountMounth)
            End If
        End If
    End Sub
End Class