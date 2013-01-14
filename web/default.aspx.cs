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
            // dropdown change languages
            if (Request.Form["ddlanguage"] != null)
            {
                String selectedLanguage = Request.Form["ddlanguage"];
                UICulture = selectedLanguage;
                Culture = selectedLanguage;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(selectedLanguage);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(selectedLanguage);
            }
            base.InitializeCulture();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (UICulture == null)
                language.Visible = false;
             */
            //System.Threading.Thread.Sleep(2000);
            //Console.WriteLine( System.Threading.Thread.CurrentThread.CurrentCulture);

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
            string state = e.State["historyPoint"];
            ddActions.SelectedIndex = Convert.ToInt32(state);
        }



        protected void ddActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////for broswer back button
            if (ScriptManager1.IsInAsyncPostBack && !ScriptManager1.IsNavigating)
            {
                ScriptManager1.AddHistoryPoint("historyPoint", ddActions.SelectedIndex.ToString(), ddActions.SelectedValue);
            }


            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Find".ToLower())
            {
                find.Visible = true;
            }
            else
            {
                find.Visible = false;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Song Number".ToLower())
            {
                songNumber.Visible = true;
            }
            else
            {
                songNumber.Visible = false;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Waiting List".ToLower())
            {
                currentList1.Visible = true;
            }
            else
            {
                currentList1.Visible = false;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Video".ToLower())
            {
                video.Visible = true;
            }
            else
            {
                video.Visible = false;
            }

            if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Volume".ToLower())
            {
                volume.Visible = true;
            }
            else
            {
                volume.Visible = false;
            }

            //if (ddActions.SelectedValue.ToString().ToLower().Trim() == "Tune".ToLower())
            //{
            //    tune.Visible = true;
            //}
            //else
            //{
            //    tune.Visible = false;
            //}




        }





    }
}