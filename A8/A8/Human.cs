using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace A8
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public float Height { get; set; }
        public Human(string firstname, string lastname, DateTime birthdate, float height)
        {
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Height = height;
        }
        public static Human operator +(Human h,object o)
        {
            Human Person = new Human( "ChildFirstName", "ChildLastName", DateTime.Today, 30);
            return Person;
        }
        public static bool operator >(Human h1,Human h2)
        {
            return (h1.BirthDate < h2.BirthDate) ;
        }
        public static bool operator <(Human h1, Human h2)
        {
            return (h1.BirthDate > h2.BirthDate);
        }
        public static bool operator >=(Human h1, Human h2)
        {
            return (h1.BirthDate < h2.BirthDate || h1.BirthDate == h2.BirthDate);
        }
        public static bool operator <=(Human h1, Human h2) 
        {
            return (h1.BirthDate > h2.BirthDate || h1.BirthDate == h2.BirthDate);
        }
        public static bool operator ==(Human h1, Human h2)
        {
            return (h1.BirthDate == h2.BirthDate);
        }
        public static bool operator !=(Human h1, Human h2)
        {
            return (h1.BirthDate != h2.BirthDate);
        }
        public override bool Equals(object obj)
        {
            Human Person = obj as Human;
            if (Person is null)
                return false;
            return (
                Person.FirstName == this.FirstName &&
                Person.LastName == this.LastName &&
                Person.BirthDate == this.BirthDate &&
                Person.Height == this.Height
            );
           
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ BirthDate.GetHashCode() ^ Height.GetHashCode();
        }

    }
}