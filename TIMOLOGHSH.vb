Imports System.Data.SqlServerCe
Imports System.IO

Public Class TIMOLOGHSH
    Inherits System.Windows.Forms.Form
    Dim Fobjcon As SqlCeConnection
    Dim Fobjcmd As New SqlCeCommand
    Dim FDS As New System.Data.DataSet
    Dim FDA As New SqlCeDataAdapter

    Dim FEIDOS(30) As String ' TO XARAKTIRISTIKO GRAMMA GIA KATHE PARASTATIKO P.X. 'T' GIA TIM.POL-DA
    Dim FEIDOS_SELECTED As String ' TO XARAKTIRISTIKO GRAMMA GIA KATHE PARASTATIKO –œ’ ≈–…À≈◊»« ≈

    Dim f_mRow As Integer 'se poia seira briskomai
    Dim f_Edit As String 'bohuhtiki metabliti gia na kana dataentry me ta buttons
    Dim mFocus As Integer 'poio textbox exei focus
    Dim f_Comm1 As New System.IO.Ports.SerialPort
    Dim f_XreosiApot As Integer  '1=ÒÔÛËÂÙÂÈ ·ÙÔ eid.pos 0=afairei
    Dim F_ENTER As Integer ' FLAG OTI PATITHIKE TO ENTER GIA NA MHN PAEI STO EPOMENO CONTROL KAI NA PERIMENEI TO EPOMENO PLIKTRO

    Dim fCOLS(20, 2) As Long

    '-----------    GLOBAL Ã≈‘¡¬À«‘≈”  ----------------
    Dim gm_str(250) As String ' OLES OI SEIRES TOY F90.TXT
    Dim gpic(250) As String  ' ÙÔ ÛÙÒÈÌ„Í ÙÔı Â‰ﬂÔı
    Dim gm_r(250) As Long, gm_c(250) As Long ' ÛÂÈÒ‹ Í·È ÛÙﬁÎÁ ÙÔı Â‰ﬂÔı
    Dim gm_f(250) As String

    Private Sub TIMOLOGHSH_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
      
    End Sub ' ÙÔ ¸ÌÔÏ· ÙÔı Â‰ﬂÔı

    Private Sub EKTYP_TIMOL()
        'Imports System.IO
        '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
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






        '¡Õœ…√Ÿ ‘«Õ »’—¡ ‘«Õ ”≈…—…¡ «
        '≈–œÃ≈Õ≈” 7 ”≈…—≈” ƒœ’À≈’œ’Õ Ã…¡ ◊¡—¡ √…¡ ‘œ ¡Õœ…√Ã¡
        '   √…¡ ≈ ‘’–Ÿ”« f_Comm1.Write(" " + Chr(10))  ¡… f_Comm1.CLOSE() KLEINO THN PORTA
        f_Comm1.BaudRate = 9600
        f_Comm1.Parity = Ports.Parity.None
        f_Comm1.PortName = COMMPORT  ' "COM1"
        f_Comm1.DataBits = 8
        'f_Comm1.CtsHolding()
        f_Comm1.Handshake = IO.Ports.Handshake.XOnXOff
        f_Comm1.StopBits = Ports.StopBits.One
        f_Comm1.Encoding = System.Text.Encoding.Default


        Try
            f_Comm1.Open()
        Catch ex As Exception
            MessageBox.Show("¡Õœ…Œ‘≈ ‘œÕ ≈ ‘’–Ÿ‘« ")  ' + Chr(13) + Mid(LINE, 1, 15))
            Try
                f_Comm1.Open()
            Catch ex2 As Exception
                MessageBox.Show("¡ƒ’Õ¡‘« « ≈ ‘’–Ÿ”«")
                Exit Sub
            End Try
        End Try
        '        f_Comm1.Write(Chr(27) + "C0" + Chr(8))

        f_Comm1.Write(Chr(27) + "C" + Chr(66)) '11 INCH
        f_Comm1.Write(Chr(27) + "wg")  ' oneil ellinika  + Chr(66)) '11 INCH


        Dim LINE As String

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        SQL = "select * from MEM"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()
        DA.SelectCommand = objcmd
        DA.Fill(DS, "MEM")



        For K = 0 To DS.Tables("MEM").Rows.Count - 1
            LINE = DS.Tables("MEM").Rows(K).Item(0)
            LINE = Mid(LINE, 1, 90)
            f_Comm1.Write(to437(LINE) + Chr(10))
            System.Threading.Thread.Sleep(300)
        Next
        ' Thread.Sleep(10000)
        System.Threading.Thread.Sleep(1000)


        f_Comm1.Write(Chr(12))
        f_Comm1.Close()

    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'AaaDataSet1.Edit' table. You can move, or remove it, as needed.
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
        ComboBox1.Text = ComboBox1.Items(0).ToString()


        f_mRow = 1
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

        '   DataGrid1.Controls.Item(1).Width = 200




        ComboBox1.Focus()



    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EIDOS.Click
        Dim FlagONOMA As Boolean
        FlagONOMA = False

        '  If f_mRow >= 1 Then
        '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        If Len(ONO_POSO.Text) > 0 Then
            SQL = "select * from EID WHERE ONO LIKE '" + ONO_POSO.Text + "%'"
            FlagONOMA = True ' False
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
            MsgBox("ƒ≈Õ ’–¡—◊≈… ‘œ ≈…ƒœ”")
            objcmd.Connection.Close()
            Exit Sub

        End If


        Dim K As Long

        If FlagONOMA = False Then
            'ÂÒÌ‹˘ ÙÔÌ Í˘‰ÈÍ¸ Í·È ÙÔ ¸ÌÔÏ· ÛÙÔ grid
            objcmd = New SqlCeCommand("UPDATE Edit SET kod='" + Mid(DS.Tables("eid").Rows(0).Item("kod"), 1, 10) + "',ono='" + DS.Tables("eid").Rows(0).Item("ono") + "' WHERE ID=" + Format(f_mRow, "###0"), objcon)
            objcmd.ExecuteNonQuery()
            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            DataGrid1.Refresh()
            TIMH.Text = Format(DS.Tables("eid").Rows(K).Item("lti"), "##0.00")
            FPA.Text = DS.Tables("eid").Rows(K).Item("FPA").ToString
            MON.Text = DS.Tables("eid").Rows(K).Item("MON").ToString
            POS.Text = DS.Tables("eid").Rows(K).Item("POS").ToString
            Label7.Text = DS.Tables("eid").Rows(0).Item("ono")
            If f_mRow > 0 Then DataGrid1.Select(f_mRow - 1)
            If f_mRow > 1 Then
                If f_mRow = 4 Then
                    DataGrid1.CurrentRowIndex = 3
                ElseIf f_mRow = 5 Then
                    DataGrid1.CurrentRowIndex = 4
                ElseIf f_mRow <= 3 Then
                    DataGrid1.CurrentRowIndex = f_mRow - 1
                Else
                    DataGrid1.CurrentRowIndex = f_mRow - 2
                End If
            End If

            If Val(EKPTPEL.Text) = 0 Then
                EKPT.Text = 0
            Else
                EKPT.Text = EKPTPEL.Text
            End If



            ONO_POSO.Text = "1"
            ONO_POSO.Focus()


        Else
            ListBox1.Items.Clear()
            ListBox1.Visible = True
            For K = 0 To DS.Tables("EID").Rows.Count - 1
                ListBox1.Items.Add(Format(K, "00") + " " + Mid(DS.Tables("eid").Rows(K).Item("kod").ToString + Space(10), 1, 4) + " " + DS.Tables("eid").Rows(K).Item("ONO"))
            Next
            objcmd.Connection.Close()

            ListBox1.Text = ListBox1.Items(0).ToString
            ListBox1.Focus()


        End If
        '       End If
        f_Edit = ""

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        '¬À≈–Ÿ –œ…¡ ”≈…—¡  –¡‘«”≈ ”‘œ GRID
        f_mRow = DataGrid1.CurrentCell.RowNumber + 1
        If f_mRow > 0 Then DataGrid1.Select(f_mRow - 1)


    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEL.Click

        EPILOGH_PELATH()



    End Sub
    Sub EPILOGH_PELATH()
        '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
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
        Dim ok As Integer = 0
        For K = 0 To DS.Tables("PEL").Rows.Count - 1
            S = ""
            S = S + Mid(DS.Tables("PEL").Rows(K).Item("kod") + Space(8), 1, 8) + "*"   'Format(K, "000") + "-" +
            S = S + Mid(DS.Tables("PEL").Rows(K).Item("EPO") + Space(25), 1, 25)
            If IsDBNull(DS.Tables("PEL").Rows(K).Item("EKPT")) Then
                S = S + "00.0"
            Else
                S = S + Format(DS.Tables("PEL").Rows(K).Item("EKPT"), "00.0")
            End If
            'S = S + DS.Tables("PEL").Rows(K).Item("DIE")
            'S = S + DS.Tables("PEL").Rows(K).Item("EPA")
            'S = S + DS.Tables("PEL").Rows(K).Item("AFM")
            'S = S + DS.Tables("PEL").Rows(K).Item("DOY")
            ListBox1.Items.Add(S)
            ok = 1
        Next
        objcmd.Connection.Close()
        If ok = 1 Then
            ListBox1.Text = ListBox1.Items(0).ToString
            ListBox1.Focus()
        End If


    End Sub

    Private Sub ListBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.GotFocus

    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
       
    End Sub

    

    

    Sub LISTBOX()
        'Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        If F_ENTER = 1 Then  ' den prolaba na pathsei pliktro
            F_ENTER = 0
            Exit Sub
        End If

        If Len(Label2.Text) = 0 Then ' ≈◊≈… ¬—≈… –≈À¡‘« 
            Label2.Text = ListBox1.SelectedItem.ToString
            EKPTPEL.Text = Mid(ListBox1.SelectedItem.ToString, 28, 4) '***34
            ListBox1.Visible = False
            PEL.Visible = False
            Dim n As Long
            n = ExecuteSQL("UPDATE Edit SET POSO=0,kod='',ono='',timm=0,ekpt=0")

            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            Label3.Text = " ˘‰.≈È‰"
            Label4.Text = " "

            DataGrid1.Refresh()
            MKOD.Text = ""
            MKOD.Focus()
            ONO_POSO.Text = ""
        Else  ' ¡… –¡Ã≈ √…¡ ≈…ƒœ”
            Dim k As Long
            k = ExecuteSQL("UPDATE Edit SET kod='" + Trim(Mid(ListBox1.SelectedItem.ToString, 4, 4)) + "',ono='" + Mid(ListBox1.SelectedItem.ToString, 9, 24) + "' WHERE ID=" + Format(f_mRow, "###0")) '***10  15

            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            DataGrid1.Refresh()
            ListBox1.Visible = False
            MKOD.Text = Trim(Mid(ListBox1.SelectedItem.ToString, 4, 4)) '***10

            Dim sql2
            sql2 = "select * from EID WHERE KOD='" + Trim(Mid(ListBox1.SelectedItem.ToString, 4, 4)) + "'"  '***  10
            Label7.Text = Mid(ListBox1.SelectedItem.ToString, 9, 24) '***15
            openSQL(sql2, FDS)
            ONO_POSO.Text = "1"
            F_ENTER = 0
            ONO_POSO.Focus()
            DataGrid1.Refresh()
            TIMH.Text = Format(FDS.Tables("P").Rows(0).Item("lti"), "##0.00")
            FPA.Text = FDS.Tables("P").Rows(0).Item("FPA").ToString
            MON.Text = FDS.Tables("P").Rows(0).Item("MON").ToString
            POS.Text = FDS.Tables("P").Rows(0).Item("POS").ToString
            If Val(EKPTPEL.Text) = 0 Then
                EKPT.Text = ""
            Else
                EKPT.Text = EKPTPEL.Text
            End If
        End If

    End Sub

    Private Sub ListBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyUp
        If e.KeyValue = 13 Then
            If F_ENTER = 1 Then
                F_ENTER = 0
            Else
                LISTBOX()  '1_SelectedIndexChanged(Nothing, e)
            End If

        End If
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub MKOD_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MKOD.GotFocus
        MKOD.BackColor = Color.Yellow
        '   F_ENTER = 0
        If mFocus <> 1 Then
            mFocus = 1
            f_Edit = MKOD.Text
        End If
    End Sub

    Private Sub MKOD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MKOD.KeyUp
        If e.KeyValue = 13 Then
            ' If F_ENTER = 1 Then  ' DEN PROLABE NA PATHSEI PLIKTRO
            'F_ENTER = 0
            'Else
            If Val(MKOD.Text) = 0 Then
                F_ENTER = 0
                ONO_POSO.Focus()

            Else


                If PEL.Visible = True Then
                    F_ENTER = 0
                    EPILOGH_PELATH()

                Else
                    '≈◊≈… ƒ…¡À≈Œ≈… ≈…ƒœ”  ¡… –¡≈… √…¡ –œ”œ‘«‘¡
                    '≈–…Àœ√« ≈…ƒœ’”
                    F_ENTER = 0
                    Button2_Click(Nothing, e)
                End If

            End If
            'End If

        End If




        If e.KeyValue > 63 Then
            MKOD.Text = toNumeric(MKOD.Text)
            MKOD.SelectionStart = Len(MKOD.Text)
            MKOD.SelectionLength = Len(MKOD.Text)
        End If

    End Sub

    Private Sub MKOD_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MKOD.LostFocus
        MKOD.BackColor = Color.White
    End Sub

    Private Sub N_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ONO_POSO.GotFocus
        ONO_POSO.BackColor = Color.Yellow
        ONO_POSO.SelectionStart = 0
        ONO_POSO.SelectionLength = Len(ONO_POSO.Text)
        'Text3.SelectionStart = 0
        'Text3.SelectionLength = Len(Text3.Text)

        If mFocus <> 2 Then
            mFocus = 2
            f_Edit = ONO_POSO.Text
        End If

    End Sub

    Private Sub ONO_POSO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ONO_POSO.KeyDown

        '        If e.KeyValue = Asc("a") Then
        'e.KeyValue = "√"

        'End If
        ' If e.KeyValue > 63 Then
        '    e.
        'e.KeyCode = "√" ' ONO_POSO.Text = toGreeK(ONO_POSO.Text)
        'End If





    End Sub

    


    Private Sub ONO_POSO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ONO_POSO.KeyUp




        If e.KeyValue = 13 Then
            If F_ENTER = 1 Then  ' DEN PROLABE NA PATHSEI PLIKTRO
                F_ENTER = 0
            Else
                If PEL.Visible = True Then '¯·˜Ì˘ ÂÎ·ÙÁ
                    F_ENTER = 0
                    ONO_POSO.Text = toGreeK(ONO_POSO.Text)
                    EPILOGH_PELATH()
                Else
                    If Len(MKOD.Text) = 0 Then '¯·˜Ì˘ EIDOS ME ONOMA
                        F_ENTER = 0
                        ONO_POSO.Text = toGreeK(ONO_POSO.Text)
                        Button2_Click(Nothing, e)
                    Else   ' –≈—Õ¡Ÿ ‘œ ‘…ÃœÀœ√…œ
                        TIMH.Focus()
                    End If
                End If


            End If
        End If
        If e.KeyValue > 63 Then
            If Len(MKOD.Text) > 0 Then ' EXEI DIALEJEI EIDOS
                ONO_POSO.Text = toNumeric(ONO_POSO.Text)
                ONO_POSO.SelectionStart = Len(ONO_POSO.Text)
                ONO_POSO.SelectionLength = Len(ONO_POSO.Text)
            Else
                ONO_POSO.Text = toGreeK(ONO_POSO.Text)
                ONO_POSO.SelectionStart = Len(ONO_POSO.Text)
                ONO_POSO.SelectionLength = Len(ONO_POSO.Text)
            End If
        End If


    End Sub
    Private Sub N_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ONO_POSO.LostFocus
        ONO_POSO.BackColor = Color.White
    End Sub

    Private Sub TIMH_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.GotFocus
        TIMH.BackColor = Color.Yellow

        TIMH.SelectionStart = 0
        TIMH.SelectionLength = Len(TIMH.Text)
        If mFocus <> 3 Then
            mFocus = 3
            f_Edit = TIMH.Text
        End If

    End Sub

    Private Sub TIMH_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TIMH.KeyUp
        If e.KeyValue = 13 Then
            EKPT.Focus()
        End If

        If e.KeyValue > 63 Then
            TIMH.Text = toNumeric(TIMH.Text)
            TIMH.SelectionStart = Len(TIMH.Text)
            TIMH.SelectionLength = Len(TIMH.Text)
        End If


    End Sub

    Private Sub TIMH_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.LostFocus
        TIMH.BackColor = Color.White
    End Sub




    Private Sub EKPT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles EKPT.GotFocus
        EKPT.BackColor = Color.Yellow
        EKPT.SelectionStart = 0
        EKPT.SelectionLength = Len(ONO_POSO.Text)


        If mFocus <> 4 Then
            mFocus = 4
            f_Edit = EKPT.Text
        End If

    End Sub

    Private Sub EKPT_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EKPT.KeyUp
        If e.KeyValue = 13 Then
            NEO_EIDOS_Click(Nothing, e)
        End If

        If e.KeyValue > 63 Then
            EKPT.Text = toNumeric(EKPT.Text)
            EKPT.SelectionStart = Len(EKPT.Text)
            EKPT.SelectionLength = Len(EKPT.Text)
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
        If Val(ONO_POSO.Text) = 0 Then
            MsgBox("ƒ≈Õ ¬◊≈… –œ”œ‘«‘¡")
            Exit Sub
        End If

        SQL = "UPDATE Edit SET POSO=" + Replace(ONO_POSO.Text, ",", ".")
        SQL = SQL + ",TIMM=" + Replace(TIMH.Text, ",", ".")
        SQL = SQL + ",EKPT=" + Replace(EKPT.Text, ",", ".")
        SQL = SQL + ",FPA=" + Replace(FPA.Text, ",", ".")
        SQL = SQL + ",MON='" + MON.Text + "' "
        SQL = SQL + " WHERE ID=" + Format(f_mRow, "#0")
        n = ExecuteSQL(SQL)

        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        'gia na mporo na blepo ti grafo
        '  DataGrid1.CurrentRowIndex = f_mRow - 1

        If f_mRow < 15 Then
            f_mRow = f_mRow + 1
        End If
        If f_mRow > 0 Then
            DataGrid1.Select(f_mRow - 1)
        End If

        Fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        'Dim SQL As String
        SQL = "select SUM(POSO*TIMM*(100-EKPT)/100*(1+FPA/100)) as SUMA from Edit "
        Fobjcmd = New SqlCeCommand(SQL, Fobjcon)
        Fobjcmd.Connection.Open()
        FDA.SelectCommand = Fobjcmd
        FDS.Clear()
        FDA.Fill(FDS, "EDIT2")


        Dim SAJIA As Single
        SAJIA = 0
        'K = FDS.Tables("EDIT2").Rows.Count - 1
        SAJIA = Val(Replace(FDS.Tables("EDIT2").Rows(0).Item(0).ToString, ",", "."))

        AJIA.Text = Format(SAJIA, "####0.00")
        Fobjcon.Close()


        If f_mRow > 1 Then DataGrid1.CurrentRowIndex = f_mRow - 2







        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""
        MKOD.Focus()
        f_Edit = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim c As String



        ListBox1.Items.Clear()


        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        SQL = "select * from Edit where POSO<>0"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "Edit")
        Dim K As Long, N As Long
        Dim KOD As String, ONO As String, mPOSO As String
        Dim mTIMM As String, mEKPT As String


        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        If Not File.Exists("EGGTIM.TXT") Then
            sw = New StreamWriter("EGGTIM.TXT")
            sw.WriteLine("  ")
        Else
            ' This text is always added, making the file longer over time
            ' if it is not deleted.
            sw = File.AppendText("EGGTIM.TXT")
        End If

        For K = 0 To DS.Tables("Edit").Rows.Count - 1
            SEIRA = Space(100)
            KOD = DS.Tables("Edit").Rows(K).Item("kod")
            ONO = DS.Tables("Edit").Rows(K).Item("ONO")
            mPOSO = Replace(DS.Tables("Edit").Rows(K).Item("POSO"), ",", ".")
            mTIMM = Replace(DS.Tables("Edit").Rows(K).Item("TIMM"), ",", ".")
            mEKPT = Replace(DS.Tables("Edit").Rows(K).Item("ekpt"), ",", ".")

            If Val(mPOSO) > 0 Then
                SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA,KODPEL) VALUES ('"
                SQL = SQL + Format(Val(atim.Text), "00000") + "','" + Format(Now, "MM/dd/yyyy") + "','" + KOD + "','" + ONO + "'," + mTIMM + "," + mPOSO + "," + mEKPT + "," + FPA.Text + ",'" + Mid(Label2.Text, 1, 4) + "')"
                N = ExecuteSQL(SQL)
                Mid(SEIRA, fCOLS(1, 1), fCOLS(1, 2)) = FEIDOS_SELECTED + Format(Val(atim.Text), "00000") ' Format(Val(atim.Text), "00000")
                Mid(SEIRA, fCOLS(2, 1), fCOLS(2, 2)) = Format(Now, "dd/MM/yyyy")
                Mid(SEIRA, fCOLS(3, 1), fCOLS(3, 2)) = KOD + Space(fCOLS(3, 2))
                Mid(SEIRA, fCOLS(4, 1), fCOLS(4, 2)) = Space(fCOLS(4, 2)) 'ONO + Space(fCOLS(4, 2))
                Mid(SEIRA, fCOLS(5, 1), fCOLS(5, 2)) = mTIMM
                Mid(SEIRA, fCOLS(6, 1), fCOLS(6, 2)) = mPOSO
                Mid(SEIRA, fCOLS(7, 1), fCOLS(7, 2)) = mEKPT + "  "
                Mid(SEIRA, fCOLS(8, 1), fCOLS(8, 2)) = FPA.Text
                Mid(SEIRA, fCOLS(9, 1), fCOLS(9, 2)) = Mid(Label2.Text, 1, 4) + Space(fCOLS(9, 2)) 'KODIKOS PELATH
                '                Mid(SEIRA, fCOLS(10, 1), fCOLS(10, 2)) = Mid(TRP.Text, 1, 3)
                sw.WriteLine(SEIRA)

                If f_XreosiApot = 1 Then
                    SQL = "update EID SET POS=POS+" + mPOSO
                Else
                    SQL = "update EID SET POS=POS-" + mPOSO
                End If
                N = ExecuteSQL(SQL)





            End If
        Next
        sw.Close()

        'End Using


        '--------------------------------------------------------------------------------------
        'Â·Ì ÂﬂÌ·È ÙÛÂÍ·ÒÈÛÏ›ÌÁ Á ÂÍÙ˝˘ÛÁ
        If ekt.Checked = True Then


            Dim objcon2 As SqlCeConnection
            Dim objcmd2 As New SqlCeCommand



            ListBox1.Items.Clear()


            objcon2 = New SqlCeConnection("Data Source ='AAACE.SDF';")

            '‰È·‚‹Ê˘ Ù· ÎﬁÒÁ ÛÙÔÈ˜Âﬂ· ÙÔı ÂÎ‹ÙÁ ÛÙÔ DS2 DATASET
            SQL = "select * from PEL WHERE KOD='" + Mid(Label2.Text, 1, 4) + "'"

            objcmd2 = New SqlCeCommand(SQL, objcon2)
            objcmd2.Connection.Open()
            Dim DS2 As New System.Data.DataSet
            Dim DA2 As New SqlCeDataAdapter
            DA2.SelectCommand = objcmd2
            DA2.Fill(DS2, "PELATHS")


            Dim EPIK, EPAN, SYN As Long
            '  EPIK :‘≈À≈’‘¡…œ –≈ƒ…œ ‘ŸÕ ≈–… ≈÷¡À…ƒŸÕ
            '  EPAN :‘≈À≈’‘¡…œ –≈ƒ…œ ‘ŸÕ √—¡ÃÃŸÕ –œ’ ≈–¡Õ¡À¡Ã¬¡ÕœÕ‘¡…
            '  SYN :‘≈À≈’‘¡…œ –≈ƒ…œ ‘ŸÕ ”’ÕœÀŸÕ
            load_forma("F90.TXT", 0, EPIK, EPAN, SYN)


            Dim I As Long

            For I = 1 To 200
                If Mid(gm_str(I), 1, 10) = "**********" Then
                    Exit For
                End If
            Next


            '* ”’ÕœÀ… ≈” ”≈…—≈”
            Dim m_No_of_seir As Long = Val(gm_str(I + 1))

            '* ”≈…—¡ –œ’ ¡—◊…∆œ’Õ ‘¡ ≈…ƒ«
            Dim m_seir_eid As Long = Val(gm_str(I + 2))

            '* ”≈…—¡ –œ’ ¡—◊…∆œ’Õ ‘¡ ”’ÕœÀ¡
            Dim m_seir_synol As Long = Val(gm_str(I + 3))

            '¬—…” Ÿ –œ”¡ –≈ƒ…¡ ‘’–ŸÕœÕ‘¡… ”‘«Õ ≈–… ≈÷¡À…ƒ¡ ,
            '”‘œ ≈–¡Õ¡À¡Ã¬¡ÕœÃ≈Õœ ‘Ã«Ã¡  ¡… ”‘¡ 
            '”’ÕœÀ¡

            Dim L As Long



            Dim PEDIA(200) As String
            PEDIA(1) = DS2.Tables("PELATHS").Rows(0).Item("kod")
            PEDIA(2) = to437(DS2.Tables("PELATHS").Rows(0).Item("EPO"))
            PEDIA(3) = to437(DS2.Tables("PELATHS").Rows(0).Item("DIE"))
            ' PEDIA(4) = DS2.Tables("PELATHS").Rows(0).Item("POL")
            If DS2.Tables("PELATHS").Rows(0).Item("EPA").ToString = Nothing Then
                PEDIA(5) = ""
            Else
                PEDIA(5) = DS2.Tables("PELATHS").Rows(0).Item("EPA")
            End If


            PEDIA(6) = DS2.Tables("PELATHS").Rows(0).Item("AFM")


            If DS2.Tables("PELATHS").Rows(0).Item("EPA").ToString = Nothing Then
                PEDIA(7) = ""
            Else
                PEDIA(7) = DS2.Tables("PELATHS").Rows(0).Item("DOY")
            End If


            'PEDIA(7) = DS2.Tables("PELATHS").Rows(0).Item("DOY")

            PEDIA(8) = ""  'DS2.Tables("PELATHS").Rows(0).Item("DEH")

            PEDIA(20) = ComboBox1.Text 'PARASTATIKO
            PEDIA(21) = Format(Now, "dd/MM/yyyy") 'HMERA
            PEDIA(22) = Format(Now, "HH:mm") 'ORA
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
            For K = 1 To EPIK ' Ùı˘ÛÂ Ù· Â‰ﬂ· ÙÁÚ ÂÈÍÂˆ·Îﬂ‰·Ú
                If gm_r(K) > 0 Then 'AN ALLAZEI SEIRA
                    'sw2.WriteLine(StrSeira) '√—¡ÿ≈ ‘«Õ ”≈…—¡
                    N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                    For L = 1 To gm_r(K) - 1
                        'kateba seires

                        'PREVIOUS  WAS : N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                        N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES (' ')")
                    Next

                    StrSeira = Space(100) 'Œ≈ …Õ¡Ã≈  ¡…Õœ’—…¡
                End If
                ' ÙıÔÛÂ STHN STHLH GM_C(K) TO :  PEDIA( GM_F(K) )
                If Mid(gm_f(K), 1, 1) = """" Then
                    c = Mid(gm_f(K), 2, Len(gm_f(K)) - 2)
                Else
                    c = Mid(PEDIA(gm_f(K)), 1, Len(gpic(K)))
                End If
                Mid(StrSeira, gm_c(K), Len(c)) = c
            Next
            '   sw2.WriteLine(StrSeira) '√—¡ÿ≈ ‘«Õ ”≈…—¡
            N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
            '-----------EPANALAMBANOMENH -----------------------≈ ‘’–Ÿ”«
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
                PEDIA(54) = Format(Val(Replace(mTIMM, ",", ".")), "###0.00")
                PEDIA(55) = mEKPT
                PEDIA(56) = Replace(DS.Tables("EDIT").Rows(K).Item("FPA"), ",", ".")
                PEDIA(57) = Format(mPOSO * mTIMM * (100 - mEKPT) / 100, "###0.00")
                PEDIA(58) = Format((mPOSO * mTIMM * (100 - mEKPT) / 100) * DS.Tables("EDIT").Rows(K).Item("fpa") / 100, "####0.00")
                StrSeira = Space(100) 'Œ≈ …Õ¡Ã≈  ¡…Õœ’—…¡
                For L = EPIK + 1 To EPAN
                    ' ÙıÔÛÂ STHN STHLH GM_C(K) TO :  PEDIA( GM_F(L) )
                    c = Mid(PEDIA(gm_f(L)), 1, Len(gpic(L))) '+ PEDIA(gm_f(L))
                    Mid(StrSeira, gm_c(L), Len(c)) = c
                Next
                'f_Comm1.Write(KOD + to437(ONO) + Chr(10))
                'sw2.WriteLine(StrSeira) '√—¡ÿ≈ ‘«Õ ”≈…—¡
                N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                SKAU = SKAU + mPOSO * mTIMM * (100 - mEKPT) / 100
                SEPID = SEPID + mPOSO * 0.272
                SFPA = SFPA + (mPOSO * mTIMM * (100 - mEKPT) / 100) * DS.Tables("EDIT").Rows(K).Item("fpa") / 100
            Next



            'KENA MEXRI TA SYNOLA
            For K = 1 To m_seir_synol - m_seir_eid - DS.Tables("EDIT").Rows.Count
                'sw2.WriteLine("") '√—¡ÿ≈ KENH SEIRA
                N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('  ')")
            Next





            '--------------SYNOLA -----------------------

            PEDIA(80) = Format(SKAU, "####0.00") 'kauaro poso
            PEDIA(81) = Format(SFPA, "####0.00") 'fpa
            PEDIA(82) = Format(SKAU + SFPA, "####0.00") 'synolo
            PEDIA(83) = Format(SEPID, "####0.00") 'EPIDOTHSH
            PEDIA(84) = Format(SEPID * 1.19, "####0.00") 'EPIDOTHSH+FPA

            PEDIA(85) = Format(SKAU + SFPA - SEPID * 1.19, "####0.00") 'PLIROTEO


            StrSeira = Space(100) 'Œ≈ …Õ¡Ã≈  ¡…Õœ’—…¡ SEIRA
            For K = EPAN + 1 To SYN ' Ùı˘ÛÂ Ù· Â‰ﬂ· ÙÁÚ ÂÈÍÂˆ·Îﬂ‰·Ú
                If gm_r(K) > 0 Then 'AN ALLAZEI SEIRA

                    ' sw2.WriteLine(StrSeira) '√—¡ÿ≈ ‘«Õ ”≈…—¡
                    N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")
                    For L = 1 To gm_r(K) - 1
                        'kateba seires
                        ' f_Comm1.Write(" " + Chr(10))
                        ' sw2.WriteLine("") '√—¡ÿ≈ KENH SEIRA
                        N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('  ')")
                    Next
                    StrSeira = Space(100) 'Œ≈ …Õ¡Ã≈  ¡…Õœ’—…¡
                End If
                ' ÙıÔÛÂ STHN STHLH GM_C(K) TO :  PEDIA( GM_F(K) )
                If Mid(gm_f(K), 1, 1) = """" Then
                    c = Mid(gm_f(K), 2, Len(gm_f(K)) - 2)
                Else
                    c = Mid(PEDIA(gm_f(K)), 1, Len(gpic(K)))
                End If
                Mid(StrSeira, gm_c(K), Len(c)) = c

                '  StrSeira = StrSeira + Space(gm_c(K)) + Mid(PEDIA(gm_f(K)), 1, Len(gpic(K))) ' + PEDIA(gm_f(K))
            Next
            'sw2.WriteLine(StrSeira) '√—¡ÿ≈ ‘«Õ ”≈…—¡
            N0 = ExecuteSQL("INSERT INTO MEM (S) VALUES ('" + StrSeira + "')")






            ' sw2.Close() ' TIMOLOGIO
            ' f_Comm1.Close()

            objcmd2.Connection.Close()

            '            Dim LL As Long, L3 As Long

            '           LL = Val(MKOD.Text)

            '          For L3 = 1 To Val(MKOD.Text)


            EKTYP_TIMOL()






            'Dim COMMPORT As String
            'Using sr As StreamReader = New StreamReader("PARAMETROI.TXT", System.Text.Encoding.Default)
            '    COMMPORT = Mid(sr.ReadLine(), 1, 4)
            '    sr.Close()
            'End Using
            'f_Comm1.BaudRate = 9600
            'f_Comm1.Parity = Ports.Parity.None
            'f_Comm1.PortName = COMMPORT  ' "COM1"
            'f_Comm1.DataBits = 8
            'f_Comm1.Handshake = IO.Ports.Handshake.XOnXOff
            'f_Comm1.StopBits = Ports.StopBits.One
            'f_Comm1.Encoding = System.Text.Encoding.Default
            'Try
            '    f_Comm1.Open()
            'Catch ex As Exception
            '    MessageBox.Show("¡Õœ…Œ‘≈ ‘œÕ ≈ ‘’–Ÿ‘« ")  ' + Chr(13) + Mid(LINE, 1, 15))
            '    Try
            '        f_Comm1.Open()
            '    Catch ex2 As Exception
            '        MessageBox.Show("¡ƒ’Õ¡‘« « ≈ ‘’–Ÿ”«")
            '        Exit Sub
            '    End Try
            'End Try
            'f_Comm1.Write(Chr(27) + "C" + Chr(66))
            'f_Comm1.Write(Chr(27) + "wg")  ' + Chr(8))
            'Dim LINE As String
            'objcmd.Connection.Close()
            'objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
            'SQL = "select * from MEM"
            'objcmd = New SqlCeCommand(SQL, objcon)
            'objcmd.Connection.Open()
            'DA.SelectCommand = objcmd
            'DA.Fill(DS, "MEM")
            'Dim ANS2 As Integer
            'Do While True
            '    Try
            '        For K = 0 To DS.Tables("MEM").Rows.Count - 1
            '            LINE = DS.Tables("MEM").Rows(K).Item(0)
            '            LINE = Mid(LINE, 1, 90)
            '            f_Comm1.Write(to437(LINE) + Chr(10))
            '            System.Threading.Thread.Sleep(500)
            '        Next
            '    Catch ex As Exception
            '        MessageBox.Show("À¡»œ” ”‘«Õ ”≈…—¡ " + Str(K)) ' + Chr(13) + Mid(LINE, 1, 15))
            '        f_Comm1.Close()
            '        Exit Sub
            '    End Try
            '    ' Thread.Sleep(10000)
            '    System.Threading.Thread.Sleep(1000)
            '    f_Comm1.Write(Chr(12))

            '    ANS2 = MsgBox("≈–¡Õ≈ ‘’–Ÿ”«;", MsgBoxStyle.YesNo)
            '    If ANS2 = vbNo Then
            '        Exit Do
            '    End If
            'Loop
            'f_Comm1.Close()




        End If



        ' objcmd.Connection.Close()


        Label2.Text = ""
        ListBox1.Visible = True
        PEL.Visible = True

        N = ExecuteSQL("UPDATE Edit SET POSO=0,kod='',ono='',timm=0,ekpt=0,fpa=0")

        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""



        f_Edit = ""

        ExecuteSQL("update parastat set aritmisi=aritmisi+1 where id=" + Format(ComboBox1.SelectedIndex + 1, "00"))

        atim.Text = Find_Atim(Format(ComboBox1.SelectedIndex + 1, "00")) + 1

        objcmd.Connection.Close()

        f_mRow = 1
        MKOD.Focus()


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

        f_Edit = f_Edit + "7"
        SENDKEY()


    End Sub
    Sub SENDKEY()

        If mFocus = 1 Then
            MKOD.Text = f_Edit
            MKOD.Focus()
            Exit Sub
        End If

        If mFocus = 2 Then
            ONO_POSO.Text = f_Edit
            ONO_POSO.Focus()
            Exit Sub
        End If

        If mFocus = 3 Then
            TIMH.Text = f_Edit
            TIMH.Focus()
            Exit Sub
        End If

        If mFocus = 4 Then
            EKPT.Text = f_Edit
            EKPT.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        f_Edit = f_Edit + "8"
        SENDKEY()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        f_Edit = f_Edit + "9"
        SENDKEY()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        f_Edit = f_Edit + "4"
        SENDKEY()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        f_Edit = f_Edit + "5"
        SENDKEY()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        f_Edit = f_Edit + "6"
        SENDKEY()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        f_Edit = f_Edit + "1"
        SENDKEY()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        f_Edit = f_Edit + "2"
        SENDKEY()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        f_Edit = f_Edit + "3"
        SENDKEY()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        f_Edit = f_Edit + "0"
        SENDKEY()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        f_Edit = f_Edit + "."
        SENDKEY()
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Len(f_Edit) > 1 Then
            f_Edit = Mid(f_Edit, 1, Len(f_Edit) - 1)
            SENDKEY()
        Else
            f_Edit = ""
            SENDKEY()
        End If


    End Sub

    Private Sub ComboBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyUp
        Dim NN As Integer

        If e.KeyValue = 13 Then


            NN = ComboBox1.SelectedIndex


            atim.Text = Find_Atim(Format(ComboBox1.SelectedIndex + 1, "00")) + 1
            FEIDOS_SELECTED = FEIDOS(ComboBox1.SelectedIndex)
            F_ENTER = 1
            MKOD.Focus()






        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' atim.Text = Find_Atim(Format(ComboBox1.SelectedIndex + 1, "00")) + 1
        ' FEIDOS_SELECTED = FEIDOS(ComboBox1.SelectedIndex)
        ' MKOD.Focus()

    End Sub
    Function Find_Atim(ByVal n As String) As Long
        '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand


        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from parastat where id =" + n, objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        Find_Atim = DS.Tables("parastat").Rows(0).Item("aritmisi")
        f_XreosiApot = DS.Tables("parastat").Rows(0).Item("XREOSIAPOT")
        objcon.Close()


    End Function

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim n As Integer, ans As Integer
        ans = MsgBox("Õ¡ ¡ ’—Ÿ»≈…?", MsgBoxStyle.YesNo)
        If ans = vbNo Then
            Exit Sub
        End If

        Label2.Text = ""
        ListBox1.Items.Clear()

        ListBox1.Visible = True

        PEL.Visible = True
        n = ExecuteSQL("UPDATE Edit SET POSO=0,kod='',ono='',timm=0,ekpt=0")
        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        DataGrid1.Refresh()
        MKOD.Text = ""
        ONO_POSO.Text = ""
        TIMH.Text = ""
        EKPT.Text = ""
        f_Edit = ""
        f_mRow = 1
        mFocus = 0
        MKOD.Focus()

    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




        'f_Comm1.StopBits = Ports.StopBits.One
        'f_Comm1.BaudRate = 9600
        'f_Comm1.Parity = Ports.Parity.None
        'f_Comm1.PortName = "COM1"
        'f_Comm1.DataBits = 8
        'f_Comm1.Encoding = System.Text.Encoding.Default
        'f_Comm1.Open()
        'f_Comm1.Write(Chr(10))

        'f_Comm1.WriteLine(to437("1//¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))
        'f_Comm1.WriteLine(to437("2//””¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))

        'f_Comm1.WriteLine(to437("3//¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))
        'f_Comm1.WriteLine(to437("4//””¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))

        'f_Comm1.WriteLine(to437("5//¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))
        'f_Comm1.WriteLine(to437("6//””¡¬√ƒ≈∆ - «»… ÀÃ - ÕŒœ– - —‘’ - ÷◊ÿŸ") + Chr(10))


        'f_Comm1.WriteLine("                                          " + Chr(10))
        'f_Comm1.WriteLine("                                          " + Chr(10))




        'f_Comm1.Close()


    End Sub

    Function load_forma(ByVal arxeio As String, ByVal spacing As Integer, ByRef NEPIK As Long, ByRef NEPAN As Long, ByRef NSYN As Long) As Boolean
        ' Dim gm_str(200) As String ' ÔÈ ÛÂÈÒ›Ú ÙÔı f99.txt

        'spacing=1 klassiko poy ta ypologizei me +1 thn stili toy pedioy (x1)
        'spacing=0 kanonika
        '*********************************************************
        '-----------    GLOBAL Ã≈‘¡¬À«‘≈”  ----------------
        'gm_str() ÔÈ ÛÂÈÒ›Ú ÙÔı f99.txt
        'gpic(i) ÙÔ ÛÙÒÈÌ„Í ÙÔı Â‰ﬂÔı
        'gm_r(i),gm_c(i) ÛÂÈÒ‹ Í·È ÛÙﬁÎÁ ÙÔı Â‰ﬂÔı
        'gm_f(i) ÙÔ ¸ÌÔÏ· ÙÔı Â‰ﬂÔı

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
        ' ƒ…¡¬¡∆Ÿ ‘¡ PICTURES  ¡… ‘«Õ »≈”« ‘œ’”
        NEPIK = 0 : NEPAN = 0 : NSYN = 0
        '*-------------------------------------------------------------------
        For K = 1 To 250
            L1 = InStr(gm_str(K), "^")
            For n = 1 To 30
                A(n) = 0
            Next


            ' * ‰ÂÌ ›˜ÂÈ Í·Ë¸ÎÔı ^
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
                '* ‚Ò›ËÁÍÂ ÛÂÈÒ‹ ÏÂ ^ , ¯‹˜Ì˘ Ïﬁ˘Ú ›˜ÂÈ Í·È ‹ÎÎ·
                A(1) = L1 '&& a[]  Ë›ÛÂÈÚ ¸Ôı ‚Ò›ËÁÍ·Ì Ù· ^

                For u = 2 To 30
                    A(u) = InStr(Mid$(gm_str(K), A(u - 1) + 1, Len(gm_str(K))), "^")
                    If A(u) = 0 Then
                        Exit For
                    End If
                    A(u) = A(u) + A(u - 1)
                Next


                ' ÏÁÍÔÚ ÛÂÈÒ‹Ú
                mhk_seir = InStr(gm_str(K), "~")
                If mhk_seir = 0 Then
                    MsgBox("‰ÂÌ ›˜˘ ÙÔ ÛÁÏ‹‰È ~ ÛÙÁÌ ÛÂÈÒ‹" + Str(K))
                    Exit Function
                End If

                ar_ped(K) = u - 1

                '”≈ ¡’‘«Õ ‘«Õ ”≈…—¡ ¬—≈»« ¡Õ U-1 –≈ƒ…¡

                For I = 1 To u - 1
                    npic = npic + 1  '¡’Œ¡Õ≈… œ ¡—…»Ãœ” ‘ŸÕ –≈ƒ…ŸÕ

                    If spacing = 1 Then  ' bgazei +1  (Î·ÌË·ÛÏ›ÌÔ ÍÒ·ÙÂﬂÙ·È „È· ÛıÏ‚·Ù¸ÙÁÙ·)
                        X1 = A(I) + 1  '&&  if ( i=1,1,a(i))
                        X2 = IIf(A(I + 1) = 0, (mhk_seir - 1) - X1 + 1, A(I + 1) - 1 - X1)
                    Else
                        X1 = A(I)   '&&  if ( i=1,1,a(i))
                        X2 = IIf(A(I + 1) = 0, (mhk_seir - 1) - X1 + 1, A(I + 1) - X1)
                    End If

                    'ÙÔ PICTURE ÙÔı Â‰ﬂÔı
                    gpic(npic) = Mid$(gm_str(K), X1, X2)

                    'Á ÛÂÈÒ‹ ÙÔı Â‰ﬂÔı
                    gm_r(npic) = IIf(I = 1, K - lastseir, 0) '·ˆÔı ÂﬂÌ·È ÛÙÁÌ ﬂ‰È· ÛÂÈÒ‹ Ì· ÏÁÌ ÒÔÛË›ÙÂÈ ÛÂÈÒ›Ú


                    'Á ÛÙﬁÎÁ ÙÔı Â‰ﬂÔı
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
            ElseIf L1 = 0 Then        ' &&  õú§ ‚Æú† °òüÊ¢¶¨ ~

            Else
                '‚Ò›ËÁÍÂ ÛÂÈÒ‹ ÏÂ ~ , ¯‹˜Ì˘ Ïﬁ˘Ú ›˜ÂÈ Í·È ‹ÎÎ·
                xa(1) = L1 'a[]  Ë›ÛÂÈÚ ¸Ôı ‚Ò›ËÁÍ·Ì Ù· ~
                For u = 2 To 30
                    xa(u) = InStr(Mid(gm_str(K), xa(u - 1) + 1, Len(gm_str(K))), "~")
                    If xa(u) = 0 Then
                        Exit For
                    End If
                    xa(u) = xa(u) + xa(u - 1)
                Next

                'ÏÁÍÔÚ ÛÂÈÒ‹Ú
                mhk_seir = Len(gm_str(K))

                '”≈ ¡’‘«Õ ‘«Õ ”≈…—¡ ¬—≈»« ¡Õ U-1 –≈ƒ…¡

                For I = 1 To u - 1
                    npic = npic + 1  '¡’Œ¡Õ≈… œ ¡—…»Ãœ” ‘ŸÕ –≈ƒ…ŸÕ
                    X1 = xa(I) + 1  '&&  if ( i=1,1,a(i))
                    X2 = IIf(xa(I + 1) = 0, (mhk_seir) - X1 + 1, xa(I + 1) - 1 - X1)

                    '* o titlow ÙÔı Â‰ﬂÔı
                    gm_f(npic) = Mid$(gm_str(K), X1, X2)

                Next
                If ar_ped(K) <> u - 1 Then
                    If ar_ped(K) > u - 1 Then
                        MsgBox("ÛÙÁÌ ÛÂÈÒ‹ " + Format(K, "##") + Mid(gm_str(K), 1, 40) + ".... Â˜˘ ·Ò·‹Ì˘  " + Str(ar_ped(K) - (u - 1)) + "^  ·¸  ~")
                    Else
                        MsgBox(" ÛÙÁÌ ÛÂÈÒ‹ " + Format(K, "##") + " " + Mid(gm_str(K), 1, 40) + ".... ›˜˘ ·Ò·‹Ì˘ " + Str(-ar_ped(K) + (u - 1)) + " ~ ·¸ ^ ")
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









    Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGrid1.CurrentRowIndex = Val(TextBox1.Text)

    End Sub

  
    Private Sub MKOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MKOD.TextChanged

    End Sub

    Private Sub ONO_POSO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ONO_POSO.TextChanged

    End Sub

    Private Sub TIMH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMH.TextChanged

    End Sub

    Private Sub EKPT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EKPT.TextChanged

    End Sub

    Private Sub Button15_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim ANS As Integer
        ANS = MsgBox("Õ¡ Œ¡Õ¡‘’–Ÿ”Ÿ ‘œ ‘…ÃœÀœ√…œ ;", MsgBoxStyle.YesNo)
        If ANS = vbYes Then
            EKTYP_TIMOL()
        End If
    End Sub
End Class