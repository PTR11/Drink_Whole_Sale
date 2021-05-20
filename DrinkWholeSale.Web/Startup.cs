using DrinkWholeSale.Persistence;
using DrinkWholeSale.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DrinkWholeSale.Web
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
            services.AddSingleton<ApplicationState>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // 0402
            // Dependency injection a IHttpContextAccessor-hoz
            services.AddHttpContextAccessor();
            
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Munkamenetkezel�s be�ll�t�sa
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15); // max. 15 percig �l a munkamenet
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "CartId";
                options.Cookie.HttpOnly = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession(); // 0402

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            var context = services.GetRequiredService<DrinkWholeSaleDbContext>();
            var directory = Configuration["ImageStore"];
            DbInitializer.Initialize(services, Configuration.GetValue<String>("ImageStore"));
        }
    }
}
