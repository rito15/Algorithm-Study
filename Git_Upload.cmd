:::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::: 깃헙 로컬 -> 웹 업로드 배치파일 :::::::::
:::::::::::::::::::::::::::::::::::::::::::::::::::

@echo off

chcp 65001
cls

set /p memo="업로드 내용 > "

cd .

git pull rito master

git add .

git commit -m "[%date%] %memo%"

git push rito master

echo.======================
echo. 깃헙 업로드 완료 !
echo.======================

pause > nul
