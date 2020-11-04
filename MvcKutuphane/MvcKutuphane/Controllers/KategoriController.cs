using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblKategori.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TblKategori kategori)
        {
            db.TblKategori.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var deger=db.TblKategori.Find(id);
            //db.TblKategori.Remove(deger);
            deger.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var deger = db.TblKategori.Find(id);
            return View("KategoriGetir",deger);
        }

        public ActionResult KategoriGuncelle(TblKategori kategori)
        {
            var deger = db.TblKategori.Find(kategori.ID);
            deger.AD = kategori.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}