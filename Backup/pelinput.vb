Imports System.Data.SqlServerCe


Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Imports System.Data.SqlServerCe

        'ÐÙÓ ÔÑÅ×Ù ÌÉÁ ÅÍÔÏËÇ ÓÔÏÍ SQLSERVER CE 

        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim n As Long

        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand, SQL As String
        Dim DS As New System.Data.DataSet, DA As New SqlCeDataAdapter
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        SQL = "select KOD from PEL ORDER BY KOD DESC"
        objcmd = New SqlCeCommand(SQL, objcon)
        objcmd.Connection.Open()
        DA.SelectCommand = objcmd
        DA.Fill(DS, "PEL")
        Dim K As Long
        K = Val(DS.Tables("PEL").Rows(K).Item("KOD")) + 1
        KOD.Text = Format(K, "0000")
        'KOD.Text = "0093"

        SQL = "INSERT INTO PEL (KOD,EPO,DIE,EPA,POL,AFM,DOY,NEOS,DEH) VALUES ('"
        SQL = SQL + KOD.Text + "','" + Mid(EPO.Text, 1, 30) + "','" + Mid(DIE.Text, 1, 30) + "','"
        SQL = SQL + Mid(EPA.Text, 1, 25) + "','" + Mid(POL.Text, 1, 20) + "','" + Mid(AFM.Text, 1, 10) + "','"
        SQL = SQL + Mid(DOY.Text, 1, 4) + "',1,'" + DEH.Text + "')"
        objcmd = New SqlCeCommand(SQL, objcon)
        n = objcmd.ExecuteNonQuery()
        objcmd.Connection.Close()

        If n > 0 Then
            MsgBox("êáôå÷ùñçèç")
        End If
        EPO.Text = ""
        EPA.Text = ""
        DOY.Text = ""
        POL.Text = ""
        AFM.Text = ""
        DIE.Text = ""


    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'ÐÑÉÍ ÁÐÏ ÔÏ CLASS ÂÁÆÙ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand


        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from PEL where KOD ='" + TextBox1.Text + "'", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        If DS.Tables(0).Rows.Count > 0 Then
            KOD.Text = DS.Tables(0).Rows(0).Item("KOD")
            EPO.Text = DS.Tables(0).Rows(0).Item("EPO")
            DIE.Text = DS.Tables(0).Rows(0).Item("DIE")
            EPA.Text = DS.Tables(0).Rows(0).Item("EPA")
            AFM.Text = DS.Tables(0).Rows(0).Item("AFM")
            DOY.Text = DS.Tables(0).Rows(0).Item("DOY")
            TYP.Text = DS.Tables(0).Rows(0).Item("TYP")
            DEH.Text = DS.Tables(0).Rows(0).Item("DEH")
        End If

        objcon.Close()












    End Sub
End Class