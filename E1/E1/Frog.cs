using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Frog:IAnimal,ISwimable,IWalkable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double SpeedRate { get; set; }
        public double Health { get; set; }
        public Frog(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

       

        public string EatFood()
        {
            string eatFood = $"{Name} is a Frog and is eating";
            return eatFood;
        }

        public string Move(Environment E)
        {
            if (E == Environment.Air)
            {
                string move = $"{Name} is a Frog and can't move in {E} environment";
                return move;
            }
            if (E == Environment.Watery)
            {
                string move1 = $"{Name} is a Frog and is swimming";
                return move1;
            }

            string move2 = $"{Name} is a Frog and is walking";
            return move2;
        }

        public string Reproduction(IAnimal animal)
        {
            string reproduction = $"{Name} is a Frog and reproductive with {animal.Name}";
            return reproduction;
        }

        public string Swim()
        {
            string move1 = $"{Name} is a Frog and is swimming";
            return move1;
        }

        public string Walk()
        {
            string move2 = $"{Name} is a Frog and is walking";
            return move2;
        }
    }
}