using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Trainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
