<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form11
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
        Me.Barcode1 = New Barcode.Barcode
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Barcode1
        '
        Me.Barcode1.DecoderParameters.CODABAR = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.CODE128 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.CODE39 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.CODE39Params.Code32Prefix = False
        Me.Barcode1.DecoderParameters.CODE39Params.Concatenation = False
        Me.Barcode1.DecoderParameters.CODE39Params.ConvertToCode32 = False
        Me.Barcode1.DecoderParameters.CODE39Params.FullAscii = False
        Me.Barcode1.DecoderParameters.CODE39Params.Redundancy = False
        Me.Barcode1.DecoderParameters.CODE39Params.ReportCheckDigit = False
        Me.Barcode1.DecoderParameters.CODE39Params.VerifyCheckDigit = False
        Me.Barcode1.DecoderParameters.D2OF5 = Barcode.DisabledEnabled.Disabled
        Me.Barcode1.DecoderParameters.EAN13 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.EAN8 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.I2OF5 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.MSI = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.UPCA = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.DecoderParameters.UPCE0 = Barcode.DisabledEnabled.Enabled
        Me.Barcode1.EnableScanner = True
        Me.Barcode1.ScanParameters.BeepFrequency = 2670
        Me.Barcode1.ScanParameters.BeepTime = 200
        Me.Barcode1.ScanParameters.CodeIdType = Barcode.CodeIdTypes.None
        Me.Barcode1.ScanParameters.LedTime = 3000
        Me.Barcode1.ScanParameters.ScanType = Barcode.ScanTypes.Foreground
        Me.Barcode1.ScanParameters.WaveFile = ""
        '
        'ListBox1
        '
        Me.ListBox1.Location = New System.Drawing.Point(3, 157)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(199, 18)
        Me.ListBox1.TabIndex = 0
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(129, 218)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(72, 20)
        Me.ButtonExit.TabIndex = 1
        Me.ButtonExit.Text = "Exit"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 244)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(240, 24)
        Me.StatusBar1.Text = "StatusBar1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 61)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(78, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(123, 23)
        Me.TextBox1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.Text = "BARCODE"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label4.Location = New System.Drawing.Point(142, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 26)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(30, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.Text = "��������"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 181)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(199, 20)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "������������ SC�����"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(30, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 26)
        Me.Label3.Text = "����"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Label6.Location = New System.Drawing.Point(142, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 26)
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form11"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Barcode1 As Barcode.Barcode
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
