Imports System.Runtime.InteropServices
Imports Microsoft.Win32

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
        If TextBox1.Text = "" Or TextBox1.Text = " " Or TextBox1.Text = "  " Or TextBox1.Text = "　" Then
            Exit Sub                    '常见空值直接跳过
        End If
        If Me.Text = "自定义自动关机时间 - WFL Tool" Then
            Dim pwstdntimeINT As Int64
            Dim pwstdntimeText As String = TextBox1.Text
            Try
                pwstdntimeINT = pwstdntimeText          '尝试转为int64类型
            Catch ex As Exception
                Exit Sub                       '转换失败说明输入不对，直接退出
            End Try
            Dim pwstdntimeNew As Int64
            If Second.Checked = True Then               '秒
                pwstdntimeNew = pwstdntimeINT           '赋值
                Try                    '注册表写入选择记忆
                    Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WFL Tool")
                        key.SetValue("ShutTimeUnit", 0, RegistryValueKind.DWord)
                    End Using
                Catch ex As Exception
                End Try
            End If
            If Minute.Checked = True Then               '分
                pwstdntimeNew = pwstdntimeINT * 60      '转换后赋值
                Try                    '注册表写入选择记忆
                    Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WFL Tool")
                        key.SetValue("ShutTimeUnit", 1, RegistryValueKind.DWord)
                    End Using
                Catch ex As Exception
                End Try
            End If
            If Hour.Checked = True Then                 '时
                pwstdntimeNew = pwstdntimeINT * 3600    '转换后赋值
                Try                    '注册表写入选择记忆
                    Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WFL Tool")
                        key.SetValue("ShutTimeUnit", 2, RegistryValueKind.DWord)
                    End Using
                Catch ex As Exception
                End Try
            End If
            Dim pwstdntimeString As String = pwstdntimeNew  '转回字符串
            CreateObject("shell.application").shellexecute("shutdown.EXE", "/s /t " + pwstdntimeString, "", "", 0)
        End If
        If Me.Text = "在""Conhost""中执行自定义命令 - WFL Tool" Then
            Shell("conhost.exe " + TextBox1.Text, AppWinStyle.NormalFocus, False, -1)
        End If
        If Me.Text = "在""Windows 终端""中执行命令 - WFL Tool" Then
            Shell("conhost.exe wt " + TextBox1.Text, AppWinStyle.NormalFocus, False, -1)
        End If
        Close()
    End Sub

    Private Sub InputUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '置顶窗口，如果在programfiles目录或Windows目录并且签名了就可以UIaccess
        Dim OnTop As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "OnTop", Nothing)
        If OnTop = "1" Then
            SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW)
        End If
        Dim STU As Integer = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "ShutTimeUnit", Nothing)
        If STU = 1 Then
            Minute.Checked = True               '读取上次的时间选择
        ElseIf STU = 2 Then
            Hour.Checked = True
        End If
    End Sub
End Class