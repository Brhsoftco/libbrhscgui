Public Class aboutForm
    Private Sub aboutForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString
    End Sub
End Class