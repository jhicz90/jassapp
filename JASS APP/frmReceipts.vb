Public Class frmReceipts
    Private Sub frmReceipts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconReceipts

        nudReceipt.Value = lastCodReceipt(0)
    End Sub

    Private Sub nudReceipt_ValueChanged(sender As Object, e As EventArgs) Handles nudReceipt.ValueChanged
        txtNumReceipt.Text = nudReceipt.Value.ToString.PadLeft(7, "0")
    End Sub
End Class