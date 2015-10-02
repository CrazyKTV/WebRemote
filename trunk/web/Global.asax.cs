using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            if (CrazyKTVWCF.checkWCF() == false)
            {
                Response.Redirect("/ErrorDeadWCF.aspx");
            }
            else
            {
                if (GuiGlobal.SingerTypeDTStatus == false)
                {
                    GlobalFunctions.setSingerImgFile();
                    GuiGlobal.SingerTypeDTStatus = true;
                }
                if (GuiGlobal.AllSongDTStatus == false)
                {
                    string jsonText = CrazyKTVWCF.QuerySong(null, null, null, null, 0, 1000000, "Song_Id");
                    GuiGlobal.AllSongDT = GlobalFunctions.JsontoDataTable(jsonText);
                    GuiGlobal.AllSongDTStatus = true;
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Response.Redirect("/ErrorDeadWCF.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}