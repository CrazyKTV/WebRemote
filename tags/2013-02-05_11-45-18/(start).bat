<<<<<<< .mine
rem "Please... no SPACE for your folder name"
start %CD%\CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000
=======
@echo off
IPCONFIG |FIND "IP" > %temp%\TEMPIP.txt
FOR /F "tokens=2 delims=:" %%a in (%temp%\TEMPIP.txt) do set IP=%%a
del %temp%\TEMPIP.txt
set IP=%IP:~1%
echo %IP% >%temp%\ip.txt
echo 等一下啟動crazyKTV後,請在其他的裝置(iphone,ipad,android,筆電,平板...)上用 網頁瀏覽器 到這個網址:
echo ---------------------------------------------------------------------------
echo http://%IP%
echo ---------------------------------------------------------------------------
echo 請按任何鍵繼續開啟 CrazyKTV...
del %temp%\ip.txt
pause


start CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000
>>>>>>> .r22862
start /wait %CD%\CrazyKTV.exe
taskkill /f /im CassiniDev4-console.exe