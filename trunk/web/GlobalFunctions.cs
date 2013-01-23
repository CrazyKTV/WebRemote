using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace web
{
    public class GlobalFunctions
    {
        public static DataSet1.songsDataTable dtSongs { get; set; }

        public static bool InidtSongs()
        { 
            DataSet1 ds = new DataSet1();
            dtSongs = ds.songs;
            return true; 
        }

        //public static string AddSong(string _songNumber)
        //{
        //    try { 
        //    //add song here
        //    }
        //    catch {
        //        return "Adding failed";
        //    }

        //    return "Added";
        //}

        //public static string InsertSong(string _songNumber)
        //{
        //    try
        //    {
        //        //Insert song here
        //    }
        //    catch
        //    {
        //        return "inserting failed";
        //    }

        //    return "Inserted";
        //}


        public static DataSet1.songsDataTable DerializeDataTable()
        {
            //const string json = @"[{""SongNum"":""AAA"",""Singer"":""22"",""SongName"":""PPP""},"
            //                   + @"{""SongNum"":""BBB"",""Singer"":""25"",""SongName"":""QQQ""},"
            //                   + @"{""SongNum"":""CCC"",""Singer"":""38"",""SongName"":""RRR""}]";
            //var table = JsonConvert.DeserializeObject<System.Data.DataTable>(json);
            //return table;

            const string json = @"[{""SongNum"":""111"",""SongName"":""我愛夏天"",""Singer"":""莫文蔚""},"
                              + @"{""SongNum"":""222"",""SongName"":""小情歌"",""Singer"":""蘇打綠""},"
                              + @"{""SongNum"":""333"",""SongName"":""我愛夏天2"",""Singer"":""莫文蔚""}]";
            var table = JsonConvert.DeserializeObject<System.Data.DataTable>(json);
            //dtSongs. = table;
            return (DataSet1.songsDataTable)table;
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

            string json = JsonConvert.SerializeObject(dtSongs, Formatting.Indented);
            Console.WriteLine(json);

            return "Nothing returned";
        }



        public static string ToQueryString(System.Collections.Specialized.NameValueCollection nvc)
        {
            return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
        }






    }
}