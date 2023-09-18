using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

using Microsoft.EntityFrameworkCore;

using System;
using System.Reflection;

using NLog.Extensions.Logging;
using NLog.Web;

namespace HSDWebApp
{
    public static class Program
    {
        /// <summary>
        /// Nlog���K�[
        /// </summary>
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// ���C�����\�b�h
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // �A�b�Z���u�����̎擾
            Assembly? assembly = Assembly.GetEntryAssembly();
            // exe�z�u�ꏊ�擾
            string appPath = assembly.Location;

            Common.Utility.NLogSetup.Setup();

            Logger.Info("===============================================================================");
            Logger.Info("�v���O�������N�����܂����B");
            Logger.Debug("-------------------------------------------------------------------------------");
            Logger.Debug("�����");
            Logger.Debug("�J�����g�f�B���N�g���@�F{0}", Directory.GetCurrentDirectory());
            Logger.Debug("�A�v���P�[�V�����p�X�@�F{0}", appPath);
            Logger.Debug("�R���t�B�O�f�B���N�g���F{0}", Path.GetDirectoryName(appPath));

            // ASP���s
            CreateWebHostBuilder(args).Build().RunAsync();

            // �T�[�r�X�v���O�����̂̎��s
            CreateHostBuilder(args).Build().Run();

            Logger.Info("�v���O�������I�����܂����B");
        }


        /// <summary>
        /// �T�[�r�X�̏�����
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService(options =>
                {
                    options.ServiceName = "HSD Web Service";
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
        /// ASP.NET������
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }

}







