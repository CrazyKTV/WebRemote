rem start /wait %CD%\CrazyKTV.exe

start /wait CassiniDev4-console.exe /a:%CD%\web /im:Any /prs:80 /pre:9000

taskkill /f /im CassiniDev4-console.exe