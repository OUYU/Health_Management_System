using AIPProject01.ViewModels;
using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.ViewModels
{
    public class AddFamily
    {
        public string Relationship { get; set; }
        public int TargetID { get; set; }
        public String TargetNAME { get; set; }
        public String TargetPASSWORD { get; set; }
    }

    public class AddFriend
    {
        public string Relationship { get; set; }
        public int TargetID { get; set; }
        public String TargetNAME { get; set; }
        public String TargetPASSWORD { get; set; }
    }

}