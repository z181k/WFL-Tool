using Microsoft.UI.Xaml;

namespace WFLTool.Core;

public enum AppTheme
{
    System,
    Light,
    Dark,
}

/// <summary>主题管理：对应旧版注册表 NColor = White / Dark / Auto。</summary>
public static class ThemeService
{
    public static AppTheme Current
    {
        get
        {
            var value = AppSettings.ColorMode;
            return value switch
            {
                "White" => AppTheme.Light,
                "Dark" => AppTheme.Dark,
                _ => AppTheme.System,
            };
        }
    }

    public static ElementTheme ElementTheme => Current switch
    {
        AppTheme.Light => ElementTheme.Light,
        AppTheme.Dark => ElementTheme.Dark,
        _ => ElementTheme.Default,
    };

    public static string DisplayName => Current switch
    {
        AppTheme.Light => "亮色",
        AppTheme.Dark => "暗色",
        _ => "跟随系统",
    };

    /// <summary>保存并立即应用主题。</summary>
    public static void Set(AppTheme theme)
    {
        AppSettings.ColorMode = theme switch
        {
            AppTheme.Light => "White",
            AppTheme.Dark => "Dark",
            _ => "Auto",
        };
        ApplyAll();
    }

    public static void Cycle()
    {
        Set(Current switch
        {
            AppTheme.System => AppTheme.Light,
            AppTheme.Light => AppTheme.Dark,
            _ => AppTheme.System,
        });
    }

    public static void ApplyAll()
    {
        foreach (var window in WindowRegistry.All)
        {
            if (window.Content is FrameworkElement root)
            {
                root.RequestedTheme = ElementTheme;
            }
        }
    }

    public static void Apply(FrameworkElement root)
    {
        root.RequestedTheme = ElementTheme;
    }
}
