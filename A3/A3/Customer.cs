using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
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
        City _city;
        public City City
        {
            set
            {
                this._city = value;
            }
            get
            {
                return this._city;
            }
        }
        List<Order> _Oreders;
        public List<Order> Orders
        {
            set
            {
                this._Oreders = value;
            }
            get
            {
                return this._Oreders;
            }
        }

        public Customer(string name, City city, List<Order> orders)
        {
            Name = name;
            City = city;
            Orders = orders;
        }

        public Product MostOrderedProduct()
        {
            int Counter=0;
            int MaxCounter = 0;
                List<Product> product = new List<Product>();
            for (int i = 0; i < Orders.Count; i++)
            {
                for (int j = 0; j < Orders[i].Products.Count; j++)
                {
                    product.Add(Orders[i].Products[j]);
                }
            }

            Product MaxOreder = new Product("name",0);
            for (int i = 0; i < product.Count; i++)
            {
                Counter = 0;
                for(int j = i; j < product.Count; j++)
                {
                    if (product[i].Name== product[j].Name)
                        Counter++;
                }
                if (Counter > MaxCounter)
                {
                    MaxOreder = product[i];
                    MaxCounter = Counter;
                }
            }

            return MaxOreder;
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> Undelivered=new List<Order>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].IsDelivered == false)
                    Undelivered.Add(Orders[i]);
            }
            return Undelivered;
        }
    }
}