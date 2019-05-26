using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
   public class CheckingAccount: Account
    {
        public double TransactionFee { get; set; }
        public CheckingAccount(double balance,double transactionFee)
            :base(balance)
        {
            TransactionFee = transactionFee;
        }
        public override void Credit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Credit amount must be positive");
            }
            Balance += (amount-TransactionFee);
        }
        public override bool Debit(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= (amount+TransactionFee);
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
