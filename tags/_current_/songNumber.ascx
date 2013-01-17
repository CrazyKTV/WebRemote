<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="songNumber.ascx.cs" Inherits="web.songNumber" %>
<link href="css/layout.css" rel="stylesheet" />
<section>
<article>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="bAdd" meta:resourcekey="Panel1Resource1">
    <br />
    <asp:Label ID="lSongNumber" runat="server" Text="Song Number: " CssClass="label2" meta:resourcekey="lSongNumberResource1"></asp:Label>
    <asp:TextBox ID="tSongNumber" runat="server" Width="74px" CssClass="textbox2" meta:resourcekey="tSongNumberResource1"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tSongNumber" Display="Dynamic" ErrorMessage=" Number Only!" ForeColor="Red" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)" meta:resourcekey="RegularExpressionValidator1Resource1"></asp:RegularExpressionValidator>
    <asp:Button ID="bAdd" runat="server" Text="Add" CssClass="button1" OnClick="bAdd_Click" meta:resourcekey="bAddResource1" />
    <asp:Button ID="bInsert" runat="server" Text="Insert" CssClass="button1" meta:resourcekey="bInsertResource1" />
    <br />
</asp:Panel>
</article>
    </section>

