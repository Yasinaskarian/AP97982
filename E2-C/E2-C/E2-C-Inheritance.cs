namespace E2
{
    public abstract class Person
    {
        public virtual string Name { get; set; }
        public bool IsFemale { get; set; }
        public Person(string name = null, bool isFemale = false)
        {
            if (isFemale == true)
            {
                this.Name = $"خانم {name}";
            }
            else
                this.Name = $"آقای {name}";

            this.IsFemale = isFemale;
        }
        public abstract int LunchRate { get; }

    }

    public class Student : Person
    {
        public  string N { get; set; }
        public override int LunchRate => 2000;
        public Student(string name, bool isFemale)
        {
            if (isFemale == true)
            {
                this.Name = $"خانم {name}";
            }
            else
                this.Name = $"آقای {name}";
            this.N = this.Name;
            this.IsFemale = isFemale;
        }

    }

    public class Employee : Person
    {
        public override int LunchRate => 5000;
        public string N { get; set; }
        public Employee(string name = null, bool isFemale = false)
        {
            if (isFemale == true)
            {
                this.Name = $"خانم {name}";
            }
            else
                this.Name = $"آقای {name}";
            this.N = this.Name;
            this.IsFemale = isFemale;
        }

        public virtual int CalculateSalary(int v)
        {
            return v * 5000;
        }
    }

    public class Teacher: Employee
    {
        public override int LunchRate => 10000;
        public string N1 { get; set; }
        public Teacher(string name, bool isFemale)
        {
            this.Name = $"استاد {name}";
            this.N1 = this.Name;
            this.IsFemale = isFemale;
        }
        public override int CalculateSalary(int v)
        {
            return v * 20000;
        }
    }
}