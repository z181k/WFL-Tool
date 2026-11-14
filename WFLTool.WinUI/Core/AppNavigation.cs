using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WFLTool.Windows;

namespace WFLTool.Core;

/// <summary>跨页面统一的导航入口。</summary>
public static class AppNavigation
{
    public static MainWindow? Shell => WindowRegistry.MainWindow as MainWindow;

    public static void Open(string tag, bool showBack = true)
    {
        if (Shell is null)
        {
            return;
        }

        if (tag is "more" or "accessories" &&
            AppSettings.LegacyMoreUi &&
            !App.Current.StartupOptions.ForceOverlay &&
            !App.Current.StartupOptions.HideBack)
        {
            PageWindow.Open(tag);
            return;
        }

        Shell.NavigateTo(tag, showBack);
    }
}
