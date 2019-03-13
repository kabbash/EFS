﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Trainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
           .UseContentRoot(Directory.GetCurrentDirectory())
           .UseStartup<Startup>()
           .PreferHostingUrls(true);

        //.ConfigureAppConfiguration((hostingContext, config) =>
        //{
        //    config.AddJsonFile("emailTemplates.json", optional: false, reloadOnChange: false);
        //})
    }
}
