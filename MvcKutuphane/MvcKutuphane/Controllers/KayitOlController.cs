using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        private DBKutuphaneEntities db = new DBKutuphaneEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(TblUyeler uye)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }

            db.TblUyeler.Add(uye);
            db.SaveChanges();
            return View();

        }
    }
}