:::::::::::::::::::::::::::::::::::::::::::::::::::::
::::::::: .gitignore 변경사항 적용 배치파일 :::::::::
:::::::::::::::::::::::::::::::::::::::::::::::::::::

@echo off

chcp 65001
cls

git rm -r --cached .
git add .

git commit -m "[%date%] Update gitignore"

git push rito master

echo.======================
echo. 깃헙 업로드 완료 !
echo.======================

pause > nul
