using Microsoft.UI.Xaml.Controls;
using WFLTool;

namespace WFLTool.Core;

/// <summary>系统修改页的注册表操作（对应旧版 Form7 各按钮）。</summary>
public static class SystemActions
{
    public static async void Run(string tag)
    {
        try
        {
            await RunAsync(tag);
        }
        catch
        {
        }
    }

    private static async Task RunAsync(string tag)
    {
        const string taskband = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Taskband";
        const string themes = @"Software\Microsoft\Windows\CurrentVersion\Themes";
        const string explorerPolicies = @"SOFTWARE\Policies\Microsoft\Windows\Explorer";
        const string desk = @"Control Panel\Desktop";

        switch (tag)
        {
            // ---------------------------------------------------------- 任务栏缩略图
            case "thumb-small":
                Launcher.SetHkcuDword(taskband, "MaxThumbSizePx", 86);
                break;
            case "thumb-medium":
                Launcher.DeleteHkcuValue(taskband, "MaxThumbSizePx");
                break;
            case "thumb-large":
                Launcher.SetHkcuDword(taskband, "MaxThumbSizePx", 0x12c);
                break;
            case "thumb-off":
                Launcher.SetHkcuDword(taskband, "MaxThumbSizePx", 1);
                break;

            // ---------------------------------------------------------- UAC
            case "uac-settings":
                Launcher.Start("UserAccountControlSettings.exe");
                break;
            case "uac-disable":
                UacWarningDialog.Show();
                break;

            // ---------------------------------------------------------- 登录信息
            case "login-detailed":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "VerboseStatus", 1);
                break;
            case "login-welcome":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "VerboseStatus", 0);
                break;

            // ---------------------------------------------------------- 桌面水印
            case "watermark-show":
                Launcher.SetHkcuDword(desk, "PaintDesktopVersion", 1);
                break;
            case "watermark-hide":
                Launcher.SetHkcuDword(desk, "PaintDesktopVersion", 0);
                break;

            // ---------------------------------------------------------- 通知
            case "notif-balloon":
                Launcher.SetHkcuDword(explorerPolicies, "EnableLegacyBalloonNotifications", 1);
                break;
            case "notif-center":
                Launcher.SetHkcuDword(explorerPolicies, "EnableLegacyBalloonNotifications", 0);
                break;

            // ---------------------------------------------------------- 音量 / 电池
            case "volume-win7":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\MTCUVC", "EnableMtcUvc", 0);
                break;
            case "volume-win10":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\MTCUVC", "EnableMtcUvc", 1);
                break;
            case "battery-win7":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell", "UseWin32BatteryFlyout", 1);
                break;
            case "battery-win10":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\ImmersiveShell", "UseWin32BatteryFlyout", 0);
                break;

            // ---------------------------------------------------------- 鼠标指针主题
            case "cursor-allow":
                Launcher.SetHkcuDword(themes, "ThemeChangesMousePointers", 1);
                break;
            case "cursor-deny":
                Launcher.SetHkcuDword(themes, "ThemeChangesMousePointers", 0);
                break;

            // ---------------------------------------------------------- 网络面板
            case "network-default":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network", "ReplaceVan", 0);
                break;
            case "network-win8":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network", "ReplaceVan", 2);
                break;
            case "network-settings":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Control Panel\Settings\Network", "ReplaceVan", 1);
                break;

            // ---------------------------------------------------------- MMC DPI
            case "mmc-default":
                Launcher.RunReg(@"delete ""HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"" /v ""C:\Windows\System32\mmc.exe"" /f");
                break;
            case "mmc-highdpi":
                Launcher.RunReg(@"add ""HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers"" /v ""C:\Windows\System32\mmc.exe"" /t REG_SZ /d ""~ HIGHDPIAWARE"" /f");
                break;

            // ---------------------------------------------------------- 打印
            case "print-new":
                Launcher.RunReg(@"delete HKEY_CURRENT_USER\SOFTWARE\Microsoft\Print\UnifiedPrintDialog /v PreferLegacyPrintDialog /f");
                break;
            case "print-legacy":
                Launcher.SetHkcuDword(@"SOFTWARE\Microsoft\Print\UnifiedPrintDialog", "PreferLegacyPrintDialog", 1);
                break;

            // ---------------------------------------------------------- 登录模糊
            case "logon-blur":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "DisableAcrylicBackgroundOnLogon", 0);
                break;
            case "logon-noblur":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\System", "DisableAcrylicBackgroundOnLogon", 1);
                break;

            // ---------------------------------------------------------- netplwiz
            case "netplwiz-all":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device", "DevicePasswordLessBuildVersion", 0);
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\wow6432node\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device", "DevicePasswordLessBuildVersion", 0);
                break;
            case "netplwiz-hide":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device", "DevicePasswordLessBuildVersion", 2);
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\wow6432node\Microsoft\Windows NT\CurrentVersion\PasswordLess\Device", "DevicePasswordLessBuildVersion", 2);
                break;

            // ---------------------------------------------------------- 资源管理器
            case "ctx-classic":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\FlightedFeatures", "ImmersiveContextMenu", 0);
                break;
            case "ctx-dark":
                Launcher.AddHklmDword(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\FlightedFeatures", "ImmersiveContextMenu", 1);
                break;
            case "win11-menu-win32":
                Launcher.SetHkcuDefault(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32", "");
                break;
            case "win11-menu-xaml":
                Launcher.DeleteHkcuKey(@"Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
                break;
            case "restore-photo-viewer":
                await RestorePhotoViewerAsync();
                break;
            case "taskbar-tutorial":
                AppNavigation.Open("tutorial", showBack: true);
                break;

            // ---------------------------------------------------------- 控制面板隐藏项
            case "old-personalize":
                Launcher.OpenShellFolder("ED834ED6-4B5A-4bfe-8F11-A626DCB6A921");
                break;
            case "old-colors":
                Launcher.Start("explorer.exe", @"shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}\pageColorization");
                break;
            case "old-wallpaper":
                Launcher.Start("explorer.exe", @"shell:::{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}\pageWallpaper");
                break;
            case "old-taskbar":
                Launcher.Start("cmd.exe", "/c start shell:::{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9}", hidden: true);
                break;

            // ---------------------------------------------------------- 通用
            case "restart-explorer":
                await ToolActions.ConfirmExplorerAsync(restart: true);
                break;
            case "exit-app":
                (WindowRegistry.MainWindow as MainWindow)?.ExitApp();
                break;
        }
    }

    private static async Task RestorePhotoViewerAsync()
    {
        var extensions = new[] { ".png", ".ico", ".dib", ".bmp", ".jfif", ".jpe", ".jpeg", ".jpg" };
        var parts = extensions.Select(ext =>
            $@"reg.exe add ""HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Photo Viewer\Capabilities\FileAssociations"" /v {ext} /T REG_SZ /d PhotoViewer.FileAssoc.Tiff /f");
        var command = string.Join("&", parts);
        Launcher.Start("cmd.exe", "/c " + command, runAs: true);
        await Task.CompletedTask;
    }
}
