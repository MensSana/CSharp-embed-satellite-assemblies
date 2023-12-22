@echo off
>NUL copy /Y "%~3%1\%~4.resources.dll" "%~2%1"
>NUL del /Q "%~3%1\%~4.resources.dll"
>NUL rmdir /Q "%~3%1"