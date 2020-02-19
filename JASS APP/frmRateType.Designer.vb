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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dtgRateType = New System.Windows.Forms.DataGridView()
        Me.clmIdRateType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNameRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmPeriodic = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        CType(Me.dtgRateType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre de tarifa o servicio:"
        '
        'txtRateTypeName
        '
        Me.txtRateTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRateTypeName.Location = New System.Drawing.Point(168, 16)
        Me.txtRateTypeName.Name = "txtRateTypeName"
        Me.txtRateTypeName.Size = New System.Drawing.Size(200, 20)
        Me.txtRateTypeName.TabIndex = 1
        '
        'txtRateTypeDescp
        '
        Me.txtRateTypeDescp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRateTypeDescp.Location = New System.Drawing.Point(168, 42)
        Me.txtRateTypeDescp.Name = "txtRateTypeDescp"
        Me.txtRateTypeDescp.Size = New System.Drawing.Size(200, 20)
        Me.txtRateTypeDescp.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'chkPeriodic
        '
        Me.chkPeriodic.AutoSize = True
        Me.chkPeriodic.Location = New System.Drawing.Point(374, 18)
        Me.chkPeriodic.Name = "chkPeriodic"
        Me.chkPeriodic.Size = New System.Drawing.Size(120, 17)
        Me.chkPeriodic.TabIndex = 4
        Me.chkPeriodic.Text = "Tarifa mensualizada"
        Me.chkPeriodic.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(676, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 64)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "GUARDAR"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = True
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
        Me.dtgRateType.Location = New System.Drawing.Point(12, 82)
        Me.dtgRateType.MultiSelect = False
        Me.dtgRateType.Name = "dtgRateType"
        Me.dtgRateType.ReadOnly = True
        Me.dtgRateType.RowHeadersVisible = False
        Me.dtgRateType.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgRateType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateType.Size = New System.Drawing.Size(760, 167)
        Me.dtgRateType.TabIndex = 6
        '
        'clmIdRateType
        '
        Me.clmIdRateType.HeaderText = "Id de Tarifa"
        Me.clmIdRateType.Name = "clmIdRateType"
        Me.clmIdRateType.ReadOnly = True
        Me.clmIdRateType.Visible = False
        '
        'clmNameRate
        '
        Me.clmNameRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmNameRate.HeaderText = "Nombre"
        Me.clmNameRate.Name = "clmNameRate"
        Me.clmNameRate.ReadOnly = True
        '
        'clmDesc
        '
        Me.clmDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clmDesc.HeaderText = "Descripción"
        Me.clmDesc.Name = "clmDesc"
        Me.clmDesc.ReadOnly = True
        '
        'clmPeriodic
        '
        Me.clmPeriodic.HeaderText = "Mensualizada"
        Me.clmPeriodic.Name = "clmPeriodic"
        Me.clmPeriodic.ReadOnly = True
        Me.clmPeriodic.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmPeriodic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btnNew
        '
        Me.btnNew.Image = Global.JASS_APP.My.Resources.Resources.hand_service_32
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(574, 12)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(96, 64)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Text = "NUEVO"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'frmRateType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 261)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dtgRateType)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkPeriodic)
        Me.Controls.Add(Me.txtRateTypeDescp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRateTypeName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRateType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarifas y servicios"
        CType(Me.dtgRateType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtRateTypeName As TextBox
    Friend WithEvents txtRateTypeDescp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkPeriodic As CheckBox
    Public WithEvents btnSave As Button
    Friend WithEvents dtgRateType As DataGridView
    Friend WithEvents clmIdRateType As DataGridViewTextBoxColumn
    Friend WithEvents clmNameRate As DataGridViewTextBoxColumn
    Friend WithEvents clmDesc As DataGridViewTextBoxColumn
    Friend WithEvents clmPeriodic As DataGridViewCheckBoxColumn
    Public WithEvents btnNew As Button
End Class
