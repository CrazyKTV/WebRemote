<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web._default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register src="currentList.ascx" tagname="currentList" tagprefix="uc1" %>
<%@ Register src="events.ascx" tagname="events" tagprefix="uc2" %>

<%@ Register src="actionsMain.ascx" tagname="actionsMain" tagprefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--Mobile specific meta goodness-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1"/>
    <!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->

    <link href="css/layout.css" rel="stylesheet" />
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

        <header id="masthead">
			 <nav>   
                 <asp:Label ID="Label1" runat="server" Text="Language: "></asp:Label>
&nbsp;<asp:DropDownList ID="language" runat="server" AutoPostBack="True" meta:resourcekey="DropDownList1Resource1">
            <asp:ListItem meta:resourcekey="ListItemResource1" Value="en-US">English</asp:ListItem>
            <asp:ListItem meta:resourcekey="ListItemResource2" Value="zh-CHT">繁體中文</asp:ListItem>
                     <asp:ListItem Value="zh-CHS">简体中文</asp:ListItem>
                     <asp:ListItem Value="JP">日本語</asp:ListItem>
                     <asp:ListItem Value="KN">한국의</asp:ListItem>
                     <asp:ListItem Value="THAI">ภาษาไทย</asp:ListItem>
           </asp:DropDownList>
			    <uc3:actionsMain ID="actionsMain1" runat="server" />
			</nav>
		</header>
    
           <br />
           <br />
           <br />
    <div>
    <article id="MainDisplay">
    </article>


    <article id="Action">
			<section class="events">
			
        <uc2:events ID="events1" runat="server" />

			</section>
			
			<section>

				<p>...</p>

			</section>
			<!--
			<aside id="testside">
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
			-->
		</article>


    
    
    </div>
    </form>
</body>
</html>
