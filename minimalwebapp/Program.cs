using System;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Logging;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var host = new WebHostBuilder()
            .UseKestrel()
            .ConfigureLogging(f => f.AddConsole(LogLevel.Information))
            .UseUrls("http://0.0.0.0:8080")
            .UseStartup<Startup>()
            .Build();
 
            host.Run();
        }
    }
}