<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtBlockQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBlockName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSecond = New System.Windows.Forms.Label()
        Me.txtSelectState = New System.Windows.Forms.TextBox()
        Me.btnCountBlock = New System.Windows.Forms.Button()
        Me.btnSelectBlock = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBlockQty
        '
        Me.txtBlockQty.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBlockQty.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtBlockQty.Location = New System.Drawing.Point(235, 129)
        Me.txtBlockQty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBlockQty.Name = "txtBlockQty"
        Me.txtBlockQty.ReadOnly = True
        Me.txtBlockQty.Size = New System.Drawing.Size(92, 25)
        Me.txtBlockQty.TabIndex = 28
        Me.txtBlockQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(156, 30)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(266, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "※ 若無選取範圍，範圍即是整張圖面。"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label3.Location = New System.Drawing.Point(156, 82)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "圖塊名："
        '
        'txtBlockName
        '
        Me.txtBlockName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBlockName.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtBlockName.Location = New System.Drawing.Point(235, 76)
        Me.txtBlockName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBlockName.Name = "txtBlockName"
        Me.txtBlockName.ReadOnly = True
        Me.txtBlockName.Size = New System.Drawing.Size(92, 25)
        Me.txtBlockName.TabIndex = 24
        Me.txtBlockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.Location = New System.Drawing.Point(156, 135)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "圖塊數："
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblSecond)
        Me.Panel2.Controls.Add(Me.txtBlockQty)
        Me.Panel2.Controls.Add(Me.txtSelectState)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnCountBlock)
        Me.Panel2.Controls.Add(Me.txtBlockName)
        Me.Panel2.Controls.Add(Me.btnSelectBlock)
        Me.Panel2.Controls.Add(Me.btnSelect)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(20, 19)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(473, 181)
        Me.Panel2.TabIndex = 0
        '
        'lblSecond
        '
        Me.lblSecond.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSecond.AutoSize = True
        Me.lblSecond.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblSecond.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSecond.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblSecond.Location = New System.Drawing.Point(355, 82)
        Me.lblSecond.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSecond.Name = "lblSecond"
        Me.lblSecond.Size = New System.Drawing.Size(66, 15)
        Me.lblSecond.TabIndex = 30
        Me.lblSecond.Text = "Loading..."
        Me.lblSecond.Visible = False
        '
        'txtSelectState
        '
        Me.txtSelectState.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSelectState.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtSelectState.Location = New System.Drawing.Point(343, 129)
        Me.txtSelectState.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSelectState.Name = "txtSelectState"
        Me.txtSelectState.ReadOnly = True
        Me.txtSelectState.Size = New System.Drawing.Size(92, 25)
        Me.txtSelectState.TabIndex = 29
        Me.txtSelectState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCountBlock
        '
        Me.btnCountBlock.Location = New System.Drawing.Point(33, 129)
        Me.btnCountBlock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCountBlock.Name = "btnCountBlock"
        Me.btnCountBlock.Size = New System.Drawing.Size(100, 29)
        Me.btnCountBlock.TabIndex = 19
        Me.btnCountBlock.Text = "圖塊數量"
        Me.btnCountBlock.UseVisualStyleBackColor = True
        '
        'btnSelectBlock
        '
        Me.btnSelectBlock.Location = New System.Drawing.Point(33, 76)
        Me.btnSelectBlock.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSelectBlock.Name = "btnSelectBlock"
        Me.btnSelectBlock.Size = New System.Drawing.Size(100, 29)
        Me.btnSelectBlock.TabIndex = 18
        Me.btnSelectBlock.Text = "選取圖塊✜"
        Me.btnSelectBlock.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(33, 24)
        Me.btnSelect.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(100, 29)
        Me.btnSelect.TabIndex = 17
        Me.btnSelect.Text = "選取範圍✜"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 215)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMain"
        Me.Text = "AcadCountBlocks"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBlockQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBlockName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCountBlock As System.Windows.Forms.Button
    Friend WithEvents btnSelectBlock As System.Windows.Forms.Button
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents txtSelectState As System.Windows.Forms.TextBox
    Friend WithEvents lblSecond As System.Windows.Forms.Label

End Class
