using Microsoft.UI.Xaml;
using WFLTool.Core;
using WFLTool.Windows;

namespace WFLTool;

public partial class App : Application
{
    public static new App Current => (App)Application.Current;

    public StartupOptions StartupOptions { get; private set; } = new();

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        StartupOptions = StartupOptions.Parse(Environment.GetCommandLineArgs().Skip(1).ToArray());

        // 旧版 Loadpga 会确保 OPEN 值存在（用于安装程序识别）。
        if (string.IsNullOrEmpty(AppSettings.Get("OPEN")))
        {
            AppSettings.Set("OPEN", "x64");
        }

        if (StartupOptions.ExitAfterStartup &&
            !StartupOptions.ShowHelp &&
            !StartupOptions.ShowDevInfo &&
            !StartupOptions.OpenRunDialog)
        {
            Exit();
            return;
        }

        if (StartupOptions.EulaOnly)
        {
            var eula = new EulaWindow(readOnly: true);
            eula.Activate();
            return;
        }

        var requireEula = !StartupOptions.HasCommandLine && string.IsNullOrEmpty(AppSettings.Eula);
        if (requireEula)
        {
            var eula = new EulaWindow(readOnly: false);
            eula.Activate();
            return;
        }

        ShowMainWindow();
    }

    public void ShowMainWindow()
    {
        if (WindowRegistry.MainWindow is MainWindow existing)
        {
            WindowInterop.Show(existing);
            WindowInterop.Activate(existing);
            return;
        }

        var window = new MainWindow(StartupOptions);
        WindowRegistry.MainWindow = window;
        WindowRegistry.Add(window);
        window.Activate();
        window.ApplyStartup();
    }
}
