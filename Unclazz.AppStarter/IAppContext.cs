using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーションの実行コンテキストを表すインターフェースです。
    /// </summary>
    public interface IAppContext
    {
        /// <summary>
        /// 実行中のアプリケーションのコマンド名（例：<c>"ExampleApp.exe"</c>）です。
        /// <para>
        /// アプリケーションがショートファイル名（8.3形式）で指定された
        /// アセンブリ・ファイルから起動された場合でも、
        /// このプロパティは当該アセンブリ・ファイルのロングファイル名を返します。
        /// </para>
        /// </summary>
        string CommandName { get; }
        /// <summary>
        /// 実行中のアプリケーションのコマンドのパス（例：<c>"C:\\path\\to\\ExapleApp.exe"</c>）です。
        /// <para>
        /// アプリケーションがショートファイル名（8.3形式）で指定されたアセンブリ・ファイルから起動された場合でも、
        /// このプロパティは当該アセンブリ・ファイルのロングファイル名を返します。
        /// </para>
        /// </summary>
        string CommandPath { get; }
        /// <summary>
        /// コマンドライン引数です。
        /// </summary>
        IList<string> Arguments { get; }
        /// <summary>
        /// アプリケーション構成ファイルのappSettingsセクションの内容を格納した辞書です。
        /// </summary>
        IDictionary<string, string> AppSettings { get; }
        /// <summary>
        /// アプリケーション構成ファイルのconnectionStringsセクションの内容を格納した辞書です。
        /// </summary>
        IDictionary<string, string> ConnectionStrings { get; }
        /// <summary>
        /// アプリケーション・ランチャーの構成情報です。
        /// </summary>
        IAppConfiguration Configuration { get; }
        /// <summary>
        /// アプリケーションの統計情報です。
        /// </summary>
        IAppStatistics Statistics { get; }
        /// <summary>
        /// このアプリケーションのために初期化されたロガーです。
        /// </summary>
        IAppLogger Logger { get; }
    }
}
