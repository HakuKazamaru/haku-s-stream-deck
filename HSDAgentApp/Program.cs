using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.NodeServices;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

using System;
using System.Reflection;

using NLog.Extensions.Logging;
using NLog.Web;

namespace HSDAgentApp
{
    public static class Program
    {
        /// <summary>
        /// Nlogロガー
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// メインメソッド
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // アッセンブリ情報の取得
            Assembly? assembly = Assembly.GetEntryAssembly();
            // exe配置場所取得
            string appPath = assembly.Location;
            // NLogの初期化
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(appPath))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            NLog.LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            Logger.Info("===============================================================================");
            Logger.Info("プログラムが起動しました。");
            Logger.Debug("-------------------------------------------------------------------------------");
            Logger.Debug("環境情報");
            Logger.Debug("カレントディレクトリ　：{0}", Directory.GetCurrentDirectory());
            Logger.Debug("アプリケーションパス　：{0}", appPath);
            Logger.Debug("コンフィグディレクトリ：{0}", Path.GetDirectoryName(appPath));

            // ASP実行
            CreateWebHostBuilder(args).Build().RunAsync();

            // NodeJs環境実行

            // サービスプログラムのの実行
            CreateHostBuilder(args).Build().Run();

            Logger.Info("プログラムが終了しました。");
        }

        /// <summary>
        /// サービスの初期化
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService(options =>
                {
                    options.ServiceName = "HSD Agent Service";
                })
                .ConfigureServices(services =>
                {
                    LoggerProviderOptions.RegisterProviderOptions<
                        EventLogSettings, EventLogLoggerProvider>(services);

                    services.AddHostedService<WorkerService>();
                })
                .ConfigureLogging((context, logging) =>
                {
                    // See: https://github.com/dotnet/runtime/issues/47303
                    logging.AddConfiguration(
                        context.Configuration.GetSection("Logging"));
                })
                .UseNLog();

        /// <summary>
        /// ASP.NET初期化
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}

