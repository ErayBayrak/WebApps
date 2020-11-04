using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblYazar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TblYazar yazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TblYazar.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var deger = db.TblYazar.Find(id);
            db.TblYazar.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var deger = db.TblYazar.Find(id);
            return View("YazarGetir", deger);
        }

        public ActionResult YazarGuncelle(TblYazar yazar)
        {
            var yzr = db.TblYazar.Find(yazar.ID);
            yzr.AD = yazar.AD;
            yzr.SOYAD = yazar.SOYAD;
            yzr.DETAY = yazar.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TblKitap.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.TblYazar.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).
                FirstOrDefault();
            ViewBag.dgr = yzrad;
            return View(yazar);
        }
    }
}