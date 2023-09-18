using Microsoft.Extensions.Configuration;
using System;
using System.IO;

using NLog;
using NLog.Web;

using Models = HSDWebApp.Models;

namespace HSDWebApp.Common.Utility
{
    /// <summary>
    /// アプリケーション設定補助クラス
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Nlogロガー
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 設定値管理用オブジェクト
        /// </summary>
        public Models.CofingModel AppConfig { get; set; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public Config()
        {
            NLogSetup.Setup();

            AppConfig = new Models.CofingModel();
            AppConfig.ConnectionStrings = GetConnectionStrings();
            AppConfig.DBType = GetAppsettingsToSectionStringValue("DBType");
        }

        /// <summary>
        /// appsettings.jsonの"appsettings"セクションから
        /// 指定したセクションの設定値を文字列で取得
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string GetAppsettingsToSectionStringValue(string sectionName)
        {
            string sectionValue = string.Empty;
            NLogSetup.Setup();

            Logger.Info("========== Func Start! ==================================================");
            Logger.Debug("Parameter[sectionName]：{0}", sectionName);

            try
            {
                var configuration =
                    new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", true, true).Build();
                IConfigurationSection section = configuration.GetSection("appSettings");

                sectionValue = section[sectionName];
                Logger.Debug("Value                 ：{0}", sectionValue);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                sectionValue = string.Empty;
            }

            Logger.Info("========== Func End!   ==================================================");

            return sectionValue;
        }

        /// <summary>
        /// DB接続文字列取得メソッド
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static string GetConnectionStrings(string sectionName = "Context")
        {
            string sectionValue = string.Empty;
            NLogSetup.Setup();

            Logger.Info("========== Func Start! ==================================================");
            Logger.Debug("Parameter[sectionName]：{0}", sectionName);

            try
            {
                var configuration =
                    new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", true, true).Build();
                IConfigurationSection section = configuration.GetSection("ConnectionStrings");

                sectionValue = section[sectionName];
                Logger.Debug("Value                 ：{0}", sectionValue);

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                sectionValue = string.Empty;
            }

            Logger.Info("========== Func End!   ==================================================");

            return sectionValue;
        }

    }
}
