Public Class frmSeePays
    Public vIdInternalLine As String = Nothing
    Private Sub frmSeePays_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCashbook

        receiptsHistory(dtgAccountReceipts, vIdInternalLine, 1)
    End Sub

    Private Sub dtgAccountReceipts_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountReceipts.CellContentClick
        If e.RowIndex <> -1 Then
            If dtgAccountReceipts.Columns(e.ColumnIndex).Name = "clmDetail" Then
                showPayDetail(dtgAccountReceipts.Item(0, e.RowIndex).Value, dtgAccountReceipts.Item(3, e.RowIndex).Value, dtgAccountReceipts.Item(6, e.RowIndex).Value, dtgAccountReceipts.Item(5, e.RowIndex).Value, dtgAccountReceipts.Item(7, e.RowIndex).Value)
                receiptsHistory(dtgAccountReceipts, vIdInternalLine, 1)
            End If
        End If
    End Sub
End Class