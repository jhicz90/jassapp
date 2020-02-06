Public Class frmMain
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Icon = My.Resources.iconApp
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        tsmiPreviewReceipt.Checked = My.Settings.vPreviewPrint
    End Sub

    Private Sub TsmiExit_Click(sender As Object, e As EventArgs) Handles tsmiExit.Click
        Application.Exit()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If frmLogin.ShowDialog() = DialogResult.Cancel Then
            Me.Dispose()
        End If
    End Sub

    Private Sub tsmiNewLine_Click(sender As Object, e As EventArgs) Handles tsmiNewLine.Click
        frmNewline.Show()
        frmNewline.Focus()
    End Sub

    Private Sub tsmiNewUser_Click(sender As Object, e As EventArgs) Handles tsmiNewUser.Click
        'Nuevo usuario
    End Sub

    Private Sub tsmiFindLines_Click(sender As Object, e As EventArgs) Handles tsmiFindLines.Click
        frmFindLines.Show()
        frmFindLines.Focus()
    End Sub

    Private Sub tsmiCollectBox_Click(sender As Object, e As EventArgs) Handles tsmiCollectBox.Click
        frmFindCollect.Show()
        frmFindCollect.Focus()
    End Sub

    Private Sub tsmiDeclarationServices_Click(sender As Object, e As EventArgs) Handles tsmiDeclarationServices.Click
        frmDeclarationServices.Show()
        frmDeclarationServices.Focus()
    End Sub

    Private Sub tsmiCloseWindows_Click(sender As Object, e As EventArgs) Handles tsmiCloseWindows.Click
        frmNewline.Close()
        frmFindLines.Close()
        frmFindCollect.Close()
        frmEditLine.Close()
        frmNewuser.Close()
        frmDeclarationServices.Close()
    End Sub

    Private Sub tsmiMinWindows_Click(sender As Object, e As EventArgs) Handles tsmiMinWindows.Click
        frmNewline.WindowState = FormWindowState.Minimized
        frmFindLines.WindowState = FormWindowState.Minimized
        frmFindCollect.WindowState = FormWindowState.Minimized
        frmEditLine.WindowState = FormWindowState.Minimized
        frmNewuser.WindowState = FormWindowState.Minimized
        frmDeclarationServices.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub tsmiMaxWindows_Click(sender As Object, e As EventArgs) Handles tsmiMaxWindows.Click
        frmNewline.WindowState = FormWindowState.Normal
        frmFindLines.WindowState = FormWindowState.Normal
        frmFindCollect.WindowState = FormWindowState.Normal
        frmEditLine.WindowState = FormWindowState.Normal
        frmNewuser.WindowState = FormWindowState.Normal
        frmDeclarationServices.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub tsmiPreviewReceipt_Click(sender As Object, e As EventArgs) Handles tsmiPreviewReceipt.Click
        tsmiPreviewReceipt.Checked = Not My.Settings.vPreviewPrint
        My.Settings.vPreviewPrint = Not My.Settings.vPreviewPrint
    End Sub

    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If cnnx.State = ConnectionState.Open Then
            cnnx.Close()
        End If
    End Sub
End Class
