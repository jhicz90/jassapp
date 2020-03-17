Partial Class dsDebts
    Partial Public Class dtDebtsResumeDataTable
        Private Sub dtDebtsResumeDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.debttodateColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class
End Class
