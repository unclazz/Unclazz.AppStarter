using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーション・ランチャーの構成情報を変更するためのインターフェースです。
    /// <para>
    /// <see cref="App.Configure(Action{IAppConfigurer})"/>もしくは
    /// <see cref="IAppStarter.Configure(Action{IAppConfigurer})"/>の引数として渡されたアクションは、
    /// この<see cref="IAppConfigurer"/>インスタンスを引数として呼び出されます。
    /// </para>
    /// </summary>
    public interface IAppConfigurer
    {
        /// <summary>
        /// アプリケーションの処理が例外をスローすることなく完了した場合の終了ステータスを指定します（デフォルトは<c>0</c>）。
        /// </summary>
        /// <param name="code">終了ステータス・コード</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetStatusOnSuccess(int code);
        /// <summary>
        /// アプリケーションの処理が例外をスローした場合、
        /// もしくはアプリケーション実行中に<see cref="IAppStatistics.ErrorDetected"/>
        /// が<c>true</c>に変化した場合の終了ステータスを指定します（デフォルトは<c>1</c>）。
        /// </summary>
        /// <param name="code">終了ステータス・コード</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetStatusOnFailure(int code);
        /// <summary>
        /// コンソールに対するログ出力において標準出力ではなく標準エラー出力を使用するよう指定します（デフォルトは<c>false</c>）。
        /// </summary>
        /// <param name="use">標準エラー出力を使用する場合<c>true</c></param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetUseErrorStream(bool use);
        /// <summary>
        /// ログ出力をファイルにも出力するよう指定します（デフォルトは<c>true</c>）。
        /// </summary>
        /// <param name="use">ファイルにも出力する場合<c>true</c></param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetUseLogFile(bool use);
        /// <summary>
        /// ログ出力する下限のログ・レベルを指定します（デフォルトは<see cref="AppLogLevel.Warn"/>）。
        /// </summary>
        /// <param name="lv">ログ・レベル</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetMinLogLevel(AppLogLevel lv);
        /// <summary>
        /// ログ出力先ディレクトリのパスを指定します。
        /// </summary>
        /// <param name="path">ログ出力先ディレクトリのパス</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetLogDirectory(string path);
        /// <summary>
        /// ログ・ファイル名を指定します（デフォルトは<c>"{commandName}_{yyyyMMddHHmmss.fff}.log"</c>形式）。
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetLogFileName(string fileName);
        /// <summary>
        /// ログ・ファイルに書き出す際に使用するエンコーディングを指定します（デフォルトは<see cref="Encoding.UTF8"/>）。
        /// </summary>
        /// <param name="enc">エンコーディング</param>
        /// <returns>このオブジェクト自身</returns>
        IAppConfigurer SetLogEncoding(Encoding enc);
    }
}
