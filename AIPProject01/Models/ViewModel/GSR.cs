namespace AIPProject01.ViewModels
{
    public class GSRIn
    {
        public int Userid { get; set; }
        public float SkinConductance { get; set; }
        public float SkinResistance { get; set; }
        public float SkinConductanceVoltage { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public int InputController { get; set; }
    }

    public class GSRAPI
    {
        public int Userid { get; set; }
        public float SkinConductance { get; set; }
        public float SkinResistance { get; set; }
        public float SkinConductanceVoltage { get; set; }
    }
}