using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitap = from k in db.TblKitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m => m.AD.Contains(p));
            }
            //var kitap = db.TblKitap.ToList();
            return View(kitap.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from x in db.TblKategori.ToList()
                select new SelectListItem
                {
                    Text = x.AD,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.TblYazar.ToList()
                select new SelectListItem
                {
                    Text = x.AD+' '+x.SOYAD,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TblKitap kitap)
        {
            var ktg = db.TblKategori.Where(k => k.ID == kitap.TblKategori.ID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.ID == kitap.TblYazar.ID).FirstOrDefault();
            kitap.TblKategori = ktg;
            kitap.TblYazar = yzr;
            db.TblKitap.Add(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TblKitap.Find(id);
            db.TblKitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var degerler = db.TblKitap.Find(id);
            List<SelectListItem> deger1 = (from x in db.TblKategori.ToList()
                select new SelectListItem
                {
                    Text = x.AD,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.TblYazar.ToList()
                select new SelectListItem
                {
                    Text = x.AD + ' ' + x.SOYAD,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir",degerler);
        }

        public ActionResult KitapGuncelle(TblKitap p)
        {
            var kitap = db.TblKitap.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            kitap.DURUM = true;
            var ktg = db.TblKategori.Where(k => k.ID == p.TblKategori.ID).FirstOrDefault();
            var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}