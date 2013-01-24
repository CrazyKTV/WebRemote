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
using System.Collections.Specialized;
using System.Text.RegularExpressions;

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
            //clean up data on display
            GridView1.DataSource = null;
            GridView1.DataBind();

            int rowsPerPage = 500; // will be super slow if more than 2000
            int? currentPageNumber = null; //if rowPerPage is more than 1300, then this must be NULL or nothing will be returned, if condition try to search more than one word, eg 天天, then this value must be NULL


            try
            {
                string jsonText = "";

                if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Song".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_SongName like '*" + tSearch.Text.ToString().Trim() + "*'", currentPageNumber, rowsPerPage); //more than 2000 per rows will be super slow
                }

                if (ddSearchType.SelectedValue.ToString().Trim().ToLower() == "Singer".ToLower())
                {
                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_Singer like '*" + tSearch.Text.ToString().Trim() + "*'", currentPageNumber, rowsPerPage); //more than 2000 per rows will be super slow
                }


                jsonText = jsonText.TrimStart('"');
                jsonText = jsonText.TrimEnd('"');
                jsonText = Regex.Replace(jsonText, @"\\""", @"""");

                DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);

                DataView dv = new DataView(dt);
                dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

                GridView1.DataSource = dv;
                GridView1.DataBind();



            }
            catch { }

           //  GlobalFunctions.DerializetoDataTable(); //test data
           


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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;            
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (GridViewSortDirection == null)
            {
                e.SortDirection = SortDirection.Descending;
            }
            else if (GridViewSortDirection == SortDirection.Ascending)
            {
                e.SortDirection = SortDirection.Descending;
            }
            else if (GridViewSortDirection == SortDirection.Descending)
            {
                e.SortDirection = SortDirection.Ascending;
            }

            GridViewSortDirection = e.SortDirection;
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;
                return (SortDirection)ViewState["sortDirection"];
            }
            set
            {
                ViewState["sortDirection"] = value;
            }
        }


    }
}