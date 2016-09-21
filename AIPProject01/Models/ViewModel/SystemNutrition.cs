using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIPProject01.Models.ViewModel
{
    public class NutritionList
    {
        public int NutritionId { get; set; }
        public List<G1_User_Account> UserList { get; set; }
    }

    public class SystemNutrition
    {
        public int NutritionId { get; set; }
        public int WhereKey { get; set; }
        public string UserName { get; set; }
        public G3_Nutrition_Nutrition Nutrition { get; set; }
        public HealthyScore UserHealthy { get; set; }
        public List<G3_Nutrition_Nutrition> NutritionList { get; set; }
    }
}