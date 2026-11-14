using System.Runtime.InteropServices;
using Microsoft.UI.Xaml;

namespace WFLTool.Core;

/// <summary>通知区域图标（替代旧版 Form13 的 NotifyIcon）。使用 Win32 Shell_NotifyIcon 实现。</summary>
public sealed class TrayIcon : IDisposable
{
    private const int WmApp = 0x8000;
    private const int WmTray = WmApp + 1;
    private const int WmRButtonUp = 0x0205;
    private const int WmLButtonUp = 0x0202;
    private const int WmNull = 0x0000;

    private const uint NimAdd = 0x00000000;
    private const uint NimModify = 0x00000001;
    private const uint NimDelete = 0x00000002;
    private const uint NifMessage = 0x00000001;
    private const uint NifIcon = 0x00000002;
    private const uint NifTip = 0x00000004;
    private const uint NifInfo = 0x00000010;

    private const uint MfString = 0x00000000;
    private const uint MfSeparator = 0x00000800;
    private const uint TpmRightButton = 0x0002;
    private const uint TpmReturnCmd = 0x0100;
    private const uint TpmNoNotify = 0x0080;

    private const int ImageIcon = 1;
    private const uint LrLoadFromFile = 0x00000010;
    private const uint LrDefaultSize = 0x00000040;

    private const int IdiApplication = 32512;
    private const int WmDestroy = 0x0002;
    private const int WmClose = 0x0010;
    private const int CsDoubleClicks = 0x0008;
    private const int IdOpen = 1001;
    private const int IdHide = 1002;
    private const int IdExit = 1003;

    private readonly string _className = "WFLToolTrayWindow_" + Guid.NewGuid().ToString("N");
    private readonly WndProcDelegate _wndProc;
    private IntPtr _hwnd;
    private IntPtr _icon;
    private IntPtr _menu;
    private bool _disposed;
    private bool _balloonShown;

    private delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct NotifyIconData
    {
        public int cbSize;
        public IntPtr hWnd;
        public uint uID;
        public uint uFlags;
        public uint uCallbackMessage;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szTip;
        public uint dwState;
        public uint dwStateMask;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szInfo;
        public uint uTimeoutOrVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szInfoTitle;
        public uint dwInfoFlags;
        public Guid guidItem;
        public IntPtr hBalloonIcon;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    private struct WndClassEx
    {
        public uint cbSize;
        public uint style;
        public IntPtr lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string? lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct Point
    {
        public int X;
        public int Y;
    }

    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    private static extern bool Shell_NotifyIcon(uint message, ref NotifyIconData data);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern ushort RegisterClassEx(ref WndClassEx windowClass);

    [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern IntPtr CreateWindowEx(
        uint exStyle, string className, string windowName, uint style,
        int x, int y, int width, int height,
        IntPtr parent, IntPtr menu, IntPtr instance, IntPtr param);

    [DllImport("user32.dll")]
    private static extern IntPtr DefWindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool DestroyWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr LoadImage(IntPtr instance, string name, int type, int cx, int cy, uint flags);

    [DllImport("user32.dll")]
    private static extern IntPtr LoadIcon(IntPtr instance, IntPtr name);

    [DllImport("user32.dll")]
    private static extern bool DestroyIcon(IntPtr icon);

    [DllImport("user32.dll")]
    private static extern IntPtr CreatePopupMenu();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern bool AppendMenu(IntPtr menu, uint flags, IntPtr id, string text);

    [DllImport("user32.dll")]
    private static extern bool DestroyMenu(IntPtr menu);

    [DllImport("user32.dll")]
    private static extern int TrackPopupMenu(
        IntPtr menu, uint flags, int x, int y, int reserved, IntPtr hWnd, IntPtr rect);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out Point point);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr GetModuleHandle(string? moduleName);

    public TrayIcon(string iconPath, string tooltip = "WFL Tool (x64)")
    {
        _wndProc = WindowProc;
        CreateHostWindow();
        LoadTrayIcon(iconPath);
        AddIcon(tooltip);
    }

    private void CreateHostWindow()
    {
        var instance = GetModuleHandle(null);
        var windowClass = new WndClassEx
        {
            cbSize = (uint)Marshal.SizeOf<WndClassEx>(),
            style = CsDoubleClicks,
            lpfnWndProc = Marshal.GetFunctionPointerForDelegate(_wndProc),
            hInstance = instance,
            lpszClassName = _className,
        };
        RegisterClassEx(ref windowClass);
        _hwnd = CreateWindowEx(0, _className, "WFLToolTray", 0, 0, 0, 0, 0,
            IntPtr.Zero, IntPtr.Zero, instance, IntPtr.Zero);
    }

    private void LoadTrayIcon(string iconPath)
    {
        try
        {
            if (File.Exists(iconPath))
            {
                _icon = LoadImage(IntPtr.Zero, iconPath, ImageIcon, 0, 0, LrLoadFromFile | LrDefaultSize);
            }
        }
        catch
        {
        }

        if (_icon == IntPtr.Zero)
        {
            _icon = LoadIcon(IntPtr.Zero, (IntPtr)IdiApplication);
        }
    }

    private void AddIcon(string tooltip)
    {
        if (_hwnd == IntPtr.Zero)
        {
            return;
        }

        var data = new NotifyIconData
        {
            cbSize = Marshal.SizeOf<NotifyIconData>(),
            hWnd = _hwnd,
            uID = 1,
            uFlags = NifMessage | NifIcon | NifTip,
            uCallbackMessage = WmTray,
            hIcon = _icon,
            szTip = tooltip,
            szInfo = "",
            szInfoTitle = "",
            guidItem = Guid.Empty,
        };
        Shell_NotifyIcon(NimAdd, ref data);
    }

    public void ShowBalloon(string title, string text)
    {
        if (_balloonShown || _hwnd == IntPtr.Zero)
        {
            return;
        }
        _balloonShown = true;

        var data = new NotifyIconData
        {
            cbSize = Marshal.SizeOf<NotifyIconData>(),
            hWnd = _hwnd,
            uID = 1,
            uFlags = NifInfo,
            szTip = "",
            szInfo = text,
            szInfoTitle = title,
            uTimeoutOrVersion = 5000,
            dwInfoFlags = 1,
            guidItem = Guid.Empty,
        };
        Shell_NotifyIcon(NimModify, ref data);
    }

    private void BuildMenu()
    {
        _menu = CreatePopupMenu();
        AppendMenu(_menu, MfString, (IntPtr)IdOpen, "打开主页");
        AppendMenu(_menu, MfSeparator, IntPtr.Zero, "");
        AppendMenu(_menu, MfString, (IntPtr)IdHide, "退出通知栏");
        AppendMenu(_menu, MfString, (IntPtr)IdExit, "退出程序");
    }

    private IntPtr WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
    {
        if (msg == WmTray)
        {
            var mouseMessage = (int)(lParam.ToInt64() & 0xFFFF);
            if (mouseMessage == WmLButtonUp)
            {
                ShowMainWindow();
                return IntPtr.Zero;
            }
            if (mouseMessage == WmRButtonUp)
            {
                ShowContextMenu();
                return IntPtr.Zero;
            }
        }

        if (msg == WmDestroy)
        {
            return IntPtr.Zero;
        }

        return DefWindowProc(hWnd, msg, wParam, lParam);
    }

    private void ShowContextMenu()
    {
        BuildMenu();
        GetCursorPos(out var point);
        SetForegroundWindow(_hwnd);
        var command = TrackPopupMenu(_menu, TpmReturnCmd | TpmRightButton | TpmNoNotify,
            point.X, point.Y, 0, _hwnd, IntPtr.Zero);
        PostMessage(_hwnd, WmNull, IntPtr.Zero, IntPtr.Zero);
        DestroyMenu(_menu);
        _menu = IntPtr.Zero;

        switch (command)
        {
            case IdOpen:
                ShowMainWindow();
                break;
            case IdHide:
                Dispose();
                break;
            case IdExit:
                Dispose();
                Application.Current.Exit();
                break;
        }
    }

    private static void ShowMainWindow()
    {
        var window = WindowRegistry.MainWindow;
        if (window is null)
        {
            return;
        }
        WindowInterop.Show(window);
        WindowInterop.Activate(window);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }
        _disposed = true;

        if (_hwnd != IntPtr.Zero)
        {
            var data = new NotifyIconData
            {
                cbSize = Marshal.SizeOf<NotifyIconData>(),
                hWnd = _hwnd,
                uID = 1,
            };
            Shell_NotifyIcon(NimDelete, ref data);
        }

        if (_menu != IntPtr.Zero)
        {
            DestroyMenu(_menu);
            _menu = IntPtr.Zero;
        }

        if (_hwnd != IntPtr.Zero)
        {
            DestroyWindow(_hwnd);
            _hwnd = IntPtr.Zero;
        }

        if (_icon != IntPtr.Zero)
        {
            DestroyIcon(_icon);
            _icon = IntPtr.Zero;
        }
    }
}
