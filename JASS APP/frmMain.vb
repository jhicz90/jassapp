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
            Dispose()
        End If
    End Sub

    Private Sub tsmiNewLine_Click(sender As Object, e As EventArgs) Handles tsmiNewLine.Click
        showNewLine(Me)
    End Sub

    Private Sub tsmiNewUser_Click(sender As Object, e As EventArgs) Handles tsmiNewUser.Click
        showNewUser("new", Nothing, 1, Me)
    End Sub

    Private Sub tsmiFindLines_Click(sender As Object, e As EventArgs) Handles tsmiFindLines.Click
        showFindLines(Me)
    End Sub

    Private Sub tsmiCollectBox_Click(sender As Object, e As EventArgs) Handles tsmiCollectBox.Click
        showFindCollect(Me)
    End Sub

    Private Sub tsmiDeclarationServices_Click(sender As Object, e As EventArgs) Handles tsmiDeclarationServices.Click
        showDeclarationServices(Me)
    End Sub

    Private Sub tsmiRateType_Click(sender As Object, e As EventArgs) Handles tsmiRateType.Click
        showRateType(Me)
    End Sub

    Private Sub tsmiCollectDaily_Click(sender As Object, e As EventArgs) Handles tsmiCollectDaily.Click
        showReportReceipts()
    End Sub

    Private Sub tsmiCollectDailyResume_Click(sender As Object, e As EventArgs) Handles tsmiCollectDailyResume.Click
        showReportReceiptsResume()
    End Sub

    Private Sub tsmiCloseWindows_Click(sender As Object, e As EventArgs) Handles tsmiCloseWindows.Click
        Do
            If MdiChildren.Count > 0 Then
                Dim frm As Form = MdiChildren(0)
                frm.Close()
            End If
        Loop While MdiChildren.Count > 0
    End Sub

    Private Sub tsmiMinWindows_Click(sender As Object, e As EventArgs) Handles tsmiMinWindows.Click
        For index As Integer = 0 To MdiChildren.Count - 1
            Dim frm As Form = MdiChildren(index)
            frm.WindowState = FormWindowState.Minimized
        Next
    End Sub

    Private Sub tsmiMaxWindows_Click(sender As Object, e As EventArgs) Handles tsmiMaxWindows.Click
        For index As Integer = 0 To MdiChildren.Count - 1
            Dim frm As Form = MdiChildren(index)
            frm.WindowState = FormWindowState.Normal
        Next
    End Sub

    Private Sub tsmiAbout_Click(sender As Object, e As EventArgs) Handles tsmiAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub tsmiPreviewReceipt_Click(sender As Object, e As EventArgs) Handles tsmiPreviewReceipt.Click
        tsmiPreviewReceipt.Checked = Not My.Settings.vPreviewPrint
        My.Settings.vPreviewPrint = tsmiPreviewReceipt.Checked
    End Sub

    Private Sub frmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If cnnx.State = ConnectionState.Open Then
            cnnx.Close()
        End If
    End Sub
End Class
