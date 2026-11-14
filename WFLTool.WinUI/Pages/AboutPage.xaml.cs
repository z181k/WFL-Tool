using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using WFLTool.Core;
using WFLTool.Models;
using WFLTool.Windows;

namespace WFLTool.Pages;

public sealed partial class AboutPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public ObservableCollection<ToolItem> Links { get; } = new();

    public AboutPage()
    {
        InitializeComponent();
        Build();
    }

    private void Build()
    {
        var logoPath = Path.Combine(AppContext.BaseDirectory, "Assets", "logo256.png");
        if (File.Exists(logoPath))
        {
            AboutLogo.Source = new BitmapImage(new Uri(logoPath));
        }

        BetaText.Text = ProductInfo.BetaDisplay;
        VersionText.Text = $"版本 {ProductInfo.Version}";
        BuildText.Text = $"Build {ProductInfo.Build}";
        ArchText.Text = "x64 · .NET 10 · WinUI 3";

        Links.Add(new ToolItem { Title = "更新日志", Description = "查看当前 Build 的更新内容", Tag = "changelog" });
        Links.Add(new ToolItem { Title = "命令行参数", Description = "查看 WFL Tool 支持的启动参数", Tag = "args" });
        Links.Add(new ToolItem { Title = "系统要求", Description = "支持的系统与架构", Tag = "requirements" });
        Links.Add(new ToolItem { Title = "联系我们", Description = "邮箱与社交平台", Tag = "contact" });
        Links.Add(new ToolItem { Title = "检查更新", Description = "打开下载中心", Tag = "update" });
        Links.Add(new ToolItem { Title = "应急下载链接", Description = "下载中心无法访问时使用", Tag = "emergency" });
        Links.Add(new ToolItem { Title = "法律信息", Description = "查看软件许可协议", Tag = "legal" });
        Links.Add(new ToolItem { Title = "开源地址", Description = "GitHub 上的 WFL Tool 项目", Tag = "github" });
    }

    private async void Link_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button || button.Tag is not string tag)
        {
            return;
        }

        switch (tag)
        {
            case "changelog":
                await DialogService.ShowAsync("当前 Build 更新日志", Changelog, "确定");
                break;
            case "args":
                await DialogService.ShowAsync("命令行参数",
                    "用法: WFLTool.exe [参数]\n\n" +
                    "  /help                 查询 WFL Tool 命令行参数\n" +
                    "  /openie [网址]        打开 IE，访问指定网址\n" +
                    "  /more                 打开更多功能页\n" +
                    "  /more msdt            打开 MSDT 页\n" +
                    "  /more nomsdt          打开更多功能页但屏蔽 MSDT 选项\n" +
                    "  /kmsui                打开 KMS 激活 UI\n" +
                    "  /ActiveTool           打开 KMS 激活 UI（和 kmsui 效果一样）\n" +
                    "  /modsys               打开系统修改页\n" +
                    "  /SystemModifications  打开系统修改页（和 modsys 效果一样）\n" +
                    "  /Accessories          打开附件页\n" +
                    "  /about                打开关于页\n" +
                    "  /about eula           显示软件许可协议\n" +
                    "  /run                  打开带 WFL Tool 字样的运行对话框\n" +
                    "  /run ori              打开运行对话框\n\n" +
                    "示例：WFLTool.exe /openie https://www.gov.cn", "确定");
                break;
            case "requirements":
                await DialogService.ShowAsync("系统要求",
                    "本应用只提供 x64 版本。对最新版本提供支持。\n\n" +
                    "由于从 Windows 11 开始，Microsoft 不再提供 x86 版本的 Windows，所以 x86 版本从 2025/10/17 起停止支持。不提供 arm 架构版本。\n\n" +
                    "最低支持 Windows 10 v1511，系统架构必须为 x64。暗色模式需要 Windows 10 v2004 及更高版本的系统。\n\n" +
                    "WinUI 3 版本需要 Windows App Runtime 2.x。", "确定");
                break;
            case "contact":
                await DialogService.ShowAsync("联系我们",
                    "邮箱: z181k@139.com 或 z181k@hotmail.com\n\n" +
                    "注：原来的 18734477184@139.com 现在只外发邮件，不接收邮件。\n\n" +
                    "社交平台：\nBilibili @也问Bot\n小红书 @尃瑫", "确定");
                break;
            case "update":
                UpdateLinks.OpenDownloadPage();
                break;
            case "emergency":
                UpdateLinks.Open("应急下载链接 - WFL Tool", UpdateLinks.EmergencyUrl);
                break;
            case "legal":
                EulaWindow.Show(readOnly: true);
                break;
            case "github":
                UpdateLinks.Open("WFL Tool 项目开源页面 - GitHub", "https://github.com/z181k/WFL-Tool");
                break;
        }
    }

    private void HistoryToggle_Click(object sender, RoutedEventArgs e)
        => HistoryText.Visibility = HistoryText.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;

    private const string Changelog =
        "Build 9824.1\n\n" +
        "使用 WinUI 3 重构界面。";
}
