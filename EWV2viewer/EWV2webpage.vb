
Option Explicit On
Imports System.Windows.Forms

Public Class EWV2webpage
    Private Sub HelpEWV2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '下方代码为根据注册表信息调整网页界面内容代码
        Dim EWV2webpageClean As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageClean", "False")
        If EWV2webpageClean = "True" Then
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
            '清理信息
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShow /T REG_SZ /d 6 /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageShowIcon /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageTitle /T REG_SZ /d 注意！这是第三方页面 /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageURL /T REG_SZ /d ""https://liulanmi.com/core"" /f", AppWinStyle.Hide, True, -1)
            Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v EWV2webpageClean /T REG_SZ /d False /f", AppWinStyle.Hide, True, -1)
        Else
            '显示图标
            Dim Sicon2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("ShowIcon", "True")
            If Sicon2 <> "True" Then
                Me.ShowIcon = False
            End If
            '标题
            Dim Title2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("Title", "彩蛋 - 注意！这是第三方页面 - DBT WebPageViewer")
            Me.Text = Title2
            'url地址
            Dim URL2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("URL", "https://player.bilibili.com/player.html?isOutside=true&aid=291456358&bvid=BV1sf4y1b74k&cid=361932939&p=1")
            WebView21.Source = New Uri(URL2)
        End If
        '低分辨率设备兼容代码
        Dim WV21W As Int64 = WebView21.Width - Me.Width
        Dim WV21H As Int64 = WebView21.Height - Me.Height
        Dim WV21HS As String = WV21H.ToString
        Dim WV21WS As String = WV21W.ToString
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v WV21W /T REG_SZ /d " + WV21WS + " /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WebPageViewer"" /v WV21H /T REG_SZ /d " + WV21HS + " /f", AppWinStyle.Hide, True, -1)
        '根据分辨率调整窗口大小
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        If ScreenWidth > 2500 And ScreenHeight > 1400 Then
            Me.Size = New Size(1800, 1200)
        ElseIf ScreenWidth > 1400 And ScreenHeight > 1000 Then
            Me.Size = New Size(900, 700)
        ElseIf ScreenWidth > 1000 And ScreenHeight > 700 Then
            Me.Size = New Size(750, 500)
        ElseIf ScreenWidth > 799 And ScreenHeight > 599 Then
            Me.Size = New Size(600, 400)
        End If
    End Sub
    Private Sub HelpEWV2_sizechange(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
        Dim WV21W As Int64 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("WV21W", "24")
        Dim WV21H As Int64 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("WV21H", "63")
        If WV21H >= 444 Then       '300%+
            WebView21.Width = Me.Width - 44
            WebView21.Height = Me.Height - 110
        ElseIf WV21H >= 300 Then   '250%
            WebView21.Width = Me.Width - 34
            WebView21.Height = Me.Height - 90
        ElseIf WV21H >= 100 Then   '225%
            WebView21.Width = Me.Width - 29
            WebView21.Height = Me.Height - 80
        ElseIf WV21H >= -100 Then   '175%
            WebView21.Width = Me.Width - 25
            WebView21.Height = Me.Height - 64
        ElseIf WV21H >= -150 Then   '150%
            WebView21.Width = Me.Width - 21
            WebView21.Height = Me.Height - 54
        ElseIf WV21H >= -200 Then   '125%
            WebView21.Width = Me.Width - 21
            WebView21.Height = Me.Height - 54
        ElseIf WV21H < -200 Then    '100%
            WebView21.Width = Me.Width - 15
            WebView21.Height = Me.Height - 37
        End If
    End Sub

End Class
