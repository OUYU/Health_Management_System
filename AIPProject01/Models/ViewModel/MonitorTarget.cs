using AIPProject01.ViewModels;
using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.ViewModels
{
    public class Relationship
    {
        public int WhereKey { get; set; }
        public string Name { get; set; }
        public List<G1_User_Account> RelationshipList { get; set; }
        public int RelationshipKey { get; set; }
        public List<G1_User_Account> RelationshipApplicationList { get; set; }
        public int ApplicationKey { get; set; }
        public List<G1_User_Account> RelationshipWaitList { get; set; }
        public int WaitKey { get; set; }
    }
}