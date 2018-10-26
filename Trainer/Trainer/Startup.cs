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
using Shared.Core.Resources;
using Attachments.Core.Models;
using Attachments.Core.Validators;
using Attachments.Core.Interfaces;
using Attachments.Core.Services;
using Products.Core.Interfaces;
using Products.Core.Services;
using Products.Core.Models;
using Products.Core.Validators;
using Authentication.Validators;
using Authentication.Models;
using MailProvider.Core;
using MailProvider.Core.Interfaces;
using MailProvider.Core.Services;

namespace Trainer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConnectionString(services);
            ConfigureManagers(services);
            ConfigureSettings(services);
            ConfigureValidations(services);
            ConfigureJwtAuthentication(services);

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            

            // to be changed to client side app origin only
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

        #region Custom Configurations
        private void ConfigureConnectionString(IServiceCollection services)
        {
            services.AddDbContext<EFSContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<ICaloriesManager, CaloriesManager>();
            services.AddScoped<IAttachmentsManager, AttachmentsManager>();
            services.AddScoped<IProductsCategoriesManager, ProductsCategoriesManager>();
            services.AddScoped<IProductsSubCategoriesManager, ProductsSubCategoriesManager>();
            services.AddScoped<IProductsManager, ProductsManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, MailService>();
        }
        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<AuthenticationSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("Email"));
            var resources = Configuration.GetSection("Resources");
            services.Configure<AttachmentsResources>(resources.GetSection("AttachmentsResources"));
            services.Configure<TestResources>(resources.GetSection("TestResources"));
            services.Configure<ProductsResources>(resources.GetSection("ProductsResources"));
        }
        private void ConfigureValidations(IServiceCollection services)
        {
            services.AddTransient<IValidator<CaloriesDto>, CaloriesDtoValidator>();
            services.AddTransient<IValidator<UploadFileDto>, UploadFileDtoValidator>();
            services.AddTransient<IValidator<ProductsCategoryDto>, ProductsCategoryDtoValidator>();
            services.AddTransient<IValidator<ProductsSubCategoryDto>, ProductsSubCategoryDtoValidator>();
            services.AddTransient<IValidator<ProductsDto>, ProductsDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterValidator>();
        } 
        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
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
        }
        #endregion
    }
}
