using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        public ActionResult Index()
        {
            using (BarkodcuboEntities db= new BarkodcuboEntities())
            {
                return View(db.Bay_SatisTarihi.ToList());
            }
           
        }
    }
}