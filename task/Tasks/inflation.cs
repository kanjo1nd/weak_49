using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Tasks
{
    internal class inflation
    {

        private double totalInflation = 0.0;
        private object locker = new();
        private Random random = new Random();

        public async Task Run()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 1; i <= 12; i++)
            {
                int month = i;
                tasks.Add(Task.Run(() => CalculateMonthlyInflation(month)));
            }

            await Task.WhenAll(tasks);
        }

        private void CalculateMonthlyInflation(int month)
        {
            Thread.Sleep(random.Next(100, 500));

            double monthlyInflation = random.NextDouble() * 2.0;

            lock (locker)
            {
                totalInflation += monthlyInflation;
                Console.WriteLine($"Month {month}:  {monthlyInflation:F2}% : {totalInflation:F2}%");
            }
        }
    }

    internal class program
    {
        static void Main(string[] args) {

            inflation calculator = new inflation();
            Task task = calculator.Run();
            task.Wait();

        }
    }
}
