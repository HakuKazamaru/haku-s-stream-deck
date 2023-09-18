using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSDAgentApp.Models
{
    public class Job
    {
        /// <summary>
        /// ジョブ名
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// ジョブ種別
        /// (PROGRAM：アプリ実行、SOUND：サウンド再生、SHORTCUT：キーボードショートカット実行)
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// コマンド内容
        /// </summary>
        string Command { get; set; }
        /// <summary>
        /// ジョブ説明
        /// </summary>
        string Description { get; set; }
    }
}
