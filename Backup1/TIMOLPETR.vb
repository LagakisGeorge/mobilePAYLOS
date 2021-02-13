Imports System.Data.SqlServerCe
Imports System.IO






Public Class TIMOLPETR
    Inherits System.Windows.Forms.Form




    Dim Fobjcon As SqlCeConnection
    Dim Fobjcmd As New SqlCeCommand
    Dim FDS As New System.Data.DataSet
    Dim FDA As New SqlCeDataAdapter

    Dim FEIDOS(30) As String ' TO XARAKTIRISTIKO GRAMMA GIA KATHE PARASTATIKO P.X. 'T' GIA TIM.POL-DA
    Dim FEIDOS_SELECTED As String ' TO XARAKTIRISTIKO GRAMMA GIA KATHE PARASTATIKO ΠΟΥ ΕΠΙΛΕΧΘΗΚΕ



    Dim mRow As Integer 'se poia seira briskomai
    Dim Edit As String 'bohuhtiki metabliti gia na kana dataentry me ta buttons
    Dim mFocus As Integer 'poio textbox exei focus
    Dim comm1 As New System.IO.Ports.SerialPort


    Dim fCOLS(20, 2) As Long

    '-----------    GLOBAL ΜΕΤΑΒΛΗΤΕΣ  ----------------
    Dim gm_str(250) As String ' OLES OI SEIRES TOY F90.TXT
    Dim gpic(250) As String  ' το στρινγκ του πεδίου
    Dim gm_r(250) As Long, gm_c(250) As Long ' σειρά και στήλη του πεδίου
    Dim gm_f(250) As String

    Private Sub TIMOLPETR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Dim ANS As Integer
        ANS = MsgBox("ΝΑ ΞΑΝΑΤΥΠΩΣΩ ΤΟ ΤΙΜΟΛΟΓΙΟ ;", MsgBoxStyle.YesNo)
        If ANS = vbYes Then
            EKTYP_TIMOL()
        End If
    End Sub ' το όνομα του πεδίου










    '  Public Class SendKeys
    'Visual Basic (Usage)
    'Dim sendk As SendKeys










    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'AaaDataSet1.EDIT' table. You can move, or remove it, as needed.
        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        Fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")

        'GEMIZO TO COMBOBOX ME TA PARASTATIKA
        Fobjcmd = New SqlCeCommand("SELECT * FROM PARASTAT", Fobjcon)
        Fobjcmd.Connection.Open()
        FDA.SelectCommand = Fobjcmd
        FDS.Clear()
        FDA.Fill(FDS, "P")
        Dim K As Integer
        ComboBox1.Items.Clear()
        For K = 0 To FDS.Tables("P").Rows.Count - 1
            ComboBox1.Items.Add(FDS.Tables("P").Rows(K).Item("PERIGRAFH"))
            FEIDOS(K) = FDS.Tables("P").Rows(K).Item("EIDOS").ToString
        Next






        mRow = 1
        mFocus = 0


        'fortono tis sthles toy ascii exagogis ton parastatikon (eggtim)
        'IMPORT EIDON

        Dim COUNTER As Integer


        If Not File.Exists("EGGTIMCOLS.TXT") Then

            Using sw As StreamWriter = New StreamWriter("EGGTIMCOLS.TXT")
                sw.WriteLine("1,6    AR.TIMOL")
                sw.WriteLine("8,10   HMEPOMHNIA")
                sw.WriteLine("20,14   KODIKOS EIDOYS")
                sw.WriteLine("35,30   ONOMASIA EIDOYS")
                sw.WriteLine("66,10   TIMH MONADOS")
                sw.WriteLine("77,10   POSOTHTA")
                sw.WriteLine("88,5   EKPTOSI % ")
                sw.WriteLine("96,3   FPA")
                sw.WriteLine("100,6   KODIKOS PELATH")
                sw.WriteLine("110,4   TROPOS PLIROMIS")
                sw.WriteLine("114,8   EPIDOTHSH PETRELAIOY")

                sw.Close()
            End Using

        End If
        Using sr As StreamReader = New StreamReader("EGGTIMCOLS.TXT", System.Text.Encoding.Default)
            COUNTER = 0
            Dim COMA As Integer
            Dim line As String
            Do
                line = sr.ReadLine()
                COMA = InStr(line, ",")
                If COMA > 0 Then
                    COUNTER = COUNTER + 1
                    fCOLS(COUNTER, 1) = Val(Mid(line, 1, COMA - 1))
                    fCOLS(COUNTER, 2) = Val(Mid(line, COMA + 1, 2))
                End If
            Loop Until line Is Nothing
        End Using
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EIDOS.Click

    End Sub
    Private Sub BRES_EIDOS()
        Dim FlagONOMA As Boolean
        FlagONOMA = False

        '  If mRow >= 1 Then
        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        If Len(ONO_POSO.Text) > 0 Then
            SQL = "select * from EID WHERE ONO LIKE '" + ONO_POSO.Text + "%'"
            FlagONOMA = False
        Else
            SQL = "select * from EID WHERE KOD='" + MKOD.Text + "'"
        End If

        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()

        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "EID")
        If DS.Tables("eid").Rows.Count = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΟ ΕΙΔΟΣ")
            objcmd.Connection.Close()
            Exit Sub

        End If


        Dim K As Long

        If FlagONOMA = False Then
            'περνάω τον κωδικό και το όνομα στο grid
            objcmd = New SqlCeCommand("UPDATE EDIT SET kod='" + DS.Tables("eid").Rows(0).Item("kod") + "',ono='" + DS.Tables("eid").Rows(0).Item("ono") + "' WHERE ID=" + Format(mRow, "###0"), objcon)
            objcmd.ExecuteNonQuery()
            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            DataGrid1.Refresh()
            TIMH.Text = Format(DS.Tables("eid").Rows(K).Item("lti"), "##0.00")
            FPA.Text = DS.Tables("eid").Rows(K).Item("FPA").ToString
            MON.Text = DS.Tables("eid").Rows(K).Item("MON").ToString

            If mRow > 0 Then DataGrid1.Select(mRow - 1)
            If mRow > 1 Then
                If mRow = 4 Then
                    DataGrid1.CurrentRowIndex = 3
                ElseIf mRow = 5 Then
                    DataGrid1.CurrentRowIndex = 4
                ElseIf mRow <= 3 Then
                    DataGrid1.CurrentRowIndex = mRow - 1
                Else
                    DataGrid1.CurrentRowIndex = mRow - 2
                End If
            End If


            ONO_POSO.Focus()


        Else
            ListBox1.Items.Clear()
            ListBox1.Visible = True
            For K = 0 To DS.Tables("EID").Rows.Count - 1
                ListBox1.Items.Add(Format(K, "##0") + DS.Tables("eid").Rows(K).Item("kod") + " " + DS.Tables("eid").Rows(K).Item("ONO"))
            Next
            objcmd.Connection.Close()
        End If
        '       End If
        Edit = ""

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        'ΒΛΕΠΩ ΠΟΙΑ ΣΕΙΡΑ  ΠΑΤΗΣΕ ΣΤΟ GRID
        mRow = DataGrid1.CurrentCell.RowNumber + 1
        If mRow > 0 Then DataGrid1.Select(mRow - 1)


    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEL.Click

        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        ListBox1.Items.Clear()


        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        If Len(ONO_POSO.Text) > 0 Then
            SQL = "select * from PEL WHERE EPO LIKE '" + ONO_POSO.Text + "%'"
        Else
            SQL = "select * from PEL WHERE KOD='" + MKOD.Text + "'"
        End If

        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()

        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "PEL")
        Dim K As Long
        Dim S As String = ""
        For K = 0 To DS.Tables("PEL").Rows.Count - 1
            S = ""
            S = S + DS.Tables("PEL").Rows(K).Item("kod") + "*"   'Format(K, "000") + "-" +
            S = S + DS.Tables("PEL").Rows(K).Item("EPO")
            ListBox1.Items.Add(S)
        Next

        'AN BRHKE ENAN OLO KAI OLO PROXORA PARAKATO
        If ListBox1.Items.Count = 1 Then
            Label2.Text = ListBox1.Items(0).ToString
            ListBox1.Visible = False
            PEL.Visible = False
            Dim n As Long
            n = ExecuteSQL("UPDATE EDIT SET POSO=0,kod='',ono='',timm=0,ekpt=0")

            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            Label3.Text = "Κωδ.Ειδ"
            Label4.Text = " "

            DataGrid1.Refresh()
            MKOD.Text = "8888"

            BRES_EIDOS()
            ONO_POSO.Text = ""
            ONO_POSO.Focus()

        End If

        objcmd.Connection.Close()




    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        If Len(Label2.Text) = 0 Then ' ΕΧΕΙ ΒΡΕΙ ΠΕΛΑΤΗ 
            Label2.Text = ListBox1.SelectedItem.ToString
            ListBox1.Visible = False
            PEL.Visible = False
            Dim n As Long
            n = ExecuteSQL("UPDATE EDIT SET POSO=0,kod='',ono='',timm=0,ekpt=0")

            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            Label3.Text = "Κωδ.Ειδ"
            Label4.Text = " "

            DataGrid1.Refresh()
            MKOD.Text = "8888"

            BRES_EIDOS()
            ONO_POSO.Text = ""
            ONO_POSO.Focus()
        Else  'ΚΑΙ ΠΑΜΕ ΓΙΑ ΕΙΔΟΣ
            Dim k As Long
            k = ExecuteSQL("UPDATE EDIT SET kod='" + Mid(ListBox1.SelectedItem.ToString, 1, 4) + "',ono='" + Mid(ListBox1.SelectedItem.ToString, 5, 24) + "' WHERE ID=" + Format(mRow, "###0"))

            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            ' DataGrid1.Refresh()

        End If

    End Sub

    Private Sub MKOD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MKOD.GotFocus
        MKOD.BackColor = Color.Yellow
        If mFocus <> 1 Then
            mFocus = 1
            Edit = MKOD.Text
        End If
    End Sub

    Private Sub MKOD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MKOD.LostFocus
        MKOD.BackColor = Color.White
    End Sub

    Private Sub N_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ONO_POSO.GotFocus
        ONO_POSO.BackColor = Color.Yellow

        If mFocus <> 2 Then
            mFocus = 2
            Edit = ONO_POSO.Text
        End If

    End Sub
    Private Sub N_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ONO_POSO.LostFocus
        ONO_POSO.BackColor = Color.White
    End Sub

    Private Sub TIMH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.GotFocus
        TIMH.BackColor = Color.Yellow
        If mFocus <> 3 Then
            mFocus = 3
            Edit = TIMH.Text
        End If

    End Sub

    Private Sub TIMH_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.LostFocus
        TIMH.BackColor = Color.White
    End Sub




    Private Sub EKPT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EKPT.GotFocus
        EKPT.BackColor = Color.Yellow
        If mFocus <> 4 Then
            mFocus = 4
            Edit = EKPT.Text
        End If

    End Sub

    Private Sub EKPT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EKPT.LostFocus
        EKPT.BackColor = Color.White

    End Sub

    Private Sub NEO_EIDOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEO_EIDOS.Click
        Dim n As Long
        Dim SQL As String

        If Len(EKPT.Text) = 0 Then EKPT.Text = "0"
        If Len(ONO_POSO.Text) = 0 Then ONO_POSO.Text = "0"
        If Len(TIMH.Text) = 0 Then TIMH.Text = "0"


        SQL = "UPDATE EDIT SET POSO=" + Replace(ONO_POSO.Text, ",", ".")
        SQL = SQL + ",TIMM=" + Replace(TIMH.Text, ",", ".")
        SQL = SQL + ",EKPT=" + Replace(EKPT.Text, ",", ".")
        SQL = SQL + ",FPA=" + Replace(FPA.Text, ",", ".")
        SQL = SQL + ",MON='" + MON.Text + "' "
        SQL = SQL + " WHERE ID=" + Format(mRow, "#0")
        n = ExecuteSQL(SQL)

        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        'gia na mporo na blepo ti grafo
        '  DataGrid1.CurrentRowIndex = mRow - 1

        If mRow < 15 Then
            mRow = mRow + 1
        End If
        If mRow > 0 Then
            DataGrid1.Select(mRow - 1)
        End If

        Fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        'Dim SQL As String
        SQL = "select SUM(POSO*TIMM*(100-EKPT)/100*(1+FPA/100)) as SUMA from EDIT "
        Fobjcmd = New SqlCeCommand(SQL, Fobjcon)
        Fobjcmd.Connection.Open()
        FDA.SelectCommand = Fobjcmd
        FDS.Clear()
        FDA.Fill(FDS, "EDIT2")


        Dim SAJIA As Single
        SAJIA = 0
        ' K = FDS.Tables("EDIT2").Rows.Count - 1
        SAJIA = Val(Replace(FDS.Tables("EDIT2").Rows(0).Item(0).ToString, ",", "."))

        AJIA.Text = Format(SAJIA, "####0.00")
        Fobjcon.Close()


        If mRow > 1 Then DataGrid1.CurrentRowIndex = mRow - 2







        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""
        MKOD.Focus()
        Edit = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim c As String



        ListBox1.Items.Clear()


        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        SQL = "select * from EDIT where POSO<>0"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "EDIT")
        Dim K As Long, N As Long
        Dim KOD As String, ONO As String, mPOSO As String
        Dim mTIMM As String, mEKPT As String


        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        If Not File.Exists("EGGTIM.TXT") Then
            sw = New StreamWriter("EGGTIM.TXT")
        Else
            ' This text is always added, making the file longer over time
            ' if it is not deleted.
            sw = File.AppendText("EGGTIM.TXT")
        End If

        For K = 0 To DS.Tables("EDIT").Rows.Count - 1
            KOD = DS.Tables("EDIT").Rows(K).Item("kod")
            ONO = DS.Tables("EDIT").Rows(K).Item("ONO")
            mPOSO = Replace(DS.Tables("EDIT").Rows(K).Item("POSO"), ",", ".")
            mTIMM = Replace(DS.Tables("EDIT").Rows(K).Item("TIMM"), ",", ".")
            mEKPT = Replace(DS.Tables("EDIT").Rows(K).Item("ekpt"), ",", ".")

            If Val(mPOSO) > 0 Then
                SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA,N1) VALUES ('"
                SQL = SQL + Format(Val(atim.Text), "00000") + "','" + Format(Now, "MM/dd/yyyy") + "','" + KOD + "','" + ONO + "'," + mTIMM + "," + mPOSO + "," + mEKPT + "," + FPA.Text + "," + Format(Val(mPOSO) * 0.272, "####.000") + ")"
                N = ExecuteSQL(SQL)
                Mid(SEIRA, fCOLS(1, 1), fCOLS(1, 2)) = FEIDOS_SELECTED + Format(Val(atim.Text), "00000")
                Mid(SEIRA, fCOLS(2, 1), fCOLS(2, 2)) = Format(Now, "dd/MM/yyyy")
                Mid(SEIRA, fCOLS(3, 1), fCOLS(3, 2)) = KOD
                Mid(SEIRA, fCOLS(4, 1), fCOLS(4, 2)) = ONO
                Mid(SEIRA, fCOLS(5, 1), fCOLS(5, 2)) = mTIMM
                Mid(SEIRA, fCOLS(6, 1), fCOLS(6, 2)) = mPOSO
                Mid(SEIRA, fCOLS(7, 1), fCOLS(7, 2)) = mEKPT
                Mid(SEIRA, fCOLS(8, 1), fCOLS(8, 2)) = FPA.Text
                Mid(SEIRA, fCOLS(9, 1), fCOLS(9, 2)) = Mid(Label2.Text, 1, 4) 'KODIKOS PELATH
                Mid(SEIRA, fCOLS(10, 1), fCOLS(10, 2)) = Mid(TRP.Text, 1, 3)
                Mid(SEIRA, fCOLS(11, 1), fCOLS(11, 2)) = Format(Val(mPOSO) * 0.272, "####.000") 'EPIDOTHSH

                sw.WriteLine(SEIRA)

            End If
        Next
        sw.Close()

        'End Using



        'εαν είναι τσεκαρισμένη η εκτύπωση
        If ekt.Checked = True Then


            Dim objcon2 As SqlCeConnection
            Dim objcmd2 As New SqlCeCommand



            ListBox1.Items.Clear()


            objcon2 = New SqlCeConnection("Data Source ='AAACE.SDF';")

            'διαβάζω τα πλήρη στοιχεία του πελάτη στο DS2 DATASET
            SQL = "select * from PEL WHERE KOD='" + Mid(Label2.Text, 1, 4) + "'"

            objcmd2 = New SqlCeCommand(SQL, objcon2)
            objcmd2.Connection.Open()
            Dim DS2 As New System.Data.DataSet
            Dim DA2 As New SqlCeDataAdapter
            DA2.SelectCommand = objcmd2
            DA2.Fill(DS2, "PELATHS")


            Dim EPIK, EPAN, SYN As Long
            '  EPIK :ΤΕΛΕΥΤΑΙΟ ΠΕΔΙΟ ΤΩΝ ΕΠΙΚΕΦΑΛΙΔΩΝ
            '  EPAN :ΤΕΛΕΥΤΑΙΟ ΠΕΔΙΟ ΤΩΝ ΓΡΑΜΜΩΝ ΠΟΥ ΕΠΑΝΑΛΑΜΒΑΝΟΝΤΑΙ
            '  SYN :ΤΕΛΕΥΤΑΙΟ ΠΕΔΙΟ ΤΩΝ ΣΥΝΟΛΩΝ
            load_forma("F91.TXT", 0, EPIK, EPAN, SYN)


            Dim I As Long

            For I = 1 To 200
                If Mid(gm_str(I), 1, 10) = "**********" Then
                    Exit For
                End If
            Next


            '* ΣΥΝΟΛΙΚΕΣ ΣΕΙΡΕΣ
            Dim m_No_of_seir As Long = Val(gm_str(I + 1))

            '* ΣΕΙΡΑ ΠΟΥ ΑΡΧΙΖΟΥΝ ΤΑ ΕΙΔΗ
            Dim m_seir_eid As Long = Val(gm_str(I + 2))

            '* ΣΕΙΡΑ ΠΟΥ ΑΡΧΙΖΟΥΝ ΤΑ ΣΥΝΟΛΑ
            Dim m_seir_synol As Long = Val(gm_str(I + 3))

            'ΒΡΙΣΚΩ ΠΟΣΑ ΠΕΔΙΑ ΤΥΠΩΝΟΝΤΑΙ ΣΤΗΝ ΕΠΙΚΕΦΑΛΙΔΑ ,
            'ΣΤΟ ΕΠΑΝΑΛΑΜΒΑΝΟΜΕΝΟ ΤΜΗΜΑ ΚΑΙ ΣΤΑ 
            'ΣΥΝΟΛΑ

            Dim L As Long



            Dim PEDIA(200) As String
            PEDIA(1) = DS2.Tables("PELATHS").Rows(0).Item("kod")
            PEDIA(2) = DS2.Tables("PELATHS").Rows(0).Item("EPO")
            PEDIA(3) = DS2.Tables("PELATHS").Rows(0).Item("DIE")
            ' PEDIA(4) = DS2.Tables("PELATHS").Rows(0).Item("POL")
            PEDIA(5) = DS2.Tables("PELATHS").Rows(0).Item("EPA")
            PEDIA(6) = DS2.Tables("PELATHS").Rows(0).Item("AFM")
            PEDIA(7) = DS2.Tables("PELATHS").Rows(0).Item("DOY")
            PEDIA(8) = DS2.Tables("PELATHS").Rows(0).Item("DEH")

            PEDIA(20) = ComboBox1.Text 'PARASTATIKO
            PEDIA(21) = Format(Now, "dd/MM/yyyy") 'HMERA
            PEDIA(22) = Format(Now, "HH:MM") 'ORA
            PEDIA(23) = TRP.Text  'TROPOS PLIROMHS
            PEDIA(24) = atim.Text  'ARITMOS TIMOLOGIOY

            Dim TREXOYSA As Long = gm_r(1)
            Dim StrSeira As String
            Dim N0 As Long

            N0 = ExecuteSQL("DELETE FROM  MEM ")


            StrSeira = Space(100)
            ' Dim sw2 As StreamWriter = New StreamWriter("TIMOLOGIO.TXT")
            '     sw.WriteLine("110,4   TROPOS PLIROMIS")
            '     sw.Close()
            'End Using
            ''----------- EPIKEFALIDA --------------------------
            For K = 1 To EPIK ' τυπωσε τα πεδία της επικεφαλίδας
                If gm_r(K) > 0 Then 'AN ALLAZEI SEIRA
                    'sw2.WriteLine(StrSeira) 'ΓΡΑΨΕ ΤΗΝ ΣΕΙΡΑ
                    N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                    For L = 1 To gm_r(K) - 1
                        'kateba seires

                        'PREVIOUS  WAS : N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                        N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES (' ')")
                    Next

                    StrSeira = Space(100) 'ΞΕΚΙΝΑΜΕ ΚΑΙΝΟΥΡΙΑ
                End If
                ' τυποσε STHN STHLH GM_C(K) TO :  PEDIA( GM_F(K) )
                If Mid(gm_f(K), 1, 1) = """" Then
                    c = Mid(gm_f(K), 2, Len(gm_f(K)) - 2)
                Else
                    c = Mid(PEDIA(gm_f(K)), 1, Len(gpic(K)))
                End If
                Mid(StrSeira, gm_c(K), Len(c)) = c
            Next
            '   sw2.WriteLine(StrSeira) 'ΓΡΑΨΕ ΤΗΝ ΣΕΙΡΑ
            N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
            '-----------EPANALAMBANOMENH -----------------------ΕΚΤΥΠΩΣΗ
            Dim SKAU As Single = 0
            Dim SFPA As Single = 0
            Dim SEPID As Single = 0
            For K = 0 To DS.Tables("EDIT").Rows.Count - 1
                KOD = DS.Tables("EDIT").Rows(K).Item("kod")
                ONO = DS.Tables("EDIT").Rows(K).Item("ONO")
                mPOSO = Val(Replace(DS.Tables("EDIT").Rows(K).Item("POSO"), ",", "."))
                mTIMM = Val(Replace(DS.Tables("EDIT").Rows(K).Item("TIMM"), ",", "."))
                mEKPT = Val(Replace(DS.Tables("EDIT").Rows(K).Item("ekpt"), ",", "."))
                PEDIA(50) = DS.Tables("EDIT").Rows(K).Item("mon")
                PEDIA(51) = KOD
                PEDIA(52) = ONO
                PEDIA(53) = mPOSO
                PEDIA(54) = mTIMM
                PEDIA(55) = mEKPT
                PEDIA(56) = Replace(DS.Tables("EDIT").Rows(K).Item("FPA"), ",", ".")
                PEDIA(57) = mPOSO * mTIMM * (100 - mEKPT) / 100
                PEDIA(58) = (mPOSO * mTIMM * (100 - mEKPT) / 100) * DS.Tables("EDIT").Rows(K).Item("fpa") / 100
                StrSeira = Space(100) 'ΞΕΚΙΝΑΜΕ ΚΑΙΝΟΥΡΙΑ
                For L = EPIK + 1 To EPAN
                    ' τυποσε STHN STHLH GM_C(K) TO :  PEDIA( GM_F(L) )
                    c = Mid(PEDIA(gm_f(L)), 1, Len(gpic(L))) '+ PEDIA(gm_f(L))
                    Mid(StrSeira, gm_c(L), Len(c)) = c
                Next
                'comm1.Write(KOD + to437(ONO) + Chr(10))
                'sw2.WriteLine(StrSeira) 'ΓΡΑΨΕ ΤΗΝ ΣΕΙΡΑ
                N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                SKAU = SKAU + mPOSO * mTIMM * (100 - mEKPT) / 100
                SEPID = SEPID + mPOSO * 0.272
                SFPA = SFPA + (mPOSO * mTIMM * (100 - mEKPT) / 100) * DS.Tables("EDIT").Rows(K).Item("fpa") / 100
            Next



            'KENA MEXRI TA SYNOLA
            For K = 1 To m_seir_synol - m_seir_eid - DS.Tables("EDIT").Rows.Count
                'sw2.WriteLine("") 'ΓΡΑΨΕ KENH SEIRA
                N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('  ')")
            Next





            '--------------SYNOLA -----------------------

            PEDIA(80) = Format(SKAU, "####0.00") 'kauaro poso
            PEDIA(81) = Format(SFPA, "####0.00") 'fpa
            PEDIA(82) = Format(SKAU + SFPA, "####0.00") 'synolo
            PEDIA(83) = Format(SEPID, "####0.00") 'EPIDOTHSH
            PEDIA(84) = Format(SEPID * 1.19, "####0.00") 'EPIDOTHSH+FPA

            PEDIA(85) = Format(SKAU + SFPA - SEPID * 1.19, "####0.00") 'PLIROTEO


            StrSeira = Space(100) 'ΞΕΚΙΝΑΜΕ ΚΑΙΝΟΥΡΙΑ SEIRA
            For K = EPAN + 1 To SYN ' τυπωσε τα πεδία της επικεφαλίδας
                If gm_r(K) > 0 Then 'AN ALLAZEI SEIRA

                    ' sw2.WriteLine(StrSeira) 'ΓΡΑΨΕ ΤΗΝ ΣΕΙΡΑ
                    N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                    For L = 1 To gm_r(K) - 1
                        'kateba seires
                        ' comm1.Write(" " + Chr(10))
                        ' sw2.WriteLine("") 'ΓΡΑΨΕ KENH SEIRA
                        N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('  ')")
                    Next
                    StrSeira = Space(100) 'ΞΕΚΙΝΑΜΕ ΚΑΙΝΟΥΡΙΑ
                End If
                ' τυποσε STHN STHLH GM_C(K) TO :  PEDIA( GM_F(K) )
                If Mid(gm_f(K), 1, 1) = """" Then
                    c = Mid(gm_f(K), 2, Len(gm_f(K)) - 2)
                Else
                    c = Mid(PEDIA(gm_f(K)), 1, Len(gpic(K)))
                End If
                Mid(StrSeira, gm_c(K), Len(c)) = c

                '  StrSeira = StrSeira + Space(gm_c(K)) + Mid(PEDIA(gm_f(K)), 1, Len(gpic(K))) ' + PEDIA(gm_f(K))
            Next
            'sw2.WriteLine(StrSeira) 'ΓΡΑΨΕ ΤΗΝ ΣΕΙΡΑ
            N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")






            ' sw2.Close() ' TIMOLOGIO
            ' comm1.Close()

            objcmd2.Connection.Close()

            '            Dim LL As Long, L3 As Long

            '           LL = Val(MKOD.Text)

            '          For L3 = 1 To Val(MKOD.Text)








            Dim COMMPORT As String
            Using sr As StreamReader = New StreamReader("PARAMETROI.TXT", System.Text.Encoding.Default)
                COMMPORT = Mid(sr.ReadLine(), 1, 4)
                sr.Close()
            End Using




            'ΑΝΟΙΓΩ ΤΗΝ ΘΥΡΑ ΤΗΝ ΣΕΙΡΙΑΚΗ
            'ΕΠΟΜΕΝΕΣ 7 ΣΕΙΡΕΣ ΔΟΥΛΕΥΟΥΝ ΜΙΑ ΧΑΡΑ ΓΙΑ ΤΟ ΑΝΟΙΓΜΑ
            '   ΓΙΑ ΕΚΤΥΠΩΣΗ comm1.Write(" " + Chr(10)) ΚΑΙ COMM1.CLOSE() KLEINO THN PORTA
            comm1.BaudRate = 9600
            comm1.Parity = Ports.Parity.None
            comm1.PortName = COMMPORT  ' "COM1"
            comm1.DataBits = 8
            'comm1.CtsHolding()
            comm1.Handshake = IO.Ports.Handshake.XOnXOff
            comm1.StopBits = Ports.StopBits.One
            comm1.Encoding = System.Text.Encoding.Default
            comm1.Open()
            comm1.Write(Chr(27) + "C0" + Chr(8))
            Dim LINE As String
            objcmd.Connection.Close()
            objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
            SQL = "select * from MEM"
            objcmd = New SqlCeCommand(SQL, objcon)
            objcmd.Connection.Open()
            DA.SelectCommand = objcmd
            DA.Fill(DS, "MEM")



            For K = 0 To DS.Tables("MEM").Rows.Count - 1
                LINE = DS.Tables("MEM").Rows(K).Item(0)
                LINE = Mid(LINE, 1, 55)
                comm1.Write(to437(LINE) + Chr(10))
            Next
            ' Thread.Sleep(10000)
            System.Threading.Thread.Sleep(1000)


            comm1.Write(Chr(12))
            comm1.Close()




        End If




        Label2.Text = ""
        ListBox1.Visible = True
        PEL.Visible = True

        N = ExecuteSQL("UPDATE EDIT SET POSO=0,kod='',ono='',timm=0,ekpt=0")

        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""



        Edit = ""

        ExecuteSQL("update parastat set aritmisi=aritmisi+1 where id=" + Format(ComboBox1.SelectedIndex + 1, "00"))

        atim.Text = Find_Atim(Format(ComboBox1.SelectedIndex + 1, "00")) + 1

        objcmd.Connection.Close()

        mRow = 1
        MKOD.Focus()


    End Sub
    Private Sub EKTYP_TIMOL()
        'Imports System.IO
        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim SQL As String
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        Dim K As Long



        Dim COMMPORT As String
        Using sr As StreamReader = New StreamReader("PARAMETROI.TXT", System.Text.Encoding.Default)
            COMMPORT = Mid(sr.ReadLine(), 1, 4)
            sr.Close()
        End Using






        'ΑΝΟΙΓΩ ΤΗΝ ΘΥΡΑ ΤΗΝ ΣΕΙΡΙΑΚΗ
        'ΕΠΟΜΕΝΕΣ 7 ΣΕΙΡΕΣ ΔΟΥΛΕΥΟΥΝ ΜΙΑ ΧΑΡΑ ΓΙΑ ΤΟ ΑΝΟΙΓΜΑ
        '   ΓΙΑ ΕΚΤΥΠΩΣΗ comm1.Write(" " + Chr(10)) ΚΑΙ COMM1.CLOSE() KLEINO THN PORTA
        comm1.BaudRate = 9600
        comm1.Parity = Ports.Parity.None
        comm1.PortName = COMMPORT  ' "COM1"
        comm1.DataBits = 8
        'comm1.CtsHolding()
        comm1.Handshake = IO.Ports.Handshake.XOnXOff
        comm1.StopBits = Ports.StopBits.One
        comm1.Encoding = System.Text.Encoding.Default
        comm1.Open()
        comm1.Write(Chr(27) + "C0" + Chr(8))
        Dim LINE As String

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        SQL = "select * from MEM"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()
        DA.SelectCommand = objcmd
        DA.Fill(DS, "MEM")



        For K = 0 To DS.Tables("MEM").Rows.Count - 1
            LINE = DS.Tables("MEM").Rows(K).Item(0)
            LINE = Mid(LINE, 1, 55)
            comm1.Write(to437(LINE) + Chr(10))
        Next
        ' Thread.Sleep(10000)
        System.Threading.Thread.Sleep(1000)


        comm1.Write(Chr(12))
        comm1.Close()

    End Sub
    'Function ExecuteSQL(ByVal sql As String) As Long
    '    Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
    '    objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
    '    objcmd = New SqlCeCommand(sql, objcon)
    '    objcmd.Connection.Open()
    '    ExecuteSQL = objcmd.ExecuteNonQuery()
    '    objcmd.Connection.Close()

    'End Function



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' System.Windows.Forms.ssend()

        Edit = Edit + "7"
        SENDKEY()


    End Sub
    Sub SENDKEY()

        If mFocus = 1 Then
            MKOD.Text = Edit
            MKOD.Focus()
            Exit Sub
        End If

        If mFocus = 2 Then
            ONO_POSO.Text = Edit
            ONO_POSO.Focus()
            Exit Sub
        End If

        If mFocus = 3 Then
            TIMH.Text = Edit
            TIMH.Focus()
            Exit Sub
        End If

        If mFocus = 4 Then
            EKPT.Text = Edit
            EKPT.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Edit = Edit + "8"
        SENDKEY()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Edit = Edit + "9"
        SENDKEY()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Edit = Edit + "4"
        SENDKEY()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Edit = Edit + "5"
        SENDKEY()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Edit = Edit + "6"
        SENDKEY()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Edit = Edit + "1"
        SENDKEY()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Edit = Edit + "2"
        SENDKEY()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Edit = Edit + "3"
        SENDKEY()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Edit = Edit + "0"
        SENDKEY()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Edit = Edit + "."
        SENDKEY()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Len(Edit) > 1 Then
            Edit = Mid(Edit, 1, Len(Edit) - 1)
            SENDKEY()
        Else
            Edit = ""
            SENDKEY()
        End If


    End Sub

    Private Sub EKPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EKPT.TextChanged

    End Sub



    Private Sub ONO_POSO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ONO_POSO.TextChanged

    End Sub

    Private Sub TIMH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMH.TextChanged

    End Sub

    Private Sub MKOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MKOD.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        atim.Text = Find_Atim(Format(ComboBox1.SelectedIndex + 1, "00")) + 1
        FEIDOS_SELECTED = ComboBox1.SelectedIndex
        MKOD.Focus()

    End Sub
    Function Find_Atim(ByVal n As String) As Long
        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand


        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from parastat where id =" + n, objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        Find_Atim = DS.Tables("parastat").Rows(0).Item("aritmisi")
        objcon.Close()


    End Function

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim n As Integer, ans As Integer
        ans = MsgBox("ΝΑ ΑΚΥΡΩΘΕΙ?", MsgBoxStyle.YesNo)
        If ans = vbNo Then
            Exit Sub
        End If

        Label2.Text = ""
        ListBox1.Items.Clear()

        ListBox1.Visible = True

        PEL.Visible = True
        n = ExecuteSQL("UPDATE EDIT SET POSO=0,kod='',ono='',timm=0,ekpt=0")
        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""
        Edit = ""
        mRow = 1
        mFocus = 0
        MKOD.Focus()
        Me.Hide()





    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




        'comm1.StopBits = Ports.StopBits.One
        'comm1.BaudRate = 9600
        'comm1.Parity = Ports.Parity.None
        'comm1.PortName = "COM1"
        'comm1.DataBits = 8
        'comm1.Encoding = System.Text.Encoding.Default
        'comm1.Open()
        'comm1.Write(Chr(10))

        'comm1.WriteLine(to437("1//ΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))
        'comm1.WriteLine(to437("2//ΣΣΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))

        'comm1.WriteLine(to437("3//ΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))
        'comm1.WriteLine(to437("4//ΣΣΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))

        'comm1.WriteLine(to437("5//ΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))
        'comm1.WriteLine(to437("6//ΣΣΑΒΓΔΕΖ - ΗΘΙΚΛΜ - ΝΞΟΠ - ΡΤΥ - ΦΧΨΩ") + Chr(10))


        'comm1.WriteLine("                                          " + Chr(10))
        'comm1.WriteLine("                                          " + Chr(10))




        'comm1.Close()


    End Sub

    Function load_forma(ByVal arxeio As String, ByVal spacing As Integer, ByRef NEPIK As Long, ByRef NEPAN As Long, ByRef NSYN As Long) As Boolean
        ' Dim gm_str(200) As String ' οι σειρές του f99.txt

        'spacing=1 klassiko poy ta ypologizei me +1 thn stili toy pedioy (x1)
        'spacing=0 kanonika
        '*********************************************************
        '-----------    GLOBAL ΜΕΤΑΒΛΗΤΕΣ  ----------------
        'gm_str() οι σειρές του f99.txt
        'gpic(i) το στρινγκ του πεδίου
        'gm_r(i),gm_c(i) σειρά και στήλη του πεδίου
        'gm_f(i) το όνομα του πεδίου

        'gm_str(6)="     ^XXXXXXXXXXXXXXXXXXXXXXXXXXX               ^xxxxxxxx    @XXXXXXXX  ~ono_par  ~SUBS(tim->atim,2,5)  ~TIM->HME
        '        gpic(2)='XXXXXXXXXXXXXXXXXXXXXXXXXXX
        'gm_r(2)=5  gm_c(2)=6    gm_f(2)=ono_par
        '========================================================
        'Dim gm_str(1 To 250) As String
        Dim ar_ped(250) As Integer
        Dim K As Integer, I As Integer, lastseir As Integer
        Dim npic As Integer, m_npic As Integer, L1 As Integer, n As Integer
        Dim A(250) As Integer
        Dim u As Integer, mhk_seir As Integer
        Dim X1 As Integer, X2 As Integer
        Dim xa(30) As Integer
        '-----------------------------------
        On Error GoTo 0
        'Close #1
        load_forma = False


        Using sr As StreamReader = New StreamReader(arxeio, System.Text.Encoding.Default)
            ' Open arxeio For Input As #1

            For K = 1 To 250
                gm_str(K) = ""
                gm_f(K) = ""
                gpic(K) = " "
                gm_r(K) = 0
                gm_c(K) = 0
                ar_ped(K) = 0
            Next
            I = 1
            Dim line As String
            Do
                line = sr.ReadLine()
                gm_str(I) = line
                I = I + 1
            Loop Until line Is Nothing
        End Using
        '----------------------------------


        lastseir = 0
        npic = 0
        ' ΔΙΑΒΑΖΩ ΤΑ PICTURES ΚΑΙ ΤΗΝ ΘΕΣΗ ΤΟΥΣ
        NEPIK = 0 : NEPAN = 0 : NSYN = 0
        '*-------------------------------------------------------------------
        For K = 1 To 250
            L1 = InStr(gm_str(K), "^")
            For n = 1 To 30
                A(n) = 0
            Next


            ' * δεν έχει καθόλου ^
            If L1 = 0 Then
                ar_ped(K) = 0
            ElseIf Mid(gm_str(K), 1, 3) = "^^^" Then   'SXOLIA
                If NEPIK = 0 Then
                    NEPIK = npic
                Else
                    If NEPAN = 0 Then
                        NEPAN = npic
                    Else
                        NSYN = npic
                    End If
                End If
                'npic = npic + 1
                ar_ped(K) = 0
            Else
                '* βρέθηκε σειρά με ^ , ψάχνω μήπως έχει και άλλα
                A(1) = L1 '&& a[]  θέσεις όπου βρέθηκαν τα ^

                For u = 2 To 30
                    A(u) = InStr(Mid$(gm_str(K), A(u - 1) + 1, Len(gm_str(K))), "^")
                    If A(u) = 0 Then
                        Exit For
                    End If
                    A(u) = A(u) + A(u - 1)
                Next


                ' μηκος σειράς
                mhk_seir = InStr(gm_str(K), "~")
                If mhk_seir = 0 Then
                    MsgBox("δεν έχω το σημάδι ~ στην σειρά" + Str(K))
                    Exit Function
                End If

                ar_ped(K) = u - 1

                'ΣΕ ΑΥΤΗΝ ΤΗΝ ΣΕΙΡΑ ΒΡΕΘΗΚΑΝ U-1 ΠΕΔΙΑ

                For I = 1 To u - 1
                    npic = npic + 1  'ΑΥΞΑΝΕΙ Ο ΑΡΙΘΜΟΣ ΤΩΝ ΠΕΔΙΩΝ

                    If spacing = 1 Then  ' bgazei +1  (λανθασμένο κρατείται για συμβατότητα)
                        X1 = A(I) + 1  '&&  if ( i=1,1,a(i))
                        X2 = IIf(A(I + 1) = 0, (mhk_seir - 1) - X1 + 1, A(I + 1) - 1 - X1)
                    Else
                        X1 = A(I)   '&&  if ( i=1,1,a(i))
                        X2 = IIf(A(I + 1) = 0, (mhk_seir - 1) - X1 + 1, A(I + 1) - X1)
                    End If

                    'το PICTURE του πεδίου
                    gpic(npic) = Mid$(gm_str(K), X1, X2)

                    'η σειρά του πεδίου
                    gm_r(npic) = IIf(I = 1, K - lastseir, 0) 'αφου είναι στην ίδια σειρά να μην προσθέτει σειρές


                    'η στήλη του πεδίου
                    gm_c(npic) = A(I)
                Next

                lastseir = K
            End If

        Next
        m_npic = npic

        'YPOLOGISMOS ONOMATON TON PEDION
        npic = 0
        For K = 1 To 250
            L1 = InStr(gm_str(K), "~")
            For n = 1 To 30
                xa(n) = 0
            Next

            If Mid(gm_str(K), 3) = "^^^" Then
                '  npic = npic + 1
            ElseIf L1 = 0 Then        ' &&  ›¤ β®  ΅ζΆ¦¬ ~

            Else
                'βρέθηκε σειρά με ~ , ψάχνω μήπως έχει και άλλα
                xa(1) = L1 'a[]  θέσεις όπου βρέθηκαν τα ~
                For u = 2 To 30
                    xa(u) = InStr(Mid(gm_str(K), xa(u - 1) + 1, Len(gm_str(K))), "~")
                    If xa(u) = 0 Then
                        Exit For
                    End If
                    xa(u) = xa(u) + xa(u - 1)
                Next

                'μηκος σειράς
                mhk_seir = Len(gm_str(K))

                'ΣΕ ΑΥΤΗΝ ΤΗΝ ΣΕΙΡΑ ΒΡΕΘΗΚΑΝ U-1 ΠΕΔΙΑ

                For I = 1 To u - 1
                    npic = npic + 1  'ΑΥΞΑΝΕΙ Ο ΑΡΙΘΜΟΣ ΤΩΝ ΠΕΔΙΩΝ
                    X1 = xa(I) + 1  '&&  if ( i=1,1,a(i))
                    X2 = IIf(xa(I + 1) = 0, (mhk_seir) - X1 + 1, xa(I + 1) - 1 - X1)

                    '* o titlow του πεδίου
                    gm_f(npic) = Mid$(gm_str(K), X1, X2)

                Next
                If ar_ped(K) <> u - 1 Then
                    If ar_ped(K) > u - 1 Then
                        MsgBox("στην σειρά " + Format(K, "##") + Mid(gm_str(K), 1, 40) + ".... εχω παραπάνω  " + Str(ar_ped(K) - (u - 1)) + "^  από  ~")
                    Else
                        MsgBox(" στην σειρά " + Format(K, "##") + " " + Mid(gm_str(K), 1, 40) + ".... έχω παραπάνω " + Str(-ar_ped(K) + (u - 1)) + " ~ από ^ ")
                    End If
                End If
                lastseir = K
            End If

        Next


        load_forma = True


    End Function












    '    Dim SC As New MSScriptControl.ScriptControl
    '    Dim Formula As String = "(2+4)*5"
    '    'SET LANGUAGE TO VBSCRIPT
    'SC.Language = "VBSCRIPT"
    '    'ATTEMPT MATH
    'Try
    '    Dim Result As Double = Convert.ToDouble(SC.Eval(Formula))
    '    'SHOW THAT IT WAS VALID
    '  MessageBox.Show("Math success, " & Formula & " equals " & Result.ToString)
    'Catch ex As Exception
    '    'SHOW THAT IT WAS INVALID
    '  MessageBox.Show("Not a valid math formula for a double.")
    'End Try 








    Private Sub MON_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MON.ParentChanged

    End Sub

   
    Private Sub atim_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atim.ParentChanged

    End Sub
End Class