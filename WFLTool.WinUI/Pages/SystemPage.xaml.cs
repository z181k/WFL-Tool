using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using WFLTool.Core;
using WFLTool.Models;

namespace WFLTool.Pages;

public sealed partial class SystemPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public ObservableCollection<OptionGroup> Groups { get; } = new();

    public SystemPage()
    {
        InitializeComponent();
        Build();
        RenderGroups();
        ActualThemeChanged += (_, _) => ReRenderGroups();
    }

    private void ReRenderGroups()
    {
        GroupsPanel.Children.Clear();
        RenderGroups();
    }

    private void Build()
    {
        var build = SystemInfo.CurrentBuild;

        Add("任务栏缩略图大小", "调整任务栏预览缩略图的大小，需要重启资源管理器", "\uE7C4", build <= 26020,
            ("小", "thumb-small"), ("中 (默认)", "thumb-medium"), ("大", "thumb-large"), ("关闭 (Win11 中为超小)", "thumb-off"));

        Add("用户账户控制", "更改 UAC 弹出设置，或彻底关闭用户账户控制", "\uE72E", true,
            ("更改弹出设置", "uac-settings"), ("彻底关闭", "uac-disable"));

        Add("登录时显示信息", "登录界面显示详细登录信息或欢迎语", "\uE77B", true,
            ("显示详细的登录信息", "login-detailed"), ("显示“欢迎” (默认)", "login-welcome"));

        Add("桌面显示 Windows 版本信息水印", "在桌面右下角显示 Windows 版本水印", "\uE7C3", true,
            ("显示", "watermark-show"), ("隐藏 (默认)", "watermark-hide"));

        Add("Win10 通知弹出效果", "Win11 使用有致命 Bug，重启生效", "\uEA8F", build <= 21390,
            ("传统气球效果", "notif-balloon"), ("通知中心效果 (默认)", "notif-center"));

        Add("Windows 10 音量控制界面样式", "切换 Win10 音量控制的界面样式", "\uE767", build <= 21390,
            ("Windows 7 样式", "volume-win7"), ("Windows 10 样式", "volume-win10"));

        Add("Windows 10 电池界面样式", "切换 Win10 电池弹出界面的样式", "\uE83F", build <= 21390,
            ("Windows 7 样式", "battery-win7"), ("Windows 10 样式", "battery-win10"));

        Add("主题更改鼠标指针", "允许或拒绝主题更改鼠标指针", "\uE8D4", true,
            ("允许 (默认)", "cursor-allow"), ("拒绝", "cursor-deny"));

        Add("Windows 10 网络面板",
            "使用前请先到注册表编辑器修改 HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Control Panel\\Settings\\Network 的权限，使 Administrators 组的用户可以写入该项",
            "\uE968", build <= 21390,
            ("默认样式", "network-default"), ("Windows 8 样式", "network-win8"), ("打开设置", "network-settings"));

        Add("MMC 强制适配高 DPI", "界面会更清晰，但会把工具栏图标变小", "\uE7F4", true,
            ("DPI 虚拟化 (默认)", "mmc-default"), ("Win 8 样式缩放", "mmc-highdpi"));

        Add("Windows 11 关闭新打印界面", "当前版本暂不可用（与旧版保持一致）", "\uE749", false,
            ("新 WinUI (默认)", "print-new"), ("传统 Win32", "print-legacy"));

        Add("Windows 10/11 登录界面模糊", "1903 及以上版本可调整登录界面的亚克力模糊", "\uE7F4", build >= 18362,
            ("有模糊 (默认)", "logon-blur"), ("无模糊", "logon-noblur"));

        Add("netplwiz 登录界面", "Windows build 19041 及以上版本；低于该版本默认显示全部", "\uE77B", build >= 19041,
            ("显示全部 (推荐)", "netplwiz-all"), ("不显示全部", "netplwiz-hide"));

        Add("Win10 桌面上下文菜单样式", "仅限 1903 以前的 Windows 10，需要重启资源管理器", "\uE8A1", build < 18362,
            ("传统 Win32", "ctx-classic"), ("支持暗色模式 Win32 (默认)", "ctx-dark"));

        Add("Windows 11 资源管理器上下文菜单", "新 XAML 菜单或原来的 Win32 菜单，需要重启资源管理器", "\uE8A1", build >= 22000,
            ("新 XAML 菜单 (默认)", "win11-menu-xaml"), ("原来的 Win32 菜单", "win11-menu-win32"));

        Add("恢复 Windows 照片查看器", "在 Win11 的控制面板中点击向上箭头可以打开 Win10 的资源管理器", "\uEB9F", true,
            ("恢复 Windows 照片查看器", "restore-photo-viewer"));

        Add("控制面板隐藏项目", "Windows 10 及以上版本控制面板中被隐藏的经典设置入口", "\uE713", build >= 14393,
            ("旧版个性化设置", "old-personalize"), ("颜色设置", "old-colors"),
            ("背景设置", "old-wallpaper"), ("旧版任务栏图标选项", "old-taskbar"));

        Add("任务栏透明度设置教程", "通过注册表调整任务栏的亚克力 / 透明效果", "\uE790", build is >= 14393 and <= 21390,
            ("打开教程", "taskbar-tutorial"));

        Add("资源管理器", "应用上述部分设置后，需要重启资源管理器才会生效", "\uE72C", true,
            ("重启资源管理器", "restart-explorer"));
    }

    private void Add(string title, string description, string glyph, bool enabled, params (string Text, string Tag)[] actions)
    {
        var group = new OptionGroup
        {
            Title = title,
            Description = description,
            Glyph = glyph,
            IsEnabled = enabled,
        };
        foreach (var (text, tag) in actions)
        {
            group.Actions.Add(new OptionAction { Text = text, Tag = tag });
        }
        Groups.Add(group);
    }

    private void RenderGroups()
    {
        var dark = IsDarkTheme();
        var cardBrush = new SolidColorBrush(dark ? Color(0xFF, 0x2D, 0x2D, 0x2D) : Color(0xFF, 0xFF, 0xFF, 0xFF));
        var strokeBrush = new SolidColorBrush(dark ? Color(0x18, 0xFF, 0xFF, 0xFF) : Color(0x14, 0x00, 0x00, 0x00));
        var accentBrush = Application.Current.Resources["AccentTextFillColorPrimaryBrush"] as Brush;
        var titleStyle = Application.Current.Resources["CardTitleTextStyle"] as Style;
        var subtitleStyle = Application.Current.Resources["CardSubtitleTextStyle"] as Style;
        var pillStyle = Application.Current.Resources["PillButtonStyle"] as Style;

        GroupsPanel.Children.Clear();
        GroupsPanel.RowDefinitions.Clear();
        var cardIndex = 0;

        foreach (var group in Groups)
        {
            var panel = new StackPanel { Spacing = 10 };

            var headerGrid = new Grid { ColumnSpacing = 12 };
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            headerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            var icon = new FontIcon
            {
                Glyph = group.Glyph,
                FontSize = 20,
                Foreground = accentBrush,
                VerticalAlignment = VerticalAlignment.Center,
            };
            headerGrid.Children.Add(icon);

            var texts = new StackPanel { Spacing = 2 };
            texts.Children.Add(new TextBlock { Text = group.Title, Style = titleStyle });
            texts.Children.Add(new TextBlock
            {
                Text = group.Description,
                Style = subtitleStyle,
                TextWrapping = TextWrapping.Wrap,
            });
            Grid.SetColumn(texts, 1);
            headerGrid.Children.Add(texts);
            panel.Children.Add(headerGrid);

            var actionsGrid = new Grid { ColumnSpacing = 8, RowSpacing = 8 };
            const int columns = 2;
            for (var i = 0; i < group.Actions.Count; i++)
            {
                var action = group.Actions[i];
                var button = new Button
                {
                    Content = new TextBlock
                    {
                        Text = action.Text,
                        TextWrapping = TextWrapping.Wrap,
                        TextAlignment = TextAlignment.Center,
                    },
                    Tag = action.Tag,
                    Style = pillStyle,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0),
                    IsEnabled = group.IsEnabled,
                };
                button.Click += Option_Click;

                var row = i / columns;
                var column = i % columns;
                while (actionsGrid.RowDefinitions.Count <= row)
                {
                    actionsGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                }
                while (actionsGrid.ColumnDefinitions.Count <= column)
                {
                    actionsGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                }
                Grid.SetRow(button, row);
                Grid.SetColumn(button, column);
                actionsGrid.Children.Add(button);
            }
            panel.Children.Add(actionsGrid);

            var card = new Border
            {
                Background = cardBrush,
                BorderBrush = strokeBrush,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(18, 14, 18, 14),
                Opacity = group.IsEnabled ? 1 : 0.55,
                Child = panel,
            };

            var gridRow = cardIndex / 2;
            while (GroupsPanel.RowDefinitions.Count <= gridRow)
            {
                GroupsPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }
            Grid.SetRow(card, gridRow);
            Grid.SetColumn(card, cardIndex % 2);
            GroupsPanel.Children.Add(card);
            cardIndex++;
        }
    }

    private static global::Windows.UI.Color Color(byte a, byte r, byte g, byte b) => global::Windows.UI.Color.FromArgb(a, r, g, b);

    private bool IsDarkTheme()
    {
        if (ActualTheme == ElementTheme.Dark)
        {
            return true;
        }
        if (ActualTheme == ElementTheme.Light)
        {
            return false;
        }
        return Application.Current.RequestedTheme == ApplicationTheme.Dark;
    }

    private void Option_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            SystemActions.Run(tag);
        }
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        (WindowRegistry.MainWindow as MainWindow)?.ExitApp();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
