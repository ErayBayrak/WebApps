using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context=new Context();
        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                select new SelectListItem
                {
                    Text = x.UrunAd,
                    Value = x.UrunID.ToString()
                }).ToList();
            List<SelectListItem> deger2 = (from x in context.Caris.ToList()
                select new SelectListItem
                {
                    Text = x.CariAd+" "+x.CariSoyad,
                    Value = x.CariID.ToString()
                }).ToList();
            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem
                {
                    Text = x.PersonelAd+" "+x.PersonelSoyad,
                    Value = x.PersonelID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih=DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(s);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Uruns.ToList()
                select new SelectListItem
                {
                    Text = x.UrunAd,
                    Value = x.UrunID.ToString()
                }).ToList();
            List<SelectListItem> deger2 = (from x in context.Caris.ToList()
                select new SelectListItem
                {
                    Text = x.CariAd + " " + x.CariSoyad,
                    Value = x.CariID.ToString()
                }).ToList();
            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem
                {
                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                    Value = x.PersonelID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = context.SatisHarekets.Find(id);
            return View(deger);
        }

        public ActionResult SatisGuncelle(SatisHareket id)
        {
            var deger = context.SatisHarekets.Find(id.SatisID);
            deger.Urunid = id.Urunid;
            deger.Cariid = id.Cariid;
            deger.Personelid = id.Personelid;
            deger.Adet = id.Adet;
            deger.Fiyat = id.Fiyat;
            deger.ToplamTutar = id.ToplamTutar;
            deger.Tarih = id.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var deger = context.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
    }
}