Public Class frmDebtRecordService
    Public vIdAccountLine As String = Nothing
    Dim dataAccount() As String = Nothing
    Private Sub frmDebtRecordService_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconDeclareservice

        initService()
    End Sub

    Public Sub initService()
        listYearRate(cbxYearRate)
        listServices(cbxService)
        dataAccount = getAccountLine(vIdAccountLine)
        cbxYearRate.SelectedValue = dataAccount(2)
    End Sub

    Private Sub cbxService_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxService.SelectedIndexChanged
        Dim value As Object = cbxService.SelectedValue

        If (TypeOf value Is Integer) Then
            cbxMonths.Enabled = getServiceRate(value)
            cbxMonths.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim accountDetail As Integer = addAccountDetail(dataAccount(1), dataAccount(2), cbxService.SelectedValue, cbxMonths.SelectedIndex + 1, nudAmountDetail.Value)
        If accountDetail = 1 Then
            MsgBox("Mes o cuenta insertada (El consumo se genero exitosamente)", vbExclamation, "Aviso")
        ElseIf accountDetail = 2 Then
            MsgBox("Mes o cuenta encontrada (No ingresada)", vbExclamation, "Aviso")
        Else
            MsgBox("Se encontro un error por lo tanto no se ingreso (No ingresada)", vbExclamation, "Aviso")
        End If
        Close()
    End Sub
End Class