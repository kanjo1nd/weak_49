using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Tasks
{
    internal class thread    
    {
        private string number = "0123456789";
        private object Locker = new();
        private string result = "";
        private Random random = new Random();

        public async Task Run() 
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                int taskIndex = i + 1;
                tasks.Add(Task.Run(async () => await CalcOneDigit(taskIndex)));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("------------------");
            Console.WriteLine($"total: \"{result}\"");
        }

        private async Task CalcOneDigit(int threadIndex)
        {
            await Task.Delay(random.Next(100, 300));

            char digit;

            lock (Locker)
            {
                if (number.Length > 0)
                {
                    int index = random.Next(0, number.Length);
                    digit = number[index];
                    number = number.Remove(index, 1);
                    result += digit;

                    Console.WriteLine($"thread {threadIndex}: \"{result}\"");
                }
            }
        }
    }

    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    thread threadExample = new thread();
        //    Task task = threadExample.Run();
        //    task.Wait();
        //}
    }
}
