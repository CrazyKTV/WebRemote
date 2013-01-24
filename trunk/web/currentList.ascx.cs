using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class currentList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string jsonText = CrazyKTVWCF.ViewSong(0, 2000);
            DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);

            DataView dv = new DataView(dt);
            //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}