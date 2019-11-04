<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewline
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDescRate = New System.Windows.Forms.TextBox()
        Me.txtPriceRate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxRates = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteUserFound = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNameSocial = New System.Windows.Forms.Label()
        Me.txtCellphone = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblSurNames = New System.Windows.Forms.Label()
        Me.txtNames = New System.Windows.Forms.TextBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSurnames = New System.Windows.Forms.TextBox()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDocID = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxTypeUser = New System.Windows.Forms.ComboBox()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCleanData = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDescpLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInstallDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAddressLine = New System.Windows.Forms.TextBox()
        Me.cbxStreets = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNameLine = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 225.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(784, 561)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtDescRate)
        Me.GroupBox2.Controls.Add(Me.txtPriceRate)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cbxRates)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(395, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox2.Size = New System.Drawing.Size(386, 219)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tarifa de cuenta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 32)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Descripcion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de la tarifa:"
        '
        'txtDescRate
        '
        Me.txtDescRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescRate.Location = New System.Drawing.Point(137, 76)
        Me.txtDescRate.Multiline = True
        Me.txtDescRate.Name = "txtDescRate"
        Me.txtDescRate.ReadOnly = True
        Me.txtDescRate.Size = New System.Drawing.Size(240, 127)
        Me.txtDescRate.TabIndex = 0
        Me.txtDescRate.TabStop = False
        '
        'txtPriceRate
        '
        Me.txtPriceRate.Location = New System.Drawing.Point(137, 51)
        Me.txtPriceRate.Name = "txtPriceRate"
        Me.txtPriceRate.ReadOnly = True
        Me.txtPriceRate.Size = New System.Drawing.Size(240, 22)
        Me.txtPriceRate.TabIndex = 0
        Me.txtPriceRate.TabStop = False
        Me.txtPriceRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 16)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Tarifa (S/.):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 16)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Tipos de Tarifas:"
        '
        'cbxRates
        '
        Me.cbxRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRates.FormattingEnabled = True
        Me.cbxRates.Location = New System.Drawing.Point(137, 20)
        Me.cbxRates.Name = "cbxRates"
        Me.cbxRates.Size = New System.Drawing.Size(240, 24)
        Me.cbxRates.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(395, 478)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 80)
        Me.Panel1.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSave.Location = New System.Drawing.Point(71, 21)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 50)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.JASS_APP.My.Resources.Resources.cancel_32
        Me.btnCancel.Location = New System.Drawing.Point(227, 21)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 50)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.GroupBox1, 2)
        Me.GroupBox1.Controls.Add(Me.btnDeleteUserFound)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Controls.Add(Me.btnAddUser)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 228)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(778, 244)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Personales del nuevo usuario"
        '
        'btnDeleteUserFound
        '
        Me.btnDeleteUserFound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteUserFound.Image = Global.JASS_APP.My.Resources.Resources.cancel_32
        Me.btnDeleteUserFound.Location = New System.Drawing.Point(165, 188)
        Me.btnDeleteUserFound.Name = "btnDeleteUserFound"
        Me.btnDeleteUserFound.Size = New System.Drawing.Size(52, 50)
        Me.btnDeleteUserFound.TabIndex = 4
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblNameSocial, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCellphone, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSurNames, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNames)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTelephone, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSurnames, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDoc, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAddress, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDocID, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxTypeUser, 3, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(9, 28)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(756, 154)
        Me.TableLayoutPanel2.TabIndex = 12
        '
        'lblNameSocial
        '
        Me.lblNameSocial.AutoSize = True
        Me.lblNameSocial.Location = New System.Drawing.Point(3, 0)
        Me.lblNameSocial.Name = "lblNameSocial"
        Me.lblNameSocial.Size = New System.Drawing.Size(67, 16)
        Me.lblNameSocial.TabIndex = 0
        Me.lblNameSocial.Text = "Nombres:"
        '
        'txtCellphone
        '
        Me.txtCellphone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCellphone.Location = New System.Drawing.Point(455, 119)
        Me.txtCellphone.Name = "txtCellphone"
        Me.txtCellphone.Size = New System.Drawing.Size(287, 22)
        Me.txtCellphone.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(380, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Celular:"
        '
        'lblSurNames
        '
        Me.lblSurNames.AutoSize = True
        Me.lblSurNames.Location = New System.Drawing.Point(380, 0)
        Me.lblSurNames.Name = "lblSurNames"
        Me.lblSurNames.Size = New System.Drawing.Size(68, 16)
        Me.lblSurNames.TabIndex = 3
        Me.lblSurNames.Text = "Apellidos:"
        '
        'txtNames
        '
        Me.txtNames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNames.Location = New System.Drawing.Point(78, 3)
        Me.txtNames.Name = "txtNames"
        Me.txtNames.Size = New System.Drawing.Size(287, 22)
        Me.txtNames.TabIndex = 1
        '
        'txtTelephone
        '
        Me.txtTelephone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelephone.Location = New System.Drawing.Point(78, 119)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(287, 22)
        Me.txtTelephone.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Télefono:"
        '
        'txtSurnames
        '
        Me.txtSurnames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSurnames.Location = New System.Drawing.Point(455, 3)
        Me.txtSurnames.Name = "txtSurnames"
        Me.txtSurnames.Size = New System.Drawing.Size(287, 22)
        Me.txtSurnames.TabIndex = 2
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Location = New System.Drawing.Point(3, 28)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(34, 16)
        Me.lblDoc.TabIndex = 5
        Me.lblDoc.Text = "DNI:"
        '
        'txtAddress
        '
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Location = New System.Drawing.Point(78, 59)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(287, 44)
        Me.txtAddress.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Dirección:"
        '
        'txtDocID
        '
        Me.txtDocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocID.Location = New System.Drawing.Point(78, 31)
        Me.txtDocID.Name = "txtDocID"
        Me.txtDocID.Size = New System.Drawing.Size(287, 22)
        Me.txtDocID.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(380, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Usuario:"
        '
        'cbxTypeUser
        '
        Me.cbxTypeUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTypeUser.FormattingEnabled = True
        Me.cbxTypeUser.Location = New System.Drawing.Point(455, 31)
        Me.cbxTypeUser.Name = "cbxTypeUser"
        Me.cbxTypeUser.Size = New System.Drawing.Size(287, 24)
        Me.cbxTypeUser.TabIndex = 4
        '
        'btnAddUser
        '
        Me.btnAddUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddUser.Image = Global.JASS_APP.My.Resources.Resources.find_user_male_32
        Me.btnAddUser.Location = New System.Drawing.Point(9, 188)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(150, 50)
        Me.btnAddUser.TabIndex = 3
        Me.btnAddUser.Text = "&Agregar un usuario existente"
        Me.btnAddUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCleanData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 478)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(386, 80)
        Me.Panel2.TabIndex = 5
        '
        'btnCleanData
        '
        Me.btnCleanData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCleanData.Image = Global.JASS_APP.My.Resources.Resources.clear_32
        Me.btnCleanData.Location = New System.Drawing.Point(9, 21)
        Me.btnCleanData.Name = "btnCleanData"
        Me.btnCleanData.Size = New System.Drawing.Size(150, 50)
        Me.btnCleanData.TabIndex = 1
        Me.btnCleanData.Text = "Li&mpiar datos"
        Me.btnCleanData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCleanData.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDescpLine)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.dtpInstallDate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtAddressLine)
        Me.GroupBox3.Controls.Add(Me.cbxStreets)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtNameLine)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtCodLine)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox3.Size = New System.Drawing.Size(386, 219)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de la linea"
        '
        'txtDescpLine
        '
        Me.txtDescpLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescpLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescpLine.Location = New System.Drawing.Point(123, 162)
        Me.txtDescpLine.Multiline = True
        Me.txtDescpLine.Name = "txtDescpLine"
        Me.txtDescpLine.Size = New System.Drawing.Size(250, 44)
        Me.txtDescpLine.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Descripcion:"
        '
        'dtpInstallDate
        '
        Me.dtpInstallDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInstallDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstallDate.Location = New System.Drawing.Point(205, 134)
        Me.dtpInstallDate.Name = "dtpInstallDate"
        Me.dtpInstallDate.Size = New System.Drawing.Size(168, 22)
        Me.dtpInstallDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha de instalación de linea:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Calle o Avenida:"
        '
        'txtAddressLine
        '
        Me.txtAddressLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddressLine.Location = New System.Drawing.Point(123, 76)
        Me.txtAddressLine.Name = "txtAddressLine"
        Me.txtAddressLine.Size = New System.Drawing.Size(250, 22)
        Me.txtAddressLine.TabIndex = 2
        '
        'cbxStreets
        '
        Me.cbxStreets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStreets.FormattingEnabled = True
        Me.cbxStreets.Location = New System.Drawing.Point(123, 104)
        Me.cbxStreets.Name = "cbxStreets"
        Me.cbxStreets.Size = New System.Drawing.Size(250, 24)
        Me.cbxStreets.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Dirreción:"
        '
        'txtNameLine
        '
        Me.txtNameLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameLine.Location = New System.Drawing.Point(123, 48)
        Me.txtNameLine.Name = "txtNameLine"
        Me.txtNameLine.Size = New System.Drawing.Size(250, 22)
        Me.txtNameLine.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Nombre de linea:"
        '
        'txtCodLine
        '
        Me.txtCodLine.Location = New System.Drawing.Point(123, 22)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(250, 22)
        Me.txtCodLine.TabIndex = 0
        Me.txtCodLine.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 16)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Código de linea:"
        '
        'frmNewline
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "frmNewline"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva Linea de servicio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtSurnames As TextBox
    Friend WithEvents txtNames As TextBox
    Friend WithEvents lblNameSocial As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblDoc As Label
    Friend WithEvents txtDocID As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCellphone As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cbxRates As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cbxStreets As ComboBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCleanData As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAddressLine As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtNameLine As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCodLine As TextBox
    Friend WithEvents txtPriceRate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDescRate As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cbxTypeUser As ComboBox
    Friend WithEvents lblSurNames As Label
    Friend WithEvents dtpInstallDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescpLine As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnDeleteUserFound As Button
End Class
