Public Class frmReceipt
    Public receiptDataStr(6) As String
    Public receiptConceptStr(12) As String
    Public previewPrint As Boolean = False
    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iconReceipt

        printPrevReceipt.AutoZoom = True

        If previewPrint = False Then
            printDialogReceipt.Document = printDocReceipt
            printDocReceipt.Print()
            Close()
        End If
    End Sub

    Private Sub printDocReceipt_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDocReceipt.PrintPage
        Dim receiptFont As New Font(FontFamily.GenericSerif, 12, FontStyle.Regular)
        Dim receiptFontData As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)

        Dim strFont As New StringFormat
        strFont.Alignment = StringAlignment.Center
        strFont.LineAlignment = StringAlignment.Center

        For copyIndex As Integer = 0 To 2
            'Datos del usuario y recibo
            e.Graphics.DrawString(receiptDataStr(0), receiptFont, Brushes.Black, 415, 43 + (355 * copyIndex)) 'Codigo de linea
            e.Graphics.DrawString(receiptDataStr(1), receiptFont, Brushes.Black, 675, 43 + (355 * copyIndex)) 'Numero de recibo
            e.Graphics.DrawString(receiptDataStr(2), receiptFontData, Brushes.Black, 450, 84 + (355 * copyIndex)) 'Nombre de usuario
            e.Graphics.DrawString(receiptDataStr(3), receiptFontData, Brushes.Black, 450, 104 + (355 * copyIndex)) 'Numero de documento de usuario
            e.Graphics.DrawString(receiptDataStr(4), receiptFontData, Brushes.Black, 450, 124 + (355 * copyIndex)) 'Calle de la linea

            'Datos de los pago por concepto inicial es 188 +19.5
            For index As Integer = 0 To 5
                e.Graphics.DrawString(receiptConceptStr(index), receiptFontData, Brushes.Black, 75, Math.Round(188 + (19.5 * index) + (355 * copyIndex), 0))
                e.Graphics.DrawString(receiptConceptStr(index + 6), receiptFontData, Brushes.Black, 675, Math.Round(188 + (19.5 * index) + (355 * copyIndex), 0))
            Next
            e.Graphics.DrawString(receiptConceptStr(12), receiptFontData, Brushes.Black, 675, 305 + (355 * copyIndex)) 'TOTAL

            'Datos del recibo usuario de cobranza y fecha de emision de recibo
            e.Graphics.DrawString(receiptDataStr(5), receiptFontData, Brushes.Black, 125, 345 + (355 * copyIndex)) 'USUARIO
            e.Graphics.DrawString(receiptDataStr(6), receiptFontData, Brushes.Black, 640, 345 + (355 * copyIndex)) 'FECHA
        Next
    End Sub

    Private Sub btnZoomIn_Click(sender As Object, e As EventArgs) Handles btnZoomIn.Click
        printPrevReceipt.Zoom = 1.2
    End Sub

    Private Sub btnZoomOut_Click(sender As Object, e As EventArgs) Handles btnZoomOut.Click
        printPrevReceipt.AutoZoom = True
    End Sub

    Private Sub btnPrintReceipt_Click(sender As Object, e As EventArgs) Handles btnPrintReceipt.Click
        printDialogReceipt.Document = printDocReceipt
        If printDialogReceipt.ShowDialog = DialogResult.OK Then
            printDocReceipt.Print()
        End If
    End Sub
End Class