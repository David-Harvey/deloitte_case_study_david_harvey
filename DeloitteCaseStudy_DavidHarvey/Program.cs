using System;
using System.Linq;

namespace DeloitteCaseStudy_DavidHarvey
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Any())
                {
                    var settings = new Settings();
                    var provider = new FileProvider { FileLocation = args[0] };
                    var scheduler = new Scheduler();
                    var organiser = new ActivityOrganiser();

                    foreach (var result in scheduler.Run(provider, organiser, settings))
                    {
                        Console.WriteLine(result);
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Press any key to close the application");
                    Console.ReadKey();
                }
                else
                {
                    Usage();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException);
                Console.WriteLine("Press any key to close application");
                Console.ReadKey();
            }
        }

        private static void Usage()
        {
            Console.WriteLine("Please provide full or relative path to execute application.");
            Console.WriteLine(@"Example: DeloitteCaseStudy_DavidHarvey.exe .\sampledata.txt");
            Console.WriteLine(@"Example: DeloitteCaseStudy_DavidHarvey.exe C:\app_data\sampledata.txt");
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}