using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーションの構成情報を表すインターフェースです。
    /// </summary>
    public interface IAppConfiguration
    {
        /// <summary>
        /// アプリケーションの処理が正常に終了した場合の終了ステータスです。
        /// </summary>
        int StatusOnSuccess { get; }
        /// <summary>
        /// アプリケーションの処理中にエラーが発生した場合の終了ステータスです。
        /// </summary>
        int StatusOnFailure { get; }
        /// <summary>
        /// コンソールに対するログ出力において標準出力ではなく標準エラー出力を使用する場合<c>true</c>です。
        /// </summary>
        bool UseErrorStream { get; }
        /// <summary>
        /// ログ出力をファイルにも出力する場合<c>true</c>です。
        /// </summary>
        bool UseLogFile { get; }
        /// <summary>
        /// ログ出力する下限のログ・レベルです。
        /// </summary>
        AppLogLevel MinLogLevel { get; }
        /// <summary>
        /// ログ出力先ディレクトリのパスです。
        /// </summary>
        string LogDirectory { get; }
        /// <summary>
        /// ログ・ファイル名です。
        /// </summary>
        string LogFileName { get; }
        /// <summary>
        /// ログ・ファイルに書き出す際に使用するエンコーディングです。
        /// </summary>
        Encoding LogEncoding { get; }
    }
}
