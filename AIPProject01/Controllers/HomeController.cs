using AIPProject01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            /// ViewBag.Message = "次標題";
            return View();
        }

        /// <summary>
        /// 首頁功能一
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {   
            ViewBag.Message = "關於我們";
            return View();
        }

        /// <summary>
        /// 首頁功能二
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            List<G1User> list = new List<G1User>();
            
            using (var context = new AIPProject01.AIPEntities())
            {
                
                var reuslt = context.G1_User.ToList();
                foreach (var item in reuslt)
                {
                    G1User user = new G1User();
                    user.id = item.id;
                    user.name = item.name;
                    list.Add(user);
                }
            }
            ViewBag.Message = "關於我們.聯絡我們";
            return View(list);
        }

        public ActionResult Idea()
        {
            ViewBag.Message = "關於我們.開發理念";
            return View();
        }

        public ActionResult Team()
        {
            ViewBag.Message = "關於我們.開發團隊";
            return View();
        }
    }
}