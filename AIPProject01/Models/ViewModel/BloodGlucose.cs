namespace AIPProject01.ViewModels
{
    public class BloodGlucoseIn
    {
        public int Userid { get; set; }
        public string MeasureTime { get; set; }
        public int GLU_AC { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }

    public class BloodGlucoseAPI
    {
        public int Userid { get; set; }
        public int GLU_AC { get; set; }
    }
}

