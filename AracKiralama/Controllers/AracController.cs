using AracKiralama.Models;
using AracKiralama.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralama.Controllers
{
    public class AracController : Controller
    {
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(VMArac model)
        {
            using (KiraDBContext db = new KiraDBContext())
            {
                Arac arac = new Arac();

                #region MarkaEşleme

                var marka = db.AracMarka.FirstOrDefault(m => m.Isim == model.MarkaIsim.ToLower().Trim());

                if (marka != null)
                {
                    arac.AracMarkaID = marka.AracMarkaID;
                }
                else
                {
                    db.AracMarka.Add(new AracMarka()
                    {
                        Isim = model.MarkaIsim.Trim().ToLower()
                    });
                    db.SaveChanges();

                    var result = db.AracMarka.FirstOrDefault(m => m.Isim == model.MarkaIsim);
                    int markaID = result.AracMarkaID;
                    arac.AracMarkaID = markaID;
                }

                #endregion

                #region ModelEşleme

                var geciciModel = 
                    db.AracModel.FirstOrDefault(m => m.Isim == model.ModelIsim.ToLower().Trim());

                if (geciciModel != null)
                {
                    arac.AracModelID = geciciModel.AracModelID;
                }
                else
                {
                    db.AracModel.Add(new AracModel()
                    {
                        Isim = model.ModelIsim.Trim().ToLower(),
                        MarkaID = arac.AracMarkaID
                    });
                    db.SaveChanges();

                    var result = db.AracModel.FirstOrDefault(m => m.Isim == model.ModelIsim);
                    int modelID = result.AracModelID;
                    arac.AracModelID = modelID;
                }
                #endregion

                arac.PlakaNo = model.PlakaNo;
                arac.Tip = model.Tip;
                arac.Yas = model.Yas;
                arac.GunlukUcret = model.GunlukUcret;

                db.Arac.Add(arac);
                db.SaveChanges();
            }
            return RedirectToAction("TumAraclar");
        }

        public ActionResult TumAraclar()
        {
            using (KiraDBContext db = new KiraDBContext())
            {
                var result = db.Arac.Where(r=> r.Silindimi == false).Select(a => new VMArac
                {
                    AracID = a.AracID,
                    PlakaNo = a.PlakaNo,
                    MarkaIsim = a.AracMarka.Isim,
                    ModelIsim = a.AracModel.Isim,
                    GunlukUcret = a.GunlukUcret,
                    Kiralandimi = a.Kiralandimi,
                    Tip = a.Tip,
                    Yas = a.Yas
                }).ToList();
                return View(result);
            }
        }

        [HttpPost]
        public ActionResult TumAraclar(VMKira model)
        {
            using (KiraDBContext db = new KiraDBContext())
            {
                var arac = db.Arac.FirstOrDefault(a => a.AracID == model.AracID);
                arac.Kiralandimi = true;
                db.SaveChanges();

                Kira kira = new Kira();
                kira.AlinanUcret = model.AlinanUcret;
                kira.AlisTarihi = model.AlisTarihi;
                kira.AracID = model.AracID;
                kira.KiralamaSuresi = model.KiralamaSuresi;

                var musteri = 
                    db.Musteri.
                    FirstOrDefault
                    (m => m.Isim == model.Isim.Trim().ToLower() 
                    && m.Soyisim == model.Soyisim.Trim().ToLower());

                if (musteri == null)
                {
                    db.Musteri.Add(new Musteri()
                    {
                        Isim = model.Isim.Trim().ToLower(),
                        Soyisim = model.Soyisim.Trim().ToLower(),
                        Telefon = model.Telefon.Trim()
                    });
                    db.SaveChanges();

                    var result = db.Musteri.
                    FirstOrDefault
                    (m => m.Isim == model.Isim.Trim().ToLower()
                    && m.Soyisim == model.Soyisim.Trim().ToLower());

                    kira.MusteriID = result.MusteriID;
                }
                else
                {
                    kira.MusteriID = musteri.MusteriID;
                }

                kira.ToplamUcret = model.ToplamUcret;

                db.Kira.Add(kira);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Panel");
        }
        public ActionResult AracSil(int id)
        {
            using (KiraDBContext db = new KiraDBContext())
            {
                var result = db.Arac.FirstOrDefault(a => a.AracID == id);
                result.Silindimi = true;
                db.SaveChanges();
            }
            return RedirectToAction("TumAraclar");
        }
    }
}