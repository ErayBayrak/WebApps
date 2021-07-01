using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mg=new MessageManager(new EfMessageDal());
        MessageValidator messageValidator=new MessageValidator();
        public ActionResult Inbox(string p)
        {
            var messageValues = mg.GetListInbox(p);
            return View(messageValues);
        }
        public ActionResult SendBox(string p)
        {
            var messageValues = mg.GetListSendbox(p);
            return View(messageValues);
        }

        //public ActionResult SendBox(string p)
        //{
        //    Console.WriteLine(p);
        //    var messageValues = mg.GetListSendboxOrderByDesc(p);
        //    return View(messageValues);
        //}

        public ActionResult GetInboxMessageDetails(int id)
        {
            var contactValues = mg.GetById(id);
            return View(contactValues);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var contactValues = mg.GetById(id);
            return View(contactValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message,string button)
        {
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                //message.IsDraft = true;
                mg.MessageAdd(message);
                return RedirectToAction("SendBox");
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

        

    }
}