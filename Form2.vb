Imports System.Data.SqlServerCe
Imports System
Imports System.IO


Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If File.Exists("PEL.TXT") Then
        Else
            MsgBox("дем упаявеи то аявеио PEL.TXT")
            Exit Sub
        End If


        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand

        Dim C As String

        objcon = New SqlCeConnection("Data Source ='aaa.sdf';")

        objcmd = New SqlCeCommand("DELETE FROM  PEL; ", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()
        Dim N As Integer
        N = 0
        Dim C2 As String


        'диабафеи око сам аявеио
        'Using sr As StreamReader = New StreamReader("PEL.txt")
        '    C2 = sr.ReadToEnd()
        'End Using


        'та диабафеи сам RECORDS
        'Public Shared Sub FileGet( _
        'ByVal FileNumber As Integer, _
        '    ByRef Value As ValueType, _
        'ByVal RecordNumber As Long )

        '    Dim FileNumber As Integer
        '    Dim Value As ValueType
        '    Dim RecordNumber As Long

        '  FileSystem.FileGet(FileNumber, Value, RecordNumber)



        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF7) та бцафеи 2 жояес лиа жояа айатакабистийа йаи лиа еккгмийа
        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF8) та бцафеи 2 жояес лиа жояа йема йаи лиа еккгмийа

        Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.Default)


            Dim line As String
            Do



                line = sr.ReadLine()
                If line Is Nothing Then
                Else
                    C = "" + line.ToString
                    ListBox1.Items.Add(C)

                    C2 = ListBox1.Items(N).ToString

                    objcmd = New SqlCeCommand("INSERT INTO PEL (KOD,EPO,DIE) VALUES ('" + Mid(ListBox1.Items(N).ToString, 1, 4) + "','" + Mid(C2, 5, 20) + "','" + Mid(ListBox1.Items(N).ToString, 20, 20) + "'); ", objcon)
                    objcmd.ExecuteNonQuery()
                    N = N + 1
                End If
            Loop Until line Is Nothing


            ListBox1.Refresh()
        End Using

        MsgBox("ециме еисацыцг " + Chr(13) + Format(N, "##0") + " пекатым")





        objcon.Close()

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ''пыс тяевы лиа емтокг стом SQLSERVER CE 

        ''пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        'Dim objcon As SqlCeConnection
        'Dim objcmd As New SqlCeCommand
        'objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
        'objcmd = New SqlCeCommand("INSERT INTO PEL (EPO) VALUES ('SASASA'); ", objcon)
        'objcmd.Connection.Open()
        'objcmd.ExecuteNonQuery()













        'пыс тяевы лиа емтокг стом SQLSERVER CE 

        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
        Dim SQL As String
        SQL = "select * from PEL"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()



        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "PEL")

        Dim C As String

        If Val(C) > 0 Then
            C = DS.Tables("PEL").Rows(1).Item("EPO")
        End If

        Dim K As Long

        For K = 0 To DS.Tables("PEL").Rows.Count - 1
            ListBox1.Items.Add(Format(K, "000") + DS.Tables("PEL").Rows(K).Item("EPO"))
        Next






    End Sub

   

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim K As Integer
        For K = 128 To 255
            ListBox1.Items.Add(Chr(K) + " " + Format(K, "000"))
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click



        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand

        Dim C As String

        objcon = New SqlCeConnection("Data Source ='aaa.sdf';")

        objcmd = New SqlCeCommand("DELETE FROM  PEL; ", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()
        Dim N As Integer
        N = 0
        Dim C2 As String


        'диабафеи око сам аявеио
        'Using sr As StreamReader = New StreamReader("PEL.txt")
        '    C2 = sr.ReadToEnd()
        'End Using


        'та диабафеи сам RECORDS
        'Public Shared Sub FileGet( _
        'ByVal FileNumber As Integer, _
        '    ByRef Value As ValueType, _
        'ByVal RecordNumber As Long )

        '    Dim FileNumber As Integer
        '    Dim Value As ValueType
        '    Dim RecordNumber As Long

        '  FileSystem.FileGet(FileNumber, Value, RecordNumber)



        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF7) та бцафеи 2 жояес лиа жояа айатакабистийа йаи лиа еккгмийа
        'Using sr As StreamReader = New StreamReader("PEL.txt", System.Text.Encoding.UTF8) та бцафеи 2 жояес лиа жояа йема йаи лиа еккгмийа
        If File.Exists("EID.TXT") Then
        Else
            MsgBox("дем упаявеи то аявеио EID.TXT")
            Exit Sub
        End If
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
                        objcmd = New SqlCeCommand("INSERT INTO EID (KOD,ONO,LTI) VALUES ('" + Mid(C2, 1, 4) + "','" + Mid(C2, 15, 30) + "'," + Mid(C2, 55, 8) + "); ", objcon)
                        objcmd.ExecuteNonQuery()
                        N = N + 1
                    End If
                End If
            Loop Until line Is Nothing
            sr.Close()

            ListBox1.Refresh()
        End Using

        MsgBox("ециме еисацыцг " + Chr(13) + Format(N, "##0") + " EIдым")

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
End Class
