Public Class frmReceipt
    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles Me.Load
        printPrevReceipt.AutoZoom = True
    End Sub

    Private Sub printDocReceipt_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles printDocReceipt.PrintPage
        Dim receiptX As Integer = 1300 'Son 2 centimetros iniciales
        Dim receiptY As Integer = 300
        Dim receiptWidth As Integer = 0
        Dim receiptHeight As Integer = 0

        Dim receiptFont As New Font(FontFamily.GenericSerif, 12, FontStyle.Regular)
        Dim receiptFontData As New Font(FontFamily.GenericSerif, 10, FontStyle.Regular)

        Dim strFont As New StringFormat
        strFont.Alignment = StringAlignment.Center
        strFont.LineAlignment = StringAlignment.Center

        'Datos del usuario y recibo
        e.Graphics.DrawString("2019-DIC94-05335", receiptFont, Brushes.Black, 415, 43)
        e.Graphics.DrawString("0000001", receiptFont, Brushes.Black, 675, 43)
        e.Graphics.DrawString("JOSE HANS IBAÑEZ CASTRO", receiptFontData, Brushes.Black, 450, 84)
        e.Graphics.DrawString("46891419", receiptFontData, Brushes.Black, 450, 104)
        e.Graphics.DrawString("SAN PEDRO", receiptFontData, Brushes.Black, 450, 124)

        'Datos de los pago por concepto inicial es 188 +19.5
        e.Graphics.DrawString("SERVICIO DE ENERO 2020", receiptFontData, Brushes.Black, 75, 188)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 188)
        e.Graphics.DrawString("SERVICIO DE FEBRERO 2020", receiptFontData, Brushes.Black, 75, 208)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 208)
        e.Graphics.DrawString("SERVICIO DE MARZO 2020", receiptFontData, Brushes.Black, 75, 227)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 227)
        e.Graphics.DrawString("SERVICIO DE ABRIL 2020", receiptFontData, Brushes.Black, 75, 247)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 247)
        e.Graphics.DrawString("SERVICIO DE MAYO 2020", receiptFontData, Brushes.Black, 75, 266)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 266)
        e.Graphics.DrawString("SERVICIO DE JUNIO 2020", receiptFontData, Brushes.Black, 75, 286)
        e.Graphics.DrawString("15.00", receiptFontData, Brushes.Black, 675, 286)
        e.Graphics.DrawString("90.00", receiptFontData, Brushes.Black, 675, 305) 'TOTAL

        'Datos del recibo usuario de cobranza y fecha de emision de recibo
        e.Graphics.DrawString("JOSE HANS", receiptFontData, Brushes.Black, 125, 345) 'USUARIO
        e.Graphics.DrawString(Date.Today, receiptFontData, Brushes.Black, 665, 345) 'FECHA
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