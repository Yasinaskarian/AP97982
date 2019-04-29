using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Submarine: ISwimable
    {
        public string Model { set; get; }
        public double MaxDepthSupported { set; get; }
        public double SpeedRate { get ; set ; }

        public Submarine(string model, double maxDepthSupported, double speedRate)
        {
            Model = model;
            MaxDepthSupported = MaxDepthSupported;
            SpeedRate = speedRate;
        }

        public string Swim()
        {
            string swim = $"{Model} is a Submarine and is swimming in {MaxDepthSupported} meter depth";
            return swim;
        }
    }
}