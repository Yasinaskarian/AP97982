using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class Account
    {
        private double _balance;
        public double Balance
        {
            get
            {

                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public Account(double balance)
        {
            if (balance < 0)
            {
                balance = 0;
                Console.WriteLine($"Initial balance is invalid. Setting balance to 0.");
            }
            else
             Balance = balance;
        }
        public virtual void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Credit amount must be positive");
            }
            Balance += amount;
        }
        public virtual bool Debit(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                
                Console.WriteLine($"Debit amount exceeded account balance.");
                return false;
            }
        }
    }
}
