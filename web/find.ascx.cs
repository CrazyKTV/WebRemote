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
            dset.songs.Clear();


            //System.Data.DataRow dataRow = dset.songs.NewRow();
            ////dataRow["ID"] = 1;
            //dataRow["SongName"] = "我愛夏天";
            //dataRow["Singer"] = "莫文蔚";            
            //dset.songs.Rows.Add(dataRow);

            //System.Data.DataRow dataRow2 = dset.songs.NewRow();
            ////dataRow["ID"] = 2;
            //dataRow["SongName"] = "小情歌";
            //dataRow["Singer"] = "蘇打綠";
            dset.songs.Rows.Add(new Object[] { 1, "111", "我愛夏天", "莫文蔚" });
            dset.songs.Rows.Add(new Object[] { 2, "222", "小情歌", "蘇打綠" });



            GridView1.DataSource = dset.songs;
            GridView1.DataBind();  
        }

        
    }
}