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
echo ���@�U�Ұ�crazyKTV��,�Цb��L���˸m(iphone,ipad,android,���q,���O...)�W�� �����s���� ��o�Ӻ��}:
echo ---------------------------------------------------------------------------
echo http://%IP%
echo ---------------------------------------------------------------------------
echo �Ы��������~��}�� CrazyKTV...
del %temp%\ip.txt
pause


start CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000
>>>>>>> .r22862
start /wait %CD%\CrazyKTV.exe
taskkill /f /im CassiniDev4-console.exe