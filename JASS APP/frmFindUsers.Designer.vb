<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindUsers
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
        Me.dtgUsers = New System.Windows.Forms.DataGridView()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.cbxCrit = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRates = New System.Windows.Forms.Label()
        Me.txtPriceRate = New System.Windows.Forms.TextBox()
        Me.lblRatePrice = New System.Windows.Forms.Label()
        Me.cbxRates = New System.Windows.Forms.ComboBox()
        Me.clmCodUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDocId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSurnames = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTypeUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCellphone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTelephone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmOptions = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dtgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgUsers
        '
        Me.dtgUsers.AllowUserToAddRows = False
        Me.dtgUsers.AllowUserToDeleteRows = False
        Me.dtgUsers.AllowUserToResizeColumns = False
        Me.dtgUsers.AllowUserToResizeRows = False
        Me.dtgUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgUsers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmCodUser, Me.clmUser, Me.clmDocId, Me.clmNames, Me.clmSurnames, Me.clmTypeUser, Me.clmAddress, Me.clmCellphone, Me.clmTelephone, Me.clmOptions})
        Me.dtgUsers.Location = New System.Drawing.Point(12, 52)
        Me.dtgUsers.MultiSelect = False
        Me.dtgUsers.Name = "dtgUsers"
        Me.dtgUsers.ReadOnly = True
        Me.dtgUsers.RowHeadersVisible = False
        Me.dtgUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgUsers.Size = New System.Drawing.Size(860, 370)
        Me.dtgUsers.TabIndex = 4
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(729, 25)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(143, 23)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Buscar"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        Me.txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFind.Location = New System.Drawing.Point(205, 26)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(518, 20)
        Me.txtFind.TabIndex = 1
        '
        'cbxCrit
        '
        Me.cbxCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCrit.FormattingEnabled = True
        Me.cbxCrit.Items.AddRange(New Object() {"NOMBRE DE USUARIO", "NUM. DE DOCUMENTO"})
        Me.cbxCrit.Location = New System.Drawing.Point(12, 25)
        Me.cbxCrit.Name = "cbxCrit"
        Me.cbxCrit.Size = New System.Drawing.Size(187, 21)
        Me.cbxCrit.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Ingrese texto a buscar:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Buscar por:"
        '
        'lblRates
        '
        Me.lblRates.AutoSize = True
        Me.lblRates.Location = New System.Drawing.Point(12, 431)
        Me.lblRates.Name = "lblRates"
        Me.lblRates.Size = New System.Drawing.Size(63, 13)
        Me.lblRates.TabIndex = 14
        Me.lblRates.Text = "Tarifa JASS"
        Me.lblRates.Visible = False
        '
        'txtPriceRate
        '
        Me.txtPriceRate.Location = New System.Drawing.Point(404, 429)
        Me.txtPriceRate.Name = "txtPriceRate"
        Me.txtPriceRate.ReadOnly = True
        Me.txtPriceRate.Size = New System.Drawing.Size(95, 20)
        Me.txtPriceRate.TabIndex = 6
        Me.txtPriceRate.TabStop = False
        Me.txtPriceRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRatePrice
        '
        Me.lblRatePrice.AutoSize = True
        Me.lblRatePrice.Location = New System.Drawing.Point(337, 431)
        Me.lblRatePrice.Name = "lblRatePrice"
        Me.lblRatePrice.Size = New System.Drawing.Size(61, 13)
        Me.lblRatePrice.TabIndex = 17
        Me.lblRatePrice.Text = "Tarifa (S/.):"
        '
        'cbxRates
        '
        Me.cbxRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxRates.FormattingEnabled = True
        Me.cbxRates.Location = New System.Drawing.Point(81, 428)
        Me.cbxRates.Name = "cbxRates"
        Me.cbxRates.Size = New System.Drawing.Size(250, 21)
        Me.cbxRates.TabIndex = 5
        '
        'clmCodUser
        '
        Me.clmCodUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmCodUser.FillWeight = 120.0!
        Me.clmCodUser.HeaderText = "Codigo de Usuario"
        Me.clmCodUser.Name = "clmCodUser"
        Me.clmCodUser.ReadOnly = True
        Me.clmCodUser.Visible = False
        Me.clmCodUser.Width = 120
        '
        'clmUser
        '
        Me.clmUser.FillWeight = 33.03412!
        Me.clmUser.HeaderText = "Usuario"
        Me.clmUser.Name = "clmUser"
        Me.clmUser.ReadOnly = True
        '
        'clmDocId
        '
        Me.clmDocId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmDocId.FillWeight = 150.0!
        Me.clmDocId.HeaderText = "Doc. de Identidad"
        Me.clmDocId.Name = "clmDocId"
        Me.clmDocId.ReadOnly = True
        Me.clmDocId.Width = 150
        '
        'clmNames
        '
        Me.clmNames.HeaderText = "Nombres"
        Me.clmNames.Name = "clmNames"
        Me.clmNames.ReadOnly = True
        Me.clmNames.Visible = False
        '
        'clmSurnames
        '
        Me.clmSurnames.HeaderText = "Apellidos"
        Me.clmSurnames.Name = "clmSurnames"
        Me.clmSurnames.ReadOnly = True
        Me.clmSurnames.Visible = False
        '
        'clmTypeUser
        '
        Me.clmTypeUser.HeaderText = "Tipo de usuario"
        Me.clmTypeUser.Name = "clmTypeUser"
        Me.clmTypeUser.ReadOnly = True
        Me.clmTypeUser.Visible = False
        '
        'clmAddress
        '
        Me.clmAddress.HeaderText = "Direccion"
        Me.clmAddress.Name = "clmAddress"
        Me.clmAddress.ReadOnly = True
        Me.clmAddress.Visible = False
        '
        'clmCellphone
        '
        Me.clmCellphone.HeaderText = "Celular"
        Me.clmCellphone.Name = "clmCellphone"
        Me.clmCellphone.ReadOnly = True
        Me.clmCellphone.Visible = False
        '
        'clmTelephone
        '
        Me.clmTelephone.HeaderText = "Telefono"
        Me.clmTelephone.Name = "clmTelephone"
        Me.clmTelephone.ReadOnly = True
        Me.clmTelephone.Visible = False
        '
        'clmOptions
        '
        Me.clmOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmOptions.FillWeight = 75.0!
        Me.clmOptions.HeaderText = ""
        Me.clmOptions.Name = "clmOptions"
        Me.clmOptions.ReadOnly = True
        Me.clmOptions.Text = "Seleccionar"
        Me.clmOptions.UseColumnTextForButtonValue = True
        Me.clmOptions.Width = 75
        '
        'frmFindUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.cbxRates)
        Me.Controls.Add(Me.txtPriceRate)
        Me.Controls.Add(Me.lblRatePrice)
        Me.Controls.Add(Me.lblRates)
        Me.Controls.Add(Me.dtgUsers)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.cbxCrit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(900, 500)
        Me.Name = "frmFindUsers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Usuarios"
        CType(Me.dtgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtgUsers As DataGridView
    Friend WithEvents btnFind As Button
    Friend WithEvents txtFind As TextBox
    Friend WithEvents cbxCrit As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblRates As Label
    Friend WithEvents txtPriceRate As TextBox
    Friend WithEvents lblRatePrice As Label
    Friend WithEvents cbxRates As ComboBox
    Friend WithEvents clmCodUser As DataGridViewTextBoxColumn
    Friend WithEvents clmUser As DataGridViewTextBoxColumn
    Friend WithEvents clmDocId As DataGridViewTextBoxColumn
    Friend WithEvents clmNames As DataGridViewTextBoxColumn
    Friend WithEvents clmSurnames As DataGridViewTextBoxColumn
    Friend WithEvents clmTypeUser As DataGridViewTextBoxColumn
    Friend WithEvents clmAddress As DataGridViewTextBoxColumn
    Friend WithEvents clmCellphone As DataGridViewTextBoxColumn
    Friend WithEvents clmTelephone As DataGridViewTextBoxColumn
    Friend WithEvents clmOptions As DataGridViewButtonColumn
End Class
