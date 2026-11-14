using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WFLTool.Core;
using WFLTool.Models;

namespace WFLTool.Pages;

public sealed partial class AccessoriesPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public ObservableCollection<ToolItem> CommonItems { get; } = new();
    public ObservableCollection<ToolItem> AccessibilityItems { get; } = new();

    public AccessoriesPage()
    {
        InitializeComponent();
        Build();
    }

    private void Build()
    {
        var canConhost = SystemInfo.CurrentBuild >= 22621;
        var canWrite = SystemInfo.CurrentBuild <= 26020;

        CommonItems.Add(new ToolItem { Glyph = "\uE70F", Title = "记事本", Description = "notepad.exe", Tag = "notepad" });
        CommonItems.Add(new ToolItem { Glyph = "\uE790", Title = "画图", Description = "mspaint.exe", Tag = "paint" });
        CommonItems.Add(new ToolItem { Glyph = "\uE8EF", Title = "计算器", Description = "calc.exe", Tag = "calc" });
        CommonItems.Add(new ToolItem { Glyph = "\uE8D7", Title = "造字程序", Description = "eudcedit.exe", Tag = "eudcedit" });
        CommonItems.Add(new ToolItem { Glyph = "\uE717", Title = "电话拨号程序", Description = "dialer.exe", Tag = "dialer" });
        CommonItems.Add(new ToolItem
        {
            Glyph = "\uE70F",
            Title = "写字板",
            Description = canWrite ? "write.exe" : "当前 Windows 版本已移除写字板",
            Tag = "write",
            IsEnabled = canWrite,
        });
        CommonItems.Add(new ToolItem
        {
            Glyph = "\uE768",
            Title = SystemInfo.CurrentBuild < 22000 ? "Windows Media Player" : "旧版 Windows 媒体播放器",
            Description = "wmplayer.exe",
            Tag = "wmplayer",
        });
        CommonItems.Add(new ToolItem { Glyph = "\uE722", Title = "截图工具", Description = "snippingtool.exe", Tag = "snippingtool" });
        CommonItems.Add(new ToolItem { Glyph = "\uE767", Title = "音量合成器", Description = "sndvol.exe", Tag = "sndvol" });
        CommonItems.Add(new ToolItem { Glyph = "\uE8AF", Title = "远程桌面连接", Description = "mstsc.exe", Tag = "mstsc" });
        CommonItems.Add(new ToolItem { Glyph = "\uE8D2", Title = "字符映射表", Description = "charmap.exe", Tag = "charmap" });
        CommonItems.Add(new ToolItem
        {
            Glyph = "\uE756",
            Title = "conhost 命令行",
            Description = canConhost ? "控制台窗口主机 (Windows 11)" : "仅 Windows 11 22H2 及以上版本支持",
            Tag = "conhost",
            IsEnabled = canConhost,
        });
        CommonItems.Add(new ToolItem
        {
            Glyph = "\uE756",
            Title = "新 终端",
            Description = canConhost ? "通过 conhost 启动 Windows 终端" : "仅 Windows 11 22H2 及以上版本支持",
            Tag = "terminal",
            IsEnabled = canConhost,
        });
        CommonItems.Add(new ToolItem { Glyph = "\uE7F8", Title = "移动中心", Description = "mblctr.exe，仅便携式计算机可用", Tag = "mblctr" });
        CommonItems.Add(new ToolItem { Glyph = "\uE8A5", Title = "扫描和传真", Description = "WFS.exe，Win11 需要自行下载", Tag = "wfs" });

        AccessibilityItems.Add(new ToolItem { Glyph = "\uE765", Title = "屏幕键盘", Description = "osk.exe", Tag = "osk" });
        AccessibilityItems.Add(new ToolItem { Glyph = "\uE71E", Title = "放大镜", Description = "magnify.exe", Tag = "magnify" });

        OptionalFeaturesButton.IsEnabled = SystemInfo.CurrentBuild >= 14393;
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button || button.Tag is not string tag)
        {
            return;
        }

        switch (tag)
        {
            case "notepad": Launcher.Start("cmd.exe", "/c start notepad.exe", hidden: true); break;
            case "paint": Launcher.Start("cmd.exe", "/c start mspaint.exe", hidden: true); break;
            case "calc": Launcher.Start("calc.exe"); break;
            case "eudcedit": Launcher.Start("cmd.exe", "/c start eudcedit.exe", hidden: true); break;
            case "dialer": Launcher.Start(Path.Combine(Launcher.System32, "dialer.exe")); break;
            case "write": Launcher.Start("cmd.exe", "/c start write.exe", hidden: true); break;
            case "wmplayer": Launcher.Start("cmd.exe", "/c start wmplayer.exe", hidden: true); break;
            case "snippingtool": Launcher.Start("cmd.exe", "/c start snippingtool.exe", hidden: true); break;
            case "sndvol": Launcher.Start("cmd.exe", "/c start sndvol.exe", hidden: true); break;
            case "mstsc": Launcher.Start("cmd.exe", "/c start mstsc.exe", hidden: true); break;
            case "charmap": Launcher.Start("cmd.exe", "/c start charmap.exe", hidden: true); break;
            case "conhost":
                ShowConhostMenu(button);
                break;
            case "terminal":
                ShowTerminalMenu(button);
                break;
            case "mblctr": Launcher.Start("cmd.exe", "/c start mblctr.exe", hidden: true); break;
            case "wfs": Launcher.Start("cmd.exe", "/c start WFS.exe", hidden: true); break;
            case "osk": Launcher.Start("cmd.exe", "/c start osk.exe", hidden: true); break;
            case "magnify": Launcher.Start("cmd.exe", "/c start magnify.exe", hidden: true); break;
        }
    }

    private void ShowConhostMenu(FrameworkElement anchor)
    {
        FlyoutHelper.ShowMenu(anchor, new (string, Action)[]
        {
            ("Conhost 打开 cmd", () => Launcher.Start("conhost.exe")),
            ("Conhost 打开 Powershell", () => Launcher.Start("conhost.exe", "powershell")),
            ("Conhost 执行自定义命令", () => RunCustomCommandAsync(terminal: false)),
        });
    }

    private void ShowTerminalMenu(FrameworkElement anchor)
    {
        FlyoutHelper.ShowMenu(anchor, new (string, Action)[]
        {
            ("打开 终端", () => Launcher.Start("conhost.exe", "wt")),
            ("使用 终端 打开 cmd", () => Launcher.Start("conhost.exe", "wt cmd")),
            ("使用 终端 打开 powershell", () => Launcher.Start("conhost.exe", "wt powershell")),
            ("在 终端 执行自定义命令", () => RunCustomCommandAsync(terminal: true)),
        });
    }

    private async void RunCustomCommandAsync(bool terminal)
    {
        var (ok, text) = await InputDialog.ShowTextAsync(
            terminal ? "在“Windows 终端”中执行命令 - WFL Tool" : "在“Conhost”中执行自定义命令 - WFL Tool",
            "在下方输入要执行的命令",
            terminal ? "在“终端”下的命令环境执行命令" : "在“控制台窗口主机”的命令环境中执行命令",
            "例如：ipconfig /all");
        if (!ok || string.IsNullOrWhiteSpace(text))
        {
            return;
        }
        Launcher.Start("conhost.exe", terminal ? "wt " + text : text);
    }

    private void WindowsFeatures_Click(object sender, RoutedEventArgs e) => Launcher.OpenWindowsFeatures();

    private void OptionalFeatures_Click(object sender, RoutedEventArgs e) => Launcher.OpenSettings("ms-settings:optionalfeatures");

    private void AccessibilityFolder_Click(object sender, RoutedEventArgs e) =>
        Launcher.Start("explorer.exe", @"%userprofile%\appdata\roaming\Microsoft\Windows\Start Menu\Programs\Accessibility");

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
