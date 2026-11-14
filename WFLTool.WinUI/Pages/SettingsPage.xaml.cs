using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using WFLTool.Core;

namespace WFLTool.Pages;

public sealed partial class SettingsPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    private bool _initializing = true;
    private bool _initialized;

    public SettingsPage()
    {
        InitializeComponent();
        Loaded += SettingsPage_Loaded;
    }

    private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        InitializeState();
        UpdateResetPromptVisibility();
        DispatcherQueue.TryEnqueue(Microsoft.UI.Dispatching.DispatcherQueuePriority.Low,
            () =>
            {
                RootScroll.ChangeView(0, 0, null, true);
                _initializing = false;
            });
    }

    private void InitializeState()
    {
        ThemeOptions.SelectedIndex = ThemeService.Current switch
        {
            AppTheme.Light => 1,
            AppTheme.Dark => 2,
            _ => 0,
        };

        HomeStyleOptions.SelectedIndex = AppSettings.LegacyHomeUi switch
        {
            "True" => 1,
            "OnlyVersion" => 2,
            "OnlyAppName" => 3,
            _ => 0,
        };

        TopmostSwitch.IsOn = AppSettings.OnTop;
        TraySwitch.IsOn = (WindowRegistry.MainWindow as MainWindow)?.IsTrayEnabled ?? AppSettings.TrayIconOnStartup;

        OpenModeOptions.SelectedIndex = AppSettings.LegacyMoreUi ? 1 : 0;

        if (SystemInfo.CurrentBuild < 22621 && CctOptions.Items.Count > 2)
        {
            CctOptions.Items.RemoveAt(2);
        }
        CctOptions.SelectedIndex = AppSettings.CctButton switch
        {
            "1" => 1,
            "2" when SystemInfo.CurrentBuild >= 22621 => 2,
            _ => 0,
        };

        VersionFooter.Text = $"WFL Tool  v{ProductInfo.Version}  ·  Build {ProductInfo.Build}  ·  {ProductInfo.BetaDisplay}  ·  x64";
    }

    private void UpdateResetPromptVisibility()
    {
        ResetExplorerPromptButton.Visibility = AppSettings.NoMsgReExp ? Visibility.Visible : Visibility.Collapsed;
    }

    private void ThemeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        ThemeService.Set(ThemeOptions.SelectedIndex switch
        {
            1 => AppTheme.Light,
            2 => AppTheme.Dark,
            _ => AppTheme.System,
        });
        (WindowRegistry.MainWindow as MainWindow)?.RefreshShellUi();
    }

    private void HomeStyleOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        AppSettings.Set("LegacyHomeUI", HomeStyleOptions.SelectedIndex switch
        {
            1 => "True",
            2 => "OnlyVersion",
            3 => "OnlyAppName",
            _ => "5",
        });
        (WindowRegistry.MainWindow as MainWindow)?.RefreshShellUi();
    }

    private void TopmostSwitch_Toggled(object sender, RoutedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        var on = TopmostSwitch.IsOn;
        AppSettings.Set("OnTop", on ? "1" : "2");
        if (WindowRegistry.MainWindow is MainWindow shell)
        {
            WindowInterop.SetTopmost(shell, on);
        }
    }

    private async void TraySwitch_Toggled(object sender, RoutedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        var on = TraySwitch.IsOn;
        AppSettings.Set("TrayIcon", on ? "True" : "3");
        (WindowRegistry.MainWindow as MainWindow)?.SetTrayEnabled(on);

        await DialogService.ShowInfoAsync("通知区域图标",
            "设置重启应用生效，但你可以手动临时打开/关闭托盘图标。");
    }

    private void OpenModeOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        if (OpenModeOptions.SelectedIndex == 1)
        {
            AppSettings.Set("LegacyMoreUI", "True");
        }
        else
        {
            AppSettings.Set("LegacyMoreUI", "5");
        }
    }

    private void CctOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_initializing)
        {
            return;
        }

        AppSettings.Set("cctButton", CctOptions.SelectedIndex switch
        {
            1 => "1",
            2 => "2",
            _ => "0",
        });
    }

    private void ResetExplorerPrompt_Click(object sender, RoutedEventArgs e)
    {
        AppSettings.Set("NoMsgReExp", "0");
        UpdateResetPromptVisibility();
    }

    private async void ClearData_Click(object sender, RoutedEventArgs e)
    {
        var confirmed = await DialogService.ConfirmAsync(
            "清除数据并关闭程序",
            "是否要清除数据？清除不会撤回协议同意。此操作会清除应用所有设置并关闭应用。",
            "清除并退出",
            "取消",
            danger: true);
        if (!confirmed)
        {
            return;
        }

        var winAppSdkUi = AppSettings.Get("WinAppSdkUi");
        AppSettings.ClearAll();
        if (winAppSdkUi == "1")
        {
            AppSettings.Set("WinAppSdkUi", "1");
        }

        try
        {
            using var viewer = Registry.CurrentUser.OpenSubKey(@"Software\DBT\WebPageViewer", true);
            if (viewer is not null)
            {
                foreach (var name in new[] { "EWV2webpageURL", "EWV2webpageTitle", "EWV2webpageShowIcon", "EWV2webpageShow", "EWV2webpageClean" })
                {
                    viewer.DeleteValue(name, false);
                }
            }
        }
        catch
        {
        }

        Launcher.Start("cmd.exe",
            "/c rd \"%localappdata%\\WFL Tool\\EWV2viewer\\EWV2viewer.exe.webview2\" /s /q", hidden: true);

        AppSettings.Set("EULA", "CleanData");
        (WindowRegistry.MainWindow as MainWindow)?.ExitApp();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
