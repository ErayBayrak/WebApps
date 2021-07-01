using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c = new Context();
        WriterValidator writerValidator = new WriterValidator();
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterEmail"];
            id = c.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading","WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterEmail"];
            var writeridinfo = c.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();

            var writer = hm.GetListByWriter(writeridinfo);
            return View(writer);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                ).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterEmail"];
            var writeridinfo = c.Writers.Where(x => x.WriterEmail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);

            if (HeadingValue.HeadingStatus)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }

            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p = 1)
        {
            var values = hm.GetList().ToPagedList(p, 4);
            return View(values);
        }
    }
}