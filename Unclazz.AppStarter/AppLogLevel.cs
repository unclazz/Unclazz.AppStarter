using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーションのログ・レベルを表す列挙型です。
    /// </summary>
    public enum AppLogLevel
    {
        /// <summary>
        /// トレース・レベル
        /// </summary>
        Trace,
        /// <summary>
        /// 情報レベル
        /// </summary>
        Info,
        /// <summary>
        /// 警告レベル
        /// </summary>
        Warn,
        /// <summary>
        /// エラー・レベル
        /// </summary>
        Error
    }
}
