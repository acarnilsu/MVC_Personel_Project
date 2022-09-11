using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Personel_Areas.Models;

namespace MVC_Personel_Areas.Areas.Member.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Member/Profile

        DbistanbulAkademiMvcEntities db=new DbistanbulAkademiMvcEntities();

        public ActionResult Index()
        {
            var mail = Session["MemberMail"];
            ViewBag.data1=db.TblMember.Where(x=>x.MemberMail==mail.ToString()).Select(y=>y.MemberName+" "+y.MemberSurname).FirstOrDefault();

            return View();
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            var mail = Session["MemberMail"];
            var values=db.TblMember.Where(x=>x.MemberMail==mail.ToString()).FirstOrDefault();
            return View(values);
        }

        [HttpPost]
        public ActionResult EditProfile(TblMember p)
        {
            var mail = Session["MemberMail"];
            var values = db.TblMember.Where(x => x.MemberMail == mail.ToString()).FirstOrDefault();
            values.MemberName= p.MemberName;
            values.MemberSurname= p.MemberSurname;
            values.MemberPassword= p.MemberPassword;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}