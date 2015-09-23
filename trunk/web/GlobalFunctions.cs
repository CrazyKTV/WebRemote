using System;
using System.Web;
using Newtonsoft.Json;
using System.Data;
using System.Collections.Generic;
using System.IO;

namespace web
{
    public class GlobalFunctions
    {

        public static System.IO.MemoryStream QRimageMS;
        //public static string wcfUrl = Properties.Settings.Default.CrazyKTV_WCF_URL;
        public static string currentlang = "";

        public static string DurationInSecond_currentList
        {
            get
            {
                if (getCookieValue("DurationInSecond_currentList") != null)
                    return getCookieValue("DurationInSecond_currentList").ToString();
                else
                    return Properties.Settings.Default.DurationInSecond_currentList.ToString();
            }

            set { ;}
        }

        public static string FindListOrder
        {
            get
            {
                if (getCookieValue("FindListOrder") != null)
                    return getCookieValue("FindListOrder").ToString();
                else
                    return Properties.Settings.Default.FindListOrder.ToString();
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

        public static void setSingerImgFile()
        {
            string jsonText = "";
            List<string> SingerTypeList = new List<string>() { "0", "1", "2", "4", "5", "6", "7" };
            List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };

            foreach (string SingerType in SingerTypeList)
            {
                jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=" + SingerType, 0, 2000, "Singer_Strokes, Singer_Name");
                DataTable dt = new DataTable();
                dt = GlobalFunctions.JsontoDataTable(jsonText);
                dt.Columns.Add("ImgFileUrl");

                foreach (DataRow row in dt.AsEnumerable())
                {
                    foreach (string ImgFormat in ImgFormatList)
                    {
                        if (File.Exists(HttpContext.Current.Server.MapPath("/singerimg/" + row["Singer_Name"].ToString() + ImgFormat)))
                        {
                            row["ImgFileUrl"] = "/singerimg/" + row["Singer_Name"].ToString() + ImgFormat;
                            break;
                        }
                    }
                    if (row["ImgFileUrl"].ToString() == "")
                    {
                        row["ImgFileUrl"] = "/images/singertype_default.png";
                    }
                }

                switch (SingerTypeList.IndexOf(SingerType))
                {
                    case 0:
                        GuiGlobal.SingerTypeMaleDT = dt;
                        break;
                    case 1:
                        GuiGlobal.SingerTypeFemaleDT = dt;
                        break;
                    case 2:
                        GuiGlobal.SingerTypeGroupDT = dt;
                        break;
                    case 3:
                        GuiGlobal.SingerTypeForeignMale = dt;
                        break;
                    case 4:
                        GuiGlobal.SingerTypeForeignFemale = dt;
                        break;
                    case 5:
                        GuiGlobal.SingerTypeForeignGroup = dt;
                        break;
                    case 6:
                        GuiGlobal.SingerTypeOther = dt;
                        break;
                }
            }
            GuiGlobal.SingerTypeDTStatus = true;
        }




    }


    class GuiGlobal
    {
        public static int SingerTypePageSize = 60;
        public static int SingerTypeDesktopPageSize = 18;
        public static int SingerTypeFullscreenPageSize = 24;

        public static int SongListPageSize = 500;
        public static int SongListDesktopPageSize = 8;
        public static int SongListFullscreenPageSize = 11;

        public static int PlayListPageSize = 10;
        public static int PlayListFullscreenPageSize = 13;


        public static int QuerySongRows = 50000;

        public static string DefaultButtonCssClass = "btn btn-success btn-lg";
        public static string ActiveButtonCssClass = "btn btn-primary btn-lg";

        public static bool SingerTypeDTStatus = false;
        public static DataTable SingerTypeMaleDT = new DataTable();
        public static DataTable SingerTypeFemaleDT = new DataTable();
        public static DataTable SingerTypeGroupDT = new DataTable();
        public static DataTable SingerTypeForeignMale = new DataTable();
        public static DataTable SingerTypeForeignFemale = new DataTable();
        public static DataTable SingerTypeForeignGroup = new DataTable();
        public static DataTable SingerTypeOther = new DataTable();
    }



}