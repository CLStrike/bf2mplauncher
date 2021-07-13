@echo off

TASKKILL /IM "Battlefield 2 Multiplayer Launcher.exe" /F
:loop1
timeout /t 1 /nobreak >nul 2>&1
tasklist | find /i "Battlefield 2 Multiplayer Launcher.exe" >nul 2>&1
if errorlevel 1 goto cont1
goto loop1
:cont1
copy /b/v/y "Battlefield 2 Multiplayer Launcher1.exe" "Battlefield 2 Multiplayer Launcher.exe"
"Battlefield 2 Multiplayer Launcher.exe"
exit