﻿Imports System.Data.OleDb

Module dataFunctions
    Public cnn As New OleDbConnection(My.Settings.dbJASSConnectionString)

    Public Function dbConnection()
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
                'MsgBox("Conectado con la base de datos", vbInformation, "Aviso")
            End If
            Return True
        Catch ex As Exception
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
            Return False
        End Try
    End Function

    Public Function userLogin(ByVal nameusr As String, ByVal passwd As String)
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return False
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT NAMEUSER, USERLOG, PASSLOG FROM users_sys WHERE USERLOG = '" & nameusr & "' AND PASSLOG = '" & passwd & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
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

    Public Function generateCodeLine(vSector As String) As String
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT COD_SECTOR FROM sector WHERE ID_SECTOR LIKE '" & vSector & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    cmd.Dispose()

                    Dim codeLine As String = ""
                    Dim codeNum As String = CInt((10000 * Rnd()) + 1)
                    codeLine = Year(Today).ToString & "-" & Trim(dr(0).ToString) & "-" & codeNum.PadLeft(5, "0")

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
        Dim cmd As New OleDbCommand

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT ID_RATE, NAME_RATE FROM rates"

            Try
                Dim ada As New OleDbDataAdapter(cmd)

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
        Dim cmd As New OleDbCommand

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT ID_SECTOR, NAME_SECTOR FROM sector ORDER BY NAME_SECTOR"

            Try
                Dim ada As New OleDbDataAdapter(cmd)

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
        Dim cmd As New OleDbCommand

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT ID_TYPE_USER, NAME_TYPE FROM user_type"

            Try
                Dim ada As New OleDbDataAdapter(cmd)

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
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            Dim comand As String

            Select Case typeBusq
                Case 0
                    'Buscar por nombres
                    comand = "SELECT user_lines.COD_USR_LINE, (user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) AS FULLNAME, user_lines.USER_DOCID,
                    user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL
                    FROM user_type INNER JOIN user_lines ON user_type.ID_TYPE_USER = user_lines.USER_TYPE
                    WHERE user_lines.USER_NAMES LIKE '%" & txtBusq & "%' OR user_lines.USER_SURNAMES LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT user_lines.COD_USR_LINE, (user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) AS FULLNAME, user_lines.USER_DOCID,
                    user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL
                    FROM user_type INNER JOIN user_lines ON user_type.ID_TYPE_USER = user_lines.USER_TYPE
                    WHERE user_lines.USER_DOCID LIKE '%" & txtBusq & "%'"
                Case Else
                    'Buscar a todos
                    comand = "SELECT user_lines.COD_USR_LINE, (user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) AS FULLNAME, user_lines.USER_DOCID,
                    user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL
                    FROM user_type INNER JOIN user_lines ON user_type.ID_TYPE_USER = user_lines.USER_TYPE"
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
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            Dim comand As String

            Select Case typeBusq
                Case 0
                    'Buscar por nombres
                    comand = "SELECT lines.COD_LINE, lines.NAME_LINE, sector.NAME_SECTOR, (user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) AS FULLNAME, user_lines.USER_DOCID, lines_to_users.TITULAR_LINE, rates.NAME_RATE
                    FROM user_lines INNER JOIN (sector INNER JOIN (rates INNER JOIN (lines INNER JOIN lines_to_users ON lines.COD_LINE = lines_to_users.COD_LINE) ON rates.ID_RATE = lines_to_users.ID_RATE) ON sector.ID_SECTOR = lines.ID_SECTOR) ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE
                    WHERE user_lines.USER_NAMES LIKE '%" & txtBusq & "%' OR user_lines.USER_SURNAMES LIKE '%" & txtBusq & "%'"
                Case 1
                    'Buscar por documento
                    comand = "SELECT lines.COD_LINE, lines.NAME_LINE, sector.NAME_SECTOR, (user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) AS FULLNAME, user_lines.USER_DOCID, lines_to_users.TITULAR_LINE, rates.NAME_RATE
                    FROM user_lines INNER JOIN (sector INNER JOIN (rates INNER JOIN (lines INNER JOIN lines_to_users ON lines.COD_LINE = lines_to_users.COD_LINE) ON rates.ID_RATE = lines_to_users.ID_RATE) ON sector.ID_SECTOR = lines.ID_SECTOR) ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE
                    WHERE user_lines.USER_DOCID LIKE '%" & txtBusq & "%'"
                Case 2
                    'Buscar por codigo de linea
                    comand = "SELECT 
                    VLINES.COD_LINE,
                    VLINES.NAME_LINE,
                    VSECTOR.NAME_SECTOR, 
                    (SELECT TOP 1 TRIM(user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS FULLNAME,
                    (SELECT TOP 1 user_lines.USER_DOCID FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS DOCID,
                    (SELECT TOP 1 IIF(lines_to_users.TITULAR_LINE = TRUE,'TRUE', 'FALSE') FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS TITULAR, 
                    (SELECT TOP 1 rates.NAME_RATE FROM rates INNER JOIN (user_lines INNER JOIN lines_to_users ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE) ON rates.ID_RATE = lines_to_users.ID_RATE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS RATE
                    FROM sector VSECTOR INNER JOIN lines VLINES ON VSECTOR.ID_SECTOR = VLINES.ID_SECTOR
                    WHERE VLINES.COD_LINE LIKE '%" & txtBusq & "%'"
                Case 3
                    'Buscar por nombre de linea
                    comand = "SELECT 
                    VLINES.COD_LINE,
                    VLINES.NAME_LINE,
                    VSECTOR.NAME_SECTOR, 
                    (SELECT TOP 1 TRIM(user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS FULLNAME,
                    (SELECT TOP 1 user_lines.USER_DOCID FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS DOCID,
                    (SELECT TOP 1 IIF(lines_to_users.TITULAR_LINE = TRUE,'TRUE', 'FALSE') FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS TITULAR, 
                    (SELECT TOP 1 rates.NAME_RATE FROM rates INNER JOIN (user_lines INNER JOIN lines_to_users ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE) ON rates.ID_RATE = lines_to_users.ID_RATE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS RATE
                    FROM sector VSECTOR INNER JOIN lines VLINES ON VSECTOR.ID_SECTOR = VLINES.ID_SECTOR
                    WHERE VLINES.NAME_LINE LIKE '%" & txtBusq & "%'"
                Case Else
                    'Buscar a todos
                    comand = "SELECT 
                    VLINES.COD_LINE,
                    VLINES.NAME_LINE,
                    VSECTOR.NAME_SECTOR, 
                    (SELECT TOP 1 TRIM(user_lines.USER_NAMES & ' ' & user_lines.USER_SURNAMES) FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS FULLNAME,
                    (SELECT TOP 1 user_lines.USER_DOCID FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS DOCID,
                    (SELECT TOP 1 IIF(lines_to_users.TITULAR_LINE = TRUE,'TRUE', 'FALSE') FROM user_lines INNER JOIN lines_to_users ON lines_to_users.COD_USR_LINE = user_lines.COD_USR_LINE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS TITULAR, 
                    (SELECT TOP 1 rates.NAME_RATE FROM rates INNER JOIN (user_lines INNER JOIN lines_to_users ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE) ON rates.ID_RATE = lines_to_users.ID_RATE WHERE lines_to_users.COD_LINE = VLINES.COD_LINE AND lines_to_users.TITULAR_LINE = TRUE) AS RATE
                    FROM sector VSECTOR INNER JOIN lines VLINES ON VSECTOR.ID_SECTOR = VLINES.ID_SECTOR"
            End Select

            cmd.CommandText = comand

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgLinesService.Rows.Clear()
                    While dr.Read()
                        Dim vHolder As Boolean = False
                        If dr(5).ToString.Equals("") Then
                            vHolder = False
                        ElseIf CType(dr(5).ToString, Boolean) = False Then
                            vHolder = False
                        ElseIf CType(dr(5).ToString, Boolean) = True Then
                            vHolder = True
                        End If
                        dgLinesService.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(3).ToString, dr(4).ToString, vHolder, dr(6).ToString)
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

    Public Sub listUserOfLine(vCodLine As String, dgUserOfLine As DataGridView)
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            MsgBox("Error de conexion", vbExclamation, "Aviso")
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT lines_to_users.COD_USR_LINE, lines_to_users.COD_LINE, lines_to_users.ID_RATE, user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_type.NAME_TYPE, user_lines.USER_DOCID, lines_to_users.TITULAR_LINE, rates.NAME_RATE, lines_to_users.COD_ACCOUNT
            FROM rates INNER JOIN (user_type INNER JOIN (user_lines INNER JOIN lines_to_users ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE) ON user_type.ID_TYPE_USER = user_lines.USER_TYPE) ON rates.ID_RATE = lines_to_users.ID_RATE
            WHERE lines_to_users.COD_LINE LIKE '" & vCodLine & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dgUserOfLine.Rows.Clear()
                    While dr.Read()
                        dgUserOfLine.Rows.Add(dr(0).ToString, dr(1).ToString, dr(2).ToString, dr(9).ToString, dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString, Convert.ToBoolean(dr(7).ToString), dr(8).ToString)
                    End While
                Else
                    dgUserOfLine.Rows.Clear()
                End If
                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("Ocurrio un error al buscar los datos", vbExclamation, "Aviso")
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Function getPriceRate(idRate As String) As String()
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT PRICE_RATE, DESC_RATE, VARIABLE FROM rates WHERE ID_RATE LIKE '" & idRate & "'"

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
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT COD_SECTOR, NAME_SECTOR FROM sector WHERE ID_SECTOR LIKE '" & idAvenue & "'"

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

    Public Function getCodeLine(vSector As Integer) As String
        Dim cmd As New OleDbCommand
        Dim codeLine As String

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            Try
                Dim vResult As Boolean
                Do
                    codeLine = generateCodeLine(vSector)
                    If codeLine = Nothing Then
                        Return Nothing
                    End If
                    Dim dr As OleDbDataReader
                    cmd.Connection = cnn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COD_LINE FROM lines WHERE COD_LINE LIKE '" & codeLine & "'"
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

    Public Sub addUserToLine(vCodLine As String, dataUser() As String, vRates As Integer, Optional vPriceRate As Double = 0)
        Dim cmdInsertLineUser As New OleDbCommand
        Dim cmdFindLineUser As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            If vCodLine.Length > 0 And vCodLine <> "" Or vRates <> 0 Then
                cmdFindLineUser.Connection = cnn
                cmdFindLineUser.CommandType = CommandType.Text

                cmdFindLineUser.CommandText = "SELECT * FROM lines_to_users WHERE COD_LINE LIKE '" & vCodLine & "' AND COD_USR_LINE LIKE '" & dataUser(0) & "'"

                Try
                    dr = cmdFindLineUser.ExecuteReader()

                    If Not (dr.HasRows) Then
                        cmdInsertLineUser.Connection = cnn
                        cmdInsertLineUser.CommandType = CommandType.Text

                        Dim vResult As String = "false"

                        If MsgBox("¿Desea insertar este usuario como titular?", MsgBoxStyle.YesNo + vbInformation, "Aviso") = MsgBoxResult.Yes Then
                            vResult = "true"
                        End If

                        cmdInsertLineUser.CommandText = "INSERT INTO lines_to_users(COD_LINE, COD_USR_LINE, TITULAR_LINE, ID_RATE, PRICE_RATE) VALUES('" & vCodLine & "','" & dataUser(0) & "', " & vResult & ",'" & vRates & "','" & vPriceRate & "')"

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

    Public Sub saveUserNew(dataUser() As String, Optional vLineToUser As Boolean = False)
        Dim codUser As String = generateCode(15, True, True, True)

        Dim cmdInsertUser As New OleDbCommand
        Dim cmdInsertLineUser As New OleDbCommand
        Dim cmdLastInsertLineUser As New OleDbCommand
        Dim cmdUpdateCodeLineUser As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            cmdInsertUser.Connection = cnn
            cmdInsertUser.CommandType = CommandType.Text

            cmdInsertUser.CommandText = "INSERT INTO user_lines(COD_USR_LINE, USER_NAMES, USER_SURNAMES, USER_TYPE, USER_DOCID, USER_ADRSS, USER_CEL, USER_TEL) VALUES(@coduserline, @nameuser, @surnameuser, @typeuser, @dociduser, @addressuser, @celluser, @teleuser)"
            cmdInsertUser.Parameters.AddWithValue("coduserline", codUser)
            cmdInsertUser.Parameters.AddWithValue("nameuser", dataUser(1))
            cmdInsertUser.Parameters.AddWithValue("surnameuser", dataUser(2))
            cmdInsertUser.Parameters.AddWithValue("typeuser", dataUser(3))
            cmdInsertUser.Parameters.AddWithValue("dociduser", dataUser(4))
            cmdInsertUser.Parameters.AddWithValue("addressuser", dataUser(5))
            cmdInsertUser.Parameters.AddWithValue("celluser", dataUser(6))
            cmdInsertUser.Parameters.AddWithValue("teleuser", dataUser(7))

            Try
                dr = cmdInsertUser.ExecuteReader()

                If vLineToUser = True Then
                    cmdInsertLineUser.Connection = cnn
                    cmdInsertLineUser.CommandType = CommandType.Text
                    cmdInsertLineUser.CommandText = "INSERT INTO lines_to_users(COD_LINE, COD_USR_LINE, TITULAR_LINE, ID_RATE, PRICE_RATE) VALUES(@codline, @coduserline, @titular, @codrate, @pricerate)"
                    cmdInsertLineUser.Parameters.AddWithValue("codline", dataUser(12))
                    cmdInsertLineUser.Parameters.AddWithValue("coduserline", codUser)
                    cmdInsertLineUser.Parameters.AddWithValue("titular", Convert.ToBoolean(dataUser(13)))
                    cmdInsertLineUser.Parameters.AddWithValue("codrate", dataUser(10))
                    cmdInsertLineUser.Parameters.AddWithValue("pricerate", dataUser(11))

                    cmdInsertLineUser.ExecuteNonQuery()

                    cmdLastInsertLineUser.Connection = cnn
                    cmdLastInsertLineUser.CommandType = CommandType.Text
                    cmdLastInsertLineUser.CommandText = "SELECT lines_to_users.ID_ACCOUNT FROM lines_to_users WHERE COD_LINE LIKE @codline AND COD_USR_LINE LIKE @coduserline"
                    cmdLastInsertLineUser.Parameters.AddWithValue("codline", dataUser(12))
                    cmdLastInsertLineUser.Parameters.AddWithValue("coduserline", codUser)

                    dr = cmdLastInsertLineUser.ExecuteReader()

                    If dr.HasRows Then
                        dr.Read()
                        cmdUpdateCodeLineUser.Connection = cnn
                        cmdUpdateCodeLineUser.CommandType = CommandType.Text
                        cmdUpdateCodeLineUser.CommandText = "UPDATE lines_to_users SET lines_to_users.COD_ACCOUNT = @codaccount WHERE lines_to_users.ID_ACCOUNT LIKE '" & dr(0).ToString & "'"
                        cmdUpdateCodeLineUser.Parameters.AddWithValue("codaccount", "C" & dr(0).ToString.PadLeft(6, "0"))
                        cmdUpdateCodeLineUser.ExecuteNonQuery()
                    End If

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

        Dim cmdInsertLine As New OleDbCommand
        Dim cmdInsertUser As New OleDbCommand
        Dim cmdInsertLineUser As New OleDbCommand
        Dim cmdLastInsertLineUser As New OleDbCommand
        Dim cmdUpdateCodeLineUser As New OleDbCommand
        Dim dr As OleDbDataReader

        If Not (cnn.DataSource.Equals("")) Then
            cmdInsertLine.Connection = cnn
            cmdInsertUser.Connection = cnn
            cmdInsertLineUser.Connection = cnn
            cmdInsertLine.CommandType = CommandType.Text
            cmdInsertUser.CommandType = CommandType.Text
            cmdInsertLineUser.CommandType = CommandType.Text

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

            cmdInsertUser.CommandText = "INSERT INTO user_lines(COD_USR_LINE, USER_NAMES, USER_SURNAMES, USER_TYPE, USER_DOCID, USER_ADRSS, USER_CEL, USER_TEL) VALUES(@coduserline, @nameuser, @surnameuser, @typeuser, @dociduser, @addressuser, @celluser, @teleuser)"
            cmdInsertUser.Parameters.AddWithValue("coduserline", codUser)
            cmdInsertUser.Parameters.AddWithValue("nameuser", dataUser(0))
            cmdInsertUser.Parameters.AddWithValue("surnameuser", dataUser(1))
            cmdInsertUser.Parameters.AddWithValue("typeuser", dataUser(2))
            cmdInsertUser.Parameters.AddWithValue("dociduser", dataUser(3))
            cmdInsertUser.Parameters.AddWithValue("addressuser", dataUser(4))
            cmdInsertUser.Parameters.AddWithValue("celluser", dataUser(5))
            cmdInsertUser.Parameters.AddWithValue("teleuser", dataUser(6))

            If dataUser(7).Length > 0 And dataUser(7) <> "" Then
                cmdInsertLineUser.CommandText = "INSERT INTO lines_to_users(COD_LINE, COD_USR_LINE, TITULAR_LINE, ID_RATE, PRICE_RATE) VALUES(@codline, @coduserline, @titular, @codrate, @pricerate)"
                cmdInsertLineUser.Parameters.AddWithValue("codline", dataLine(0))
                cmdInsertLineUser.Parameters.AddWithValue("coduserline", dataUser(7))
                cmdInsertLineUser.Parameters.AddWithValue("titular", Convert.ToBoolean(True))
                cmdInsertLineUser.Parameters.AddWithValue("codrate", dataLine(4))
                cmdInsertLineUser.Parameters.AddWithValue("pricerate", vPriceRate)
            Else
                cmdInsertLineUser.CommandText = "INSERT INTO lines_to_users(COD_LINE, COD_USR_LINE, TITULAR_LINE, ID_RATE, PRICE_RATE) VALUES(@codline, @coduserline, @titular, @codrate, @pricerate)"
                cmdInsertLineUser.Parameters.AddWithValue("codline", dataLine(0))
                cmdInsertLineUser.Parameters.AddWithValue("coduserline", codUser)
                cmdInsertLineUser.Parameters.AddWithValue("titular", Convert.ToBoolean(True))
                cmdInsertLineUser.Parameters.AddWithValue("codrate", dataLine(4))
                cmdInsertLineUser.Parameters.AddWithValue("pricerate", vPriceRate)
            End If


            Try
                If dataUser(7).Length = 0 And dataUser(7) = "" Then
                    dr = cmdInsertUser.ExecuteReader()
                End If
                dr = cmdInsertLine.ExecuteReader()
                dr = cmdInsertLineUser.ExecuteReader()

                cmdLastInsertLineUser.Connection = cnn
                cmdLastInsertLineUser.CommandType = CommandType.Text
                cmdLastInsertLineUser.CommandText = "SELECT lines_to_users.ID_ACCOUNT FROM lines_to_users WHERE COD_LINE LIKE @codline AND COD_USR_LINE LIKE @coduserline"
                cmdLastInsertLineUser.Parameters.AddWithValue("codline", dataLine(0))
                If dataUser(7).Length = 0 And dataUser(7) = "" Then
                    cmdLastInsertLineUser.Parameters.AddWithValue("coduserline", codUser)
                Else
                    cmdLastInsertLineUser.Parameters.AddWithValue("coduserline", dataUser(7))
                End If


                dr = cmdLastInsertLineUser.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    cmdUpdateCodeLineUser.Connection = cnn
                    cmdUpdateCodeLineUser.CommandType = CommandType.Text
                    cmdUpdateCodeLineUser.CommandText = "UPDATE lines_to_users SET lines_to_users.COD_ACCOUNT = @codaccount WHERE lines_to_users.ID_ACCOUNT LIKE '" & dr(0).ToString & "'"
                    cmdUpdateCodeLineUser.Parameters.AddWithValue("codaccount", "C" & dr(0).ToString.PadLeft(6, "0"))
                    cmdUpdateCodeLineUser.ExecuteNonQuery()
                End If


                dr.Close()
                cmdInsertLine.Dispose()
                cmdInsertUser.Dispose()
                cmdInsertLineUser.Dispose()
                cmdLastInsertLineUser.Dispose()
                cmdUpdateCodeLineUser.Dispose()

                MsgBox("La linea se guardo exitosamente", vbInformation, "Aviso")
            Catch ex As Exception
                MsgBox("Ocurrio un error al guardar el registro", vbCritical, "Aviso")
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No se conecto con la base de datos", vbCritical, "Aviso")
        End If
    End Sub

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

    Public Sub showEditLine(codLine As String)
        frmEditLine.vCodEditLine = codLine
        frmEditLine.ShowDialog()
    End Sub

    Public Sub showNewEditUser(vState As Integer, vForm As Form, Optional vCodUser As String = "new", Optional vCodLine As String = Nothing, Optional vCodRate As Integer = 0)
        frmNewuser.vFrmGet = vState
        frmNewuser.vCodUser = vCodUser
        frmNewuser.vCodLine = vCodLine
        frmNewuser.vCodRate = vCodRate

        If vState = 1 Then
            frmNewuser.MdiParent = vForm
            frmNewuser.Show()
        ElseIf vState = 2 Or vState = 3 Then
            frmNewuser.ShowDialog(vForm)
        End If

        frmNewuser.Focus()
    End Sub

    Public Function getLine(vCodLine As String) As String()
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            cmd.CommandText = "SELECT ID_LINE, COD_LINE, NAME_LINE, ID_SECTOR, ADDRESS, INSTALLDATE_LINE, DESCP_LINE, CREATE_LINE, UPDATE_LINE FROM lines WHERE COD_LINE LIKE '" & vCodLine & "'"

            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    cmd.Dispose()

                    Dim dataLine(8) As String
                    dataLine(0) = dr(0).ToString
                    dataLine(1) = dr(1).ToString
                    dataLine(2) = dr(2).ToString
                    dataLine(3) = dr(3).ToString
                    dataLine(4) = dr(4).ToString
                    dataLine(5) = Format(dr(5).ToString, "Short Date")
                    dataLine(6) = dr(6).ToString
                    dataLine(7) = Format(dr(7).ToString, "Short Date")
                    dataLine(8) = Format(dr(8).ToString, "Short Date")

                    Return dataLine
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function

    Public Function getUser(vCodeUser As String, Optional vRate As Integer = 0) As String()
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        If cnn.DataSource.Equals("") Or IsNothing(vCodeUser) Then
            Return Nothing
        Else
            cmd.Connection = cnn
            cmd.CommandType = CommandType.Text

            If vRate = 0 Then
                cmd.CommandText = "SELECT user_lines.COD_USR_LINE, user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_type.NAME_TYPE, user_lines.USER_DOCID, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL, user_lines.USER_CREATED, user_lines.USER_UPDATED
                FROM user_type INNER JOIN user_lines ON user_type.ID_TYPE_USER = user_lines.USER_TYPE
                WHERE user_lines.COD_USR_LINE LIKE '" & vCodeUser & "'"
            Else
                cmd.CommandText = "SELECT user_lines.COD_USR_LINE, user_lines.USER_NAMES, user_lines.USER_SURNAMES, user_lines.USER_TYPE, user_type.NAME_TYPE, user_lines.USER_DOCID, user_lines.USER_ADRSS, user_lines.USER_CEL, user_lines.USER_TEL, user_lines.USER_CREATED, user_lines.USER_UPDATED, lines_to_users.ID_RATE, lines_to_users.TITULAR_LINE, lines_to_users.COD_LINE, rates.VARIABLE, lines_to_users.PRICE_RATE
                FROM rates INNER JOIN (user_type INNER JOIN (user_lines INNER JOIN lines_to_users ON user_lines.COD_USR_LINE = lines_to_users.COD_USR_LINE) ON user_type.ID_TYPE_USER = user_lines.USER_TYPE) ON rates.ID_RATE = lines_to_users.ID_RATE 
                WHERE user_lines.COD_USR_LINE LIKE '" & vCodeUser & "'"
            End If


            Try
                dr = cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    cmd.Dispose()

                    Dim dataUser(15) As String
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

                    If vRate = 0 Then
                        dataUser(11) = 0
                        dataUser(12) = False
                        dataUser(13) = 0
                        dataUser(14) = False
                        dataUser(15) = 0
                    Else
                        dataUser(11) = dr(11).ToString 'Codigo de tarifa
                        dataUser(12) = Convert.ToBoolean(dr(12).ToString) 'Titular
                        dataUser(13) = dr(11).ToString 'Codigo de linea
                        dataUser(14) = Convert.ToBoolean(dr(14).ToString) 'Variable
                        dataUser(15) = dr(15).ToString 'Precio de tarifa
                    End If

                    Return dataUser
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End If
    End Function
End Module
