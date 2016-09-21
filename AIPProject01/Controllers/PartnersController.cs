using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;


namespace AIPProject01.Controllers
{
    public class PartnerController : Controller
    {
        //
        // GET: /Partners/

        public ActionResult Index()
        {
            ViewBag.Message = "合作團隊";
            return View();
        }

        public ActionResult Indexs()
        {
            ViewBag.Message = "合作團隊";
            return View();
        }

        public ActionResult G1()
        {
            ViewBag.Message = "合作團隊.G1";
            return View();
        }

        public ActionResult G7()
        {
            ViewBag.Message = "合作團隊.G7";
            return View();
        }

        public ActionResult G8()
        {
            ViewBag.Message = "合作團隊.G8";
            return View();
        }

        public ActionResult G9()
        {
            ViewBag.Message = "合作團隊.G9";
            return View();
        }
    }
}
