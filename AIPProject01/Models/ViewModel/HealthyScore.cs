using AIPProject01.Models.ViewModel;
using AIPProject01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Models.ViewModel
{
    public class HealthyScore
    {
        public string name { get; set; }
        public int WhereKey { get; set; }
        public UserHealthyInformation HealthyInformation { get; set; }
        public int Total { get; set; }
    }
}