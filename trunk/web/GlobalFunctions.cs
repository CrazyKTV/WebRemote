﻿using System;
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

        public static bool GetSingerTypeDT()
        {
            string jsonText = "";
            List<string> SingerTypeList = new List<string>() { "0", "1", "2", "4", "5", "6", "7" };
            List<string> ImgFormatList = new List<string>() { ".jpg", ".png", ".bmp", ".gif" };
            GuiGlobal.SingerName = new List<string>();
            GuiGlobal.SingerType = new List<string>();

            foreach (string SingerType in SingerTypeList)
            {
                jsonText = CrazyKTVWCF.QuerySinger("Singer_Type=" + SingerType, 0, GuiGlobal.QuerySongRows, "Singer_Strokes, Singer_Name");
                DataTable dt = new DataTable();
                dt = GlobalFunctions.JsontoDataTable(jsonText);
                if (dt == null) return false;

                dt.Columns.Add("ImgFileUrl");

                foreach (DataRow row in dt.AsEnumerable())
                {
                    GuiGlobal.SingerName.Add(row["Singer_Name"].ToString());
                    GuiGlobal.SingerType.Add(SingerTypeList.IndexOf(SingerType).ToString());

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

            return true;
        }

        public static bool GetAllSongDT()
        {
            string jsonText = CrazyKTVWCF.QuerySong(null, null, null, null, 0, 1000000, "Song_Id");
            GuiGlobal.AllSongDT = GlobalFunctions.JsontoDataTable(jsonText);
            if (GuiGlobal.AllSongDT == null) return false;
            System.Threading.Thread.Sleep(200);

            jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_SingerType=3", 0, 1000000, "Song_Id");
            GuiGlobal.ChorusSongDT = GlobalFunctions.JsontoDataTable(jsonText);
            if (GuiGlobal.ChorusSongDT == null) return false;
            System.Threading.Thread.Sleep(200);

            foreach (string langstr in GuiGlobal.SongLangList)
            {
                jsonText = CrazyKTVWCF.QuerySong(langstr, null, null, null, 0, GuiGlobal.MaxNewSongRows, "Song_CreatDate desc, Song_SongName");
                if (GlobalFunctions.JsontoDataTable(jsonText) == null) return false;
                GuiGlobal.NewSongDT.Merge(GlobalFunctions.JsontoDataTable(jsonText));
                System.Threading.Thread.Sleep(200);
            }

            foreach (string langstr in GuiGlobal.SongLangList)
            {
                jsonText = CrazyKTVWCF.QuerySong(langstr, null, null, "Song_PlayCount >= 1", 0, GuiGlobal.MaxTopSongRows, "Song_PlayCount desc, Song_SongName");
                if (GlobalFunctions.JsontoDataTable(jsonText) == null) return false;
                GuiGlobal.TopSongDT.Merge(GlobalFunctions.JsontoDataTable(jsonText));
                System.Threading.Thread.Sleep(200);
            }
            return true;
        }


    }


    class GuiGlobal
    {
        public static List<string> SongLangList = new List<string>(Properties.Settings.Default.SongLangList.Split(','));

        public static int SingerTypePageSize = 60;
        public static int SongListPageSize = 100;
        public static int MaxNewSongRows = 500;
        public static int MaxTopSongRows = 500;
        public static int QuerySongRows = 100000;

        public static string DefaultButtonCssClass = "btn btn-success btn-lg";
        public static string ActiveButtonCssClass = "btn btn-primary btn-lg";

        public static bool AllSongDTStatus = false;
        public static bool SingerTypeDTStatus = false;

        public static List<string> SingerName = new List<string>();
        public static List<string> SingerType = new List<string>();

        public static DataTable AllSongDT = new DataTable();
        public static DataTable ChorusSongDT = new DataTable();
        public static DataTable NewSongDT = new DataTable();
        public static DataTable TopSongDT = new DataTable();


        public static DataTable SingerTypeMaleDT = new DataTable();
        public static DataTable SingerTypeFemaleDT = new DataTable();
        public static DataTable SingerTypeGroupDT = new DataTable();
        public static DataTable SingerTypeForeignMale = new DataTable();
        public static DataTable SingerTypeForeignFemale = new DataTable();
        public static DataTable SingerTypeForeignGroup = new DataTable();
        public static DataTable SingerTypeOther = new DataTable();
    }



}