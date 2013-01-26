<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="volume.ascx.cs" Inherits="web.volume" %>
<link href="css/layout.css" rel="stylesheet" />
<br/>
<asp:Button ID="Mute" runat="server" Text="Mute"  CssClass="button1" OnClick="Mute_Click" meta:resourcekey="MuteResource1" /> 
<asp:Button ID="softer" runat="server" Text="softer"  CssClass="button1" OnClick="softer_Click" meta:resourcekey="softerResource1" /> 
<asp:Button ID="louder" runat="server" Text="louder"  CssClass="button1" OnClick="louder_Click" meta:resourcekey="louderResource1" /> 
<asp:Button ID="reset" runat="server" Text="reset" CssClass="button1" OnClick="reset_Click" Visible="False" meta:resourcekey="resetResource1" /> 