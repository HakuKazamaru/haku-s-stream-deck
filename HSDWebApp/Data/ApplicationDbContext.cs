using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MLog = Microsoft.Extensions.Logging;

using NLog;
using NLog.Extensions.Logging;
using NLog.Fluent;
using NLog.Web;

using HSDWebApp.Common.Utility;
using ModelCreationg = HSDWebApp.Data.ModelCreationg;
using HSDWebApp.Models;
using System.Reflection;

namespace HSDWebApp.Data
{
    /// <summary>
    /// DBコンテキスト
    /// </summary>
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        /// <summary>
        /// Nlogロガー
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 使用DB
        /// </summary>
        private string dbType = "sqlite";

        /// <summary>
        /// データベース接続文字列
        /// </summary>
        // private string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-HSDWebApp-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";
        private string connectionString = "Data Source=Application.db;Cache=Shared";

        #region テーブルモデル宣言
        /// <summary>
        /// HSD標準サイズ設定管理テーブル
        /// </summary>
        public DbSet<HsdNormalConfig> HsdNormalConfigTable { get; set; }
        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="options"></param>
        /// <param name="operationalStoreOptions"></param>
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
            string tmpConnectionString = "";
            NLogSetup.Setup();

            Logger.Info("========== Func Start! ==================================================");
            // 使用するDBの指定
            dbType = Config.GetAppsettingsToSectionStringValue("DBType");
            tmpConnectionString = Config.GetConnectionStrings();

            Logger.Debug("設定データベース：{0}", dbType);
            Logger.Debug("設定DB接続文字列：{0}", tmpConnectionString);

            if (dbType != "mysql" && dbType != "pgsql" && dbType != "mssql" && dbType != "sqlite")
            {
                dbType = "sqlite";
            }

            if (!string.IsNullOrWhiteSpace(tmpConnectionString))
            {
                connectionString = tmpConnectionString;
            }

            Logger.Info("使用データベース：{0}", dbType);
            Logger.Info("DB接続文字列　　：{0}", connectionString);

            Logger.Info("========== Func End!   ==================================================");
        }

        /// <summary>
        /// コンテキスト初期化時処理
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Logger.Info("========== Func Start! ==================================================");
            // ロガーの設定
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddProvider(new NLogLoggerProvider())
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name &&
                        level == MLog.LogLevel.Information);
            });

            // DB接続先指定
            switch (dbType)
            {
                case "sqlite":
                    {
                        Logger.Info("SQLiteモードで実行します。");
                        optionsBuilder
                            .UseSqlite(connectionString)
                            .EnableDetailedErrors()
                            .EnableSensitiveDataLogging()
                            .UseLoggerFactory(loggerFactory);
                        break;
                    }
                case "mysql":
                    {
                        Logger.Info("MySQLモードで実行します。");
                        optionsBuilder
                            .UseMySQL(connectionString)
                            .EnableDetailedErrors()
                            .EnableSensitiveDataLogging()
                            .UseLoggerFactory(loggerFactory);
                        break;
                    }
                case "pgsql":
                    {
                        Logger.Info("PostgerSQLモードで実行します。");
                        optionsBuilder
                            .UseNpgsql(connectionString)
                            .EnableSensitiveDataLogging()
                            .UseLoggerFactory(loggerFactory);
                        break;
                    }
                case "mssql":
                    {
                        Logger.Info("MicrosoftSQLモードで実行します。");
                        optionsBuilder
                            .UseSqlServer(connectionString)
                            .EnableSensitiveDataLogging()
                            .UseLoggerFactory(loggerFactory);
                        break;
                    }
                default:
                    {
                        Logger.Warn("DBTypeに不正な値が指定されています。設定値：{0}", dbType);
                        goto case "mysql";
                    }
            }

            Logger.Info("========== Func End!   ==================================================");
        }

        /// <summary>
        /// データモデル生成時処理
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Logger.Info("========== Func Start! ==================================================");
            base.OnModelCreating(modelBuilder);

            // 各データモデルの初期化
            ModelCreationg.HsdNomalConfigTable.Init(dbType, ref modelBuilder);

            Logger.Info("========== Func End!   ==================================================");
        }
    }
}