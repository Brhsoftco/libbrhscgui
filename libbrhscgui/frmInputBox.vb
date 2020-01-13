'================================='
'= SIMPLECHAT BASIC DIALOG CODE  ='
'= COPYRIGHT (C) BRH SOFTCO 2018 ='
'================================='

Imports System.Windows.Forms

Public Class frmInputBox
    Public strResult As String = ""
    Public blnCheckResult As Boolean = False
    Public blnCheckbox As Boolean = False

    Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        strResult = txtResponse.Text
        blnCheckResult = chkMain.Checked
        Me.Close()
    End Sub

    Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtResponse.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Sub frmInputBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Sub frmInputBox_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not blnCheckbox Then
            chkMain.Visible = False
            Me.Controls.Remove(chkMain)
            Me.Size = New Drawing.Size(Me.Width, 87)
        Else
            chkMain.Visible = True
            Me.Controls.Remove(chkMain)
            Me.Controls.Add(chkMain)
            Me.Size = New Drawing.Size(Me.Width, 121)
        End If
    End Sub

    Private Sub frmInputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class