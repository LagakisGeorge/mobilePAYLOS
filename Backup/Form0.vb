Imports System.Data.SqlServerCe


Imports System
Imports System.IO


Public Class Form0






    Private Sub BindingSource1_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    '    '–—…Õ ¡–œ ‘œ CLASS ¬¡∆Ÿ :  Imports System.Data.SqlServerCe
    '    Dim objcon As SqlCeConnection
    '    Dim objcmd As New SqlCeCommand

    '    ListBox1.Items.Clear()


    '    objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
    '    Dim SQL As String
    '    Dim mTable As String

    '    mTable = ComboBox1.Text

    '    SQL = "select * from EGGTIM"

    '    objcmd = New SqlCeCommand(SQL, objcon)
    '    objcmd.Connection.Open()



    '    Dim DS As New System.Data.DataSet
    '    Dim DA As New SqlCeDataAdapter

    '    DA.SelectCommand = objcmd
    '    DA.Fill(DS, mTable)
    '    Dim K As Long
    '    Dim S As String

    '    ' Create an instance of StreamWriter to write text to a file.
    '    Using sw As StreamWriter = New StreamWriter("lagakisFile.txt")
    '        ' Add some text to the file.

    '        For K = 0 To DS.Tables(mTable).Rows.Count - 1
    '            S = DS.Tables(mTable).Rows(K).Item("ATIM").ToString
    '            S = S + "," + DS.Tables(mTable).Rows(K).Item("HME").ToString
    '            S = S + "," + DS.Tables(mTable).Rows(K).Item("KODE").ToString
    '            S = S + "," + Replace(DS.Tables(mTable).Rows(K).Item("POSO").ToString, ",", ".")
    '            S = S + "," + Replace(DS.Tables(mTable).Rows(K).Item("TIMM").ToString, ",", ".")
    '            S = S + "," + Replace(DS.Tables(mTable).Rows(K).Item("EKPT").ToString, ",", ".")
    '            sw.WriteLine(S)
    '        Next
    '        'sw.Write("This is the ")
    '        'sw.WriteLine("header for the file.")
    '        'sw.WriteLine("====================.")
    '        'sw.WriteLine("-------------------")
    '        '' Arbitrary objects can also be written to the file.
    '        'sw.Write("The date is: ")
    '        'sw.WriteLine(DateTime.Now)
    '        sw.Close()
    '    End Using

    '    objcon.Close()

    'End Sub

    


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TIMOLOGHSH.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        IMPORT.Show()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AaaDataSet.PEL' table. You can move, or remove it, as needed.
        '  Me.PELTableAdapter.Fill(Me.AaaDataSet.PEL)
        ' ComboBox1.Text = ComboBox1.Items(0).ToString
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  TextBox1.Text = " SELECT * FROM " + ComboBox1.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TIMOLPETR.Show()
        'STELNEI MIA KENH SELIDA 8 INCH STON EKTYPOTH
        'Dim comm1 As New System.IO.Ports.SerialPort
        'comm1.BaudRate = 9600
        'comm1.Parity = Ports.Parity.None
        'comm1.PortName = "COM1"
        'comm1.DataBits = 8
        'comm1.StopBits = Ports.StopBits.One
        'comm1.Encoding = System.Text.Encoding.Default
        'comm1.Open()
        'comm1.Write(Chr(27) + "C0" + Chr(8))
        'comm1.Write(Chr(12))
        'comm1.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        BOHU.Show()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Eidos.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        APOG.Show()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SHOWAPOGR.Show()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim FDS2 As New System.Data.DataSet
        Dim k As Long
        Dim N As Long


        k = openSQL("SELECT ERG,sum(POS) AS S ,RAFI FROM APOG GROUP BY RAFI,ERG", FDS2)


        N = 0
        File.Delete("APOG.TXT")

        Using sw As StreamWriter = New StreamWriter("APOG.TXT")

            For N = 0 To FDS2.Tables(0).Rows.Count - 1
                sw.WriteLine(FDS2.Tables(0).Rows(N).Item("ERG").ToString + "  " + FDS2.Tables(0).Rows(N).Item("S").ToString + "  " + FDS2.Tables(0).Rows(N).Item("RAFI").ToString)
                If N Mod 10 = 0 Then
                    Me.Text = Format(N, "#####")
                End If
            Next

            sw.Close()
            MsgBox("OK œÀœ À«—Ÿ»« ≈")
        End Using


    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        symbol1.Show()

    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Form11.Show()

    End Sub
End Class
