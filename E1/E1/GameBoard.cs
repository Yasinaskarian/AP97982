using System;
using System.Collections.Generic;
using System.Linq;
using E1.Interfaces;
using Environment = E1.Enums.Environment;

namespace E1.Classes
{
    public class GameBoard<_Type> where  _Type : IAnimal
    {
        public List<IAnimal> Animals { get; set; }
        public GameBoard(IEnumerable<IAnimal> animals)
        {
            Animals = animals.ToList();
        }

        

        public string[] MoveAnimals()
        {
            List<string> animal = new List<string>();
			for(int i = 0; i < Animals.Count; i++)
            {
                animal.Add(Animals[i].Move(Environment.Air));
                animal.Add(Animals[i].Move(Environment.Land));
                animal.Add(Animals[i].Move(Environment.Watery));
            }
            return animal.ToArray();
        }
    }
}