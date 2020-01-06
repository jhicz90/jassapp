<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeePays
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
        Me.dtgAccountReceipts = New System.Windows.Forms.DataGridView()
        Me.dtgReceiptDetail = New System.Windows.Forms.DataGridView()
        Me.clmIdPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAccountYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAmountTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCollector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgAccountReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgReceiptDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgAccountReceipts
        '
        Me.dtgAccountReceipts.AllowUserToAddRows = False
        Me.dtgAccountReceipts.AllowUserToDeleteRows = False
        Me.dtgAccountReceipts.AllowUserToResizeColumns = False
        Me.dtgAccountReceipts.AllowUserToResizeRows = False
        Me.dtgAccountReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccountReceipts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccountReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdPay, Me.clmAccountYear, Me.clmCodPay, Me.clmAmountTotal, Me.clmPayer, Me.clmCollector, Me.clmPayCreated})
        Me.dtgAccountReceipts.Location = New System.Drawing.Point(12, 12)
        Me.dtgAccountReceipts.MultiSelect = False
        Me.dtgAccountReceipts.Name = "dtgAccountReceipts"
        Me.dtgAccountReceipts.ReadOnly = True
        Me.dtgAccountReceipts.RowHeadersVisible = False
        Me.dtgAccountReceipts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountReceipts.Size = New System.Drawing.Size(589, 387)
        Me.dtgAccountReceipts.TabIndex = 0
        '
        'dtgReceiptDetail
        '
        Me.dtgReceiptDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgReceiptDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgReceiptDetail.Location = New System.Drawing.Point(607, 149)
        Me.dtgReceiptDetail.Name = "dtgReceiptDetail"
        Me.dtgReceiptDetail.Size = New System.Drawing.Size(265, 250)
        Me.dtgReceiptDetail.TabIndex = 1
        '
        'clmIdPay
        '
        Me.clmIdPay.HeaderText = "Id Pago"
        Me.clmIdPay.Name = "clmIdPay"
        Me.clmIdPay.ReadOnly = True
        Me.clmIdPay.Visible = False
        '
        'clmAccountYear
        '
        Me.clmAccountYear.FillWeight = 50.0!
        Me.clmAccountYear.HeaderText = "Año"
        Me.clmAccountYear.Name = "clmAccountYear"
        Me.clmAccountYear.ReadOnly = True
        Me.clmAccountYear.Width = 50
        '
        'clmCodPay
        '
        Me.clmCodPay.FillWeight = 125.0!
        Me.clmCodPay.HeaderText = "Numero de recibo"
        Me.clmCodPay.Name = "clmCodPay"
        Me.clmCodPay.ReadOnly = True
        Me.clmCodPay.Width = 125
        '
        'clmAmountTotal
        '
        Me.clmAmountTotal.FillWeight = 115.0!
        Me.clmAmountTotal.HeaderText = "Monto pagado"
        Me.clmAmountTotal.Name = "clmAmountTotal"
        Me.clmAmountTotal.ReadOnly = True
        Me.clmAmountTotal.Width = 115
        '
        'clmPayer
        '
        Me.clmPayer.FillWeight = 75.0!
        Me.clmPayer.HeaderText = "Pagador"
        Me.clmPayer.Name = "clmPayer"
        Me.clmPayer.ReadOnly = True
        Me.clmPayer.Width = 75
        '
        'clmCollector
        '
        Me.clmCollector.FillWeight = 75.0!
        Me.clmCollector.HeaderText = "Cobrador"
        Me.clmCollector.Name = "clmCollector"
        Me.clmCollector.ReadOnly = True
        Me.clmCollector.Width = 75
        '
        'clmPayCreated
        '
        Me.clmPayCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmPayCreated.FillWeight = 75.0!
        Me.clmPayCreated.HeaderText = "Fecha de pago"
        Me.clmPayCreated.Name = "clmPayCreated"
        Me.clmPayCreated.ReadOnly = True
        '
        'frmSeePays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 411)
        Me.Controls.Add(Me.dtgReceiptDetail)
        Me.Controls.Add(Me.dtgAccountReceipts)
        Me.Name = "frmSeePays"
        Me.Text = "Historial de Pagos"
        CType(Me.dtgAccountReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgReceiptDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgAccountReceipts As DataGridView
    Friend WithEvents dtgReceiptDetail As DataGridView
    Friend WithEvents clmIdPay As DataGridViewTextBoxColumn
    Friend WithEvents clmAccountYear As DataGridViewTextBoxColumn
    Friend WithEvents clmCodPay As DataGridViewTextBoxColumn
    Friend WithEvents clmAmountTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmPayer As DataGridViewTextBoxColumn
    Friend WithEvents clmCollector As DataGridViewTextBoxColumn
    Friend WithEvents clmPayCreated As DataGridViewTextBoxColumn
End Class
