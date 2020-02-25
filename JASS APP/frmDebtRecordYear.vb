Public Class frmDebtRecordYear
    Public vIdInternalLine As String = Nothing
    Private Sub frmDebtRecordYear_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconDebtrecord

        listYearRate(cbxYearRate)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim resp As Integer = addAccountYear(vIdInternalLine, cbxYearRate.SelectedValue)
        If resp = 1 Then
            MsgBox("AÑO INSERTADO", vbInformation, "Aviso")
        ElseIf resp = 2 Then
            MsgBox("AÑO ENCONTRADO Y NO GENERADO", vbInformation, "Aviso")
        Else
            MsgBox("AÑO NO INGRESADO", vbInformation, "Aviso")
        End If
        Close()
    End Sub
End Class