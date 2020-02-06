Public Class frmDeclarationServices
    Private Sub frmDeclarationServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconDeclareservice
        MdiParent = frmMain
    End Sub

    Private Sub chkOrder_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrder.CheckedChanged
        cbxCrit.Enabled = chkOrder.Checked
    End Sub
End Class