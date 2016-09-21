using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIPProject01.Models.ViewModel
{
    public class SystemNotify
    {
        public int NotifyId { get; set; }
        public List<G3_Monitor_Notice> NotifyList { get; set; }
    }
}