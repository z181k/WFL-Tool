using Microsoft.Win32;

namespace WFLTool.Core;

/// <summary>系统信息读取，对应旧版 My.Computer.Registry.GetValue 调用。</summary>
public static class SystemInfo
{
    private const string CvKey = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

    public static string SystemRoot { get; } = ReadCv("SystemRoot", Environment.GetFolderPath(Environment.SpecialFolder.Windows));

    public static int CurrentBuild { get; } = ParseInt(ReadCv("CurrentBuild"));

    public static long Ubr { get; } = ParseLong(ReadCv("UBR"));

    public static string EditionId { get; } = ReadCv("EditionID");

    public static string InstallationType { get; } = ReadCv("InstallationType");

    public static string DisplayVersion { get; } = ReadCv("DisplayVersion");

    public static bool IsWindows11 => CurrentBuild >= 22000;

    public static bool IsWindows10 => CurrentBuild is >= 10240 and < 22000;

    public static string ProcessorArchitecture
    {
        get
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(
                    @"SYSTEM\CurrentControlSet\Control\Session Manager\Environment", false);
                return key?.GetValue("PROCESSOR_ARCHITECTURE") as string ?? "";
            }
            catch
            {
                return "";
            }
        }
    }

    public static bool IsArm64 => ProcessorArchitecture.Equals("ARM64", StringComparison.OrdinalIgnoreCase);

    public static bool IsX64 => ProcessorArchitecture.Equals("AMD64", StringComparison.OrdinalIgnoreCase);

    /// <summary>旧版：安装位置从卸载项读取。</summary>
    public static string InstallLocation
    {
        get
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Uninstall\WFLtool", false);
                return key?.GetValue("InstallLocation") as string ?? AppContext.BaseDirectory;
            }
            catch
            {
                return AppContext.BaseDirectory;
            }
        }
    }

    /// <summary>是否安装了 Edge WebView2（旧版用 WOW6432Node 卸载项判断）。</summary>
    public static bool IsWebView2Available
    {
        get
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Microsoft EdgeWebView", false);
                var version = key?.GetValue("Version") as string;
                if (!string.IsNullOrEmpty(version))
                {
                    return true;
                }
            }
            catch
            {
            }

            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}", false);
                var version = key?.GetValue("pv") as string;
                return !string.IsNullOrEmpty(version) && version != "0.0.0.0";
            }
            catch
            {
                return false;
            }
        }
    }

    public static bool IsHomeEdition => EditionId is "Core" or "CoreSingleLanguage" or "CoreCountrySpecific";

    public static bool IsServer => InstallationType.Equals("Server", StringComparison.OrdinalIgnoreCase);

    private static string ReadCv(string name, string fallback = "")
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(CvKey, false);
            return key?.GetValue(name)?.ToString() ?? fallback;
        }
        catch
        {
            return fallback;
        }
    }

    private static int ParseInt(string value) => int.TryParse(value, out var result) ? result : 0;

    private static long ParseLong(string value) => long.TryParse(value, out var result) ? result : 0;
}
