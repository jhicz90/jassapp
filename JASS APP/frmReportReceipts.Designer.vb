<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportReceipts
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.rptReceipts = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.panelDatesRange = New System.Windows.Forms.Panel()
        Me.dtReceiptsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsReceipts = New JASS_APP.dsReceipts()
        CType(Me.dtReceiptsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptReceipts
        '
        Me.rptReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource3.Name = "dsReceipts"
        ReportDataSource3.Value = Me.dtReceiptsBindingSource
        Me.rptReceipts.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rptReceipts.LocalReport.ReportEmbeddedResource = "JASS_APP.rptReceiptsResumen.rdlc"
        Me.rptReceipts.Location = New System.Drawing.Point(0, 103)
        Me.rptReceipts.Name = "rptReceipts"
        Me.rptReceipts.ServerReport.BearerToken = Nothing
        Me.rptReceipts.Size = New System.Drawing.Size(634, 359)
        Me.rptReceipts.TabIndex = 0
        '
        'panelDatesRange
        '
        Me.panelDatesRange.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelDatesRange.BackColor = System.Drawing.Color.MediumTurquoise
        Me.panelDatesRange.Location = New System.Drawing.Point(0, 0)
        Me.panelDatesRange.Margin = New System.Windows.Forms.Padding(0)
        Me.panelDatesRange.Name = "panelDatesRange"
        Me.panelDatesRange.Size = New System.Drawing.Size(634, 100)
        Me.panelDatesRange.TabIndex = 1
        '
        'dtReceiptsBindingSource
        '
        Me.dtReceiptsBindingSource.DataMember = "dtReceipts"
        Me.dtReceiptsBindingSource.DataSource = Me.dsReceipts
        '
        'dsReceipts
        '
        Me.dsReceipts.DataSetName = "dsReceipts"
        Me.dsReceipts.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'frmReportReceipts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 461)
        Me.Controls.Add(Me.panelDatesRange)
        Me.Controls.Add(Me.rptReceipts)
        Me.Name = "frmReportReceipts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Pagos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dtReceiptsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rptReceipts As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtReceiptsBindingSource As BindingSource
    Friend WithEvents dsReceipts As dsReceipts
    Friend WithEvents panelDatesRange As Panel
End Class
