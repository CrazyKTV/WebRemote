using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data;

namespace web
{
    public class GlobalFunctions
    {

        public static System.IO.MemoryStream QRimageMS;
        //public static string wcfUrl = Properties.Settings.Default.CrazyKTV_WCF_URL;
        public static string currentlang = "";

        public static string DurationInMillisecond_currentList
        {
            get
            {
                if (getCookieValue("DurationInMillisecond_currentList") != null)
                    return getCookieValue("DurationInMillisecond_currentList").ToString();
                else
                    return Properties.Settings.Default.DurationInMillisecond_currentList.ToString();
            }

            set { ;}
        }



        public static DataTable JsontoDataTable(string jsonString)
        {
            try
            {
                var table = JsonConvert.DeserializeObject<System.Data.DataTable>(jsonString);
                return (DataTable)table;
            }
            catch { return null; }

            
        }


        public static string SearchKeyword()
        {
            //var hardware = new TopSecretHardware()
            //{
            //    ID = 1,
            //    Name = "box 1",
            //    IPAddress = new IPAddressAndPort("192.168.1.71:123")
            //};

            //string json = JsonConvert.SerializeObject(hardware);

            //Console.WriteLine(json);

            //TopSecretHardware dehardware = JsonConvert.DeserializeObject<TopSecretHardware>(json);

            //Console.WriteLine("{0} - {1} - {2}", dehardware.ID, dehardware.Name, dehardware.IPAddress);

            //string json = JsonConvert.SerializeObject(GlobalFunctions.dt.Tables["songs"], Formatting.Indented);
            //Console.WriteLine(json);

            return "Nothing returned";
        }



        public static string ToQueryString(System.Collections.Specialized.NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
        }


        public static bool setCookie(string cookieName, string value)
        {

            HttpContext.Current.Response.Cookies["userSettings"][cookieName] = value.ToString();
            HttpContext.Current.Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(18262);
            return true;
        }

        public static bool setCookie(string cookieObjectName, string cookieName, string value)
        {
            HttpContext.Current.Response.Cookies[cookieObjectName][cookieName] = value.ToString();
            HttpContext.Current.Response.Cookies["UserSettings"].Expires = DateTime.Now.AddDays(18262);
            return true;
        }

        public static string getCookieValue(string cookieName)
        {
            string _value = null;

            if (HttpContext.Current.Request.Cookies["UserSettings"] != null)
            {
                if (HttpContext.Current.Request.Cookies["UserSettings"][cookieName] != null)
                { _value = HttpContext.Current.Request.Cookies["UserSettings"][cookieName].ToString();}
            }

            return _value;
        }

        public static string getCookieValue(string cookieObjectName, string cookieName)
        {
            string _value = null;

            if (HttpContext.Current.Request.Cookies[cookieObjectName] != null)
            {
                if (HttpContext.Current.Request.Cookies[cookieObjectName][cookieName] != null)
                { _value = HttpContext.Current.Request.Cookies[cookieObjectName][cookieName].ToString(); }
            }

            return _value;
        }






    }
}