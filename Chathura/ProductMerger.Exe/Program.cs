using ProductMerger.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMerger.Business;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProductMerger.Service;

namespace ProductMerger.Exe
{
    public class Program
    {
        static Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            Console.WriteLine("Please enter the Ids of the parent company and the child company in the order with a single space");
            Console.WriteLine("");

            var input = Console.ReadLine();

            var inputArray = input?.Split(' ');

            if (inputArray == null ||
                !int.TryParse(inputArray[0], out var parentCompanyId) ||
                !int.TryParse(inputArray[1], out var childCompanyId))
            {
                throw new Exception("Invalid inputs.");
            }

            host.Services.GetService<IProductMergerAppService>().MergeProducts(parentCompanyId,
                childCompanyId);

            Console.WriteLine("New merged file has been saved. Press enter to exit.");

            Console.ReadLine();

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<IRepository, Repository>()
                        .AddSingleton<IProductMergerAppService, ProductMergerAppService>());

    }
}
