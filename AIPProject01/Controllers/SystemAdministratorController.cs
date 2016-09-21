using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.Data;
using System.Data.Entity;
using PagedList;

namespace AIPProject01.Controllers
{
    public class SystemAdministratorController : Controller
    {
        //
        // GET: /SystemAdministrator/
        private AIPEntities20 db = new AIPEntities20();

        public ActionResult HealthLink()
        {

            String strLoginID = User.Identity.Name;
            List<G3_SystemAdministrator_HealthLink> list = new List<G3_SystemAdministrator_HealthLink>();


            if (strLoginID == "wc985247@yahoo.com.tw")
            {
                list = db.G3_SystemAdministrator_HealthLink.ToList();

                ViewBag.Message = "系統管理";
                return View(list);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            ViewBag.Message = "新增連結";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(G3_SystemAdministrator_HealthLink table)
        {
            if (ModelState.IsValid)
            {
                table.UserId = User.Identity.Name;
                table.Date = DateTime.Now;
                db.G3_SystemAdministrator_HealthLink.Add(table);
                db.SaveChanges();
                return RedirectToAction("HealthLink", "SystemAdministrator");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id = 0)
        {
            G3_SystemAdministrator_HealthLink table = db.G3_SystemAdministrator_HealthLink.Find(id);
            if (table == null || table.UserId != User.Identity.Name)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "編輯連結";
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(G3_SystemAdministrator_HealthLink table)
        {
            if (ModelState.IsValid)
            {
                table.UserId = User.Identity.Name;
                table.Date = DateTime.Now;
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HealthLink", "SystemAdministrator");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id = 0)
        {
            G3_SystemAdministrator_HealthLink table = db.G3_SystemAdministrator_HealthLink.Find(id);
            if (table == null || table.UserId != User.Identity.Name)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "刪除文章";
            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            G3_SystemAdministrator_HealthLink table = db.G3_SystemAdministrator_HealthLink.Find(id);
            db.G3_SystemAdministrator_HealthLink.Remove(table);
            db.SaveChanges();
            return RedirectToAction("HealthLink", "SystemAdministrator");
        }
    }
}
