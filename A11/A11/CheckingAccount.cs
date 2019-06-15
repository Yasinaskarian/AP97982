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
           => base.Credit((amount - TransactionFee));
   
        public override bool Debit(double amount)
               =>  base.Debit(amount+TransactionFee);
    }
}
