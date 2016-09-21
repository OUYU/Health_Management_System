namespace AIPProject01.ViewModels
{
    public class GyroValuesIn
    {
        public int Userid { get; set; }
        public int RawX { get; set; }
        public int RawY { get; set; }
        public int RawZ { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int InputController { get; set; }
    }

    public class GyroValuesAPI
    {
        public int Userid { get; set; }
        public int RawX { get; set; }
        public int RawY { get; set; }
        public int RawZ { get; set; }
    }
}
