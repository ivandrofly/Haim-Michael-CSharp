using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Task_ContinueWith
{
    class Account
    {
        public double Balance { get; set; }
        public Account(double sum)
        {
            Balance = sum;
        }
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
    class Program
    {
        public static List<Account> accounts = new List<Account>();
        private static void PrintAccountTotal()
        {
            double total = 0;
            foreach (Account account in accounts)
            {
                total += account.Balance;
            }
            Console.WriteLine(total);
        }
        public static void CreateAccounts()
        {
            double[] sums = { 12000, 8000, 10000, -400, 5400, 8000, 2240 };
            foreach (double sum in sums)
            {
                accounts.Add(new Account(sum));
                Thread.Sleep(200);
            }
        }
        static void Main(string[] args)
        {
            Task creatingAccountsTask = new Task(CreateAccounts);
            // Note: this printTotalTask isn't required "can be removed and the application will still works just fine"
            Task printTotalTask = creatingAccountsTask.ContinueWith((_) => PrintAccountTotal());
            // printTotalTask.Wait(); this will cause a problem 'cause the creatingAccountsTask will never run so
            // the PrintAccountTotal won't run either because it's the continuation of creatingAccountsTask!
            creatingAccountsTask.Start();
            Console.ReadLine();
        }
    }

}
