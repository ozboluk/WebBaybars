using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBaybars.Helpers;
using WebBaybars.Models;

namespace WebBaybars.Controllers
{
    public class AcountController : Controller
    {
        // GET: Acount
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home/Index");


        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                
                //Aşağıdaki if komutu gönderilen mail ve şifre doğrultusunda kullanıcı kontrolu yapar. Eğer kullanıcı var ise login olur.
                if (model.EMail=="100"&& model.Password=="100")
                {
                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}