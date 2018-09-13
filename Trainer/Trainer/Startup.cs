using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using test.core;
using Trainer.EF;
using Microsoft.EntityFrameworkCore;
using Trainer.EF.Models;
using System.Reflection;
using test.core.Services;
using test.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Core;

namespace Trainer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=aspnet-ITI.MVC.MovieStore-20160318014639;Trusted_Connection=True";
            //sservices.AddDbContext<aspnetITIMVCMovieStore20160318014639Context>(options => options.UseSqlServer(connection));
            services.AddScoped<ITestManager, TestManager>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DbContext, aspnetITIMVCMovieStore20160318014639Context>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
     
            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
