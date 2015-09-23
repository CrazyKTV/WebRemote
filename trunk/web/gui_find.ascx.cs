using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace web
{
    public partial class gui_find : System.Web.UI.UserControl
    {
        public void EnableMainMenuPanel()
        {
            hideAllGridViewPanel();
            MainMenuPanel.Visible = true;
        }

        protected void LPageNumCount_PreRender(object sender, EventArgs e)
        {
            
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }


/*
        private void songList(int page, int rows)
        {
            findCaller.Value = "toTop";
            //pre-set
            hideAllGridViewPanel();
            SongListPanel.Visible = true;


            int currentPageNumber  = page;
            int rowsPerPage = rows;
            try
            {
                string jsonText = "";
                gvMode.Value = "";

                if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Song".ToLower())
                {

                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_SongName like '%" + tSearch.Text.ToString().Trim() + "%'", currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName"); //more than 2000 per rows will be super slow
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Singer".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '%" + tSearch.Text.ToString().Trim() + "%'", page, rows, "Song_Singer, Song_WordCount,Song_SongStroke, Song_SongName"); //more than 2000 per rows will be super slow
                
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "NewSongs".ToLower())
                {
                    tSearch.Text = "";
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_CreatDate >= '" + DateTime.Now.AddDays(-120).ToString("yyyy/MM/dd") + "'", currentPageNumber, rowsPerPage, "Song_CreatDate desc, Song_SongName"); //more than 2000 per rows will be super slow
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "male".ToLower())
                {
                    hideAllGridViewPanel();
                    SingerListPanel.Visible = true;

                    tSearch.Text = "";
                    jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=0", 0, 2000, "Singer_Strokes, Singer_Name");

                    DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);

                    DataView dv3 = new DataView(dt3);
                    //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                    SingerListView.DataSource = dv3;
                    SingerListView.DataBind();
                    //ddSearchType.SelectedIndex = 1;

                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "female".ToLower())
                {
                    hideAllGridViewPanel();
                    SingerListPanel.Visible = true;

                    tSearch.Text = "";
                    jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=1", 0, 2000, "Singer_Strokes, Singer_Name");

                    DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);

                    DataView dv3 = new DataView(dt3);
                    //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                    SingerListView.DataSource = dv3;
                    SingerListView.DataBind();
                    //ddSearchType.SelectedIndex = 1;
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Group".ToLower())
                {
                    hideAllGridViewPanel();
                    SingerListPanel.Visible = true;

                    tSearch.Text = "";
                    jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=2", 0, 2000, "Singer_Strokes, Singer_Name");

                    DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);

                    DataView dv3 = new DataView(dt3);
                    //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                    SingerListView.DataSource = dv3;
                    SingerListView.DataBind();
                    //ddSearchType.SelectedIndex = 1;
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "chorus".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_SingerType=3", currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke, Song_SongName, Song_Singer, Song_CreatDate desc"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "wordcount".ToLower())
                {
                    if (tSearch.Text.ToString().Trim().Length > 0)
                    {
                        jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_WordCount=" + tSearch.Text.ToString().Trim(), currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName,Song_CreatDate desc"); //more than 2000 per rows will be super slow
                    }
                    else {
                        jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '%'", currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName,Song_CreatDate desc"); //more than 2000 per rows will be super slow
                   
                    }
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "toporder".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_PlayCount >= 1 ", currentPageNumber, rowsPerPage, "Song_PlayCount desc, Song_CreatDate desc, Song_SongStroke, Song_SongName"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }

                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Mandarin".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("國語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount, Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                 else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Taiwanese".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("台語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Cantonese".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("粵語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Japanese".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("日語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "English".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("英語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Haka".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("客語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Local".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("原住民語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Korean".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("韓語", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Kid".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("兒歌", null, null, null, currentPageNumber, rowsPerPage, "Song_WordCount,Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "OtherLangs".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong("其它", null, null, null, currentPageNumber, rowsPerPage, "Song_SongStroke,Song_SongName, Song_Singer"); //more than 2000 per rows will be super slow
                    tSearch.Text = "";
                }                    
                else if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Favorites".ToLower())
                {
                    tSearch.Text = "";
                    hideAllGridViewPanel();
                    Panel3.Visible = true;

                    jsonText = CrazyKTVWCF.FavoriteUser(0, 200);

                    DataTable dt2 = GlobalFunctions.JsontoDataTable(jsonText);

                    DataView dv2 = new DataView(dt2);
                    //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                    GridView2.DataSource = dv2;
                    GridView2.DataBind();

                }

                //jsonText = jsonText.TrimStart('"');
                //jsonText = jsonText.TrimEnd('"');
                //jsonText = Regex.Replace(jsonText, @"\\""", @"""");

                try
                {
                    DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);

                    DataView dv = new DataView(dt);
                    //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                    GridView1.DataSource = dv;
                    GridView1.DataBind();

                    if (dv.Count == rows)
                    {
                        BNext.Visible = true;
                        if (page > 0)
                        {
                            BPrevious.Visible = true;
                        }
                        else
                        {
                            BPrevious.Visible = false;
                        }

                    }
                    else
                    {
                        BNext.Visible = false;
                        if (page > 0)
                        {
                            BPrevious.Visible = true;
                        }
                        else
                        {
                            BPrevious.Visible = false;
                        }
                    }

                    
                }
                catch { }

               
                


            }
            catch { }

            //  GlobalFunctions.DerializetoDataTable(); //test data
           

        }
        */

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //clean up data on display
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    tSearch.Text = "";
        //    hideAllGridViewPanel();
        //    SongListPanel.Visible = true;
        //    BNext.Visible = false;
        //    BPrevious.Visible = false;
        //    songDGpage.Value = "0";
        //    LPageNumCount.Text = "1";

        //    var data = GridView2.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get DataKeyNames="User_ID"
        //    gvMode.Value = data.ToString();
        //    FSongList(0, 100, data.ToString());
        //}


        //protected void Bfavorite_Click(object sender, EventArgs e)
        //{
        //    //clean up data on display
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    tSearch.Text = "";
        //    hideAllGridViewPanel();
        //    SongListPanel.Visible = true;
        //    BNext.Visible = false;
        //    BPrevious.Visible = false;
        //    songDGpage.Value = "0";
        //    LPageNumCount.Text = "1";


        //    //LocationID = Me.MyListView.DataKeys(currentItem.DataItemIndex)("LocationID")

        //    //var data = this.GridView2.DataKeys( ((Button)sender).Text.ToString(); //get DataKeyNames="User_ID"
        //    //gvMode.Value = data.ToString();
        //    //FSongList(0, 100, data.ToString());
        //}



        private void FSongList(int page, int rows, string user)
        {
            if (user.Length > 0)
            {
                CrazyKTVWCF.FavoriteLogin(user.ToString()); //need to login first to see favoritesongs
            }

            string jsonText = CrazyKTVWCF.FavoriteSong(user.ToString().Trim(), page, rows);

            DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);
            DataView dv3 = new DataView(dt3);
            //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            SongListGridView.DataSource = dv3;
            SongListGridView.DataBind();

        }


       //protected void LPageNumCount_PreRender(object sender, EventArgs e)
        //{
        //    //LPageNumCount.Text = (int.Parse(songDGpage.Value)+1).ToString();
        //}

        protected void hideAllGridViewPanel()
        {
            SongListPanel.Visible = false;
            Panel3.Visible = false;
            SingerListPanel.Visible = false;
            MainMenuPanel.Visible = false;

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                SingerTypePanel.Visible = false;
            }
        }

        //protected void SingerListView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //clean up data on display
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    tSearch.Text = "";
        //    hideAllGridViewPanel();
        //    SongListPanel.Visible = true;
        //    BNext.Visible = false;
        //    BPrevious.Visible = false;
        //    songDGpage.Value = "0";
        //    LPageNumCount.Text = "1";

        //    var data = SingerListView.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get DataKeyNames="Singer_Name"
        //   // gvMode.Value = data.ToString();
        //    tSearch.Text = data.ToString();
        //    SingerSongList(0, 100, data.ToString());
        //    ddSearchType.SelectedIndex = 1;

        //}

        private void SingerSongList(int page, int rows, string Singer_Name)
        {
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "Singer";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = Singer_Name;
            string jsonText = "";
            DataTable dt = new DataTable();

            if (GuiGlobal.AllSongDTStatus == false)
            {
                jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '%" + Singer_Name.Trim() + "%'", page, rows, "Song_WordCount, Song_SongName"); //more than 2000 per rows will be super slow
                dt = GlobalFunctions.JsontoDataTable(jsonText);
            }
            else
            {
                dt = GuiGlobal.AllSongDT.Clone();
                var query = from row in GuiGlobal.AllSongDT.AsEnumerable()
                            where row.Field<string>("Song_Singer").Equals(Singer_Name) ||
                                  row.Field<string>("Song_Singer").StartsWith(Singer_Name + "&") ||
                                  row.Field<string>("Song_Singer").EndsWith("&" + Singer_Name)
                            select row;

                if (query.Count<DataRow>() > 0)
                {
                    foreach (DataRow Row in query)
                    {
                        dt.ImportRow(Row);
                    }
                }
            }
                
            DataView dv = new DataView(dt);
            dv.Sort = "Song_WordCount, Song_SongName";

            SongListGridView.DataSource = dv;
            SongListGridView.DataBind();
            
            findCaller.Value = "toTop";
        }


        protected void bSearch_PreRender(object sender, EventArgs e)
        {
            try
            {

                //DataView dv = new DataView(dt);
                ////dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                //GridView1.Rows.C = dv;


                //LPageNumCount.Text = (int.Parse(songDGpage.Value) + 1).ToString();
                //int.Parse(LPageNumCount.Text.ToString().Trim())
            }
            catch
            {

            }
        }

        protected void GridView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();
            hideAllGridViewPanel();
            SongListPanel.Visible = true;




            //LocationID = Me.MyListView.DataKeys(currentItem.DataItemIndex)("LocationID")

            var data = this.GridView2.DataKeys[e.Item.DataItemIndex]["User_Id"]; //get DataKeyNames="User_ID"

            FSongList(0, 100, data.ToString());
        }

        protected void MainMenu_FindSingerButton_Click(object sender, EventArgs e)
        {
            hideAllGridViewPanel();
            SingerTypePanel.Visible = true;
        }

        protected void MainMenu_FindLangButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_QuerySongButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_WordCountButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_ChorusSongButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_TopSongButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_NewSongButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_FavoriteSongButton_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_WordCount_Click(object sender, EventArgs e)
        {

        }

        protected void MainMenu_SongNumberButton_Click(object sender, EventArgs e)
        {

        }

        protected void SingerTypeButton_Click(object sender, EventArgs e)
        {
            if (CrazyKTVWCF.checkWCF() == true)
            {
                hideAllGridViewPanel();
                SingerListPanel.Visible = true;

                int PageSize = 0;

                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
                {
                    PageSize = GuiGlobal.SingerTypePageSize;
                }
                else
                {
                    if ((((HiddenField)this.Parent.FindControl("BrowserScreenMode")).Value == "Fullscreen"))
                    {
                        PageSize = GuiGlobal.SingerTypeFullscreenPageSize;
                    }
                    else
                    {
                        PageSize = GuiGlobal.SingerTypeDesktopPageSize;
                    }

                    SingerTypeMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeForeignMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeForeignFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeForeignGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    SingerTypeOtherDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    ((LinkButton)sender).CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                }
                    
                SingerListDataPager.SetPageProperties(0, PageSize, true);

                string jsonText = "";
                string SingerType = "";
                int SingerTypeIndex = -1;

                DataTable[] dtlist =
                {
                    GuiGlobal.SingerTypeMaleDT,
                    GuiGlobal.SingerTypeFemaleDT,
                    GuiGlobal.SingerTypeGroupDT,
                    GuiGlobal.SingerTypeForeignMale,
                    GuiGlobal.SingerTypeForeignFemale,
                    GuiGlobal.SingerTypeForeignGroup,
                    GuiGlobal.SingerTypeOther
                };

                switch (((LinkButton)sender).ID)
                {
                    case "SingerTypeMaleButton":
                    case "SingerTypeMaleDesktopButton":
                        SingerType = "0";
                        SingerTypeIndex = 0;
                        break;
                    case "SingerTypeFemaleButton":
                    case "SingerTypeFemaleDesktopButton":
                        SingerType = "1";
                        SingerTypeIndex = 1;
                        break;
                    case "SingerTypeGroupButton":
                    case "SingerTypeGroupDesktopButton":
                        SingerType = "2";
                        SingerTypeIndex = 2;
                        break;
                    case "SingerTypeForeignMaleButton":
                    case "SingerTypeForeignMaleDesktopButton":
                        SingerType = "4";
                        SingerTypeIndex = 3;
                        break;
                    case "SingerTypeForeignFemaleButton":
                    case "SingerTypeForeignFemaleDesktopButton":
                        SingerType = "5";
                        SingerTypeIndex = 4;
                        break;
                    case "SingerTypeForeignGroupButton":
                    case "SingerTypeForeignGroupDesktopButton":
                        SingerType = "6";
                        SingerTypeIndex = 5;
                        break;
                    case "SingerTypeOtherButton":
                    case "SingerTypeOtherDesktopButton":
                        SingerType = "7";
                        SingerTypeIndex = 6;
                        break;
                }
                ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = SingerTypeIndex.ToString();

                List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };
                jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=" + SingerType, 0, GuiGlobal.QuerySongRows, "Singer_Strokes, Singer_Name");
                DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);
                DataView dv3 = new DataView();

                if (dt3.Rows.Count != dtlist[SingerTypeIndex].Rows.Count)
                {
                    dt3.Columns.Add("ImgFileUrl");

                    foreach (DataRow row in dt3.AsEnumerable())
                    {
                        foreach (string ImgFormat in ImgFormatList)
                        {
                            if (File.Exists(Server.MapPath("/singerimg/" + row["Singer_Name"].ToString() + ImgFormat)))
                            {
                                row["ImgFileUrl"] = "/singerimg/" + row["Singer_Name"].ToString() + ImgFormat;
                                break;
                            }
                        }
                        if (row["ImgFileUrl"].ToString() == "")
                        {
                            row["ImgFileUrl"] = "/images/singertype_default.png";
                        }
                    }

                    dv3 = new DataView(dt3);
                    switch (SingerTypeIndex)
                    {
                        case 0:
                            GuiGlobal.SingerTypeMaleDT = dt3;
                            break;
                        case 1:
                            GuiGlobal.SingerTypeFemaleDT = dt3;
                            break;
                        case 2:
                            GuiGlobal.SingerTypeGroupDT = dt3;
                            break;
                        case 3:
                            GuiGlobal.SingerTypeForeignMale = dt3;
                            break;
                        case 4:
                            GuiGlobal.SingerTypeForeignFemale = dt3;
                            break;
                        case 5:
                            GuiGlobal.SingerTypeForeignGroup = dt3;
                            break;
                        case 6:
                            GuiGlobal.SingerTypeOther = dt3;
                            break;
                    }
                }
                else
                {
                    dv3 = new DataView(dtlist[SingerTypeIndex]);
                }

                SingerListView.DataSource = dv3;
                SingerListView.DataBind();
            }
        }

        protected void SingerListButton_Click(object sender, EventArgs e)
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();

            hideAllGridViewPanel();
            SongListPanel.Visible = true;
            SongListGridView.PageIndex = 0;

            var data = ((LinkButton)sender).CommandArgument.ToString();
            SingerSongList(0, GuiGlobal.QuerySongRows, data.ToString());
        }

        protected void SingerListView_PagePropertiesChanged(object sender, EventArgs e)
        {
            SingerListView.DataSource = null;
            SingerListView.DataBind();

            int PageSize = 0;

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                PageSize = GuiGlobal.SingerTypePageSize;
            }
            else
            {
                if ((((HiddenField)this.Parent.FindControl("BrowserScreenMode")).Value == "Fullscreen"))
                {
                    PageSize = GuiGlobal.SingerTypeFullscreenPageSize;
                }
                else
                {
                    PageSize = GuiGlobal.SingerTypeDesktopPageSize;
                }
            }
                
            int StartRowIndex = SingerListDataPager.StartRowIndex;
            SingerListDataPager.SetPageProperties(StartRowIndex, PageSize, true);

            DataTable[] dtlist =
            {
                    GuiGlobal.SingerTypeMaleDT,
                    GuiGlobal.SingerTypeFemaleDT,
                    GuiGlobal.SingerTypeGroupDT,
                    GuiGlobal.SingerTypeForeignMale,
                    GuiGlobal.SingerTypeForeignFemale,
                    GuiGlobal.SingerTypeForeignGroup,
                    GuiGlobal.SingerTypeOther
            };

            int SingerTypeIndex = Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value);

            DataView dv = new DataView(dtlist[SingerTypeIndex]);
            SingerListView.DataSource = dv;
            SingerListView.DataBind();
        }

        protected void SingerListDataPager_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
        {
            // Check which button raised the event
            switch (e.CommandName)
            {
                case "Next":
                    int newIndex = e.Item.Pager.StartRowIndex + e.Item.Pager.PageSize;
                    if (newIndex <= e.TotalRowCount)
                    {
                        e.NewStartRowIndex = newIndex;
                        e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    }
                    break;
                case "Last":
                    e.NewStartRowIndex = (Convert.ToInt32(e.CommandArgument) - 1) * e.Item.Pager.PageSize;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    break;
                case "Previous":
                    e.NewStartRowIndex = e.Item.Pager.StartRowIndex - e.Item.Pager.PageSize;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    break;
                case "First":
                    e.NewStartRowIndex = 0;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    break;
            }
        }

        protected void SongListAddSong_Click(object sender, EventArgs e)
        {
            findCaller.Value = "";
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            var data = SongListGridView.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID
            CrazyKTVWCF.wcf_addsong(data.ToString().Trim());
            SongListPanel.Visible = true;
        }

        protected void SongListQuerySinger_Click(object sender, EventArgs e)
        {
            findCaller.Value = "";
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            findCaller.Value = "toTop";
            string singer = ((LinkButton)sender).Text.Trim();

            SingerSongList(0, GuiGlobal.QuerySongRows, singer);
        }

        protected void SongListInsSong_Click(object sender, EventArgs e)
        {
            findCaller.Value = "";
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            var data = SongListGridView.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID

            CrazyKTVWCF.wcf_insertsong(data.ToString().Trim());
            SongListPanel.Visible = true;
        }
        protected void SongListGridView_PreRender(object sender, EventArgs e)
        {
            SongListGetData();
        }

        protected void SongListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SongListGridView.PageIndex = e.NewPageIndex;
            SongListGridView.DataBind();
        }

        private void SongListGetData()
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;

            int PageSize = 0;
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                PageSize = GuiGlobal.SongListPageSize;
            }
            else
            {
                if ((((HiddenField)this.Parent.FindControl("BrowserScreenMode")).Value == "Fullscreen"))
                {
                    PageSize = GuiGlobal.SongListFullscreenPageSize;
                }
                else
                {
                    PageSize = GuiGlobal.SongListDesktopPageSize;
                }
            }

            SongListGridView.PageSize = PageSize;

            switch (SongQueryType)
            {
                case "Singer":
                    SingerSongList(0, GuiGlobal.QuerySongRows, SongQueryValue);
                    break;
            }

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (SongListGridView.PageCount > 1)
                {
                    DropDownList ddlSelectPage = (DropDownList)SongListGridView.BottomPagerRow.FindControl("SongListddlSelectPage");
                    for (int i = 0; i < SongListGridView.PageCount; i++)
                    {
                        ddlSelectPage.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
                    }
                    ddlSelectPage.SelectedIndex = SongListGridView.PageIndex;
                }
            }
        }

        protected void SongListddlSelectPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSelectPage = (DropDownList)SongListGridView.BottomPagerRow.FindControl("SongListddlSelectPage");

            int pIndex = 0;
            if (int.TryParse(ddlSelectPage.SelectedValue, out pIndex))
            {
                SongListGridView.PageIndex = pIndex;
            }
        }











        //public SortDirection GridViewSortDirection
        //{
        //    //get
        //    //{
        //    //    if (ViewState["sortDirection"] == null)
        //    //        ViewState["sortDirection"] = SortDirection.Ascending;
        //    //    return (SortDirection)ViewState["sortDirection"];
        //    //}
        //    //set
        //    //{
        //    //    ViewState["sortDirection"] = value;
        //    //}
        //}


    }
}