<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectDetail
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
        Me.txtNameLine = New System.Windows.Forms.TextBox()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgAccountYear = New System.Windows.Forms.DataGridView()
        Me.grpYearDetail = New System.Windows.Forms.GroupBox()
        Me.dtgAccountMounth = New System.Windows.Forms.DataGridView()
        Me.clmYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmOpciones = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.clmOpcionMes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPagadoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDebitAccount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkDebitUse = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMountPay = New System.Windows.Forms.TextBox()
        Me.btnPay = New System.Windows.Forms.Button()
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpYearDetail.SuspendLayout()
        CType(Me.dtgAccountMounth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNameLine
        '
        Me.txtNameLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameLine.Location = New System.Drawing.Point(527, 12)
        Me.txtNameLine.Name = "txtNameLine"
        Me.txtNameLine.ReadOnly = True
        Me.txtNameLine.Size = New System.Drawing.Size(260, 20)
        Me.txtNameLine.TabIndex = 9
        '
        'txtCodLine
        '
        Me.txtCodLine.Location = New System.Drawing.Point(109, 12)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(180, 20)
        Me.txtCodLine.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(426, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre de la linea"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Código de la linea"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(527, 38)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(260, 20)
        Me.TextBox1.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Nombre de la cuenta"
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
        Me.dtgAccountYear.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmYear, Me.clmMontoTotal, Me.clmSaldoTotal, Me.clmEstado, Me.clmOpciones})
        Me.dtgAccountYear.Location = New System.Drawing.Point(12, 64)
        Me.dtgAccountYear.Name = "dtgAccountYear"
        Me.dtgAccountYear.ReadOnly = True
        Me.dtgAccountYear.RowHeadersVisible = False
        Me.dtgAccountYear.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountYear.Size = New System.Drawing.Size(775, 150)
        Me.dtgAccountYear.TabIndex = 12
        '
        'grpYearDetail
        '
        Me.grpYearDetail.Controls.Add(Me.btnPay)
        Me.grpYearDetail.Controls.Add(Me.Label6)
        Me.grpYearDetail.Controls.Add(Me.txtMountPay)
        Me.grpYearDetail.Controls.Add(Me.Label5)
        Me.grpYearDetail.Controls.Add(Me.txtSaldo)
        Me.grpYearDetail.Controls.Add(Me.chkDebitUse)
        Me.grpYearDetail.Controls.Add(Me.Label4)
        Me.grpYearDetail.Controls.Add(Me.txtDebitAccount)
        Me.grpYearDetail.Controls.Add(Me.dtgAccountMounth)
        Me.grpYearDetail.Location = New System.Drawing.Point(12, 220)
        Me.grpYearDetail.Name = "grpYearDetail"
        Me.grpYearDetail.Size = New System.Drawing.Size(772, 229)
        Me.grpYearDetail.TabIndex = 13
        Me.grpYearDetail.TabStop = False
        Me.grpYearDetail.Text = "Datos de Año-Tarifa"
        '
        'dtgAccountMounth
        '
        Me.dtgAccountMounth.AllowUserToAddRows = False
        Me.dtgAccountMounth.AllowUserToDeleteRows = False
        Me.dtgAccountMounth.AllowUserToResizeColumns = False
        Me.dtgAccountMounth.AllowUserToResizeRows = False
        Me.dtgAccountMounth.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgAccountMounth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgAccountMounth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccountMounth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmOpcionMes, Me.clmMes, Me.clmMontoMes, Me.clmPagadoMes, Me.clmSaldoMes})
        Me.dtgAccountMounth.Location = New System.Drawing.Point(6, 19)
        Me.dtgAccountMounth.Name = "dtgAccountMounth"
        Me.dtgAccountMounth.ReadOnly = True
        Me.dtgAccountMounth.RowHeadersVisible = False
        Me.dtgAccountMounth.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountMounth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountMounth.Size = New System.Drawing.Size(452, 204)
        Me.dtgAccountMounth.TabIndex = 13
        '
        'clmYear
        '
        Me.clmYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmYear.HeaderText = "Año"
        Me.clmYear.Name = "clmYear"
        Me.clmYear.ReadOnly = True
        '
        'clmMontoTotal
        '
        Me.clmMontoTotal.HeaderText = "Monto Total"
        Me.clmMontoTotal.Name = "clmMontoTotal"
        Me.clmMontoTotal.ReadOnly = True
        '
        'clmSaldoTotal
        '
        Me.clmSaldoTotal.HeaderText = "Saldo Total"
        Me.clmSaldoTotal.Name = "clmSaldoTotal"
        Me.clmSaldoTotal.ReadOnly = True
        '
        'clmEstado
        '
        Me.clmEstado.HeaderText = "Estado"
        Me.clmEstado.Name = "clmEstado"
        Me.clmEstado.ReadOnly = True
        '
        'clmOpciones
        '
        Me.clmOpciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmOpciones.HeaderText = ""
        Me.clmOpciones.Name = "clmOpciones"
        Me.clmOpciones.ReadOnly = True
        '
        'clmOpcionMes
        '
        Me.clmOpcionMes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmOpcionMes.FillWeight = 50.0!
        Me.clmOpcionMes.HeaderText = ""
        Me.clmOpcionMes.Name = "clmOpcionMes"
        Me.clmOpcionMes.ReadOnly = True
        Me.clmOpcionMes.Width = 50
        '
        'clmMes
        '
        Me.clmMes.HeaderText = "Mes"
        Me.clmMes.Name = "clmMes"
        Me.clmMes.ReadOnly = True
        '
        'clmMontoMes
        '
        Me.clmMontoMes.HeaderText = "Monto"
        Me.clmMontoMes.Name = "clmMontoMes"
        Me.clmMontoMes.ReadOnly = True
        '
        'clmPagadoMes
        '
        Me.clmPagadoMes.HeaderText = "Pagado"
        Me.clmPagadoMes.Name = "clmPagadoMes"
        Me.clmPagadoMes.ReadOnly = True
        '
        'clmSaldoMes
        '
        Me.clmSaldoMes.HeaderText = "Saldo"
        Me.clmSaldoMes.Name = "clmSaldoMes"
        Me.clmSaldoMes.ReadOnly = True
        '
        'txtDebitAccount
        '
        Me.txtDebitAccount.Location = New System.Drawing.Point(668, 19)
        Me.txtDebitAccount.Name = "txtDebitAccount"
        Me.txtDebitAccount.ReadOnly = True
        Me.txtDebitAccount.Size = New System.Drawing.Size(98, 20)
        Me.txtDebitAccount.TabIndex = 14
        Me.txtDebitAccount.Text = "0.00"
        Me.txtDebitAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(561, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Debito de la Cuenta"
        '
        'chkDebitUse
        '
        Me.chkDebitUse.AutoSize = True
        Me.chkDebitUse.Location = New System.Drawing.Point(521, 45)
        Me.chkDebitUse.Name = "chkDebitUse"
        Me.chkDebitUse.Size = New System.Drawing.Size(245, 17)
        Me.chkDebitUse.TabIndex = 15
        Me.chkDebitUse.Text = "Usar el debito acumulado para pagar el saldo?"
        Me.chkDebitUse.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(561, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Saldo de la cuenta"
        '
        'txtSaldo
        '
        Me.txtSaldo.Location = New System.Drawing.Point(668, 68)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(98, 20)
        Me.txtSaldo.TabIndex = 17
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(561, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Monto a pagar"
        '
        'txtMountPay
        '
        Me.txtMountPay.Location = New System.Drawing.Point(668, 94)
        Me.txtMountPay.Name = "txtMountPay"
        Me.txtMountPay.ReadOnly = True
        Me.txtMountPay.Size = New System.Drawing.Size(98, 20)
        Me.txtMountPay.TabIndex = 19
        Me.txtMountPay.Text = "0.00"
        Me.txtMountPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPay
        '
        Me.btnPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPay.Image = Global.JASS_APP.My.Resources.Resources.refund_32
        Me.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPay.Location = New System.Drawing.Point(564, 187)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(202, 36)
        Me.btnPay.TabIndex = 20
        Me.btnPay.Text = "PAGAR"
        Me.btnPay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'frmCollectDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 461)
        Me.Controls.Add(Me.grpYearDetail)
        Me.Controls.Add(Me.dtgAccountYear)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNameLine)
        Me.Controls.Add(Me.txtCodLine)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmCollectDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta de Servicio"
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpYearDetail.ResumeLayout(False)
        Me.grpYearDetail.PerformLayout()
        CType(Me.dtgAccountMounth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNameLine As TextBox
    Private WithEvents txtCodLine As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtgAccountYear As DataGridView
    Friend WithEvents grpYearDetail As GroupBox
    Friend WithEvents clmYear As DataGridViewTextBoxColumn
    Friend WithEvents clmMontoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmEstado As DataGridViewTextBoxColumn
    Friend WithEvents clmOpciones As DataGridViewButtonColumn
    Friend WithEvents dtgAccountMounth As DataGridView
    Friend WithEvents clmOpcionMes As DataGridViewCheckBoxColumn
    Friend WithEvents clmMes As DataGridViewTextBoxColumn
    Friend WithEvents clmMontoMes As DataGridViewTextBoxColumn
    Friend WithEvents clmPagadoMes As DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoMes As DataGridViewTextBoxColumn
    Friend WithEvents chkDebitUse As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDebitAccount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMountPay As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents btnPay As Button
End Class
