using DrinkWholeSale.Persistence;
using DrinkWholeSale.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkWholeSale.WebApi
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
            DbType dbType = Configuration.GetValue<DbType>("DbType");
            switch (dbType)
            {
                case DbType.SqlServer:
                    services.AddDbContext<DrinkWholeSaleDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                        options.UseLazyLoadingProxies();
                    });

                    break;
                case DbType.Sqlite:
                    services.AddDbContext<DrinkWholeSaleDbContext>(options =>
                    {
                        options.UseSqlServer(Configuration.GetConnectionString("SqliteConnection"));
                        options.UseLazyLoadingProxies();
                    });
                    break;
                default:
                    break;
            }
            services.AddIdentity<Guest, IdentityRole<int>>()
                .AddEntityFrameworkStores<DrinkWholeSaleDbContext>() // EF haszn�lata a TravelAgencyContext entit�s kontextussal
                .AddDefaultTokenProviders(); // Alap�rtelmezett token gener�tor haszn�lata (pl. SecurityStamp-hez)



            services.Configure<IdentityOptions>(options =>
            {
                // Jelsz� komplexit�s�ra vonatkoz� konfigur�ci�
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;

                // Hib�s bejelentkez�s eset�n az (ideiglenes) kiz�r�sra vonatkoz� konfigur�ci�
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // Felhaszn�l�kezel�sre vonatkoz� konfigur�ci�
                options.User.RequireUniqueEmail = true;
            });

            // services.AddDistributedMemoryCache();  // 0402

            services.AddTransient<IDrinkWholeSaleService, DrinkWholeSaleService>();
            // Dependency injection be�ll�t�sa az alkalmaz�s �llapotra
            //services.AddSingleton<ApplicationState>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // 0402
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            DbInitializer.Initialize(serviceProvider, Configuration.GetValue<String>("ImageStore"));
        }
    }
}
