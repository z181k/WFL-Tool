using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.Win32;
using WFLTool.Core;
using WFLTool.Pages;
using WFLTool.Windows;
using Windows.Graphics;

namespace WFLTool;

public sealed partial class MainWindow : Window
{
    private readonly StartupOptions _startup;
    private IAppPage? _currentPage;
    private string _currentTag = "";
    private readonly List<string> _history = new();
    private bool _exiting;
    private TrayIcon? _tray;
    private bool _trayBalloonShown;

    public MainWindow(StartupOptions startup)
    {
        _startup = startup;
        InitializeComponent();

        Title = "WFL Tool";
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
        SystemBackdrop = new MicaBackdrop();

        var iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "xinlogo.ico");
        if (File.Exists(iconPath))
        {
            AppWindow.SetIcon(iconPath);
        }

        var logoPath = Path.Combine(AppContext.BaseDirectory, "Assets", "logo256.png");
        if (File.Exists(logoPath))
        {
            AppTitleBar.IconSource = new ImageIconSource
            {
                ImageSource = new BitmapImage(new Uri(logoPath)),
            };
        }

        RootGrid.RequestedTheme = ThemeService.ElementTheme;
        ResizeAndCenter();
        RootGrid.Loaded += (_, _) =>
        {
            ResizeAndCenter();
            ApplyTitleBarTheme();
        };
        Activated += (_, _) => ApplyTitleBarTheme();

        UpdateThemeUi();
        UpdateVersionUi();
        UpdateMenuState();

        if (AppSettings.OnTop)
        {
            WindowInterop.SetTopmost(this, true);
        }

        if (AppSettings.TrayIconOnStartup)
        {
            SetTrayEnabled(true);
        }

        AppWindow.Closing += AppWindow_Closing;
        AppWindow.Changed += AppWindow_Changed;
        Closed += MainWindow_Closed;

        RootGrid.KeyDown += RootGrid_KeyDown;

        NavigateTo("home", showBack: false, pushHistory: false);
    }

    private void ResizeAndCenter()
    {
        try
        {
            var area = DisplayArea.GetFromWindowId(AppWindow.Id, DisplayAreaFallback.Primary);
            var work = area.WorkArea;

            var width = Math.Min(Math.Max(900, (int)Math.Round(work.Width * 0.84)), 2000);
            var height = Math.Min(Math.Max(600, (int)Math.Round(work.Height * 0.86)), 1400);

            AppWindow.Resize(new SizeInt32(width, height));
            AppWindow.Move(new PointInt32(
                work.X + Math.Max(0, (work.Width - width) / 2),
                work.Y + Math.Max(0, (work.Height - height) / 2)));
        }
        catch
        {
        }
    }

    // ------------------------------------------------------------ 导航
    public void NavigateTo(string tag, bool showBack, bool pushHistory = true)
    {
        if (string.IsNullOrEmpty(tag))
        {
            tag = "home";
        }

        if (pushHistory && !string.IsNullOrEmpty(_currentTag) && _currentTag != tag)
        {
            _history.Add(_currentTag);
        }

        var page = CreatePage(tag);
        if (page is not IAppPage appPage || page is not Page ui)
        {
            return;
        }

        if (_currentPage is not null)
        {
            _currentPage.BackRequested -= CurrentPage_BackRequested;
        }

        _currentPage = appPage;
        appPage.BackRequested += CurrentPage_BackRequested;
        appPage.SetBackVisible(false);

        ContentFrame.Content = ui;
        _currentTag = tag;
        Title = tag == "home" ? "WFL Tool" : $"WFL Tool  -  {PageTitle(tag)}";
        AppTitleBar.IsBackButtonVisible = true;
        AppTitleBar.IsBackButtonEnabled = showBack;
    }

    private static Page CreatePage(string tag) => tag switch
    {
        "more" => new MorePage(App.Current?.StartupOptions?.NoMsdt ?? false),
        "accessories" => new AccessoriesPage(),
        "system" => new SystemPage(),
        "kms" => new KmsPage(),
        "about" => new AboutPage(),
        "settings" => new SettingsPage(),
        "msdt" => new MsdtPage(),
        "tutorial" => new TransparencyTutorialPage(),
        _ => new HomePage(),
    };

    internal static Page CreatePageForWindow(string tag) => CreatePage(tag);

    private static string PageTitle(string tag) => tag switch
    {
        "more" => "查看更多",
        "accessories" => "系统附件",
        "system" => "系统修改",
        "kms" => "密钥管理服务",
        "about" => "关于",
        "settings" => "WFL Tool 选项",
        "msdt" => "MSDT 疑难解答",
        "tutorial" => "任务栏透明度设置教程",
        _ => "主页",
    };

    private void CurrentPage_BackRequested(object? sender, EventArgs e)
    {
        if (_history.Count > 0)
        {
            var target = _history[^1];
            _history.RemoveAt(_history.Count - 1);
            NavigateTo(target, showBack: target != "home", pushHistory: false);
        }
        else
        {
            NavigateTo("home", showBack: false, pushHistory: false);
        }
    }

    private void AppTitleBar_BackRequested(TitleBar sender, object args)
    {
        NavigateBack();
    }

    private void MenuSettings_Click(object sender, RoutedEventArgs e)
    {
        NavigateTo("settings", showBack: true);
    }

    private void SettingsMenuButton_Tapped(object sender, TappedRoutedEventArgs e)
    {
        NavigateTo("settings", showBack: true);
    }

    private void SettingsMenuButton_PointerReleased(object sender, PointerRoutedEventArgs e)
    {
        NavigateTo("settings", showBack: true);
    }

    private void RootGrid_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key != global::Windows.System.VirtualKey.Back || !AppTitleBar.IsBackButtonEnabled)
        {
            return;
        }

        // 输入框中的 Backspace 仍然是删除字符，不触发返回。
        var focused = FocusManager.GetFocusedElement(RootGrid.XamlRoot);
        if (focused is TextBox or PasswordBox or RichEditBox or AutoSuggestBox or NumberBox)
        {
            return;
        }

        e.Handled = true;
        NavigateBack();
    }

    private void NavigateBack()
    {
        if (!AppTitleBar.IsBackButtonEnabled)
        {
            return;
        }

        if (_history.Count > 0)
        {
            var target = _history[^1];
            _history.RemoveAt(_history.Count - 1);
            NavigateTo(target, showBack: target != "home", pushHistory: false);
        }
        else
        {
            NavigateTo("home", showBack: false, pushHistory: false);
        }
    }

    private void UpdateThemeUi()
    {
        RootGrid.RequestedTheme = ThemeService.ElementTheme;
        ApplyTitleBarTheme();
        UpdateMenuState();
    }

    private void ApplyTitleBarTheme()
    {
        try
        {
            var dark = ThemeService.Current == AppTheme.Dark ||
                       (ThemeService.Current == AppTheme.System &&
                        Application.Current.RequestedTheme == ApplicationTheme.Dark);
            var foreground = dark
                ? global::Windows.UI.Color.FromArgb(255, 255, 255, 255)
                : global::Windows.UI.Color.FromArgb(255, 0, 0, 0);
            var inactive = dark
                ? global::Windows.UI.Color.FromArgb(255, 160, 160, 160)
                : global::Windows.UI.Color.FromArgb(255, 96, 96, 96);
            var hover = dark
                ? global::Windows.UI.Color.FromArgb(40, 255, 255, 255)
                : global::Windows.UI.Color.FromArgb(20, 0, 0, 0);
            var pressed = dark
                ? global::Windows.UI.Color.FromArgb(70, 255, 255, 255)
                : global::Windows.UI.Color.FromArgb(40, 0, 0, 0);

            var titleBar = AppWindow.TitleBar;
            try
            {
                titleBar.PreferredTheme = dark ? TitleBarTheme.Dark : TitleBarTheme.Light;
            }
            catch
            {
            }

            titleBar.ButtonBackgroundColor = global::Windows.UI.Color.FromArgb(0, 0, 0, 0);
            titleBar.ButtonInactiveBackgroundColor = global::Windows.UI.Color.FromArgb(0, 0, 0, 0);
            titleBar.ButtonForegroundColor = foreground;
            titleBar.ButtonInactiveForegroundColor = inactive;
            titleBar.ButtonHoverBackgroundColor = hover;
            titleBar.ButtonHoverForegroundColor = foreground;
            titleBar.ButtonPressedBackgroundColor = pressed;
            titleBar.ButtonPressedForegroundColor = foreground;
        }
        catch
        {
        }
    }

    private void UpdateVersionUi()
    {
        VersionText.Text = AppSettings.LegacyHomeUi switch
        {
            "True" => $"欢迎使用  v{ProductInfo.Version}",
            "OnlyVersion" => $"v{ProductInfo.Version}",
            "OnlyAppName" => ProductInfo.AppName,
            _ => $"{ProductInfo.AppName}  v{ProductInfo.Version}",
        };
    }

    public void RefreshShellUi()
    {
        UpdateThemeUi();
        UpdateVersionUi();
    }

    // ------------------------------------------------------------ 菜单
    private static readonly Dictionary<string, string> MenuActionMap = new()
    {
        ["主页"] = "home",
        ["浏览文件…"] = "browse-files",
        ["运行…"] = "run-dialog",
        ["检查 Windows 更新"] = "windows-update",
        ["Windows 更新日志及离线更新包"] = "update-log",
        ["官网下载"] = "download-windows-official",
        ["MSDN 我告诉你"] = "msdn",
        ["UUP Dump (不忘初心)"] = "uupdump",
        ["下载新版本 WFL Tool"] = "download-new-version",
        ["系统修改"] = "system-tweaks",
        ["密钥管理服务"] = "kms",
        ["所有任务"] = "all-tasks",
        ["打开系统属性"] = "system-properties",
        ["设置 Windows 安全问题"] = "windows-security-questions",
        ["功能说明 - 帮助"] = "advanced-help",
        ["修复 Win10/11 开始菜单卡死"] = "fix-start-menu",
        ["禁用命令提示符"] = "cmd-disable",
        ["恢复命令提示符"] = "cmd-restore",
        ["禁用控制面板"] = "cp-disable",
        ["恢复控制面板"] = "cp-restore",
        ["禁用任务管理器"] = "tm-disable",
        ["恢复任务管理器"] = "tm-restore",
        ["查看更多"] = "more",
        ["系统附件"] = "accessories",
        ["选项"] = "settings-page",
        ["清除数据"] = "clear-data-page",
        ["退出"] = "exit-app",
        ["设置"] = "settings",
        ["Windows 安全中心"] = "defender",
        ["Microsoft Store"] = "store",
        ["相机"] = "camera",
        ["相册"] = "photos",
        ["时钟"] = "clock",
        ["查看所有应用"] = "all-apps",
        ["锁定"] = "lock",
        ["切换用户"] = "switch-user",
        ["休眠"] = "sleep",
        ["1 分钟后"] = "timer-60",
        ["5 分钟后"] = "timer-300",
        ["10 分钟后"] = "timer-600",
        ["20 分钟后"] = "timer-1200",
        ["30 分钟后"] = "timer-1800",
        ["1 小时后"] = "timer-3600",
        ["2 小时后"] = "timer-7200",
        ["5 小时后"] = "timer-18000",
        ["12 小时后"] = "timer-43200",
        ["1 天后"] = "timer-86400",
        ["2 天后"] = "timer-172800",
        ["自定义…"] = "timer-custom",
        ["高级选项"] = "timer-advanced",
        ["取消定时关机"] = "shutdown-cancel",
        ["关机"] = "shutdown",
        ["重启"] = "restart",
        ["进入 WinRE"] = "winre",
        ["快速关机"] = "quick-shutdown",
        ["查看更多内部功能"] = "settings-page",
        ["获取帮助"] = "help-center",
        ["发送反馈 (邮箱)"] = "feedback",
        ["设备管理器错误代码帮助"] = "device-error-help",
        ["Windows 帮助和支持"] = "windows-help",
        ["关于"] = "about",
    };

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is MenuFlyoutItem item && MenuActionMap.TryGetValue(item.Text, out var tag))
        {
            ToolActions.Run(tag);
        }
    }

    private void ThemeLight_Click(object sender, RoutedEventArgs e) => SetThemeFromMenu(AppTheme.Light);

    private void ThemeDark_Click(object sender, RoutedEventArgs e) => SetThemeFromMenu(AppTheme.Dark);

    private void ThemeAuto_Click(object sender, RoutedEventArgs e) => SetThemeFromMenu(AppTheme.System);

    private void SetThemeFromMenu(AppTheme theme)
    {
        ThemeService.Set(theme);
        UpdateThemeUi();
        UpdateMenuState();
    }

    private async void AutoUpdateOn_Click(object sender, RoutedEventArgs e)
    {
        ToolActions.Run("windows-auto-update-on");
        await Task.Delay(900);
        UpdateMenuState();
    }

    private async void AutoUpdateOff_Click(object sender, RoutedEventArgs e)
    {
        ToolActions.Run("windows-auto-update-off");
        await Task.Delay(900);
        UpdateMenuState();
    }

    private void UwpExplorer_Click(object sender, RoutedEventArgs e) => ToolActions.Run("uwp-explorer");

    private void MediaPlayer_Click(object sender, RoutedEventArgs e) => ToolActions.Run("media-player");

    private void Battery_Click(object sender, RoutedEventArgs e) => ToolActions.Run("battery-report");

    private void Logoff_Click(object sender, RoutedEventArgs e) => ToolActions.Run("logoff");

    private void UpdateMenuState()
    {
        var theme = ThemeService.Current;
        ThemeLightItem.IsChecked = theme == AppTheme.Light;
        ThemeDarkItem.IsChecked = theme == AppTheme.Dark;
        ThemeAutoItem.IsChecked = theme == AppTheme.System;

        ThemeMenuBarItem.IsEnabled = SystemInfo.CurrentBuild >= 19041;
        ThemeAutoItem.IsEnabled = SystemInfo.CurrentBuild >= 22000;

        UwpExplorerMenuItem.IsEnabled = SystemInfo.CurrentBuild >= 18362;
        BatteryMenuItem.IsEnabled = SystemInfo.CurrentBuild >= 18362;
        SecurityQuestionsMenuItem.IsEnabled = SystemInfo.CurrentBuild >= 19041;

        MediaPlayerMenuItem.Text = SystemInfo.CurrentBuild < 22000 ? "Groove 音乐" : "媒体播放器";
        LogoffMenuItem.Text = (SystemInfo.CurrentBuild == 26200 ||
                               (SystemInfo.CurrentBuild == 26100 && SystemInfo.Ubr >= 8457))
            ? "退出登录"
            : "注销";

        SystemTweaksMenuItem.Visibility = ProductInfo.NewUi is "NSet" or "NSetMod" or "NMod"
            ? Visibility.Collapsed
            : Visibility.Visible;
        SettingsMenuItem.Visibility = AppSettings.EnterpriseNotShow ? Visibility.Collapsed : Visibility.Visible;

        var noAutoUpdate = 0;
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU", false);
            if (key?.GetValue("NoAutoUpdate") is int value)
            {
                noAutoUpdate = value;
            }
        }
        catch
        {
        }

        AutoUpdateOnItem.Text = noAutoUpdate == 1 ? "开启自动更新" : "开启自动更新 (当前)";
        AutoUpdateOffItem.Text = noAutoUpdate == 1 ? "禁用自动更新 (当前)" : "禁用自动更新";
    }

    // ------------------------------------------------------------ 启动参数
    public async void ApplyStartup()
    {
        await Task.Yield();

        var startup = _startup;
        if (startup.ShowDevInfo)
        {
            await DialogService.ShowInfoAsync("配置的 WFL Tool 产品策略",
                $"{ProductInfo.Version}，{ProductInfo.Beta}，{ProductInfo.NewUi}，{ProductInfo.Build}");
            ExitApp();
            return;
        }

        if (startup.ShowHelp)
        {
            await DialogService.ShowInfoAsync("WFL Tool 命令行参数", CommandLineHelp);
            ExitApp();
            return;
        }

        if (startup.OpenRunDialog)
        {
            Launcher.ShowRunDialog(WindowInterop.GetHwnd(this), startup.RunDialogTitle, startup.RunDialogDescription);
            ExitApp();
            return;
        }

        if (startup.Page != "home")
        {
            NavigateTo(startup.Page, showBack: !startup.HideBack, pushHistory: false);
        }

        if (startup.NoMsdt && ContentFrame.Content is MorePage more)
        {
            more.DisableMsdt();
        }
    }

    private const string CommandLineHelp =
        "使用命令行调用本程序即代表你同意本软件的软件许可协议\n\n" +
        "用法: WFLTool.exe [参数]\n\n" +
        "参数:\n" +
        "  /help                 查询 WFL Tool 命令行参数\n" +
        "  /openie               打开 IE 空白页\n" +
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
        "不带任何参数或参数错误则以正常方式打开程序\n\n" +
        "示例：\n  WFLTool.exe /openie https://www.gov.cn";

    // ------------------------------------------------------------ 托盘与退出
    public void SetTrayEnabled(bool enabled)
    {
        if (enabled)
        {
            if (_tray is null)
            {
                var icon = Path.Combine(AppContext.BaseDirectory, "Assets", "xinlogo.ico");
                _tray = new TrayIcon(icon);
            }
        }
        else
        {
            _tray?.Dispose();
            _tray = null;
        }
    }

    public bool IsTrayEnabled => _tray is not null;

    public void ExitApp()
    {
        _exiting = true;
        _tray?.Dispose();
        _tray = null;
        Close();
    }

    private void AppWindow_Changed(AppWindow sender, AppWindowChangedEventArgs args)
    {
        if (!args.DidSizeChange)
        {
            return;
        }

        var scale = WindowInterop.GetDpiScale(this);
        var minWidth = (int)Math.Round(900 * scale);
        var minHeight = (int)Math.Round(600 * scale);
        var size = sender.Size;
        if (size.Width < minWidth || size.Height < minHeight)
        {
            sender.Resize(new SizeInt32(Math.Max(size.Width, minWidth), Math.Max(size.Height, minHeight)));
        }
    }

    private void AppWindow_Closing(AppWindow sender, AppWindowClosingEventArgs args)
    {
        if (_tray is not null && !_exiting)
        {
            args.Cancel = true;
            WindowInterop.Hide(this);
            if (!_trayBalloonShown)
            {
                _trayBalloonShown = true;
                _tray.ShowBalloon("WFL Tool 未完全退出",
                    "你配置了在通知区域显示图标，关闭主界面时不会退出 WFL Tool，如需退出，请在通知区域图标上操作。");
            }
        }
    }

    private void MainWindow_Closed(object sender, WindowEventArgs args)
    {
        if (_currentPage is not null)
        {
            _currentPage.BackRequested -= CurrentPage_BackRequested;
        }
        _tray?.Dispose();
        WindowRegistry.Remove(this);
    }
}
