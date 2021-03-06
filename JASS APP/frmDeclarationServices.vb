﻿Imports System.ComponentModel
Imports ClosedXML.Excel
Public Class frmDeclarationServices
    Dim vAction As Integer = 0
    Dim vExporOrImport As Boolean = False
    Private Sub frmDeclarationServices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iconDeclareservice
        CheckForIllegalCrossThreadCalls = False

        listYearRate(cbxYearRate)
        newDeclaration()
    End Sub

    Public Sub newDeclaration()
        cbxCrit.SelectedIndex = 0
        cbxMonths.SelectedIndex = 0
    End Sub

    Public Sub blockWindow(vBlock As Boolean)
        Enabled = vBlock
    End Sub

    Public Sub exportExcel()
        Try
            Libro.SaveAs(dialogSaveExcel.FileName)
            exportingExcel(prgWorking, cbxYearRate.Text, cbxYearRate.SelectedValue, cbxCrit.SelectedIndex, chkFillAccountsRate.Checked, chkMonths.Checked, cbxMonths.SelectedIndex)
            Libro.Save()
            MsgBox("Exportación terminada con exito.", MsgBoxStyle.Information, "Excel")
            vExporOrImport = False
        Catch ex As Exception
            MsgBox("Error a la hora de exportar", MsgBoxStyle.Exclamation, "Excel")
            MsgBox(ex.Message)
        End Try
        blockWindow(True)
    End Sub

    Public Sub importExcel()
        Try
            importingExcel(prgWorking)
            MsgBox("Importación terminada con exito.", MsgBoxStyle.Information, "Excel")
            vExporOrImport = False
        Catch ex As Exception
            MsgBox("Error a la hora de importar", MsgBoxStyle.Exclamation, "Excel")
            MsgBox(ex.Message)
        End Try
        blockWindow(True)
    End Sub

    Private Sub chkOrder_CheckedChanged(sender As Object, e As EventArgs) Handles chkOrder.CheckedChanged
        cbxCrit.Enabled = chkOrder.Checked
    End Sub

    Private Sub chkMonths_CheckedChanged(sender As Object, e As EventArgs) Handles chkMonths.CheckedChanged
        cbxMonths.Enabled = chkMonths.Checked
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
            vExporOrImport = False
        End If
    End Sub

    Private Sub btnImportAccounts_Click(sender As Object, e As EventArgs) Handles btnImportAccounts.Click
        dialogOpenExcel.DefaultExt = "*.xlsx"
        dialogOpenExcel.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        dialogOpenExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)

        If dialogOpenExcel.ShowDialog(Me) = DialogResult.OK Then
            Libro = New XLWorkbook(dialogOpenExcel.FileName)
            Hoja = Libro.Worksheet("Servicios")
            vAction = 2
            vExporOrImport = True
            blockWindow(False)
            bgwServices.RunWorkerAsync()
        Else
            vExporOrImport = False
        End If
    End Sub

    Private Sub bgwServices_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwServices.DoWork
        Select Case vAction
            Case 1
                exportExcel()
            Case 2
                importExcel()
        End Select
    End Sub

    Private Sub frmDeclarationServices_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If vExporOrImport Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub
End Class