Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Module dataFunctions
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

    Public Function userLogin(ByVal nameusr As String, ByVal passwd As String)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            Return False
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT idusersys ,name, loguser, passuser FROM user_sys WHERE loguser = '" & nameusr & "' AND passuser = '" & passwd & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        My.Settings.vUserIdLogin = CInt(dr(0).ToString)
                        My.Settings.vUserNameLogin = dr(1).ToString
                        MsgBox("Bienvenid@ " + dr(1).ToString, vbInformation, "Aviso")
                    End While
                Else
                    MsgBox("El usuario o contraseña ingresadas son incorrectas o no existen", vbExclamation, "Aviso")
                    cmd.Dispose()
                    dr.Close()
                    Return False
                End If

                cmd.Dispose()

                Return True
            Catch ex As Exception
                Return False
            End Try
        End If
    End Function
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
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT code FROM streets WHERE idstreet LIKE '" & vIdSector & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    Dim codeLine As String = ""
                    Dim codeNum As String = CInt((10000 * Rnd()) + 1)
                    codeLine = Year(Today).ToString & "-" & Trim(dr(0).ToString) & "-" & codeNum.PadLeft(5, "0")

                    cmd.Dispose()
                    Return codeLine
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
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
    Public Function listRates() As DataSet
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cnnx.Close()
                cnnx.Open()
                ada.SelectCommand = New MySqlCommand("SELECT idrate, name FROM rates", cnnx)
                ada.Fill(ds)
                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function listAvenues() As DataSet
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cnnx.Close()
                cnnx.Open()
                ada.SelectCommand = New MySqlCommand("SELECT idstreet, name FROM streets ORDER BY name", cnnx)
                ada.Fill(ds)
                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function listUserTypes() As DataSet
        Dim ds As New DataSet
        Dim ada As New MySqlDataAdapter

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cnnx.Close()
                cnnx.Open()
                ada.SelectCommand = New MySqlCommand("SELECT idusertype, name FROM user_type", cnnx)
                ada.Fill(ds)
                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function listUsersInAccount(vIdInternalLine As String) As DataSet
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                cnnx.Close()
                cnnx.Open()

                cmd.Connection = cnnx
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT users_line.userreg AS iduser, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname " &
                "FROM users_line INNER JOIN user_reg ON users_line.userreg = user_reg.iduserreg WHERE users_line.internalline = @idinternalline"
                cmd.Parameters.AddWithValue("idinternalline", vIdInternalLine)

                Dim ada As New MySqlDataAdapter(cmd)
                ada.Fill(ds)
                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Sub listUsers(txtBusq As String, typeBusq As Integer, dgUsers As DataGridView)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            Dim comand As String

            Select Case typeBusq
                Case 0
                    'Buscar por nombres
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                Case Else
                    'Buscar a todos
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.idusertype, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype"
            End Select

            cmd.CommandText = comand

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgUsers.Rows.Clear()
                    While dr.Read()
                        dgUsers.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString, dr(7).ToString, dr(8).ToString)
                    End While
                Else
                    dgUsers.Rows.Clear()
                End If
                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub listLinesService(txtBusq As String, typeBusq As Integer, dgLinesService As DataGridView)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            Dim comand As String

            Select Case typeBusq
                Case 0
                    'Buscar por nombres
                    comand = "SELECT internal_line.idinternalline, service_line.idserviceline, service_line.code, service_line.name, streets.name, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, user_reg.docid " &
                    "FROM service_line " &
                    "INNER JOIN streets On streets.idstreet = service_line.street " &
                    "INNER JOIN internal_line ON internal_line.serviceline = service_line.idserviceline " &
                    "INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline " &
                    "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg " &
                    "WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT internal_line.idinternalline, service_line.idserviceline, service_line.code, service_line.name, streets.name, CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, user_reg.docid " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                    "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                    "FROM service_line SERVLINE " &
                    "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street"
            End Select

            cmd.CommandText = comand

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgLinesService.Rows.Clear()
                    While dr.Read()
                        dgLinesService.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString)
                    End While
                Else
                    dgLinesService.Rows.Clear()
                End If

                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Sub listAccounts(txtBusq As String, typeBusq As Integer, dgAccounts As DataGridView)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
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
                    "CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, " &
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
                    "CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                    "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                    "FROM service_line SERVLINE " &
                    "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street"
            End Select

            cmd.CommandText = comand

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgAccounts.Rows.Clear()
                    While dr.Read()
                        dgAccounts.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString)
                    End While
                Else
                    dgAccounts.Rows.Clear()
                End If

                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgAccounts.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listAccountLine(vIdServiceLine As String, dgAccountLine As DataGridView)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT 
            INTERLINE.idinternalline, 
            rates.idrate, 
            INTERLINE.code, 
            (SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.surnames, "" "", user_reg.names) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE users_line.internalline = INTERLINE.idinternalline) AS fullname, 
            rates.name 
            FROM internal_line INTERLINE 
            INNER JOIN rates ON INTERLINE.rate = rates.idrate 
            INNER JOIN service_line ON service_line.idserviceline = INTERLINE.serviceline 
            WHERE service_line.idserviceline = @idserviceline"
            cmd.Parameters.AddWithValue("idserviceline", vIdServiceLine)

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgAccountLine.Rows.Clear()
                    While dr.Read()
                        dgAccountLine.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString)
                    End While
                Else
                    dgAccountLine.Rows.Clear()
                End If
                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgAccountLine.Rows.Clear()
            End Try
        End If
    End Sub

    Public Sub listUserAccount(vIdLine As String, vIdInterline As String, dgUserAccount As DataGridView)
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cnnx.Close()
            cnnx.Open()
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT
            internal_line.idinternalline,
            internal_line.serviceline,
            user_reg.iduserreg,
            CONCAT(user_reg.surnames, "" "", user_reg.names) AS fullname,
            user_reg.docid,
            user_type.name 
            FROM internal_line
            INNER JOIN users_line ON internal_line.idinternalline = users_line.internalline
            INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg
            INNER JOIN user_type ON user_type.idusertype = user_reg.usertype
            WHERE internal_line.serviceline = @idserviceline AND internal_line.idinternalline = @idinternalline"
            cmd.Parameters.AddWithValue("idserviceline", vIdLine)
            cmd.Parameters.AddWithValue("idinternalline", vIdInterline)

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgUserAccount.Rows.Clear()
                    While dr.Read()
                        dgUserAccount.Rows.Add(dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString)
                    End While
                Else
                    dgUserAccount.Rows.Clear()
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                dgUserAccount.Rows.Clear()
            End Try
        End If
    End Sub

    Public Function getPriceRate(idRate As String) As String()
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT price, description, variable FROM rates WHERE idrate LIKE '" & idRate & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim dataPrice(2) As String
                    dataPrice(0) = dr(0).ToString
                    dataPrice(1) = dr(1).ToString
                    dataPrice(2) = dr(2).ToString

                    cmd.Dispose()
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
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT code, name FROM streets WHERE idstreet LIKE '" & idAvenue & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim dataAvenue(1) As String
                    dataAvenue(0) = dr(0).ToString
                    dataAvenue(1) = dr(1).ToString

                    cmd.Dispose()
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
                Dim vResult As Boolean
                Do
                    codeLine = generateCodeLine(vIdSector)
                    If codeLine = Nothing Then
                        Return Nothing
                    End If
                    Dim dr As MySqlDataReader
                    cmd.Connection = cnnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT code FROM service_line WHERE code LIKE '" & codeLine & "'"
                    dr = cmd.ExecuteReader()
                    vResult = dr.HasRows

                    cmd.Dispose()
                Loop While vResult

                Return codeLine
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Sub addUserToLine(vIdInternalLine As String, dataUser() As String, vIdRate As Integer, Optional vPriceRate As Double = 0)
        Dim cmdInsertLineUser As New MySqlCommand
        Dim cmdFindLineUser As New MySqlCommand
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            If vIdInternalLine.Length > 0 And vIdInternalLine <> "" Or vIdRate <> 0 Then
                cmdFindLineUser.Connection = cnnx
                cmdFindLineUser.CommandType = CommandType.Text

                cmdFindLineUser.CommandText = "SELECT * FROM users_line WHERE users_line.internalline = @idinternalline AND users_line.userreg = @iduserreg"
                cmdFindLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                cmdFindLineUser.Parameters.AddWithValue("iduserreg", dataUser(0))

                Try
                    dr = cmdFindLineUser.ExecuteReader()

                    If Not (dr.HasRows) Then
                        dr.Close()
                        cmdInsertLineUser.Connection = cnnx
                        cmdInsertLineUser.CommandType = CommandType.Text

                        cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline,@iduserreg)"
                        cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdInsertLineUser.Parameters.AddWithValue("iduserreg", dataUser(0))

                        dr = cmdInsertLineUser.ExecuteReader()
                        dr.Close()

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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            Try
                cmdFindUser.Connection = cnnx
                cmdFindUser.CommandType = CommandType.Text
                cmdFindUser.CommandText = "SELECT user_reg.docid FROM user_reg WHERE user_reg.docid LIKE @docid"
                cmdFindUser.Parameters.AddWithValue("docid", dataUser(4))
                dr = cmdFindUser.ExecuteReader
                Dim vDuplicateDoc As Boolean = dr.HasRows
                dr.Close()

                If vDuplicateDoc Then
                    MsgBox("El numero de documento ya esta en uso.", vbExclamation, "Aviso")
                    Exit Sub
                End If

                cmdInsertUser.Connection = cnnx
                cmdInsertUser.CommandType = CommandType.Text
                cmdInsertUser.CommandText = "INSERT INTO user_reg(names, surnames, usertype, docid, address, cellphone, telephone) VALUES(@names, @surnames, @usertype, @docid, @address, @cellphone, @telephone)"
                'cmdInsertUser.Parameters.AddWithValue("iduserreg", codUser)
                cmdInsertUser.Parameters.AddWithValue("names", dataUser(1))
                cmdInsertUser.Parameters.AddWithValue("surnames", dataUser(2))
                cmdInsertUser.Parameters.AddWithValue("usertype", dataUser(3))
                cmdInsertUser.Parameters.AddWithValue("docid", dataUser(4))
                cmdInsertUser.Parameters.AddWithValue("address", dataUser(5))
                cmdInsertUser.Parameters.AddWithValue("cellphone", dataUser(6))
                cmdInsertUser.Parameters.AddWithValue("telephone", dataUser(7))

                dr = cmdInsertUser.ExecuteReader()
                dr.Close()

                If vLineToUser = True And Not IsNothing(vIdInternalLine) Then
                    cmdInsertLineUser.Connection = cnnx
                    cmdInsertLineUser.CommandType = CommandType.Text
                    cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline, (SELECT MAX(user_reg.iduserreg) AS id FROM user_reg))"
                    cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdInsertLineUser.ExecuteNonQuery()
                End If

                cmdInsertUser.Dispose()
                cmdInsertLineUser.Dispose()

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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            Try
                If dataUser(3).Trim <> "" And (dataUser(7).Trim = "" Or dataUser(7) = Nothing) Then
                    cmdFindUser.Connection = cnnx
                    cmdFindUser.CommandType = CommandType.Text
                    cmdFindUser.CommandText = "SELECT * FROM user_reg WHERE user_reg.docid LIKE @docid"
                    cmdFindUser.Parameters.AddWithValue("docid", dataUser(3))
                    dr = cmdFindUser.ExecuteReader
                    vFindUser = dr.HasRows

                    If vFindUser Then
                        MsgBox("El numero de documento ya esta en uso.", vbExclamation, "Aviso")
                        Return False
                    End If
                    dr.Close()
                End If

                cmdFindLine.Connection = cnnx
                cmdFindLine.CommandType = CommandType.Text
                cmdFindLine.CommandText = "SELECT * FROM service_line WHERE service_line.code LIKE @codeserviceline"
                cmdFindLine.Parameters.AddWithValue("codeserviceline", dataLine(0))
                dr = cmdFindLine.ExecuteReader
                vFindLine = dr.HasRows

                If vFindLine Then
                    MsgBox("El codigo de linea ya esta en uso.", vbExclamation, "Aviso")
                    Return False
                End If
                dr.Close()

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

                    'Dim codAccount As String = ""
                    'codAccount = "C" & dr(0).ToString.PadLeft(6, "0")

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

                    dr.Close()
                    cmdFindUser.Dispose()
                    cmdInsertLine.Dispose()
                    cmdInsertUser.Dispose()
                    cmdInsertLineAccount.Dispose()
                    cmdLastInsertLineUser.Dispose()
                    cmdUpdateCodeLineAccount.Dispose()
                    cmdInsertAccountUser.Dispose()

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
        Dim dr As MySqlDataReader

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
                dr = cmdIdInternalLine.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim IdInternalLine As String = dr(0).ToString
                    MsgBox("La nueva cuenta de la linea: " & dr(1).ToString & " se registro correctamente.")

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

    Public Sub updateLine(dataLine() As String)
        Dim cmdUpdateLine As New MySqlCommand

        If Not (cnnx.DataSource.Equals("")) Then
            cmdUpdateLine.Connection = cnnx
            cmdUpdateLine.CommandType = CommandType.Text

            If Not (dataLine(0) = Nothing) Then
                cmdUpdateLine.CommandText = "UPDATE service_line SET name = @name, street = @street, ADDRESS = @address, installdate = @installdate, description = @description " &
                    "WHERE service_line.idserviceline = @idserviceline"
                cmdUpdateLine.Parameters.AddWithValue("name", dataLine(2))
                cmdUpdateLine.Parameters.AddWithValue("street", dataLine(3))
                cmdUpdateLine.Parameters.AddWithValue("address", dataLine(4))
                cmdUpdateLine.Parameters.AddWithValue("installdate", Format(CDate(dataLine(5)), "yyyy-MM-dd"))
                cmdUpdateLine.Parameters.AddWithValue("description", dataLine(6))
                cmdUpdateLine.Parameters.AddWithValue("idserviceline", dataLine(0))

                Try
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
                cmdUpdateLine.CommandText = "UPDATE user_reg SET names = @names, surnames = @surnamesuser, usertype = @usertype, docid = @docid, address = @address, cellphone = @cellphone, telephone = @telephone " &
                    "WHERE user_reg.iduserreg = @iduserreg"

                cmdUpdateLine.Parameters.AddWithValue("names", dataUser(1))
                cmdUpdateLine.Parameters.AddWithValue("surnames", dataUser(2))
                cmdUpdateLine.Parameters.AddWithValue("usertype", dataUser(3))
                cmdUpdateLine.Parameters.AddWithValue("docid", dataUser(4))
                cmdUpdateLine.Parameters.AddWithValue("address", dataUser(5))
                cmdUpdateLine.Parameters.AddWithValue("cellphone", dataUser(6))
                cmdUpdateLine.Parameters.AddWithValue("telephone", dataUser(7))
                cmdUpdateLine.Parameters.AddWithValue("iduserreg", dataUser(0))

                If (dataUser(12) <> Nothing) Then
                    cmdUpdateUserToLine.Connection = cnnx
                    cmdUpdateUserToLine.CommandType = CommandType.Text
                    cmdUpdateUserToLine.CommandText = "UPDATE users_line SET internalline = @idinternalline, userreg = @iduserreg"
                    cmdUpdateUserToLine.Parameters.AddWithValue("iduserreg", dataUser(0))
                    cmdUpdateUserToLine.Parameters.AddWithValue("idinternalline", dataUser(12))

                    cmdUpdateUserToLine.ExecuteNonQuery()
                    cmdUpdateUserToLine.Dispose()
                End If

                Try
                    cmdUpdateLine.ExecuteNonQuery()
                    cmdUpdateLine.Dispose()

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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            cnnx.Close()
            cnnx.Open()

            If Not (vIdInternalLine = Nothing) Then
                Try
                    cmdFindAccounts.Connection = cnnx
                    cmdFindAccounts.CommandType = CommandType.Text
                    cmdFindAccounts.CommandText = "SELECT * FROM account_line WHERE account_line.internalline = @idinternalline"
                    cmdFindAccounts.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    dr = cmdFindAccounts.ExecuteReader()
                    Dim vFindAccounts As Boolean = dr.HasRows
                    dr.Close()

                    If vFindAccounts = False Then
                        cmdDeleteUserInternal.Connection = cnnx
                        cmdDeleteUserInternal.CommandType = CommandType.Text
                        cmdDeleteUserInternal.CommandText = "DELETE FROM users_line WHERE users_line.internalline = @idinternalline"
                        cmdDeleteUserInternal.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdDeleteUserInternal.ExecuteNonQuery()
                        cmdDeleteUserInternal.Dispose()

                        cmdDeleteInternal.Connection = cnnx
                        cmdDeleteInternal.CommandType = CommandType.Text
                        cmdDeleteInternal.CommandText = "DELETE FROM internal_line " &
                            "WHERE internal_line.serviceline = @idserviceline AND internal_line.idinternalline = @idinternalline"
                        cmdDeleteInternal.Parameters.AddWithValue("idserviceline", vIdServiceLine)
                        cmdDeleteInternal.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdDeleteInternal.ExecuteNonQuery()
                        cmdDeleteInternal.Dispose()

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

        If Not (cnnx.DataSource.Equals("")) Then
            cnnx.Close()
            cnnx.Open()

            If Not (vIdInternalLine = Nothing Or vIdUserReg = Nothing) Then
                Try
                    cmdDeleteUser.Connection = cnnx
                    cmdDeleteUser.CommandType = CommandType.Text
                    cmdDeleteUser.CommandText = "DELETE FROM users_line WHERE users_line.internalline = @idinternalline AND users_line.userreg = @iduserreg"
                    cmdDeleteUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                    cmdDeleteUser.Parameters.AddWithValue("iduserreg", vIdUserReg)

                    cmdDeleteUser.ExecuteNonQuery()
                    cmdDeleteUser.Dispose()

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

    Public Sub showFindUsers(frmMdiParent As Form, vFrmGet As Integer, vFrmIn As Form)
        Dim frm As New frmFindUsers
        frm.MdiParent = frmMdiParent
        frm.vFrmGet = vFrmGet
        frm.vFrmIn = vFrmIn

        If IsNothing(frmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.Show()
        End If
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

    Public Sub showAccountCollect(vIdServiceLine As String, vIdInternalLine As String, vNameLine As String)
        Dim frm As New frmCollectDetail
        frm.vIdServiceLine = vIdServiceLine
        frm.vIdInternalLine = vIdInternalLine
        frm.vNameLine = vNameLine
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

    Public Sub showNewUser(vIdUserReg As String, vIdInternalLine As String, vFrmGet As Integer)
        Dim frm As New frmNewuser
        frm.vIdUserReg = vIdUserReg
        frm.vFrmGet = vFrmGet
        frm.vIdInternalLine = vIdInternalLine
        frm.ShowDialog()
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
        Dim dr As MySqlDataReader
        Dim dataStr(1) As String
        dataStr(0) = ""
        dataStr(1) = ""

        If Not cnnx.DataSource.Equals("") Then
            cnnx.Close()
            cnnx.Open()
            cmdGetLastReceipt.Connection = cnnx
            cmdGetLastReceipt.CommandType = CommandType.Text

            cmdGetLastReceipt.CommandText = "SELECT MAX(payments.idpayment) AS id FROM payments"

            Try
                dr = cmdGetLastReceipt.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    dataStr(0) = Val(dr(0).ToString) + 1
                    dataStr(1) = dataStr(0).PadLeft(7, "0")
                Else
                    dataStr(0) = "1"
                    dataStr(1) = dataStr(0).PadLeft(7, "0")
                End If
                dr.Close()

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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then

            If Not (vIdServiceLine = Nothing And vIdInternalLine = Nothing) Then
                cnnx.Close()
                cnnx.Open()
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

                Try
                    dr = cmdGetAccountCollect.ExecuteReader()

                    If dr.HasRows Then
                        dgAccountYear.Rows.Clear()
                        While dr.Read()
                            Dim vState As String
                            If CDec(dr(3).ToString) > 0 Then
                                vState = "Saldo Pendiente"
                            Else
                                vState = "Cancelado"
                            End If
                            dgAccountYear.Rows.Add(dr(0).ToString, CInt(dr(1).ToString), Format(CDec(dr(2).ToString), "###,##0.00"), Format(CDec(dr(2).ToString) - CDec(dr(3).ToString), "###,##0.00"), Format(CDec(dr(3).ToString), "###,##0.00"), vState)
                        End While
                    Else
                        MsgBox("No hay cuentas por año que mostrar", vbCritical, "Aviso")
                    End If
                    dr.Close()
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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            If Not (vIdAccountLine = Nothing) Then
                cnnx.Close()
                cnnx.Open()
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

                Try
                    dr = cmdGetAccountCollectCharge.ExecuteReader()

                    If dr.HasRows Then
                        dgAccountCharge.Rows.Clear()
                        While dr.Read
                            Dim vNameMonth As String
                            If CInt(dr(4).ToString) = 0 Then
                                vNameMonth = ""
                            Else
                                vNameMonth = UCase(MonthName(dr(4).ToString))
                            End If
                            Dim vCharge As Boolean = dr(6).ToString
                            Dim vNameCharge As String

                            If vCharge Then
                                vNameCharge = dr(5).ToString & " " & vNameMonth & " " & dr(10).ToString
                            Else
                                vNameCharge = dr(5).ToString
                            End If

                            dgAccountCharge.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, False, vNameCharge, Format(CDec(dr(7).ToString), "###,##0.00"), Format(CDec(dr(8).ToString), "###,##0.00"), Format(CDec(dr(9).ToString), "###,##0.00"))
                        End While
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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            If Not (vIdInternalLine = Nothing) Then
                cnnx.Close()
                cnnx.Open()
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

                Try
                    dr = cmdGetAccountReceipts.ExecuteReader()
                    dgHistory.Rows.Clear()
                    If dr.HasRows Then
                        While dr.Read
                            dgHistory.Rows.Add(dr(0).ToString, dr(2).ToString, dr(3).ToString, dr(1).ToString, Format(CDec(dr(5).ToString), "###,##0.00"), dr(6).ToString, dr(7).ToString, dr(8).ToString)
                        End While
                    Else
                        MsgBox("No hay pagos que mostrar", vbCritical, "Aviso")
                    End If
                    dr.Close()
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
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
            If Not (vIdPayment = Nothing) Then
                cnnx.Close()
                cnnx.Open()
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

                Try
                    dr = cmdGetReceiptDetail.ExecuteReader()

                    dgDetail.Rows.Clear()
                    If dr.HasRows Then
                        While dr.Read
                            Dim vNameMonth As String
                            If CInt(dr(4).ToString) = 0 Then
                                vNameMonth = ""
                            Else
                                vNameMonth = UCase(MonthName(dr(4).ToString))
                            End If
                            Dim vCharge As Boolean = dr(6).ToString
                            Dim vNameCharge As String

                            If vCharge Then
                                vNameCharge = dr(5).ToString & " " & vNameMonth & " " & dr(3).ToString
                            Else
                                vNameCharge = dr(5).ToString
                            End If

                            dgDetail.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, vNameCharge, Format(CDec(dr(7).ToString), "###,##0.00"))
                        End While
                    Else
                        MsgBox("No hay pagos que mostrar", vbCritical, "Aviso")
                    End If
                    dr.Close()
                Catch ex As Exception
                    dgDetail.Rows.Clear()
                    MsgBox("Ocurrio un error en la consulta", vbCritical, "Aviso")
                End Try
            Else
                MsgBox("No se envio el identificador del recibo", vbCritical, "Aviso")
            End If
        End If
    End Sub

    Public Function cancelReceipt(dgDetail As DataGridView, vIdPayment As String, vNumReceipt As String, vDatePay As Date) As Boolean
        Dim cmdUpdateReceipt As New MySqlCommand
        Dim cmdUpdateAccountLine As New MySqlCommand

        If Not (cnnx.DataSource.Equals("")) Then
            If DateDiff(DateInterval.Day, CDate(Format(vDatePay, "dd/MM/yyyy")), Today) <= 7 Then
                If MsgBox("¿Desea anular el recibo N°" & vNumReceipt & "?", MsgBoxStyle.YesNo + vbExclamation, "Aviso") = MsgBoxResult.Yes Then
                    If Not (vIdPayment = Nothing And dgDetail.Rows.Count > 0) Then
                        Dim vIdAccountLine As String = dgDetail.Item(1, 0).Value
                        Try
                            cnnx.Close()
                            cnnx.Open()
                            cmdUpdateReceipt.Connection = cnnx
                            cmdUpdateReceipt.CommandType = CommandType.Text
                            cmdUpdateReceipt.CommandText = "UPDATE payments SET payments.canceled = 1 WHERE payments.idpayment = @idpayment"
                            cmdUpdateReceipt.Parameters.AddWithValue("idpayment", vIdPayment)
                            cmdUpdateReceipt.ExecuteNonQuery()
                            cmdUpdateReceipt.Dispose()

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
                                cmdUpdateAccountDetail.Dispose()
                            Next

                            cmdUpdateAccountLine.Connection = cnnx
                            cmdUpdateAccountLine.CommandType = CommandType.Text
                            cmdUpdateAccountLine.CommandText = "UPDATE 
                            account_line 
                            SET account_line.saldototal = (SELECT SUM(account_detail.saldototal) AS saldototal FROM account_detail WHERE account_detail.accountline = @idaccountline) 
                            WHERE account_line.idaccountline = @idaccountline"
                            cmdUpdateAccountLine.Parameters.AddWithValue("idaccountline", vIdAccountLine)
                            cmdUpdateAccountLine.ExecuteNonQuery()
                            cmdUpdateAccountLine.Dispose()

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

    Public Function payAccount(dgAccount As DataGridView, amountPay As Decimal, Optional vIdInternalLine As String = Nothing, Optional vIdPay As Integer = Nothing, Optional vCodNumReceipt As String = Nothing, Optional vNamePayer As String = Nothing) As String()
        Dim rateYear As Integer = 0
        Dim idAcccount As String = Nothing
        Dim dataConceptReceipt(12) As String
        Dim indexConcept As Integer = 0
        Dim amountPayTotal As Decimal
        Dim dgAccountCopy As DataGridView = dgAccount

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
                cnnx.Close()
                cnnx.Open()
                insertPaymentDetail.Connection = cnnx
                insertPaymentDetail.CommandType = CommandType.Text
                insertPaymentDetail.CommandText = "INSERT INTO payment_detail(payment, accountline, accountdetail, payamount) VALUES(@idpay, @internalline, @accountdetail, @payamount)"
                insertPaymentDetail.Parameters.AddWithValue("idpay", vIdPaymnent)
                insertPaymentDetail.Parameters.AddWithValue("internalline", vIdAccountLine)
                insertPaymentDetail.Parameters.AddWithValue("accountdetail", idDetailAccount)
                insertPaymentDetail.Parameters.AddWithValue("payamount", amountPay)

                insertPaymentDetail.ExecuteNonQuery()
                insertPaymentDetail.Dispose()
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
                cnnx.Close()
                cnnx.Open()
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
                insertPaymentDetail.Dispose()
            Else
                MsgBox("Faltan datos para registrar el pago", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub getAccountYearUpdated(yearRate As Integer, vIdInternalLine As String, vIdAccount As String)
        Dim cmdGetAccountYearDetail, cmdUpdateAccountYear As New MySqlCommand
        Dim dr As MySqlDataReader

        If Not cnnx.DataSource.Equals("") Then

            If Not (vIdInternalLine = Nothing And vIdAccount = Nothing) Then
                cnnx.Close()
                cnnx.Open()
                cmdGetAccountYearDetail.Connection = cnnx
                cmdGetAccountYearDetail.CommandType = CommandType.Text
                cmdGetAccountYearDetail.CommandText = "SELECT DISTINCTROW 
                SUM(account_detail.saldototal) AS total 
                FROM account_detail WHERE account_detail.yearrate = @yearrate AND account_detail.accountline = @idaccountline"
                cmdGetAccountYearDetail.Parameters.AddWithValue("yearrate", yearRate)
                cmdGetAccountYearDetail.Parameters.AddWithValue("idaccountline", vIdAccount)

                Try
                    dr = cmdGetAccountYearDetail.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        Dim saldoTotalYear As Decimal = 0
                        saldoTotalYear = Val(dr(0).ToString)
                        dr.Close()

                        cmdUpdateAccountYear.Connection = cnnx
                        cmdUpdateAccountYear.CommandType = CommandType.Text
                        cmdUpdateAccountYear.CommandText = "UPDATE account_line SET account_line.saldototal = @accountsaldo 
                        WHERE account_line.idaccountline = @idaccountline AND account_line.yearrate = @yearrate"
                        cmdUpdateAccountYear.Parameters.AddWithValue("accountsaldo", saldoTotalYear)
                        cmdUpdateAccountYear.Parameters.AddWithValue("idaccountline", vIdAccount)
                        cmdUpdateAccountYear.Parameters.AddWithValue("yearrate", yearRate)

                        cmdUpdateAccountYear.ExecuteNonQuery()
                        cmdUpdateAccountYear.Dispose()
                        cmdGetAccountYearDetail.Dispose()
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
                cnnx.Close()
                cnnx.Open()
                cmdUpdateAccountDetail.Connection = cnnx
                cmdUpdateAccountDetail.CommandType = CommandType.Text
                cmdUpdateAccountDetail.CommandText = "UPDATE account_detail SET account_detail.saldototal = @amountsaldo 
                WHERE account_detail.idaccountdetail = @idaccountdetail"
                cmdUpdateAccountDetail.Parameters.AddWithValue("amountsaldo", CDec(amountSaldo - amountPay))
                cmdUpdateAccountDetail.Parameters.AddWithValue("idaccountdetail", idAccountDetail)

                Try
                    cmdUpdateAccountDetail.ExecuteNonQuery()
                    cmdUpdateAccountDetail.Dispose()

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
        Dim dr As MySqlDataReader

        If Not cnnx.DataSource.Equals("") Then
            If Not (vIdServiceLine = Nothing And vIdInternalLine = Nothing) Then
                cnnx.Close()
                cnnx.Open()
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

                Try
                    dr = cmdGetAccount.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()

                        Dim dataAccount(7) As String
                        dataAccount(0) = dr(0).ToString 'Id de internalline
                        dataAccount(1) = dr(1).ToString 'Id de serviceline
                        dataAccount(2) = dr(2).ToString 'Code de internalline
                        dataAccount(3) = dr(3).ToString 'Code de serviceline
                        dataAccount(4) = dr(4).ToString 'Id de rate
                        dataAccount(5) = dr(5).ToString 'Precio rate
                        dataAccount(6) = Format(dr(6).ToString, "Short Date")
                        dataAccount(7) = Format(dr(7).ToString, "Short Date")

                        cmdGetAccount.Dispose()
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

    Public Function getLine(vIdServiceLine As String) As String()
        Dim cmd As New MySqlCommand
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cnnx.Close()
            cnnx.Open()
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

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    Dim dataLine(10) As String
                    dataLine(0) = dr(0).ToString 'Id de linea
                    dataLine(1) = dr(1).ToString 'Codigo de linea
                    dataLine(2) = dr(2).ToString 'Nombre de linea
                    dataLine(3) = dr(3).ToString 'Id de sector
                    dataLine(4) = dr(4).ToString 'Codigo de sector
                    dataLine(5) = dr(5).ToString 'Nombre del sector
                    dataLine(6) = dr(6).ToString 'Direccion de la linea
                    dataLine(7) = dr(7).ToString 'Fecha de instalacion
                    dataLine(8) = dr(8).ToString 'Descripcion de linea
                    dataLine(9) = dr(9).ToString 'Fecha de registro
                    dataLine(10) = dr(10).ToString 'Fecha de actualizacion

                    dr.Close()
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
        Dim dr As MySqlDataReader

        If cnnx.DataSource.Equals("") Or IsNothing(vIdUserReg) Then
            Return Nothing
        Else
            cnnx.Close()
            cnnx.Open()
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

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()

                    Dim dataUser(10) As String
                    dataUser(0) = dr(0).ToString 'Codigo de usuario
                    dataUser(1) = dr(1).ToString 'Nombres
                    dataUser(2) = dr(2).ToString 'Apellidos
                    dataUser(3) = dr(3).ToString 'Tipo de usuario
                    dataUser(4) = dr(4).ToString 'Nombre de tipo de usuario
                    dataUser(5) = dr(5).ToString 'Numero de documento
                    dataUser(6) = dr(6).ToString 'Direccion
                    dataUser(7) = dr(7).ToString 'Celular
                    dataUser(8) = dr(8).ToString 'Telefono
                    dataUser(9) = dr(9).ToString 'Fecha creado
                    dataUser(10) = dr(10).ToString 'Fecha actualizado

                    cmd.Dispose()
                    Return dataUser
                Else
                    Return Nothing
                End If

                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
                Return Nothing
            End Try
        End If
    End Function
End Module
