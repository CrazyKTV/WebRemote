<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="currentList.ascx.cs" Inherits="web.currentList" %>
<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>


  <section>
      <article>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:Timer ID="Timer1" runat="server" Interval="180000" OnTick="Timer1_Tick" ></asp:Timer>
            <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
              

                <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowSorting="True" PageSize="1" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" meta:resourcekey="GridView1Resource1">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField><ItemTemplate>
    <%# Container.DataItemIndex + 1  + "."%>
  </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle CssClass="dgLang" HorizontalAlign="Left" ForeColor="#993300" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" meta:resourcekey="BoundFieldResource1" >
            </asp:BoundField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="Song_SongName" meta:resourcekey="BoundFieldResource2">
            <HeaderStyle HorizontalAlign="Left" CssClass="dgSong" />
            <ItemStyle HorizontalAlign="Left" CssClass="dgSong" />
            </asp:BoundField>
            <asp:BoundField DataField="Song_Singer" HeaderText="Singer" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource3">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle HorizontalAlign="Left" CssClass="dgSinger" />
            <ItemStyle CssClass="dgSinger" ForeColor="#993300" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="w#" meta:resourcekey="TemplateFieldResource1" Visible="False">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSong_WordCount" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="lSong_WordCountResource1"></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L" meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>' meta:resourcekey="lSong_LangResource1"></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Insert" Text="Int" meta:resourcekey="ButtonFieldResource1">
            <ControlStyle CssClass="dgInsert" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Right" />
            <ItemStyle CssClass="dgInsert" />
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="gridviewHeader" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle CssClass="gridviewRows" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>


            </asp:Panel>
        </ContentTemplate>
        
<%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Load" />
        </Triggers>--%>
     
    </asp:UpdatePanel>
            
       </article>
   </section>


