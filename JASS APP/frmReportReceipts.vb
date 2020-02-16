Imports Microsoft.Reporting.WinForms
Public Class frmReportReceipts
    Private Sub frmReportReceipts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ds As dsReceipts = reportReceipts()
        Dim dtReport As New ReportDataSource("dsReceipts", ds.Tables(0))
        rptReceipts.LocalReport.DataSources.Clear()
        rptReceipts.LocalReport.DataSources.Add(dtReport)
        rptReceipts.RefreshReport()
    End Sub
End Class