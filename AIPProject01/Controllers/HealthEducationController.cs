using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AIPProject01.Models.ViewModel;
using PagedList.Mvc;
using PagedList;


namespace AIPProject01.Controllers
{
    [Authorize]
    public class HealthEducationController : Controller
    {
        private AIPEntities17 db = new AIPEntities17();

        public ActionResult Index(string search, int? page)
        {
            ViewBag.Message = "衛教分享";
            return View(db.G3_HealthEducation.Where(x => x.Title.IndexOf(search) >= 0 || search == null).ToList().ToPagedList(page ?? 1, 5));
        }

        public ActionResult Details(int id = 0)
        {
            G3_HealthEducation table = db.G3_HealthEducation.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            else if (table.userId != User.Identity.Name)
            {
                return RedirectToAction("Details_other", new { id = table.Id });
            }
            return View(table);
        }

        public ActionResult Details_other(int id = 0)
        {
            G3_HealthEducation table = db.G3_HealthEducation.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            return View(table);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "新增文章";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(G3_HealthEducation table)
        {
            if (ModelState.IsValid)
            {
                table.userId = User.Identity.Name;
                table.Date = DateTime.Now;
                db.G3_HealthEducation.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table);
        }

        public ActionResult Edit(int id = 0)
        {
            G3_HealthEducation table = db.G3_HealthEducation.Find(id);
            if (table == null || table.userId != User.Identity.Name)
            {
                return HttpNotFound();
            }
            ViewBag.Message = "編輯文章";
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(G3_HealthEducation table)
        {
            if (ModelState.IsValid)
            {
                table.userId = User.Identity.Name;
                table.Date = DateTime.Now;
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table);
        }

        public ActionResult Delete(int id = 0)
        {
            G3_HealthEducation table = db.G3_HealthEducation.Find(id);
            if (table == null || table.userId != User.Identity.Name)
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
            G3_HealthEducation table = db.G3_HealthEducation.Find(id);
            db.G3_HealthEducation.Remove(table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult HealthLink()
        {

            String strLoginID = User.Identity.Name;
            List<G3_SystemAdministrator_HealthLink> list = new List<G3_SystemAdministrator_HealthLink>();

            using (AIPEntities20 db = new AIPEntities20())
            {
                list = db.G3_SystemAdministrator_HealthLink.ToList();
            }

            ViewBag.Message = "衛教專區";
            return View(list);
        }
    }
}