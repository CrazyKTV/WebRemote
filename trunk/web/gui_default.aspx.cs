using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web
{
    public partial class gui_default : System.Web.UI.Page
    {

        protected override void InitializeCulture()
        {
            changeLang();
        }

        protected void changeLang()
        {
            // dropdown change languages
            if (Request.Form["ddlanguage"] != null)
            {
                String selectedLanguage = Request.Form["ddlanguage"];
                UICulture = selectedLanguage;
                Culture = selectedLanguage;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectedLanguage);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(selectedLanguage);
            }
            else //default setting
            {
                String selectedLanguage = "zh-CHT";
                UICulture = selectedLanguage;
                Culture = selectedLanguage;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectedLanguage);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(selectedLanguage);
                // ddlanguage.SelectedIndex = 1; //SelectedValue = "zh-CHT";
            }
            base.InitializeCulture();

            //((ExtendedListItem)find.FindControl("NewSongs")).Value = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ddlanguage"] == null)
            {
                //gui_find.Visible = true;
                //currentList1.Visible = true;
            }



            GlobalFunctions.currentlang = "zh-CHT";

            // if WCF is alive then continue with other process
            if (GuiGlobal.AllSongDTStatus == false || GuiGlobal.SingerTypeDTStatus == false)
            {
                System.Threading.Thread.Sleep(150);  // to display "loading" icon for 0.15 second
            }
        }

        protected void language_SelectedIndexChanged(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);

        }

        /// <summary>
        /// for browswer back button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void scriptManager_Navigate(object sender, HistoryEventArgs e)
        {
            //string state = e.State["historyPoint"];
            //ddActions.SelectedIndex = Convert.ToInt32(state);
        }
        /*
        protected void ddActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////for broswer back button
            if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            {
                ScriptManager1.AddHistoryPoint("historyPoint", ddActions.SelectedIndex.ToString(), ddActions.SelectedValue);
            }


            hideAllCU();

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Find".ToLower())
            {
                gui_find.Visible = true;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Song Number".ToLower())
            {
                gui_songNumber.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Waiting List".ToLower())
            {
                gui_currentList1.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Video".ToLower())
            {
                gui_video.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Volume".ToLower())
            {
                gui_volume.Visible = true;
            }

 

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Tune".ToLower())
            {
                gui_tune.Visible = true;
            }



            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "advanced".ToLower())
            {
                gui_advanced.Visible = true;
            }
   


        }
        */


        private void hideAllCU()
        {
            gui_tune.Visible = false;
            gui_advanced.Visible = false;
            gui_volume.Visible = false;
            gui_video.Visible = false;
            gui_currentList.Visible = false;
            gui_songNumber.Visible = false;
            gui_find.Visible = false;
        }

        protected void CrazyKTV_ControlButton_Click(object sender, EventArgs e)
        {
            switch (((LinkButton)sender).ID)
            {
                case "BChannel":
                case "BChannelDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(null, "Channel");
                    break;
                case "BFind":
                    hideAllCU();
                    hideAllfindPanel();
                    gui_find.Visible = true;
                    ((Panel)gui_find.FindControl("SongListPanel")).Visible = true;
                    break;
                case "BCut":
                case "BCutDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Action(null, "Cut");
                    break;
                case "BdPause":
                case "BdPauseDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Action(null, "PlayPause");
                    break;
                case "BdRestart":
                case "BdRestartDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Action(null, "RsetPlay");
                    break;
                case "BdRepeat":
                case "BdRepeatDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Action(null, "Replay");
                    break;
                case "BdKeyDown":
                case "BdKeyDownDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(-1, "Pitch");
                    break;
                case "BdDefaultPitch":
                case "BdDefaultPitchDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(null, "DefaultPitch");
                    break;
                case "BdKeyUp":
                case "BdKeyUpDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(1, "Pitch");
                    break;
                case "BdVolumeDown":
                case "BdVolumeDownDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(-1, "Volume");
                    break;
                case "BdMute":
                case "BdMuteDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(null, "Mute");
                    break;
                case "BdVolumeUp":
                case "BdVolumeUpDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(1, "Volume");
                    break;
                case "BdFixedCH":
                case "BdFixedCHDesktop":
                    CrazyKTVWCF.DoCrazyKTV_Control(null, "Fixed");
                    break;
                case "BdSongRecoed":
                    CrazyKTVWCF.DoCrazyKTV_Action(null, "SongRecoedList");
                    break;
                case "BdRandom":
                    CrazyKTVWCF.DoCrazyKTV_Control(null, "RandomSong");
                    break;
            }
        }

        protected void MainMenu_PlayListButton_Click(object sender, EventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_currentList.Visible = true;
        }

        protected void MainMenu_FindSongButton_Click(object sender, EventArgs e)
        {
            hideAllCU();
            gui_find.EnableMainMenuPanel();
            if (CrazyKTVWCF.WCFlive) gui_find.Visible = true;
        }

        protected void MainMenu_AdvancedButton_Click(object sender, EventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_advanced.Visible = true;
        }

        protected void hideAllfindPanel()
        {
            ((Panel)gui_find.FindControl("MainMenuPanel")).Visible = false;
            ((Panel)gui_find.FindControl("SingerTypePanel")).Visible = false;
            ((Panel)gui_find.FindControl("SingerListPanel")).Visible = false;
            ((Panel)gui_find.FindControl("SongLangPanel")).Visible = false;
            ((Panel)gui_find.FindControl("QuerySongPanel")).Visible = false;
            ((Panel)gui_find.FindControl("SongListPanel")).Visible = false;
            ((Panel)gui_find.FindControl("Panel3")).Visible = false;
        }

        protected void hideAllfindDesktopPanel()
        {
            ((Panel)gui_findDesktop.FindControl("MainMenuPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SingerTypePanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SingerListPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SongLangPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("QuerySongPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SongListPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("Panel3")).Visible = false;
        }

        protected void MainMenu_Desktop_Button_Click(object sender, EventArgs e)
        {
            MainMenu_FindSingerDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_FindLangDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_QuerySongDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_WordCountDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_ChorusSongDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_NewSongDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_TopSongDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_FavoriteSongDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            MainMenu_SongNumberDesktopButton.CssClass = "ControlButton " + GuiGlobal.DefaultButtonCssClass;
            ((LinkButton)sender).CssClass = "ControlButton " + GuiGlobal.ActiveButtonCssClass;

            hideAllfindDesktopPanel();

            switch (((LinkButton)sender).ID)
            {
                case "MainMenu_FindSingerDesktopButton":
                    ((Panel)gui_findDesktop.FindControl("SingerTypePanel")).Visible = true;
                    ((Panel)gui_findDesktop.FindControl("SingerListPanel")).Visible = true;
                    break;
                case "MainMenu_FindLangDesktopButton":
                    ((Panel)gui_findDesktop.FindControl("SongLangPanel")).Visible = true;
                    ((Panel)gui_findDesktop.FindControl("SongListPanel")).Visible = true;
                    if (((HiddenField)this.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop")) { GetCurrentSongLangSongList(); }
                    break;
                case "MainMenu_QuerySongDesktopButton":
                    ((Panel)gui_findDesktop.FindControl("QuerySongPanel")).Visible = true;
                    ((Panel)gui_findDesktop.FindControl("SongListPanel")).Visible = true;
                    if (((HiddenField)this.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop")) { GetCurrentQuerySongSongList(); }
                    break;
                case "MainMenu_WordCountDesktopButton":
                    break;
                case "MainMenu_ChorusSongDesktopButton":
                    break;
                case "MainMenu_NewSongDesktopButton":
                    break;
                case "MainMenu_TopSongDesktopButton":
                    break;
                case "MainMenu_FavoriteSongDesktopButton":
                    break;
                case "MainMenu_SongNumberDesktopButton":
                    break;
            }

        }

        private void GetCurrentSongList(string QueryType, string QueryValue)
        {
            //clean up data on display
            ((GridView)gui_findDesktop.FindControl("SongListGridView")).DataSource = null;
            ((GridView)gui_findDesktop.FindControl("SongListGridView")).DataBind();
            ((GridView)gui_findDesktop.FindControl("SongListGridView")).PageIndex = 0;
            ((GridView)gui_findDesktop.FindControl("SongListFilterGridView")).DataSource = null;
            ((GridView)gui_findDesktop.FindControl("SongListFilterGridView")).DataBind();
            ((GridView)gui_findDesktop.FindControl("SongListFilterGridView")).PageIndex = 0;
            ((HiddenField)this.FindControl("CurrentSongQueryFilterList")).Value = "";
            ((HiddenField)this.FindControl("CurrentSongQueryFilterValue")).Value = "";

            ((HiddenField)this.FindControl("CurrentSongQueryType")).Value = QueryType;
            ((HiddenField)this.FindControl("CurrentSongQueryValue")).Value = QueryValue;

            string dvSortStr = "";
            DataTable dt = new DataTable();
            dt = GuiGlobal.AllSongDT.Clone();

            switch (QueryType)
            {
                case "SongLang":
                    dvSortStr = "Song_WordCount, Song_SongStroke, Song_SongName, Song_Singer";
                    var SongLangQuery = from row in GuiGlobal.AllSongDT.AsEnumerable()
                                where row.Field<string>("Song_Lang").Equals(QueryValue)
                                select row;

                    if (SongLangQuery.Count<DataRow>() > 0)
                    {
                        foreach (DataRow Row in SongLangQuery)
                        {
                            dt.ImportRow(Row);
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
                        foreach (DataRow Row in SongNameQuery)
                        {
                            dt.ImportRow(Row);
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
                        foreach (DataRow Row in SingerNameQuery)
                        {
                            dt.ImportRow(Row);
                        }
                    }
                    break;
            }

            DataView dv = new DataView(dt);
            dv.Sort = dvSortStr;
            dt = dv.ToTable();

            ((GridView)gui_findDesktop.FindControl("SongListGridView")).DataSource = dt;
            ((GridView)gui_findDesktop.FindControl("SongListGridView")).DataBind();
        }

        private void GetCurrentSongLangSongList()
        {
            string QueryType = "SongLang";
            string QueryValue = GuiGlobal.SongLangList[Convert.ToInt32(((HiddenField)this.FindControl("CurrentSongLang")).Value)];

            GetCurrentSongList(QueryType, QueryValue);
        }

        private void GetCurrentQuerySongSongList()
        {
            string QueryType = "";
            if (((RadioButton)gui_findDesktop.FindControl("QuerySong_SongName_Desktop_RadioButton")).Checked)
            {
                QueryType = "SongName";
            }
            else
            {
                QueryType = "SingerName";
            }
            string QueryValue = ((HiddenField)this.FindControl("CurrentQuerySong")).Value;

            GetCurrentSongList(QueryType, QueryValue);
        }

        protected void RefreshUpdatePanelButton_Click(object sender, EventArgs e)
        {
            if (((HiddenField)this.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                
            }
            else
            {
                
                
            }
            
        }
    }
}