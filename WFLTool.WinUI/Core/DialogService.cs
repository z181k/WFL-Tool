using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>ContentDialog 封装，替代旧版 Form16 自定义消息窗口与 MsgBox。</summary>
public static class DialogService
{
    public static XamlRoot? Root => WindowRegistry.MainXamlRoot;

    /// <summary>
    /// WinUI 3 已知问题：ContentDialog 在 ShowAsync 前不显式指定样式时，入场动画会丢失。
    /// 所有对话框在显示前都必须调用此方法。
    /// </summary>
    public static void ApplyDefaultStyle(ContentDialog dialog)
    {
        try
        {
            dialog.Style = (Style)Application.Current.Resources["DefaultContentDialogStyle"];
        }
        catch
        {
        }
    }

    public static async Task<ContentDialogResult> ShowAsync(
        string title,
        string message,
        string primaryText = "确定",
        string? secondaryText = null,
        string? closeText = null,
        ContentDialogButton defaultButton = ContentDialogButton.Primary)
    {
        var root = Root;
        if (root is null)
        {
            return ContentDialogResult.None;
        }

        var text = new TextBlock
        {
            Text = message,
            TextWrapping = TextWrapping.Wrap,
            IsTextSelectionEnabled = true,
        };

        var scroll = new ScrollViewer
        {
            Content = text,
            MaxHeight = 460,
            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
            HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
        };

        var dialog = new ContentDialog
        {
            XamlRoot = root,
            Title = title,
            Content = scroll,
            PrimaryButtonText = primaryText,
            DefaultButton = defaultButton,
        };
        ApplyDefaultStyle(dialog);
        if (!string.IsNullOrEmpty(secondaryText))
        {
            dialog.SecondaryButtonText = secondaryText;
        }
        if (!string.IsNullOrEmpty(closeText))
        {
            dialog.CloseButtonText = closeText;
        }

        return await dialog.ShowAsync();
    }

    public static Task<ContentDialogResult> ShowInfoAsync(string title, string message)
        => ShowAsync(title, message, "确定", closeText: null);

    public static async Task<bool> ConfirmAsync(
        string title,
        string message,
        string primaryText = "继续",
        string closeText = "取消",
        bool danger = false)
    {
        var root = Root;
        if (root is null)
        {
            return false;
        }

        var dialog = new ContentDialog
        {
            XamlRoot = root,
            Title = title,
            Content = new ScrollViewer
            {
                MaxHeight = 460,
                Content = new TextBlock
                {
                    Text = message,
                    TextWrapping = TextWrapping.Wrap,
                    IsTextSelectionEnabled = true,
                },
            },
            PrimaryButtonText = primaryText,
            CloseButtonText = closeText,
            DefaultButton = ContentDialogButton.Close,
        };
        ApplyDefaultStyle(dialog);

        if (danger)
        {
            dialog.PrimaryButtonStyle = (Style)Application.Current.Resources["AccentButtonStyle"];
        }

        var result = await dialog.ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}
