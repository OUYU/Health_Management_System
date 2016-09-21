using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class sponsorController : Controller
    {
        //
        // GET: /sponsor/

        public ActionResult Index()
        {
            ViewBag.Message = "贊助廠商";
            return View();
        }

    }
}
