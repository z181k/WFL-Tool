using Microsoft.Win32;

namespace WFLTool.Core;

/// <summary>产品版本信息（对应旧版 Loadpga 中隐藏的 Ver / Build / Beta / NewUI 标签）。</summary>
public static class ProductInfo
{
    public const string Version = "17.5";
    public const string Build = "9824.1";
#if STORE_BUILD
    public static string Beta => "StoreSF";
#else
    public static string Beta => ReadBeta();
#endif

    private static string ReadBeta()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\DBT\WFL Tool");
            var value = key?.GetValue("Beta") as string;
            return string.IsNullOrWhiteSpace(value) ? "RTM" : value;
        }
        catch
        {
            return "RTM";
        }
    }

    /// <summary>Legacy / NSet / NSetMod / NMod —— 由产品定制构建写入。</summary>
    public static readonly string NewUi = "Legacy";

    public const string AppName = "WFL Tool";
    public const string ChineseName = "电脑功能启动器";
    public const string Slogan = "方便快捷 一点即达";

    public static string FullVersion => $"{Version}  ·  Build {Build}";

    public static string BetaDisplay => Beta switch
    {
        "B1" => "内测版",
        "B2" => "公测版",
        "RC" => "发布候选",
        "SF" => "正式版",
        "Store" or "StoreSF" => "正式版（无 UIAccess）",
        "StoreB2" => "公测版（无 UIAccess）",
        "StoreRC" => "发布候选（无 UIAccess）",
        _ => "正式版",
    };

    public static bool IsStoreVersion => Beta is "Store" or "StoreSF" or "StoreB2" or "StoreRC";
}
