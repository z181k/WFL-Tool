using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;

namespace WFLTool.Core;

/// <summary>WinUI3 窗口的 Win32 辅助。</summary>
public static class WindowInterop
{
    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern uint GetDpiForWindow(IntPtr hWnd);

    private static readonly IntPtr HwndTopmost = new(-1);
    private static readonly IntPtr HwndNoTopmost = new(-2);
    private const uint SwpNoSize = 0x0001;
    private const uint SwpNoMove = 0x0002;
    private const uint SwpShowWindow = 0x0040;

    public static IntPtr GetHwnd(Window window)
    {
        var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        return hwnd;
    }

    public static void SetTopmost(Window window, bool topmost)
    {
        try
        {
            var hwnd = GetHwnd(window);
            SetWindowPos(hwnd,
                topmost ? HwndTopmost : HwndNoTopmost,
                0, 0, 0, 0,
                SwpNoMove | SwpNoSize | SwpShowWindow);
        }
        catch
        {
        }
    }

    public static void Activate(Window window)
    {
        try
        {
            var hwnd = GetHwnd(window);
            ShowWindow(hwnd, 9);
            SetForegroundWindow(hwnd);
        }
        catch
        {
        }
    }

    public static void Hide(Window window)
    {
        try
        {
            ShowWindow(GetHwnd(window), 0);
        }
        catch
        {
        }
    }

    public static void Show(Window window)
    {
        try
        {
            ShowWindow(GetHwnd(window), 5);
        }
        catch
        {
        }
    }

    /// <summary>窗口所在显示器的 DPI 缩放比例（1.0 = 96 DPI）。</summary>
    public static double GetDpiScale(Window window)
    {
        try
        {
            var dpi = GetDpiForWindow(GetHwnd(window));
            return dpi > 0 ? dpi / 96.0 : 1.0;
        }
        catch
        {
            return 1.0;
        }
    }
}
