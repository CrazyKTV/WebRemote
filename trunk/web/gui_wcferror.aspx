<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gui_wcferror.aspx.cs" Inherits="web.gui_wcferror" %>

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
    <link href="css/overlay.css" rel="stylesheet" />

    <!--[if lt IE 9]>
        <script src="Scripts/respond.min.js"></script>
        <script src="Scripts/html5shiv.min.js"></script>
    <![endif]-->

    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/hammer.min.js"></script>

    <meta charset="utf-8" />
    <title>CrazyKTV Wcf 連線錯誤</title>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer" runat="server" Interval="1000" OnTick="Timer_Tick" OnPreRender="Timer_PreRender" ></asp:Timer>
                <asp:HiddenField ID="TimerTotal" runat="server" Value="30" />
                <div class="container" style="margin-top: 25px;">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="panel panel-danger">
                                <div class="panel-heading">CrazyKTV Wcf 連線錯誤</div>
                                <div class="panel-body" style="color:black;">
                                    <div>
                                        <asp:Label ID="WcfError_Label" runat="server" Text="目前無法連線至 WCF 服務,請確認 CrazyKTV 系統設定裡有啟用 WCF 服務, 30 秒後系統將會再次嘗試連線。" />
                                    </div>
                                    <div style="margin-top: 15px;">
                                        <asp:Image ID="WcfError_Image" ImageUrl="images/wcferror.png" runat="server" CssClass="img-responsive" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    
                <asp:UpdateProgress ID="UpdateProgress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel" Visible="false">
                    <ProgressTemplate>
                        <div class="overlay" />
                        <div class="overlayContent" id="overlayContent1">
                            <h2>
                                <asp:Label ID="lLoading" runat="server" Text="載入中..." meta:resourcekey="lLoadingResource1"></asp:Label></h2>
                            <img src="/images/ajax-loader.gif" alt="Loading" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
