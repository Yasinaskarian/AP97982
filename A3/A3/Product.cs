using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Product
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
        float _price;
        public  float Price
        {
            set
            {
                this._price = value;
            }
            get
            {
                return this._price;
            }
        }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}