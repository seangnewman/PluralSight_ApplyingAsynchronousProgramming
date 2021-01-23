using System;
using System.Threading;
using System.Threading.Tasks;

namespace StockAnalyzer.AttachedDetached
{
    class Program
    {
        static async  Task Main(string[] args)
        {

            Console.WriteLine("Starting");

            // Returns a Task of a task of string 
            //var task =  Task.Factory.StartNew( async () => {
            //    await Task.Delay(2000);
            //    return "Pluralsight";
            // });
            //var result = await await task;



            // Returns a task of string == Task.Run()
            // Task.Run unwraps the task
            var task = Task.Factory.StartNew(async () => {
                await Task.Delay(2000);
                return "Pluralsight";
            }).Unwrap();
            var result = await task;
            
            Console.WriteLine("Completed");
            Console.ReadLine();

        }
    }
}
