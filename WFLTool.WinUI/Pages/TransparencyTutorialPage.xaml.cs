using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WFLTool.Core;
using DataTransfer = global::Windows.ApplicationModel.DataTransfer;

namespace WFLTool.Pages;

public sealed partial class TransparencyTutorialPage : Page, IAppPage
{
    public event EventHandler? BackRequested;

    public TransparencyTutorialPage()
    {
        InitializeComponent();
        var path = Path.Combine(AppContext.BaseDirectory, "Assets", "TransparencyTutorial.txt");
        TutorialText.Text = File.Exists(path)
            ? File.ReadAllText(path)
            : "教程文件缺失：Assets\\TransparencyTutorial.txt";
    }

    private void Copy_Click(object sender, RoutedEventArgs e)
    {
        var package = new DataTransfer.DataPackage();
        package.SetText(TutorialText.Text);
        DataTransfer.Clipboard.SetContent(package);
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => BackRequested?.Invoke(this, EventArgs.Empty);

    public void SetBackVisible(bool visible) => BackButton.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
}
