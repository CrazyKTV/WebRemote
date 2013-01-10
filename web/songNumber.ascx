<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="songNumber.ascx.cs" Inherits="web.songNumber" %>
<link href="css/layout.css" rel="stylesheet" />
<section>
<article>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="bAdd">
        <br />
    <br />
    <asp:Label ID="lSongNumber" runat="server" Text="Song Number: " CssClass="label2"></asp:Label>
    <asp:TextBox ID="tSongNumber" runat="server" Width="74px" CssClass="textbox2"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tSongNumber" Display="Dynamic" ErrorMessage=" Number Only!" ForeColor="Red" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
    <asp:Button ID="bAdd" runat="server" Text="Add" CssClass="button1" OnClick="bAdd_Click" />
    <asp:Button ID="bInsert" runat="server" Text="Insert" CssClass="button1" />
    <br />
</asp:Panel>
</article>
    </section>

