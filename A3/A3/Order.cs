using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        List<Product> _products;
        public List<Product> Products
        {
            set
            {
                this._products = value;
            }
            get
            {
                return this._products;
            }
        }
        bool _IsDElivered;
        public bool IsDelivered
        {
            set
            {
                this._IsDElivered = value;
            }
            get
            {
                return this._IsDElivered;
            }
        }

        public Order(List<Product> products, bool isDelivered)
        {
            Products = products;
            IsDelivered = isDelivered;
        }

        public float CalculateTotalPrice()
        {
            float Sum=0;
            for (int i = 0; i < Products.Count; i++)
                Sum += Products[i].Price;
                return Sum;
        }
    }
}