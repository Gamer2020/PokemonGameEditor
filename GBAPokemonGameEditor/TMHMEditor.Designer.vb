<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TMHMEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TMHMEditor))
        Me.TMHMList = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AttackList = New System.Windows.Forms.ComboBox()
        Me.SvBttn = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'TMHMList
        '
        Me.TMHMList.FormattingEnabled = True
        Me.TMHMList.ItemHeight = 20
        Me.TMHMList.Location = New System.Drawing.Point(22, 58)
        Me.TMHMList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TMHMList.Name = "TMHMList"
        Me.TMHMList.Size = New System.Drawing.Size(354, 264)
        Me.TMHMList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TM/HM List:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 345)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attack:"
        '
        'AttackList
        '
        Me.AttackList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AttackList.FormattingEnabled = True
        Me.AttackList.Location = New System.Drawing.Point(88, 340)
        Me.AttackList.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.AttackList.Name = "AttackList"
        Me.AttackList.Size = New System.Drawing.Size(180, 28)
        Me.AttackList.TabIndex = 3
        '
        'SvBttn
        '
        Me.SvBttn.Location = New System.Drawing.Point(286, 337)
        Me.SvBttn.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SvBttn.Name = "SvBttn"
        Me.SvBttn.Size = New System.Drawing.Size(92, 35)
        Me.SvBttn.TabIndex = 4
        Me.SvBttn.Text = "Save"
        Me.SvBttn.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(296, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(103, 24)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "Skip HMs"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(206, 14)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 35)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Import"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(119, 13)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 35)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'TMHMEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 403)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SvBttn)
        Me.Controls.Add(Me.AttackList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TMHMList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "TMHMEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TM/HM Editor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TMHMList As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents AttackList As ComboBox
    Friend WithEvents SvBttn As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents OpenFileDialog As OpenFileDialog
End Class
