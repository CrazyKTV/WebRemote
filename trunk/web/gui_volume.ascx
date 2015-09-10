<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gui_volume.ascx.cs" Inherits="web.gui_volume" %>
<link href="css/gui_layout.css" rel="stylesheet" />
<br/>
<asp:Button ID="Mute" runat="server" Text="Mute"  CssClass="button1" OnClick="Mute_Click" meta:resourcekey="MuteResource1" /> 
<asp:Button ID="softer" runat="server" Text="Softer"  CssClass="button1" OnClick="softer_Click" meta:resourcekey="softerResource1" /> 
<asp:Button ID="louder" runat="server" Text="Louder"  CssClass="button1" OnClick="louder_Click" meta:resourcekey="louderResource1" /> 
<asp:Button ID="reset" runat="server" Text="reset" CssClass="button1" OnClick="reset_Click" Visible="False" meta:resourcekey="resetResource1" />  
<asp:Button ID="record" runat="server" Text="Record" CssClass="button1" meta:resourcekey="recordResource1" OnClick="record_Click" /> 
<asp:Button ID="FixVolume" runat="server" Text="Fix Volume" CssClass="button1" OnClick="FixVolume_Click" meta:resourcekey="FixVolumeResource1"  />