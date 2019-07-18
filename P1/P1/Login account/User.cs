using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Login_account
{
    class User:IEquatable<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string u, string p)
        {
            Username = u;
            Password = p;
        }
        public static bool operator ==(User obj1, User obj2)
            =>((obj1.Username == obj2.Username) && (obj1.Password == obj2.Password));
        public static bool operator !=(User obj1, User obj2)
            => ((obj1.Username != obj2.Username) && (obj1.Password != obj2.Password));

        public bool Equals(User other)
           => (this.Username == other.Username) && (this.Password == other.Password);
        
    }
}
