using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using WFLTool.Core;
using WFLTool.Models;
using WFLTool.Windows;

namespace WFLTool.Pages;

public sealed partial class MorePage : Page, IAppPage
{
    private readonly bool _noMsdt;
    private ToolItem? _msdtItem;

    public event EventHandler? BackRequested;

    public ObservableCollection<ToolItem> ManagementItems { get; } = new();
    public ObservableCollection<ToolItem> SecurityItems { get; } = new();
    public ObservableCollection<ToolItem> SupportItems { get; } = new();

    public MorePage(bool noMsdt = false)
    {
        _noMsdt = noMsdt;
        InitializeComponent();
        Build();
    }

    private void Build()
    {
        ManagementItems.Add(new ToolItem { Glyph = "\uE968", Title = "iSCSI 发起程序", Description = "iSCSI 连接与目标管理", Tag = "iscsi" });
        ManagementItems.Add(new ToolItem { Glyph = "\uE8F1", Title = "ODBC 数据源", Description = "64 位 ODBC 数据源管理器", Tag = "odbc" });
        ManagementItems.Add(new ToolItem { Glyph = "\uE8F1", Title = "ODBC 数据源 (32 位)", Description = "32 位 ODBC 数据源管理器", Tag = "odbc32" });
        ManagementItems.Add(new ToolItem { Glyph = "\uE74D", Title = "磁盘清理", Description = "清理临时文件与系统垃圾", Tag = "cleanmgr" });
        ManagementItems.Add(new ToolItem { Glyph = "\uE770", Title = "Microsoft 管理控制台", Description = "空的 MMC 控制台", Tag = "mmc" });
        ManagementItems.Add(new ToolItem { Glyph = "\uE777", Title = "恢复驱动器", Description = "创建 USB 恢复驱动器", Tag = "recoverydrive" });

        SecurityItems.Add(new ToolItem { Glyph = "\uE72E", Title = "高级安全 Windows Defender 防火墙", Description = "打开 WF.msc", Tag = "firewall" });
        SecurityItems.Add(new ToolItem { Glyph = "\uE9D9", Title = "碎片整理和优化驱动器", Description = "dfrgui，固态硬盘请使用优化功能", Tag = "defrag" });
        SecurityItems.Add(new ToolItem { Glyph = "\uE9D2", Title = "性能监视器", Description = "perfmon.msc", Tag = "perfmon" });
        SecurityItems.Add(new ToolItem { Glyph = "\uE9D2", Title = "资源监视器", Description = "CPU、内存、磁盘与网络实时监视", Tag = "resmon" });
        SecurityItems.Add(new ToolItem { Glyph = "\uE713", Title = "系统配置实用程序", Description = "msconfig，管理启动与引导", Tag = "msconfig" });
        SecurityItems.Add(new ToolItem { Glyph = "\uE7EF", Title = "任务管理器", Description = "taskmgr.exe", Tag = "taskmgr" });

        SupportItems.Add(new ToolItem { Glyph = "\uE946", Title = "系统信息", Description = "msinfo32，硬件与系统摘要", Tag = "sysinfo" });
        _msdtItem = new ToolItem
        {
            Glyph = "\uE9D9",
            Title = "MSDT 疑难解答",
            Description = "Microsoft 支持诊断工具 (已弃用)",
            Tag = "msdt",
            IsEnabled = !_noMsdt,
        };
        SupportItems.Add(_msdtItem);

        var cctTitle = AppSettings.CctButton switch
        {
            "1" => "命令提示符 (管理员)",
            "2" when SystemInfo.CurrentBuild >= 22621 => "旧版任务管理器",
            _ => "计算机管理",
        };
        SupportItems.Add(new ToolItem
        {
            Glyph = "\uE7EF",
            Title = cctTitle,
            Description = "由“查看更多内部功能”设置决定",
            Tag = "compmgmt-cct",
        });
        SupportItems.Add(new ToolItem
        {
            Glyph = "\uE756",
            Title = "Windows PowerShell",
            Description = "左键打开 PowerShell，右键选择管理员 / x86 / ISE",
            Tag = "powershell",
        });
        SupportItems.Add(new ToolItem
        {
            Glyph = "\uE77B",
            Title = "高级用户账户控制面板",
            Description = "netplwiz，管理用户账户与登录方式",
            Tag = "user-accounts",
        });
    }

    public void DisableMsdt()
    {
        if (_msdtItem is not null)
        {
            _msdtItem.IsEnabled = false;
        }
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            ToolActions.Run(tag, button);
        }
    }

    private void Tile_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        if (sender is not Button button || button.Tag is not string tag || tag != "powershell")
        {
            return;
        }

        FlyoutHelper.ShowMenu(button, new (string, Action)[]
        {
            ("Windows PowerShell", () => Launcher.StartPowerShell()),
            ("Windows PowerShell (管理员)", () => Launcher.StartPowerShell(runAs: true)),
            ("Windows PowerShell (x86)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell.exe"))),
            ("Windows PowerShell (x86) (管理员)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell.exe"), null, runAs: true)),
            ("Windows PowerShell ISE", () => Launcher.Start("powershell_ise.exe")),
            ("Windows PowerShell ISE (管理员)", () => Launcher.Start("powershell_ise.exe", null, runAs: true)),
            ("Windows PowerShell ISE (x86)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell_ise.exe"))),
            ("Windows PowerShell ISE (x86) (管理员)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "WindowsPowerShell", "v1.0", "powershell_ise.exe"), null, runAs: true)),
        });
        e.Handled = true;
    }

    private void DefragHelp_Click(object sender, RoutedEventArgs e)
    {
        EulaWindow.ShowInfo("碎片整理和优化驱动器功能说明",
            "此功能在 Win10 及以上系统在使用固态硬盘时只有优化驱动器功能，在 Win8 及以下系统在使用固态硬盘时碎片整理功能和优化驱动器功能都有，机械硬盘所有系统都有碎片整理功能和优化驱动器功能。\n\n" +
            "因为碎片整理会给固态硬盘造成损伤，这些在固态硬盘支持碎片整理的系统发布时没有出现或流行固态硬盘，所以请不要在固态硬盘碎片整理，并且及时关闭这些系统对固态硬盘的自动碎片整理！");
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
