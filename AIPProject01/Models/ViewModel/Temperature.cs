namespace AIPProject01.ViewModels
{
    public class TemperatureIn
    {
        public int Userid { get; set; }
        public float Temperature { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int InputController { get; set; }
    }

    public class TemperatureAPI
    {
        public int Userid { get; set; }
        public float Temperature { get; set; }
    }
}