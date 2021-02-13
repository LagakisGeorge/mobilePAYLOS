<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TIMOLPETR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ONO_POSO = New System.Windows.Forms.TextBox
        Me.EIDOS = New System.Windows.Forms.Button
        Me.MKOD = New System.Windows.Forms.TextBox
        Me.NEO_EIDOS = New System.Windows.Forms.Button
        Me.AaaDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AaaDataSet1 = New CETIMOL3.aaaDataSet1
        Me.EDITBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.AaaDataSet = New CETIMOL3.aaaDataSet
        Me.TIMH = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PEL = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.EKPT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.EDITTableAdapter = New CETIMOL3.aaaDataSet1TableAdapters.EDITTableAdapter
        Me.EditTableAdapter1 = New CETIMOL3.aaaDataSet1TableAdapters.EDITTableAdapter
        Me.Button14 = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.atim = New System.Windows.Forms.Label
        Me.FPA = New System.Windows.Forms.Label
        Me.AJIA = New System.Windows.Forms.Label
        Me.MON = New System.Windows.Forms.Label
        Me.ekt = New System.Windows.Forms.CheckBox
        Me.TRP = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'ONO_POSO
        '
        Me.ONO_POSO.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ONO_POSO.Location = New System.Drawing.Point(60, 74)
        Me.ONO_POSO.Name = "ONO_POSO"
        Me.ONO_POSO.Size = New System.Drawing.Size(51, 26)
        Me.ONO_POSO.TabIndex = 9
        '
        'EIDOS
        '
        Me.EIDOS.Location = New System.Drawing.Point(-2, 148)
        Me.EIDOS.Name = "EIDOS"
        Me.EIDOS.Size = New System.Drawing.Size(78, 10)
        Me.EIDOS.TabIndex = 8
        Me.EIDOS.Text = "≈È‰"
        '
        'MKOD
        '
        Me.MKOD.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MKOD.Location = New System.Drawing.Point(0, 74)
        Me.MKOD.Name = "MKOD"
        Me.MKOD.Size = New System.Drawing.Size(60, 26)
        Me.MKOD.TabIndex = 7
        '
        'NEO_EIDOS
        '
        Me.NEO_EIDOS.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.NEO_EIDOS.Location = New System.Drawing.Point(134, 100)
        Me.NEO_EIDOS.Name = "NEO_EIDOS"
        Me.NEO_EIDOS.Size = New System.Drawing.Size(104, 22)
        Me.NEO_EIDOS.TabIndex = 6
        Me.NEO_EIDOS.Text = "Õ≈œ ≈…ƒœ”"
        '
        'AaaDataSetBindingSource
        '
        Me.AaaDataSetBindingSource.DataSource = Me.AaaDataSet1
        Me.AaaDataSetBindingSource.Position = 0
        '
        'AaaDataSet1
        '
        Me.AaaDataSet1.DataSetName = "aaaDataSet1"
        Me.AaaDataSet1.Locale = New System.Globalization.CultureInfo("en-GB")
        Me.AaaDataSet1.Prefix = ""
        Me.AaaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EDITBindingSource
        '
        Me.EDITBindingSource.DataMember = "EDIT"
        Me.EDITBindingSource.DataSource = Me.AaaDataSetBindingSource
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGrid1.DataSource = Me.EDITBindingSource
        Me.DataGrid1.Location = New System.Drawing.Point(-2, 36)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(237, 10)
        Me.DataGrid1.TabIndex = 5
        Me.DataGrid1.Visible = False
        '
        'AaaDataSet
        '
        Me.AaaDataSet.DataSetName = "aaaDataSet"
        Me.AaaDataSet.Locale = New System.Globalization.CultureInfo("en-GB")
        Me.AaaDataSet.Prefix = ""
        Me.AaaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TIMH
        '
        Me.TIMH.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TIMH.Location = New System.Drawing.Point(110, 74)
        Me.TIMH.Name = "TIMH"
        Me.TIMH.Size = New System.Drawing.Size(51, 26)
        Me.TIMH.TabIndex = 10
        Me.TIMH.Tag = "1"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 14)
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.Items.Add("¡–œƒ≈…Œ« À…¡Õ… «”-ƒ¡   l")
        Me.ComboBox1.Items.Add("¡–œƒ≈…Œ« À…¡Õ… «”         L")
        Me.ComboBox1.Items.Add("ƒ≈À‘…œ ¡–œ”‘œÀ«”         A")
        Me.ComboBox1.Items.Add("‘…ÃœÀœ√…œ –ŸÀ«”«”       t")
        Me.ComboBox1.Items.Add("‘…ÃœÀœ√…œ –ŸÀ«”«”-ƒ¡ T")
        Me.ComboBox1.Location = New System.Drawing.Point(3, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(175, 23)
        Me.ComboBox1.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(2, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 33)
        Me.Label3.Text = " ˘‰.–ÂÎ"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(60, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.Text = "À…‘—¡"
        '
        'PEL
        '
        Me.PEL.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PEL.Location = New System.Drawing.Point(197, 235)
        Me.PEL.Name = "PEL"
        Me.PEL.Size = New System.Drawing.Size(138, 22)
        Me.PEL.TabIndex = 15
        Me.PEL.Text = "–ÂÎ"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ListBox1.Location = New System.Drawing.Point(2, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(233, 21)
        Me.ListBox1.TabIndex = 16
        '
        'EKPT
        '
        Me.EKPT.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.EKPT.Location = New System.Drawing.Point(172, 280)
        Me.EKPT.Name = "EKPT"
        Me.EKPT.Size = New System.Drawing.Size(10, 23)
        Me.EKPT.TabIndex = 20
        Me.EKPT.Tag = "1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(108, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.Text = "‘ÈÏﬁ"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(150, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 20)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "≈KTY–Ÿ”«"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(0, 162)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 40)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "7"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.Location = New System.Drawing.Point(78, 162)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 40)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "8"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.Location = New System.Drawing.Point(158, 162)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(80, 40)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "9"
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.Location = New System.Drawing.Point(0, 202)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 40)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "4"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button6.Location = New System.Drawing.Point(78, 202)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(80, 40)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "5"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button7.Location = New System.Drawing.Point(158, 202)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(80, 40)
        Me.Button7.TabIndex = 35
        Me.Button7.Text = "6"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button8.Location = New System.Drawing.Point(158, 240)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(80, 40)
        Me.Button8.TabIndex = 38
        Me.Button8.Text = "3"
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button9.Location = New System.Drawing.Point(78, 240)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(80, 40)
        Me.Button9.TabIndex = 37
        Me.Button9.Text = "2"
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button10.Location = New System.Drawing.Point(0, 240)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(80, 40)
        Me.Button10.TabIndex = 36
        Me.Button10.Text = "1"
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button11.Location = New System.Drawing.Point(158, 280)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(80, 40)
        Me.Button11.TabIndex = 41
        Me.Button11.Text = "<="
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button12.Location = New System.Drawing.Point(78, 280)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(80, 40)
        Me.Button12.TabIndex = 40
        Me.Button12.Text = ","
        '
        'Button13
        '
        Me.Button13.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button13.Location = New System.Drawing.Point(0, 280)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(80, 40)
        Me.Button13.TabIndex = 39
        Me.Button13.Text = "0"
        '
        'EDITTableAdapter
        '
        Me.EDITTableAdapter.ClearBeforeFill = True
        '
        'EditTableAdapter1
        '
        Me.EditTableAdapter1.ClearBeforeFill = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(0, 138)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(120, 24)
        Me.Button14.TabIndex = 47
        Me.Button14.Text = "·ÍıÒ˘ÛÁ ·Ò/ÍÔı"
        '
        'atim
        '
        Me.atim.Location = New System.Drawing.Point(186, 0)
        Me.atim.Name = "atim"
        Me.atim.Size = New System.Drawing.Size(52, 22)
        '
        'FPA
        '
        Me.FPA.Location = New System.Drawing.Point(194, 288)
        Me.FPA.Name = "FPA"
        Me.FPA.Size = New System.Drawing.Size(44, 18)
        Me.FPA.Text = "1FPA"
        '
        'AJIA
        '
        Me.AJIA.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.AJIA.Location = New System.Drawing.Point(162, 68)
        Me.AJIA.Name = "AJIA"
        Me.AJIA.Size = New System.Drawing.Size(78, 32)
        '
        'MON
        '
        Me.MON.Location = New System.Drawing.Point(-2, 288)
        Me.MON.Name = "MON"
        Me.MON.Size = New System.Drawing.Size(66, 16)
        Me.MON.Text = "2MON"
        Me.MON.Visible = False
        '
        'ekt
        '
        Me.ekt.Checked = True
        Me.ekt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ekt.Location = New System.Drawing.Point(60, 288)
        Me.ekt.Name = "ekt"
        Me.ekt.Size = New System.Drawing.Size(140, 18)
        Me.ekt.TabIndex = 54
        Me.ekt.Text = "≈ÍÙ˝˘ÛÁ"
        '
        'TRP
        '
        Me.TRP.Items.Add("1.Ã≈‘—«‘œ…”")
        Me.TRP.Items.Add("2.–…”‘Ÿ”« 30 «Ã≈—≈”")
        Me.TRP.Items.Add("3.–…”‘Ÿ‘… «")
        Me.TRP.Location = New System.Drawing.Point(0, 122)
        Me.TRP.Name = "TRP"
        Me.TRP.Size = New System.Drawing.Size(122, 23)
        Me.TRP.TabIndex = 55
        '
        'TIMOLPETR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.ONO_POSO)
        Me.Controls.Add(Me.MKOD)
        Me.Controls.Add(Me.TRP)
        Me.Controls.Add(Me.AJIA)
        Me.Controls.Add(Me.atim)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EKPT)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TIMH)
        Me.Controls.Add(Me.NEO_EIDOS)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.PEL)
        Me.Controls.Add(Me.EIDOS)
        Me.Controls.Add(Me.FPA)
        Me.Controls.Add(Me.ekt)
        Me.Controls.Add(Me.MON)
        Me.Name = "TIMOLPETR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ONO_POSO As System.Windows.Forms.TextBox
    Friend WithEvents EIDOS As System.Windows.Forms.Button
    Friend WithEvents MKOD As System.Windows.Forms.TextBox
    Friend WithEvents NEO_EIDOS As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents AaaDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AaaDataSet1 As CETIMOL3.aaaDataSet1
    Friend WithEvents EDITBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AaaDataSet As CETIMOL3.aaaDataSet
    Friend WithEvents EDITTableAdapter As CETIMOL3.aaaDataSet1TableAdapters.EDITTableAdapter
    Friend WithEvents EditTableAdapter1 As CETIMOL3.aaaDataSet1TableAdapters.EDITTableAdapter
    Friend WithEvents TIMH As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PEL As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents EKPT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents atim As System.Windows.Forms.Label
    Friend WithEvents FPA As System.Windows.Forms.Label
    Friend WithEvents AJIA As System.Windows.Forms.Label
    Friend WithEvents MON As System.Windows.Forms.Label
    Friend WithEvents ekt As System.Windows.Forms.CheckBox
    Friend WithEvents TRP As System.Windows.Forms.ComboBox
End Class
