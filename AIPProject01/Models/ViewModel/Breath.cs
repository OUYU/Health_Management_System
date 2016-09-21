namespace AIPProject01.ViewModels
{
    public class BreathIn
    {
        public int Userid { get; set; }
        public int Air { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int InputController { get; set; }
    }

    public class BreathAPI
    {
        public int Userid { get; set; }
        public int Air { get; set; }
    }
}