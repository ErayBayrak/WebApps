using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string) Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.ALICI == uyemail).ToList();
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TblMesajlar.Where(x => x.GONDEREN == uyemail).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar p)
        {
            var uyemail = (string)Session["Mail"].ToString();
            p.GONDEREN = uyemail;
            p.TARIH=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblMesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
    }
}