Imports System.Data.SqlServerCe


Imports System
Imports System.IO


Public Class SQL

    Private Sub SQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'пыс тяевы лиа емтокг стом SQLSERVER CE 

        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand

        ListBox1.Items.Clear()



        If Len(TextBox1.Text) < 2 Then
            MsgBox("дем ояисате аявеио ")
            Exit Sub
        End If


        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        Dim SQL As String
        Dim mTable As String

        mTable = ComboBox1.Text

        SQL = TextBox1.Text ' "select * from " + mTable

        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()



        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        DA.SelectCommand = objcmd
        DA.Fill(DS, mTable)
        Dim K As Long
        Dim S As String
        Dim L As Integer

        For K = 0 To DS.Tables(mTable).Rows.Count - 1
            S = Format(K, "##0") + " "

            For L = 0 To 3
                If IsNumeric(DS.Tables(mTable).Rows(K).Item(L)) Then
                    S = S + Format(DS.Tables(mTable).Rows(K).Item(L), "####.#") + " "
                Else
                    S = S + DS.Tables(mTable).Rows(K).Item(L) + " "
                End If
            Next

            ListBox1.Items.Add(S)


        Next
        ListBox1.Refresh()

        objcon.Close()




    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim L As Long
        L = ExecuteSQL(TextBox1.Text)

    End Sub
End Class