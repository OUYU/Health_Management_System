using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Models.ViewModel
{
    public class UserHealthyInformation
    {
        public string User { get; set; }
        public G3_Measure_ABG ABG { get; set; }
        public G3_Measure_BloodGlucose BloodGlucose { get; set; }
        public G3_Measure_BloodPressure BloodPressure { get; set; }
        public G3_Measure_BMI BMI { get; set; }
        public G3_Measure_Air Air  { get; set; }
        public G3_Measure_GSR GSR { get; set; }
        public G3_Measure_GyroValues GyroValues { get; set; }
        public G3_Measure_Pulse Pulse { get; set; }
        public G3_Measure_Temperature Temperature { get; set; }
    }
}