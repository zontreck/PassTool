@echo off

call runprebuild.bat
dotnet build -c Debug
dotnet build -c Release

dotnet Prebuild\bootstrap\SnapWrap.dll setup.cs setup.SnapWrap.iss System