using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>所有页面共用的操作分发。</summary>
public static class ToolActions
{
    public static async void Run(string tag, FrameworkElement? anchor = null)
    {
        try
        {
            await RunAsync(tag, anchor);
        }
        catch
        {
            // 与旧版一致：操作失败不打断界面。
        }
    }

    private static async Task RunAsync(string tag, FrameworkElement? anchor)
    {
        switch (tag)
        {
            // ---------------------------------------------------------- 资源管理器
            case "explorer-start":
                Launcher.Start("cmd.exe", "/c start %windir%\\explorer.exe", hidden: true);
                break;
            case "explorer-close":
                await ConfirmExplorerAsync(restart: false);
                break;
            case "explorer-restart":
                await ConfirmExplorerAsync(restart: true);
                break;

            // ---------------------------------------------------------- 系统位置
            case "thispc":
                Launcher.OpenShellFolder("20D04FE0-3AEA-1069-A2D8-08002B30309D");
                break;
            case "network":
                Launcher.OpenShellFolder("F02C1A0D-BE21-4350-88B0-7367FC96EF3C");
                break;
            case "controlpanel":
                Launcher.Start("control.exe");
                break;
            case "recyclebin":
                Launcher.OpenShellFolder("645FF040-5081-101B-9F08-00AA002F954E");
                break;
            case "all-tasks":
                Launcher.OpenShellFolder("ED7BA470-8E54-465E-825C-99712043E01C");
                break;
            case "system-properties":
                Launcher.OpenShellFolder("BB06C0E4-D293-4F75-8A90-CB05B6477EEE");
                break;
            case "system-tasks":
                Launcher.OpenSettings("ms-settings:");
                break;
            case "windows-security-questions":
                Launcher.OpenSettings("ms-cxh://setsqsalocalonly/");
                break;

            // ---------------------------------------------------------- 控制台 / 管理
            case "cmd":
                Launcher.Start("cmd.exe");
                break;
            case "cmd-admin":
                Launcher.Start("cmd.exe", null, runAs: true);
                break;
            case "cmd-x86":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "cmd.exe"));
                break;
            case "cmd-x86-admin":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "cmd.exe"), "goto :Admin", runAs: true);
                break;
            case "powershell":
                Launcher.StartPowerShell();
                break;
            case "powershell-admin":
                Launcher.StartPowerShell(runAs: true);
                break;
            case "powershell-x86":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell.exe"));
                break;
            case "powershell-x86-admin":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell.exe"), null, runAs: true);
                break;
            case "powershell-ise":
                Launcher.Start("powershell_ise.exe");
                break;
            case "powershell-ise-admin":
                Launcher.Start("powershell_ise.exe", null, runAs: true);
                break;
            case "powershell-ise-x86":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell_ise.exe"));
                break;
            case "powershell-ise-x86-admin":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell_ise.exe"), null, runAs: true);
                break;
            case "compmgmt":
                Launcher.Start(Path.Combine(Launcher.System32, "compmgmt.msc"), "/s");
                break;
            case "compmgmt-cct":
                await RunComputerManagementAsync();
                break;
            case "regedit":
                Launcher.Start(Path.Combine(SystemInfo.SystemRoot, "regedit.exe"));
                break;
            case "regedit-multi":
                Launcher.Start(Path.Combine(SystemInfo.SystemRoot, "regedit.exe"), "-m");
                break;
            case "regedit-x86":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "regedit.exe"));
                break;
            case "winver":
                Launcher.Start("winver.exe");
                break;
            case "memdiag":
                Launcher.Start(Path.Combine(Launcher.System32, "MdSched.exe"));
                break;
            case "gpedit":
                if (SystemInfo.IsHomeEdition)
                {
                    await DialogService.ShowInfoAsync("WFL Tool", "家庭版、家庭单语言版以及家庭中文版的 Windows 不支持该功能");
                }
                else
                {
                    Launcher.Start(Path.Combine(Launcher.System32, "gpedit.msc"));
                }
                break;
            case "iexpress":
                Launcher.Start(Path.Combine(Launcher.System32, "iexpress.exe"));
                break;
            case "taskmgr":
                Launcher.Start(Path.Combine(Launcher.System32, "taskmgr.exe"));
                break;
            case "taskmgr-legacy":
                Launcher.Start(Path.Combine(Launcher.System32, "Taskmgr.exe"), "-d", runAs: true);
                break;
            case "msconfig":
                Launcher.Start(Path.Combine(Launcher.System32, "msconfig.exe"));
                break;
            case "sysinfo":
                Launcher.Start("msinfo32.exe");
                break;
            case "cleanmgr":
                Launcher.Start(Path.Combine(Launcher.System32, "cleanmgr.exe"));
                break;
            case "mmc":
                Launcher.Start(Path.Combine(Launcher.System32, "mmc.exe"));
                break;
            case "recoverydrive":
                Launcher.Start(Path.Combine(Launcher.System32, "RecoveryDrive.exe"));
                break;
            case "firewall":
                Launcher.Start(Path.Combine(Launcher.System32, "WF.msc"));
                break;
            case "defrag":
                Launcher.Start(Path.Combine(Launcher.System32, "dfrgui.exe"));
                break;
            case "perfmon":
                Launcher.Start(Path.Combine(Launcher.System32, "perfmon.msc"), "/s");
                break;
            case "resmon":
                Launcher.Start(Path.Combine(Launcher.System32, "perfmon.exe"), "/res");
                break;
            case "iscsi":
                Launcher.Start(Path.Combine(Launcher.System32, "iscsicpl.exe"));
                break;
            case "odbc":
                Launcher.Start(Path.Combine(Launcher.System32, "odbcad32.exe"));
                break;
            case "odbc32":
                Launcher.Start(Path.Combine(Launcher.SysWow64, "odbcad32.exe"));
                break;
            case "netplwiz":
                Launcher.Start("netplwiz.exe");
                break;
            case "user-accounts":
                Launcher.Start("netplwiz.exe");
                break;

            // ---------------------------------------------------------- UWP / 设置
            case "settings":
                Launcher.OpenSettings("ms-settings:");
                break;
            case "defender":
                Launcher.Start("WindowsDefender:");
                break;
            case "store":
                Launcher.Start("ms-windows-store://home");
                break;
            case "uwp-explorer":
                Launcher.Start("explorer.exe",
                    @"shell:AppsFolder\c5e2524a-ea46-4f67-841f-6a9465d9d515_cw5n1h2txyewy!App");
                break;
            case "media-player":
                Launcher.Start("MsWindowsMusic:1");
                break;
            case "camera":
                Launcher.Start("Microsoft.windows.camera:5");
                break;
            case "photos":
                Launcher.Start("ms-photos:5");
                break;
            case "clock":
                Launcher.Start("ms-clock:1");
                break;
            case "all-apps":
                Launcher.OpenShellFolder("4234D49B-0245-4DF3-B780-3893943456E1");
                break;
            case "windows-update":
                Launcher.OpenSettings("ms-settings:windowsupdate");
                break;
            case "optional-features":
                Launcher.OpenSettings("ms-settings:optionalfeatures");
                break;
            case "windows-features":
                Launcher.OpenWindowsFeatures();
                break;
            case "accessibility-folder":
                Launcher.Start("explorer.exe",
                    @"%userprofile%\appdata\roaming\Microsoft\Windows\Start Menu\Programs\Accessibility");
                break;
            case "conhost":
                Launcher.Start("conhost.exe");
                break;
            case "terminal":
                Launcher.Start("conhost.exe", "wt.exe");
                break;

            // ---------------------------------------------------------- 电源
            case "lock":
                Launcher.LockWorkstation();
                break;
            case "switch-user":
                Launcher.Start("tsdiscon.exe", hidden: true);
                break;
            case "sleep":
                Launcher.Shutdown("/h");
                break;
            case "logoff":
                Launcher.Shutdown("-L");
                break;
            case "shutdown":
                Launcher.Shutdown("-s -t 0");
                break;
            case "restart":
                Launcher.Shutdown("-r -t 0");
                break;
            case "winre":
                Launcher.Shutdown("/r /o /T 0");
                break;
            case "battery-report":
                await ShowBatteryReportAsync();
                break;
            case "shutdown-cancel":
                Launcher.Shutdown("-a");
                break;

            // ---------------------------------------------------------- 启动项
            case "startup-manager":
                StartupDialog.Show();
                break;
            case "startup-add":
                await DialogService.ShowInfoAsync("添加开机启动项目", "将文件或快捷方式拖入打开的文件夹即可。");
                Launcher.Start("explorer.exe", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp");
                break;
            case "startup-open":
                if (SystemInfo.CurrentBuild >= 22621)
                {
                    Launcher.OpenSettings("ms-settings:startupapps");
                }
                else
                {
                    Launcher.Start(Path.Combine(Launcher.System32, "taskmgr.exe"), "/7 /Startup");
                }
                break;

            // ---------------------------------------------------------- UAC
            case "uac-settings":
                Launcher.Start("UserAccountControlSettings.exe");
                break;
            case "uac-off":
                UacWarningDialog.Show();
                break;

            // ---------------------------------------------------------- 更新
            case "update-log":
                UpdateLinks.OpenUpdateLog();
                break;
            case "windows-auto-update-on":
                Launcher.RunReg(
                    @"delete HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /f", runAs: true);
                Launcher.RunReg(
                    @"delete HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v NoAutoUpdate /f", runAs: true);
                break;
            case "windows-auto-update-off":
                Launcher.RunReg(
                    @"add HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v AUOptions /T REG_DWORD /d 0 /f", runAs: true);
                Launcher.RunReg(
                    @"add HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU /v NoAutoUpdate /T REG_DWORD /d 1 /f", runAs: true);
                break;
            case "browse-files":
                await BrowseFilesAsync();
                break;
            case "run-dialog":
                if (WindowRegistry.MainWindow is MainWindow runShell)
                {
                    Launcher.ShowRunDialog(WindowInterop.GetHwnd(runShell),
                        "运行  -  WFL Tool",
                        "WFL Tool 将根据你所输入的名称,为你打开相应的程序、文件夹、文档、Internet 资源以及 Intranet 资源。");
                }
                break;
            case "feedback":
                Launcher.OpenUrl("mailto:z181k@139.com?subject=WFL+Tool+(x64)+%E5%8F%8D%E9%A6%88%E9%82%AE%E4%BB%B6");
                break;
            case "device-error-help":
                UpdateLinks.OpenDeviceErrorHelp();
                break;
            case "help-center":
                UpdateLinks.OpenHelp();
                break;
            case "windows-help":
                UpdateLinks.OpenWindowsHelp();
                break;
            case "clear-data-page":
                AppNavigation.Open("settings", showBack: true);
                break;

            // ---------------------------------------------------------- 定时关机
            case "timer-60":
                Launcher.Shutdown("-s -t 60");
                break;
            case "timer-300":
                Launcher.Shutdown("-s -t 300");
                break;
            case "timer-600":
                Launcher.Shutdown("-s -t 600");
                break;
            case "timer-1200":
                Launcher.Shutdown("-s -t 1200");
                break;
            case "timer-1800":
                Launcher.Shutdown("-s -t 1800");
                break;
            case "timer-3600":
                Launcher.Shutdown("-s -t 3600");
                break;
            case "timer-7200":
                Launcher.Shutdown("-s -t 7200");
                break;
            case "timer-18000":
                Launcher.Shutdown("-s -t 18000");
                break;
            case "timer-43200":
                Launcher.Shutdown("-s -t 43200");
                break;
            case "timer-86400":
                Launcher.Shutdown("-s -t 86400");
                break;
            case "timer-172800":
                Launcher.Shutdown("-s -t 172800");
                break;
            case "timer-custom":
                var (ok, seconds) = await InputDialog.ShowShutdownTimeAsync();
                if (ok)
                {
                    Launcher.Shutdown($"/s /t {seconds}");
                }
                break;
            case "timer-advanced":
                Launcher.Start("shutdown.exe", "-i", hidden: false);
                break;
            case "quick-shutdown":
                Launcher.Start(Path.Combine(AppContext.BaseDirectory, "QuickShutdown.exe"), "/s", hidden: true);
                break;

            // ---------------------------------------------------------- 高级功能
            case "cmd-disable":
                Launcher.SetHkcuDword(@"Software\Policies\Microsoft\Windows\System", "DisableCMD", 1);
                break;
            case "cmd-restore":
                Launcher.SetHkcuDword(@"Software\Policies\Microsoft\Windows\System", "DisableCMD", 0);
                break;
            case "cp-disable":
                Launcher.SetHkcuDword(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoControlPanel", 1);
                break;
            case "cp-restore":
                Launcher.SetHkcuDword(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoControlPanel", 0);
                break;
            case "tm-disable":
                Launcher.SetHkcuDword(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "DisableTaskmgr", 1);
                break;
            case "tm-restore":
                Launcher.SetHkcuDword(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer", "DisableTaskmgr", 0);
                break;
            case "exit-app":
                (WindowRegistry.MainWindow as MainWindow)?.ExitApp();
                break;

            case "download-windows-official":
                Launcher.OpenUrl("https://www.microsoft.com/zh-cn/software-download/");
                break;
            case "msdn":
                Launcher.OpenUrl("https://msdn.itellyou.cn/");
                break;
            case "uupdump":
                Launcher.OpenUrl("https://www.uupdump.cn/");
                break;
            case "download-new-version":
                UpdateLinks.OpenDownloadPage();
                break;

            // ---------------------------------------------------------- 导航
            case "home":
                AppNavigation.Shell?.NavigateTo("home", showBack: false);
                break;
            case "more":
                AppNavigation.Open("more", showBack: true);
                break;
            case "accessories":
                AppNavigation.Open("accessories", showBack: true);
                break;
            case "system-tweaks":
                AppNavigation.Open("system", showBack: true);
                break;
            case "kms":
                AppNavigation.Open("kms", showBack: true);
                break;
            case "about":
                AppNavigation.Open("about", showBack: true);
                break;
            case "settings-page":
                AppNavigation.Open("settings", showBack: true);
                break;
            case "msdt":
                AppNavigation.Open("msdt", showBack: true);
                break;
            case "tutorial":
                AppNavigation.Open("tutorial", showBack: true);
                break;

            // ---------------------------------------------------------- 说明
            case "advanced-help":
                await DialogService.ShowInfoAsync("高级功能", "这里的功能可能会对计算机造成损坏，请谨慎使用！");
                break;
            case "topmost-help":
                await DialogService.ShowInfoAsync("置顶功能说明",
                    "为了弹窗正常显示，置顶后将不使用 WinAppSDK 提供的弹窗。在为所有用户安装情况下，将使用 UIAccess 这个置顶模式。");
                break;
            case "fix-start-menu":
                Launcher.KillProcess("StartMenuExperienceHost");
                break;
        }
    }

    public static async Task ConfirmExplorerAsync(bool restart)
    {
        if (AppSettings.NoMsgReExp)
        {
            Launcher.KillExplorer();
            if (restart)
            {
                Launcher.Start("cmd.exe", "/c start %windir%\\explorer.exe", hidden: true);
            }
            return;
        }

        var title = restart ? "要 重启资源管理器 吗？" : "要 关闭资源管理器 吗？";
        var message = restart
            ? "你确定要重启资源管理器吗？\n\n重启资源管理器会导致你正在进行的文件操作（文件复制、删除等操作）被强行打断，如果你需要重启，请先关闭这些操作或等待这些操作完成后单击继续重启或不再提示\n\n如果不希望以后再弹出这个提示，请点击不再提示，否则请单击继续重启"
            : "你确定要关闭资源管理器吗？\n\n关闭资源管理器会导致你正在进行的文件操作（文件复制、删除等操作）被强行打断，如果你需要关闭，请先关闭这些操作或等待这些操作完成后单击继续关闭或不再提示\n\n关闭资源管理器后会没有桌面和任务栏，不要忘记重新打开\n\n如果不希望以后再弹出这个提示，请点击不再提示，否则请单击继续关闭";

        var result = await DialogService.ShowAsync(
            title,
            message,
            primaryText: restart ? "继续重启" : "继续关闭",
            secondaryText: "不再提示",
            closeText: "取消",
            defaultButton: ContentDialogButton.Primary);

        if (result == ContentDialogResult.None)
        {
            return;
        }

        if (result == ContentDialogResult.Secondary)
        {
            AppSettings.Set("NoMsgReExp", "True");
        }

        Launcher.KillExplorer();
        if (restart)
        {
            Launcher.Start("cmd.exe", "/c start %windir%\\explorer.exe", hidden: true);
        }
    }

    private static async Task RunComputerManagementAsync()
    {
        var setting = AppSettings.CctButton;
        if (setting == "1")
        {
            Launcher.Start("cmd.exe", null, runAs: true);
        }
        else if (setting == "2" && SystemInfo.CurrentBuild >= 22621)
        {
            Launcher.Start(Path.Combine(Launcher.System32, "Taskmgr.exe"), "-d", runAs: true);
        }
        else
        {
            await Task.CompletedTask;
            Launcher.Start(Path.Combine(Launcher.System32, "compmgmt.msc"), "/s");
        }
    }

    private static Task BrowseFilesAsync()
    {
        if (WindowRegistry.MainWindow is not MainWindow shell)
        {
            return Task.CompletedTask;
        }

        IFileOpenDialog? dialog = null;
        IShellItemArray? results = null;
        try
        {
            dialog = (IFileOpenDialog)new FileOpenDialogClass();
            dialog.GetOptions(out var options);
            dialog.SetOptions(options | FosForceShowHidden | FosAllowMultiSelect | FosFileMustExist | FosPathMustExist);
            dialog.SetTitle("文件浏览 - WFL Tool");

            var hr = dialog.Show(WindowInterop.GetHwnd(shell));
            if (hr != 0)
            {
                return Task.CompletedTask;
            }

            dialog.GetResults(out results);
            results.GetCount(out var count);
            for (uint i = 0; i < count; i++)
            {
                results.GetItemAt(i, out var item);
                if (item is null)
                {
                    continue;
                }
                item.GetDisplayName(SigdnFileSysPath, out var pointer);
                var path = Marshal.PtrToStringUni(pointer);
                if (pointer != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pointer);
                }
                if (!string.IsNullOrEmpty(path))
                {
                    Launcher.Start(path);
                }
                Marshal.ReleaseComObject(item);
            }
        }
        catch
        {
        }
        finally
        {
            if (results is not null)
            {
                Marshal.ReleaseComObject(results);
            }
            if (dialog is not null)
            {
                Marshal.ReleaseComObject(dialog);
            }
        }

        return Task.CompletedTask;
    }

    private const uint FosAllowMultiSelect = 0x00000200;
    private const uint FosPathMustExist = 0x00000800;
    private const uint FosFileMustExist = 0x00001000;
    private const uint FosForceShowHidden = 0x10000000;
    private const uint SigdnFileSysPath = 0x80058000;

    [ComImport]
    [Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7")]
    private class FileOpenDialogClass
    {
    }

    [ComImport]
    [Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IFileOpenDialog
    {
        [PreserveSig]
        int Show(IntPtr parent);

        void SetFileTypes(uint cFileTypes, IntPtr rgFilterSpec);
        void SetFileTypeIndex(uint iFileType);
        void GetFileTypeIndex(out uint piFileType);
        void Advise(IntPtr pfde, out uint pdwCookie);
        void Unadvise(uint dwCookie);
        void SetOptions(uint fos);
        void GetOptions(out uint pfos);
        void SetDefaultFolder(IShellItem psi);
        void SetFolder(IShellItem psi);
        void GetFolder(out IShellItem ppsi);
        void GetCurrentSelection(out IShellItem ppsi);
        void SetFileName([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        void GetFileName([MarshalAs(UnmanagedType.LPWStr)] out string pszName);
        void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string pszTitle);
        void SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)] string pszText);
        void SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)] string pszLabel);
        void GetResult(out IShellItem ppsi);
        void AddPlace(IShellItem psi, int fdap);
        void SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)] string pszDefaultExtension);
        void Close([MarshalAs(UnmanagedType.Error)] int hr);
        void SetClientGuid(ref Guid guid);
        void ClearClientData();
        void SetFilter(IntPtr pFilter);
        void GetResults(out IShellItemArray ppenum);
        void GetSelectedItems(out IShellItemArray ppsai);
    }

    [ComImport]
    [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IShellItem
    {
        void BindToHandler(IntPtr pbc, ref Guid bhid, ref Guid riid, out IntPtr ppv);
        void GetParent(out IShellItem ppsi);
        void GetDisplayName(uint sigdnName, out IntPtr ppszName);
        void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
        void Compare(IShellItem psi, uint hint, out int piOrder);
    }

    [ComImport]
    [Guid("b63ea76d-1f85-456f-a19c-48159efa858b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IShellItemArray
    {
        void BindToHandler(IntPtr pbc, ref Guid bhid, ref Guid riid, out IntPtr ppvOut);
        void GetPropertyStore(uint flags, ref Guid riid, out IntPtr ppv);
        void GetPropertyDescriptionList(IntPtr keyType, ref Guid riid, out IntPtr ppv);
        void GetAttributes(uint attribFlags, uint sfgaoMask, out uint psfgaoAttribs);
        void GetCount(out uint pdwNumItems);
        void GetItemAt(uint dwIndex, out IShellItem ppsi);
        void EnumItems(out IntPtr ppenumShellItems);
    }

    private static async Task ShowBatteryReportAsync()
    {
        var path = Path.Combine(Path.GetTempPath(), "batteryreport_formWFLt.html");
        Launcher.Start("cmd.exe", $"/c powercfg.exe /batteryreport /OUTPUT \"{path}\"", hidden: true);
        await Task.Delay(1200);
        if (File.Exists(path))
        {
            Launcher.Start(path);
        }
    }
}
