<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.gbLogin = New System.Windows.Forms.GroupBox()
        Me.txtUsername = New libbrhscgui.Components.WaterMarkTextBox()
        Me.txtPassword = New libbrhscgui.Components.WaterMarkTextBox()
        Me.txtDomain = New libbrhscgui.Components.WaterMarkTextBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbLogin
        '
        Me.gbLogin.AutoSize = True
        Me.gbLogin.Controls.Add(Me.txtDomain)
        Me.gbLogin.Controls.Add(Me.txtPassword)
        Me.gbLogin.Controls.Add(Me.txtUsername)
        Me.gbLogin.Location = New System.Drawing.Point(13, 13)
        Me.gbLogin.Name = "gbLogin"
        Me.gbLogin.Size = New System.Drawing.Size(277, 111)
        Me.gbLogin.TabIndex = 0
        Me.gbLogin.TabStop = False
        Me.gbLogin.Text = "Please enter your credentials for <Service Name>"
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtUsername.Location = New System.Drawing.Point(7, 20)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(261, 20)
        Me.txtUsername.TabIndex = 0
        Me.txtUsername.WaterMarkColor = System.Drawing.Color.Gray
        Me.txtUsername.WaterMarkText = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPassword.Location = New System.Drawing.Point(7, 46)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(261, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        Me.txtPassword.WaterMarkColor = System.Drawing.Color.Gray
        Me.txtPassword.WaterMarkText = "Password"
        '
        'txtDomain
        '
        Me.txtDomain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDomain.Location = New System.Drawing.Point(7, 72)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(261, 20)
        Me.txtDomain.TabIndex = 2
        Me.txtDomain.WaterMarkColor = System.Drawing.Color.Gray
        Me.txtDomain.WaterMarkText = "Domain"
        '
        'btnSubmit
        '
        Me.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSubmit.Location = New System.Drawing.Point(215, 130)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 1
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(134, 130)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(305, 165)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.gbLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.gbLogin.ResumeLayout(False)
        Me.gbLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbLogin As System.Windows.Forms.GroupBox
    Friend WithEvents txtUsername As Components.WaterMarkTextBox
    Friend WithEvents txtPassword As Components.WaterMarkTextBox
    Friend WithEvents txtDomain As Components.WaterMarkTextBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
