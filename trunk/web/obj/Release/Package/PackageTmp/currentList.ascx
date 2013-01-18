<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="currentList.ascx.cs" Inherits="web.currentList" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
                Result Here...</asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>


