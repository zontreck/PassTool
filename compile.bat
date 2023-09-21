@echo off

call runprebuild.bat
dotnet build -c Debug
dotnet build -c Release