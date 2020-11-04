using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var deger0 = db.TblCezalar.Sum(x => x.PARA);
            var deger1 = db.TblUyeler.Count();
            var deger2 = db.TblKitap.Count();
            var deger3 = db.TblKitap.Where(x => x.DURUM == false).Count();
            ViewBag.dgr0 = deger0;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.TblKitap.Count();
            var deger2 = db.TblUyeler.Count();
            var deger3 = db.TblCezalar.Sum(x => x.PARA);
            var deger4 = db.TblKitap.Where(x => x.DURUM == false).Count();
            var deger5 = db.TblKategori.Count();

            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TblKitap.GroupBy(x => x.YAYINEVI).
                OrderByDescending(y => y.Count()).Select(z => new
                {
                    z.Key
                }).FirstOrDefault();

            var deger11 = db.Tbliletisim.Count();

            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;

            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;

            ViewBag.d11 = deger11;
            return View();
        }
    }
}