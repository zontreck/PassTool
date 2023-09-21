
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
$"#define MyAppVersion \"{versionInfo}.{patch}.0-{commitHash}\"\n" +
$"#define MyAppPublisher \"ByteWave Labs\"\n" +
$"#define MyAppExeName \"PassTool.GUI.exe\"\n" +
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
$"Filename: \"{{app}}\\{{#MyAppExeName}}\"; Description: \"{{cm:LaunchProgram,{{#StringChange(MyAppName, '&', '&&')}}\"; Flags: nowait postinstall skipifsilent"



);
