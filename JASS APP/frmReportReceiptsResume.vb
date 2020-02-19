Imports Microsoft.Reporting.WinForms
Public Class frmReportReceiptsResume
    Private Sub frmReportReceiptsResume_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconAttendance

        listUserSys(cbxUsersSys)
        listYearRate(cbxYearRate)
        listAvenues(cbxStreets)
        initReport()

        Dim dataReport(8) As String
        dataReport(0) = chkDateRange.Checked
        dataReport(1) = dtpSince.Value
        dataReport(2) = dtpTo.Value
        dataReport(3) = chkCollectUserSys.Checked
        dataReport(4) = cbxUsersSys.SelectedValue
        dataReport(5) = chkYearRate.Checked
        dataReport(6) = cbxYearRate.SelectedValue
        dataReport(7) = chkStreet.Checked
        dataReport(8) = cbxStreets.SelectedValue

        Dim ds As dsReceipts = reportReceiptsResume(dataReport)
        Dim dtReport As New ReportDataSource("dsReceipts", ds.Tables(1))
        rptReceipts.LocalReport.DataSources.Clear()
        rptReceipts.LocalReport.DataSources.Add(dtReport)
        rptReceipts.SetDisplayMode(DisplayMode.PrintLayout)
        rptReceipts.ZoomMode = ZoomMode.FullPage
        rptReceipts.RefreshReport()
    End Sub

    Public Sub initReport()
        If chkDateRange.Checked Then
            dtpSince.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpSince.Enabled = False
            dtpTo.Enabled = False
        End If

        If chkCollectUserSys.Checked Then
            cbxUsersSys.Enabled = True
        Else
            cbxUsersSys.Enabled = False
        End If

        If chkYearRate.Checked Then
            cbxYearRate.Enabled = True
        Else
            cbxYearRate.Enabled = False
        End If

        If chkStreet.Checked Then
            cbxStreets.Enabled = True
        Else
            cbxStreets.Enabled = False
        End If
    End Sub

    Private Sub chkDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateRange.CheckedChanged
        initReport()
    End Sub

    Private Sub chkCollectUserSys_CheckedChanged(sender As Object, e As EventArgs) Handles chkCollectUserSys.CheckedChanged
        initReport()
    End Sub

    Private Sub chkYearRate_CheckedChanged(sender As Object, e As EventArgs) Handles chkYearRate.CheckedChanged
        initReport()
    End Sub

    Private Sub chkStreet_CheckedChanged(sender As Object, e As EventArgs) Handles chkStreet.CheckedChanged
        initReport()
    End Sub

    Private Sub btnReportRefresh_Click(sender As Object, e As EventArgs) Handles btnReportRefresh.Click
        Dim dataReport(8) As String
        dataReport(0) = chkDateRange.Checked
        dataReport(1) = dtpSince.Value
        dataReport(2) = dtpTo.Value
        dataReport(3) = chkCollectUserSys.Checked
        dataReport(4) = cbxUsersSys.SelectedValue
        dataReport(5) = chkYearRate.Checked
        dataReport(6) = cbxYearRate.SelectedValue
        dataReport(7) = chkStreet.Checked
        dataReport(8) = cbxStreets.SelectedValue

        Dim ds As dsReceipts = reportReceiptsResume(dataReport)
        Dim dtReport As New ReportDataSource("dsReceipts", ds.Tables(1))
        rptReceipts.LocalReport.DataSources.Clear()
        rptReceipts.LocalReport.DataSources.Add(dtReport)
        rptReceipts.RefreshReport()
    End Sub
End Class