using E1.Enums;

namespace E1.Interfaces
{
    public interface IAnimal
    {
        string Name { set; get; }
        int Age { set; get; }
        string EatFood();
        string Reproduction(IAnimal animal);
        string Move(Environment E);
     
    }
}