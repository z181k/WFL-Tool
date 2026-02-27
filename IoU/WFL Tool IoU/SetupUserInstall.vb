Imports System.ComponentModel

Public Class SetupUserInstall



    Private Sub SetupUserInstall_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub SetupUserInstall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '低分辨率设备兼容代码
        PictureBox2.Height = PictureBox2.Width
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        If ScreenHeight < 1080 Then
            Label7.Location = Label7.Location - New Size(3, 0)
        End If
    End Sub
End Class