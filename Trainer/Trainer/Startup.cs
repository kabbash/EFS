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
using System.Reflection;
using test.core.Services;
using test.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Shared.Core;
using Trainer.EF.Models;

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
            var connection = @"Server=DESKTOP-55PE9HK\MOHAMEDMAGDY;Database=EFS_Dev;Trusted_Connection=True";
            services.AddScoped<ITestManager, TestManager>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DbContext, EFS_DevContext>();
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
