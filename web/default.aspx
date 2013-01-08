﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="currentList.ascx" tagname="currentList" tagprefix="uc1" %>
<%@ Register src="events.ascx" tagname="events" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1"/>
    <!--css-->

    <link href="css/computer.css" rel="stylesheet" />
    <!--[if lt IE 9]>
        <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <script src="IE9html5.js"></script>
    <![endif]-->
    <!-- Favicons-->
    <!--<link rel="shortcut icon" href="img/favicon.ico">-->
    <script src="jquery-1.8.3.min.js"></script>
    <meta charset="utf-8" />  
    <title>Main Page</title>
</head>
<body dir='<asp:Literal runat="server" Text='<%$Resources: GlobalMessages, directionltr %>'></asp:Literal>'>

    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:DropDownList ID="language" runat="server" AutoPostBack="True" meta:resourcekey="DropDownList1Resource1">
            <asp:ListItem meta:resourcekey="ListItemResource1" Value="en-US">English</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2" Value="zh-CHT">繁體中文</asp:ListItem>
           </asp:DropDownList>
           <br />
           <br />
           <br />
    <div>
    
    
        <uc2:events ID="events1" runat="server" />
    
    
    </div>
    </form>
</body>
</html>
