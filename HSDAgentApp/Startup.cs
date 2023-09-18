using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

namespace HSDAgentApp
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
            string cosrPolicyName = "DefaultPolicy";
            _logger.LogInformation("動作設定を開始します。");

            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy
                            .WithOrigins(new string[] {
                                "http://localhost:*",
                                "https://localhost:*"
                            })
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                    );
                options.AddPolicy(name: cosrPolicyName,
                     policy =>
                     {
                         policy
                            .WithOrigins(new string[] {
                                "http://localhost:*",
                                "https://localhost:*"
                            })
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                     }
                    );
            });

            // services.AddNodeServices();

            _logger.LogInformation("動作設定が完了しました。");
        }

        /// <summary>
        /// ASP.NET Core設定
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        [Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            string cosrPolicyName = "DefaultPolicy";
            _logger.LogInformation("ASP.NET Core設定を開始します。");

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                _logger.LogInformation("デバックモード");

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                _logger.LogInformation("プロダクションモード");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(cosrPolicyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireCors(cosrPolicyName); ;
            });

            _logger.LogInformation("ASP.NET Core設定が完了しました。");
        }
    }
}
