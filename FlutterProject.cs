
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
Console.WriteLine("name: pass_tool\n" + 
"description: Flutter Pass Tool Project\n" + 
"publish_to: 'none'\n" +
$"version: {versionInfo}.{patch}\n" +
"environment:\n" +
"  sdk: ^3.6.1\n" +
"\n\n" +
"dependencies:\n"  + 
"  flutter:\n" +
"    sdk: flutter\n" +
"  cupertino_icons: ^1.0.8\n" +
"  crypto: ^3.0.3\n" +
"  libac_dart:\n" +
"    hosted: https://git.zontreck.com/api/packages/AriasCreations/pub/\n" +
"    version: ^1.4.012225+0413\n" +
"  libacflutter:\n" +
"    hosted: https://git.zontreck.com/api/packages/AriasCreations/pub/\n" +
"    version: ^1.0.13125+0358\n" +
"dev_dependencies:\n" +
"  flutter_test:\n" +
"    sdk: flutter\n" +
"  flutter_lints: ^5.0.0\n" +
"  build_runner:\n" +
"flutter:\n" +
"  uses-material-design: true\n"


);

