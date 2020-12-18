using CheckoutRepositories;
using CheckoutServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CheckoutApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IScanService, ScanService>()
            .AddSingleton<IDataStore, ItemsDataStore>()
            .BuildServiceProvider();

            var scanService = serviceProvider.GetService<IScanService>();

            Console.WriteLine("Welcome to Checkout!");
            Console.WriteLine("Scan Your Items");
            Console.WriteLine("Type 'sum' to sum goods");

            string item;

            for(; ;)
            {
                Console.WriteLine("Item name:");

                item = Console.ReadLine();

                if (item.ToLower() == "sum")
                {
                    break;
                }

                try
                {
                    scanService.Scan(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            var total = scanService.Total();
            Console.WriteLine($"The total is {total}");
        }
    }
}
