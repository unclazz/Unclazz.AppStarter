using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーションの終了処理を代行するためのアセンブリ・プライベートなインターフェースです。
    /// <para>単体テストにおいて<see cref="Environment.Exit(int)"/>のプロキシを用意する必要があるため、
    /// このインターフェースが用意されました。</para>
    /// </summary>
    interface IAppExitProxy
    {
        /// <summary>
        /// アプリケーションの終了処理を行います。
        /// </summary>
        /// <param name="code">終了ステータス・コード</param>
        void Exit(int code);
    }
}
