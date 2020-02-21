Imports System.ComponentModel

Public Class frmLogin

    ' TODO: inserte el c�digo para realizar autenticaci�n personalizada usando el nombre de usuario y la contrase�a proporcionada 
    ' (Consulte https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuaci�n: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementaci�n de IPrincipal utilizada para realizar la autenticaci�n. 
    ' Posteriormente, My.User devolver� la informaci�n de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If DatabaseConnect() Then
            getYearActive()
            If userLogin(UsernameTextBox.Text, PasswordTextBox.Text) = True Then
                DialogResult = DialogResult.OK
            End If
        Else
            Close()
            Application.Exit()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        checkMysql()
    End Sub

    Public Sub checkMysql()
        Dim cheking As Integer = detectedMysql()

        If cheking = 1 Then
            lblState.Text = "DB: Iniciada"
            OK.Enabled = True
        ElseIf cheking = 2 Then
            lblState.Text = "DB: Ejecutada"
            OK.Enabled = True
        Else
            lblState.Text = "DB: No iniciada"
            OK.Enabled = False
        End If
    End Sub

    Private Sub btnCheckMysql_Click(sender As Object, e As EventArgs) Handles btnCheckMysql.Click
        checkMysql()
    End Sub
End Class
