Imports ClosedXML.Excel
Public Class frmDeclarationServices
    Dim dsYearsRate As DataSet = Nothing
    Dim vAction As Integer = 0
    Dim vExporOrImport As Boolean = False
    Private Sub frmDeclarationServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconDeclareservice
        MdiParent = frmMain
        CheckForIllegalCrossThreadCalls = False

        dsYearsRate = listYearRate()

        If Not dsYearsRate.HasErrors Then
            cbxYearRate.DataSource = dsYearsRate.Tables(0)
            cbxYearRate.ValueMember = "idyearrate"
            cbxYearRate.DisplayMember = "year"
            If cbxYearRate.Items.Count > 0 Then
                cbxYearRate.SelectedIndex = 0
            End If
        Else
            cbxYearRate.Enabled = False
            cbxYearRate.SelectedIndex = -1
        End If

        newDeclaration()
    End Sub

    Public Sub newDeclaration()
        cbxCrit.SelectedIndex = 0
    End Sub

    Public Sub blockWindow(vBlock As Boolean)
        Enabled = vBlock
    End Sub

    Public Sub exportExcel()
        Libro.SaveAs(dialogSaveExcel.FileName)
        exportingExcel(cbxYearRate.SelectedValue, cbxCrit.SelectedIndex, chkFillAccountsRate.Checked)
        Libro.Save()
        MsgBox("Exportación terminada con exito.", MsgBoxStyle.Information, "Excel")
        blockWindow(True)
    End Sub

    Private Sub chkOrder_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrder.CheckedChanged
        cbxCrit.Enabled = chkOrder.Checked
    End Sub

    Private Sub btnExportAccounts_Click(sender As Object, e As EventArgs) Handles btnExportAccounts.Click
        Libro = New XLWorkbook
        Hoja = Libro.Worksheets.Add("Otra hoja")

        Dim vAnno As String = ""
        If cbxYearRate.Items.Count > 0 Then
            vAnno = cbxYearRate.Text
        End If

        dialogSaveExcel.DefaultExt = "*.xlsx"
        dialogSaveExcel.FileName = "JASS " & vAnno & " - " & Date.Now.ToString("ddMMyyyy")
        dialogSaveExcel.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        dialogSaveExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)

        If dialogSaveExcel.ShowDialog(Me) = DialogResult.OK Then
            MsgBox("Se guardara en: " & vbCr & dialogSaveExcel.FileName, vbInformation, "Excel")
            vAction = 1
            vExporOrImport = True
            blockWindow(False)
            bgwServices.RunWorkerAsync()
        Else
            Libro.Dispose()
        End If
    End Sub

    Private Sub bgwServices_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwServices.DoWork
        Select Case vAction
            Case 1
                exportExcel()
        End Select
    End Sub
End Class