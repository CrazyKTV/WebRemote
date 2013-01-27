<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="advanced.ascx.cs" Inherits="web.advanced" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
               <asp:Button ID="Random" runat="server" Text="Random" CssClass="button1" meta:resourcekey="RandomResource1" OnClick="Random_Click" /> 
                <p/><hr style="
    height: 5PX;
    background-color: rgb(73, 72, 72);
    color: rgb(73, 72, 72);
"/>
                <div style="flex-align:center; text-align:center">

                    <asp:Label ID="LToFriend" runat="server" Text="QR to Share with Friends:" CssClass="displayBlock" meta:resourcekey="LToFriendResource1"></asp:Label>
                    <asp:Image ID="ImageQR" runat="server" ImageUrl="GenImage.ashx" Height="160px" Width="160px" CssClass="displayBlock" meta:resourcekey="ImageQRResource1" />
                </div>
                
            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>


