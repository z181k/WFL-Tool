### WFL Tool



##### 介绍

WFL Tool 是一款针对 Windows 系统的工具软件，可以快速打开及访问 Windows 系统功能，修改系统隐藏的设置。

将系统分散在各处和隐藏的设置及功能整合，方便 IT 管理员管理及配置设备，还有附带一些常用的功能，方便在应急情况管理及配置设备，浏览设备文件。



### 系统要求与支持策略

##### 目前还在支持的系统

* Windows 10 x64
* Windows 11 x64

##### 已停止支持的系统及其最后一个版本

* Windows Vista、Windows 7、Windows 8、Windows 8.1：[v14.4](https://github.com/z181k/WFL-Tool/releases/tag/14.4)
* Windows XP 及 所有 x86 系统：[v9.20](https://github.com/z181k/WFL-Tool/releases/tag/9.20)

###### 不支持所有Arm架构的Windows



### 其他下载通道

###### [蓝奏云](https://dbtpan.lanzoub.com/b0205vf6f)	[OneDrive 世纪互联](https://medbt-my.sharepoint.cn/:f:/g/personal/dbtob_medbt_partner_onmschina_cn/IgBdYnImsH-5RIqkDkx3h2pCAZaJ_8KKWMkn7g9S3mbt5tM?e=EaTFxL)



### 企业功能

##### 1\. 自动化安装

从版本8.34.8320.1开始支持该功能，但注意Windows XP不能使用

注册表路径：HKEY\_LOCAL\_MACHINE\\SOFTWARE\\DBT\\WFL Tool

值类型：REG\_SZ

值名称：EnterpriseAutoInstall

值：0、1或2

说明：此设置将对所有用户生效，0为默认安装方式，是带界面交互的正常安装模式，当注册表中该值不存在时默认为0；为“1”时是为所有用户安装（需要管理员权限）；为“2”时是为当前用户安装，安装程序在启动时会检查这些值，并进行自动安装（会有界面，注册表值在安装完成后需要手动删除或更改），安装完成后安装界面会自动关闭。

注意：在为为所有用户安装时，实际进行安装操作的进程名称为InAdmin.exe，该进程由安装程序Setup.exe启动后拉起，识别时请注意。

##### 2\. 禁用WFL Tool选项

从版本12.1.9024.3开始支持该功能

注册表路径：HKEY\_LOCAL\_MACHINE\\SOFTWARE\\DBT\\WFL Tool

值类型：REG\_DWORD

值名称：EnterpriseNotShow

值：0或1

说明：此设置将对所有用户生效，0为默认情况，会显示WFL Tool选项，通过WFL Tool选项可以修改WFL Tool的界面以及一些功能实现；1为停用WFL Tool 选项，为该值时WFL Tool选项将会隐藏，将不能再修改WFL Tool的界面及WFL Tool的行为。

##### 3\. 自定义启动界面

从版本13.0.9072.1 Alpha开始支持该功能

注册表路径：HKEY\_CURRENT\_USER\\SOFTWARE\\DBT\\WFL Tool

值类型：REG\_SZ

值名称：ShowSpecifyPage

说明：此功能可以指定应用启动时打开的界面，只能针对每个用户单独设置，该值设置后除指定的界面以外其他界面均无法进入



值		More			Accessories	SystemModifications	ActiveTool

作用		打开“显示更多”	打开“附件”	打开“系统修改”		打开“KMS UI”





### 联系方式

* **邮箱**：z181k@139.com
* **许可协议**：使用前需同意软件许可协议。



##### 版权信息

© 2025 董博涛. 保留所有权利。

