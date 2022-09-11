using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace Demo_Personal_Project.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        DbistanbulAkademiMvcEntities dbistanbulAkademiMvcEntities = new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            var values = dbistanbulAkademiMvcEntities.TblExperience.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            dbistanbulAkademiMvcEntities.TblExperience.Add(p);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var values = dbistanbulAkademiMvcEntities.TblExperience.Where(y=>y.ExperienceID==id).FirstOrDefault();
            dbistanbulAkademiMvcEntities.TblExperience.Remove(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var values = dbistanbulAkademiMvcEntities.TblExperience.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience tblExperience)
        {
            var values = dbistanbulAkademiMvcEntities.TblExperience.Find(tblExperience.ExperienceID);
            values.ExperienceID = tblExperience.ExperienceID;
            values.ExperienceTitle = tblExperience.ExperienceTitle;
            values.ExperienceDescription = tblExperience.ExperienceDescription;
            values.ExperienceDate=tblExperience.ExperienceDate;
            dbistanbulAkademiMvcEntities.TblExperience.AddOrUpdate(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}