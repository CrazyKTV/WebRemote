<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="events.ascx.cs" Inherits="web.events" %>
<link href="css/layout.css" rel="stylesheet" />
<link href="css/overlay.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
          
<%--            <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="">              
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Button1.jpg"  />
                <div class="button1Text">text</div>               
            </asp:LinkButton>--%>


 <asp:Button ID="Pause" runat="server" Text="Pause" meta:resourcekey="PauseResource1"  /> 
&nbsp;<asp:Button ID="Play" runat="server" Text="Play" meta:resourcekey="PlayResource1" /> 
&nbsp;<asp:Button ID="Cut" runat="server" Text="Cut" meta:resourcekey="CutResource1" /> 
&nbsp;<asp:Button ID="FastFoward" runat="server" Text="FastFoward" meta:resourcekey="FastFowardResource1" /> 
&nbsp;<asp:Button ID="FastBackward" runat="server" Text="FastBackward" meta:resourcekey="FastBackwardResource1" /> 
&nbsp;<asp:Button ID="Mute" runat="server" Text="Mute" meta:resourcekey="MuteResource1" /> 
<hr>
&nbsp;<asp:Button ID="Repeat" runat="server" Text="Mute" meta:resourcekey="RepeatResource1" /> 
<hr>
<asp:Button ID="ToneUp" runat="server" Text="ToneUp" meta:resourcekey="ToneUpResource1" />
<asp:Button ID="ToneDown" runat="server" Text="ToneDown" meta:resourcekey="ToneDownResource1" />
<asp:Button ID="ToneBack" runat="server" Text="ToneBack" meta:resourcekey="ToneBackResource1" />
<hr>
<asp:Button ID="Button4" runat="server" Text="Button" meta:resourcekey="Button4Resource1" />
<asp:Button ID="Button1" runat="server" Text="Button" meta:resourcekey="Button1Resource1" />
<asp:Button ID="Button2" runat="server" Text="Button" meta:resourcekey="Button2Resource1" />



        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>

