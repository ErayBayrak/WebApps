using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblPersonel.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TblPersonel p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TblPersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.TblPersonel.Find(id);
            db.TblPersonel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TblPersonel.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var deger = db.TblPersonel.Find(p.ID);
            deger.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}