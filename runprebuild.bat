cd Prebuild
call compile.bat
cd ..



dotnet Prebuild\bootstrap\SnapWrap.dll FlutterProject.cs flutter.SnapWrap.yaml System
move flutter.SnapWrap.yaml source\pubspec.yaml