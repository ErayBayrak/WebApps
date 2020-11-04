using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context=new Context();
        public ActionResult Index()
        {
            var liste = context.Faturas.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        { 
            context.Faturas.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var deger = context.Faturas.Find(id);
            return View(deger);
        }

        public ActionResult FaturaGuncelle(Fatura id)
        {
            var deger = context.Faturas.Find(id.FaturaID);
            deger.FaturaSeriNo = id.FaturaSeriNo;
            deger.FaturaSiraNo = id.FaturaSiraNo;
            deger.VergiDairesi = id.VergiDairesi;
            deger.Tarih = id.Tarih;
            deger.Saat = id.Saat;
            deger.TeslimEden = id.TeslimEden;
            deger.TeslimAlan = id.TeslimAlan;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var deger = context.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            context.FaturaKalems.Add(f);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}