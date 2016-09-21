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
    public class PartnersController : Controller
    {
        //
        // GET: /Partners/

        public ActionResult Index()
        {
            ViewBag.Message = "合作團隊";
            return View();
        }
    }
}
