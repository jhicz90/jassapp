<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportDebtsResume
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
        Me.components = New System.ComponentModel.Container()
        Me.panelDatesRange = New System.Windows.Forms.Panel()
        Me.chkStreet = New System.Windows.Forms.CheckBox()
        Me.cbxStreets = New System.Windows.Forms.ComboBox()
        Me.btnReportRefresh = New System.Windows.Forms.Button()
        Me.chkYearRate = New System.Windows.Forms.CheckBox()
        Me.cbxYearRate = New System.Windows.Forms.ComboBox()
        Me.chkCollectUserSys = New System.Windows.Forms.CheckBox()
        Me.cbxUsersSys = New System.Windows.Forms.ComboBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpSince = New System.Windows.Forms.DateTimePicker()
        Me.chkDateRange = New System.Windows.Forms.CheckBox()
        Me.rptDebts = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dtDebtsResumeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDebts = New JASS_APP.dsDebts()
        Me.panelDatesRange.SuspendLayout()
        CType(Me.dtDebtsResumeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDebts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelDatesRange
        '
        Me.panelDatesRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDatesRange.BackColor = System.Drawing.Color.MediumTurquoise
        Me.panelDatesRange.Controls.Add(Me.chkStreet)
        Me.panelDatesRange.Controls.Add(Me.cbxStreets)
        Me.panelDatesRange.Controls.Add(Me.btnReportRefresh)
        Me.panelDatesRange.Controls.Add(Me.chkYearRate)
        Me.panelDatesRange.Controls.Add(Me.cbxYearRate)
        Me.panelDatesRange.Controls.Add(Me.chkCollectUserSys)
        Me.panelDatesRange.Controls.Add(Me.cbxUsersSys)
        Me.panelDatesRange.Controls.Add(Me.dtpTo)
        Me.panelDatesRange.Controls.Add(Me.dtpSince)
        Me.panelDatesRange.Controls.Add(Me.chkDateRange)
        Me.panelDatesRange.Location = New System.Drawing.Point(0, 0)
        Me.panelDatesRange.Margin = New System.Windows.Forms.Padding(0)
        Me.panelDatesRange.Name = "panelDatesRange"
        Me.panelDatesRange.Size = New System.Drawing.Size(984, 111)
        Me.panelDatesRange.TabIndex = 4
        '
        'chkStreet
        '
        Me.chkStreet.AutoSize = True
        Me.chkStreet.Location = New System.Drawing.Point(378, 47)
        Me.chkStreet.Margin = New System.Windows.Forms.Padding(3, 15, 3, 3)
        Me.chkStreet.Name = "chkStreet"
        Me.chkStreet.Size = New System.Drawing.Size(54, 17)
        Me.chkStreet.TabIndex = 11
        Me.chkStreet.Text = "Calles"
        Me.chkStreet.UseVisualStyleBackColor = True
        '
        'cbxStreets
        '
        Me.cbxStreets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStreets.FormattingEnabled = True
        Me.cbxStreets.Location = New System.Drawing.Point(438, 45)
        Me.cbxStreets.Name = "cbxStreets"
        Me.cbxStreets.Size = New System.Drawing.Size(231, 21)
        Me.cbxStreets.TabIndex = 10
        '
        'btnReportRefresh
        '
        Me.btnReportRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReportRefresh.Image = Global.JASS_APP.My.Resources.Resources.report_card_32
        Me.btnReportRefresh.Location = New System.Drawing.Point(897, 12)
        Me.btnReportRefresh.Name = "btnReportRefresh"
        Me.btnReportRefresh.Size = New System.Drawing.Size(75, 87)
        Me.btnReportRefresh.TabIndex = 7
        Me.btnReportRefresh.Text = "Reporte"
        Me.btnReportRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReportRefresh.UseVisualStyleBackColor = True
        '
        'chkYearRate
        '
        Me.chkYearRate.AutoSize = True
        Me.chkYearRate.Location = New System.Drawing.Point(12, 82)
        Me.chkYearRate.Margin = New System.Windows.Forms.Padding(3, 15, 3, 3)
        Me.chkYearRate.Name = "chkYearRate"
        Me.chkYearRate.Size = New System.Drawing.Size(71, 17)
        Me.chkYearRate.TabIndex = 6
        Me.chkYearRate.Text = "Año tarifa"
        Me.chkYearRate.UseVisualStyleBackColor = True
        '
        'cbxYearRate
        '
        Me.cbxYearRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxYearRate.FormattingEnabled = True
        Me.cbxYearRate.Location = New System.Drawing.Point(141, 80)
        Me.cbxYearRate.Name = "cbxYearRate"
        Me.cbxYearRate.Size = New System.Drawing.Size(120, 21)
        Me.cbxYearRate.TabIndex = 5
        '
        'chkCollectUserSys
        '
        Me.chkCollectUserSys.AutoSize = True
        Me.chkCollectUserSys.Location = New System.Drawing.Point(12, 47)
        Me.chkCollectUserSys.Margin = New System.Windows.Forms.Padding(3, 15, 3, 3)
        Me.chkCollectUserSys.Name = "chkCollectUserSys"
        Me.chkCollectUserSys.Size = New System.Drawing.Size(123, 17)
        Me.chkCollectUserSys.TabIndex = 4
        Me.chkCollectUserSys.Text = "Cobrado por Usuario"
        Me.chkCollectUserSys.UseVisualStyleBackColor = True
        '
        'cbxUsersSys
        '
        Me.cbxUsersSys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUsersSys.FormattingEnabled = True
        Me.cbxUsersSys.Location = New System.Drawing.Point(141, 45)
        Me.cbxUsersSys.Name = "cbxUsersSys"
        Me.cbxUsersSys.Size = New System.Drawing.Size(231, 21)
        Me.cbxUsersSys.TabIndex = 3
        '
        'dtpTo
        '
        Me.dtpTo.Checked = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(267, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(120, 20)
        Me.dtpTo.TabIndex = 2
        '
        'dtpSince
        '
        Me.dtpSince.Checked = False
        Me.dtpSince.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSince.Location = New System.Drawing.Point(141, 9)
        Me.dtpSince.Name = "dtpSince"
        Me.dtpSince.Size = New System.Drawing.Size(120, 20)
        Me.dtpSince.TabIndex = 1
        '
        'chkDateRange
        '
        Me.chkDateRange.AutoSize = True
        Me.chkDateRange.Checked = True
        Me.chkDateRange.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateRange.Location = New System.Drawing.Point(12, 12)
        Me.chkDateRange.Name = "chkDateRange"
        Me.chkDateRange.Size = New System.Drawing.Size(108, 17)
        Me.chkDateRange.TabIndex = 0
        Me.chkDateRange.Text = "Rango de fechas"
        Me.chkDateRange.UseVisualStyleBackColor = True
        '
        'rptDebts
        '
        Me.rptDebts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rptDebts.DocumentMapCollapsed = True
        Me.rptDebts.LocalReport.ReportEmbeddedResource = "JASS_APP.rptDebtsResume.rdlc"
        Me.rptDebts.Location = New System.Drawing.Point(0, 114)
        Me.rptDebts.Name = "rptDebts"
        Me.rptDebts.ServerReport.BearerToken = Nothing
        Me.rptDebts.Size = New System.Drawing.Size(984, 347)
        Me.rptDebts.TabIndex = 5
        Me.rptDebts.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        '
        'dtDebtsResumeBindingSource
        '
        Me.dtDebtsResumeBindingSource.DataMember = "dtDebtsResume"
        Me.dtDebtsResumeBindingSource.DataSource = Me.dsDebts
        '
        'dsDebts
        '
        Me.dsDebts.DataSetName = "dsDebts"
        Me.dsDebts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmReportDebtsResume
        '
        Me.AcceptButton = Me.btnReportRefresh
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 461)
        Me.Controls.Add(Me.rptDebts)
        Me.Controls.Add(Me.panelDatesRange)
        Me.Name = "frmReportDebtsResume"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte resumen de Deudas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panelDatesRange.ResumeLayout(False)
        Me.panelDatesRange.PerformLayout()
        CType(Me.dtDebtsResumeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDebts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelDatesRange As Panel
    Friend WithEvents chkStreet As CheckBox
    Friend WithEvents cbxStreets As ComboBox
    Friend WithEvents btnReportRefresh As Button
    Friend WithEvents chkYearRate As CheckBox
    Friend WithEvents cbxYearRate As ComboBox
    Friend WithEvents chkCollectUserSys As CheckBox
    Friend WithEvents cbxUsersSys As ComboBox
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpSince As DateTimePicker
    Friend WithEvents chkDateRange As CheckBox
    Friend WithEvents rptDebts As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtDebtsResumeBindingSource As BindingSource
    Friend WithEvents dsDebts As dsDebts
End Class
