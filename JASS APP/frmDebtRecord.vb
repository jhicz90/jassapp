Public Class frmDebtRecord
    Public vIdServiceLine As String = Nothing
    Public vIdInternalLine As String = Nothing
    Public vNameLine As String = Nothing
    Private Sub frmDebtRecord_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconDebtrecord

        listUsersInAccount(vIdInternalLine, Nothing, lsxUsersInAccount)

        If lsxUsersInAccount.Items.Count > 0 Then
            lsxUsersInAccount.Enabled = True
        Else
            lsxUsersInAccount.Enabled = False
        End If

        initDetail()
    End Sub

    Public Sub initDetail()
        getAccountCollect(vIdServiceLine, vIdInternalLine, dtgAccountYear)
        Dim dataAccount() As String = getAccount(vIdServiceLine, vIdInternalLine)

        txtCodLine.Text = dataAccount(3)
        txtCodAccount.Text = dataAccount(2)
        txtNameLine.Text = vNameLine
    End Sub

    Private Sub btnAddYear_Click(sender As Object, e As EventArgs) Handles btnAddYear.Click
        showGenerateYear(vIdInternalLine)
        initDetail()
    End Sub
    Private Sub btnAddDebtDetail_Click(sender As Object, e As EventArgs) Handles btnAddDebtDetail.Click
        If dtgAccountYear.Rows.Count > 0 And dtgAccountYear.SelectedRows(0).Index <> -1 Then
            showGenerateService(dtgAccountYear.Item(0, dtgAccountYear.SelectedRows(0).Index).Value)
            initDetail()
        Else
            MsgBox("La lista no contiene registros o necesita seleccionar un registro", vbInformation, "Aviso")
        End If
    End Sub

    Private Sub dtgAccountYear_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountYear.CellClick
        If e.RowIndex <> -1 Then
            If dtgAccountYear.Columns(e.ColumnIndex).Name = "clmEdit" Then
                showGenerateDetail(dtgAccountYear.Item(0, e.RowIndex).Value)
                initDetail()
            End If
        Else
            MsgBox("Seleccione un registro de la lista", vbInformation, "Aviso")
        End If
    End Sub
End Class