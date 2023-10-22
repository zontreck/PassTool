@echo off

call runprebuild.bat

cd source
call flutter build windows
cd ..

dotnet Prebuild\bootstrap\SnapWrap.dll setup.cs setup.SnapWrap.iss System
iscc setup.SnapWrap.iss