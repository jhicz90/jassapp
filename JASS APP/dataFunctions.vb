Imports System.Data.OleDb
Imports System.IO
Imports ClosedXML.Excel
Imports MySql.Data.MySqlClient

Module dataFunctions
    Public Libro As XLWorkbook
    Public Hoja As IXLWorksheet
    Public cnnx As New MySqlConnection
    Public cnnstr As New MySqlConnectionStringBuilder

    Public Function DatabaseConnect() As Boolean
        Try
            If cnnx.State = ConnectionState.Closed Then
                cnnstr.Server = "localhost"
                cnnstr.UserID = "root"
                cnnstr.Password = ""
                cnnstr.Database = "jassdb"
                cnnx.ConnectionString = cnnstr.ToString
                cnnx.Open()
            End If

            Return True
        Catch ex As Exception
            MsgBox("No pudo completarse la conección a la base de datos.", vbCritical, "Aviso")
            cnnx.Close()
            Return False
        End Try
    End Function

    Public Function detectedMysql() As Integer
        Dim mysqlExe As New Process
        Dim routeFile As String = "C:\xampp\mysql\bin\mysqld.exe"

        Try
            Dim execute As Boolean
            For Each p In Process.GetProcesses()
                If Not p Is Nothing Then
                    If p.ProcessName = "mysqld" Then
                        execute = True
                        Exit For
                    Else
                        execute = False
                    End If
                End If
            Next

            If execute = True Then
                Return 2
            Else
                mysqlExe.StartInfo.FileName = routeFile
                mysqlExe.Start()
                Return 1
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub backupDBMysql()
        Dim dialogSaveBackup As New SaveFileDialog

        Try
            dialogSaveBackup.Filter = "SQL Backup (*.sql)|*.sql|Todos los archivos (*.*)|*.*"
            dialogSaveBackup.FileName = "JASS backup - " & DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") & ".sql"

            If dialogSaveBackup.ShowDialog = DialogResult.OK Then
                Dim backupFile As String = dialogSaveBackup.FileName
                Dim backupProcess As New Process
                backupProcess.StartInfo.FileName = "cmd.exe"
                backupProcess.StartInfo.UseShellExecute = False
                backupProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                backupProcess.StartInfo.RedirectStandardInput = True
                backupProcess.StartInfo.RedirectStandardOutput = True
                backupProcess.Start()

                Dim backupStream As StreamWriter = backupProcess.StandardInput
                Dim myStreamReader As StreamReader = backupProcess.StandardOutput
                backupStream.WriteLine("mysqldump --user=root --password= -h localhost jassdb > """ & backupFile & """")

                backupStream.Close()
                backupProcess.WaitForExit()
                backupProcess.Close()
                MsgBox("La copia de la base de datos JASS ah sido creada", vbInformation, "Aviso")
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error en la copia de la base de datos", vbExclamation, "Aviso")
        End Try
    End Sub

    Public Sub restoreDBMysql()
        Dim dialogOpenBackup As New OpenFileDialog

        Try
            dialogOpenBackup.Filter = "SQL Backup (*.sql)|*.sql|Todos los archivos (*.*)|*.*"

            If dialogOpenBackup.ShowDialog = DialogResult.OK Then
                Dim backupFile As String = dialogOpenBackup.FileName
                Dim backupProcess As New Process
                backupProcess.StartInfo.FileName = "cmd.exe"
                backupProcess.StartInfo.UseShellExecute = False
                backupProcess.StartInfo.WorkingDirectory = "C:\xampp\mysql\bin\"
                backupProcess.StartInfo.RedirectStandardInput = True
                backupProcess.StartInfo.RedirectStandardOutput = True
                backupProcess.Start()

                Dim backupStream As StreamWriter = backupProcess.StandardInput
                Dim myStreamReader As StreamReader = backupProcess.StandardOutput
                backupStream.WriteLine("mysql -u root jassdb < """ & backupFile & """ && exit")

                backupStream.Close()
                backupProcess.WaitForExit()
                backupProcess.Close()
                MsgBox("La base de datos JASS ha sido restaurada correctamente." & vbCr & "Ahora el programa se cerrara para cargar los nuevos datos", vbInformation, "Aviso")
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox("Ocurrio un error en la restauración de la base de datos", vbExclamation, "Aviso")
        End Try
    End Sub

    Public Function userLogin(ByVal nameusr As String, ByVal passwd As String) As Boolean
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableUserSystem As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return False
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT idusersys ,name, loguser, passuser FROM user_sys WHERE loguser = @name AND passuser = @pass"
                cmd.Parameters.AddWithValue("name", nameusr)
                cmd.Parameters.AddWithValue("pass", passwd)
                ada.SelectCommand = cmd
                ada.Fill(tableUserSystem)

                If tableUserSystem.Rows.Count > 0 Then
                    For index As Integer = 0 To tableUserSystem.Rows.Count - 1
                        My.Settings.vUserIdLogin = CInt(tableUserSystem.Rows(index).Item(0).ToString)
                        My.Settings.vUserNameLogin = tableUserSystem.Rows(index).Item(1).ToString
                    Next
                    MsgBox("Bienvenid@ " + tableUserSystem.Rows(0).Item(1).ToString, vbInformation, "Aviso")
                    Return True
                Else
                    MsgBox("El usuario o contraseña ingresadas son incorrectas o no existen", vbExclamation, "Aviso")
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Public Sub getYearActive()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableYear As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT years_rate.idyearrate, years_rate.year, years_rate.nameyear FROM years_rate WHERE years_rate.active = 1 LIMIT 1"
                ada.SelectCommand = cmd
                ada.Fill(tableYear)

                My.Settings.vIdYear = tableYear.Rows(0).Item(0).ToString
                My.Settings.vYear = CInt(tableYear.Rows(0).Item(1).ToString)
                My.Settings.vYearName = tableYear.Rows(0).Item(2).ToString
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function generateCode(vLen As Integer, vLower As Boolean, vUpper As Boolean, vNumber As Boolean) As String
        Dim intRnd As Integer
        Dim intStep As Integer = Nothing
        Dim strcode As String
        Dim intlength As Integer
        Dim strinputstring As String = ""
        Dim Numbers As String = "12345678901234567890"
        Dim Lower As String = "abcdefghijklmnopqrstuvwxyzyz"
        Dim Upper As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZYZ"
        Dim intnamelength As Integer = 1


        If vLower Then strinputstring &= Lower
        If vNumber Then strinputstring &= Numbers
        If vUpper Then strinputstring &= Upper

        intlength = Len(strinputstring)

        Integer.TryParse(vLen, intnamelength)

        Randomize()

        strcode = ""

        For inStep = 1 To intnamelength

            intRnd = Int(Rnd() * intlength) + 1

            strcode &= Mid(strinputstring, intRnd, 1)

        Next

        Return strcode
    End Function

    Public Function generateCodeLine(vIdSector As String) As String
        Dim cmdStreet, cmdLastServiceLine, cmdCheck As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableStreet, tableLast, tableCheck As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Dim index As Integer = 1
            Do
                Try
                    cmdStreet.Connection = cnnx
                    cmdStreet.CommandType = CommandType.Text
                    cmdStreet.CommandText = "SELECT code FROM streets WHERE idstreet LIKE @idsector"
                    cmdStreet.Parameters.AddWithValue("idsector", vIdSector)
                    ada.SelectCommand = cmdStreet
                    ada.Fill(tableStreet)

                    If tableStreet.Rows.Count > 0 Then
                        Dim streetLine As String = tableStreet.Rows(0).Item(0).ToString
                        Dim codeLine As String = ""
                        Dim codeNum As String = ""

                        cmdLastServiceLine.Connection = cnnx
                        cmdLastServiceLine.CommandType = CommandType.Text
                        cmdLastServiceLine.CommandText = "SELECT MAX(service_line.idserviceline) AS id FROM service_line"
                        ada.SelectCommand = cmdLastServiceLine
                        ada.Fill(tableLast)

                        If tableLast.Rows.Count > 0 Then
                            codeNum = CInt(tableLast.Rows(0).Item(0).ToString) + index
                        Else
                            codeNum = "1"
                        End If

                        codeLine = Year(Today).ToString & "-" & Trim(streetLine) & "-" & codeNum.PadLeft(5, "0")

                        cmdCheck.Connection = cnnx
                        cmdCheck.CommandType = CommandType.Text
                        cmdCheck.CommandText = "SELECT code FROM service_line WHERE code LIKE @codserviceline"
                        cmdCheck.Parameters.AddWithValue("codserviceline", codeLine)
                        ada.SelectCommand = cmdCheck
                        ada.Fill(tableCheck)

                        If tableCheck.Rows.Count > 0 Then
                            index += 1
                        Else
                            Return codeLine
                        End If
                    Else
                        Return Nothing
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            Loop
        End If
    End Function

    Public Function compareDataLine(vDataLineOriginal() As String, vDataLineEdited() As String) As Boolean
        Dim vResult As Boolean = True
        For index As Integer = 0 To vDataLineOriginal.Length - 1
            If (Not (vDataLineOriginal(index) = vDataLineEdited(index))) And index <> 8 Then
                'MsgBox("Primer dato: " & vDataLineOriginal(index) & vbCr & "Segundo dato: " & vDataLineEdited(index))
                vResult = False
                Exit For
            End If
        Next
        Return vResult
    End Function

    Public Sub listYearRate(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idyearrate, year FROM years_rate", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idyearrate"
                vControl.DisplayMember = "year"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listRates(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idrate, name FROM rates", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idrate"
                vControl.DisplayMember = "name"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listServices(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idratetype, (CONCAT(name, "" - "", description)) AS namerate FROM rate_types", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idratetype"
                vControl.DisplayMember = "namerate"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listAvenues(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idstreet, name FROM streets ORDER BY name", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idstreet"
                vControl.DisplayMember = "name"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listUserTypes(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idusertype, name FROM user_type", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idusertype"
                vControl.DisplayMember = "name"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listUserSys(vControl As ComboBox)
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If Not cnnx.DataSource.Equals("") Then
            Try
                ada.SelectCommand = New MySqlCommand("SELECT idusersys, name FROM user_sys", cnnx)
                ada.Fill(ds)

                vControl.DataSource = ds.Tables(0)
                vControl.ValueMember = "idusersys"
                vControl.DisplayMember = "name"

                If vControl.Items.Count > 0 Then
                    vControl.SelectedIndex = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                vControl.Enabled = False
                vControl.SelectedIndex = -1
            End Try
        End If
    End Sub

    Public Sub listUsersInAccount(vIdInternalLine As String, Optional vCombo As ComboBox = Nothing, Optional vList As ListBox = Nothing)
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT users_line.userreg AS iduser, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname " &
                "FROM users_line INNER JOIN user_reg ON users_line.userreg = user_reg.iduserreg WHERE users_line.internalline = @idinternalline"
                cmd.Parameters.AddWithValue("idinternalline", vIdInternalLine)

                Dim ada As New MySqlDataAdapter(cmd)
                ada.Fill(ds)

                If Not IsNothing(vCombo) Then
                    vCombo.DataSource = ds.Tables(0)
                    vCombo.ValueMember = "iduser"
                    vCombo.DisplayMember = "fullname"

                    If vCombo.Items.Count > 0 Then
                        vCombo.SelectedIndex = 0
                    End If
                End If

                If Not IsNothing(vList) Then
                    vList.DataSource = ds.Tables(0)
                    vList.ValueMember = "iduser"
                    vList.DisplayMember = "fullname"

                    If vList.Items.Count > 0 Then
                        vList.SelectedIndex = 0
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                If Not IsNothing(vCombo) Then
                    vCombo.Enabled = False
                    vCombo.SelectedIndex = -1
                End If

                If Not IsNothing(vList) Then
                    vList.Enabled = False
                    vList.SelectedIndex = -1
                End If
            End Try
        End If
    End Sub

    Public Sub listUsers(txtBusq As String, typeBusq As Integer, dgUsers As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableListUsers As New DataTable

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text

                Dim comand As String

                Select Case typeBusq
                    Case 0
                        'Buscar por nombres
                        comand = "SELECT user_reg.iduserreg, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                    Case 1
                        'Buscar por documento
                        comand = "SELECT user_reg.iduserreg, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                    Case Else
                        'Buscar a todos
                        comand = "SELECT user_reg.iduserreg, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype"
                End Select

                cmd.CommandText = comand
                ada.SelectCommand = cmd
                ada.Fill(tableListUsers)

                If tableListUsers.Rows.Count > 0 Then
                    dgUsers.Rows.Clear()
                    For index As Integer = 0 To tableListUsers.Rows.Count - 1
                        dgUsers.Rows.Add(tableListUsers.Rows(index).Item(0), tableListUsers.Rows(index).Item(1), tableListUsers.Rows(index).Item(2), tableListUsers.Rows(index).Item(3), tableListUsers.Rows(index).Item(4), tableListUsers.Rows(index).Item(5), tableListUsers.Rows(index).Item(6), tableListUsers.Rows(index).Item(7), tableListUsers.Rows(index).Item(8))
                    Next
                Else
                    dgUsers.Rows.Clear()
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgUsers.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listLinesService(txtBusq As String, typeBusq As Integer, dgLinesService As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableLinesService As New DataTable

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                Dim comand As String

                Select Case typeBusq
                    Case 0
                        'Buscar por nombres
                        comand = "SELECT internal_line.idinternalline, service_line.idserviceline, service_line.code, service_line.name, streets.name, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, user_reg.docid " &
                        "FROM service_line " &
                        "INNER JOIN streets On streets.idstreet = service_line.street " &
                        "INNER JOIN internal_line ON internal_line.serviceline = service_line.idserviceline " &
                        "INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline " &
                        "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg " &
                        "WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                    Case 1
                        'Buscar por documento
                        comand = "SELECT internal_line.idinternalline, service_line.idserviceline, service_line.code, service_line.name, streets.name, TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, user_reg.docid " &
                        "FROM service_line " &
                        "INNER JOIN streets On streets.idstreet = service_line.street " &
                        "INNER JOIN internal_line ON internal_line.serviceline = service_line.idserviceline " &
                        "INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline " &
                        "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg " &
                        "WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                    Case 2
                        'Buscar por codigo de linea
                        comand = "SELECT " &
                        "(SELECT """") AS idinternalline, " &
                        "SERVLINE.idserviceline, " &
                        "SERVLINE.code, " &
                        "SERVLINE.name, " &
                        "SECTOR.name, " &
                        "(SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                        "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                        "FROM service_line SERVLINE " &
                        "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street " &
                        "WHERE SERVLINE.code LIKE '%" & txtBusq & "%'"
                    Case 3
                        'Buscar por nombre de linea
                        comand = "SELECT " &
                        "(SELECT "" "") AS idinternalline, " &
                        "SERVLINE.idserviceline, " &
                        "SERVLINE.code, " &
                        "SERVLINE.name, " &
                        "SECTOR.name, " &
                        "(SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                        "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                        "FROM service_line SERVLINE " &
                        "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street " &
                        "WHERE SERVLINE.name LIKE '%" & txtBusq & "%'"
                    Case Else
                        'Buscar a todos
                        comand = "SELECT " &
                        "(SELECT "" "") AS idinternalline, " &
                        "SERVLINE.idserviceline, " &
                        "SERVLINE.code, " &
                        "SERVLINE.name, " &
                        "SECTOR.name, " &
                        "(SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                        "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                        "FROM service_line SERVLINE " &
                        "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street"
                End Select

                cmd.CommandText = comand
                ada.SelectCommand = cmd
                ada.Fill(tableLinesService)


                If tableLinesService.Rows.Count > 0 Then
                    dgLinesService.Rows.Clear()
                    For index As Integer = 0 To tableLinesService.Rows.Count - 1
                        dgLinesService.Rows.Add(tableLinesService.Rows(index).Item(0), tableLinesService.Rows(index).Item(1), tableLinesService.Rows(index).Item(2), tableLinesService.Rows(index).Item(3), tableLinesService.Rows(index).Item(4), tableLinesService.Rows(index).Item(5), tableLinesService.Rows(index).Item(6))
                    Next
                Else
                    dgLinesService.Rows.Clear()
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgLinesService.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listAccounts(txtBusq As String, typeBusq As Integer, dgAccounts As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableAccounts As New DataTable

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                Dim comand As String

                Select Case typeBusq
                    Case 0
                        'Buscar por nombre de la cuenta
                        comand = "SELECT " &
                        "internal_line.idinternalline, " &
                        "service_line.code, " &
                        "service_line.name, " &
                        "streets.name, " &
                        "TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, " &
                        "user_reg.docid " &
                        "FROM internal_line " &
                        "INNER JOIN service_line ON service_line.idserviceline = internal_line.serviceline" &
                        "INNER JOIN streets ON streets.idstreet = service_line.street" &
                        "INNER JOIN users_line ON internal_line.idinternalline = users_line.internalline" &
                        "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg" &
                        "WHERE user_reg.names LIKE '%" & txtBusq & "%' Or user_reg.surnames Like '%" & txtBusq & "'%"
                    Case 1
                        'Buscar por nombre de usuario asociado a la cuenta
                        comand = "SELECT " &
                        "internal_line.idinternalline, " &
                        "service_line.code, " &
                        "service_line.name, " &
                        "streets.name, " &
                        "TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname, " &
                        "user_reg.docid " &
                        "FROM internal_line " &
                        "INNER JOIN service_line ON service_line.idserviceline = internal_line.serviceline" &
                        "INNER JOIN streets ON streets.idstreet = service_line.street" &
                        "INNER JOIN users_line ON internal_line.idinternalline = users_line.internalline" &
                        "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg" &
                        "WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                    Case 2
                        'Buscar por codigo de linea
                        comand = "SELECT " &
                        "(SELECT "" "") AS idinternalline, " &
                        "SERVLINE.code, " &
                        "SERVLINE.name, " &
                        "SECTOR.name, " &
                        "(SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                        "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                        "FROM service_line SERVLINE " &
                        "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street " &
                        "WHERE SERVLINE.code LIKE '%" & txtBusq & "%'"
                    Case Else
                        'Buscar a todos
                        comand = "SELECT " &
                        "(SELECT "" "") AS idinternalline, " &
                        "SERVLINE.code, " &
                        "SERVLINE.name, " &
                        "SECTOR.name, " &
                        "(SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                        "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                        "FROM service_line SERVLINE " &
                        "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street"
                End Select

                cmd.CommandText = comand
                ada.SelectCommand = cmd
                ada.Fill(tableAccounts)

                If tableAccounts.Rows.Count > 0 Then
                    dgAccounts.Rows.Clear()
                    For index As Integer = 0 To tableAccounts.Rows.Count - 1
                        dgAccounts.Rows.Add(tableAccounts.Rows(index).Item(0), tableAccounts.Rows(index).Item(1), tableAccounts.Rows(index).Item(2), tableAccounts.Rows(index).Item(3), tableAccounts.Rows(index).Item(4), tableAccounts.Rows(index).Item(5))
                    Next
                Else
                    dgAccounts.Rows.Clear()
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgAccounts.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listAccountLine(vIdServiceLine As String, dgAccountLine As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableAccounts As New DataTable

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                INTERLINE.idinternalline, 
                rates.idrate, 
                INTERLINE.code, 
                (SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE users_line.internalline = INTERLINE.idinternalline) AS fullname, 
                rates.name 
                FROM internal_line INTERLINE 
                INNER JOIN rates ON INTERLINE.rate = rates.idrate 
                INNER JOIN service_line ON service_line.idserviceline = INTERLINE.serviceline 
                WHERE service_line.idserviceline = @idserviceline"
                cmd.Parameters.AddWithValue("idserviceline", vIdServiceLine)
                ada.SelectCommand = cmd
                ada.Fill(tableAccounts)

                If tableAccounts.Rows.Count > 0 Then
                    dgAccountLine.Rows.Clear()
                    For index As Integer = 0 To tableAccounts.Rows.Count - 1
                        dgAccountLine.Rows.Add(tableAccounts.Rows(index).Item(0), tableAccounts.Rows(index).Item(1), tableAccounts.Rows(index).Item(2), tableAccounts.Rows(index).Item(3), tableAccounts.Rows(index).Item(4))
                    Next
                Else
                    dgAccountLine.Rows.Clear()
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgAccountLine.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listUserAccount(vIdLine As String, vIdInterline As String, dgUserAccount As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableUsersAccount As New DataTable

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                internal_line.idinternalline,
                internal_line.serviceline,
                user_reg.iduserreg,
                TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) AS fullname,
                user_reg.docid,
                user_type.name 
                FROM internal_line
                INNER JOIN users_line ON internal_line.idinternalline = users_line.internalline
                INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg
                INNER JOIN user_type ON user_type.idusertype = user_reg.usertype
                WHERE internal_line.serviceline = @idserviceline AND internal_line.idinternalline = @idinternalline"
                cmd.Parameters.AddWithValue("idserviceline", vIdLine)
                cmd.Parameters.AddWithValue("idinternalline", vIdInterline)
                ada.SelectCommand = cmd
                ada.Fill(tableUsersAccount)

                If tableUsersAccount.Rows.Count > 0 Then
                    dgUserAccount.Rows.Clear()
                    For index As Integer = 0 To tableUsersAccount.Rows.Count - 1
                        dgUserAccount.Rows.Add(tableUsersAccount.Rows(index).Item(2), tableUsersAccount.Rows(index).Item(3), tableUsersAccount.Rows(index).Item(4), tableUsersAccount.Rows(index).Item(5))
                    Next
                Else
                    dgUserAccount.Rows.Clear()
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgUserAccount.Rows.Clear()
            End Try
        End If
    End Sub

    Public Function getPriceRate(idRate As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tablePrice As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                price, 
                description, 
                variable 
                FROM rates 
                INNER JOIN rate_price ON rate_price.rate = rates.idrate 
                WHERE rate_price.yearrate=@idyearrate AND idrate=@idrate"
                cmd.Parameters.AddWithValue("idyearrate", My.Settings.vIdYear)
                cmd.Parameters.AddWithValue("idrate", idRate)
                ada.SelectCommand = cmd
                ada.Fill(tablePrice)

                If tablePrice.Rows.Count > 0 Then
                    Dim dataPrice(2) As String
                    dataPrice(0) = tablePrice.Rows(0).Item(0).ToString
                    dataPrice(1) = tablePrice.Rows(0).Item(1).ToString
                    dataPrice(2) = tablePrice.Rows(0).Item(2).ToString

                    Return dataPrice
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getAveSector(idAvenue As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableStreet As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT code, name FROM streets WHERE idstreet LIKE '" & idAvenue & "'"
                ada.SelectCommand = cmd
                ada.Fill(tableStreet)

                If tableStreet.Rows.Count > 0 Then
                    Dim dataAvenue(1) As String
                    dataAvenue(0) = tableStreet.Rows(0).Item(0).ToString
                    dataAvenue(1) = tableStreet.Rows(0).Item(1).ToString

                    Return dataAvenue
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getCodeLine(vIdSector As Integer) As String
        Dim cmd As New MySqlCommand
        Dim codeLine As String

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                codeLine = generateCodeLine(vIdSector)

                Return codeLine
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getServiceRate(vIdService As Integer) As Boolean
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableService As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return False
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT rate_types.periodic FROM rate_types WHERE rate_types.idratetype LIKE @idratetype"
                cmd.Parameters.AddWithValue("idratetype", vIdService)
                ada.SelectCommand = cmd
                ada.Fill(tableService)

                If tableService.Rows.Count > 0 Then
                    Return tableService.Rows(0).Item(0).ToString
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function

    Public Function checkDocId(vDocId As String) As Boolean
        Dim cmdFindUser As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableCheckId As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                Dim vDuplicateDoc As Boolean = False

                If vDocId.Trim <> "" Then
                    cmdFindUser.Connection = cnnx
                    cmdFindUser.CommandType = CommandType.Text
                    cmdFindUser.CommandText = "SELECT user_reg.docid FROM user_reg WHERE user_reg.docid LIKE @docid"
                    cmdFindUser.Parameters.AddWithValue("docid", vDocId)
                    ada.SelectCommand = cmdFindUser
                    ada.Fill(tableCheckId)

                    If tableCheckId.Rows.Count > 0 Then
                        vDuplicateDoc = True
                    End If
                End If

                If vDuplicateDoc Then
                    MsgBox("El numero de documento ya esta en uso.", vbExclamation, "Aviso")
                End If

                Return vDuplicateDoc
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Sub addUserToLine(vIdInternalLine As String, dataUser() As String, vIdRate As Integer, Optional vPriceRate As Double = 0)
        Dim cmdInsertLineUser As New MySqlCommand
        Dim cmdFindLineUser As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindUser As New DataTable

        If Not (cnnx.DataSource.Equals("")) Then
            If vIdInternalLine.Length > 0 And vIdInternalLine <> "" Or vIdRate <> 0 Then
                Try
                    cmdFindLineUser.Connection = cnnx
                    cmdFindLineUser.CommandType = CommandType.Text
                    cmdFindLineUser.CommandText = "SELECT * FROM users_line WHERE users_line.internalline = @idinternalline AND users_line.userreg = @iduserreg"
                    cmdFindLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdFindLineUser.Parameters.AddWithValue("iduserreg", dataUser(0))
                    ada.SelectCommand = cmdFindLineUser
                    ada.Fill(tableFindUser)

                    If Not (tableFindUser.Rows.Count > 0) Then
                        cmdInsertLineUser.Connection = cnnx
                        cmdInsertLineUser.CommandType = CommandType.Text

                        cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline,@iduserreg)"
                        cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdInsertLineUser.Parameters.AddWithValue("iduserreg", dataUser(0))
                        cmdInsertLineUser.ExecuteNonQuery()

                        MsgBox("El usuario se agrego exitosamente", vbInformation, "Aviso")
                    Else
                        MsgBox("El usuario ya esta enlazado a la linea de servicio", vbInformation, "Aviso")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al guardar el registro", vbExclamation, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo de la linea a insertar", vbExclamation, "Aviso")
                Exit Sub
            End If
        End If
    End Sub

    Public Sub saveUserNew(dataUser() As String, Optional vLineToUser As Boolean = False, Optional vIdInternalLine As String = Nothing)
        Dim cmdFindUser As New MySqlCommand
        Dim cmdInsertUser As New MySqlCommand
        Dim cmdInsertLineUser As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindUser As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                If checkDocId(dataUser(4)) Then
                    Exit Sub
                End If

                cmdInsertUser.Connection = cnnx
                cmdInsertUser.CommandType = CommandType.Text
                cmdInsertUser.CommandText = "INSERT INTO user_reg(names, surnames, usertype, docid, address, cellphone, telephone) VALUES(@names, @surnames, @usertype, @docid, @address, @cellphone, @telephone)"
                cmdInsertUser.Parameters.AddWithValue("names", dataUser(1))
                cmdInsertUser.Parameters.AddWithValue("surnames", dataUser(2))
                cmdInsertUser.Parameters.AddWithValue("usertype", dataUser(3))
                cmdInsertUser.Parameters.AddWithValue("docid", dataUser(4))
                cmdInsertUser.Parameters.AddWithValue("address", dataUser(5))
                cmdInsertUser.Parameters.AddWithValue("cellphone", dataUser(6))
                cmdInsertUser.Parameters.AddWithValue("telephone", dataUser(7))
                cmdInsertUser.ExecuteNonQuery()

                If vLineToUser = True And Not IsNothing(vIdInternalLine) Then
                    cmdInsertLineUser.Connection = cnnx
                    cmdInsertLineUser.CommandType = CommandType.Text
                    cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline, (SELECT MAX(user_reg.iduserreg) AS id FROM user_reg))"
                    cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdInsertLineUser.ExecuteNonQuery()
                End If

                MsgBox("El usuario se guardo exitosamente", vbInformation, "Aviso")
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Function saveLineNew(dataLine() As String, dataUser() As String, Optional vPriceRate As Double = 0) As Boolean
        Dim vFindUser, vFindLine As Boolean

        Dim cmdFindLine As New MySqlCommand
        Dim cmdFindUser As New MySqlCommand
        Dim cmdInsertLine As New MySqlCommand
        Dim cmdInsertUser As New MySqlCommand
        Dim cmdInsertLineAccount As New MySqlCommand
        Dim cmdLastInsertLineUser As New MySqlCommand
        Dim cmdUpdateCodeLineAccount As New MySqlCommand
        Dim cmdInsertAccountUser As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindLine As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                If dataUser(3).Trim <> "" And (dataUser(7).Trim = "" Or dataUser(7) = Nothing) Then
                    If checkDocId(dataUser(3)) Then
                        Return False
                    End If
                End If

                cmdFindLine.Connection = cnnx
                cmdFindLine.CommandType = CommandType.Text
                cmdFindLine.CommandText = "SELECT * FROM service_line WHERE service_line.code LIKE @codeserviceline"
                cmdFindLine.Parameters.AddWithValue("codeserviceline", dataLine(0))
                ada.SelectCommand = cmdFindLine
                ada.Fill(tableFindLine)

                If tableFindLine.Rows.Count > 0 Then
                    vFindLine = True
                End If

                If vFindLine Then
                    MsgBox("El codigo de linea ya esta en uso.", vbExclamation, "Aviso")
                    Return False
                End If

                If Not vFindUser And Not vFindLine Then
                    'Registrando un nuevo usuario
                    cmdInsertUser.Connection = cnnx
                    cmdInsertUser.CommandType = CommandType.Text
                    cmdInsertUser.CommandText = "INSERT INTO user_reg(names, surnames, usertype, docid, address, cellphone, telephone) VALUES(@names, @surnames, @usertype, @docid, @address, @cellphone, @telephone)"
                    cmdInsertUser.Parameters.AddWithValue("names", dataUser(0))
                    cmdInsertUser.Parameters.AddWithValue("surnames", dataUser(1))
                    cmdInsertUser.Parameters.AddWithValue("usertype", dataUser(2))
                    cmdInsertUser.Parameters.AddWithValue("docid", dataUser(3))
                    cmdInsertUser.Parameters.AddWithValue("address", dataUser(4))
                    cmdInsertUser.Parameters.AddWithValue("cellphone", dataUser(5))
                    cmdInsertUser.Parameters.AddWithValue("telephone", dataUser(6))

                    If dataUser(7).Length = 0 And dataUser(7) = "" Then
                        cmdInsertUser.ExecuteNonQuery()
                    End If

                    'Registrando una nueva linea
                    cmdInsertLine.Connection = cnnx
                    cmdInsertLine.CommandType = CommandType.Text

                    If (dataLine(1) = "" Or dataLine(1) = Nothing) Then
                        dataLine(1) = dataLine(0)
                    End If

                    cmdInsertLine.CommandText = "INSERT INTO service_line(code, name, street, address, installdate, description) VALUES(@code, @name, @street, @address, @installdate, @description)"
                    cmdInsertLine.Parameters.AddWithValue("code", dataLine(0))
                    cmdInsertLine.Parameters.AddWithValue("name", dataLine(1))
                    cmdInsertLine.Parameters.AddWithValue("street", dataLine(2))
                    cmdInsertLine.Parameters.AddWithValue("address", dataLine(3))
                    cmdInsertLine.Parameters.AddWithValue("installdate", Format(CDate(dataLine(5)), "yyyy-MM-dd"))
                    cmdInsertLine.Parameters.AddWithValue("description", dataLine(6))

                    'Registrando una linea-cuenta
                    cmdInsertLineAccount.Connection = cnnx
                    cmdInsertLineAccount.CommandType = CommandType.Text

                    cmdInsertLineAccount.CommandText = "INSERT INTO internal_line(code, serviceline, rate, pricerate) VALUES(@code, (SELECT MAX(service_line.idserviceline) AS id FROM service_line), @rate, @pricerate)"
                    cmdInsertLineAccount.Parameters.AddWithValue("code", "new")
                    cmdInsertLineAccount.Parameters.AddWithValue("serviceline", dataLine(0))
                    cmdInsertLineAccount.Parameters.AddWithValue("rate", dataLine(4))
                    cmdInsertLineAccount.Parameters.AddWithValue("pricerate", vPriceRate)

                    cmdInsertLine.ExecuteNonQuery()
                    cmdInsertLineAccount.ExecuteNonQuery()

                    'Buscando y cambiando el codigo de cuenta
                    cmdLastInsertLineUser.Connection = cnnx
                    cmdLastInsertLineUser.CommandType = CommandType.Text
                    cmdLastInsertLineUser.CommandText = "UPDATE internal_line SET internal_line.code = (SELECT CONCAT(""C"",LPAD(LAST_INSERT_ID(),6,""0""))) WHERE internal_line.idinternalline LIKE LAST_INSERT_ID()"
                    'cmdLastInsertLineUser.CommandText = "UPDATE internal_line SET internal_line.code = (SELECT LPAD(MAX(internal_line.idinternalline),6,""0"") AS id FROM internal_line) WHERE internal_line.idinternalline LIKE (SELECT MAX(internal_line.idinternalline) AS id FROM internal_line)"
                    cmdLastInsertLineUser.ExecuteNonQuery()

                    'Registrando la cuenta-usuario
                    Dim userCmd As String
                    If dataUser(7).Length = 0 And dataUser(7) = "" Then
                        userCmd = "INSERT INTO users_line(internalline, userreg) VALUES((SELECT MAX(internal_line.idinternalline) AS id FROM internal_line), (SELECT MAX(user_reg.iduserreg) AS id FROM user_reg))"
                    Else
                        userCmd = "INSERT INTO users_line(internalline, userreg) VALUES((SELECT MAX(internal_line.idinternalline) AS id FROM internal_line), '" & dataUser(7) & "')"
                    End If

                    cmdInsertAccountUser.Connection = cnnx
                    cmdInsertAccountUser.CommandType = CommandType.Text

                    cmdInsertAccountUser.CommandText = userCmd
                    cmdInsertAccountUser.ExecuteNonQuery()

                    MsgBox("La linea se guardo exitosamente", vbInformation, "Aviso")
                    Return True
                Else
                    If vFindUser Then
                        MsgBox("El numero de documento ya esta registrado", vbExclamation, "Aviso")
                    End If
                    If vFindLine Then
                        MsgBox("El codigo de linea ya esta en uso", vbExclamation, "Aviso")
                    End If
                    Return False
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return False
        End If
    End Function

    Public Function saveAccountNew(vIdLine As String, vIdRate As Integer, vPriceRate As Decimal) As String
        Dim cmdInsertLineAccount As New MySqlCommand
        Dim cmdLastInsertLineUser As New MySqlCommand
        Dim cmdIdInternalLine As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindLine As New DataTable

        If Not (cnnx.DataSource.Equals("")) Then
            Try
                'Registrando una linea-cuenta
                cmdInsertLineAccount.Connection = cnnx
                cmdInsertLineAccount.CommandType = CommandType.Text
                cmdInsertLineAccount.CommandText = "INSERT INTO internal_line(code, serviceline, rate, pricerate) VALUES(@code, @serviceline, @rate, @pricerate)"
                cmdInsertLineAccount.Parameters.AddWithValue("code", "new")
                cmdInsertLineAccount.Parameters.AddWithValue("serviceline", vIdLine)
                cmdInsertLineAccount.Parameters.AddWithValue("rate", vIdRate)
                cmdInsertLineAccount.Parameters.AddWithValue("pricerate", vPriceRate)
                cmdInsertLineAccount.ExecuteNonQuery()

                'Buscando y cambiando el codigo de cuenta
                cmdLastInsertLineUser.Connection = cnnx
                cmdLastInsertLineUser.CommandType = CommandType.Text
                cmdLastInsertLineUser.CommandText = "UPDATE internal_line SET internal_line.code = (SELECT CONCAT(""C"",LPAD(LAST_INSERT_ID(),6,""0""))) WHERE internal_line.idinternalline LIKE LAST_INSERT_ID()"
                cmdLastInsertLineUser.ExecuteNonQuery()

                'Obteniendo el id del ultimo registrado
                cmdIdInternalLine.Connection = cnnx
                cmdIdInternalLine.CommandType = CommandType.Text
                cmdIdInternalLine.CommandText = "SELECT MAX(internal_line.idinternalline) AS id, MAX(internal_line.code) AS accountcode FROM internal_line"
                ada.SelectCommand = cmdIdInternalLine
                ada.Fill(tableFindLine)

                If tableFindLine.Rows.Count > 0 Then
                    Dim IdInternalLine As String = tableFindLine.Rows(0).Item(0).ToString
                    MsgBox("La nueva cuenta de la linea: " & tableFindLine.Rows(0).Item(1).ToString & " se registro correctamente.")

                    Return IdInternalLine
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
                Return Nothing
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return Nothing
        End If
    End Function

    Public Function updateAccount(vIdInternalLine As String, vIdLine As String, vIdRate As Integer, vPriceRate As Decimal) As Boolean
        Dim cmdUpdateAccount As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            Try
                'Registrando una linea-cuenta
                cmdUpdateAccount.Connection = cnnx
                cmdUpdateAccount.CommandType = CommandType.Text
                cmdUpdateAccount.CommandText = "UPDATE internal_line SET serviceline=@serviceline, rate=@rate, pricerate=@pricerate WHERE internal_line.idinternalline = @idinternalline"
                cmdUpdateAccount.Parameters.AddWithValue("serviceline", vIdLine)
                cmdUpdateAccount.Parameters.AddWithValue("rate", vIdRate)
                cmdUpdateAccount.Parameters.AddWithValue("pricerate", vPriceRate)
                cmdUpdateAccount.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                cmdUpdateAccount.ExecuteNonQuery()

                MsgBox("El registro se actualizo corrrectamente", MsgBoxStyle.Exclamation, "Aviso")
                Return True
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
                Return False
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return False
        End If
    End Function

    Public Sub updateLine(dataLine() As String)
        Dim cmdUpdateLine As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            If Not (dataLine(0) = Nothing) Then
                Try
                    cmdUpdateLine.Connection = cnnx
                    cmdUpdateLine.CommandType = CommandType.Text
                    cmdUpdateLine.CommandText = "UPDATE service_line SET name = @name, street = @street, ADDRESS = @address, installdate = @installdate, description = @description " &
                    "WHERE service_line.idserviceline = @idserviceline"
                    cmdUpdateLine.Parameters.AddWithValue("name", dataLine(2))
                    cmdUpdateLine.Parameters.AddWithValue("street", dataLine(3))
                    cmdUpdateLine.Parameters.AddWithValue("address", dataLine(4))
                    cmdUpdateLine.Parameters.AddWithValue("installdate", Format(CDate(dataLine(5)), "yyyy-MM-dd"))
                    cmdUpdateLine.Parameters.AddWithValue("description", dataLine(6))
                    cmdUpdateLine.Parameters.AddWithValue("idserviceline", dataLine(0))
                    cmdUpdateLine.ExecuteNonQuery()

                    MsgBox("La linea se actualizo exitosamente", vbInformation, "Aviso")
                Catch ex As Exception
                    MsgBox("Ocurrio un error al actualizar el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo de la linea para actualizar", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub updateUser(dataUser() As String)
        Dim cmdUpdateLine As New MySqlCommand
        Dim cmdUpdateUserToLine As New MySqlCommand

        If Not (cnnx.DataSource.Equals("")) Then
            cmdUpdateLine.Connection = cnnx
            cmdUpdateLine.CommandType = CommandType.Text

            If Not (dataUser(0) = Nothing) Then
                Try
                    cmdUpdateLine.CommandText = "UPDATE user_reg SET names = @nameuser, surnames = @surnamesuser, usertype = @usertype, docid = @docid, address = @address, cellphone = @cellphone, telephone = @telephone " &
                    "WHERE user_reg.iduserreg = @iduserreg"

                    cmdUpdateLine.Parameters.AddWithValue("nameuser", dataUser(1))
                    cmdUpdateLine.Parameters.AddWithValue("surnamesuser", dataUser(2))
                    cmdUpdateLine.Parameters.AddWithValue("usertype", dataUser(3))
                    cmdUpdateLine.Parameters.AddWithValue("docid", dataUser(4))
                    cmdUpdateLine.Parameters.AddWithValue("address", dataUser(5))
                    cmdUpdateLine.Parameters.AddWithValue("cellphone", dataUser(6))
                    cmdUpdateLine.Parameters.AddWithValue("telephone", dataUser(7))
                    cmdUpdateLine.Parameters.AddWithValue("iduserreg", dataUser(0))
                    cmdUpdateLine.ExecuteNonQuery()

                    If (dataUser(12) <> Nothing) Then
                        cmdUpdateUserToLine.Connection = cnnx
                        cmdUpdateUserToLine.CommandType = CommandType.Text
                        cmdUpdateUserToLine.CommandText = "UPDATE users_line SET internalline = @idinternalline, userreg = @iduserreg"
                        cmdUpdateUserToLine.Parameters.AddWithValue("iduserreg", dataUser(0))
                        cmdUpdateUserToLine.Parameters.AddWithValue("idinternalline", dataUser(12))
                        cmdUpdateUserToLine.ExecuteNonQuery()
                    End If

                    MsgBox("El usuario se actualizo exitosamente", vbInformation, "Aviso")
                Catch ex As Exception
                    MsgBox("Ocurrio un error al actualizar el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo del usuario para actualizar", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub deleteInterlalToService(vIdServiceLine As String, vIdInternalLine As String)
        Dim cmdFindAccounts As New MySqlCommand
        Dim cmdDeleteInternal As New MySqlCommand
        Dim cmdDeleteUserInternal As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindLine As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdInternalLine = Nothing) Then
                Try
                    cmdFindAccounts.Connection = cnnx
                    cmdFindAccounts.CommandType = CommandType.Text
                    cmdFindAccounts.CommandText = "SELECT * FROM account_line WHERE account_line.internalline = @idinternalline"
                    cmdFindAccounts.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    ada.SelectCommand = cmdFindAccounts
                    ada.Fill(tableFindLine)

                    Dim vFindAccounts As Boolean = False

                    If tableFindLine.Rows.Count > 0 Then
                        vFindAccounts = True
                    End If

                    If vFindAccounts = False Then
                        cmdDeleteUserInternal.Connection = cnnx
                        cmdDeleteUserInternal.CommandType = CommandType.Text
                        cmdDeleteUserInternal.CommandText = "DELETE FROM users_line WHERE users_line.internalline = @idinternalline"
                        cmdDeleteUserInternal.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdDeleteUserInternal.ExecuteNonQuery()

                        cmdDeleteInternal.Connection = cnnx
                        cmdDeleteInternal.CommandType = CommandType.Text
                        cmdDeleteInternal.CommandText = "DELETE FROM internal_line " &
                            "WHERE internal_line.serviceline = @idserviceline AND internal_line.idinternalline = @idinternalline"
                        cmdDeleteInternal.Parameters.AddWithValue("idserviceline", vIdServiceLine)
                        cmdDeleteInternal.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdDeleteInternal.ExecuteNonQuery()

                        MsgBox("Se elemino la linea-cuenta de la linea de servicio", vbInformation, "Aviso")
                    Else
                        MsgBox("Esta cuenta no puede ser eliminada porque hay cuentas enlazadas a ella.", vbInformation, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al actualizar el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo de la linea", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub deleteUserToInternal(vIdInternalLine As String, vIdUserReg As String)
        Dim cmdDeleteUser As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdInternalLine = Nothing Or vIdUserReg = Nothing) Then
                Try
                    cmdDeleteUser.Connection = cnnx
                    cmdDeleteUser.CommandType = CommandType.Text
                    cmdDeleteUser.CommandText = "DELETE FROM users_line WHERE users_line.internalline = @idinternalline AND users_line.userreg = @iduserreg"
                    cmdDeleteUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdDeleteUser.Parameters.AddWithValue("iduserreg", vIdUserReg)
                    cmdDeleteUser.ExecuteNonQuery()

                    MsgBox("Se elemino el usuario o representante de la linea-cuenta", vbInformation, "Aviso")
                Catch ex As Exception
                    MsgBox("Ocurrio un error al eliminar el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo de la linea o el codigo de usuario", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub showNewLine(vfrmMdiParent As Form)
        Dim frm As New frmNewline

        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showFindLines(vfrmMdiParent As Form)
        Dim frm As New frmFindLines

        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
        frm.txtFind.Focus()
    End Sub

    Public Sub showFindCollect(vfrmMdiParent As Form)
        Dim frm As New frmFindCollect

        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
        frm.txtFind.Focus()
    End Sub

    Public Sub showDeclarationServices(vfrmMdiParent As Form)
        Dim frm As New frmDeclarationServices

        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showFindUsers(vfrmMdiParent As Form, vFrmGet As Integer, vFrmIn As Form)
        Dim frm As New frmFindUsers
        frm.vFrmGet = vFrmGet
        frm.vFrmIn = vFrmIn

        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showRateType(Optional vfrmMdiParent As Form = Nothing)
        Dim frm As New frmRateType
        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showReceipts(Optional vfrmMdiParent As Form = Nothing)
        Dim frm As New frmReceipts
        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showReportReceipts()
        Dim frm As New frmReportReceipts
        frm.Show()
    End Sub

    Public Sub showReportReceiptsResume()
        Dim frm As New frmReportReceiptsResume
        frm.Show()
    End Sub

    Public Sub showReportDebtsResume()
        Dim frm As New frmReportDebtsResume
        frm.Show()
    End Sub

    Public Sub showReportDebtsDetail()
        Dim frm As New frmReportDebtsDetail
        frm.Show()
    End Sub

    Public Sub showEditLine(vIdServiceLine As String)
        Dim frm As New frmEditLine
        frm.vIdServiceLine = vIdServiceLine
        frm.ShowDialog()
    End Sub

    Public Sub showAccount(vIdServiceLine As String, vIdInternalLine As String)
        Dim frm As New frmAccount
        frm.vIdServiceLine = vIdServiceLine
        frm.vIdInternalLine = vIdInternalLine
        frm.ShowDialog()
    End Sub

    Public Sub showAccountCollect(vIdServiceLine As String, vIdInternalLine As String, vNameLine As String, vNameStreet As String)
        Dim frm As New frmCollectDetail
        frm.vIdServiceLine = vIdServiceLine
        frm.vIdInternalLine = vIdInternalLine
        frm.vNameLine = vNameLine
        frm.vNameStreet = vNameStreet
        frm.ShowDialog()
    End Sub

    Public Sub showPrintReceipt(dataReceipt() As String, dataConceptReceipt() As String)
        Dim frm As New frmReceipt
        frm.receiptDataStr = dataReceipt
        frm.receiptConceptStr = dataConceptReceipt
        frm.previewPrint = My.Settings.vPreviewPrint
        frm.ShowDialog()
    End Sub

    Public Sub showAccountReceipts(vIdInternalLine As String)
        Dim frm As New frmSeePays
        frm.vIdInternalLine = vIdInternalLine
        frm.ShowDialog()
    End Sub

    Public Sub showGenerateYear(vIdInternalLine As String)
        Dim frm As New frmDebtRecordYear
        frm.vIdInternalLine = vIdInternalLine
        frm.ShowDialog()
    End Sub

    Public Sub showGenerateService(vIdAccountLine As String)
        Dim frm As New frmDebtRecordService
        frm.vIdAccountLine = vIdAccountLine
        frm.ShowDialog()
    End Sub

    Public Sub showGenerateDetail(vIdAccountLine As String)
        Dim frm As New frmDebtRecordDetail
        frm.vIdAccountLine = vIdAccountLine
        frm.ShowDialog()
    End Sub

    Public Sub showNewUser(vIdUserReg As String, vIdInternalLine As String, vFrmGet As Integer, Optional vfrmMdiParent As Form = Nothing)
        Dim frm As New frmNewuser
        frm.vIdUserReg = vIdUserReg
        frm.vFrmGet = vFrmGet
        frm.vIdInternalLine = vIdInternalLine
        If IsNothing(vfrmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.MdiParent = vfrmMdiParent
            frm.Show()
        End If
    End Sub

    Public Sub showPayDetail(vIdPayment As String, vNumReceipt As String, vCollector As String, vPayer As String, vDatePay As Date)
        Dim frm As New frmPayDetail
        frm.vIdPayment = vIdPayment
        frm.vNumReceipt = vNumReceipt
        frm.vCollector = vCollector
        frm.vPayer = vPayer
        frm.vDatePay = vDatePay
        frm.ShowDialog()
    End Sub

    Public Sub showDebtRecord(vIdServiceLine As String, vIdInternalLine As String, vNameLine As String)
        Dim frm As New frmDebtRecord
        frm.vIdServiceLine = vIdServiceLine
        frm.vIdInternalLine = vIdInternalLine
        frm.vNameLine = vNameLine
        frm.ShowDialog()
    End Sub

    Public Function lastCodReceipt() As String()
        Dim cmdGetLastReceipt As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableLastReceipt As New DataTable

        Dim dataStr(1) As String
        dataStr(0) = ""
        dataStr(1) = ""

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmdGetLastReceipt.Connection = cnnx
                cmdGetLastReceipt.CommandType = CommandType.Text
                cmdGetLastReceipt.CommandText = "SELECT MAX(payments.idpayment) AS id FROM payments"
                ada.SelectCommand = cmdGetLastReceipt
                ada.Fill(tableLastReceipt)

                If tableLastReceipt.Rows.Count > 0 Then
                    dataStr(0) = Val(tableLastReceipt.Rows(0).Item(0).ToString) + 1
                    dataStr(1) = dataStr(0).PadLeft(7, "0")
                Else
                    dataStr(0) = "1"
                    dataStr(1) = dataStr(0).PadLeft(7, "0")
                End If

                Return dataStr
            Catch ex As Exception
                MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
                Return dataStr
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return dataStr
        End If
    End Function

    Public Sub getAccountCollect(vIdServiceLine As String, vIdInternalLine As String, dgAccountYear As DataGridView)
        'Se agregara la tabla service_line a la consulta para obtener mas datos
        Dim cmdGetAccountCollect As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableLastReceipt As New DataTable

        If Not cnnx.DataSource.Equals("") Then

            If Not (vIdServiceLine = Nothing And vIdInternalLine = Nothing) Then
                Try
                    cmdGetAccountCollect.Connection = cnnx
                    cmdGetAccountCollect.CommandType = CommandType.Text
                    cmdGetAccountCollect.CommandText = "SELECT 
                    account_line.idaccountline, 
                    years_rate.year AS numyear, 
                    account_line.debttotal, 
                    account_line.saldototal 
                    FROM account_line 
                    INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate 
                    WHERE account_line.internalline = @idinternalline 
                    ORDER BY numyear DESC"
                    cmdGetAccountCollect.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    ada.SelectCommand = cmdGetAccountCollect
                    ada.Fill(tableLastReceipt)

                    dgAccountYear.Rows.Clear()
                    If tableLastReceipt.Rows.Count > 0 Then
                        For index As Integer = 0 To tableLastReceipt.Rows.Count - 1
                            Dim vState As String
                            If CDec(tableLastReceipt.Rows(index).Item(3).ToString) > 0 Then
                                vState = "SALDO PENDIENTE"
                            Else
                                vState = "CANCELADO"
                            End If
                            dgAccountYear.Rows.Add(tableLastReceipt.Rows(index).Item(0).ToString, CInt(tableLastReceipt.Rows(index).Item(1).ToString), Format(CDec(tableLastReceipt.Rows(index).Item(2).ToString), "###,##0.00"), Format(CDec(tableLastReceipt.Rows(index).Item(2).ToString) - CDec(tableLastReceipt.Rows(index).Item(3).ToString), "###,##0.00"), Format(CDec(tableLastReceipt.Rows(index).Item(3).ToString), "###,##0.00"), vState)

                            dgAccountYear.Item(5, dgAccountYear.Rows.GetLastRow(0)).Style.ForeColor = Color.White
                            If CDec(tableLastReceipt.Rows(index).Item(3).ToString) > 0 Then
                                dgAccountYear.Item(5, dgAccountYear.Rows.GetLastRow(0)).Style.BackColor = Color.Red
                                dgAccountYear.Item(5, dgAccountYear.Rows.GetLastRow(0)).Style.SelectionBackColor = Color.Red
                            Else
                                dgAccountYear.Item(5, dgAccountYear.Rows.GetLastRow(0)).Style.BackColor = Color.Green
                                dgAccountYear.Item(5, dgAccountYear.Rows.GetLastRow(0)).Style.SelectionBackColor = Color.Green
                            End If
                        Next
                    Else
                        MsgBox("No hay cuentas por año que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
                    dgAccountYear.Rows.Clear()
                End Try
            Else
                MsgBox("No se envio el codigo de linea o cuenta", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub getAccountCollectCharge(vIdAccountLine As String, dgAccountCharge As DataGridView)
        Dim cmdGetAccountCollectCharge As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableCollect As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdAccountLine = Nothing) Then

                Try
                    cmdGetAccountCollectCharge.Connection = cnnx
                    cmdGetAccountCollectCharge.CommandType = CommandType.Text
                    cmdGetAccountCollectCharge.CommandText = "SELECT 
                    account_detail.idaccountdetail, 
                    account_detail.accountline, 
                    years_rate.idyearrate, 
                    rate_types.idratetype, 
                    account_detail.month, 
                    rate_types.name AS cargo, 
                    rate_types.periodic, 
                    account_detail.debttotal, 
                    (account_detail.debttotal - account_detail.saldototal) AS saldo, 
                    account_detail.saldototal, 
                    years_rate.year 
                    FROM account_detail 
                    INNER JOIN years_rate ON years_rate.idyearrate = account_detail.yearrate 
                    INNER JOIN rate_types ON rate_types.idratetype = account_detail.ratetype
                    WHERE account_detail.accountline = @idaccountline 
                    ORDER BY account_detail.idaccountdetail ASC"
                    cmdGetAccountCollectCharge.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                    ada.SelectCommand = cmdGetAccountCollectCharge
                    ada.Fill(tableCollect)

                    dgAccountCharge.Rows.Clear()
                    If tableCollect.Rows.Count > 0 Then
                        For index As Integer = 0 To tableCollect.Rows.Count - 1
                            Dim vNameMonth As String
                            If CInt(tableCollect.Rows(index).Item(4).ToString) = 0 Then
                                vNameMonth = ""
                            Else
                                vNameMonth = UCase(MonthName(tableCollect.Rows(index).Item(4).ToString))
                            End If
                            Dim vCharge As Boolean = tableCollect.Rows(index).Item(6).ToString
                            Dim vNameCharge As String

                            If vCharge Then
                                vNameCharge = tableCollect.Rows(index).Item(5).ToString & " " & vNameMonth & " " & tableCollect.Rows(index).Item(10).ToString
                            Else
                                vNameCharge = tableCollect.Rows(index).Item(5).ToString
                            End If

                            Dim vState As String
                            If CDec(tableCollect.Rows(index).Item(9).ToString) > 0 Then
                                vState = "PENDIENTE"
                            Else
                                vState = "CANCELADO"
                            End If

                            dgAccountCharge.Rows.Add(tableCollect.Rows(index).Item(0).ToString, tableCollect.Rows(index).Item(1).ToString, tableCollect.Rows(index).Item(2).ToString, tableCollect.Rows(index).Item(3).ToString, tableCollect.Rows(index).Item(4).ToString, False, vNameCharge, Format(CDec(tableCollect.Rows(index).Item(7).ToString), "###,##0.00"), Format(CDec(tableCollect.Rows(index).Item(8).ToString), "###,##0.00"), Format(CDec(tableCollect.Rows(index).Item(9).ToString), "###,##0.00"), vState)

                            dgAccountCharge.Item(10, dgAccountCharge.Rows.GetLastRow(0)).Style.ForeColor = Color.White
                            If CDec(tableCollect.Rows(index).Item(9).ToString) > 0 Then
                                dgAccountCharge.Item(10, dgAccountCharge.Rows.GetLastRow(0)).Style.BackColor = Color.Red
                                dgAccountCharge.Item(10, dgAccountCharge.Rows.GetLastRow(0)).Style.SelectionBackColor = Color.Red
                            Else
                                dgAccountCharge.Item(10, dgAccountCharge.Rows.GetLastRow(0)).Style.BackColor = Color.Green
                                dgAccountCharge.Item(10, dgAccountCharge.Rows.GetLastRow(0)).Style.SelectionBackColor = Color.Green
                            End If
                        Next
                    Else
                        MsgBox("No hay cuentas por año que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                    dgAccountCharge.Rows.Clear()
                End Try
            Else
                MsgBox("No se envio el codigo de la cuenta", vbCritical, "Aviso")
            End If
        End If
    End Sub

    Public Function selectCharge(dgAccountCharge As DataGridView, Optional ByVal cleanAll As Boolean = False) As Decimal
        Dim vSaldoTotal As Decimal = 0

        If cleanAll Then
            For index As Integer = 0 To dgAccountCharge.Rows.Count - 1
                dgAccountCharge.Item(5, index).Value = False
            Next
            vSaldoTotal = 0
        Else
            For index As Integer = 0 To dgAccountCharge.Rows.Count - 1
                If dgAccountCharge.Item(5, index).Value = True Then
                    vSaldoTotal += CDec(dgAccountCharge.Item(9, index).Value)
                End If
            Next
        End If

        Return vSaldoTotal
    End Function

    Public Sub receiptsHistory(dgHistory As DataGridView, vIdInternalLine As String, Optional vSeeAll As Integer = 0, Optional vYear As Integer = 0)
        Dim cmdGetAccountReceipts As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableReceipts As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdInternalLine = Nothing) Then

                Try
                    cmdGetAccountReceipts.Connection = cnnx
                    cmdGetAccountReceipts.CommandType = CommandType.Text
                    Dim strCommand As String = "SELECT 
                    payments.idpayment, 
                    payments.codepay, 
                    payments.accountline, 
                    years_rate.year, 
                    payments.canceled, 
                    payments.amounttotal, 
                    payments.payer, 
                    UCASE(user_sys.name) as usercollect, 
                    payments.created, 
                    payments.updated 
                    FROM payments 
                    INNER JOIN years_rate ON years_rate.idyearrate = payments.yearrate 
                    INNER JOIN account_line ON account_line.idaccountline = payments.accountline 
                    INNER JOIN internal_line ON internal_line.idinternalline = account_line.internalline 
                    INNER JOIN user_sys ON user_sys.idusersys = payments.collector
                    WHERE internal_line.idinternalline = @idinternalline"

                    If vSeeAll <> 0 Then
                        '0: ver todos los recibos, 1: ver los no anulados, 2: ver los anulados
                        strCommand = strCommand & " AND payments.canceled = @canceled"
                    End If
                    strCommand = strCommand & " ORDER BY payments.created DESC"

                    cmdGetAccountReceipts.CommandText = strCommand
                    cmdGetAccountReceipts.Parameters.AddWithValue("idinternalline", vIdInternalLine)

                    If vSeeAll <> 0 Then
                        If vSeeAll = 1 Then
                            cmdGetAccountReceipts.Parameters.AddWithValue("canceled", 0)
                        ElseIf vSeeAll = 2 Then
                            cmdGetAccountReceipts.Parameters.AddWithValue("canceled", 1)
                        End If
                    End If

                    ada.SelectCommand = cmdGetAccountReceipts
                    ada.Fill(tableReceipts)

                    dgHistory.Rows.Clear()

                    If tableReceipts.Rows.Count > 0 Then
                        For index As Integer = 0 To tableReceipts.Rows.Count - 1
                            dgHistory.Rows.Add(tableReceipts.Rows(index).Item(0).ToString, tableReceipts.Rows(index).Item(2).ToString, tableReceipts.Rows(index).Item(3).ToString, tableReceipts.Rows(index).Item(1).ToString, Format(CDec(tableReceipts.Rows(index).Item(5).ToString), "###,##0.00"), tableReceipts.Rows(index).Item(6).ToString, tableReceipts.Rows(index).Item(7).ToString, tableReceipts.Rows(index).Item(8).ToString)
                        Next
                    Else
                        MsgBox("No hay pagos que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    dgHistory.Rows.Clear()
                    MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
                End Try
            Else
                MsgBox("No se envio el codigo de la cuenta", vbCritical, "Aviso")
            End If
        End If
    End Sub

    Public Sub receiptDetail(dgDetail As DataGridView, vIdPayment As String)
        Dim cmdGetReceiptDetail As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableReceipts As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdPayment = Nothing) Then
                Try
                    cmdGetReceiptDetail.Connection = cnnx
                    cmdGetReceiptDetail.CommandType = CommandType.Text
                    cmdGetReceiptDetail.CommandText = "SELECT 
                    payments.idpayment, 
                    payments.accountline, 
                    account_detail.idaccountdetail, 
                    years_rate.year, 
                    account_detail.month, 
                    rate_types.name, 
                    rate_types.periodic, 
                    payment_detail.payamount 
                    FROM payment_detail 
                    INNER JOIN payments ON payments.idpayment = payment_detail.payment 
                    INNER JOIN account_detail ON account_detail.idaccountdetail = payment_detail.accountdetail 
                    INNER JOIN rate_types ON rate_types.idratetype = account_detail.ratetype 
                    INNER JOIN years_rate ON years_rate.idyearrate = payments.yearrate
                    WHERE payment_detail.payment = @idpayment"
                    cmdGetReceiptDetail.Parameters.AddWithValue("idpayment", vIdPayment)
                    ada.SelectCommand = cmdGetReceiptDetail
                    ada.Fill(tableReceipts)

                    dgDetail.Rows.Clear()
                    If tableReceipts.Rows.Count > 0 Then
                        For index As Integer = 0 To tableReceipts.Rows.Count - 1
                            Dim vNameMonth As String
                            If CInt(tableReceipts.Rows(index).Item(4).ToString) = 0 Then
                                vNameMonth = ""
                            Else
                                vNameMonth = UCase(MonthName(tableReceipts.Rows(index).Item(4).ToString))
                            End If
                            Dim vCharge As Boolean = tableReceipts.Rows(index).Item(6).ToString
                            Dim vNameCharge As String

                            If vCharge Then
                                vNameCharge = tableReceipts.Rows(index).Item(5).ToString & " " & vNameMonth & " " & tableReceipts.Rows(index).Item(3).ToString
                            Else
                                vNameCharge = tableReceipts.Rows(index).Item(5).ToString
                            End If

                            dgDetail.Rows.Add(tableReceipts.Rows(index).Item(0).ToString, tableReceipts.Rows(index).Item(1).ToString, tableReceipts.Rows(index).Item(2).ToString, vNameCharge, Format(CDec(tableReceipts.Rows(index).Item(7).ToString), "###,##0.00"))
                        Next
                    Else
                        MsgBox("No hay pagos que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    dgDetail.Rows.Clear()
                    MsgBox("Ocurrio un error en la consulta", vbCritical, "Aviso")
                End Try
            Else
                MsgBox("No se envio el identificador del recibo", vbCritical, "Aviso")
            End If
        End If
    End Sub

    Public Sub registerCancelReceipt(vNumReceipt As Integer)
        Dim cmdFindReceipts, cmdInsertCancelReceipt As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableReceipts As New DataTable
        Dim numReceipt As String = vNumReceipt.ToString.PadLeft(7, "0")

        If Not cnnx.DataSource.Equals("") Then
            cmdFindReceipts.Connection = cnnx
            cmdFindReceipts.CommandType = CommandType.Text
            cmdFindReceipts.CommandText = "SELECT * FROM payments WHERE payments.codepay LIKE @codepayment"
            cmdFindReceipts.Parameters.AddWithValue("codepayment", numReceipt)
            ada.SelectCommand = cmdFindReceipts
            ada.Fill(tableReceipts)

            If tableReceipts.Rows.Count > 0 Then
                MsgBox("El recibo N°" & numReceipt & " esta registrado anulelo desde la lista", vbCritical, "Aviso")
            Else
                If MsgBox("¿Desea registrar el recibo N°" & numReceipt & " como anulado?", MsgBoxStyle.YesNo + vbExclamation, "Aviso") = MsgBoxResult.Yes Then
                    cmdInsertCancelReceipt.Connection = cnnx
                    cmdInsertCancelReceipt.CommandType = CommandType.Text
                    cmdInsertCancelReceipt.CommandText = "INSERT INTO payments(codepay, accountline, yearrate, canceled, amounttotal, payer, collector) VALUES(@codepay, @accountline, @yearrate, @canceled, @amounttotal, @payer, @collector)"
                    cmdInsertCancelReceipt.Parameters.AddWithValue("codepay", numReceipt)
                    cmdInsertCancelReceipt.Parameters.AddWithValue("accountline", 0)
                    cmdInsertCancelReceipt.Parameters.AddWithValue("yearrate", My.Settings.vIdYear)
                    cmdInsertCancelReceipt.Parameters.AddWithValue("canceled", 1)
                    cmdInsertCancelReceipt.Parameters.AddWithValue("amounttotal", 0)
                    cmdInsertCancelReceipt.Parameters.AddWithValue("payer", "ANULADO")
                    cmdInsertCancelReceipt.Parameters.AddWithValue("collector", My.Settings.vUserIdLogin)
                    cmdInsertCancelReceipt.ExecuteNonQuery()
                End If
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Function cancelReceipt(dgDetail As DataGridView, vIdPayment As String, vNumReceipt As String, vDatePay As Date) As Boolean
        Dim cmdUpdateReceipt As New MySqlCommand
        Dim cmdUpdateAccountLine As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            If DateDiff(DateInterval.Day, CDate(Format(vDatePay, "dd/MM/yyyy")), Today) <= 7 Then
                If MsgBox("¿Desea anular el recibo N°" & vNumReceipt & "?", MsgBoxStyle.YesNo + vbExclamation, "Aviso") = MsgBoxResult.Yes Then
                    If Not (vIdPayment = Nothing And dgDetail.Rows.Count > 0) Then

                        Dim vIdAccountLine As String = dgDetail.Item(1, 0).Value

                        Try
                            cmdUpdateReceipt.Connection = cnnx
                            cmdUpdateReceipt.CommandType = CommandType.Text
                            cmdUpdateReceipt.CommandText = "UPDATE payments SET payments.canceled = 1 WHERE payments.idpayment = @idpayment"
                            cmdUpdateReceipt.Parameters.AddWithValue("idpayment", vIdPayment)
                            cmdUpdateReceipt.ExecuteNonQuery()

                            For index As Integer = 0 To dgDetail.Rows.Count - 1
                                Dim cmdUpdateAccountDetail As New MySqlCommand
                                cmdUpdateAccountDetail.Connection = cnnx
                                cmdUpdateAccountDetail.CommandType = CommandType.Text
                                cmdUpdateAccountDetail.CommandText = "UPDATE 
                                account_detail 
                                SET account_detail.saldototal = (
                                SELECT 
                                (account_detail.saldototal + payment_detail.payamount) AS afterpay 
                                FROM account_detail INNER JOIN payment_detail ON payment_detail.accountdetail = account_detail.idaccountdetail 
                                WHERE payment_detail.accountdetail = @idaccountdetail AND payment_detail.payment = @idpayment) 
                                WHERE account_detail.idaccountdetail = @idaccountdetail"
                                cmdUpdateAccountDetail.Parameters.AddWithValue("idaccountdetail", dgDetail.Item(2, index).Value)
                                cmdUpdateAccountDetail.Parameters.AddWithValue("idpayment", vIdPayment)
                                cmdUpdateAccountDetail.ExecuteNonQuery()
                            Next

                            cmdUpdateAccountLine.Connection = cnnx
                            cmdUpdateAccountLine.CommandType = CommandType.Text
                            cmdUpdateAccountLine.CommandText = "UPDATE 
                            account_line 
                            SET account_line.saldototal = (SELECT SUM(account_detail.saldototal) AS saldototal FROM account_detail WHERE account_detail.accountline = @idaccountline), 
                            account_line.debttotal = (SELECT SUM(account_detail.debttotal) AS debttotal FROM account_detail WHERE account_detail.accountline = @idaccountline) 
                            WHERE account_line.idaccountline = @idaccountline"
                            cmdUpdateAccountLine.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                            cmdUpdateAccountLine.ExecuteNonQuery()

                            Return True
                        Catch ex As Exception
                            MsgBox("Ocurrio un error en la consulta", vbCritical, "Aviso")
                            Return False
                        End Try
                    Else
                        MsgBox("No se envio el identificador del recibo o faltan datos", vbCritical, "Aviso")
                        Return False
                    End If
                Else
                    Return False
                End If
            Else
                MsgBox("Excedio el dia para reclamo por anulación de recibo", vbCritical, "Aviso")
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub printReceiptCopy(vIdPayment As String, dgDetail As DataGridView)
        Dim cmdReceipt, cmdReceiptDetail As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableReceipt As New DataTable
        Dim data(7) As String
        Dim concepts(12) As String

        'data(0) = getLine(vIdServiceLine)(1)
        'data(1) = vDataReceipt(1)
        'data(2) = cbxUsersInAccount.Text
        'data(3) = getUser(cbxUsersInAccount.SelectedValue)(5)
        'data(4) = getLine(vIdServiceLine)(5)
        'data(5) = Strings.Left(My.Settings.vUserNameLogin, 40)
        'data(6) = Format(DateAndTime.Today, "dd/MM/yyyy") & " " & Format(DateAndTime.TimeOfDay, "hh:mm tt")
        'data(7) = vDataReceipt(0)

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdPayment = Nothing) Then
                cmdReceipt.Connection = cnnx
                cmdReceipt.CommandType = CommandType.Text
                cmdReceipt.CommandText = "SELECT 
                service_line.code, 
                payments.codepay, 
                payments.payer, 
                (SELECT user_reg.docid AS docid FROM users_line INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE users_line.internalline = INTERLINE.idinternalline LIMIT 1) AS docid,
                streets.name,
                user_sys.name,
                payments.created 
                FROM payments 
                INNER JOIN account_line ON account_line.idaccountline = payments.accountline 
                INNER JOIN internal_line AS INTERLINE ON INTERLINE.idinternalline = account_line.internalline
                INNER JOIN service_line ON service_line.idserviceline = INTERLINE.serviceline
                INNER JOIN streets ON streets.idstreet = service_line.street 
                INNER JOIN user_sys ON user_sys.idusersys = payments.collector 
                WHERE payments.idpayment = @idpay"
                cmdReceipt.Parameters.AddWithValue("idpay", vIdPayment)
                ada.SelectCommand = cmdReceipt
                ada.Fill(tableReceipt)

                data(0) = tableReceipt.Rows(0).Item(0).ToString
                data(1) = tableReceipt.Rows(0).Item(1).ToString
                data(2) = tableReceipt.Rows(0).Item(2).ToString
                data(3) = tableReceipt.Rows(0).Item(3).ToString
                data(4) = tableReceipt.Rows(0).Item(4).ToString
                data(5) = tableReceipt.Rows(0).Item(5).ToString
                data(6) = tableReceipt.Rows(0).Item(6).ToString
                data(7) = ""

                For index As Integer = 0 To dgDetail.Rows.Count - 1
                    concepts(index) = dgDetail.Item(3, index).Value
                    concepts(index + 6) = dgDetail.Item(4, index).Value
                Next

                showPrintReceipt(data, concepts)
            Else
                MsgBox("Faltan datos del pago detalle", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Function payAccount(dgAccount As DataGridView, amountPay As Decimal, Optional vIdInternalLine As String = Nothing, Optional vIdPay As Integer = Nothing, Optional vCodNumReceipt As String = Nothing, Optional vNamePayer As String = Nothing) As String()
        Dim rateYear As Integer = 0
        Dim idAcccount As String = Nothing
        Dim dataConceptReceipt(12) As String
        Dim indexConcept As Integer = 0
        Dim amountPayTotal As Decimal

        If dgAccount.Rows.Count > 0 Then
            For index As Integer = 0 To dgAccount.Rows.Count - 1
                rateYear = dgAccount.Item(2, index).Value
                idAcccount = dgAccount.Item(1, index).Value

                If dgAccount.Item(5, index).Value = True Then
                    If dgAccount.Item(9, index).Value <= amountPay And amountPay > 0 Then
                        If payAccountDetail(dgAccount.Item(0, index).Value, dgAccount.Item(9, index).Value, dgAccount.Item(9, index).Value) Then

                            payReceiptDetail(vIdPay, idAcccount, dgAccount.Item(0, index).Value, dgAccount.Item(9, index).Value)

                            dataConceptReceipt(indexConcept) = dgAccount.Item(6, index).Value
                            dataConceptReceipt(indexConcept + 6) = Format(CDec(dgAccount.Item(9, index).Value), "###,##0.00")
                            amountPayTotal += dgAccount.Item(9, index).Value
                            indexConcept += 1

                            amountPay -= dgAccount.Item(9, index).Value
                        End If
                    ElseIf dgAccount.Item(9, index).Value > amountPay And amountPay > 0 Then
                        If payAccountDetail(dgAccount.Item(0, index).Value, amountPay, dgAccount.Item(9, index).Value) Then

                            payReceiptDetail(vIdPay, idAcccount, dgAccount.Item(0, index).Value, amountPay)

                            dataConceptReceipt(indexConcept) = dgAccount.Item(6, index).Value
                            dataConceptReceipt(indexConcept + 6) = Format(CDec(amountPay), "###,##0.00")
                            amountPayTotal += amountPay
                            indexConcept += 1

                            amountPay = 0
                        End If
                    Else
                        Exit For
                    End If
                End If
            Next

            payReceipt(vIdPay, vCodNumReceipt, idAcccount, rateYear, amountPayTotal, vNamePayer)
            dataConceptReceipt(12) = Format(amountPayTotal, "###,##0.00")
            getAccountYearUpdated(rateYear, vIdInternalLine, idAcccount)
            getAccountCollectCharge(idAcccount, dgAccount)
            Return dataConceptReceipt
            'Recordar implementar un limite de pagos por concepto en un maximo de 6
        Else
            dataConceptReceipt = Nothing
            Return dataConceptReceipt
        End If
    End Function

    Public Sub payReceiptDetail(vIdPaymnent As Integer, vIdAccountLine As String, idDetailAccount As String, amountPay As Decimal)
        Dim insertPaymentDetail As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdPaymnent = Nothing And vIdAccountLine = Nothing And idDetailAccount = Nothing And amountPay = Nothing) Then
                insertPaymentDetail.Connection = cnnx
                insertPaymentDetail.CommandType = CommandType.Text
                insertPaymentDetail.CommandText = "INSERT INTO payment_detail(payment, accountline, accountdetail, payamount) VALUES(@idpay, @internalline, @accountdetail, @payamount)"
                insertPaymentDetail.Parameters.AddWithValue("idpay", vIdPaymnent)
                insertPaymentDetail.Parameters.AddWithValue("internalline", vIdAccountLine)
                insertPaymentDetail.Parameters.AddWithValue("accountdetail", idDetailAccount)
                insertPaymentDetail.Parameters.AddWithValue("payamount", amountPay)
                insertPaymentDetail.ExecuteNonQuery()
            Else
                MsgBox("Faltan datos para registrar el pago detalle", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub payReceipt(idPaymnent As Integer, vCodNumReceipt As String, vIdAccount As String, vAccountYear As Integer, amountPayTotal As Decimal, payerUser As String)
        Dim insertPaymentDetail As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then
            If Not (idPaymnent = Nothing And vCodNumReceipt = Nothing And vIdAccount = Nothing And amountPayTotal = Nothing And payerUser = Nothing) Then
                insertPaymentDetail.Connection = cnnx
                insertPaymentDetail.CommandType = CommandType.Text
                insertPaymentDetail.CommandText = "INSERT INTO payments(idpayment, codepay, accountline, yearrate, amounttotal, payer, collector) VALUES(@idpay, @codepay, @accountline, @yearrate, @amounttotal, @payer, @collector)"
                insertPaymentDetail.Parameters.AddWithValue("idpay", idPaymnent)
                insertPaymentDetail.Parameters.AddWithValue("codepay", vCodNumReceipt)
                insertPaymentDetail.Parameters.AddWithValue("accountline", vIdAccount)
                insertPaymentDetail.Parameters.AddWithValue("yearrate", vAccountYear)
                insertPaymentDetail.Parameters.AddWithValue("amounttotal", amountPayTotal)
                insertPaymentDetail.Parameters.AddWithValue("payer", payerUser)
                insertPaymentDetail.Parameters.AddWithValue("collector", My.Settings.vUserIdLogin)
                insertPaymentDetail.ExecuteNonQuery()
            Else
                MsgBox("Faltan datos para registrar el pago", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub getAccountYearUpdated(yearRate As Integer, vIdInternalLine As String, vIdAccount As String)
        Dim cmdGetAccountYearDetail, cmdUpdateAccountYear As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableAccount As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdInternalLine = Nothing And vIdAccount = Nothing) Then
                Try
                    cmdGetAccountYearDetail.Connection = cnnx
                    cmdGetAccountYearDetail.CommandType = CommandType.Text
                    cmdGetAccountYearDetail.CommandText = "SELECT DISTINCTROW 
                    SUM(account_detail.saldototal) AS total 
                    FROM account_detail WHERE account_detail.yearrate = @yearrate AND account_detail.accountline = @idaccountline"
                    cmdGetAccountYearDetail.Parameters.AddWithValue("yearrate", yearRate)
                    cmdGetAccountYearDetail.Parameters.AddWithValue("idaccountline", vIdAccount)
                    ada.SelectCommand = cmdGetAccountYearDetail
                    ada.Fill(tableAccount)

                    If tableAccount.Rows.Count > 0 Then
                        Dim saldoTotalYear As Decimal = 0
                        saldoTotalYear = Val(tableAccount.Rows(0).Item(0).ToString)

                        cmdUpdateAccountYear.Connection = cnnx
                        cmdUpdateAccountYear.CommandType = CommandType.Text
                        cmdUpdateAccountYear.CommandText = "UPDATE account_line SET account_line.saldototal = @accountsaldo 
                        WHERE account_line.idaccountline = @idaccountline AND account_line.yearrate = @yearrate"
                        cmdUpdateAccountYear.Parameters.AddWithValue("accountsaldo", saldoTotalYear)
                        cmdUpdateAccountYear.Parameters.AddWithValue("idaccountline", vIdAccount)
                        cmdUpdateAccountYear.Parameters.AddWithValue("yearrate", yearRate)
                        cmdUpdateAccountYear.ExecuteNonQuery()
                    Else
                        MsgBox("No hay registro de cuenta", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al obtener el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se envio el codigo de la cuenta", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Function payAccountDetail(idAccountDetail As Integer, amountPay As Decimal, amountSaldo As Decimal) As Boolean
        Dim cmdUpdateAccountDetail As New MySqlCommand

        If Not cnnx.DataSource.Equals("") Then

            If Not idAccountDetail = Nothing Then
                Try
                    cmdUpdateAccountDetail.Connection = cnnx
                    cmdUpdateAccountDetail.CommandType = CommandType.Text
                    cmdUpdateAccountDetail.CommandText = "UPDATE account_detail SET account_detail.saldototal = @amountsaldo 
                    WHERE account_detail.idaccountdetail = @idaccountdetail"
                    cmdUpdateAccountDetail.Parameters.AddWithValue("amountsaldo", CDec(amountSaldo - amountPay))
                    cmdUpdateAccountDetail.Parameters.AddWithValue("idaccountdetail", idAccountDetail)
                    cmdUpdateAccountDetail.ExecuteNonQuery()

                    Return True
                Catch ex As Exception
                    MsgBox("Ocurrio un error al actualizar el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                    Return False
                End Try
            Else
                MsgBox("No se envio el codigo de la linea", vbCritical, "Aviso")
                Return False
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return False
        End If
    End Function

    Public Function getAccount(vIdServiceLine As String, vIdInternalLine As String) As String()
        Dim cmdGetAccount As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableAccount As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdServiceLine = Nothing And vIdInternalLine = Nothing) Then
                Try
                    cmdGetAccount.Connection = cnnx
                    cmdGetAccount.CommandType = CommandType.Text
                    cmdGetAccount.CommandText = "SELECT 
                    internal_line.idinternalline, 
                    internal_line.serviceline, 
                    internal_line.code, 
                    service_line.code, 
                    internal_line.rate, 
                    internal_line.pricerate, 
                    internal_line.created, 
                    internal_line.updated 
                    FROM internal_line 
                    INNER JOIN service_line ON service_line.idserviceline = internal_line.serviceline 
                    WHERE internal_line.serviceline = @idserviceline AND internal_line.idinternalline = @idinternalline"
                    cmdGetAccount.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdGetAccount.Parameters.AddWithValue("idserviceline", vIdServiceLine)
                    ada.SelectCommand = cmdGetAccount
                    ada.Fill(tableAccount)

                    If tableAccount.Rows.Count > 0 Then
                        Dim dataAccount(7) As String
                        dataAccount(0) = tableAccount.Rows(0).Item(0).ToString 'Id de internalline
                        dataAccount(1) = tableAccount.Rows(0).Item(1).ToString 'Id de serviceline
                        dataAccount(2) = tableAccount.Rows(0).Item(2).ToString 'Code de internalline
                        dataAccount(3) = tableAccount.Rows(0).Item(3).ToString 'Code de serviceline
                        dataAccount(4) = tableAccount.Rows(0).Item(4).ToString 'Id de rate
                        dataAccount(5) = tableAccount.Rows(0).Item(5).ToString 'Precio rate
                        dataAccount(6) = Format(tableAccount.Rows(0).Item(6).ToString, "Short Date")
                        dataAccount(7) = Format(tableAccount.Rows(0).Item(7).ToString, "Short Date")

                        Return dataAccount
                    Else
                        MsgBox("No hay registro de cuenta", vbCritical, "Aviso")
                        Return Nothing
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al obtener el registro", vbCritical, "Aviso")
                    MsgBox(ex.Message)
                    Return Nothing
                End Try
            Else
                MsgBox("No se envio el codigo de la cuenta", vbCritical, "Aviso")
                Return Nothing
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return Nothing
        End If
    End Function

    Public Function getAccountLine(vIdAccount As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableAccount As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                  account_line.idaccountline,
                  account_line.internalline,
                  years_rate.idyearrate,
                  years_rate.year,
                  account_line.debttotal,
                  account_line.saldototal
                FROM
                  account_line
                  INNER JOIN years_rate
                    ON years_rate.idyearrate = account_line.yearrate 
                WHERE account_line.idaccountline = @idaccount"
                cmd.Parameters.AddWithValue("idaccount", vIdAccount)
                ada.SelectCommand = cmd
                ada.Fill(tableAccount)

                If tableAccount.Rows.Count > 0 Then
                    Dim dataAccount(5) As String
                    dataAccount(0) = tableAccount.Rows(0).Item(0).ToString 'Id de cuenta
                    dataAccount(1) = tableAccount.Rows(0).Item(1).ToString 'Id de linea interna
                    dataAccount(2) = tableAccount.Rows(0).Item(2).ToString 'Id de año
                    dataAccount(3) = tableAccount.Rows(0).Item(3).ToString 'Año
                    dataAccount(4) = tableAccount.Rows(0).Item(4).ToString 'Deuda inicial
                    dataAccount(5) = tableAccount.Rows(0).Item(5).ToString 'Saldo total

                    Return dataAccount
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getLine(vIdServiceLine As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableLine As New DataTable

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                service_line.idserviceline, 
                service_line.code AS servicecode, 
                service_line.name AS servicename, 
                service_line.street, 
                streets.code AS streetcode, 
                streets.name AS streetname, 
                service_line.address, 
                service_line.installdate, 
                service_line.description, 
                service_line.created, 
                service_line.updated 
                FROM service_line 
                INNER JOIN streets ON streets.idstreet = service_line.street 
                WHERE service_line.idserviceline = @idserviceline"
                cmd.Parameters.AddWithValue("idserviceline", vIdServiceLine)
                ada.SelectCommand = cmd
                ada.Fill(tableLine)

                If tableLine.Rows.Count > 0 Then
                    Dim dataLine(10) As String
                    dataLine(0) = tableLine.Rows(0).Item(0).ToString 'Id de linea
                    dataLine(1) = tableLine.Rows(0).Item(1).ToString 'Codigo de linea
                    dataLine(2) = tableLine.Rows(0).Item(2).ToString 'Nombre de linea
                    dataLine(3) = tableLine.Rows(0).Item(3).ToString 'Id de sector
                    dataLine(4) = tableLine.Rows(0).Item(4).ToString 'Codigo de sector
                    dataLine(5) = tableLine.Rows(0).Item(5).ToString 'Nombre del sector
                    dataLine(6) = tableLine.Rows(0).Item(6).ToString 'Direccion de la linea
                    dataLine(7) = tableLine.Rows(0).Item(7).ToString 'Fecha de instalacion
                    dataLine(8) = tableLine.Rows(0).Item(8).ToString 'Descripcion de linea
                    dataLine(9) = tableLine.Rows(0).Item(9).ToString 'Fecha de registro
                    dataLine(10) = tableLine.Rows(0).Item(10).ToString 'Fecha de actualizacion

                    Return dataLine
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getUser(vIdUserReg As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableUsers As New DataTable

        If cnnx.DataSource.Equals("") Or IsNothing(vIdUserReg) Then
            Return Nothing
        Else
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                user_reg.iduserreg,
                user_reg.names,
                user_reg.surnames,
                user_reg.usertype,
                user_type.name,
                user_reg.docid,
                user_reg.address,
                user_reg.cellphone,
                user_reg.telephone,
                user_reg.created,
                user_reg.updated
                FROM user_reg
                INNER JOIN user_type ON user_type.idusertype = user_reg.usertype
                WHERE user_reg.iduserreg = @iduserreg"
                cmd.Parameters.AddWithValue("iduserreg", vIdUserReg)
                ada.SelectCommand = cmd
                ada.Fill(tableUsers)

                If tableUsers.Rows.Count > 0 Then
                    Dim dataUser(10) As String
                    dataUser(0) = tableUsers.Rows(0).Item(0).ToString 'Codigo de usuario
                    dataUser(1) = tableUsers.Rows(0).Item(1).ToString 'Nombres
                    dataUser(2) = tableUsers.Rows(0).Item(2).ToString 'Apellidos
                    dataUser(3) = tableUsers.Rows(0).Item(3).ToString 'Tipo de usuario
                    dataUser(4) = tableUsers.Rows(0).Item(4).ToString 'Nombre de tipo de usuario
                    dataUser(5) = tableUsers.Rows(0).Item(5).ToString 'Numero de documento
                    dataUser(6) = tableUsers.Rows(0).Item(6).ToString 'Direccion
                    dataUser(7) = tableUsers.Rows(0).Item(7).ToString 'Celular
                    dataUser(8) = tableUsers.Rows(0).Item(8).ToString 'Telefono
                    dataUser(9) = tableUsers.Rows(0).Item(9).ToString 'Fecha creado
                    dataUser(10) = tableUsers.Rows(0).Item(10).ToString 'Fecha actualizado

                    Return dataUser
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End If
    End Function

    Public Sub exportingExcel(vPrgWorking As ProgressBar, vYear As String, vIdYearRate As String, vCrit As Integer, Optional vOptionFill As Boolean = False, Optional vOptionMes As Boolean = False, Optional vMes As Integer = 0)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableExcel, TableLeyenda As New DataTable

        vMes += 1

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                service_line.idserviceline, 
                INTERLINE.idinternalline, 
                (SELECT @idyearrate) AS idyear, 
                rates.idrate, 
                service_line.code, 
                INTERLINE.code, 
                streets.name, 
                (SELECT GROUP_CONCAT(DISTINCT TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE users_line.internalline = INTERLINE.idinternalline) AS users, 
                rates.name, 
                (SELECT @year) AS datayear, 
                INTERLINE.pricerate 
                FROM internal_line INTERLINE
                INNER JOIN service_line ON service_line.idserviceline = INTERLINE.serviceline 
                INNER JOIN rates ON rates.idrate = INTERLINE.rate 
                INNER JOIN streets ON streets.idstreet = service_line.street 
                ORDER BY users ASC"
                cmd.Parameters.AddWithValue("idyearrate", vIdYearRate)
                cmd.Parameters.AddWithValue("year", vYear)

                ada.SelectCommand = cmd
                ada.Fill(TableExcel)

                With Hoja
                    .Name = "Servicios"
                    .SheetView.ZoomScale = 90
                    .PageSetup.PageOrientation = XLPageOrientation.Landscape
                    .PageSetup.PaperSize = XLPaperSize.A4Paper
                    .PageSetup.PrintAreas.Add("E:M")
                    .PageSetup.SetRowsToRepeatAtTop("1:1")
                    .PageSetup.FitToPages(1, 0)
                    .PageSetup.Margins.Left = 0.4
                    .PageSetup.Margins.Right = 0.4
                    .PageSetup.Margins.Top = 0.8
                    .PageSetup.Margins.Bottom = 0.8
                    .PageSetup.Margins.Header = 0.4
                    .PageSetup.Margins.Footer = 0.4
                    .PageSetup.Header.Left.AddText("JASS HUANGALA " & Year(Today))
                    .PageSetup.Footer.Left.AddText(UCase(Today))
                    .PageSetup.Footer.Center.AddText("LINEAS DE SERVICIO")
                    .PageSetup.Footer.Right.AddText("Página &P de &N")
                    .SheetView.FreezeRows(1)

                    .Range("A1").Value = "ID LINEA"
                    .Range("B1").Value = "ID CUENTA"
                    .Range("C1").Value = "ID AÑO"
                    .Range("D1").Value = "ID TARIFA"
                    .Range("E1").Value = "COD. SERVICIO DE LINEA"
                    .Range("F1").Value = "COD. CUENTA"
                    .Range("G1").Value = "CALLE O SECTOR"
                    .Range("H1").Value = "USUARIOS"
                    .Range("I1").Value = "TARIFA"
                    .Range("J1").Value = "AÑO"
                    .Range("K1").Value = "PRECIO"
                    .Range("L1").Value = "SERVICIO"
                    .Range("M1").Value = "MES"
                    .Range("N1").Value = "TARIFA MES"

                    .Columns("A:D").Hide()
                    .Columns("E").Width = 25
                    .Columns("F").Width = 15
                    .Columns("G").Width = 20
                    .Columns("H").Width = 45
                    .Columns("I").Width = 30
                    .Columns("J").Width = 10
                    .Columns("K").Width = 12
                    .Columns("L").Width = 12
                    .Columns("M").Width = 15
                    .Columns("N").Width = 12

                    'Dim index As Integer = 2
                    vPrgWorking.Minimum = 1
                    vPrgWorking.Maximum = TableExcel.Rows.Count
                    For index As Integer = 0 To TableExcel.Rows.Count - 1
                        Dim flecha As Integer = index + 2
                        .Range("A" & flecha).Value = TableExcel.Rows(index).Item(0).ToString
                        .Range("B" & flecha).Value = TableExcel.Rows(index).Item(1).ToString
                        .Range("C" & flecha).Value = TableExcel.Rows(index).Item(2).ToString
                        .Range("D" & flecha).Value = TableExcel.Rows(index).Item(3).ToString
                        .Range("E" & flecha).Value = TableExcel.Rows(index).Item(4).ToString
                        .Range("F" & flecha).Value = TableExcel.Rows(index).Item(5).ToString
                        .Range("G" & flecha).Value = TableExcel.Rows(index).Item(6).ToString
                        .Range("H" & flecha).Value = TableExcel.Rows(index).Item(7).ToString
                        .Range("I" & flecha).Value = TableExcel.Rows(index).Item(8).ToString
                        .Range("J" & flecha).Value = TableExcel.Rows(index).Item(9).ToString
                        .Range("K" & flecha).Value = TableExcel.Rows(index).Item(10).ToString

                        If vOptionMes Then
                            .Range("M" & flecha).Value = vMes
                        Else
                            .Range("M" & flecha).Value = 0
                        End If

                        If vOptionFill Then
                            .Range("N" & flecha).Value = TableExcel.Rows(index).Item(10).ToString
                        Else
                            .Range("N" & flecha).Value = 0
                        End If

                        vPrgWorking.Value = index + 1
                    Next
                End With

                'Consulta para la siguiente hoja
                cmd.CommandText = "SELECT 
                idratetype, 
                name,
                description, 
                periodic 
                FROM rate_types"

                ada.SelectCommand = cmd
                ada.Fill(TableLeyenda)

                Hoja = Libro.Worksheets.Add("Leyenda")

                With Hoja
                    .Cell("A1").Value = "ID DE ORDEN"
                    .Cell("B1").Value = "NOMBRE"
                    .Cell("C1").Value = "DESCRIPCION"
                    .Cell("D1").Value = "PERIODICO"
                    .Columns("A").Width = 12
                    .Columns("B").Width = 15
                    .Columns("C").Width = 45
                    .Columns("D").Width = 12

                    vPrgWorking.Minimum = 1
                    vPrgWorking.Maximum = TableLeyenda.Rows.Count
                    For index As Integer = 0 To TableLeyenda.Rows.Count - 1
                        Dim flecha As Integer = index + 2
                        .Cell("A" & flecha).Value = TableLeyenda.Rows(index).Item(0).ToString
                        .Cell("B" & flecha).Value = TableLeyenda.Rows(index).Item(1).ToString
                        .Cell("C" & flecha).Value = TableLeyenda.Rows(index).Item(2).ToString
                        .Cell("D" & flecha).Value = CBool(TableLeyenda.Rows(index).Item(3))
                        vPrgWorking.Value = index + 1
                    Next
                End With
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub importingExcel(vPrgWorking As ProgressBar)
        With Hoja
            Dim rowsLast As Integer = .Range("E:E").LastRowUsed.RowNumber
            vPrgWorking.Minimum = 1
            vPrgWorking.Maximum = rowsLast - 1
            If rowsLast > 1 Then
                For index = 2 To rowsLast
                    If (Trim(.Cell("A" & index).Value) <> "" And Trim(.Cell("B" & index).Value) <> "" And Trim(.Cell("C" & index).Value) <> "" And Trim(.Cell("D" & index).Value) <> "") Then
                        Dim accountYear As Integer = addAccountYear(.Cell("B" & index).Value, .Cell("C" & index).Value)
                        If accountYear = 1 Then
                            .Cell("O" & index).Value = "AÑO INSERTADO"
                        ElseIf accountYear = 2 Then
                            .Cell("O" & index).Value = "AÑO ENCONTRADO"
                        Else
                            .Cell("O" & index).Value = "NO INGRESADO"
                        End If

                        If CDec(.Cell("N" & index).Value) > 0 And accountYear > 0 Then
                            Dim accountDetail As Integer = addAccountDetail(.Cell("B" & index).Value, .Cell("C" & index).Value, .Cell("L" & index).Value, .Cell("M" & index).Value, .Cell("N" & index).Value)
                            If accountDetail = 1 Then
                                .Cell("P" & index).Value = "MES O CUENTA INSERTADA"
                            ElseIf accountDetail = 2 Then
                                .Cell("P" & index).Value = "MES O CUENTA ENCONTRADA"
                            Else
                                .Cell("P" & index).Value = "NO INGRESADO"
                            End If
                        Else
                            .Cell("P" & index).Value = "SE NECESITA AÑO O DATO"
                        End If
                    Else
                        .Cell("O" & index).Value = "FALTAN DATOS"
                    End If
                    vPrgWorking.Value = index - 1
                Next
            Else
                MsgBox("No hay datos que cargar", vbExclamation, "Aviso")
            End If
        End With
        Libro.Save()
    End Sub

    Public Function addAccountYear(vIdInternalLine As String, vIdYearRate As String) As Integer
        Dim cmdCheked, cmdInsertAccountYear As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableCheck As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmdCheked.Connection = cnnx
                cmdCheked.CommandType = CommandType.Text
                cmdCheked.CommandText = "SELECT 
                * 
                FROM account_line 
                WHERE account_line.internalline = @idinternalline AND account_line.yearrate = @idyearrate"
                cmdCheked.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                cmdCheked.Parameters.AddWithValue("idyearrate", vIdYearRate)
                ada.SelectCommand = cmdCheked
                ada.Fill(TableCheck)

                Dim check As Boolean = False
                If TableCheck.Rows.Count > 0 Then
                    check = True
                End If

                If Not check Then
                    cmdInsertAccountYear.Connection = cnnx
                    cmdInsertAccountYear.CommandType = CommandType.Text
                    cmdInsertAccountYear.CommandText = "INSERT INTO account_line(internalline, yearrate, debttotal, saldototal) VALUES(" & vIdInternalLine & ", " & vIdYearRate & ", 0, 0)"
                    cmdInsertAccountYear.ExecuteNonQuery()
                    Return 1
                Else
                    Return 2
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar o grabar los datos del año", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return 0
            End Try
        Else
            Return 0
        End If
    End Function

    Public Function addAccountDetail(vIdInternalLine As String, vIdYearRate As String, vIdDetail As String, vMonth As String, vDebtAmount As Decimal) As Integer
        Dim cmdChekedDetail, cmdChekedYear, cmdChekedRateType, cmdInsertAccountDetail, cmdUpdateAccountYear As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableCheckYear, TableCheckDetail, TableCheckRateType As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmdChekedYear.Connection = cnnx
                cmdChekedYear.CommandType = CommandType.Text
                cmdChekedYear.CommandText = "SELECT 
                account_line.idaccountline 
                FROM account_line 
                WHERE account_line.internalline = @idinternalline AND account_line.yearrate = @idyearrate"
                cmdChekedYear.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                cmdChekedYear.Parameters.AddWithValue("idyearrate", vIdYearRate)
                ada.SelectCommand = cmdChekedYear
                ada.Fill(TableCheckYear)

                Dim vIdAccountLine As String
                Dim chekedYear As Boolean = False

                If TableCheckYear.Rows.Count > 0 Then
                    chekedYear = True
                End If

                If chekedYear Then
                    vIdAccountLine = TableCheckYear.Rows(0).Item(0).ToString
                Else
                    vIdAccountLine = 0
                    chekedYear = False
                End If

                If chekedYear And (vIdAccountLine <> "" And vIdYearRate <> "" And vIdDetail <> "") Then
                    cmdChekedDetail.Connection = cnnx
                    cmdChekedDetail.CommandType = CommandType.Text
                    cmdChekedDetail.CommandText = "SELECT 
                    * 
                    FROM account_detail 
                    INNER JOIN rate_types ON rate_types.idratetype = account_detail.ratetype
                    WHERE account_detail.accountline = @idaccountline AND account_detail.yearrate = @idyearrate AND account_detail.ratetype = @idratetype AND account_detail.month = @month"
                    cmdChekedDetail.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                    cmdChekedDetail.Parameters.AddWithValue("idyearrate", vIdYearRate)
                    cmdChekedDetail.Parameters.AddWithValue("idratetype", vIdDetail)
                    cmdChekedDetail.Parameters.AddWithValue("month", vMonth)
                    ada.SelectCommand = cmdChekedDetail
                    ada.Fill(TableCheckDetail)

                    Dim checkDetail As Boolean = False

                    If TableCheckDetail.Rows.Count > 0 Then
                        checkDetail = True
                    Else
                        cmdChekedRateType.Connection = cnnx
                        cmdChekedRateType.CommandType = CommandType.Text
                        cmdChekedRateType.CommandText = "SELECT rate_types.periodic FROM rate_types WHERE rate_types.idratetype = @idratetype"
                        cmdChekedRateType.Parameters.AddWithValue("idratetype", vIdDetail)
                        ada.SelectCommand = cmdChekedRateType
                        ada.Fill(TableCheckRateType)

                        If TableCheckRateType.Rows.Count > 0 Then
                            If CBool(TableCheckRateType.Rows(0).Item(0).ToString) = True And vMonth > 0 Then
                                checkDetail = False
                            End If
                        End If
                    End If

                    If Not checkDetail And (vIdAccountLine <> "" And vIdYearRate <> "" And vIdDetail <> "") Then
                        cmdInsertAccountDetail.Connection = cnnx
                        cmdInsertAccountDetail.CommandType = CommandType.Text
                        cmdInsertAccountDetail.CommandText = "INSERT INTO account_detail(accountline, yearrate, ratetype, month, debttotal, saldototal) VALUES(" & vIdAccountLine & ", " & vIdYearRate & ", " & vIdDetail & ", " & vMonth & ", " & vDebtAmount & ", " & vDebtAmount & ")"
                        cmdInsertAccountDetail.ExecuteNonQuery()

                        cmdUpdateAccountYear.Connection = cnnx
                        cmdUpdateAccountYear.CommandType = CommandType.Text
                        cmdUpdateAccountYear.CommandText = "UPDATE 
                        account_line 
                        SET account_line.saldototal = (SELECT SUM(account_detail.saldototal) AS saldototal FROM account_detail WHERE account_detail.accountline = @idaccountline), 
                        account_line.debttotal = (SELECT SUM(account_detail.debttotal) AS debttotal FROM account_detail WHERE account_detail.accountline = @idaccountline) 
                        WHERE account_line.idaccountline = @idaccountline"
                        cmdUpdateAccountYear.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                        cmdUpdateAccountYear.ExecuteNonQuery()
                        Return 1
                    Else
                        Return 2
                    End If
                Else
                    Return 0
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar o grabar los datos de la cuenta detalle", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return 0
            End Try
        Else
            Return 0
        End If
    End Function

    Public Sub listRateTypes(dgRates As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableRates As New DataTable

        dgRates.Rows.Clear()
        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                idratetype, 
                name, 
                description, 
                periodic 
                FROM rate_types"
                ada.SelectCommand = cmd
                ada.Fill(TableRates)

                For index As Integer = 0 To TableRates.Rows.Count - 1
                    dgRates.Rows.Add(TableRates.Rows(index).Item(0), TableRates.Rows(index).Item(1), TableRates.Rows(index).Item(2), CBool(TableRates.Rows(index).Item(3)))
                Next
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar o grabar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgRates.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listYears(dgYears As DataGridView)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableYears As New DataTable

        dgYears.Rows.Clear()
        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                idyearrate, 
                year, 
                active, 
                nameyear 
                FROM years_rate"
                ada.SelectCommand = cmd
                ada.Fill(TableYears)

                For index As Integer = 0 To TableYears.Rows.Count - 1
                    dgYears.Rows.Add(TableYears.Rows(index).Item(0), TableYears.Rows(index).Item(1), CBool(TableYears.Rows(index).Item(2)), TableYears.Rows(index).Item(3))
                Next
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgYears.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listLastReceipts(dgReceipts As DataGridView, vNumReceipt As String, Optional vSeeNumReceipts As Integer = 10)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableReceipts As New DataTable
        Dim valNumReceipt As Integer = Val(vNumReceipt)

        dgReceipts.Rows.Clear()
        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                    payments.idpayment,
                    payments.codepay,
                    payments.accountline,
                    years_rate.year,
                    IF(payments.canceled,""Anulado"","""") AS state,
                    payments.amounttotal,
                    payments.payer,
                    UCASE(user_sys.name) AS usercollect,
                    payments.created,
                    payments.updated
                FROM
                    payments
                    INNER JOIN years_rate
                    ON years_rate.idyearrate = payments.yearrate
                    LEFT JOIN account_line
                    ON account_line.idaccountline = payments.accountline
                    LEFT JOIN internal_line
                    ON internal_line.idinternalline = account_line.internalline
                    INNER JOIN user_sys
                    ON user_sys.idusersys = payments.collector
                WHERE CONVERT(payments.codepay,SIGNED) <= @numreceipt
                ORDER BY payments.created DESC
                LIMIT " & vSeeNumReceipts
                cmd.Parameters.AddWithValue("numreceipt", valNumReceipt)
                ada.SelectCommand = cmd
                ada.Fill(tableReceipts)

                For index As Integer = 0 To tableReceipts.Rows.Count - 1
                    dgReceipts.Rows.Add(tableReceipts.Rows(index).Item(0).ToString, tableReceipts.Rows(index).Item(2).ToString, tableReceipts.Rows(index).Item(3).ToString, tableReceipts.Rows(index).Item(1).ToString, tableReceipts.Rows(index).Item(4).ToString, Format(CDec(tableReceipts.Rows(index).Item(5).ToString), "###,##0.00"), tableReceipts.Rows(index).Item(6).ToString, tableReceipts.Rows(index).Item(7).ToString, tableReceipts.Rows(index).Item(8).ToString)
                Next
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgReceipts.Rows.Clear()
            End Try
        End If
    End Sub

    Public Function getRateType(vIdRateType As String) As String()
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim TableRates As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                idratetype, 
                name, 
                description, 
                periodic 
                FROM rate_types WHERE rate_types.idratetype = @idratetype"
                cmd.Parameters.AddWithValue("idratetype", vIdRateType)
                ada.SelectCommand = cmd
                ada.Fill(TableRates)

                If TableRates.Rows.Count > 0 Then
                    Dim dataRate(3) As String
                    dataRate(0) = TableRates.Rows(0).Item(0).ToString
                    dataRate(1) = TableRates.Rows(0).Item(1).ToString
                    dataRate(2) = TableRates.Rows(0).Item(2).ToString
                    dataRate(3) = TableRates.Rows(0).Item(3).ToString
                    Return dataRate
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return Nothing
            End Try
        Else
            Return Nothing
        End If
    End Function

    Public Sub addupdRateType(vIdRateType As String, vNameRateType As String, vDescRateType As String, vPeriodic As Boolean)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter

        If vIdRateType <> "" And vNameRateType.Trim <> "" And vDescRateType.Trim <> "" Then
            If Not cnnx.DataSource.Equals("") Then
                Try
                    cmd.Connection = cnnx
                    cmd.CommandType = CommandType.Text
                    If vIdRateType = "new" Then
                        cmd.CommandText = "INSERT INTO rate_types(name, description, periodic) VALUES(@name, @desc, @periodic)"
                        cmd.Parameters.AddWithValue("name", vNameRateType)
                        cmd.Parameters.AddWithValue("desc", vDescRateType)
                        cmd.Parameters.AddWithValue("periodic", CInt(vPeriodic))
                        cmd.ExecuteNonQuery()
                        MsgBox("El registro se guardo exitosamente", vbInformation, "Aviso")
                    Else
                        cmd.CommandText = "UPDATE rate_types SET rate_types.name = @name, rate_types.description = @desc, rate_types.periodic = @periodic WHERE rate_types.idratetype = @idratetype"
                        cmd.Parameters.AddWithValue("name", vNameRateType)
                        cmd.Parameters.AddWithValue("desc", vDescRateType)
                        cmd.Parameters.AddWithValue("periodic", CInt(vPeriodic))
                        cmd.Parameters.AddWithValue("idratetype", vIdRateType)
                        cmd.ExecuteNonQuery()
                        MsgBox("El registro se actualizo", vbInformation, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al cargar o grabar los datos", vbExclamation, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            End If
        Else
            MsgBox("Faltan datos en los campos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub addupdYear(vIdYear As String, vYear As Integer, vYearName As String, vActive As Integer, Optional vActiveYear As Boolean = False)
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindYear As New DataTable

        If vIdYear <> "" And vYearName.Trim <> "" And vYear <> 0 Then
            If Not cnnx.DataSource.Equals("") Then
                Try
                    cmd.Connection = cnnx
                    cmd.CommandType = CommandType.Text
                    If vIdYear = "new" Then
                        cmd.CommandText = "SELECT * FROM years_rate WHERE years_rate.year = @year"
                        cmd.Parameters.AddWithValue("year", vYear)
                        ada.SelectCommand = cmd
                        ada.Fill(tableFindYear)

                        If tableFindYear.Rows.Count > 0 Then
                            MsgBox("Ya existe el año que trata de ingresar", vbExclamation, "Aviso")
                        Else
                            cmd.CommandText = "INSERT INTO years_rate(year, nameyear) VALUES(@vyear, @nameyear)"
                            cmd.Parameters.AddWithValue("vyear", vYear)
                            cmd.Parameters.AddWithValue("nameyear", vYearName)
                            cmd.ExecuteNonQuery()
                            MsgBox("El registro se guardo exitosamente", vbInformation, "Aviso")
                        End If
                    Else
                        If vActiveYear = True Then
                            cmd.CommandText = "UPDATE years_rate SET years_rate.active = @active"
                            cmd.Parameters.AddWithValue("active", False)
                            cmd.ExecuteNonQuery()
                        End If

                        cmd.CommandText = "UPDATE years_rate SET years_rate.year = @year, years_rate.active = @yearactive, years_rate.nameyear = @nameyear WHERE years_rate.idyearrate = @idyearrate"
                        cmd.Parameters.AddWithValue("year", vYear)
                        cmd.Parameters.AddWithValue("yearactive", vActive)
                        cmd.Parameters.AddWithValue("nameyear", vYearName)
                        cmd.Parameters.AddWithValue("idyearrate", vIdYear)
                        cmd.ExecuteNonQuery()
                        MsgBox("El registro se actualizo", vbInformation, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error al cargar o grabar los datos", vbExclamation, "Aviso")
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            End If
        Else
            MsgBox("Faltan datos en los campos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub updDetail(vIdAccountLine As String, vIdAccountDetail As String, vAmountNew As Decimal)
        Dim cmd, cmdUpdateAccountYear As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim tableFindPays As New DataTable

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT 
                IFNULL(SUM(payment_detail.payamount),0) AS sumpays
                FROM payment_detail 
                INNER JOIN payments ON payments.idpayment = payment_detail.payment
                WHERE payments.canceled = 0 AND payment_detail.accountdetail = @idaccountdetail"
                cmd.Parameters.AddWithValue("idaccountdetail", vIdAccountDetail)
                ada.SelectCommand = cmd
                ada.Fill(tableFindPays)

                If tableFindPays.Rows.Count > 0 Then
                    Dim AccountAmountMax As Decimal = CDec(tableFindPays.Rows(0).Item(0).ToString)

                    If vAmountNew < AccountAmountMax Then
                        MsgBox("La suma de los recibos cobrados en esta cuenta son mayores" & vbCr & "al nuevo monto ingresado. Si desea aplicar este cambio primero anule los recibos.", vbExclamation, "Aviso")
                        Exit Sub
                    Else
                        cmd.CommandText = "UPDATE account_detail 
                        SET account_detail.debttotal = @newamount, 
                        account_detail.saldototal = @newamount 
                        WHERE account_detail.idaccountdetail = @idaccountdet"
                        cmd.Parameters.AddWithValue("newamount", vAmountNew)
                        cmd.Parameters.AddWithValue("idaccountdet", vIdAccountDetail)
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "UPDATE account_detail 
                        SET account_detail.saldototal = @amount - (SELECT IFNULL(SUM(payment_detail.payamount),0) FROM payment_detail INNER JOIN payments ON payments.idpayment = payment_detail.payment WHERE payments.canceled = 0 AND payment_detail.accountdetail = @idaccountdeta)
                        WHERE account_detail.idaccountdetail = @idaccountdeta"
                        cmd.Parameters.AddWithValue("amount", vAmountNew)
                        cmd.Parameters.AddWithValue("idaccountdeta", vIdAccountDetail)
                        cmd.ExecuteNonQuery()

                        cmdUpdateAccountYear.Connection = cnnx
                        cmdUpdateAccountYear.CommandType = CommandType.Text
                        cmdUpdateAccountYear.CommandText = "UPDATE 
                        account_line 
                        SET account_line.saldototal = (SELECT IFNULL(SUM(account_detail.saldototal),0) AS saldototal FROM account_detail WHERE account_detail.accountline = @idaccountline), 
                        account_line.debttotal = (SELECT IFNULL(SUM(account_detail.debttotal),0) AS debttotal FROM account_detail WHERE account_detail.accountline = @idaccountline) 
                        WHERE account_line.idaccountline = @idaccountline"
                        cmdUpdateAccountYear.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                        cmdUpdateAccountYear.ExecuteNonQuery()

                        MsgBox("El registro se actualizo", vbInformation, "Aviso")
                    End If
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar o grabar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function reportReceipts(dataReport() As String) As dsReceipts
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim ds As New dsReceipts

        If Not cnnx.DataSource.Equals("") Then
            Try
                Dim cmdstr As String = ""

                cmdstr &= " WHERE "

                If CBool(dataReport(0)) Then
                    cmdstr = cmdstr & "(DATE_FORMAT(payments.created, ""%Y-%m-%d"") BETWEEN """ & CDate(dataReport(1)).ToString("yyyy-MM-dd") & """ AND """ & CDate(dataReport(2)).ToString("yyyy-MM-dd") & """)"
                Else
                    cmdstr &= " (payments.created <> """")"
                End If

                If CBool(dataReport(3)) Then
                    cmdstr = cmdstr & " AND (user_sys.idusersys = " & dataReport(4) & ")"
                Else
                    cmdstr &= " AND (user_sys.idusersys <> """")"
                End If

                If CBool(dataReport(5)) Then
                    cmdstr = cmdstr & " AND (payments.yearrate = " & dataReport(6) & ")"
                Else
                    cmdstr &= " AND (payments.yearrate <> """")"
                End If

                If CBool(dataReport(7)) Then
                    cmdstr = cmdstr & " AND (service_line.street = " & dataReport(8) & ")"
                Else
                    cmdstr &= " AND (service_line.street <> """")"
                End If

                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                  payments.idpayment, 
                  CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, 
                  payments.payer, 
                  payments.codepay, 
                  IF(payments.canceled,""Anulado"","""") AS state,
                  years_rate.year, 
                  IF(payments.canceled,0,payments.amounttotal) AS amount, 
                  user_sys.name, 
                  DATE_FORMAT(payments.created,""%d/%m/%Y"") AS created 
                FROM
                  payments
                  INNER JOIN user_sys
                    ON user_sys.idusersys = payments.collector
                  INNER JOIN years_rate
                    ON years_rate.idyearrate = payments.yearrate
                  INNER JOIN account_line
                    ON account_line.idaccountline = payments.accountline
                  INNER JOIN internal_line
                    ON internal_line.idinternalline = account_line.internalline
                  INNER JOIN users_line
                    ON users_line.internalline = internal_line.idinternalline
                  INNER JOIN user_reg
                    ON user_reg.iduserreg = users_line.userreg 
                  INNER JOIN service_line 
                    ON service_line.idserviceline = internal_line.serviceline " & cmdstr &
                "ORDER BY payments.created ASC"
                ada.SelectCommand = cmd
                ada.Fill(ds, "dtReceipts")

                Return ds
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return ds
            End Try
        Else
            Return ds
        End If
    End Function

    Public Function reportReceiptsResume(dataReport() As String) As dsReceipts
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim ds As New dsReceipts

        If Not cnnx.DataSource.Equals("") Then
            Try
                Dim cmdstr As String = ""

                cmdstr &= " WHERE "

                If CBool(dataReport(0)) Then
                    cmdstr = cmdstr & "(DATE_FORMAT(payments.created, ""%Y-%m-%d"") BETWEEN """ & CDate(dataReport(1)).ToString("yyyy-MM-dd") & """ AND """ & CDate(dataReport(2)).ToString("yyyy-MM-dd") & """)"
                Else
                    cmdstr &= " (payments.created <> """")"
                End If

                If CBool(dataReport(3)) Then
                    cmdstr = cmdstr & " AND (user_sys.idusersys = " & dataReport(4) & ")"
                Else
                    cmdstr &= " AND (user_sys.idusersys <> """")"
                End If

                If CBool(dataReport(5)) Then
                    cmdstr = cmdstr & " AND (payments.yearrate = " & dataReport(6) & ")"
                Else
                    cmdstr &= " AND (payments.yearrate <> """")"
                End If

                If CBool(dataReport(7)) Then
                    cmdstr = cmdstr & " AND (service_line.street = " & dataReport(8) & ")"
                Else
                    cmdstr &= " AND (service_line.street <> """")"
                End If

                cmdstr &= " AND payments.canceled = 0 "

                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                  years_rate.year, 
                  (SELECT
                    SUM(payment_detail.payamount) AS ammounttotal
                  FROM
                    payment_detail
                  INNER JOIN payments
                    ON payments.idpayment = payment_detail.payment
                  INNER JOIN account_detail
                    ON account_detail.idaccountdetail = payment_detail.accountdetail
                  INNER JOIN account_line
                    ON account_line.idaccountline = payments.accountline
                  INNER JOIN internal_line
                    ON internal_line.idinternalline = account_line.internalline
                  INNER JOIN service_line
                    ON service_line.idserviceline = internal_line.serviceline
                  INNER JOIN user_sys
                    ON user_sys.idusersys = payments.collector" & cmdstr &
                  " AND account_detail.ratetype = 1) AS payconsumption,
                  (SELECT
                    SUM(payment_detail.payamount) AS ammounttotal
                  FROM
                    payment_detail
                  INNER JOIN payments
                    ON payments.idpayment = payment_detail.payment
                  INNER JOIN account_detail
                    ON account_detail.idaccountdetail = payment_detail.accountdetail
                  INNER JOIN account_line
                    ON account_line.idaccountline = payments.accountline
                  INNER JOIN internal_line
                    ON internal_line.idinternalline = account_line.internalline
                  INNER JOIN service_line 
                    ON service_line.idserviceline = internal_line.serviceline
                  INNER JOIN user_sys
                    ON user_sys.idusersys = payments.collector" & cmdstr &
                  " AND account_detail.ratetype <> 1) AS payothers,
                  IFNULL(SUM(payments.amounttotal),0) AS amounttotal 
                FROM
                  payments
                  INNER JOIN user_sys
                    ON user_sys.idusersys = payments.collector
                  INNER JOIN years_rate
                    ON years_rate.idyearrate = payments.yearrate
                  INNER JOIN account_line
                    ON account_line.idaccountline = payments.accountline
                  INNER JOIN internal_line
                    ON internal_line.idinternalline = account_line.internalline
                  INNER JOIN users_line 
                    ON users_line.internalline = internal_line.idinternalline
                  INNER JOIN user_reg
                    ON user_reg.iduserreg = users_line.userreg 
                  INNER JOIN service_line 
                    ON service_line.idserviceline = internal_line.serviceline " & cmdstr &
                "GROUP BY years_rate.year 
                 ORDER BY payments.created ASC"
                ada.SelectCommand = cmd
                ada.Fill(ds, "dtReceiptsResume")

                Return ds
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return ds
            End Try
        Else
            Return ds
        End If
    End Function

    Public Function reportDebtsResume(dataReport() As String) As dsDebts
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim ds As New dsDebts

        If Not cnnx.DataSource.Equals("") Then
            Try
                Dim cmdstr As String = ""
                Dim cmdstr2 As String = ""
                Dim cmdstr3 As String = ""

                cmdstr = cmdstr & " AND (DATE_FORMAT(payments.created, ""%Y-%m-%d"") <= """ & CDate(dataReport(1)).ToString("yyyy-MM-dd") & """) AND (DATE_FORMAT(account_line.created, ""%Y-%m-%d"") <= """ & CDate(dataReport(0)).ToString("yyyy-MM-dd") & """)"
                cmdstr2 = cmdstr2 & " AND (DATE_FORMAT(account_line.created, ""%Y-%m-%d"") <= """ & CDate(dataReport(0)).ToString("yyyy-MM-dd") & """)"

                If CBool(dataReport(2)) Then
                    cmdstr = cmdstr & " AND (payments.collector = " & dataReport(3) & ")"
                Else
                    cmdstr &= " AND (payments.collector <> """")"
                End If

                If CBool(dataReport(4)) Then
                    cmdstr3 = " WHERE yeardebt.idyearrate = " & dataReport(5)
                Else
                    cmdstr3 = ""
                End If

                If CBool(dataReport(6)) Then
                    cmdstr = cmdstr & " AND (service_line.street = " & dataReport(7) & ")"
                    cmdstr2 = cmdstr2 & " AND (service_line.street = " & dataReport(7) & ")"
                End If

                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT
                    yeardebt.year, 
                    (SELECT IFNULL(SUM(account_line.debttotal),0) FROM account_line LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE account_line.yearrate = yeardebt.idyearrate " & cmdstr2 & ") AS debtentered, 
                    (SELECT IFNULL(SUM(payments.amounttotal),0) FROM payments INNER JOIN account_line ON account_line.idaccountline = payments.accountline LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE payments.canceled=0 AND payments.yearrate = yeardebt.idyearrate" & cmdstr & ") AS paidout, 
                    (SELECT debtentered-paidout) AS debttodate 
                    FROM account_line INNER JOIN years_rate AS yeardebt ON yeardebt.idyearrate = account_line.yearrate" & cmdstr3 & " GROUP BY account_line.yearrate
                    ORDER BY yeardebt.year ASC"
                ada.SelectCommand = cmd
                ada.Fill(ds, "dtDebtsResume")

                Return ds
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return ds
            End Try
        Else
            Return ds
        End If
    End Function

    Public Function reportDebtsDetail(dataReport() As String) As dsDebtsDetail
        Dim cmd As New MySqlCommand
        Dim ada As New MySqlDataAdapter
        Dim ds As New dsDebtsDetail

        If Not cnnx.DataSource.Equals("") Then
            Try
                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT DISTINCT
                CALLE.idstreet AS idstreet,
                CALLE.name AS street,
                SERVICE.idserviceline AS idservice_line,
                SERVICE.name AS service_line,
                INTERNAL.code AS internal_line,
                (SELECT GROUP_CONCAT(TRIM(CONCAT(user_reg.surnames, "" "", user_reg.names)) SEPARATOR ',') AS fullname
                FROM internal_line
                INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline
                INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg
                WHERE internal_line.serviceline = SERVICE.idserviceline AND internal_line.idinternalline = INTERNAL.idinternalline) AS users_line,
                (SELECT IFNULL(SUM(account_line.saldototal),0) FROM account_line INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE years_rate.year <= @year1 AND account_line.internalline = INTERNAL.idinternalline) AS debt1,
                (SELECT IFNULL(SUM(account_line.saldototal),0) FROM account_line INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE years_rate.year = @year2 AND account_line.internalline = INTERNAL.idinternalline) AS debt2,
                (SELECT IFNULL(SUM(account_line.saldototal),0) FROM account_line INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE years_rate.year = @year3 AND account_line.internalline = INTERNAL.idinternalline) AS debt3,
                (SELECT IFNULL(SUM(account_line.saldototal),0) FROM account_line INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE years_rate.year = @year4 AND account_line.internalline = INTERNAL.idinternalline) AS debt4,
                (SELECT IFNULL(SUM(account_line.saldototal),0) FROM account_line INNER JOIN years_rate ON years_rate.idyearrate = account_line.yearrate LEFT JOIN internal_line ON internal_line.idinternalline = account_line.idaccountline LEFT JOIN service_line ON service_line.idserviceline = internal_line.serviceline WHERE years_rate.year = @year5 AND account_line.internalline = INTERNAL.idinternalline) AS debt5,
                (SELECT debt1+debt2+debt3+debt4+debt5) AS debttotal
                FROM internal_line AS INTERNAL
                LEFT JOIN service_line AS SERVICE ON INTERNAL.serviceline = SERVICE.idserviceline
                INNER JOIN streets AS CALLE ON CALLE.idstreet = SERVICE.street"
                cmd.Parameters.AddWithValue("year1", CInt(dataReport(8)) - 4)
                cmd.Parameters.AddWithValue("year2", CInt(dataReport(8)) - 3)
                cmd.Parameters.AddWithValue("year3", CInt(dataReport(8)) - 2)
                cmd.Parameters.AddWithValue("year4", CInt(dataReport(8)) - 1)
                cmd.Parameters.AddWithValue("year5", CInt(dataReport(8)))
                ada.SelectCommand = cmd
                ada.Fill(ds, "dtDebtsDetail")

                Return ds
            Catch ex As Exception
                MsgBox("Ocurrio un error al cargar", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return ds
            End Try
        Else
            Return ds
        End If
    End Function
End Module
