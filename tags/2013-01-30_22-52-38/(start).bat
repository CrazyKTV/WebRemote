
start CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000
start /wait %CD%\CrazyKTV.exe


rem CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000
rem start /wait %CD%\CrazyKTV.exe

taskkill /f /im CassiniDev4-console.exe