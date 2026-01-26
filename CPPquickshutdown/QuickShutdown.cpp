#include <windows.h>
#include <powrprof.h>
#include <Lm.h>
#include <windef.h>

typedef enum _SHUTDOWN_ACTION
{
	ShutdownNoReboot,
	ShutdownReboot,
	ShutdownPowerOff
} SHUTDOWN_ACTION;

typedef NTSTATUS(NTAPI* TYPE_NtShutdownSystem)(SHUTDOWN_ACTION);
typedef NTSTATUS(NTAPI* TYPE_NtInitiatePowerAction)(
	POWER_ACTION SystemAction,
	SYSTEM_POWER_STATE MinSystemState,
	ULONG Flags,
	BOOLEAN Asynchronous);


DWORD
WINAPI
AdjustPrivilege(LPCWSTR lpPrivilegeName, BOOL fEnable) {

	HANDLE hToken;
	TOKEN_PRIVILEGES NewState;
	LUID luidPrivilegeLUID;


	if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES, &hToken)) /* Open process token */
		return GetLastError();


	if (fEnable == FALSE) /*We disable all the privileges */
	{
		if (!AdjustTokenPrivileges(hToken, TRUE, NULL, 0, NULL, NULL))
			return GetLastError();

		else return ERROR_SUCCESS;
	}
	/*Look up the LUID value of the privilege */
	LookupPrivilegeValue(NULL, lpPrivilegeName, &luidPrivilegeLUID);

	/* Fill the TOKEN_STATE structure*/
	NewState.PrivilegeCount = 1;
	NewState.Privileges[0].Luid = luidPrivilegeLUID;
	NewState.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;


	/* Adjust the process token's privileges */
	if (!AdjustTokenPrivileges(hToken, FALSE, &NewState, 0, NULL, NULL))
		return GetLastError();



	/* We've done successfully, return */
	return ERROR_SUCCESS;
}

//LPCWSTR lpIgnoreBtn = L"更多(&M)";
LPCWSTR lpIgnoreBtn = L"取消(&E)";
LPCWSTR lpAbortBtn = L"快速关机(&S)";
LPCWSTR lpRetryBtn = L"快速重启(&R)";
LRESULT CALLBACK messageBoxHookButton(int nCode, WPARAM wParam, LPARAM lParam) {
	if (nCode < 0)
		return CallNextHookEx(0, nCode, wParam, lParam);

	LPCWPRETSTRUCT msg = (LPCWPRETSTRUCT)lParam;
	if (msg->message == WM_INITDIALOG) {
		HWND btn = GetDlgItem(msg->hwnd, IDIGNORE);
		SetWindowTextW(btn, lpIgnoreBtn);
		btn = GetDlgItem(msg->hwnd, IDABORT);
		SetWindowTextW(btn, lpAbortBtn);
		btn = GetDlgItem(msg->hwnd, IDRETRY);
		SetWindowTextW(btn, lpRetryBtn);
	}

	return CallNextHookEx(0, nCode, wParam, lParam);
}

int main() {
	/*MessageBoxW(
		NULL,                          // 父窗口句柄，NULL表示没有父窗口
		L"点击确定或关闭弹窗后将会执行快速关机，请注意保存您的文件，因关机造成的文件丢失我们概不负责。\n\n此功能使用了 BiliBili@旮沓曼_GT428 的开源代码，详情请见关于界面的更多信息。",                   // 弹窗内容文本
		L"WFL Tool",                   // 弹窗标题
		MB_OK                          // 弹窗样式，这里使用默认的确定按钮
		| MB_ICONINFORMATION
	);*/
	AdjustPrivilege(SE_SHUTDOWN_NAME, TRUE);
	HHOOK hook = SetWindowsHookEx(WH_CALLWNDPROCRET, messageBoxHookButton, 0, GetCurrentThreadId());
	int opt = MessageBoxW(NULL, L"请选择您要执行的操作，请注意保存您的文件，因关机造成的文件丢失我们概不负责。", L"WFL Tool", /*MB_ICONINFORMATION |*/ MB_TOPMOST | MB_ABORTRETRYIGNORE);
	/*manifest的视觉样式，部分情况下添加可能会导致程序异常，比如对话框有图标，所以使用需要测试！！！*/
	UnhookWindowsHookEx(hook);
	HMODULE hDll = GetModuleHandleA("NtDll.dll");

	if (opt == IDIGNORE) return 0;

	/*if (opt == IDIGNORE) {
		lpIgnoreBtn = L"退出(&E)";
		lpAbortBtn = L"睡眠(&S)";
		lpRetryBtn = L"休眠(&H)";
		hook = SetWindowsHookEx(WH_CALLWNDPROCRET, messageBoxHookButton, 0, GetCurrentThreadId());
		opt = MessageBoxW(NULL, L"快 速 黑 屏 v1.0 by GT428\n请选择更多操作：", L"更多操作", MB_ICONINFORMATION | MB_TOPMOST | MB_ABORTRETRYIGNORE);
		UnhookWindowsHookEx(hook);*/
		TYPE_NtInitiatePowerAction NtInitiatePowerAction = (TYPE_NtInitiatePowerAction)GetProcAddress(hDll, "NtInitiatePowerAction");

		/*if (opt == IDIGNORE) return 0;
		if (opt == IDABORT)  NtInitiatePowerAction(PowerActionSleep, PowerSystemSleeping1, 0, TRUE);
		if (opt == IDRETRY)  NtInitiatePowerAction(PowerActionHibernate, PowerSystemHibernate, 0, TRUE);
		return 0;
	}*/

	SHUTDOWN_ACTION sa = opt == IDABORT ? ShutdownNoReboot : ShutdownReboot;


	TYPE_NtShutdownSystem NtShutdownSystem = (TYPE_NtShutdownSystem)GetProcAddress(hDll, "NtShutdownSystem");
	NtShutdownSystem(sa);
	/* 仅供展示调用NtShutdownSystem,相当于
	NtInitiatePowerAction(PowerActionShutdownOff, PowerSystemShutdown, 0, 0); */

	return 0;

}