Imports System.Runtime.InteropServices

Public Class InputUI
    <DllImport("user32.dll")>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Const SWP_NOSIZE As UInteger = &H1
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_SHOWWINDOW As UInteger = &H40


    Private Sub Second_CheckedChanged(sender As Object, e As EventArgs) Handles Second.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        If Me.Text = "自定义自动关机时间 - WFL Tool" Then
            Dim pwstdntimeINT As Int64
            Dim pwstdntimeText As String = TextBox1.Text
            Try
                pwstdntimeINT = pwstdntimeText
            Catch ex As Exception
                Exit Sub
            End Try
            Dim pwstdntimeNew As Int64
            If Second.Checked = True Then
                pwstdntimeNew = pwstdntimeINT
            End If
            If Minute.Checked = True Then
                pwstdntimeNew = pwstdntimeINT * 60
            End If
            If Hour.Checked = True Then
                pwstdntimeNew = pwstdntimeINT * 3600
            End If
            Dim pwstdntimeString As String = pwstdntimeNew
            CreateObject("shell.application").shellexecute("shutdown.EXE", "/s /t " + pwstdntimeString, "", "", 0)
        End If
        Close()
    End Sub

    Private Sub InputUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '置顶窗口，如果在programfiles目录或Windows目录并且签名了就可以UIaccess
        Dim OnTop As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("OnTop", "无")
        If OnTop = "1" Then
            SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW)
        End If
    End Sub
End Class