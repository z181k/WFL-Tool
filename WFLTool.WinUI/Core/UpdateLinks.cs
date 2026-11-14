namespace WFLTool.Core;

/// <summary>在线更新 / 下载 / 帮助链接：与旧版一致，通过 EWV2Viewer 打开，而不是自己内嵌 WebView2。</summary>
public static class UpdateLinks
{
    public const string DownloadUrl =
        "https://medbt-my.sharepoint.cn/:f:/g/personal/dbtob_medbt_partner_onmschina_cn/IgBdYnImsH-5RIqkDkx3h2pCAZaJ_8KKWMkn7g9S3mbt5tM?e=EaTFxL";

    public const string EmergencyUrl = "https://z181k.lanzoux.com/b0205vf6f";

    private const string ViewerRegistryPath = @"Software\DBT\WebPageViewer";

    public static void Open(string title, string url)
    {
        var viewer = FindViewer();
        if (viewer is not null)
        {
            // 与旧版 WriteWebPageSettings 的注册表参数一致，EWV2Viewer 会读取这些值。
            Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageClean", "True");
            Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageShow", "True");
            Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageShowIcon", "True");
            Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageTitle", title);
            Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageURL", url);
            Launcher.Start(viewer, workingDirectory: Path.GetDirectoryName(viewer));
            return;
        }

        // 找不到 EWV2Viewer 时退回系统默认浏览器（旧版同样有 legacy 分支）。
        Launcher.SetHkcuString(ViewerRegistryPath, "EWV2webpageClean", "False");
        Launcher.OpenUrl(url);
    }

    private static string? FindViewer()
    {
        var baseDirectory = AppContext.BaseDirectory;
        var candidates = new[]
        {
            Path.Combine(baseDirectory, "EWV2viewer", "EWV2Viewer.exe"),
            Path.Combine(baseDirectory, "EWV2viewer", "EWV2viewer.exe"),
            Path.Combine(baseDirectory, "EWV2Viewer.exe"),
            Path.Combine(baseDirectory, "EWV2viewer.exe"),
        };

        foreach (var candidate in candidates)
        {
            try
            {
                if (!string.IsNullOrEmpty(candidate) && File.Exists(candidate))
                {
                    return candidate;
                }
            }
            catch
            {
            }
        }

        return null;
    }

    public static void OpenDownloadPage() =>
        Open("下载新版本 WFL Tool - 请手动下载完整最新版安装包", DownloadUrl);

    public static void OpenUpdateLog()
    {
        // 与旧版 Form1.离线更新下载ToolStripMenuItem_Click 的分支保持一致。
        var build = SystemInfo.CurrentBuild;
        var isClient = string.Equals(SystemInfo.InstallationType, "Client", StringComparison.OrdinalIgnoreCase);
        string url;

        if (build > 26300)
        {
            url = isClient
                ? "https://support.microsoft.com/zh-cn/help/5079670"
                : "https://support.microsoft.com/zh-cn/help/5047442";
        }
        else if (build >= 26200)
        {
            url = "https://support.microsoft.com/zh-cn/help/5065323";
        }
        else if (build >= 26100)
        {
            url = isClient
                ? "https://support.microsoft.com/zh-cn/help/5045988"
                : "https://support.microsoft.com/zh-cn/help/5047442";
        }
        else if (build == 25398)
        {
            url = "https://support.microsoft.com/zh-cn/help/5031680";
        }
        else if (build >= 22631)
        {
            url = "https://support.microsoft.com/zh-cn/help/5031682";
        }
        else if (build >= 22621)
        {
            url = "https://support.microsoft.com/zh-cn/help/5018680";
        }
        else if (build >= 21380)
        {
            url = "https://support.microsoft.com/zh-cn/help/5006099";
        }
        else if (build == 20348)
        {
            url = "https://support.microsoft.com/zh-cn/help/5005454";
        }
        else
        {
            url = "https://support.microsoft.com/topic/8127c2c6-6edf-4fdf-8b9f-0f7be1ef3562";
        }

        Open("Windows 更新日志及离线更新包 - Microsoft 支持", url);
    }

    public static void OpenHelp() =>
        Open("WFL Tool 帮助", "https://kdocs.cn/l/sqxx3d4vumUT");

    public static void OpenWindowsHelp() =>
        Open("Windows 帮助与学习 - Microsoft 帮助与支持中心", "https://support.microsoft.com/windows");

    public static void OpenDeviceErrorHelp() =>
        Open("Windows 设备管理器中的错误代码 - Microsoft 支持", "https://go.microsoft.com/fwlink/?LinkID=2004354");

    public static void OpenMsdtRetire() =>
        Open("Microsoft 支持诊断工具 (MSDT) 弃用的说明 - Microsoft 支持", "https://aka.ms/msdtretire");
}
