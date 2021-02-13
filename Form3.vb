Imports System.Data.SqlServerCe


Imports System
Imports System.IO


Public Class TIMOLOGHSH
    Dim objcon As SqlCeConnection
    Dim objcmd As New SqlCeCommand
    Dim mRow As Integer

    
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'AaaDataSet1.EDIT' table. You can move, or remove it, as needed.
        Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
        mRow = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'пыс тяевы лиа емтокг стом SQLSERVER CE 

        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        '  Dim objcon As SqlCeConnection
        '  Dim objcmd As New SqlCeCommand
        ' objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
        objcmd = New SqlCeCommand("UPDATE EDIT SET KOD='    ';", objcon)
        objcmd.Connection.Open()
        objcmd.ExecuteNonQuery()

        objcmd = New SqlCeCommand("UPDATE EDIT SET ONO='---  ';", objcon)
        objcmd.ExecuteNonQuery()



        Dim SQL As String
        SQL = "select * from EDIT"
        objcmd = New SqlCeCommand(SQL, objcon)
        'objcmd.Connection.Open()

        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        DA.SelectCommand = objcmd
        DA.Fill(DS, "EDIT")
        Dim K As Integer
        For K = 0 To DS.Tables("EDIT").Rows.Count - 1
            DS.Tables("EDIT").Rows(K).Item("POSO") = K
        Next



        objcmd.Connection.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If mRow = 0 Then
            'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
            Dim objcon As SqlCeConnection
            Dim objcmd As New SqlCeCommand
            objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
            Dim SQL As String
            If Len(N.Text) > 0 Then
                SQL = "select * from EID WHERE ONO LIKE '" + N.Text + "%'"
            Else
                SQL = "select * from EID WHERE KOD='" + MKOD.Text + "'"
            End If

            objcmd = New SqlCeCommand(SQL, objcon)
            objcmd.Connection.Open()

            Dim DS As New System.Data.DataSet
            Dim DA As New SqlCeDataAdapter
            DA.SelectCommand = objcmd
            DA.Fill(DS, "EID")
            Dim K As Long

            ListBox1.Visible = True
            For K = 0 To DS.Tables("EID").Rows.Count - 1
                ListBox1.Items.Add(Format(K, "##0") + DS.Tables("eid").Rows(K).Item("kod") + " " + DS.Tables("eid").Rows(K).Item("ONO"))
            Next

            objcmd.Connection.Close()

        End If
        'If c.Text = 2 Then
        '    objcmd = New SqlCeCommand("UPDATE EDIT SET ono='" + MKOD.Text + "' WHERE ID=" + N.Text, objcon)
        'Else
        '    objcmd = New SqlCeCommand("UPDATE EDIT SET KOD='" + MKOD.Text + "' WHERE ID=" + N.Text, objcon)
        'End If

        'objcmd.Connection.Open()
        'objcmd.ExecuteNonQuery()
        'Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
        'DataGrid1.Refresh()
        'objcmd.Connection.Close()

    End Sub

    Private Sub DataGrid1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.Click
        'бкепы поиа сеияа  патгсе сто GRID
        ' Label2.Text = DataGrid1.CurrentCell.RowNumber



    End Sub

    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection
        Dim objcmd As New SqlCeCommand
        objcon = New SqlCeConnection("Data Source ='aaa.sdf';")
        Dim SQL As String
        If Len(N.Text) > 0 Then
            SQL = "select * from PEL WHERE EPO LIKE '" + N.Text + "%'"
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

        For K = 0 To DS.Tables("PEL").Rows.Count - 1
            ListBox1.Items.Add(Format(K, "##0") + DS.Tables("PEL").Rows(K).Item("kod") + " " + DS.Tables("PEL").Rows(K).Item("EPO"))
        Next





    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If Len(Label2.Text) = 0 Then ' евеи бяеи пекатг йаи пале циа еидос

            Label2.Text = ListBox1.SelectedItem.ToString
            'Label4.Text = ListBox1.SelectedIndex

            ListBox1.Visible = False
        Else
            Dim objcon As SqlCeConnection
            Dim objcmd As New SqlCeCommand
            objcon = New SqlCeConnection("Data Source ='aaa.sdf';")

            objcmd = New SqlCeCommand("UPDATE EDIT SET kod='" + Mid(ListBox1.SelectedItem.ToString, 1, 4) + "',ono='" + Mid(ListBox1.SelectedItem.ToString, 5, 24) + "' WHERE ID=" + Format(mRow, "###0"), objcon)
            objcmd.Connection.Open()

            objcmd.ExecuteNonQuery()
            Me.EDITTableAdapter.Fill(Me.AaaDataSet1.EDIT)
            DataGrid1.Refresh()
            objcmd.Connection.Close()

        End If

    End Sub

    
End Class