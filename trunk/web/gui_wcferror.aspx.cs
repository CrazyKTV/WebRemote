using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class gui_wcferror : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            int TimerTotalValue = Convert.ToInt32(((HiddenField)this.FindControl("TimerTotal")).Value) - 1;
            ((HiddenField)this.FindControl("TimerTotal")).Value = TimerTotalValue.ToString();
            ((Label)this.FindControl("WcfError_Label")).Text = "目前無法連線至 WCF 服務,請確認 CrazyKTV 系統設定裡有啟用 WCF 服務, " + TimerTotalValue.ToString() + " 秒後系統將會再次嘗試連線。";

            if (TimerTotalValue == 0) ((UpdateProgress)this.FindControl("UpdateProgress")).Visible = true;
            if (TimerTotalValue == -1)
            {
                if (CrazyKTVWCF.checkWCF() == false)
                {
                    Response.Redirect("/gui_wcferror.aspx");
                }
                else
                {
                    System.Threading.Thread.Sleep(200);
                    GuiGlobal.SingerTypeDTStatus = GlobalFunctions.GetSingerTypeDT();
                    System.Threading.Thread.Sleep(200);
                    GuiGlobal.AllSongDTStatus = GlobalFunctions.GetAllSongDT();

                    if (GuiGlobal.SingerTypeDTStatus && GuiGlobal.AllSongDTStatus)
                    {
                        Response.Redirect("/default.aspx");
                    }
                    else
                    {
                        Response.Redirect("/gui_wcferror.aspx");
                    }
                }
            }
        }

        protected void Timer_PreRender(object sender, EventArgs e)
        {

        }
    }
}