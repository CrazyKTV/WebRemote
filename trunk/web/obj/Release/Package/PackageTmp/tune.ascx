﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tune.ascx.cs" Inherits="web.tune" %>

<link href="css/layout.css" rel="stylesheet" />

<br/>
<asp:Button ID="tuneUp" runat="server" Text="Tune Up" CssClass="button1" OnClick="tuneUp_Click" /> 
<asp:Button ID="tuneDown" runat="server" Text="Tune Down" CssClass="button1" OnClick="tuneDown_Click" /> 
<asp:Button ID="tuneReset" runat="server" Text="Tune Reset" CssClass="button1" Visible="False" /> 