<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class symbol1
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
        Me.Barcode1 = New Barcode.Barcode
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ButtonExit = New System.Windows.Forms.Button
        Me.StatusBar1 = New System.Windows.Forms.StatusBar
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
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
        Me.ListBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.ListBox1.Location = New System.Drawing.Point(0, 184)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(191, 21)
        Me.ListBox1.TabIndex = 0
        '
        'ButtonExit
        '
        Me.ButtonExit.Location = New System.Drawing.Point(0, 227)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(72, 20)
        Me.ButtonExit.TabIndex = 1
        Me.ButtonExit.Text = "Exit"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 247)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(223, 24)
        Me.StatusBar1.Text = "StatusBar1"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox1.Location = New System.Drawing.Point(90, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(130, 26)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(28, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 18)
        Me.Label1.Text = "Label1"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(28, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 21)
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(99, 121)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(120, 23)
        Me.TextBox2.TabIndex = 5
        '
        'symbol1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ListBox1)
        Me.Menu = Me.mainMenu1
        Me.Name = "symbol1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Barcode1 As Barcode.Barcode
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox

End Class
