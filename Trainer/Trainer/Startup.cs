
using Articles.Core.Interfaces;
using Articles.Core.Models;
using Articles.Core.Services;
using Articles.Core.Validators;
using Attachments.Core.Interfaces;
using Attachments.Core.Models;
using Attachments.Core.Services;
using Attachments.Core.Validators;
using Authentication.Interfaces;
using Authentication.Models;
using Authentication.Services;
using Authentication.Validators;
using Banner.Core.Interfaces;
using Banner.Core.Models;
using Banner.Core.Services;
using Banner.Core.Validations;
using FluentValidation;
using Home.Core.Interfaces;
using Home.Core.Models;
using Home.Core.Services;
using Home.Core.Validators;
using ItemsReview.Interfaces;
using ItemsReview.Models;
using ItemsReview.Services;
using ItemsReview.Validators;
using Lookups.Core.Interfaces;
using Lookups.Core.Services;
using MailProvider.Core.Interfaces;
using MailProvider.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Neutrints.Core.Interfaces;
using Neutrints.Core.Services;
using OTraining.Core.Interfaces;
using OTraining.Core.Models;
using OTraining.Core.Services;
using OTraining.Core.Validators;
using Products.Core.Interfaces;
using Products.Core.Models;
using Products.Core.Services;
using Products.Core.Validators;
using Rating.Core.Interfaces;
using Rating.Core.Models;
using Rating.Core.Services;
using Rating.Core.Validators;
using Serilog;
using Shared.Core.Models;
using Shared.Core.Settings;
using Shared.Core.Utilities.Models;
using Shared.Core.Validators;
using System.Linq;
using System.Text;
using Trainer.EF;
using DBModels = Shared.Core.Models;

namespace Trainer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConnectionString(services);
            ConfigureValidations(services);
            ConfigureManagers(services);
            ConfigureSettings(services);
            ConfigureJwtAuthentication(services);
            ConfigureMapstr();

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder.WithOrigins("https://www.egyfitstore.com","http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();        
            app.UseStaticFiles();
            app.UseCors("MyPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Custom Configurations
        private void ConfigureConnectionString(IServiceCollection services)
        {
            services.AddDbContext<EFSContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<IAttachmentsManager, AttachmentsManager>();
            services.AddScoped<IProductsManager, ProductsManager>();
            services.AddScoped<IOTrainingManager, OTrainingManager>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailService, MailService>();
            services.AddScoped<IArticlesService, ArticleService>();
            services.AddScoped<IItemsReviewsManager, ItemsReviewsManager>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IBannerManager, BannerManager>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<INeutrintsManager, NeutrintsManager>();

            // Generic Services 
            services.AddScoped(typeof(ISliderManager<>), typeof(SliderManager<>));
            services.AddScoped(typeof(IRatingManager<>), typeof(RatingManager<>));
            services.AddScoped(typeof(ILookupService<,>), typeof(LookupService<,>));
        }
        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }
        private void ConfigureValidations(IServiceCollection services)
        {
            services.AddTransient<IValidator<ArticlesCategoriesDto>, ArticlesCategoriesValidator>();
            services.AddTransient<IValidator<UploadFileDto>, UploadFileDtoValidator>();
            services.AddTransient<IValidator<ProductsCategoryDto>, ProductsCategoryDtoValidator>();
            services.AddTransient<IValidator<ProductsDto>, ProductsDtoValidator>();
            services.AddTransient<IValidator<OTrainingDetailsDto>, OTrainingDetailsDtoValidator>();
            services.AddTransient<IValidator<OTrainingProgramDto>, ProgramDtoValidator>();
            services.AddTransient<IValidator<RatingDto>, RatingDtoValidator>();
            services.AddTransient<IValidator<RegisterDto>, RegisterValidator>();
            services.AddTransient<IValidator<ArticleAddDto>, ArticleAddDtoValidator>();
            services.AddTransient<IValidator<RejectDto>, RejectDtoValidator>();
            services.AddTransient<IValidator<ItemReviewDto>, ItemReviewDtoValidator>();
            services.AddTransient<IValidator<BannerDto>, BannerValidator>();
            services.AddTransient<IValidator<ContactUsDto>, ContactUsValidator>();
        }
        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.AuthenticationSettings.Secret);
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
        private void ConfigureMapstr()
        {
            TypeAdapterConfig<ArticleAddDto, DBModels.Articles>.NewConfig()
                                                   .Ignore(dest => dest.Id);
            TypeAdapterConfig<DBModels.Products, ProductsDto>.NewConfig()
                                                   .Map(dest => dest.CategoryName, src => (src.Category ?? new ProductsCategories()).Name);
            TypeAdapterConfig<DBModels.ProductsCategories, ProductsCategoryDto>.NewConfig()
                                                   .Map(dest => dest.HasSubCategory, src => src.Subcategories != null && src.Subcategories.Count > 0);
            TypeAdapterConfig<DBModels.AspNetUsers, User>.NewConfig()
                                                  .Map(dest => dest.Roles, src => src.AspNetUserRoles != null ? src.AspNetUserRoles.Select(r => r.Role.Name) : null);

        }
        #endregion
    }
}
