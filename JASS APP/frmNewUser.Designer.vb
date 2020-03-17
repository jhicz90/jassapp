<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewuser
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
        Me.grpUser = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNameSocial = New System.Windows.Forms.Label()
        Me.lblSurNames = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSurnames = New System.Windows.Forms.TextBox()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDocID = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxTypeUser = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNames = New System.Windows.Forms.TextBox()
        Me.txtCellphone = New System.Windows.Forms.TextBox()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFindUser = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtDateUpdated = New System.Windows.Forms.TextBox()
        Me.txtDateCreated = New System.Windows.Forms.TextBox()
        Me.txtCodUser = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grpUser.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpUser
        '
        Me.grpUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpUser.Controls.Add(Me.TableLayoutPanel2)
        Me.grpUser.Location = New System.Drawing.Point(13, 65)
        Me.grpUser.Margin = New System.Windows.Forms.Padding(4)
        Me.grpUser.Name = "grpUser"
        Me.grpUser.Padding = New System.Windows.Forms.Padding(13, 12, 13, 12)
        Me.grpUser.Size = New System.Drawing.Size(758, 222)
        Me.grpUser.TabIndex = 1
        Me.grpUser.TabStop = False
        Me.grpUser.Text = "Datos del Usuario"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblNameSocial, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSurNames, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtSurnames, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblDoc, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtAddress, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtDocID, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cbxTypeUser, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtNames, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtCellphone, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.txtTelephone, 1, 3)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(17, 27)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(724, 179)
        Me.TableLayoutPanel2.TabIndex = 28
        '
        'lblNameSocial
        '
        Me.lblNameSocial.AutoSize = True
        Me.lblNameSocial.Location = New System.Drawing.Point(4, 0)
        Me.lblNameSocial.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNameSocial.Name = "lblNameSocial"
        Me.lblNameSocial.Size = New System.Drawing.Size(67, 16)
        Me.lblNameSocial.TabIndex = 0
        Me.lblNameSocial.Text = "Nombres:"
        '
        'lblSurNames
        '
        Me.lblSurNames.AutoSize = True
        Me.lblSurNames.Location = New System.Drawing.Point(365, 0)
        Me.lblSurNames.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSurNames.Name = "lblSurNames"
        Me.lblSurNames.Size = New System.Drawing.Size(68, 16)
        Me.lblSurNames.TabIndex = 3
        Me.lblSurNames.Text = "Apellidos:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 136)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Télefono:"
        '
        'txtSurnames
        '
        Me.txtSurnames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSurnames.Location = New System.Drawing.Point(451, 4)
        Me.txtSurnames.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSurnames.Name = "txtSurnames"
        Me.txtSurnames.Size = New System.Drawing.Size(269, 22)
        Me.txtSurnames.TabIndex = 2
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Location = New System.Drawing.Point(4, 31)
        Me.lblDoc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(34, 16)
        Me.lblDoc.TabIndex = 5
        Me.lblDoc.Text = "DNI:"
        '
        'txtAddress
        '
        Me.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress.Location = New System.Drawing.Point(90, 66)
        Me.txtAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(267, 53)
        Me.txtAddress.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 62)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 16)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Dirección:"
        '
        'txtDocID
        '
        Me.txtDocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocID.Location = New System.Drawing.Point(90, 35)
        Me.txtDocID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDocID.Name = "txtDocID"
        Me.txtDocID.Size = New System.Drawing.Size(267, 22)
        Me.txtDocID.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(365, 31)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Usuario:"
        '
        'cbxTypeUser
        '
        Me.cbxTypeUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTypeUser.FormattingEnabled = True
        Me.cbxTypeUser.Location = New System.Drawing.Point(451, 35)
        Me.cbxTypeUser.Margin = New System.Windows.Forms.Padding(4)
        Me.cbxTypeUser.Name = "cbxTypeUser"
        Me.cbxTypeUser.Size = New System.Drawing.Size(269, 24)
        Me.cbxTypeUser.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(365, 136)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Celular:"
        '
        'txtNames
        '
        Me.txtNames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNames.Location = New System.Drawing.Point(90, 4)
        Me.txtNames.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNames.Name = "txtNames"
        Me.txtNames.Size = New System.Drawing.Size(267, 22)
        Me.txtNames.TabIndex = 1
        '
        'txtCellphone
        '
        Me.txtCellphone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCellphone.Location = New System.Drawing.Point(451, 140)
        Me.txtCellphone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCellphone.Name = "txtCellphone"
        Me.txtCellphone.Size = New System.Drawing.Size(267, 22)
        Me.txtCellphone.TabIndex = 8
        '
        'txtTelephone
        '
        Me.txtTelephone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelephone.Location = New System.Drawing.Point(90, 140)
        Me.txtTelephone.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(267, 22)
        Me.txtTelephone.TabIndex = 7
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(12, 374)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(760, 75)
        Me.TableLayoutPanel3.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnFindUser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(374, 69)
        Me.Panel1.TabIndex = 2
        '
        'btnFindUser
        '
        Me.btnFindUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnFindUser.Image = Global.JASS_APP.My.Resources.Resources.find_user_male_32
        Me.btnFindUser.Location = New System.Drawing.Point(3, 10)
        Me.btnFindUser.Name = "btnFindUser"
        Me.btnFindUser.Size = New System.Drawing.Size(150, 50)
        Me.btnFindUser.TabIndex = 1
        Me.btnFindUser.Text = "&Buscar"
        Me.btnFindUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFindUser.UseVisualStyleBackColor = True
        Me.btnFindUser.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnSave)
        Me.Panel3.Controls.Add(Me.btnCancel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(383, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(374, 69)
        Me.Panel3.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Image = Global.JASS_APP.My.Resources.Resources.save_32
        Me.btnSave.Location = New System.Drawing.Point(59, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 50)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Guardar"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.JASS_APP.My.Resources.Resources.cancel_32
        Me.btnCancel.Location = New System.Drawing.Point(215, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 50)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtDateUpdated
        '
        Me.txtDateUpdated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateUpdated.Location = New System.Drawing.Point(636, 34)
        Me.txtDateUpdated.Name = "txtDateUpdated"
        Me.txtDateUpdated.ReadOnly = True
        Me.txtDateUpdated.Size = New System.Drawing.Size(136, 22)
        Me.txtDateUpdated.TabIndex = 100
        Me.txtDateUpdated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDateCreated.Location = New System.Drawing.Point(636, 6)
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.ReadOnly = True
        Me.txtDateCreated.Size = New System.Drawing.Size(136, 22)
        Me.txtDateCreated.TabIndex = 100
        Me.txtDateCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodUser
        '
        Me.txtCodUser.Location = New System.Drawing.Point(140, 6)
        Me.txtCodUser.Name = "txtCodUser"
        Me.txtCodUser.ReadOnly = True
        Me.txtCodUser.Size = New System.Drawing.Size(180, 22)
        Me.txtCodUser.TabIndex = 100
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(510, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Actualizado"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(510, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Fecha de creación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Código de usuario"
        '
        'frmNewuser
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.txtDateUpdated)
        Me.Controls.Add(Me.txtDateCreated)
        Me.Controls.Add(Me.txtCodUser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TableLayoutPanel3)
        Me.Controls.Add(Me.grpUser)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "frmNewuser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuario"
        Me.grpUser.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpUser As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblNameSocial As Label
    Friend WithEvents txtCellphone As TextBox
    Friend WithEvents lblSurNames As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtSurnames As TextBox
    Friend WithEvents lblDoc As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDocID As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cbxTypeUser As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTelephone As TextBox
    Friend WithEvents txtNames As TextBox
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Private WithEvents txtDateUpdated As TextBox
    Private WithEvents txtDateCreated As TextBox
    Private WithEvents txtCodUser As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnFindUser As Button
End Class
