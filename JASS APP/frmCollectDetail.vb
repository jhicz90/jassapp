Public Class frmCollectDetail
    Public vCodLine As String = Nothing
    Public vCodAccount As String = Nothing
    Public vNameLine As String = Nothing
    Private vDebitAmount As Double = 0
    Private Sub frmCollectDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        getAccountCollect(vCodLine, vCodAccount, dtgAccountYear)

        txtCodLine.Text = vCodLine
        txtCodAccount.Text = vCodAccount
        txtNameLine.Text = vNameLine

        txtDebitAccount.Text = vDebitAmount
        If vDebitAmount > 0 Then
            chkDebitUse.Enabled = True
        Else
            chkDebitUse.Enabled = False
        End If
    End Sub
End Class