using System;

namespace web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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