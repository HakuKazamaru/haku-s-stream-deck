using Microsoft.EntityFrameworkCore;

using NLog;
using NLog.Web;

using HSDWebApp.Models;
using HSDWebApp.Common.Utility;

namespace HSDWebApp.Data.ModelCreationg
{
    /// <summary>
    /// HSDノーマルサイズ設定管理用テーブル
    /// </summary>
    public class HsdNomalConfigTable
    {
        /// <summary>
        /// Nlogロガー
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// HSDノーマルサイズ設定管理用テーブルモデル初期化メソッド
        /// </summary>
        /// <param name="dbType"></param>
        /// <param name="modelBuilder"></param>
        public static void Init(string dbType, ref ModelBuilder modelBuilder)
        {
            NLogSetup.Setup();
            Logger.Info("========== Func Start! ==================================================");
            // チャットログ管理テーブル
            modelBuilder.Entity<HsdNormalConfig>(entity =>
            {
                // 主キーの設定
                entity.HasKey(e => new {
                    e.UserId ,
                    e.PanelId,
                    e.RowNumber,
                    e.ColumnNumber
                });
                // テーブル名の設定
                entity.HasComment("HSDノーマルサイズ設定管理用テーブル");

                // DB共通のカラム処理
                // 入室者名
                entity.Property(c => c.UserId)
                    .HasColumnType("varchar(95)")
                    .HasComment("ユーザーID");
                // パネルナンバー
                entity.Property(c => c.PanelId)
                    .HasColumnType("smallint")
                    .HasComment("パネルナンバー");
                // 行番
                entity.Property(c => c.RowNumber)
                    .HasColumnType("smallint")
                    .HasComment("行番");
                // 列番
                entity.Property(c => c.ColumnNumber)
                    .HasColumnType("smallint")
                    .HasComment("列番");
                // ボタン名
                entity.Property(c => c.ButtonName)
                    .HasColumnType("varchar(128)")
                    .HasComment("ボタン名");
                // ボタン種別
                entity.Property(c => c.ButtonType)
                    .HasColumnType("smallint")
                    .HasComment("ボタン種別");
                // ボタンコマンド
                entity.Property(c => c.CommandString)
                    .HasColumnType("varchar(512)")
                    .HasComment("ボタンコマンド");

                // ボタンアイコンイメージデータ
                entity.Property(c => c.ButtonIconData)
                    .HasColumnType("blob")
                    .HasComment("ボタンアイコンイメージデータ");

                // ボタンについてのメモ
                entity.Property(c => c.Description)
                    .HasColumnType("varchar(2048)")
                    .HasComment("ボタンについてのメモ");

                // DBごとのカラム処理
                switch (dbType)
                {
                    case "mysql":
                        {
                            Logger.Debug("MySQLモードで実行します。");
                            // 最終更新日時
                            entity.Property(c => c.LastUpdate)
                                .HasColumnType("datetime")
                                .HasComment("最終更新日時");
                            break;
                        }
                    case "pgsql":
                        {
                            Logger.Debug("PostgerSQLモードで実行します。");
                            // 最終更新日時
                            entity.Property(c => c.LastUpdate)
                                .HasColumnType("timestamp with time zone")
                                .HasComment("最終更新日時");
                            break;
                        }
                    case "mssql":
                        {
                            Logger.Debug("MicrosoftSQLモードで実行します。");
                            // 最終更新日時
                            entity.Property(c => c.LastUpdate)
                                .HasColumnType("datetimeoffset")
                                .HasComment("最終更新日時");
                            break;
                        }
                    default:
                        {
                            Logger.Warn("DBTypeに不正な値が指定されています。設定値：{0}", dbType);
                            goto case "mysql";
                        }
                }

            });
            Logger.Info("========== Func End!   ==================================================");
        }
    }
}
