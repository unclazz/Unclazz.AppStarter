using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーションのロガーを表すインターフェースです。
    /// </summary>
    public interface IAppLogger
    {
        /// <summary>
        /// トレース・レベルのログ出力を行います。
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Trace(string message);
        /// <summary>
        /// トレース・レベルのログ出力を行います。
        /// </summary>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Trace(string format, params object[] args);
        /// <summary>
        /// 情報レベルのログ出力を行います。
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Info(string message);
        /// <summary>
        /// 情報レベルのログ出力を行います。
        /// </summary>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Info(string format, params object[] args);
        /// <summary>
        /// 警告レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.WarningDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Warn(string message);
        /// <summary>
        /// 警告レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.WarningDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Warn(string format, params object[] args);
        /// <summary>
        /// 警告レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.WarningDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="ex">警告レベル扱いの例外オブジェクト</param>
        /// <param name="message">メッセージ</param>
        void Warn(Exception ex, string message);
        /// <summary>
        /// 警告レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.WarningDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="ex">警告レベル扱いの例外オブジェクト</param>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Warn(Exception ex, string format, params object[] args);
        /// <summary>
        /// エラー・レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.ErrorDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Error(string format, params object[] args);
        /// <summary>
        /// エラー・レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.ErrorDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="message">メッセージ</param>
        void Error(string message);
        /// <summary>
        /// エラー・レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.ErrorDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="message">メッセージ</param>
        void Error(Exception ex, string message);
        /// <summary>
        /// エラー・レベルのログ出力を行います。
        /// <para>
        /// このメソッドを呼び出すと<see cref="IAppStatistics.ErrorDetected"/>に<c>true</c>が設定されます。
        /// </para>
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="format">メッセージ・フォーマット</param>
        /// <param name="args">フォーマット対象オブジェクトの配列</param>
        void Error(Exception ex, string format, params object[] args);
    }
}
