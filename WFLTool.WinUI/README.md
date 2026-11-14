# WFL Tool WinUI 3（Dark UI 重制版）
# 该方案目前已经封存，不得再开发

用 **WinUI 3 / Windows App SDK 2.4.0** 重写的 WFL Tool 界面，覆盖原 `Dark` 项目中的全部窗体。
版本：**17.5 · Build 9824.1**

## 环境要求

- Windows 10 1809+ / Windows 11 x64
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows App Runtime **2.x**（2.4.0 或更高，2.6.4 已实测兼容）
- WebView2 Runtime（“检查更新 / 开源地址 / 帮助”等内嵌网页需要）

## 构建

本项目为框架依赖构建（`SelfContained=false`、`WindowsAppSDKSelfContained=false`），不会自带 .NET 或 Windows App Runtime；目标机需要安装 .NET 10 Desktop Runtime 和 Windows App Runtime 2.x（2.4.0 或更高）。

```powershell
cd WinUI3\WFLTool.WinUI
dotnet build -c Debug
```

生成目录：

```
bin\Debug\net10.0-windows10.0.19041.0\win-x64\WFLTool.exe

```

### 构建工具与 PRI

项目使用 Visual Studio Build Tools 自带的 AppxPackage MSBuild 任务生成 `WFLTool.pri`。
`csproj` 中的 `AppxMSBuildToolsPath` 默认指向本机的
`D:\VSBuildTools\MSBuild\Microsoft\VisualStudio\v17.0\AppxPackage\`，
如果 Build Tools 安装在别处，可通过同名 MSBuild 属性覆盖：

```powershell
dotnet build -c Debug -p:AppxMSBuildToolsPath="<VS>\MSBuild\Microsoft\VisualStudio\v17.0\AppxPackage\"
```

### 发布（框架依赖，不自带运行时）

```powershell
dotnet publish -c Release -r win-x64 --self-contained false `
  -p:WindowsAppSDKSelfContained=false -p:DebugType=None -o ..\publish
```

**不包含 .NET 运行时或 Windows App Runtime**。目标机需要预装：

- .NET 10 Desktop Runtime
- Windows App Runtime 2.x（2.4.0 或更高）
- WebView2 Runtime（内嵌网页功能需要）


## 窗体迁移对照

| 旧版 WinForms | WinUI 3 |
| --- | --- |
| Form1 主界面 | `MainWindow` + `HomePage` + 顶部菜单栏 |
| Form2 查看更多 | `MorePage` |
| Form4 内嵌浏览器 | 调用 `EWV2Viewer`（不再是自建 WebView2 窗口） |
| Form5 系统附件 | `AccessoriesPage` |
| Form6 任务栏透明度教程 | `TransparencyTutorialPage` |
| Form7 系统修改 | `SystemPage` |
| Form8 关闭 UAC 警告 | `UacWarningDialog`（ContentDialog） |
| Form9 关于 | `AboutPage` |
| Form10 密钥管理服务 | `KmsPage` |
| Form11 清除数据 | `SettingsPage` 中的清除数据 |
| Form12 软件许可协议 | `EulaWindow` |
| Form13 托盘图标 | `TrayIcon`（Win32 Shell_NotifyIcon） |
| Form14 MSDT 疑难解答 | `MsdtPage` |
| Form15 开机启动项 | `StartupDialog` |
| Form16 自定义对话框 | `DialogService` / `InputDialog` |
| InputUI 输入框 | `InputDialog`（关机时间 / Conhost / 终端命令） |
| Loadpga 启动与命令行 | `App.OnLaunched` + `StartupOptions` |
| NewSets 选项 | `SettingsPage` |
| Form6/Form12 长文本 | `Assets/TransparencyTutorial.txt`、`Assets/Eula.txt` |

## 与旧版兼容

- 设置仍保存在 `HKCU\Software\DBT\WFL Tool`（`NColor`、`OnTop`、`TrayIcon`、`LegacyMoreUI`、
  `cctButton`、`EULA`、`Preview`、`ShutTimeUnit` 等）。
- 企业策略 `HKLM\Software\DBT\WFL Tool\EnterpriseNotShow` 仍然生效。
- 命令行参数保持兼容：`/help`、`/openie [url]`、`/more [msdt|nomsdt]`、`/kmsui`、`/ActiveTool`、
  `/modsys`、`/SystemModifications`、`/Accessories`、`/about [eula]`、`/run [ori]`、`/sets`。
- 所有系统操作继续调用系统自带程序（`slmgr.vbs`、`gpedit.msc`、`taskmgr.exe`、`shutdown.exe` 等）。

## 目录结构

```
WFLTool.WinUI/
  App.xaml(.cs)          应用入口、首次运行 EULA、启动参数
  MainWindow.xaml(.cs)   标题栏、五菜单、页面宿主、主题、托盘
  Assets/                图标、EULA、教程文本
  Core/                  设置、系统信息、启动器、主题、托盘、对话框、命令分发
  Models/                卡片与设置组模型
  Pages/                 主页、查看更多、附件、系统修改、KMS、关于、选项、MSDT 等
  Windows/               EULA、旧版弹出页面窗口
```

## 在线内容与 EWV2Viewer

帮助、更新日志、开源地址等网页统一写入 `HKCU\Software\DBT\WebPageViewer` 后调用 `EWV2viewer\EWV2viewer.exe`，与旧版一致；不再在应用内自建 WebView2 窗口。发布时把 `EWV2viewer` 文件夹放在 `WFLTool.exe` 同目录即可。

## 备注

- 由于维护复杂性增加，WinUI版本的WFL Tool不再维护及任何开发行为
- 98xx这系列的build是给WinUI版本App开发预留，停止开发后不要复用这段build号，WinForm版本可以继续使用96xx、97xx、99xx等构建号
