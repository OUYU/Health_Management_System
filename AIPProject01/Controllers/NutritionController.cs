using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using System.Data;
using System.Data.Entity;
using PagedList;
using AIPProject01.ViewModels;
using PagedList.Mvc;
using PagedList;


namespace AIPProject01.Controllers
{
    public class NutritionController : Controller
    {
        //
        // GET: /Nutrition/

        public ActionResult Index()
        {
            List<G1_User_Account> A = new List<G1_User_Account>();
            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                A = reuslt;
            }
            NutritionList B = new NutritionList();
            B.UserList = A;
            ViewBag.Message = "醫生營養建議";
            return View(B);
        }

        public ActionResult View(int id = 0)
        {
            SystemNutrition C = new SystemNutrition();
            List<G3_Nutrition_Nutrition> list = new List<G3_Nutrition_Nutrition>();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (id == item.id)
                    {
                        C.UserName = item.email;
                    }
                }
            }

            using (Nutrition db = new Nutrition())
            {
                var reuslt = db.G3_Nutrition_Nutrition.ToList();
                foreach (var item in reuslt)
                {
                    if (id == item.UserId)
                    {
                        G3_Nutrition_Nutrition Data = new G3_Nutrition_Nutrition();
                        Data.Id = item.Id;
                        Data.UserId = item.UserId;
                        Data.Title = item.Title;
                        Data.Content = item.Content;
                        Data.Doctor = item.Doctor;
                        Data.Date = item.Date;

                        list.Add(Data);
                    }
                }
            }

            C.NutritionList = list;
            ViewBag.Message = "建議檢視";
            return View(C);
        }

        public ActionResult UserView(int WhereKey = 0, string Name = null)
        {
            SystemNutrition C = new SystemNutrition();
            List<G3_Nutrition_Nutrition> list = new List<G3_Nutrition_Nutrition>();

            C.WhereKey = WhereKey;
            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (Name == item.email)
                    {
                        C.NutritionId = item.id;
                        C.UserName = item.email;
                    }
                }
            }

            using (Nutrition db = new Nutrition())
            {
                var reuslt = db.G3_Nutrition_Nutrition.ToList();
                foreach (var item in reuslt)
                {
                    if (C.NutritionId == item.UserId)
                    {
                        G3_Nutrition_Nutrition Data = new G3_Nutrition_Nutrition();
                        Data.Id = item.Id;
                        Data.UserId = item.UserId;
                        Data.Title = item.Title;
                        Data.Content = item.Content;
                        Data.Doctor = item.Doctor;
                        Data.Date = item.Date;

                        list.Add(Data);
                    }
                }
            }

            C.NutritionList = list;
            ViewBag.Message = "建議檢視";
            return View(C);
        }

        public ActionResult Create(string Name = null)
        {
            SystemNutrition D = new SystemNutrition();
            G3_Nutrition_Nutrition B = new G3_Nutrition_Nutrition();
            HealthyScore Healthy = new HealthyScore();
            UserHealthyInformation C = new UserHealthyInformation();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (Name == item.email)
                    {
                        B.UserId = item.id;
                    }
                }
            }
            D.UserName = Name;
            D.Nutrition = B;

            using (AIPEntities7 db = new AIPEntities7())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                G3_Measure_BloodPressure History = new G3_Measure_BloodPressure();
                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SBP = item.SBP;
                        History.DBP = item.DBP;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SBP = item.SBP;
                            History.DBP = item.DBP;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.BloodPressure = History;
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                int number = 1;
                var reuslt = db.G3_Measure_ABG.ToList();
                G3_Measure_ABG History = new G3_Measure_ABG();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SpO2 = item.SpO2;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SpO2 = item.SpO2;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.ABG = History;
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                G3_Measure_BloodGlucose History = new G3_Measure_BloodGlucose();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.GLU_AC = item.GLU_AC;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.GLU_AC = item.GLU_AC;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.BloodGlucose = History;
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BMI.ToList();
                G3_Measure_BMI History = new G3_Measure_BMI();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.BMI = item.BMI;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.BMI = item.BMI;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.BMI = History;
                }
            }
            using (AIPEntities25 db = new AIPEntities25())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Air.ToList();
                G3_Measure_Air History = new G3_Measure_Air();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Air = item.Air;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Air = item.Air;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.Air = History;
                }
            }
            using (GSR db = new GSR())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GSR.ToList();
                G3_Measure_GSR History = new G3_Measure_GSR();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SkinConductance = item.SkinConductance;
                        History.SkinResistance = item.SkinResistance;
                        History.SkinConductanceVoltage = item.SkinConductanceVoltage;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SkinConductance = item.SkinConductance;
                            History.SkinResistance = item.SkinResistance;
                            History.SkinConductanceVoltage = item.SkinConductanceVoltage;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.GSR = History;
                }
            }
            using (GyroValues db = new GyroValues())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GyroValues.ToList();
                G3_Measure_GyroValues History = new G3_Measure_GyroValues();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.RawX = item.RawX;
                        History.RawY = item.RawY;
                        History.RawZ = item.RawZ;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.RawX = item.RawX;
                            History.RawY = item.RawY;
                            History.RawZ = item.RawZ;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.GyroValues = History;
                }
            }
            using (bodyTemperature db = new bodyTemperature())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Temperature.ToList();
                G3_Measure_Temperature History = new G3_Measure_Temperature();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Temperature = item.Temperature;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Temperature = item.Temperature;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.Temperature = History;
                }
            }
            using (Pulse db = new Pulse())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Pulse.ToList();
                G3_Measure_Pulse History = new G3_Measure_Pulse();

                foreach (var item in reuslt)
                {
                    if (B.UserId == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Pulse = item.Pulse;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (B.UserId == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Pulse = item.Pulse;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    C.Pulse = History;
                }
            }

            Healthy.HealthyInformation = C;
            Healthy.Total = C.ABG.Score + C.BloodGlucose.Score + C.BloodPressure.Score + C.BMI.Score +
                            C.Air.Score + C.GSR.Score + C.GyroValues.Score + C.Pulse.Score +
                            C.Temperature.Score;

            D.UserHealthy = Healthy;

            ViewBag.Message = "新增建議";
            return View(D);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemNutrition A)
        {
            G3_Nutrition_Nutrition B = new G3_Nutrition_Nutrition();
            
            B.UserId = A.Nutrition.UserId;
            B.Title = A.Nutrition.Title;
            B.Content = A.Nutrition.Content;
            B.Doctor = User.Identity.Name;
            B.Date = DateTime.Now;

            using (Nutrition db = new Nutrition())
            {
                db.G3_Nutrition_Nutrition.Add(B);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Nutrition");
        }

        public ActionResult Edit(int id = 0)
        {
            using (Nutrition db = new Nutrition())
            {
                G3_Nutrition_Nutrition table = db.G3_Nutrition_Nutrition.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Message = "編輯建議";
                return View(table);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(G3_Nutrition_Nutrition table)
        {
            using (Nutrition db = new Nutrition())
            {
                if (ModelState.IsValid)
                {
                    table.Date = DateTime.Now;
                    db.Entry(table).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Nutrition");
                }
            }
            return RedirectToAction("View", "Nutrition", new { id = table.UserId });
        }

        public ActionResult Delete(int id = 0)
        {
            using (Nutrition db = new Nutrition())
            {
                G3_Nutrition_Nutrition table = db.G3_Nutrition_Nutrition.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Message = "刪除建議";
                return View(table);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (Nutrition db = new Nutrition())
            {
                G3_Nutrition_Nutrition table = db.G3_Nutrition_Nutrition.Find(id);
                db.G3_Nutrition_Nutrition.Remove(table);
                db.SaveChanges();
                return RedirectToAction("View", "Nutrition", new { id = table.UserId });
            }
        }

        public ActionResult Details(int id = 0, string name = null)
        {
            SystemNutrition C = new SystemNutrition();
            C.UserName = name;
            using (Nutrition db = new Nutrition())
            {
                G3_Nutrition_Nutrition table = db.G3_Nutrition_Nutrition.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    C.Nutrition = table;
                }
            }
            return View(C);
        }

        public ActionResult UserDetails(int id = 0, int WhereKey = 0, string name = null)
        {
            SystemNutrition C = new SystemNutrition();
            C.WhereKey = WhereKey;
            C.UserName = name;
            using (Nutrition db = new Nutrition())
            {
                G3_Nutrition_Nutrition table = db.G3_Nutrition_Nutrition.Find(id);
                if (table == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    C.Nutrition = table;
                }
            }
            return View(C);
        }
    }
}
