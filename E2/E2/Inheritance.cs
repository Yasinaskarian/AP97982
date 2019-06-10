using System;

namespace E2
{
    
    public abstract class Person
    {
        public virtual string Name { get; set; }
        public bool IsFemale { get; set; }
        public Person(string name=null, bool isFemale=false)
        {
            if (isFemale == true)
            {
                this.Name = $"خانم {name}";
            }
            else
                this.Name = $"آقای {name}";

            this.IsFemale = isFemale;
        }
        public abstract int LunchRate { get;  }
        

    }

    public class Student : Person
    {
        public string Name { get; set; }
        public bool IsFemale { get; set; }
        public override int LunchRate => 2000;
        //public Student(string name, bool isFemale)
        //    : base(name, isFemale);
        public Student(string name, bool isFemale)
            :base(name,isFemale)
        {
            //if (isFemale == true)
            //{
            //    this.Name = $"خانم {name}";
            //}
            //else
            //    this.Name = $"آقای {name}";

            //this.IsFemale = isFemale;
        }

    }

    public class Employee : Person
    {
        public override int LunchRate => 5000;
        public string Name { get; set; }
        public bool IsFemale { get; set; }
        //public Student(string name, bool isFemale)
        //    : base(name, isFemale);
        public Employee(string name, bool isFemale)
             : base(name, isFemale)
        {
            //if (isFemale == true)
            //{
            //    this.Name = $"خانم {name}";
            //}
            //else
            //    this.Name = $"آقای {name}";

            //this.IsFemale = isFemale;
            //Name = this.Name;
        }

        public virtual int CalculateSalary(int v)
        {
           return v*5000 ;
        }
    }

    public class Teacher : Employee
    {
        public override int LunchRate => 10000;
        public string Name { get; set; }
        public bool IsFemale { get; set; }
        //public Student(string name, bool isFemale)
        //    : base(name, isFemale);
        public Teacher(string name, bool isFemale) 
            :base(name,isFemale)
        {
            if (isFemale == true)
            {
                this.Name = $"استاد {name}";
            }
            else
                this.Name = $"استاد {name}";

            this.IsFemale = isFemale;
            Name = this.Name;
        }
        public override int CalculateSalary(int v)
        {
            return v * 20000;
        }
    }
}