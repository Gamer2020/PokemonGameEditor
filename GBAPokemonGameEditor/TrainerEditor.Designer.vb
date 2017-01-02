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
        Me.ClssRnmBttn = New System.Windows.Forms.Button()
        Me.ClssTxtBx = New System.Windows.Forms.TextBox()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.MusicTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ClassComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RnmBttn = New System.Windows.Forms.Button()
        Me.TNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PicNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.TrainerPic = New System.Windows.Forms.PictureBox()
        Me.SaveBttn = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TrainerItem1 = New System.Windows.Forms.ComboBox()
        Me.TrainerItem2 = New System.Windows.Forms.ComboBox()
        Me.TrainerItem3 = New System.Windows.Forms.ComboBox()
        Me.TrainerItem4 = New System.Windows.Forms.ComboBox()
        Me.DblCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AITextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PicNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrainerPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.TrainerListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TrainerListComboBox.FormattingEnabled = True
        Me.TrainerListComboBox.Location = New System.Drawing.Point(6, 21)
        Me.TrainerListComboBox.Name = "TrainerListComboBox"
        Me.TrainerListComboBox.Size = New System.Drawing.Size(142, 24)
        Me.TrainerListComboBox.TabIndex = 0
        '
        'ClssRnmBttn
        '
        Me.ClssRnmBttn.Location = New System.Drawing.Point(64, 65)
        Me.ClssRnmBttn.Name = "ClssRnmBttn"
        Me.ClssRnmBttn.Size = New System.Drawing.Size(181, 34)
        Me.ClssRnmBttn.TabIndex = 23
        Me.ClssRnmBttn.Text = "Rename Class"
        Me.ClssRnmBttn.UseVisualStyleBackColor = True
        '
        'ClssTxtBx
        '
        Me.ClssTxtBx.Location = New System.Drawing.Point(64, 40)
        Me.ClssTxtBx.Name = "ClssTxtBx"
        Me.ClssTxtBx.Size = New System.Drawing.Size(181, 22)
        Me.ClssTxtBx.TabIndex = 22
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(7, 171)
        Me.Button22.Margin = New System.Windows.Forms.Padding(4)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(85, 43)
        Me.Button22.TabIndex = 21
        Me.Button22.Text = "Export Sprite"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(7, 122)
        Me.Button21.Margin = New System.Windows.Forms.Padding(4)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(85, 43)
        Me.Button21.TabIndex = 20
        Me.Button21.Text = "Import Sprite"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'MusicTextBox
        '
        Me.MusicTextBox.Location = New System.Drawing.Point(255, 53)
        Me.MusicTextBox.Name = "MusicTextBox"
        Me.MusicTextBox.Size = New System.Drawing.Size(86, 22)
        Me.MusicTextBox.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Music:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(108, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(87, 82)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Gender"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.ForeColor = System.Drawing.Color.DeepPink
        Me.RadioButton2.Location = New System.Drawing.Point(6, 48)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(75, 21)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Female"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.RadioButton1.Location = New System.Drawing.Point(6, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(59, 21)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Male"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ClassComboBox
        '
        Me.ClassComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ClassComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ClassComboBox.FormattingEnabled = True
        Me.ClassComboBox.Location = New System.Drawing.Point(64, 10)
        Me.ClassComboBox.Name = "ClassComboBox"
        Me.ClassComboBox.Size = New System.Drawing.Size(181, 24)
        Me.ClassComboBox.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Class:"
        '
        'RnmBttn
        '
        Me.RnmBttn.Location = New System.Drawing.Point(266, 13)
        Me.RnmBttn.Name = "RnmBttn"
        Me.RnmBttn.Size = New System.Drawing.Size(75, 24)
        Me.RnmBttn.TabIndex = 14
        Me.RnmBttn.Text = "Rename"
        Me.RnmBttn.UseVisualStyleBackColor = True
        '
        'TNameTextBox
        '
        Me.TNameTextBox.Location = New System.Drawing.Point(160, 13)
        Me.TNameTextBox.Name = "TNameTextBox"
        Me.TNameTextBox.Size = New System.Drawing.Size(100, 22)
        Me.TNameTextBox.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 17)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Name:"
        '
        'PicNumericUpDown
        '
        Me.PicNumericUpDown.Location = New System.Drawing.Point(7, 93)
        Me.PicNumericUpDown.Name = "PicNumericUpDown"
        Me.PicNumericUpDown.Size = New System.Drawing.Size(85, 22)
        Me.PicNumericUpDown.TabIndex = 11
        '
        'TrainerPic
        '
        Me.TrainerPic.Location = New System.Drawing.Point(7, 7)
        Me.TrainerPic.Margin = New System.Windows.Forms.Padding(4)
        Me.TrainerPic.Name = "TrainerPic"
        Me.TrainerPic.Size = New System.Drawing.Size(85, 79)
        Me.TrainerPic.TabIndex = 10
        Me.TrainerPic.TabStop = False
        '
        'SaveBttn
        '
        Me.SaveBttn.Location = New System.Drawing.Point(18, 109)
        Me.SaveBttn.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveBttn.Name = "SaveBttn"
        Me.SaveBttn.Size = New System.Drawing.Size(142, 41)
        Me.SaveBttn.TabIndex = 2
        Me.SaveBttn.Text = "Save"
        Me.SaveBttn.UseVisualStyleBackColor = True
        '
        'fileOpenDialog
        '
        Me.fileOpenDialog.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(179, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(368, 323)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.AITextBox)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.DblCheckBox)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.TrainerPic)
        Me.TabPage1.Controls.Add(Me.PicNumericUpDown)
        Me.TabPage1.Controls.Add(Me.Button22)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.RnmBttn)
        Me.TabPage1.Controls.Add(Me.Button21)
        Me.TabPage1.Controls.Add(Me.TNameTextBox)
        Me.TabPage1.Controls.Add(Me.MusicTextBox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(360, 294)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Trainer Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ClssRnmBttn)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.ClassComboBox)
        Me.TabPage2.Controls.Add(Me.ClssTxtBx)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(360, 277)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Trainer Class"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(360, 277)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pokemon Data"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TrainerItem4)
        Me.GroupBox2.Controls.Add(Me.TrainerItem3)
        Me.GroupBox2.Controls.Add(Me.TrainerItem2)
        Me.GroupBox2.Controls.Add(Me.TrainerItem1)
        Me.GroupBox2.Location = New System.Drawing.Point(108, 139)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(179, 144)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Trainer Items"
        '
        'TrainerItem1
        '
        Me.TrainerItem1.FormattingEnabled = True
        Me.TrainerItem1.Location = New System.Drawing.Point(6, 21)
        Me.TrainerItem1.Name = "TrainerItem1"
        Me.TrainerItem1.Size = New System.Drawing.Size(157, 24)
        Me.TrainerItem1.TabIndex = 0
        '
        'TrainerItem2
        '
        Me.TrainerItem2.FormattingEnabled = True
        Me.TrainerItem2.Location = New System.Drawing.Point(6, 51)
        Me.TrainerItem2.Name = "TrainerItem2"
        Me.TrainerItem2.Size = New System.Drawing.Size(157, 24)
        Me.TrainerItem2.TabIndex = 1
        '
        'TrainerItem3
        '
        Me.TrainerItem3.FormattingEnabled = True
        Me.TrainerItem3.Location = New System.Drawing.Point(6, 81)
        Me.TrainerItem3.Name = "TrainerItem3"
        Me.TrainerItem3.Size = New System.Drawing.Size(157, 24)
        Me.TrainerItem3.TabIndex = 2
        '
        'TrainerItem4
        '
        Me.TrainerItem4.FormattingEnabled = True
        Me.TrainerItem4.Location = New System.Drawing.Point(6, 111)
        Me.TrainerItem4.Name = "TrainerItem4"
        Me.TrainerItem4.Size = New System.Drawing.Size(157, 24)
        Me.TrainerItem4.TabIndex = 3
        '
        'DblCheckBox
        '
        Me.DblCheckBox.AutoSize = True
        Me.DblCheckBox.Location = New System.Drawing.Point(204, 83)
        Me.DblCheckBox.Name = "DblCheckBox"
        Me.DblCheckBox.Size = New System.Drawing.Size(115, 21)
        Me.DblCheckBox.TabIndex = 23
        Me.DblCheckBox.Text = "Double Battle"
        Me.DblCheckBox.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(201, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "AI:"
        '
        'AITextBox
        '
        Me.AITextBox.Location = New System.Drawing.Point(255, 104)
        Me.AITextBox.Name = "AITextBox"
        Me.AITextBox.Size = New System.Drawing.Size(86, 22)
        Me.AITextBox.TabIndex = 25
        '
        'TrainerEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 345)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SaveBttn)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TrainerEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trainer Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PicNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrainerPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TrainerIndexTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TrainerListComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PicNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents TrainerPic As System.Windows.Forms.PictureBox
    Friend WithEvents RnmBttn As System.Windows.Forms.Button
    Friend WithEvents TNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SaveBttn As System.Windows.Forms.Button
    Friend WithEvents ClassComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents MusicTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents fileOpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ClssRnmBttn As System.Windows.Forms.Button
    Friend WithEvents ClssTxtBx As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TrainerItem4 As System.Windows.Forms.ComboBox
    Friend WithEvents TrainerItem3 As System.Windows.Forms.ComboBox
    Friend WithEvents TrainerItem2 As System.Windows.Forms.ComboBox
    Friend WithEvents TrainerItem1 As System.Windows.Forms.ComboBox
    Friend WithEvents DblCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AITextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
