
Imports System.Data.SqlServerCe
Public Class apografh
    '--------------------------------------------------------------------
    ' FILENAME: APOGRAFH.cs
    '
    ' Copyright(c) 2006 Symbol Technologies Inc. All rights reserved.
    '
    ' DESCRIPTION:
    '
    ' NOTES:
    '
    ' 
    '--------------------------------------------------------------------

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneXIT.Click
        ' You must disable the scanner before exiting the application in order 
        ' to release all the resources.
        Barcode1.EnableScanner = False
        Me.Close()

    End Sub

    Private Sub ButtonExit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ButtoneXIT.KeyDown
        ' Checks if the Enter key (character code 13) was used.
        If e.KeyValue = 13 Then
            ButtonExit_Click(Nothing, e)
        End If
    End Sub

    Private Sub APOGRAFH_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Me.ListBox1.Focus()
    End Sub

    Private Sub Barcode1_OnRead(ByVal sender As System.Object, ByVal readerData As Symbol.Barcode.ReaderData)
        ' maintain a maximum of 10 items in the list box
        While ListBox1.Items.Count >= 10
            ListBox1.Items.RemoveAt(0)
        End While

        ' Write the scanned data and type (symbology) to the list box
        ListBox1.Items.Add(readerData.Text + ";" + readerData.Type.ToString)
    End Sub

    Private Sub Barcode1_OnStatus(ByVal sender As System.Object, ByVal barcodeStatus As Symbol.Barcode.BarcodeStatus)
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

    Private Sub APOGRAFH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ScaleDown(Me)
        Me.ListBox1.Focus()
    End Sub

    Private Sub ButtoneXIT_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoneXIT.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'пяим апо то CLASS бафы :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand


        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from EID where KOD ='0001'", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        If DS.Tables(0).Rows.Count > 0 Then
            ' KOD.Text = DS.Tables(0).Rows(0).Item("KOD")
        End If

        objcon.Close()









    End Sub
End Class