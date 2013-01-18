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
            string orderSongUrl = "";
            if (songID != null)
            {
                orderSongUrl = wcfUrl + string.Format("/OrderSong?value={0}", songID.Trim());
            }

            return requestWeb(orderSongUrl);
        }



        /// <summary>
        /// Does the crazy KT v_ control.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="state">
        ///Fixed,//固定,value 不需值
        ///Volume,//音量,value 1代表加 -1代表減
        ///Pitch,//升降Key,value 1代表加 -1代表減
        ///Channel,//聲道,value 不需值
        ///Mute//靜音,value 不需值
        /// </param>
        /// <returns></returns>
        public static string DoCrazyKTV_Control(int? value, string state)
        {
            string Url = "";

            if (value.HasValue == true)
            {
                Url = wcfUrl + string.Format("/DoCrazyKTV_Control?value={0}&state={1}", value, state.Trim());
            }
            else {
                Url = wcfUrl + string.Format("/DoCrazyKTV_Control?state={0}", state.Trim());
            }

            return requestWeb(Url);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">song_ID</param>
        /// <param name="state">
        ///
        ///Delete,//刪歌,value Song_Id
        ///Cut,//切歌,value 不需值
        ///Inster,//插播,value Song_Id
        ///Replay//重播,value 不需值
        /// <returns></returns>
        public static string DoCrazyKTV_Action(string value, string state)
        {
            string Url = "";

            if (value!=null)
            {
                Url = wcfUrl + string.Format("/DoCrazyKTV_Action?value={0}&state={1}", value.Trim(), state.Trim());
            }
            else
            {
                Url = wcfUrl + string.Format("/DoCrazyKTV_Action?state={0}", state.Trim());
            }

            return requestWeb(Url);
        }


    }
}