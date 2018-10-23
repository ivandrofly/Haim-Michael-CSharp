using System;
using System.ComponentModel;
using System.Threading;

namespace Background_Worker
{
    class Program
    {
        static BackgroundWorker worker1 = new BackgroundWorker();
        static BackgroundWorker worker2 = new BackgroundWorker();
        static void Main()
        {
            // these methods will be called and run work asynchronous
            worker1.DoWork += DoSomething;
            worker1.DoWork += DoBlaBla;
            worker2.DoWork += DoSomething;
            worker2.DoWork += DoBlaBla;

            worker1.RunWorkerCompleted += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Worker #1 is done!");
                //Console.ReadLine(); // Wait here!
            };
            worker1.ProgressChanged += (object sender, ProgressChangedEventArgs e) =>
            {
                Console.WriteLine("{0}%", e.ProgressPercentage);
            };
            worker2.RunWorkerCompleted += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Worker #2 is done!");
                //Console.ReadLine(); // Wait here!
            };
            worker2.ProgressChanged += (object sender, ProgressChangedEventArgs e) =>
            {
                Console.WriteLine("{0}%", e.ProgressPercentage);
            };
            worker1.WorkerReportsProgress = true;
            worker1.RunWorkerAsync("Bla bla bla"); // call method DoSomething then BoBlabla aynchronous

            worker2.WorkerReportsProgress = true;
            worker2.RunWorkerAsync("Ivandro Ismael");

            Console.ReadLine();
        }

        static void DoSomething(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker obj = sender as BackgroundWorker;
            Console.WriteLine("=================================================");
            Console.WriteLine("Do something: " + e.Argument);
            Console.WriteLine("Sent from: " + sender);
            Console.WriteLine("=================================================");
            obj.ReportProgress(50, "Completed");
            System.Threading.Thread.Sleep(5000);
        }
        static void DoBlaBla(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("=================================================");
            Console.WriteLine("Bla bla bla... " + e.Argument);
            Console.WriteLine("Sent from: " + (sender as BackgroundWorker).ToString());
            Console.WriteLine("=================================================");
            ((BackgroundWorker)sender).ReportProgress(100, "Progress completed successfully!");
        }
    }
}
