using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class UrunStokSonuController : Controller
    {
        // GET: UrunStokSonu
        public ActionResult Index()
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                var urunler = db.AylikSayim;
                    return View(urunler.OrderBy(x=>x.ToplamStok).ToList());
            }
        }

        public ActionResult Edit(int id)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                var urun = db.AylikSayim.FirstOrDefault(x => x.Id == id);

                return View(urun);
            }
        }

        [HttpPost]
            public ActionResult Edit(AylikSayim aylik)
        {
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                AylikSayim sayi = new AylikSayim {Barkod=aylik.Barkod,Cinsi=aylik.Cinsi,Fiyat=aylik.Fiyat,
                    Miktar=aylik.Miktar,ToplamStok=aylik.ToplamStok };
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}