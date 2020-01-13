Public Class frmLogin

    Public strUsername As String = ""
    Public strPassword As String = ""
    Public strDomain As String = ""
    Public strResult As String = "ok"

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        strResult = "!cancel=user"
        Me.Close()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        strUsername = txtUsername.Text
        strPassword = txtPassword.Text
        strDomain = txtDomain.Text
    End Sub
End Class