Option Strict Off
Option Explicit On
Class Form11
    Inherits System.Windows.Forms.Form

    Dim fSCR As Object ' SCRIPT CONTROL

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        fSCR = CreateObject("MSScriptControl.ScriptControl")
        'UPGRADE_WARNING: Couldn't resolve default property of object fSCR.language. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        fSCR.language = "vbscript"
        'fSCR.AddObject "ADODC2", Adodc2
        'UPGRADE_WARNING: Couldn't resolve default property of object fSCR.AddObject. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        fSCR.AddObject("mactext", mactext)


        Me.Text = mac("5+5")







        'UPGRADE_NOTE: Object fSCR may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        fSCR = Nothing




    End Sub
    Function mac(ByVal S As String) As String
        'δινω ενα στρινγκ και μου επιστρέφει μία τιμή
        Dim X As Object
        On Error GoTo 0
        mactext.Text = "   "
        On Error GoTo err2
        'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        X = "MACtEXT.Text = " & S
        'UPGRADE_WARNING: Couldn't resolve default property of object fSCR.ExecuteStatement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        fSCR.ExecuteStatement(X)

        mac = mactext.Text

        Exit Function

err2:
        'UPGRADE_WARNING: Couldn't resolve default property of object X. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Me.Text = X
        mac = "  "
        Resume Next
    End Function
End Class