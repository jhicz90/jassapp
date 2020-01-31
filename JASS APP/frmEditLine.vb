Imports System.ComponentModel

Public Class frmEditLine
    Public vIdServiceLine As String = Nothing
    Dim dsAvenues As DataSet = Nothing
    Dim dataLineOriginal(8) As String
    Dim dataLineEdited(8) As String
    Private Sub frmEditLine_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconEditpipe

        dsAvenues = listAvenues()

        If Not (dsAvenues.Equals(Nothing)) Then
            cbxStreets.DataSource = dsAvenues.Tables(0)
            cbxStreets.ValueMember = "idstreet"
            cbxStreets.DisplayMember = "name"
        End If

        If vIdServiceLine.Equals(Nothing) Then
            Close()
        Else
            Dim dataLine() As String = Nothing
            dataLine = getLine(vIdServiceLine)

            If IsNothing(dataLine) Then
                Close()
            Else
                txtCodLine.Text = dataLine(1)
                txtNameLine.Text = dataLine(2)
                txtDateCreated.Text = Format(dataLine(9), "Short Date")
                txtDateUpdated.Text = Format(dataLine(10), "Short Date")
                txtAddressLine.Text = dataLine(6)
                cbxStreets.SelectedValue = dataLine(3)
                dtpInstallDate.Value = Format(dataLine(7), "Short Date")
                txtDescpLine.Text = dataLine(8)

                dataLineOriginal(0) = dataLine(0)
                dataLineOriginal(1) = dataLine(1)
                dataLineOriginal(2) = dataLine(2)
                dataLineOriginal(3) = dataLine(3)
                dataLineOriginal(4) = dataLine(6)
                dataLineOriginal(5) = Format(dataLine(7), "Short Date")
                dataLineOriginal(6) = dataLine(8)
                dataLineOriginal(7) = Format(dataLine(9), "Short Date")
                dataLineOriginal(8) = Format(dataLine(10), "Short Date")
                listAccountLine(dataLine(0), dtgAccountLine)
            End If
        End If
    End Sub

    Public Sub userFound(vActive As Boolean, Optional vDataUser() As String = Nothing, Optional vRates As Integer = 0, Optional vPriceRate As Double = 0)
        addUserToLine(txtCodLine.Text, vDataUser, vRates, vPriceRate)
        listAccountLine(txtCodLine.Text, dtgAccountLine)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnAddAccount_Click(sender As Object, e As EventArgs) Handles btnAddAccount.Click
        'Buscar cuentas
    End Sub

    Private Sub frmEditLine_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        dataLineEdited(0) = dataLineOriginal(0)
        dataLineEdited(1) = txtCodLine.Text
        dataLineEdited(2) = txtNameLine.Text
        dataLineEdited(3) = cbxStreets.SelectedValue
        dataLineEdited(4) = txtAddressLine.Text
        dataLineEdited(5) = Format(dtpInstallDate.Value, "Short Date")
        dataLineEdited(6) = txtDescpLine.Text
        dataLineEdited(7) = Format(txtDateCreated.Text, "Short Date")
        dataLineEdited(8) = Format(Today, "Short Date")

        If Not (compareDataLine(dataLineOriginal, dataLineEdited)) Then
            Dim vQuestion As Integer = MsgBox("Los datos modificados no han sido guardados" & vbCr & "¿Desea guardarlos?", MsgBoxStyle.YesNoCancel + vbExclamation, "Aviso")
            If vQuestion = MsgBoxResult.No Then
                e.Cancel = False
            ElseIf vQuestion = MsgBoxResult.Cancel Then
                e.Cancel = True
            Else
                updateLine(dataLineEdited)
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        dataLineEdited(0) = dataLineOriginal(0)
        dataLineEdited(1) = txtCodLine.Text
        dataLineEdited(2) = txtNameLine.Text
        dataLineEdited(3) = cbxStreets.SelectedValue
        dataLineEdited(4) = txtAddressLine.Text
        dataLineEdited(5) = dtpInstallDate.Value
        dataLineEdited(6) = txtDescpLine.Text
        dataLineEdited(7) = txtDateCreated.Text
        dataLineEdited(8) = Today

        Try
            updateLine(dataLineEdited)
            dataLineOriginal = dataLineEdited
            Close()
        Catch ex As Exception
            MsgBox("Ocurrio un error", vbExclamation, "Aviso")
        End Try
    End Sub

    Private Sub dtgUserLine_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgAccountLine.CellContentClick
        If dtgAccountLine.Columns(e.ColumnIndex).Name = "clmDelete" Then
            If MsgBox("¿Desea eleminar a " & dtgAccountLine.Item(3, e.RowIndex).Value & " " & dtgAccountLine.Item(4, e.RowIndex).Value & vbCr & " de " & txtNameLine.Text & "?", MsgBoxStyle.YesNo + vbExclamation, "Aviso") = MsgBoxResult.Yes Then
                Try
                    deleteUserToLine(txtCodLine.Text, dtgAccountLine.Item(0, e.RowIndex).Value)
                    listAccountLine(txtCodLine.Text, dtgAccountLine)
                Catch ex As Exception
                    MsgBox("Ocurrio un error", vbExclamation, "Aviso")
                End Try
            End If
        ElseIf dtgAccountLine.Columns(e.ColumnIndex).Name = "clmEdit" Then
            showAccount(dataLineOriginal(0), dtgAccountLine.Item(0, e.RowIndex).Value)
            listAccountLine(dataLineOriginal(0), dtgAccountLine)
        End If
    End Sub

    Private Sub btnNewAccount_Click(sender As Object, e As EventArgs) Handles btnNewAccount.Click
        showAccount(dataLineOriginal(0), "new")
        listAccountLine(dataLineOriginal(0), dtgAccountLine)
    End Sub
End Class