using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class tune : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tuneUp_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(1, "Pitch");
        }

        protected void tuneDown_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "Pitch");
        }

        protected void tuneReset_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "DefaultPitch");
        }

        protected void tuneMaleVoice_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "WomanVoice");
        }

        protected void tuneWomanVoice_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(-1, "MaleVoice");
        }


    }
}