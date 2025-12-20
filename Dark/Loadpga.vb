Public Class Loadpga
    Private Sub Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PROCESSOR_ARCHITECTURE As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment", "PROCESSOR_ARCHITECTURE", Nothing)
        If PROCESSOR_ARCHITECTURE <> "AMD64" Then
            MsgBox("此版本仅为 x64 架构处理器提供，我们没有提供 arm64 基于架构的版本，请关注我们的网站，我们可能会在将来提供基于 arm64 的 WFL Tool。", MsgBoxStyle.Critical, "WFL Tool")
            End
            '判断兼容性，拒绝在非x64版本运行
        End If
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 10240 Then              '检查版本控制应用启动
            MsgBox("WFL Tool 仅支持 Windows 10 及以上版本 x64 架构 Windows 系统，请升级你的操作系统。", 0, "WFL Tool without Dark Theme")
            End
            '拒绝在比Windows 8.1更低版本系统的X64版本上运行
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
        Dim NF1 As New Form1()
        NF1.Show()
        Close()
1:
    End Sub

    Private Sub Loadpga_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class