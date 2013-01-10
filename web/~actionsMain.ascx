<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="~actionsMain.ascx.cs" Inherits="web.actions" %>
<div>
    <asp:Label ID="Label1" runat="server" Text="Functions: " meta:resourcekey="Label1Resource1"></asp:Label><asp:DropDownList ID="DDActions" runat="server" AutoPostBack="True" meta:resourcekey="DDActionsResource1" CssClass="dropdown1">
    <asp:ListItem meta:resourcekey="ListItemResource1">Find</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource1">Song Number</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource2">Waiting List</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource3">Video</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource4">Volume</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource5">Tune</asp:ListItem>
    <asp:ListItem meta:resourcekey="ListItemResource6">Advance</asp:ListItem>
    </asp:DropDownList>
</div>