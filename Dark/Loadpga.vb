Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Loadpga

    <DllImport("user32.dll")>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)     ' 置顶
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)   ' 取消置顶
    Private Shared ReadOnly HWND_TOP As New IntPtr(0)          ' 放在顶层但不置顶
    Private Shared ReadOnly HWND_BOTTOM As New IntPtr(1)       ' 放在底层
    Private Const SWP_NOSIZE As UInteger = &H1
    Private Const SWP_NOMOVE As UInteger = &H2
    Private Const SWP_SHOWWINDOW As UInteger = &H40


    Dim asc As AutoSizeFormClass = New AutoSizeFormClass()
    Dim SizeChangeFlg As Boolean = False '首次加载窗体会误触发SizeChange,容易报错

    <DllImport("kernel32.dll")>
    Private Shared Function AttachConsole(ByVal dwProcessId As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function AllocConsole() As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function FreeConsole() As Boolean
    End Function

    <DllImport("kernel32.dll")>
    Private Shared Function GetLastError() As Integer
    End Function

    Private Const ATTACH_PARENT_PROCESS As Integer = -1

    Public Shared Sub ConsoleShowHelp(currentMe As Loadpga)
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("WFL Tool   版本 " + currentMe.Ver.Text + "." + currentMe.Build.Text + "  x64")
        Console.WriteLine()
        Console.WriteLine("使用命令行调用本程序即代表你同意本软件的软件许可协议")
        Console.WriteLine()
        Console.WriteLine("用法: WFLToolDark.exe [参数] 或 WFL Tool.exe [参数]")
        Console.WriteLine()
        Console.WriteLine("参数:")
        Console.WriteLine("  /help                 查询 WFL Tool 命令行参数")
        Console.WriteLine("  /openie               打开IE空白页")
        Console.WriteLine("  /openie [网址]        打开IE，访问指定网址")
        Console.WriteLine("  /more                 打开更多功能页")
        Console.WriteLine("  /more msdt            打开 MSDT 页")
        Console.WriteLine("  /more nomsdt          打开更多功能页但屏蔽 MSDT 选项")
        Console.WriteLine("  /kmsui                打开 KMS 激活 UI")
        Console.WriteLine("  /ActiveTool           打开 KMS 激活 UI（和 kmsui 效果一样）")
        Console.WriteLine("  /modsys               打开系统修改页")
        Console.WriteLine("  /SystemModifications  打开系统修改页（和 modsys 效果一样）")
        Console.WriteLine("  /Accessories          打开附件页")
        Console.WriteLine("  /about                打开关于页")
        Console.WriteLine("  /about eula           显示软件许可协议")
        Console.WriteLine("  /run                  打开带 WFL Tool 字样的运行对话框")
        Console.WriteLine("  /run ori              打开运行对话框")
        Console.WriteLine()
        Console.WriteLine("不带任何参数或参数错误则以正常方式打开程序")
        Console.WriteLine()
        Console.WriteLine("示例：")
        Console.WriteLine("  WFLToolDark.exe /openie https://www.gov.cn")
        Console.WriteLine()
        Console.WriteLine("从控制台程序和 gui 程序调用 /help 提供的内容会有差别")
        Console.WriteLine()
        Console.WriteLine("按 Enter 以退出程序/返回控制台...")

        Environment.Exit(0)
    End Sub

    Public Shared Sub ShowHelpAndExit()

        If AttachConsole(ATTACH_PARENT_PROCESS) Then
            ' 输出内容到控制台
            Dim myLoadpga As New Loadpga()
            Loadpga.ConsoleShowHelp(myLoadpga)
            'Console.WriteLine("=" & StrDup(50, "="))

            ' 可选：等待按键（注意：这会阻塞控制台输入）
            ' Console.WriteLine("按任意键继续...")
            ' Console.ReadKey()

            ' 分离控制台（可选，程序退出时会自动分离）
            'FreeConsole()

        Else
            ' 无法附加到父进程控制台（可能不是从控制台启动）
            Dim Nform16ConLine As New Form16
            Nform16ConLine.Show()
            Nform16ConLine.TextBox1.Text = "使用命令行调用本程序即代表你同意本软件的软件许可协议" & vbCrLf & vbCrLf & "用法: WFLToolDark.exe [参数] 或 WFL Tool.exe [参数]" & vbCrLf & vbCrLf & "参数:" & vbCrLf & "  /help                          查询 WFL Tool 命令行参数" & vbCrLf & "  /openie                        打开IE空白页" & vbCrLf & "  /openie [网址]              打开IE，访问指定网址" & vbCrLf & "  /more                          打开更多功能页" & vbCrLf & "  /more msdt              打开 MSDT 页" & vbCrLf & "  /more nomsdt      打开更多功能页但屏蔽 MSDT 选项" & vbCrLf & "  /kmsui                         打开 KMS 激活 UI" & vbCrLf & "  /ActiveTool        打开 KMS 激活 UI（和 kmsui 效果一样）" & vbCrLf & "  /modsys                         打开系统修改页" & vbCrLf & "  /SystemModifications  打开系统修改页（和 kmsui 效果一样）" & vbCrLf & "  /Accessories                   打开附件页" & vbCrLf & "  /about                         打开关于页" & vbCrLf & "  /about eula         显示软件许可协议" & vbCrLf & "  /run         打开带 WFL Tool 字样的运行对话框" & vbCrLf & "  /run ori              打开运行对话框" & vbCrLf & vbCrLf & "示例:" & vbCrLf & "  WFLToolDark.exe /openie https://www.gov.cn"
            Nform16ConLine.Label1.Text = "WFL Tool 命令行参数"
        End If


        '=================================================================================
        '上方代码由AI和人工共同编写，并非完全AIGC
        '=================================================================================
    End Sub

    Private Sub Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE <> "AMD64" Then
            MsgBox("此版本仅为 x64 架构处理器提供，我们没有提供 arm64 基于架构的版本，请关注我们的网站，我们可能会在将来提供基于 arm64 的 WFL Tool。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '判断兼容性，拒绝在非x64版本运行
        End If
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 10586 Then              '检查版本控制应用启动
            MsgBox("WFL Tool 仅支持 Windows 10 1511 及以上版本 x64 架构 Windows 系统，请升级你的操作系统。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '拒绝在比Windows 8.1更低版本系统的X64版本上运行
        End If

        '==========================分隔============================下面代码有AI参与==================================

        ' 获取命令行参数（包括程序路径）
        Dim args As String() = Environment.GetCommandLineArgs()

        Dim conline1 As String = If(args.Length >= 2, args(1), "")
        Dim conline2 As String = If(args.Length >= 3, args(2), "")

        If Not String.IsNullOrEmpty(conline1) Then
            If conline1 = "/openie" Or conline1 = "/OPENIE" Or conline1 = "/OpenIE" Then
                Try
                    Dim ie11 As Object = CreateObject("InternetExplorer.Application")
                    ie11.Visible = True            '打开ie
                    If Not String.IsNullOrEmpty(conline2) Then
                        ie11.Navigate(conline2)
                    End If
                Catch ex As System.Exception When ex.Message.Contains("Cannot create ActiveX component")
                    '生成随机数，随机延迟后再启动，避免冲突
                    Dim random1 As New Random()
                    Dim randomNumber As Integer = random1.Next(500, 5001) ' 注意：上界是5001才包含5000
                    Thread.Sleep(randomNumber)
                    '
                    Dim ie11next As Object = CreateObject("InternetExplorer.Application")
                    ie11next.Visible = True            '打开ie
                    If Not String.IsNullOrEmpty(conline2) Then
                        ie11next.Navigate(conline2)
                    End If
                End Try
                End
            ElseIf conline1 = "/help" Or conline1 = "/?" Or conline1 = "/？" Or conline1 = "/HELP" Or conline1 = "/Help" Then
                Loadpga.ShowHelpAndExit()
                Close()
                Exit Sub
            ElseIf conline1 = "/more" Or conline1 = "/MORE" Or conline1 = "/More" Then
                If conline2 = "msdt" Or conline2 = "MSDT" Then
                    Form14.Show()
                    Form14.快捷键返回BToolStripMenuItem.Enabled = False
                    Form14.返回更多功能.Visible = False                     '显示MSDT
                    Form14.快捷键返回BToolStripMenuItem.Enabled = False
                    Form14.FeatureControlLabel1.Text = "ConMSDT"
                ElseIf conline2 = "NOMSDT" Or conline2 = "nomsdt" Or conline2 = "NoMSDT" Then
                    Form2.Show()
                    Form2.打开主页ToolStripMenuItem.Enabled = False
                    Form2.返回主界面.Visible = False                     '显示更多 - 无msdt
                    Form2.快捷键返回BToolStripMenuItem.Enabled = False
                    Form2.Button14.Enabled = False
                    Form2.FeatureControlLabel1.Text = "ConNoMSDT"
                Else
                    Form2.Show()
                    Form2.打开主页ToolStripMenuItem.Enabled = False
                    Form2.返回主界面.Visible = False                     '显示更多
                    Form2.快捷键返回BToolStripMenuItem.Enabled = False
                    Form2.FeatureControlLabel1.Text = "ConAll"
                End If
                Close()
                Exit Sub
            ElseIf conline1 = "/kmsui" Or conline1 = "/KMSUI" Or conline1 = "/KmsUI" Or conline1 = "/ActiveTool" Or conline1 = "/activetool" Or conline1 = "/ACTIVETOOL" Then
                Form10.Show()
                Form10.打开主界面ToolStripMenuItem.Enabled = False   '激活工具
                Close()
                Exit Sub
            ElseIf conline1 = "/SystemModifications" Or conline1 = "/systemmodifications" Or conline1 = "/SYSTEMMODIFICATIONS" Or conline1 = "/MODSYS" Or conline1 = "/ModSys" Or conline1 = "/modsys" Then
                If NewUI.Text = "NSetMod" Then

                ElseIf NewUI.Text = "NMod" Then

                Else
                    Form7.Show()
                    Form7.返回主界面ToolStripMenuItem.Visible = False    '系统修改
                    Form7.ToolStripMenuItem1.Visible = False
                End If
                '
                Close()
                Exit Sub
            ElseIf conline1 = "/Sets" Or conline1 = "/SETS" Or conline1 = "/sets" Then
                If NewUI.Text = "NSetMod" Then
                    NewSets.Show()
                ElseIf NewUI.Text = "NSets" Then
                    NewSets.Show()
                Else
                    Dim f1 As New Form1
                    f1.Show()
                End If
                '
                Close()
                Exit Sub
            ElseIf conline1 = "/Accessories" Or conline1 = "/accessories" Or conline1 = "/ACCESSORIES" Then
                Form5.Show()
                Form5.打开主页ToolStripMenuItem.Enabled = False
                Form5.返回主界面.Visible = False                     '附件
                Form5.快捷键返回BToolStripMenuItem.Enabled = False
                Close()
                Exit Sub
            ElseIf conline1 = "/About" Or conline1 = "/ABOUT" Or conline1 = "/about" Then
                If conline2 = "EULA" Or conline2 = "eula" Then
                    Dim NF12 As New Form12()
                    NF12.Show()
                    NF12.Button3.Visible = True
                    NF12.Button1.Visible = False         '协议及调整协议界面
                    NF12.Button2.Visible = False
                    NF12.Label1.Visible = False
                Else
                    Form9.Show()
                    Form9.打开主界面ToolStripMenuItem.Visible = False
                    Form9.ToolStripMenuItem1.Visible = False
                    Form9.Label3.Text = "版本 " + Ver.Text
                    Form9.Label4.Text = "Build " + Build.Text
                    Form9.Beta.Text = Beta.Text
                End If
                Close()
                Exit Sub
            ElseIf conline1 = "/Run" Or conline1 = "/RUN" Or conline1 = "/run" Then
                If conline2 = "ori" Or conline2 = "ORI" Then
                    RunFileDialog.ShowRunDialog(Me, "", "运行", "Windows 将根据你所输入的名称,为你打开相应的程序、文件夹、文档或 Internet 资源。")
                Else
                    RunFileDialog.ShowRunDialog(Me, "", "运行  -  WFL Tool", "WFL Tool 将根据你所输入的名称,为你打开相应的程序、文件夹、文档、Internet 资源以及 Intranet 资源。")
                End If
                End
            ElseIf conline1 = "devinfo" And conline2 = "xscpcl" Then
                MsgBox(Ver.Text + "，" + Beta.Text + "，" + NewUI.Text + "，" + Build.Text, 0, "配置的 WFL Tool 产品策略")
                End
            End If
        End If


        '=================================================================================
        '上方代码由AI和人工共同编写，并非完全AIGC
        '=================================================================================

        Dim WinAppSdkUi As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "WinAppSdkUi", Nothing)
        If WinAppSdkUi = "1" And CurrentBuild < 17763 Then
            Shell("reg.exe delete ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v WinAppSdkUi /f", AppWinStyle.Hide, True, -1)
        End If
        Dim NColor As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "NColor", Nothing)
        If CurrentBuild < 19041 Then              '检查版本控制应用启动颜色
            Application.SetColorMode(SystemColorMode.Classic)
        Else
            If NColor = "White" Then
                Application.SetColorMode(SystemColorMode.Classic)
            ElseIf NColor = "Dark" Then
                Application.SetColorMode(SystemColorMode.Dark)
            Else
                Application.SetColorMode(SystemColorMode.System)
            End If
        End If
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ScreenHeigh As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenWidth < 800 Or ScreenHeigh < 600 Then
            MsgBox("请在 800x600 或更高分辨率下运行！", MsgBoxStyle.Critical, "WFL Tool")
            Application.Exit()
            Exit Sub
        End If
1:
        Dim NF1 As New Form1()
        NF1.Show()
        Close()
    End Sub

    Private Sub Loadpga_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class


'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
'==================================================================================================================================================================================================
'——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————————


'下面是调用位于shell32.dll的运行函数
'该部分代码代码由 DeepSeek 生成，是 AIGC 内容
Public Class RunFileDialogInLoadpga
    ' ============================================
    ' Windows API 常量声明
    ' ============================================
    Private Shared Sub RunFileDlg_Ordinal(
        ByVal hwndOwner As IntPtr,
        ByVal hIcon As IntPtr,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrDirectory As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrTitle As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal lpstrDescription As String,
        ByVal uFlags As UInteger
    )
    End Sub

    Public Class RunFileDlgFlags
        Public Const RFF_NOBROWSE As UInteger = &H1           ' 移除"浏览"按钮
        Public Const RFF_NODEFAULT As UInteger = &H2          ' 没有默认项
        Public Const RFF_CALCDIRECTORY As UInteger = &H4      ' 基于lpstrDirectory计算目录
        Public Const RFF_NOLABEL As UInteger = &H8            ' 移除"打开"标签
        Public Const RFF_NOSEPARATEMEM As UInteger = &H20     ' 不单独记忆
    End Class

    Public Shared Sub ShowRunDialog(
        Optional ByVal owner As IWin32Window = Nothing,
        Optional ByVal defaultDirectory As String = Nothing,
        Optional ByVal title As String = "运行",
        Optional ByVal description As String = "输入程序、文件夹、文档或 Internet 资源名称，我们将为您打开它。",
        Optional ByVal showBrowseButton As Boolean = True
    )
        Dim hwnd As IntPtr = IntPtr.Zero
        If owner IsNot Nothing Then
            hwnd = owner.Handle
        End If

        Dim flags As UInteger = 0
        If Not showBrowseButton Then
            flags = flags Or RunFileDlgFlags.RFF_NOBROWSE
        End If

        Try
            RunFileDlg_Ordinal(hwnd, IntPtr.Zero, defaultDirectory, title, description, flags)
        Catch ex As Exception
        End Try
    End Sub
End Class
