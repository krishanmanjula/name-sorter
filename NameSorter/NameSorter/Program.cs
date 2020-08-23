using Microsoft.Extensions.DependencyInjection;
using System;
using StructureMap;
using NameSorter.Logic;
using Microsoft.Extensions.Logging;
using System.IO;
using NameSorter.Services;
using System.Text;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection and configure our services and the framework services.
            var services = new ServiceCollection()
             .AddSingleton<IValidateFile, ValidateTxtFileFormat>()
             .AddSingleton<IFileServices, ReadFileContent>()
             .AddSingleton<ISortName, SortName>()
             .AddLogging();


            var container = new Container();
            container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap.
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });
                //Populate the container using the service collection.
                config.Populate(services);
            });

            // Generate a provider.
            var serviceProvider = container.GetInstance<IServiceProvider>();

            // Configure console logging.
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            string UnsortedNamesPath = @"Files\unsorted-names-list.txt";
            string SortedNamesPath = @"Files\sorted-names-list.txt";
            string FileFormat = ".txt";

            // Calling SortNamesByLastNameThenGivenName.
            var SortName = serviceProvider.GetService<ISortName>();
            var SortedString = SortName.SortNamesByLastNameThenGivenName(UnsortedNamesPath, SortedNamesPath, FileFormat);

            // Print the results to screen.
            Console.WriteLine(SortedString);
            Console.ReadKey();
        }
    }
}
