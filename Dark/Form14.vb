Imports System.Runtime.InteropServices

Public Class Form14
    <DllImport("user32.dll")>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Const SWP_NOSIZE As UInteger = &H1
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_SHOWWINDOW As UInteger = &H40


    Private Sub 返回更多功能_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles 返回更多功能.LinkClicked
        Form2.Show()
        Close()
    End Sub

    Private Sub 快捷键返回BToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 快捷键返回BToolStripMenuItem.Click
        Form2.Show()
        Close()
    End Sub

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '置顶窗口，如果在programfiles目录或Windows目录并且签名了就可以UIaccess
        Dim OnTop As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\DBT\WFL Tool", True).GetValue("OnTop", "无")
        If OnTop = "1" Then
            SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW)
        End If
        Dim EnterpriseNotShow As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\DBT\WFL Tool", "EnterpriseNotShow", Nothing)
        Dim LegacyMoreUI As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("LegacyMoreUI", "无")
        If EnterpriseNotShow = 1 Then
            Exit Sub                        '企业自定义屏蔽
        ElseIf LegacyMoreUI = "True" Then
            返回更多功能.Visible = False
            快捷键返回BToolStripMenuItem.Enabled = False
        End If
        '低分辨率设备兼容代码
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        If ScreenWidth < 1000 Then
            If Me.Width < 572 Then
                Me.Width = 572
            End If
        End If
    End Sub

    Private Sub MSDT弃用说明_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MSDT弃用说明.LinkClicked
        On Error GoTo legacy
        Dim EDGEWV2 As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", "Version", Nothing)
        If EDGEWV2 = "" Then               '判断EDGE WEBVIEW2是否存在
            GoTo legacy
        End If
        If MsgBox("要在本应用窗口内打开 MSDT 弃用说明吗？这是一个来自 Microsoft 的网页内容", 308, "WFL Tool (x64)") = vbYes Then
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageClean /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageTitle /T REG_SZ /d ""Microsoft 支持诊断工具 (MSDT) 弃用的说明 - Microsoft 支持"" /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebpageViewer"" /v EWV2webpageURL /T REG_SZ /d ""https://aka.ms/msdtretire"" /f", AppWinStyle.Hide, True, -1)
            Shell("EWV2viewer\EWV2Viewer.exe", AppWinStyle.NormalFocus, False, -1)   '写入启动参数注册表并且启动ewv2
            Exit Sub
        End If
legacy:
        Shell("cmd.exe /c start https://aka.ms/msdtretire", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Apps\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Audio\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\BITS\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Power\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\PCW\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\IEBrowseWEB\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\IESecurity\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Keyboard\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Networking\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Device\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Bluetooth\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Printer\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Search\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Speech\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\WindowsUpdate\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\WindowsMediaPlayerMediaLibrary\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\WindowsMediaPlayerConfiguration\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\Video\DiagPackage.diagpkg", "", "", "", 1)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Dim SystemRoot As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "SystemRoot", Nothing)
        CreateObject("shell.application").shellexecute(SystemRoot + "\diagnostics\system\DeviceCenter\DiagPackage.diagpkg", "", "", "", 1)
    End Sub
End Class