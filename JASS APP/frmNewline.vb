Public Class frmNewline
    Dim dsRates As DataSet = Nothing
    Dim dsAvenues As DataSet = Nothing
    Dim dsUserTypes As DataSet = Nothing
    Public codUser As String = ""
    Private Sub FrmNewline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconNewline

        dsRates = listRates()

        If Not dsRates.HasErrors Then
            cbxRates.Enabled = True
            cbxRates.DataSource = dsRates.Tables(0)
            cbxRates.ValueMember = "idrate"
            cbxRates.DisplayMember = "name"
        Else
            cbxRates.Enabled = False
        End If

        dsAvenues = listAvenues()

        If Not dsAvenues.HasErrors Then
            cbxStreets.Enabled = True
            cbxStreets.DataSource = dsAvenues.Tables(0)
            cbxStreets.ValueMember = "idstreet"
            cbxStreets.DisplayMember = "name"
        Else
            cbxStreets.Enabled = False
        End If

        dsUserTypes = listUserTypes()

        If Not dsUserTypes.HasErrors Then
            cbxTypeUser.Enabled = True
            cbxTypeUser.DataSource = dsUserTypes.Tables(0)
            cbxTypeUser.ValueMember = "idusertype"
            cbxTypeUser.DisplayMember = "name"
        Else
            cbxTypeUser.Enabled = False
        End If

        newLine()
    End Sub

    Public Sub newLine()
        userFound(False)

        txtNameLine.Text = ""
        txtAddressLine.Text = ""
        cbxStreets.SelectedIndex = 0
        dtpInstallDate.Value = Format(Today, "Short Date")
        txtDescpLine.Text = ""
        cbxRates.SelectedIndex = 0
        txtNames.Text = ""
        txtSurnames.Text = ""
        txtDocID.Text = ""
        'cbxTypeUser.SelectedIndex = 0
        txtAddress.Text = ""
        txtTelephone.Text = ""
        txtCellphone.Text = ""
        txtNameLine.Focus()

        'Dim codeLine As String
        'codeLine = getCodeLine(cbxStreets.SelectedValue)
        'If (codeLine <> Nothing) Then
        '    txtCodLine.Text = codeLine
        'Else
        '    Close()
        'End If
    End Sub

    Public Sub userFound(vActive As Boolean, Optional vDataUser() As String = Nothing)
        txtNames.Enabled = Not (vActive)
        txtSurnames.Enabled = Not (vActive)
        txtDocID.Enabled = Not (vActive)
        cbxTypeUser.Enabled = Not (vActive)
        txtAddress.Enabled = Not (vActive)
        txtTelephone.Enabled = Not (vActive)
        txtCellphone.Enabled = Not (vActive)
        btnDeleteUserFound.Enabled = vActive

        If vActive = False Then
            txtNames.Text = ""
            txtSurnames.Text = ""
            txtDocID.Text = ""
            'cbxTypeUser.SelectedIndex = 0
            txtAddress.Text = ""
            txtTelephone.Text = ""
            txtCellphone.Text = ""
            codUser = ""
        Else
            codUser = vDataUser(0)
            txtNames.Text = vDataUser(2)
            txtSurnames.Text = vDataUser(3)
            txtDocID.Text = vDataUser(1)
            cbxTypeUser.SelectedValue = vDataUser(4)
            txtAddress.Text = vDataUser(5)
            txtTelephone.Text = vDataUser(7)
            txtCellphone.Text = vDataUser(6)
        End If
    End Sub

    Private Sub CbxRates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxRates.SelectedIndexChanged
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dataLine(6) As String
        Dim dataUser(7) As String

        If (txtNames.Text <> "" And txtSurnames.Text <> "" And cbxTypeUser.SelectedValue = 1) Or (txtNames.Text <> "" And (cbxTypeUser.SelectedValue = 2 Or cbxTypeUser.SelectedValue = 3)) Then
            dataLine(0) = txtCodLine.Text
            dataLine(1) = txtNameLine.Text
            dataLine(2) = cbxStreets.SelectedValue
            dataLine(3) = txtAddressLine.Text
            dataLine(4) = cbxRates.SelectedValue
            dataLine(5) = dtpInstallDate.Value
            dataLine(6) = txtDescpLine.Text

            dataUser(0) = txtNames.Text
            dataUser(1) = txtSurnames.Text
            dataUser(2) = cbxTypeUser.SelectedValue
            dataUser(3) = txtDocID.Text
            dataUser(4) = txtAddress.Text
            dataUser(5) = txtCellphone.Text
            dataUser(6) = txtTelephone.Text
            dataUser(7) = codUser

            If saveLineNew(dataLine, dataUser, Convert.ToDouble(txtPriceRate.Text)) Then
                newLine()
            Else
                Close()
            End If
        Else
            MsgBox("Faltan datos de la Persona titular", vbExclamation, "Aviso")
        End If
    End Sub

    Private Sub cbxStreets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxStreets.SelectedIndexChanged
        If IsNumeric(cbxStreets.SelectedValue.ToString) Then
            Dim codeLine As String = getCodeLine(cbxStreets.SelectedValue)
            If (codeLine <> Nothing) Then
                txtCodLine.Text = codeLine
            Else
                Close()
            End If
        End If
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

    Private Sub btnCleanData_Click(sender As Object, e As EventArgs) Handles btnCleanData.Click
        newLine()
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        showFindUsers(Nothing, 1, Me)
    End Sub

    Private Sub btnDeleteUserFound_Click(sender As Object, e As EventArgs) Handles btnDeleteUserFound.Click
        userFound(False)
    End Sub
End Class