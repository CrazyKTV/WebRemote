﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            if (CrazyKTVWCF.checkWCF() == false)
            {
                Response.Redirect("/ErrorDeadWCF.aspx");
            }
            else
            {
                if (GuiGlobal.SingerTypeDTStatus == false)
                {
                    GlobalFunctions.setSingerImgFile();
                    GuiGlobal.SingerTypeDTStatus = true;
                    System.Threading.Thread.Sleep(200);
                }
                if (GuiGlobal.AllSongDTStatus == false)
                {
                    string jsonText = CrazyKTVWCF.QuerySong(null, null, null, null, 0, 1000000, "Song_Id");
                    GuiGlobal.AllSongDT = GlobalFunctions.JsontoDataTable(jsonText);
                    System.Threading.Thread.Sleep(200);

                    jsonText = CrazyKTVWCF.QuerySong(null, null, null, "Song_SingerType=3", 0, 1000000, "Song_Id");
                    GuiGlobal.ChorusSongDT = GlobalFunctions.JsontoDataTable(jsonText);
                    System.Threading.Thread.Sleep(200);

                    foreach (string langstr in GuiGlobal.SongLangList)
                    {
                        jsonText = CrazyKTVWCF.QuerySong(langstr, null, null, null, 0, GuiGlobal.MaxNewSongRows, "Song_CreatDate desc, Song_SongName");
                        GuiGlobal.NewSongDT.Merge(GlobalFunctions.JsontoDataTable(jsonText));
                        System.Threading.Thread.Sleep(200);
                    }

                    foreach (string langstr in GuiGlobal.SongLangList)
                    {
                        jsonText = CrazyKTVWCF.QuerySong(langstr, null, null, "Song_PlayCount >= 1", 0, GuiGlobal.MaxTopSongRows, "Song_PlayCount desc, Song_SongName");
                        GuiGlobal.TopSongDT.Merge(GlobalFunctions.JsontoDataTable(jsonText));
                        System.Threading.Thread.Sleep(200);
                    }



                    GuiGlobal.AllSongDTStatus = true;
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Response.Redirect("/ErrorDeadWCF.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}