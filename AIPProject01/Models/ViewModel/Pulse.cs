namespace AIPProject01.ViewModels
{
    public class PulseIn
    {
        public int Userid { get; set; }
        public int Pulse { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int InputController { get; set; }
    }

    public class PulseAPI
    {
        public int Userid { get; set; }
        public int Pulse { get; set; }
    }
}