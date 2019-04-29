using System;
using E1.Enums;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes.Animals
{
    public class Snake: IAnimal,ICrawlable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double SpeedRate { get; set; }
        public double Health { get; set; }
        public Snake(string name, int age, double health, double speedRate)
        {
            Name = name;
            Age = age;
            SpeedRate = speedRate;
            Health = health;
        }

      

        public string Crawl()
        {
            string crawl=$"{Name} is a Snake and is crawling";
            return crawl;
        }

        public string EatFood()
        {
            string eatFood = $"{Name} is a Snake and is eating";
            return eatFood;
        }

        public string Move(Environment E)
        {
            if (E == Environment.Land)
            {
                string move = $"{Name} is a Snake and is crawling";
                return move;
            }
             string move1 = $"{Name} is a Snake and can't move in {E} environment";
            return move1;
        }

        public string Reproduction(IAnimal animal)
        {
            string reproduction = $"{Name} is a Snake and reproductive with {animal.Name}";
            return reproduction;
        }
    }
}