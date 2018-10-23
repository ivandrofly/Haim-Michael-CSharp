using System;

namespace Delegates_Contravariance
{
    public delegate void Deposit(BusinessAccount ob, double sum);

    public class PrivateAccount
    {
        public double Balance { get; set; }
    }

    public class BusinessAccount : PrivateAccount { }

    public class PremiumAccount : BusinessAccount { }

    internal class Program
    {
        public static Deposit deposit;

        public static void SimpleDeposit(PrivateAccount ob, double sum)
        {
            Console.WriteLine("Simple deposit " + sum);
            ob.Balance += (sum * 0.98);
        }

        public static void SpecialDeposit(BusinessAccount ob, double sum)
        {
            Console.WriteLine("Speicial deposit: " + sum + " customer doesn't pay any commision");
            ob.Balance += sum;
        }

        private static void Main()
        {
            PremiumAccount account = new PremiumAccount();
            deposit = SimpleDeposit;
            deposit(account, 100);
            deposit = SpecialDeposit;
            deposit(account, 100);
            Console.WriteLine("Balance is " + account.Balance);
        }
    }
}