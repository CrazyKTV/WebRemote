'Declare the variables. Not mandatory but a best practice
Dim dtmValue, strDate, strTime
Dim objFSO

'Create the file system object for creating folders
Set objFSO = CreateObject("Scripting.FileSystemObject")

'Get current time in to a variable
dtmValue = Now()

'use date /time part functions to create the folder names as required
'Assuming that you are creating these folders in C:\
strDate = Year(dtmValue)  & "-" & Right(String(2, "0") & Month(dtmValue), 2)& "-" & Right(String(2, "0") & Day(dtmValue), 2)
strTime = "_" & Right(String(2, "0") & Hour(dtmValue), 2)& "-" & Right(String(2, "0") & Minute(dtmValue), 2)& "-" & Right(String(2, "0") & Second(dtmValue), 2)


'Wscript.Echo strDate
'Wscript.Echo strTime

currentDirectory = left(WScript.ScriptFullName,(Len(WScript.ScriptFullName))-(len(WScript.ScriptName)))
'WScript.Echo currentDirectory

'Create the folders using objFSO
'First check if folders exists and create only they dont exist
if objFSO.FolderExists(strDate) Then
	if not objFSO.FolderExists(strTime) Then
		objFSO.CreateFolder(strTime)
	End If
Else
	'Create Top level folder first
	objFSO.CreateFolder(currentDirectory & strDate&strTime)

	'Create subfolder
	'objFSO.CreateFolder(strTime)	
End If 