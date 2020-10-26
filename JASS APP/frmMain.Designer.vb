<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.tsMainToolbar = New System.Windows.Forms.ToolStrip()
        Me.tsdpdFile = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNewLine = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiContract = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiConfigPrints = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPreviewReceipt = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiConfig = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdpdRegister = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiFindLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiFindUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdpdCollect = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiCollectBox = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDeclarationServices = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRateType = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiReceipts = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdpdWindows = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiMinWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMaxWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiCloseWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdpdReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiCollectDaily = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCollectDailyResume = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDebtsResume = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsdpdHelp = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.stStatusToolbar = New System.Windows.Forms.StatusStrip()
        Me.tsMainToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMainToolbar
        '
        Me.tsMainToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsdpdFile, Me.tsdpdRegister, Me.tsdpdCollect, Me.tsdpdWindows, Me.tsdpdReports, Me.tsdpdHelp})
        Me.tsMainToolbar.Location = New System.Drawing.Point(0, 0)
        Me.tsMainToolbar.Name = "tsMainToolbar"
        Me.tsMainToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsMainToolbar.Size = New System.Drawing.Size(1045, 25)
        Me.tsMainToolbar.TabIndex = 0
        Me.tsMainToolbar.Text = "MainToolbar"
        '
        'tsdpdFile
        '
        Me.tsdpdFile.AutoToolTip = False
        Me.tsdpdFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNew, Me.tsmiPrint, Me.tsmiConfig, Me.tsmiBackup, Me.tsmiRestore, Me.tsmiExit})
        Me.tsdpdFile.Image = Global.JASS_APP.My.Resources.Resources.top_menu_32
        Me.tsdpdFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdFile.Name = "tsdpdFile"
        Me.tsdpdFile.ShowDropDownArrow = False
        Me.tsdpdFile.Size = New System.Drawing.Size(68, 22)
        Me.tsdpdFile.Text = "Archivo"
        '
        'tsmiNew
        '
        Me.tsmiNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNewLine, Me.tsmiContract, Me.tsmiNewUser})
        Me.tsmiNew.Image = Global.JASS_APP.My.Resources.Resources.btn_add
        Me.tsmiNew.Name = "tsmiNew"
        Me.tsmiNew.Size = New System.Drawing.Size(198, 22)
        Me.tsmiNew.Text = "Nuevo"
        '
        'tsmiNewLine
        '
        Me.tsmiNewLine.Image = Global.JASS_APP.My.Resources.Resources.plumbing
        Me.tsmiNewLine.Name = "tsmiNewLine"
        Me.tsmiNewLine.ShortcutKeyDisplayString = "F3"
        Me.tsmiNewLine.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.tsmiNewLine.Size = New System.Drawing.Size(180, 22)
        Me.tsmiNewLine.Text = "Linea de servicio"
        '
        'tsmiContract
        '
        Me.tsmiContract.Name = "tsmiContract"
        Me.tsmiContract.ShortcutKeyDisplayString = ""
        Me.tsmiContract.Size = New System.Drawing.Size(180, 22)
        Me.tsmiContract.Text = "Convenio"
        '
        'tsmiNewUser
        '
        Me.tsmiNewUser.Image = Global.JASS_APP.My.Resources.Resources.new_contact
        Me.tsmiNewUser.Name = "tsmiNewUser"
        Me.tsmiNewUser.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.tsmiNewUser.Size = New System.Drawing.Size(180, 22)
        Me.tsmiNewUser.Text = "Usuario"
        '
        'tsmiPrint
        '
        Me.tsmiPrint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiConfigPrints, Me.tsmiPreviewReceipt})
        Me.tsmiPrint.Image = Global.JASS_APP.My.Resources.Resources.print
        Me.tsmiPrint.Name = "tsmiPrint"
        Me.tsmiPrint.Size = New System.Drawing.Size(198, 22)
        Me.tsmiPrint.Text = "Impresora"
        '
        'tsmiConfigPrints
        '
        Me.tsmiConfigPrints.Name = "tsmiConfigPrints"
        Me.tsmiConfigPrints.Size = New System.Drawing.Size(252, 22)
        Me.tsmiConfigPrints.Text = "Configurar impresoras"
        '
        'tsmiPreviewReceipt
        '
        Me.tsmiPreviewReceipt.Checked = Global.JASS_APP.My.MySettings.Default.vPreviewPrint
        Me.tsmiPreviewReceipt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmiPreviewReceipt.Name = "tsmiPreviewReceipt"
        Me.tsmiPreviewReceipt.Size = New System.Drawing.Size(252, 22)
        Me.tsmiPreviewReceipt.Text = "Previsualizar impresion de recibos"
        '
        'tsmiConfig
        '
        Me.tsmiConfig.Image = Global.JASS_APP.My.Resources.Resources.administrative_tools
        Me.tsmiConfig.Name = "tsmiConfig"
        Me.tsmiConfig.Size = New System.Drawing.Size(198, 22)
        Me.tsmiConfig.Text = "Configuración"
        '
        'tsmiBackup
        '
        Me.tsmiBackup.Image = Global.JASS_APP.My.Resources.Resources.database_view
        Me.tsmiBackup.Name = "tsmiBackup"
        Me.tsmiBackup.Size = New System.Drawing.Size(198, 22)
        Me.tsmiBackup.Text = "Copia de seguridad"
        '
        'tsmiRestore
        '
        Me.tsmiRestore.Image = Global.JASS_APP.My.Resources.Resources.reload_update
        Me.tsmiRestore.Name = "tsmiRestore"
        Me.tsmiRestore.Size = New System.Drawing.Size(198, 22)
        Me.tsmiRestore.Text = "Restaurar base de datos"
        '
        'tsmiExit
        '
        Me.tsmiExit.Image = Global.JASS_APP.My.Resources.Resources.close_window
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.ShortcutKeyDisplayString = "Alt + F4"
        Me.tsmiExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.tsmiExit.Size = New System.Drawing.Size(198, 22)
        Me.tsmiExit.Text = "&Salir"
        '
        'tsdpdRegister
        '
        Me.tsdpdRegister.AutoToolTip = False
        Me.tsdpdRegister.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFindLines, Me.tsmiFindUsers})
        Me.tsdpdRegister.Image = Global.JASS_APP.My.Resources.Resources.book_stack_32
        Me.tsdpdRegister.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdRegister.Name = "tsdpdRegister"
        Me.tsdpdRegister.ShowDropDownArrow = False
        Me.tsdpdRegister.Size = New System.Drawing.Size(70, 22)
        Me.tsdpdRegister.Text = "Registro"
        '
        'tsmiFindLines
        '
        Me.tsmiFindLines.Image = Global.JASS_APP.My.Resources.Resources.plumbing
        Me.tsmiFindLines.Name = "tsmiFindLines"
        Me.tsmiFindLines.ShortcutKeyDisplayString = "F4"
        Me.tsmiFindLines.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.tsmiFindLines.Size = New System.Drawing.Size(209, 22)
        Me.tsmiFindLines.Text = "Lineas de servicio"
        '
        'tsmiFindUsers
        '
        Me.tsmiFindUsers.Image = Global.JASS_APP.My.Resources.Resources.user_account
        Me.tsmiFindUsers.Name = "tsmiFindUsers"
        Me.tsmiFindUsers.Size = New System.Drawing.Size(209, 22)
        Me.tsmiFindUsers.Text = "Usuarios o representantes"
        '
        'tsdpdCollect
        '
        Me.tsdpdCollect.AutoToolTip = False
        Me.tsdpdCollect.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCollectBox, Me.tsmiDeclarationServices, Me.tsmiRateType, Me.tsmiReceipts})
        Me.tsdpdCollect.Image = Global.JASS_APP.My.Resources.Resources.coins_32
        Me.tsdpdCollect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdCollect.Name = "tsdpdCollect"
        Me.tsdpdCollect.ShowDropDownArrow = False
        Me.tsdpdCollect.Size = New System.Drawing.Size(77, 22)
        Me.tsdpdCollect.Text = "Cobranza"
        '
        'tsmiCollectBox
        '
        Me.tsmiCollectBox.Image = Global.JASS_APP.My.Resources.Resources.coin_in_hand
        Me.tsmiCollectBox.Name = "tsmiCollectBox"
        Me.tsmiCollectBox.ShortcutKeyDisplayString = "F5"
        Me.tsmiCollectBox.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.tsmiCollectBox.Size = New System.Drawing.Size(200, 22)
        Me.tsmiCollectBox.Text = "Caja de cobranza"
        '
        'tsmiDeclarationServices
        '
        Me.tsmiDeclarationServices.Image = Global.JASS_APP.My.Resources.Resources._event
        Me.tsmiDeclarationServices.Name = "tsmiDeclarationServices"
        Me.tsmiDeclarationServices.Size = New System.Drawing.Size(200, 22)
        Me.tsmiDeclarationServices.Text = "Declaración de servicios"
        '
        'tsmiRateType
        '
        Me.tsmiRateType.Image = Global.JASS_APP.My.Resources.Resources.todo_list
        Me.tsmiRateType.Name = "tsmiRateType"
        Me.tsmiRateType.Size = New System.Drawing.Size(200, 22)
        Me.tsmiRateType.Text = "Años, tarifas y servicios"
        '
        'tsmiReceipts
        '
        Me.tsmiReceipts.Image = Global.JASS_APP.My.Resources.Resources.receipt_check
        Me.tsmiReceipts.Name = "tsmiReceipts"
        Me.tsmiReceipts.Size = New System.Drawing.Size(200, 22)
        Me.tsmiReceipts.Text = "Recibos"
        '
        'tsdpdWindows
        '
        Me.tsdpdWindows.AutoToolTip = False
        Me.tsdpdWindows.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiMinWindows, Me.tsmiMaxWindows, Me.ToolStripSeparator1, Me.tsmiCloseWindows})
        Me.tsdpdWindows.Image = Global.JASS_APP.My.Resources.Resources.restore_window_32
        Me.tsdpdWindows.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdWindows.Name = "tsdpdWindows"
        Me.tsdpdWindows.ShowDropDownArrow = False
        Me.tsdpdWindows.Size = New System.Drawing.Size(74, 22)
        Me.tsdpdWindows.Text = "Ventanas"
        '
        'tsmiMinWindows
        '
        Me.tsmiMinWindows.Name = "tsmiMinWindows"
        Me.tsmiMinWindows.Size = New System.Drawing.Size(226, 22)
        Me.tsmiMinWindows.Text = "Minimizar todas las ventanas"
        '
        'tsmiMaxWindows
        '
        Me.tsmiMaxWindows.Name = "tsmiMaxWindows"
        Me.tsmiMaxWindows.Size = New System.Drawing.Size(226, 22)
        Me.tsmiMaxWindows.Text = "Mostrar todas las ventanas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(223, 6)
        '
        'tsmiCloseWindows
        '
        Me.tsmiCloseWindows.Name = "tsmiCloseWindows"
        Me.tsmiCloseWindows.Size = New System.Drawing.Size(226, 22)
        Me.tsmiCloseWindows.Text = "Cerrar todas las ventanas"
        '
        'tsdpdReports
        '
        Me.tsdpdReports.AutoToolTip = False
        Me.tsdpdReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCollectDaily, Me.tsmiCollectDailyResume, Me.tsmiDebtsResume})
        Me.tsdpdReports.Image = Global.JASS_APP.My.Resources.Resources.analyze_32
        Me.tsdpdReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdReports.Name = "tsdpdReports"
        Me.tsdpdReports.ShowDropDownArrow = False
        Me.tsdpdReports.Size = New System.Drawing.Size(73, 22)
        Me.tsdpdReports.Text = "Reportes"
        '
        'tsmiCollectDaily
        '
        Me.tsmiCollectDaily.Name = "tsmiCollectDaily"
        Me.tsmiCollectDaily.Size = New System.Drawing.Size(263, 22)
        Me.tsmiCollectDaily.Text = "Reporte a detalle de cobranza diaria"
        '
        'tsmiCollectDailyResume
        '
        Me.tsmiCollectDailyResume.Name = "tsmiCollectDailyResume"
        Me.tsmiCollectDailyResume.Size = New System.Drawing.Size(263, 22)
        Me.tsmiCollectDailyResume.Text = "Reporte resumen de cobranza diaria"
        '
        'tsmiDebtsResume
        '
        Me.tsmiDebtsResume.Name = "tsmiDebtsResume"
        Me.tsmiDebtsResume.Size = New System.Drawing.Size(263, 22)
        Me.tsmiDebtsResume.Text = "Reporte resumen de deudas"
        '
        'tsdpdHelp
        '
        Me.tsdpdHelp.AutoToolTip = False
        Me.tsdpdHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAbout})
        Me.tsdpdHelp.Image = Global.JASS_APP.My.Resources.Resources.help_32
        Me.tsdpdHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdpdHelp.Name = "tsdpdHelp"
        Me.tsdpdHelp.ShowDropDownArrow = False
        Me.tsdpdHelp.Size = New System.Drawing.Size(61, 22)
        Me.tsdpdHelp.Text = "Ayuda"
        '
        'tsmiAbout
        '
        Me.tsmiAbout.Name = "tsmiAbout"
        Me.tsmiAbout.Size = New System.Drawing.Size(136, 22)
        Me.tsmiAbout.Text = "Acerda de..."
        '
        'stStatusToolbar
        '
        Me.stStatusToolbar.Location = New System.Drawing.Point(0, 668)
        Me.stStatusToolbar.Name = "stStatusToolbar"
        Me.stStatusToolbar.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.stStatusToolbar.Size = New System.Drawing.Size(1045, 22)
        Me.stStatusToolbar.TabIndex = 1
        Me.stStatusToolbar.Text = "StatusToolbar"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 690)
        Me.Controls.Add(Me.stStatusToolbar)
        Me.Controls.Add(Me.tsMainToolbar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JASS - Junta administradora de servicios de saneamiento"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsMainToolbar.ResumeLayout(False)
        Me.tsMainToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMainToolbar As ToolStrip
    Friend WithEvents stStatusToolbar As StatusStrip
    Friend WithEvents tsdpdFile As ToolStripDropDownButton
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiNewLine As ToolStripMenuItem
    Friend WithEvents tsmiContract As ToolStripMenuItem
    Friend WithEvents tsmiPrint As ToolStripMenuItem
    Friend WithEvents tsmiConfig As ToolStripMenuItem
    Friend WithEvents tsmiExit As ToolStripMenuItem
    Friend WithEvents tsdpdRegister As ToolStripDropDownButton
    Friend WithEvents tsmiFindLines As ToolStripMenuItem
    Friend WithEvents tsdpdCollect As ToolStripDropDownButton
    Friend WithEvents tsmiCollectBox As ToolStripMenuItem
    Friend WithEvents tsdpdWindows As ToolStripDropDownButton
    Friend WithEvents tsmiCloseWindows As ToolStripMenuItem
    Friend WithEvents tsdpdReports As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiMinWindows As ToolStripMenuItem
    Friend WithEvents tsmiMaxWindows As ToolStripMenuItem
    Friend WithEvents tsmiFindUsers As ToolStripMenuItem
    Friend WithEvents tsdpdHelp As ToolStripDropDownButton
    Friend WithEvents tsmiAbout As ToolStripMenuItem
    Friend WithEvents tsmiNewUser As ToolStripMenuItem
    Friend WithEvents tsmiConfigPrints As ToolStripMenuItem
    Friend WithEvents tsmiPreviewReceipt As ToolStripMenuItem
    Friend WithEvents tsmiDeclarationServices As ToolStripMenuItem
    Friend WithEvents tsmiRateType As ToolStripMenuItem
    Friend WithEvents tsmiCollectDaily As ToolStripMenuItem
    Friend WithEvents tsmiCollectDailyResume As ToolStripMenuItem
    Friend WithEvents tsmiBackup As ToolStripMenuItem
    Friend WithEvents tsmiRestore As ToolStripMenuItem
    Friend WithEvents tsmiReceipts As ToolStripMenuItem
    Friend WithEvents tsmiDebtsResume As ToolStripMenuItem
End Class
