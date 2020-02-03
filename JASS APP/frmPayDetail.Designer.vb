<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayDetail
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCanceled = New System.Windows.Forms.Button()
        Me.dtgDetail = New System.Windows.Forms.DataGridView()
        Me.clmIdPay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAccountDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAmountCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNumReceipt = New System.Windows.Forms.TextBox()
        Me.txtCollector = New System.Windows.Forms.TextBox()
        Me.txtPayer = New System.Windows.Forms.TextBox()
        CType(Me.dtgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(367, 236)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Cerrar"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCanceled
        '
        Me.btnCanceled.Location = New System.Drawing.Point(12, 236)
        Me.btnCanceled.Name = "btnCanceled"
        Me.btnCanceled.Size = New System.Drawing.Size(75, 23)
        Me.btnCanceled.TabIndex = 1
        Me.btnCanceled.Text = "Anular"
        Me.btnCanceled.UseVisualStyleBackColor = True
        '
        'dtgDetail
        '
        Me.dtgDetail.AllowUserToAddRows = False
        Me.dtgDetail.AllowUserToDeleteRows = False
        Me.dtgDetail.AllowUserToResizeColumns = False
        Me.dtgDetail.AllowUserToResizeRows = False
        Me.dtgDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdPay, Me.clmIdAccount, Me.clmAccountDetail, Me.clmCharge, Me.clmAmountCharge})
        Me.dtgDetail.Location = New System.Drawing.Point(12, 38)
        Me.dtgDetail.MultiSelect = False
        Me.dtgDetail.Name = "dtgDetail"
        Me.dtgDetail.ReadOnly = True
        Me.dtgDetail.RowHeadersVisible = False
        Me.dtgDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDetail.Size = New System.Drawing.Size(430, 150)
        Me.dtgDetail.TabIndex = 2
        '
        'clmIdPay
        '
        Me.clmIdPay.HeaderText = "Id Pago Detalle"
        Me.clmIdPay.Name = "clmIdPay"
        Me.clmIdPay.ReadOnly = True
        Me.clmIdPay.Visible = False
        '
        'clmIdAccount
        '
        Me.clmIdAccount.HeaderText = "Id Cuenta"
        Me.clmIdAccount.Name = "clmIdAccount"
        Me.clmIdAccount.ReadOnly = True
        Me.clmIdAccount.Visible = False
        '
        'clmAccountDetail
        '
        Me.clmAccountDetail.HeaderText = "Id Cuenta Detalle"
        Me.clmAccountDetail.Name = "clmAccountDetail"
        Me.clmAccountDetail.ReadOnly = True
        Me.clmAccountDetail.Visible = False
        '
        'clmCharge
        '
        Me.clmCharge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmCharge.HeaderText = "Cargo"
        Me.clmCharge.Name = "clmCharge"
        Me.clmCharge.ReadOnly = True
        '
        'clmAmountCharge
        '
        Me.clmAmountCharge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmAmountCharge.HeaderText = "Monto"
        Me.clmAmountCharge.Name = "clmAmountCharge"
        Me.clmAmountCharge.ReadOnly = True
        '
        'txtNumReceipt
        '
        Me.txtNumReceipt.Location = New System.Drawing.Point(12, 12)
        Me.txtNumReceipt.Name = "txtNumReceipt"
        Me.txtNumReceipt.ReadOnly = True
        Me.txtNumReceipt.Size = New System.Drawing.Size(150, 20)
        Me.txtNumReceipt.TabIndex = 3
        '
        'txtCollector
        '
        Me.txtCollector.Location = New System.Drawing.Point(168, 12)
        Me.txtCollector.Name = "txtCollector"
        Me.txtCollector.ReadOnly = True
        Me.txtCollector.Size = New System.Drawing.Size(274, 20)
        Me.txtCollector.TabIndex = 4
        '
        'txtPayer
        '
        Me.txtPayer.Location = New System.Drawing.Point(12, 194)
        Me.txtPayer.Name = "txtPayer"
        Me.txtPayer.ReadOnly = True
        Me.txtPayer.Size = New System.Drawing.Size(430, 20)
        Me.txtPayer.TabIndex = 5
        '
        'frmPayDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(454, 271)
        Me.Controls.Add(Me.txtPayer)
        Me.Controls.Add(Me.txtCollector)
        Me.Controls.Add(Me.txtNumReceipt)
        Me.Controls.Add(Me.dtgDetail)
        Me.Controls.Add(Me.btnCanceled)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.Name = "frmPayDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de recibo"
        CType(Me.dtgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents btnCanceled As Button
    Friend WithEvents dtgDetail As DataGridView
    Friend WithEvents clmIdPay As DataGridViewTextBoxColumn
    Friend WithEvents clmIdAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmAccountDetail As DataGridViewTextBoxColumn
    Friend WithEvents clmCharge As DataGridViewTextBoxColumn
    Friend WithEvents clmAmountCharge As DataGridViewTextBoxColumn
    Friend WithEvents txtNumReceipt As TextBox
    Friend WithEvents txtCollector As TextBox
    Friend WithEvents txtPayer As TextBox
End Class
