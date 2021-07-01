using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager com=new ContactManager(new EfContactDal());
        ContactValidator cv=new ContactValidator();
        MessageManager mg=new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactValues = com.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = com.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult PartialMessagePageSidebar()
        {
            return PartialView();
        }
      
    }
}