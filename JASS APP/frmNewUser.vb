Imports System.ComponentModel

Public Class frmNewuser
    Public vFrmGet As Integer = 0
    Public vIdUserReg As String = "new"
    Public vIdInternalLine As String = Nothing
    Dim dataUserEdited(13) As String
    Public Sub frmNewuser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconAdduser

        listUserTypes(cbxTypeUser)

        If IsNothing(vIdUserReg) Then
            Close()
        ElseIf vIdUserReg = "new" Then
            newUser()
        ElseIf vIdUserReg = "edit" Then
            newUser()
            btnFindUser.Visible = True
            btnFindUser.PerformClick()
        Else
            Dim dataUser() As String = getUser(vIdUserReg)

            If vIdInternalLine.Length = 0 Then
                Close()
            ElseIf Not IsNothing(dataUser) And vIdInternalLine.Length > 0 Then
                txtCodUser.Text = vIdUserReg = dataUser(0)
                txtNames.Text = dataUser(1)
                txtSurnames.Text = dataUser(2)
                cbxTypeUser.SelectedValue = dataUser(3)
                txtDocID.Text = dataUser(5)
                txtAddress.Text = dataUser(6)

                txtCellphone.Text = dataUser(7)
                txtTelephone.Text = dataUser(8)

                txtDateCreated.Text = Format(dataUser(9), "Short Date")
                txtDateUpdated.Text = Format(dataUser(10), "Short Date")

                txtNames.Focus()
            End If
        End If
    End Sub

    Public Sub newUser()
        vIdUserReg = "new"
        txtCodUser.Text = ""
        txtNames.Text = ""
        txtSurnames.Text = ""
        cbxTypeUser.SelectedIndex = 0
        txtDocID.Text = ""
        cbxTypeUser.SelectedIndex = 0
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtCellphone.Text = ""
        txtDateCreated.Text = Format(Today, "Short Date")
        txtDateUpdated.Text = Format(Today, "Short Date")
        grpUser.Focus()
    End Sub

    Public Sub userFound(Optional vDataUser() As String = Nothing)
        vIdUserReg = vDataUser(0)
        txtNames.Text = vDataUser(2)
        txtSurnames.Text = vDataUser(3)
        txtDocID.Text = vDataUser(1)
        cbxTypeUser.SelectedValue = vDataUser(4)
        txtAddress.Text = vDataUser(5)
        txtTelephone.Text = vDataUser(7)
        txtCellphone.Text = vDataUser(6)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub cbxTypeUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTypeUser.SelectedIndexChanged
        If IsNumeric(cbxTypeUser.SelectedValue.ToString) Then
            If (cbxTypeUser.SelectedValue > 1) Then
                lblNameSocial.Text = "Razon:"
                lblDoc.Text = "RUC:"
                txtSurnames.Text = ""
                lblSurNames.Visible = False
                txtSurnames.Visible = False
                lblSurNames.Enabled = False
                txtSurnames.Enabled = False
            Else
                lblNameSocial.Text = "Nombres:"
                lblDoc.Text = "DNI:"
                lblSurNames.Visible = True
                txtSurnames.Visible = True
                lblSurNames.Enabled = True
                txtSurnames.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        dataUserEdited(0) = vIdUserReg
        dataUserEdited(1) = txtNames.Text
        dataUserEdited(2) = txtSurnames.Text
        dataUserEdited(3) = cbxTypeUser.SelectedValue
        dataUserEdited(4) = txtDocID.Text
        dataUserEdited(5) = txtAddress.Text
        dataUserEdited(6) = txtCellphone.Text
        dataUserEdited(7) = txtTelephone.Text
        dataUserEdited(8) = Format(txtDateCreated.Text, "Short Date")
        dataUserEdited(9) = Format(Today, "Short Date")

        If vFrmGet = 1 Then
            saveUserNew(dataUserEdited)
            newUser()
        ElseIf vFrmGet = 2 And vIdUserReg <> "new" And vIdUserReg <> "edit" Then
            updateUser(dataUserEdited)
        ElseIf vFrmGet = 3 Then
            saveUserNew(dataUserEdited, True, vIdInternalLine)
            newUser()
        End If
    End Sub

    Private Sub frmNewuser_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub

    Private Sub btnFindUser_Click(sender As Object, e As EventArgs) Handles btnFindUser.Click
        showFindUsers(Nothing, 3, Me)
    End Sub
End Class