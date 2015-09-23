using System;

namespace web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if the WCF is alive
            if (CrazyKTVWCF.WCFlive == false)
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
                    }
                    if (GuiGlobal.AllSongDTStatus == false)
                    {
                        string jsonText = CrazyKTVWCF.QuerySong(null, null, null, null, 0, 1000000, "Song_Id");
                        GuiGlobal.AllSongDT = GlobalFunctions.JsontoDataTable(jsonText);
                        GuiGlobal.AllSongDTStatus = true;
                    }
                }
            }
        }

        protected void TUIButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/tui_default.aspx");
        }

        protected void GUIButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/gui_default.aspx");
        }
    }
}