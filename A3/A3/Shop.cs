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
            List<City> cities=new List<City>();
            int counter = 0;
            for (int i = 0; i < Customers.Count; i++)
            {
                for(int j = 0; j < cities.Count; j++)
                {
                    counter = 0;
                    if (cities[j] == Customers[i].City)// اینجا بررسی میکنیم که اگر چند نفر در یک شهر مشخص زندگی کنند  
                    {
                        counter++;
                    }
                }
                if (counter == 0)
                {
                    cities.Add(Customers[i].City);
                }
            }

            return cities;
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
            List<Customer> ourCustomers = new List<Customer>();
            List<Customer> maxCustomers = new List<Customer>();
            Customer testCustomers ;
            for (int i = 0; i < this.Customers.Count; i++)
                ourCustomers.Add(this.Customers[i]);//اینجا مشتریامون رو ادد میکنیم
            for(int i = 0; i < ourCustomers.Count-2; i++)
            {//اینجا از روش بابل سورت مشتریامون رو از بیشترین به کمترین سفارش سورت میکنیم
                for (int j = 0;  j < ourCustomers.Count-2; j++)
                {
                    if(ourCustomers[j].Orders.Count< ourCustomers[j+1].Orders.Count)
                    {
                        testCustomers = ourCustomers[j+1];
                        ourCustomers[j+1] = ourCustomers[j];
                        ourCustomers[j] = testCustomers;
                    }
                }
            }
            for (int i = 0; i < ourCustomers.Count ; i++)
            {//اینجا احتمال اینکه چند مشتری بیشترین سفارش را داشته اند بررسی میکنیم
                if(ourCustomers[0].Orders.Count == ourCustomers[i].Orders.Count)
                {
                    maxCustomers.Add(ourCustomers[i]);
                }
            }
            return maxCustomers;
        }
    }
}