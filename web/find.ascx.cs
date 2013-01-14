using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class find : System.Web.UI.UserControl
    {
       
                   protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSearch_Click(object sender, EventArgs e)
        {
            DataSet1 dset = new DataSet1();

            System.Data.DataRow dataRow = dset.songs.NewRow();
            dataRow["SongName"] = "name1";
            dset.songs.Rows.Add(dataRow);

            GridView1.DataSource = dset.songs;
            GridView1.DataBind();  
        }

        
    }
}