<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="actionsMain.ascx.cs" Inherits="web.actions" %>
<div>
    <asp:Label ID="Label1" runat="server" Text="Functions: "></asp:Label><asp:DropDownList ID="DDActions" runat="server" AutoPostBack="True">
    <asp:ListItem>Order Songs</asp:ListItem>
    <asp:ListItem>video</asp:ListItem>
    <asp:ListItem>volume</asp:ListItem>
    <asp:ListItem>tune</asp:ListItem>
    </asp:DropDownList>
</div>