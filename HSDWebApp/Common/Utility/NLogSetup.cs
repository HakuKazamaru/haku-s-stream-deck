using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using System.Reflection;

using nlogex= NLog.Extensions.Logging;
using nlog=NLog;

namespace HSDWebApp.Common.Utility
{
    public class NLogSetup
    {
        /// <summary>
        /// NLogのセットアップメソッド
        /// </summary>
        public static void Setup()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("HSDWebApp.Common.Utility", LogLevel.Debug)
                    .AddConsole();
            });

            ILogger logger = loggerFactory.CreateLogger<NLogSetup>();
            logger.LogInformation("========== Func Start! ==================================================");

            // アッセンブリ情報の取得
            Assembly? assembly = Assembly.GetEntryAssembly();
            // exe配置場所取得
            string appPath = assembly.Location;
            // NLogの初期化
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(appPath))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            nlog.LogManager.Configuration = new nlogex.NLogLoggingConfiguration(config.GetSection("NLog"));

            logger.LogDebug("-------------------------------------------------------------------------------");
            logger.LogDebug("環境情報");
            logger.LogDebug("カレントディレクトリ　：{0}", Directory.GetCurrentDirectory());
            logger.LogDebug("アプリケーションパス　：{0}", appPath);
            logger.LogDebug("コンフィグディレクトリ：{0}", Path.GetDirectoryName(appPath));

            logger.LogInformation("========== Func End!   ==================================================");
        }
    }
}
