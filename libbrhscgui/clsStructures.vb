Imports System.Windows.Forms
Imports System.Windows
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Structures
    Public Class Credential

        Private strUsername As String
        Private strPassword As String
        Private strDomain As String

        ''' <summary>
        ''' Set or get the username for this credential profile
        ''' </summary>
        ''' <returns>username</returns>
        Public Property username() As String
            Set(value As String)
                strUsername = value
            End Set
            Get
                Return strUsername
            End Get
        End Property

        ''' <summary>
        ''' Set or get the password for this credential profile
        ''' </summary>
        ''' <returns>password</returns>
        Public Property password() As String
            Set(value As String)
                strPassword = value
            End Set
            Get
                Return strPassword
            End Get
        End Property

        ''' <summary>
        ''' Set or get the domain for this credential profile
        ''' </summary>
        ''' <returns>domain</returns>
        Public Property domain() As String
            Set(value As String)
                strDomain = value
            End Set
            Get
                Return strDomain
            End Get
        End Property
    End Class

    Public Class ProxyDetails

        Private strAddress As String = ""
        Private intPort As Integer = 8080

        ''' <summary>
        ''' Get or set the proxy server's IP Address or Hostname
        ''' </summary>
        ''' <returns>strAddress</returns>
        Public Property Address As String
            Get
                Return strAddress
            End Get
            Set(value As String)
                strAddress = value
            End Set
        End Property
    End Class

    Public Class GUIMethods

        ''' <summary>
        ''' Return True if the internet settings has ProxyEnable = True.
        ''' </summary>
        ''' <returns></returns>

        Private Function LocalProxyDetails() As System.Net.WebProxy

        End Function

        Public Function GetInternetDateTime(Optional useProxy As Boolean = False, Optional proxyPort As Integer = 8080, Optional proxyAddress As String = "127.0.0.1", Optional useCredentials As Boolean = False, Optional proxyUsername As String = "", Optional proxyPassword As String = "") As DateTime
            Dim dateTime As DateTime = DateTime.MinValue
            Dim request As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("http://www.microsoft.com"), System.Net.HttpWebRequest)
            Dim userInt As New libbrhscgui.Components.UserInteraction


            If useProxy Then
                request.Proxy = request.GetSystemWebProxy()
                request.DefaultWebProxy = request.GetSystemWebProxy()
            End If
            request.Method = "GET"
            request.Accept = "text/html, application/xhtml+xml, */*"
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)"
            request.ContentType = "application/x-www-form-urlencoded"
            request.CachePolicy = New System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore)
            Dim response As System.Net.HttpWebResponse = DirectCast(request.GetResponse(), System.Net.HttpWebResponse)
            If response.StatusCode = System.Net.HttpStatusCode.OK Then
                Dim todaysDates As String = response.Headers("date")
                dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal)
            Else
                MessageBox.Show("Internet Protocol Error: " & response.StatusCode.ToString() & ". Occurred in " & System.Reflection.Assembly.GetExecutingAssembly().FullName(),
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return dateTime
        End Function

        Public Shared Iterator Function GetAllChildren(ByVal root As Control) As IEnumerable(Of Control)
            Dim stack = New Stack(Of Control)()
            stack.Push(root)

            While stack.Any()
                Dim [next] = stack.Pop()

                For Each child As Control In [next].Controls
                    stack.Push(child)
                Next

                Yield [next]
            End While
        End Function
        Public Sub makeFormWinDefault(form As libbrhscgui.Components.FlatMoveableForm)
            form.FormBorderStyle = FormBorderStyle.FixedSingle
            form.MaximizeBox = False
            form.MinimizeBox = False
            form.BackColor = Color.FromKnownColor(KnownColor.Control)
            form.Font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
            form.ControlBox = True

            For Each ctrl As Object In GetAllChildren(form)
                If ctrl.Text = "X" Or ctrl.Text = "_" Then
                    form.Controls.Remove(ctrl)
                ElseIf ctrl.GetType() Is GetType(libbrhscgui.Components.FlatTitleBar) Then
                    form.Controls.Remove(ctrl)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.TextBox) Then
                    ctrl.BackColor = Color.White
                    ctrl.BorderStyle = BorderStyle.FixedSingle
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.Button) Then
                    ctrl.FlatStyle = FlatStyle.System
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ForeColor = Color.Black
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(libbrhscgui.Components.FlatButton) Then
                    ctrl.FlatStyle = FlatStyle.System
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ForeColor = Color.Black
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.RadioButton) Then
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ForeColor = Color.Black
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.Label) Then
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ForeColor = Color.Black
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.LinkLabel) Then
                    ctrl.LinkColor = Color.Blue
                    ctrl.VisitedLinkColor = Color.Purple
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ActiveLinkColor = Color.Red
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(libbrhscgui.Components.FlatLinkLabel) Then
                    ctrl.LinkColor = Color.Blue
                    ctrl.VisitedLinkColor = Color.Purple
                    ctrl.BackColor = Color.FromKnownColor(KnownColor.Control)
                    ctrl.ActiveLinkColor = Color.Red
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                ElseIf ctrl.GetType() Is GetType(System.Windows.Forms.ListBox) Then
                    ctrl.BackColor = Color.White
                    ctrl.ForeColor = Color.Black
                    ctrl.font = New Font(FontFamily.GenericSansSerif, 8.25, FontStyle.Regular, GraphicsUnit.Point)
                End If
            Next
        End Sub
    End Class
End Namespace