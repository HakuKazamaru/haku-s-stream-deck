using HSDWebApp.Common.Identity;
using HSDWebApp.Data;
using HSDWebApp.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

using NLog.Extensions.Logging;
using NLog.Web;

namespace HSDWebApp
{
    public class Startup
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<Startup> _logger;

        /// <summary>
        /// Appsettg.json設定値管理用
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// 動作設定
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("動作設定を開始します。");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Add services to the container.
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                var dbType = "sqlite";

                // ログ出力設定
                options.EnableSensitiveDataLogging();


                // DB接続先指定
                switch (dbType)
                {
                    case "sqlite":
                        {
                            _logger.LogInformation("DBモード：SQLiteモード");
                            options.UseSqlite(connectionString, providerOptions => { });
                            break;
                        }
                    case "mssql":
                        {
                            _logger.LogInformation("DBモード：Microsoft SQL Serverモード");
                            options.UseSqlServer(connectionString, providerOptions =>
                            {
                                providerOptions.EnableRetryOnFailure();
                            });
                            break;
                        }
                    default:
                        {
                            goto case "sqlite";
                        }
                }

            });

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<JapaneseIdentityErrorDescriber>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddControllersWithViews();
            services.AddRazorPages();

            _logger.LogInformation("動作設定が完了しました。");
        }

        /// <summary>
        /// ASP.NET Core設定
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            _logger.LogInformation("ASP.NET Core設定を開始します。");

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                _logger.LogInformation("デバックモード");
                app.UseMigrationsEndPoint();
            }
            else
            {
                _logger.LogInformation("プロダクションモード");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // app.UseCors();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapFallbackToFile("index.html"); ;
            });

            _logger.LogInformation("ASP.NET Core設定が完了しました。");
        }
    }
}
