@echo OFF
CLS

echo Troya Engine - Cleaning all solutions...

CD src_dll
START /w src_dll.clean.cmd
CD..
CD src_tools
START /w src_tools.clean.cmd
CD..

REM @pause>nul
exit