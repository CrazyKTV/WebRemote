<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gui_tune.ascx.cs" Inherits="web.gui_tune" %>

<link href="css/gui_layout.css" rel="stylesheet" />

<br/>
<asp:Button ID="tuneUp" runat="server" Text="Tune Up" CssClass="button1" OnClick="tuneUp_Click" meta:resourcekey="tuneUpResource1" /> 
<asp:Button ID="tuneDown" runat="server" Text="Tune Down" CssClass="button1" OnClick="tuneDown_Click" meta:resourcekey="tuneDownResource1" /> 
<asp:Button ID="tuneReset" runat="server" Text="Tune Reset" CssClass="button1" meta:resourcekey="tuneResetResource1" OnClick="tuneReset_Click" /> 
<asp:Button ID="tuneMaleVoice" runat="server" Text="Tune Male Voice" CssClass="button1" meta:resourcekey="tuneMaleVoiceResource1" OnClick="tuneMaleVoice_Click" /> 
<asp:Button ID="tuneWomanVoice" runat="server" Text="Tune Female Voice" CssClass="button1" meta:resourcekey="tuneWomanVoiceResource1" OnClick="tuneWomanVoice_Click" /> 