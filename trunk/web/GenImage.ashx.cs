using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace web
{
    /// <summary>
    /// Summary description for GenImage
    /// </summary>
    public class GenImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            //int width = 150; //int.Parse(context.Request.QueryString["width"]);
            //int height = 150; //int.Parse(context.Request.QueryString["height"]);

            //Bitmap bitmap = new Bitmap(width, height);

            //Graphics g = Graphics.FromImage((Image)bitmap);
            //g.FillRectangle(Brushes.Red, 0f, 0f, bitmap.Width, bitmap.Height);	// fill the entire bitmap with a red rectangle

            //MemoryStream mem = new MemoryStream();
            //bitmap.Save(mem, ImageFormat.Jpeg);

            byte[] buffer = GlobalFunctions.QRimageMS.ToArray();
            //byte[] buffer = Application["QRimageMS"].ToArray();

            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(buffer);
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}