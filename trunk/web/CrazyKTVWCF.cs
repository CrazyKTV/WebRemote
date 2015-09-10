using System;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Net.NetworkInformation;

namespace web
{
    public class CrazyKTVWCF
    {
        public static string wcfUrl = Properties.Settings.Default.CrazyKTV_WCF_URL;
        public static bool WCFlive = false;




        public static bool checkWCF()
        {
            WebRequest request = WebRequest.Create(wcfUrl + "/QuerySong");
            request.Timeout = 500;
            HttpWebResponse response;
            string responseText = "";

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                responseText = sr.ReadToEnd();
                sr.Close();
                response.Close();
            }
            catch
            {
                WCFlive = false;

                IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
                foreach (IPEndPoint endPoint in ipEndPoints)
                {
                    if (endPoint.Address.ToString() == "0.0.0.0" && endPoint.Port != 80 && endPoint.Port != 135 && endPoint.Port != 445 && endPoint.Port != 5357)
                    {
                        try
                        {
                            request = WebRequest.Create("http://127.0.0.1:" + endPoint.Port + "/QuerySong");
                            request.Timeout = 500;
                            response = (HttpWebResponse)request.GetResponse();
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                StreamReader sr = new StreamReader(response.GetResponseStream());
                                responseText = sr.ReadToEnd();
                                sr.Close();

                                if (responseText == "[]")
                                {
                                    wcfUrl = "http://127.0.0.1:" + endPoint.Port;
                                    WCFlive = true;
                                    break;
                                }
                            }
                            response.Close();
                        }
                        catch
                        {

                        }
                    }
                }
            }

            if (responseText == "[]")
            {
                WCFlive = true;
            }

            return WCFlive;
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
                //Console.WriteLine(strResponse);

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
            DoCrazyKTV_Action(songID, "Insert");
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
            //string Url = "";

            //if (value!=null)
            //{
            //    Url = wcfUrl + string.Format("/DoCrazyKTV_Action?value={0}&state={1}", value.Trim(), state.Trim());
            //}
            //else
            //{
            //    Url = wcfUrl + string.Format("/DoCrazyKTV_Action?state={0}", state.Trim());
            //}

            //return requestWeb(Url);

            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            if (value != null)
            {
                collection.Add("value", value.ToString().Trim());
            }


            collection.Add("state", state.ToString().Trim());

            Url = wcfUrl + string.Format("/DoCrazyKTV_Action") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);

        }

        public static string QuerySong(string lang, string singer, string words, string condition, int? page, int rows, string sort)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            if (lang != null && lang!="")
            {
                collection.Add("lang", lang.Trim());
            }

            if (singer != null && singer != "")
            {
                collection.Add("singer", singer.Trim());
            }

            if (words != null && words != "")
            {
                collection.Add("words", words.Trim());
            }

            if (condition != null && condition != "")
            {
                collection.Add("condition", condition.Trim());
            }

            if (sort != null && sort != "")
            {
                collection.Add("sort", sort.Trim());
            }

            if (page.HasValue==true)
            {
                collection.Add("page", page.ToString());
            }


             collection.Add("rows", rows.ToString().Trim()); //must have

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

        public static string FavoriteLogin(string user)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            collection.Add("user", user.ToString().Trim());

            Url = wcfUrl + string.Format("/FavoriteLogin") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);
        }

        public static string FavoriteUser(int page, int rows) {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            collection.Add("page", page.ToString().Trim());
            collection.Add("rows", rows.ToString().Trim());

            Url = wcfUrl + string.Format("/FavoriteUser") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);
        }
        
        public static string FavoriteSong(string user, int page, int rows)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            collection.Add("user", user.ToString().Trim());
            collection.Add("page", page.ToString().Trim());
            collection.Add("rows", rows.ToString().Trim());

            Url = wcfUrl + string.Format("/FavoriteSong") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);
        }

        public static string QuerySinger(string condition, int page, int rows, string sort)
        {
            string Url = "";

            NameValueCollection collection = new NameValueCollection();

            collection.Add("condition", condition.ToString().Trim());
            collection.Add("sort", sort.ToString().Trim());
            collection.Add("page", page.ToString().Trim());
            collection.Add("rows", rows.ToString().Trim());

            Url = wcfUrl + string.Format("/QuerySinger") + GlobalFunctions.ToQueryString(collection);


            return requestWeb(Url);
        }
        




    }
}