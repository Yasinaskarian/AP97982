using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Crow: IAnimal, IFlyable
    {
        public string Name { get ; set ; }
        public int Age { get ; set; }
        public double SpeedRate { get ; set ; }
        public double Health { get; set; }
        public Crow(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            Health = health;
            SpeedRate = speedRate;
        }

        

        public string EatFood()
        {
            string eatFood = $"{Name} is a Crow and is eating";
            return eatFood; 
        }

        public string Fly()
        {
            string fly = $"{Name} is a Crow and is flying";
            return fly;
        }

        public string Move(Environment E)
        {
            if (E == Environment.Air)
            {
                string move = $"{Name} is a Crow and is flying";
                return move;
            }
            string move1 = $"{Name} is a Crow and can't move in {E} environment";
            return move1;
        }

        public string Reproduction(IAnimal animal)
        {
            string reproduction = $"{Name} is a Crow and reproductive with {animal.Name}";
            return reproduction;
        }
    }
}