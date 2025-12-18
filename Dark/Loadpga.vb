Public Class Loadpga
    Private Sub Load_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo 1
        Dim NColor As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\DBT\WFL Tool", "NColor", Nothing)
        Dim CurrentBuild As Integer = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", Nothing)
        If CurrentBuild < 9600 Then              '检查版本控制应用启动
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