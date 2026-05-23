Imports System.Runtime.InteropServices

Public Class Form16

    <DllImport("user32.dll")>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Const SWP_NOSIZE As UInteger = &H1
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_SHOWWINDOW As UInteger = &H40


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '置顶窗口，如果在programfiles目录或Windows目录并且签名了就可以UIaccess
        Dim OnTop As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("OnTop", "无")
        If OnTop = "1" Then
            SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW)
        End If
        Timer1.start
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Dim heightback As Int32 = Me.Height '捕获自动调整窗体大小模式下的窗体高度
        AutoSize = False                    '关闭自动调整窗体大小模式，窗体会变窄变高
        Me.Height = heightback              '应用保存的高度
        If Label1.Text = "要 重启资源管理器 吗？" Then
            TextBox1.Text = "你确定要重启资源管理器吗？" & vbCrLf & vbCrLf & "重启资源管理器会导致你正在进行的文件操作（文件复制、删除等操作）被强行打断，如果你需要重启，请先关闭这些操作或等待这些操作完成后单击继续重启或不再提示" & vbCrLf & vbCrLf & "如果不希望以后再弹出这个提示，请点击不再提示，否则请单击继续重启"
            Button2.Visible = True
            Button3.Visible = True
            Button1.Visible = False
            Button2.Text = "继续重启"
        ElseIf Label1.Text = "要 关闭资源管理器 吗？" Then
            TextBox1.Text = "你确定要关闭资源管理器吗？" & vbCrLf & vbCrLf & "关闭资源管理器会导致你正在进行的文件操作（文件复制、删除等操作）被强行打断，如果你需要关闭，请先关闭这些操作或等待这些操作完成后单击继续关闭或不再提示" & vbCrLf & vbCrLf & "关闭资源管理器后会没有桌面和任务栏，不要忘记重新打开" & vbCrLf & vbCrLf & "如果不希望以后再弹出这个提示，请点击不再提示，否则请单击继续关闭"
            Button2.Visible = True
            Button3.Visible = True
            Button1.Visible = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Visible = False
        Shell("taskkill.exe /im explorer.exe /f", AppWinStyle.Hide, True, -1)
        If Label1.Text = "要 重启资源管理器 吗？" Then
            Shell("cmd.exe /c start %windir%\explorer.exe", AppWinStyle.Hide, True, -1)
        End If
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Visible = False
        Shell("taskkill.exe /im explorer.exe /f", AppWinStyle.Hide, True, -1)
        If Label1.Text = "要 重启资源管理器 吗？" Then
            Shell("cmd.exe /c start %windir%\explorer.exe", AppWinStyle.Hide, True, -1)
        End If
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v NoMsgReExp /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)

        ' 遍历所有打开的窗体，查找类型为 Form1 的实例
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is Form1 Then
                ' 找到目标窗体实例，将其转换为 Form1 类型以访问其控件
                Dim targetForm As Form1 = DirectCast(frm, Form1)
                ' 确保控件存在并设置其可见性
                ' 注意：ToolStripMenuItem34 可能是 Private，需修改为 Internal 或 Public，
                ' 或通过公开方法/属性来设置。这里假设已将其 Modifiers 属性设置为 Friend 或 Public。
                If targetForm.ToolStripMenuItem34 IsNot Nothing Then
                    targetForm.ToolStripMenuItem34.Visible = True
                End If
                ' 找到并操作后可以退出循环（如果只需操作第一个找到的实例）
                Exit For
            End If
        Next

        Close()
    End Sub
End Class