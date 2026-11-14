namespace WFLTool.Core;

/// <summary>启动参数解析（对应旧版 Loadpga 的命令行分支）。</summary>
public sealed class StartupOptions
{
    public string Page { get; set; } = "home";
    public bool HasCommandLine { get; set; }
    public bool HideBack { get; set; }
    public bool NoMsdt { get; set; }
    public bool EulaOnly { get; set; }
    public bool ShowEulaInAbout { get; set; }
    public bool OpenRunDialog { get; set; }
    public string RunDialogTitle { get; set; } = "运行  -  WFL Tool";
    public string RunDialogDescription { get; set; } = "WFL Tool 将根据你所输入的名称,为你打开相应的程序、文件夹、文档、Internet 资源以及 Intranet 资源。";
    public bool ExitAfterStartup { get; set; }
    public bool ShowHelp { get; set; }
    public bool ShowDevInfo { get; set; }
    public bool ForceOverlay { get; set; }

    public static StartupOptions Parse(string[] args)
    {
        var options = new StartupOptions();
        var first = args.Length >= 1 ? args[0] : "";
        var second = args.Length >= 2 ? args[1] : "";

        if (string.IsNullOrEmpty(first))
        {
            return options;
        }

        options.HasCommandLine = true;
        var command = first.ToLowerInvariant();
        switch (command)
        {
            case "/openie":
                Launcher.OpenInternetExplorer(string.IsNullOrEmpty(second) ? null : second);
                options.ExitAfterStartup = true;
                break;

            case "/help":
            case "/?":
            case "/？":
                options.ShowHelp = true;
                options.ExitAfterStartup = true;
                break;

            case "/more":
                options.Page = second.Equals("msdt", StringComparison.OrdinalIgnoreCase) ? "msdt" : "more";
                options.HideBack = true;
                options.ForceOverlay = true;
                options.NoMsdt = second.Equals("nomsdt", StringComparison.OrdinalIgnoreCase);
                break;

            case "/kmsui":
            case "/activetool":
                options.Page = "kms";
                options.HideBack = true;
                options.ForceOverlay = true;
                break;

            case "/modsys":
            case "/systemmodifications":
                if (ProductInfo.NewUi is not ("NSetMod" or "NMod"))
                {
                    options.Page = "system";
                    options.HideBack = true;
                    options.ForceOverlay = true;
                }
                break;

            case "/sets":
                options.Page = "settings";
                options.HideBack = true;
                options.ForceOverlay = true;
                break;

            case "/accessories":
                options.Page = "accessories";
                options.HideBack = true;
                options.ForceOverlay = true;
                break;

            case "/about":
                if (second.Equals("eula", StringComparison.OrdinalIgnoreCase))
                {
                    options.EulaOnly = true;
                }
                else
                {
                    options.Page = "about";
                    options.HideBack = true;
                    options.ForceOverlay = true;
                }
                break;

            case "/run":
                options.OpenRunDialog = true;
                if (second.Equals("ori", StringComparison.OrdinalIgnoreCase))
                {
                    options.RunDialogTitle = "运行";
                    options.RunDialogDescription = "Windows 将根据你所输入的名称,为你打开相应的程序、文件夹、文档或 Internet 资源。";
                }
                break;

            case "devinfo" when second.Equals("xscpcl", StringComparison.OrdinalIgnoreCase):
                options.ShowDevInfo = true;
                options.ExitAfterStartup = true;
                break;
        }

        return options;
    }
}
