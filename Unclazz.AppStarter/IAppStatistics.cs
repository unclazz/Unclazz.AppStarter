using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// 実行中のアプリケーションの統計情報です。
    /// </summary>
    public interface IAppStatistics
    {
        /// <summary>
        /// アプリケーションの起動にあたりショートファイル名（8.3形式）でアセンブリ・ファイルが指定された場合<c>true</c>。
        /// </summary>
        bool ShortNameUsed { get; }
        /// <summary>
        /// アプリケーションの実行中にエラー発生が検知された場合<c>true</c>。
        /// <para>
        /// このプロパティは<see cref="IAppLogger.Error(String)"/>もしくはそのオーバーロードが呼び出されたとき
        /// <c>true</c>になります。
        /// </para>
        /// </summary>
        bool ErrorDetected { get; }
        /// <summary>
        /// アプリケーションの実行中に警告発生が検知された場合<c>true</c>。
        /// <para>
        /// このプロパティは<see cref="IAppLogger.Warn(String)"/>もしくはそのオーバーロードが呼び出されたとき
        /// <c>true</c>になります。
        /// </para>
        /// </summary>
        bool WarningDetected { get; }
        /// <summary>
        /// アプリケーションが起動した日時です。
        /// </summary>
        DateTime StartedOn { get; }
        /// <summary>
        /// アプリケーションが起動してからの経過時間です。
        /// </summary>
        TimeSpan ElapsedTime { get; }
    }
}
