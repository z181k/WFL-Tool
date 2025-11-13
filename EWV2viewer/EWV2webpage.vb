
Option Explicit On
Imports System.Windows.Forms

Public Class EWV2webpage
    Dim asc As AutoSizeFormClass = New AutoSizeFormClass()
    Dim SizeChangeFlg As Boolean = False '首次加载窗体会误触发SizeChange,容易报错
    Private Sub HelpEWV2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        asc.ControllInitializeSize(Me) '记录控件初始位置&大小
        SizeChangeFlg = True '允许触发SizeChange
        'Size = New Size(900, 550) '调整窗口大小

        '下方代码为根据注册表信息调整网页界面内容代码
        '显示图标
        Dim EWV2webpageSicon As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EWV2webpageShowIcon", "True")
        If EWV2webpageSicon = "False" Then
            Me.ShowIcon = False
        End If
        '标题
        Dim EWV2webpageTitle As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EWV2webpageTitle", "WFL Tool 帮助")
        Me.Text = EWV2webpageTitle
        'url地址
        Dim EWV2webpageURL As String = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\DBT\WFL Tool", True).GetValue("EWV2webpageURL", "https://kdocs.cn/l/sqxx3d4vumUT")
        WebView21.Source = New Uri(EWV2webpageURL)
        '清理信息
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShow /T REG_SZ /d 6 /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageShowIcon /T REG_SZ /d True /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageTitle /T REG_SZ /d default /f", AppWinStyle.Hide, True, -1)
        Shell("reg.exe add ""HKEY_CURRENT_USER\Software\DBT\WFL Tool"" /v EWV2webpageURL /T REG_SZ /d ""https://liulanmi.com/core"" /f", AppWinStyle.Hide, True, -1)
    End Sub
    Private Sub HelpEWV2_sizechange(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SizeChanged
        If SizeChangeFlg Then
            asc.ControlAutoSize(Me)
        End If
        'Button5.Text = Me.Width & ":" & Me.Height '利用控件名称显示的窗体大小，可删
    End Sub

End Class
Partial Class AutoSizeFormClass
    Public Structure ControlRect
        Public Name As String '控件名称其实没必要，只是调试时用，可删
        Public Left As Integer
        Public Top As Integer
        Public Width As Integer
        Public Height As Integer
    End Structure

    Public OldCtrl As List(Of ControlRect) = New List(Of ControlRect)()
    Dim CtrlNo As Integer = 0
    Public Sub ControllInitializeSize(ByVal mForm As Control)
        Dim Cr As ControlRect
        Cr.Name = mForm.Name
        Cr.Left = mForm.Left
        Cr.Top = mForm.Top
        Cr.Width = mForm.Width
        Cr.Height = mForm.Height
        OldCtrl.Add(Cr)
        AddControl(mForm)
    End Sub
    Private Sub AddControl(ByVal Ctl As Control)
        For Each c As Control In Ctl.Controls
            Dim ObjCtrl As ControlRect
            ObjCtrl.Name = c.Name
            ObjCtrl.Left = c.Left
            ObjCtrl.Top = c.Top
            ObjCtrl.Width = c.Width
            ObjCtrl.Height = c.Height
            OldCtrl.Add(ObjCtrl)
            If c.Controls.Count > 0 Then
                AddControl(c)
            End If
        Next
    End Sub
    Public Sub ControlAutoSize(ByVal mForm As Control)
        If CtrlNo = 0 Then
            Dim Cr As ControlRect
            Cr.Name = mForm.Name
            Cr.Left = 0
            Cr.Top = 0
            Cr.Width = mForm.PreferredSize.Width
            Cr.Height = mForm.PreferredSize.Height
            OldCtrl.Add(Cr)
            AddControl(mForm)
        End If
        Dim WScale As Single
        WScale = CSng(mForm.Width) / CSng(OldCtrl(0).Width)
        'HelpEWV2.Button3.Text = WScale '利用控件名称显示的窗体大小，可删
        Dim HScale As Single
        HScale = CSng(mForm.Height) / CSng(OldCtrl(0).Height)
        'HelpEWV2.Button4.Text = WScale '利用控件名称显示的窗体大小，可删
        CtrlNo = 1
        AutoScaleControl(mForm, WScale, HScale)

    End Sub
    Private Sub AutoScaleControl(ByVal ctl As Control, ByVal wScale As Single, ByVal hScale As Single)
        Dim ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0 As Integer

        For Each c As Control In ctl.Controls
            ctrLeft0 = OldCtrl(CtrlNo).Left
            ctrTop0 = OldCtrl(CtrlNo).Top
            ctrWidth0 = OldCtrl(CtrlNo).Width
            ctrHeight0 = OldCtrl(CtrlNo).Height

            c.Left = CInt(ctrLeft0 * wScale)
            c.Top = CInt(ctrTop0 * hScale)
            c.Width = CInt(ctrWidth0 * wScale)
            c.Height = CInt(ctrHeight0 * hScale)
            CtrlNo += 1
            If c.Controls.Count > 0 Then
                AutoScaleControl(c, wScale, hScale)
            End If
            '以下代码用于实现表格内各单元格按比例缩放，其实没什么必要，因为DataGridView本身有很好的适应能力
            '任何缩放状态下都可以保证数值显示正常，反而更好，如果行列按窗体缩放比例小到看不清值，有些适得其反
            '（纯属从个人习惯出发的见解）
            'If ctl.GetType.Name Like ("DataGridView") Then
            '    Dim Dgv As DataGridView
            '    Dgv = ctl
            '    Cursor.Current = Cursors.WaitCursor
            '    Dim widths As Integer = 0
            '    For i As Integer = 0 To Dgv.Columns.Count
            '        If i > 0 Then
            '            Dgv.AutoResizeColumn(i - 1, DataGridViewAutoSizeColumnMode.AllCells)
            '            'widths += Dgv.Columns(i - 1).Width
            '        End If
            '    Next
            '    If widths >= Dgv.Size.Width Then
            '        Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            '    Else
            '        Dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            '    End If
            '    Cursor.Current = Cursors.Default
            'End If
        Next

    End Sub


End Class
