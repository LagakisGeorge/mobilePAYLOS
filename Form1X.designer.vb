<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form11
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents mactext As System.Windows.Forms.TextBox
    Public WithEvents Command1 As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mactext = New System.Windows.Forms.TextBox
        Me.Command1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mactext
        '
        Me.mactext.AcceptsReturn = True
        Me.mactext.BackColor = System.Drawing.SystemColors.Window
        Me.mactext.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.mactext.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mactext.Location = New System.Drawing.Point(48, 16)
        Me.mactext.MaxLength = 0
        Me.mactext.Name = "mactext"
        Me.mactext.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mactext.Size = New System.Drawing.Size(137, 33)
        Me.mactext.TabIndex = 1
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(56, 80)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(113, 33)
        Me.Command1.TabIndex = 0
        Me.Command1.Text = "Command1"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(312, 206)
        Me.Controls.Add(Me.mactext)
        Me.Controls.Add(Me.Command1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "Form11"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class