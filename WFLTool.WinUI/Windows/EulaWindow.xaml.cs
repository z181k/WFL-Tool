using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.Win32;
using WFLTool.Core;
using Windows.Graphics;

namespace WFLTool.Windows;

/// <summary>替代旧版 Form12 软件许可协议窗口。</summary>
public sealed partial class EulaWindow : Window
{
    private static EulaWindow? _current;
    private readonly bool _readOnly;
    private readonly bool _infoMode;

    public EulaWindow(bool readOnly, string? infoTitle = null, string? infoText = null)
    {
        _readOnly = readOnly;
        _infoMode = infoTitle is not null;
        InitializeComponent();

        Title = _infoMode ? infoTitle! : "软件许可协议  -  WFL Tool";

        if (_infoMode)
        {
            HeadingText.Text = infoTitle!;
            UpdatedText.Visibility = Visibility.Collapsed;
            EulaText.Text = infoText ?? "";
            PromptText.Visibility = Visibility.Collapsed;
            ReadDoneButton.Visibility = Visibility.Collapsed;
            DeclineButton.Visibility = Visibility.Collapsed;
            AcceptButton.Content = "确定";
        }
        else
        {
            var oldLicense = "";
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(@"Software\DBT\WFL Tool", false);
                oldLicense = key?.GetValue("License") as string ?? "";
            }
            catch
            {
            }

            if (oldLicense is "5" or "SetupUser")
            {
                Title = "软件许可协议  -  请注意！协议已更新  -  WFL Tool";
            }

            var eulaPath = Path.Combine(AppContext.BaseDirectory, "Assets", "Eula.txt");
            EulaText.Text = File.Exists(eulaPath)
                ? File.ReadAllText(eulaPath)
                : "软件许可协议文件缺失。";

            if (readOnly)
            {
                ReadDoneButton.Visibility = Visibility.Visible;
                DeclineButton.Visibility = Visibility.Collapsed;
                AcceptButton.Visibility = Visibility.Collapsed;
                PromptText.Visibility = Visibility.Collapsed;
            }
        }

        RootGrid.RequestedTheme = ThemeService.ElementTheme;

        try
        {
            AppWindow.TitleBar.IconShowOptions = IconShowOptions.HideIconAndSystemMenu;
        }
        catch
        {
        }

        WindowRegistry.Add(this);
        Closed += (_, _) =>
        {
            WindowRegistry.Remove(this);
            if (ReferenceEquals(_current, this))
            {
                _current = null;
            }
        };
        if (!_infoMode)
        {
            _current = this;
        }

        try
        {
            var scale = WindowInterop.GetDpiScale(this);
            var area = DisplayArea.GetFromWindowId(AppWindow.Id, DisplayAreaFallback.Primary);
            var work = area.WorkArea;
            var baseWidth = _infoMode ? 600 : 900;
            var baseHeight = _infoMode ? 430 : 760;
            var width = Math.Min((int)Math.Round(baseWidth * scale), (int)(work.Width * 0.92));
            var height = Math.Min((int)Math.Round(baseHeight * scale), (int)(work.Height * 0.92));
            AppWindow.Resize(new SizeInt32(width, height));
            AppWindow.Move(new PointInt32(
                work.X + Math.Max(0, (work.Width - width) / 2),
                work.Y + Math.Max(0, (work.Height - height) / 2)));
        }
        catch
        {
        }
    }

    public static void Show(bool readOnly)
    {
        if (_current is not null)
        {
            WindowInterop.Activate(_current);
            return;
        }

        var window = new EulaWindow(readOnly);
        window.Activate();
    }

    public static void ShowInfo(string title, string text)
    {
        var window = new EulaWindow(false, title, text);
        window.Activate();
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        if (_infoMode)
        {
            Close();
            return;
        }

        AppSettings.Set("EULA", "5");

        var oldLicense = "";
        try
        {
            using var key = Registry.CurrentUser.OpenSubKey(@"Software\DBT\WFL Tool", false);
            oldLicense = key?.GetValue("License") as string ?? "";
        }
        catch
        {
        }

        if (oldLicense is "5" or "SetupUser")
        {
            AppSettings.Set("License", "newEULA");
        }

        Close();
        App.Current.ShowMainWindow();
    }

    private void Decline_Click(object sender, RoutedEventArgs e)
    {
        Close();
        Application.Current.Exit();
    }

    private void ReadDone_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
