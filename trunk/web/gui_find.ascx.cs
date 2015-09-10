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
        //DataSet1 dset = new DataSet1();

        //string findListOrder =  GlobalFunctions.FindListOrder;

        protected void LPageNumCount_PreRender(object sender, EventArgs e)
        {
            

            //try
            //{
            //    if (GridView1.Rows.Count > 0)
            //    {
            //        LPageNumDisplay.Visible = true;
            //        LPageNumCount.Visible = true;
            //    }
            //    else
            //    {
            //        LPageNumDisplay.Visible = false;
            //        LPageNumCount.Visible = false;
            //    }

            //    LPageNumCount.Text = (int.Parse(songDGpage.Value) + 1).ToString();
            //}
            //catch
            //{
            //    LPageNumDisplay.Visible = false;
            //    LPageNumCount.Visible = false;
            //}
        }


        protected void Page_Load(object sender, EventArgs e)
        {


            //hideAllGridViewPanel();

            // if (GlobalFunctions.FindListOrder == "2") //order
            // {
            //SharpPieces.Web.Controls.ExtendedListItem eli1 = new SharpPieces.Web.Controls.ExtendedListItem("Song Name", "Song", SharpPieces.Web.Controls.ListItemGroupingType.None);
            //SharpPieces.Web.Controls.ExtendedListItem eli2 = new SharpPieces.Web.Controls.ExtendedListItem("Singer", "Singer", SharpPieces.Web.Controls.ListItemGroupingType.None);
            //SharpPieces.Web.Controls.ExtendedListItem eli3 = new SharpPieces.Web.Controls.ExtendedListItem("Word Count", "WordCount", SharpPieces.Web.Controls.ListItemGroupingType.None);

            //eli1.Attributes.Add("meta:resourcekey", "ListItemResource1");
            //eli1.Attributes.Add("meta:resourcekey", "ListItemResource2");
            //eli1.Attributes.Add("meta:resourcekey", "ListItemResource3");

            //ddSearchType.ExtendedItems.Add(eli1);
            //ddSearchType.ExtendedItems.Add(eli2);
            //ddSearchType.ExtendedItems.Add(eli3);


            // }

            //    SharpPieces.Web.Controls.ExtendedListItem eli = new SharpPieces.Web.Controls.ExtendedListItem();


            //    ddSearchType.ExtendedItems.Insert ([0].Enabled = false;
            //    ddSearchType.ExtendedItems[1].Enabled = false;
            //    ddSearchType.ExtendedItems[2].Enabled = false;            
            //}
            //else {
            //    ddSearchType.ExtendedItems[5].Enabled = false;
            //    ddSearchType.ExtendedItems[6].Enabled = false;
            //    ddSearchType.ExtendedItems[7].Enabled = false;   

            //}

            //////for broswer back button
            //if (ScriptManagerProxy1.isinas.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            //{
            //    ScriptManager1.AddHistoryPoint("historyPoint", ddActions.SelectedIndex.ToString(), ddActions.SelectedValue);
            //}

            //try
            //{

            //    //DataView dv = new DataView(dt);
            //    ////dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            //    //GridView1.Rows.C = dv;


            //    if (int.Parse(songDGpage.Value) >= 0)
            //    {
            //        LPageNumDisplay.Visible = true;
            //        LPageNumCount.Visible = true;
            //        BJump.Visible = true;
            //    }
            //    else
            //    {
            //        LPageNumDisplay.Visible = false;
            //        LPageNumCount.Visible = false;
            //        BJump.Visible = false;
            //    }
            //    //LPageNumCount.Text = (int.Parse(songDGpage.Value) + 1).ToString();
            //    //int.Parse(LPageNumCount.Text.ToString().Trim())
            //    songDGpage.Value = (int.Parse(LPageNumCount.Text) - 1).ToString();
            //}
            //catch {
            //    LPageNumDisplay.Visible = false;
            //    LPageNumCount.Visible = false;
            //    songDGpage.Value = "0";
            //    BJump.Visible = false;
            //}
        }


        protected void bSearch_Click(object sender, EventArgs e)
        {
            //findCaller.Value = "toTop";
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();

            int rowsPerPage = 100; // will be super slow if more than 2000
            //int currentPageNumber = 0; //if rowPerPage is more than 1300, then this must be NULL or nothing will be returned, if condition try to search more than one word, eg 天天, then this value must be NULL

            songList(0, rowsPerPage);

            songDGpage.Value = "0";
            LPageNumCount.Text = "1";
        }

        private void songList(int page, int rows)
        {
            findCaller.Value = "toTop";
            //pre-set
            hideAllGridViewPanel();
            Panel2.Visible = true;


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
                    Panel4.Visible = true;

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
                    Panel4.Visible = true;

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
                    Panel4.Visible = true;

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



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            findCaller.Value = "";
            var data = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get hidden Song_ID
            var dataStr = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1]; //get hidden Song_Singer

            if (e.CommandName.ToLower().Trim() == "Add".ToLower().Trim())
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.

                //GridViewRow selectedRow = GridView1.Rows[index];
                //TableCell Song_Id = selectedRow.Cells[1];
                //CrazyKTVWCF.wcf_addsong(Song_Id.Text.Trim());

                CrazyKTVWCF.wcf_addsong(data.ToString().Trim());
                Panel2.Visible = true;
            } else if (e.CommandName.ToLower().Trim() == "Insert".ToLower().Trim())
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                //GridViewRow selectedRow = GridView1.Rows[index];
                //TableCell Song_Id = selectedRow.Cells[1];
                //CrazyKTVWCF.wcf_insertsong(Song_Id.Text.Trim());

                CrazyKTVWCF.wcf_insertsong(data.ToString().Trim());
                Panel2.Visible = true;
            }
            else if (e.CommandName.ToLower().Trim() == "Singer".ToLower().Trim())
            {
                //clean up data on display
                GridView1.DataSource = null;
                GridView1.DataBind();
                hideAllGridViewPanel();
                Panel2.Visible = true;
                BNext.Visible = false;
                BPrevious.Visible = false;
                songDGpage.Value = "0";
                LPageNumCount.Text = "1";

                findCaller.Value = "toTop";
                string _singer = dataStr.ToString().Trim(); // singer
                // gvMode.Value = data.ToString();
                tSearch.Text = _singer;
                SingerSongList(0, 100, _singer);
                ddSearchType.SelectedIndex = 1;
            }




        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;            
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            //if (GridViewSortDirection == null)
            //{
            //    e.SortDirection = SortDirection.Descending;
            //}
            //else if (GridViewSortDirection == SortDirection.Ascending)
            //{
            //    e.SortDirection = SortDirection.Descending;
            //}
            //else if (GridViewSortDirection == SortDirection.Descending)
            //{
            //    e.SortDirection = SortDirection.Ascending;
            //}

            //GridViewSortDirection = e.SortDirection;
        }

        protected void BNext_Click(object sender, EventArgs e)
        {
            findCaller.Value = "toTop";
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();

            if (gvMode.Value.ToString().Trim().Length>0)
            {
                FSongList(1 + int.Parse(songDGpage.Value.ToString()), 100, gvMode.Value.ToString());
            }
            else
            {
                songList(1 + int.Parse(songDGpage.Value.ToString()), 100);
            }


            songDGpage.Value=(1 + int.Parse(songDGpage.Value.ToString())).ToString();
            LPageNumCount.Text = (int.Parse(LPageNumCount.Text) + 1).ToString();

            //LPageNumCount.Text = songDGpage.Value.ToString();
        }

        protected void BPrevious_Click(object sender, EventArgs e)
        {
            findCaller.Value = "toTop";
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();

            if (gvMode.Value.ToString().Trim().Length > 0)
            {
                FSongList(int.Parse(songDGpage.Value.ToString()) - 1, 100, gvMode.Value.ToString());
            }
            else
            {
                songList(int.Parse(songDGpage.Value.ToString()) - 1, 100);
            }
            

            songDGpage.Value=(int.Parse(songDGpage.Value.ToString()) -1).ToString();
            LPageNumCount.Text = (int.Parse(LPageNumCount.Text) - 1).ToString();
            //LPageNumCount.Text = songDGpage.Value.ToString();
        }

        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //clean up data on display
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    tSearch.Text = "";
        //    hideAllGridViewPanel();
        //    Panel2.Visible = true;
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
        //    Panel2.Visible = true;
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

            GridView1.DataSource = dv3;
            GridView1.DataBind();

            if (dv3.Count == rows)
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


       //protected void LPageNumCount_PreRender(object sender, EventArgs e)
        //{
        //    //LPageNumCount.Text = (int.Parse(songDGpage.Value)+1).ToString();
        //}

        protected void hideAllGridViewPanel()
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;
            MainMenuPanel.Visible = false;
            SingerTypePanel.Visible = false;
        }

        //protected void SingerListView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    //clean up data on display
        //    GridView1.DataSource = null;
        //    GridView1.DataBind();
        //    tSearch.Text = "";
        //    hideAllGridViewPanel();
        //    Panel2.Visible = true;
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

        protected void Bsinger_Click(object sender, EventArgs e) {
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();
            tSearch.Text = "";
            hideAllGridViewPanel();
            Panel2.Visible = true;
            BNext.Visible = false;
            BPrevious.Visible = false;
            songDGpage.Value = "0";
            LPageNumCount.Text = "1";

           // var data = SingerListView.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get DataKeyNames="Singer_Name"
            var data = ((Button)sender).Text.ToString();
             gvMode.Value = data.ToString();
            tSearch.Text = data.ToString();
            SingerSongList(0, 100, data.ToString());
            ddSearchType.SelectedIndex = 1;
        }

        private void SingerSongList(int page, int rows, string Singer_Name)
        {
            string   jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '%" + Singer_Name.Trim() + "%'", page, rows, "Song_Singer, Song_SongName"); //more than 2000 per rows will be super slow
                
            DataTable dt3 = GlobalFunctions.JsontoDataTable(jsonText);
            DataView dv3 = new DataView(dt3);
            //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            GridView1.DataSource = dv3;
            GridView1.DataBind();
            
            if (dv3.Count == rows)
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

            findCaller.Value = "toTop";
        }

        protected void BJump_Click(object sender, EventArgs e)
        {


            try
            {
                int _page = int.Parse(LPageNumCount.Text.ToString().Trim());
                findCaller.Value = "toTop";
                //clean up data on display
                GridView1.DataSource = null;
                GridView1.DataBind();

                if (_page <= 0)
                    _page = 1;

                if (gvMode.Value.ToString().Trim().Length > 0)
                {
                    FSongList(_page - 1, 100, gvMode.Value.ToString());
                }
                else
                {
                    songList(_page - 1, 100);
                }


                songDGpage.Value = (_page - 1).ToString();

            }
            catch (Exception) { }


            //LPageNumCount.Text = songDGpage.Value.ToString();
        }

        protected void bSearch_PreRender(object sender, EventArgs e)
        {
            try
            {

                //DataView dv = new DataView(dt);
                ////dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                //GridView1.Rows.C = dv;

                if (GridView1.Rows.Count > 0 || int.Parse(songDGpage.Value) > 0)
                {
                    LPageNumDisplay.Visible = true;
                    LPageNumCount.Visible = true;
                    BJump.Visible = true;
                }
                else
                {
                    LPageNumDisplay.Visible = false;
                    LPageNumCount.Visible = false;
                    BJump.Visible = false;
                }
                //LPageNumCount.Text = (int.Parse(songDGpage.Value) + 1).ToString();
                //int.Parse(LPageNumCount.Text.ToString().Trim())
                songDGpage.Value = (int.Parse(LPageNumCount.Text) - 1).ToString();
            }
            catch
            {
                LPageNumDisplay.Visible = false;
                LPageNumCount.Visible = false;
                songDGpage.Value = "0";
                LPageNumCount.Text = "1";
                BJump.Visible = false;
            }
        }

        protected void GridView2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();
            tSearch.Text = "";
            hideAllGridViewPanel();
            Panel2.Visible = true;
            BNext.Visible = false;
            BPrevious.Visible = false;
            songDGpage.Value = "0";
            LPageNumCount.Text = "1";


            //LocationID = Me.MyListView.DataKeys(currentItem.DataItemIndex)("LocationID")

            var data = this.GridView2.DataKeys[e.Item.DataItemIndex]["User_Id"]; //get DataKeyNames="User_ID"
            gvMode.Value = data.ToString();
            FSongList(0, 100, data.ToString());
        }

        protected void MainMenu_FindSingerButton_Click(object sender, ImageClickEventArgs e)
        {
            hideAllGridViewPanel();
            SingerTypePanel.Visible = true;
        }

        protected void MainMenu_FindLangButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void MainMenu_QuerySongButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void MainMenu_ChorusSongButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void MainMenu_ChartSongButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void MainMenu_NewSongButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void MainMenu_FavoriteSongButton_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void SingerTypeButton_Click(object sender, ImageClickEventArgs e)
        {
            if (CrazyKTVWCF.checkWCF() == true)
            {
                hideAllGridViewPanel();
                Panel4.Visible = true;
                int PageSize = GuiGlobal.SingerTypePageSize;
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

                switch (((ImageButton)sender).ID)
                {
                    case "SingerTypeMaleButton":
                        SingerType = "0";
                        SingerTypeIndex = 0;
                        break;
                    case "SingerTypeFemaleButton":
                        SingerType = "1";
                        SingerTypeIndex = 1;
                        break;
                    case "SingerTypeGroupButton":
                        SingerType = "2";
                        SingerTypeIndex = 2;
                        break;
                    case "SingerTypeForeignMaleShowButton":
                    case "SingerTypeForeignMaleButton":
                        SingerType = "4";
                        SingerTypeIndex = 3;
                        break;
                    case "SingerTypeForeignFemaleButton":
                        SingerType = "5";
                        SingerTypeIndex = 4;
                        break;
                    case "SingerTypeForeignGroupButton":
                        SingerType = "6";
                        SingerTypeIndex = 5;
                        break;
                    case "SingerTypeOtherShowButton":
                    case "SingerTypeOtherButton":
                        SingerType = "7";
                        SingerTypeIndex = 6;
                        break;
                }

                List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };
                jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=" + SingerType, 0, 2000, "Singer_Strokes, Singer_Name");
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

                    GuiGlobal.SingerTypeCurrentDT = dt3;
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
                    GuiGlobal.SingerTypeCurrentDT = dtlist[SingerTypeIndex];
                    dv3 = new DataView(dtlist[SingerTypeIndex]);
                }

                SingerListView.DataSource = dv3;
                SingerListView.DataBind();
            }
        }

        protected void SingerImageButton_Click(object sender, ImageClickEventArgs e)
        {
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();
            tSearch.Text = "";
            hideAllGridViewPanel();
            Panel2.Visible = true;

            BNext.Visible = false;
            BPrevious.Visible = false;
            songDGpage.Value = "0";
            LPageNumCount.Text = "1";

            // var data = SingerListView.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get DataKeyNames="Singer_Name"
            var data = ((ImageButton)sender).AlternateText.ToString();
            gvMode.Value = data.ToString();
            tSearch.Text = data.ToString();
            SingerSongList(0, 100, data.ToString());
            ddSearchType.SelectedIndex = 1;
        }

        protected void SingerListView_PagePropertiesChanged(object sender, EventArgs e)
        {
            SingerListView.DataSource = null;
            SingerListView.DataBind();
            hideAllGridViewPanel();
            Panel4.Visible = true;
            
            int PageSize = GuiGlobal.SingerTypePageSize;
            int StartRowIndex = SingerListDataPager.StartRowIndex;
            SingerListDataPager.SetPageProperties(StartRowIndex, PageSize, true);
            
            SingerListView.DataSource = GuiGlobal.SingerTypeCurrentDT;
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