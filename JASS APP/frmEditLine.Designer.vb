<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditLine
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
        Me.tabDataLine = New System.Windows.Forms.TabControl()
        Me.tabpageDataLine = New System.Windows.Forms.TabPage()
        Me.dtpInstallDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDescpLine = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxStreets = New System.Windows.Forms.ComboBox()
        Me.txtAddressLine = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabpageUsers = New System.Windows.Forms.TabPage()
        Me.btnAddAccount = New System.Windows.Forms.Button()
        Me.btnNewAccount = New System.Windows.Forms.Button()
        Me.dtgUserLine = New System.Windows.Forms.DataGridView()
        Me.clmCodUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSurnames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTypeUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmHolder = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDateUpdated = New System.Windows.Forms.TextBox()
        Me.txtDateCreated = New System.Windows.Forms.TextBox()
        Me.txtNameLine = New System.Windows.Forms.TextBox()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tabDataLine.SuspendLayout()
        Me.tabpageDataLine.SuspendLayout()
        Me.tabpageUsers.SuspendLayout()
        CType(Me.dtgUserLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDataLine
        '
        Me.tabDataLine.Controls.Add(Me.tabpageDataLine)
        Me.tabDataLine.Controls.Add(Me.tabpageUsers)
        Me.tabDataLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDataLine.Location = New System.Drawing.Point(3, 103)
        Me.tabDataLine.Name = "tabDataLine"
        Me.tabDataLine.SelectedIndex = 0
        Me.tabDataLine.Size = New System.Drawing.Size(928, 455)
        Me.tabDataLine.TabIndex = 0
        '
        'tabpageDataLine
        '
        Me.tabpageDataLine.Controls.Add(Me.dtpInstallDate)
        Me.tabpageDataLine.Controls.Add(Me.Label8)
        Me.tabpageDataLine.Controls.Add(Me.txtDescpLine)
        Me.tabpageDataLine.Controls.Add(Me.Label7)
        Me.tabpageDataLine.Controls.Add(Me.cbxStreets)
        Me.tabpageDataLine.Controls.Add(Me.txtAddressLine)
        Me.tabpageDataLine.Controls.Add(Me.Label6)
        Me.tabpageDataLine.Controls.Add(Me.Label5)
        Me.tabpageDataLine.Location = New System.Drawing.Point(4, 22)
        Me.tabpageDataLine.Name = "tabpageDataLine"
        Me.tabpageDataLine.Padding = New System.Windows.Forms.Padding(20)
        Me.tabpageDataLine.Size = New System.Drawing.Size(920, 429)
        Me.tabpageDataLine.TabIndex = 0
        Me.tabpageDataLine.Text = "DATOS DE LA LINEA"
        Me.tabpageDataLine.UseVisualStyleBackColor = True
        '
        'dtpInstallDate
        '
        Me.dtpInstallDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpInstallDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpInstallDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInstallDate.Location = New System.Drawing.Point(777, 43)
        Me.dtpInstallDate.Name = "dtpInstallDate"
        Me.dtpInstallDate.Size = New System.Drawing.Size(120, 20)
        Me.dtpInstallDate.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(623, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Fecha de instalación de linea:"
        '
        'txtDescpLine
        '
        Me.txtDescpLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescpLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescpLine.Location = New System.Drawing.Point(114, 70)
        Me.txtDescpLine.Multiline = True
        Me.txtDescpLine.Name = "txtDescpLine"
        Me.txtDescpLine.Size = New System.Drawing.Size(783, 49)
        Me.txtDescpLine.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Descripcion:"
        '
        'cbxStreets
        '
        Me.cbxStreets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStreets.FormattingEnabled = True
        Me.cbxStreets.Location = New System.Drawing.Point(114, 43)
        Me.cbxStreets.Name = "cbxStreets"
        Me.cbxStreets.Size = New System.Drawing.Size(260, 21)
        Me.cbxStreets.TabIndex = 9
        '
        'txtAddressLine
        '
        Me.txtAddressLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddressLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddressLine.Location = New System.Drawing.Point(114, 17)
        Me.txtAddressLine.Name = "txtAddressLine"
        Me.txtAddressLine.Size = New System.Drawing.Size(783, 20)
        Me.txtAddressLine.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Calle o Avenida:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Dirección:"
        '
        'tabpageUsers
        '
        Me.tabpageUsers.Controls.Add(Me.btnAddAccount)
        Me.tabpageUsers.Controls.Add(Me.btnNewAccount)
        Me.tabpageUsers.Controls.Add(Me.dtgUserLine)
        Me.tabpageUsers.Location = New System.Drawing.Point(4, 22)
        Me.tabpageUsers.Name = "tabpageUsers"
        Me.tabpageUsers.Padding = New System.Windows.Forms.Padding(20)
        Me.tabpageUsers.Size = New System.Drawing.Size(920, 429)
        Me.tabpageUsers.TabIndex = 2
        Me.tabpageUsers.Text = "CUENTAS ASOCIADAS"
        Me.tabpageUsers.UseVisualStyleBackColor = True
        '
        'btnAddAccount
        '
        Me.btnAddAccount.Image = Global.JASS_APP.My.Resources.Resources.general_ledger_32
        Me.btnAddAccount.Location = New System.Drawing.Point(169, 23)
        Me.btnAddAccount.Name = "btnAddAccount"
        Me.btnAddAccount.Size = New System.Drawing.Size(140, 48)
        Me.btnAddAccount.TabIndex = 2
        Me.btnAddAccount.Text = "Agregar una cuenta existente"
        Me.btnAddAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnAddAccount.UseVisualStyleBackColor = True
        '
        'btnNewAccount
        '
        Me.btnNewAccount.Image = Global.JASS_APP.My.Resources.Resources.new_contact_32
        Me.btnNewAccount.Location = New System.Drawing.Point(23, 23)
        Me.btnNewAccount.Name = "btnNewAccount"
        Me.btnNewAccount.Size = New System.Drawing.Size(140, 48)
        Me.btnNewAccount.TabIndex = 1
        Me.btnNewAccount.Text = "Nuevo Cuenta"
        Me.btnNewAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewAccount.UseVisualStyleBackColor = True
        '
        'dtgUserLine
        '
        Me.dtgUserLine.AllowUserToAddRows = False
        Me.dtgUserLine.AllowUserToDeleteRows = False
        Me.dtgUserLine.AllowUserToResizeColumns = False
        Me.dtgUserLine.AllowUserToResizeRows = False
        Me.dtgUserLine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgUserLine.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgUserLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgUserLine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmCodUser, Me.clmCodLine, Me.clmCodRate, Me.clmAccount, Me.clmNames, Me.clmSurnames, Me.clmTypeUser, Me.clmDoc, Me.clmHolder, Me.clmRate, Me.clmEdit, Me.clmDelete})
        Me.dtgUserLine.Location = New System.Drawing.Point(23, 86)
        Me.dtgUserLine.Name = "dtgUserLine"
        Me.dtgUserLine.ReadOnly = True
        Me.dtgUserLine.RowHeadersVisible = False
        Me.dtgUserLine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgUserLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgUserLine.Size = New System.Drawing.Size(874, 320)
        Me.dtgUserLine.TabIndex = 5
        '
        'clmCodUser
        '
        Me.clmCodUser.HeaderText = "Codigo de usuario"
        Me.clmCodUser.Name = "clmCodUser"
        Me.clmCodUser.ReadOnly = True
        Me.clmCodUser.Visible = False
        '
        'clmCodLine
        '
        Me.clmCodLine.HeaderText = "Codigo de linea"
        Me.clmCodLine.Name = "clmCodLine"
        Me.clmCodLine.ReadOnly = True
        Me.clmCodLine.Visible = False
        '
        'clmCodRate
        '
        Me.clmCodRate.HeaderText = "Codigo de Tarifa"
        Me.clmCodRate.Name = "clmCodRate"
        Me.clmCodRate.ReadOnly = True
        Me.clmCodRate.Visible = False
        '
        'clmAccount
        '
        Me.clmAccount.HeaderText = "Cod. Cuenta"
        Me.clmAccount.Name = "clmAccount"
        Me.clmAccount.ReadOnly = True
        '
        'clmNames
        '
        Me.clmNames.FillWeight = 200.0!
        Me.clmNames.HeaderText = "Nombre(s) o Razon social"
        Me.clmNames.Name = "clmNames"
        Me.clmNames.ReadOnly = True
        '
        'clmSurnames
        '
        Me.clmSurnames.HeaderText = "Apellido(s)"
        Me.clmSurnames.Name = "clmSurnames"
        Me.clmSurnames.ReadOnly = True
        '
        'clmTypeUser
        '
        Me.clmTypeUser.HeaderText = "Tipo de Usuario"
        Me.clmTypeUser.Name = "clmTypeUser"
        Me.clmTypeUser.ReadOnly = True
        '
        'clmDoc
        '
        Me.clmDoc.HeaderText = "Doc. de identidad"
        Me.clmDoc.Name = "clmDoc"
        Me.clmDoc.ReadOnly = True
        '
        'clmHolder
        '
        Me.clmHolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmHolder.FillWeight = 50.0!
        Me.clmHolder.HeaderText = "Titular"
        Me.clmHolder.Name = "clmHolder"
        Me.clmHolder.ReadOnly = True
        Me.clmHolder.Width = 50
        '
        'clmRate
        '
        Me.clmRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmRate.FillWeight = 120.0!
        Me.clmRate.HeaderText = "Tarifa"
        Me.clmRate.Name = "clmRate"
        Me.clmRate.ReadOnly = True
        Me.clmRate.Width = 120
        '
        'clmEdit
        '
        Me.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmEdit.FillWeight = 75.0!
        Me.clmEdit.HeaderText = ""
        Me.clmEdit.Name = "clmEdit"
        Me.clmEdit.ReadOnly = True
        Me.clmEdit.Text = "Editar"
        Me.clmEdit.UseColumnTextForButtonValue = True
        Me.clmEdit.Width = 75
        '
        'clmDelete
        '
        Me.clmDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmDelete.FillWeight = 75.0!
        Me.clmDelete.HeaderText = ""
        Me.clmDelete.Name = "clmDelete"
        Me.clmDelete.ReadOnly = True
        Me.clmDelete.Text = "Quitar"
        Me.clmDelete.UseColumnTextForButtonValue = True
        Me.clmDelete.Width = 75
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtDateUpdated)
        Me.Panel1.Controls.Add(Me.txtDateCreated)
        Me.Panel1.Controls.Add(Me.txtNameLine)
        Me.Panel1.Controls.Add(Me.txtCodLine)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel1.Size = New System.Drawing.Size(928, 94)
        Me.Panel1.TabIndex = 1
        '
        'txtDateUpdated
        '
        Me.txtDateUpdated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateUpdated.Location = New System.Drawing.Point(779, 41)
        Me.txtDateUpdated.Name = "txtDateUpdated"
        Me.txtDateUpdated.ReadOnly = True
        Me.txtDateUpdated.Size = New System.Drawing.Size(136, 22)
        Me.txtDateUpdated.TabIndex = 7
        Me.txtDateUpdated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateCreated.Location = New System.Drawing.Point(779, 13)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.Size = New System.Drawing.Size(136, 22)
        Me.txtDateCreated.TabIndex = 6
        Me.txtDateCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNameLine
        '
        Me.txtNameLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameLine.Location = New System.Drawing.Point(137, 41)
        Me.txtNameLine.Name = "txtNameLine"
        Me.txtNameLine.Size = New System.Drawing.Size(260, 22)
        Me.txtNameLine.TabIndex = 5
        '
        'txtCodLine
        '
        Me.txtCodLine.Location = New System.Drawing.Point(137, 13)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(180, 22)
        Me.txtCodLine.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(653, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Actualizado"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(653, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de creación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre de la linea"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código de la linea"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tabDataLine, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(934, 661)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 564)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(928, 94)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(467, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(458, 88)
        Me.Panel3.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSave.Location = New System.Drawing.Point(143, 29)
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
        Me.btnCancel.Location = New System.Drawing.Point(299, 29)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 50)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditLine
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(934, 661)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(800, 700)
        Me.Name = "frmEditLine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Linea de servicio"
        Me.tabDataLine.ResumeLayout(False)
        Me.tabpageDataLine.ResumeLayout(False)
        Me.tabpageDataLine.PerformLayout()
        Me.tabpageUsers.ResumeLayout(False)
        CType(Me.dtgUserLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabDataLine As TabControl
    Friend WithEvents tabpageDataLine As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtNameLine As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Private WithEvents txtDateUpdated As TextBox
    Private WithEvents txtDateCreated As TextBox
    Private WithEvents txtCodLine As TextBox
    Friend WithEvents tabpageUsers As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAddressLine As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxStreets As ComboBox
    Friend WithEvents txtDescpLine As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpInstallDate As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents dtgUserLine As DataGridView
    Friend WithEvents btnAddAccount As Button
    Friend WithEvents btnNewAccount As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents clmCodUser As DataGridViewTextBoxColumn
    Friend WithEvents clmCodLine As DataGridViewTextBoxColumn
    Friend WithEvents clmCodRate As DataGridViewTextBoxColumn
    Friend WithEvents clmAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmNames As DataGridViewTextBoxColumn
    Friend WithEvents clmSurnames As DataGridViewTextBoxColumn
    Friend WithEvents clmTypeUser As DataGridViewTextBoxColumn
    Friend WithEvents clmDoc As DataGridViewTextBoxColumn
    Friend WithEvents clmHolder As DataGridViewCheckBoxColumn
    Friend WithEvents clmRate As DataGridViewTextBoxColumn
    Friend WithEvents clmEdit As DataGridViewButtonColumn
    Friend WithEvents clmDelete As DataGridViewButtonColumn
End Class
