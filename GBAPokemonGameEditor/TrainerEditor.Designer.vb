<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrainerEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrainerEditor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TrainerIndexTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrainerListComboBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PicNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.TrainerPic = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TNameTextBox = New System.Windows.Forms.TextBox()
        Me.RnmBttn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PicNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrainerPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TrainerIndexTextBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TrainerListComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trainer List"
        '
        'TrainerIndexTextBox
        '
        Me.TrainerIndexTextBox.Location = New System.Drawing.Point(74, 51)
        Me.TrainerIndexTextBox.Name = "TrainerIndexTextBox"
        Me.TrainerIndexTextBox.Size = New System.Drawing.Size(74, 22)
        Me.TrainerIndexTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Index:"
        '
        'TrainerListComboBox
        '
        Me.TrainerListComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TrainerListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TrainerListComboBox.FormattingEnabled = True
        Me.TrainerListComboBox.Location = New System.Drawing.Point(6, 21)
        Me.TrainerListComboBox.Name = "TrainerListComboBox"
        Me.TrainerListComboBox.Size = New System.Drawing.Size(142, 24)
        Me.TrainerListComboBox.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RnmBttn)
        Me.GroupBox2.Controls.Add(Me.TNameTextBox)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.PicNumericUpDown)
        Me.GroupBox2.Controls.Add(Me.TrainerPic)
        Me.GroupBox2.Location = New System.Drawing.Point(189, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(406, 166)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Trainer Data"
        '
        'PicNumericUpDown
        '
        Me.PicNumericUpDown.Location = New System.Drawing.Point(16, 107)
        Me.PicNumericUpDown.Name = "PicNumericUpDown"
        Me.PicNumericUpDown.Size = New System.Drawing.Size(85, 22)
        Me.PicNumericUpDown.TabIndex = 11
        '
        'TrainerPic
        '
        Me.TrainerPic.Location = New System.Drawing.Point(16, 21)
        Me.TrainerPic.Margin = New System.Windows.Forms.Padding(4)
        Me.TrainerPic.Name = "TrainerPic"
        Me.TrainerPic.Size = New System.Drawing.Size(85, 79)
        Me.TrainerPic.TabIndex = 10
        Me.TrainerPic.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(108, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Name:"
        '
        'TNameTextBox
        '
        Me.TNameTextBox.Location = New System.Drawing.Point(163, 21)
        Me.TNameTextBox.Name = "TNameTextBox"
        Me.TNameTextBox.Size = New System.Drawing.Size(100, 22)
        Me.TNameTextBox.TabIndex = 13
        '
        'RnmBttn
        '
        Me.RnmBttn.Location = New System.Drawing.Point(269, 22)
        Me.RnmBttn.Name = "RnmBttn"
        Me.RnmBttn.Size = New System.Drawing.Size(75, 23)
        Me.RnmBttn.TabIndex = 14
        Me.RnmBttn.Text = "Rename"
        Me.RnmBttn.UseVisualStyleBackColor = True
        '
        'TrainerEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 206)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TrainerEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trainer Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PicNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrainerPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TrainerIndexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrainerListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PicNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrainerPic As System.Windows.Forms.PictureBox
    Friend WithEvents RnmBttn As System.Windows.Forms.Button
    Friend WithEvents TNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
