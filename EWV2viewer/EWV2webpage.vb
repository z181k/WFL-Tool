
Option Explicit On
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports System.Windows.Forms
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Win32

Public Class EWV2webpage
    Private Async Sub HelpEWV2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '根据分辨率调整窗口大小
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        If ScreenWidth >= 4000 And ScreenHeight >= 2500 Then
            Me.Size = New Size(3500, 2000)
        ElseIf ScreenWidth >= 2500 And ScreenHeight >= 1400 Then
            Me.Size = New Size(2000, 1200)
        ElseIf ScreenWidth >= 1900 And ScreenHeight >= 1000 Then
            Me.Size = New Size(1600, 900)
        ElseIf ScreenWidth >= 1400 And ScreenHeight >= 900 Then
            Me.Size = New Size(1150, 700)
        ElseIf ScreenWidth >= 1100 And ScreenHeight >= 700 Then
            Me.Size = New Size(950, 600)
        ElseIf ScreenWidth >= 900 And ScreenHeight >= 700 Then
            Me.Size = New Size(750, 600)
        ElseIf ScreenWidth >= 799 And ScreenHeight >= 599 Then
            Me.Size = New Size(600, 400)
        End If
        Try
            ' 1. 构建目标路径：%localappdata%\Publish\App
            Dim appDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            Dim targetFolder As String = Path.Combine(appDataPath, "DBT", "EasyWebpageViewer")

            ' 2. 检查文件夹是否存在，不存在则创建
            If Not Directory.Exists(targetFolder) Then
                Directory.CreateDirectory(targetFolder)
                'Debug.WriteLine($"创建文件夹: {targetFolder}")
            Else
                'Debug.WriteLine($"文件夹已存在: {targetFolder}")
            End If

            ' 3. 指定为用户数据文件夹
            Dim userDataFolder As String = targetFolder

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

            Dim environmentWV2 As CoreWebView2Environment
            environmentWV2 = Await CoreWebView2Environment.CreateAsync(browserExecutableFolder:=runtimePath, userDataFolder)

Showpage:
            ' 使用创建好的环境初始化 WebView2 控件
            ' 控件名称是 WebView21
            Await WebView21.EnsureCoreWebView2Async(environmentWV2)


            ' 初始化成功后导航到网页
            Dim EWV2webpageClean As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageClean", "False")
            If EWV2webpageClean = "True" Then
                '显示图标
                Dim EWV2webpageSicon As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageShowIcon", "True")
                If EWV2webpageSicon <> "False" Then
                    Me.ShowIcon = True
                End If
                '标题
                Dim EWV2webpageTitle As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageTitle", "彩蛋 - 注意！这是第三方页面 - DBT WebPageViewer")
                Me.Text = EWV2webpageTitle
                'url地址
                Dim EWV2webpageURL As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageURL", "https://player.bilibili.com/player.html?isOutside=true&aid=291456358&bvid=BV1sf4y1b74k&cid=361932939&p=1")
                WebView21.Source = New Uri(EWV2webpageURL)
                '清理信息
                Try
                    ' 写入
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
                Dim Sicon2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("ShowIcon", "False")
                If Sicon2 = "True" Then
                    Me.ShowIcon = True
                End If
                '标题
                Dim Title2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("Title", "无页面 - DBT WebPageViewer")
                Me.Text = Title2
                'url地址
                Dim URL2 As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("URL", "https://player.bilibili.com/player.html?isOutside=true&aid=291456358&bvid=BV1sf4y1b74k&cid=361932939&p=1")
                WebView21.Source = New Uri(URL2)
                '禁用开发工具
                Dim NoDev As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("NoDev", "False")
                If NoDev = "True" Then
                    WebView21.CoreWebView2.Settings.AreDevToolsEnabled = False
                End If
                '禁用快捷键
                Dim NoKeys As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("NoKeys", "False")
                If NoKeys = "True" Then
                    WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = False
                End If
                '禁用默认上下文菜单
                Dim NoMenu As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("NoMenu", "False")
                If NoMenu = "True" Then
                    WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("WebView2 初始化失败: " & ex.Message)
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
            'MessageBox.Show("页面加载失败")
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

    Private Sub OnNewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs)
        Dim NoNewWindow As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("NoNewWindow", "False")
        If NoNewWindow = "True" Then
            ' 标记事件为已处理，阻止系统创建新窗口
            e.Handled = True
            ' 直接在当前 WebView2 控件中导航到目标 URL
            WebView21.CoreWebView2.Navigate(e.Uri)
        End If
    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        ' 获取 CoreWebView2 对象
        Dim coreWebView2 As CoreWebView2 = WebView21.CoreWebView2


        Dim NoNewWindow As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("NoNewWindow", "False")
        If NoNewWindow = "True" Then
            ' 订阅新窗口请求事件
            AddHandler coreWebView2.NewWindowRequested, AddressOf OnNewWindowRequested
        End If

        Dim ThinMenu As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("ThinMenu", "False")
        If ThinMenu = "True" Then
            ' 订阅右键菜单请求事件
            AddHandler coreWebView2.ContextMenuRequested, AddressOf OnContextMenuRequested
        End If

    End Sub
    ' 事件处理程序 - 删除指定菜单项
    Private Sub OnContextMenuRequested(sender As Object, e As CoreWebView2ContextMenuRequestedEventArgs)
        ' 创建一个字符串来收集所有菜单项信息
        Dim menuInfo As String = ""

        ' 遍历所有菜单项
        For Each item In e.MenuItems
            menuInfo &= $"Name: {item.Name}" & vbCrLf
            menuInfo &= $"Label: {item.Label}" & vbCrLf
            menuInfo &= $"Kind: {item.Kind}" & vbCrLf
            menuInfo &= "-------------------" & vbCrLf
        Next

        ' 如果没有菜单项
        If String.IsNullOrEmpty(menuInfo) Then
            menuInfo = "没有找到任何菜单项"
        End If

        ' 用 MessageBox 显示(调试用)
        'MessageBox.Show(menuInfo, "右键菜单项列表")
        ' 获取默认菜单项列表
        Dim menuList As IList(Of CoreWebView2ContextMenuItem) = e.MenuItems

        ' 查找并删除"另存为"菜单项（通常 Name 为 "saveAs"）
        Dim saveAsItem = menuList.FirstOrDefault(Function(x) x.Name = "saveAs")
        If saveAsItem IsNot Nothing Then
            menuList.Remove(saveAsItem)
        End If

        ' 查找并删除"在新窗口中打开"菜单项（通常 Name 为 "openInNewWindow"）
        Dim openInNewWindowItem = menuList.FirstOrDefault(Function(x) x.Name = "openLinkInNewWindow")
        If openInNewWindowItem IsNot Nothing Then
            menuList.Remove(openInNewWindowItem)
        End If

        '复制链接
        Dim CLItem = menuList.FirstOrDefault(Function(x) x.Name = "copyLinkLocation")
        If CLItem IsNot Nothing Then
            menuList.Remove(CLItem)
        End If

        '复制图像
        Dim CIItem = menuList.FirstOrDefault(Function(x) x.Name = "copyImage")
        If CIItem IsNot Nothing Then
            menuList.Remove(CIItem)
        End If

        '复制图像链接
        Dim CILItem = menuList.FirstOrDefault(Function(x) x.Name = "copyImageLocation")
        If CILItem IsNot Nothing Then
            menuList.Remove(CILItem)
        End If

        '链接另存
        Dim SLAItem = menuList.FirstOrDefault(Function(x) x.Name = "saveLinkAs")
        If SLAItem IsNot Nothing Then
            menuList.Remove(SLAItem)
        End If

        '更多
        Dim ShareItem = menuList.FirstOrDefault(Function(x) x.Name = "moreTools")
        If ShareItem IsNot Nothing Then
            menuList.Remove(ShareItem)
        End If

        '复制链接：视频
        Dim VCLItem = menuList.FirstOrDefault(Function(x) x.Name = "copyLink")
        If VCLItem IsNot Nothing Then
            menuList.Remove(VCLItem)
        End If

        '显示所有控件：视频
        Dim SACItem = menuList.FirstOrDefault(Function(x) x.Name = "showAllControls")
        If SACItem IsNot Nothing Then
            menuList.Remove(SACItem)
        End If

        '循环：视频
        Dim LOOPItem = menuList.FirstOrDefault(Function(x) x.Name = "loop")
        If LOOPItem IsNot Nothing Then
            menuList.Remove(LOOPItem)
        End If

        '刷新
        Dim reloadItem = menuList.FirstOrDefault(Function(x) x.Name = "reload")
        If reloadItem IsNot Nothing Then
            menuList.Remove(reloadItem)
        End If

        '打印
        Dim printItem = menuList.FirstOrDefault(Function(x) x.Name = "print")
        If printItem IsNot Nothing Then
            menuList.Remove(printItem)
        End If

        '保存图片
        Dim SAAItem = menuList.FirstOrDefault(Function(x) x.Name = "saveImageAs")
        If SAAItem IsNot Nothing Then
            menuList.Remove(SAAItem)
        End If

        '保存视频
        Dim SVAItem = menuList.FirstOrDefault(Function(x) x.Name = "saveVideoAs")
        If SVAItem IsNot Nothing Then
            menuList.Remove(SVAItem)
        End If

        '其他
        Dim OtherItem = menuList.FirstOrDefault(Function(x) x.Name = "other")
        If OtherItem IsNot Nothing Then
            menuList.Remove(OtherItem)
        End If
    End Sub
End Class
