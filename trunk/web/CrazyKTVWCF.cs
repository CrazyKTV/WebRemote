using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace web
{
    public class CrazyKTVWCF
    {
        public static string wcfUrl = Properties.Settings.Default.CrazyKTV_WCF_URL;

        public static string requestWeb(string url)
        {
            string strResponse = "";
            try
            {
                System.Net.WebRequest myWebRequest = WebRequest.Create(url);
                WebResponse myWebResponse = myWebRequest.GetResponse();
                System.IO.Stream ReceiveStream = myWebResponse.GetResponseStream();
                System.Text.Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                System.IO.StreamReader readStream = new StreamReader(ReceiveStream, encode);
                strResponse = readStream.ReadToEnd();
                // StreamWriter oSw = new StreamWriter(strFilePath);
                // oSw.WriteLine(strResponse);
                // oSw.Close();
                Console.WriteLine(strResponse);

                readStream.Close();
                myWebResponse.Close();
            }
            catch (Exception i)
            {
                strResponse = i.ToString();
            }

            return strResponse;
        }


        public static string wcf_ordersong(string songID)
        {
            string orderSongUrl = wcfUrl + string.Format("/OrderSong?value={0}", songID);
            return requestWeb(orderSongUrl);
        }




    }
}