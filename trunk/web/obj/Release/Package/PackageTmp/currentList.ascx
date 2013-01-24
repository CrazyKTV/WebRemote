<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="currentList.ascx.cs" Inherits="web.currentList" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server">
              

                <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowSorting="True" PageSize="1" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" >
            </asp:BoundField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="Song_SongName">
            </asp:BoundField>
            <asp:BoundField DataField="Song_Singer" HeaderText="Singer" InsertVisible="False" ReadOnly="True">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle CssClass="dgSong" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="w#">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Song_WordCount") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSong_WordCount" runat="server" Text='<%# Bind("Song_WordCount") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Insert" HeaderText="D" Text="Del">
            <ControlStyle CssClass="dgInsert" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Right" />
            <ItemStyle CssClass="dgInsert" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="gridviewHeader" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>


            </asp:Panel>
        </ContentTemplate>
        
    </asp:UpdatePanel>

       </article>
   </section>


