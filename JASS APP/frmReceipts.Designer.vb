<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceipts
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
        Me.btnCancelReceipt = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnFindUser = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudReceipt = New System.Windows.Forms.NumericUpDown()
        Me.dtgReceipts = New System.Windows.Forms.DataGridView()
        Me.clmIdPayment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAccountYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAmountTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCollector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDetail = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtNumReceipt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxSeeNumReceipts = New System.Windows.Forms.ComboBox()
        CType(Me.nudReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancelReceipt
        '
        Me.btnCancelReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelReceipt.Image = Global.JASS_APP.My.Resources.Resources.billdelete_32
        Me.btnCancelReceipt.Location = New System.Drawing.Point(566, 399)
        Me.btnCancelReceipt.Name = "btnCancelReceipt"
        Me.btnCancelReceipt.Size = New System.Drawing.Size(150, 50)
        Me.btnCancelReceipt.TabIndex = 5
        Me.btnCancelReceipt.Text = "&Anular Recibo"
        Me.btnCancelReceipt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelReceipt.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.JASS_APP.My.Resources.Resources.cancel_32
        Me.btnCancel.Location = New System.Drawing.Point(722, 399)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 50)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnFindUser
        '
        Me.btnFindUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindUser.Image = Global.JASS_APP.My.Resources.Resources.search_32
        Me.btnFindUser.Location = New System.Drawing.Point(12, 399)
        Me.btnFindUser.Name = "btnFindUser"
        Me.btnFindUser.Size = New System.Drawing.Size(80, 50)
        Me.btnFindUser.TabIndex = 4
        Me.btnFindUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Número de recibo"
        '
        'nudReceipt
        '
        Me.nudReceipt.Location = New System.Drawing.Point(123, 17)
        Me.nudReceipt.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudReceipt.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudReceipt.Name = "nudReceipt"
        Me.nudReceipt.Size = New System.Drawing.Size(120, 20)
        Me.nudReceipt.TabIndex = 0
        Me.nudReceipt.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'dtgReceipts
        '
        Me.dtgReceipts.AllowUserToAddRows = False
        Me.dtgReceipts.AllowUserToDeleteRows = False
        Me.dtgReceipts.AllowUserToResizeColumns = False
        Me.dtgReceipts.AllowUserToResizeRows = False
        Me.dtgReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgReceipts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdPayment, Me.clmIdAccount, Me.clmAccountYear, Me.clmCodPay, Me.clmState, Me.clmAmountTotal, Me.clmPayer, Me.clmCollector, Me.clmPayCreated, Me.clmDetail})
        Me.dtgReceipts.Location = New System.Drawing.Point(12, 43)
        Me.dtgReceipts.MultiSelect = False
        Me.dtgReceipts.Name = "dtgReceipts"
        Me.dtgReceipts.ReadOnly = True
        Me.dtgReceipts.RowHeadersVisible = False
        Me.dtgReceipts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgReceipts.Size = New System.Drawing.Size(860, 350)
        Me.dtgReceipts.TabIndex = 3
        '
        'clmIdPayment
        '
        Me.clmIdPayment.HeaderText = "Id Pago"
        Me.clmIdPayment.Name = "clmIdPayment"
        Me.clmIdPayment.ReadOnly = True
        Me.clmIdPayment.Visible = False
        '
        'clmIdAccount
        '
        Me.clmIdAccount.FillWeight = 120.0!
        Me.clmIdAccount.HeaderText = "Id de Cuenta"
        Me.clmIdAccount.Name = "clmIdAccount"
        Me.clmIdAccount.ReadOnly = True
        Me.clmIdAccount.Visible = False
        '
        'clmAccountYear
        '
        Me.clmAccountYear.FillWeight = 50.0!
        Me.clmAccountYear.HeaderText = "Año"
        Me.clmAccountYear.Name = "clmAccountYear"
        Me.clmAccountYear.ReadOnly = True
        '
        'clmCodPay
        '
        Me.clmCodPay.FillWeight = 120.0!
        Me.clmCodPay.HeaderText = "Numero de recibo"
        Me.clmCodPay.Name = "clmCodPay"
        Me.clmCodPay.ReadOnly = True
        '
        'clmState
        '
        Me.clmState.FillWeight = 125.0!
        Me.clmState.HeaderText = "Estado"
        Me.clmState.Name = "clmState"
        Me.clmState.ReadOnly = True
        '
        'clmAmountTotal
        '
        Me.clmAmountTotal.HeaderText = "Monto pagado"
        Me.clmAmountTotal.Name = "clmAmountTotal"
        Me.clmAmountTotal.ReadOnly = True
        '
        'clmPayer
        '
        Me.clmPayer.FillWeight = 150.0!
        Me.clmPayer.HeaderText = "Pagador"
        Me.clmPayer.Name = "clmPayer"
        Me.clmPayer.ReadOnly = True
        '
        'clmCollector
        '
        Me.clmCollector.FillWeight = 150.0!
        Me.clmCollector.HeaderText = "Cobrador"
        Me.clmCollector.Name = "clmCollector"
        Me.clmCollector.ReadOnly = True
        '
        'clmPayCreated
        '
        Me.clmPayCreated.HeaderText = "Fecha de pago"
        Me.clmPayCreated.Name = "clmPayCreated"
        Me.clmPayCreated.ReadOnly = True
        '
        'clmDetail
        '
        Me.clmDetail.HeaderText = ""
        Me.clmDetail.Name = "clmDetail"
        Me.clmDetail.ReadOnly = True
        Me.clmDetail.Text = "Detalle"
        Me.clmDetail.UseColumnTextForButtonValue = True
        '
        'txtNumReceipt
        '
        Me.txtNumReceipt.Location = New System.Drawing.Point(249, 17)
        Me.txtNumReceipt.Name = "txtNumReceipt"
        Me.txtNumReceipt.ReadOnly = True
        Me.txtNumReceipt.Size = New System.Drawing.Size(125, 20)
        Me.txtNumReceipt.TabIndex = 1
        Me.txtNumReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(387, 20)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ver"
        '
        'cbxSeeNumReceipts
        '
        Me.cbxSeeNumReceipts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSeeNumReceipts.FormattingEnabled = True
        Me.cbxSeeNumReceipts.Items.AddRange(New Object() {"10", "20", "30"})
        Me.cbxSeeNumReceipts.Location = New System.Drawing.Point(423, 16)
        Me.cbxSeeNumReceipts.Name = "cbxSeeNumReceipts"
        Me.cbxSeeNumReceipts.Size = New System.Drawing.Size(121, 21)
        Me.cbxSeeNumReceipts.TabIndex = 2
        '
        'frmReceipts
        '
        Me.AcceptButton = Me.btnCancelReceipt
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.cbxSeeNumReceipts)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumReceipt)
        Me.Controls.Add(Me.dtgReceipts)
        Me.Controls.Add(Me.nudReceipt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelReceipt)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnFindUser)
        Me.Name = "frmReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos"
        CType(Me.nudReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancelReceipt As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnFindUser As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents nudReceipt As NumericUpDown
    Friend WithEvents dtgReceipts As DataGridView
    Friend WithEvents txtNumReceipt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxSeeNumReceipts As ComboBox
    Friend WithEvents clmIdPayment As DataGridViewTextBoxColumn
    Friend WithEvents clmIdAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmAccountYear As DataGridViewTextBoxColumn
    Friend WithEvents clmCodPay As DataGridViewTextBoxColumn
    Friend WithEvents clmState As DataGridViewTextBoxColumn
    Friend WithEvents clmAmountTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmPayer As DataGridViewTextBoxColumn
    Friend WithEvents clmCollector As DataGridViewTextBoxColumn
    Friend WithEvents clmPayCreated As DataGridViewTextBoxColumn
    Friend WithEvents clmDetail As DataGridViewButtonColumn
End Class
