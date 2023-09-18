using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;
using static System.Net.WebRequestMethods;

namespace HSDAgentApp.Controllers
{
    /// <summary>
    /// 効果音再生コントローラー
    /// </summary>
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("[controller]")]
    public class SoundController : ControllerBase
    {
        /// <summary>
        /// ロガー
        /// </summary>
        private readonly ILogger<SoundController> _logger;
        // private static SoundPlayer player = null;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="logger"></param>
        public SoundController(ILogger<SoundController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "PlaySound")]
        public ActionResult Play(string filePath)
        {
            JsonResult result = null;
            Dictionary<string, object> returnVal = new Dictionary<string, object>();

            string playStatus = "NULL";
            int statusCode = 000;

            filePath = filePath.Replace(@"\\", @"\");

            _logger.LogInformation("リクエストファイルパス：{0}", filePath);

            if (System.IO.File.Exists(filePath))
            {
                Dictionary<string, string> fileInfo = new Dictionary<string, string>();
                string fileExtension = Path.GetExtension(filePath);

                fileInfo.Add("File Exists", "OK");
                fileInfo.Add("File Parh", filePath);
                fileInfo.Add("File Name", Path.GetFileName(filePath));
                fileInfo.Add("File Extension", fileExtension);

                returnVal.Add("File Info", fileInfo);

                try
                {
                    /*
                    using (var waveOut = new WaveOutEvent())
                    {
                        using (var wavReader = new WaveFileReader(filePath))
                        {
                            waveOut.Init(wavReader);
                            waveOut.Play();
                        }
                    }
                    */

                    Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{filePath}').PlaySync();");

                    playStatus = "OK";
                    statusCode = (int)HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    _logger.LogError("ファイルの再生に失敗しました。：{0}", ex.Message);
                    _logger.LogDebug("スタックトレース：\n{0}", ex.StackTrace);
                    playStatus = "ERORR";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                Dictionary<string, string> fileInfo = new Dictionary<string, string>();

                _logger.LogError("リクエストされたファイルパスが存在しません。：{0}", filePath);

                fileInfo.Add("File Exists", "NG");
                fileInfo.Add("File Parh", filePath);

                returnVal.Add("File Info", fileInfo);

                playStatus = "NOT FOUND";
                statusCode = (int)HttpStatusCode.NotFound;
            }

            returnVal.Add("Play Status", playStatus);

            result = new JsonResult(returnVal);
            result.StatusCode = statusCode;

            return result;
        }

    }
}
