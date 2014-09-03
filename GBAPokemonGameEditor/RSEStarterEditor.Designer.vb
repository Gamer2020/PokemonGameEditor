<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RSEStarterEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RSEStarterEditor))
        Me.Starter1 = New System.Windows.Forms.ComboBox()
        Me.Starter3 = New System.Windows.Forms.ComboBox()
        Me.Starter2 = New System.Windows.Forms.ComboBox()
        Me.Opponent = New System.Windows.Forms.ComboBox()
        Me.OpoPic = New System.Windows.Forms.PictureBox()
        Me.Start1Pic = New System.Windows.Forms.PictureBox()
        Me.Start2Pic = New System.Windows.Forms.PictureBox()
        Me.Start3Pic = New System.Windows.Forms.PictureBox()
        Me.StarterLevel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpponentLevel = New System.Windows.Forms.TextBox()
        CType(Me.OpoPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Start1Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Start2Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Start3Pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Starter1
        '
        Me.Starter1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Starter1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Starter1.FormattingEnabled = True
        Me.Starter1.Location = New System.Drawing.Point(12, 242)
        Me.Starter1.Name = "Starter1"
        Me.Starter1.Size = New System.Drawing.Size(118, 21)
        Me.Starter1.TabIndex = 8
        '
        'Starter3
        '
        Me.Starter3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Starter3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Starter3.FormattingEnabled = True
        Me.Starter3.Location = New System.Drawing.Point(260, 242)
        Me.Starter3.Name = "Starter3"
        Me.Starter3.Size = New System.Drawing.Size(118, 21)
        Me.Starter3.TabIndex = 9
        '
        'Starter2
        '
        Me.Starter2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Starter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Starter2.FormattingEnabled = True
        Me.Starter2.Location = New System.Drawing.Point(136, 242)
        Me.Starter2.Name = "Starter2"
        Me.Starter2.Size = New System.Drawing.Size(118, 21)
        Me.Starter2.TabIndex = 10
        '
        'Opponent
        '
        Me.Opponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Opponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Opponent.FormattingEnabled = True
        Me.Opponent.Location = New System.Drawing.Point(136, 95)
        Me.Opponent.Name = "Opponent"
        Me.Opponent.Size = New System.Drawing.Size(118, 21)
        Me.Opponent.TabIndex = 11
        '
        'OpoPic
        '
        Me.OpoPic.Location = New System.Drawing.Point(161, 25)
        Me.OpoPic.Name = "OpoPic"
        Me.OpoPic.Size = New System.Drawing.Size(64, 64)
        Me.OpoPic.TabIndex = 12
        Me.OpoPic.TabStop = False
        '
        'Start1Pic
        '
        Me.Start1Pic.Location = New System.Drawing.Point(39, 161)
        Me.Start1Pic.Name = "Start1Pic"
        Me.Start1Pic.Size = New System.Drawing.Size(64, 64)
        Me.Start1Pic.TabIndex = 13
        Me.Start1Pic.TabStop = False
        '
        'Start2Pic
        '
        Me.Start2Pic.Location = New System.Drawing.Point(161, 161)
        Me.Start2Pic.Name = "Start2Pic"
        Me.Start2Pic.Size = New System.Drawing.Size(64, 64)
        Me.Start2Pic.TabIndex = 14
        Me.Start2Pic.TabStop = False
        '
        'Start3Pic
        '
        Me.Start3Pic.Location = New System.Drawing.Point(282, 161)
        Me.Start3Pic.Name = "Start3Pic"
        Me.Start3Pic.Size = New System.Drawing.Size(64, 64)
        Me.Start3Pic.TabIndex = 15
        Me.Start3Pic.TabStop = False
        '
        'StarterLevel
        '
        Me.StarterLevel.Location = New System.Drawing.Point(222, 270)
        Me.StarterLevel.Name = "StarterLevel"
        Me.StarterLevel.Size = New System.Drawing.Size(32, 20)
        Me.StarterLevel.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 273)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Level:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(260, 294)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 34)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Level:"
        '
        'OpponentLevel
        '
        Me.OpponentLevel.Location = New System.Drawing.Point(222, 123)
        Me.OpponentLevel.Name = "OpponentLevel"
        Me.OpponentLevel.Size = New System.Drawing.Size(32, 20)
        Me.OpponentLevel.TabIndex = 19
        '
        'RSEStarterEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 340)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.OpponentLevel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StarterLevel)
        Me.Controls.Add(Me.Start3Pic)
        Me.Controls.Add(Me.Start2Pic)
        Me.Controls.Add(Me.Start1Pic)
        Me.Controls.Add(Me.OpoPic)
        Me.Controls.Add(Me.Opponent)
        Me.Controls.Add(Me.Starter2)
        Me.Controls.Add(Me.Starter3)
        Me.Controls.Add(Me.Starter1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "RSEStarterEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RSE Starter Editor"
        CType(Me.OpoPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Start1Pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Start2Pic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Start3Pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Starter1 As System.Windows.Forms.ComboBox
    Friend WithEvents Starter3 As System.Windows.Forms.ComboBox
    Friend WithEvents Starter2 As System.Windows.Forms.ComboBox
    Friend WithEvents Opponent As System.Windows.Forms.ComboBox
    Friend WithEvents OpoPic As System.Windows.Forms.PictureBox
    Friend WithEvents Start1Pic As System.Windows.Forms.PictureBox
    Friend WithEvents Start2Pic As System.Windows.Forms.PictureBox
    Friend WithEvents Start3Pic As System.Windows.Forms.PictureBox
    Friend WithEvents StarterLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpponentLevel As System.Windows.Forms.TextBox
End Class
