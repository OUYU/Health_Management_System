using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class IntroductionController : Controller
    {
        //
        // GET: /Introduction/

        public ActionResult Index()
        {
            ViewBag.Message = "系統介紹";
            return View();
        }

        public ActionResult measure()
        {
            ViewBag.Message = "系統介紹.健康量測";
            return View();
        }

        public ActionResult Monitor()
        {
            ViewBag.Message = "系統介紹.好友監測";
            return View();
        }

        public ActionResult notify()
        {
            ViewBag.Message = "系統介紹.需求通知";
            return View();
        }

        public ActionResult Knowledge()
        {
            ViewBag.Message = "系統介紹.衛教資訊";
            return View();
        }

    }
}
