<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceipt
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
        Me.printDocReceipt = New System.Drawing.Printing.PrintDocument()
        Me.printPrevReceipt = New System.Windows.Forms.PrintPreviewControl()
        Me.btnZoomIn = New System.Windows.Forms.Button()
        Me.btnZoomOut = New System.Windows.Forms.Button()
        Me.btnPrintReceipt = New System.Windows.Forms.Button()
        Me.printDialogReceipt = New System.Windows.Forms.PrintDialog()
        Me.SuspendLayout()
        '
        'printDocReceipt
        '
        '
        'printPrevReceipt
        '
        Me.printPrevReceipt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printPrevReceipt.AutoZoom = False
        Me.printPrevReceipt.Document = Me.printDocReceipt
        Me.printPrevReceipt.Location = New System.Drawing.Point(12, 41)
        Me.printPrevReceipt.Name = "printPrevReceipt"
        Me.printPrevReceipt.Size = New System.Drawing.Size(660, 308)
        Me.printPrevReceipt.TabIndex = 0
        Me.printPrevReceipt.Zoom = 0.25662959794696322R
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Location = New System.Drawing.Point(12, 12)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(75, 23)
        Me.btnZoomIn.TabIndex = 1
        Me.btnZoomIn.Text = "Aumentar"
        Me.btnZoomIn.UseVisualStyleBackColor = True
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Location = New System.Drawing.Point(93, 12)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(75, 23)
        Me.btnZoomOut.TabIndex = 2
        Me.btnZoomOut.Text = "Reducir"
        Me.btnZoomOut.UseVisualStyleBackColor = True
        '
        'btnPrintReceipt
        '
        Me.btnPrintReceipt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintReceipt.Location = New System.Drawing.Point(597, 12)
        Me.btnPrintReceipt.Name = "btnPrintReceipt"
        Me.btnPrintReceipt.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintReceipt.TabIndex = 3
        Me.btnPrintReceipt.Text = "Imprimir"
        Me.btnPrintReceipt.UseVisualStyleBackColor = True
        '
        'printDialogReceipt
        '
        Me.printDialogReceipt.UseEXDialog = True
        '
        'frmReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 361)
        Me.Controls.Add(Me.btnPrintReceipt)
        Me.Controls.Add(Me.btnZoomOut)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.printPrevReceipt)
        Me.Name = "frmReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents printDocReceipt As Printing.PrintDocument
    Friend WithEvents printPrevReceipt As PrintPreviewControl
    Friend WithEvents btnZoomIn As Button
    Friend WithEvents btnZoomOut As Button
    Friend WithEvents btnPrintReceipt As Button
    Friend WithEvents printDialogReceipt As PrintDialog
End Class
