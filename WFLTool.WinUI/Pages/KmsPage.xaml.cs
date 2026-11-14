using System.Collections.ObjectModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WFLTool.Core;

namespace WFLTool.Pages;

public sealed partial class KmsPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public sealed class EditionItem
    {
        public string Title { get; set; } = "";
        public string Tag { get; set; } = "";
    }

    public ObservableCollection<EditionItem> Editions { get; } = new();

    public KmsPage()
    {
        InitializeComponent();
        Editions.Add(new EditionItem { Title = "专业版", Tag = "W269N-WFGWX-YVC9B-4J6C9-T83GX" });
        Editions.Add(new EditionItem { Title = "专业教育版", Tag = "6TP4R-GNPTD-KYYHQ-7B7DP-J447Y" });
        Editions.Add(new EditionItem { Title = "专业工作站版", Tag = "NRG8B-VKKQ-CXVCJ-9G2XF-6Q84J" });
        Editions.Add(new EditionItem { Title = "教育版", Tag = "NW6C2-QMPVW-D7KKK-3GKT6-VCFB2" });
        Editions.Add(new EditionItem { Title = "企业版", Tag = "NPPR9-FWDCX-D2C8J-H872K-2YT43" });
    }

    private async void Status_Click(object sender, RoutedEventArgs e)
    {
        Launcher.Start("cmd.exe",
            $"/c start WSCRIPT.EXE {Path.Combine(Launcher.System32, "slmgr.vbs")} /dlv&timeout /t 5&start wscript.exe {Path.Combine(Launcher.System32, "slmgr.vbs")} /xpr");
        await Task.CompletedTask;
    }

    private void Activate_Click(object sender, RoutedEventArgs e) => Launcher.RunSlmgr("/ato", runAs: false);

    private void UninstallKey_Click(object sender, RoutedEventArgs e) => Launcher.RunSlmgr("/upk", runAs: false);

    private void Rearm_Click(object sender, RoutedEventArgs e) => Launcher.RunSlmgr("/rearm");

    private void PhoneActivate_Click(object sender, RoutedEventArgs e) => Launcher.Start("Slui.EXE", "4", runAs: true);

    private async void InstallKey_Click(object sender, RoutedEventArgs e)
    {
        var key = InputBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(key))
        {
            await DialogService.ShowInfoAsync("密钥安装", "请在输入框提供信息");
            return;
        }

        Launcher.RunSlmgr("/ipk " + key);
        InputBox.Text = "";
    }

    private async void SetKms_Click(object sender, RoutedEventArgs e)
    {
        var address = InputBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(address))
        {
            await DialogService.ShowInfoAsync("KMS 地址", "请在下方输入框提供信息");
            return;
        }

        Launcher.RunSlmgr("/skms " + address);
        InputBox.Text = "";
    }

    private void Edition_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string key)
        {
            Launcher.RunSlmgr("/ipk " + key);
        }
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
