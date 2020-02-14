Public Class frmRateType
    Private Sub frmRateType_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconRate

        getRateTypes(dtgRateType)
    End Sub
End Class