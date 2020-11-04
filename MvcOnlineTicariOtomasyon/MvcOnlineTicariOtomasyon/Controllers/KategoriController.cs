using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori      
        Context context = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var degerler = context.Kategoris.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            context.Kategoris.Add(k);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var degerler = context.Kategoris.Find(id);
            context.Kategoris.Remove(degerler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var degerler = context.Kategoris.Find(id);
            return View("KategoriGetir", degerler);
        }

        public ActionResult KategoriGuncelle(Kategori ktg)
        {
            var degerler = context.Kategoris.Find(ktg.KategoriID);
            degerler.KateogoriAd = ktg.KateogoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}