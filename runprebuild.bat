cd Prebuild
call compile.bat
cd ..

dotnet Prebuild/bootstrap/prebuild.dll /target vs2022 /excludedir = "obj | bin" /file prebuild.xml
