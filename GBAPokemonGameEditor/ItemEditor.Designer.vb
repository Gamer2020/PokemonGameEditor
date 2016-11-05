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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemEditor))
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
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
        Me.FieldUsagePTTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BattleUsagePTTextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BUTextBox = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ExtParTxt = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(200, 101)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Item Names:"
        '
        'ChangeNameTextBox
        '
        Me.ChangeNameTextBox.Location = New System.Drawing.Point(24, 57)
        Me.ChangeNameTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ChangeNameTextBox.MaxLength = 13
        Me.ChangeNameTextBox.Name = "ChangeNameTextBox"
        Me.ChangeNameTextBox.Size = New System.Drawing.Size(156, 22)
        Me.ChangeNameTextBox.TabIndex = 1
        '
        'ItemListComboBox
        '
        Me.ItemListComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ItemListComboBox.FormattingEnabled = True
        Me.ItemListComboBox.Location = New System.Drawing.Point(24, 23)
        Me.ItemListComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ItemListComboBox.Name = "ItemListComboBox"
        Me.ItemListComboBox.Size = New System.Drawing.Size(156, 24)
        Me.ItemListComboBox.TabIndex = 0
        '
        'SaveBttn
        '
        Me.SaveBttn.Location = New System.Drawing.Point(40, 330)
        Me.SaveBttn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SaveBttn.Name = "SaveBttn"
        Me.SaveBttn.Size = New System.Drawing.Size(127, 41)
        Me.SaveBttn.TabIndex = 1
        Me.SaveBttn.Text = "Save"
        Me.SaveBttn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(220, 257)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Index:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 288)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Price:"
        '
        'IndexTextBox
        '
        Me.IndexTextBox.Location = New System.Drawing.Point(307, 254)
        Me.IndexTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.IndexTextBox.Name = "IndexTextBox"
        Me.IndexTextBox.Size = New System.Drawing.Size(52, 22)
        Me.IndexTextBox.TabIndex = 4
        '
        'PriceTextBox
        '
        Me.PriceTextBox.Location = New System.Drawing.Point(307, 284)
        Me.PriceTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PriceTextBox.Name = "PriceTextBox"
        Me.PriceTextBox.Size = New System.Drawing.Size(52, 22)
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
        Me.GroupBox2.Location = New System.Drawing.Point(16, 123)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(179, 188)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Item Image:"
        '
        'ItmRpntBttn
        '
        Me.ItmRpntBttn.Location = New System.Drawing.Point(27, 98)
        Me.ItmRpntBttn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ItmRpntBttn.Name = "ItmRpntBttn"
        Me.ItmRpntBttn.Size = New System.Drawing.Size(132, 28)
        Me.ItmRpntBttn.TabIndex = 5
        Me.ItmRpntBttn.Text = "Repoint"
        Me.ItmRpntBttn.UseVisualStyleBackColor = True
        '
        'ItmPlPntrTextBox
        '
        Me.ItmPlPntrTextBox.Location = New System.Drawing.Point(83, 57)
        Me.ItmPlPntrTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ItmPlPntrTextBox.Name = "ItmPlPntrTextBox"
        Me.ItmPlPntrTextBox.Size = New System.Drawing.Size(75, 22)
        Me.ItmPlPntrTextBox.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 60)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Pal:"
        '
        'ItmImgPntrTextBox
        '
        Me.ItmImgPntrTextBox.Location = New System.Drawing.Point(83, 20)
        Me.ItmImgPntrTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ItmImgPntrTextBox.Name = "ItmImgPntrTextBox"
        Me.ItmImgPntrTextBox.Size = New System.Drawing.Size(75, 22)
        Me.ItmImgPntrTextBox.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 27)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Image:"
        '
        'ItemImagePictureBox
        '
        Me.ItemImagePictureBox.Location = New System.Drawing.Point(83, 134)
        Me.ItemImagePictureBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ItemImagePictureBox.Name = "ItemImagePictureBox"
        Me.ItemImagePictureBox.Size = New System.Drawing.Size(43, 39)
        Me.ItemImagePictureBox.TabIndex = 0
        Me.ItemImagePictureBox.TabStop = False
        '
        'DscrpRpntBttn
        '
        Me.DscrpRpntBttn.Location = New System.Drawing.Point(139, 23)
        Me.DscrpRpntBttn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DscrpRpntBttn.Name = "DscrpRpntBttn"
        Me.DscrpRpntBttn.Size = New System.Drawing.Size(89, 25)
        Me.DscrpRpntBttn.TabIndex = 31
        Me.DscrpRpntBttn.Text = "Repoint"
        Me.DscrpRpntBttn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 60)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 17)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Description:"
        '
        'DsrptnTextBox
        '
        Me.DsrptnTextBox.Location = New System.Drawing.Point(20, 89)
        Me.DsrptnTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DsrptnTextBox.Multiline = True
        Me.DsrptnTextBox.Name = "DsrptnTextBox"
        Me.DsrptnTextBox.Size = New System.Drawing.Size(207, 90)
        Me.DsrptnTextBox.TabIndex = 29
        '
        'DescribPointTextBox
        '
        Me.DescribPointTextBox.Location = New System.Drawing.Point(20, 23)
        Me.DescribPointTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DescribPointTextBox.Name = "DescribPointTextBox"
        Me.DescribPointTextBox.Size = New System.Drawing.Size(109, 22)
        Me.DescribPointTextBox.TabIndex = 28
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.DescribPointTextBox)
        Me.GroupBox3.Controls.Add(Me.DscrpRpntBttn)
        Me.GroupBox3.Controls.Add(Me.DsrptnTextBox)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(224, 15)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(251, 231)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Description Pointer:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(19, 183)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 17)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Length:"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(139, 199)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(89, 25)
        Me.Button6.TabIndex = 32
        Me.Button6.Text = "Save"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(216, 320)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 17)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Hold Effect:"
        '
        'HoldEffectTextBox
        '
        Me.HoldEffectTextBox.Location = New System.Drawing.Point(307, 316)
        Me.HoldEffectTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.HoldEffectTextBox.Name = "HoldEffectTextBox"
        Me.HoldEffectTextBox.Size = New System.Drawing.Size(52, 22)
        Me.HoldEffectTextBox.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(216, 352)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Parameter:"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(307, 348)
        Me.ValueTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(52, 22)
        Me.ValueTextBox.TabIndex = 36
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(376, 257)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "KeyItem Value:"
        '
        'MysteryValue2TextBox
        '
        Me.MysteryValue2TextBox.Location = New System.Drawing.Point(504, 284)
        Me.MysteryValue2TextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MysteryValue2TextBox.Name = "MysteryValue2TextBox"
        Me.MysteryValue2TextBox.Size = New System.Drawing.Size(52, 22)
        Me.MysteryValue2TextBox.TabIndex = 39
        '
        'MysteryValue1TextBox
        '
        Me.MysteryValue1TextBox.Location = New System.Drawing.Point(504, 254)
        Me.MysteryValue1TextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MysteryValue1TextBox.Name = "MysteryValue1TextBox"
        Me.MysteryValue1TextBox.Size = New System.Drawing.Size(52, 22)
        Me.MysteryValue1TextBox.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(376, 320)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 17)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Pocket:"
        '
        'PocketComboBox
        '
        Me.PocketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PocketComboBox.FormattingEnabled = True
        Me.PocketComboBox.Items.AddRange(New Object() {"???", "Items", "Poke Balls", "TM/HM's", "Berries", "Key Items"})
        Me.PocketComboBox.Location = New System.Drawing.Point(504, 316)
        Me.PocketComboBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PocketComboBox.Name = "PocketComboBox"
        Me.PocketComboBox.Size = New System.Drawing.Size(108, 24)
        Me.PocketComboBox.TabIndex = 41
        '
        'TypeTextBox
        '
        Me.TypeTextBox.Location = New System.Drawing.Point(504, 348)
        Me.TypeTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TypeTextBox.Name = "TypeTextBox"
        Me.TypeTextBox.Size = New System.Drawing.Size(52, 22)
        Me.TypeTextBox.TabIndex = 43
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(376, 348)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 17)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Type:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(376, 288)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Bag Keyitem:"
        '
        'FieldUsagePTTextBox
        '
        Me.FieldUsagePTTextBox.Location = New System.Drawing.Point(496, 71)
        Me.FieldUsagePTTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FieldUsagePTTextBox.Name = "FieldUsagePTTextBox"
        Me.FieldUsagePTTextBox.Size = New System.Drawing.Size(109, 22)
        Me.FieldUsagePTTextBox.TabIndex = 45
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(492, 43)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 17)
        Me.Label12.TabIndex = 46
        Me.Label12.Text = "Field Usage Pointer:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(492, 107)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 17)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Battle Usage Pointer:"
        '
        'BattleUsagePTTextBox
        '
        Me.BattleUsagePTTextBox.Location = New System.Drawing.Point(496, 142)
        Me.BattleUsagePTTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BattleUsagePTTextBox.Name = "BattleUsagePTTextBox"
        Me.BattleUsagePTTextBox.Size = New System.Drawing.Size(109, 22)
        Me.BattleUsagePTTextBox.TabIndex = 47
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(492, 177)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 17)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "Battle Usage:"
        '
        'BUTextBox
        '
        Me.BUTextBox.Location = New System.Drawing.Point(595, 174)
        Me.BUTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BUTextBox.Name = "BUTextBox"
        Me.BUTextBox.Size = New System.Drawing.Size(32, 22)
        Me.BUTextBox.TabIndex = 50
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(492, 198)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 17)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "Extra Parameter:"
        '
        'ExtParTxt
        '
        Me.ExtParTxt.Location = New System.Drawing.Point(495, 218)
        Me.ExtParTxt.Name = "ExtParTxt"
        Me.ExtParTxt.Size = New System.Drawing.Size(110, 22)
        Me.ExtParTxt.TabIndex = 52
        '
        'ItemEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 389)
        Me.Controls.Add(Me.ExtParTxt)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.BUTextBox)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.BattleUsagePTTextBox)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.FieldUsagePTTextBox)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
    Friend WithEvents FieldUsagePTTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents BattleUsagePTTextBox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents BUTextBox As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ExtParTxt As System.Windows.Forms.TextBox
End Class
