using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context context=new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in context.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KateogoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        { 
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index","Urun");
        }

        public ActionResult UrunSil(int id)
        {
            var urun=context.Uruns.Find(id);
            urun.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Kategoris.ToList()
                select new SelectListItem
                {
                    Text = x.KateogoriAd,
                    Value = x.KategoriID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            var urun = context.Uruns.Find(id);
            return View(urun);
        }

        public ActionResult UrunGuncelle(Urun id)
        {
            var urun = context.Uruns.Find(id.UrunID);
            urun.UrunAd = id.UrunAd;
            urun.Marka = id.Marka;
            urun.Stok = id.Stok;
            urun.AlisFiyat = id.AlisFiyat;
            urun.SatisFiyat = id.SatisFiyat;
            urun.Durum = id.Durum;
            urun.UrunGorsel = id.UrunGorsel;
            urun.Kategoriid = id.Kategoriid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in context.Personels.ToList()
                select new SelectListItem
                {
                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                    Value = x.PersonelID.ToString()
                }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = context.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index","Satis");
            
        }
    }
}