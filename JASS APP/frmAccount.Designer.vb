<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccount
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCodAccount = New System.Windows.Forms.TextBox()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDescRate = New System.Windows.Forms.TextBox()
        Me.txtPriceRate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxRates = New System.Windows.Forms.ComboBox()
        Me.tabDataAccount = New System.Windows.Forms.TabControl()
        Me.tabpageAcounts = New System.Windows.Forms.TabPage()
        Me.dtgAccountYear = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tabpageUsers = New System.Windows.Forms.TabPage()
        Me.btnFindUser = New System.Windows.Forms.Button()
        Me.dtgUsersAccount = New System.Windows.Forms.DataGridView()
        Me.btnNewUser = New System.Windows.Forms.Button()
        Me.txtDateUpdated = New System.Windows.Forms.TextBox()
        Me.txtDateCreated = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.clmIdUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDocNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTypeUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        Me.tabDataAccount.SuspendLayout()
        Me.tabpageAcounts.SuspendLayout()
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageUsers.SuspendLayout()
        CType(Me.dtgUsersAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodAccount
        '
        Me.txtCodAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodAccount.Location = New System.Drawing.Point(238, 12)
        Me.txtCodAccount.Name = "txtCodAccount"
        Me.txtCodAccount.ReadOnly = True
        Me.txtCodAccount.Size = New System.Drawing.Size(200, 22)
        Me.txtCodAccount.TabIndex = 2
        '
        'txtCodLine
        '
        Me.txtCodLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodLine.Location = New System.Drawing.Point(12, 12)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(220, 22)
        Me.txtCodLine.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtDescRate)
        Me.GroupBox1.Controls.Add(Me.txtPriceRate)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbxRates)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 104)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la tarifa del servicio"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 26)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Descripcion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de la tarifa:"
        '
        'txtDescRate
        '
        Me.txtDescRate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescRate.Location = New System.Drawing.Point(134, 46)
        Me.txtDescRate.Multiline = True
        Me.txtDescRate.Name = "txtDescRate"
        Me.txtDescRate.ReadOnly = True
        Me.txtDescRate.Size = New System.Drawing.Size(620, 52)
        Me.txtDescRate.TabIndex = 3
        Me.txtDescRate.TabStop = False
        '
        'txtPriceRate
        '
        Me.txtPriceRate.Location = New System.Drawing.Point(594, 21)
        Me.txtPriceRate.Name = "txtPriceRate"
        Me.txtPriceRate.ReadOnly = True
        Me.txtPriceRate.Size = New System.Drawing.Size(160, 20)
        Me.txtPriceRate.TabIndex = 2
        Me.txtPriceRate.TabStop = False
        Me.txtPriceRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(527, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Tarifa (S/.):"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Tipos de Tarifas:"
        '
        'cbxRates
        '
        Me.cbxRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRates.FormattingEnabled = True
        Me.cbxRates.Location = New System.Drawing.Point(134, 19)
        Me.cbxRates.Name = "cbxRates"
        Me.cbxRates.Size = New System.Drawing.Size(387, 21)
        Me.cbxRates.TabIndex = 1
        '
        'tabDataAccount
        '
        Me.tabDataAccount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDataAccount.Controls.Add(Me.tabpageAcounts)
        Me.tabDataAccount.Controls.Add(Me.tabpageUsers)
        Me.tabDataAccount.Location = New System.Drawing.Point(12, 176)
        Me.tabDataAccount.Name = "tabDataAccount"
        Me.tabDataAccount.SelectedIndex = 0
        Me.tabDataAccount.Size = New System.Drawing.Size(760, 417)
        Me.tabDataAccount.TabIndex = 4
        '
        'tabpageAcounts
        '
        Me.tabpageAcounts.Controls.Add(Me.dtgAccountYear)
        Me.tabpageAcounts.Location = New System.Drawing.Point(4, 22)
        Me.tabpageAcounts.Name = "tabpageAcounts"
        Me.tabpageAcounts.Padding = New System.Windows.Forms.Padding(5)
        Me.tabpageAcounts.Size = New System.Drawing.Size(752, 391)
        Me.tabpageAcounts.TabIndex = 0
        Me.tabpageAcounts.Text = "CUENTAS ANUALES"
        Me.tabpageAcounts.UseVisualStyleBackColor = True
        '
        'dtgAccountYear
        '
        Me.dtgAccountYear.AllowUserToAddRows = False
        Me.dtgAccountYear.AllowUserToDeleteRows = False
        Me.dtgAccountYear.AllowUserToResizeColumns = False
        Me.dtgAccountYear.AllowUserToResizeRows = False
        Me.dtgAccountYear.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccountYear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAccountYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccountYear.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.clmState, Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2})
        Me.dtgAccountYear.Location = New System.Drawing.Point(9, 50)
        Me.dtgAccountYear.Name = "dtgAccountYear"
        Me.dtgAccountYear.ReadOnly = True
        Me.dtgAccountYear.RowHeadersVisible = False
        Me.dtgAccountYear.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountYear.Size = New System.Drawing.Size(735, 333)
        Me.dtgAccountYear.TabIndex = 7
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Cod. Cuenta Linea"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Año"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Monto Total"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Saldo Total"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'clmState
        '
        Me.clmState.FillWeight = 70.0!
        Me.clmState.HeaderText = "Estado"
        Me.clmState.Name = "clmState"
        Me.clmState.ReadOnly = True
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewButtonColumn1.FillWeight = 75.0!
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "Reporte"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Width = 75
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewButtonColumn2.FillWeight = 75.0!
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Text = "Ver"
        Me.DataGridViewButtonColumn2.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn2.Width = 75
        '
        'tabpageUsers
        '
        Me.tabpageUsers.Controls.Add(Me.btnFindUser)
        Me.tabpageUsers.Controls.Add(Me.dtgUsersAccount)
        Me.tabpageUsers.Controls.Add(Me.btnNewUser)
        Me.tabpageUsers.Location = New System.Drawing.Point(4, 22)
        Me.tabpageUsers.Name = "tabpageUsers"
        Me.tabpageUsers.Padding = New System.Windows.Forms.Padding(20)
        Me.tabpageUsers.Size = New System.Drawing.Size(752, 391)
        Me.tabpageUsers.TabIndex = 1
        Me.tabpageUsers.Text = "USUARIOS ASOCIADOS A LA CUENTA"
        Me.tabpageUsers.UseVisualStyleBackColor = True
        '
        'btnFindUser
        '
        Me.btnFindUser.Image = Global.JASS_APP.My.Resources.Resources.find_user_male_32
        Me.btnFindUser.Location = New System.Drawing.Point(169, 23)
        Me.btnFindUser.Name = "btnFindUser"
        Me.btnFindUser.Size = New System.Drawing.Size(140, 48)
        Me.btnFindUser.TabIndex = 7
        Me.btnFindUser.Text = "Usuario existente"
        Me.btnFindUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFindUser.UseVisualStyleBackColor = True
        '
        'dtgUsersAccount
        '
        Me.dtgUsersAccount.AllowUserToAddRows = False
        Me.dtgUsersAccount.AllowUserToDeleteRows = False
        Me.dtgUsersAccount.AllowUserToResizeColumns = False
        Me.dtgUsersAccount.AllowUserToResizeRows = False
        Me.dtgUsersAccount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgUsersAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgUsersAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgUsersAccount.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdUser, Me.clmNames, Me.clmDocNum, Me.clmTypeUser, Me.clmEdit, Me.clmDelete})
        Me.dtgUsersAccount.Location = New System.Drawing.Point(23, 77)
        Me.dtgUsersAccount.Name = "dtgUsersAccount"
        Me.dtgUsersAccount.ReadOnly = True
        Me.dtgUsersAccount.RowHeadersVisible = False
        Me.dtgUsersAccount.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgUsersAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgUsersAccount.Size = New System.Drawing.Size(706, 291)
        Me.dtgUsersAccount.TabIndex = 6
        '
        'btnNewUser
        '
        Me.btnNewUser.Image = Global.JASS_APP.My.Resources.Resources.add_user_male_32
        Me.btnNewUser.Location = New System.Drawing.Point(23, 23)
        Me.btnNewUser.Name = "btnNewUser"
        Me.btnNewUser.Size = New System.Drawing.Size(140, 48)
        Me.btnNewUser.TabIndex = 1
        Me.btnNewUser.Text = "Nuevo Usuario"
        Me.btnNewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNewUser.UseVisualStyleBackColor = True
        '
        'txtDateUpdated
        '
        Me.txtDateUpdated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateUpdated.Location = New System.Drawing.Point(636, 40)
        Me.txtDateUpdated.Name = "txtDateUpdated"
        Me.txtDateUpdated.ReadOnly = True
        Me.txtDateUpdated.Size = New System.Drawing.Size(136, 20)
        Me.txtDateUpdated.TabIndex = 11
        Me.txtDateUpdated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateCreated.Location = New System.Drawing.Point(636, 12)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.Size = New System.Drawing.Size(136, 20)
        Me.txtDateCreated.TabIndex = 10
        Me.txtDateCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(510, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Actualizado"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(510, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fecha de creación"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSave.Location = New System.Drawing.Point(466, 599)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 50)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.JASS_APP.My.Resources.Resources.cancel_32
        Me.btnCancel.Location = New System.Drawing.Point(622, 599)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 50)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'clmIdUser
        '
        Me.clmIdUser.HeaderText = "Id de Usuario"
        Me.clmIdUser.Name = "clmIdUser"
        Me.clmIdUser.ReadOnly = True
        Me.clmIdUser.Visible = False
        '
        'clmNames
        '
        Me.clmNames.FillWeight = 200.0!
        Me.clmNames.HeaderText = "Nombre(s) o Razon social"
        Me.clmNames.Name = "clmNames"
        Me.clmNames.ReadOnly = True
        '
        'clmDocNum
        '
        Me.clmDocNum.HeaderText = "DNI o RUC"
        Me.clmDocNum.Name = "clmDocNum"
        Me.clmDocNum.ReadOnly = True
        '
        'clmTypeUser
        '
        Me.clmTypeUser.HeaderText = "Usuario"
        Me.clmTypeUser.Name = "clmTypeUser"
        Me.clmTypeUser.ReadOnly = True
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
        'frmAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 661)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtDateUpdated)
        Me.Controls.Add(Me.txtDateCreated)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tabDataAccount)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCodLine)
        Me.Controls.Add(Me.txtCodAccount)
        Me.Name = "frmAccount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta de Servicio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabDataAccount.ResumeLayout(False)
        Me.tabpageAcounts.ResumeLayout(False)
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageUsers.ResumeLayout(False)
        CType(Me.dtgUsersAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodAccount As TextBox
    Friend WithEvents txtCodLine As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtDescRate As TextBox
    Friend WithEvents txtPriceRate As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbxRates As ComboBox
    Friend WithEvents tabDataAccount As TabControl
    Friend WithEvents tabpageAcounts As TabPage
    Friend WithEvents tabpageUsers As TabPage
    Friend WithEvents btnNewUser As Button
    Friend WithEvents dtgUsersAccount As DataGridView
    Friend WithEvents dtgAccountYear As DataGridView
    Private WithEvents txtDateUpdated As TextBox
    Private WithEvents txtDateCreated As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents clmState As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnFindUser As Button
    Friend WithEvents clmIdUser As DataGridViewTextBoxColumn
    Friend WithEvents clmNames As DataGridViewTextBoxColumn
    Friend WithEvents clmDocNum As DataGridViewTextBoxColumn
    Friend WithEvents clmTypeUser As DataGridViewTextBoxColumn
    Friend WithEvents clmEdit As DataGridViewButtonColumn
    Friend WithEvents clmDelete As DataGridViewButtonColumn
End Class
