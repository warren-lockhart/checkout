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
            .AddSingleton<IItemService, ItemService>()
            .BuildServiceProvider();

            var itemService = serviceProvider.GetService<IItemService>();

            Console.WriteLine("Welcome to Checkout! Warren Corporation: Copyright 2020");
            Console.WriteLine("Scan Your Items");
            Console.WriteLine("Type 'done' to sum goods");

            string name;

            do
            {
                Console.WriteLine("Item name:");

                name = Console.ReadLine();

            } while (name.ToLower() != "done");
        }
    }
}
