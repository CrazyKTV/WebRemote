using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class gui_songNumber : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void bAdd_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.wcf_addsong(tSongNumber.Text.Trim());
        }
        
        protected void tSongNumber_PreRender(object sender, EventArgs e)
        {
            tSongNumber.Text = "";
        }

        protected void bInsert_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.wcf_insertsong(tSongNumber.Text.Trim());
        }



    }
}