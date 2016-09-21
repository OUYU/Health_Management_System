using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class KnowledgeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "衛教資訊";
            return View();
        }
    }
}
