Public Class frmDebtRecord
    Dim dsUsersInAccount As DataSet = Nothing
    Public vIdServiceLine As String = Nothing
    Public vIdInternalLine As String = Nothing
    Public vNameLine As String = Nothing
    Private Sub frmDebtRecord_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconDebtrecord

        dsUsersInAccount = listUsersInAccount(vIdInternalLine)

        If Not dsUsersInAccount.HasErrors Then
            lsxUsersInAccount.DataSource = dsUsersInAccount.Tables(0)
            lsxUsersInAccount.ValueMember = "iduser"
            lsxUsersInAccount.DisplayMember = "fullname"
        Else
            lsxUsersInAccount.Enabled = False
        End If

        If lsxUsersInAccount.Items.Count > 0 Then
            lsxUsersInAccount.Enabled = True
        Else
            lsxUsersInAccount.Enabled = False
        End If

        getAccountCollect(vIdServiceLine, vIdInternalLine, dtgAccountYear)
        Dim dataAccount() As String = getAccount(vIdServiceLine, vIdInternalLine)

        txtCodLine.Text = dataAccount(3)
        txtCodAccount.Text = dataAccount(2)
        txtNameLine.Text = vNameLine
    End Sub
End Class