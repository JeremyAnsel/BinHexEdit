@echo off
setlocal

cd "%~dp0"

xcopy dist\ bld\dist\ /E

For %%a in (
"BinHexEdit\BinHexEdit\bin\Release\net48\*.exe"
"BinHexEdit\BinHexEdit\bin\Release\net48\*.exe.config"
) do (
xcopy /s /d "%%~a" bld\dist\
)
