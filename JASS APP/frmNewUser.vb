﻿Imports System.ComponentModel

Public Class frmNewuser
    Public vFrmGet As Integer = 0
    Public vCodUser As String = Nothing
    Public vCodAccount As String = Nothing
    Dim dsUserTypes As DataSet = Nothing
    Dim dataUserEdited(13) As String
    Public Sub frmNewuser_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconAdduser

        dsUserTypes = listUserTypes()

        If Not (dsUserTypes.Equals(Nothing)) Then
            cbxTypeUser.DataSource = dsUserTypes.Tables(0)
            cbxTypeUser.ValueMember = "ID_TYPE_USER"
            cbxTypeUser.DisplayMember = "NAME_TYPE"
        End If

        cbxTypeUser.SelectedIndex = 0

        If IsNothing(vCodUser) Then
            Close()
        ElseIf vCodUser = "new" Then
            newUser()
        Else
            Dim dataUser() As String = getUser(vCodUser)

            If vCodUser.Length = 0 Then
                Close()
            ElseIf Not IsNothing(dataUser) And vCodUser.Length > 0 Then
                txtCodUser.Text = dataUser(0)
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
        dataUserEdited(0) = txtCodUser.Text
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
        ElseIf vFrmGet = 2 Then
            updateUser(dataUserEdited)
        ElseIf vFrmGet = 3 Then
            saveUserNew(dataUserEdited, True, vCodAccount)
            newUser()
        End If

        Close()
    End Sub

    Private Sub frmNewuser_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub
End Class