using System.Linq;
using System.Web.Mvc;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class AramaController : Controller
    {
        // GET: Arama
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kontrol()
        {
            ViewBag.durum = 0;
            return View();
        }
        [HttpPost]
        public ActionResult Kontrol(string id)
        {    using (BarkodcuboEntities db = new BarkodcuboEntities())
                {
            var urun = db.AylikSayim .FirstOrDefault(x => x.Barkod.Contains(id.Trim()));
                if (!string.IsNullOrEmpty(id)&&urun!=null)
            {
                    ViewBag.durum = 1;
             
                    ViewBag.UrunAdi = "  "+urun.Cinsi;
                    return View();
              
            }
              ViewBag.durum = 3;
               ViewBag.UrunAdi = "Bu ürün kayıtlı Değil! Kayıt Yapın";
                ViewBag.barkod = id;
                    }
            return View();
        }
        public ActionResult Ara(string id)
        {
            int? depo = 0;


            ViewBag.Barkod = id;
            using (BarkodcuboEntities db = new BarkodcuboEntities())
            {
                var satis = db.Bay_SatisTarihi.Where(x => x.Barkod.Contains(id.Trim()));
                try
                {
                var urunbilgisi=    db.AylikSayim.Where(x => x.Barkod.Contains(id.Trim())).FirstOrDefault();
                    if (urunbilgisi!=null)
                    {
                        depo = urunbilgisi.ToplamStok;
                        ViewBag.urunadi = urunbilgisi.Cinsi;
                        ViewBag.depo = depo;
                        ViewBag.satis = (int)satis.Count();
                        ViewBag.kalan = (int)(depo - satis.Count());
                    }
                 
                    return View(satis.ToList());
                }
                catch 
                {

                  
                }
                return View(satis.ToList());
            }
        }
    }
}