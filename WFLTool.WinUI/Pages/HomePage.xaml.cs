using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using WFLTool.Core;
using WFLTool.Models;

namespace WFLTool.Pages;

public sealed partial class HomePage : Page, IAppPage
{
    public event EventHandler? BackRequested
    {
        add { }
        remove { }
    }

    public ObservableCollection<ToolItem> QuickItems { get; } = new();
    public ObservableCollection<ToolItem> ExplorerItems { get; } = new();
    public ObservableCollection<ToolItem> ToolItems { get; } = new();

    public HomePage()
    {
        InitializeComponent();
        Build();
    }

    private void Build()
    {
        // ---------------------------------------------------------- 快速操作
        QuickItems.Add(new ToolItem
        {
            Glyph = "\uE768",
            Title = "启动资源管理器",
            Description = "重新打开 Windows 桌面与任务栏",
            Tag = "explorer-start",
        });
        QuickItems.Add(new ToolItem
        {
            Glyph = "\uE72C",
            Title = "重启资源管理器",
            Description = "刷新桌面、任务栏和文件资源管理器",
            Tag = "explorer-restart",
        });
        QuickItems.Add(new ToolItem
        {
            Glyph = "\uE711",
            Title = "关闭资源管理器",
            Description = "强制结束 explorer.exe 进程",
            Tag = "explorer-close",
        });

        // ---------------------------------------------------------- 资源管理器
        ExplorerItems.Add(new ToolItem { Glyph = "\uE977", Title = "此电脑", Description = "打开“此电脑”", Tag = "thispc" });
        ExplorerItems.Add(new ToolItem { Glyph = "\uE968", Title = "网络", Description = "打开网络位置", Tag = "network" });
        ExplorerItems.Add(new ToolItem { Glyph = "\uE770", Title = "控制面板", Description = "打开经典控制面板", Tag = "controlpanel" });
        ExplorerItems.Add(new ToolItem { Glyph = "\uE74D", Title = "回收站", Description = "打开回收站", Tag = "recyclebin" });

        // ---------------------------------------------------------- 实用功能
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE756",
            Title = "命令提示符",
            Description = "左键打开 CMD，右键选择管理员 / x86 版本",
            Tag = "cmd",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE7EF",
            Title = "计算机管理",
            Description = "设备管理器、磁盘管理、服务等",
            Tag = "compmgmt",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE8EF",
            Title = "注册表编辑器",
            Description = "左键打开 regedit，右键可多开 / x86",
            Tag = "regedit",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE946",
            Title = "Windows 版本",
            Description = "查看 winver 版本信息",
            Tag = "winver",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE9D9",
            Title = "内存诊断",
            Description = "Windows 内存诊断工具 (MdSched)",
            Tag = "memdiag",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE8A5",
            Title = "本地组策略编辑器",
            Description = "家庭版系统不支持该功能",
            Tag = "gpedit",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE7B8",
            Title = "自解压创建程序",
            Description = "IExpress 向导",
            Tag = "iexpress",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE7E8",
            Title = "设置开机启动项目",
            Description = "添加或管理开机启动项",
            Tag = "startup-manager",
        });

        var ieTitle = SystemInfo.CurrentBuild >= 22000
            ? "打开被 Windows 11 隐藏的 IE"
            : "启动没有任何起始页的 IE";
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE774",
            Title = ieTitle,
            Description = "Internet Explorer 浏览器",
            Tag = "ie",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE8B7",
            Title = "系统附件",
            Description = "记事本、画图、计算器、远程桌面等",
            Tag = "accessories",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE71D",
            Title = "查看更多",
            Description = "iSCSI、ODBC、磁盘清理、MSDT 等",
            Tag = "more",
        });
        ToolItems.Add(new ToolItem
        {
            Glyph = "\uE72E",
            Title = "密钥管理服务",
            Description = "Windows / Office KMS 激活 UI",
            Tag = "kms",
        });

        SetupBetaBar();
    }

    private void SetupBetaBar()
    {
        var beta = ProductInfo.Beta;
        string? message = null;
        var canDismiss = true;

        if (beta == "B1")
        {
            message = "仅供内部测试，内部机密，若意外获得，请向我们举报。";
            canDismiss = false;
        }
        else if (beta is "B2" or "StoreB2")
        {
            if (AppSettings.Preview != ProductInfo.Build)
            {
                message = "这是 WFL Tool 公测版本 (Beta)，有问题及时反馈。";
            }
        }
        else if (beta is "SF" or "StoreSF")
        {
            if (AppSettings.Preview != ProductInfo.Build)
            {
                message = "五周年，大更新！欢迎点击帮助参加五周年活动。";
            }
        }

        if (message is null)
        {
            BetaBar.IsOpen = false;
            return;
        }

        BetaBar.Message = message;
        BetaBar.IsOpen = true;
        if (BetaBar.ActionButton is Button action)
        {
            action.Visibility = canDismiss ? Visibility.Visible : Visibility.Collapsed;
        }
    }

    private void BetaBar_DismissClick(object sender, RoutedEventArgs e)
    {
        AppSettings.Set("Preview", ProductInfo.Build);
        BetaBar.IsOpen = false;
    }

    private void BetaBar_CloseButtonClick(InfoBar sender, object args)
    {
        sender.IsOpen = false;
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            if (tag == "ie")
            {
                Launcher.OpenInternetExplorer();
                return;
            }
            ToolActions.Run(tag, button);
        }
    }

    private void Tile_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        if (sender is not Button button || button.Tag is not string tag)
        {
            return;
        }

        switch (tag)
        {
            case "cmd":
                FlyoutHelper.ShowMenu(button, new (string, Action)[]
                {
                    ("命令提示符", () => Launcher.Start("cmd.exe")),
                    ("命令提示符 (管理员)", () => Launcher.Start("cmd.exe", null, runAs: true)),
                    ("命令提示符 (x86)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "cmd.exe"))),
                    ("命令提示符 (x86) (管理员)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "cmd.exe"), null, runAs: true)),
                });
                e.Handled = true;
                break;

            case "regedit":
                FlyoutHelper.ShowMenu(button, new (string, Action)[]
                {
                    ("注册表编辑器 (多开)", () => Launcher.Start(Path.Combine(SystemInfo.SystemRoot, "regedit.exe"), "-m")),
                    ("注册表编辑器 (不多开)", () => Launcher.Start(Path.Combine(SystemInfo.SystemRoot, "regedit.exe"))),
                    ("注册表编辑器 (多开, x86)", () => Launcher.Start(Path.Combine(Launcher.SysWow64, "regedit.exe"), "-m")),
                });
                e.Handled = true;
                break;
        }
    }

    public void SetBackVisible(bool visible)
    {
    }
}
