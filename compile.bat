@echo off

call runprebuild.bat

dotnet Prebuild\bootstrap\SnapWrap.dll FlutterProject.cs flutter.SnapWrap.yaml System
move flutter.SnapWrap.yaml source\pubspec.yaml

cd source
flutter build windows
cd ..

dotnet Prebuild\bootstrap\SnapWrap.dll setup.cs setup.SnapWrap.iss System
iscc setup.SnapWrap.iss