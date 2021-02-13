Imports System.IO
Imports System.Data.SqlServerCe

Public Class SHOWAPOGR
    Dim fCOLS(20, 2) As Long
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from OLA ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()


    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from APOG ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()







    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from OLA ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ANS As Integer, SQL As String, N As Long

        ANS = MsgBox("åéóáé óßãïõñïò ÔÇÍ ÄÉÁÃÑÁÖÇ ÔÇÓ ÁÐÏÃÑÁÖÇÓ ;", MsgBoxStyle.YesNo)
        If ANS = vbYes Then
            SQL = "DELETE FROM APOG"
            Try
                N = ExecuteSQL(SQL)
                MsgBox("OK ")
            Catch ex As Exception
                MsgBox("ËÁÈÏÓ ÄÅÍ ÄÉÅÃÑÁÖÇ " & Chr(13) & ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ANS As Integer, SQL As String, N As Long

        ANS = MsgBox("åéóáé óßãïõñïò ÔÇÍ ÄÉÁÃÑÁÖÇ ÔÙÍ ÅÉÄÙÍ ;", MsgBoxStyle.YesNo)
        If ANS = vbYes Then
            SQL = "DELETE FROM OLA"
            Try
                N = ExecuteSQL(SQL)
                MsgBox("OK ")
            Catch ex As Exception
                MsgBox("ËÁÈÏÓ ÄÅÍ ÄÉÅÃÑÁÖÇ " & Chr(13) & ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim L As Long = ExecuteSQL("ALTER TABLE APOG ADD  RAFI NUMERIC;")

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from EID ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from PEL ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select PEL.EPO,EGGTIM.* from EGGTIM INNER JOIN PEL ON EGGTIM.KODPEL=PEL.KOD ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")

        DataGrid1.DataSource = DS.Tables(0)

        DataGrid1.Refresh()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long

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








        If Not File.Exists("EGGTIM2.TXT") Then
            sw = New StreamWriter("EGGTIM2.TXT")
            sw.WriteLine("  ")
        Else
            ' This text is always added, making the file longer over time
            ' if it is not deleted.
            sw = File.AppendText("EGGTIM2.TXT")
        End If
        Dim K As Long
        'SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        ' For K = 0 To DS.Tables("Edit").Rows.Count - 1
        ' SQL = "INSERT INTO EGGTIM (ATIM,HME,KODE,ONO,TIMM,POSO,EKPT,FPA) VALUES ('"
        'SQL = SQL + Format(Val(atim.Text), "00000") + "','" + Format(Now, "MM/dd/yyyy") + "','" + KOD + "','" + ONO + "'," + mTIMM + "," + mPOSO + "," + mEKPT + "," + FPA.Text + ")"
        'N = ExecuteSQL(SQL)
        





        objcon = New SqlCeConnection("Data Source ='aaaCE.sdf';")
        objcmd = New SqlCeCommand("select * from EGGTIM ", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        ' DataGrid1.DataSource = DS.Tables(0)

        For K = 0 To DS.Tables(0).Rows.Count - 1
            SEIRA = Space(100)
            Mid(SEIRA, fCOLS(1, 1), fCOLS(1, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            Mid(SEIRA, fCOLS(2, 1), fCOLS(2, 2)) = DS.Tables(0).Rows(K).Item("HME").ToString
            Mid(SEIRA, fCOLS(3, 1), fCOLS(3, 2)) = DS.Tables(0).Rows(K).Item("KODE").ToString
            Mid(SEIRA, fCOLS(4, 1), fCOLS(4, 2)) = DS.Tables(0).Rows(K).Item("ONO").ToString

            Mid(SEIRA, fCOLS(5, 1), fCOLS(5, 2)) = DS.Tables(0).Rows(K).Item("TIMM").ToString
            Mid(SEIRA, fCOLS(6, 1), fCOLS(6, 2)) = Format(DS.Tables(0).Rows(K).Item("POSO"), "#####")
            Mid(SEIRA, fCOLS(7, 1), fCOLS(7, 2)) = DS.Tables(0).Rows(K).Item("EKPT").ToString

            Mid(SEIRA, fCOLS(8, 1), fCOLS(8, 2)) = DS.Tables(0).Rows(K).Item("FPA").ToString
            'Mid(SEIRA, fCOLS(9, 1), fCOLS(9, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            'Mid(SEIRA, fCOLS(10, 1), fCOLS(10, 2)) = DS.Tables(0).Rows(K).Item("ATIM").ToString
            sw.WriteLine(SEIRA)

        Next
        sw.Close()
    End Sub
End Class