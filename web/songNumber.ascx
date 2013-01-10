<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="songNumber.ascx.cs" Inherits="web.songNumber" %>
<link href="css/layout.css" rel="stylesheet" />
<section>
<article>
    <br />
    <br />
    <asp:Label ID="lSongNumber" runat="server" Text="Song Number: "></asp:Label>
    <asp:TextBox ID="tSongNumber" runat="server"></asp:TextBox>
    <asp:Button ID="bAdd" runat="server" Text="Add" CssClass="button1" />
    <asp:Button ID="bInsert" runat="server" Text="Insert" CssClass="button1" />
    <br />
</article>
    </section>