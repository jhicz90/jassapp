﻿Public Class frmAccount
    Public vIdServiceLine As String = Nothing
    Public vIdInternalLine As String = Nothing
    Private Sub frmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconNewline

        loadAccount(vIdServiceLine, vIdInternalLine)
    End Sub

    Private Sub loadAccount(vIdLine As String, vIdInternal As String)
        listRates(cbxRates)

        If vIdInternal <> "new" Then
            If vIdLine.Equals(Nothing) Or vIdInternal.Equals(Nothing) Then
                MsgBox("Faltan datos de la cuenta", vbCritical, "Aviso")
                Close()
            Else
                Dim dataAccount() As String = getAccount(vIdLine, vIdInternal)

                If IsNothing(dataAccount) Then
                    Close()
                Else
                    vIdInternalLine = dataAccount(0)
                    vIdServiceLine = dataAccount(1)
                    txtCodAccount.Text = dataAccount(2)
                    txtCodLine.Text = dataAccount(3)
                    cbxRates.SelectedValue = dataAccount(4)
                    txtPriceRate.Text = dataAccount(5)
                    txtDateCreated.Text = Format(dataAccount(6), "Short Date")
                    txtDateUpdated.Text = Format(dataAccount(7), "Short Date")

                    listUserAccount(dataAccount(1), dataAccount(0), dtgUsersAccount)
                End If
            End If
            tabDataAccount.Enabled = True
            tabDataAccount.Visible = True
            Text = "Cuenta de Servicio"
        Else
            txtCodAccount.Text = ""
            txtCodLine.Text = ""
            txtDateCreated.Text = ""
            txtDateUpdated.Text = ""
            tabDataAccount.Enabled = False
            tabDataAccount.Visible = False
            Text = "Nueva Cuenta de Servicio"
        End If
    End Sub

    Public Sub userFound(vActive As Boolean, Optional vDataUser() As String = Nothing, Optional vRates As Integer = 0, Optional vPriceRate As Double = 0)
        addUserToLine(vIdInternalLine, vDataUser, vRates, vPriceRate)
        listUserAccount(vIdServiceLine, vIdInternalLine, dtgUsersAccount)
    End Sub

    Private Sub cbxRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedIndexChanged
        If IsNumeric(cbxRates.SelectedValue.ToString) Then
            Dim dataPrice() As String = getPriceRate(cbxRates.SelectedValue.ToString)
            txtPriceRate.Text = Math.Round(Convert.ToDouble(dataPrice(0)), 2).ToString
            txtDescRate.Text = dataPrice(1)
            If Convert.ToBoolean(dataPrice(2)) = True Then
                txtPriceRate.ReadOnly = False
                txtPriceRate.Text = 0
            Else
                txtPriceRate.ReadOnly = True
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vIdInternalLine <> "new" Then
            Dim saved As Boolean = updateAccount(vIdInternalLine, vIdServiceLine, cbxRates.SelectedValue, Val(txtPriceRate.Text))
            If saved = False Then
                Close()
            End If
        Else
            vIdInternalLine = saveAccountNew(vIdServiceLine, cbxRates.SelectedValue, Val(txtPriceRate.Text))
        End If
        loadAccount(vIdServiceLine, vIdInternalLine)
    End Sub

    Private Sub btnNewUser_Click(sender As Object, e As EventArgs) Handles btnNewUser.Click
        showNewUser("new", vIdInternalLine, 3)
        listUserAccount(vIdServiceLine, vIdInternalLine, dtgUsersAccount)
    End Sub

    Private Sub btnFindUser_Click(sender As Object, e As EventArgs) Handles btnFindUser.Click
        showFindUsers(Nothing, 4, Me)
    End Sub

    Private Sub dtgUsersAccount_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgUsersAccount.CellContentClick
        If dtgUsersAccount.Columns(e.ColumnIndex).Name = "clmDelete" Then
            If MsgBox("¿Desea eleminar a " & dtgUsersAccount.Item(1, e.RowIndex).Value & " de esta cuenta?", MsgBoxStyle.YesNo + vbExclamation, "Aviso") = MsgBoxResult.Yes Then
                deleteUserToInternal(vIdInternalLine, dtgUsersAccount.Item(0, e.RowIndex).Value)
                listUserAccount(vIdServiceLine, vIdInternalLine, dtgUsersAccount)
            End If
        ElseIf dtgUsersAccount.Columns(e.ColumnIndex).Name = "clmEdit" Then
            'Editar usuario
        End If
    End Sub
End Class