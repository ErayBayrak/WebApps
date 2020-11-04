using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblDuyurular.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TblDuyurular p)
        {
            db.TblDuyurular.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruDetay(TblDuyurular p)
        {
            var duyuru = db.TblDuyurular.Find(p.ID);
            return View("DuyuruDetay", duyuru);
        }

        public ActionResult DuyuruGuncelle(TblDuyurular p)
        {
            var duyuru = db.TblDuyurular.Find(p.ID);
            duyuru.KATEGORI = p.KATEGORI;
            duyuru.ICERIK = p.ICERIK;
            duyuru.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}