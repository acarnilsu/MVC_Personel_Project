using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace Demo_Personal_Project.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        DbistanbulAkademiMvcEntities dbistanbulAkademiMvcEntities=new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            var value=dbistanbulAkademiMvcEntities.TblFeature.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature p)
        {
            dbistanbulAkademiMvcEntities.TblFeature.Add(p);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var values = dbistanbulAkademiMvcEntities.TblFeature.Where(x => x.FeatureID == id).FirstOrDefault();
            dbistanbulAkademiMvcEntities.TblFeature.Remove(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var values = dbistanbulAkademiMvcEntities.TblFeature.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateFeature(TblFeature p) 
        {
            var values = dbistanbulAkademiMvcEntities.TblFeature.Find(p.FeatureID);
            values.FeatureID = p.FeatureID;
            values.FeatureTitle = p.FeatureTitle;
            values.FeatureLogo = p.FeatureLogo;
            values.FeatureDescription = p.FeatureDescription;
            
            dbistanbulAkademiMvcEntities.TblFeature.AddOrUpdate(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}