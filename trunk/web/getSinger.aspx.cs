﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class getSinger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //for (int i = 1; i <= 81; i++)
            //{
            //    Response.Write((getSingerSex(string.Format(@"http:www.oiktv.com/singerlist-m-{0}.html", i.ToString()),",0")).Replace(@"<pre></pre>", ""));
            //}
            //for (int i = 1; i <= 81; i++)
            //{
            //    Response.Write((getSingerSex(string.Format(@"http:www.oiktv.com/singerlist-w-{0}.html", i.ToString()), ",1")).Replace(@"<pre></pre>", ""));
            //}
            //for (int i = 1; i <= 81; i++)
            //{
            //    Response.Write((getSingerSex(string.Format(@"http:www.oiktv.com/singerlist-g-{0}.html", i.ToString()), ",2")).Replace(@"<pre></pre>", ""));
            //}
              */

            Response.Write(getSingerSex(@"http://mojim.com/twzlha_all.htm","0"));
            Response.Write(getSingerSex(@"http://mojim.com/twzlhb_all.htm","1"));
            Response.Write(getSingerSex(@"http://mojim.com/twzlhc_all.htm","2"));
            
            
        }

        private string getSingerSex(string url, string singerType) { 
            string _contecnt = CrazyKTVWCF.requestWeb(url);

            _contecnt = Regex.Replace(_contecnt, "<.*<table width=\"100%\">", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            _contecnt = Regex.Replace(_contecnt, "<script[\\s\\S]*?/script>", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            _contecnt = Regex.Replace(_contecnt, "(\\S*)<p align=\"center\"><script>document.write(.*)", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            _contecnt = Regex.Replace(_contecnt, "<(.|\\n)*?>", "",RegexOptions.Multiline | RegexOptions.IgnoreCase);
          //  _contecnt = _contecnt.Replace(Environment.NewLine + Environment.NewLine, "");
            _contecnt = _contecnt.Replace(Environment.NewLine, "," + singerType + Environment.NewLine);
            _contecnt = Regex.Replace(_contecnt, "[%*/]", "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            _contecnt = _contecnt.Replace(@"&", @"+");
            _contecnt = (@"<pre>" + Environment.NewLine+ _contecnt + Environment.NewLine+ @"</pre>");


           // _contecnt = Regex.Replace(_contecnt, @"<(.|\n)*?>", "");

           // Match _match = Regex.Match(_contecnt, @"(\S*)mart10 link4 radius7 btlink2(.*)<div");
           // string key = @"<a " +_match.Groups[0].Value +@">";
           // _contecnt=Regex.Replace(key,@"<(?:([a-zA-Z\?][\w:\-]*)(\s(?:\s*[a-zA-Z][\w:\-]*(?:\s*=(?:\s*""(?:\\""|[^""])*""|\s*'(?:\\'|[^'])*'|[^\s>]+))?)*)?(\s*[\/\?]?)|\/([a-zA-Z][\w:\-]*)\s*|!--((?:[^\-]|-(?!->))*)--|!\[CDATA\[((?:[^\]]|\](?!\]>))*)\]\])>",Environment.NewLine);
           // _contecnt = (@"<pre>" + _contecnt + @"</pre>").Replace(Environment.NewLine + Environment.NewLine, singerType + Environment.NewLine);
           //// Console.WriteLine(_contecnt);

            return _contecnt;
        }
    }
}