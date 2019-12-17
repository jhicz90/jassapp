Public Class frmCollectDetail
    Public vCodLine As String = Nothing
    Public vCodAccount As String = Nothing
    Public vNameLine As String = Nothing
    Private vDebitAmount As Decimal = 0
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
End Class