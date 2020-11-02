Imports Microsoft.Reporting.WinForms
Public Class frmReportDebtsResume
    Public dateSinceTo As String = ""
    Public collectUserSys As String = ""
    Public sectorStreet As String = ""
    Public yearRate As String = ""
    Private Sub frmReportDebtsResume_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconAttendance

        listUserSys(cbxUsersSys)
        listYearRate(cbxYearRate)
        listAvenues(cbxStreets)
        initReport()
        dtpDebtTo.Value = Today
        dtpPayTo.Value = Today

        Dim dataReport(7) As String
        dataReport(0) = dtpDebtTo.Value
        dataReport(1) = dtpPayTo.Value
        dataReport(2) = chkCollectUserSys.Checked
        dataReport(3) = cbxUsersSys.SelectedValue
        dataReport(4) = chkYearRate.Checked
        dataReport(5) = cbxYearRate.SelectedValue
        dataReport(6) = chkStreet.Checked
        dataReport(7) = cbxStreets.SelectedValue

        Dim ds As dsDebts = reportDebtsResume(dataReport)
        Dim dtReport As New ReportDataSource("dsDebts", ds.Tables(0))
        rptDebts.LocalReport.DataSources.Clear()
        rptDebts.LocalReport.DataSources.Add(dtReport)
        rptDebts.SetDisplayMode(DisplayMode.PrintLayout)
        rptDebts.ZoomMode = ZoomMode.PageWidth
        critReport()
        rptDebts.RefreshReport()
    End Sub

    Public Sub initReport()
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

    Public Sub critReport()
        Dim parameters As New List(Of ReportParameter)()

        dateSinceTo = "Deuda hasta: " & dtpDebtTo.Value & " Pagos hasta: " & dtpPayTo.Value

        If chkCollectUserSys.Checked Then
            collectUserSys = "Cobrado por: " & cbxUsersSys.Text
        Else
            collectUserSys = "Cobrado por: Sin criterio"
        End If

        If chkStreet.Checked Then
            sectorStreet = "Calle: " & cbxStreets.Text
        Else
            sectorStreet = "Calle: Sin criterio"
        End If

        If chkYearRate.Checked Then
            yearRate = "Año: " & cbxYearRate.Text
        Else
            yearRate = "Año: Todo"
        End If

        parameters.Add(New ReportParameter("rptParamDateSinceTo", dateSinceTo))
        parameters.Add(New ReportParameter("rptParamUserSys", collectUserSys))
        parameters.Add(New ReportParameter("rptParamStreet", sectorStreet))
        parameters.Add(New ReportParameter("rptParamYearRate", yearRate))
        rptDebts.LocalReport.SetParameters(parameters)
    End Sub

    Private Sub chkDateRange_CheckedChanged(sender As Object, e As EventArgs)
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
        Dim dataReport(7) As String
        dataReport(0) = dtpDebtTo.Value
        dataReport(1) = dtpPayTo.Value
        dataReport(2) = chkCollectUserSys.Checked
        dataReport(3) = cbxUsersSys.SelectedValue
        dataReport(4) = chkYearRate.Checked
        dataReport(5) = cbxYearRate.SelectedValue
        dataReport(6) = chkStreet.Checked
        dataReport(7) = cbxStreets.SelectedValue

        Dim ds As dsDebts = reportDebtsResume(dataReport)
        Dim dtReport As New ReportDataSource("dsDebts", ds.Tables(0))
        rptDebts.LocalReport.DataSources.Clear()
        rptDebts.LocalReport.DataSources.Add(dtReport)
        critReport()
        rptDebts.RefreshReport()
    End Sub
End Class