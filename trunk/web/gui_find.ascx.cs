﻿using System;
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
using System.Web;

namespace web
{
    public partial class gui_find : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void hideAllGridViewPanel()
        {
            MainMenuPanel.Visible = false;
            SingerListPanel.Visible = false;
            MobileFilterPanel.Visible = false;
            FavoriteListPanel.Visible = false;
            SongListPanel.Visible = false;

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                SingerTypePanel.Visible = false;
                SongLangPanel.Visible = false;
                QuerySongPanel.Visible = false;
                SongNumberPanel.Visible = false;
                FavoriteSongPanel.Visible = false;
            }
        }

        protected void CleanUpData()
        {
            //clean up data on display
            SongListGridView.DataSource = null;
            SongListGridView.DataBind();
            SongListGridView.PageIndex = 0;
            SongListFilterGridView.DataSource = null;
            SongListFilterGridView.DataBind();
            SongListFilterGridView.PageIndex = 0;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterPage")).Value = "0";
        }

        protected void MainMenu_Button_Click(object sender, EventArgs e)
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "MainMenuPanel";

            hideAllGridViewPanel();
            switch (((LinkButton)sender).ID)
            {
                case "MainMenu_FindSingerButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "Singer";
                    SingerTypePanel.Visible = true;
                    break;
                case "MainMenu_FindLangButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongLang";
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_QuerySongButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = "";
                    if (QuerySong_SongName_RadioButton.Checked)
                    {
                        ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongName";
                    }
                    else
                    {
                        ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SingerName";
                    }
                    QuerySongPanel.Visible = true;
                    SongListPanel.Visible = true;
                    break;
                case "MainMenu_SongStrokeDesktopButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongStroke";
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_ChorusSongButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "ChorusSong";
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_NewSongButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "NewSong";
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_TopSongButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "TopSong";
                    SongLangPanel.Visible = true;
                    break;
                case "MainMenu_FavoriteSongButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "FavoriteSong";
                    FavoriteSongPanel.Visible = true;
                    break;
                case "MainMenu_SongNumberButton":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongNumber";
                    SongNumberPanel.Visible = true;
                    SongListPanel.Visible = true;
                    break;
            }
        }

        private void SongList(int page, int rows, string QueryType, string QueryValue)
        {
            string QueryFilterList = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
            string QueryFilterValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value;

            string dvSortStr = "";

            DataTable dt = new DataTable();
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
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
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
                case "SongStroke":
                    dvSortStr = "Song_SongStroke, Song_SongName";
                    var SongStrokeQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                          where row.Field<string>("Song_Lang").Equals(QueryValue)
                                          select row;

                    if (SongStrokeQuery.Count<DataRow>() > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            foreach (DataRow row in SongStrokeQuery)
                            {
                                if (QueryFilterValue == "全部" || QueryFilterValue == "")
                                {
                                    dt.ImportRow(row);
                                }
                                else
                                {
                                    if (row["Song_SongStroke"].ToString().Equals(QueryFilterValue))
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

                            foreach (DataRow row in SongStrokeQuery)
                            {
                                if (list.IndexOf(row["Song_SongStroke"].ToString()) < 0)
                                {
                                    list.Add(row["Song_SongStroke"].ToString());
                                }
                                dt.ImportRow(row);
                            }
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                        }
                    }
                    break;
                case "ChorusSong":
                    dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";
                    var ChorusSongQuery = from row in GuiGlobal.ChorusSongDT.AsEnumerable()
                                          where row.Field<string>("Song_Lang").Equals(QueryValue)
                                          select row;

                    if (ChorusSongQuery.Count<DataRow>() > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            foreach (DataRow row in ChorusSongQuery)
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

                            foreach (DataRow row in ChorusSongQuery)
                            {
                                if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                {
                                    list.Add(row["Song_WordCount"].ToString());
                                }
                                dt.ImportRow(row);
                            }
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                        }
                    }
                    break;
                case "NewSong":
                    dvSortStr = "";
                    var NewSongQuery = from row in GuiGlobal.NewSongDT.AsEnumerable()
                                       where row.Field<string>("Song_Lang").Equals(QueryValue)
                                       select row;

                    if (NewSongQuery.Count<DataRow>() > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            foreach (DataRow row in NewSongQuery)
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

                            foreach (DataRow row in NewSongQuery)
                            {
                                if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                {
                                    list.Add(row["Song_WordCount"].ToString());
                                }
                                dt.ImportRow(row);
                            }
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                        }
                    }
                    break;
                case "TopSong":
                    dvSortStr = "";
                    var TopSongQuery = from row in GuiGlobal.TopSongDT.AsEnumerable()
                                       where row.Field<string>("Song_Lang").Equals(QueryValue)
                                       select row;

                    if (TopSongQuery.Count<DataRow>() > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            foreach (DataRow row in TopSongQuery)
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

                            foreach (DataRow row in TopSongQuery)
                            {
                                if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                {
                                    list.Add(row["Song_WordCount"].ToString());
                                }
                                dt.ImportRow(row);
                            }
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                        }
                    }
                    break;
                case "FavoriteSong":
                    dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";

                    CrazyKTVWCF.FavoriteLogin(QueryValue); //need to login first to see favoritesongs
                    string jsonText = CrazyKTVWCF.FavoriteSong(QueryValue, 0, GuiGlobal.QuerySongRows);
                    DataTable FavoriteSongDT = GlobalFunctions.JsontoDataTable(jsonText);

                    if (FavoriteSongDT.Rows.Count > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            foreach (DataRow row in FavoriteSongDT.AsEnumerable())
                            {
                                if (QueryFilterValue == "全部" || QueryFilterValue == "")
                                {
                                    dt.ImportRow(row);
                                }
                                else
                                {
                                    switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                                    {
                                        case "錢櫃英語排行榜":
                                        case "錢櫃粵語排行榜":
                                        case "錢櫃日語排行榜":
                                            if (row["Song_WordCount"].ToString().Equals(QueryFilterValue))
                                            {
                                                dt.ImportRow(row);
                                            }
                                            break;
                                        default:
                                            if (row["Song_Lang"].ToString().Equals(QueryFilterValue))
                                            {
                                                dt.ImportRow(row);
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            List<string> list = new List<string>();
                            list.Add("全部");

                            foreach (DataRow row in FavoriteSongDT.AsEnumerable())
                            {
                                switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                                {
                                    case "錢櫃英語排行榜":
                                    case "錢櫃粵語排行榜":
                                    case "錢櫃日語排行榜":
                                        if (list.IndexOf(row["Song_WordCount"].ToString()) < 0)
                                        {
                                            list.Add(row["Song_WordCount"].ToString());
                                        }
                                        break;
                                    default:
                                        if (list.IndexOf(row["Song_Lang"].ToString()) < 0)
                                        {
                                            list.Add(row["Song_Lang"].ToString());
                                        }
                                        break;
                                }
                                dt.ImportRow(row);
                            }
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value = string.Join(",", list);
                        }
                    }
                    break;
                case "SongNumber":
                    dvSortStr = "Song_Id, Song_WordCount, Song_SongStroke, Song_SongName";
                    var SongNumberQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                          where row.Field<string>("Song_Id").Contains(QueryValue)
                                          select row;

                    if (SongNumberQuery.Count<DataRow>() > 0)
                    {
                        if (QueryFilterList != "")
                        {
                            if (QueryFilterValue == "全部") QueryFilterValue = "";
                            foreach (DataRow row in SongNumberQuery)
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

                            foreach (DataRow row in SongNumberQuery)
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
            CleanUpData();

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            string SingerName = ((LinkButton)sender).Text.Trim();

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

                switch (GuiGlobal.SingerType[GuiGlobal.SingerName.IndexOf(SingerName)])
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
            else
            {
                ScrolltoTop.Value = "True";
            }

            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "Singer";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = SingerName;
        }

        protected void SongListInsSong_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            var data = SongListGridView.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID

            CrazyKTVWCF.wcf_addsong(data.ToString().Trim());
            CrazyKTVWCF.wcf_insertsong(data.ToString().Trim());
            SongListPanel.Visible = true;
        }

        protected void SongListGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:
                    string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
                    string SongQueryValue = "";
                    string TitleName = "歌曲列表";

                    switch (SongQueryType)
                    {
                        case "Singer":
                            TitleName = "歌星名稱";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "SongLang":
                            TitleName = "歌曲語系";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "SongName":
                            TitleName = "歌曲名稱";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value;
                            break;
                        case "SingerName":
                            TitleName = "歌星名稱";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value;
                            break;
                        case "SongStroke":
                            TitleName = "歌曲筆劃";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "ChorusSong":
                            TitleName = "合唱歌曲";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "NewSong":
                            TitleName = "新進歌曲";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "TopSong":
                            TitleName = "排行歌曲";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "FavoriteSong":
                            TitleName = "我的最愛";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                        case "SongNumber":
                            TitleName = "歌曲編號";
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongNumber")).Value;
                            break;
                        default:
                            SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                            if (SongQueryValue == "") SongQueryValue = "尚無資料";
                            break;
                    }

                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();

                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Attributes.Add("colspan", "5");
                    tcHeader[0].CssClass = "gridviewHeader";
                    tcHeader[0].Text = TitleName + " (" + SongQueryValue + ")";
                    break;
            }
        }

        protected void SongListGridView_PreRender(object sender, EventArgs e)
        {
            SongListGetData();
        }

        private void SongListGetData()
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;

            switch (SongQueryType)
            {
                case "SongName":
                case "SingerName":
                    SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value;
                    break;
                case "SongNumber":
                    SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongNumber")).Value;
                    break;
            }

            int PageSize = 0;
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                PageSize = GuiGlobal.SongListPageSize;
            }
            else
            {
                if (SongNumberPanel.Visible)
                {
                    PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 7;
                }
                else
                {
                    PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 2;
                }
                if (PageSize < 1) PageSize = 1;

                SongListGridView.PageIndex = Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value);
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

        protected void SongListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SongListGridView.PageIndex = e.NewPageIndex;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = e.NewPageIndex.ToString();

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;

                switch (SongQueryType)
                {
                    case "SongLang":
                        ((HiddenField)this.Parent.FindControl("CurrentSongLangPage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "SongName":
                    case "SingerName":
                        ((HiddenField)this.Parent.FindControl("CurrentQuerySongPage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "SongStroke":
                        ((HiddenField)this.Parent.FindControl("CurrentSongStrokePage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "ChorusSong":
                        ((HiddenField)this.Parent.FindControl("CurrentChorusSongPage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "NewSong":
                        ((HiddenField)this.Parent.FindControl("CurrentNewSongPage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "TopSong":
                        ((HiddenField)this.Parent.FindControl("CurrentTopSongPage")).Value = e.NewPageIndex.ToString();
                        break;
                    case "SongNumber":
                        ((HiddenField)this.Parent.FindControl("CurrentSongNumberPage")).Value = e.NewPageIndex.ToString();
                        break;
                }
            }
            else
            {
                ScrolltoTop.Value = "True";
            }
            SongListGridView.DataBind();
        }

        protected void SongList_SelectPage_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSelectPage = (DropDownList)SongListGridView.BottomPagerRow.FindControl("SongList_SelectPage_DropDownList");

            int pIndex = 0;
            if (int.TryParse(ddlSelectPage.SelectedValue, out pIndex))
            {
                SongListGridView.PageIndex = pIndex;
                ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = pIndex.ToString();

                // Desktop / Tablet Mode
                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                {
                    string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;

                    switch (SongQueryType)
                    {
                        case "SongLang":
                            ((HiddenField)this.Parent.FindControl("CurrentSongLangPage")).Value = pIndex.ToString();
                            break;
                        case "SongName":
                        case "SingerName":
                            ((HiddenField)this.Parent.FindControl("CurrentQuerySongPage")).Value = pIndex.ToString();
                            break;
                        case "SongStroke":
                            ((HiddenField)this.Parent.FindControl("CurrentSongStrokePage")).Value = pIndex.ToString();
                            break;
                        case "ChorusSong":
                            ((HiddenField)this.Parent.FindControl("CurrentChorusSongPage")).Value = pIndex.ToString();
                            break;
                        case "NewSong":
                            ((HiddenField)this.Parent.FindControl("CurrentNewSongPage")).Value = pIndex.ToString();
                            break;
                        case "TopSong":
                            ((HiddenField)this.Parent.FindControl("CurrentTopSongPage")).Value = pIndex.ToString();
                            break;
                        case "SongNumber":
                            ((HiddenField)this.Parent.FindControl("CurrentSongNumberPage")).Value = pIndex.ToString();
                            break;
                    }
                }
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
                    ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "SingerTypePanel";
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
            CleanUpData();

            hideAllGridViewPanel();
            SongListPanel.Visible = true;
            
            var data = ((Label)((LinkButton)sender).Controls[0]).Text;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "Singer";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = data.ToString();

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "SingerListPanel";
            }
        }

        protected void SingerListView_PreRender(object sender, EventArgs e)
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

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                ScrolltoTop.Value = "True";
            }
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
                if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
                {
                    if (GuiGlobal.SongLangList[i].Length > 2)
                    {
                        SongLangLabel[i].Text = GuiGlobal.SongLangList[i].Substring(0, 1) + GuiGlobal.SongLangList[i].Substring(GuiGlobal.SongLangList[i].Length - 1, 1);
                        SongLangDesktopLabel[i].Text = GuiGlobal.SongLangList[i].Substring(0, 1) + GuiGlobal.SongLangList[i].Substring(GuiGlobal.SongLangList[i].Length - 1, 1);
                    }
                    else
                    {
                        SongLangLabel[i].Text = GuiGlobal.SongLangList[i];
                        SongLangDesktopLabel[i].Text = GuiGlobal.SongLangList[i];
                    }
                }
                else
                {
                    SongLangLabel[i].Text = GuiGlobal.SongLangList[i];
                    SongLangDesktopLabel[i].Text = GuiGlobal.SongLangList[i];
                }
            }

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
                LinkButton[] SongLangDesktopButton =
                {
                    SongLang1DesktopButton,
                    SongLang2DesktopButton,
                    SongLang3DesktopButton,
                    SongLang4DesktopButton,
                    SongLang5DesktopButton,
                    SongLang6DesktopButton,
                    SongLang7DesktopButton,
                    SongLang8DesktopButton,
                    SongLang9DesktopButton,
                    SongLang10DesktopButton
                };

                string langstr = "";
                foreach (LinkButton lb in SongLangDesktopButton)
                {
                    if (GuiGlobal.SongLangList.IndexOf(((Label)lb.Controls[1]).Text) < 0)
                    {
                        langstr = GuiGlobal.SongLangList.Find(lang => lang.Substring(0, 1) + lang.Substring(lang.Length - 1, 1) == ((Label)lb.Controls[1]).Text);
                    }
                    else
                    {
                        langstr = ((Label)lb.Controls[1]).Text;
                    }

                    lb.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                    switch (SongQueryType)
                    {
                        case "SongLang":
                            if (GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentSongLang")).Value)] == langstr) lb.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                            break;
                        case "SongStroke":
                            if (GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentSongStrokeLang")).Value)] == langstr) lb.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                            break;
                        case "ChorusSong":
                            if (GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentChorusSongLang")).Value)] == langstr) lb.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                            break;
                        case "NewSong":
                            if (GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentNewSongLang")).Value)] == langstr) lb.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                            break;
                        case "TopSong":
                            if (GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentTopSongLang")).Value)] == langstr) lb.CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
                            break;
                    }
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
            CleanUpData();

            hideAllGridViewPanel();

            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            var data = ((Label)((LinkButton)sender).Controls[1]).Text;

            if (GuiGlobal.SongLangList.IndexOf(data.ToString()) < 0)
            {
                string langstr = GuiGlobal.SongLangList.Find(lang => lang.Substring(0, 1) + lang.Substring(lang.Length - 1, 1) == data.ToString());
                data = langstr;
            }

            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = data.ToString();

            switch (SongQueryType)
            {
                case "SongLang":
                    ((HiddenField)this.Parent.FindControl("CurrentSongLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterValue")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterPage")).Value = "0";
                    break;
                case "SongStroke":
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokePage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterValue")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterPage")).Value = "0";
                    break;
                case "ChorusSong":
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterValue")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterPage")).Value = "0";
                    break;
                case "NewSong":
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterValue")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterPage")).Value = "0";
                    break;
                case "TopSong":
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongLang")).Value = GuiGlobal.SongLangList.IndexOf(data.ToString()).ToString();
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterList")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterValue")).Value = "";
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterPage")).Value = "0";
                    break;
            }

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                SongListPanel.Visible = true;
            }
            else
            {
                ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "SongLangPanel";

                SongList(0, GuiGlobal.QuerySongRows, SongQueryType, data.ToString());
                if (SongListGridView.Rows.Count > 0)
                {
                    MobileFilterPanel.Visible = true;
                }
                else
                {
                    SongListPanel.Visible = true;
                }
            }
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
                            case "ChorusSong":
                            case "NewSong":
                            case "TopSong":
                            case "SongNumber":
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
                            case "SongStroke":
                                if (liststr == "全部" || liststr == "")
                                {
                                    row["FilterText"] = liststr;
                                    row["FilterSort"] = -1;
                                }
                                else
                                {
                                    row["FilterText"] = liststr + "劃";
                                    row["FilterSort"] = Convert.ToInt32(liststr);
                                }
                                break;
                            case "FavoriteSong":
                                switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                                {
                                    case "錢櫃英語排行榜":
                                    case "錢櫃粵語排行榜":
                                    case "錢櫃日語排行榜":
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
                                    default:
                                        row["FilterText"] = liststr;
                                        row["FilterSort"] = GuiGlobal.SongLangList.IndexOf(liststr) + 1;
                                        break;
                                }
                                break;

                        }
                        
                        
                        dt.Rows.Add(row);
                    }

                    int CurPageSize = 0;
                    if (SongNumberPanel.Visible)
                    {
                        CurPageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 7;
                    }
                    else
                    {
                        CurPageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("PlayListGridViewPageSize")).Value) - 2;
                    }
                    if (CurPageSize < 1) CurPageSize = 1;
                    
                    SongListFilterGridView.PageSize = CurPageSize;
                    SongListFilterGridView.PageIndex = Convert.ToInt32(((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterPage")).Value);

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
                            case "ChorusSong":
                            case "NewSong":
                            case "TopSong":
                            case "SongNumber":
                                tcHeader[0].Text = "字數";
                                break;
                            case "SongStroke":
                                tcHeader[0].Text = "筆劃";
                                break;
                            case "FavoriteSong":
                                switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                                {
                                    case "錢櫃英語排行榜":
                                    case "錢櫃粵語排行榜":
                                    case "錢櫃日語排行榜":
                                        tcHeader[0].Text = "字數";
                                        break;
                                    default:
                                        tcHeader[0].Text = "語系";
                                        break;
                                }
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
                                case "ChorusSong":
                                case "NewSong":
                                case "TopSong":
                                case "SongNumber":
                                    if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue + "字")
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                    }
                                    else
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                    }
                                    break;
                                case "SongStroke":
                                    if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue + "劃")
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                    }
                                    else
                                    {
                                        ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                    }
                                    break;
                                case "FavoriteSong":
                                    switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                                    {
                                        case "錢櫃英語排行榜":
                                        case "錢櫃粵語排行榜":
                                        case "錢櫃日語排行榜":
                                            if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue + "字")
                                            {
                                                ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                            }
                                            else
                                            {
                                                ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                            }
                                            break;
                                        default:
                                            if (((LinkButton)lb.Controls[0].Controls[1]).Text == SongQueryFilterValue)
                                            {
                                                ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.ActiveButtonCssClass;
                                            }
                                            else
                                            {
                                                ((LinkButton)lb.Controls[0].Controls[1]).CssClass = "GridViewFilterButton " + GuiGlobal.DefaultButtonCssClass;
                                            }
                                            break;
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
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;

            SongListFilterGridView.PageIndex = e.NewPageIndex;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterPage")).Value = e.NewPageIndex.ToString();

            switch (SongQueryType)
            {
                case "SongLang":
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "SongName":
                case "SingerName":
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "SongStroke":
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "ChorusSong":
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "NewSong":
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "TopSong":
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
                case "SongNumber":
                    ((HiddenField)this.Parent.FindControl("CurrentSongNumberFilterPage")).Value = e.NewPageIndex.ToString();
                    break;
            }

            SongListFilterGridView.DataBind();
        }

        protected void SongList_Filter_Button_Click(object sender, EventArgs e)
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;

            switch (SongQueryType)
            {
                case "SongName":
                case "SingerName":
                    SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = SongQueryValue;
                    break;
                case "SongNumber":
                    SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongNumber")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = SongQueryValue;
                    break;
            }

            switch (SongQueryType)
            {
                case "Singer":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text;
                    break;
                case "SongLang":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentSongLangFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
                case "SongName":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
                case "SingerName":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text;
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterValue")).Value = ((LinkButton)sender).Text;
                    break;
                case "SongStroke":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokePage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('劃');
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentSongStrokeFilterValue")).Value = ((LinkButton)sender).Text.Trim('劃');
                    break;
                case "ChorusSong":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentChorusSongFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
                case "NewSong":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
                case "TopSong":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentTopSongFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;
                case "FavoriteSong":
                    switch (((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value)
                    {
                        case "錢櫃英語排行榜":
                        case "錢櫃粵語排行榜":
                        case "錢櫃日語排行榜":
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                            break;
                        default:
                            ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text;
                            break;
                    }
                    break;
                case "SongNumber":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentNewSongPage")).Value = "0";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    ((HiddenField)this.Parent.FindControl("CurrentSongNumberFilterList")).Value = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                    ((HiddenField)this.Parent.FindControl("CurrentSongNumberFilterValue")).Value = ((LinkButton)sender).Text.Trim('字');
                    break;

            }
            SongListGridView.PageIndex = 0;
        }

        private void QuerySongGetData()
        {
            //clean up data on display
            CleanUpData();

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value = QuerySong_QueryName_Desktop_TextBox.Text;
                if (QuerySong_SongName_Desktop_RadioButton.Checked)
                {
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongName";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = QuerySong_QueryName_Desktop_TextBox.Text;
                }
                else
                {
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SingerName";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = QuerySong_QueryName_Desktop_TextBox.Text;
                }
            }
            else
            {
                ((HiddenField)this.Parent.FindControl("CurrentQuerySong")).Value = QuerySong_QueryName_TextBox.Text;
                if (QuerySong_SongName_RadioButton.Checked)
                {
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongName";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = QuerySong_QueryName_TextBox.Text;
                }
                else
                {
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SingerName";
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = QuerySong_QueryName_TextBox.Text;
                }
            }
            SongListPanel.Visible = true;
        }

        protected void QuerySong_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (QuerySong_QueryName_Desktop_TextBox.Text != "") QuerySongGetData();
                ((HiddenField)this.Parent.FindControl("CurrentQuerySongPage")).Value = "0";
                ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterList")).Value = "";
                ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterValue")).Value = "";
                ((HiddenField)this.Parent.FindControl("CurrentQuerySongFilterPage")).Value = "0";
            }
            else
            {
                if (QuerySong_QueryName_TextBox.Text != "") QuerySongGetData();
            }
        }

        protected void QuerySong_QueryName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "") QuerySongGetData();
        }

        protected void MobileFilter_ListView_PreRender(object sender, EventArgs e)
        {
            // Mobile Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                DataTable dt = new DataTable();
                DataColumn col = new DataColumn("FilterText", typeof(string));
                dt.Columns.Add(col);
                col = new DataColumn("FilterImgUrl", typeof(string));
                dt.Columns.Add(col);
                col = new DataColumn("FilterSort", typeof(Int32));
                dt.Columns.Add(col);

                string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
                string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
                string SongQueryFilterValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value;
                string SongQueryFilterList = ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterList")).Value;
                string FilterImgUrl = "";

                List<string> list = new List<string>(SongQueryFilterList.Split(','));
                foreach (string liststr in list)
                {
                    DataRow row = dt.NewRow();
                    switch (SongQueryType)
                    {
                        case "SongLang":
                        case "ChorusSong":
                        case "NewSong":
                        case "TopSong":
                            FilterImgUrl = "/images/langstr_" + SongQueryValue.Substring(0, 1) + ".png";
                            if (liststr == "全部" || liststr == "")
                            {
                                row["FilterText"] = liststr;
                                row["FilterImgUrl"] = FilterImgUrl;
                                row["FilterSort"] = -1;
                            }
                            else
                            {
                                row["FilterText"] = liststr + "字部";
                                row["FilterImgUrl"] = FilterImgUrl;
                                row["FilterSort"] = Convert.ToInt32(liststr);
                            }
                            break;
                        case "SongStroke":
                            FilterImgUrl = "/images/langstr_" + SongQueryValue.Substring(0, 1) + ".png";
                            if (liststr == "全部" || liststr == "")
                            {
                                row["FilterText"] = liststr;
                                row["FilterImgUrl"] = FilterImgUrl;
                                row["FilterSort"] = -1;
                            }
                            else
                            {
                                row["FilterText"] = liststr + "劃";
                                row["FilterImgUrl"] = FilterImgUrl;
                                row["FilterSort"] = Convert.ToInt32(liststr);
                            }
                            break;
                    }
                    dt.Rows.Add(row);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "FilterSort";
                dt = dv.ToTable();

                MobileFilter_ListView.DataSource = dt;
                MobileFilter_ListView.DataBind();
            }
        }

        protected void MobileFilter_Button_Click(object sender, EventArgs e)
        {
            string SongQueryType = ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value;
            string SongQueryValue = ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value;
            ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "MobileFilterPanel";

            switch (SongQueryType)
            {
                case "SongLang":
                case "ChorusSong":
                case "NewSong":
                case "TopSong":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((Label)((LinkButton)sender).Controls[1]).Text.Replace("字部", "");
                    break;
                case "SongStroke":
                    ((HiddenField)this.Parent.FindControl("CurrentSongQueryFilterValue")).Value = ((Label)((LinkButton)sender).Controls[1]).Text.Replace("劃", "");
                    break;
            }
            SongListGridView.PageIndex = 0;

            hideAllGridViewPanel();
            SongListPanel.Visible = true;
        }

        protected void FavoriteSong_Button_Click(object sender, EventArgs e)
        {
            hideAllGridViewPanel();
            FavoriteListPanel.Visible = true;

            int PageSize = 0;

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
                FavoriteSong_Desktop_User_Button.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                FavoriteSong_Desktop_History_Button.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                FavoriteSong_Desktop_Cashbox_Button.CssClass = "MainMenuButton " + GuiGlobal.DefaultButtonCssClass;
                ((LinkButton)sender).CssClass = "MainMenuButton " + GuiGlobal.ActiveButtonCssClass;
            }
            else
            {
                ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "FavoriteSongPanel";
                PageSize = GuiGlobal.SingerTypePageSize;
            }

            FavoriteListDataPager.SetPageProperties(0, PageSize, true);

            switch (((LinkButton)sender).ID)
            {
                case "FavoriteSong_User_Button":
                case "FavoriteSong_Desktop_User_Button":
                    ((HiddenField)this.Parent.FindControl("CurrentFavoriteSongType")).Value = "User";
                    break;
                case "FavoriteSong_History_Button":
                case "FavoriteSong_Desktop_History_Button":
                    ((HiddenField)this.Parent.FindControl("CurrentFavoriteSongType")).Value = "History";
                    break;
                case "FavoriteSong_Cashbox_Button":
                case "FavoriteSong_Desktop_Cashbox_Button":
                    ((HiddenField)this.Parent.FindControl("CurrentFavoriteSongType")).Value = "Cashbox";
                    break;
            }
        }

        protected void FavoriteListView_PreRender(object sender, EventArgs e)
        {
            int PageSize = 0;

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                PageSize = GuiGlobal.SingerTypePageSize;
            }
            else
            {
                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
            }

            int StartRowIndex = FavoriteListDataPager.StartRowIndex;
            FavoriteListDataPager.SetPageProperties(StartRowIndex, PageSize, true);

            FavoriteSongGetData();

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (FavoriteListDataPager.TotalRowCount > PageSize)
                {
                    int PageCount = Convert.ToInt32(Math.Ceiling((double)FavoriteListDataPager.TotalRowCount / PageSize));
                    DropDownList ddlSelectPage = (DropDownList)FavoriteListDataPager.Controls[0].FindControl("FavoriteList_SelectPage_DropDownList");
                    for (int i = 0; i < PageCount; i++)
                    {
                        ddlSelectPage.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
                    }
                    ddlSelectPage.SelectedIndex = FavoriteListDataPager.StartRowIndex / PageSize;
                }
            }
        }

        private void FavoriteSongGetData()
        {
            FavoriteListView.DataSource = null;
            FavoriteListView.DataBind();

            List<string> Filterlist = new List<string>();
            List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };
            string FavoriteSongType = ((HiddenField)this.Parent.FindControl("CurrentFavoriteSongType")).Value;

            string jsonText = CrazyKTVWCF.FavoriteUser(0, GuiGlobal.QuerySongRows);
            DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);
            DataColumn col = new DataColumn("ImgFileUrl", typeof(string));
            dt.Columns.Add(col);

            DataTable listdt = new DataTable();
            listdt = dt.Clone();

            if (dt.Rows.Count > 0)
            {
                switch (FavoriteSongType)
                {
                    case "User":
                        Filterlist = new List<string>() { "上次播放", "今日播放", "錢櫃" };
                        foreach (DataRow row in dt.AsEnumerable())
                        {
                            if (!row["User_Name"].ToString().ContainsAny(Filterlist.ToArray()))
                            {
                                foreach (string ImgFormat in ImgFormatList)
                                {
                                    if (File.Exists(HttpContext.Current.Server.MapPath("/userimg/" + row["User_Name"].ToString() + ImgFormat)))
                                    {
                                        row["ImgFileUrl"] = "/userimg/" + row["User_Name"].ToString() + ImgFormat;
                                        break;
                                    }
                                }
                                if (row["ImgFileUrl"].ToString() == "")
                                {
                                    row["ImgFileUrl"] = "/images/singertype_default.png";
                                }
                                listdt.ImportRow(row);
                            }
                        }
                        break;
                    case "History":
                        Filterlist = new List<string>() { "上次播放", "今日播放" };
                        foreach (DataRow row in dt.AsEnumerable())
                        {
                            if (row["User_Name"].ToString().ContainsAny(Filterlist.ToArray()))
                            {
                                switch (row["User_Name"].ToString())
                                {
                                    case "上次播放":
                                        row["ImgFileUrl"] = "/images/favoritesong_lastplayed.png";
                                        break;
                                    case "今日播放":
                                        row["ImgFileUrl"] = "/images/favoritesong_todaylist.png";
                                        break;
                                }
                                listdt.ImportRow(row);
                            }
                        }
                        break;
                    case "Cashbox":
                        Filterlist = new List<string>() { "錢櫃" };
                        foreach (DataRow row in dt.AsEnumerable())
                        {
                            if (row["User_Name"].ToString().ContainsAny(Filterlist.ToArray()))
                            {
                                switch (row["User_Name"].ToString())
                                {
                                    case "錢櫃新歌排行榜":
                                    case "錢櫃點播總排行":
                                    case "錢櫃英語排行榜":
                                    case "錢櫃粵語排行榜":
                                    case "錢櫃日語排行榜":
                                        row["ImgFileUrl"] = "/images/favoritesong_topsong.png";
                                        break;
                                    default:
                                        row["ImgFileUrl"] = "/images/favoritesong_newsong.png";
                                        break;
                                }
                                listdt.ImportRow(row);
                            }
                        }
                        break;
                }
            }

            FavoriteListView.DataSource = listdt;
            FavoriteListView.DataBind();
        }

        protected void FavoriteListDataPager_OnPagerCommand(object sender, DataPagerCommandEventArgs e)
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
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                ScrolltoTop.Value = "True";
            }
        }

        protected void FavoriteList_SelectPage_DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                DropDownList ddlSelectPage = (DropDownList)FavoriteListDataPager.Controls[0].FindControl("FavoriteList_SelectPage_DropDownList");

                int PageSize = 0;

                PageSize = Convert.ToInt32(((HiddenField)this.Parent.FindControl("SingerListViewPageSize")).Value);
                int StartRowIndex = Convert.ToInt32(ddlSelectPage.SelectedValue) * PageSize;
                FavoriteListDataPager.SetPageProperties(StartRowIndex, PageSize, true);
            }
        }

        protected void FavoriteListButton_Click(object sender, EventArgs e)
        {
            //clean up data on display
            CleanUpData();

            hideAllGridViewPanel();
            SongListPanel.Visible = true;

            var data = ((LinkButton)sender).CommandArgument;
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "FavoriteSong";
            ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = data.ToString();

            string FavoriteSongType = ((HiddenField)this.Parent.FindControl("CurrentFavoriteSongType")).Value;
            if (FavoriteSongType == "Cashbox")
            {
                ((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value = "錢櫃" + ((Label)((LinkButton)sender).Controls[0]).Text;
            }
            else
            {
                ((HiddenField)this.Parent.FindControl("CurrentFavoriteUserName")).Value = ((Label)((LinkButton)sender).Controls[0]).Text;
            }

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Mobile"))
            {
                ((HiddenField)this.Parent.FindControl("MobilePreviousPage")).Value = "FavoriteListPanel";
            }
        }

        protected void SongNumber_OrderSong_Button_Click(object sender, EventArgs e)
        {
            string SongId = SongNumber_QueryNumber_TextBox.Text;
            SongNumber_QueryNumber_TextBox.Text = "";
            CrazyKTVWCF.wcf_addsong(SongId);
        }

        protected void SongNumber_InsertSong_Button_Click(object sender, EventArgs e)
        {
            string SongId = SongNumber_QueryNumber_TextBox.Text;
            SongNumber_QueryNumber_TextBox.Text = "";
            CrazyKTVWCF.wcf_addsong(SongId);
            CrazyKTVWCF.wcf_insertsong(SongId);
        }

        private void SongNumberGetData()
        {
            //clean up data on display
            CleanUpData();

            ((HiddenField)this.Parent.FindControl("CurrentSongQueryType")).Value = "SongNumber";
            if (SongNumber_QueryNumber_TextBox.Text != "" && SongNumber_QueryNumber_TextBox.Text.Length > 3)
            {
                ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = SongNumber_QueryNumber_TextBox.Text;
                ((HiddenField)this.Parent.FindControl("CurrentSongNumber")).Value = SongNumber_QueryNumber_TextBox.Text;
            }
            else
            {
                ((HiddenField)this.Parent.FindControl("CurrentSongQueryValue")).Value = "請輸入歌曲編號";
                ((HiddenField)this.Parent.FindControl("CurrentSongNumber")).Value = "請輸入歌曲編號";
            }

            SongListPanel.Visible = true;
        }

        protected void SongNumber_QueryNumber_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "") SongNumberGetData();
        }

        protected void SongNumber_Number_Button_Click(object sender, EventArgs e)
        {
            string TextBoxValue = SongNumber_QueryNumber_TextBox.Text;

            switch (((LinkButton)sender).ID)
            {
                case "SongNumber_Clear_Button":
                    SongNumber_QueryNumber_TextBox.Text = "";
                    break;
                case "SongNumber_BackSpace_Button":
                    if (TextBoxValue.Length > 0) SongNumber_QueryNumber_TextBox.Text = TextBoxValue.Substring(0, TextBoxValue.Length - 1);
                    break;
            }

            if (TextBoxValue.Length < 6)
            {
                switch (((LinkButton)sender).ID)
                {
                    case "SongNumber_Number1_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "1";
                        break;
                    case "SongNumber_Number2_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "2";
                        break;
                    case "SongNumber_Number3_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "3";
                        break;
                    case "SongNumber_Number4_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "4";
                        break;
                    case "SongNumber_Number5_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "5";
                        break;
                    case "SongNumber_Number6_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "6";
                        break;
                    case "SongNumber_Number7_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "7";
                        break;
                    case "SongNumber_Number8_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "8";
                        break;
                    case "SongNumber_Number9_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "9";
                        break;
                    case "SongNumber_Number0_Button":
                        SongNumber_QueryNumber_TextBox.Text = TextBoxValue + "0";
                        break;

                }
            }
            SongNumberGetData();
        }




    }
}