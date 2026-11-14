using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>替代旧版 Form8：彻底关闭 UAC 前的风险确认。</summary>
public static class UacWarningDialog
{
    public static async void Show()
    {
        var confirmed = await DialogService.ConfirmAsync(
            "用户账户控制",
            "彻底关闭 UAC 会使计算机暴露在风险中，确定继续?\n\n修改后重启生效，若要重新打开，请选择“更改弹出设置”选项或到控制面板设置。",
            primaryText: "继续",
            closeText: "算了吧",
            danger: true);

        if (confirmed)
        {
            Launcher.AddHklmDword(
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System",
                "EnableLUA", 0);
        }
    }
}
