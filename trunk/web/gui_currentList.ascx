<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gui_currentList.ascx.cs" Inherits="web.gui_currentList" %>

<link href="Content/bootstrap.min.css" rel="stylesheet" /> 
<link href="css/gui_layout.css" rel="stylesheet" />
<link href="css/gui_button.css" rel="stylesheet" />

<script src="Scripts/bootstrap.min.js"></script>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />

<section>
    <article>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="180000" OnTick="Timer1_Tick" OnPreRender="Timer1_PreRender" ></asp:Timer>
                <asp:Panel ID="Panel1" runat="server" meta:resourcekey="Panel1Resource1">
                    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Song_Id" AutoGenerateColumns="False" BackColor="White" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" CellPadding="3" CssClass="gridview" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" PageSize="1" OnPageIndexChanging="GridView1_PageIndexChanging"  EnableSortingAndPagingCallbacks="True" ShowHeaderWhenEmpty="True" meta:resourcekey="GridView1Resource1" OnPreRender="GridView1_PreRender" OnRowCreated="GridView1_RowCreated" PagerStyle-Wrap="True">
                        <AlternatingRowStyle BackColor="#d9ffd9"/>
                        <Columns>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BIns" runat="server" CssClass='<%# Eval("Song_SongName").ToString()!="" ? "GridViewButton btn btn-success btn-lg" : "GridViewButton btn btn-success btn-lg disabled" %>' OnClick="BIns_Click">
                                        <span class="glyphicon glyphicon-arrow-up"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="32px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1  + "."%>
                                    <p><asp:Label ID="lSong_Lang" runat="server" Text='<%# Eval("Song_Lang").ToString().Substring(0,1) %>' ForeColor="#0026ff" /></p>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle CssClass="dgSongID" HorizontalAlign="Left"/>
                            </asp:TemplateField>
            
                            <asp:BoundField HeaderText="Song_Id" DataField="Song_Id" Visible="False" meta:resourcekey="BoundFieldResource1" ShowHeader="False" />

                            <asp:TemplateField HeaderText="Song" InsertVisible="False" meta:resourcekey="BoundFieldResource2">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Song_SongName").ToString() %>' CssClass="dgSong" />
                                    <p><asp:Label runat="server" Text='<%# Eval("Song_Singer").ToString() %>' CssClass="dgSinger" /></p>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"/>
                                <ItemStyle HorizontalAlign="Left" CssClass="dgSong" />
                            </asp:TemplateField>
            
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BDel" runat="server" CssClass='<%# Eval("Song_SongName").ToString()!="" ? "GridViewButton btn btn-success btn-lg" : "GridViewButton btn btn-success btn-lg disabled" %>' OnClick="BDel_Click" OnClientClick="return confirm('Delete this song?');">
                                        <span class="glyphicon glyphicon-remove"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
    
                        <PagerTemplate>
                            <asp:LinkButton ID="FirstPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=0 ? "GridViewPageButton btn btn-success btn-lg" : "GridViewPageButton btn btn-success btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="First">
                                <span class="glyphicon glyphicon-step-backward"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="PreviewPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=0 ? "GridViewPageButton btn btn-success btn-lg" : "GridViewPageButton btn btn-success btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Prev">
                                <span class="glyphicon glyphicon-backward"></span>
                            </asp:LinkButton>
                            
                            第<asp:Label ID="lblcurPage" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageIndex+1 %>' />頁 /
                            共<asp:Label ID="lblPageCount" runat="server" Text='<%# ((GridView)Container.Parent.Parent).PageCount %>' />頁
    
                            <asp:LinkButton ID="NextPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 ? "GridViewPageButton btn btn-success btn-lg" : "GridViewPageButton btn btn-success btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Next">
                                <span class="glyphicon glyphicon-forward"></span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="LastPageButton" runat="server" CssClass='<%# ((GridView)Container.Parent.Parent).PageIndex!=((GridView)Container.Parent.Parent).PageCount-1 ? "GridViewPageButton btn btn-success btn-lg" : "GridViewPageButton btn btn-success btn-lg disabled" %>' BorderStyle="None" CommandName="Page" CommandArgument="Last">
                                <span class="glyphicon glyphicon-fast-forward"></span>
                            </asp:LinkButton>

                            到 <asp:DropDownList ID="ddlSelectPage" runat="server" CssClass="GridViewPageButton btn btn-primary dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlSelectPage_SelectedIndexChanged" /> 頁
                        </PagerTemplate>

                        <FooterStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle CssClass="gridviewHeader" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="gridviewPager" Font-Bold="True" ForeColor="White" />
                        <RowStyle CssClass="gridviewRows" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="Gray" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </article>
</section>


