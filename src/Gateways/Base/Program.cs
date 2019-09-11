namespace UserLocation.Gateways.Base
{
    using System.IO;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);

            builder
                .ConfigureServices(services => services.AddSingleton(builder))
                .ConfigureAppConfiguration(configuration => configuration
                    .AddJsonFile("ocelot.json"))
                .UseStartup<Startup>();

            return builder;
        }
    }
}
