using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>页面导航约定：返回按钮由 MainWindow 统一管理。</summary>
public interface IAppPage
{
    event EventHandler? BackRequested;

    void SetBackVisible(bool visible);
}

public static class FlyoutHelper
{
    /// <summary>在按钮上弹出菜单。</summary>
    public static void ShowMenu(FrameworkElement anchor, IEnumerable<(string Text, Action Action)> items)
    {
        var menu = new MenuFlyout();
        foreach (var (text, action) in items)
        {
            var item = new MenuFlyoutItem { Text = text };
            item.Click += (_, _) => action();
            menu.Items.Add(item);
        }
        menu.ShowAt(anchor);
    }
}
