using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKutuphaneEntities db=new DBKutuphaneEntities();
        Class1 cs=new Class1();

        
        public ActionResult Index()
        {
            cs.Deger1 = db.TblKitap.ToList();
            cs.Deger2 = db.TblHakkımızda.ToList();
            //var degerler = db.TblKitap.ToList();
            return View(cs);
        }

        
        public ActionResult MesajGonder(Tbliletisim t)
        {
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}