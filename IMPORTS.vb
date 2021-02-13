

Imports System.Data.SqlServerCe
Imports System
Imports System.IO



Public Class IMPORT
    Inherits System.Windows.Forms.Form


    '-----------    GLOBAL Ã≈‘¡¬À«‘≈”  ----------------
    Dim gm_str(250) As String ' OLES OI SEIRES TOY F90.TXT
    Dim gpic(250) As String  ' ÙÔ ÛÙÒÈÌ„Í ÙÔı Â‰ﬂÔı
    Dim gm_r(250) As Long, gm_c(250) As Long ' ÛÂÈÒ‹ Í·È ÛÙﬁÎÁ ÙÔı Â‰ﬂÔı
    Dim gm_f(250) As String ' ÙÔ ¸ÌÔÏ· ÙÔı Â‰ﬂÔı

    Dim elem(30) As String









    Dim fSCR As Object ' SCRIPT CONTROL
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'IMPORT PELATON
        Dim COLS(20, 2) As Long
        Dim COUNTER As Integer




        If File.Exists("My Documents\PEL.TXT") Then
        Else
            MsgBox("ƒ≈Õ ’–¡—◊≈… ‘œ ¡—◊≈…œ PEL.TXT")
            Exit Sub
        End If


        Dim nn As Integer = MsgBox("Õ· ‰È·„Ò·ˆÂﬂ ÙÔ ·Ò˜ÂﬂÔ –ÂÎ·Ù˛Ì „È· Ì· ˆÔÒÙ˘ËÂﬂÙÔ Ì›Ô;", MsgBoxStyle.YesNo)
        If nn = MsgBoxResult.No Then
            MsgBox("·ÍıÒ˘ÛÁ ˆ¸ÒÙ˘ÛÁÚ")
            Exit Sub
        End If




        ListBox1.Items.Clear()
        ListBox1.BackColor = Color.Blue


        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim SQL As String

        Dim C As String

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")

        objcmd = New SqlCeCommand("DELETE FROM  PEL; ", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()
        Dim N As Integer
        N = 0
        Dim C2 As String
        Dim ans As Integer

        'ƒ…¡¬¡∆≈… œÀœ ”¡Õ ¡—◊≈…œ
        'Using sr As StreamReader = New StreamReader("PEL.txt")
        '    C2 = sr.ReadToEnd()
        'End Using


        '‘¡ ƒ…¡¬¡∆≈… ”¡Õ RECORDS
        'Public Shared Sub FileGet( _
        'ByVal FileNumber As Integer, _
        '    ByRef Value As ValueType, _
        'ByVal RecordNumber As Long )

        '    Dim FileNumber As Integer
        '    Dim Value As ValueType
        '    Dim RecordNumber As Long

        '  FileSystem.FileGet(FileNumber, Value, RecordNumber)



        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF7) ‘¡ ¬√¡∆≈… 2 ÷œ—≈” Ã…¡ ÷œ—¡ ¡ ¡‘¡À¡¬…”‘… ¡  ¡… Ã…¡ ≈ÀÀ«Õ… ¡
        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF8) ‘¡ ¬√¡∆≈… 2 ÷œ—≈” Ã…¡ ÷œ—¡  ≈Õ¡  ¡… Ã…¡ ≈ÀÀ«Õ… ¡


        If Not File.Exists("PELCOLS.TXT") Then

            Using sw As StreamWriter = New StreamWriter("pelcols.txt")
                sw.WriteLine("1,4    kod")
                sw.WriteLine("6,20   per")
                sw.WriteLine("40,20  die")
                sw.WriteLine("65,16   epa")
                sw.WriteLine("81,10   afm")

                sw.WriteLine("118,15   doy")

                sw.WriteLine("110,8   typ")

                sw.WriteLine("132,12   DEH")
                sw.Close()
            End Using

        End If



        Using sr As StreamReader = New StreamReader("PELCOLS.txt", System.Text.Encoding.Default)

            COUNTER = 0
            Dim COMA As Integer
            Dim line As String
            Do

                line = sr.ReadLine()
                COMA = InStr(line, ",")
                If COMA > 0 Then
                    COUNTER = COUNTER + 1
                    COLS(COUNTER, 1) = Val(Mid(line, 1, COMA - 1))
                    COLS(COUNTER, 2) = Val(Mid(line, COMA + 1, 2))
                End If
            Loop Until line Is Nothing

        End Using





        Dim csv As Integer = 1






        Using sr As StreamReader = New StreamReader("My Documents\PEL.txt", System.Text.Encoding.Default)


            Dim line As String
            Dim ypol As String
            Dim mkod, mepo, mafm, mdie, mepa, mdoy As String
            ListBox1.BackColor = Color.Blue

            line = sr.ReadLine()  ' EPIKEFALIDA  ' ˘‰ÈÍ¸Ú;¡.÷.Ã.;≈˘ÌıÏﬂ·;ƒÈÂ˝ËıÌÛÁ;–¸ÎÁ;‘ÁÎ.1
            Dim N2 As Long
            N2 = 0
            Do

                '0004  ¡Ã–œ’—…ƒ«” Ã¡ «”                  —œÕœ’ 8                 2521033161                                          0ƒ—¡Ã¡”               
                '0005 ¡Õ¡”‘¡”…¡ƒ«” «À…¡”                Ã«‘—œ–.¡√¡»¡√√≈Àœ’ 13    ‘¡◊’Ã≈‘¡÷œ—≈”   042972546                           0ƒ—¡Ã¡”               
                N2 = N2 + 1

                If N2 Mod 100 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(N2, "#####")
                End If



                'If N2 Mod 100 = 0 Then
                'ListBox1.Items.Add(Str(N2))

                'End If
                line = sr.ReadLine()
                If line Is Nothing Then
                Else
                    'Val(Split(tmpStr, ":")(4)) = 1 Then

                    ' ˘‰ÈÍ¸Ú;¡.÷.Ã.;≈˘ÌıÏﬂ·;ƒÈÂ˝ËıÌÛÁ;–¸ÎÁ;‘ÁÎ.1
                    '0001;099376551;CREAM TEAM;¡…√¡…œ’ 4/Õ… œ–œÀ« 

                    'mkod, mepo, mafm, mdie, mepa, mdoy, mtyp

                    If csv = 1 Then
                        mkod = Split(line, ";")(0)

                        mafm = Split(line, ";")(1)
                        mepo = Replace(Split(line, ";")(2), "'", "`")
                        mdie = Replace(Split(line, ";")(3), "'", "`")
                        mdoy = Replace(Split(line, ";")(4), "'", "`")
                        mepa = Replace(Split(line, ";")(5), "'", "`")
                        ypol = "0"
                        ' ListBox1.Items.Add(mepo)
                    Else

                        mkod = Mid(C2, COLS(1, 1), COLS(1, 2))
                        mepo = Mid(C2, COLS(2, 1), COLS(2, 2))
                        mafm = Mid(C2, COLS(5, 1), COLS(5, 2))
                        mdie = Mid(C2, COLS(3, 1), COLS(3, 2))
                        mepa = Mid(C2, COLS(4, 1), COLS(4, 2))
                        mdoy = Mid(C2, COLS(6, 1), COLS(6, 2))
                        C = "" + line.ToString
                        ListBox1.Items.Add(C)
                        C2 = ListBox1.Items(N).ToString
                        C2 = Replace(C2, "'", " ")
                        ypol = Replace(Mid(C2, COLS(7, 1), COLS(7, 2)), ",", "")
                        ypol = Format(Val(Replace(Mid(C2, COLS(7, 1), COLS(7, 2)), ",", "")), "#####0.00")
                        ypol = Replace(ypol, ",", ".")
                        If CheckBox1.Checked = True Then
                            MsgBox("kod" + mkod)
                            MsgBox("epo" + mepo)
                            MsgBox("die" + mdie)
                            MsgBox("epa" + mepa)
                            MsgBox("afm" + mafm)
                            MsgBox("doy" + mdoy)
                            ' MsgBox("doy" + Mid(C2, COLS(8, 1), COLS(8, 2)))
                            MsgBox("typ" + ypol)
                        End If

                    End If
                    SQL = ""
                    SQL = "INSERT INTO PEL (KOD,EPO,DIE,EPA,AFM,DOY,TYP,POL ) VALUES ('" + _
                    Mid(mkod, 1, 10) + "','" + _
                    Mid(mepo, 1, 30) + "','" + _
                    Mid(mdie, 1, 30) + "','" + _
                    Mid(mepa, 1, 30) + "','" + _
                    Mid(mafm, 1, 10) + "','" + _
                    Mid(mdoy, 1, 15) + "'," + _
                    ypol + ",'" + _
                    Mid(mdoy, 1, 15) + "'); "
                    objcmd = New SqlCeCommand(SQL, objcon)
                    Try
                        objcmd.ExecuteNonQuery()
                    Catch ex As Exception
                        ListBox1.Items.Add(SQL & ex.Message)
                        MsgBox("‰ÂÌ Í·Ù·˜˘ÒﬁËÁÍÂ" & vbCrLf & C2 & ex.Message)
                        ans = MsgBox("”ıÌÂ˜ÂÈ·;", MsgBoxStyle.YesNo)
                        If ans = vbNo Then
                            Exit Sub
                        End If
                    End Try



                    N = N + 1


                End If
            Loop Until line Is Nothing


            ListBox1.Refresh()
        End Using


        ListBox1.BackColor = Color.White



        MsgBox("≈√…Õ≈ ≈…”¡√Ÿ√« " + Chr(13) + Format(N, "##0") + " –≈À¡‘ŸÕ")


        File.Delete("PEL.TXT")


        objcon.Close()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim K As Integer
        For K = 128 To 255
            ListBox1.Items.Add(Chr(K) + " " + Format(K, "000"))
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'IMPORT EIDON
        Dim COLS(20, 2) As Long
        Dim COUNTER As Integer

        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand

        Dim C As String


        If File.Exists("My Documents\EID.TXT") Then
        Else
            MsgBox("ƒ≈Õ ’–¡—◊≈… ‘œ ¡—◊≈…œ EID.TXT")
            Exit Sub
        End If



        Dim nn As Integer = MsgBox("Õ· ‰È·„Ò·ˆÂﬂ ÙÔ ·Ò˜ÂﬂÔ EIƒŸÕ „È· Ì· ˆÔÒÙ˘ËÂﬂÙÔ Ì›Ô;", MsgBoxStyle.YesNo)
        If nn = MsgBoxResult.No Then
            MsgBox("·ÍıÒ˘ÛÁ ˆ¸ÒÙ˘ÛÁÚ")
            Exit Sub
        End If



        If Not File.Exists("EIDCOLS.TXT") Then

            Using sw As StreamWriter = New StreamWriter("eidcols.txt")
                sw.WriteLine("1,4    kod")
                sw.WriteLine("17,30   ONO")
                sw.WriteLine("90,5  LTI  XONDRIKH TIMH")
                sw.WriteLine("73,1   fpa")
                sw.WriteLine("53,3   mon")
                sw.WriteLine("100,6   YPOL")
                sw.Close()
            End Using

        End If

        'objcmd = New SqlCeCommand("INSERT INTO EID (KOD,ONO,LTI,FPA,MON) VALUES ('" + _
        '                 Mid(C2, 1, 4) + "','" + Mid(C2, 15, 30) + "'," + _
        '                 Mid(C2, 55, 8) + "," + Mid(C2, 65, 1) + ",'" + _
        '                 Mid(C2, 66, 3) + "'); ", objcon)

        Using sr As StreamReader = New StreamReader("EIDCOLS.txt", System.Text.Encoding.UTF8)

            COUNTER = 0
            Dim COMA As Integer
            Dim line As String
            Do

                line = sr.ReadLine()
                COMA = InStr(line, ",")
                If COMA > 0 Then
                    COUNTER = COUNTER + 1
                    COLS(COUNTER, 1) = Val(Mid(line, 1, COMA - 1))
                    COLS(COUNTER, 2) = Val(Mid(line, COMA + 1, 2))
                End If
            Loop Until line Is Nothing

        End Using
























        objcon = New SqlCeConnection("Data Source ='My Documents\AAACE.SDF';")

        objcmd = New SqlCeCommand("DELETE FROM EID; ", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()
        Dim N As Integer
        N = 0
        Dim C2 As String
        Dim mfpa As String
        Dim SQL As String
        Dim lti As String
        Dim ans As Integer

        ListBox1.Items.Clear()
        ListBox1.BackColor = Color.BlueViolet

        Dim CSV As Integer = 1
        If CSV = 1 Then

            Using sr As StreamReader = New StreamReader("My Documents\EID.TXT", System.Text.Encoding.Default)
                Dim line, CC As String
                CC = ""
                Dim MKOD, MONO, MLTI, MBARCODE As String

                Dim MANAM, MDESMIA, MPOS, MENAL As String


                ListBox1.Items.Add("ƒ≈Õ –≈—¡”T« ¡Õ")
                '  line = sr.ReadLine()  'seira me header
                Do
                    line = sr.ReadLine()
                    If line Is Nothing Then
                    Else

                        Try


                            '0          1         2             3       4        5          6          7
                            ' ˘‰ÈÍ¸Ú;–ÂÒÈ„Ò·ˆﬁ;≈Õ¡À.  Ÿƒ… œ”;◊ÔÌ‰ÒÈÍﬁÚ;’ÔÎ.1;ƒÂÛÏÂıÏ›Ì·;¡Ì·ÏÂÌ¸ÏÂÌ·;Barcode
                            '12-01-30;À¡Ã–¡ƒ¡  ≈—…Õ« KOKKIN«   ¡ÀÀ¡”/‘—…¡Õ;12-01-30;2,7000;;3;;5200001201306

                            ' ˘‰ÈÍ¸Ú;–ÂÒÈ„Ò·ˆﬁ;Barcode;◊ÔÌ‰ÒÈÍﬁÚ
                            '12-01-0050;–œ‘«—¡ … √…¡ À¡Ã¡–ƒ¡ 72‘≈Ã;5200590076262;0,0700

                            MKOD = Mid(Split(line, ";")(0), 1, 30)
                            If Len(Split(line, ";")(0)) > 30 Then
                                ListBox1.Items.Add(MKOD)
                                Application.DoEvents()
                            End If


                            MENAL = Mid(Split(line, ";")(2), 1, 30)




                            MONO = Mid(Replace(Split(line, ";")(1), "'", "`"), 1, 40)
                            MBARCODE = Mid(Replace(Split(line, ";")(7), "'", "`"), 1, 13)



                            MLTI = Replace(Split(line, ";")(3), ",", ".")
                            If MLTI = Nothing Then MLTI = "0"

                            MPOS = Replace(Split(line, ";")(4), ",", ".")
                            If MPOS = Nothing Then MPOS = "0"
                            MANAM = Replace(Split(line, ";")(6), ",", ".")
                            If MANAM = Nothing Then MANAM = "0"
                            MDESMIA = Replace(Split(line, ";")(5), ",", ".")
                            If MDESMIA = Nothing Then MDESMIA = "0"

                            SQL = "INSERT INTO EID (KOD,ONO,BARCODE,LTI,POS,ANAM,DESM,ENALL) VALUES ('" + MKOD + "','" + MONO + "','" + MBARCODE + "'," + MLTI + "," + MPOS + "," + MANAM + "," + MDESMIA + ",'" + MENAL + "' ); "
                            objcmd = New SqlCeCommand(SQL, objcon)
                            objcmd.ExecuteNonQuery()
                        Catch ex As Exception
                            ListBox1.Items.Add(CC & ex.Message)
                            MsgBox("‰ÂÌ Í·Ù·˜˘ÒﬁËÁÍÂ" & vbCrLf & C2 & ex.Message)
                            ans = MsgBox("”ıÌÂ˜ÂÈ·;", MsgBoxStyle.YesNo)
                            If ans = vbNo Then
                                Exit Sub
                            End If
                        End Try
                    End If
                    N = N + 1
                    If N Mod 100 = 0 Then
                        Application.DoEvents()
                        Me.Text = Format(N, "#####")
                    End If
                Loop Until line Is Nothing
                sr.Close()

                ListBox1.Refresh()
            End Using
        Else
            Dim mPOS As String

            Using sr As StreamReader = New StreamReader("EID.txt", System.Text.Encoding.Default)
                Dim line As String
                Do
                    line = sr.ReadLine()
                    If line Is Nothing Then
                    Else
                        C = "" + line.ToString
                        ListBox1.Items.Add(C)

                        C2 = ListBox1.Items(N).ToString
                        C2 = Replace(C2, "'", " ")

                        If Len(C2) > 5 Then
                            mfpa = Mid(C2, COLS(4, 1), COLS(4, 2))
                            mfpa = Replace(mfpa, "%", "")
                            If Val(mfpa) = 2 Then mfpa = "23"
                            If Val(mfpa) = 1 Then mfpa = "11"
                            If Val(mfpa) = 0 Then mfpa = "23"
                            mPOS = Format(Val(Trim(Mid(C2, COLS(6, 1), COLS(6, 2)))), "####0.00")
                            mPOS = Replace(mPOS, ",", ".")
                            lti = Mid(C2, COLS(3, 1), COLS(3, 2))
                            lti = Format(Val(lti), "####.00")
                            lti = Replace(lti, ",", ".")
                            If CheckBox1.Checked = True Then
                                MsgBox("kod" + Mid(C2, COLS(1, 1), COLS(1, 2)))
                                MsgBox("ono" + Mid(C2, COLS(2, 1), COLS(2, 2)))
                                MsgBox("lti" + lti)
                                MsgBox("fpa" + mfpa)
                                MsgBox("mon" + Mid(C2, COLS(5, 1), COLS(5, 2)))
                                ans = MsgBox("”ıÌÂ˜ÂÈ·;", MsgBoxStyle.YesNo)
                                If ans = vbNo Then
                                    Exit Sub
                                End If
                            End If


                            Try



                                SQL = "INSERT INTO EID (KOD,ONO,LTI,FPA,MON,POS) VALUES ('" + _
                                                        Trim(Mid(C2, COLS(1, 1), COLS(1, 2))) + "','" + Trim(Mid(C2, COLS(2, 1), COLS(2, 2))) + "'," + _
                                                        lti + "," + mfpa + ",'" + _
                                                        Mid(C2, COLS(5, 1), COLS(5, 2)) + "'," + mPOS + "); "
                                objcmd = New SqlCeCommand(SQL, objcon)
                                objcmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox("‰ÂÌ Í·Ù·˜˘ÒﬁËÁÍÂ" & vbCrLf & C2 & ex.Message)
                                ans = MsgBox("”ıÌÂ˜ÂÈ·;", MsgBoxStyle.YesNo)
                                If ans = vbNo Then
                                    Exit Sub
                                End If
                            End Try


                            N = N + 1
                            If N Mod 100 = 0 Then
                                Me.Text = Format(N, "#####")
                            End If
                        End If
                    End If
                Loop Until line Is Nothing
                sr.Close()

                ListBox1.Refresh()
            End Using
        End If

        MsgBox("≈√…Õ≈ ≈…”¡√Ÿ√« " + Chr(13) + Format(N, "##0") + " EIƒŸÕ")


        File.Delete("EID.TXT")



        objcon.Close()

        'Dim fileReader As System.IO.StreamReader
        'Dim filePath As String
        'filePath = "pel.txt"
        'fileReader = New System.IO.StreamReader(filePath, System.Text.Encoding.Default)
        'While fileReader.Peek <> -1

        '    ListBox1.Items.Add(fileReader.ReadLine)
        'End While

        'fileReader.Close()

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim N As Long

        File.Delete("EGGTIM.TXT")
        N = ExecuteSQL("DELETE FROM EGGTIM")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'IMPORT EIDON
        Dim COLS(20, 2) As Long

        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim SQL As String




        If File.Exists("OLA3") Then
        Else
            MsgBox("ƒ≈Õ ’–¡—◊≈… ‘œ ¡—◊≈…œ OLA")
            Exit Sub
        End If






        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")

        objcmd = New SqlCeCommand("DELETE FROM OLA; ", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()
        objcon.Close()
        Dim N As Integer
        N = 0


        ListBox1.Items.Clear()
        Dim CSV As Integer = 1
        Dim CCH As String
        Dim x As Long

        Dim fields(30) As String
        Dim k As Integer




        x = 0
        If CSV = 1 Then

            Using sr As StreamReader = New StreamReader("OLA3", System.Text.Encoding.Default)
                Dim line, CC As String
                CC = ""
                line = sr.ReadLine()  'seira me header
                CCH = Replace(line, ";", ",")

                CCH = Replace(CCH, """", "")

                fetes(CCH)

                For k = 1 To 6
                    fields(k) = elem(k)
                Next




                Do
                    line = sr.ReadLine()

                    If line Is Nothing Then
                    Else

                        Try
                            CC = Replace(line, ",", ".")
                            CC = Replace(CC, ";", ",")

                            CC = Replace(CC, """", "'")

                            CC = Replace(CC, ",,", ",'',")
                            fetes(CC)
                            ' SQL = "update OLA SET ONO=" + elem(3) + ",LTI5=" + elem(4) + ",POS=" + elem(5) + " WHERE ERG=" + elem(2)
                            SQL = "INSERT INTO OLA (" + CCH + ") VALUES (" + CC + "); "
                            objcmd = New SqlCeCommand(SQL, objcon)
                            objcmd.Connection.Open()
                            k = objcmd.ExecuteNonQuery()
                            If k = 0 Then
                                objcon.Close()
                                SQL = "INSERT INTO OLA (" + CCH + ") VALUES (" + CC + "); "
                                objcmd = New SqlCeCommand(SQL, objcon)
                                objcmd.Connection.Open()
                                k = objcmd.ExecuteNonQuery()

                            End If

                        Catch ex As Exception
                            x = x + 1
                            ListBox1.Items.Add(CC & ex.Message)
                            'MsgBox("‰ÂÌ Í·Ù·˜˘ÒﬁËÁÍÂ" & vbCrLf & C2 & ex.Message)
                            'ans = MsgBox("”ıÌÂ˜ÂÈ·;", MsgBoxStyle.YesNo)
                            'If ans = vbNo Then
                            ' Exit Sub
                            ' End If
                        End Try
                    End If

                    objcon.Close()

                    N = N + 1
                    If N Mod 100 = 0 Then
                        Me.Text = Format(N, "#####") + "--À¡»«:" + Format(x, "#####")
                    End If
                Loop Until line Is Nothing
                sr.Close()

                ListBox1.Refresh()
            End Using
        Else
        End If

        MsgBox("≈√…Õ≈ ≈…”¡√Ÿ√« " + Chr(13) + Format(N, "##0") + " EIƒŸÕ")


        File.Delete("OLA")



        objcon.Close()


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        'SqlConnection con = null;

        'SqlCommand cmd = null;

        'SqlDataReader reader = null;

        'con = new SqlConnection();

        'con.ConnectionString = "Persist Security Info=False;Integrated Security=False;Server=HISDEVNEW,1433;initial catalog=HISStock;user id=VBQUser;password=1999Q2000;";

        'con.Open();

        'cmd = new SqlCommand();

        'cmd.Connection = con;

        'cmd.CommandType = CommandType.Text;

        'cmd.CommandText = "Select @@Version";

        'object version = cmd.ExecuteScalar();



    End Sub

    Function fetes(ByVal line As String)

        Dim KL, KE


        '  DIABAZO SE PINAKA OLA TA STOIXEIA THS GRAMHS
        For KE = 1 To 30
            elem(KE) = ""
        Next

        KL = 1   ' metraei xaraktires
        KE = 0   ' metritis toy pinaka  ELEMENT
        Do
            KE = KE + 1  ' metritis toy pinaka  ELEMENT
            'KL = KL + 1  ' metraei xaraktires

            Do While Mid$(line, KL, 1) <> "," ' Chr(13) ' tab
                elem(KE) = elem(KE) + Mid$(line, KL, 1)
                KL = KL + 1  ' metraei xaraktires
                If KL > Len(line) Then Exit Do
            Loop
            KL = KL + 1 ' „È· Ì· ÂÒ·ÛÂÈ ÙÔ chr(10)

            If KL > Len(line) Then Exit Do

        Loop Until KL >= Len(line) 'OLO TO MHKOS THS GRAMMHS

        'fetes = NULL

    End Function
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'IMPORT EK–‘Ÿ”≈…” PELATON
        Dim COLS(20, 2) As Long
        Dim COUNTER As Integer




        If File.Exists("EKPTOSEIS.TXT") Then
        Else
            MsgBox("ƒ≈Õ ’–¡—◊≈… ‘œ ¡—◊≈…œ EKPTOSEIS.TXT")
            Exit Sub
        End If
        ListBox1.Items.Clear()
        ListBox1.BackColor = Color.Blue


        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        Dim SQL As String

        Dim C As String

        'objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")

        'objcmd = New SqlCeCommand("DELETE FROM  PEL; ", objcon)
        'objcmd.Connection.Open()
        'objcmd.ExecuteNonQuery()
        Dim N As Integer
        N = 0
        Dim C2 As String


        'ƒ…¡¬¡∆≈… œÀœ ”¡Õ ¡—◊≈…œ
        'Using sr As StreamReader = New StreamReader("PEL.txt")
        '    C2 = sr.ReadToEnd()
        'End Using


        '‘¡ ƒ…¡¬¡∆≈… ”¡Õ RECORDS
        'Public Shared Sub FileGet( _
        'ByVal FileNumber As Integer, _
        '    ByRef Value As ValueType, _
        'ByVal RecordNumber As Long )

        '    Dim FileNumber As Integer
        '    Dim Value As ValueType
        '    Dim RecordNumber As Long

        '  FileSystem.FileGet(FileNumber, Value, RecordNumber)



        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF7) ‘¡ ¬√¡∆≈… 2 ÷œ—≈” Ã…¡ ÷œ—¡ ¡ ¡‘¡À¡¬…”‘… ¡  ¡… Ã…¡ ≈ÀÀ«Õ… ¡
        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF8) ‘¡ ¬√¡∆≈… 2 ÷œ—≈” Ã…¡ ÷œ—¡  ≈Õ¡  ¡… Ã…¡ ≈ÀÀ«Õ… ¡


        If Not File.Exists("EKPTCOLS.TXT") Then

            Using sw As StreamWriter = New StreamWriter("EKPTCOLS.txt")
                sw.WriteLine("29,4    kod")
                sw.WriteLine("100,6   EKPT")
                sw.Close()
            End Using

        End If



        Using sr As StreamReader = New StreamReader("EKPTCOLS.txt", System.Text.Encoding.Default)

            COUNTER = 0
            Dim COMA As Integer
            Dim line As String
            Do

                line = sr.ReadLine()
                COMA = InStr(line, ",")
                If COMA > 0 Then
                    COUNTER = COUNTER + 1
                    COLS(COUNTER, 1) = Val(Mid(line, 1, COMA - 1))
                    COLS(COUNTER, 2) = Val(Mid(line, COMA + 1, 2))
                End If
            Loop Until line Is Nothing

        End Using










        Dim EKPT As String


        Using sr As StreamReader = New StreamReader("EKPTOSEIS.txt", System.Text.Encoding.Default)


            Dim line As String
            Dim ypol As String

            Do

                '0004  ¡Ã–œ’—…ƒ«” Ã¡ «”                  —œÕœ’ 8                 2521033161                                          0ƒ—¡Ã¡”               
                '0005 ¡Õ¡”‘¡”…¡ƒ«” «À…¡”                Ã«‘—œ–.¡√¡»¡√√≈Àœ’ 13    ‘¡◊’Ã≈‘¡÷œ—≈”   042972546                           0ƒ—¡Ã¡”               


                line = sr.ReadLine()
                If line Is Nothing Then
                Else


                    C = "" + line.ToString
                    ListBox1.Items.Add(C)

                    C2 = ListBox1.Items(N).ToString
                    C2 = Replace(C2, "'", " ")
                    'ypol = Replace(Mid(C2, COLS(7, 1), COLS(7, 2)), ",", "")
                    'If Len(Trim(ypol)) = 0 Then
                    EKPT = Format(Val(Replace(Mid(C2, COLS(2, 1), COLS(2, 2)), ",", ".")), "#####0.00")
                    ' ypol = Replace(ypol, ",", ".")
                    'End If
                    If CheckBox1.Checked = True Then
                        'MsgBox("kod" + Mid(C2, COLS(1, 1), COLS(1, 2)))
                        'MsgBox("epo" + Mid(C2, COLS(2, 1), COLS(2, 2)))
                        'MsgBox("die" + Mid(C2, COLS(3, 1), COLS(3, 2)))
                        'MsgBox("epa" + Mid(C2, COLS(4, 1), COLS(4, 2)))
                        'MsgBox("afm" + Mid(C2, COLS(5, 1), COLS(5, 2)))
                        'MsgBox("doy" + Mid(C2, COLS(6, 1), COLS(6, 2)))
                        'MsgBox("doy" + Mid(C2, COLS(8, 1), COLS(8, 2)))
                        'MsgBox("typ" + ypol)

                    End If
                    SQL = "UPDATE PEL SET EKPT=" + EKPT + " WHERE KOD='" + Trim(Mid(C2, COLS(1, 1), COLS(1, 2))) + "'"
                    ExecuteSQL(SQL)
                    N = N + 1


                End If
            Loop Until line Is Nothing


            ListBox1.Refresh()
        End Using

        MsgBox("≈√…Õ≈ ENHME—Ÿ”« " + Chr(13) + Format(N, "##0") + " –≈À¡‘ŸÕ")


        File.Delete("EKPTOSEIS.TXT")


        ' objcon.Close()
    End Sub
End Class
