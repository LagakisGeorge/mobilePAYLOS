Imports System.Data.SqlServerCe

Public Class Eidos

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'ΠΡΙΝ ΑΠΟ ΤΟ CLASS ΒΑΖΩ :  Imports System.Data.SqlServerCe
        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand


        Dim DS As New System.Data.DataSet
        Dim DA As New SqlCeDataAdapter

        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand("select * from EID where KOD ='" + TextBox1.Text + "'", objcon)
        objcmd.Connection.Open()

        DA.SelectCommand = objcmd
        DA.Fill(DS, "parastat")
        If DS.Tables(0).Rows.Count > 0 Then
            KOD.Text = DS.Tables(0).Rows(0).Item("KOD")
            ONO.Text = A2U(DS.Tables(0).Rows(0).Item("ONO"))
            LTI.Text = DS.Tables(0).Rows(0).Item("LTI")
            MON.Text = A2U(DS.Tables(0).Rows(0).Item("MON"))
            FPA.Text = DS.Tables(0).Rows(0).Item("FPA")
        End If

        objcon.Close()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim n As Long

        n = ExecuteSQL("update EID SET ONO='" + ONO.Text + "',LTI=" + LTI.Text + ",MON='" + MON.Text + "',FPA=" + FPA.Text + " WHERE KOD='" + KOD.Text + "'")
        If n > 0 Then
            MsgBox("κατεχωρηθη")
        End If
        KOD.Text = ""
        MON.Text = ""
        ONO.Text = ""
        FPA.Text = ""
        LTI.Text = ""

    End Sub

    Private Sub DIE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTI.TextChanged

    End Sub
End Class