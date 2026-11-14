using Microsoft.UI.Xaml;

namespace WFLTool.Core;

/// <summary>记录所有打开的窗口，供主题切换与统一关闭使用。</summary>
public static class WindowRegistry
{
    private static readonly List<Window> Windows = new();

    public static IReadOnlyList<Window> All => Windows;

    public static void Add(Window window)
    {
        if (!Windows.Contains(window))
        {
            Windows.Add(window);
        }
    }

    public static void Remove(Window window)
    {
        Windows.Remove(window);
    }

    public static Window? MainWindow { get; set; }

    public static XamlRoot? MainXamlRoot => (MainWindow?.Content as FrameworkElement)?.XamlRoot;
}
