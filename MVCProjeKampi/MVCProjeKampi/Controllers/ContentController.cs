using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager conm=new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = conm.GetListByHeadingID(id);
            return View(contentValues);
        }
    }
}