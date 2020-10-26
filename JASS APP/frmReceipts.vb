Public Class frmReceipts
    Private Sub frmReceipts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconReceipts

        nudReceipt.Value = lastCodReceipt(0)
        cbxSeeNumReceipts.SelectedIndex = My.Settings.vSeeNumReceipts

        listLastReceipts(dtgReceipts, nudReceipt.Value, cbxSeeNumReceipts.SelectedItem)
    End Sub

    Private Sub nudReceipt_ValueChanged(sender As Object, e As EventArgs) Handles nudReceipt.ValueChanged
        txtNumReceipt.Text = nudReceipt.Value.ToString.PadLeft(7, "0")
        listLastReceipts(dtgReceipts, nudReceipt.Value, cbxSeeNumReceipts.SelectedItem)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub dtgReceipts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgReceipts.CellContentClick
        If e.RowIndex <> -1 Then
            If dtgReceipts.Columns(e.ColumnIndex).Name = "clmDetail" And dtgReceipts.Item(1, e.RowIndex).Value <> 0 Then
                showPayDetail(dtgReceipts.Item(0, e.RowIndex).Value, dtgReceipts.Item(3, e.RowIndex).Value, dtgReceipts.Item(7, e.RowIndex).Value, dtgReceipts.Item(6, e.RowIndex).Value, dtgReceipts.Item(8, e.RowIndex).Value)
                listLastReceipts(dtgReceipts, nudReceipt.Value, cbxSeeNumReceipts.SelectedItem)
            End If
        End If
    End Sub

    Private Sub cbxSeeNumReceipts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSeeNumReceipts.SelectedIndexChanged
        My.Settings.vSeeNumReceipts = cbxSeeNumReceipts.SelectedIndex
        listLastReceipts(dtgReceipts, nudReceipt.Value, cbxSeeNumReceipts.SelectedItem)
    End Sub

    Private Sub btnCancelReceipt_Click(sender As Object, e As EventArgs) Handles btnCancelReceipt.Click
        registerCancelReceipt(nudReceipt.Value)
        nudReceipt.Value = lastCodReceipt(0)
        listLastReceipts(dtgReceipts, nudReceipt.Value, cbxSeeNumReceipts.SelectedItem)
    End Sub
End Class