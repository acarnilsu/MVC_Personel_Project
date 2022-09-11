using MVC_Personel_Areas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Personel_Areas.Areas.Member.Controllers
{
    public class BanController : Controller
    {
        // GET: Member/Ban

        DbistanbulAkademiMvcEntities db = new DbistanbulAkademiMvcEntities();
        public ActionResult Index(int id)
        {
            var member = db.TblMember.Find(id);
            var banTimeHour = (Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now)).Hours;
            var banTimeDay = (Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now)).Days;
            var banTimeMinute = (Convert.ToDateTime(member.LockoutEnd).Subtract(DateTime.Now)).Minutes;
            ViewBag.banTimeMinute = banTimeMinute;
            ViewBag.banTimeHour = banTimeHour;
            ViewBag.banTimeDay = banTimeDay;
            return View();
        }
    }
}