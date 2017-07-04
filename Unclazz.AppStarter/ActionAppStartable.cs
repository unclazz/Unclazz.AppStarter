using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class ActionAppStartable : IAppStartable
    {
        readonly Action<IAppContext> _action;
        internal ActionAppStartable(Action<IAppContext> action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }
        public void Start(IAppContext ctx)
        {
            _action(ctx);
        }
    }
}
