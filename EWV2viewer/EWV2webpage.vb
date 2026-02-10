
Option Explicit On
Imports System.Windows.Forms

Public Class EWV2webpage
    Private Sub HelpEWV2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '下方代码为根据注册表信息调整网页界面内容代码
        '显示图标
        Dim EWV2webpageSicon As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageShowIcon", "True")
        If EWV2webpageSicon = "False" Then
            Me.ShowIcon = False
        End If
        '标题
        Dim EWV2webpageTitle As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageTitle", "彩蛋 - 注意！这是第三方页面 - DBT WebPageViewer")
        Me.Text = EWV2webpageTitle
        'url地址
        Dim EWV2webpageURL As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageURL", "https://player.bilibili.com/player.html?isOutside=true&aid=291456358&bvid=BV1sf4y1b74k&cid=361932939&p=1")
        WebView21.Source = New Uri(EWV2webpageURL)
        Dim EWV2webpageClean As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageClean", "False")
        If EWV2webpageClean = "True" Then
            '清理信息
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShow /T REG_SZ /d 6 /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d 注意！这是第三方页面 /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d ""https://liulanmi.com/core"" /f", AppWinStyle.Hide, True, -1)
        End If
    End Sub
    Private Sub HelpEWV2_sizechange(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
        WebView21.Width = Me.Width - 24
        WebView21.Height = Me.Height - 63
    End Sub

End Class
