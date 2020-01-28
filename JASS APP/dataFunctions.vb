﻿Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Module dataFunctions
    Public cnn As New OleDbConnection(My.Settings.dbJASSConnectionString)
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

            cmd.CommandText = "SELECT name, loguser, passuser FROM user_sys WHERE loguser = '" & nameusr & "' AND passuser = '" & passwd & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        My.Settings.vUserNameLogin = dr(0).ToString
                        MsgBox("Bienvenid@ " + dr(0).ToString, vbInformation, "Aviso")
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
        Dim cmd As New MySqlCommand

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT idrate, name FROM rates"

            Try
                Dim ada As New MySqlDataAdapter(cmd)

                ada.Fill(ds)
                ada.Dispose()
                cmd.Dispose()

                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function listAvenues() As DataSet
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT idstreet, name FROM streets ORDER BY name"

            Try
                Dim ada As New MySqlDataAdapter(cmd)

                ada.Fill(ds)
                ada.Dispose()
                cmd.Dispose()

                Return ds
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function listUserTypes() As DataSet
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand

        If cnnx.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT idusertype, name FROM user_type"

            Try
                Dim ada As New MySqlDataAdapter(cmd)

                ada.Fill(ds)
                ada.Dispose()
                cmd.Dispose()

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
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT users_line.internalline, CONCAT(user_reg.names, "" "", user_reg.surnames) AS fullname " &
            "FROM users_line INNER JOIN user_reg ON users_line.userreg = user_reg.iduserreg WHERE users_line.internalline = @idinternalline"
            cmd.Parameters.AddWithValue("idinternalline", vIdInternalLine)

            Try
                Dim ada As New MySqlDataAdapter(cmd)

                ada.Fill(ds)
                ada.Dispose()
                cmd.Dispose()

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
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.names, "" "", user_reg.surnames) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.name, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.names, "" "", user_reg.surnames) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.name, user_reg.address, user_reg.cellphone, user_reg.telephone
                    FROM user_reg INNER JOIN user_type ON user_type.idusertype = user_reg.usertype 
                    WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                Case Else
                    'Buscar a todos
                    comand = "SELECT user_reg.iduserreg, CONCAT(user_reg.names, "" "", user_reg.surnames) AS fullname, user_reg.docid,
                    user_reg.names, user_reg.surnames, user_type.name, user_reg.address, user_reg.cellphone, user_reg.telephone
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
                    comand = "SELECT internal_line.idinternalline, service_line.code, service_line.name, streets.name, CONCAT(user_reg.names & "" "" & user_reg.surnames) AS fullname, user_reg.docid " &
                    "FROM service_line " &
                    "INNER JOIN streets On streets.idstreet = service_line.street " &
                    "INNER JOIN internal_line ON internal_line.serviceline = service_line.idserviceline " &
                    "INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline " &
                    "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg " &
                    "WHERE user_reg.names LIKE '%" & txtBusq & "%' OR user_reg.surnames LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT internal_line.idinternalline, service_line.code, service_line.name, streets.name, CONCAT(user_reg.names & "" "" & user_reg.surnames) AS fullname, user_reg.docid " &
                    "FROM service_line " &
                    "INNER JOIN streets On streets.idstreet = service_line.street " &
                    "INNER JOIN internal_line ON internal_line.serviceline = service_line.idserviceline " &
                    "INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline " &
                    "INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg " &
                    "WHERE user_reg.docid LIKE '%" & txtBusq & "%'"
                Case 2
                    'Buscar por codigo de linea
                    comand = "SELECT " &
                    "(SELECT "" "") AS idinternalline, " &
                    "SERVLINE.code, " &
                    "SERVLINE.name, " &
                    "SECTOR.name, " &
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                    "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                    "FROM service_line SERVLINE " &
                    "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street " &
                    "WHERE SERVLINE.code LIKE '%" & txtBusq & "%'"
                Case 3
                    'Buscar por nombre de linea
                    comand = "SELECT " &
                    "(SELECT "" "") AS idinternalline, " &
                    "SERVLINE.code, " &
                    "SERVLINE.name, " &
                    "SECTOR.name, " &
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
                    "(SELECT GROUP_CONCAT(DISTINCT user_reg.docid SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS docids " &
                    "FROM service_line SERVLINE " &
                    "INNER JOIN streets SECTOR ON SECTOR.idstreet = SERVLINE.street " &
                    "WHERE SERVLINE.name LIKE '%" & txtBusq & "%'"
                Case Else
                    'Buscar a todos
                    comand = "SELECT " &
                    "(SELECT "" "") AS idinternalline, " &
                    "SERVLINE.code, " &
                    "SERVLINE.name, " &
                    "SECTOR.name, " &
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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
                        dgLinesService.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString)
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
                    "CONCAT(user_reg.names, "" "",user_reg.surnames) AS fullname, " &
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
                    "CONCAT(user_reg.names, "" "",user_reg.surnames) AS fullname, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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
                    "(SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE internal_line.serviceline = SERVLINE.idserviceline) AS fullnames, " &
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

    Public Sub listAccountLine(vIdLine As String, dgAccountLine As DataGridView)
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
            service_line.code, 
            (SELECT GROUP_CONCAT(DISTINCT CONCAT(user_reg.names, "" "", user_reg.surnames) SEPARATOR "", "") FROM internal_line INNER JOIN users_line ON users_line.internalline = internal_line.idinternalline INNER JOIN user_reg ON user_reg.iduserreg = users_line.userreg WHERE users_line.internalline = INTERLINE.idinternalline) AS fullname, 
            rates.name 
            FROM internal_line INTERLINE 
            INNER JOIN rates ON internal_line.rate = rates.idrate 
            INNER JOIN service_line ON service_line.idserviceline = internal_line.serviceline 
            WHERE service_line.idserviceline = @idserviceline"
            cmd.Parameters.AddWithValue("idserviceline", vIdLine)

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
            cmd.Connection = cnnx
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT
            internal_line.idinternalline,
            internal_line.serviceline,
            user_reg.iduserreg,
            CONCAT(user_reg.names, "" "", user_reg.surnames) AS fullname,
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
                cmd.Dispose()
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
                    dr.Close()
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
                    dr.Close()
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
                    dr.Close()
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
                        cmdInsertLineUser.Connection = cnnx
                        cmdInsertLineUser.CommandType = CommandType.Text

                        cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline,@iduserreg)"
                        cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)
                        cmdInsertLineUser.Parameters.AddWithValue("iduserreg", dataUser(0))

                        Try
                            dr = cmdInsertLineUser.ExecuteReader()
                            dr.Close()
                            cmdInsertLineUser.Dispose()

                            MsgBox("El usuario se agrego exitosamente", vbInformation, "Aviso")
                        Catch ex As Exception
                            MsgBox("Ocurrio un error al guardar el registro", vbExclamation, "Aviso")
                            MsgBox(ex.Message)
                        End Try
                    Else
                        MsgBox("El usuario ya esta enlazado a la linea de servicio", vbInformation, "Aviso")
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
        'Dim codUser As String = generateCode(15, True, True, True)

        Dim cmdInsertUser As New MySqlCommand
        Dim cmdInsertLineUser As New MySqlCommand
        Dim cmdLastInsertLineUser As New MySqlCommand
        Dim cmdUpdateCodeLineUser As New MySqlCommand
        Dim dr As MySqlDataReader

        If Not (cnnx.DataSource.Equals("")) Then
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

            Try
                dr = cmdInsertUser.ExecuteReader()

                If vLineToUser = True And Not IsNothing(vIdInternalLine) Then
                    cmdInsertLineUser.Connection = cnnx
                    cmdInsertLineUser.CommandType = CommandType.Text
                    cmdInsertLineUser.CommandText = "INSERT INTO users_line(internalline, userreg) VALUES(@idinternalline, (SELECT MAX(user_reg.iduserreg) AS id FROM user_reg))"
                    cmdInsertLineUser.Parameters.AddWithValue("idinternalline", vIdInternalLine)

                    cmdInsertLineUser.ExecuteNonQuery()
                End If

                dr.Close()
                cmdInsertUser.Dispose()
                cmdInsertLineUser.Dispose()
                cmdLastInsertLineUser.Dispose()
                cmdUpdateCodeLineUser.Dispose()

                MsgBox("El usuario se guardo exitosamente", vbInformation, "Aviso")
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub saveLineNew(dataLine() As String, dataUser() As String, Optional vPriceRate As Double = 0)
        Dim codUser As String = generateCode(15, True, True, True)
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
                    cmdFindUser.CommandText = "SELECT * FROM user_lines WHERE user_lines.USER_DOCID LIKE @dociduser"
                    cmdFindUser.Parameters.AddWithValue("dociduser", dataUser(3))
                    dr = cmdFindUser.ExecuteReader
                    vFindUser = dr.HasRows

                    If vFindUser Then
                        MsgBox("El numero de documento ya esta en uso.", vbExclamation, "Aviso")
                        Exit Sub
                    End If
                End If

                cmdFindLine.Connection = cnnx
                cmdFindLine.CommandType = CommandType.Text
                cmdFindLine.CommandText = "SELECT * FROM lines WHERE lines.COD_LINE LIKE @codline"
                cmdFindLine.Parameters.AddWithValue("codline", dataLine(0))
                dr = cmdFindLine.ExecuteReader
                vFindLine = dr.HasRows

                If vFindLine Then
                    MsgBox("El codigo de linea ya esta en uso.", vbExclamation, "Aviso")
                    Exit Sub
                End If

                If Not vFindUser And Not vFindLine Then
                    'Registrando un nuevo usuario
                    cmdInsertUser.Connection = cnnx
                    cmdInsertUser.CommandType = CommandType.Text

                    cmdInsertUser.CommandText = "INSERT INTO user_lines(COD_USR_LINE, USER_NAMES, USER_SURNAMES, USER_TYPE, USER_DOCID, USER_ADRSS, USER_CEL, USER_TEL) VALUES(@coduserline, @nameuser, @surnameuser, @typeuser, @dociduser, @addressuser, @celluser, @teleuser)"
                    cmdInsertUser.Parameters.AddWithValue("coduserline", codUser)
                    cmdInsertUser.Parameters.AddWithValue("nameuser", dataUser(0))
                    cmdInsertUser.Parameters.AddWithValue("surnameuser", dataUser(1))
                    cmdInsertUser.Parameters.AddWithValue("typeuser", dataUser(2))
                    cmdInsertUser.Parameters.AddWithValue("dociduser", dataUser(3))
                    cmdInsertUser.Parameters.AddWithValue("addressuser", dataUser(4))
                    cmdInsertUser.Parameters.AddWithValue("celluser", dataUser(5))
                    cmdInsertUser.Parameters.AddWithValue("teleuser", dataUser(6))

                    If dataUser(7).Length = 0 And dataUser(7) = "" Then
                        cmdInsertUser.ExecuteNonQuery()
                    End If

                    'Registrando una nueva linea
                    cmdInsertLine.Connection = cnnx
                    cmdInsertLine.CommandType = CommandType.Text

                    If (dataLine(1) = "" Or dataLine(1) = Nothing) Then
                        dataLine(1) = dataLine(0)
                    End If

                    cmdInsertLine.CommandText = "INSERT INTO lines(COD_LINE, NAME_LINE, ID_SECTOR, ADDRESS, INSTALLDATE_LINE, DESCP_LINE) VALUES(@codline, @nameline, @codsector, @address, @installdate, @descpline)"
                    cmdInsertLine.Parameters.AddWithValue("codline", dataLine(0))
                    cmdInsertLine.Parameters.AddWithValue("nameline", dataLine(1))
                    cmdInsertLine.Parameters.AddWithValue("codsector", dataLine(2))
                    cmdInsertLine.Parameters.AddWithValue("address", dataLine(3))
                    cmdInsertLine.Parameters.AddWithValue("installdate", dataLine(5))
                    cmdInsertLine.Parameters.AddWithValue("descpline", dataLine(6))

                    'Registrando una linea-cuenta
                    cmdInsertLineAccount.Connection = cnnx
                    cmdInsertLineAccount.CommandType = CommandType.Text

                    cmdInsertLineAccount.CommandText = "INSERT INTO lines_to_account(COD_ACCOUNT, COD_LINE, ID_RATE, PRICE_RATE) VALUES(@codaccount, @codline, @codrate, @pricerate)"
                    cmdInsertLineAccount.Parameters.AddWithValue("codaccount", "new")
                    cmdInsertLineAccount.Parameters.AddWithValue("codline", dataLine(0))
                    cmdInsertLineAccount.Parameters.AddWithValue("codrate", dataLine(4))
                    cmdInsertLineAccount.Parameters.AddWithValue("pricerate", vPriceRate)

                    cmdInsertLine.ExecuteNonQuery()
                    cmdInsertLineAccount.ExecuteNonQuery()

                    'Buscando y cambiando el codigo de cuenta
                    cmdLastInsertLineUser.Connection = cnnx
                    cmdLastInsertLineUser.CommandType = CommandType.Text

                    cmdLastInsertLineUser.CommandText = "SELECT lines_to_account.ID_ACCOUNT FROM lines_to_account WHERE lines_to_account.COD_LINE LIKE @codline AND lines_to_account.COD_ACCOUNT LIKE @codaccount"
                    cmdLastInsertLineUser.Parameters.AddWithValue("codline", dataLine(0))
                    cmdLastInsertLineUser.Parameters.AddWithValue("codaccount", "new")

                    dr = cmdLastInsertLineUser.ExecuteReader()

                    Dim codAccount As String = ""
                    If dr.HasRows Then
                        dr.Read()
                        codAccount = "C" & dr(0).ToString.PadLeft(6, "0")
                        cmdUpdateCodeLineAccount.Connection = cnnx
                        cmdUpdateCodeLineAccount.CommandType = CommandType.Text
                        cmdUpdateCodeLineAccount.CommandText = "UPDATE lines_to_account SET lines_to_account.COD_ACCOUNT = @codaccount WHERE lines_to_account.ID_ACCOUNT LIKE '" & dr(0).ToString & "'"
                        cmdUpdateCodeLineAccount.Parameters.AddWithValue("codaccount", codAccount)
                        cmdUpdateCodeLineAccount.ExecuteNonQuery()
                    End If

                    'Registrando la cuenta-usuario
                    Dim codLineUser As String = ""
                    If dataUser(7).Length = 0 And dataUser(7) = "" Then
                        codLineUser = codUser
                    Else
                        codLineUser = dataUser(7)
                    End If

                    cmdInsertAccountUser.Connection = cnnx
                    cmdInsertAccountUser.CommandType = CommandType.Text

                    cmdInsertAccountUser.CommandText = "INSERT INTO users_to_account(COD_USR_LINE, COD_ACCOUNT) VALUES(@coduserline, @codaccount)"
                    cmdInsertAccountUser.Parameters.AddWithValue("coduserline", codLineUser)
                    cmdInsertAccountUser.Parameters.AddWithValue("codaccount", codAccount)
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
                Else
                    If vFindUser Then
                        MsgBox("El numero de documento ya esta registrado", vbExclamation, "Aviso")
                    End If
                    If vFindLine Then
                        MsgBox("El codigo de linea ya esta en uso", vbExclamation, "Aviso")
                    End If
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Function saveAccountNew(vCodLine As String, vCodRate As Integer, vPriceRate As Decimal) As String
        Dim cmdInsertLineAccount As New OleDbCommand
        Dim cmdLastInsertLineUser As New OleDbCommand
        Dim cmdUpdateCodeLineAccount As New OleDbCommand
        Dim cmdInsertAccountUser As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            Try
                'Registrando una linea-cuenta
                cmdInsertLineAccount.Connection = cnn
                cmdInsertLineAccount.CommandType = CommandType.Text

                cmdInsertLineAccount.CommandText = "INSERT INTO lines_to_account(COD_ACCOUNT, COD_LINE, ID_RATE, PRICE_RATE) VALUES(@codaccount, @codline, @codrate, @pricerate)"
                cmdInsertLineAccount.Parameters.AddWithValue("codaccount", "new")
                cmdInsertLineAccount.Parameters.AddWithValue("codline", vCodLine)
                cmdInsertLineAccount.Parameters.AddWithValue("codrate", vCodRate)
                cmdInsertLineAccount.Parameters.AddWithValue("pricerate", vPriceRate)

                cmdInsertLineAccount.ExecuteNonQuery()

                'Buscando y cambiando el codigo de cuenta
                cmdLastInsertLineUser.Connection = cnn
                cmdLastInsertLineUser.CommandType = CommandType.Text

                cmdLastInsertLineUser.CommandText = "SELECT lines_to_account.ID_ACCOUNT FROM lines_to_account WHERE lines_to_account.COD_LINE LIKE @codline AND lines_to_account.COD_ACCOUNT LIKE @codaccount"
                cmdLastInsertLineUser.Parameters.AddWithValue("codline", vCodLine)
                cmdLastInsertLineUser.Parameters.AddWithValue("codaccount", "new")

                dr = cmdLastInsertLineUser.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim codAccount As String = "C" & dr(0).ToString.PadLeft(6, "0")

                    cmdUpdateCodeLineAccount.Connection = cnn
                    cmdUpdateCodeLineAccount.CommandType = CommandType.Text
                    cmdUpdateCodeLineAccount.CommandText = "UPDATE lines_to_account SET lines_to_account.COD_ACCOUNT = @codaccount WHERE lines_to_account.ID_ACCOUNT LIKE '" & dr(0).ToString & "'"
                    cmdUpdateCodeLineAccount.Parameters.AddWithValue("codaccount", codAccount)
                    cmdUpdateCodeLineAccount.ExecuteNonQuery()

                    MsgBox("La nueva cuenta de la linea: " & vCodLine & " se registro correctamente.")

                    Return codAccount
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

        'Registrando la cuenta-usuario
        'Dim codLineUser As String = ""
        'If dataUser(7).Length = 0 And dataUser(7) = "" Then
        '    codLineUser = codUser
        'Else
        '    codLineUser = dataUser(7)
        'End If

        'cmdInsertAccountUser.Connection = cnn
        'cmdInsertAccountUser.CommandType = CommandType.Text

        'cmdInsertAccountUser.CommandText = "INSERT INTO users_to_account(COD_USR_LINE, COD_ACCOUNT) VALUES(@coduserline, @codaccount)"
        'cmdInsertAccountUser.Parameters.AddWithValue("coduserline", codLineUser)
        'cmdInsertAccountUser.Parameters.AddWithValue("codaccount", codAccount)
        'cmdInsertAccountUser.ExecuteNonQuery()
    End Function

    Public Sub updateLine(dataLine() As String)
        Dim cmdUpdateLine As New OleDbCommand

        If Not (cnn.DataSource.Equals("")) Then
            cmdUpdateLine.Connection = cnn
            cmdUpdateLine.CommandType = CommandType.Text

            If Not (dataLine(0) = Nothing) Then
                cmdUpdateLine.CommandText = "UPDATE lines SET NAME_LINE = @nameline, ID_SECTOR = @idsector, ADDRESS = @address, INSTALLDATE_LINE = @installdateline, DESCP_LINE = @descpline, UPDATE_LINE = @updateline " &
                    "WHERE lines.COD_LINE = @codline"
                cmdUpdateLine.Parameters.AddWithValue("nameline", dataLine(2))
                cmdUpdateLine.Parameters.AddWithValue("idsector", dataLine(3))
                cmdUpdateLine.Parameters.AddWithValue("address", dataLine(4))
                cmdUpdateLine.Parameters.AddWithValue("installdateline", dataLine(5))
                cmdUpdateLine.Parameters.AddWithValue("descpline", dataLine(6))
                cmdUpdateLine.Parameters.AddWithValue("updateline", dataLine(8))
                cmdUpdateLine.Parameters.AddWithValue("codline", dataLine(1))

                Try
                    cmdUpdateLine.ExecuteNonQuery()
                    cmdUpdateLine.Dispose()

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
        Dim cmdUpdateLine As New OleDbCommand
        Dim cmdUpdateUserToLine As New OleDbCommand

        If Not (cnn.DataSource.Equals("")) Then
            cmdUpdateLine.Connection = cnn
            cmdUpdateLine.CommandType = CommandType.Text

            If Not (dataUser(0) = Nothing) Then
                cmdUpdateLine.CommandText = "UPDATE user_lines SET USER_NAMES = @namesuser, USER_SURNAMES = @surnamesuser, USER_TYPE = @typeuser, USER_DOCID = @dociduser, USER_ADRSS = @addrsuser, USER_CEL = @celuser, USER_TEL = @teluser, USER_CREATED = @createduser, USER_UPDATED = @updateduser " &
                    "WHERE user_lines.COD_USR_LINE = @coduser"

                cmdUpdateLine.Parameters.AddWithValue("namesuser", dataUser(1))
                cmdUpdateLine.Parameters.AddWithValue("surnamesuser", dataUser(2))
                cmdUpdateLine.Parameters.AddWithValue("typeuser", dataUser(3))
                cmdUpdateLine.Parameters.AddWithValue("dociduser", dataUser(4))
                cmdUpdateLine.Parameters.AddWithValue("addrsuser", dataUser(5))
                cmdUpdateLine.Parameters.AddWithValue("celuser", dataUser(6))
                cmdUpdateLine.Parameters.AddWithValue("teluser", dataUser(7))
                cmdUpdateLine.Parameters.AddWithValue("createduser", dataUser(8))
                cmdUpdateLine.Parameters.AddWithValue("updateduser", dataUser(9))
                cmdUpdateLine.Parameters.AddWithValue("coduser", dataUser(0))

                If (dataUser(12) <> Nothing) Then
                    cmdUpdateUserToLine.Connection = cnn
                    cmdUpdateUserToLine.CommandType = CommandType.Text

                    cmdUpdateUserToLine.CommandText = "UPDATE lines_to_users SET ID_RATE = @codrate, TITULAR_LINE = @titular, PRICE_RATE = @pricerate " &
                    "WHERE lines_to_users.COD_USR_LINE = @coduser AND lines_to_users.COD_LINE = @codline"

                    cmdUpdateUserToLine.Parameters.AddWithValue("codrate", dataUser(10))
                    cmdUpdateUserToLine.Parameters.AddWithValue("titular", Convert.ToBoolean(dataUser(13)))
                    cmdUpdateUserToLine.Parameters.AddWithValue("pricerate", dataUser(11))
                    cmdUpdateUserToLine.Parameters.AddWithValue("coduser", dataUser(0))
                    cmdUpdateUserToLine.Parameters.AddWithValue("codline", dataUser(12))

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

    Public Sub deleteUserToLine(vCodLine As String, vCodUser As String)
        Dim cmdDeleteLineUser As New OleDbCommand

        If Not (cnn.DataSource.Equals("")) Then
            cmdDeleteLineUser.Connection = cnn
            cmdDeleteLineUser.CommandType = CommandType.Text

            If Not (vCodLine = Nothing And vCodUser = Nothing) Then
                cmdDeleteLineUser.CommandText = "DELETE * FROM lines_to_users " &
                    "WHERE lines_to_users.COD_LINE = @codline AND lines_to_users.COD_USR_LINE = @codusrline"
                cmdDeleteLineUser.Parameters.AddWithValue("codline", vCodLine)
                cmdDeleteLineUser.Parameters.AddWithValue("codusrline", vCodUser)

                Try
                    cmdDeleteLineUser.ExecuteNonQuery()
                    cmdDeleteLineUser.Dispose()

                    MsgBox("Se elemino el usuario de la linea", vbInformation, "Aviso")
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

    Public Sub showFindUsers(frmMdiParent As Form, vFrmGet As Integer)
        Dim frm As New frmFindUsers
        frm.MdiParent = frmMdiParent
        frm.vFrmGet = vFrmGet

        If IsNothing(frmMdiParent) Then
            frm.ShowDialog()
        Else
            frm.Show()
        End If
    End Sub

    Public Sub showEditLine(vCodLine As String)
        Dim frm As New frmEditLine
        frm.vCodEditLine = vCodLine
        frm.ShowDialog()
    End Sub

    Public Sub showAccount(vCodLine As String, vCodAccount As String)
        Dim frm As New frmAccount
        frm.vCodLine = vCodLine
        frm.vCodAccount = vCodAccount
        frm.ShowDialog()
    End Sub

    Public Sub showAccountCollect(vCodLine As String, vCodAccount As String, vNameLine As String)
        Dim frm As New frmCollectDetail
        frm.vCodLine = vCodLine
        frm.vCodAccount = vCodAccount
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

    Public Sub showAccountReceipts(vCodAccount As String)
        Dim frm As New frmSeePays
        frm.vCodAccount = vCodAccount
        frm.ShowDialog()
    End Sub

    Public Sub showNewUser(vCodUser As String, vCodAccount As String, vFrmGet As Integer)
        Dim frm As New frmNewuser
        frm.vCodUser = vCodUser
        frm.vFrmGet = vFrmGet
        frm.vCodAccount = vCodAccount
        frm.ShowDialog()
    End Sub

    Public Function lastCodReceipt() As String()
        Dim cmdGetLastReceipt As New OleDbCommand
        Dim dr As OleDbDataReader
        Dim dataStr(1) As String
        dataStr(0) = ""
        dataStr(1) = ""

        If Not cnn.DataSource.Equals("") Then
            cmdGetLastReceipt.Connection = cnn
            cmdGetLastReceipt.CommandType = CommandType.Text

            cmdGetLastReceipt.CommandText = "SELECT DISTINCT TOP 1 payments.ID_PAY FROM payments ORDER BY payments.ID_PAY DESC"

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

    Public Sub getAccountCollect(vCodLine As String, vCodAccount As String, dgAccountYear As DataGridView)
        Dim cmdGetAccountCollect As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            cmdGetAccountCollect.Connection = cnn
            cmdGetAccountCollect.CommandType = CommandType.Text

            If Not (vCodLine = Nothing And vCodAccount = Nothing) Then
                cmdGetAccountCollect.CommandText = "SELECT account_line.ACCOUNT_YEAR, account_line.ACCOUNT_DEBTOTAL, account_line.ACCOUNT_SALDO 
                FROM account_line WHERE account_line.COD_ACCOUNT = @codaccount 
                ORDER BY account_line.ACCOUNT_YEAR DESC"
                cmdGetAccountCollect.Parameters.AddWithValue("codaccount", vCodAccount)

                Try
                    dr = cmdGetAccountCollect.ExecuteReader()

                    If dr.HasRows Then
                        dgAccountYear.Rows.Clear()
                        While dr.Read()
                            Dim vState As String
                            If CDec(dr(2).ToString) > 0 Then
                                vState = "Saldo Pendiente"
                            Else
                                vState = "Cancelado"
                            End If
                            dgAccountYear.Rows.Add(dr(0).ToString, Format(CDec(dr(1).ToString), "###,##0.00"), Format(CDec(dr(2).ToString), "###,##0.00"), vState)
                        End While
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

    Public Sub getAccountCollectCharge(vCodAccount As String, dgAccountCharge As DataGridView)
        Dim cmdGetAccountCollectCharge As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            cmdGetAccountCollectCharge.Connection = cnn
            cmdGetAccountCollectCharge.CommandType = CommandType.Text

            If Not (vCodAccount = Nothing) Then
                cmdGetAccountCollectCharge.CommandText = "SELECT account_detail.ID_DETAIL_ACCOUNT, account_detail.ACCOUNT_YEAR, account_detail.COD_ACCOUNT, account_detail.ACCOUNT_YEAR, account_detail.TYPE_CHARGE, account_detail.MONTH_DEB, account_detail.AMOUNT_DEB, account_detail.AMOUNT_SALDO 
                FROM account_detail WHERE account_detail.COD_ACCOUNT = @codaccount 
                ORDER BY account_detail.TYPE_CHARGE ASC, account_detail.MONTH_DEB ASC, account_detail.ACCOUNT_DETAIL_CREATED ASC"
                cmdGetAccountCollectCharge.Parameters.AddWithValue("codaccount", vCodAccount)

                Try
                    dr = cmdGetAccountCollectCharge.ExecuteReader()

                    If dr.HasRows Then
                        dgAccountCharge.Rows.Clear()
                        While dr.Read
                            Dim vState As String = ""
                            Select Case CInt(dr(4).ToString)
                                Case 1
                                    vState = "Instalacion"
                                Case 2
                                    vState = "Reposicion"
                                Case 3
                                    vState = "Servicio de " & MonthName(CInt(dr(5).ToString)) & " " & dr(1).ToString
                            End Select
                            dgAccountCharge.Rows.Add(dr(0).ToString, dr(1).ToString, dr(4).ToString, dr(5).ToString, False, vState, Format(CDec(dr(6).ToString), "###,##0.00"), Format(CDec(dr(6).ToString) - CDec(dr(7).ToString), "###,##0.00"), Format(CDec(dr(7).ToString), "###,##0.00"))
                        End While
                    Else
                        MsgBox("No hay cuentas por año que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
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
                dgAccountCharge.Item(4, index).Value = False
            Next
            vSaldoTotal = 0
        Else
            For index As Integer = 0 To dgAccountCharge.Rows.Count - 1
                If dgAccountCharge.Item(4, index).Value = True Then
                    vSaldoTotal += CDec(dgAccountCharge.Item(8, index).Value)
                End If
            Next
        End If

        Return vSaldoTotal
    End Function

    Public Sub receiptsHistory(dgHistory As DataGridView, vCodAccount As String, Optional vSeeAll As Integer = 0, Optional vAccountYear As Integer = 0)
        Dim cmdGetAccountReceipts As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            cmdGetAccountReceipts.Connection = cnn
            cmdGetAccountReceipts.CommandType = CommandType.Text

            If Not (vCodAccount = Nothing) Then
                Dim strCommand As String = "SELECT payments.ID_PAY, payments.COD_PAY, payments.COD_ACCOUNT, payments.ACCOUNT_YEAR, payments.PAY_CANCELED, payments.PAY_AMOUNT_TOTAL, payments.PAYER, payments.COLLECTOR, payments.PAY_CREATED, payments.PAY_UPDATED" &
                    " FROM payments WHERE payments.COD_ACCOUNT = @codaccount"
                If vSeeAll <> 0 Then
                    '0: ver todos los recibos, 1: ver los no anulados, 2: ver los anulados
                    strCommand = strCommand & " AND payments.PAY_CANCELED = @canceled"
                End If
                strCommand = strCommand & " ORDER BY payments.PAY_CREATED DESC"
                cmdGetAccountReceipts.CommandText = strCommand
                cmdGetAccountReceipts.Parameters.AddWithValue("codaccount", vCodAccount)
                If vSeeAll <> 0 Then
                    If vSeeAll = 1 Then
                        cmdGetAccountReceipts.Parameters.AddWithValue("canceled", False)
                    ElseIf vSeeAll = 2 Then
                        cmdGetAccountReceipts.Parameters.AddWithValue("canceled", True)
                    End If
                End If

                Try
                    dr = cmdGetAccountReceipts.ExecuteReader()

                    If dr.HasRows Then
                        dgHistory.Rows.Clear()
                        While dr.Read
                            dgHistory.Rows.Add(dr(0).ToString, dr(3).ToString, dr(1).ToString, Format(CDec(dr(5).ToString), "###,##0.00"), dr(6).ToString, dr(7).ToString, dr(8).ToString)
                        End While
                    Else
                        MsgBox("No hay pagos que mostrar", vbCritical, "Aviso")
                    End If
                Catch ex As Exception
                    MsgBox("Ocurrio un error en la consulta de registros", vbCritical, "Aviso")
                    dgHistory.Rows.Clear()
                End Try
            Else
                MsgBox("No se envio el codigo de la cuenta", vbCritical, "Aviso")
            End If
        End If
    End Sub

    Public Function payAccount(dgAccount As DataGridView, amountPay As Decimal, Optional vCodLine As String = Nothing, Optional vCodAccount As String = Nothing, Optional vIdPay As Integer = Nothing, Optional vCodNumReceipt As String = Nothing, Optional vNamePayer As String = Nothing) As String()
        Dim rateYear As Integer = 0
        Dim dataConceptReceipt(12) As String
        Dim indexConcept As Integer = 0
        Dim amountPayTotal As Decimal
        Dim dgAccountCopy As DataGridView = dgAccount

        If dgAccount.Rows.Count > 0 Then
            For index As Integer = 0 To dgAccount.Rows.Count - 1
                rateYear = dgAccount.Item(1, index).Value

                If dgAccount.Item(4, index).Value = True Then
                    If dgAccount.Item(8, index).Value <= amountPay And amountPay > 0 Then
                        If payAccountDetail(dgAccount.Item(0, index).Value, dgAccount.Item(8, index).Value, dgAccount.Item(8, index).Value) Then

                            payReceiptDetail(vIdPay, vCodAccount, dgAccount.Item(0, index).Value, dgAccount.Item(8, index).Value)

                            dataConceptReceipt(indexConcept) = dgAccount.Item(5, index).Value
                            dataConceptReceipt(indexConcept + 6) = dgAccount.Item(8, index).Value
                            amountPayTotal += dgAccount.Item(8, index).Value
                            indexConcept += 1

                            amountPay -= dgAccount.Item(8, index).Value
                        End If
                    ElseIf dgAccount.Item(8, index).Value > amountPay And amountPay > 0 Then
                        If payAccountDetail(dgAccount.Item(0, index).Value, amountPay, dgAccount.Item(8, index).Value) Then

                            payReceiptDetail(vIdPay, vCodAccount, dgAccount.Item(0, index).Value, amountPay)

                            dataConceptReceipt(indexConcept) = dgAccount.Item(5, index).Value
                            dataConceptReceipt(indexConcept + 6) = dgAccount.Item(8, index).Value
                            amountPayTotal += amountPay
                            indexConcept += 1

                            amountPay = 0
                        End If
                    Else
                        Exit For
                    End If
                End If
            Next

            payReceipt(vIdPay, vCodNumReceipt, vCodAccount, rateYear, amountPayTotal, vNamePayer)
            dataConceptReceipt(12) = Format(amountPayTotal, "###,##0.00")
            getAccountYearUpdated(rateYear, vCodLine, vCodAccount)
            Return dataConceptReceipt
            'Recordar implementar un limite de pagos por concepto en un maximo de 6
        Else
            dataConceptReceipt = Nothing
            Return dataConceptReceipt
        End If
    End Function

    Public Sub payReceiptDetail(idPaymnent As Integer, vCodAccount As String, idDetailAccount As String, amountPay As Decimal)
        Dim insertPaymentDetail As New OleDbCommand

        If Not cnn.DataSource.Equals("") Then
            insertPaymentDetail.Connection = cnn
            insertPaymentDetail.CommandType = CommandType.Text

            If Not (idPaymnent = Nothing And vCodAccount = Nothing And idDetailAccount = Nothing And amountPay = Nothing) Then
                insertPaymentDetail.CommandText = "INSERT INTO payments_detail(ID_PAY, COD_ACCOUNT, ID_DETAIL_ACCOUNT, PAY_AMOUNT) VALUES(@idpay, @codaccount, @iddetailaccount, @payamount)"
                insertPaymentDetail.Parameters.AddWithValue("idpay", idPaymnent)
                insertPaymentDetail.Parameters.AddWithValue("codaccount", vCodAccount)
                insertPaymentDetail.Parameters.AddWithValue("iddetailaccount", idDetailAccount)
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

    Public Sub payReceipt(idPaymnent As Integer, vCodNumReceipt As String, vCodAccount As String, vAccountYear As Integer, amountPayTotal As Decimal, payerUser As String)
        Dim insertPaymentDetail As New OleDbCommand

        If Not cnn.DataSource.Equals("") Then
            insertPaymentDetail.Connection = cnn
            insertPaymentDetail.CommandType = CommandType.Text

            If Not (idPaymnent = Nothing And vCodNumReceipt = Nothing And vCodAccount = Nothing And amountPayTotal = Nothing And payerUser = Nothing) Then
                insertPaymentDetail.CommandText = "INSERT INTO payments(ID_PAY, COD_PAY, COD_ACCOUNT, ACCOUNT_YEAR, PAY_AMOUNT_TOTAL, PAYER, COLLECTOR, PAY_CREATED) VALUES(@idpay, @codpay, @codaccount, @accountyear, @payamounttotal, @payer, @collector, @payed)"
                insertPaymentDetail.Parameters.AddWithValue("idpay", idPaymnent)
                insertPaymentDetail.Parameters.AddWithValue("codpay", vCodNumReceipt)
                insertPaymentDetail.Parameters.AddWithValue("codaccount", vCodAccount)
                insertPaymentDetail.Parameters.AddWithValue("accountyear", vAccountYear)
                insertPaymentDetail.Parameters.AddWithValue("payamounttotal", amountPayTotal)
                insertPaymentDetail.Parameters.AddWithValue("payer", payerUser)
                insertPaymentDetail.Parameters.AddWithValue("collector", My.Settings.vUserNameLogin)
                insertPaymentDetail.Parameters.AddWithValue("payed", Format(DateAndTime.Today, "dd/MM/yyyy") & " " & Format(DateAndTime.TimeOfDay, "hh:mm tt"))

                insertPaymentDetail.ExecuteNonQuery()
                insertPaymentDetail.Dispose()
            Else
                MsgBox("Faltan datos para registrar el pago", vbCritical, "Aviso")
            End If
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

    Public Sub getAccountYearUpdated(rateYear As Integer, vCodLine As String, vCodAccount As String)
        Dim cmdGetAccountYearDetail, cmdUpdateAccountYear As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not cnn.DataSource.Equals("") Then
            cmdGetAccountYearDetail.Connection = cnn
            cmdGetAccountYearDetail.CommandType = CommandType.Text
            cmdUpdateAccountYear.Connection = cnn
            cmdUpdateAccountYear.CommandType = CommandType.Text

            If Not (vCodLine = Nothing And vCodAccount = Nothing) Then
                cmdGetAccountYearDetail.CommandText = "SELECT DISTINCTROW Sum([account_detail].[AMOUNT_SALDO])" &
                    " FROM account_detail WHERE account_detail.ACCOUNT_YEAR = @rateyear AND account_detail.COD_ACCOUNT = @codaccount"
                cmdGetAccountYearDetail.Parameters.AddWithValue("rateyear", rateYear)
                cmdGetAccountYearDetail.Parameters.AddWithValue("codaccount", vCodAccount)

                Try
                    dr = cmdGetAccountYearDetail.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()
                        cmdGetAccountYearDetail.Dispose()

                        Dim saldoTotalYear As Decimal = 0
                        saldoTotalYear = Val(dr(0).ToString)

                        cmdUpdateAccountYear.CommandText = "UPDATE account_line SET ACCOUNT_SALDO = @accountsaldo, ACCOUNT_UPDATED = @dateUpdated" &
                            " WHERE account_line.COD_ACCOUNT = @codaccount AND account_line.ACCOUNT_YEAR = @accountyear"
                        cmdUpdateAccountYear.Parameters.AddWithValue("accountsaldo", saldoTotalYear)
                        cmdUpdateAccountYear.Parameters.AddWithValue("dateUpdated", Date.Today)
                        cmdUpdateAccountYear.Parameters.AddWithValue("codaccount", vCodAccount)
                        cmdUpdateAccountYear.Parameters.AddWithValue("accountyear", rateYear)

                        cmdUpdateAccountYear.ExecuteNonQuery()
                        cmdUpdateAccountYear.Dispose()
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
        Dim cmdUpdateAccountDetail As New OleDbCommand

        If Not cnn.DataSource.Equals("") Then
            cmdUpdateAccountDetail.Connection = cnn
            cmdUpdateAccountDetail.CommandType = CommandType.Text

            If Not idAccountDetail = Nothing Then
                cmdUpdateAccountDetail.CommandText = "UPDATE account_detail SET AMOUNT_SALDO = @amountsaldo" &
                    " WHERE account_detail.ID_DETAIL_ACCOUNT = @idaccountdetail"
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

    Public Function getAccount(vCodLine As String, vCodAccount As String) As String()
        Dim cmdGetAccount As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not cnn.DataSource.Equals("") Then
            cmdGetAccount.Connection = cnn
            cmdGetAccount.CommandType = CommandType.Text

            If Not (vCodLine = Nothing And vCodAccount = Nothing) Then
                cmdGetAccount.CommandText = "SELECT lines_to_account.COD_ACCOUNT, lines_to_account.COD_LINE, lines_to_account.ID_RATE, lines_to_account.PRICE_RATE, lines_to_account.ACCOUNT_CREATED, lines_to_account.ACCOUNT_UPDATED 
                FROM lines_to_account WHERE lines_to_account.COD_ACCOUNT = @codaccount AND lines_to_account.COD_LINE = @codline"
                cmdGetAccount.Parameters.AddWithValue("codaccount", vCodAccount)
                cmdGetAccount.Parameters.AddWithValue("codline", vCodLine)

                Try
                    dr = cmdGetAccount.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()
                        cmdGetAccount.Dispose()

                        Dim dataAccount(5) As String
                        dataAccount(0) = dr(0).ToString
                        dataAccount(1) = dr(1).ToString
                        dataAccount(2) = dr(2).ToString
                        dataAccount(3) = dr(3).ToString
                        dataAccount(4) = Format(dr(4).ToString, "Short Date")
                        dataAccount(5) = Format(dr(5).ToString, "Short Date")

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

    Public Function getLine(vCodLine As String) As String()
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT lines.ID_LINE, lines.COD_LINE, lines.NAME_LINE, lines.ID_SECTOR, sector.COD_SECTOR, sector.NAME_SECTOR, lines.ADDRESS, lines.INSTALLDATE_LINE, lines.DESCP_LINE, lines.CREATE_LINE, lines.UPDATE_LINE" &
                " FROM lines INNER JOIN sector ON lines.ID_SECTOR = sector.ID_SECTOR WHERE lines.COD_LINE = @codline"
            cmd.Parameters.AddWithValue("codline", vCodLine)

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    cmd.Dispose()

                    Dim dataLine(10) As String
                    dataLine(0) = dr(0).ToString 'Id de linea
                    dataLine(1) = dr(1).ToString 'Codigo de linea
                    dataLine(2) = dr(2).ToString 'Nombre de linea
                    dataLine(3) = dr(3).ToString 'Id de sector
                    dataLine(4) = dr(4).ToString 'Codigo de sector
                    dataLine(5) = dr(5).ToString 'Nombre del sector
                    dataLine(6) = dr(6).ToString 'Direccion de la linea
                    dataLine(7) = Format(dr(7).ToString, "Short Date") 'Fecha de instalacion
                    dataLine(8) = dr(8).ToString 'Descripcion de linea
                    dataLine(9) = Format(dr(9).ToString, "Short Date") 'Fecha de registro
                    dataLine(10) = Format(dr(10).ToString, "Short Date") 'Fecha de actualizacion

                    Return dataLine
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getUser(vCodUser As String) As String()
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Or IsNothing(vCodUser) Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT user_lines.COD_USR_LINE, user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_type.NAME_TYPE, user_lines.USER_DOCID, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL, user_lines.USER_CREATED, user_lines.USER_UPDATED
            FROM user_type INNER JOIN user_lines ON user_type.ID_TYPE_USER = user_lines.USER_TYPE
            WHERE user_lines.COD_USR_LINE = @coduser"
            cmd.Parameters.AddWithValue("coduser", vCodUser)

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
