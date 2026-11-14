using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;

namespace WFLTool.Models;

/// <summary>卡片磁贴的数据模型。</summary>
public sealed class ToolItem : INotifyPropertyChanged
{
    private bool _isEnabled = true;

    public string Glyph { get; set; } = "\uE8B7";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Tag { get; set; } = "";
    public string? Badge { get; set; }

    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            if (_isEnabled == value)
            {
                return;
            }
            _isEnabled = value;
            OnPropertyChanged();
        }
    }

    public Visibility BadgeVisibility =>
        string.IsNullOrEmpty(Badge) ? Visibility.Collapsed : Visibility.Visible;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

/// <summary>设置页 / 系统修改页使用的分组模型。</summary>
public sealed class OptionGroup
{
    public string Glyph { get; set; } = "\uE713";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsEnabled { get; set; } = true;
    public List<OptionAction> Actions { get; } = new();
}

public sealed class OptionAction
{
    public string Text { get; set; } = "";
    public string Tag { get; set; } = "";
    public bool IsAccent { get; set; }
    public string? ToolTip { get; set; }
}
