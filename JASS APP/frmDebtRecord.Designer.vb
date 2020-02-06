<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebtRecord
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lsxUsersInAccount = New System.Windows.Forms.ListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNameLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodAccount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAddDebtDetail = New System.Windows.Forms.Button()
        Me.btnAddYear = New System.Windows.Forms.Button()
        Me.dtgAccountYear = New System.Windows.Forms.DataGridView()
        Me.clmIdAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayedTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEdit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lsxUsersInAccount)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtNameLine)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCodAccount)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnFind)
        Me.GroupBox1.Controls.Add(Me.txtCodLine)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(780, 113)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la linea de servicio y cuentas"
        '
        'lsxUsersInAccount
        '
        Me.lsxUsersInAccount.FormattingEnabled = True
        Me.lsxUsersInAccount.Location = New System.Drawing.Point(438, 42)
        Me.lsxUsersInAccount.Name = "lsxUsersInAccount"
        Me.lsxUsersInAccount.Size = New System.Drawing.Size(336, 56)
        Me.lsxUsersInAccount.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(435, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Usuarios asociados a cuenta"
        '
        'txtNameLine
        '
        Me.txtNameLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameLine.Location = New System.Drawing.Point(116, 49)
        Me.txtNameLine.Name = "txtNameLine"
        Me.txtNameLine.ReadOnly = True
        Me.txtNameLine.Size = New System.Drawing.Size(260, 20)
        Me.txtNameLine.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nombre de la linea"
        '
        'txtCodAccount
        '
        Me.txtCodAccount.Location = New System.Drawing.Point(116, 75)
        Me.txtCodAccount.Name = "txtCodAccount"
        Me.txtCodAccount.ReadOnly = True
        Me.txtCodAccount.Size = New System.Drawing.Size(260, 20)
        Me.txtCodAccount.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Código de cuenta"
        '
        'btnFind
        '
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Image = Global.JASS_APP.My.Resources.Resources.search_16
        Me.btnFind.Location = New System.Drawing.Point(375, 23)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(24, 20)
        Me.btnFind.TabIndex = 1
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtCodLine
        '
        Me.txtCodLine.Location = New System.Drawing.Point(116, 23)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(260, 20)
        Me.txtCodLine.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Linea de servicio:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddDebtDetail)
        Me.GroupBox2.Controls.Add(Me.btnAddYear)
        Me.GroupBox2.Controls.Add(Me.dtgAccountYear)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(780, 418)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de las deudas"
        '
        'btnAddDebtDetail
        '
        Me.btnAddDebtDetail.Image = Global.JASS_APP.My.Resources.Resources.event_32
        Me.btnAddDebtDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddDebtDetail.Location = New System.Drawing.Point(152, 19)
        Me.btnAddDebtDetail.Name = "btnAddDebtDetail"
        Me.btnAddDebtDetail.Size = New System.Drawing.Size(200, 48)
        Me.btnAddDebtDetail.TabIndex = 7
        Me.btnAddDebtDetail.Text = "GENERAR DEUDA DETALLE"
        Me.btnAddDebtDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddDebtDetail.UseVisualStyleBackColor = True
        '
        'btnAddYear
        '
        Me.btnAddYear.Image = Global.JASS_APP.My.Resources.Resources.plus_1_year_32
        Me.btnAddYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddYear.Location = New System.Drawing.Point(6, 19)
        Me.btnAddYear.Name = "btnAddYear"
        Me.btnAddYear.Size = New System.Drawing.Size(140, 48)
        Me.btnAddYear.TabIndex = 6
        Me.btnAddYear.Text = "GENERAR AÑO"
        Me.btnAddYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddYear.UseVisualStyleBackColor = True
        '
        'dtgAccountYear
        '
        Me.dtgAccountYear.AllowUserToAddRows = False
        Me.dtgAccountYear.AllowUserToDeleteRows = False
        Me.dtgAccountYear.AllowUserToResizeColumns = False
        Me.dtgAccountYear.AllowUserToResizeRows = False
        Me.dtgAccountYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccountYear.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAccountYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccountYear.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdAccount, Me.clmYear, Me.clmMontoTotal, Me.clmPayedTotal, Me.clmSaldoTotal, Me.clmEstado, Me.clmEdit})
        Me.dtgAccountYear.Location = New System.Drawing.Point(6, 73)
        Me.dtgAccountYear.MultiSelect = False
        Me.dtgAccountYear.Name = "dtgAccountYear"
        Me.dtgAccountYear.ReadOnly = True
        Me.dtgAccountYear.RowHeadersVisible = False
        Me.dtgAccountYear.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountYear.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgAccountYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountYear.Size = New System.Drawing.Size(768, 339)
        Me.dtgAccountYear.TabIndex = 5
        '
        'clmIdAccount
        '
        Me.clmIdAccount.HeaderText = "Id de Cuenta"
        Me.clmIdAccount.Name = "clmIdAccount"
        Me.clmIdAccount.ReadOnly = True
        Me.clmIdAccount.Visible = False
        '
        'clmYear
        '
        Me.clmYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmYear.HeaderText = "Año"
        Me.clmYear.Name = "clmYear"
        Me.clmYear.ReadOnly = True
        Me.clmYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmMontoTotal
        '
        Me.clmMontoTotal.HeaderText = "Monto Total"
        Me.clmMontoTotal.Name = "clmMontoTotal"
        Me.clmMontoTotal.ReadOnly = True
        Me.clmMontoTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmPayedTotal
        '
        Me.clmPayedTotal.HeaderText = "Pagado"
        Me.clmPayedTotal.Name = "clmPayedTotal"
        Me.clmPayedTotal.ReadOnly = True
        Me.clmPayedTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmSaldoTotal
        '
        Me.clmSaldoTotal.HeaderText = "Saldo Total"
        Me.clmSaldoTotal.Name = "clmSaldoTotal"
        Me.clmSaldoTotal.ReadOnly = True
        Me.clmSaldoTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmEstado
        '
        Me.clmEstado.HeaderText = "Estado"
        Me.clmEstado.Name = "clmEstado"
        Me.clmEstado.ReadOnly = True
        Me.clmEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmEdit
        '
        Me.clmEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmEdit.HeaderText = ""
        Me.clmEdit.Name = "clmEdit"
        Me.clmEdit.ReadOnly = True
        Me.clmEdit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.clmEdit.Text = "Editar"
        Me.clmEdit.UseColumnTextForButtonValue = True
        '
        'frmDebtRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 561)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDebtRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de deudas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFind As Button
    Private WithEvents txtCodLine As TextBox
    Private WithEvents txtCodAccount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNameLine As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lsxUsersInAccount As ListBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtgAccountYear As DataGridView
    Friend WithEvents clmIdAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmYear As DataGridViewTextBoxColumn
    Friend WithEvents clmMontoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmPayedTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmEstado As DataGridViewTextBoxColumn
    Friend WithEvents clmEdit As DataGridViewButtonColumn
    Friend WithEvents btnAddYear As Button
    Friend WithEvents btnAddDebtDetail As Button
End Class
