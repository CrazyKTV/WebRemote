<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gui_find.ascx.cs" Inherits="web.gui_find" %>

<link href="Content/bootstrap.min.css" rel="stylesheet" /> 
<link href="Content/bootstrap-theme.min.css" rel="stylesheet" /> 
<link href="css/gui_layout.css" rel="stylesheet" />

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />
<asp:HiddenField ID="ScrolltoTop" runat="server" />

<asp:Panel ID="MainMenuPanel" runat="server" Visible="true" meta:resourcekey="MainMenuPanelResource1" cssclass="alignCenter">
    <div class="container-fluid">
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_FindSingerButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_findsinger.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="歌星點歌" meta:resourcekey="MainMenu_FindSingerButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_FindLangButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_findlang.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="語系點歌" meta:resourcekey="MainMenu_FindLangButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_QuerySongButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_querysong.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="搜尋歌曲" meta:resourcekey="MainMenu_QuerySongButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_SongStrokeDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_songstroke.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="筆劃點歌" meta:resourcekey="MainMenu_SongStrokeDesktopButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_ChorusSongButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_chorussong.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="合唱歌曲" meta:resourcekey="MainMenu_ChorusSongButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_NewSongButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_newsong.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="新進歌曲" meta:resourcekey="MainMenu_NewSongButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_TopSongButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_topsong.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="排行歌曲" meta:resourcekey="MainMenu_TopSongButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_FavoriteSongButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_favoritesong.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="我的最愛" meta:resourcekey="MainMenu_FavoriteSongButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="MainMenu_SongNumberButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MainMenu_Button_Click">
                    <asp:Image ImageUrl="images/mainmenu_songnumber.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="編號點歌" meta:resourcekey="MainMenu_SongNumberButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="SingerTypePanel" runat="server" Visible="false" meta:resourcekey="SingerPanelResource1" cssclass="alignCenter">
    <div class="container-fluid">
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeMaleButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_male.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="男星" meta:resourcekey="SingerTypeMaleButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeFemaleButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_female.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="女星" meta:resourcekey="SingerTypeFemaleButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeGroupButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_group.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="團體" meta:resourcekey="SingerTypeGroupButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <!-- Desktop / Tablet -->
            <div class="SubMenuArea hidden-xs hidden-sm">
                <div class ="hidden-xs hidden-sm col-md-12 col-lg-12" style="padding: 0px;">
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeMaleDesktopButton" runat="server" CssClass="MainMenuButton btn btn-primary btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_male.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="男星" meta:resourcekey="SingerTypeMaleButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeFemaleDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_female.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="女星" meta:resourcekey="SingerTypeFemaleButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeGroupDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_group.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="團體" meta:resourcekey="SingerTypeGroupButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeForeignMaleDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_foreignmale.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="外男" meta:resourcekey="SingerTypeForeignMaleDesktopButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeForeignFemaleDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_foreignfemale.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="外女" meta:resourcekey="SingerTypeForeignFemaleDesktopButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeForeignGroupDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_foreigngroup.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="外團" meta:resourcekey="SingerTypeForeignGroupDesktopButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SingerTypeOtherDesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                            <asp:Image ImageUrl="images/singertype_other.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="其它" meta:resourcekey="SingerTypeOtherButton_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeForeignMaleButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_foreignmale.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="外國男星" meta:resourcekey="SingerTypeForeignMaleButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeForeignFemaleButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_foreignfemale.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="外國女星" meta:resourcekey="SingerTypeForeignFemaleButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeForeignGroupButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_foreigngroup.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="外國團體" meta:resourcekey="SingerTypeForeignGroupButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SingerTypeOtherButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SingerTypeButton_Click">
                    <asp:Image ImageUrl="images/singertype_other.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="其它" meta:resourcekey="SingerTypeOtherButton_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="SingerListPanel" runat="server" Visible="False" meta:resourcekey="SingerListPanelResource1">
    <div class="container-fluid">
        <div class="row">
            <asp:ListView ID="SingerListView" runat="server" DataKeyNames="Singer_Name,Singer_Type" OnPreRender="SingerListView_PreRender">
                <ItemTemplate>
                    <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                        <asp:LinkButton ID="SingerListButton" runat="server" CssClass="SingerListButton btn btn-success btn-lg" OnClick="SingerListButton_Click">
                            <asp:Label runat="server" Text='<%# Eval("Singer_Name").ToString() %>' CssClass="SingerListLabel" Font-Size='<%# Eval("Singer_Name").ToString().Length > 5 ? FontUnit.Empty : FontUnit.Medium %>' />
                            <div class="SingerListBox">
                                <asp:Image ImageUrl='<%# Eval("ImgFileUrl").ToString() %>' runat="server" CssClass="SingerListImage" />
                            </div>
                        </asp:LinkButton>
                    </div>
                    <!-- Desktop / Tablet -->
                    <div class ="hidden-xs hidden-sm col-md-2 col-lg-2" style="padding: 5px 5px 5px 5px;">
                        <asp:LinkButton ID="SingerListDesktopButton" runat="server" CssClass="SingerListButton btn btn-success btn-lg" OnClick="SingerListButton_Click">
                            <asp:Label runat="server" Text='<%# Eval("Singer_Name").ToString() %>' CssClass="SingerListLabel" Font-Size='<%# Eval("Singer_Name").ToString().Length > 5 ? FontUnit.Empty : FontUnit.Medium %>' />
                            <div class="SingerListBox">
                                <asp:Image ImageUrl='<%# Eval("ImgFileUrl").ToString() %>' runat="server" CssClass="SingerListImage" />
                            </div>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            
            <asp:DataPager ID="SingerListDataPager" runat="server" PagedControlID="SingerListView">
                <Fields>
                    <asp:TemplatePagerField OnPagerCommand="SingerListDataPager_OnPagerCommand">
                        <PagerTemplate>
                            <div class="SingerListPagerArea">
                                <asp:LinkButton ID="SingerList_FirstPage_Button" runat="server" CssClass='<%# Container.StartRowIndex > 0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="First">
                                    <span class="glyphicon glyphicon-fast-backward gi-big"></span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="SingerList_PreviousPage_Button" runat="server" CssClass='<%# Container.StartRowIndex > 0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Previous">
                                    <span class="glyphicon glyphicon-backward gi-big"></span>
                                </asp:LinkButton>

                                <div class="GridViewPageText" style="display: inline-block;">
                                    <div class="hidden-md hidden-lg">
                                        <asp:Label ID="SingerList_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SingerList_CurPage_Label_Before_RES" />
                                        <asp:Label ID="SingerList_CurPage_Label" runat="server" Text='<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>' />

                                        <asp:Label ID="SingerList_PageCount_Label_Before" runat="server" Text=" / " />
                                        <asp:Label ID="SingerList_PageCount_Label" runat="server" Text='<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>' />
                                        <asp:Label ID="SingerList_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_PageCount_Label_After_RES" />
                                    </div>
                                    <div class="hidden-xs hidden-sm">
                                        <asp:Label ID="SingerList_Desktop_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SingerList_CurPage_Label_Before_RES" />
                                        <asp:Label ID="SingerList_Desktop_CurPage_Label" runat="server" Text='<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>' />
                                        <asp:Label ID="SingerList_Desktop_CurPage_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_CurPage_Label_After_RES" />
                    
                                        <asp:Label ID="SingerList_Desktop_PageCount_Label_Before" runat="server" Text=" / 共" meta:resourcekey="SingerList_PageCount_Label_Before_RES" />
                                        <asp:Label ID="SingerList_Desktop_PageCount_Label" runat="server" Text='<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>' />
                                        <asp:Label ID="SingerList_Desktop_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_PageCount_Label_After_RES" />
                                    </div>
                                </div>

                                <asp:LinkButton ID="SingerList_NextPage_Button" runat="server" CssClass='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Next">
                                    <span class="glyphicon glyphicon-forward gi-big"></span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="SingerList_LastPage_Button" runat="server" CssClass='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Last" CommandArgument="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>">
                                    <span class="glyphicon glyphicon-fast-forward gi-big"></span>
                                </asp:LinkButton>

                                <div class="hidden-xs hidden-sm" style="display: inline-block;">
                                    <div class="GridViewPageText" style="display: inline-block;">
                                        <asp:Label ID="SingerList_SelectPage_Label_Before" runat="server" Text="到" meta:resourcekey="SingerList_SelectPage_Label_Before_RES" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    </div>
                                    <asp:DropDownList ID="SingerList_SelectPage_DropDownList" runat="server" CssClass="GridViewPageButton btn btn-primary" AutoPostBack="True" OnSelectedIndexChanged="SingerList_SelectPage_DropDownList_SelectedIndexChanged" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    <div class="GridViewPageText" style="display: inline-block;">
                                        <asp:Label ID="SingerList_SelectPage_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_SelectPage_Label_After_RES" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    </div>
                                </div>
                            </div>        
                        </PagerTemplate>
                    </asp:TemplatePagerField>
                </Fields>
            </asp:DataPager>
        </div>
    </div>
    <div class="hidden-md hidden-lg spacerToFooter"></div>
</asp:Panel>


<asp:Panel ID="SongLangPanel" runat="server" Visible="false" meta:resourcekey="SongLangPanel_Res" cssclass="alignCenter" OnPreRender="SongLangPanel_PreRender">
    <div class="container-fluid">
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang1Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang1Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang1Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang2Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang2Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang2Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang3Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang3Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang3Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <!-- Desktop / Tablet -->
            <div class="SubMenuArea hidden-xs hidden-sm">
                <div class ="hidden-xs hidden-sm col-md-12 col-lg-12" style="padding: 0px;">
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang1DesktopButton" runat="server" CssClass="MainMenuButton btn btn-primary btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang1DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang1DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel" />
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang2DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang2DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang2DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang3DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang3DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang3DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang4DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang4DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang4DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang5DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang5DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang5DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang6DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang6DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang6DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang7DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang7DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang7DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang8DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang8DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang8DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang9DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang9DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang9DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="SongLang10DesktopButton" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                            <asp:Image ID="SongLang10DesktopImage" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label ID="SongLang10DesktopLabel" runat="server" Text="" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang4Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang4Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang4Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang5Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang5Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang5Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang6Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang6Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang6Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang7Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang7Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang7Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang8Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang8Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang8Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang9Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang9Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang9Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="SongLang10Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="SongLangButton_Click">
                    <asp:Image ID="SongLang10Image" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label ID="SongLang10Label" runat="server" Text="" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="MobileFilterPanel" runat="server" Visible="False">
    <div class="container-fluid">
        <div class="row">
            <asp:ListView ID="MobileFilter_ListView" runat="server" DataKeyNames="FilterText" OnPreRender="MobileFilter_ListView_PreRender">
                <ItemTemplate>
                    <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                        <asp:LinkButton ID="MobileFilter_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="MobileFilter_Button_Click">
                            <asp:Image ID="MobileFilter_Image" runat="server" ImageUrl='<%# Eval("FilterImgUrl").ToString() %>' CssClass="MainMenuImage"/>
                            <asp:Label ID="MobileFilter_Label" runat="server" Text='<%# Eval("FilterText").ToString() %>' CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="QuerySongPanel" runat="server" Visible="false" cssclass="alignCenter">
    <div class="container-fluid">
        <div class="row">
            <div class="SubMenuArea hidden-md hidden-lg">
                <div class ="col-xs-3 col-sm-3 hidden-md hidden-lg" style="padding-left: 5px; padding-right: 5px;">
                    <asp:Image ImageUrl="images/mainmenu_querysong.png" runat="server" CssClass="MainImage"/>
                    <asp:Label runat="server" Text="搜尋" meta:resourcekey="QuerySong_Title_Label_RES" CssClass="MainMenuLabel textshadow"/>
                </div>
                <div class="col-xs-9 col-sm-9 hidden-md hidden-lg" style="padding-left: 0px; text-align: left;">
                    <div class="row" style="margin-top: 5px;">
                        <div class="col-xs-12 col-sm-12 hidden-md hidden-lg" style="padding-left: 5px; padding-right: 5px;">
                            <asp:RadioButton ID="QuerySong_SongName_RadioButton" runat="server" Text="歌曲名稱" meta:resourcekey="QuerySong_SongName_RadioButton_RES" CssClass="GridViewPageButton" GroupName="QuerySongRadioGroup" AutoPostBack="true" OnCheckedChanged="QuerySong_RadioButton_CheckedChanged" Checked="True" />
                            <asp:RadioButton ID="QuerySong_SingerName_RadioButton" runat="server" Text="歌星名稱" meta:resourcekey="QuerySong_SingerName_RadioButton_RES" CssClass="GridViewPageButton" GroupName="QuerySongRadioGroup" AutoPostBack="true" OnCheckedChanged="QuerySong_RadioButton_CheckedChanged" />
                        </div>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <div class="col-xs-12 col-sm-12 hidden-md hidden-lg">
                            <asp:TextBox ID="QuerySong_QueryName_TextBox" runat="server" CssClass="form-control" Font-Size="Large" AutoPostBack="true" OnTextChanged="QuerySong_QueryName_TextBox_TextChanged" />
                        </div>
                    </div>
                </div>
            </div>
            <!-- Desktop / Tablet -->
            <div class="SubMenuArea hidden-xs hidden-sm">
                <div class ="hidden-xs hidden-sm col-md-12 col-lg-12" style="padding: 0px;">
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding: 1.27px 5px 1.27px 5px;">
                        <asp:Image ImageUrl="images/mainmenu_querysong.png" runat="server" CssClass="MainMenuImage"/>
                        <asp:Label runat="server" Text="搜尋" meta:resourcekey="QuerySong_Title_Label_RES" CssClass="MainMenuLabel textshadow"/>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-10 col-lg-10" style="padding-left: 5px; padding-right: 5px; text-align: left;">
                        <div class="row">
                            <div class="hidden-xs hidden-sm col-md-12 col-lg-12" style="padding-left: 5px; padding-right: 5px;">
                                <asp:RadioButton ID="QuerySong_SongName_Desktop_RadioButton" runat="server" Text="歌曲名稱" meta:resourcekey="QuerySong_SongName_RadioButton_RES" CssClass="GridViewPageButton" GroupName="QuerySongDesktopRadioGroup" AutoPostBack="true" OnCheckedChanged="QuerySong_RadioButton_CheckedChanged" Checked="True" />
                                <asp:RadioButton ID="QuerySong_SingerName_Desktop_RadioButton" runat="server" Text="歌星名稱" meta:resourcekey="QuerySong_SingerName_RadioButton_RES" CssClass="GridViewPageButton" GroupName="QuerySongDesktopRadioGroup" AutoPostBack="true" OnCheckedChanged="QuerySong_RadioButton_CheckedChanged" />
                            </div>
                        </div>
                        <div class="row" style="margin-top: 5px;">
                            <div class="hidden-xs hidden-sm col-md-12 col-lg-12">
                                <asp:TextBox ID="QuerySong_QueryName_Desktop_TextBox" runat="server" CssClass="form-control" Font-Size="Large" AutoPostBack="true" OnTextChanged="QuerySong_QueryName_TextBox_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="FavoriteSongPanel" runat="server" Visible="false" cssclass="alignCenter">
    <div class="container-fluid">
        <div class="row">
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="FavoriteSong_User_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="FavoriteSong_Button_Click">
                    <asp:Image ImageUrl="images/singertype_male.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="用戶" meta:resourcekey="FavoriteSong_User_Button_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="FavoriteSong_History_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="FavoriteSong_Button_Click">
                    <asp:Image ImageUrl="images/favoritesong_history.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="歷史" meta:resourcekey="FavoriteSong_History_Button_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                <asp:LinkButton ID="FavoriteSong_Cashbox_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="FavoriteSong_Button_Click">
                    <asp:Image ImageUrl="images/favoritesong_cashbox.png" runat="server" CssClass="MainMenuImage"/>
                    <asp:Label runat="server" Text="錢櫃" meta:resourcekey="FavoriteSong_Cashbox_Button_RES" CssClass="MainMenuLabel"/>
                </asp:LinkButton>
            </div>
            <!-- Desktop / Tablet -->
            <div class="SubMenuArea hidden-xs hidden-sm">
                <div class ="hidden-xs hidden-sm col-md-12 col-lg-12" style="padding: 0px;">
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="FavoriteSong_Desktop_User_Button" runat="server" CssClass="MainMenuButton btn btn-primary btn-lg" OnClick="FavoriteSong_Button_Click">
                            <asp:Image ImageUrl="images/singertype_male.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="用戶" meta:resourcekey="FavoriteSong_User_Button_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="FavoriteSong_Desktop_History_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="FavoriteSong_Button_Click">
                            <asp:Image ImageUrl="images/favoritesong_history.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="歷史" meta:resourcekey="FavoriteSong_History_Button_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                    <div class ="hidden-xs hidden-sm col-md-1 col-lg-1" style="width: 10%; padding-left: 5px; padding-right: 5px;">
                        <asp:LinkButton ID="FavoriteSong_Desktop_Cashbox_Button" runat="server" CssClass="MainMenuButton btn btn-success btn-lg" OnClick="FavoriteSong_Button_Click">
                            <asp:Image ImageUrl="images/favoritesong_cashbox.png" runat="server" CssClass="MainMenuImage"/>
                            <asp:Label runat="server" Text="錢櫃" meta:resourcekey="FavoriteSong_Cashbox_Button_RES" CssClass="MainMenuLabel"/>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>


<asp:Panel ID="FavoriteListPanel" runat="server" Visible="False">
    <div class="container-fluid">
        <div class="row">
            <asp:ListView ID="FavoriteListView" runat="server" DataKeyNames="User_Id, User_Name" OnPreRender="FavoriteListView_PreRender">
                <ItemTemplate>
                    <div class ="col-xs-4 col-sm-4 hidden-md hidden-lg" style="padding: 5px;">
                        <asp:LinkButton ID="FavoriteListButton" runat="server" CssClass="SingerListButton btn btn-success btn-lg" OnClick="FavoriteListButton_Click" CommandArgument='<%# Eval("User_Id").ToString() %>'>
                            <asp:Label runat="server" Text='<%# Eval("User_Name").ToString().Replace("錢櫃", "") %>' CssClass="SingerListLabel" Font-Size='<%# Eval("User_Name").ToString().Replace("錢櫃", "").Length > 5 ? FontUnit.Empty : FontUnit.Medium %>' />
                            <div class="SingerListBox">
                                <asp:Image ImageUrl='<%# Eval("ImgFileUrl").ToString() %>' runat="server" CssClass="SingerListImage" />
                            </div>
                        </asp:LinkButton>
                    </div>
                    <!-- Desktop / Tablet -->
                    <div class ="hidden-xs hidden-sm col-md-2 col-lg-2" style="padding: 5px 5px 5px 5px;">
                        <asp:LinkButton ID="FavoriteListDesktopButton" runat="server" CssClass="SingerListButton btn btn-success btn-lg" OnClick="FavoriteListButton_Click" CommandArgument='<%# Eval("User_Id").ToString() %>'>
                            <asp:Label runat="server" Text='<%# Eval("User_Name").ToString().Replace("錢櫃", "") %>' CssClass="SingerListLabel" Font-Size='<%# Eval("User_Name").ToString().Replace("錢櫃", "").Length > 5 ? FontUnit.Empty : FontUnit.Medium %>' />
                            <div class="SingerListBox">
                                <asp:Image ImageUrl='<%# Eval("ImgFileUrl").ToString() %>' runat="server" CssClass="SingerListImage" />
                            </div>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            
            <asp:DataPager ID="FavoriteListDataPager" runat="server" PagedControlID="FavoriteListView">
                <Fields>
                    <asp:TemplatePagerField OnPagerCommand="FavoriteListDataPager_OnPagerCommand">
                        <PagerTemplate>
                            <div class="SingerListPagerArea">
                                <asp:LinkButton ID="FavoriteList_FirstPage_Button" runat="server" CssClass='<%# Container.StartRowIndex > 0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="First">
                                    <span class="glyphicon glyphicon-fast-backward gi-big"></span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="FavoriteList_PreviousPage_Button" runat="server" CssClass='<%# Container.StartRowIndex > 0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Previous">
                                    <span class="glyphicon glyphicon-backward gi-big"></span>
                                </asp:LinkButton>

                                <div class="GridViewPageText" style="display: inline-block;">
                                    <div class="hidden-md hidden-lg">
                                        <asp:Label ID="FavoriteList_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SingerList_CurPage_Label_Before_RES" />
                                        <asp:Label ID="FavoriteList_CurPage_Label" runat="server" Text='<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>' />

                                        <asp:Label ID="FavoriteList_PageCount_Label_Before" runat="server" Text=" / " />
                                        <asp:Label ID="FavoriteList_PageCount_Label" runat="server" Text='<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>' />
                                        <asp:Label ID="FavoriteList_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_PageCount_Label_After_RES" />
                                    </div>
                                    <div class="hidden-xs hidden-sm">
                                        <asp:Label ID="FavoriteList_Desktop_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SingerList_CurPage_Label_Before_RES" />
                                        <asp:Label ID="FavoriteList_Desktop_CurPage_Label" runat="server" Text='<%# Container.TotalRowCount>0 ? (Container.StartRowIndex / Container.PageSize) + 1 : 0 %>' />
                                        <asp:Label ID="FavoriteList_Desktop_CurPage_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_CurPage_Label_After_RES" />
                    
                                        <asp:Label ID="FavoriteList_Desktop_PageCount_Label_Before" runat="server" Text=" / 共" meta:resourcekey="SingerList_PageCount_Label_Before_RES" />
                                        <asp:Label ID="FavoriteList_Desktop_PageCount_Label" runat="server" Text='<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>' />
                                        <asp:Label ID="FavoriteList_Desktop_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_PageCount_Label_After_RES" />
                                    </div>
                                </div>

                                <asp:LinkButton ID="FavoriteList_NextPage_Button" runat="server" CssClass='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Next">
                                    <span class="glyphicon glyphicon-forward gi-big"></span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="FavoriteList_LastPage_Button" runat="server" CssClass='<%# (Container.StartRowIndex + Container.PageSize) < Container.TotalRowCount ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Last" CommandArgument="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>">
                                    <span class="glyphicon glyphicon-fast-forward gi-big"></span>
                                </asp:LinkButton>

                                <div class="hidden-xs hidden-sm" style="display: inline-block;">
                                    <div class="GridViewPageText" style="display: inline-block;">
                                        <asp:Label ID="FavoriteList_SelectPage_Label_Before" runat="server" Text="到" meta:resourcekey="SingerList_SelectPage_Label_Before_RES" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    </div>
                                    <asp:DropDownList ID="FavoriteList_SelectPage_DropDownList" runat="server" CssClass="GridViewPageButton btn btn-primary" AutoPostBack="True" OnSelectedIndexChanged="FavoriteList_SelectPage_DropDownList_SelectedIndexChanged" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    <div class="GridViewPageText" style="display: inline-block;">
                                        <asp:Label ID="FavoriteList_SelectPage_Label_After" runat="server" Text="頁" meta:resourcekey="SingerList_SelectPage_Label_After_RES" Visible='<%# Container.TotalRowCount > Container.PageSize ? true : false %>' />
                                    </div>
                                </div>
                            </div>        
                        </PagerTemplate>
                    </asp:TemplatePagerField>
                </Fields>
            </asp:DataPager>
        </div>
    </div>
    <div class="hidden-md hidden-lg spacerToFooter"></div>
</asp:Panel>


<asp:Panel ID="SongNumberPanel" runat="server" Visible="false" cssclass="alignCenter">
    <div class="container-fluid">
        <div class="row">
            <div class ="hidden-xs hidden-sm col-md-3 col-lg-3"></div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6" style="padding: 0px;">
                <div class="SubMenuArea" style="padding-bottom: 5px;">
                    <div class ="col-xs-3 col-sm-3 col-md-3 col-lg-3" style="padding-left: 5px; padding-right: 5px;">
                        <div class="row">
                            <asp:Image ImageUrl="images/mainmenu_songnumber.png" runat="server" CssClass="MainImage"/>
                            <asp:Label runat="server" Text="編號" CssClass="MainMenuLabel textshadow" meta:resourcekey="SongNumber_Title_Label_RES" />
                        </div>
                        <div class="row" style="margin-top: 8px;">
                            <div class ="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-left: 5px; padding-right: 5px;">
                                <asp:LinkButton ID="SongNumber_OrderSong_Button" runat="server" CssClass="SongNumberButton btn btn-success btn-lg" OnClick="SongNumber_OrderSong_Button_Click">
                                    <span class="glyphicon glyphicon-plus"></span>
                                    <asp:Label runat="server" Text="點播" CssClass="MainMenuLabel" meta:resourcekey="SongNumber_OrderSong_Button_RES" />
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-left: 5px; padding-right: 5px;">
                                <asp:LinkButton ID="SongNumber_InsertSong_Button" runat="server" CssClass="SongNumberButton btn btn-success btn-lg" OnClick="SongNumber_InsertSong_Button_Click">
                                    <span class="glyphicon glyphicon-retweet gi-big"></span>
                                    <asp:Label runat="server" Text="插播" CssClass="MainMenuLabel" meta:resourcekey="SongNumber_InsertSong_Button_RES" />
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-left: 5px; padding-right: 5px;">
                                <asp:LinkButton ID="SongNumber_Clear_Button" runat="server" CssClass="SongNumberButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon glyphicon-remove gi-big"></span>
                                    <asp:Label runat="server" Text="清除" CssClass="MainMenuLabel" meta:resourcekey="SongNumber_Clear_Button_RES" />
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-9 col-sm-9 col-md-9 col-lg-9">
                        <div class="row" style="margin-top: 5px;">
                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <asp:TextBox ID="SongNumber_QueryNumber_TextBox" runat="server" CssClass="form-control" Font-Size="Large" AutoPostBack="true" MaxLength="6" OnTextChanged="SongNumber_QueryNumber_TextBox_TextChanged" />
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number1_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">1</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number2_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">2</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number3_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">3</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number4_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">4</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number5_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">5</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number6_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">6</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number7_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">7</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number8_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">8</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_Number9_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">9</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-8 col-sm-8 col-md-8 col-lg-8">
                                <asp:LinkButton ID="SongNumber_Number0_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="glyphicon gi-big">0</span>
                                </asp:LinkButton>
                            </div>
                            <div class="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                                <asp:LinkButton ID="SongNumber_BackSpace_Button" runat="server" CssClass="ControlButton btn btn-success btn-lg" OnClick="SongNumber_Number_Button_Click">
                                    <span class="materialicons materialicons-backspace gi-big"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>





<asp:Panel ID="SongListPanel" runat="server" Visible="False" meta:resourcekey="SongListPanelResource1">
    <div class="hidden-md hidden-lg" style="margin-top: 5px;"></div>
    <div class="hidden-xs hidden-sm hidden-lg" style="margin-top: 7px;"></div>
    <asp:GridView ID="SongListGridView" runat="server" DataKeyNames="Song_Id,Song_Singer" AutoGenerateColumns="False" BackColor="White" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CssClass="col-xs-12 col-sm-12 col-md-10 col-lg-10" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" PageSize="10" OnPageIndexChanging="SongListGridView_PageIndexChanging" OnPreRender="SongListGridView_PreRender" OnRowCreated="SongListGridView_RowCreated"  EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" meta:resourcekey="GridView1Resource1">
        <AlternatingRowStyle BackColor="#d9ffd9" />
        <Columns>
            <asp:TemplateField ShowHeader="False" ItemStyle-Width="44px">
                <ItemTemplate>
                    <asp:LinkButton ID="SongListAddSong" runat="server" CssClass='<%# Eval("Song_SongName").ToString()!="" ? "GridViewButton btn btn-success btn-lg" : "GridViewButton btn btn-success btn-lg disabled" %>' OnClick="SongListAddSong_Click">
                        <span class="glyphicon glyphicon-plus"></span>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False" ItemStyle-Width="32px">
                <ItemTemplate>
                    <asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>' ForeColor="#0026ff" /></p>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle CssClass="dgLang" HorizontalAlign="Center"/>
            </asp:TemplateField>

            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" meta:resourcekey="BoundFieldResource2" />
                            
            <asp:TemplateField HeaderText="Song" InsertVisible="False" meta:resourcekey="BoundFieldResource3">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Eval("Song_SongName").ToString() %>' CssClass="dgSong" />
                    <p><asp:LinkButton ID="SongListQuerySinger" runat="server" Text='<%# Eval("Song_Singer").ToString() %>' CssClass="dgSinger dgSingerbutton" OnClick="SongListQuerySinger_Click" /></p>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" CssClass="dgSong" />
            </asp:TemplateField>

            <asp:TemplateField ShowHeader="False" ItemStyle-Width="44px">
                <ItemTemplate>
                    <asp:LinkButton ID="SongListInsSong" runat="server" CssClass='<%# Eval("Song_SongName").ToString()!="" ? "GridViewButton btn btn-success btn-lg" : "GridViewButton btn btn-success btn-lg disabled" %>' OnClick="SongListInsSong_Click">
                        <span class="glyphicon glyphicon-retweet"></span>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
                
        <PagerTemplate>
            <asp:LinkButton ID="SongList_FirstPage_Button" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="First">
                <span class="glyphicon glyphicon-fast-backward gi-big"></span>
            </asp:LinkButton>
            <asp:LinkButton ID="SongList_PreviousPage_Button" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=0 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Prev">
                <span class="glyphicon glyphicon-backward gi-big"></span>
            </asp:LinkButton>

            <div class="GridViewPageText" style="display: inline-block;">
                <div class="hidden-md hidden-lg">
                    <asp:Label ID="SongList_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SongList_CurPage_Label_Before_RES" />
                    <asp:Label ID="SongList_CurPage_Label" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1 %>' />

                    <asp:Label ID="SongList_PageCount_Label_Before" runat="server" Text=" / " />
                    <asp:Label ID="SongList_PageCount_Label" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>' />
                    <asp:Label ID="SongList_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SongList_PageCount_Label_After_RES" />
                </div>
                <div class="hidden-xs hidden-sm">
                    <asp:Label ID="SongList_Desktop_CurPage_Label_Before" runat="server" Text="第" meta:resourcekey="SongList_CurPage_Label_Before_RES" />
                    <asp:Label ID="SongList_Desktop_CurPage_Label" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1 %>' />
                    <asp:Label ID="SongList_Desktop_CurPage_Label_After" runat="server" Text="頁" meta:resourcekey="SongList_CurPage_Label_After_RES" />
                    
                    <asp:Label ID="SongList_Desktop_PageCount_Label_Before" runat="server" Text=" / 共" meta:resourcekey="SongList_PageCount_Label_Before_RES" />
                    <asp:Label ID="SongList_Desktop_PageCount_Label" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>' />
                    <asp:Label ID="SongList_Desktop_PageCount_Label_After" runat="server" Text="頁" meta:resourcekey="SongList_PageCount_Label_After_RES" />
                </div>
            </div>

            <asp:LinkButton ID="SongList_NextPage_Button" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Next">
                <span class="glyphicon glyphicon-forward gi-big"></span>
            </asp:LinkButton>
            <asp:LinkButton ID="SongList_LastPage_Button" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 ? "GridViewPageButton btn btn-lg" : "GridViewPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Last">
                <span class="glyphicon glyphicon-fast-forward gi-big"></span>
            </asp:LinkButton>

            <div class="hidden-xs hidden-sm hidden-md" style="display: inline-block;">
                <div class="GridViewPageText" style="display: inline-block;">
                    <asp:Label ID="SongList_SelectPage_Label_Before" runat="server" Text="到" meta:resourcekey="SongList_SelectPage_Label_Before_RES" />
                </div>
                <asp:DropDownList ID="SongList_SelectPage_DropDownList" runat="server" CssClass="GridViewPageButton btn btn-primary" AutoPostBack="True" OnSelectedIndexChanged="SongList_SelectPage_DropDownList_SelectedIndexChanged" />
                <div class="GridViewPageText" style="display: inline-block;">
                    <asp:Label ID="SongList_SelectPage_Label_After" runat="server" Text="頁" meta:resourcekey="SongList_SelectPage_Label_After_RES" />
                </div>
            </div>
        </PagerTemplate>
        
        <HeaderStyle CssClass="gridviewHeader" Font-Bold="True" ForeColor="White" />
        <FooterStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
        <PagerStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
        <RowStyle CssClass="gridviewRows" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    
    <div class="hidden-md hidden-lg spacerToFooter" style="clear:both"></div>
    <div class="hidden-xs hidden-sm col-md-2 col-lg-2" style="padding-left: 10px; padding-right: 0px;">
        <asp:GridView ID="SongListFilterGridView" runat="server" DataKeyNames="FilterText" AutoGenerateColumns="False" BackColor="White" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" PageSize="1" OnPageIndexChanging="SongListFilterGridView_PageIndexChanging" EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" OnPreRender="SongListFilterGridView_PreRender" PagerStyle-Wrap="True">
            <AlternatingRowStyle BackColor="#d9ffd9"/>
            <Columns>
                <asp:TemplateField ShowHeader="False" ItemStyle-Width="44px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="SongList_Filter_Button" runat="server" Text='<%# Eval("FilterText").ToString() %>' CssClass="GridViewFilterButton btn btn-success btn-lg" Visible='<%# Eval("FilterText").ToString()!="" ? true : false %>' OnClick="SongList_Filter_Button_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <PagerTemplate>
                <div class ="container-fluid">
                    <div class ="row">
                        <div class="col-md-6 col-lg-6" style="padding:0px;">
                            <asp:LinkButton ID="SongList_Filter_PreviousPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=0 ? "GridViewFilterPageButton btn btn-lg" : "GridViewFilterPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Prev">
                                <span class="glyphicon glyphicon-backward gi-big"></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-md-6 col-lg-6" style="padding:0px;">
                            <asp:LinkButton ID="SongList_Filter_NextPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 ? "GridViewFilterPageButton btn btn-lg" : "GridViewFilterPageButton btn btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Next">
                                <span class="glyphicon glyphicon-forward gi-big"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </PagerTemplate>

            <HeaderStyle CssClass="gridviewHeader" Font-Bold="True" ForeColor="White" />
            <FooterStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
            <RowStyle CssClass="gridviewRows GridViewFilterRows" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
</asp:Panel>



