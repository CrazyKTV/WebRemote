<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gui_find.ascx.cs" Inherits="web.gui_find" %>
<%@ Register Assembly="SharpPieces.Web.Controls" Namespace="SharpPieces.Web.Controls" TagPrefix="piece" %>


<link href="css/gui_layout.css" rel="stylesheet" />
<link href="css/gui_button.css" rel="stylesheet" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

<%--<br/>--%>
<asp:Panel ID="Panel1" runat="server" Visible="False" meta:resourcekey="Panel1Resource1">
    <piece:ExtendedDropDownList ID="ddSearchType" runat="server" CssClass="dropdown2" meta:resourcekey="ddSearchTypeResource1">
        <ExtendedItems>
<%--                <piece:ExtendedListItem GroupingText="Group 1"  GroupingType="New"></piece:ExtendedListItem>
                <piece:ExtendedListItem Text="My item2" Value="2" GroupingType="none"></piece:ExtendedListItem>
            <piece:ExtendedListItem Text="My item2" Value="2" GroupingType="none"></piece:ExtendedListItem>
            <piece:ExtendedListItem Text="My item2" Value="2" GroupingType="none"></piece:ExtendedListItem>
            <piece:ExtendedListItem GroupingText="--排行--" GroupingType="New" meta:resourcekey="ListItemResource17"></piece:ExtendedListItem>
            <piece:ExtendedListItem Text="NewSongs" Value="NewSongs" GroupingType="inherit" meta:resourcekey="ListItemResource4"></piece:ExtendedListItem>
            <piece:ExtendedListItem Text="TopOrder" Value="TopOrder" GroupingType="inherit"></piece:ExtendedListItem>
            <piece:ExtendedListItem Text="Favorites" Value="Favorites" GroupingType="inherit"></piece:ExtendedListItem>
--%>
        
            
        <piece:ExtendedListItem id="Song1" Value="Song" meta:resourcekey="ListItemResource1" Text="Song Name" GroupingType="none"></piece:ExtendedListItem> 
        <piece:ExtendedListItem id="Singer1" meta:resourcekey="ListItemResource2" Text="Singer" Value="Singer" GroupingType="none"></piece:ExtendedListItem>        
        <piece:ExtendedListItem id="WordCount1" Value="WordCount" meta:resourcekey="ListItemResource3" Text="Word Count" GroupingType="none"></piece:ExtendedListItem>  
        
        <%--<piece:ExtendedListItem GroupingText="--排行--"Text="---排行---" meta:resourcekey="ListItemResource17"></piece:ExtendedListItem>--%>    
        <piece:ExtendedListItem GroupingText="-TOP-" GroupingType="New" Value="NewSongs" meta:resourcekey="ListItemResource4" Text="New Songs"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="TopOrder" meta:resourcekey="ListItemResource5" Text="Top Order"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" meta:resourcekey="ListItemResource6" Text="Favorites" Value="Favorites"></piece:ExtendedListItem>
        <%--<piece:ExtendedListItem Text="---歌星---" meta:resourcekey="ListItemResource18"></piece:ExtendedListItem>--%>    
        <piece:ExtendedListItem GroupingText="-SINGER-" GroupingType="New" meta:resourcekey="ListItemResource7" Text="Male" Value="Male"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" meta:resourcekey="ListItemResource8" Text="Female" Value="Female"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" meta:resourcekey="ListItemResource9" Text="Group" Value="Group"></piece:ExtendedListItem>
        <%--<piece:ExtendedListItem Text="---歌種---" meta:resourcekey="ListItemResource19"></piece:ExtendedListItem>--%>    
        <piece:ExtendedListItem GroupingText="-TYPE-" GroupingType="New" meta:resourcekey="ListItemResource10" Text="Chorus"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Mandarin" meta:resourcekey="ListItemResource11" Text="Mandarin"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Taiwanese" meta:resourcekey="ListItemResource12" Text="Taiwanese"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Cantonese" meta:resourcekey="ListItemResource13" Text="Cantonese"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Japanese" meta:resourcekey="ListItemResource14" Text="Japanese"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="English" meta:resourcekey="ListItemResource15" Text="English"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Haka" Text="Haka"  meta:resourcekey="ExtendedListItem1" ></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Local" Text="Local" meta:resourcekey="ExtendedListItem2"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Korean" Text="Korean" meta:resourcekey="ExtendedListItem3"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="Kid" Text="Kid" meta:resourcekey="ExtendedListItem4"></piece:ExtendedListItem>
        <piece:ExtendedListItem GroupingType="inherit" Value="OtherLangs" meta:resourcekey="ListItemResource16" Text="Other Langs"></piece:ExtendedListItem>

<%--        <piece:ExtendedListItem id="Song2" Value="Song" meta:resourcekey="ListItemResource1" Text="Song Name" GroupingType="none"></piece:ExtendedListItem> 
        <piece:ExtendedListItem id="Singer2" meta:resourcekey="ListItemResource2" Text="Singer" Value="Singer" GroupingType="none"></piece:ExtendedListItem>        
        <piece:ExtendedListItem id="WordCount2" Value="WordCount" meta:resourcekey="ListItemResource3" Text="Word Count" GroupingType="none"></piece:ExtendedListItem>  
        
		--%>
            </ExtendedItems>

    </piece:ExtendedDropDownList>


<%--    <asp:DropDownList ID="ddSearchType" runat="server" CssClass="dropdown2" meta:resourcekey="ddSearchTypeResource1">
        <asp:ListItem Value="Song" meta:resourcekey="ListItemResource1" Text="Song Name"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource2" Text="Singer" Value="Singer"></asp:ListItem>        
        <asp:ListItem Value="WordCount" meta:resourcekey="ListItemResource3" Text="Word Count"></asp:ListItem>  
        <asp:ListItem Text="---排行---" meta:resourcekey="ListItemResource17"></asp:ListItem>    
        <asp:ListItem Value="NewSongs" meta:resourcekey="ListItemResource4" Text="New Songs"></asp:ListItem>
        <asp:ListItem Value="TopOrder" meta:resourcekey="ListItemResource5" Text="Top Order"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource6" Text="Favorites"></asp:ListItem>
        <asp:ListItem Text="---歌星---" meta:resourcekey="ListItemResource18"></asp:ListItem>    
        <asp:ListItem meta:resourcekey="ListItemResource7" Text="Male"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource8" Text="Female"></asp:ListItem>
        <asp:ListItem meta:resourcekey="ListItemResource9" Text="Group"></asp:ListItem>
        <asp:ListItem Text="---歌種---" meta:resourcekey="ListItemResource19"></asp:ListItem>    
        <asp:ListItem meta:resourcekey="ListItemResource10" Text="Chorus"></asp:ListItem>
        <asp:ListItem Value="Mandarin" meta:resourcekey="ListItemResource11" Text="Mandarin"></asp:ListItem>
        <asp:ListItem Value="Taiwanese" meta:resourcekey="ListItemResource12" Text="Taiwanese"></asp:ListItem>
        <asp:ListItem Value="Cantonese" meta:resourcekey="ListItemResource13" Text="Cantonese"></asp:ListItem>
        <asp:ListItem Value="Japanese" meta:resourcekey="ListItemResource14" Text="Japanese"></asp:ListItem>
        <asp:ListItem Value="English" meta:resourcekey="ListItemResource15" Text="English"></asp:ListItem>
        <asp:ListItem Value="OtherLangs" meta:resourcekey="ListItemResource16" Text="Other Langs"></asp:ListItem>
    </asp:DropDownList>
        --%>
    <asp:TextBox ID="tSearch" runat="server" CssClass="textbox2" meta:resourcekey="tSearchResource1" Width="100px"></asp:TextBox>

    <asp:Button ID="bSearch" runat="server" Text="List" CssClass="button2" OnClick="bSearch_Click" meta:resourcekey="bSearchResource1" OnPreRender="bSearch_PreRender" />





</asp:Panel>




<asp:Panel ID="Panel2" runat="server" Visible="False" meta:resourcekey="Panel2Resource1">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id,Song_Singer" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CssClass="gridview" GridLines="Vertical" AllowSorting="True" PageSize="1" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" EnableSortingAndPagingCallbacks="True" OnSorting="GridView1_Sorting" ShowHeaderWhenEmpty="True" meta:resourcekey="GridView1Resource1">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ButtonField HeaderText="A" Text="＋" ButtonType="Button" InsertVisible="False" CommandName="Add" meta:resourcekey="ButtonFieldResource2" >
            <ControlStyle CssClass="dgAdd" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Left" />
            <ItemStyle CssClass="dgAddbackground" />
            </asp:ButtonField>
            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" meta:resourcekey="BoundFieldResource2" >
            </asp:BoundField>
            <asp:BoundField HeaderText="Song" InsertVisible="False" ReadOnly="True" DataField="Song_SongName" meta:resourcekey="BoundFieldResource3">
            <ControlStyle CssClass="dgSong" />
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle CssClass="dgSong" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Song_Singer" HeaderText="Singer" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource4" Visible="False">
            <ControlStyle CssClass="dgSinger" />
            <HeaderStyle HorizontalAlign="Left" CssClass="dgSinger" />
            <ItemStyle CssClass="dgSinger" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:ButtonField HeaderText="Singer" Text="Singer" InsertVisible="False" DataTextField="Song_Singer"  CommandName="Singer" meta:resourcekey="BoundFieldResource4"  >
            <ControlStyle CssClass="dgSinger" />
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle CssClass="dgSinger" HorizontalAlign="Left"  />
            </asp:ButtonField>
            <asp:TemplateField HeaderText="w#" meta:resourcekey="TemplateFieldResource1">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="TextBox1Resource1"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lSong_WordCount" runat="server" Text='<%# Bind("Song_WordCount") %>' meta:resourcekey="lSong_WordCountResource1"></asp:Label>
                </ItemTemplate>
                <ControlStyle CssClass="dgLang" />
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle CssClass="dgLang" HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="L" meta:resourcekey="TemplateFieldResource2">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>' meta:resourcekey="lSong_LangResource1"></asp:Label>
                </ItemTemplate>
                 <ControlStyle CssClass="dgLang" />
                <HeaderStyle  HorizontalAlign="Right" />
                <ItemStyle CssClass="dgLang" HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Button" CommandName="Insert" HeaderText="I" Text="Ins" meta:resourcekey="ButtonFieldResource3">
            <ControlStyle CssClass="dgInsert" />
            <HeaderStyle CssClass="hideThis" HorizontalAlign="Right" />
            <ItemStyle CssClass="dgInsertbackground" HorizontalAlign="Right" />
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
        <asp:TextBox ID="LPageNumCount" runat="server" Text="1" Width="50px" type="number" meta:resourcekey="TPageNumCountResource1" ></asp:TextBox>
        <asp:Button ID="BJump" runat="server" Text="Jump" CssClass="button2" meta:resourcekey="BJumpResource1" OnClick="BJump_Click" />    
    </div>
    <asp:HiddenField ID="songDGpage" runat="server" Value="0" />
    <asp:HiddenField ID="gvMode" runat="server" />
    <asp:HiddenField ID="findCaller" runat="server" />
    <br/>
</asp:Panel>


<asp:Panel ID="Panel3" runat="server" Visible="False" meta:resourcekey="Panel3Resource1" cssclass="alignCenter">

    <asp:ListView ID="GridView2" runat="server" DataKeyNames="User_Id,User_Name" OnItemCommand="GridView2_ItemCommand">
              <ItemTemplate>
                   <asp:Button CssClass="button1columns" ID="Bfavorite"   runat="server" Text='<%# Eval("User_Name").ToString() %>' Visible="true" />
        </ItemTemplate>
    </asp:ListView>





<%--    <asp:GridView ID="GridView23" runat="server" DataKeyNames="User_Id,User_Name" AutoGenerateColumns="False" 
        CssClass="gridview" AllowSorting="True" PageSize="1" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnRowCommand="GridView2_RowCommand" meta:resourcekey="GridView2Resource1">
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
    </asp:GridView>--%>
    <br />
</asp:Panel>



<asp:Panel ID="Panel4" runat="server" Visible="False" meta:resourcekey="Panel4Resource1" cssclass="alignCenter">
    <asp:ListView ID="SingerListView" runat="server" DataKeyNames="Singer_Name,Singer_Type" OnPagePropertiesChanged="SingerListView_PagePropertiesChanged" >
        <ItemTemplate>
            <div id="SingerListDiv" style="display: block; float:left;">
                <div>
                    <asp:Button ID="SingerNameButton" CssClass="SingerNameButton" Font-Size='<%# Eval("Singer_Name").ToString().Length > 5 ? FontUnit.Empty : FontUnit.Medium %>' onclick="Bsinger_Click" runat="server" Text='<%# Eval("Singer_Name").ToString() %>' Visible="true" OnClientClick="Bsinger_Click" />
                </div>
                <div>
                    <asp:ImageButton ID="SingerImageButton" ImageUrl='<%# Eval("ImgFileUrl").ToString() %>' runat="server" AlternateText='<%# Eval("Singer_Name").ToString() %>' CssClass="SingerImageButton" OnClick="SingerImageButton_Click"/>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <div style="clear: both;" />
    <asp:DataPager ID="SingerListDataPager" runat="server" PagedControlID="SingerListView">
        <Fields>
            <asp:TemplatePagerField OnPagerCommand="SingerListDataPager_OnPagerCommand">
                <PagerTemplate>
                    <div>
                        <b>
                            第
                            <asp:Label ID="CurrentPageLabel" runat="server" Text="<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>" />
                            頁 (總計
                            <asp:Label ID="TotalPagesLabel" runat="server" Text="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>" />
                            頁,共
                            <asp:Label ID="TotalItemsLabel" runat="server" Text="<%# Container.TotalRowCount%>" />
                            位歌手)
                        </b>
                    </div>
                    <div>
                        <asp:Button ID="FirstButton" runat="server" CommandName="First"  Text="首頁" Enabled='<%# Container.StartRowIndex > 0 %>' CssClass='<%# Container.StartRowIndex > 0 ? "PageButton" : "PageButtonDisable"%>' />
                        <asp:Button ID="PreviousButton" runat="server" CommandName="Previous" Text="上一頁" Enabled='<%# Container.StartRowIndex > 0 %>' CssClass='<%# Container.StartRowIndex > 0 ? "PageButton" : "PageButtonDisable" %>' />
                        <asp:Button ID="NextButton" runat="server" CommandName="Next" Text="下一頁" Enabled='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount %>' CssClass='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount ? "PageButton" : "PageButtonDisable" %>' />
                    </div>
                </PagerTemplate>
            </asp:TemplatePagerField>
        </Fields>
    </asp:DataPager>
    <%--<asp:GridView ID="GridView23" runat="server" DataKeyNames="Singer_Name,Singer_Type" AutoGenerateColumns="False" CssClass="gridview" AllowSorting="True" PageSize="1" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnRowCommand="GridView3_RowCommand" meta:resourcekey="GridView3Resource1" >
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" DataTextField="Singer_Name" InsertVisible="False" meta:resourcekey="ButtonFieldResource4">
            <ControlStyle CssClass="button1" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center"/>
            </asp:ButtonField>
        </Columns>
        <HeaderStyle CssClass="gridviewHeader" />
    </asp:GridView>--%>
</asp:Panel>


<asp:Panel ID="MainMenuPanel" runat="server" Visible="true" meta:resourcekey="MainMenuPanelResource1" cssclass="alignCenter">
    <div id="row1" style="display: block;">
        <asp:ImageButton ID="MainMenu_FindSingerButton" ImageUrl="images/mainmenu_findsinger.png" runat="server" CssClass="MainMenuButton" OnClick="MainMenu_FindSingerButton_Click"/>
        <asp:ImageButton ID="MainMenu_FindLangButton" ImageUrl="images/mainmenu_findlang.png" runat="server" CssClass="MainMenuButton" OnClick="MainMenu_FindLangButton_Click"/>
        <asp:ImageButton ID="MainMenu_QuerySongButton" ImageUrl="images/mainmenu_querysong.png" runat="server" CssClass="MainMenuButton" OnClick="MainMenu_QuerySongButton_Click"/>
        <asp:ImageButton ID="MainMenu_ChorusSongShowButton" ImageUrl="images/mainmenu_chorussong.png" runat="server" CssClass="MainMenuShowButton" OnClick="MainMenu_ChorusSongButton_Click"/>
    </div>
    <div id="row2" style="display: block;">
        <asp:ImageButton ID="MainMenu_ChorusSongButton" ImageUrl="images/mainmenu_chorussong.png" runat="server" CssClass="MainMenuHideButton" OnClick="MainMenu_ChorusSongButton_Click"/>
        <asp:ImageButton ID="MainMenu_ChartSongButton" ImageUrl="images/mainmenu_chartsong.png" runat="server" CssClass="MainMenuButton" OnClick="MainMenu_ChartSongButton_Click"/>
        <asp:ImageButton ID="MainMenu_NewSongButton" ImageUrl="images/mainmenu_newsong.png" runat="server" CssClass="MainMenuButton" OnClick="MainMenu_NewSongButton_Click"/>
        <asp:ImageButton ID="MainMenu_FavoriteSongShowButton" ImageUrl="images/mainmenu_favoritesong.png" runat="server" CssClass="MainMenuShowButton" OnClick="MainMenu_FavoriteSongButton_Click"/>
        <asp:Image ID="MainMenu_EmptyShowImage" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuShowImage"/>
    </div>
    <div id="row3" style="display: block;">
        <asp:ImageButton ID="MainMenu_FavoriteSongButton" ImageUrl="images/mainmenu_favoritesong.png" runat="server" CssClass="MainMenuHideButton" OnClick="MainMenu_FavoriteSongButton_Click"/>
        <asp:Image ID="MainMenu_EmptyImage1" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuHideImage"/>
        <asp:Image ID="MainMenu_EmptyImage2" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuHideImage"/>
    </div>
</asp:Panel>

<asp:Panel ID="SingerTypePanel" runat="server" Visible="false" meta:resourcekey="SingerPanelResource1" cssclass="alignCenter">
    <div id="SingerRow1" style="display: block;">
        <asp:ImageButton ID="SingerTypeMaleButton" ImageUrl="images/singertype_male.png" runat="server" CssClass="MainMenuButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeFemaleButton" ImageUrl="images/singertype_female.png" runat="server" CssClass="MainMenuButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeGroupButton" ImageUrl="images/singertype_group.png" runat="server" CssClass="MainMenuButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeForeignMaleShowButton" ImageUrl="images/singertype_foreignmale.png" runat="server" CssClass="MainMenuShowButton" OnClick="SingerTypeButton_Click"/>
    </div>
    <div id="SingerTypeRow2" style="display: block;">
        <asp:ImageButton ID="SingerTypeForeignMaleButton" ImageUrl="images/singertype_foreignmale.png" runat="server" CssClass="MainMenuHideButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeForeignFemaleButton" ImageUrl="images/singertype_foreignfemale.png" runat="server" CssClass="MainMenuButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeForeignGroupButton" ImageUrl="images/singertype_foreigngroup.png" runat="server" CssClass="MainMenuButton" OnClick="SingerTypeButton_Click"/>
        <asp:ImageButton ID="SingerTypeOtherShowButton" ImageUrl="images/singertype_other.png" runat="server" CssClass="MainMenuShowButton" OnClick="SingerTypeButton_Click"/>
        <asp:Image ID="Image1" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuShowImage"/>
    </div>
    <div id="SingerTypeRow3" style="display: block;">
        <asp:ImageButton ID="SingerTypeOtherButton" ImageUrl="images/singertype_other.png" runat="server" CssClass="MainMenuHideButton" OnClick="SingerTypeButton_Click"/>
        <asp:Image ID="Image2" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuHideImage"/>
        <asp:Image ID="Image3" ImageUrl="images/mainmenu_emptyimage.png" runat="server" CssClass="MainMenuHideImage"/>
    </div>
</asp:Panel>