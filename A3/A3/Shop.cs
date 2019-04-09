using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Shop
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
        List<Customer> _customers;
        public List<Customer> Customers
        {
            set
            {
                this._customers = value;
            }
            get
            {
                return this._customers;
            }
        }

        public Shop(string name, List<Customer> customers)
        {
            Name = name;
            Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> city=new List<City>();
            int Counter = 0;
            for (int i = 0; i < Customers.Count; i++)
            {
                for(int j = 0; j < city.Count; j++)
                {
                    Counter = 0;
                    if (city[j] == Customers[i].City)
                    {
                        Counter++;
                    }
                }
                if (Counter == 0)
                {
                    city.Add(Customers[i].City);
                }
            }

            return city;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customer = new List<Customer>();
            for (int i = 0; i < Customers.Count; i++)
            {
                if (city == Customers[i].City)
                {
                    customer.Add(Customers[i]);
                }
            }
                

            return customer;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<Customer> MaxCustemers = new List<Customer>();
            List<Customer> MaxCustemers1 = new List<Customer>();
            Customer TestCustemer ;
            for (int i = 0; i < Customers.Count; i++)
                MaxCustemers.Add(Customers[i]);
            for(int i = 0; i < MaxCustemers.Count-2; i++)
            {
                for (int j = 0;  j < MaxCustemers.Count-2; j++)
                {
                    if(MaxCustemers[j].Orders.Count< MaxCustemers[j+1].Orders.Count)
                    {
                        TestCustemer = MaxCustemers[j+1];
                        MaxCustemers[j+1] = MaxCustemers[j];
                        MaxCustemers[j] = TestCustemer;
                    }
                }
            }
            for (int i = 0; i < MaxCustemers.Count ; i++)
            {
                if(MaxCustemers[0].Orders.Count == MaxCustemers[i].Orders.Count)
                {
                    MaxCustemers1.Add(MaxCustemers[i]);
                }
            }

                
            return MaxCustemers1;
        }
    }
}