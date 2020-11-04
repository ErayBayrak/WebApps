using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TblUyeler.ToList();
            var degerler = db.TblUyeler.ToList().ToPagedList(sayfa, 3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TblUyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TblUyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeSil(int id)
        {
            var degerler = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TblUyeler p)
        {
            var uye = db.TblUyeler.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TblHareket.Where(x => x.UYE == id).ToList();
            var uyead = db.TblUyeler.Where(x => x.ID == id).Select(y => y.AD + " " + y.SOYAD).
                FirstOrDefault();
            ViewBag.dgr1 = uyead;
            return View(ktpgcms);
        }
    }
}