Public Class frmSeePays
    Public vCodAccount As String = Nothing
    Private Sub frmSeePays_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCashbook

        receiptsHistory(dtgAccountReceipts, vCodAccount, 1)
    End Sub
End Class