using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>替代旧版 Form15：开机启动项目的添加与管理。</summary>
public static class StartupDialog
{
    public static async void Show()
    {
        var result = await DialogService.ShowAsync(
            "设置开机启动项目",
            "选择你想要设置的项目：\n\n" +
            "· 添加开机启动项目：将文件或快捷方式拖入打开的启动文件夹\n" +
            "· 开启 / 关闭开机启动项目：Windows 11 打开“设置 - 启动应用”，旧版 Windows 打开任务管理器启动选项卡",
            primaryText: "添加开机启动项目",
            secondaryText: "开启 / 关闭开机启动项目",
            closeText: "取消");

        if (result == ContentDialogResult.Primary)
        {
            await DialogService.ShowInfoAsync("添加开机启动项目", "将文件或快捷方式拖入打开的文件夹即可。");
            Launcher.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp");
        }
        else if (result == ContentDialogResult.Secondary)
        {
            if (SystemInfo.CurrentBuild >= 22621)
            {
                Launcher.OpenSettings("ms-settings:startupapps");
            }
            else
            {
                Launcher.Start(Path.Combine(Launcher.System32, "taskmgr.exe"), "/7 /Startup");
            }
        }
    }
}
