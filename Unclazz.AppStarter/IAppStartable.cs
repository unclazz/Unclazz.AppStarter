using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    /// <summary>
    /// <see cref="App"/>もしくは<see cref="IAppStarter"/>から起動可能なアプリケーションを表すインターフェースです。
    /// </summary>
    public interface IAppStartable
    {
        /// <summary>
        /// アプリケーションのエントリー・ポイントとなるメソッドです。
        /// </summary>
        /// <param name="ctx"></param>
        void Start(IAppContext ctx);
    }
}
