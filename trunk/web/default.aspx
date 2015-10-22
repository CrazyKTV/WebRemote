<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="/images/favicon.ico" type="image/x-icon" />
    <link rel="apple-touch-icon" href="/images/crazyktv.png" />
    <link rel="apple-touch-icon-precomposed" href="/images/crazyktv.png" />

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="user-scalable=no, width=device-width, initial-scale=1, maximum-scale=1" />
    <!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->

    <link href="Content/bootstrap.min.css" rel="stylesheet" /> 
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" /> 
    <link href="css/gui_layout.css" rel="stylesheet" />

    <!--[if lt IE 9]>
        <script src="Scripts/respond.min.js"></script>
        <script src="Scripts/html5shiv.min.js"></script>
    <![endif]-->

    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/hammer.min.js"></script>

    <meta charset="utf-8" />
    <title>CrazyKTV</title>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 25px;">
            <div class="row">
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <asp:LinkButton ID="TUIButton" runat="server" CssClass="btn btn-primary btn-lg" OnClick="TUIButton_Click">
                        <asp:Image ImageUrl="images/interface_tui.png" runat="server" CssClass="MainMenuImage"/>
                        <div style="margin-top: 10px;"></div>
                        <asp:Label runat="server" Text="文字介面" CssClass="MainMenuLabel" meta:resourcekey="TUIButton_RES" />
                    </asp:LinkButton>
                </div>
                <div class="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                    <asp:LinkButton ID="GUIButton" runat="server" CssClass="btn btn-primary btn-lg" OnClick="GUIButton_Click">
                        <asp:Image ImageUrl="images/interface_gui.png" runat="server" CssClass="MainMenuImage"/>
                        <div style="margin-top: 10px;"></div>
                        <asp:Label runat="server" Text="圖形介面" CssClass="MainMenuLabel" meta:resourcekey="GUIButton_RES" />
                    </asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
