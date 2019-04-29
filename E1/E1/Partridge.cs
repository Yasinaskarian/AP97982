using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Partridge:IAnimal,IWalkable,IFlyable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double SpeedRate { get; set; }
        public double Health { get; set; }
        public Partridge(string name, int age, double speedRate, double health)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

       
        public string EatFood()
        {
            string eatFood = $"{Name} is a Partridge and is eating";
            return eatFood;
        }

        public string Fly()
        {
            string fly = $"{Name} is a Partridge and is flying";
            return fly;
        }

        public string Move(Environment E)
        {
            if (E == Environment.Watery)
            {
                string move = $"{Name} is a Partridge and can't move in {E} environment";
                return move;
            }
            if (E == Environment.Air)
            {
                string move1 = $"{Name} is a Partridge and is flying";
                return move1;
            }

            string move2 = $"{Name} is a Partridge and is walking";
            return move2;
        }

        public string Reproduction(IAnimal animal)
        {
            string reproduction = $"{Name} is a Partridge and reproductive with {animal.Name}";
            return reproduction;
        }

        public string Walk()
        {
            string move2 = $"{Name} is a Partridge and is walking";
            return move2;
        }
    }
}