<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCollectDetail
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
        Me.txtNameLine = New System.Windows.Forms.TextBox()
        Me.txtCodLine = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodAccount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtgAccountYear = New System.Windows.Forms.DataGridView()
        Me.grpYearDetail = New System.Windows.Forms.GroupBox()
        Me.btnDebtRecord = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodNumReceipt = New System.Windows.Forms.TextBox()
        Me.btnClean = New System.Windows.Forms.Button()
        Me.chkChangingUse = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtChanging = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.btnDeposit = New System.Windows.Forms.Button()
        Me.btnSeePayments = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMountPay = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.chkDebitUse = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDebitAccount = New System.Windows.Forms.TextBox()
        Me.dtgAccountMounth = New System.Windows.Forms.DataGridView()
        Me.clmIdDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmIdAccountDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYearDetail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCodMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmOpcionMes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmCharge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPagadoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbxUsersInAccount = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.clmIdAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmMontoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPayedTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmOpciones = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dtgAccountYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpYearDetail.SuspendLayout()
        CType(Me.dtgAccountMounth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNameLine
        '
        Me.txtNameLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameLine.Location = New System.Drawing.Point(657, 12)
        Me.txtNameLine.Name = "txtNameLine"
        Me.txtNameLine.ReadOnly = True
        Me.txtNameLine.Size = New System.Drawing.Size(260, 20)
        Me.txtNameLine.TabIndex = 3
        '
        'txtCodLine
        '
        Me.txtCodLine.Location = New System.Drawing.Point(129, 12)
        Me.txtCodLine.Name = "txtCodLine"
        Me.txtCodLine.ReadOnly = True
        Me.txtCodLine.Size = New System.Drawing.Size(260, 20)
        Me.txtCodLine.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(556, 15)
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
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Linea de servicio"
        '
        'txtCodAccount
        '
        Me.txtCodAccount.Location = New System.Drawing.Point(129, 35)
        Me.txtCodAccount.Name = "txtCodAccount"
        Me.txtCodAccount.ReadOnly = True
        Me.txtCodAccount.Size = New System.Drawing.Size(260, 20)
        Me.txtCodAccount.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Código de cuenta"
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
        Me.dtgAccountYear.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdAccount, Me.clmYear, Me.clmMontoTotal, Me.clmPayedTotal, Me.clmSaldoTotal, Me.clmEstado, Me.clmOpciones})
        Me.dtgAccountYear.Location = New System.Drawing.Point(12, 64)
        Me.dtgAccountYear.MultiSelect = False
        Me.dtgAccountYear.Name = "dtgAccountYear"
        Me.dtgAccountYear.ReadOnly = True
        Me.dtgAccountYear.RowHeadersVisible = False
        Me.dtgAccountYear.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountYear.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgAccountYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountYear.Size = New System.Drawing.Size(905, 150)
        Me.dtgAccountYear.TabIndex = 4
        '
        'grpYearDetail
        '
        Me.grpYearDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpYearDetail.Controls.Add(Me.btnDebtRecord)
        Me.grpYearDetail.Controls.Add(Me.btnClose)
        Me.grpYearDetail.Controls.Add(Me.Label9)
        Me.grpYearDetail.Controls.Add(Me.txtCodNumReceipt)
        Me.grpYearDetail.Controls.Add(Me.btnClean)
        Me.grpYearDetail.Controls.Add(Me.chkChangingUse)
        Me.grpYearDetail.Controls.Add(Me.Label8)
        Me.grpYearDetail.Controls.Add(Me.txtChanging)
        Me.grpYearDetail.Controls.Add(Me.Label7)
        Me.grpYearDetail.Controls.Add(Me.txtCash)
        Me.grpYearDetail.Controls.Add(Me.btnDeposit)
        Me.grpYearDetail.Controls.Add(Me.btnSeePayments)
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
        Me.grpYearDetail.Size = New System.Drawing.Size(905, 479)
        Me.grpYearDetail.TabIndex = 5
        Me.grpYearDetail.TabStop = False
        Me.grpYearDetail.Text = "Datos de Año-Tarifa"
        '
        'btnDebtRecord
        '
        Me.btnDebtRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDebtRecord.Image = Global.JASS_APP.My.Resources.Resources.ledger_edit_32
        Me.btnDebtRecord.Location = New System.Drawing.Point(339, 391)
        Me.btnDebtRecord.Name = "btnDebtRecord"
        Me.btnDebtRecord.Size = New System.Drawing.Size(105, 82)
        Me.btnDebtRecord.TabIndex = 29
        Me.btnDebtRecord.Text = "REGISTRAR DEUDAS"
        Me.btnDebtRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDebtRecord.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Image = Global.JASS_APP.My.Resources.Resources.close_window_32
        Me.btnClose.Location = New System.Drawing.Point(613, 425)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 48)
        Me.btnClose.TabIndex = 28
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(632, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "N° de Recibo"
        '
        'txtCodNumReceipt
        '
        Me.txtCodNumReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCodNumReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodNumReceipt.Location = New System.Drawing.Point(739, 19)
        Me.txtCodNumReceipt.Name = "txtCodNumReceipt"
        Me.txtCodNumReceipt.ReadOnly = True
        Me.txtCodNumReceipt.Size = New System.Drawing.Size(160, 26)
        Me.txtCodNumReceipt.TabIndex = 26
        Me.txtCodNumReceipt.Text = "#"
        Me.txtCodNumReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClean
        '
        Me.btnClean.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClean.Image = Global.JASS_APP.My.Resources.Resources.clear_32
        Me.btnClean.Location = New System.Drawing.Point(6, 391)
        Me.btnClean.Name = "btnClean"
        Me.btnClean.Size = New System.Drawing.Size(105, 82)
        Me.btnClean.TabIndex = 10
        Me.btnClean.Text = "LIMPIAR"
        Me.btnClean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClean.UseVisualStyleBackColor = True
        '
        'chkChangingUse
        '
        Me.chkChangingUse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkChangingUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChangingUse.Location = New System.Drawing.Point(649, 287)
        Me.chkChangingUse.Name = "chkChangingUse"
        Me.chkChangingUse.Size = New System.Drawing.Size(250, 70)
        Me.chkChangingUse.TabIndex = 8
        Me.chkChangingUse.Text = "¿Usar el cambio sobrante como deposito a debito?"
        Me.chkChangingUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkChangingUse.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(729, 258)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 20)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Cambio"
        '
        'txtChanging
        '
        Me.txtChanging.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtChanging.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChanging.Location = New System.Drawing.Point(801, 255)
        Me.txtChanging.Name = "txtChanging"
        Me.txtChanging.ReadOnly = True
        Me.txtChanging.Size = New System.Drawing.Size(98, 26)
        Me.txtChanging.TabIndex = 7
        Me.txtChanging.Text = "0.00"
        Me.txtChanging.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(729, 226)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "Efectivo"
        '
        'txtCash
        '
        Me.txtCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.Location = New System.Drawing.Point(801, 223)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(98, 26)
        Me.txtCash.TabIndex = 6
        Me.txtCash.Text = "0.00"
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDeposit
        '
        Me.btnDeposit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeposit.Image = Global.JASS_APP.My.Resources.Resources.deposit_32
        Me.btnDeposit.Location = New System.Drawing.Point(117, 391)
        Me.btnDeposit.Name = "btnDeposit"
        Me.btnDeposit.Size = New System.Drawing.Size(105, 82)
        Me.btnDeposit.TabIndex = 11
        Me.btnDeposit.Text = "DEPOSITO A CUENTA"
        Me.btnDeposit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDeposit.UseVisualStyleBackColor = True
        '
        'btnSeePayments
        '
        Me.btnSeePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSeePayments.Image = Global.JASS_APP.My.Resources.Resources.cashbook_32
        Me.btnSeePayments.Location = New System.Drawing.Point(228, 391)
        Me.btnSeePayments.Name = "btnSeePayments"
        Me.btnSeePayments.Size = New System.Drawing.Size(105, 82)
        Me.btnSeePayments.TabIndex = 12
        Me.btnSeePayments.Text = "VER PAGOS REALIZADOS"
        Me.btnSeePayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSeePayments.UseVisualStyleBackColor = True
        '
        'btnPay
        '
        Me.btnPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPay.Image = Global.JASS_APP.My.Resources.Resources.refund_32
        Me.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPay.Location = New System.Drawing.Point(683, 425)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(216, 48)
        Me.btnPay.TabIndex = 9
        Me.btnPay.Text = "PAGAR"
        Me.btnPay.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(648, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 20)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Monto total a pagar"
        '
        'txtMountPay
        '
        Me.txtMountPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMountPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMountPay.Location = New System.Drawing.Point(801, 191)
        Me.txtMountPay.Name = "txtMountPay"
        Me.txtMountPay.Size = New System.Drawing.Size(98, 26)
        Me.txtMountPay.TabIndex = 5
        Me.txtMountPay.Text = "0.00"
        Me.txtMountPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(654, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Saldo de la cuenta"
        '
        'txtSaldo
        '
        Me.txtSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.Location = New System.Drawing.Point(801, 159)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.ReadOnly = True
        Me.txtSaldo.Size = New System.Drawing.Size(98, 26)
        Me.txtSaldo.TabIndex = 4
        Me.txtSaldo.Text = "0.00"
        Me.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkDebitUse
        '
        Me.chkDebitUse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkDebitUse.Enabled = False
        Me.chkDebitUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDebitUse.Location = New System.Drawing.Point(649, 83)
        Me.chkDebitUse.Name = "chkDebitUse"
        Me.chkDebitUse.Size = New System.Drawing.Size(250, 70)
        Me.chkDebitUse.TabIndex = 3
        Me.chkDebitUse.Text = "¿Usar el debito acumulado para pagar el saldo?"
        Me.chkDebitUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDebitUse.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(645, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Debito de la Cuenta"
        '
        'txtDebitAccount
        '
        Me.txtDebitAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebitAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebitAccount.Location = New System.Drawing.Point(801, 51)
        Me.txtDebitAccount.Name = "txtDebitAccount"
        Me.txtDebitAccount.ReadOnly = True
        Me.txtDebitAccount.Size = New System.Drawing.Size(98, 26)
        Me.txtDebitAccount.TabIndex = 2
        Me.txtDebitAccount.Text = "0.00"
        Me.txtDebitAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.dtgAccountMounth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdDetail, Me.clmIdAccountDetail, Me.clmYearDetail, Me.clmCodCharge, Me.clmCodMonth, Me.clmOpcionMes, Me.clmCharge, Me.clmMontoMes, Me.clmPagadoMes, Me.clmSaldoMes})
        Me.dtgAccountMounth.Location = New System.Drawing.Point(6, 19)
        Me.dtgAccountMounth.MultiSelect = False
        Me.dtgAccountMounth.Name = "dtgAccountMounth"
        Me.dtgAccountMounth.ReadOnly = True
        Me.dtgAccountMounth.RowHeadersVisible = False
        Me.dtgAccountMounth.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountMounth.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgAccountMounth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountMounth.Size = New System.Drawing.Size(620, 366)
        Me.dtgAccountMounth.TabIndex = 1
        '
        'clmIdDetail
        '
        Me.clmIdDetail.HeaderText = "Id Detalle"
        Me.clmIdDetail.Name = "clmIdDetail"
        Me.clmIdDetail.ReadOnly = True
        Me.clmIdDetail.Visible = False
        '
        'clmIdAccountDetail
        '
        Me.clmIdAccountDetail.HeaderText = "Id de Cuenta"
        Me.clmIdAccountDetail.Name = "clmIdAccountDetail"
        Me.clmIdAccountDetail.ReadOnly = True
        Me.clmIdAccountDetail.Visible = False
        '
        'clmYearDetail
        '
        Me.clmYearDetail.HeaderText = "Codigo Año"
        Me.clmYearDetail.Name = "clmYearDetail"
        Me.clmYearDetail.ReadOnly = True
        Me.clmYearDetail.Visible = False
        '
        'clmCodCharge
        '
        Me.clmCodCharge.HeaderText = "Codigo Cargo"
        Me.clmCodCharge.Name = "clmCodCharge"
        Me.clmCodCharge.ReadOnly = True
        Me.clmCodCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmCodCharge.Visible = False
        '
        'clmCodMonth
        '
        Me.clmCodMonth.HeaderText = "Codigo Mes"
        Me.clmCodMonth.Name = "clmCodMonth"
        Me.clmCodMonth.ReadOnly = True
        Me.clmCodMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmCodMonth.Visible = False
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
        'clmCharge
        '
        Me.clmCharge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmCharge.FillWeight = 210.0!
        Me.clmCharge.HeaderText = "Cargo"
        Me.clmCharge.Name = "clmCharge"
        Me.clmCharge.ReadOnly = True
        Me.clmCharge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmCharge.Width = 210
        '
        'clmMontoMes
        '
        Me.clmMontoMes.HeaderText = "Monto"
        Me.clmMontoMes.Name = "clmMontoMes"
        Me.clmMontoMes.ReadOnly = True
        Me.clmMontoMes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmPagadoMes
        '
        Me.clmPagadoMes.HeaderText = "Pagado"
        Me.clmPagadoMes.Name = "clmPagadoMes"
        Me.clmPagadoMes.ReadOnly = True
        Me.clmPagadoMes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmSaldoMes
        '
        Me.clmSaldoMes.HeaderText = "Saldo"
        Me.clmSaldoMes.Name = "clmSaldoMes"
        Me.clmSaldoMes.ReadOnly = True
        Me.clmSaldoMes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'cbxUsersInAccount
        '
        Me.cbxUsersInAccount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxUsersInAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUsersInAccount.FormattingEnabled = True
        Me.cbxUsersInAccount.Location = New System.Drawing.Point(657, 38)
        Me.cbxUsersInAccount.Name = "cbxUsersInAccount"
        Me.cbxUsersInAccount.Size = New System.Drawing.Size(260, 21)
        Me.cbxUsersInAccount.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(507, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(144, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Usuarios asociados a cuenta"
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
        'clmOpciones
        '
        Me.clmOpciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmOpciones.HeaderText = ""
        Me.clmOpciones.Name = "clmOpciones"
        Me.clmOpciones.ReadOnly = True
        Me.clmOpciones.Text = "Ver"
        Me.clmOpciones.UseColumnTextForButtonValue = True
        '
        'frmCollectDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(929, 711)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbxUsersInAccount)
        Me.Controls.Add(Me.grpYearDetail)
        Me.Controls.Add(Me.dtgAccountYear)
        Me.Controls.Add(Me.txtCodAccount)
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
    Private WithEvents txtCodAccount As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtgAccountYear As DataGridView
    Friend WithEvents grpYearDetail As GroupBox
    Friend WithEvents dtgAccountMounth As DataGridView
    Friend WithEvents chkDebitUse As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDebitAccount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMountPay As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSaldo As TextBox
    Friend WithEvents btnPay As Button
    Friend WithEvents btnSeePayments As Button
    Friend WithEvents btnDeposit As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtChanging As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCash As TextBox
    Friend WithEvents chkChangingUse As CheckBox
    Friend WithEvents btnClean As Button
    Friend WithEvents txtCodNumReceipt As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbxUsersInAccount As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents clmIdDetail As DataGridViewTextBoxColumn
    Friend WithEvents clmIdAccountDetail As DataGridViewTextBoxColumn
    Friend WithEvents clmYearDetail As DataGridViewTextBoxColumn
    Friend WithEvents clmCodCharge As DataGridViewTextBoxColumn
    Friend WithEvents clmCodMonth As DataGridViewTextBoxColumn
    Friend WithEvents clmOpcionMes As DataGridViewCheckBoxColumn
    Friend WithEvents clmCharge As DataGridViewTextBoxColumn
    Friend WithEvents clmMontoMes As DataGridViewTextBoxColumn
    Friend WithEvents clmPagadoMes As DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoMes As DataGridViewTextBoxColumn
    Friend WithEvents btnClose As Button
    Friend WithEvents btnDebtRecord As Button
    Friend WithEvents clmIdAccount As DataGridViewTextBoxColumn
    Friend WithEvents clmYear As DataGridViewTextBoxColumn
    Friend WithEvents clmMontoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmPayedTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmSaldoTotal As DataGridViewTextBoxColumn
    Friend WithEvents clmEstado As DataGridViewTextBoxColumn
    Friend WithEvents clmOpciones As DataGridViewButtonColumn
End Class
