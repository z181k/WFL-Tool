Imports System.Reflection.Emit
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Loadpga

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

    Public Shared Sub ConsoleShowHelp()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("WFL Tool   版本 17.0.9632.1  x64")
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
        Console.WriteLine("  /kmsui                打开 KMS 激活 UI")
        Console.WriteLine("  /ActiveTool           打开 KMS 激活 UI（和 kmsui 效果一样）")
        Console.WriteLine("  /modsys               打开系统修改页")
        Console.WriteLine("  /SystemModifications  打开系统修改页（和 modsys 效果一样）")
        Console.WriteLine("  /Accessories          打开附件页")
        Console.WriteLine("  /about                打开关于页")
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
            Loadpga.ConsoleShowHelp()
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
            Nform16ConLine.TextBox1.Text = "使用命令行调用本程序即代表你同意本软件的软件许可协议" & vbCrLf & vbCrLf & "用法: WFLToolDark.exe [参数] 或 WFL Tool.exe [参数]" & vbCrLf & vbCrLf & "参数:" & vbCrLf & "  /help                          查询 WFL Tool 命令行参数" & vbCrLf & "  /openie                        打开IE空白页" & vbCrLf & "  /openie [网址]              打开IE，访问指定网址" & vbCrLf & "  /more                          打开更多功能页" & vbCrLf & "  /kmsui                         打开 KMS 激活 UI" & vbCrLf & "  /ActiveTool        打开 KMS 激活 UI（和 modsys 效果一样）" & vbCrLf & "  /modsys                         打开系统修改页" & vbCrLf & "  /SystemModifications  打开系统修改页（和 kmsui 效果一样）" & vbCrLf & "  /Accessories                   打开附件页" & vbCrLf & "  /about                         打开关于页" & vbCrLf & vbCrLf & "示例:" & vbCrLf & "  WFLToolDark.exe /openie https://www.gov.cn"
            Nform16ConLine.Label1.Text = "WFL Tool 命令行参数"
        End If

    End Sub

    Private Sub Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE <> "AMD64" Then
            MsgBox("此版本仅为 x64 架构处理器提供，我们没有提供 arm64 基于架构的版本，请关注我们的网站，我们可能会在将来提供基于 arm64 的 WFL Tool。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '判断兼容性，拒绝在非x64版本运行
        End If
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 10240 Then              '检查版本控制应用启动
            MsgBox("WFL Tool 仅支持 Windows 10 及以上版本 x64 架构 Windows 系统，请升级你的操作系统。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '拒绝在比Windows 8.1更低版本系统的X64版本上运行
        End If


        ' 获取命令行参数（包括程序路径）
        Dim args As String() = Environment.GetCommandLineArgs()

        Dim conline1 As String = If(args.Length >= 2, args(1), "")
        Dim conline2 As String = If(args.Length >= 3, args(2), "")

        If Not String.IsNullOrEmpty(conline1) Then
            If conline1 = "/openie" Or conline1 = "/OPENIE" Or conline1 = "/OpenIE" Then
                Dim ie11 As Object = CreateObject("InternetExplorer.Application")
                ie11.Visible = True            '打开ie
                If Not String.IsNullOrEmpty(conline2) Then
                    ie11.Navigate(conline2)
                End If
                End
            ElseIf conline1 = "/help" Or conline1 = "/?" Or conline1 = "/？" Or conline1 = "/HELP" Or conline1 = "/Help" Then
                Loadpga.ShowHelpAndExit()
                Close()
                Exit Sub
            ElseIf conline1 = "/more" Or conline1 = "/MORE" Or conline1 = "/More" Then
                Form2.Show()
                Form2.打开主页ToolStripMenuItem.Enabled = False
                Form2.返回主界面.Visible = False                     '显示更多
                Form2.快捷键返回BToolStripMenuItem.Enabled = False
                Close()
                Exit Sub
            ElseIf conline1 = "/kmsui" Or conline1 = "/KMSUI" Or conline1 = "/KmsUI" Or conline1 = "/ActiveTool" Or conline1 = "/activetool" Or conline1 = "/ACTIVETOOL" Then
                Form10.Show()
                Form10.打开主界面ToolStripMenuItem.Enabled = False   '激活工具
                Close()
                Exit Sub
            ElseIf conline1 = "/SystemModifications" Or conline1 = "/systemmodifications" Or conline1 = "/SYSTEMMODIFICATIONS" Or conline1 = "/MODSYS" Or conline1 = "/ModSys" Or conline1 = "/modsys" Then
                Form7.Show()
                Form7.返回主界面ToolStripMenuItem.Visible = False    '系统修改
                Form7.ToolStripMenuItem1.Visible = False
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
                Form9.Show()
                Close()
                Exit Sub
            End If
        End If


        On Error GoTo 1
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