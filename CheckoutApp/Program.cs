using CheckoutRepositories;
using CheckoutServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

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
            Console.WriteLine("Type 'done' to sum goods");

            string name;
            var items = new List<string>();

            do
            {
                Console.WriteLine("Item name:");

                name = Console.ReadLine();
                // TODO: Process error/exception if the item is not registered (Scan(string))
                items.Add(name);

            } while (name.ToLower() != "done");
        }
    }
}
