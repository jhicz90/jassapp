<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDebtRecordDetail
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
        Me.clmSaldoState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDebt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPayed = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudAmountNew = New System.Windows.Forms.NumericUpDown()
        Me.txtService = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddDebtDetail = New System.Windows.Forms.Button()
        CType(Me.dtgAccountMounth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAmountNew, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dtgAccountMounth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdDetail, Me.clmIdAccountDetail, Me.clmYearDetail, Me.clmCodCharge, Me.clmCodMonth, Me.clmOpcionMes, Me.clmCharge, Me.clmMontoMes, Me.clmPagadoMes, Me.clmSaldoMes, Me.clmSaldoState})
        Me.dtgAccountMounth.Location = New System.Drawing.Point(12, 12)
        Me.dtgAccountMounth.MultiSelect = False
        Me.dtgAccountMounth.Name = "dtgAccountMounth"
        Me.dtgAccountMounth.ReadOnly = True
        Me.dtgAccountMounth.RowHeadersVisible = False
        Me.dtgAccountMounth.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgAccountMounth.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgAccountMounth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccountMounth.Size = New System.Drawing.Size(760, 125)
        Me.dtgAccountMounth.TabIndex = 2
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
        Me.clmOpcionMes.FalseValue = ""
        Me.clmOpcionMes.FillWeight = 50.0!
        Me.clmOpcionMes.HeaderText = ""
        Me.clmOpcionMes.Name = "clmOpcionMes"
        Me.clmOpcionMes.ReadOnly = True
        Me.clmOpcionMes.TrueValue = ""
        Me.clmOpcionMes.Visible = False
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
        'clmSaldoState
        '
        Me.clmSaldoState.HeaderText = "Estado"
        Me.clmSaldoState.Name = "clmSaldoState"
        Me.clmSaldoState.ReadOnly = True
        Me.clmSaldoState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnAddDebtDetail)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDebt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtPayed)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.nudAmountNew)
        Me.GroupBox1.Controls.Add(Me.txtService)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 206)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la cuenta detalle seleccionada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 129)
        Me.Label6.Margin = New System.Windows.Forms.Padding(10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Nuevo monto:"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(494, 23)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(260, 20)
        Me.txtState.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(391, 26)
        Me.Label5.Margin = New System.Windows.Forms.Padding(10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Estado de servicio:"
        '
        'txtDebt
        '
        Me.txtDebt.Location = New System.Drawing.Point(116, 101)
        Me.txtDebt.Name = "txtDebt"
        Me.txtDebt.ReadOnly = True
        Me.txtDebt.Size = New System.Drawing.Size(100, 20)
        Me.txtDebt.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 104)
        Me.Label4.Margin = New System.Windows.Forms.Padding(10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Saldo de servicio:"
        '
        'txtPayed
        '
        Me.txtPayed.Location = New System.Drawing.Point(116, 75)
        Me.txtPayed.Name = "txtPayed"
        Me.txtPayed.ReadOnly = True
        Me.txtPayed.Size = New System.Drawing.Size(100, 20)
        Me.txtPayed.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Pago de servicio:"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(116, 49)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Monto de servicio:"
        '
        'nudAmountNew
        '
        Me.nudAmountNew.Location = New System.Drawing.Point(116, 127)
        Me.nudAmountNew.Name = "nudAmountNew"
        Me.nudAmountNew.Size = New System.Drawing.Size(100, 20)
        Me.nudAmountNew.TabIndex = 4
        '
        'txtService
        '
        Me.txtService.Location = New System.Drawing.Point(116, 23)
        Me.txtService.Name = "txtService"
        Me.txtService.ReadOnly = True
        Me.txtService.Size = New System.Drawing.Size(260, 20)
        Me.txtService.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cargo de servicio:"
        '
        'btnAddDebtDetail
        '
        Me.btnAddDebtDetail.Image = Global.JASS_APP.My.Resources.Resources.ledger_edit_32
        Me.btnAddDebtDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddDebtDetail.Location = New System.Drawing.Point(554, 152)
        Me.btnAddDebtDetail.Name = "btnAddDebtDetail"
        Me.btnAddDebtDetail.Size = New System.Drawing.Size(200, 48)
        Me.btnAddDebtDetail.TabIndex = 14
        Me.btnAddDebtDetail.Text = "CAMBIAR DEUDA DETALLE"
        Me.btnAddDebtDetail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddDebtDetail.UseVisualStyleBackColor = True
        '
        'frmDebtRecordDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 361)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtgAccountMounth)
        Me.MaximizeBox = False
        Me.Name = "frmDebtRecordDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar deuda detalle"
        CType(Me.dtgAccountMounth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAmountNew, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtgAccountMounth As DataGridView
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
    Friend WithEvents clmSaldoState As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Private WithEvents txtService As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Private WithEvents txtState As TextBox
    Friend WithEvents Label5 As Label
    Private WithEvents txtDebt As TextBox
    Friend WithEvents Label4 As Label
    Private WithEvents txtPayed As TextBox
    Friend WithEvents Label3 As Label
    Private WithEvents txtAmount As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents nudAmountNew As NumericUpDown
    Friend WithEvents btnAddDebtDetail As Button
End Class
