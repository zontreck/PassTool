#!/bin/bash

# Use the prebuild bootstrap to compile prebuild
chmod +x runprebuild.sh
./runprebuild.sh

# Build Prebuild and SnapWrap
dotnet build -c Release