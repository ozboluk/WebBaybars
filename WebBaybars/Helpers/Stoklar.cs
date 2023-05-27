using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebBaybars.Models;

namespace WebBaybars.Helpers
{
    public static class Stoklar
    {

      
        //public static int GelenMal(string barkod)
        //{
        //    try
        //    {
        //        BarkodcuboEntities db = new BarkodcuboEntities();
        //        return (int)db.Malinyeri.Where(x => x.barcod.Contains(barkod.Trim())).Sum(x => x.miktar);
        //    }
        //    catch
        //    {

        //        return 0;
        //    }

        //}
        //public static int KalanToplam(string barkod)
        //{

        //    BarkodcuboEntities db = new BarkodcuboEntities();
        //    try
        //    {
        //        //int depo = int.Parse(db.ExcellicinDepoToplami(barkod).ToString());
        //        //int satis = int.Parse(db.ExcellicinSatisToplam(barkod).ToString());


        //        return (GelenMal(barkod) - SatilanToplam(barkod));
        //    }
        //    catch
        //    {

        //        return 0;
        //    }

        //}
        public static string Urunadigetir(string barkod)
        {
            BarkodcuboEntities db = new BarkodcuboEntities();
            try
            {
                return db.AylikSayim.FirstOrDefault(x => x.Barkod == barkod.Trim()).Cinsi;
            }
            catch
            {


            }
            return "adsiz";


        }
        public static string GetMacIP()
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }
        public static string GetClientIp()
        {
            var ipAddress = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                ipAddress = HttpContext.Current.Request.UserHostName;
            return ipAddress;
        }
    }
}