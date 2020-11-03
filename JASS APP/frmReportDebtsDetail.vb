Imports Microsoft.Reporting.WinForms
Public Class frmReportDebtsDetail
    Public dateSinceTo As String = ""
    Public collectUserSys As String = ""
    Public sectorStreet As String = ""
    Public yearRate As String = ""
    Private Sub frmReportDebtsDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconAttendance

        listUserSys(cbxUsersSys)
        listYearRate(cbxYearRate)
        listAvenues(cbxStreets)
        initReport()
        dtpDebtTo.Value = Today
        dtpPayTo.Value = Today

        Dim dataReport(8) As String
        dataReport(0) = dtpDebtTo.Value
        dataReport(1) = dtpPayTo.Value
        dataReport(2) = chkCollectUserSys.Checked
        dataReport(3) = cbxUsersSys.SelectedValue
        dataReport(4) = chkYearRate.Checked
        dataReport(5) = cbxYearRate.SelectedValue
        dataReport(6) = chkStreet.Checked
        dataReport(7) = cbxStreets.SelectedValue
        dataReport(8) = My.Settings.vYear

        Dim ds As dsDebtsDetail = reportDebtsDetail(dataReport)
        Dim dtReport As New ReportDataSource("dsDetail", ds.Tables(0))
        rptDebts.LocalReport.DataSources.Clear()
        rptDebts.LocalReport.DataSources.Add(dtReport)
        rptDebts.SetDisplayMode(DisplayMode.PrintLayout)
        rptDebts.ZoomMode = ZoomMode.PageWidth
        critReport()
        rptDebts.RefreshReport()
        Me.rptDebts.RefreshReport()
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
        parameters.Add(New ReportParameter("rptParamYear5", My.Settings.vYear))
        parameters.Add(New ReportParameter("rptParamYear4", My.Settings.vYear - 1))
        parameters.Add(New ReportParameter("rptParamYear3", My.Settings.vYear - 2))
        parameters.Add(New ReportParameter("rptParamYear2", My.Settings.vYear - 3))
        parameters.Add(New ReportParameter("rptParamYear1", My.Settings.vYear - 4))
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
        Dim dataReport(8) As String
        dataReport(0) = dtpDebtTo.Value
        dataReport(1) = dtpPayTo.Value
        dataReport(2) = chkCollectUserSys.Checked
        dataReport(3) = cbxUsersSys.SelectedValue
        dataReport(4) = chkYearRate.Checked
        dataReport(5) = cbxYearRate.SelectedValue
        dataReport(6) = chkStreet.Checked
        dataReport(7) = cbxStreets.SelectedValue
        dataReport(8) = My.Settings.vYear

        Dim ds As dsDebts = reportDebtsResume(dataReport)
        Dim dtReport As New ReportDataSource("dsDetail", ds.Tables(0))
        rptDebts.LocalReport.DataSources.Clear()
        rptDebts.LocalReport.DataSources.Add(dtReport)
        critReport()
        rptDebts.RefreshReport()
    End Sub
End Class