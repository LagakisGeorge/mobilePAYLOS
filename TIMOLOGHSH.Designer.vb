<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class TIMOLOGHSH
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
        Me.Label5 = New System.Windows.Forms.Label
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.POS = New System.Windows.Forms.Label
        Me.EKPTPEL = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button15 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ONO_POSO
        '
        Me.ONO_POSO.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ONO_POSO.Location = New System.Drawing.Point(68, 158)
        Me.ONO_POSO.Name = "ONO_POSO"
        Me.ONO_POSO.Size = New System.Drawing.Size(51, 26)
        Me.ONO_POSO.TabIndex = 9
        '
        'EIDOS
        '
        Me.EIDOS.Location = New System.Drawing.Point(115, 350)
        Me.EIDOS.Name = "EIDOS"
        Me.EIDOS.Size = New System.Drawing.Size(48, 20)
        Me.EIDOS.TabIndex = 8
        Me.EIDOS.Text = "≈È‰"
        '
        'MKOD
        '
        Me.MKOD.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.MKOD.Location = New System.Drawing.Point(2, 158)
        Me.MKOD.Name = "MKOD"
        Me.MKOD.Size = New System.Drawing.Size(60, 26)
        Me.MKOD.TabIndex = 7
        '
        'NEO_EIDOS
        '
        Me.NEO_EIDOS.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.NEO_EIDOS.Location = New System.Drawing.Point(115, 398)
        Me.NEO_EIDOS.Name = "NEO_EIDOS"
        Me.NEO_EIDOS.Size = New System.Drawing.Size(120, 20)
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
        Me.DataGrid1.ColumnHeadersVisible = False
        Me.DataGrid1.DataSource = Me.EDITBindingSource
        Me.DataGrid1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DataGrid1.Location = New System.Drawing.Point(0, 38)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(284, 99)
        Me.DataGrid1.TabIndex = 5
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
        Me.TIMH.Location = New System.Drawing.Point(125, 158)
        Me.TIMH.Name = "TIMH"
        Me.TIMH.Size = New System.Drawing.Size(51, 26)
        Me.TIMH.TabIndex = 10
        Me.TIMH.Tag = "1"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 20)
        '
        'ComboBox1
        '
        Me.ComboBox1.Items.Add("¡–œƒ≈…Œ« À…¡Õ… «”-ƒ¡   l")
        Me.ComboBox1.Items.Add("¡–œƒ≈…Œ« À…¡Õ… «”         L")
        Me.ComboBox1.Items.Add("ƒ≈À‘…œ ¡–œ”‘œÀ«”         A")
        Me.ComboBox1.Items.Add("‘…ÃœÀœ√…œ –ŸÀ«”«”       t")
        Me.ComboBox1.Items.Add("‘…ÃœÀœ√…œ –ŸÀ«”«”-ƒ¡ T")
        Me.ComboBox1.Location = New System.Drawing.Point(3, 210)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(152, 22)
        Me.ComboBox1.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.Text = " ˘‰.–ÂÎ"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(68, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.Text = "≈˘Ì.–ÂÎ‹ÙÁ"
        '
        'PEL
        '
        Me.PEL.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PEL.Location = New System.Drawing.Point(221, 372)
        Me.PEL.Name = "PEL"
        Me.PEL.Size = New System.Drawing.Size(56, 10)
        Me.PEL.TabIndex = 15
        Me.PEL.Text = "–ÂÎ"
        '
        'ListBox1
        '
        Me.ListBox1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.ListBox1.Location = New System.Drawing.Point(1, 25)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(280, 110)
        Me.ListBox1.TabIndex = 16
        '
        'EKPT
        '
        Me.EKPT.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.EKPT.Location = New System.Drawing.Point(182, 158)
        Me.EKPT.Name = "EKPT"
        Me.EKPT.Size = New System.Drawing.Size(51, 26)
        Me.EKPT.TabIndex = 20
        Me.EKPT.Tag = "1"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(130, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.Text = "‘ÈÏﬁ"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(182, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.Text = "≈ÍÙ˘ÛÁ"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(4, 241)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 30)
        Me.Button1.TabIndex = 24
        Me.Button1.Text = "≈Õ«Ã"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(212, 339)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(10, 10)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "7"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(244, 339)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(10, 10)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "8"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(228, 339)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(10, 10)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "9"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(10, 352)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(30, 18)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "4"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(42, 352)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(30, 18)
        Me.Button6.TabIndex = 34
        Me.Button6.Text = "5"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(74, 352)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(30, 18)
        Me.Button7.TabIndex = 35
        Me.Button7.Text = "6"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(74, 372)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(30, 18)
        Me.Button8.TabIndex = 38
        Me.Button8.Text = "3"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(42, 372)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(30, 18)
        Me.Button9.TabIndex = 37
        Me.Button9.Text = "2"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(10, 372)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(30, 18)
        Me.Button10.TabIndex = 36
        Me.Button10.Text = "1"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(74, 392)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(30, 18)
        Me.Button11.TabIndex = 41
        Me.Button11.Text = "<="
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(42, 392)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(30, 18)
        Me.Button12.TabIndex = 40
        Me.Button12.Text = ","
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(10, 392)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(30, 18)
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
        Me.Button14.Location = New System.Drawing.Point(198, 247)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(72, 24)
        Me.Button14.TabIndex = 47
        Me.Button14.Text = "¡ ’—Ÿ”«"
        '
        'atim
        '
        Me.atim.Location = New System.Drawing.Point(99, 228)
        Me.atim.Name = "atim"
        Me.atim.Size = New System.Drawing.Size(52, 20)
        '
        'FPA
        '
        Me.FPA.Location = New System.Drawing.Point(171, 352)
        Me.FPA.Name = "FPA"
        Me.FPA.Size = New System.Drawing.Size(44, 18)
        Me.FPA.Text = "1FPA"
        '
        'AJIA
        '
        Me.AJIA.BackColor = System.Drawing.SystemColors.Info
        Me.AJIA.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.AJIA.Location = New System.Drawing.Point(162, 216)
        Me.AJIA.Name = "AJIA"
        Me.AJIA.Size = New System.Drawing.Size(60, 32)
        '
        'MON
        '
        Me.MON.Location = New System.Drawing.Point(228, 352)
        Me.MON.Name = "MON"
        Me.MON.Size = New System.Drawing.Size(66, 16)
        Me.MON.Text = "2MON"
        Me.MON.Visible = False
        '
        'ekt
        '
        Me.ekt.Checked = True
        Me.ekt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ekt.Location = New System.Drawing.Point(7, 328)
        Me.ekt.Name = "ekt"
        Me.ekt.Size = New System.Drawing.Size(97, 18)
        Me.ekt.TabIndex = 54
        Me.ekt.Text = "≈ÍÙ˝˘ÛÁ"
        '
        'TRP
        '
        Me.TRP.Items.Add("1.Ã≈‘—«‘œ…”")
        Me.TRP.Items.Add("2.–…”‘Ÿ”« 30 «Ã≈—≈”")
        Me.TRP.Items.Add("3.–…”‘Ÿ‘… «")
        Me.TRP.Location = New System.Drawing.Point(99, 249)
        Me.TRP.Name = "TRP"
        Me.TRP.Size = New System.Drawing.Size(93, 22)
        Me.TRP.TabIndex = 55
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 410)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 8)
        '
        'POS
        '
        Me.POS.Location = New System.Drawing.Point(130, 188)
        Me.POS.Name = "POS"
        Me.POS.Size = New System.Drawing.Size(31, 23)
        '
        'EKPTPEL
        '
        Me.EKPTPEL.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.EKPTPEL.Location = New System.Drawing.Point(109, 288)
        Me.EKPTPEL.Name = "EKPTPEL"
        Me.EKPTPEL.Size = New System.Drawing.Size(49, 15)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(3, 188)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(267, 21)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(115, 371)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 77
        Me.TextBox1.Text = "TextBox1"
        '
        'Button15
        '
        Me.Button15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Button15.Location = New System.Drawing.Point(99, 271)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(95, 21)
        Me.Button15.TabIndex = 91
        Me.Button15.Text = "‘’–ŸÕŸ Œ¡Õ¡"
        '
        'TIMOLOGHSH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(333, 433)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.EKPTPEL)
        Me.Controls.Add(Me.Label6)
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
        Me.Controls.Add(Me.EKPT)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TIMH)
        Me.Controls.Add(Me.ONO_POSO)
        Me.Controls.Add(Me.MKOD)
        Me.Controls.Add(Me.NEO_EIDOS)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.PEL)
        Me.Controls.Add(Me.EIDOS)
        Me.Controls.Add(Me.FPA)
        Me.Controls.Add(Me.ekt)
        Me.Controls.Add(Me.MON)
        Me.Controls.Add(Me.POS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Name = "TIMOLOGHSH"
        Me.Text = "Form3"
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents POS As System.Windows.Forms.Label
    Friend WithEvents EKPTPEL As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button15 As System.Windows.Forms.Button
End Class
