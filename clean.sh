#!/bin/bash

git clean -xfd
git reset --hard

git submodule foreach git clean -xfd
git submodule foreach git reset --hard