//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AIPProject01.Models.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class G3_Measure_BloodPressure
    {
        public int ID { get; set; }
        public int Userid { get; set; }
        public int SBP { get; set; }
        public int DBP { get; set; }
        public System.DateTime MeasurementDate { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
    }
}
