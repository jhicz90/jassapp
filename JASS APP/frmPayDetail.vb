Public Class frmPayDetail
    Public vIdPayment As String = Nothing
    Public vNumReceipt As String = Nothing
    Public vCollector As String = Nothing
    Public vPayer As String = Nothing
    Public vDatePay As Date = Nothing

    Private Sub frmPayDetail_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconCashbook

        txtNumReceipt.Text = "RECIBO: N°" & vNumReceipt
        txtCollector.Text = "COBRADOR: " & vCollector
        txtPayer.Text = "PAGADOR: " & vPayer
        receiptDetail(dtgDetail, vIdPayment)
    End Sub

    Private Sub btnCanceled_Click(sender As Object, e As EventArgs) Handles btnCanceled.Click
        If cancelReceipt(dtgDetail, vIdPayment, vNumReceipt, vDatePay) Then
            Close()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        printReceiptCopy(vIdPayment, dtgDetail)
    End Sub
End Class