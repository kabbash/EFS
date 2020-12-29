using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using Trainer.EF;

namespace Trainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var appContext = services.GetRequiredService<EFSContext>();

                if (appContext.Database.GetPendingMigrations().Any())
                    appContext.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
         {
             webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
             webBuilder.UseStartup<Startup>();
             webBuilder.PreferHostingUrls(true);
         });
    }
}
