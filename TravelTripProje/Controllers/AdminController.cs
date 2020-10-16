using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = context.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var blog=context.Blogs.Find(id);
            return View("BlogGetir",blog);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blog = context.Blogs.Find(b.ID);
            blog.Aciklama = b.Aciklama;
            blog.Baslik = b.Baslik;
            blog.BlogImage = b.BlogImage;
            blog.Tarih = b.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = context.Yorums.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b=context.Yorums.Find(id);
            context.Yorums.Remove(b);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
           var yorum=context.Yorums.Find(id);
           return View("YorumGetir", yorum);
        }

        public ActionResult YorumGuncelle(Yorum y)
        {
            var yorum = context.Yorums.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorumlar = y.Yorumlar;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");

        }
    }
}