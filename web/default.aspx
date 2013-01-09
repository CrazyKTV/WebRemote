<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Src="currentList.ascx" TagName="currentList" TagPrefix="uc1" %>
<%@ Register Src="events.ascx" TagName="events" TagPrefix="uc2" %>

<%@ Register Src="actionsMain.ascx" TagName="actionsMain" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1" />
    <!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->

    <link href="css/layout.css" rel="stylesheet" />
    <link href="css/overlay.css" rel="stylesheet" />
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
<body dir='<asp:Literal ID="Literal1" runat="server" Text="<%$Resources: GlobalMessages, directionltr %>"></asp:Literal>'>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <header id="masthead">
                    <nav>

                        <div style="float: left; width: 50%;">
                            <asp:Label ID="Label1" runat="server" Text="Language: " meta:resourcekey="Label1Resource1" CssClass="label1"></asp:Label>
                            &nbsp;<asp:DropDownList ID="language" runat="server" AutoPostBack="True" meta:resourcekey="DropDownList1Resource1" OnSelectedIndexChanged="language_SelectedIndexChanged" CssClass="dropdown1">
                                <asp:ListItem meta:resourcekey="ListItemResource1" Value="en-US"></asp:ListItem>
                                <asp:ListItem meta:resourcekey="ListItemResource2" Value="zh-CHT"></asp:ListItem>
                                <asp:ListItem Value="zh-CHS" meta:resourcekey="ListItemResource3">简体中文</asp:ListItem>
                                <asp:ListItem Value="ja-JP" meta:resourcekey="ListItemResource4">日本語</asp:ListItem>
                                <asp:ListItem Value="ko-KR" meta:resourcekey="ListItemResource5">한국의</asp:ListItem>
                                <asp:ListItem Value="th-TH" meta:resourcekey="ListItemResource6">ภาษาไทย</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>

                            <uc3:actionsMain ID="actionsMain1" runat="server" />



                        </div>
                    </nav>
                </header>
                <br />

                <article id="Action">

                    <section class="events">
                        <uc2:events ID="events1" runat="server" />

                        <h3>
                    </section>
                    <section>

                        <p />

                    </section>
                    
<%--			<aside id="testside">
				<h4>test side</h4>
				<ul>
					<li>
						test1
					</li>
					<li>
						test2
					</li>
				</ul>
			</aside>
			--%>
                </article>


            </ContentTemplate>
        </asp:UpdatePanel>




        
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                <h2>Loading...</h2>
                <img src="Images/ajax-loader.gif" alt="Loading"/>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
       

    </form>
</body>
</html>
