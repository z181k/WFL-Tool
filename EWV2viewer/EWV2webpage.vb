
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
        '根据分辨率调整窗口大小
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        If ScreenWidth > 2500 And ScreenHeight > 1400 Then
            Me.Size = New Size(2000, 1200)
        ElseIf ScreenWidth > 2000 And ScreenHeight > 1000 Then
            Me.Size = New Size(1400, 850)
        ElseIf ScreenWidth > 1400 And ScreenHeight > 1000 Then
            Me.Size = New Size(900, 700)
        ElseIf ScreenWidth > 1000 And ScreenHeight > 700 Then
            Me.Size = New Size(750, 500)
        ElseIf ScreenWidth > 799 And ScreenHeight > 599 Then
            Me.Size = New Size(600, 400)
        End If
    End Sub
    Private Sub HelpEWV2_sizechange(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
        Dim scalePercentage As Integer
        Using g As Graphics = Me.CreateGraphics
            scalePercentage = CInt(Math.Round((g.DpiX / 96.0F) * 100))
        End Using

        ' 根据缩放比例设置宽度
        If scalePercentage <= 100 Then
            WebView21.Width = Me.Width - 15
            WebView21.Height = Me.Height - 37
        ElseIf scalePercentage <= 150 Then
            WebView21.Width = Me.Width - 20
            WebView21.Height = Me.Height - 54
        ElseIf scalePercentage <= 175 Then
            WebView21.Width = Me.Width - 24
            WebView21.Height = Me.Height - 64
        ElseIf scalePercentage <= 225 Then
            WebView21.Width = Me.Width - 28
            WebView21.Height = Me.Height - 80
        ElseIf scalePercentage <= 250 Then
            WebView21.Width = Me.Width - 34
            WebView21.Height = Me.Height - 90
        ElseIf scalePercentage <= 300 Then
            WebView21.Width = Me.Width - 43
            WebView21.Height = Me.Height - 108
        ElseIf scalePercentage <= 375 Then
            WebView21.Width = Me.Width - 53
            WebView21.Height = Me.Height - 136
        ElseIf scalePercentage <= 450 Then
            WebView21.Width = Me.Width - 64
            WebView21.Height = Me.Height - 164
        ElseIf scalePercentage <= 525 Then
            WebView21.Width = Me.Width - 75
            WebView21.Height = Me.Height - 192
        End If
    End Sub

End Class
