using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace WFLTool.Core;

/// <summary>启动程序 / 打开系统页面 / 写入注册表等操作的统一入口。</summary>
public static class Launcher
{
    public static void Start(string fileName, string? arguments = null, bool runAs = false, bool hidden = false, string? workingDirectory = null)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = fileName,
                UseShellExecute = true,
            };
            if (!string.IsNullOrEmpty(arguments))
            {
                psi.Arguments = arguments;
            }
            if (runAs)
            {
                psi.Verb = "runas";
            }
            if (hidden)
            {
                psi.WindowStyle = ProcessWindowStyle.Hidden;
            }
            if (!string.IsNullOrEmpty(workingDirectory))
            {
                psi.WorkingDirectory = workingDirectory;
            }
            Process.Start(psi);
        }
        catch
        {
            // 与旧版 Shell() 相同：失败时静默。
        }
    }

    /// <summary>用 ShellExecute 打开任意目标（网址、URI 协议、文件、文件夹）。</summary>
    public static void ShellOpen(string target, string? arguments = null, bool runAs = false)
        => Start(target, arguments, runAs);

    public static void OpenUrl(string url) => Start(url);

    public static void OpenSettings(string msSettingsUri) => Start(msSettingsUri);

    public static void OpenExplorer(string arguments) => Start("explorer.exe", arguments);

    public static void StartCmd(bool runAs = false) => Start("cmd.exe", null, runAs);

    public static void StartPowerShell(bool runAs = false) => Start("powershell.exe", null, runAs);

    public static string SysWow64 => Path.Combine(SystemInfo.SystemRoot, "SysWOW64");

    public static string System32 => Path.Combine(SystemInfo.SystemRoot, "System32");

    // ---------------------------------------------------------------- 注册表
    /// <summary>HKCU 写入 DWORD。</summary>
    public static void SetHkcuDword(string keyPath, string valueName, int value)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(keyPath, true);
            key?.SetValue(valueName, value, RegistryValueKind.DWord);
        }
        catch
        {
        }
    }

    public static void SetHkcuString(string keyPath, string valueName, string value)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(keyPath, true);
            key?.SetValue(valueName, value, RegistryValueKind.String);
        }
        catch
        {
        }
    }

    public static void SetHkcuDefault(string keyPath, string value)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(keyPath, true);
            key?.SetValue(null, value, RegistryValueKind.String);
        }
        catch
        {
        }
    }

    public static void DeleteHkcuValue(string keyPath, string valueName)
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(keyPath, true);
            key?.DeleteValue(valueName, false);
        }
        catch
        {
        }
    }

    public static void DeleteHkcuKey(string keyPath, bool tree = true)
    {
        try
        {
            if (tree)
            {
                Registry.CurrentUser.DeleteSubKeyTree(keyPath, false);
            }
            else
            {
                Registry.CurrentUser.DeleteSubKey(keyPath, false);
            }
        }
        catch
        {
        }
    }

    /// <summary>旧版 reg.exe 调用（HKLM / 需要管理员权限时提权）。</summary>
    public static void RunReg(string arguments, bool runAs = false)
        => Start(Path.Combine(System32, "reg.exe"), arguments, runAs, hidden: !runAs);

    public static void AddHklmDword(string keyPath, string valueName, int value)
        => RunReg($"add \"{keyPath}\" /v {valueName} /T REG_DWORD /d {value} /f", runAs: true);

    public static void AddHklmString(string keyPath, string valueName, string value)
        => RunReg($"add \"{keyPath}\" /v {valueName} /T REG_SZ /d \"{value}\" /f", runAs: true);

    // ---------------------------------------------------------------- 系统操作
    public static void RestartExplorer()
    {
        KillExplorer();
        Start("cmd.exe", "/c start %windir%\\explorer.exe", hidden: true);
    }

    public static void KillExplorer()
    {
        try
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
        }
        catch
        {
        }
    }

    public static void KillProcess(string processName)
    {
        try
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
        catch
        {
        }
    }

    public static void Shutdown(string arguments) => Start("shutdown.exe", arguments, hidden: true);

    public static void LockWorkstation() => Start("rundll32.exe", "user32.dll,LockWorkStation");

    public static void OpenInternetExplorer(string? url = null)
    {
        try
        {
            var type = Type.GetTypeFromProgID("InternetExplorer.Application");
            if (type is null)
            {
                Start("iexplore.exe", url);
                return;
            }
            var ie = Activator.CreateInstance(type);
            if (ie is null)
            {
                Start("iexplore.exe", url);
                return;
            }
            type.InvokeMember("Visible", System.Reflection.BindingFlags.SetProperty, null, ie, new object[] { true });
            if (!string.IsNullOrEmpty(url))
            {
                type.InvokeMember("Navigate", System.Reflection.BindingFlags.InvokeMethod, null, ie, new object[] { url });
            }
        }
        catch
        {
            Start("iexplore.exe", url);
        }
    }

    public static void RunSlmgr(string arguments, bool runAs = true)
        => Start("wscript.exe", $"{Path.Combine(System32, "slmgr.vbs")} {arguments}", runAs);

    public static void OpenDiagPackage(string packageName)
        => Start(Path.Combine(SystemInfo.SystemRoot, "diagnostics", "system", packageName, "DiagPackage.diagpkg"));

    public static void OpenShellFolder(string guid)
        => Start("explorer.exe", $"shell:::{guid}");

    public static void OpenWindowsFeatures() => Start("OptionalFeatures.exe");

    // ---------------------------------------------------------------- Win32
    private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    [DllImport("shell32.dll", EntryPoint = "#61", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
    private static extern void RunFileDlg(
        IntPtr hwndOwner,
        IntPtr hIcon,
        string? lpstrDirectory,
        string? lpstrTitle,
        string? lpstrDescription,
        uint uFlags);

    /// <summary>调用 shell32 的资源管理器“运行”对话框。</summary>
    public static void ShowRunDialog(IntPtr owner, string title = "运行", string description = "Windows 将根据你所输入的名称,为你打开相应的程序、文件夹、文档或 Internet 资源。")
    {
        try
        {
            RunFileDlg(owner, IntPtr.Zero, null, title, description, 0);
        }
        catch
        {
        }
    }
}
