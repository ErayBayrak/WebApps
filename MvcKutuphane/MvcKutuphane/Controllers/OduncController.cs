using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncController : Controller
    {
        // GET: Odunc
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareket.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            List<SelectListItem> deger1 = (from x in db.TblUyeler.ToList()
                    select new SelectListItem
                    {
                        Text = x.AD +" "+ x.SOYAD,
                        Value = x.ID.ToString()
                    }
                ).ToList();
            List<SelectListItem> deger2 = (from x in db.TblKitap.Where(y=>y.DURUM==true).ToList()
                select new SelectListItem
                {
                    Text = x.AD,
                    Value = x.ID.ToString()
                }).ToList();
            List<SelectListItem> deger3 = (from x in db.TblPersonel.ToList()
                select new SelectListItem
                {
                    Text = x.PERSONEL,
                    Value = x.ID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TblHareket p)
        {
            var d1 = db.TblUyeler.Where(x => x.ID == p.TblUyeler.ID).FirstOrDefault();
            var d2 = db.TblKitap.Where(y => y.ID == p.TblKitap.ID).FirstOrDefault();
            var d3 = db.TblPersonel.Where(z => z.ID == p.TblPersonel.ID).FirstOrDefault();
            p.TblUyeler = d1;
            p.TblKitap = d2;
            p.TblPersonel = d3;

            db.TblHareket.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Odunciade(TblHareket p)
        {
            var odn = db.TblHareket.Find(p.ID);
            DateTime d1=DateTime.Parse(odn.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Odunciade",odn);
        }
        public ActionResult OduncGuncelle(TblHareket p)
        {
            var hrk = db.TblHareket.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}