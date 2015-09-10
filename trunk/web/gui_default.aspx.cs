using System;
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
                ddlanguage.SelectedValue = "zh-CHT";
                ddActions.SelectedValue = "Waiting List";
                gui_find.Visible = true;

                
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



            GlobalFunctions.currentlang = ddlanguage.SelectedValue.ToString();
            
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

        private void hideAllCU()
        {
            gui_tune.Visible = false;
            gui_advanced.Visible = false;
            gui_volume.Visible = false;
            gui_video.Visible = false;
            gui_currentList1.Visible = false;
            gui_songNumber.Visible = false;
            gui_find.Visible = false;
        }

        protected void BChannel_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Channel");
            ((HiddenField)gui_find.FindControl("findCaller")).Value="";

        }

        protected void BCut_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Cut");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BFind_Click(object sender, EventArgs e)
        {
            hideAllCU();
            gui_find.Visible = true;
            ddActions.SelectedValue = "Find";
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "toTop";
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

        protected void BdKeyUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Pitch");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdRepeat_Click(object sender, EventArgs e)
        {            
            //CrazyKTVWCF.DoCrazyKTV_Action(null, "Replay");
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
            //CrazyKTVWCF.DoCrazyKTV_Control(null, "Mute");
            CrazyKTVWCF.DoCrazyKTV_Action(null, "SongRecoedList");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdVolumeDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Volume");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void BdColumeUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Volume");
            ((HiddenField)gui_find.FindControl("findCaller")).Value = "";
        }

        protected void PlayListButton_Click(object sender, ImageClickEventArgs e)
        {
            hideAllCU();
            if (CrazyKTVWCF.WCFlive) gui_currentList1.Visible = true;
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


    }
}