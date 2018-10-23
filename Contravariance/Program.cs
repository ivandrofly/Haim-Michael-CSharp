using System;

namespace Contravariance
{
    public delegate void Deposit(BusinessAccount ob, double sum);
    class Program
    {
        public static Deposit deposit;
        static void Main()
        {
            PremiumAccount account = new PremiumAccount();
            deposit = SimpleDeposit;
            deposit(account, 100);
            deposit = SpecialDeposit;
            deposit(account, 100);
            Console.WriteLine("balance is: " + account.Balance);
        }
        /// <summary>
        /// Since Business extend Private Account this would world just fine!
        /// </summary>
        /// <param name="ob">privateAccount or anything that extends it...</param>
        /// <param name="sum"></param>
        public static void SimpleDeposit(PrivateAccount ob, double sum)
        {
            Console.WriteLine("simple deposit " + sum);
            ob.Balance += (sum * 0.98);
        }

        /// <summary>
        /// In this case this is full matching with Deposit delegate...
        /// </summary>
        /// <param name="ob"></param>
        /// <param name="sum"></param>
        public static void SpecialDeposit(BusinessAccount ob, double sum)
        {
            Console.WriteLine("special deposit " + sum + "customer doesn't pay any commision");
            ob.Balance += sum;
        }

    }

    class PrivateAccount
	{
        public double Balance { get; set; }
	}
    class BusinessAccount : PrivateAccount{}
    class  PremiumAccount : BusinessAccount{};
}
