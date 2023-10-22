#!/bin/bash

cd Prebuild
./runprebuild.sh
cd ..



dotnet Prebuild/bootstrap/SnapWrap.dll FlutterProject.cs flutter.SnapWrap.yaml System
mv flutter.SnapWrap.yaml source/pubspec.yaml