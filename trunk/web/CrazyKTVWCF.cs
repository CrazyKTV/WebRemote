using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Collections.Specialized;

namespace web
{
    public class CrazyKTVWCF
    {
        public static string wcfUrl = Properties.Settings.Default.CrazyKTV_WCF_URL;
        public static bool WCFlive=false;



        public static bool checkWCF()
        {
            WebRequest request = WebRequest.Create(wcfUrl);
            HttpWebResponse response;
            string __responseText = "";

            try {
               response= (HttpWebResponse)request.GetResponse();           
            }
            catch (WebException e) {
                __responseText = e.ToString();
            }

            if (__responseText.Trim().ToLower().IndexOf("Unable to connect to the remote server".Trim().ToLower()) == -1)
            {
                WCFlive = true;
                return true; }
            else
            {
                WCFlive = false; 
                return false; }
   
        }


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

        //public static string requestJSONWeb()
        //{ 
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
        //    httpWebRequest.ContentType = "text/json";
        //    httpWebRequest.Method = "POST";

        //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //    {
        //    string json = "{\"user\":\"test\"," +
        //                  "\"password\":\"bla"}";

        //    streamWriter.Write(json);
        //    streamWriter.Flush();
        //    streamWriter.Close();

        //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //    {
        //        var result = streamReader.ReadToEnd();
        //    }
        //}

        public static string wcf_addsong(string songID)
        {
            string orderSongUrl = "";                       

            if (songID != null)
            {
                //orderSongUrl = wcfUrl + string.Format("/OrderSong?value={0}", songID.Trim());

                NameValueCollection collection = new NameValueCollection();
                collection.Add("value", songID.Trim());

                orderSongUrl=wcfUrl + string.Format("/OrderSong") + GlobalFunctions.ToQueryString(collection);
            }

            return requestWeb(orderSongUrl);
        }

        public static bool wcf_insertsong(string songID)
        {
            DoCrazyKTV_Action(songID, "Inster");
            return true;
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


        public static string QuerySong(string lang, string singer, string words, string condition, int page, int rows)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            if (lang != null || lang=="")
            {
                collection.Add("lang", lang.Trim());
            }

            if (singer != null || singer == "")
            {
                collection.Add("singer", singer.Trim());
            }

            if (words != null || words == "")
            {
                collection.Add("words", words.Trim());
            }

            if (condition != null || condition == "")
            {
                collection.Add("condition", condition.Trim());
            }


             collection.Add("page", page.ToString().Trim());
             collection.Add("rows", rows.ToString().Trim());

             Url = wcfUrl + string.Format("/QuerySong") + GlobalFunctions.ToQueryString(collection);


             return requestWeb(Url);
        }


        public static string ViewSong(int page, int rows)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            collection.Add("page", page.ToString().Trim());
            collection.Add("rows", rows.ToString().Trim());

            Url = wcfUrl + string.Format("/ViewSong") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);
        }





    }
}