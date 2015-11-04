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
        Me.ItmRpntBttn = New System.Windows.Forms.Button()
        Me.ItmPlPntrTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ItmImgPntrTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ItemImagePictureBox = New System.Windows.Forms.PictureBox()
        Me.DscrpRpntBttn = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DsrptnTextBox = New System.Windows.Forms.TextBox()
        Me.DescribPointTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HoldEffectTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ValueTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MysteryValue2TextBox = New System.Windows.Forms.TextBox()
        Me.MysteryValue1TextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PocketComboBox = New System.Windows.Forms.ComboBox()
        Me.TypeTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ItemImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        Me.SaveBttn.Location = New System.Drawing.Point(30, 268)
        Me.SaveBttn.Name = "SaveBttn"
        Me.SaveBttn.Size = New System.Drawing.Size(95, 33)
        Me.SaveBttn.TabIndex = 1
        Me.SaveBttn.Text = "Save"
        Me.SaveBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Index:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 210)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Price:"
        '
        'IndexTextBox
        '
        Me.IndexTextBox.Location = New System.Drawing.Point(248, 182)
        Me.IndexTextBox.Name = "IndexTextBox"
        Me.IndexTextBox.Size = New System.Drawing.Size(40, 20)
        Me.IndexTextBox.TabIndex = 4
        '
        'PriceTextBox
        '
        Me.PriceTextBox.Location = New System.Drawing.Point(248, 207)
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 153)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Image:"
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
        'ItmPlPntrTextBox
        '
        Me.ItmPlPntrTextBox.Location = New System.Drawing.Point(62, 46)
        Me.ItmPlPntrTextBox.Name = "ItmPlPntrTextBox"
        Me.ItmPlPntrTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ItmPlPntrTextBox.TabIndex = 4
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
        'ItmImgPntrTextBox
        '
        Me.ItmImgPntrTextBox.Location = New System.Drawing.Point(62, 16)
        Me.ItmImgPntrTextBox.Name = "ItmImgPntrTextBox"
        Me.ItmImgPntrTextBox.Size = New System.Drawing.Size(57, 20)
        Me.ItmImgPntrTextBox.TabIndex = 2
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
        'ItemImagePictureBox
        '
        Me.ItemImagePictureBox.Location = New System.Drawing.Point(62, 109)
        Me.ItemImagePictureBox.Name = "ItemImagePictureBox"
        Me.ItemImagePictureBox.Size = New System.Drawing.Size(32, 32)
        Me.ItemImagePictureBox.TabIndex = 0
        Me.ItemImagePictureBox.TabStop = False
        '
        'DscrpRpntBttn
        '
        Me.DscrpRpntBttn.Location = New System.Drawing.Point(104, 19)
        Me.DscrpRpntBttn.Name = "DscrpRpntBttn"
        Me.DscrpRpntBttn.Size = New System.Drawing.Size(67, 20)
        Me.DscrpRpntBttn.TabIndex = 31
        Me.DscrpRpntBttn.Text = "Repoint"
        Me.DscrpRpntBttn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Description:"
        '
        'DsrptnTextBox
        '
        Me.DsrptnTextBox.Location = New System.Drawing.Point(15, 72)
        Me.DsrptnTextBox.Multiline = True
        Me.DsrptnTextBox.Name = "DsrptnTextBox"
        Me.DsrptnTextBox.ReadOnly = True
        Me.DsrptnTextBox.Size = New System.Drawing.Size(147, 74)
        Me.DsrptnTextBox.TabIndex = 29
        '
        'DescribPointTextBox
        '
        Me.DescribPointTextBox.Location = New System.Drawing.Point(15, 19)
        Me.DescribPointTextBox.Name = "DescribPointTextBox"
        Me.DescribPointTextBox.Size = New System.Drawing.Size(83, 20)
        Me.DescribPointTextBox.TabIndex = 28
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DescribPointTextBox)
        Me.GroupBox3.Controls.Add(Me.DscrpRpntBttn)
        Me.GroupBox3.Controls.Add(Me.DsrptnTextBox)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(168, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(188, 153)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Description Pointer:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Hold Effect:"
        '
        'HoldEffectTextBox
        '
        Me.HoldEffectTextBox.Location = New System.Drawing.Point(248, 233)
        Me.HoldEffectTextBox.Name = "HoldEffectTextBox"
        Me.HoldEffectTextBox.Size = New System.Drawing.Size(40, 20)
        Me.HoldEffectTextBox.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(180, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Value:"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(248, 259)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(40, 20)
        Me.ValueTextBox.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(300, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "KeyItem Value:"
        '
        'MysteryValue2TextBox
        '
        Me.MysteryValue2TextBox.Location = New System.Drawing.Point(396, 207)
        Me.MysteryValue2TextBox.Name = "MysteryValue2TextBox"
        Me.MysteryValue2TextBox.Size = New System.Drawing.Size(40, 20)
        Me.MysteryValue2TextBox.TabIndex = 39
        '
        'MysteryValue1TextBox
        '
        Me.MysteryValue1TextBox.Location = New System.Drawing.Point(396, 182)
        Me.MysteryValue1TextBox.Name = "MysteryValue1TextBox"
        Me.MysteryValue1TextBox.Size = New System.Drawing.Size(40, 20)
        Me.MysteryValue1TextBox.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(300, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Pocket:"
        '
        'PocketComboBox
        '
        Me.PocketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PocketComboBox.FormattingEnabled = True
        Me.PocketComboBox.Items.AddRange(New Object() {"???", "Items", "Poke Balls", "TM/HM's", "Berries", "Key Items"})
        Me.PocketComboBox.Location = New System.Drawing.Point(396, 233)
        Me.PocketComboBox.Name = "PocketComboBox"
        Me.PocketComboBox.Size = New System.Drawing.Size(82, 21)
        Me.PocketComboBox.TabIndex = 41
        '
        'TypeTextBox
        '
        Me.TypeTextBox.Location = New System.Drawing.Point(396, 259)
        Me.TypeTextBox.Name = "TypeTextBox"
        Me.TypeTextBox.Size = New System.Drawing.Size(40, 20)
        Me.TypeTextBox.TabIndex = 43
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(300, 259)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Type:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(300, 210)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Bag Keyitem:"
        '
        'ItemEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 318)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TypeTextBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PocketComboBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.MysteryValue2TextBox)
        Me.Controls.Add(Me.MysteryValue1TextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ValueTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.HoldEffectTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox3)
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
    Friend WithEvents DscrpRpntBttn As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents DsrptnTextBox As TextBox
    Friend WithEvents DescribPointTextBox As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents HoldEffectTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ValueTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents MysteryValue2TextBox As TextBox
    Friend WithEvents MysteryValue1TextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents PocketComboBox As ComboBox
    Friend WithEvents TypeTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
End Class
