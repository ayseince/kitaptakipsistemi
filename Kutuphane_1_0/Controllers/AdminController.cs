using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane_1_0.Models;

namespace Kutuphane_1_0.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        kütüphaneEntities3 db = new kütüphaneEntities3();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult sssss()
        {
            return View();
        }
        public ActionResult KitapListesi()
        {
            return View();
        }
        public ActionResult KitapListesiLoad()
        {
            var result = db.Kitaplar.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Kitapsil(int kid)
        {
            var a = db.Kitaplar.Where(w => w.KitapID == kid).FirstOrDefault();
            db.Kitaplar.Remove(a);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
     
        public ActionResult Kitapekle(Kitaplar z)
        {
            db.Kitaplar.Add(z);
            db.SaveChanges();
            return View();
        }
        public ActionResult Uye_Listesi()
        {
            return View();
        }
        public ActionResult UyeListesiLoad()
        {
            var result = db.Uyeler.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UyeListesii(Uyeler z)
        {
            string ad = z.Ad;
            string soyad = z.Soyad;
            string cins = z.Cinsiyet;
            string tel = z.Tel;
            if (ad!=null &&soyad!=null && cins!=null && tel!=null )
            {
                db.Uyeler.Add(z);
                db.SaveChanges();
            }
           
            return View();
        }
        public ActionResult Uyesil(int Uid)
        {
            var a = db.Uyeler.Where(w => w.UyeID == Uid).FirstOrDefault();
            db.Uyeler.Remove(a);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AdresListesii(Adresler adress)
        {
            db.Adresler.Add(adress);
            db.SaveChanges();
            return View();
        }
        public ActionResult AdresListesi()
        {
            return View();
        }  
        public ActionResult AdresListesiLoad()
        {
           var result = (from k in db.Kütüphane
                         join a in db.Adresler on k.AdresID equals a.AdresID
                          select new { k.KütüphaneAd, a.BinaNo, a.Cadde, a.Mahalle, a.Sokak, a.İl, a.İlçe, a.Kat,a.PostaKodu,a.AdresID}).ToList();
                         return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Adressil(int Aid)
        {
            var a = db.Adresler.Where(w => w.AdresID == Aid).FirstOrDefault();
            db.Adresler.Remove(a);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EmanetListesi()
        {
            return View();
        }
        public ActionResult EmanetListesiLoad()
        {
            var date = DateTime.Now;
            var result = (from e in db.Emanet
                          join ü in db.Uyeler on e.ÜyeID equals ü.UyeID
                          join k in db.Kitaplar on e.KitapID equals k.KitapID
                          join kth in db.Kütüphane on e.KütüphaneID equals kth.KütüphaneID
                          select new {
                              k.KitapAd,ü.Ad,ü.Soyad,ü.UyeID,kth.KütüphaneAd,e.EmanetT,e.TeslimT

                          }).ToList().Select(s=>new {
                              s.KitapAd,s.Ad,s.EmanetT,s.UyeID,s.KütüphaneAd,s.TeslimT,s.Soyad,asd = date.Subtract(s.TeslimT.Value).TotalDays<0?"Geçmedi":"Geçti"
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Emanetekle(Emanet z)
        {
            db.Emanet.Add(z);
            db.SaveChanges();
            return View();
        }
        public ActionResult Emanetsil(int Eid)
        {
            var a = db.Emanet.Where(w => w.Id == Eid).FirstOrDefault();
            db.Emanet.Remove(a);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
       
    }
}