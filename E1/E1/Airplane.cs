using E1.Interfaces;

namespace E1.Classes.Vehicles
{
    public class Airplane: IFlyable
    {
        public double SpeedRate { get; set; }
        public string Model;
        public Airplane(double speedRate, string model)
        {
            SpeedRate = speedRate;
            Model = model;
        }

       

        public string Fly()
        {
            string fly = $"{Model} with {SpeedRate} speed rate is flying";
            return fly;
        }
    }
}