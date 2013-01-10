<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="find.ascx.cs" Inherits="web.video" %>
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>

<link href="css/layout.css" rel="stylesheet" />

<asp:Panel ID="Panel1" runat="server">
    <asp:DropDownList ID="ddSearchType" runat="server" CssClass="dropdown2">
        <asp:ListItem>Song</asp:ListItem>
        <asp:ListItem>Singer</asp:ListItem>
        <asp:ListItem>Favorites</asp:ListItem>
    </asp:DropDownList>


    <asp:TextBox ID="tSearch" runat="server" CssClass="textbox2"></asp:TextBox>


    <asp:Button ID="bSearch" runat="server" Text="List" CssClass="button2" />


</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    result here
</asp:Panel>


