using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Controls;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace web
{
    public partial class advanced : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //only generate once for the QR code, isregard the sessions
                if (Application["QRimageMS"] == null)
                {
                    String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                    String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

                    QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                    QrCode qrCode = new QrCode();
                    qrEncoder.TryEncode(strUrl, out qrCode);

                    Renderer renderer = new Renderer(5, Brushes.Black, Brushes.White);
                    MemoryStream ms = new MemoryStream();
                    renderer.WriteToStream(qrCode.Matrix, ms, ImageFormat.Jpeg);
                    //GlobalFunctions.QRimageMS = ms;
                    Application["QRimageMS"]=ms;
                }

                if (GlobalFunctions.QRimageMS == null)
                {
                    GlobalFunctions.QRimageMS = (MemoryStream)Application["QRimageMS"];
                }
            }
            catch { }

        }

        protected void Random_Click(object sender, EventArgs e)
        {

        }

        protected void HideConsole_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "HideConsole");
        }

        protected void ShowTime_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Control(null, "ShowTime");
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Exit");
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            CrazyKTVWCF.DoCrazyKTV_Action(null, "Close");
        }


    }
}