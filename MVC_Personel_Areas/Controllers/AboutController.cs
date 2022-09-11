using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace Demo_Personal_Project.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DbistanbulAkademiMvcEntities db=new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult StatisticsPartial()
        {
            ViewBag.v1 = db.TblSkill.Count();
            ViewBag.v2 = db.TblImage.Where(x=>x.Category=="C#").Count();
            int id = db.TblExperience.Max(x=>x.ExperienceID);
            ViewBag.v3 = db.TblExperience.Where(x => x.ExperienceID == id).Select(y => y.ExperienceDate).FirstOrDefault();
            ViewBag.v4 = db.TblExperience.Where(x => x.ExperienceTitle == "Eğitmen").Count();
            return PartialView();
        }
    }
}