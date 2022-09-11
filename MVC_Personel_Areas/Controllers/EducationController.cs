using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace Demo_Personal_Project.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        DbistanbulAkademiMvcEntities dbistanbulAkademi = new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            var values=dbistanbulAkademi.TblEducation.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            dbistanbulAkademi.TblEducation.Add(p);
            dbistanbulAkademi.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var values = dbistanbulAkademi.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();
            dbistanbulAkademi.TblEducation.Remove(values);
            dbistanbulAkademi.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values = dbistanbulAkademi.TblEducation.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation tblEducation)
        {
            var values = dbistanbulAkademi.TblEducation.Find(tblEducation.EducationID);
            values.EducationID = tblEducation.EducationID;
            values.EducationTitle = tblEducation.EducationTitle;
            values.EducationDescription = tblEducation.EducationDescription;
            values.EducationDate = tblEducation.EducationDate;
            dbistanbulAkademi.TblEducation.AddOrUpdate(values);
            dbistanbulAkademi.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}