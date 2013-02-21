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
        private void getDataToGv()
        {
            string jsonText = CrazyKTVWCF.ViewSong(0, 1000); // it will be very slow if more than 2000
            DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);

            DataView dv = new DataView(dt);
            //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            GridView1.DataSource = dv;
            GridView1.DataBind();        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //getDataToGv();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            var data = GridView1.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0]; //get hiddent Song_ID

            if (e.CommandName.ToLower().Trim() == "Insert".ToLower().Trim())
            {
                int index = Convert.ToInt32(e.CommandArgument);
                CrazyKTVWCF.DoCrazyKTV_Action(data.ToString().Trim(), "Insert");
            }


            if (e.CommandName.ToLower().Trim() == "Del".ToLower().Trim())
            {
                int index = Convert.ToInt32(e.CommandArgument);
                CrazyKTVWCF.DoCrazyKTV_Action(data.ToString().Trim(), "Delete");
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            getDataToGv();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex != -1)
            //{
            //    //Here Index of Cell will be the No of Delete Column. 
            //    LinkButton btn = (Button)e.Row.Cells[1].Controls[1];
            //    //btn.Attributes.Add("onclick", "if (confirm('Are you sure to delete this admin user?')){return true} else {return false}");
            //    if (GlobalFunctions.currentlang.ToString().Trim().ToLower() == "zh-CHT".ToLower())
            //    {
            //        btn.Attributes.Add("onclick", "return confirm('刪除此歌曲?');");
            //    }
            //    else
            //    {
            //        btn.Attributes.Add("onclick", "return confirm('Remove this song?');");
            //    }

            //}
        }

        protected void Timer1_PreRender(object sender, EventArgs e)
        {
            try
            {
               Timer1.Interval = int.Parse(GlobalFunctions.DurationInMillisecond_currentList);
            }
            catch (Exception)
            { }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            getDataToGv();
        }
    }
}