using aventuras.data.sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using aventuras.data.sql.Migrations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using aventuras.Middlewares;
using aventuras.BindingModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using aventuras.idata.User;
using aventuras.iservices.User;
using aventuras.services.User;
using aventuras.data.sql.User;
using aventuras.Validation;
using aventuras.idata.Share;
using aventuras.iservices.Share;
using aventuras.services.Share;
using aventuras.data.sql.Share;
using aventuras.idata.Rating;
using aventuras.iservices.Rating;
using aventuras.services.Rating;
using aventuras.data.sql.Rating;



namespace aventuras
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AventurasDbContext>(options => options
                .UseMySQL(Configuration.GetConnectionString("AventurasDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
                .AddFluentValidation();
            services.AddTransient<IValidator<EditUser>, EditUserValidator>();
            services.AddTransient<IValidator<CreateUser>, CreateUserValidator>();
            services.AddTransient<IValidator<EditShare>, EditShareValidator>();
            services.AddTransient<IValidator<CreateShare>, CreateShareValidator>();
            services.AddTransient<IValidator<EditRating>, EditRatingValidator>();
            services.AddTransient<IValidator<CreateRating>, CreateRatingValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShareService, ShareService>();
            services.AddScoped<IShareRepository, ShareRepository>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.UseApiBehavior = false;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AventurasDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
