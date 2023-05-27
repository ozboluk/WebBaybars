using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBaybars.Helpers;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        BarkodcuboEntities db = new BarkodcuboEntities();
        // GET: Urunler
      
        public ActionResult Populer()
        {
            ViewBag.EnCokSatilanlar = db.ProcEncokSatilanUrunler().OrderByDescending(x=>x.SatisAdeti).ToList();
            return View();
        }
        public ActionResult Index()
        {
            return View(db.AylikSayim.ToList());
        }
    
        public ActionResult Edit(string id)
        {
            var sayim = db.AylikSayim.FirstOrDefault(x => x.Barkod == id);
            return View(sayim);
        }
        [HttpPost]
        public ActionResult Edit(AylikSayim aylikSayim)
        {
            aylikSayim.Miktar = 1;
            if (aylikSayim == null)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { Status = "success", Message = "Succesfully updated" });
                }
            }
           var mi=   db.AylikSayim.FirstOrDefault(x => x.Barkod == aylikSayim.Barkod);
            if (mi!=null)
            {
                mi.Miktar = 1;
                mi.Fiyat = aylikSayim.Fiyat;
                mi.Cinsi = aylikSayim.Cinsi;
                mi.ToplamStok = aylikSayim.ToplamStok;
                db.SaveChanges();

            }

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create(string id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(AylikSayim _aylikSayim)
        {
            try
            {
                AylikSayim aylikSayim = new AylikSayim
                {
                    Barkod = _aylikSayim.Barkod,
                    Cinsi = _aylikSayim.Cinsi,
                    Miktar = 1
                    ,ToplamStok=_aylikSayim.ToplamStok
                    

                };
                db.AylikSayim.Add(_aylikSayim);
                db.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Detail(string id)
        {
            var data = db.AylikSayim.FirstOrDefault(x => x.Barkod.Contains(id));
         var toplamsatis=   db.Bay_SatisTarihi.Where(x => x.Barkod.Contains(id)).Count();
            ViewBag.ToplamSatıs = toplamsatis;
            ViewBag.kalan = data.ToplamStok - toplamsatis;
           
            return View(data);
        }
        public ActionResult Delete(string id)
        {
            try
            {
                var sayim = db.AylikSayim.FirstOrDefault(x => x.Barkod == id);
                db.AylikSayim.Remove(sayim);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}