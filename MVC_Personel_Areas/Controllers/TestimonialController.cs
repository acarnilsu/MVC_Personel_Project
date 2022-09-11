using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace Demo_Personal_Project.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        DbistanbulAkademiMvcEntities dbistanbulAkademiMvcEntities=new DbistanbulAkademiMvcEntities();
        public ActionResult Index()
        {
            var values=dbistanbulAkademiMvcEntities.TblTestimonial.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {
            dbistanbulAkademiMvcEntities.TblTestimonial.Add(p);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var values=dbistanbulAkademiMvcEntities.TblTestimonial.Where(x=>x.TestimonialID==id).FirstOrDefault();
            dbistanbulAkademiMvcEntities.TblTestimonial.Remove(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values=dbistanbulAkademiMvcEntities.TblTestimonial.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial p)
        {
            var values = dbistanbulAkademiMvcEntities.TblTestimonial.Find(p.TestimonialID);
            values.TestimonialID = p.TestimonialID;
            values.TestimonialName = p.TestimonialName;
            values.TestimonialImage=p.TestimonialImage;
            values.TestimonialTitle = p.TestimonialTitle;
            values.TestimonialDescription = p.TestimonialDescription;
            dbistanbulAkademiMvcEntities.TblTestimonial.AddOrUpdate(values);
            dbistanbulAkademiMvcEntities.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}