using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Xml;

namespace web
{
    public partial class find : System.Web.UI.UserControl
    {
        //DataSet1 dset = new DataSet1();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void bSearch_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = GlobalFunctions.DerializetoDataTable();
            GridView1.DataBind();


            GridView1.Columns[1].Visible = false; //Song_Id
            GridView1.Columns[4].Visible = false; //Song_WordCount

        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Trim() == "Add".ToLower().Trim())
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.

                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell Song_Id = selectedRow.Cells[1];
                CrazyKTVWCF.wcf_addsong(Song_Id.Text.Trim());
            }

            if (e.CommandName.ToLower().Trim() == "Insert".ToLower().Trim())
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the last name of the selected author from the appropriate
                // cell in the GridView control.
                GridViewRow selectedRow = GridView1.Rows[index];
                TableCell Song_Id = selectedRow.Cells[1];
                CrazyKTVWCF.wcf_insertsong(Song_Id.Text.Trim());
            }




        }


    }
}