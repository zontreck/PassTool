#!/bin/bash

# Use the prebuild bootstrap to compile prebuild
chmod +x runprebuild.sh
./runprebuild.sh

cd source
flutter build apk
flutter build linux

cd ..