using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBaybars.Helpers;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    [Authorize]
    public class DepoController : Controller
    {
        BarkodcuboEntities db = new BarkodcuboEntities();
       
        public ActionResult Index1(string returnurl)
        {
            if (!string.IsNullOrEmpty(returnurl))
            {
                return Redirect(returnurl);
            }
            return View(db.Malinyeri.OrderByDescending(x => x.@int).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Malinyeri malinyeri)
        {
            Malinyeri malinyeri1 = new Malinyeri
            {
                barcod = malinyeri.barcod,
                miktar = malinyeri.miktar,

                yeri = malinyeri.yeri
            };
            db.Malinyeri.Add(malinyeri1);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
        public ActionResult Delete(string id)
        {
            var bunu = db.Malinyeri.FirstOrDefault(x => x.barcod == id);
            db.Malinyeri.Remove(bunu);
            db.SaveChanges();
            return RedirectToAction("Index1");
        }
    }
}