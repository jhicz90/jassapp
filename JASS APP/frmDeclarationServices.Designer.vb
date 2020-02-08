<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeclarationServices
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxYearRate = New System.Windows.Forms.ComboBox()
        Me.cbxCrit = New System.Windows.Forms.ComboBox()
        Me.chkOrder = New System.Windows.Forms.CheckBox()
        Me.dtgAccounts = New System.Windows.Forms.DataGridView()
        Me.clmIdLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYearRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodServiceLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmUsersAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmRateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMonths = New System.Windows.Forms.CheckBox()
        Me.cbxMonths = New System.Windows.Forms.ComboBox()
        Me.chkFillAccountsRate = New System.Windows.Forms.CheckBox()
        Me.btnLoadAccounts = New System.Windows.Forms.Button()
        Me.btnExportAccounts = New System.Windows.Forms.Button()
        Me.btnImportAccounts = New System.Windows.Forms.Button()
        Me.bgwServices = New System.ComponentModel.BackgroundWorker()
        Me.dialogSaveExcel = New System.Windows.Forms.SaveFileDialog()
        Me.dialogOpenExcel = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dtgAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año Tarifa:"
        '
        'cbxYearRate
        '
        Me.cbxYearRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxYearRate.FormattingEnabled = True
        Me.cbxYearRate.Location = New System.Drawing.Point(118, 19)
        Me.cbxYearRate.Name = "cbxYearRate"
        Me.cbxYearRate.Size = New System.Drawing.Size(120, 21)
        Me.cbxYearRate.TabIndex = 1
        '
        'cbxCrit
        '
        Me.cbxCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCrit.Enabled = False
        Me.cbxCrit.FormattingEnabled = True
        Me.cbxCrit.Items.AddRange(New Object() {"Calle o sector", "Nombre de usuario", "Año de registro"})
        Me.cbxCrit.Location = New System.Drawing.Point(368, 19)
        Me.cbxCrit.Name = "cbxCrit"
        Me.cbxCrit.Size = New System.Drawing.Size(120, 21)
        Me.cbxCrit.TabIndex = 3
        '
        'chkOrder
        '
        Me.chkOrder.AutoSize = True
        Me.chkOrder.Location = New System.Drawing.Point(256, 21)
        Me.chkOrder.Name = "chkOrder"
        Me.chkOrder.Size = New System.Drawing.Size(88, 17)
        Me.chkOrder.TabIndex = 4
        Me.chkOrder.Text = "Ordernar por:"
        Me.chkOrder.UseVisualStyleBackColor = True
        '
        'dtgAccounts
        '
        Me.dtgAccounts.AllowUserToAddRows = False
        Me.dtgAccounts.AllowUserToDeleteRows = False
        Me.dtgAccounts.AllowUserToResizeColumns = False
        Me.dtgAccounts.AllowUserToResizeRows = False
        Me.dtgAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dtgAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdLine, Me.clmIdAccount, Me.clmYearRate, Me.clmIdRate, Me.clmCodServiceLine, Me.clmCodAccount, Me.clmSector, Me.clmUsersAccount, Me.clmRateName, Me.clmYear, Me.clmEdit})
        Me.dtgAccounts.Location = New System.Drawing.Point(12, 145)
        Me.dtgAccounts.MultiSelect = False
        Me.dtgAccounts.Name = "dtgAccounts"
        Me.dtgAccounts.ReadOnly = True
        Me.dtgAccounts.RowHeadersVisible = False
        Me.dtgAccounts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccounts.Size = New System.Drawing.Size(810, 304)
        Me.dtgAccounts.TabIndex = 6
        '
        'clmIdLine
        '
        Me.clmIdLine.HeaderText = "Id de Servicio de linea"
        Me.clmIdLine.Name = "clmIdLine"
        Me.clmIdLine.ReadOnly = True
        Me.clmIdLine.Visible = False
        '
        'clmIdAccount
        '
        Me.clmIdAccount.HeaderText = "Id de Cuenta"
        Me.clmIdAccount.Name = "clmIdAccount"
        Me.clmIdAccount.ReadOnly = True
        Me.clmIdAccount.Visible = False
        '
        'clmYearRate
        '
        Me.clmYearRate.HeaderText = "Id de Año tarifa"
        Me.clmYearRate.Name = "clmYearRate"
        Me.clmYearRate.ReadOnly = True
        Me.clmYearRate.Visible = False
        '
        'clmIdRate
        '
        Me.clmIdRate.HeaderText = "Id de Tarifa"
        Me.clmIdRate.Name = "clmIdRate"
        Me.clmIdRate.ReadOnly = True
        Me.clmIdRate.Visible = False
        '
        'clmCodServiceLine
        '
        Me.clmCodServiceLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmCodServiceLine.FillWeight = 150.0!
        Me.clmCodServiceLine.HeaderText = "Cod. de Servicio"
        Me.clmCodServiceLine.Name = "clmCodServiceLine"
        Me.clmCodServiceLine.ReadOnly = True
        Me.clmCodServiceLine.Width = 150
        '
        'clmCodAccount
        '
        Me.clmCodAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmCodAccount.FillWeight = 150.0!
        Me.clmCodAccount.HeaderText = "Cod. de Cuenta"
        Me.clmCodAccount.Name = "clmCodAccount"
        Me.clmCodAccount.ReadOnly = True
        Me.clmCodAccount.Width = 150
        '
        'clmSector
        '
        Me.clmSector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmSector.FillWeight = 125.0!
        Me.clmSector.HeaderText = "Sector"
        Me.clmSector.Name = "clmSector"
        Me.clmSector.ReadOnly = True
        Me.clmSector.Width = 125
        '
        'clmUsersAccount
        '
        Me.clmUsersAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmUsersAccount.FillWeight = 300.0!
        Me.clmUsersAccount.HeaderText = "Usuarios de la cuenta"
        Me.clmUsersAccount.Name = "clmUsersAccount"
        Me.clmUsersAccount.ReadOnly = True
        '
        'clmRateName
        '
        Me.clmRateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmRateName.FillWeight = 150.0!
        Me.clmRateName.HeaderText = "Tarifa"
        Me.clmRateName.Name = "clmRateName"
        Me.clmRateName.ReadOnly = True
        Me.clmRateName.Width = 150
        '
        'clmYear
        '
        Me.clmYear.FillWeight = 50.0!
        Me.clmYear.HeaderText = "Año"
        Me.clmYear.Name = "clmYear"
        Me.clmYear.ReadOnly = True
        '
        'clmEdit
        '
        Me.clmEdit.HeaderText = ""
        Me.clmEdit.Name = "clmEdit"
        Me.clmEdit.ReadOnly = True
        Me.clmEdit.UseColumnTextForButtonValue = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMonths)
        Me.GroupBox1.Controls.Add(Me.cbxMonths)
        Me.GroupBox1.Controls.Add(Me.chkFillAccountsRate)
        Me.GroupBox1.Controls.Add(Me.cbxYearRate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkOrder)
        Me.GroupBox1.Controls.Add(Me.cbxCrit)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 127)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tarifas y orden"
        '
        'chkMonths
        '
        Me.chkMonths.AutoSize = True
        Me.chkMonths.Location = New System.Drawing.Point(6, 48)
        Me.chkMonths.Name = "chkMonths"
        Me.chkMonths.Size = New System.Drawing.Size(86, 17)
        Me.chkMonths.TabIndex = 7
        Me.chkMonths.Text = "Asignar mes:"
        Me.chkMonths.UseVisualStyleBackColor = True
        '
        'cbxMonths
        '
        Me.cbxMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMonths.Enabled = False
        Me.cbxMonths.FormattingEnabled = True
        Me.cbxMonths.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbxMonths.Location = New System.Drawing.Point(118, 46)
        Me.cbxMonths.Name = "cbxMonths"
        Me.cbxMonths.Size = New System.Drawing.Size(120, 21)
        Me.cbxMonths.TabIndex = 6
        '
        'chkFillAccountsRate
        '
        Me.chkFillAccountsRate.Location = New System.Drawing.Point(6, 73)
        Me.chkFillAccountsRate.Name = "chkFillAccountsRate"
        Me.chkFillAccountsRate.Size = New System.Drawing.Size(338, 40)
        Me.chkFillAccountsRate.TabIndex = 5
        Me.chkFillAccountsRate.Text = "Llenar automaticamente los servicios conforme a la tarifa impuesta en la cuenta"
        Me.chkFillAccountsRate.UseVisualStyleBackColor = True
        '
        'btnLoadAccounts
        '
        Me.btnLoadAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadAccounts.Image = Global.JASS_APP.My.Resources.Resources.data_sheet_32
        Me.btnLoadAccounts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLoadAccounts.Location = New System.Drawing.Point(522, 12)
        Me.btnLoadAccounts.Name = "btnLoadAccounts"
        Me.btnLoadAccounts.Size = New System.Drawing.Size(96, 64)
        Me.btnLoadAccounts.TabIndex = 8
        Me.btnLoadAccounts.Text = "CARGAR"
        Me.btnLoadAccounts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadAccounts.UseVisualStyleBackColor = True
        '
        'btnExportAccounts
        '
        Me.btnExportAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportAccounts.Image = Global.JASS_APP.My.Resources.Resources.excel_export_32
        Me.btnExportAccounts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportAccounts.Location = New System.Drawing.Point(624, 12)
        Me.btnExportAccounts.Name = "btnExportAccounts"
        Me.btnExportAccounts.Size = New System.Drawing.Size(96, 64)
        Me.btnExportAccounts.TabIndex = 9
        Me.btnExportAccounts.Text = "EXPORTAR"
        Me.btnExportAccounts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportAccounts.UseVisualStyleBackColor = True
        '
        'btnImportAccounts
        '
        Me.btnImportAccounts.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImportAccounts.Image = Global.JASS_APP.My.Resources.Resources.excel_import_32
        Me.btnImportAccounts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImportAccounts.Location = New System.Drawing.Point(726, 12)
        Me.btnImportAccounts.Name = "btnImportAccounts"
        Me.btnImportAccounts.Size = New System.Drawing.Size(96, 64)
        Me.btnImportAccounts.TabIndex = 10
        Me.btnImportAccounts.Text = "IMPORTAR"
        Me.btnImportAccounts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportAccounts.UseVisualStyleBackColor = True
        '
        'bgwServices
        '
        '
        'frmDeclarationServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 461)
        Me.Controls.Add(Me.btnImportAccounts)
        Me.Controls.Add(Me.btnExportAccounts)
        Me.Controls.Add(Me.btnLoadAccounts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgAccounts)
        Me.MinimumSize = New System.Drawing.Size(850, 500)
        Me.Name = "frmDeclarationServices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Declaración de servicios"
        CType(Me.dtgAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbxYearRate As ComboBox
    Friend WithEvents cbxCrit As ComboBox
    Friend WithEvents chkOrder As CheckBox
    Friend WithEvents dtgAccounts As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLoadAccounts As Button
    Friend WithEvents btnExportAccounts As Button
    Friend WithEvents btnImportAccounts As Button
    Friend WithEvents chkFillAccountsRate As CheckBox
    Friend WithEvents bgwServices As System.ComponentModel.BackgroundWorker
    Friend WithEvents dialogSaveExcel As SaveFileDialog
    Friend WithEvents clmIdLine As DataGridViewTextBoxColumn
    Friend WithEvents clmIdAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmYearRate As DataGridViewTextBoxColumn
    Friend WithEvents clmIdRate As DataGridViewTextBoxColumn
    Friend WithEvents clmCodServiceLine As DataGridViewTextBoxColumn
    Friend WithEvents clmCodAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmSector As DataGridViewTextBoxColumn
    Friend WithEvents clmUsersAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmRateName As DataGridViewTextBoxColumn
    Friend WithEvents clmYear As DataGridViewTextBoxColumn
    Friend WithEvents clmEdit As DataGridViewButtonColumn
    Friend WithEvents chkMonths As CheckBox
    Friend WithEvents cbxMonths As ComboBox
    Friend WithEvents dialogOpenExcel As OpenFileDialog
End Class
