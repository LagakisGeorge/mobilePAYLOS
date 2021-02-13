Imports System.IO
Imports System.Data.SqlServerCe



Public Class BOHU
    Dim comm1 As New System.IO.Ports.SerialPort
    Dim fDS As New System.Data.DataSet
    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim K As Integer

        get_table("select * from parastat")
        ComboBox1.Items.Clear()
        For K = 0 To fDS.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(fDS.Tables(0).Rows(K).Item("PERIGRAFH"))
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a, b, c, K As Long
        a = InputBox("аявийг секида ", "", 1)
        b = InputBox("аявийг секида ", "", 2)
        If Not File.Exists("F95.TXT") Then
            MsgBox("дем упаявеи то аявеио F95.TXT")
            Exit Sub
        End If


        Dim LINES(5) As String, LINE As String = ""


        Dim COMMPORT As String

        Using sr As StreamReader = New StreamReader("PARAMETROI.TXT", System.Text.Encoding.Default)
            COMMPORT = Mid(sr.ReadLine(), 1, 4)
            sr.Close()
        End Using


        Using sr As StreamReader = New StreamReader("F95.TXT", System.Text.Encoding.Default)
            For K = 1 To 5
                LINE = sr.ReadLine()
                If LINE Is Nothing Then
                    LINES(K) = ""
                Else
                    LINES(K) = LINE
                End If
            Next
            sr.Close()

        End Using




        'амоицы тгм хуяа тгм сеияиайг
        'еполемес 7 сеияес доукеуоум лиа ваяа циа то амоицла
        '   циа ейтупысг comm1.Write(" " + Chr(10)) йаи COMM1.CLOSE() KLEINO THN PORTA
        comm1.BaudRate = 9600
        comm1.Parity = Ports.Parity.None
        comm1.PortName = COMMPORT ' "COM8"
        comm1.DataBits = 8
        'comm1.CtsHolding()
        comm1.Handshake = IO.Ports.Handshake.XOnXOff
        comm1.StopBits = Ports.StopBits.One
        comm1.Encoding = System.Text.Encoding.Default
        comm1.Open()






        For c = a To b
            comm1.Write(Chr(27) + "C0" + Chr(8))
            comm1.Write(to437(LINES(1) + "                No " + Format(c, "#####")) + Chr(10))
            For K = 2 To 5
                comm1.Write(to437(LINES(K)) + Chr(10))
            Next
            System.Threading.Thread.Sleep(1000)
            comm1.Write(Chr(12))
        Next


        comm1.Close()


    End Sub
    Private Sub get_table(ByVal sql As String)

        Dim objcon As SqlCeConnection, objcmd As New SqlCeCommand, DA As New SqlCeDataAdapter
        objcon = New SqlCeConnection("Data Source ='AAACE.SDF';")
        objcmd = New SqlCeCommand(sql, objcon)
        objcmd.Connection.Open()
        fDS.Clear()

        DA.SelectCommand = objcmd
        DA.Fill(fDS, "parastat")
        objcon.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim L As Long = ExecuteSQL(TextBox1.Text)


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        get_table("select * from parastat")
        aritmisi.Text = fDS.Tables(0).Rows(ComboBox1.SelectedIndex).Item("aritmisi")

        ComboBox1.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim L As Long
        L = ExecuteSQL("UPDATE PARASTAT SET ARITMISI=" + aritmisi.Text + " WHERE ID=" + Format(ComboBox1.SelectedIndex + 1, "#####"))
        ComboBox1.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim L As Long = ExecuteSQL("ALTER TABLE APOG ADD  RAFI SINGLE;")


    End Sub
End Class