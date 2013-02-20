using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web
{
    public partial class _default : System.Web.UI.Page
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
                currentList1.Visible = true;
            }

            // check if the WCF is alive
            if (CrazyKTVWCF.WCFlive == false)
            {
                if (CrazyKTVWCF.checkWCF() == false)
                {
                    Response.Redirect("ErrorDeadWCF.html");
                }
            }

            GlobalFunctions.currentlang = ddlanguage.SelectedValue.ToString();
            // if WCF is alive then continue with other process
            System.Threading.Thread.Sleep(150);

            

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
                find.Visible = true;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Song Number".ToLower())
            {
                songNumber.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Waiting List".ToLower())
            {
                currentList1.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Video".ToLower())
            {
                video.Visible = true;
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Volume".ToLower())
            {
                volume.Visible = true;
            }

 

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Tune".ToLower())
            {
                tune.Visible = true;
            }



            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "advanced".ToLower())
            {
                advanced.Visible = true;
            }
   


        }

        private void hideAllCU()
        {
            tune.Visible = false;
            advanced.Visible = false;
                volume.Visible = false;
                video.Visible = false;
                currentList1.Visible = false;
                songNumber.Visible = false;
                find.Visible = false;
        }

        protected void BChannel_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Channel");
            ((HiddenField)find.FindControl("findCaller")).Value="";

        }

        protected void BCut_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Cut");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BFind_Click(object sender, EventArgs e)
        {
            hideAllCU();
            find.Visible = true;
            ddActions.SelectedValue = "Find";
            ((HiddenField)find.FindControl("findCaller")).Value = "toTop";
        }

        protected void BdRestart_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "RsetPlay");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdKeyDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Pitch");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdKeyUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Pitch");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdRepeat_Click(object sender, EventArgs e)
        {            
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Replay");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdMale_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "MaleVoice");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdFemale_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "WomanVoice");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdPause_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "PlayPause");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdBackward_Click(object sender, EventArgs e)
        {            
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Back");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdForward_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Forward");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdMute_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Mute");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdVolumeDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Volume");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }

        protected void BdColumeUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Volume");
            ((HiddenField)find.FindControl("findCaller")).Value = "";
        }





    }
}