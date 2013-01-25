<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="find.ascx.cs" Inherits="web.find" %>

<link href="css/layout.css" rel="stylesheet" />
<%--<br/>--%>
<asp:Panel ID="Panel1" runat="server">
    <asp:DropDownList ID="ddSearchType" runat="server" CssClass="dropdown2">
        <asp:ListItem Value="Song">Song Name</asp:ListItem>
        <asp:ListItem>Singer</asp:ListItem>
        <asp:ListItem Value="WordCount">Word Count</asp:ListItem>
        <asp:ListItem Value="TopOrder">Top Order</asp:ListItem>
        <asp:ListItem>Favorites</asp:ListItem>
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
        <asp:ListItem>Chorus</asp:ListItem>
        <asp:ListItem Value="NewSongs">New Songs</asp:ListItem>
    </asp:DropDownList>
        
    <asp:TextBox ID="tSearch" runat="server" CssClass="textbox2"></asp:TextBox>

    <asp:Button ID="bSearch" runat="server" Text="List" CssClass="button2" OnClick="bSearch_Click" />



</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowSorting="True" PageSize="1" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" EnableSortingAndPagingCallbacks="True" OnSorting="GridView1_Sorting" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField HeaderText="A" Text="Add" ButtonType="Button" InsertVisible="False" CommandName="Add" >
            <ControlStyle CssClass="dgAdd" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Left" />
            <ItemStyle CssClass="dgAdd" />
            </asp:ButtonField>
            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" >
            </asp:BoundField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="Song_SongName">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle CssClass="dgSong" />
            <ItemStyle CssClass="dgSong" />
            </asp:BoundField>
            <asp:BoundField DataField="Song_Singer" HeaderText="Singer" InsertVisible="False" ReadOnly="True">
            <ControlStyle CssClass="dgSinger" />
            <HeaderStyle HorizontalAlign="Left" CssClass="dgSinger" />
            <ItemStyle CssClass="dgSinger" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="w#">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Song_WordCount") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSong_WordCount" runat="server" Text='<%# Bind("Song_WordCount") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="dgLang" />
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Insert" HeaderText="I" Text="Int">
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
    <div style="text-align: center ;">
    <asp:Button ID="BPrevious" runat="server" Text="Previous" CssClass="button3" OnClick="BPrevious_Click" Visible="False" />
    <asp:Button ID="BNext" runat="server" Text="Next" CssClass="button3" OnClick="BNext_Click" Visible="False" />
        
    
        </div>
    <asp:HiddenField ID="songDGpage" runat="server" Value="0" />
    <br/>
</asp:Panel>


<asp:Panel ID="Panel3" runat="server" Visible="False">
    <asp:GridView ID="GridView2" runat="server" DataKeyNames="User_Name,User_Id" AutoGenerateColumns="False" CssClass="gridview" AllowSorting="True" PageSize="1" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnRowCommand="GridView2_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="User_Id" DataField="User_Id" Visible="False" >
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Select" DataTextField="User_Name" HeaderText="Select" InsertVisible="False" ControlStyle-CssClass="button1">
            <ControlStyle CssClass="button1" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center"/>
            </asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="gridviewHeader" />
    </asp:GridView>
    <br />
</asp:Panel>



