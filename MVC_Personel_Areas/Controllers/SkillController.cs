using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;


namespace Demo_Personal_Project.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        DbistanbulAkademiMvcEntities dbistanbulAkademiMvcEntities=new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            var values = dbistanbulAkademiMvcEntities.TblSkill.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill p)
        {
            dbistanbulAkademiMvcEntities.TblSkill.Add(p);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value=dbistanbulAkademiMvcEntities.TblSkill.Where(x=>x.SkillID==id).FirstOrDefault();
            dbistanbulAkademiMvcEntities.TblSkill.Remove(value);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var value = dbistanbulAkademiMvcEntities.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            return View(value);
        }
    }
}