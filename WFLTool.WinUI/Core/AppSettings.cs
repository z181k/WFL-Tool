using Microsoft.Win32;

namespace WFLTool.Core;

/// <summary>
/// 与旧版 WFL Tool (WinForms) 完全兼容的注册表设置读写。
/// 所有设置都保存在 HKCU\Software\DBT\WFL Tool 下。
/// </summary>
public static class AppSettings
{
    public const string ProductKeyPath = @"Software\DBT\WFL Tool";

    public static string Get(string name, string fallback = "")
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(ProductKeyPath, false);
            return key?.GetValue(name) as string ?? fallback;
        }
        catch
        {
            return fallback;
        }
    }

    public static void Set(string name, string value)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(ProductKeyPath, true);
            key?.SetValue(name, value, RegistryValueKind.String);
        }
        catch
        {
            // 与旧版一致：写入失败时静默忽略。
        }
    }

    public static int GetInt(string name, int fallback = 0)
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(ProductKeyPath, false);
            var value = key?.GetValue(name);
            return value is int i ? i : fallback;
        }
        catch
        {
            return fallback;
        }
    }

    public static void SetInt(string name, int value)
    {
        try
        {
            using var key = Registry.CurrentUser.CreateSubKey(ProductKeyPath, true);
            key?.SetValue(name, value, RegistryValueKind.DWord);
        }
        catch
        {
        }
    }

    public static void Delete(string name)
    {
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(ProductKeyPath, true);
            key?.DeleteValue(name, false);
        }
        catch
        {
        }
    }

    /// <summary>清除应用的全部用户设置（与旧版“清除数据”一致）。</summary>
    public static void ClearAll()
    {
        try
        {
            Registry.CurrentUser.DeleteSubKeyTree(ProductKeyPath, false);
        }
        catch
        {
        }
    }

    public static bool IsTrue(string name) =>
        string.Equals(Get(name), "True", StringComparison.OrdinalIgnoreCase) || Get(name) == "1";

    // ---------------------------------------------------------------- 常用设置
    /// <summary>主题：White / Dark / Auto（空值等于 Auto）。</summary>
    public static string ColorMode
    {
        get => Get("NColor");
        set => Set("NColor", value);
    }

    public static bool OnTop => Get("OnTop") == "1";
    public static bool LegacyMoreUi => IsTrue("LegacyMoreUI");
    public static bool TrayIconOnStartup => IsTrue("TrayIcon");
    public static string LegacyHomeUi => Get("LegacyHomeUI");
    public static string CctButton => Get("cctButton", "0");
    public static string Eula => Get("EULA");
    public static string Preview => Get("Preview");
    public static bool NoMsgReExp => IsTrue("NoMsgReExp");

    /// <summary>企业策略：HKLM\SOFTWARE\DBT\WFL Tool\EnterpriseNotShow = 1 时隐藏“选项”。</summary>
    public static bool EnterpriseNotShow
    {
        get
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"Software\DBT\WFL Tool", false);
                var value = key?.GetValue("EnterpriseNotShow");
                return value is int i && i == 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
