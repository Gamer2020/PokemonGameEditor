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
        Me.SuspendLayout()
        '
        'TMHMList
        '
        Me.TMHMList.FormattingEnabled = True
        Me.TMHMList.Location = New System.Drawing.Point(15, 38)
        Me.TMHMList.Name = "TMHMList"
        Me.TMHMList.Size = New System.Drawing.Size(237, 173)
        Me.TMHMList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "TM/HM List:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 224)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Attack:"
        '
        'AttackList
        '
        Me.AttackList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AttackList.FormattingEnabled = True
        Me.AttackList.Location = New System.Drawing.Point(59, 221)
        Me.AttackList.Name = "AttackList"
        Me.AttackList.Size = New System.Drawing.Size(121, 21)
        Me.AttackList.TabIndex = 3
        '
        'SvBttn
        '
        Me.SvBttn.Location = New System.Drawing.Point(191, 219)
        Me.SvBttn.Name = "SvBttn"
        Me.SvBttn.Size = New System.Drawing.Size(61, 23)
        Me.SvBttn.TabIndex = 4
        Me.SvBttn.Text = "Save"
        Me.SvBttn.UseVisualStyleBackColor = True
        '
        'TMHMEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 262)
        Me.Controls.Add(Me.SvBttn)
        Me.Controls.Add(Me.AttackList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TMHMList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
End Class
