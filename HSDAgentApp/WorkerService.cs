using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace HSDAgentApp
{
    public sealed class WorkerService : BackgroundService
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<WorkerService> _logger;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="logger"></param>
        public WorkerService(ILogger<WorkerService> logger) =>
            (_logger) = (logger);

        /// <summary>
        /// サービス開始処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("サービスを開始します。");
            return base.StartAsync(cancellationToken);
        }

        /// <summary>
        /// サービス終了処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("サービスを終了します。");
            return base.StopAsync(cancellationToken);
        }

        /// <summary>
        /// 常駐処理
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("バックグランド処理を開始します。.");

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogTrace("バックグラウンド処理が実行中です。");
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "バックグラウンド処理でエラーが発生しました。エラー；{Message}", ex.Message);
                Environment.Exit(1);
            }

            _logger.LogDebug("バックグラウンド処理が停止しました。");
        }

    }
}
