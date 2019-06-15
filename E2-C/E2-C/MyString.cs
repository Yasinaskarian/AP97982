using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2_C
{
    public class MyString
    {
        public string Name { get; set; }
        public MyString(string name)
        {
            this.Name = name;
        }

        public static bool operator ==(MyString m, string s)
             => m.Name == s;
        public static bool operator !=(MyString m, string s)
             => m.Name == s;

        public static explicit operator MyString(string v)
        {
            return new MyString(v);
        }

        public static explicit operator string(MyString v)
        {
            return v.Name;
        }
        public static MyString operator ++(MyString m)
        {
            m.Name = m.Name.ToUpper();
            return m;
        }
        public static MyString operator --(MyString m)
        {
            m.Name = m.Name.ToLower();
            return m;
        }
        public override string ToString()
        {
            string s = this.Name;
            return s;
        }
        public override bool Equals(object obj)
        {
            string s=null;
           if (obj is string)
            {
                s= obj as string;
            }
            return (s == this.Name);
        }
    }
}
