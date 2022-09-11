using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Personel_Areas.Models;

namespace MVC_Personel_Areas.Areas.Member.Controllers
{
    public class LoginController : Controller
    {
        // GET: Member/Login

        DbistanbulAkademiMvcEntities db = new DbistanbulAkademiMvcEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblMember p)
        {
            var values = db.TblMember.FirstOrDefault(x => x.MemberMail == p.MemberMail && x.MemberPassword == p.MemberPassword);
            var selectUser = db.TblMember.FirstOrDefault(x => x.MemberMail == p.MemberMail);
            if (values != null && values.LockoutEnabled==true)
            {
                FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                Session["MemberMail"]=values.MemberMail;
                return RedirectToAction("Index", "Profile");
            }
            else if (values != null && values.LockoutEnabled==false)
            {
                var banTimeMinute = (Convert.ToDateTime(p.LockoutEnd).Subtract(DateTime.Now)).Minutes;
                var banTimeHour = (Convert.ToDateTime(p.LockoutEnd).Subtract(DateTime.Now)).Hours;
                var banTimeDay = (Convert.ToDateTime(p.LockoutEnd).Subtract(DateTime.Now)).Days;
                if (banTimeMinute<=0 && banTimeHour<=0 && banTimeDay<=0)
                {
                    values.LockoutEnabled = true;
                    values.LockoutEnd = null;
                    values.AccessFailedCount = 0;
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(values.MemberMail, false);
                    Session["MemberMail"] = values.MemberMail;
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    return RedirectToAction("Index/" + values.MemberID, "Ban");
                }
            }
            else
            {
                
                if (selectUser?.AccessFailedCount < 3)
                {
                    selectUser.AccessFailedCount += 1;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    selectUser.LockoutEnabled = false;
                    DateTime date = DateTime.Now;
                    TimeSpan banTime = new TimeSpan(3, 0, 0, 0);
                    var banTimeEnd = date.Add(banTime);
                    selectUser.LockoutEnd = banTimeEnd;
                    db.SaveChanges();
                    return RedirectToAction("Index/" + selectUser.MemberID, "Ban");
                }
            }
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Index");
        }
    }
}