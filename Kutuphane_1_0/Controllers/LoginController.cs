using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane_1_0.Models;

namespace Kutuphane_1_0.Controllers
{
    public class LoginController : Controller
    {
     kütüphaneEntities3 db = new kütüphaneEntities3(); //Veritabanına erişim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginKontrol(String KullanıcıAdı, String Sifre)
        {
          
            List<Admin> x = db.Admin.Where(q => q.KullanıcıAd == KullanıcıAdı && q.Şifre == Sifre).ToList();
            if (x.Count>0)
            {
                  Session["Kullaniciadi"] = KullanıcıAdı;
                  Session["sifre"] = Sifre;
                return RedirectToAction("Index", "Admin");
            }
            else
            { 
                return RedirectToAction("Index", "Login");
            }

        }
        public ActionResult Logout()
        {
            Session["Kullaniciadi"] = "";
            Session["sifre"] = "";
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult SifremiUnuttum(String email)
        {
            List<Admin> x = db.Admin.Where(q => q.Eposta == email ).ToList();
            Session["Kadi"] = x[0].KullanıcıAd;
            Session["ksifree"] = x[0].Şifre;
            return RedirectToAction("Index", "Login");

        }
    }


    

}