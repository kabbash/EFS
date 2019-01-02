
using Articles.Core.Interfaces;
using Articles.Core.Models;
using Articles.Core.Services;
using Articles.Core.Validators;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Attachments.Core.Services;
using Attachments.Core.Validators;
using Authentication;
using Authentication.Interfaces;
using Authentication.Models;
using Authentication.Services;
using Authentication.Validators;
using FluentValidation;
using ItemsReview.Interfaces;
using ItemsReview.Models;
using ItemsReview.Services;
using ItemsReview.Validators;
using Lookups.Core.Interfaces;
using Lookups.Core.Services;
using MailProvider.Core;
using MailProvider.Core.Interfaces;
using MailProvider.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Products.Core.Interfaces;
using Products.Core.Models;
using Products.Core.Services;
using Products.Core.Validators;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Rating.Core.Services;
using Rating.Core.Validators;
using Shared.Core.Models;
using Shared.Core.Resources;
using Shared.Core.Utilities.Models;
using System.Text;
using test.core.Model;
using test.core.Validators;
using Trainer.EF;

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
            ConfigureValidations(services);
            ConfigureManagers(services);
            ConfigureSettings(services);
            ConfigureJwtAuthentication(services);

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // to be changed to client side app origin only
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();
            app.UseMvc();
        }

        #region Custom Configurations
        private void ConfigureConnectionString(IServiceCollection services)
        {
            services.AddDbContext<EFSContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<IAttachmentsManager, AttachmentsManager>();
            services.AddScoped<IProductsCategoriesManager, ProductsCategoriesManager>();
            services.AddScoped<IProductsManager, ProductsManager>();
            services.AddScoped<IRatingManager<Shared.Core.Models.Products>, RatingManager<Shared.Core.Models.Products>>();
            services.AddScoped<IRatingManager<ItemsForReview>, RatingManager<ItemsForReview>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, MailService>();
            services.AddScoped<ILookupService<CaloriesDto, Calories>, LookupService<CaloriesDto, Calories>>();
            services.AddScoped<ILookupService<ArticlesCategoriesDto, ArticlesCategories>, LookupService<ArticlesCategoriesDto, ArticlesCategories>>();
            services.AddScoped<IArticlesService, ArticleService>();
            services.AddScoped<IItemsReviewsManager, ItemsReviewsManager>();

        }
        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<AuthenticationSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<MailSettings>(Configuration.GetSection("Email"));
            var resources = Configuration.GetSection("Resources");
            services.Configure<AttachmentsResources>(resources.GetSection("FilesPaths").GetSection("Attachments"));
            services.Configure<ProductsResources>(resources.GetSection("ProductsResources"));
        }
        private void ConfigureValidations(IServiceCollection services)
        {
            services.AddTransient<IValidator<CaloriesDto>, CaloriesDtoValidator>();
            services.AddTransient<IValidator<ArticlesCategoriesDto>, ArticlesCategoriesValidator>();
            services.AddTransient<IValidator<UploadFileDto>, UploadFileDtoValidator>();
            services.AddTransient<IValidator<ProductsCategoryDto>, ProductsCategoryDtoValidator>();
            services.AddTransient<IValidator<ProductsDto>, ProductsDtoValidator>();
            services.AddTransient<IValidator<RatingDto>, RatingDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterValidator>();
            services.AddTransient<IValidator<ArticleAddDto>, ArticleAddDtoValidator>();
            services.AddTransient<IValidator<ItemReviewDto>, ItemReviewDtoValidator>();

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
