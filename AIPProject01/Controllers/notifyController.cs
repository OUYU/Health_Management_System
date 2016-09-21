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
    public class notifyController : Controller
    {
        public ActionResult Index()
        {
            List<G3_Monitor_Notice> list = new List<G3_Monitor_Notice>();
            String strLoginID = User.Identity.Name;
            using (Monitor_Notice db = new Monitor_Notice())
            {
                var reuslt = db.G3_Monitor_Notice.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.User)
                    {
                        G3_Monitor_Notice Data = new G3_Monitor_Notice();
                        Data.Id = item.Id;
                        Data.User = item.User;
                        Data.MeasurementDate = item.MeasurementDate;
                        Data.Object = item.Object;
                        Data.status = item.status;

                        list.Add(Data);
                    }
                }
            }
            ViewBag.Message = "需求";
            return View(list);
        }

        public ActionResult SystemNotify()
        {
            SystemNotify A = new SystemNotify();
            List<G3_Monitor_Notice> list = new List<G3_Monitor_Notice>();
            using (Monitor_Notice db = new Monitor_Notice())
            {
                var reuslt = db.G3_Monitor_Notice.ToList();
                foreach (var item in reuslt)
                {
                    if (item.status == 1)
                    {
                        G3_Monitor_Notice Data = new G3_Monitor_Notice();
                        Data.Id = item.Id;
                        Data.User = item.User;
                        Data.MeasurementDate = item.MeasurementDate;
                        Data.Object = item.Object;
                        Data.status = item.status;

                        list.Add(Data);
                    }
                }
            }
            A.NotifyList = list;
            ViewBag.Message = "需求管理";
            return View(A);
        }
        public ActionResult Edit(int id = 0)
        {
            G3_Monitor_Notice table;
            using (Monitor_Notice db = new Monitor_Notice())
            {
                table = db.G3_Monitor_Notice.Find(id);
                if (table == null || table.Id != id)
                {
                    return HttpNotFound();
                }
            }
            ViewBag.Message = "狀況處理";
            return View(table);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(G3_Monitor_Notice table)
        {
            using (Monitor_Notice db = new Monitor_Notice())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(table).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("SystemNotify", "notify");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SystemNotifyComplete()
        {
            SystemNotify A = new SystemNotify();
            List<G3_Monitor_Notice> list = new List<G3_Monitor_Notice>();
            using (Monitor_Notice db = new Monitor_Notice())
            {
                var reuslt = db.G3_Monitor_Notice.ToList();
                foreach (var item in reuslt)
                {
                    if (item.status == 2)
                    {
                        G3_Monitor_Notice Data = new G3_Monitor_Notice();
                        Data.Id = item.Id;
                        Data.User = item.User;
                        Data.MeasurementDate = item.MeasurementDate;
                        Data.Object = item.Object;
                        Data.status = item.status;

                        list.Add(Data);
                    }
                }
            }
            A.NotifyList = list;
            ViewBag.Message = "已完成之需求";
            return View(A);
        }

        public ActionResult OutDoor()
        {
            ViewBag.Message = "外出";
            return View();
        }

        public ActionResult LookAfter()
        {
            ViewBag.Message = "照護";
            return View();
        }

        public ActionResult Rehabilitation()
        {
            ViewBag.Message = "復健";
            return View();
        }
    }
}
