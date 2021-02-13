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
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.N = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.MKOD = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.AaaDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AaaDataSet1 = New DOKIMI_PC2003_1.aaaDataSet1
        Me.EDITBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.AaaDataSet = New DOKIMI_PC2003_1.aaaDataSet
        Me.c = New System.Windows.Forms.TextBox
        Me.EDITTableAdapter = New DOKIMI_PC2003_1.aaaDataSet1TableAdapters.EDITTableAdapter
        Me.EditTableAdapter1 = New DOKIMI_PC2003_1.aaaDataSet1TableAdapters.EDITTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'N
        '
        Me.N.Location = New System.Drawing.Point(67, 161)
        Me.N.Name = "N"
        Me.N.Size = New System.Drawing.Size(61, 21)
        Me.N.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(23, 188)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 20)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Ειδ"
        '
        'MKOD
        '
        Me.MKOD.Location = New System.Drawing.Point(1, 161)
        Me.MKOD.Name = "MKOD"
        Me.MKOD.Size = New System.Drawing.Size(60, 21)
        Me.MKOD.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(100, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 22)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "CLEAR"
        '
        'AaaDataSetBindingSource
        '
        Me.AaaDataSetBindingSource.DataSource = Me.AaaDataSet1
        Me.AaaDataSetBindingSource.Position = 0
        '
        'AaaDataSet1
        '
        Me.AaaDataSet1.DataSetName = "aaaDataSet1"
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
        Me.DataGrid1.Location = New System.Drawing.Point(3, 43)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(237, 102)
        Me.DataGrid1.TabIndex = 5
        '
        'AaaDataSet
        '
        Me.AaaDataSet.DataSetName = "aaaDataSet"
        Me.AaaDataSet.Prefix = ""
        Me.AaaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'c
        '
        Me.c.Location = New System.Drawing.Point(134, 161)
        Me.c.Name = "c"
        Me.c.Size = New System.Drawing.Size(64, 21)
        Me.c.TabIndex = 10
        Me.c.Tag = "1"
        '
        'EDITTableAdapter
        '
        Me.EDITTableAdapter.ClearBeforeFill = True
        '
        'EditTableAdapter1
        '
        Me.EditTableAdapter1.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(236, 14)
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(3, 0)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(175, 22)
        Me.ComboBox1.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.Text = "Κωδ.Πελ"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(67, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.Text = "Επων.Πελάτη"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(0, 218)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(56, 20)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Πελ"
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(0, 43)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(240, 100)
        Me.ListBox1.TabIndex = 16
        '
        'TIMOLOGHSH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.c)
        Me.Controls.Add(Me.N)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MKOD)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Menu = Me.mainMenu1
        Me.Name = "TIMOLOGHSH"
        Me.Text = "Form3"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents N As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MKOD As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents AaaDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AaaDataSet1 As DOKIMI_PC2003_1.aaaDataSet1
    Friend WithEvents EDITBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AaaDataSet As DOKIMI_PC2003_1.aaaDataSet
    Friend WithEvents EDITTableAdapter As DOKIMI_PC2003_1.aaaDataSet1TableAdapters.EDITTableAdapter
    Friend WithEvents EditTableAdapter1 As DOKIMI_PC2003_1.aaaDataSet1TableAdapters.EDITTableAdapter
    Friend WithEvents c As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
