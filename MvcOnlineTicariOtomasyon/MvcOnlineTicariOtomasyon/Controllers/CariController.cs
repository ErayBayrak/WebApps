using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context=new Context();
        public ActionResult Index()
        {
            var degerler=context.Caris.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            cari.Durum = true;
            context.Caris.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Caris.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var degerler = context.Caris.Find(id);
            return View(degerler);
        }

        public ActionResult CariGuncelle(Cari c)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = context.Caris.Find(c.CariID);
            cari.CariAd = c.CariAd;
            cari.CariSoyad = c.CariSoyad;
            cari.CariSehir = c.CariSehir;
            cari.CariMail = c.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = context.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad)
                .FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}