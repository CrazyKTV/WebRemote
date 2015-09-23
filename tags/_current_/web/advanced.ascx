<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="advanced.ascx.cs" Inherits="web.advanced" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
               <asp:Button ID="Random" runat="server" Text="Random" CssClass="button1columns" meta:resourcekey="RandomResource1" OnClick="Random_Click" /> 
                <asp:Button ID="TxtBadSongs" runat="server" Text="Txt Bad Songs" CssClass="button1columns" OnClick="TxtBadSongs_Click" meta:resourcekey="TxtBadSongsResource1" />
                <asp:Button ID="ShowTime" runat="server" Text="Show Count Time" CssClass="button1columns" meta:resourcekey="ShowTimeResource1" OnClick="ShowTime_Click"/>
                <asp:Button ID="HideConsole" runat="server" Text="Hide Console" CssClass="button1columns" meta:resourcekey="HideConsoleResource1" OnClick="HideConsole_Click" />
                <p/><hr style="
    height: 5PX;
    background-color: rgb(73, 72, 72);
    color: rgb(73, 72, 72);
"/>
                <div style="flex-align:center; text-align:center">

                    <asp:Label ID="LToFriend" runat="server" Text="QR to Share with Friends:" CssClass="displayBlock" meta:resourcekey="LToFriendResource1"></asp:Label>
                    <asp:Image ID="ImageQR" runat="server" ImageUrl="GenImage.ashx" Height="160px" Width="160px" CssClass="displayBlock" meta:resourcekey="ImageQRResource1" />
                </div>
                
                <hr style="
    height: 5PX;
    background-color: rgb(73, 72, 72);
    color: rgb(73, 72, 72);
"/>
                <asp:Button ID="Exit" runat="server" Text="Exit" CssClass="button1columns" OnClick="Exit_Click" meta:resourcekey="ExitResource1"  />
                <asp:Button ID="Close" runat="server" Text="Close" CssClass="button1columns" OnClick="Close_Click" meta:resourcekey="CloseResource1"  />
           
              <hr style="
    height: 5PX;
    background-color: rgb(73, 72, 72);
    color: rgb(73, 72, 72);
"/>
                 <asp:Label ID="LSettingDiv" runat="server" Text="Setting: " meta:resourcekey="LSettingDivResource1"></asp:Label>
                <div style="vertical-align:middle;">
                    <asp:Label ID="LsettingRefreshRate" runat="server" Text="Refresh Rate (s): " meta:resourcekey="LsettingRefreshRateResource1"></asp:Label>
                    <asp:TextBox ID="TsettingRefreshRate" runat="server" CssClass="textbox2" meta:resourcekey="TsettingRefreshRateResource1" OnPreRender="TsettingRefreshRate_PreRender" OnTextChanged="TsettingRefreshRate_TextChanged" Width="65px"></asp:TextBox>
                    <asp:Button ID="BsettingRefreshRate" runat="server" Text="Save"  CssClass="button2" OnClick="BsettingRefreshRate_Click" meta:resourcekey="BsettingRefreshRateResource1"/>
           

                    </div>
                
                 </asp:Panel>



        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>


