using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBaybars.Models;

namespace WebBaybars.Helpers
{
    public class GetData
    {
        //public static string ProductPrice(string id)
        //{
        //    using (BarkodcuboEntities db = new BarkodcuboEntities())
        //    {
        //        var orderdetail = db.EnCokSatilanlarGunBazinda(id.Trim(), 0).FirstOrDefault();
        //        var data = db.AylikSayim.FirstOrDefault(x => x.Barkod == id);
        //        if (data != null)
        //        {
        //            //return data.Cinsi+"("+ orderdetail.Value + ")";
        //            return data.Cinsi;
        //        }
        //        else
        //        {
        //            return "Bu ürün henüz kaydedilmedi.";
        //        }
        //    }

        //}
        public static string ProductName(string id)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                //var orderdetail = db.EnCokSatilanlarGunBazinda(id.Trim(), 0).FirstOrDefault();
                var data = db.AylikSayim.FirstOrDefault(x => x.Barkod == id);
                if (data != null)
                {
                    //return data.Cinsi+"("+ orderdetail.Value + ")";
                    return data.Cinsi;
                }
                else
                {
                    return "Bu ürün henüz kaydedilmedi.";
                }
            }
        }
          
        public static int UrunlerinToplamSatislari(string id)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
               var ogren= db.Proc_SatilanUrunuBarkodlaSatisToplaminiOgren(id);
                try
                {
                    if (ogren != null)
                    {
                        return Convert.ToInt32(ogren.Select(x => x.SatisAdeti).FirstOrDefault());
                    }
                }
                catch 
                {

                  
                }
             
                return 0;
            }

        }




        }
    }