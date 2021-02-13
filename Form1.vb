Imports System.IO
Imports System.Data.SqlServerCe
Imports System.Data.SqlClient

Public Class Form1
    Public FDS2 As New System.Data.DataSet
    Public SAJIA As Single


    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        ' System.IO.File.Copy("\abc.txt", "\servername\abc\temp.txt", True)
    End Sub

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.ParentChanged


    End Sub

    Private Sub MBARCODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MBARCODE.GotFocus
        MBARCODE.BackColor = Color.Yellow
    End Sub

    Private Sub MBARCODE_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MBARCODE.KeyUp
        Dim FDS2 As New System.Data.DataSet
        Dim FDS3 As New System.Data.DataSet
        Dim k As Long
        Dim N As Long
        If e.KeyCode = 13 Then

            If Len(MBARCODE.Text) = 0 Then
                Exit Sub
            End If

            Try
                'N = ExecuteSQL(SQL)
                'ListBox1.Items.Insert(0, Mid(MONO.Text, 1, 15) + " " + mPOS.Text)
                'SAJIA = SAJIA + Val(Replace(mPOS.Text, ",", ".")) * Val(Replace(MLTI.Text, ",", "."))
                'ajia.Text = Format(SAJIA, "#####.00")










                ' If Len(MBARCODE.Text) = 13 Then
                k = open2SQL("SELECT * FROM EID WHERE BARCODE like '" + MBARCODE.Text + "%'", FDS2)
                ' Else
                '  k = open2SQL("SELECT * FROM EID WHERE KOD='" + Replace(MBARCODE.Text, "'", "-") + "'", FDS2)

                '  End If
                If FDS2.Tables(0).Rows.Count >= 1 Then
                    ' FDS2.Tables(0).Rows(0).Item("barcode").ToString
                    '    For N = 0 To FDS2.Tables(0).Rows.Count - 1
                    MONO.Text = FDS2.Tables(0).Rows(0).Item("ONO").ToString
                    MKOD.Text = FDS2.Tables(0).Rows(0).Item("KOD").ToString
                    MLTI.Text = FDS2.Tables(0).Rows(0).Item("LTI").ToString

                    ypol.Text = FDS2.Tables(0).Rows(0).Item("pos").ToString
                    desm.Text = FDS2.Tables(0).Rows(0).Item("desm").ToString
                    anam.Text = FDS2.Tables(0).Rows(0).Item("anam").ToString




                    k = open2SQL("SELECT SUM(POSO) as S FROM EGGTIM WHERE NATIM=" + ATIM.Text + " AND KODE='" + MBARCODE.Text + "'", FDS3)


                    SPOS.Text = FDS3.Tables(0).Rows(0).Item("S").ToString

                    mPOS.Text = 1

                    '  If Val(SPOS.Text) <> 0 Then  'υπηρχε ηδη ποσοτητα και την προσαρμόζει

                    'Dim FDS3 As New System.Data.DataSet
                    ''If Val(mPOS.Text) <> 0 Then
                    'k = open2SQL("UPDATE EGGTIM SET POSO=" + Replace(mPOS.Text, ",", ".") + " WHERE NATIM=" + ATIM.Text + " AND KODE='" + MBARCODE.Text + "'", FDS3)
                    ''Else
                    ''   K = open2SQL("DELETE FROM EGGTIM  WHERE NATIM=" + ATIM.Text + " AND KODE='" + MBARCODE.Text + "'", FDS3)
                    ''End If

                    'k = open2SQL("SELECT SUM(POSO*TIMM) AS SSS FROM EGGTIM WHERE NATIM=" + ATIM.Text, FDS3)
                    'SAJIA = FDS3.Tables(0).Rows(0)(0)

                    '   Else  ' εντελως για πρωτη φορά

                    Dim SQL As String
                    If Val(mPOS.Text) <> 0 Then



                        SQL = "INSERT INTO EGGTIM (KODE,POSO,TIMM,NATIM,NMHX,KODPEL,ONO) VALUES ('" + MBARCODE.Text + "'," + Replace(mPOS.Text, ",", ".") + "," + "0," + Str(Val(ATIM.Text)) + "," + Str(AAMHX) + ",'" + "1111" + "','" + MKOD.Text + "')"
                        Try
                            N = ExecuteSQL(SQL)
                            ListBox1.Items.Insert(0, Mid(MKOD.Text, 1, 25) + " " + mPOS.Text)

                            'ajia.Text = Format(SAJIA, "#####.00")
                        Catch ex As Exception
                            ListBox1.Items.Add("ΛΑΘΟΣ " & ex.Message)
                        End Try
                        ' SAJIA = SAJIA + Val(mPOS.Text) * Val(MLTI.Text)
                        SAJIA = SAJIA + Val(Replace(mPOS.Text, ",", ".")) * Val(Replace(MLTI.Text, ",", "."))
                    End If  ' Val(mPOS.Text) <> 0 Then


                    '  End If  '' εντελως για πρωτη φορά

                    MBARCODE.Text = ""
                    MBARCODE.Focus()
                    '+ "  " + FDS2.Tables(0).Rows(N).Item("S").ToString + "  " + FDS2.Tables(0).Rows(N).Item("RAFI").ToString)
                    ' Me.Text = Format(N, "#####")
                ElseIf FDS2.Tables(0).Rows.Count = 0 Then

                    Dim RR As Integer
                    Do While True

                        RR = MsgBox("ΔΕΝ ΒΡΕΘΗΚΕ.ΝΑ ΣΤΑΜΑΤΗΣΩ?.", MsgBoxStyle.YesNo)

                        If RR = DialogResult.No Then
                            Exit Do
                        End If
                    Loop

                   

                    MBARCODE.Text = ""
                Else  ' > 1
                        MsgBox("ΒΡΕΘΗΚAN ME TA IΔIA ΣTOIXEIA")
                End If



            Catch ex As Exception
                ListBox1.Items.Add("ΛΑΘΟΣ " & ex.Message)
            End Try




        End If

    End Sub

    Private Sub MBARCODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MBARCODE.LostFocus
        MBARCODE.BackColor = Color.White

    End Sub

    Private Sub MBARCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MBARCODE.TextChanged



    End Sub

    Private Sub mPOS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mPOS.GotFocus
        mPOS.BackColor = Color.Yellow
    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mPOS.KeyUp
        'mPOS.KeyUp

        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim sql As String
        Dim KODPEL As String = Split(mAFM.Text, ";")(0)
        If Val(mPOS.Text) > 9999 Then

            MsgBox("ΛΑΘΟΣ ΠΟΣΟ")
            mPOS.Text = ""
            Exit Sub
        End If
        Dim KK As Integer
        


        Dim ANS As Integer
        If Val(mPOS.Text) > Val(ypol.Text) - Val(desm.Text) Then

            ypol.BackColor = Color.Red

        Else
            ypol.BackColor = Color.SkyBlue



        End If







        Dim x As String
        x = ""
        Dim n As Long
        Dim K As Long


        If e.KeyCode = 13 And Len(Trim(MBARCODE.Text)) > 0 Then ' And Val(mPOS.Text) <> 0 Then

            If Val(mPOS.Text) = 0 Then
                KK = MsgBox("ΜΗΔΕΝΙΚΗ ΠΟΣΟΤΗΤΑ", MsgBoxStyle.YesNo)
                If KK = MsgBoxResult.No Then
                    mPOS.Text = ""
                    Exit Sub
                Else
                    mPOS.Text = "0"
                End If
            End If








            'If Val(mPOS.Text) > Val(ypol.Text) - Val(desm.Text) Then

            '    ANS = MsgBox("ΥΠΕΡΒΑΣΗ ΥΠΟΛΟΙΠΟΥ", MsgBoxStyle.YesNo)
            '    If ANS = MsgBoxResult.No Then
            '        mPOS.Focus()
            '        Exit Sub
            '    End If
            'End If






            If Val(SPOS.Text) <> 0 Then  'υπηρχε ηδη ποσοτητα και την προσαρμόζει

                Dim FDS3 As New System.Data.DataSet
                'If Val(mPOS.Text) <> 0 Then
                K = open2SQL("UPDATE EGGTIM SET POSO=" + Replace(mPOS.Text, ",", ".") + " WHERE NATIM=" + ATIM.Text + " AND KODE='" + MBARCODE.Text + "'", FDS3)
                'Else
                '   K = open2SQL("DELETE FROM EGGTIM  WHERE NATIM=" + ATIM.Text + " AND KODE='" + MBARCODE.Text + "'", FDS3)
                'End If

                K = open2SQL("SELECT SUM(POSO*TIMM) AS SSS FROM EGGTIM WHERE NATIM=" + ATIM.Text, FDS3)
                SAJIA = FDS3.Tables(0).Rows(0)(0)

            Else  ' εντελως για πρωτη φορά


                If Val(mPOS.Text) <> 0 Then



                    sql = "INSERT INTO EGGTIM (KODE,POSO,TIMM,NATIM,NMHX,KODPEL,ONO) VALUES ('" + MBARCODE.Text + "'," + Replace(mPOS.Text, ",", ".") + "," + Replace(MLTI.Text, ",", ".") + "," + Str(Val(ATIM.Text)) + "," + Str(AAMHX) + ",'" + KODPEL + "','" + MKOD.Text + "')"
                    Try
                        n = ExecuteSQL(sql)
                        ListBox1.Items.Insert(0, Mid(MKOD.Text, 1, 25) + " " + mPOS.Text)

                        'ajia.Text = Format(SAJIA, "#####.00")
                    Catch ex As Exception
                        ListBox1.Items.Add("ΛΑΘΟΣ " & ex.Message)
                    End Try
                    ' SAJIA = SAJIA + Val(mPOS.Text) * Val(MLTI.Text)
                    SAJIA = SAJIA + Val(Replace(mPOS.Text, ",", ".")) * Val(Replace(MLTI.Text, ",", "."))
                End If  ' Val(mPOS.Text) <> 0 Then


            End If  '' εντελως για πρωτη φορά

            ajia.Text = Format(SAJIA, "#####.00")
            ' ListBox1.Items.Add(Mid(MONO.Text, 1, 10) + " " + mPOS.Text)

            mPOS.Text = ""
            MBARCODE.Text = ""
            MBARCODE.Focus()
            '  Barcode1.EnableScanner = True
        End If  'If e.KeyCode = 13 And Len(Trim(MBARCODE.Text)) > 0 Then
    End Sub

    Private Sub mPOS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mPOS.LostFocus
        mPOS.BackColor = Color.White
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mPOS.TextChanged

    End Sub

    Private Sub mAFM_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mAFM.GotFocus
        mAFM.BackColor = Color.Yellow
    End Sub

    Private Sub mAFM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mAFM.KeyUp
        Dim FDS2 As New System.Data.DataSet
        Dim k As Long
        Dim N As Long
        If e.KeyCode = 13 Then



            If InStr("1234567890", Mid(mAFM.Text, 1, 1)) > 0 Then  ' ΑΡΙΘΜΗΤΙΚΑ ΨΗΦΙΑ
                If Len(mAFM.Text) = 9 Then
                    k = open2SQL("SELECT * FROM PEL WHERE AFM='" + mAFM.Text + "'", FDS2)
                Else
                    k = open2SQL("SELECT * FROM PEL WHERE KOD='" + mAFM.Text + "'", FDS2)
                End If
                ''=====================================================
                If FDS2.Tables(0).Rows.Count = 1 Then
                    '    For N = 0 To FDS2.Tables(0).Rows.Count - 1
                    Me.Text = FDS2.Tables(0).Rows(0).Item("EPO").ToString
                    ListBox1.Items.Add(FDS2.Tables(0).Rows(0).Item("EPO").ToString)
                    mAFM.Text = FDS2.Tables(0).Rows(0).Item("KOD").ToString + ";" + FDS2.Tables(0).Rows(0).Item("AFM").ToString
                    N = ExecuteSQL("INSERT INTO TIM (NATIM,KPE,NMHX,EPO) VALUES (" + ATIM.Text + ",'" + FDS2.Tables(0).Rows(0).Item("KOD").ToString + "'," + Str(AAMHX) + ",'" + FDS2.Tables(0).Rows(0).Item("EPO").ToString + "')")
                    mAFM.Enabled = False
                    MBARCODE.Focus()
                    '+ "  " + FDS2.Tables(0).Rows(N).Item("S").ToString + "  " + FDS2.Tables(0).Rows(N).Item("RAFI").ToString)
                    ' Me.Text = Format(N, "#####")
                ElseIf FDS2.Tables(0).Rows.Count = 0 Then
                    MsgBox("ΔΕΝ ΒΡΕΘΗΚΕ")
                Else  ' > 1
                    MsgBox("ΒΡΕΘΗΚAN ME TA IΔIA ΣTOIXEIA")
                End If
                '=====================================================


            Else  'InStr("1234567890", Mid(mAFM.Text, 1)) > 0 Then  ' ΑΡΙΘΜΗΤΙΚΑ ΨΗΦΙΑ ' ΟΝΟΜΑ
                Dim mafm2 As String
                mafm2 = Replace(mAFM.Text, "*", "%")

                ' If InStr(mAFM.Text, "*") > 0 Then  ' ΑΡΙΘΜΗΤΙΚΑ ΨΗΦΙΑ
                k = open2SQL("SELECT * FROM PEL WHERE EPO LIKE '" + mafm2 + "%' ", FDS2)
                'End If ' If InStr("1234567890", Mid(mAFM.Text, 1)) > 0 Then  ' ΑΡΙΘΜΗΤΙΚΑ ΨΗΦΙΑ
                Dim CC As String
                For k = 0 To FDS2.Tables(0).Rows.Count - 1
                    CC = Mid(FDS2.Tables(0).Rows(k).Item("EPO").ToString + Space(50), 1, 50)
                    ListBox1.Items.Add(CC + FDS2.Tables(0).Rows(k).Item("KOD").ToString)
                Next
            End If  ''InStr("1234567890", Mid(mAFM.Text, 1)) > 0 Then  ' ΑΡΙΘΜΗΤΙΚΑ ΨΗΦΙΑ ' ΟΝΟΜΑ

        End If ' ECODE=13


    End Sub

    Private Sub mAFM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mAFM.TextChanged

    End Sub

    Private Function open2SQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

        Dim fobjcon As SqlCeConnection, fobjcmd As New SqlCeCommand

        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlCeDataAdapter

        fobjcon = New SqlCeConnection("Data Source ='My Documents\AAACE.SDF';")
        'fobjcmd = New SqlCeCommand(sql, fobjcon) 
        'fobjcmd.Connection.Open()

        fobjcmd = New SqlCeCommand(sql, fobjcon)
        fobjcmd.Connection.Open()
        FDA.SelectCommand = fobjcmd
        FDS.Clear()
        FDA.Fill(FDS)
        fobjcon.Close()



    End Function

    






    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click

        Dim n As Integer


        n = ExecuteSQL("UPDATE PARASTAT SET ARITMISI=ARITMISI+1 WHERE ID=1")

        Dim FDS2 As New System.Data.DataSet
        Dim k As Long


        SAJIA = 0
        k = open2SQL("SELECT ARITMISI FROM PARASTAT WHERE ID=1", FDS2)


        ATIM.Text = FDS2.Tables(0).Rows(0).Item(0).ToString
        ListBox1.Items.Clear()

        mAFM.Enabled = True
        mAFM.Text = ""
        mAFM.Focus()









    End Sub

    Sub WRITE_EGGTIM2()

        Dim ONOMA As String



        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long


        Dim remote As Integer = 0
        Dim line As String = ""
        If File.Exists("My Documents\config2.ini") Then
            Using sr As StreamReader = New StreamReader("My Documents\config2.ini", System.Text.Encoding.Default)
                COUNTER = 0

                Do
                    line = sr.ReadLine()
                    remote = 1
                    Exit Do
                Loop Until line Is Nothing

            End Using
        End If

        Dim mPath As String
        If remote = 1 Then
            mPath = line
        Else
            mPath = "My Documents"
        End If

        If Not File.Exists(mPath + "\EGGTIM2.TXT") Then
            sw = New StreamWriter(mPath + "\EGGTIM2.TXT")
            sw.WriteLine("  ")
        Else
            ' This text is always added, making the file longer over time
            ' if it is not deleted.
            ' sw = File.AppendText("My Documents\EGGTIM2.TXT")
            sw = File.CreateText(mPath + "\EGGTIM2.TXT")
        End If
















        'If Not File.Exists("My Documents\EGGTIM2.TXT") Then
        '    sw = New StreamWriter("My Documents\EGGTIM2.TXT")
        '    sw.WriteLine("  ")
        'Else
        '    ' This text is always added, making the file longer over time
        '    ' if it is not deleted.
        '    ' sw = File.AppendText("My Documents\EGGTIM2.TXT")
        '    sw = File.CreateText("My Documents\EGGTIM2.TXT")
        'End If
        Dim K As Long
        'SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        ' For K = 0 To DS.Tables("Edit").Rows.Count - 1
        ' SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        'SQL = SQL + Format(Val(atim.Text), "00000") + "','" + Format(Now, "MM/dd/yyyy") + "','" + KOD + "','" + ONO + "'," + mTIMM + "," + mPOSO + "," + mEKPT + "," + FPA.Text + ")"
        'N = ExecuteSQL(SQL)






        objcon = New SqlCeConnection("Data Source ='My Documents\AAACE.SDF';")
        objcmd = New SqlCeCommand("select G.*,D.ONO AS NAME,P.EPO,P.AFM from EGGTIM G INNER JOIN EID D ON D.KOD=G.ONO INNER JOIN PEL P ON G.KODPEL=P.KOD ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        ' DataGrid1.DataSource = DS.Tables(0)
        Dim atim, kode, poso, KPE As String
        Dim TIMM As String
        Dim EPO As String = mAFM.Text
        Dim EIDOS As String
        Dim AFM As String



        For K = 0 To DS.Tables(0).Rows.Count - 1
            SEIRA = Space(100)
            atim = DS.Tables(0).Rows(K).Item("nATIM").ToString
            EPO = DS.Tables(0).Rows(K).Item("EPO").ToString

            AFM = DS.Tables(0).Rows(K).Item("AFM").ToString

            kode = DS.Tables(0).Rows(K).Item("KODE").ToString
            ONOMA = DS.Tables(0).Rows(K).Item("ONO").ToString
            EIDOS = DS.Tables(0).Rows(K).Item("NAME").ToString
            TIMM = Replace(DS.Tables(0).Rows(K).Item("timm").ToString, ".", ",")
            KPE = DS.Tables(0).Rows(K).Item("KODPEL").ToString
            ' Mid(SEIRA, fCOLS(4, 1), fCOLS(4, 2)) = DS.Tables(0).Rows(K).Item("ONO").ToString

            ' Mid(SEIRA, fCOLS(5, 1), fCOLS(5, 2)) = DS.Tables(0).Rows(K).Item("TIMM").ToString
            poso = Replace(Format(DS.Tables(0).Rows(K).Item("POSO"), "#####.00"), ".", ",")
            'Mid(SEIRA, fCOLS(7, 1), fCOLS(7, 2)) = DS.Tables(0).Rows(K).Item("EKPT").ToString

            'Mid(SEIRA, fCOLS(8, 1), fCOLS(8, 2)) = DS.Tables(0).Rows(K).Item("FPA").ToString
            'Mid(SEIRA, fCOLS(9, 1), fCOLS(9, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            'Mid(SEIRA, fCOLS(10, 1), fCOLS(10, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            sw.WriteLine(Format(Now, "dd/MM/yyyy") + ";" + EPO + ";" + AFM + ";" + atim + ";" + kode + ";" + EIDOS + ";" + poso + ";" + TIMM + ";" + ";" + Trim(KPE) + ";" + Trim(ONOMA) + ";" + Format(Now, "dd/MM/yyyy"))

        Next
        sw.Close()

        MsgBox("ok")

        'Try
        '    File.Delete(GEGGTIMPATH) 'ΣΒΗΝΩ ΤΟ ΠΑΛΙΌ
        '    File.Copy("My Documents\EGGTIM2.TXT", GEGGTIMPATH)
        'Catch ex As Exception

        'End Try















    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click

        Dim ONOMA As String

        If File.Exists("My Documents\BARAN.TXT") Then
            WRITE_EGGTIM2()
            Exit Sub
        End If

        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long

        Dim remote As Integer = 0
        Dim line As String = ""
        If File.Exists("My Documents\config2.ini") Then
            Using sr As StreamReader = New StreamReader("My Documents\config2.ini", System.Text.Encoding.Default)
                COUNTER = 0

                Do
                    line = sr.ReadLine()
                    remote = 1
                    Exit Do
                Loop Until line Is Nothing

            End Using
        End If

        Dim mPath As String
        If remote = 1 Then
            mPath = line
        Else
            mPath = "My Documents"
        End If



        Try
            If Not File.Exists(mPath + "\EGGTIM2.TXT") Then
                sw = New StreamWriter(mPath + "\EGGTIM2.TXT")
                sw.WriteLine("  ")
            Else
                ' This text is always added, making the file longer over time
                ' if it is not deleted.
                ' sw = File.AppendText("My Documents\EGGTIM2.TXT")
                sw = File.CreateText(mPath + "\EGGTIM2.TXT")
            End If

        Catch ex As Exception
            MsgBox("ΘΑ ΓΡΑΦΕΙ ΤΟΠΙΚΑ")
            mPath = "My Documents"
            If Not File.Exists(mPath + "\EGGTIM2.TXT") Then
                sw = New StreamWriter(mPath + "\EGGTIM2.TXT")
                sw.WriteLine("  ")
            Else
                ' This text is always added, making the file longer over time
                ' if it is not deleted.
                ' sw = File.AppendText("My Documents\EGGTIM2.TXT")
                sw = File.CreateText(mPath + "\EGGTIM2.TXT")
            End If

        End Try












        Dim K As Long
        'SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        ' For K = 0 To DS.Tables("Edit").Rows.Count - 1
        ' SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        'SQL = SQL + Format(Val(atim.Text), "00000") + "','" + Format(Now, "MM/dd/yyyy") + "','" + KOD + "','" + ONO + "'," + mTIMM + "," + mPOSO + "," + mEKPT + "," + FPA.Text + ")"
        'N = ExecuteSQL(SQL)






        objcon = New SqlCeConnection("Data Source ='My Documents\AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from EGGTIM WHERE POSO>0 ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        ' DataGrid1.DataSource = DS.Tables(0)
        Dim atim, kode, poso, KPE As String
        Dim TIMM As String
        For K = 0 To DS.Tables(0).Rows.Count - 1
            SEIRA = Space(100)
            atim = DS.Tables(0).Rows(K).Item("nATIM").ToString

            kode = DS.Tables(0).Rows(K).Item("KODE").ToString
            ONOMA = DS.Tables(0).Rows(K).Item("ONO").ToString
            TIMM = Replace(DS.Tables(0).Rows(K).Item("timm").ToString, ".", ",")
            KPE = DS.Tables(0).Rows(K).Item("KODPEL").ToString
            ' Mid(SEIRA, fCOLS(4, 1), fCOLS(4, 2)) = DS.Tables(0).Rows(K).Item("ONO").ToString

            ' Mid(SEIRA, fCOLS(5, 1), fCOLS(5, 2)) = DS.Tables(0).Rows(K).Item("TIMM").ToString
            poso = Replace(Format(DS.Tables(0).Rows(K).Item("POSO"), "#####.00"), ".", ",")
            'Mid(SEIRA, fCOLS(7, 1), fCOLS(7, 2)) = DS.Tables(0).Rows(K).Item("EKPT").ToString

            'Mid(SEIRA, fCOLS(8, 1), fCOLS(8, 2)) = DS.Tables(0).Rows(K).Item("FPA").ToString
            'Mid(SEIRA, fCOLS(9, 1), fCOLS(9, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            'Mid(SEIRA, fCOLS(10, 1), fCOLS(10, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            sw.WriteLine(Str(AAMHX) + ";" + atim + ";" + kode + ";" + poso + ";" + TIMM + ";" + ";" + Trim(KPE) + ";" + Trim(ONOMA) + ";" + Format(Now, "dd/MM/yyyy"))

        Next
        sw.Close()

        MsgBox("ok")




    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        ' DIORTOSI
        Dim FDS2 As New System.Data.DataSet
        Dim k As Long
        Dim N As Long

        k = open2SQL("SELECT * FROM EGGTIM ORDER BY NATIM DESC ", FDS2)
        If FDS2.Tables(0).Rows.Count = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΟΥΝ ΕΓΓΡΑΦΕΣ")
            Exit Sub
        End If


        ATIM.Text = FDS2.Tables(0).Rows(k).Item("nATIM").ToString

        
        mAFM.Text = FDS2.Tables(0).Rows(k).Item("KODPEL").ToString


        If Len(mAFM.Text) = 9 Then
            k = open2SQL("SELECT * FROM PEL WHERE AFM='" + mAFM.Text + "'", FDS2)
        Else
            k = open2SQL("SELECT * FROM PEL WHERE KOD='" + mAFM.Text + "'", FDS2)
        End If
        If FDS2.Tables(0).Rows.Count = 1 Then
            '    For N = 0 To FDS2.Tables(0).Rows.Count - 1
            Me.Text = FDS2.Tables(0).Rows(0).Item("EPO").ToString
            ListBox1.Items.Add(FDS2.Tables(0).Rows(0).Item("EPO").ToString)
            mAFM.Text = FDS2.Tables(0).Rows(0).Item("KOD").ToString + ";" + FDS2.Tables(0).Rows(0).Item("AFM").ToString
            ' N = ExecuteSQL("INSERT INTO TIM (NATIM,KPE,NMHX,EPO) VALUES (" + ATIM.Text + ",'" + FDS2.Tables(0).Rows(0).Item("KOD").ToString + "'," + Str(AAMHX) + ",'" + FDS2.Tables(0).Rows(0).Item("EPO").ToString + "')")
            mAFM.Enabled = False




            MBARCODE.Focus()

            '+ "  " + FDS2.Tables(0).Rows(N).Item("S").ToString + "  " + FDS2.Tables(0).Rows(N).Item("RAFI").ToString)
            ' Me.Text = Format(N, "#####")
        ElseIf FDS2.Tables(0).Rows.Count = 0 Then
            MsgBox("ΔΕΝ ΒΡΕΘΗΚΕ")
        Else  ' > 1
            MsgBox("ΒΡΕΘΗΚAN ME TA IΔIA ΣTOIXEIA")
        End If

        k = open2SQL("SELECT SUM(POSO*TIMM) AS S  FROM EGGTIM  WHERE NATIM=" + ATIM.Text, FDS2)

        SAJIA = Val(FDS2.Tables(0).Rows(0).Item("S").ToString)

        ajia.Text = Format(SAJIA, "######0.00")



    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim CC As String
        If mAFM.Enabled = False Then
            Exit Sub
        End If



        CC = Mid(ListBox1.SelectedItem.ToString, 51, 4)
        mAFM.Text = CC
        mAFM.Focus()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As String
        Dim DS As New System.Data.DataSet
        'Dim DA As New SqlDataAdapter






        'ΟΤΑΝ ΤΡΕΧΩ EXECUTE SQL STRING P.X. UPDATE EGGTIM SET ....TO K=0 KAI DEN YPARXEI TABLES(0) ΚΑΘΟΛΟΥ
        'ΟΤΑΝ ΤΡΕΧΩ SELECT
        'For K = 0 To DS.Tables(0).Rows.Count - 1
        ' atim = DS.Tables(0).Rows(k).Item("ATIM").ToString
        'Next k
        Dim k As Integer = open3SQL("UPDATE EGGTIM SET APOT=33 ", DS)

        Dim atim As String

        For k = 0 To DS.Tables(0).Rows.Count - 1
            'SEIRA = Space(100)
            atim = DS.Tables(0).Rows(k).Item("ATIM").ToString

        Next k


    End Sub



    Private Function open3SQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

        Dim fobjcon As SqlConnection, fobjcmd As New SqlCommand
        Dim c As String = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlDataAdapter

        fobjcon = New SqlConnection(c)
        'fobjcmd = New SqlCeCommand(sql, fobjcon)
        'fobjcmd.Connection.Open()

        fobjcmd = New SqlCommand(sql, fobjcon)
        fobjcmd.Connection.Open()
        FDA.SelectCommand = fobjcmd
        FDS.Clear()
        FDA.Fill(FDS)
        fobjcon.Close()



    End Function




    Private Sub Label2_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.ParentChanged

    End Sub

    Private Sub ATIM_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATIM.ParentChanged

    End Sub
End Class