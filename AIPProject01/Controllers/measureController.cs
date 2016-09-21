using AIPProject01.ViewModels;
using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class measureController : Controller
    {
        //
        // GET: /measure/
        public ActionResult Index()
        {
            ViewBag.Message = "健康量測";
            return View();
        }

        public ActionResult BloodPressure()
        {
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_BloodPressure B = new G3_Measure_BloodPressure();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
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
                    B = History;
                }
            }

            ViewBag.Message = "健康量測.血壓";
            return View(B);
        }

        public ActionResult BloodPressureInput()
        {
            ViewBag.Message = "健康量測.血壓.量測開始";
         
            return View();
        }

        [HttpPost]
        public ActionResult BloodPressureOutput(BloodPressureIn A)
        {
            ViewBag.Message = "健康量測.血壓.量測結果";

            G3_Measure_BloodPressure B = new G3_Measure_BloodPressure();
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
                    }
                }

                B.Userid = C.id;
                B.SBP = A.SBP;
                B.DBP = A.DBP;
                B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);

                if (B.SBP >= 100 && 140 >= B.SBP && B.DBP >= 60 && 90 >= B.DBP && B.SBP > B.DBP)
                {
                    B.Status = "正常";
                    B.Score = 0;
                }
                else if (B.SBP >= 140 && 160 >= B.SBP && B.DBP >= 90 && 100 >= B.DBP && B.SBP > B.DBP)
                {
                    B.Status = "輕度高血壓";
                    B.Score = 2;
                }
                else if (B.SBP >= 160 && 180 >= B.SBP && B.DBP >= 100 && 110 >= B.DBP && B.SBP > B.DBP)
                {
                    B.Status = "中度高血壓";
                    B.Score = 5;
                }
                else if (B.SBP > 180 && B.DBP > 110 && B.SBP > B.DBP)
                {
                    B.Status = "嚴重高血壓";
                    B.Score = 8;
                }
                else
                {
                    B.Status = "血壓異常。請檢查是否正確輸入或重新進行量測，若為正確輸入，建議立即就醫。";
                    B.Score = 10;
                }
            }

            using (AIPEntities7 db = new AIPEntities7())
            {
                db.G3_Measure_BloodPressure.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }

        public ActionResult BloodPressureHistory()
        {
            ViewBag.Message = "健康量測.血壓.歷史紀錄";

            List<G3_Measure_BloodPressure> list = new List<G3_Measure_BloodPressure>();
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
                    }
                }
            }

            using (AIPEntities7 db = new AIPEntities7())
            {
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_BloodPressure History = new G3_Measure_BloodPressure();
                        History.Userid = item.Userid;
                        History.SBP = item.SBP;
                        History.DBP = item.DBP;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }

            return View(list);
        }


        public ActionResult ABG()
        {
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_ABG B = new G3_Measure_ABG();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }

            ViewBag.Message = "健康量測.血氧";
            return View(B);
        }

        public ActionResult ABGInput()
        {
            ViewBag.Message = "健康量測.血氧.量測開始";

            return View();
        }

        public ActionResult ABGOutput(ABGIn A)
        {
            ViewBag.Message = "健康量測.血氧.量測結果";

            G3_Measure_ABG B = new G3_Measure_ABG();
            G1_User_Account C = new G1_User_Account();

            if (A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;

                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }

                    B.Userid = C.id;
                    B.SpO2 = A.SpO2;
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);

                    if (B.SpO2 >= 97 && 99 >= B.SpO2)
                    {
                        B.Status = "正常";
                        B.Score = 0;
                    }
                    else if (B.SpO2 > 90 && 97 > B.SpO2)
                    {
                        B.Status = "偏低";
                        B.Score = 4;
                    }
                    else if (B.SpO2 >= 100)
                    {
                        B.Status = "輸入錯誤，請重新輸入";
                        B.Score = -1;
                        return View(B);
                    }
                    else
                    {
                        B.Status = "低血氧症，狀態異常，請重新量測或立即送醫";
                        B.Score = 10;
                    }
                }
            }
            else
            {
                B.Userid = A.Userid;
                B.SpO2 = A.SpO2;
                B.MeasurementDate = DateTime.Now;

                if (B.SpO2 >= 97 && 99 >= B.SpO2)
                {
                    B.Status = "正常";
                    B.Score = 0;
                }
                else if (B.SpO2 > 90 && 97 > B.SpO2)
                {
                    B.Status = "偏低";
                    B.Score = 4;
                }
                else if (B.SpO2 >= 100)
                {
                    B.Status = "輸入錯誤，請重新輸入";
                    B.Score = -1;
                    return View(B);
                }
                else
                {
                    B.Status = "低血氧症，狀態異常，請重新量測或立即送醫";
                    B.Score = 10;
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                db.G3_Measure_ABG.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }

        public ActionResult ABGHistory()
        {
            ViewBag.Message = "健康量測.血氧.歷史紀錄";

            List<G3_Measure_ABG> list = new List<G3_Measure_ABG>();
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
                    }
                }
            }

            using (AIPEntities9 db = new AIPEntities9())
            {
                var reuslt = db.G3_Measure_ABG.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_ABG History = new G3_Measure_ABG();
                        History.Userid = item.Userid;
                        History.SpO2 = item.SpO2;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }

            return View(list);
        }

        public ActionResult BloodGlucose()
        {
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_BloodGlucose B = new G3_Measure_BloodGlucose();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }

            ViewBag.Message = "健康量測.血糖";
            return View(B);
        }

        public ActionResult BloodGlucoseInput()
        {
            ViewBag.Message = "健康量測.血糖.量測開始";
            return View();
        }

        public ActionResult BloodGlucoseOutput(BloodGlucoseIn A)
        {
            ViewBag.Message = "健康量測.血糖.量測結果";
            G3_Measure_BloodGlucose B = new G3_Measure_BloodGlucose();
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
                    }
                }
              
                B.Userid = C.id;
                B.GLU_AC = A.GLU_AC;
                B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);

                if (A.MeasureTime == "起床空腹")
                {
                    if (B.GLU_AC <= 40)
                    {
                        B.Status = "血糖嚴重低下，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else if (B.GLU_AC <= 69 && B.GLU_AC >= 41)
                    {
                        B.Status = "血糖偏低，須注意，建議前往醫院檢查";
                        B.Score = 4;
                    }
                    else if (B.GLU_AC >= 70 && B.GLU_AC <= 99)
                    {
                        B.Status = "正常";
                        B.Score = 0;
                    }
                    else if (B.GLU_AC >= 100 && B.GLU_AC <= 126)
                    {
                        B.Status = "血糖偏高，可能為糖尿病前期，建議前往醫院檢查";
                        B.Score = 4;
                    }
                    else if (B.GLU_AC >= 500)
                    {
                        B.Status = "血糖超標，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "血糖過高，可能患有糖尿病，建議前往醫院檢查";
                        B.Score = 8;
                    }
                }

                else
                {
                    if (B.GLU_AC <= 40)
                    {
                        B.Status = "血糖嚴重低下，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else if (B.GLU_AC <= 69 && B.GLU_AC >= 41)
                    {
                        B.Status = "血糖偏低，須注意，建議前往醫院檢查";
                        B.Score = 4;
                    }
                    else if (B.GLU_AC >= 70 && B.GLU_AC <= 120)
                    {
                        B.Status = "正常";
                        B.Score = 0;
                    }
                    else if (B.GLU_AC >= 121 && B.GLU_AC <= 199)
                    {
                        B.Status = "血糖偏高，可能為糖尿病前期，建議前往醫院檢查";
                        B.Score = 4;
                    }
                    else if (B.GLU_AC >= 500)
                    {
                        B.Status = "血糖超標，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "血糖過高，可能患有糖尿病，建議前往醫院檢查";
                        B.Score = 8;
                    }
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                db.G3_Measure_BloodGlucose.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }

        public ActionResult BloodGlucoseHistory()
        {
            ViewBag.Message = "健康量測.血糖.歷史紀錄";

            List<G3_Measure_BloodGlucose> list = new List<G3_Measure_BloodGlucose>();
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
                    }
                }
            }

            using (AIPEntities8 db = new AIPEntities8())
            {
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_BloodGlucose History = new G3_Measure_BloodGlucose();
                        History.Userid = item.Userid;
                        History.GLU_AC = item.GLU_AC;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }

            return View(list);
        }

        public ActionResult BMI()
        {
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_BMI B = new G3_Measure_BMI();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }

            ViewBag.Message = "健康量測.身體質量數值";
            return View(B);
        }

        public ActionResult BMIInput()
        {
            ViewBag.Message = "健康量測.身體質量數值.量測開始";
            return View();
        }

        public ActionResult BMIOutput(BMIIn A)
        {
            ViewBag.Message = "健康量測.身體質量數值.量測結果";
            G3_Measure_BMI B = new G3_Measure_BMI();

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
                    }
                }

                B.Userid = C.id;
                B.BMI = A.Weight / (A.Height * A.Height);
                B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);

                if (B.BMI < 18.5)
                {
                    B.Status = "過輕體位";
                    B.Score = 4;
                }

                else if (18.5 <= B.BMI || B.BMI < 24)
                {
                    B.Status = "健康體位";
                    B.Score = 0;
                }

                else if (24 <= B.BMI || B.BMI < 27)
                {
                    B.Status = "過重體位";
                    B.Score = 4;
                }

                else if (27 <= B.BMI || B.BMI < 30)
                {
                    B.Status = "輕度肥胖體位";
                    B.Score = 6;
                }

                else if (30 <= B.BMI || B.BMI < 35)
                {
                    B.Status = "中度肥胖體位";
                    B.Score = 8;
                }

                else
                {
                    B.Status = "重度肥胖體位";
                    B.Score = 10;
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                db.G3_Measure_BMI.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }

        public ActionResult BMIHistory()
        {
            ViewBag.Message = "健康量測.身體質量數值.歷史紀錄";

            List<G3_Measure_BMI> list = new List<G3_Measure_BMI>();
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
                    }
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                var reuslt = db.G3_Measure_BMI.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_BMI History = new G3_Measure_BMI();
                        History.Userid = item.Userid;
                        History.BMI = item.BMI;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }

            return View(list);
        }

        public ActionResult Breath()
        {
            ViewBag.Message = "健康量測.呼吸強度";
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_Air B = new G3_Measure_Air();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }
            return View(B);
        }
        public ActionResult BreathInput()
        {
            ViewBag.Message = "健康量測.呼吸強度.量測開始";
            return View();
        }
        public ActionResult BreathOutput(BreathIn A)
        {
            ViewBag.Message = "健康量測.呼吸強度.量測結果";
            G3_Measure_Air B = new G3_Measure_Air();
            G1_User_Account C = new G1_User_Account();

            if (A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;

                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }

                    B.Userid = C.id;
                    B.Air = A.Air;
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);
                    if (B.Air <= 0)
                    {
                        B.Status = "呼吸停止，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "呼吸正常";
                        B.Score = 0;
                    }
                }
            }
            else
            {
                B.Userid = A.Userid;
                B.Air = A.Air;
                B.MeasurementDate = DateTime.Now;
                if (B.Air <= 0)
                {
                    B.Status = "呼吸停止，有立即性危險，應盡速送醫";
                    B.Score = 10;
                }
                else
                {
                    B.Status = "呼吸正常";
                    B.Score = 0;
                }
            }

            using (AIPEntities25 db = new AIPEntities25())
            {
                db.G3_Measure_Air.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }
        public ActionResult BreathHistory()
        {
            ViewBag.Message = "健康量測.呼吸強度.歷史紀錄";

            List<G3_Measure_Air> list = new List<G3_Measure_Air>();
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
                    }
                }
            }

            using (AIPEntities25 db = new AIPEntities25())
            {
                var reuslt = db.G3_Measure_Air.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_Air History = new G3_Measure_Air();
                        History.Userid = item.Userid;
                        History.Air = item.Air;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }
            return View(list);
        }

        public ActionResult GSR()
        {
            ViewBag.Message = "健康量測.膚電反應";
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_GSR B = new G3_Measure_GSR();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }
            return View(B);
        }
        public ActionResult GSRInput()
        {
            ViewBag.Message = "健康量測.膚電反應.量測開始";
            return View();
        }
        public ActionResult GSROutput(GSRIn A)
        {
            ViewBag.Message = "健康量測.膚電反應.量測結果";
            G3_Measure_GSR B = new G3_Measure_GSR();
            G1_User_Account C = new G1_User_Account();

            if(A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;

                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }

                    B.Userid = C.id;

                    int temp = (int)A.SkinConductance;
                    int temp2 = (int)((A.SkinConductance - temp) * 100);

                    B.SkinConductance = temp + ((float)temp2 / 100);

                    long temp3 = (int)A.SkinResistance;
                    int temp4 = (int)((A.SkinResistance - temp3) * 100);

                    B.SkinResistance = temp3 + ((float)temp4 / 100);

                    int temp5 = (int)A.SkinConductanceVoltage;
                    int temp6 = (int)((A.SkinConductanceVoltage - temp5) * 10000);

                    B.SkinConductanceVoltage = temp5 + ((float)temp6 / 10000);
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);
                    if (B.SkinResistance < 1000)
                    {
                        B.Status = "出汗異常，有立即性危險，應盡速送醫";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "出汗正常";
                        B.Score = 0;
                    }
                }
            }
            else
            {
                B.Userid = A.Userid;
                int temp = (int)A.SkinConductance;
                int temp2 = (int)((A.SkinConductance - temp) * 100);

                B.SkinConductance = temp + ((float)temp2 / 100);

                long temp3 = (int)A.SkinResistance;
                int temp4 = (int)((A.SkinResistance - temp3) * 100);

                B.SkinResistance = temp3 + ((float)temp4 / 100);

                int temp5 = (int)A.SkinConductanceVoltage;
                int temp6 = (int)((A.SkinConductanceVoltage - temp5) * 10000);

                B.SkinConductanceVoltage = temp5 + ((float)temp6 / 10000);
                B.MeasurementDate = DateTime.Now;
                if (B.SkinResistance < 1000)
                {
                    B.Status = "出汗異常，有立即性危險，應盡速送醫";
                    B.Score = 10;
                }
                else
                {
                    B.Status = "出汗正常";
                    B.Score = 0;
                }
            }

            using (GSR db = new GSR())
            {
                db.G3_Measure_GSR.Add(B);
                db.SaveChanges();
            }             

            return View(B);
        }
        public ActionResult GSRHistory()
        {
            ViewBag.Message = "健康量測.膚電反應.歷史紀錄";

            List<G3_Measure_GSR> list = new List<G3_Measure_GSR>();
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
                    }
                }
            }

            using (GSR db = new GSR())
            {
                var reuslt = db.G3_Measure_GSR.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_GSR History = new G3_Measure_GSR();
                        History.Userid = item.Userid;
                        History.SkinConductance = item.SkinConductance;
                        History.SkinResistance = item.SkinResistance;
                        History.SkinConductanceVoltage = item.SkinConductanceVoltage;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }
            return View(list);
        }

        public ActionResult GyroValues()
        {
            ViewBag.Message = "健康量測.運動反應";
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_GyroValues B = new G3_Measure_GyroValues();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }
            return View(B);
        }
        public ActionResult GyroValuesInput()
        {
            ViewBag.Message = "健康量測.運動反應.量測開始";
            return View();
        }
        public ActionResult GyroValuesOutput(GyroValuesIn A)
        {
            ViewBag.Message = "健康量測.運動反應.量測結果";
            G3_Measure_GyroValues B = new G3_Measure_GyroValues();
            G1_User_Account C = new G1_User_Account();

            if (A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;
                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }
                    B.Userid = C.id;
                    B.RawX = A.RawX;
                    B.RawY = A.RawY;
                    B.RawZ = A.RawZ;
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);
                    if (B.RawX == 0 && B.RawY == 0 && B.RawZ == 0)
                    {
                        B.Status = "沒有運動跡象，建議專員前往查看";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "正在運動";
                        B.Score = 0;
                    }
                }
            }
            else 
            {
                    B.Userid = A.Userid;
                    B.RawX = A.RawX;
                    B.RawY = A.RawY;
                    B.RawZ = A.RawZ;
                    B.MeasurementDate = DateTime.Now;
                    if (B.RawX == 0 && B.RawY == 0 && B.RawZ == 0)
                    {
                        B.Status = "沒有運動跡象，建議專員前往查看";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "正在運動";
                        B.Score = 0;
                    }
                
            }

            using (GyroValues db = new GyroValues())
            {
                db.G3_Measure_GyroValues.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }
        public ActionResult GyroValuesHistory()
        {
            ViewBag.Message = "健康量測.運動反應.歷史紀錄";

            List<G3_Measure_GyroValues> list = new List<G3_Measure_GyroValues>();
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
                    }
                }
            }

            using (GyroValues db = new GyroValues())
            {
                var reuslt = db.G3_Measure_GyroValues.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_GyroValues History = new G3_Measure_GyroValues();
                        History.Userid = item.Userid;
                        History.RawX = item.RawX;
                        History.RawY = item.RawY;
                        History.RawZ = item.RawZ;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }
            return View(list);
        }

        public ActionResult Temperature()
        {
            ViewBag.Message = "健康量測.溫度";
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_Temperature B = new G3_Measure_Temperature();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }
            return View(B);
        }

        public ActionResult TemperatureInput()
        {
            ViewBag.Message = "健康量測.溫度.量測開始";
            return View();
        }
        public ActionResult TemperatureOutput(TemperatureIn A)
        {
            ViewBag.Message = "健康量測.溫度.量測結果";
            G3_Measure_Temperature B = new G3_Measure_Temperature();
            G1_User_Account C = new G1_User_Account();

            if (A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;

                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }
                    B.Userid = C.id;
                    int temp = (int)A.Temperature;
                    int temp2 = (int)((A.Temperature - temp) * 100);
                    B.Temperature = temp + ((float)temp2 / 100);
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);
                    if (B.Temperature < 36 && B.Temperature >= 33)
                    {
                        B.Status = "輕度失溫";
                        B.Score = 6;
                    }
                    else if (B.Temperature < 33 && B.Temperature >= 30)
                    {
                        B.Status = "中度失溫";
                        B.Score = 8;
                    }
                    else if (B.Temperature < 30)
                    {
                        B.Status = "重度失溫";
                        B.Score = 10;
                    }
                    else if (B.Temperature >= 38.8)
                    {
                        B.Status = "重度發燒";
                        B.Score = 10;
                    }
                    else if (B.Temperature < 38.8 && B.Temperature >= 38.5)
                    {
                        B.Status = "中度發燒";
                        B.Score = 8;
                    }
                    else if (B.Temperature < 38.5 && B.Temperature >= 38)
                    {
                        B.Status = "輕度發燒";
                        B.Score = 6;
                    }
                    else
                    {
                        B.Status = "體溫正常";
                        B.Score = 0;
                    }
                }
            }
            else
            { 
                    B.Userid = A.Userid;
                    int temp = (int)A.Temperature;
                    int temp2 = (int)((A.Temperature - temp) * 100);
                    B.Temperature = temp + ((float)temp2 / 100);
                    B.MeasurementDate = DateTime.Now;
                    if (B.Temperature < 36 && B.Temperature >= 33)
                    {
                        B.Status = "輕度失溫";
                        B.Score = 6;
                    }
                    else if (B.Temperature < 33 && B.Temperature >= 30)
                    {
                        B.Status = "中度失溫";
                        B.Score = 8;
                    }
                    else if (B.Temperature < 30)
                    {
                        B.Status = "重度失溫";
                        B.Score = 10;
                    }
                    else if (B.Temperature >= 38.8)
                    {
                        B.Status = "重度發燒";
                        B.Score = 10;
                    }
                    else if (B.Temperature < 38.8 && B.Temperature >= 38.5)
                    {
                        B.Status = "中度發燒";
                        B.Score = 8;
                    }
                    else if (B.Temperature < 38.5 && B.Temperature >= 38)
                    {
                        B.Status = "輕度發燒";
                        B.Score = 6;
                    }
                    else
                    {
                        B.Status = "體溫正常";
                        B.Score = 0;
                    }
                
            }
            using (bodyTemperature db = new bodyTemperature())
            {
                db.G3_Measure_Temperature.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }
        public ActionResult TemperatureHistory()
        {
            ViewBag.Message = "健康量測.溫度.歷史紀錄";

            List<G3_Measure_Temperature> list = new List<G3_Measure_Temperature>();
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
                    }
                }
            }

            using (bodyTemperature db = new bodyTemperature())
            {
                var reuslt = db.G3_Measure_Temperature.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_Temperature History = new G3_Measure_Temperature();
                        History.Userid = item.Userid;
                        History.Temperature = item.Temperature;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }
            return View(list);
        }
        public ActionResult Pulse()
        {
            ViewBag.Message = "健康量測.脈搏";
            String strLoginID = User.Identity.Name;
            G1_User_Account C = new G1_User_Account();
            G3_Measure_Pulse B = new G3_Measure_Pulse();

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
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
                    B = History;
                }
            }
            return View(B);
        }

        public ActionResult PulseInput()
        {
            ViewBag.Message = "健康量測.脈搏.量測開始";
            return View();
        }
        public ActionResult PulseOutput(PulseIn A)
        {
            ViewBag.Message = "健康量測.脈搏.量測結果";
            G3_Measure_Pulse B = new G3_Measure_Pulse();
            G1_User_Account C = new G1_User_Account();

            if (A.InputController == 1)
            {
                String strLoginID = User.Identity.Name;

                using (AIPEntities18 db = new AIPEntities18())
                {
                    var reuslt = db.G1_User_Account.ToList();
                    foreach (var item in reuslt)
                    {
                        if (strLoginID == item.email)
                        {
                            C.id = item.id;
                        }
                    }
                    B.Userid = C.id;
                    B.Pulse = A.Pulse;
                    B.MeasurementDate = Convert.ToDateTime(A.date + " " + A.time);
                    if (B.Pulse < 60)
                    {
                        B.Status = "心跳過緩";
                        B.Score = 10;
                    }
                    else if (B.Pulse > 100)
                    {
                        B.Status = "心跳過速";
                        B.Score = 10;
                    }
                    else
                    {
                        B.Status = "心跳正常";
                        B.Score = 0;
                    }
                }
            }
            else
            {
                B.Userid = A.Userid;
                B.Pulse = A.Pulse;
                B.MeasurementDate = DateTime.Now;
                if (B.Pulse < 60)
                {
                    B.Status = "心跳過緩";
                    B.Score = 10;
                }
                else if (B.Pulse > 100)
                {
                    B.Status = "心跳過速";
                    B.Score = 10;
                }
                else
                {
                    B.Status = "心跳正常";
                    B.Score = 0;
                }
            }
            using (Pulse db = new Pulse())
            {
                db.G3_Measure_Pulse.Add(B);
                db.SaveChanges();
            }

            return View(B);
        }
        public ActionResult PulseHistory()
        {
            ViewBag.Message = "健康量測.脈搏.歷史紀錄";

            List<G3_Measure_Pulse> list = new List<G3_Measure_Pulse>();
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
                    }
                }
            }

            using (Pulse db = new Pulse())
            {
                var reuslt = db.G3_Measure_Pulse.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        G3_Measure_Pulse History = new G3_Measure_Pulse();
                        History.Userid = item.Userid;
                        History.Pulse = item.Pulse;
                        History.MeasurementDate = item.MeasurementDate;
                        History.Status = item.Status;
                        History.Score = item.Score;

                        list.Add(History);
                    }
                }
            }
            return View(list);
        }

        public JsonResult GetDonutDataABG()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }
            using (AIPEntities9 db = new AIPEntities9())
            {
                var reuslt = db.G3_Measure_ABG.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.ID),
                            value = item.SpO2
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDonutDataBloodGlucose()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }
            using (AIPEntities8 db = new AIPEntities8())
            {
                var reuslt = db.G3_Measure_BloodGlucose.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.ID),
                            value = item.GLU_AC
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDonutDataBloodPressure()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }
            using (AIPEntities7 db = new AIPEntities7())
            {
                var reuslt = db.G3_Measure_BloodPressure.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.ID),
                            value = item.SBP
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDonutDataBMI()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }

            using (AIPEntities11 db = new AIPEntities11())
            {
                var reuslt = db.G3_Measure_BMI.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.ID),
                            value = item.BMI
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDonutDataBreath()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
            G1_User_Account C = new G1_User_Account();
            String strLoginID = User.Identity.Name;
            int fine = 0;
            int abnormal = 0;
            int bad = 0;

            using (AIPEntities18 db = new AIPEntities18())
            {
                var reuslt = db.G1_User_Account.ToList();
                foreach (var item in reuslt)
                {
                    if (strLoginID == item.email)
                    {
                        C.id = item.id;
                    }
                }
            }

            using (AIPEntities25 db = new AIPEntities25())
            {
                var reuslt = db.G3_Measure_Air.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.Id),
                            value = item.Air
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDonutDataGSR()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }

            using (GSR db = new GSR())
            {
                var reuslt = db.G3_Measure_GSR.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.Id),
                            value = item.SkinConductance
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDonutDataGyroValues()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }

            using (GyroValues db = new GyroValues())
            {
                var reuslt = db.G3_Measure_GyroValues.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.Id),
                            value = item.RawX
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDonutDataTemperature()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }

            using (bodyTemperature db = new bodyTemperature())
            {
                var reuslt = db.G3_Measure_Temperature.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.Id),
                            value = item.Temperature
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDonutDataPulse()
        {
            List<DonutDataModel2> list = new List<DonutDataModel2>();
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
                    }
                }
            }

            using (Pulse db = new Pulse())
            {
                var reuslt = db.G3_Measure_Pulse.ToList();
                foreach (var item in reuslt)
                {
                    if (C.id == item.Userid)
                    {
                        DonutDataModel2 data = new DonutDataModel2()
                        {
                            Year = Convert.ToString(item.Id),
                            value = item.Pulse
                        };
                        list.Add(data);
                    }
                }
            }

            //最後回傳結果
            //為了可以直接從javascript中用Get取得值
            //JsonRequestBehavior.AllowGet 一定要記得寫
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
