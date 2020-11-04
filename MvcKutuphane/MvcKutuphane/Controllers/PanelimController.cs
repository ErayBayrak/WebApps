using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        private DBKutuphaneEntities db = new DBKutuphaneEntities();
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string) Session["Mail"];
            var degerler = db.TblUyeler.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string) Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.OKUL = p.OKUL;
            uye.KULLANICIADI = p.KULLANICIADI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TblUyeler.Where(x => x.MAIL == kullanici).Select(z=>z.ID).FirstOrDefault();
            var degerler = db.TblHareket.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyuruListesi = db.TblDuyurular.ToList();
            return View(duyuruListesi);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
    }
}