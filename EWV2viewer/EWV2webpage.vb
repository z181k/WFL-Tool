
Option Explicit On
Imports System.Security.Policy
Imports System.Windows.Forms
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Win32

Public Class EWV2webpage
    Private Async Sub HelpEWV2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Try
            ' 获取存放固定版本运行时的完整路径
            Dim runtimePath As String = System.IO.Path.Combine(Application.StartupPath, "WebView2Runtime")

            ' 检查运行时文件夹是否存在
            If Not System.IO.Directory.Exists(runtimePath) Then
                'MessageBox.Show("WebView2运行时文件夹不存在: " & runtimePath)
                GoTo Showpage
                Return
            End If

            ' 使用固定版本运行时创建 WebView2 环境
            ' 注意：参数必须用括号括起来
            Dim environment As CoreWebView2Environment =
                Await CoreWebView2Environment.CreateAsync(browserExecutableFolder:=runtimePath)

            ' 使用创建好的环境初始化 WebView2 控件
            ' 控件名称是 WebView21
            Await WebView21.EnsureCoreWebView2Async(environment)

Showpage:

            ' 初始化成功后导航到网页
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
                Try
                    ' 写入 HKEY_CURRENT_USER\Software\MyApp
                    Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WebPageViewer")
                        ' 写入字符串值
                        key.SetValue("EWV2webpageShowIcon", "True", RegistryValueKind.String)
                        key.SetValue("EWV2webpageTitle", "注意！这是第三方页面", RegistryValueKind.String)
                        key.SetValue("EWV2webpageURL", "https://liulanmi.com/core", RegistryValueKind.String)
                        key.SetValue("EWV2webpageClean", "False", RegistryValueKind.String)

                        ' 写入整数值
                        'key.SetValue("UserAge", 25, RegistryValueKind.DWord)

                        ' 写入其他类型
                        'key.SetValue("LastLogin", DateTime.Now.ToString(), RegistryValueKind.String)
                        'key.SetValue("IsAdmin", False, RegistryValueKind.DWord) ' 0 = False, 1 = True

                        'MessageBox.Show("注册表写入成功！")

                    End Using
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("没有权限写入注册表，请以管理员身份运行程序或联系开发者以寻求帮助。", "错误 - DBT WebPageViewer")
                Catch ex As Exception
                    MsgBox("写入注册表失败：" & ex.Message, MsgBoxStyle.Critical, "错误 - DBT WebPageViewer")
                End Try
            Else
                '窗口大小
                Dim FormWidth As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("Width", "0")
                Dim FormHeight As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("Height", "0")
                If FormWidth > 0 And FormHeight > 0 Then
                    Me.Size = New Size(FormWidth, FormHeight)
                End If
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

        Catch ex As Exception
            WebView21.Source = New Uri("https://www.gov.cn")
            'MessageBox.Show("WebView2 初始化失败: " & ex.Message)
        End Try
    End Sub

    ' 可选：处理导航开始事件
    Private Sub WebView21_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        ' 可以在这里添加加载动画或禁用按钮
        'Me.Text = "正在加载..."
    End Sub

    ' 可选：处理导航完成事件
    Private Sub WebView21_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        ' 加载完成后恢复界面
        'Me.Text = "WebView2 示例"

        ' 检查是否加载成功
        If e.IsSuccess Then
            ' 可以在这里执行其他操作
        Else
            MessageBox.Show("页面加载失败")
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
