@echo off


call flutter doctor
call flutter build windows

iscc setup.iss