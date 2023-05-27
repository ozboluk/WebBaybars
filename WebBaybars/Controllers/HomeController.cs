using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebBaybars.Helpers;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Anasayfa(string returnurl)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                return View(db.AylikSayim.Where(x=>x.IsActive==true).ToList());
            }
           
        }
        [HttpPost]
        public ActionResult AnasayfaPost(string barkod,int? miktar)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
            var urun=    db.AylikSayim.FirstOrDefault(x => x.Barkod.Contains(barkod));
                if (urun!=null)
                { 
                    Bay_SatisTarihi bay_SatisTarihi = new Bay_SatisTarihi
                {
                    Barkod=barkod,SatisAdeti=miktar,SatisTarihi=DateTime.Now };

                    db.Bay_SatisTarihi.Add(bay_SatisTarihi);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Anasayfa");


        }

            public ActionResult Index(string returnurl)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                var data = db.Bay_SatisTarihi;
                if (!string.IsNullOrEmpty(returnurl))
                {
                    return Redirect(returnurl);
                }
                ViewBag.toplamurun = db.AylikSayim.Count();
                ViewBag.bugunsatilan = db.BUGUN_SATILANLARIN_ADETI.Count();
                //ViewBag.Toplamz = db.ToplamZRaporu(DateTime.Now.Day).FirstOrDefault().Value;
                //ViewBag.Toplamsatılanurun = data.Count();
                return View(data.OrderByDescending(x => x.Id).Take(50).ToList());
            }

        }




        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                if (id != 0)
                {
                    var bu = db.Bay_SatisTarihi.FirstOrDefault(x => x.Id == id);
                    db.Bay_SatisTarihi.Remove(bu);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }



        public ActionResult FiyatGor()
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                return View(db.AylikSayim.ToList());
            }
        }

        public ActionResult KalanMal()
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                return View(db.AylikSayim.ToList());
            }
        }


    }
}