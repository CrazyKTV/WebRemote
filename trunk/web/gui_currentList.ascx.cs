using System;
using System.Data;
using System.Web.UI.WebControls;

namespace web
{
    public partial class gui_currentList : System.Web.UI.UserControl
    {
        private void getDataToGv()
        {
            string jsonText = CrazyKTVWCF.ViewSong(0, GuiGlobal.QuerySongRows);
            DataTable dt = GlobalFunctions.JsontoDataTable(jsonText);

            int CurPageSize = (((HiddenField)this.Parent.FindControl("BrowserScreenMode")).Value == "Fullscreen") ? GuiGlobal.PlayListFullscreenPageSize : GuiGlobal.PlayListPageSize;

            // Desktop / Tablet Mode
            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (dt.Rows.Count == 0)
                {
                    DataColumn col = new DataColumn("Song_Id");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_Lang");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_SongName");
                    dt.Columns.Add(col);
                    col = new DataColumn("Song_Singer");
                    dt.Columns.Add(col);
                }

                if (dt.Rows.Count > CurPageSize)
                {
                    if (dt.Rows.Count % CurPageSize > 0)
                    {
                        int NewRowCount = CurPageSize - (dt.Rows.Count % CurPageSize);
                        for (int i = 0; i < NewRowCount; i++)
                        {
                            DataRow row = dt.NewRow();
                            row["Song_Lang"] = " ";
                            dt.Rows.Add(row);
                        }
                    }
                    GridView1.ShowFooter = false;
                }
                else
                {
                    int NewRowCount = CurPageSize - dt.Rows.Count;
                    for (int i = 0; i < NewRowCount; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["Song_Lang"] = " ";
                        dt.Rows.Add(row);
                    }
                    GridView1.ShowFooter = true;
                }
            }

            DataView dv = new DataView(dt);
            //dv.Sort = "Song_Singer asc, Song_SongName asc, Song_Id asc";

            GridView1.DataSource = dv;
            GridView1.DataBind();

            if (((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value.Contains("Desktop"))
            {
                if (dt.Rows.Count > CurPageSize)
                {
                    DropDownList ddlSelectPage = (DropDownList)GridView1.BottomPagerRow.FindControl("ddlSelectPage");
                    for (int i = 0; i < GridView1.PageCount; i++)
                    {
                        ddlSelectPage.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
                    }
                    ddlSelectPage.SelectedIndex = GridView1.PageIndex;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BIns_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            var data = GridView1.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID
            CrazyKTVWCF.DoCrazyKTV_Action(data.ToString().Trim(), "Insert");
        }

        protected void BDel_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Response.Write("Row Index of Link button: " + row.RowIndex +
            //               "DataKey value:" + GridView1.DataKeys[row.RowIndex].Value.ToString());

            var data = GridView1.DataKeys[row.RowIndex].Value.ToString(); //get hiddent Song_ID
            CrazyKTVWCF.DoCrazyKTV_Action(data.ToString().Trim(), "Delete");
        }

  

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            getDataToGv();
        }

        protected void Timer1_PreRender(object sender, EventArgs e)
        {
            try
            {
                Timer1.Interval = int.Parse(GlobalFunctions.DurationInSecond_currentList)*1000;
            }
            catch (Exception)
            { }
        }

        protected void GridView1_PreRender(object sender, EventArgs e)
        {
            getDataToGv();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();

                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Attributes.Add("colspan", "5");
                    tcHeader[0].CssClass = "gridviewHeader";
                    tcHeader[0].Text = "待播清單 (" + ((HiddenField)this.Parent.FindControl("BootstrapResponsiveMode")).Value + ") [歌庫: " + GuiGlobal.AllSongDT.Rows.Count + "]";
                    break;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void ddlSelectPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSelectPage = (DropDownList)GridView1.BottomPagerRow.FindControl("ddlSelectPage");

            int pIndex = 0;
            if (int.TryParse(ddlSelectPage.SelectedValue, out pIndex))
            {
                GridView1.PageIndex = pIndex;
            }
        }
    }
}