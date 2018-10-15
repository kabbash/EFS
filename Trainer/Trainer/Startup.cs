using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trainer.EF;
using Microsoft.EntityFrameworkCore;
using test.core.Services;
using test.core.Interfaces;
using Shared.Core;
using Authentication;
using Microsoft.IdentityModel.Tokens;
using Authentication.Services;
using Authentication.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using test.core.Model;
using FluentValidation;
using test.core.Validators;
using Authentication.Validators;
using Authentication.Models;

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
            services.AddDbContext<EFSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICaloriesManager, CaloriesManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AuthenticationSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AuthenticationSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<IValidator<CaloriesDto>, CaloriesDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterValidator>();



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
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
