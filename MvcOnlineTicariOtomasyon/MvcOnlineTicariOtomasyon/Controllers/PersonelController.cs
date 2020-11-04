using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context context=new Context();
        public ActionResult Index()
        {
            var degerler=context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanID.ToString()
                }).ToList();
            ViewBag.dpt = deger;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel P)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                P.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            context.Personels.Add(P);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger = (from x in context.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.DepartmanID.ToString()
                }).ToList();
            ViewBag.prs = deger;
            var prs = context.Personels.Find(id);
            return View(prs);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var prsn = context.Personels.Find(p.PersonelID);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var degerler = context.Personels.ToList();
            return View(degerler);
        }
    }
}