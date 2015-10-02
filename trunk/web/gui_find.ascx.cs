using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Drawing.Imaging;

namespace web
{
    public partial class gui_find : System.Web.UI.UserControl
    {
        public void EnableMainMenuPanel()
        {
            hideAllGridViewPanel();
            MainMenuPanel.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            QuerySong_QueryName_TextBox.Focus();
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

        protected void hideAllGridViewPanel()
        {
            MainMenuPanel.Visible = false;
            SingerListPanel.Visible = false;
            SongListPanel.Visible = false;
            Panel3.Visible = false;

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                SingerTypePanel.Visible = false;
                SongLangPanel.Visible = false;
                QuerySongPanel.Visible = false;
            }
        }

        private void SongList(int page, int rows, string QueryType, string QueryValue)
        {
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = QueryType;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = QueryValue;

            string QueryFilterList = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
            string QueryFilterValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value;
            string jsonText = "";
            string dvSortStr = "";
            DataTable dt = new DataTable();

            if (GuiGlobal.AllSongDTStatus == false)
            {
                switch (QueryType)
                {
                    case "Singer":
                        jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '%" + QueryValue.Trim() + "%'", page, rows, "Song_WordCount,Song_SongStroke,Song_SongName");
                        dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName";
                        break;
                    case "SongLang":
                        jsonText = CrazyKTVWCF.QuerySong(QueryValue, null, null, null, page, rows, "Song_WordCount,Song_SongStroke,Song_SongName,Song_Singer");
                        dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";
                        break;
                }
                dt = GlobalFunctions.JsontoDataTable(jsonText);
            }
            else
            {
                dt = GuiGlobal.AllSongDT.Clone();

                switch (QueryType)
                {
                    case "Singer":
                        dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName";
                        var SingerQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                          where row.Field<string>("Song_Singer").Equals(QueryValue) ||
                                                row.Field<string>("Song_Singer").StartsWith(QueryValue + "&") ||
                                                row.Field<string>("Song_Singer").EndsWith("&" + QueryValue)
                                          select row;

                        if (SingerQuery.Count<DataRow>() > 0)
                        {
                            if (QueryFilterList != "")
                            {
                                if (QueryFilterValue == "全部") QueryFilterValue = "";
                                foreach (DataRow row in SingerQuery)
                                {
                                    if (row["Song_Lang"].ToString().Contains(QueryFilterValue))
                                    {
                                        dt.ImportRow(row);
                                    }
                                }
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add("全部");

                                foreach (DataRow row in SingerQuery)
                                {
                                    if (list.IndexOf(row["Song_Lang"].ToString()) < 0)
                                    {
                                        list.Add(row["Song_Lang"].ToString());
                                    }
                                    dt.ImportRow(row);
                                }

                                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                                {
                                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                                }
                            }
                        }
                        break;
                    case "SongLang":
                        dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";
                        var SongLangQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                            where row.Field<string>("Song_Lang").Equals(QueryValue)
                                            select row;

                        if (SongLangQuery.Count<DataRow>() > 0)
                        {
                            if (QueryFilterList != "")
                            {
                                foreach (DataRow row in SongLangQuery)
                                {
                                    if (QueryFilterValue == "全部" || QueryFilterValue == "")
                                    {
                                        dt.ImportRow(row);
                                    }
                                    else
                                    {
                                        if (row["Song_WordCount"].ToString().Equals(QueryFilterValue))
                                        {
                                            dt.ImportRow(row);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add("全部");

                                foreach (DataRow row in SongLangQuery)
                                {
                                    if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                    {
                                        list.Add(row["Song_WordCount"].ToString());
                                    }
                                    dt.ImportRow(row);
                                }

                                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                                {
                                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                                }
                            }
                        }
                        break;
                    case "SongName":
                        dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";
                        var SongNameQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                            where row.Field<string>("Song_SongName").Contains(QueryValue)
                                            select row;

                        if (SongNameQuery.Count<DataRow>() > 0)
                        {
                            if (QueryFilterList != "")
                            {
                                if (QueryFilterValue == "全部") QueryFilterValue = "";
                                foreach (DataRow row in SongNameQuery)
                                {
                                    if (row["Song_WordCount"].ToString().Contains(QueryFilterValue))
                                    {
                                        dt.ImportRow(row);
                                    }
                                }
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add("全部");

                                foreach (DataRow row in SongNameQuery)
                                {
                                    if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                    {
                                        list.Add(row["Song_WordCount"].ToString());
                                    }
                                    dt.ImportRow(row);
                                }

                                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                                {
                                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                                }
                            }
                        }
                        break;
                    case "SingerName":
                        dvSortStr = "Song_Singer, Song_WordCount, Song_SongStroke, Song_SongName";
                        var SingerNameQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                              where row.Field<string>("Song_Singer").Contains(QueryValue)
                                              select row;

                        if (SingerNameQuery.Count<DataRow>() > 0)
                        {
                            if (QueryFilterList != "")
                            {
                                if (QueryFilterValue == "全部") QueryFilterValue = "";
                                foreach (DataRow row in SingerNameQuery)
                                {
                                    if (row["Song_Lang"].ToString().Contains(QueryFilterValue))
                                    {
                                        dt.ImportRow(row);
                                    }
                                }
                            }
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add("全部");

                                foreach (DataRow row in SingerNameQuery)
                                {
                                    if (list.IndexOf(row["Song_Lang"].ToString()) < 0)
                                    {
                                        list.Add(row["Song_Lang"].ToString());
                                    }
                                    dt.ImportRow(row);
                                }

                                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                                {
                                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                                }
                            }
                        }
                        break;
                }
            }

            DataView dv = new DataView(dt);
            dv.Sort = dvSortStr;
            dt = dv.ToTable();
            
            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (dt.Rows.Count == 0 && GuiGlobal.AllSongDTStatus == false)
                {
                    DataColumn col = new DataColumn("Song_Id");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_Lang");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_SongName");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_Singer");
                    dt.Columns.Add(col);
                }

                int CurPageSize = SongListGridView.PageSize;
                if (dt.Rows.Count > CurPageSize)
                {
                    if (dt.Rows.Count % CurPageSize > 0)
                    {
                        int NewRowCount = CurPageSize - (dt.Rows.Count % CurPageSize);
                        for (int i = 0; i < NewRowCount; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["Song_Lang"] = " ";
                            dt.Rows.Add(row);
                        }
                    }
                    SongListGridView.ShowFooter = false;
                }
                else
                {
                    int NewRowCount = CurPageSize - dt.Rows.Count;
                    for (int i = 0; i < NewRowCount; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["Song_Lang"] = " ";
                        dt.Rows.Add(row);
                    }
                    SongListGridView.ShowFooter = true;
                }
            }

            SongListGridView.DataSource = dt;
            SongListGridView.DataBind();
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

        protected void MainMenu_Button_Click(object sender, EventArgs e)
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            switch (((LinkButton)sender).ID)
            {
                case "MainMenu_FindSingerButton":
                    hideAllGridViewPanel();
                    SingerTypePanel.Visible = true;
                    break;
                case "MainMenu_FindLangButton":
                    hideAllGridViewPanel();
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_QuerySongButton":
                    hideAllGridViewPanel();
                    QuerySongPanel.Visible = true;
                    if (SongQueryType == "SongName" || SongQueryType == "SingerName")
                    {
                        SongListPanel.Visible = true;
                    }
                    else
                    {
                        QuerySong_QueryName_TextBox.Text = "";
                    }
                    break;
                case "MainMenu_WordCountButton":
                    hideAllGridViewPanel();

                    break;
                case "MainMenu_ChorusSongButton":
                    hideAllGridViewPanel();

                    break;
                case "MainMenu_TopSongButton":
                    hideAllGridViewPanel();

                    break;
                case "MainMenu_NewSongButton":
                    hideAllGridViewPanel();

                    break;
                case "MainMenu_FavoriteSongButton":
                    hideAllGridViewPanel();

                    break;
                case "MainMenu_SongNumberButton":
                    hideAllGridViewPanel();

                    break;

            }
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
                    PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);

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

                DataView dv3 = new DataView();

                if (GuiGlobal.SingerTypeDTStatus == false)
                {
                    List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };
                    jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=" + SingerType, 0, GuiGlobal.QuerySongRows, "Singer_Strokes, Singer_Name");
                    DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);

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
            SongListGridView.PageIndex = 0;
            SongListFilterGridView.DataSource = null;
            SongListFilterGridView.DataBind();
            SongListFilterGridView.PageIndex = 0;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            var data = ((Label)((LinkButton)sender).Controls[0]).Text;
            SongList(0, GuiGlobal.QuerySongRows, "Singer", data.ToString());
        }

        private void SingerListGetData()
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
                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
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

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (SingerListDataPager.TotalRowCount > PageSize)
                {
                    int PageCount = Convert.ToInt32(Math.Ceiling((double)SingerListDataPager.TotalRowCount / PageSize));
                    DropDownList ddlSelectPage = (DropDownList)SingerListDataPager.Controls[0].FindControl("SingerList_SelectPage_DropDownList");
                    for (int i = 0; i < PageCount; i++)
                    {
                        ddlSelectPage.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
                    }
                    ddlSelectPage.SelectedIndex = SingerListDataPager.StartRowIndex / PageSize;
                }
            }
        }

        protected void SingerListView_PreRender(object sender, EventArgs e)
        {
            SingerListGetData();
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
            ScrolltoTop.Value = "True";
        }

        protected void SingerList_SelectPage_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                DropDownList ddlSelectPage = (DropDownList)SingerListDataPager.Controls[0].FindControl("SingerList_SelectPage_DropDownList");

                int PageSize = 0;

                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
                int StartRowIndex = Convert.ToInt32(ddlSelectPage.SelectedValue) * PageSize;
                SingerListDataPager.SetPageProperties(StartRowIndex, PageSize, true);
            }
        }

        protected void SongListAddSong_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            var data = SongListGridView.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID
            CrazyKTVWCF.wcf_addsong(data.ToString().Trim());
            SongListPanel.Visible = true;
        }

        protected void SongListQuerySinger_Click(object sender, EventArgs e)
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();
            SongListGridView.PageIndex = 0;
            SongListFilterGridView.DataSource = null;
            SongListFilterGridView.DataBind();
            SongListFilterGridView.PageIndex = 0;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            string singer = ((LinkButton)sender).Text.Trim();

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                SongLangPanel.Visible = false;
                SingerTypePanel.Visible = true;
                int PageSize = 0;
                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
                int StartRowIndex = 0;
                SingerListDataPager.SetPageProperties(StartRowIndex, PageSize, true);

                SingerTypeMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeForeignMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeForeignFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeForeignGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SingerTypeOtherDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;

                switch (GuiGlobal.SingerType[GuiGlobal.SingerName.IndexOf(singer)])
                {
                    case "0":
                        SingerTypeMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "0";
                        break;
                    case "1":
                        SingerTypeFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "1";
                        break;
                    case "2":
                        SingerTypeGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "2";
                        break;
                    case "3":
                        SingerTypeForeignMaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "3";
                        break;
                    case "4":
                        SingerTypeForeignFemaleDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "4";
                        break;
                    case "5":
                        SingerTypeForeignGroupDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "5";
                        break;
                    case "6":
                        SingerTypeOtherDesktopButton.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                        ((HiddenField)this.Parent.FindControl("CurrentSinerType")).Value = "6";
                        break;
                }

                
                ((LinkButton)this.Parent.FindControl("MainMenu_FindLangDesktopButton")).CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
                ((LinkButton)this.Parent.FindControl("MainMenu_FindSingerDesktopButton")).CssClass = "ControlButton " + GuiGlobal.ActiveButtonCssClass;
            }
            SongList(0, GuiGlobal.QuerySongRows, "Singer", singer);
        }

        protected void SongListInsSong_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            var data = SongListGridView.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID

            CrazyKTVWCF.wcf_insertsong(data.ToString().Trim());
            SongListPanel.Visible = true;
        }

        protected void SongListGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                    if (SongQueryValue == "") SongQueryValue = "尚無資料";
                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();

                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Attributes.Add("colspan", "5");
                    tcHeader[0].CssClass = "gridviewHeader";
                    tcHeader[0].Text = "歌曲列表 (" + SongQueryValue + ")";
                    break;
            }
        }

        protected void SongListGridView_PreRender(object sender, EventArgs e)
        {
            SongListGetData();
        }

        protected void SongListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ScrolltoTop.Value = "True";
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
                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 2;
            }

            SongListGridView.PageSize = PageSize;

            SongList(0, GuiGlobal.QuerySongRows, SongQueryType, SongQueryValue);

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (SongListGridView.PageCount > 1)
                {
                    DropDownList ddlSelectPage = (DropDownList)SongListGridView.BottomPagerRow.FindControl("SongList_SelectPage_DropDownList");
                    for (int i = 0; i < SongListGridView.PageCount; i++)
                    {
                        ddlSelectPage.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
                    }
                    ddlSelectPage.SelectedIndex = SongListGridView.PageIndex;
                }
            }
        }

        protected void SongList_SelectPage_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSelectPage = (DropDownList)SongListGridView.BottomPagerRow.FindControl("SongList_SelectPage_DropDownList");

            int pIndex = 0;
            if (int.TryParse(ddlSelectPage.SelectedValue, out pIndex))
            {
                SongListGridView.PageIndex = pIndex;
            }
        }

        protected void SongLangPanel_PreRender(object sender, EventArgs e)
        {
            string LangImgFile = "";

            System.Web.UI.WebControls.Image[] SongLangImage =
            {
                SongLang1Image,
                SongLang2Image,
                SongLang3Image,
                SongLang4Image,
                SongLang5Image,
                SongLang6Image,
                SongLang7Image,
                SongLang8Image,
                SongLang9Image,
                SongLang10Image
            };

            System.Web.UI.WebControls.Image[] SongLangDesktopImage =
            {
                SongLang1DesktopImage,
                SongLang2DesktopImage,
                SongLang3DesktopImage,
                SongLang4DesktopImage,
                SongLang5DesktopImage,
                SongLang6DesktopImage,
                SongLang7DesktopImage,
                SongLang8DesktopImage,
                SongLang9DesktopImage,
                SongLang10DesktopImage
            };

            System.Web.UI.WebControls.Label[] SongLangLabel =
            {
                SongLang1Label,
                SongLang2Label,
                SongLang3Label,
                SongLang4Label,
                SongLang5Label,
                SongLang6Label,
                SongLang7Label,
                SongLang8Label,
                SongLang9Label,
                SongLang10Label
            };

            System.Web.UI.WebControls.Label[] SongLangDesktopLabel =
            {
                SongLang1DesktopLabel,
                SongLang2DesktopLabel,
                SongLang3DesktopLabel,
                SongLang4DesktopLabel,
                SongLang5DesktopLabel,
                SongLang6DesktopLabel,
                SongLang7DesktopLabel,
                SongLang8DesktopLabel,
                SongLang9DesktopLabel,
                SongLang10DesktopLabel
            };

            for (int i = 0; i < GuiGlobal.SongLangList.Count; i++)
            {
                LangImgFile = "/images/langstr_" + GuiGlobal.SongLangList[i].Substring(0, 1) + ".png";
                if (File.Exists(Server.MapPath(LangImgFile)))
                {
                    SongLangImage[i].ImageUrl = LangImgFile;
                    SongLangDesktopImage[i].ImageUrl = LangImgFile;
                }
                else
                {
                    SongLangImage[i].ImageUrl = DrawLangImage(GuiGlobal.SongLangList[i].Substring(0, 1));
                    SongLangDesktopImage[i].ImageUrl = LangImgFile;
                }

                if (GuiGlobal.SongLangList[i].Length > 2)
                {
                    SongLangLabel[i].Text = GuiGlobal.SongLangList[i].Substring(0,1) + GuiGlobal.SongLangList[i].Substring(GuiGlobal.SongLangList[i].Length - 1, 1);
                    SongLangDesktopLabel[i].Text = GuiGlobal.SongLangList[i].Substring(0, 1) + GuiGlobal.SongLangList[i].Substring(GuiGlobal.SongLangList[i].Length - 1, 1);
                }
                else
                {
                    SongLangLabel[i].Text = GuiGlobal.SongLangList[i];
                    SongLangDesktopLabel[i].Text = GuiGlobal.SongLangList[i];
                }
            }
        }

        private string DrawLangImage(string LangStr)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Font font = new Font("標楷體", 116, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = 128;
            int height = 100;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawString(LangStr, font, new SolidBrush(Color.FromArgb(90, 0, 0, 0)), -12, -8);
            graphics.DrawString(LangStr, font, new SolidBrush(Color.FromArgb(255, 255, 255)), -14, -10);
            graphics.Flush();
            graphics.Dispose();
            string fileName = "langstr_" + LangStr + ".png";
            bitmap.Save(Server.MapPath("/images/") + fileName, ImageFormat.Png);
            return "/images/" + fileName;
        }

        protected void SongLangButton_Click(object sender, EventArgs e)
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();
            SongListGridView.PageIndex = 0;
            SongListFilterGridView.DataSource = null;
            SongListFilterGridView.DataBind();
            SongListFilterGridView.PageIndex = 0;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            var data = ((Label)((LinkButton)sender).Controls[1]).Text;
            ((HiddenField)this.Parent.FindControl("CurrentSongLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                SongLang1DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang2DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang3DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang4DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang5DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang6DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang7DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang8DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang9DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                SongLang10DesktopButton.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                ((LinkButton)sender).CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
            }

            SongList(0, GuiGlobal.QuerySongRows, "SongLang", data.ToString());
        }


        protected void SongListFilterGridView_PreRender(object sender, EventArgs e)
        {
            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (SongListPanel.Visible)
                {
                    DataTable dt = new DataTable();
                    DataColumn col = new DataColumn("FilterText", typeof(string));
                    dt.Columns.Add(col);
                    col = new DataColumn("FilterSort", typeof(Int32));
                    dt.Columns.Add(col);

                    string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
                    string SongQueryFilterValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value;
                    string SongQueryFilterList = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;

                    List<string> list = new List<string>(SongQueryFilterList.Split(','));
                    foreach (string liststr in list)
                    {
                        DataRow row = dt.NewRow();
                        switch (SongQueryType)
                        {
                            case "Singer":
                            case "SingerName":
                                row["FilterText"] = liststr;
                                row["FilterSort"] = GuiGlobal.SongLangList.IndexOf(liststr) + 1;
                                break;
                            case "SongLang":
                            case "SongName":
                                if (liststr == "全部" || liststr == "")
                                {
                                    row["FilterText"] = liststr;
                                    row["FilterSort"] = -1;
                                }
                                else
                                {
                                    row["FilterText"] = liststr + "字";
                                    row["FilterSort"] = Convert.ToInt32(liststr);
                                }
                                break;
                        }
                        
                        
                        dt.Rows.Add(row);
                    }

                    int CurPageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 2;
                    SongListFilterGridView.PageSize = CurPageSize;

                    DataView dv = new DataView(dt);
                    dv.Sort = "FilterSort";
                    dt = dv.ToTable();

                    if (dt.Rows.Count > CurPageSize)
                    {
                        if (dt.Rows.Count % CurPageSize > 0)
                        {
                            int NewRowCount = CurPageSize - (dt.Rows.Count % CurPageSize);
                            for (int i = 0; i < NewRowCount; i++)
                            {
                                DataRow row = dt.NewRow();
                                dt.Rows.Add(row);
                            }
                        }

                        SongListFilterGridView.AllowPaging = true;
                        SongListFilterGridView.ShowFooter = false;
                    }
                    else
                    {
                        int NewRowCount = CurPageSize - dt.Rows.Count;
                        for (int i = 0; i < NewRowCount; i++)
                        {
                            DataRow row = dt.NewRow();
                            dt.Rows.Add(row);
                        }
                        SongListFilterGridView.ShowFooter = true;
                    }

                    SongListFilterGridView.DataSource = dt;
                    SongListFilterGridView.DataBind();

                    if (SongQueryType != "")
                    {
                        TableCellCollection tcHeader = SongListFilterGridView.HeaderRow.Cells;
                        tcHeader.Clear();

                        tcHeader.Add(new TableHeaderCell());
                        tcHeader[0].Attributes.Add("colspan", "1");
                        tcHeader[0].CssClass = "gridviewHeader";

                        switch (SongQueryType)
                        {
                            case "Singer":
                            case "SingerName":
                                tcHeader[0].Text = "語系";
                                break;
                            case "SongLang":
                            case "SongName":
                                tcHeader[0].Text = "字數";
                                break;
                        }
                    }

                    if (SongQueryFilterValue != "")
                    {
                        foreach (Control lb in SongListFilterGridView.Rows)
                        {
                            switch (SongQueryType)
                            {
                                case "Singer":
                                case "SingerName":
                                    if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue)
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                    }
                                    else
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                    }
                                    break;
                                case "SongLang":
                                case "SongName":
                                    if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue + "字")
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                    }
                                    else
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        foreach (Control lb in SongListFilterGridView.Rows)
                        {
                            if (((LinkButton)lb.Controls[0].Controls[1]).Text == "全部")
                            {
                                ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                            }
                        }
                    }
                }
            }
        }

        protected void SongListFilterGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SongListFilterGridView.PageIndex = e.NewPageIndex;
            SongListFilterGridView.DataBind();
        }

        protected void SongList_Filter_Button_Click(object sender, EventArgs e)
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;

            switch (SongQueryType)
            {
                case "Singer":
                case "SingerName":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text;
                    break;
                case "SongLang":
                case "SongName":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
            }
            SongListGridView.PageIndex = 0;
            SongList(0, GuiGlobal.QuerySongRows, SongQueryType, SongQueryValue);
        }

        private void QuerySong_GetData()
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();
            SongListGridView.PageIndex = 0;
            SongListFilterGridView.DataSource = null;
            SongListFilterGridView.DataBind();
            SongListFilterGridView.PageIndex = 0;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";
            

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (QuerySong_SongName_Desktop_RadioButton.Checked)
                {
                    SongList(0, GuiGlobal.QuerySongRows, "SongName", QuerySong_QueryName_Desktop_TextBox.Text);
                }
                else
                {
                    SongList(0, GuiGlobal.QuerySongRows, "SingerName", QuerySong_QueryName_Desktop_TextBox.Text);
                }
                ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value = QuerySong_QueryName_Desktop_TextBox.Text;
            }
            else
            {
                if (QuerySong_SongName_RadioButton.Checked)
                {
                    SongList(0, GuiGlobal.QuerySongRows, "SongName", QuerySong_QueryName_TextBox.Text);
                }
                else
                {
                    SongList(0, GuiGlobal.QuerySongRows, "SingerName", QuerySong_QueryName_TextBox.Text);
                }
            }
            SongListPanel.Visible = true;
        }

        protected void QuerySong_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (QuerySong_QueryName_Desktop_TextBox.Text != "") QuerySong_GetData();
            }
            else
            {
                if (QuerySong_QueryName_TextBox.Text != "") QuerySong_GetData();
            }
        }

        protected void QuerySong_QueryName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "") QuerySong_GetData();
           ((TextBox)sender).Focus();
        }
    }
}