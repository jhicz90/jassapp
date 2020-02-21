Public Class frmRateType
    Dim idRateType As String = "new"
    Dim nameRateType As String = ""
    Dim descpRateType As String = ""
    Dim monthlyRateType As Boolean = False

    Dim idYear As String = "new"
    Dim yearName As String = ""
    Private Sub frmRateType_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconRate

        nudYear.Maximum = Year(Today)

        listRateTypes(dtgRateType)
        listYears(dtgYears)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveService.Click
        addupdRateType(idRateType, txtRateTypeName.Text, txtRateTypeDescp.Text, chkPeriodic.Checked)
        listRateTypes(dtgRateType)
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNewService.Click
        idRateType = "new"
        nameRateType = ""
        descpRateType = ""
        monthlyRateType = False
        txtRateTypeName.Text = nameRateType
        txtRateTypeDescp.Text = descpRateType
        chkPeriodic.Checked = monthlyRateType
        txtRateTypeName.Focus()
    End Sub

    Private Sub dtgRateType_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgRateType.CellMouseDoubleClick
        If e.RowIndex <> -1 Then
            Dim dataRate() As String = getRateType(dtgRateType.Item(0, e.RowIndex).Value)
            idRateType = dataRate(0)
            nameRateType = dataRate(1)
            descpRateType = dataRate(2)
            monthlyRateType = CBool(dataRate(3))
            txtRateTypeName.Text = nameRateType
            txtRateTypeDescp.Text = descpRateType
            chkPeriodic.Checked = monthlyRateType
            txtRateTypeName.Focus()
        End If
    End Sub
End Class