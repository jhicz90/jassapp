Public Class frmMain
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Icon = My.Resources.iconApp
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
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

    Private Sub tsmiCloseWindows_Click(sender As Object, e As EventArgs) Handles tsmiCloseWindows.Click
        frmNewline.Close()
        frmFindLines.Close()
        frmEditLine.Close()
    End Sub

    Private Sub tsmiMinWindows_Click(sender As Object, e As EventArgs) Handles tsmiMinWindows.Click
        frmNewline.WindowState = FormWindowState.Minimized
        frmFindLines.WindowState = FormWindowState.Minimized
        frmEditLine.WindowState = FormWindowState.Minimized
        frmNewuser.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub tsmiMaxWindows_Click(sender As Object, e As EventArgs) Handles tsmiMaxWindows.Click
        frmNewline.WindowState = FormWindowState.Normal
        frmFindLines.WindowState = FormWindowState.Normal
        frmEditLine.WindowState = FormWindowState.Normal
        frmNewuser.WindowState = FormWindowState.Normal
    End Sub

    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        frmAbout.ShowDialog()
    End Sub
End Class
