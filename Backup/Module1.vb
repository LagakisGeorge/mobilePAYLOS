Imports System.Data.SqlServerCe
Module Module1
    Function A2U(ByVal C As String) As String
        'METATREPEI TO ANSI SE UNICODE GIA NA MPORO NA TO DIABASO

        Dim K, L As Long
        '        C2 = ""
        For K = 1 To Len(C)
            L = InStr("ÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÓÔÕÖ×ØÙ", Mid(C, K, 1))
            If L > 0 Then
                Mid(C, K, 1) = Mid("ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ", L, 1)
            End If
        Next
        A2U = C

    End Function
    Function dos2U(ByVal C As String) As String
        'METATREPEI TO ANSI SE UNICODE GIA NA MPORO NA TO DIABASO

        Dim K As Long
        Dim n As Integer

        '        C2 = ""
        For K = 1 To Len(C)
            n = Asc(Mid(C, K, 1))

            'L = InStr("ΑΒΓΔ", Mid(C, K, 1))
            If n >= 224 Then
                Mid(C, K, 1) = Mid("ωάέήϊίόύϋώΆΈΉΊΌΎΏ", n - 223, 1)
            Else
                If n > 127 Then
                    Mid(C, K, 1) = Mid("ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩαβγδεζηθικλμνξοπρσςτυφχψω", n - 127, 1)
                End If
            End If
        Next
        dos2U = C

    End Function
    Public Function ExecuteSQL(ByVal sql As String) As Long
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand(sql, objcon)
        objcmd.Connection.Open()
        ExecuteSQL = objcmd.ExecuteNonQuery()
        objcmd.Connection.Close()

    End Function
    Public Function openSQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

        Dim fobjcon As SqlCeConnection, fobjcmd As New SqlCeCommand

        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlCeDataAdapter

        fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        fobjcmd = New SqlCeCommand(sql, fobjcon)
        'fobjcmd.Connection.Open()


        fobjcmd = New SqlCeCommand(sql, fobjcon)
        fobjcmd.Connection.Open()
        FDA.SelectCommand = fobjcmd
        FDS.Clear()
        FDA.Fill(FDS, "P")

    End Function

    Public Function ADD_FIELD(ByVal sql As String, ByVal FIELDNAME As String, ByVal TYPE As String)
        Dim FDS As New System.Data.DataSet
        Dim fobjcon As SqlCeConnection, fobjcmd As New SqlCeCommand

        Dim K As Integer, l As Long

        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlCeDataAdapter

        fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        fobjcmd = New SqlCeCommand("SELECT * FROM " + sql, fobjcon)

        fobjcmd.Connection.Open()
        FDA.SelectCommand = fobjcmd
        FDS.Clear()
        FDA.Fill(FDS, "P")
        Dim OK As Integer = 0

        For K = 0 To FDS.Tables("P").Columns.Count - 1
            If FIELDNAME = FDS.Tables(0).Columns(K).Caption Then
                OK = 1
            End If
        Next
        If OK = 0 Then
            K = ExecuteSQL("ALTER TABLE " + sql + " ADD " + FIELDNAME + " " + TYPE)
        End If





    End Function









    Public Function to437(ByVal SQL As String) As String
        Dim s928, s437, s As String, k As Integer
        'metatrepei eggrafo apo 928 -> 437
        s928 = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ-αβγδεζηθικλμνξοπρστυφχψω-ςάέήίόύώ"
        s437 = "€‚ƒ„…†‡‰‹‘’•–—-™› ΅Ά£¤¥¦§¨©«¬­®―ΰ-αβγεζηι" ' saehioyv
        '  saehioyv

        For k = 1 To Len(SQL)
            s = Mid(SQL, k, 1)
            't = InStr(s928, s)
            If Asc(s) > 190 Then
                If Asc(s) <= 209 Then
                    Mid(SQL, k, 1) = Chr(Asc(s) - 65)
                Else
                    Mid(SQL, k, 1) = Chr(Asc(s) - 66)
                End If

            End If
        Next




        'For k = 1 To Len(SQL)
        '    s = Mid(SQL, k, 1)
        '    t = InStr(s928, s)
        '    If t > 0 Then
        '        Mid(SQL, k, 1) = Mid$(s437, t, 1)
        '    End If
        'Next


        to437 = SQL

    End Function

    

    Public Function toGreeK(ByVal SQL As String) As String
        Dim s928, s437, s As String, k As Integer
        'metatrepei eggrafo apo 928 -> 437
        s928 = "abgdezhuiklmnjoprstyfxcv"
        s437 = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ" ' saehioyv
        '  saehioyv
        Dim T As Integer


        For k = 1 To Len(SQL)
            s = Mid(SQL, k, 1)
            't = InStr(s928, s)
            t = InStr(s928, s)
            If t > 0 Then
                Mid$(SQL, k, 1) = Mid$(s437, T, 1)
            End If
        Next



        toGreeK = SQL

    End Function

    Public Function toNumeric(ByVal SQL As String) As String
        Dim s928, s437, s As String, k As Integer
        'metatrepei eggrafo apo 928 -> 437
        s928 = "*adgjmptw*ADGJMPT"
        s437 = "123456789123456789" ' saehioyv
        '  saehioyv
        Dim T As Integer


        For k = 1 To Len(SQL)
            s = Mid(SQL, k, 1)
            't = InStr(s928, s)
            T = InStr(s928, s)
            If T > 0 Then
                Mid$(SQL, k, 1) = Mid$(s437, T, 1)
            End If
        Next



        toNumeric = SQL

    End Function






End Module
