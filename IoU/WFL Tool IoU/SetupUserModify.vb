Public Class SetupUserModify
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("设置仅对当前安装的当前版本有效，更新或重新安装应用时会自动将此处的设置重置为默认值。"， vbInformation, "更改 WFL Tool (x64) 的安装")
    End Sub
End Class