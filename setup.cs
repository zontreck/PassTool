
using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

string versionInfo = "";
string patch = "";
string commitHash = "";
string AppID = "A2C192B9-68E2-4B5E-A096-941BA8A4F39C";

string CurrentDirectory = Directory.GetCurrentDirectory();

string[] vals;

try
{
    var processStartInfo = new ProcessStartInfo()
    {
        FileName = "git",
        Arguments = "describe --tags",
        RedirectStandardOutput = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    using (var process = new Process())
    {
        process.StartInfo = processStartInfo;
        process.Start();
        vals = process.StandardOutput.ReadToEnd().Trim().Split('-');
        versionInfo = vals[0];
        patch = vals[1];
        commitHash = vals[2];
        process.WaitForExit();
    }
}
catch (Exception ex)
{
    // Handle any exceptions that might occur during process execution
    // Set default values or perform error handling here
    versionInfo = "1.0";
    patch = "0";
    commitHash = "unknown";
}
Console.WriteLine();
Console.WriteLine("; Script Generated By SnapWrap\n" +
$"#define MyAppName \"PassTool\"\n" +
$"#define MyAppVersion \"{versionInfo}.{patch}.0\"\n" +
$"#define MyAppPublisher \"ByteWave Labs\"\n" +
"#define MyAppURL \"https://github.com/zontreck/PassTool\"\n" +
$"#define MyAppExeName \"PassTool.exe\"\n" +
$"\n" +
$"[Setup]\n" +
"AppId={{" + AppID + "}\n" +
"AppName={#MyAppName}\n" +
"AppVersion={#MyAppVersion}\n" +
"AppPublisher={#MyAppPublisher}\n" +
"AppPublisherURL={#MyAppURL}\n" +
"AppSupportURL={#MyAppURL}\n" +
"AppUpdatesURL={#MyAppURL}\n" +
"DefaultDirName={autopf}\\{#MyAppName}\n" +
"DisableProgramGroupPage=yes\n" +
"PrivilegesRequiredOverridesAllowed=dialog\n" +
"OutputDir=setup\n" +
"OutputBaseFilename=PassTool-setup\n" +
$"LicenseFile={Path.Combine(CurrentDirectory, "LICENSE.txt")}\n" +
$"SetupIconFile={Path.Combine(CurrentDirectory, "key.ico")}\n" +
$"Compression=lzma\n" +
$"SolidCompression=yes\n" +
$"WizardStyle=modern\n" +
$"\n" +
$"\n" +
$"[Code]\n" +

"{ ///////////////////////////////////////////////////////////////////// }\n" +
"function GetUninstallString(): String;\n" +
"var\n" +
"  sUnInstPath: String;\n" +
"  sUnInstallString: String;\n" +
"begin\n" +
"  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting(\"AppId\")}_is1');\n" +
"  sUnInstallString := '';\n" + 
"  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then\n" +
"    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);\n" +
"  Result := sUnInstallString;\n" +
"end;\n" +


"{ ///////////////////////////////////////////////////////////////////// }\n" +
"function IsUpgrade(): Boolean;\n" +
"begin\n" +
"  Result := (GetUninstallString() <> '');\n" +
"end;\n" +


"{ ///////////////////////////////////////////////////////////////////// }\n" +
"function UnInstallOldVersion(): Integer;\n" +
"var\n" +
"  sUnInstallString: String;\n" +
"  iResultCode: Integer;\n" +
"begin\n" +
"{ Return Values: }\n" +
"{ 1 - uninstall string is empty }\n" +
"{ 2 - error executing the UnInstallString }\n" +
"{ 3 - successfully executed the UnInstallString }\n" +

"  { default return value }\n" +
"  Result := 0;\n" +

"  { get the uninstall string of the old app }\n" +
"  sUnInstallString := GetUninstallString();\n" +
"  if sUnInstallString <> '' then begin\n" +
"    sUnInstallString := RemoveQuotes(sUnInstallString);\n" +
"    if Exec(sUnInstallString, '/SILENT /NORESTART /SUPPRESSMSGBOXES','', SW_HIDE, ewWaitUntilTerminated, iResultCode) then\n" +
"      Result := 3\n" +
"    else\n" +
"      Result := 2;\n" +
"  end else\n" +
"    Result := 1;\n" +
"end;\n" +

"{ ///////////////////////////////////////////////////////////////////// }\n" +
"procedure CurStepChanged(CurStep: TSetupStep);\n" +
"begin\n" +
"  if (CurStep=ssInstall) then\n" +
"  begin\n" +
"    if (IsUpgrade()) then\n" +
"    begin\n" +
"      UnInstallOldVersion();\n" +
"    end;\n" +
"  end;\n"+
"end;\n"
$"\n" +
$"[Languages]\n" +
$"Name: \"english\"; MessagesFile: \"compiler:Default.isl\"\n" +
$"\n" +
$"\n" +
$"[Tasks]\n" +
$"Name: \"desktopicon\"; Description: \"{{cm:CreateDesktopIcon}}\"; GroupDescription: \"{{cm:AdditionalIcons}}\"; Flags: unchecked\r\n\n" +
$"\n" +
$"[Files]\n" +
$"Source: \"{Path.Combine(Path.Combine(CurrentDirectory, "bin"), "release")}\\*\"; DestDir: \"{{app}}\"; Flags: ignoreversion recursesubdirs createallsubdirs\n" +
$"\n" +
$"[Icons]\n" +
$"Name: \"{{autoprograms}}\\{{#MyAppName}}\"; Filename: \"{{app}}\\{{#MyAppExeName}}\"\n" +
$"Name: \"{{autodesktop}}\\{{#MyAppName}}\"; Filename: \"{{app}}\\{{#MyAppExeName}}\"; Tasks: desktopicon\n" +
$"\n" +
$"\n" +
$"[Run]\n" +
"Filename: \"{app}\\{#MyAppExeName}\"; Description: \"{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}\"; Flags: nowait postinstall skipifsilent"



);

