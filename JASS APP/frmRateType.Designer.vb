<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRateType
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRateTypeName = New System.Windows.Forms.TextBox()
        Me.txtRateTypeDescp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkPeriodic = New System.Windows.Forms.CheckBox()
        Me.btnSaveService = New System.Windows.Forms.Button()
        Me.dtgRateType = New System.Windows.Forms.DataGridView()
        Me.clmIdRateType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNameRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPeriodic = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnNewService = New System.Windows.Forms.Button()
        Me.tabRates = New System.Windows.Forms.TabControl()
        Me.tabpageServices = New System.Windows.Forms.TabPage()
        Me.tabpageYear = New System.Windows.Forms.TabPage()
        Me.btnYearActive = New System.Windows.Forms.Button()
        Me.btnNewYear = New System.Windows.Forms.Button()
        Me.btnSaveYear = New System.Windows.Forms.Button()
        Me.nudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtYearName = New System.Windows.Forms.TextBox()
        Me.dtgYears = New System.Windows.Forms.DataGridView()
        Me.clmIdYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmYearName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageRates = New System.Windows.Forms.TabPage()
        CType(Me.dtgRateType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRates.SuspendLayout()
        Me.tabpageServices.SuspendLayout()
        Me.tabpageYear.SuspendLayout()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgYears, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de tarifa o servicio:"
        '
        'txtRateTypeName
        '
        Me.txtRateTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRateTypeName.Location = New System.Drawing.Point(164, 10)
        Me.txtRateTypeName.Name = "txtRateTypeName"
        Me.txtRateTypeName.Size = New System.Drawing.Size(200, 20)
        Me.txtRateTypeName.TabIndex = 1
        '
        'txtRateTypeDescp
        '
        Me.txtRateTypeDescp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRateTypeDescp.Location = New System.Drawing.Point(164, 36)
        Me.txtRateTypeDescp.Name = "txtRateTypeDescp"
        Me.txtRateTypeDescp.Size = New System.Drawing.Size(200, 20)
        Me.txtRateTypeDescp.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'chkPeriodic
        '
        Me.chkPeriodic.AutoSize = True
        Me.chkPeriodic.Location = New System.Drawing.Point(370, 12)
        Me.chkPeriodic.Name = "chkPeriodic"
        Me.chkPeriodic.Size = New System.Drawing.Size(120, 17)
        Me.chkPeriodic.TabIndex = 4
        Me.chkPeriodic.Text = "Tarifa mensualizada"
        Me.chkPeriodic.UseVisualStyleBackColor = True
        Me.chkPeriodic.Visible = False
        '
        'btnSaveService
        '
        Me.btnSaveService.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveService.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSaveService.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveService.Location = New System.Drawing.Point(672, 6)
        Me.btnSaveService.Name = "btnSaveService"
        Me.btnSaveService.Size = New System.Drawing.Size(96, 64)
        Me.btnSaveService.TabIndex = 5
        Me.btnSaveService.Text = "GUARDAR"
        Me.btnSaveService.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveService.UseVisualStyleBackColor = True
        '
        'dtgRateType
        '
        Me.dtgRateType.AllowUserToAddRows = False
        Me.dtgRateType.AllowUserToDeleteRows = False
        Me.dtgRateType.AllowUserToResizeColumns = False
        Me.dtgRateType.AllowUserToResizeRows = False
        Me.dtgRateType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgRateType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRateType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdRateType, Me.clmNameRate, Me.clmDesc, Me.clmPeriodic})
        Me.dtgRateType.Location = New System.Drawing.Point(6, 76)
        Me.dtgRateType.MultiSelect = False
        Me.dtgRateType.Name = "dtgRateType"
        Me.dtgRateType.ReadOnly = True
        Me.dtgRateType.RowHeadersVisible = False
        Me.dtgRateType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgRateType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateType.Size = New System.Drawing.Size(762, 342)
        Me.dtgRateType.TabIndex = 6
        '
        'clmIdRateType
        '
        Me.clmIdRateType.HeaderText = "Id de Tarifa"
        Me.clmIdRateType.Name = "clmIdRateType"
        Me.clmIdRateType.ReadOnly = True
        Me.clmIdRateType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmIdRateType.Visible = False
        '
        'clmNameRate
        '
        Me.clmNameRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmNameRate.HeaderText = "Nombre"
        Me.clmNameRate.Name = "clmNameRate"
        Me.clmNameRate.ReadOnly = True
        Me.clmNameRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmDesc
        '
        Me.clmDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmDesc.HeaderText = "Descripción"
        Me.clmDesc.Name = "clmDesc"
        Me.clmDesc.ReadOnly = True
        Me.clmDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'clmPeriodic
        '
        Me.clmPeriodic.HeaderText = "Mensualizada"
        Me.clmPeriodic.Name = "clmPeriodic"
        Me.clmPeriodic.ReadOnly = True
        Me.clmPeriodic.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'btnNewService
        '
        Me.btnNewService.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewService.Image = Global.JASS_APP.My.Resources.Resources.hand_service_32
        Me.btnNewService.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNewService.Location = New System.Drawing.Point(570, 6)
        Me.btnNewService.Name = "btnNewService"
        Me.btnNewService.Size = New System.Drawing.Size(96, 64)
        Me.btnNewService.TabIndex = 7
        Me.btnNewService.Text = "NUEVO"
        Me.btnNewService.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNewService.UseVisualStyleBackColor = True
        '
        'tabRates
        '
        Me.tabRates.Controls.Add(Me.tabpageServices)
        Me.tabRates.Controls.Add(Me.tabpageYear)
        Me.tabRates.Controls.Add(Me.tabpageRates)
        Me.tabRates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabRates.Location = New System.Drawing.Point(0, 0)
        Me.tabRates.Name = "tabRates"
        Me.tabRates.SelectedIndex = 0
        Me.tabRates.Size = New System.Drawing.Size(784, 450)
        Me.tabRates.TabIndex = 8
        '
        'tabpageServices
        '
        Me.tabpageServices.Controls.Add(Me.Label1)
        Me.tabpageServices.Controls.Add(Me.btnNewService)
        Me.tabpageServices.Controls.Add(Me.txtRateTypeName)
        Me.tabpageServices.Controls.Add(Me.dtgRateType)
        Me.tabpageServices.Controls.Add(Me.Label2)
        Me.tabpageServices.Controls.Add(Me.btnSaveService)
        Me.tabpageServices.Controls.Add(Me.txtRateTypeDescp)
        Me.tabpageServices.Controls.Add(Me.chkPeriodic)
        Me.tabpageServices.Location = New System.Drawing.Point(4, 22)
        Me.tabpageServices.Name = "tabpageServices"
        Me.tabpageServices.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageServices.Size = New System.Drawing.Size(776, 424)
        Me.tabpageServices.TabIndex = 0
        Me.tabpageServices.Text = "Servicios"
        Me.tabpageServices.UseVisualStyleBackColor = True
        '
        'tabpageYear
        '
        Me.tabpageYear.Controls.Add(Me.btnYearActive)
        Me.tabpageYear.Controls.Add(Me.btnNewYear)
        Me.tabpageYear.Controls.Add(Me.btnSaveYear)
        Me.tabpageYear.Controls.Add(Me.nudYear)
        Me.tabpageYear.Controls.Add(Me.Label3)
        Me.tabpageYear.Controls.Add(Me.Label4)
        Me.tabpageYear.Controls.Add(Me.txtYearName)
        Me.tabpageYear.Controls.Add(Me.dtgYears)
        Me.tabpageYear.Location = New System.Drawing.Point(4, 22)
        Me.tabpageYear.Name = "tabpageYear"
        Me.tabpageYear.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageYear.Size = New System.Drawing.Size(776, 424)
        Me.tabpageYear.TabIndex = 1
        Me.tabpageYear.Text = "Año"
        Me.tabpageYear.UseVisualStyleBackColor = True
        '
        'btnYearActive
        '
        Me.btnYearActive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnYearActive.Image = Global.JASS_APP.My.Resources.Resources.in_progress_32
        Me.btnYearActive.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnYearActive.Location = New System.Drawing.Point(468, 6)
        Me.btnYearActive.Name = "btnYearActive"
        Me.btnYearActive.Size = New System.Drawing.Size(96, 64)
        Me.btnYearActive.TabIndex = 16
        Me.btnYearActive.Text = "Activar Año"
        Me.btnYearActive.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnYearActive.UseVisualStyleBackColor = True
        '
        'btnNewYear
        '
        Me.btnNewYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewYear.Image = Global.JASS_APP.My.Resources.Resources.plus_1_year_32
        Me.btnNewYear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNewYear.Location = New System.Drawing.Point(570, 6)
        Me.btnNewYear.Name = "btnNewYear"
        Me.btnNewYear.Size = New System.Drawing.Size(96, 64)
        Me.btnNewYear.TabIndex = 15
        Me.btnNewYear.Text = "NUEVO"
        Me.btnNewYear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNewYear.UseVisualStyleBackColor = True
        '
        'btnSaveYear
        '
        Me.btnSaveYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveYear.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSaveYear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveYear.Location = New System.Drawing.Point(672, 6)
        Me.btnSaveYear.Name = "btnSaveYear"
        Me.btnSaveYear.Size = New System.Drawing.Size(96, 64)
        Me.btnSaveYear.TabIndex = 14
        Me.btnSaveYear.Text = "GUARDAR"
        Me.btnSaveYear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveYear.UseVisualStyleBackColor = True
        '
        'nudYear
        '
        Me.nudYear.Location = New System.Drawing.Point(113, 11)
        Me.nudYear.Maximum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(75, 20)
        Me.nudYear.TabIndex = 13
        Me.nudYear.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Año:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Nombre del año:"
        '
        'txtYearName
        '
        Me.txtYearName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYearName.Location = New System.Drawing.Point(113, 36)
        Me.txtYearName.Name = "txtYearName"
        Me.txtYearName.Size = New System.Drawing.Size(250, 20)
        Me.txtYearName.TabIndex = 11
        '
        'dtgYears
        '
        Me.dtgYears.AllowUserToAddRows = False
        Me.dtgYears.AllowUserToDeleteRows = False
        Me.dtgYears.AllowUserToResizeColumns = False
        Me.dtgYears.AllowUserToResizeRows = False
        Me.dtgYears.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgYears.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgYears.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmIdYear, Me.clmYear, Me.clmActive, Me.clmYearName})
        Me.dtgYears.Location = New System.Drawing.Point(6, 76)
        Me.dtgYears.MultiSelect = False
        Me.dtgYears.Name = "dtgYears"
        Me.dtgYears.ReadOnly = True
        Me.dtgYears.RowHeadersVisible = False
        Me.dtgYears.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgYears.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgYears.Size = New System.Drawing.Size(762, 342)
        Me.dtgYears.TabIndex = 7
        '
        'clmIdYear
        '
        Me.clmIdYear.HeaderText = "Id de Año"
        Me.clmIdYear.Name = "clmIdYear"
        Me.clmIdYear.ReadOnly = True
        Me.clmIdYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmIdYear.Visible = False
        '
        'clmYear
        '
        Me.clmYear.FillWeight = 75.0!
        Me.clmYear.HeaderText = "Año"
        Me.clmYear.Name = "clmYear"
        Me.clmYear.ReadOnly = True
        Me.clmYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmYear.Width = 75
        '
        'clmActive
        '
        Me.clmActive.HeaderText = "Activo"
        Me.clmActive.Name = "clmActive"
        Me.clmActive.ReadOnly = True
        '
        'clmYearName
        '
        Me.clmYearName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmYearName.HeaderText = "Nombre del año"
        Me.clmYearName.Name = "clmYearName"
        Me.clmYearName.ReadOnly = True
        Me.clmYearName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tabpageRates
        '
        Me.tabpageRates.Location = New System.Drawing.Point(4, 22)
        Me.tabpageRates.Name = "tabpageRates"
        Me.tabpageRates.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRates.Size = New System.Drawing.Size(776, 424)
        Me.tabpageRates.TabIndex = 2
        Me.tabpageRates.Text = "Tarifas de servicios"
        Me.tabpageRates.UseVisualStyleBackColor = True
        '
        'frmRateType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 450)
        Me.Controls.Add(Me.tabRates)
        Me.Name = "frmRateType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Años, tarifas y servicios"
        CType(Me.dtgRateType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRates.ResumeLayout(False)
        Me.tabpageServices.ResumeLayout(False)
        Me.tabpageServices.PerformLayout()
        Me.tabpageYear.ResumeLayout(False)
        Me.tabpageYear.PerformLayout()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgYears, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtRateTypeName As TextBox
    Friend WithEvents txtRateTypeDescp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkPeriodic As CheckBox
    Public WithEvents btnSaveService As Button
    Friend WithEvents dtgRateType As DataGridView
    Public WithEvents btnNewService As Button
    Friend WithEvents tabRates As TabControl
    Friend WithEvents tabpageServices As TabPage
    Friend WithEvents tabpageYear As TabPage
    Friend WithEvents tabpageRates As TabPage
    Friend WithEvents dtgYears As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtYearName As TextBox
    Friend WithEvents nudYear As NumericUpDown
    Public WithEvents btnNewYear As Button
    Public WithEvents btnSaveYear As Button
    Public WithEvents btnYearActive As Button
    Friend WithEvents clmIdRateType As DataGridViewTextBoxColumn
    Friend WithEvents clmNameRate As DataGridViewTextBoxColumn
    Friend WithEvents clmDesc As DataGridViewTextBoxColumn
    Friend WithEvents clmPeriodic As DataGridViewCheckBoxColumn
    Friend WithEvents clmIdYear As DataGridViewTextBoxColumn
    Friend WithEvents clmYear As DataGridViewTextBoxColumn
    Friend WithEvents clmActive As DataGridViewCheckBoxColumn
    Friend WithEvents clmYearName As DataGridViewTextBoxColumn
End Class
