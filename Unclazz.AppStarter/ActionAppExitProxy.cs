using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// <see cref="IAppExitProxy"/>の実装クラスです。
    /// <para>
    /// <see cref="Exit(int)"/>は、コンストラクタの引数として指定されたデリゲートを呼び出します。
    /// そしてそれ以外何も行いません。
    /// </para>
    /// </summary>
    sealed class ActionAppExitProxy : IAppExitProxy
    {
        static ActionAppExitProxy _defaultCache;

        /// <summary>
        /// <see cref="ActionAppExitProxy"/>のデフォルトのインスタンスです。
        /// <para><see cref="Exit(int)"/>は<c>Environment.Exit(int)</c>を呼び出します。</para>
        /// </summary>
        internal static ActionAppExitProxy Default => _defaultCache ??
            (_defaultCache = new ActionAppExitProxy(Environment.Exit));

        readonly Action<int> _action;
        internal ActionAppExitProxy(Action<int> action)
        {
            _action = action;
        }
        public void Exit(int code)
        {
            _action(code);
        }
    }
}
