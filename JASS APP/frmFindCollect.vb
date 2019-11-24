Public Class frmFindCollect
    Private Sub frmFindCollect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconSearch
        MdiParent = frmMain

        cbxCrit.SelectedIndex = 0

        txtFind.Text = ""
        txtFind.Focus()
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        If Trim(txtFind.Text) <> "" And Trim(txtFind.Text).Length > 2 Then
            listLinesService(txtFind.Text, cbxCrit.SelectedIndex, dtgLines)
        Else
            dtgLines.Rows.Clear()
        End If
    End Sub
    Private Sub cbxCrit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCrit.SelectedIndexChanged
        If Trim(txtFind.Text) <> "" And Trim(txtFind.Text).Length > 2 Then
            listLinesService(txtFind.Text, cbxCrit.SelectedIndex, dtgLines)
        Else
            dtgLines.Rows.Clear()
        End If
    End Sub

    Private Sub dtgLines_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgLines.CellContentClick
        If dtgLines.Columns(e.ColumnIndex).Name = "clmOptions" Then
            showCollect()
        End If
    End Sub
End Class