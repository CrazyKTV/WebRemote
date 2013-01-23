using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

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
            GlobalFunctions.InidtSongs();
            GlobalFunctions.dtSongs.Clear();
            //dset.songs.Clear();

            GlobalFunctions.dtSongs.Rows.Add(new Object[] { "111", "我愛夏天", "莫文蔚", "langA",12 });
            GlobalFunctions.dtSongs.Rows.Add(new Object[] { "222", "小情歌", "蘇打綠","LANGB",2 });

            //json test
            



            GridView1.DataSource = GlobalFunctions.dtSongs;

            //json test
            //GridView1.DataSource = GlobalFunctions.DerializeDataTable();
            GridView1.DataBind();


            GridView1.Columns[1].Visible = false; //Song_Id
            GridView1.Columns[4].Visible = false; //Song_WordCount
           // GridView1.Columns[5].Visible = false; //Song_Lang




            ////GlobalFunctions.SearchKeyword();
            //string json = JsonConvert.SerializeObject(GlobalFunctions.dtSongs, Formatting.Indented, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            //});
            //Console.WriteLine(json);

            string json = @"{""key1"":""value1"",""key2"":""value2""}";

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            Console.WriteLine(values.Count);
            // 2

            Console.WriteLine(values["key1"]);
            // value1



            




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