using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WFLTool.Core;
using WFLTool.Models;

namespace WFLTool.Pages;

public sealed partial class MsdtPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public ObservableCollection<ToolItem> Items { get; } = new();

    public MsdtPage()
    {
        InitializeComponent();
        Build();
    }

    private void Build()
    {
        Add("Microsoft Store 应用", "Apps", "\uE719");
        Add("声音", "Audio", "\uE767");
        Add("后台智能传输服务", "BITS", "\uE896");
        Add("电源", "Power", "\uE83F");
        Add("程序兼容性", "PCW", "\uE7B8");
        Add("Internet Explorer 性能", "IEBrowseWEB", "\uE774");
        Add("Internet Explorer 安全", "IESecurity", "\uE72E");
        Add("键盘", "Keyboard", "\uE765");
        Add("网络", "Networking", "\uE968");
        Add("设备", "Device", "\uE772");
        Add("蓝牙", "Bluetooth", "\uE702");
        Add("打印", "Printer", "\uE749");
        Add("搜索", "Search", "\uE721");
        Add("麦克风", "Speech", "\uE720");
        Add("Windows 更新", "WindowsUpdate", "\uE895");
        Add("旧版媒体播放器媒体库", "WindowsMediaPlayerMediaLibrary", "\uE8B7");
        Add("旧版媒体播放器设置", "WindowsMediaPlayerConfiguration", "\uE713");
        Add("视频播放", "Video", "\uE714");
        Add("设备中心", "DeviceCenter", "\uE975");
    }

    private void Add(string title, string package, string glyph)
    {
        Items.Add(new ToolItem
        {
            Glyph = glyph,
            Title = title,
            Description = $"diagnostics\\system\\{package}",
            Tag = package,
        });
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string package)
        {
            Launcher.OpenDiagPackage(package);
        }
    }

    private void LearnMore_Click(object sender, RoutedEventArgs e) => UpdateLinks.OpenMsdtRetire();

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
