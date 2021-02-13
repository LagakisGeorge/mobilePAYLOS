<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
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
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mAFM = New System.Windows.Forms.TextBox
        Me.MBARCODE = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.mPOS = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.MONO = New System.Windows.Forms.Label
        Me.MLTI = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SPOS = New System.Windows.Forms.Label
        Me.MKOD = New System.Windows.Forms.Label
        Me.ATIM = New System.Windows.Forms.Label
        Me.ajia = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ypol = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.anam = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.desm = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.MenuItems.Add(Me.MenuItem2)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem3)
        Me.MenuItem1.MenuItems.Add(Me.MenuItem4)
        Me.MenuItem1.Text = "Παραγγελίες"
        '
        'MenuItem2
        '
        Me.MenuItem2.Checked = True
        Me.MenuItem2.Text = "Διόρθωση"
        '
        'MenuItem3
        '
        Me.MenuItem3.Checked = True
        Me.MenuItem3.Text = "Αποστολή"
        '
        'MenuItem4
        '
        Me.MenuItem4.Checked = True
        Me.MenuItem4.Text = "Νέα"
        '
        'mAFM
        '
        Me.mAFM.Enabled = False
        Me.mAFM.Location = New System.Drawing.Point(54, 3)
        Me.mAFM.Name = "mAFM"
        Me.mAFM.Size = New System.Drawing.Size(112, 23)
        Me.mAFM.TabIndex = 1
        '
        'MBARCODE
        '
        Me.MBARCODE.Location = New System.Drawing.Point(100, 34)
        Me.MBARCODE.Name = "MBARCODE"
        Me.MBARCODE.Size = New System.Drawing.Size(140, 23)
        Me.MBARCODE.TabIndex = 3
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(9, 209)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(228, 50)
        Me.ListBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 22)
        Me.Label1.Text = "ΑΦΜ"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 22)
        Me.Label2.Text = "BARCODE"
        '
        'mPOS
        '
        Me.mPOS.Location = New System.Drawing.Point(82, 112)
        Me.mPOS.Name = "mPOS"
        Me.mPOS.Size = New System.Drawing.Size(53, 23)
        Me.mPOS.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(3, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 22)
        Me.Label3.Text = "ΠΟΣΟΤΗΤΑ"
        '
        'MONO
        '
        Me.MONO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MONO.Location = New System.Drawing.Point(4, 59)
        Me.MONO.Name = "MONO"
        Me.MONO.Size = New System.Drawing.Size(233, 22)
        '
        'MLTI
        '
        Me.MLTI.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MLTI.Location = New System.Drawing.Point(82, 140)
        Me.MLTI.Name = "MLTI"
        Me.MLTI.Size = New System.Drawing.Size(53, 22)
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(9, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 22)
        Me.Label5.Text = "Τιμή"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(141, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 22)
        Me.Label6.Text = "Συν.Παρ"
        '
        'SPOS
        '
        Me.SPOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SPOS.Location = New System.Drawing.Point(187, 114)
        Me.SPOS.Name = "SPOS"
        Me.SPOS.Size = New System.Drawing.Size(53, 22)
        '
        'MKOD
        '
        Me.MKOD.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MKOD.Location = New System.Drawing.Point(4, 87)
        Me.MKOD.Name = "MKOD"
        Me.MKOD.Size = New System.Drawing.Size(193, 22)
        '
        'ATIM
        '
        Me.ATIM.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ATIM.Location = New System.Drawing.Point(173, 3)
        Me.ATIM.Name = "ATIM"
        Me.ATIM.Size = New System.Drawing.Size(64, 22)
        Me.ATIM.Text = "1"
        '
        'ajia
        '
        Me.ajia.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ajia.Location = New System.Drawing.Point(172, 140)
        Me.ajia.Name = "ajia"
        Me.ajia.Size = New System.Drawing.Size(65, 22)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.Label7.Location = New System.Drawing.Point(134, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 22)
        Me.Label7.Text = "Αξία"
        '
        'ypol
        '
        Me.ypol.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ypol.Location = New System.Drawing.Point(63, 185)
        Me.ypol.Name = "ypol"
        Me.ypol.Size = New System.Drawing.Size(65, 21)
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(9, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 21)
        Me.Label8.Text = "Yπ."
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(9, 167)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 21)
        Me.Label9.Text = "Αν."
        '
        'anam
        '
        Me.anam.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.anam.Location = New System.Drawing.Point(63, 164)
        Me.anam.Name = "anam"
        Me.anam.Size = New System.Drawing.Size(65, 21)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(134, 188)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 21)
        Me.Label11.Text = "Δεσμ."
        '
        'desm
        '
        Me.desm.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.desm.Location = New System.Drawing.Point(172, 188)
        Me.desm.Name = "desm"
        Me.desm.Size = New System.Drawing.Size(65, 21)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.desm)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.anam)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ypol)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ajia)
        Me.Controls.Add(Me.ATIM)
        Me.Controls.Add(Me.MKOD)
        Me.Controls.Add(Me.SPOS)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MLTI)
        Me.Controls.Add(Me.MONO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mPOS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MBARCODE)
        Me.Controls.Add(Me.mAFM)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Παραγγ. v.17.9.15"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mAFM As System.Windows.Forms.TextBox
    Friend WithEvents MBARCODE As System.Windows.Forms.TextBox
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mPOS As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MONO As System.Windows.Forms.Label
    Friend WithEvents MLTI As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SPOS As System.Windows.Forms.Label
    Friend WithEvents MKOD As System.Windows.Forms.Label
    Friend WithEvents ATIM As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents ajia As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ypol As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents anam As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents desm As System.Windows.Forms.Label
End Class
