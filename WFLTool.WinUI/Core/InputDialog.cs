using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace WFLTool.Core;

/// <summary>替代旧版 InputUI：自定义关机时间、Conhost / Windows 终端自定义命令。</summary>
public static class InputDialog
{
    public static async Task<(bool Ok, string Text)> ShowTextAsync(
        string title,
        string prompt,
        string description,
        string placeholder = "")
    {
        var root = DialogService.Root;
        if (root is null)
        {
            return (false, "");
        }

        var input = new TextBox
        {
            PlaceholderText = placeholder,
            Text = "",
            Margin = new Thickness(0, 12, 0, 0),
        };

        var panel = new StackPanel
        {
            Spacing = 4,
            MinWidth = 360,
        };
        panel.Children.Add(new TextBlock { Text = prompt, Style = (Style)Application.Current.Resources["BodyStrongTextBlockStyle"] });
        panel.Children.Add(new TextBlock
        {
            Text = description,
            Opacity = 0.7,
            TextWrapping = TextWrapping.Wrap,
        });
        panel.Children.Add(input);

        var dialog = new ContentDialog
        {
            XamlRoot = root,
            Title = title,
            Content = panel,
            PrimaryButtonText = "确定",
            CloseButtonText = "取消",
            DefaultButton = ContentDialogButton.Primary,
        };
        DialogService.ApplyDefaultStyle(dialog);
        input.Loaded += (_, _) => input.Focus(FocusState.Programmatic);

        var result = await dialog.ShowAsync();
        return (result == ContentDialogResult.Primary, input.Text.Trim());
    }

    /// <summary>返回关机延迟（秒）。</summary>
    public static async Task<(bool Ok, long Seconds)> ShowShutdownTimeAsync()
    {
        var root = DialogService.Root;
        if (root is null)
        {
            return (false, 0);
        }

        var input = new TextBox
        {
            PlaceholderText = "请输入整数",
            Margin = new Thickness(0, 12, 0, 0),
        };
        var units = new RadioButtons
        {
            Header = "时间单位",
            Margin = new Thickness(0, 12, 0, 0),
        };
        units.Items.Add("秒");
        units.Items.Add("分钟");
        units.Items.Add("小时");
        units.SelectedIndex = AppSettings.GetInt("ShutTimeUnit", 0) switch
        {
            1 => 1,
            2 => 2,
            _ => 0,
        };

        var error = new TextBlock
        {
            Text = "请输入大于 0 的整数。",
            Foreground = (Microsoft.UI.Xaml.Media.Brush)Application.Current.Resources["SystemFillColorCriticalBrush"],
            Visibility = Visibility.Collapsed,
            Margin = new Thickness(0, 8, 0, 0),
        };

        var panel = new StackPanel { Spacing = 2, MinWidth = 360 };
        panel.Children.Add(new TextBlock { Text = "要在多久后关机？", Style = (Style)Application.Current.Resources["BodyStrongTextBlockStyle"] });
        panel.Children.Add(new TextBlock
        {
            Text = "在下方输入时间，仅支持整数。",
            Opacity = 0.7,
        });
        panel.Children.Add(input);
        panel.Children.Add(units);
        panel.Children.Add(error);

        var dialog = new ContentDialog
        {
            XamlRoot = root,
            Title = "自定义自动关机时间 - WFL Tool",
            Content = panel,
            PrimaryButtonText = "确定",
            CloseButtonText = "取消",
            DefaultButton = ContentDialogButton.Primary,
        };
        DialogService.ApplyDefaultStyle(dialog);

        dialog.PrimaryButtonClick += (_, args) =>
        {
            if (!long.TryParse(input.Text.Trim(), out var value) || value <= 0)
            {
                args.Cancel = true;
                error.Visibility = Visibility.Visible;
            }
        };

        var result = await dialog.ShowAsync();
        if (result != ContentDialogResult.Primary)
        {
            return (false, 0);
        }

        if (!long.TryParse(input.Text.Trim(), out var number) || number <= 0)
        {
            return (false, 0);
        }

        var unit = units.SelectedIndex;
        AppSettings.SetInt("ShutTimeUnit", unit);
        var seconds = unit switch
        {
            1 => number * 60,
            2 => number * 3600,
            _ => number,
        };
        return (true, seconds);
    }
}
