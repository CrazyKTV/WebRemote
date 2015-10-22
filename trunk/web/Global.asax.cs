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
            System.Threading.Thread.Sleep(500);
            if (CrazyKTVWCF.checkWCF())
            {
                if (GuiGlobal.SingerTypeDTStatus == false)
                {
                    GuiGlobal.SingerTypeDTStatus = GlobalFunctions.GetSingerTypeDT();
                    System.Threading.Thread.Sleep(200);
                }

                if (GuiGlobal.AllSongDTStatus == false)
                {
                    GuiGlobal.AllSongDTStatus = GlobalFunctions.GetAllSongDT();
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (!GuiGlobal.SingerTypeDTStatus && !GuiGlobal.AllSongDTStatus)
            {
                Response.Redirect("/gui_wcferror.aspx");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("/gui_wcferror.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}