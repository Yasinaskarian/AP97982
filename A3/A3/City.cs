using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class City
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
                //int num = 0;
                //char[] CharOfCity = this._name.ToCharArray();
                //foreach(char s in CharOfCity)
                //{
                //    if (s > 0 || s<0)
                //        num++;
                //}
                //if(num==0)
                    return this._name;
                //else
                ////throw new Exception("wrong city");
            }
        }

        public City(string name)
        {
            Name = name;
        }
    }
}