using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineAuction.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAuction.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host= CreateHostBuilder(args).Build();
            CreateAndSeedDatabase(host);
            host.Run();

        }

        private static void CreateAndSeedDatabase(IHost host)
        {
            using (var scope= host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFfactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var aspnetRunContext = services.GetRequiredService<WebAppContext>();
                    WebAppContextSeed.SeedAsync(aspnetRunContext, loggerFfactory).Wait();
                }
                catch (Exception ex )
                {

                    var logger = loggerFfactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured seeding the Db");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
