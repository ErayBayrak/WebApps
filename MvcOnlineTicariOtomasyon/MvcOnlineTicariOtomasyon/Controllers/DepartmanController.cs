using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context context=new Context();
        public ActionResult Index()
        {
            var deparmanlar=context.Departmans.Where(x=>x.Durum==true).ToList();
            return View(deparmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman=context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var dpt=context.Departmans.Find(id);
            return View(dpt);
        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dpt = context.Departmans.Find(d.DepartmanID);
            dpt.DepartmanAd = d.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var deger = context.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = context.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd)
                .FirstOrDefault();
            ViewBag.d = dpt;
            return View(deger);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var per = context.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad)
                .FirstOrDefault();
            ViewBag.dper = per;
            return View(degerler);
        }
    }
}