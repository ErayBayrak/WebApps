using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;

namespace MVCProjeKampi.Controllers
{
   
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager conm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string) Session["WriterEmail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = conm.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            string mail = (string)Session["WriterEmail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            conm.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }
    }
}