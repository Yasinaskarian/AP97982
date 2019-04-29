namespace E1B
{
    public interface IHasAge
    {
       int GetAge();
    }
    public class Human: IHasAge
    {
        string _name;
        public string Name
        {
            set
            {
                this._name = value;
            }
            get
            {
                return this._name;
            }
        }
        int _age;
        public int Age
        {
            set
            {
                this._age = value;
            }
            get
            {
                return this._age;
            }
        }
        public Human(string name,int age)
        {
            Name = name;
            Age = age;
        }

       public int GetAge()
        {
            return Age;
        }
    }
}