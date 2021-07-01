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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        Context c = new Context();

        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                ).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName+" "+x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }
                ).ToList();
            ViewBag.vlw = valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }
                ).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue); 
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);

            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }

            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}