﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindLines
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxCrit = New System.Windows.Forms.ComboBox()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.dtgLines = New System.Windows.Forms.DataGridView()
        Me.clmCodLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNameLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmUserLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmDocId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmHolder = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmOptions = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dtgLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar por:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(202, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ingrese texto a buscar:"
        '
        'cbxCrit
        '
        Me.cbxCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCrit.FormattingEnabled = True
        Me.cbxCrit.Items.AddRange(New Object() {"NOMBRE DE USUARIO", "NUM. DE DOCUMENTO", "COD. DE LINEA", "NOMBRE DE LINEA"})
        Me.cbxCrit.Location = New System.Drawing.Point(12, 25)
        Me.cbxCrit.Name = "cbxCrit"
        Me.cbxCrit.Size = New System.Drawing.Size(187, 21)
        Me.cbxCrit.TabIndex = 1
        '
        'txtFind
        '
        Me.txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFind.Location = New System.Drawing.Point(205, 26)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(518, 20)
        Me.txtFind.TabIndex = 2
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(729, 25)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(143, 23)
        Me.btnFind.TabIndex = 3
        Me.btnFind.Text = "Buscar"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'dtgLines
        '
        Me.dtgLines.AllowUserToAddRows = False
        Me.dtgLines.AllowUserToDeleteRows = False
        Me.dtgLines.AllowUserToResizeColumns = False
        Me.dtgLines.AllowUserToResizeRows = False
        Me.dtgLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmCodLine, Me.clmNameLine, Me.clmSector, Me.clmUserLine, Me.clmDocId, Me.clmHolder, Me.clmRate, Me.clmOptions})
        Me.dtgLines.Location = New System.Drawing.Point(12, 52)
        Me.dtgLines.MultiSelect = False
        Me.dtgLines.Name = "dtgLines"
        Me.dtgLines.ReadOnly = True
        Me.dtgLines.RowHeadersVisible = False
        Me.dtgLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgLines.Size = New System.Drawing.Size(860, 397)
        Me.dtgLines.TabIndex = 7
        '
        'clmCodLine
        '
        Me.clmCodLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmCodLine.FillWeight = 120.0!
        Me.clmCodLine.HeaderText = "Codigo de Linea"
        Me.clmCodLine.Name = "clmCodLine"
        Me.clmCodLine.ReadOnly = True
        Me.clmCodLine.Width = 120
        '
        'clmNameLine
        '
        Me.clmNameLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmNameLine.FillWeight = 120.0!
        Me.clmNameLine.HeaderText = "Nombre de Linea"
        Me.clmNameLine.Name = "clmNameLine"
        Me.clmNameLine.ReadOnly = True
        Me.clmNameLine.Width = 120
        '
        'clmSector
        '
        Me.clmSector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmSector.FillWeight = 120.0!
        Me.clmSector.HeaderText = "Calle o Avenida"
        Me.clmSector.Name = "clmSector"
        Me.clmSector.ReadOnly = True
        Me.clmSector.Width = 120
        '
        'clmUserLine
        '
        Me.clmUserLine.FillWeight = 33.03412!
        Me.clmUserLine.HeaderText = "Usuario de Linea"
        Me.clmUserLine.Name = "clmUserLine"
        Me.clmUserLine.ReadOnly = True
        '
        'clmDocId
        '
        Me.clmDocId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmDocId.HeaderText = "Doc. de Identidad"
        Me.clmDocId.Name = "clmDocId"
        Me.clmDocId.ReadOnly = True
        '
        'clmHolder
        '
        Me.clmHolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmHolder.FillWeight = 50.0!
        Me.clmHolder.HeaderText = "Titular"
        Me.clmHolder.Name = "clmHolder"
        Me.clmHolder.ReadOnly = True
        Me.clmHolder.Width = 50
        '
        'clmRate
        '
        Me.clmRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmRate.FillWeight = 120.0!
        Me.clmRate.HeaderText = "Tarifa"
        Me.clmRate.Name = "clmRate"
        Me.clmRate.ReadOnly = True
        Me.clmRate.Width = 120
        '
        'clmOptions
        '
        Me.clmOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clmOptions.FillWeight = 75.0!
        Me.clmOptions.HeaderText = ""
        Me.clmOptions.Name = "clmOptions"
        Me.clmOptions.ReadOnly = True
        Me.clmOptions.Text = "Editar"
        Me.clmOptions.UseColumnTextForButtonValue = True
        Me.clmOptions.Width = 75
        '
        'frmFindLines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.dtgLines)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.cbxCrit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(900, 500)
        Me.Name = "frmFindLines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lineas de servicio"
        CType(Me.dtgLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxCrit As ComboBox
    Friend WithEvents txtFind As TextBox
    Friend WithEvents btnFind As Button
    Friend WithEvents dtgLines As DataGridView
    Friend WithEvents clmCodLine As DataGridViewTextBoxColumn
    Friend WithEvents clmNameLine As DataGridViewTextBoxColumn
    Friend WithEvents clmSector As DataGridViewTextBoxColumn
    Friend WithEvents clmUserLine As DataGridViewTextBoxColumn
    Friend WithEvents clmDocId As DataGridViewTextBoxColumn
    Friend WithEvents clmHolder As DataGridViewCheckBoxColumn
    Friend WithEvents clmRate As DataGridViewTextBoxColumn
    Friend WithEvents clmOptions As DataGridViewButtonColumn
End Class
