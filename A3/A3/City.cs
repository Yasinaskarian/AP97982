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
                    return this._name;
            }
        }

        public City(string name)
        {
            Name = name;
        }
    }
}