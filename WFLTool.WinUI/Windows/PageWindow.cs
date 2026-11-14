using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using WFLTool.Core;
using Windows.Graphics;

namespace WFLTool.Windows;

/// <summary>
/// 旧版“查看更多 / 系统附件”的弹出窗口方式（LegacyMoreUI = True）。
/// 新 UI 默认在 NavigationView 内覆盖显示，并带返回按钮。
/// </summary>
public sealed class PageWindow : Window
{
    private static readonly List<PageWindow> OpenWindows = new();
    private readonly string _tag;

    public PageWindow(string tag)
    {
        _tag = tag;
        Title = tag == "more" ? "查看更多  -  WFL Tool" : "系统附件  -  WFL Tool";

        var root = new Grid();
        var frame = new Frame();
        frame.Content = MainWindow.CreatePageForWindow(tag);
        root.Children.Add(frame);
        Content = root;

        SystemBackdrop = new MicaBackdrop();

        var iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "xinlogo.ico");
        if (File.Exists(iconPath))
        {
            AppWindow.SetIcon(iconPath);
        }

        WindowRegistry.Add(this);
        OpenWindows.Add(this);

        Closed += (_, _) =>
        {
            WindowRegistry.Remove(this);
            OpenWindows.Remove(this);
        };

        try
        {
            var scale = WindowInterop.GetDpiScale(this);
            var area = DisplayArea.GetFromWindowId(AppWindow.Id, DisplayAreaFallback.Primary);
            var work = area.WorkArea;
            var width = Math.Min((int)Math.Round(1040 * scale), (int)(work.Width * 0.92));
            var height = Math.Min((int)Math.Round(760 * scale), (int)(work.Height * 0.92));
            AppWindow.Resize(new SizeInt32(width, height));
            AppWindow.Move(new PointInt32(
                work.X + Math.Max(0, (work.Width - width) / 2),
                work.Y + Math.Max(0, (work.Height - height) / 2)));
        }
        catch
        {
        }
    }

    public static void Open(string tag)
    {
        var existing = OpenWindows.FirstOrDefault(window => window._tag == tag);
        if (existing is not null)
        {
            WindowInterop.Activate(existing);
            return;
        }

        var window = new PageWindow(tag);
        window.Activate();
    }
}
