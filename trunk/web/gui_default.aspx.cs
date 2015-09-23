using System;
using System.Data;
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

            // check if the WCF is alive
            if (CrazyKTVWCF.WCFlive == false)
            {
                if (CrazyKTVWCF.checkWCF() == false)
                {
                    hideAllCU();
                    wcferror.Visible = true;
                }
                else
                {
                    wcferror.Visible = false;
                }
            }

            GlobalFunctions.currentlang = "zh-CHT";
            
            // if WCF is alive then continue with other process
            System.Threading.Thread.Sleep(150);  // to display "loading" icon for 0.15 second
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

        protected void BChannel_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Channel");
            ((HiddenField)gui_find.FindControl("findCaller")).Value="";

        }

        protected void BFind_Click(object sender, EventArgs e)
        {
            hideAllCU();
            gui_find.Visible = true;
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "toTop";
        }

        protected void BCut_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Cut");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdFixedCH_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Fixed");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdSongRecoed_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "SongRecoedList");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdRestart_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "RsetPlay");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdKeyDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Pitch");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdDefaultPitch_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "DefaultPitch");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdKeyUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Pitch");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }


        protected void BdRepeat_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Replay");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdRandom_Click(object sender, EventArgs e)
        {            
            CrazyKTVWCF.DoCrazyKTV_Control(null, "RandomSong");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdMale_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "MaleVoice");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdFemale_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "WomanVoice");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdPause_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "PlayPause");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdBackward_Click(object sender, EventArgs e)
        {            
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Back");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdForward_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Forward");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdMute_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Mute");
            //CrazyKTVWCF.DoCrazyKTV_Action(null, "SongRecoedList");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdVolumeDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Volume");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdVolumeUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Volume");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void PlayListButton_Click(object sender, EventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_currentList.Visible = true;
        }

        protected void FindSongButton_Click(object sender, ImageClickEventArgs e)
        {
            hideAllCU();
            gui_find.EnableMainMenuPanel();
            if (CrazyKTVWCF.WCFlive) gui_find.Visible = true;
        }

        protected void SongNumberButton_Click(object sender, ImageClickEventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_songNumber.Visible = true;
        }

        protected void AdvancedButton_Click(object sender, ImageClickEventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_advanced.Visible = true;
        }

        protected void hideAllfindDesktopPanel()
        {
            ((Panel)gui_findDesktop.FindControl("SongListPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("Panel3")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("MainMenuPanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SingerTypePanel")).Visible = false;
            ((Panel)gui_findDesktop.FindControl("SingerListPanel")).Visible = false;
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
                    break;
                case "MainMenu_QuerySongDesktopButton":
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

        protected void RefreshUpdatePanelButton_Click(object sender, EventArgs e)
        {
            if (((HiddenField)this.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                ((GridView)gui_currentListDesktop.FindControl("GridView1")).PageSize = (((HiddenField)this.FindControl("BrowserScreenMode")).Value == "Fullscreen") ? GuiGlobal.PlayListFullscreenPageSize : GuiGlobal.PlayListPageSize;
                ((GridView)gui_currentList.FindControl("GridView1")).AllowPaging = true;
                ((DataPager)gui_findDesktop.FindControl("SingerListDataPager")).PageSize = (((HiddenField)this.FindControl("BrowserScreenMode")).Value == "Fullscreen") ? GuiGlobal.SingerTypeFullscreenPageSize : GuiGlobal.SingerTypeDesktopPageSize;
            }
            else
            {
                ((GridView)gui_currentList.FindControl("GridView1")).PageSize = 1;
                ((GridView)gui_currentList.FindControl("GridView1")).AllowPaging = false;
                ((DataPager)gui_findDesktop.FindControl("SingerListDataPager")).PageSize = GuiGlobal.SingerTypePageSize;
            }
            
        }
    }
}