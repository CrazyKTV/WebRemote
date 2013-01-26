<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="advanced.ascx.cs" Inherits="web.advanced" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
               <asp:Button ID="Random" runat="server" Text="Random" CssClass="button1" /> 

            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>


