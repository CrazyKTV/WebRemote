using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class volume : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Mute_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "Mute");
        }

        protected void softer_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Volume");
        }

        protected void louder_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Volume");
        }

        protected void reset_Click(object sender, EventArgs e)
        {

        }

        protected void record_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Record");
        }

        protected void FixVolume_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "AmendVolume");
        }
    }
}