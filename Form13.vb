Public Class Form13

    Private Sub 退出程序ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出程序ToolStripMenuItem.Click
        NotifyIcon1.Visible = False
        Application.Exit()
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Form1.Show()
    End Sub

    Private Sub 退出通知栏ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出通知栏ToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub Form13_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Form1.Show()
    End Sub

End Class