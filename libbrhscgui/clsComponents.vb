Imports System.Drawing
Imports System.Windows.Forms

'=================================='
'= CUSTOM COMPONENTS CLASS FOR UI ='
'=================================='
'= NOTE(S): *OPTIONAL NOTES HERE* ='
'=================================='
'= COPYRIGHT (C) BRH SOFTCO 2018  ='
'=================================='

Namespace Components

    Public Class CalloutYou
        Inherits System.Windows.Forms.Label
        Sub New()
            Me.BackgroundImage = My.Resources.callout_002
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.TextAlign = ContentAlignment.MiddleCenter
            Me.AutoSize = True
            Me.ForeColor = Color.White
            Me.Padding = New Padding(20, 5, 20, 5)
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New Padding(0, 2, 30, 10)
        End Sub
    End Class
    Public Class CalloutOther
        Inherits Label
        Sub New()
            Me.BackgroundImage = My.Resources.callout_001
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.TextAlign = ContentAlignment.MiddleCenter
            Me.AutoSize = True
            Me.ForeColor = Color.White
            Me.Padding = New Padding(20, 5, 20, 5)
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular,
            System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New Padding(15, 2, 20, 10)
        End Sub
    End Class
    Public Class FlatButton
        Inherits System.Windows.Forms.Button

        Sub New()
            Me.ForeColor = Color.Black
            Me.FlatStyle = FlatStyle.Flat
            Me.FlatAppearance.BorderSize = 0
            Me.BackColor = Color.Silver
            Me.FlatAppearance.MouseOverBackColor = Color.Gray
            Me.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Font = New System.Drawing.Font("Arial", 8.25!,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.AutoSize = True
        End Sub

        Public Sub controlmouseenter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
            Me.ForeColor = Color.White
        End Sub

        Public Sub controlmouseleave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
            Me.ForeColor = Color.Black
        End Sub

    End Class

    Public Class FlatExitButton
        Inherits System.Windows.Forms.Label

        Private blnExitsForm As Boolean = True

        Public WriteOnly Property exitsForm As Boolean
            Set(value As Boolean)
                blnExitsForm = value
            End Set
        End Property

        Sub New()
            Me.AutoSize = True
            Me.Text = "X"
            Me.ForeColor = Color.Red
            Me.Font = New System.Drawing.Font("Arial", 8.25!,
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End Sub

        Public Sub controlmouseenter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
            Me.ForeColor = Color.White
            Me.BackColor = Color.Red
        End Sub

        Public Sub controlmouseleave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
            Me.ForeColor = Color.Red
            Me.BackColor = Me.Parent.BackColor
        End Sub

        Public Sub controlmouseclick(sender As Object, e As EventArgs) Handles MyBase.Click
            If blnExitsForm Then
                FindForm().Close()
            End If
        End Sub

    End Class

    Public Class WaterMarkTextBox
        Inherits TextBox

        Private oldFont As Font = Nothing
        Private waterMarkTextEnabled As Boolean = False
        Private _waterMarkColor As Color = Color.Gray

        Public Property WaterMarkColor As Color
            Get
                Return _waterMarkColor
            End Get
            Set(ByVal value As Color)
                _waterMarkColor = value
                Invalidate()
            End Set
        End Property

        Private _waterMarkText As String = "Water Mark"

        Public Property WaterMarkText As String
            Get
                Return _waterMarkText
            End Get
            Set(ByVal value As String)
                _waterMarkText = value
                Invalidate()
            End Set
        End Property

        Public Sub New()
            JoinEvents(True)
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            WaterMark_Toggel(Nothing, Nothing)
        End Sub

        Protected Overrides Sub OnPaint(ByVal args As PaintEventArgs)
            Dim drawFont As System.Drawing.Font = New System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit)
            Dim drawBrush As SolidBrush = New SolidBrush(WaterMarkColor)
            args.Graphics.DrawString((If(waterMarkTextEnabled, WaterMarkText, Text)), drawFont, drawBrush, New PointF(0.0F, 0.0F))
            MyBase.OnPaint(args)
        End Sub

        Private Sub JoinEvents(ByVal join As Boolean)
            If join Then
                AddHandler Me.TextChanged, New System.EventHandler(AddressOf Me.WaterMark_Toggel)
                AddHandler Me.LostFocus, New System.EventHandler(AddressOf Me.WaterMark_Toggel)
                AddHandler Me.FontChanged, New System.EventHandler(AddressOf Me.WaterMark_FontChanged)
            End If
        End Sub

        Private Sub WaterMark_Toggel(ByVal sender As Object, ByVal args As EventArgs)
            If Me.Text.Length <= 0 Then
                EnableWaterMark()
            Else
                DisbaleWaterMark()
            End If
        End Sub

        Private Sub EnableWaterMark()
            oldFont = New System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit)
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.waterMarkTextEnabled = True
            Refresh()
        End Sub

        Private Sub DisbaleWaterMark()
            Me.waterMarkTextEnabled = False
            Me.SetStyle(ControlStyles.UserPaint, False)
            If oldFont IsNot Nothing Then Me.Font = New System.Drawing.Font(oldFont.FontFamily, oldFont.Size, oldFont.Style, oldFont.Unit)
        End Sub

        Private Sub WaterMark_FontChanged(ByVal sender As Object, ByVal args As EventArgs)
            If waterMarkTextEnabled Then
                oldFont = New System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit)
                Refresh()
            End If
        End Sub
    End Class


    Public Class FlatLinkLabel
        Inherits System.Windows.Forms.LinkLabel

        Sub New()
            Me.ActiveLinkColor = Color.Gray
            Me.AutoSize = True
            Me.VisitedLinkColor = Color.Silver
            Me.LinkColor = Color.Silver
            Me.Font = New System.Drawing.Font("Arial", 8.25!,
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End Sub

    End Class

    Public Class FlatLabel
        Inherits System.Windows.Forms.Label
        Sub New()
            Me.ForeColor = Color.White
        End Sub
    End Class

    ''' <summary>
    ''' CREDIT: https://stackoverflow.com/questions/800767/how-to-kill-background-worker-completely
    ''' </summary>
    Public Class AbortableBackgroundWorker
        Inherits System.ComponentModel.BackgroundWorker

        Private workerThread As System.Threading.Thread

        Protected Overrides Sub OnDoWork(ByVal e As System.ComponentModel.DoWorkEventArgs)
            workerThread = System.Threading.Thread.CurrentThread

            Try
                MyBase.OnDoWork(e)
            Catch __unusedThreadAbortException1__ As System.Threading.ThreadAbortException
                e.Cancel = True
                System.Threading.Thread.ResetAbort()
            End Try
        End Sub

        Public Sub Abort()
            If workerThread IsNot Nothing Then
                workerThread.Abort()
                workerThread = Nothing
            End If
        End Sub
    End Class

    Public Class FlatTitleBar
        Inherits System.Windows.Forms.Panel

        Dim drawMnmzBtn As Boolean = True

        Dim title As New System.Windows.Forms.Label
        Dim exitBtn As New FlatExitButton
        Dim mnmzBtn As New FlatMinimizeButton

        Dim movesForm As Boolean = True

        ''' <summary>
        ''' Get or set whether the titleBar can interact with point-to-point details
        ''' for moving flat forms.
        ''' Requirement(s): Parent form must be of type FlatMoveableForm
        ''' </summary>
        Public Property canMoveForm As Boolean
            Get
                Return movesForm
            End Get
            Set(value As Boolean)
                movesForm = value
            End Set
        End Property

        ''' <summary>
        ''' Set or get the title text of the titleBar. This will change the
        ''' text of the label to the left of the title bar.
        ''' Default: "SimpleChat.FlatTitleBar"
        ''' </summary>
        Public Property titleText As String
            Get
                Return title.Text
            End Get
            Set(value As String)
                title.Text = value
            End Set
        End Property

        ''' <summary>
        ''' Control whether the titleBar will draw a FlatMinimizeButton next to
        ''' the FlatExitButton
        ''' Default: True
        ''' </summary>
        Public Property drawMinimizeBtn As Boolean
            Get
                Return drawMnmzBtn
            End Get
            Set(value As Boolean)
                If value Then
                    Me.Controls.Remove(exitBtn)
                    Me.Controls.Add(mnmzBtn)
                    Me.Controls.Add(exitBtn)
                Else
                    Me.Controls.Remove(mnmzBtn)
                End If
            End Set
        End Property

        ''' <summary>
        ''' Indicate whether clicking the FlatExitButton on the titleBar
        ''' will close the form; useful for providing custom exit behaviour.
        ''' Default: True
        ''' </summary>
        Public WriteOnly Property exitClosesForm As Boolean
            Set(value As Boolean)
                exitBtn.exitsForm = value
            End Set
        End Property

        Sub New()
            ''TITLE LABEL
            title = New System.Windows.Forms.Label
            title.ForeColor = Color.White
            title.Font = New System.Drawing.Font("Arial", 10.0!,
                    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            title.Text = "SimpleChat.FlatTitleBar"
            title.Location = New Point(5, 5)
            title.AutoSize = True

            ''EXIT BUTTON
            exitBtn = New FlatExitButton
            exitBtn.Dock = System.Windows.Forms.DockStyle.Right
            exitBtn.Padding = New Padding(5, 5, 5, 5)

            ''MINIMIZE BUTTON
            mnmzBtn = New FlatMinimizeButton
            mnmzBtn.Dock = System.Windows.Forms.DockStyle.Right
            mnmzBtn.Padding = New Padding(5, 3, 5, 5)

            ''REQUIRED OBJECT PROPERTIES
            Me.BackColor = System.Drawing.Color.SlateBlue
            Me.Controls.Add(title)
            Me.Controls.Add(exitBtn)
            Me.Dock = System.Windows.Forms.DockStyle.Top
            Me.Location = New System.Drawing.Point(0, 0)
            Me.Name = "titleBar"
            Me.Height = 27
            Me.TabIndex = 29
        End Sub

        Sub controlmousedown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
            Dim parent As FlatMoveableForm = Me.Parent
            If movesForm And parent.isMoveable Then
                parent.lastPoint = New Point(e.X, e.Y)
            End If
        End Sub

        Sub controlmousemove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
            Dim parent As FlatMoveableForm = Me.Parent
            If movesForm And parent.isMoveable Then
                If e.Button = MouseButtons.Left Then
                    parent.Left += e.X - parent.lastPoint.X
                    parent.Top += e.Y - parent.lastPoint.Y
                End If
            End If
        End Sub

    End Class

    Public Class FlatMinimizeButton
        Inherits System.Windows.Forms.Label

        Sub New()
            Me.ForeColor = Color.White
            Me.Text = "_"
            Me.AutoSize = True
        End Sub

        Sub controlmouseenter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
            Me.BackColor = Color.Blue
        End Sub

        Sub controlmouseleave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
            Me.BackColor = Me.Parent.BackColor
        End Sub

        Sub controlmouseclick(sender As Object, e As EventArgs) Handles MyBase.Click
            FindForm.Hide()
        End Sub

    End Class

    Public Class FlatMoveableForm
        Inherits System.Windows.Forms.Form

        Dim objTitleBar As FlatTitleBar
        Dim pntLastPoint As System.Drawing.Point
        Dim blnIsMoveable As Boolean = True

        ''' <summary>
        ''' Access the last known point before a point move executes
        ''' </summary>
        ''' <returns></returns>
        Public Property lastPoint As Point
            Get
                Return pntLastPoint
            End Get
            Set(value As Point)
                pntLastPoint = value
            End Set
        End Property

        ''' <summary>
        ''' Defines whether or not the form can move by user mouse input
        ''' </summary>
        ''' <returns></returns>
        Property isMoveable As Boolean
            Get
                Return blnIsMoveable
            End Get
            Set(value As Boolean)
                blnIsMoveable = value
            End Set
        End Property

        ''' <summary>
        ''' Gets the initial flat title bar object associated with the current FlatMoveableForm.
        ''' </summary>
        ''' <returns></returns>
        ReadOnly Property titleBar As FlatTitleBar
            Get
                Return objTitleBar
            End Get
        End Property

        Property titleText As String
            Get
                Return titleBar.titleText
            End Get
            Set(value As String)
                titleBar.titleText = value
            End Set
        End Property

        Sub New()
            objTitleBar = New FlatTitleBar()
            objTitleBar.titleText = "FlatMoveableForm"
            Me.Controls.Add(objTitleBar)

            Me.BackColor = System.Drawing.Color.FromArgb(255, 64, 64, 64)
            Me.FormBorderStyle = FormBorderStyle.None
        End Sub

        Public Sub controlmousedown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
            If blnIsMoveable Then
                pntLastPoint = New Point(e.X, e.Y)
            End If
        End Sub

        Public Sub controlmousemove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
            If e.Button = MouseButtons.Left And blnIsMoveable Then
                Me.Left += e.X - pntLastPoint.X
                Me.Top += e.Y - pntLastPoint.Y
            End If
        End Sub

    End Class

    Public Class SearchTextBox
        Inherits System.Windows.Forms.TextBox

        Dim blnSearching As Boolean = False

        Public Property Searching As Boolean
            Get
                Return blnSearching
            End Get
            Set(value As Boolean)
                blnSearching = value
            End Set
        End Property

        Sub New()
            Me.BorderStyle = BorderStyle.FixedSingle
            Me.Text = "Search"
            Me.ForeColor = Color.Gray

            Me.blnSearching = False
        End Sub

        Public Sub ResetSearchBox()
            Me.BorderStyle = BorderStyle.FixedSingle
            Me.Text = "Search"
            Me.ForeColor = Color.Gray

            Me.blnSearching = False
        End Sub

        Sub controlgotfocus(sender As Object, e As EventArgs) Handles MyBase.GotFocus
            If Me.Text = "Search" And Me.ForeColor = Color.Gray Then
                Me.blnSearching = True

                Me.Clear()
                Me.ForeColor = Color.Black
            End If
        End Sub

        Sub controllostfocus(sender As Object, e As EventArgs) Handles MyBase.LostFocus
            If Me.Text = "" Then
                Me.blnSearching = False

                Me.Text = "Search"
                Me.ForeColor = Color.Gray
            End If
        End Sub

    End Class

    Public Class UserInteraction

        Dim blnPasswordChar As Boolean = False

        Public Property usePasswordChar() As Boolean
            Set(value As Boolean)
                blnPasswordChar = value
            End Set
            Get
                Return blnPasswordChar
            End Get
        End Property

        Public Function showLoginForm(serviceName As String, Optional domain As String = "") As Structures.Credential
            Dim cred As New Structures.Credential
            Dim frm As New frmLogin

            frm.gbLogin.Text = "Please enter your credentials for " & serviceName

            If Not domain = "" Then
                frm.txtDomain.WaterMarkText = ""
                frm.txtDomain.Text = domain
            End If

            If frm.ShowDialog = DialogResult.OK Then
                If frm.strUsername = "" Or frm.strPassword = "" Then
                    MsgBox("One or more fields are blank; please enter your username and password.", vbCritical, "Validation Error")
                    cred.username = "null"
                    cred.password = "null"
                    cred.domain = "null"
                    Return cred
                Else
                    cred.domain = frm.strDomain
                    cred.username = frm.strUsername
                    cred.password = frm.strPassword
                    Return cred
                End If
            ElseIf frm.DialogResult = DialogResult.Cancel Then
                MsgBox("Operation cancelled by user", vbCritical, "Validation Error")
                cred.username = "null"
                cred.password = "null"
                cred.domain = "null"
                Return cred
            Else
                MsgBox("Invalid results were")
            End If
        End Function

        Public Function showInputForm(Optional description As String = "Enter Value", Optional title As String = "Input", Optional checkbox As Boolean = False, Optional checkboxvalue As String = "") As InputResult

            Dim frm As New frmInputBox
            Dim iptresult As New InputResult

            frm.txtResponse.UseSystemPasswordChar = blnPasswordChar
            frm.txtResponse.Clear()
            frm.Text = title
            frm.lblDescription.Text = description


            If Not checkbox Then
                frm.blnCheckbox = False
            Else
                frm.blnCheckbox = True
                frm.chkMain.Text = checkboxvalue
            End If
            If frm.ShowDialog = DialogResult.OK Then
                iptresult.txt = frm.strResult
                iptresult.chkd = frm.blnCheckResult
                Return iptresult
            ElseIf frm.DialogResult = DialogResult.Cancel Then
                MsgBox("Operation cancelled by user", vbCritical, "Validation Error")
                iptresult.txt = "!cancel=user"
                Return iptresult
            Else
                MsgBox("An unexpected DialogResult was given; this might affect overall performance of the application.", vbExclamation, "Warning")
                iptresult.txt = ""
                Return iptresult
            End If
        End Function
    End Class
    Public Class InputResult
        Public txt As String = ""
        Public chkd As Boolean = False
    End Class

End Namespace