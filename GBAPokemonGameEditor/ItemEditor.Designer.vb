<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemEditor
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ChangeNameTextBox = New System.Windows.Forms.TextBox()
        Me.ItemListComboBox = New System.Windows.Forms.ComboBox()
        Me.SaveBttn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.IndexTextBox = New System.Windows.Forms.TextBox()
        Me.PriceTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ItemImagePictureBox = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ItmImgPntrTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ItmPlPntrTextBox = New System.Windows.Forms.TextBox()
        Me.ItmRpntBttn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ItemImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ChangeNameTextBox)
        Me.GroupBox1.Controls.Add(Me.ItemListComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 82)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Names:"
        '
        'ChangeNameTextBox
        '
        Me.ChangeNameTextBox.Location = New System.Drawing.Point(18, 46)
        Me.ChangeNameTextBox.MaxLength = 13
        Me.ChangeNameTextBox.Name = "ChangeNameTextBox"
        Me.ChangeNameTextBox.Size = New System.Drawing.Size(118, 20)
        Me.ChangeNameTextBox.TabIndex = 1
        '
        'ItemListComboBox
        '
        Me.ItemListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemListComboBox.FormattingEnabled = True
        Me.ItemListComboBox.Location = New System.Drawing.Point(18, 19)
        Me.ItemListComboBox.Name = "ItemListComboBox"
        Me.ItemListComboBox.Size = New System.Drawing.Size(118, 21)
        Me.ItemListComboBox.TabIndex = 0
        '
        'SaveBttn
        '
        Me.SaveBttn.Location = New System.Drawing.Point(42, 92)
        Me.SaveBttn.Name = "SaveBttn"
        Me.SaveBttn.Size = New System.Drawing.Size(95, 33)
        Me.SaveBttn.TabIndex = 1
        Me.SaveBttn.Text = "Save"
        Me.SaveBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(318, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Index:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(320, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Price:"
        '
        'IndexTextBox
        '
        Me.IndexTextBox.Location = New System.Drawing.Point(360, 9)
        Me.IndexTextBox.Name = "IndexTextBox"
        Me.IndexTextBox.Size = New System.Drawing.Size(42, 20)
        Me.IndexTextBox.TabIndex = 4
        '
        'PriceTextBox
        '
        Me.PriceTextBox.Location = New System.Drawing.Point(360, 36)
        Me.PriceTextBox.Name = "PriceTextBox"
        Me.PriceTextBox.Size = New System.Drawing.Size(40, 20)
        Me.PriceTextBox.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ItmRpntBttn)
        Me.GroupBox2.Controls.Add(Me.ItmPlPntrTextBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ItmImgPntrTextBox)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ItemImagePictureBox)
        Me.GroupBox2.Location = New System.Drawing.Point(168, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 153)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Image:"
        '
        'ItemImagePictureBox
        '
        Me.ItemImagePictureBox.Location = New System.Drawing.Point(62, 109)
        Me.ItemImagePictureBox.Name = "ItemImagePictureBox"
        Me.ItemImagePictureBox.Size = New System.Drawing.Size(32, 32)
        Me.ItemImagePictureBox.TabIndex = 0
        Me.ItemImagePictureBox.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Image:"
        '
        'ItmImgPntrTextBox
        '
        Me.ItmImgPntrTextBox.Location = New System.Drawing.Point(62, 16)
        Me.ItmImgPntrTextBox.Name = "ItmImgPntrTextBox"
        Me.ItmImgPntrTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ItmImgPntrTextBox.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Pal:"
        '
        'ItmPlPntrTextBox
        '
        Me.ItmPlPntrTextBox.Location = New System.Drawing.Point(62, 46)
        Me.ItmPlPntrTextBox.Name = "ItmPlPntrTextBox"
        Me.ItmPlPntrTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ItmPlPntrTextBox.TabIndex = 4
        '
        'ItmRpntBttn
        '
        Me.ItmRpntBttn.Location = New System.Drawing.Point(20, 80)
        Me.ItmRpntBttn.Name = "ItmRpntBttn"
        Me.ItmRpntBttn.Size = New System.Drawing.Size(99, 23)
        Me.ItmRpntBttn.TabIndex = 5
        Me.ItmRpntBttn.Text = "Repoint"
        Me.ItmRpntBttn.UseVisualStyleBackColor = True
        '
        'ItemEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 202)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PriceTextBox)
        Me.Controls.Add(Me.IndexTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SaveBttn)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ItemEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Editor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ItemImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ItemListComboBox As ComboBox
    Friend WithEvents ChangeNameTextBox As TextBox
    Friend WithEvents SaveBttn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents IndexTextBox As TextBox
    Friend WithEvents PriceTextBox As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ItemImagePictureBox As PictureBox
    Friend WithEvents ItmRpntBttn As Button
    Friend WithEvents ItmPlPntrTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ItmImgPntrTextBox As TextBox
    Friend WithEvents Label3 As Label
End Class
