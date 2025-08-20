Public Class Form12
    Private Sub Form12_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "请仔细阅读本协议。若安装或使用本软件之全部或其任何部分,就等于接受本协议内之所有条款。" & vbCrLf & "本软件所含文字材料和软件程序以及附属文件受到世界范围内的版权法保护。" & vbCrLf & "" & vbCrLf & "1.特许使用" & vbCrLf & "董博涛及其团队(以下简称""我们"")授于在一台计算机(依据协议的具体系统要求)上使用本软件的非专有不可转让的权利。" & vbCrLf & "" & vbCrLf & "2.软件的使用" & vbCrLf & "2.1在无损任何法定权利下及除本协议允许的权利外,不得修改、改编、分发、传输、转让、出版、复制或更改软件及其附属文件。" & vbCrLf & "2.2鉴于盗版使用本软件会对我们造成损害,在本协议有效期内及终止后,必尽一切努力确保软件和附属文件的安全。本软件的正版以我们签署的数字签名并且从官方渠道下载为准。" & vbCrLf & "" & vbCrLf & "3.终止" & vbCrLf & "任何时候毁掉软件及附属文件即是对本协议的终止。若违反任何条款,本协议亦将终止" & vbCrLf & "" & vbCrLf & "4.保证" & vbCrLf & "4.1我们不保证本软件不会出现损坏您的数据的情况。" & vbCrLf & "4.2以上保证取代其他明示或默示的保证和陈述,特别但不仅限于：" & vbCrLf & "4.2.1我们未做出处上方内容之外关于本软件适用于任何目的或可在任何条件下使用的保证或陈述,即使该目的或条件可能为我们所知" & vbCrLf & "4.2.2我们不为软件的滥用和恶意使用承担任何责任;" & vbCrLf & "4.2.3我们不保证软件运行不中断或无差错。" & vbCrLf & "4.2.4我们不为软件的运算和技术缺陷承担任何的责任" & vbCrLf & "" & vbCrLf & "5.责任的有限性" & vbCrLf & "5.1我们的全部责任和对客户的唯一补救方法是提供正版软件并尝试恢复您的数据(可能会失败及损坏更多数据)；" & vbCrLf & "5.2我们在任何情况下都不对任何因使用或无能力使用本软件及附属文件造成的损害负责(包括但不仅限于使用者死亡、人身伤害、数据丢失业务提失、收入亏损、声誉损失或其他任何相应损害)。" & vbCrLf & "5.3我们提供的第三方网址仅供查阅,我们不对第三方网站的任何内容负责，虽然他们可能承担了一些重要功能并且在本应用提供的窗口打开(所有在本应用提供的窗口打开的第三方功能：检查更新、更新本程序、获取帮助(窗口标题为““WFL Tool 帮助””)" & vbCrLf & "" & vbCrLf & "6.隐私权" & vbCrLf & "本软件收集和产生的所有数据（可能包括隐私信息）均不会上传，不会共享。但应用所需的运行库所产生的数据请遵守相关条款" & vbCrLf & "" & vbCrLf & "7.管辖法律" & vbCrLf & "本协议受中国内地法律管据,中国内地法院拥有司法权。我们有权更新协议后不通知您，因此请定期查看协议的最新版本，如您无法接受，请立刻停止使用本软件"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v License /T REG_SZ /d 5 /f", AppWinStyle.Hide, True, -1)
        Form1.Show()
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form11.Show()
        'Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v License /T REG_SZ /d 无 /f", AppWinStyle.Hide, True, -1)
        'End
    End Sub
End Class