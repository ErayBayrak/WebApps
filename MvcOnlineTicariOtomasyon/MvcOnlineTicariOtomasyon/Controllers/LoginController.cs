using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cari cari)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd,false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd;
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}