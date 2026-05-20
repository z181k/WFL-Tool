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


int main() {
	// 使用标准 main 和 GetCommandLineW 手动解析
	int action = 9; 
	LPWSTR cmdLine = GetCommandLineW();

	// 跳过程序路径，查找参数
	int argc = 0;
	LPWSTR* argv = CommandLineToArgvW(cmdLine, &argc);

	if (argv) {
		for (int i = 1; i < argc; i++) {
			if (wcscmp(argv[i], L"/s") == 0 || wcscmp(argv[i], L"/S") == 0) {
				action = 0; // 快速关机
				break;
			}
			else if (wcscmp(argv[i], L"/r") == 0 || wcscmp(argv[i], L"/R") == 0) {
				action = 1; // 快速重启
				break;
			}
		}
		LocalFree(argv);
	}

	AdjustPrivilege(SE_SHUTDOWN_NAME, TRUE);
	HMODULE hDll = GetModuleHandleA("NtDll.dll");

	if (action == 0) {
		// 快速关机
		TYPE_NtShutdownSystem NtShutdownSystem = (TYPE_NtShutdownSystem)GetProcAddress(hDll, "NtShutdownSystem");
		NtShutdownSystem(ShutdownNoReboot);
	}
	else if (action == 1) {
		// 快速重启
		TYPE_NtShutdownSystem NtShutdownSystem = (TYPE_NtShutdownSystem)GetProcAddress(hDll, "NtShutdownSystem");
		NtShutdownSystem(ShutdownReboot);
	}

	return 0;
}