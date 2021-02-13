'--------------------------------------------------------------------
' FILENAME: Form1.cs
'
' Copyright(c) 2006 Symbol Technologies Inc. All rights reserved.
'
' DESCRIPTION:
'
' NOTES:
'
' 
'--------------------------------------------------------------------

Imports System.Data.SqlServerCe
Imports System
Imports System.IO

Public Class Form11
    Dim fobjcon As SqlCeConnection, fobjcmd As New SqlCeCommand
    Dim fDS As New System.Data.DataSet
    Dim fDA As New SqlCeDataAdapter
    Dim found As Integer


    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        ' You must disable the scanner before exiting the application in order 
        ' to release all the resources.
        Barcode1.EnableScanner = False
        Me.Hide() 'Close()


    End Sub

    Private Sub ButtonExit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ButtonExit.KeyDown
        ' Checks if the Enter key (character code 13) was used.
        If e.KeyValue = 13 Then
            ButtonExit_Click(Nothing, e)
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.ListBox1.Focus()
    End Sub
    Sub FIND_EID()
        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand
        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from OLA where ERG ='" + TextBox1.Text + "'", objcon)
        objcmd.Connection.Open()
        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        If DS.Tables(0).Rows.Count > 0 Then
            Label1.Text = dos2U(DS.Tables(0).Rows(0).Item("ONO"))
            Label1.BackColor = Color.LightBlue
            Label4.Text = DS.Tables(0).Rows(0).Item("POS")
            Label6.Text = DS.Tables(0).Rows(0).Item("LTI5")
        Else
            Label1.Text = "дем бяехгйе " + TextBox1.Text
            Label1.BackColor = Color.Magenta
            TextBox1.Text = ""
        End If
        objcon.Close()
        While ListBox1.Items.Count >= 10
            ListBox1.Items.RemoveAt(0)
        End While
    End Sub

    Private Sub Barcode1_OnRead(ByVal sender As System.Object, ByVal readerData As Symbol.Barcode.ReaderData) Handles Barcode1.OnRead
        ' maintain a maximum of 10 items in the list box
        TextBox1.Text = readerData.Text

        If Len(Trim(TextBox1.Text)) <= 1 Then
            Exit Sub
        End If

        Dim FDS2 As New System.Data.DataSet
        Dim k As Long
        k = openSQL("select * from OLA where ERG ='" + TextBox1.Text + "'", FDS2)


        If FDS2.Tables(0).Rows.Count > 0 Then
            'Label4.Text = FDS2.Tables(0).Rows(0).Item(0)
            Label1.Text = dos2U(FDS2.Tables(0).Rows(0).Item("ONO"))
            Label1.BackColor = Color.LightBlue

            Label4.Text = FDS2.Tables(0).Rows(0).Item("POS").ToString
            Label6.Text = FDS2.Tables(0).Rows(0).Item("LTI5").ToString


            '  TextBox2.Focus()
        Else
            Label1.Text = "дем бяехгйе " + TextBox1.Text
            Label1.BackColor = Color.Magenta
            TextBox1.Text = ""
            ' TextBox2.Focus()
        End If


        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        '   Dim sql As String


        Dim x As String
        x = ""
        'Dim n As Long
        'If CheckBox1.Checked = True Then
        '    TextBox2.Text = 1
        '    sql = "INSERT INTO APOG (ERG,POS) VALUES ('" + TextBox1.Text + "',1)"
        '    Try
        '        n = ExecuteSQL(sql)
        '    Catch ex As Exception
        '        ListBox1.Items.Add("кахос " & ex.Message)
        '    End Try
        '    TextBox2.Text = ""
        '    TextBox1.Text = ""
        '    TextBox1.Focus()
        '    '  Barcode1.EnableScanner = True
        'End If


        Exit Sub





    End Sub

    Private Sub Barcode1_OnStatus(ByVal sender As System.Object, ByVal barcodeStatus As Symbol.Barcode.BarcodeStatus) Handles Barcode1.OnStatus
        StatusBar1.Text = barcodeStatus.Text
    End Sub

    'This function scales down the given Form & its child controls in order to
    'make them completely viewable, based on the screen width & height.
    Sub ScaleDown(ByVal frm As System.Windows.Forms.Form)

        Dim scrWidth As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
        Dim scrHeight As Integer = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height
        Dim cntrl As System.Windows.Forms.Control
        If (scrWidth < frm.Width) Then
            For Each cntrl In frm.Controls

                cntrl.Width = CInt(((cntrl.Width) * (scrWidth)) / (frm.Width))
                cntrl.Left = CInt(((cntrl.Left) * (scrWidth)) / (frm.Width))
            Next cntrl
        End If

        If (scrHeight < frm.Height) Then
            For Each cntrl In frm.Controls

                cntrl.Height = CInt(((cntrl.Height) * (scrHeight)) / (frm.Height))
                cntrl.Top = CInt(((cntrl.Top) * (scrHeight)) / (frm.Height))

            Next cntrl
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ScaleDown(Me)
        fobjcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim FDS2 As New System.Data.DataSet
        Dim k As Long

        k = openSQL("SELECT * FROM APOG", FDS2)

        Label1.Text = FDS2.Tables(0).Rows(0).Item(0).ToString


    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox1.BackColor = Color.Yellow
    End Sub

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox1.BackColor = Color.White
    End Sub


    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Barcode1.EnableScanner = True

    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.BackColor = Color.Yellow

        ' Barcode1.EnableScanner = True
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        '  Dim sql As String


        Dim x As String
        x = ""
        ' Dim n As Long

        If e.KeyCode = 13 And Len(Trim(TextBox1.Text)) > 0 Then
            Try
                FIND_EID()
            Catch ex As Exception
                ListBox1.Items.Add("кахос " & ex.Message)
            End Try
        End If





    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        TextBox1.BackColor = Color.White
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
