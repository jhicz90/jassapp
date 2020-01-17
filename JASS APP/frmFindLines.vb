Public Class frmFindLines
    Private Sub frmSeeLines_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            showEditLine(dtgLines.Item(1, e.RowIndex).Value)
        End If
    End Sub

    Private Sub txtFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFind.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) And dtgLines.Rows.Count > 0 Then
            showEditLine(dtgLines.Item(1, 0).Value)
        ElseIf e.KeyChar = ChrW(keys.Escape) Then
            Close()
        End If
    End Sub
End Class