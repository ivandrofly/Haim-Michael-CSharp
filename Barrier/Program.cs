using System;
using System.Collections.Generic;
using System.Threading;

namespace BarrierDemo
{
    internal class Account
    {
        public Account(double sum)
        {
            Balance = sum;
        }

        public double Balance { get; set; }

        public int CalcCreaditPoint()
        {
            Thread.Sleep(400);
            return (int)Balance / 10;
        }

        public double CalcUBalance(double currenty)
        {
            Thread.Sleep(400);
            return currenty * Balance;
        }
    }

    internal class Program
    {
        public static List<Account> accounts = new List<Account>();
        public static double balanceTotal = 0;
        public static double creaditPointTotal = 0;
        public static Barrier myBarrier = new Barrier(3); // three signals will be required in order to proceed

        private static void CalculateAccountsTotal()
        {
            double total = 0;
            foreach (Account account in accounts)
            {
                Thread.Sleep(500);
                total += account.Balance;
            }
            balanceTotal = total;
            Console.WriteLine("Signal send: " + Thread.CurrentContext.ContextID);
            myBarrier.SignalAndWait(); // Can be signal 1/2
        }

        private static void CalculateTotalCreditPoints()
        {
            double total = 0;
            foreach (Account account in accounts)
            {
                Thread.Sleep(500);
                total += account.CalcCreaditPoint();
            }
            creaditPointTotal = total;
            Console.WriteLine("Signal send: " + Thread.CurrentContext.ContextID);
            myBarrier.SignalAndWait(); // Can be signal 2/1
        }

        private static void CreateAccounts()
        {
            double[] sums = { 12000, 8000, 10000, -400, 5400, 8000, 2240 };
            foreach (double sum in sums)
            {
                accounts.Add(new Account(sum));
                Thread.Sleep(200);
            }
        }

        private static void Main(string[] args)
        {
            CreateAccounts();
            new Thread(CalculateAccountsTotal).Start();
            new Thread(CalculateTotalCreditPoints).Start();
            // This will wai all the other running thread to call there method SignalWait as well since it's 3 so wait for 3 to call SignalWait
            Console.WriteLine("Signal send: " + Thread.CurrentContext.ContextID);
            myBarrier.SignalAndWait(); // after this will remains 2 more signals to be sent
            Console.WriteLine("Total balance: " + balanceTotal);
            Console.WriteLine("Total credit points: " + creaditPointTotal);
            Console.ReadLine();
        }
    }
}