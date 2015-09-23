<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="apple-touch-icon" href="/images/crazyktv.png" />
    <link rel="apple-touch-icon-precomposed" href="/images/crazyktv.png" />

    <link href="css/gui_layout.css" rel="stylesheet" />
    <link href="css/gui_button.css" rel="stylesheet" />
    <link href="css/gui_overlay.css" rel="stylesheet" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CrazyKTV</title>
</head>
<body>
    <form id="form1" runat="server">

    <div class="alignCenter">
        <asp:Button ID="TUIButton" runat="server" CssClass="PageButton" Text="文字介面" onclick="TUIButton_Click" />
        <asp:Button ID="GUIButton" runat="server" CssClass="PageButton" Text="圖形介面" onclick="GUIButton_Click" />
    </div>

    </form>
</body>
</html>
