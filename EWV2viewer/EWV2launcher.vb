Public Class EWV2launcher
    Private Sub EWV2launcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
defaultstart:
        On Error GoTo no3info2
        Dim EWV2webpageShow As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WebPageViewer", True).GetValue("EWV2webpageShow", "nothing")
        If EWV2webpageShow = "True" Then
            EWV2webpage.Show()
            Close()
            Exit Sub
        End If
no3info2:
        MsgBox("此应用暂不能使用。", MsgBoxStyle.Exclamation, "WFL Tool WebPageViewer")
        Close()
    End Sub

    Private Sub EWV2launcher_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class