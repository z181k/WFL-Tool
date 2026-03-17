Imports Microsoft.Win32

Public Class EWV2launcher
    Private Sub EWV2launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim OpenAge As Int64 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("OpenAge", "1")
            '            写入启动数
            Try
                ' 写入 
                If OpenAge >= 9223372036854775806 Then
                    OpenAge = 0
                End If
                Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WebPageViewer")
                    ' 写入整数值
                    key.SetValue("OpenAge", OpenAge + 1, RegistryValueKind.QWord)
                End Using
            Finally
            End Try
        Catch ex As Exception
            '            写入基本注册表
            ' 写入 
            Using key As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\DBT\WebPageViewer")
                ' 写入整数值
                key.SetValue("OpenAge", 1, RegistryValueKind.QWord)
            End Using

        End Try
        EWV2webpage.Show()
        Close()
    End Sub

    Private Sub EWV2launcher_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class