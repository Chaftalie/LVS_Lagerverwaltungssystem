@echo off
color a
echo C:\Windows\System32\cmd.exe /E:ON /K C:\Ruby25-x64\bin\setrbvars.cmd
cls
echo         ===========================================
echo         *             RUBY - MONITOR              *
echo         *         LIFE SASS-CSS WATCHDOG          *
echo         * COMPATIBLE WITH *.SCSS and *.SASS FILES *
echo         *                                         *
echo         *           CLOSE WITH CTRL + C           * 
echo         ===========================================
echo.
S:
cd /D S:\XAMPP\htdocs\LVS_Web
sass --watch sass:css

pause >nul