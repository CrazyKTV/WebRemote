<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="find.ascx.cs" Inherits="web.find" %>

<link href="css/layout.css" rel="stylesheet" />
<%--<br/>--%>
<asp:Panel ID="Panel1" runat="server">
    <asp:DropDownList ID="ddSearchType" runat="server" CssClass="dropdown2">
        <asp:ListItem>Song</asp:ListItem>
        <asp:ListItem>Singer</asp:ListItem>
        <asp:ListItem>Favorites</asp:ListItem>
        <asp:ListItem>Male</asp:ListItem>
        <asp:ListItem>Female</asp:ListItem>
    </asp:DropDownList>


    <asp:TextBox ID="tSearch" runat="server" CssClass="textbox2"></asp:TextBox>


    <asp:Button ID="bSearch" runat="server" Text="List" CssClass="button2" OnClick="bSearch_Click" />



</asp:Panel>

<asp:Panel ID="Panel2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" PageSize="100">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField HeaderText="A" Text="Add" ButtonType="Button" InsertVisible="False">
            <ControlStyle CssClass="dgAdd" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Left" />
            <ItemStyle CssClass="dgAdd" />
            </asp:ButtonField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="SongName">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle CssClass="dgSong" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Singer" InsertVisible="False" ReadOnly="True" DataField="Singer">
            <ControlStyle CssClass="dgSinger" />
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle CssClass="dgSinger" />
            </asp:BoundField>
            <asp:ButtonField HeaderText="I" Text="Int" ButtonType="Button">
            <ControlStyle CssClass="dgInsert" />
            <HeaderStyle HorizontalAlign="Right" CssClass="hideThis" />
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


<asp:Panel ID="Panel3" runat="server">
    choose others here and then link to panel 2<br />
</asp:Panel>



