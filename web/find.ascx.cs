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
        DataSet1 dset = new DataSet1();
       
         protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void bSearch_Click(object sender, EventArgs e)
        {
            
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    
            if (e.CommandName == "Add")
            {

                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell contactName = selectedRow.Cells[1];
                string contact = contactName.Text;

                // Display the selected author.
                //Console.WriteLine("You selected " + contact + ".");

            }


        }

        
    }
}