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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLoadAccounts = New System.Windows.Forms.Button()
        Me.btnExportAccounts = New System.Windows.Forms.Button()
        Me.btnImportAccounts = New System.Windows.Forms.Button()
        CType(Me.dtgAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tarifa:"
        '
        'cbxYearRate
        '
        Me.cbxYearRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxYearRate.FormattingEnabled = True
        Me.cbxYearRate.Location = New System.Drawing.Point(118, 19)
        Me.cbxYearRate.Name = "cbxYearRate"
        Me.cbxYearRate.Size = New System.Drawing.Size(226, 21)
        Me.cbxYearRate.TabIndex = 1
        '
        'cbxCrit
        '
        Me.cbxCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCrit.Enabled = False
        Me.cbxCrit.FormattingEnabled = True
        Me.cbxCrit.Items.AddRange(New Object() {"Calle o sector", "Nombre de usuario", "Año de registro"})
        Me.cbxCrit.Location = New System.Drawing.Point(118, 46)
        Me.cbxCrit.Name = "cbxCrit"
        Me.cbxCrit.Size = New System.Drawing.Size(226, 21)
        Me.cbxCrit.TabIndex = 3
        '
        'chkOrder
        '
        Me.chkOrder.AutoSize = True
        Me.chkOrder.Location = New System.Drawing.Point(6, 48)
        Me.chkOrder.Name = "chkOrder"
        Me.chkOrder.Size = New System.Drawing.Size(88, 17)
        Me.chkOrder.TabIndex = 4
        Me.chkOrder.Text = "Ordernar por:"
        Me.chkOrder.UseVisualStyleBackColor = True
        '
        'dtgAccounts
        '
        Me.dtgAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccounts.Location = New System.Drawing.Point(12, 97)
        Me.dtgAccounts.Name = "dtgAccounts"
        Me.dtgAccounts.Size = New System.Drawing.Size(810, 452)
        Me.dtgAccounts.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxYearRate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkOrder)
        Me.GroupBox1.Controls.Add(Me.cbxCrit)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 79)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tarifas y orden"
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
        'frmDeclarationServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 561)
        Me.Controls.Add(Me.btnImportAccounts)
        Me.Controls.Add(Me.btnExportAccounts)
        Me.Controls.Add(Me.btnLoadAccounts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgAccounts)
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
End Class
