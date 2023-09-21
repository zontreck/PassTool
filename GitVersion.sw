
using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

string versionInfo = "";
string patch = "";
string commitHash = "";

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
Console.WriteLine("using System.Reflection;");
Console.WriteLine("using CS.TPEventsBus.Attributes;");
Console.WriteLine("[assembly: EventBusBroadcastable()]");
Console.WriteLine($"[assembly: AssemblyInformationalVersion(\"{versionInfo}.{patch}-{commitHash}\")]");
Console.WriteLine($"[assembly: AssemblyVersion(\"{versionInfo}.{patch}.0\")]");
Console.WriteLine($"\n" +
"public static class GitVersion\n" +
"{\n" +
$"    public const string Version = \"{versionInfo}.{patch}\";\n" +
$"    public const string FullVersion = \"{versionInfo}.{patch}-{commitHash}\";\n" +
$"    public const string APIVer = \"{versionInfo}\";\n" +
$"    public const string CommitHash = \"{commitHash}\";\n" +
"}\n");
