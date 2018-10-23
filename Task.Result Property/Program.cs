using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Result_Property
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

        private static double CalculateAccountsTotal()
        {
            double total = 0;
            foreach (Account account in accounts)
            {
                Thread.Sleep(500);
                total += account.Balance;
            }
            return total;
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

        // https://www.youtube.com/watch?v=RpXm4sDd4Ek&index=55&list=PLDA1E3A69F4FCF7F0
        // playlist: https://www.youtube.com/playlist?list=PLDA1E3A69F4FCF7F0
        private static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Task createingAccountTask = new Task(CreateAccounts);
            Task<double> CalculateTotalTask = new Task<double>(CalculateAccountsTotal);
            createingAccountTask.Start();
            Console.WriteLine("Creating accounts...");
            createingAccountTask.Wait(); // wait it to finish
            watch.Stop();

            CalculateTotalTask.Start();
            Console.WriteLine("Calculating total...");
            CalculateTotalTask.Wait();
            double result = CalculateTotalTask.Result;
            Console.WriteLine("The result is: {0}, {1}.", result, watch.Elapsed);
            Console.ReadLine();
            // Note: don't use await/result when dealing with UI use await
        }
    }
}