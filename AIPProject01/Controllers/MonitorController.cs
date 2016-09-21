using AIPProject01.ViewModels;
using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace AIPProject01.Controllers
{
    public class MonitorController : Controller
    {
        public ActionResult Index()
        {
            List<G3_User> list = new List<G3_User>();

            using (AIPEntities3 db = new AIPEntities3())
            {
                var reuslt = db.G3_User.ToList();
                foreach (var item in reuslt)
                {
                    G3_User user = new G3_User();
                    user.NAME = item.NAME;
                    list.Add(user);
                }
            }

            ViewBag.Message = "好友監測";
            return View(list);
        }

        public ActionResult UserHealthyInformation()
        {
            HealthyScore Healthy = new HealthyScore();
            UserHealthyInformation B = new UserHealthyInformation();
            G1_User_Account C = new G1_User_Account();
            String strLoginID = User.Identity.Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                        B.User = strLoginID;
                    }
                }
            }

            using (AIPEntities7 db = new AIPEntities7())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                G3_Measure_BloodPressure History = new G3_Measure_BloodPressure();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SBP = item.SBP;
                        History.DBP = item.DBP;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
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
                    B.BloodPressure = History;
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                int number = 1;
                var reuslt = db.G3_Measure_ABG.ToList();
                G3_Measure_ABG History = new G3_Measure_ABG();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SpO2 = item.SpO2;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SpO2 = item.SpO2;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.ABG = History;
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                G3_Measure_BloodGlucose History = new G3_Measure_BloodGlucose();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.GLU_AC = item.GLU_AC;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.GLU_AC = item.GLU_AC;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BloodGlucose = History;
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BMI.ToList();
                G3_Measure_BMI History = new G3_Measure_BMI();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.BMI = item.BMI;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.BMI = item.BMI;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BMI = History;
                }
            }
            using (AIPEntities25 db = new AIPEntities25())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Air.ToList();
                G3_Measure_Air History = new G3_Measure_Air();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Air = item.Air;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Air = item.Air;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Air = History;
                }           
            }
            using (GSR db = new GSR())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GSR.ToList();
                G3_Measure_GSR History = new G3_Measure_GSR();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GSR = History;
                }
            }
            using (GyroValues db = new GyroValues())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GyroValues.ToList();
                G3_Measure_GyroValues History = new G3_Measure_GyroValues();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GyroValues = History;
                }
            }
            using (bodyTemperature db = new bodyTemperature())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Temperature.ToList();
                G3_Measure_Temperature History = new G3_Measure_Temperature();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Temperature = item.Temperature;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Temperature = item.Temperature;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Temperature = History;
                }
            }
            using (Pulse db = new Pulse())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Pulse.ToList();
                G3_Measure_Pulse History = new G3_Measure_Pulse();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Pulse = item.Pulse;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Pulse = item.Pulse;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Pulse = History;
                }
            }

            Healthy.HealthyInformation = B;
            Healthy.Total = B.ABG.Score + B.BloodGlucose.Score + B.BloodPressure.Score + B.BMI.Score +
                            B.Air.Score + B.GSR.Score + B.GyroValues.Score + B.Pulse.Score +
                            B.Temperature.Score;

            ViewBag.Message = "我的健康資訊";
            return View(Healthy);
        }

        public ActionResult HealthyInformation(int WhereKey = 0, string Name = null)
        {
            HealthyScore Healthy = new HealthyScore();
            Healthy.WhereKey = WhereKey;
            UserHealthyInformation B = new UserHealthyInformation();
            G1_User_Account C = new G1_User_Account();
            String strLoginID = Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                        B.User = strLoginID;
                    }
                }
            }

            using (AIPEntities7 db = new AIPEntities7())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                G3_Measure_BloodPressure History = new G3_Measure_BloodPressure();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SBP = item.SBP;
                        History.DBP = item.DBP;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
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
                    B.BloodPressure = History;
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                int number = 1;
                var reuslt = db.G3_Measure_ABG.ToList();
                G3_Measure_ABG History = new G3_Measure_ABG();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SpO2 = item.SpO2;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SpO2 = item.SpO2;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.ABG = History;
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                G3_Measure_BloodGlucose History = new G3_Measure_BloodGlucose();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.GLU_AC = item.GLU_AC;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.GLU_AC = item.GLU_AC;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BloodGlucose = History;
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BMI.ToList();
                G3_Measure_BMI History = new G3_Measure_BMI();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.BMI = item.BMI;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.BMI = item.BMI;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BMI = History;
                }
            }
            using (AIPEntities25 db = new AIPEntities25())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Air.ToList();
                G3_Measure_Air History = new G3_Measure_Air();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Air = item.Air;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Air = item.Air;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Air = History;
                }
            }
            using (GSR db = new GSR())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GSR.ToList();
                G3_Measure_GSR History = new G3_Measure_GSR();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GSR = History;
                }
            }
            using (GyroValues db = new GyroValues())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GyroValues.ToList();
                G3_Measure_GyroValues History = new G3_Measure_GyroValues();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GyroValues = History;
                }
            }
            using (bodyTemperature db = new bodyTemperature())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Temperature.ToList();
                G3_Measure_Temperature History = new G3_Measure_Temperature();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Temperature = item.Temperature;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Temperature = item.Temperature;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Temperature = History;
                }
            }
            using (Pulse db = new Pulse())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Pulse.ToList();
                G3_Measure_Pulse History = new G3_Measure_Pulse();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Pulse = item.Pulse;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Pulse = item.Pulse;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Pulse = History;
                }
            }

            Healthy.HealthyInformation = B;
            Healthy.Total = B.ABG.Score + B.BloodGlucose.Score + B.BloodPressure.Score + B.BMI.Score +
                            B.Air.Score + B.GSR.Score + B.GyroValues.Score + B.Pulse.Score +
                            B.Temperature.Score;

            ViewBag.Message = "健康資訊";
            return View(Healthy);
        }

        public ActionResult HealthyInformationNutrition(int WhereKey = 0, string Name = null)
        {
            HealthyScore Healthy = new HealthyScore();
            Healthy.WhereKey = WhereKey;
            UserHealthyInformation B = new UserHealthyInformation();
            G1_User_Account C = new G1_User_Account();
            String strLoginID = Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                        B.User = strLoginID;
                    }
                }
            }

            using (AIPEntities7 db = new AIPEntities7())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                G3_Measure_BloodPressure History = new G3_Measure_BloodPressure();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SBP = item.SBP;
                        History.DBP = item.DBP;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
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
                    B.BloodPressure = History;
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                int number = 1;
                var reuslt = db.G3_Measure_ABG.ToList();
                G3_Measure_ABG History = new G3_Measure_ABG();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.SpO2 = item.SpO2;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.SpO2 = item.SpO2;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.ABG = History;
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                G3_Measure_BloodGlucose History = new G3_Measure_BloodGlucose();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.GLU_AC = item.GLU_AC;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.GLU_AC = item.GLU_AC;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BloodGlucose = History;
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                int number = 1;
                var reuslt = db.G3_Measure_BMI.ToList();
                G3_Measure_BMI History = new G3_Measure_BMI();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.BMI = item.BMI;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.BMI = item.BMI;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.BMI = History;
                }
            }
            using (AIPEntities25 db = new AIPEntities25())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Air.ToList();
                G3_Measure_Air History = new G3_Measure_Air();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Air = item.Air;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Air = item.Air;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Air = History;
                }
            }
            using (GSR db = new GSR())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GSR.ToList();
                G3_Measure_GSR History = new G3_Measure_GSR();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GSR = History;
                }
            }
            using (GyroValues db = new GyroValues())
            {
                int number = 1;
                var reuslt = db.G3_Measure_GyroValues.ToList();
                G3_Measure_GyroValues History = new G3_Measure_GyroValues();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
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
                    else if (C.id == item.Userid && number != 1)
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
                    B.GyroValues = History;
                }
            }
            using (bodyTemperature db = new bodyTemperature())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Temperature.ToList();
                G3_Measure_Temperature History = new G3_Measure_Temperature();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Temperature = item.Temperature;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Temperature = item.Temperature;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Temperature = History;
                }
            }
            using (Pulse db = new Pulse())
            {
                int number = 1;
                var reuslt = db.G3_Measure_Pulse.ToList();
                G3_Measure_Pulse History = new G3_Measure_Pulse();

                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid && number == 1)
                    {
                        History.Userid = item.Userid;
                        History.Pulse = item.Pulse;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        number = number + 1;
                    }
                    else if (C.id == item.Userid && number != 1)
                    {
                        if (DateTime.Compare(item.MeasurementDate, History.MeasurementDate) > 0)
                        {
                            History.Pulse = item.Pulse;
                            History.MeasurementDate = item.MeasurementDate;
                            History.Status = item.Status;
                            History.Score = item.Score;
                        }
                    }
                    B.Pulse = History;
                }
            }

            Healthy.HealthyInformation = B;
            Healthy.Total = B.ABG.Score + B.BloodGlucose.Score + B.BloodPressure.Score + B.BMI.Score +
                            B.Air.Score + B.GSR.Score + B.GyroValues.Score + B.Pulse.Score +
                            B.Temperature.Score;

            ViewBag.Message = "健康資訊";
            return View(Healthy);
        }

        public ActionResult Family()
        {
            String strLoginID = User.Identity.Name;
            Relationship MonitorTarget = new Relationship();
            MonitorTarget.WhereKey = 1;
            MonitorTarget.RelationshipKey = 0;
            int Userid = new int();       
            List<G1_User_Account> A = new List<G1_User_Account>();
            List<G1_User_Account> temp = new List<G1_User_Account>();
            List<G1_User_FamilyMember> B = new List<G1_User_FamilyMember>();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                A = reuslt;

                foreach (var item in reuslt)
                {
                    if (item.email == strLoginID)
                    {                       
                        Userid = item.id;
                    }
                }
            }

            using (AIPEntities22 db = new AIPEntities22())
            {
                var reuslt = db.G1_User_FamilyMember.ToList();

                foreach (var item in reuslt)
                {
                    if (Userid == item.id)
                    {
                        MonitorTarget.RelationshipKey = 1;
                        B.Add(item);
                    }
                }

                foreach (var item in B)
                {
                    foreach (var item2 in A)
                    {
                        if (item.id_relatives == item2.id)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            temp.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipList = temp;
            }

            /*/// 你發給誰家屬申請 

            using (AIPEntities13 db = new AIPEntities13())
            {
                var reuslt = db.G3_Monitor_FamilyApplication.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.User)
                    {
                        MonitorTarget.ApplicationKey = 1;
                        FamilyApplication.Add(item.Family);
                    }
                }
            }

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in FamilyApplication)
                {
                    foreach (var item2 in reuslt)
                    {
                        if (item2.email == item)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            B.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipApplicationList = B;
            }

            /// 誰發給你家屬申請 

            using (AIPEntities13 db = new AIPEntities13())
            {
                var reuslt = db.G3_Monitor_FamilyApplication.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.Family)
                    {
                        MonitorTarget.WaitKey = 1;
                        FamilyWait.Add(item.User);
                    }
                }
            }

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in FamilyWait)
                {
                    foreach (var item2 in reuslt)
                    {
                        if (item2.email == item)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            C.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipWaitList = C;
            }*/    

            ViewBag.Message = "家屬";
            return View(MonitorTarget);
        }

        public ActionResult AddFamily()
        {
            return View();
        }

        public ActionResult AddFamilyApplication(AddFamily A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities13 db = new AIPEntities13())
            {
                G3_Monitor_FamilyApplication Application = new G3_Monitor_FamilyApplication();

                Application.User = strLoginID;
                Application.Family = A.TargetNAME;

                db.G3_Monitor_FamilyApplication.Add(Application);
                db.SaveChanges();
            }

            return RedirectToAction("Family", "Monitor");
        }

        public ActionResult CancelFamilyApplication(Relationship A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities13 db = new AIPEntities13())
            {
                /*G3_Monitor_FamilyApplication Application = new G3_Monitor_FamilyApplication();*/

                var reuslt = db.G3_Monitor_FamilyApplication.ToList();
                foreach (var item in reuslt)
                {
                    G3_Monitor_FamilyApplication Application = db.G3_Monitor_FamilyApplication.FirstOrDefault(c => c.User == strLoginID
                                                                                                                && c.Family == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_FamilyApplication.Remove(Application);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Family", "Monitor");
        }

        public ActionResult AgreeFamilyApplication(Relationship A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities13 db = new AIPEntities13())
            {
                var reuslt = db.G3_Monitor_FamilyApplication.ToList();
                foreach (var item in reuslt)
                {
                    G3_Monitor_FamilyApplication Application = db.G3_Monitor_FamilyApplication.FirstOrDefault(c => c.Family == strLoginID
                                                                                                                && c.User == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_FamilyApplication.Remove(Application);
                        db.SaveChanges();
                    }

                    Application = db.G3_Monitor_FamilyApplication.FirstOrDefault(c => c.User == strLoginID
                                                                                   && c.Family == A.Name);

                    if (Application != null)
                    {
                        db.G3_Monitor_FamilyApplication.Remove(Application);
                        db.SaveChanges();
                    }
                }
            }

            using (AIPEntities12 db = new AIPEntities12())
            {
                G3_Monitor_Family Family = new G3_Monitor_Family();

                Family.User = strLoginID;
                Family.Family = A.Name;
                db.G3_Monitor_Family.Add(Family);
                db.SaveChanges();

                Family.User = A.Name;
                Family.Family = strLoginID;
                db.G3_Monitor_Family.Add(Family);
                db.SaveChanges();
            }

            return RedirectToAction("Family", "Monitor");
        }

        public ActionResult AddFamilyOutput(AddFamily A)
        {
            AddFamily C = new AddFamily();
            C.TargetNAME = null;
            C.Relationship = null;
            String strLoginID = User.Identity.Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (item.email == A.TargetNAME)
                    {
                        C.TargetID = item.id;
                        C.TargetNAME = item.email;
                        C.TargetPASSWORD = item.passwd;
                    }
                }
            }

            if (C.TargetNAME != null)
            {
                if (strLoginID == C.TargetNAME)
                {
                    C.Relationship = "自己";
                }
                else
                {
                    using (AIPEntities12 db = new AIPEntities12())
                    {
                        var reuslt = db.G3_Monitor_Family.ToList();
                        foreach (var item in reuslt)
                        {
                            if (C.TargetNAME == item.User)
                            {
                                C.Relationship = "家屬";
                            }
                        }
                    }

                    if (C.Relationship == null)
                    {
                        C.Relationship = "家屬申請";
                    }
                }
            }
            ViewBag.Message = "家屬搜尋結果";
            return View(C);
        }

        public ActionResult Friends()
        {
            Relationship MonitorTarget = new Relationship();
            MonitorTarget.WhereKey = 2;
            MonitorTarget.RelationshipKey = 0;
            MonitorTarget.ApplicationKey = 0;
            MonitorTarget.WaitKey = 0;
            List<String> Friend = new List<String>();
            List<String> FriendApplication = new List<String>();
            List<String> FriendWait = new List<String>();
            String strLoginID = User.Identity.Name;
            List<G1_User_Account> A = new List<G1_User_Account>();
            List<G1_User_Account> B = new List<G1_User_Account>();
            List<G1_User_Account> C = new List<G1_User_Account>();

            /// 誰已經是你的好友 

            using (AIPEntities14 db = new AIPEntities14())
            {
                var reuslt = db.G3_Monitor_Friends.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.User)
                    {
                        MonitorTarget.RelationshipKey = 1;
                        Friend.Add(item.Friend);
                    }
                }
            }

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in Friend)
                {
                    foreach (var item2 in reuslt)
                    {
                        if (item2.email == item)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            A.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipList = A;
            }

             /// 你發給誰好友申請 

            using (AIPEntities15 db = new AIPEntities15())
            {
                var reuslt = db.G3_Monitor_FriendApplication.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.User)
                    {
                        MonitorTarget.ApplicationKey = 1;
                        FriendApplication.Add(item.Friend);
                    }
                }
            }

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in FriendApplication)
                {
                    foreach (var item2 in reuslt)
                    {
                        if (item2.email == item)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            B.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipApplicationList = B;
            }

             /// 誰發給你好友申請 

            using (AIPEntities15 db = new AIPEntities15())
            {
                var reuslt = db.G3_Monitor_FriendApplication.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.Friend)
                    {
                        MonitorTarget.WaitKey = 1;
                        FriendWait.Add(item.User);
                    }
                }
            }

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in FriendWait)
                {
                    foreach (var item2 in reuslt)
                    {
                        if (item2.email == item)
                        {
                            G1_User_Account user = new G1_User_Account();
                            user.id = item2.id;
                            user.email = item2.email;
                            user.passwd = item2.passwd;

                            C.Add(user);
                        }
                    }
                }
                MonitorTarget.RelationshipWaitList = C;
            }

            ViewBag.Message = "好友";
            return View(MonitorTarget);
        }

        public ActionResult AddFriend()
        {
            return View();
        }

        public ActionResult DeleteFriend(Relationship A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities14 db = new AIPEntities14())
            {
                var reuslt = db.G3_Monitor_Friends.ToList();
                foreach (var item in reuslt)
                {
                    G3_Monitor_Friends Application = db.G3_Monitor_Friends.FirstOrDefault(c => c.User == A.Name && c.Friend == strLoginID);
                    
                    if (Application != null)
                    {
                        db.G3_Monitor_Friends.Remove(Application);
                        db.SaveChanges();
                    }

                    Application = db.G3_Monitor_Friends.FirstOrDefault(c => c.User == strLoginID
                                                                                   && c.Friend == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_Friends.Remove(Application);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Friends", "Monitor");
        }

        public ActionResult AddFriendApplication(AddFriend A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities15 db = new AIPEntities15())
            {
                G3_Monitor_FriendApplication Application = new G3_Monitor_FriendApplication();

                Application.User = strLoginID;
                Application.Friend = A.TargetNAME;

                db.G3_Monitor_FriendApplication.Add(Application);
                db.SaveChanges();
            }

            return RedirectToAction("Friends", "Monitor");
        }

        public ActionResult CancelFriendApplication(Relationship A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities15 db = new AIPEntities15())
            {
                /*G3_Monitor_FamilyApplication Application = new G3_Monitor_FamilyApplication();*/

                var reuslt = db.G3_Monitor_FriendApplication.ToList();
                foreach (var item in reuslt)
                {
                    G3_Monitor_FriendApplication Application = db.G3_Monitor_FriendApplication.FirstOrDefault(c => c.User == strLoginID
                                                                                                                && c.Friend == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_FriendApplication.Remove(Application);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("Friends", "Monitor");
        }

        public ActionResult AgreeFriendApplication(Relationship A)
        {
            String strLoginID = User.Identity.Name;

            using (AIPEntities15 db = new AIPEntities15())
            {
                var reuslt = db.G3_Monitor_FriendApplication.ToList();
                foreach (var item in reuslt)
                {
                    G3_Monitor_FriendApplication Application = db.G3_Monitor_FriendApplication.FirstOrDefault(c => c.Friend == strLoginID
                                                                                                                && c.User == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_FriendApplication.Remove(Application);
                        db.SaveChanges();
                    }

                    Application = db.G3_Monitor_FriendApplication.FirstOrDefault(c => c.User == strLoginID
                                                                                   && c.Friend == A.Name);
                    if (Application != null)
                    {
                        db.G3_Monitor_FriendApplication.Remove(Application);
                        db.SaveChanges();
                    }
                }
            }

            using (AIPEntities14 db = new AIPEntities14())
            {
                G3_Monitor_Friends Friend = new G3_Monitor_Friends();

                //User.ID = User.ID;
                Friend.User = strLoginID;
                Friend.Friend = A.Name;
                db.G3_Monitor_Friends.Add(Friend);
                db.SaveChanges();

                Friend.User = A.Name;
                Friend.Friend = strLoginID;
                db.G3_Monitor_Friends.Add(Friend);
                db.SaveChanges();
            }

            return RedirectToAction("Friends", "Monitor");
        }

        public ActionResult AddFriendOutput(AddFriend A)
        {
            AddFriend C = new AddFriend();
            C.TargetNAME = null;
            C.Relationship = null;
            String strLoginID = User.Identity.Name;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (item.email == A.TargetNAME)
                    {
                        C.TargetID = item.id;
                        C.TargetNAME = item.email;
                        C.TargetPASSWORD = item.passwd;
                    }
                }
            }

            if (C.TargetNAME != null)
            {
                if (strLoginID == C.TargetNAME)
                {
                    C.Relationship = "自己";
                }
                else
                {
                    using (AIPEntities14 db = new AIPEntities14())
                    {
                        var reuslt = db.G3_Monitor_Friends.ToList();
                        foreach (var item in reuslt)
                        {
                            if (C.TargetNAME == item.Friend && strLoginID == item.User)
                            {
                                C.Relationship = "好友";
                            }
                        }
                    }

                    using (AIPEntities15 db = new AIPEntities15())
                    {
                        var reuslt = db.G3_Monitor_FriendApplication.ToList();
                        foreach (var item in reuslt)
                        {
                            if (C.TargetNAME == item.Friend && strLoginID == item.User)
                            {
                                C.Relationship = "已發出好友申請";
                            }

                            else if (C.TargetNAME == item.User && strLoginID == item.Friend)
                            {
                                C.Relationship = "已接到好友申請";
                            }
                        }
                    }

                    if (C.Relationship == null)
                    {
                        C.Relationship = "好友申請";
                    }
                }
            }

            return View(C);
        }

        public ActionResult Volunteers()
        {
            G1_User_Identity UserIndentity = new G1_User_Identity();
            String strLoginID = User.Identity.Name;
            int Userid = new int();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();

                foreach (var item in reuslt)
                {
                    if (item.email == strLoginID)
                    {                       
                        Userid = item.id;
                    }
                }
            }

            using (AIPEntities21 db = new AIPEntities21())
            {
                var reuslt = db.G1_User_Identity.ToList();

                foreach (var item in reuslt)
                {
                    if (Userid == item.id && item.UserType == 4)
                    {
                        UserIndentity.id = item.id;
                        UserIndentity.TypeName = item.TypeName;
                        UserIndentity.UserType = item.UserType;
                    }
                 }
            }

            ViewBag.Message = "志工";
            return View(UserIndentity);
        }

        public ActionResult Output(HealthyScore A)
        {
            G3_Monitor_Notice B = new G3_Monitor_Notice();

            B.User = User.Identity.Name;
            B.Object = A.name;
            B.MeasurementDate = DateTime.Now;
            B.status = 1;

            using (Monitor_Notice db = new Monitor_Notice())
            {
                db.G3_Monitor_Notice.Add(B);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "notify");
        }
    }
}