<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="find.ascx.cs" Inherits="web.find" %>


<link href="css/layout.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<%--<br/>--%>
<asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
    <asp:DropDownList ID="ddSearchType" runat="server" CssClass="dropdown2" meta:resourcekey="ddSearchTypeResource1">
        <asp:ListItem Value="Song" meta:resourcekey="ListItemResource1" Text="Song Name"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource2" Text="Singer" Value="Singer"></asp:ListItem>
        <asp:ListItem  Text="--------------"></asp:ListItem>
        <asp:ListItem Value="WordCount" meta:resourcekey="ListItemResource3" Text="Word Count"></asp:ListItem>        
        <asp:ListItem Value="NewSongs" meta:resourcekey="ListItemResource4" Text="New Songs"></asp:ListItem>
        <asp:ListItem Value="TopOrder" meta:resourcekey="ListItemResource5" Text="Top Order"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource6" Text="Favorites"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource7" Text="Male"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource8" Text="Female"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource9" Text="Group"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource10" Text="Chorus"></asp:ListItem>
        <asp:ListItem Value="Mandarin" meta:resourcekey="ListItemResource11" Text="Mandarin"></asp:ListItem>
        <asp:ListItem Value="Taiwanese" meta:resourcekey="ListItemResource12" Text="Taiwanese"></asp:ListItem>
        <asp:ListItem Value="Cantonese" meta:resourcekey="ListItemResource13" Text="Cantonese"></asp:ListItem>
        <asp:ListItem Value="Japanese" meta:resourcekey="ListItemResource14" Text="Japanese"></asp:ListItem>
        <asp:ListItem Value="English" meta:resourcekey="ListItemResource15" Text="English"></asp:ListItem>
        <asp:ListItem Value="OtherLangs" meta:resourcekey="ListItemResource16" Text="Other Langs"></asp:ListItem>
    </asp:DropDownList>
        
    <asp:TextBox ID="tSearch" runat="server" CssClass="textbox2" meta:resourcekey="tSearchResource1" Width="120px"></asp:TextBox>

<%--    <asp:TextBoxWatermarkExtender ID="tSearch_TextBoxWatermarkExtender" runat="server" 
        meta:resourcekey="TextBoxWatermarkExtenderResource1" 
        TargetControlID="tSearch" WatermarkText="Empty = List All." WatermarkCssClass="textboxWaterMark" Enabled="True">
    </asp:TextBoxWatermarkExtender>--%>

    <asp:Button ID="bSearch" runat="server" Text="List" CssClass="button2" OnClick="bSearch_Click" meta:resourcekey="bSearchResource1" />



</asp:Panel>




<asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowSorting="True" PageSize="1" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" EnableSortingAndPagingCallbacks="True" OnSorting="GridView1_Sorting" ShowHeaderWhenEmpty="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" meta:resourcekey="GridView1Resource1">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField HeaderText="A" Text="＋" ButtonType="Button" InsertVisible="False" CommandName="Add" meta:resourcekey="ButtonFieldResource2" >
            <ControlStyle CssClass="dgAdd" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Left" />
            <ItemStyle CssClass="dgAdd" />
            </asp:ButtonField>
            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" meta:resourcekey="BoundFieldResource2" >
            </asp:BoundField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="Song_SongName" meta:resourcekey="BoundFieldResource3">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle CssClass="dgSong" />
            <ItemStyle CssClass="dgSong" />
            </asp:BoundField>
            <asp:BoundField DataField="Song_Singer" HeaderText="Singer" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource4">
            <ControlStyle CssClass="dgSinger" />
            <HeaderStyle HorizontalAlign="Left" CssClass="dgSinger" />
            <ItemStyle CssClass="dgSinger" ForeColor="#993300" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="w#" meta:resourcekey="TemplateFieldResource1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSong_WordCount" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="lSong_WordCountResource1"></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="dgLang" />
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L" meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>' meta:resourcekey="lSong_LangResource1"></asp:Label>
                </ItemTemplate>
                <HeaderStyle CssClass="dgLang" />
                <ItemStyle CssClass="dgLang" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Insert" HeaderText="I" Text="Ins" meta:resourcekey="ButtonFieldResource3">
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
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <div style="text-align: center ;">
    <asp:Button ID="BPrevious" runat="server" Text="Previous" CssClass="button3" OnClick="BPrevious_Click" Visible="False" meta:resourcekey="BPreviousResource1" />
    <asp:Button ID="BNext" runat="server" Text="Next" CssClass="button3" OnClick="BNext_Click" Visible="False" meta:resourcekey="BNextResource1" />
      <div style="display:block" />
        <div style="display:inline;"><asp:Label ID="LPageNumDisplay" runat="server" Text="Page. " style="font-size:small" meta:resourcekey="LPageNumDisplayResource1"></asp:Label></div>
        <asp:Label ID="LPageNumCount" runat="server" Text="1" style="font-size:small" meta:resourcekey="LPageNumCountResource1" OnPreRender="LPageNumCount_PreRender"></asp:Label>
        </div>
    <asp:HiddenField ID="songDGpage" runat="server" Value="0" />
    <asp:HiddenField ID="gvMode" runat="server" />
    <asp:HiddenField ID="findCaller" runat="server" />
    <br/>
</asp:Panel>


<asp:Panel ID="Panel3" runat="server" Visible="False" meta:resourcekey="Panel3Resource1">
    <asp:GridView ID="GridView2" runat="server" DataKeyNames="User_Id,User_Name" AutoGenerateColumns="False" CssClass="gridview" AllowSorting="True" PageSize="1" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnRowCommand="GridView2_RowCommand" meta:resourcekey="GridView2Resource1">
        <Columns>
            <asp:BoundField HeaderText="User_Id" DataField="User_Id" Visible="False" meta:resourcekey="BoundFieldResource1" >
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Select" DataTextField="User_Name" InsertVisible="False" meta:resourcekey="ButtonFieldResource1">
            <ControlStyle CssClass="button1" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center"/>
            </asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="gridviewHeader" />
    </asp:GridView>
    <br />
</asp:Panel>



<asp:Panel ID="Panel4" runat="server" Visible="False">
    <asp:GridView ID="GridView3" runat="server" DataKeyNames="User_Id,User_Name" AutoGenerateColumns="False" CssClass="gridview" AllowSorting="True" PageSize="1" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnRowCommand="GridView2_RowCommand" >
        <Columns>
            <asp:BoundField HeaderText="User_Id" DataField="User_Id" Visible="False" >
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" CommandName="Select" DataTextField="User_Name" InsertVisible="False">
            <ControlStyle CssClass="button1" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center"/>
            </asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="gridviewHeader" />
    </asp:GridView>
    <br />
</asp:Panel>



