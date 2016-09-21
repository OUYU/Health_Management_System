using AIPProject01.ViewModels;
using AIPProject01.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AIPProject01.Controllers
{
    public class MeasureAPIController : Controller
    {
        //
        // GET: /MeasureAPI/

        public ActionResult Index()
        {
            return View();
        }

        public void BloodGlucoseAPI(BloodGlucoseAPI A)
        {
            G3_Measure_BloodGlucose B = new G3_Measure_BloodGlucose();

                B.Userid = A.Userid;
                B.GLU_AC = A.GLU_AC;
                B.MeasurementDate = DateTime.Now;
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

            using (AIPEntities8 db = new AIPEntities8())
            {
                db.G3_Measure_BloodGlucose.Add(B);
                db.SaveChanges();
            }
        }

        public void BreathAPI(BreathAPI A)
        {
            G3_Measure_Air B = new G3_Measure_Air();

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
            using (AIPEntities25 db = new AIPEntities25())
            {
                db.G3_Measure_Air.Add(B);
                db.SaveChanges();
            }
        }

        public void BreathAPI(GSRAPI A)
        {
            G3_Measure_GSR B = new G3_Measure_GSR();

            B.Userid = A.Userid;
            int temp = (int)A.SkinConductance;
            int temp2 = (int)((A.SkinConductance - temp) * 100);

            B.SkinConductance = temp + ((float)temp2 / 100);

            long temp3 = (int)A.SkinResistance;
            int temp4 = (int)((A.SkinResistance - temp) * 100);

            B.SkinResistance = temp3 + ((float)temp4 / 100);

            int temp5 = (int)A.SkinConductanceVoltage;
            int temp6 = (int)((A.SkinConductanceVoltage - temp) * 10000);

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
            using (GSR db = new GSR())
            {
                db.G3_Measure_GSR.Add(B);
                db.SaveChanges();
            }
        }
        public void GyroValuesAPI(GyroValuesAPI A)
        {
            G3_Measure_GyroValues B = new G3_Measure_GyroValues();

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

            using (GyroValues db = new GyroValues())
            {
                db.G3_Measure_GyroValues.Add(B);
                db.SaveChanges();
            }
        }
        public void TemperatureOutput(TemperatureAPI A)
        {
            G3_Measure_Temperature B = new G3_Measure_Temperature();
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
            using (bodyTemperature db = new bodyTemperature())
            {
                db.G3_Measure_Temperature.Add(B);
                db.SaveChanges();
            }
        }
        public void PulseOutput(PulseAPI A)
        {
            G3_Measure_Pulse B = new G3_Measure_Pulse();
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
            using (Pulse db = new Pulse())
            {
                db.G3_Measure_Pulse.Add(B);
                db.SaveChanges();
            }
        }
    }
}
