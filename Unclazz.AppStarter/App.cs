using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// アプリケーション・ランチャーの機能を提供するユーティリティです。
    /// </summary>
    public static class App
    {
        /// <summary>
        /// アプリケーション・ランチャーの構成を変更します。
        /// </summary>
        /// <param name="configAction">構成変更を行うアクション</param>
        /// <returns>変更された構成に基づきインスタンス化された<see cref="IAppStarter"/>インスタンス</returns>
        public static IAppStarter Configure(Action<IAppConfigurer> configAction)
        {
            return new DefaultAppStarter().Configure(configAction);
        }
        /// <summary>
        /// アプリケーションを起動します。
        /// <para>
        /// コマンドライン引数はアプリケーション構成ファイルの内容などとともに、
        /// <see cref="IAppContext"/>インスタンスに格納されてから、
        /// アプリケーションに渡されます。
        /// </para>
        /// <para>
        /// アプリケーションにより例外がスローされた場合、
        /// このメソッドはランチャーの構成内容に基づいて終了ステータスのコードを決定し、
        /// <see cref="Environment.Exit(int)"/>を呼び出します。
        /// </para>
        /// </summary>
        /// <param name="myApp">アプリケーションを表す<see cref="IAppStartable"/>インスタンス</param>
        /// <param name="args">コマンドライン引数</param>
        public static void Start(IAppStartable myApp, params string[] args)
        {
            new DefaultAppStarter().Start(myApp);
        }
        /// <summary>
        /// アプリケーションを起動します。
        /// <para>
        /// コマンドライン引数はアプリケーション構成ファイルの内容などとともに、
        /// <see cref="IAppContext"/>インスタンスに格納されてから、
        /// アプリケーションに渡されます。
        /// </para>
        /// <para>
        /// アプリケーションにより例外がスローされた場合、
        /// このメソッドはランチャーの構成内容に基づいて終了ステータスのコードを決定し、
        /// <see cref="Environment.Exit(int)"/>を呼び出します。
        /// </para>
        /// </summary>
        /// <typeparam name="T">アプリケーションを表す<see cref="IAppStartable"/>実装クラス</typeparam>
        /// <param name="args">コマンドライン引数</param>
        public static void Start<T>(params string[] args) where T : IAppStartable, new()
        {
            Start(new T());
        }
        /// <summary>
        /// アプリケーションを起動します。
        /// <para>
        /// コマンドライン引数はアプリケーション構成ファイルの内容などとともに、
        /// <see cref="IAppContext"/>インスタンスに格納されてから、
        /// アプリケーションに渡されます。
        /// </para>
        /// <para>
        /// アプリケーションにより例外がスローされた場合、
        /// このメソッドはランチャーの構成内容に基づいて終了ステータスのコードを決定し、
        /// <see cref="Environment.Exit(int)"/>を呼び出します。
        /// </para>
        /// </summary>
        /// <param name="myApp">アプリケーションを表すアクション</param>
        /// <param name="args">コマンドライン引数</param>
        public static void Start(Action<IAppContext> myApp, params string[] args)
        {
            Start(new ActionAppStartable(myApp ?? throw new ArgumentNullException(nameof(myApp))));
        }
    }
}
