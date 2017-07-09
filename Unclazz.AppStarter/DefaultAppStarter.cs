using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Unclazz.AppStarter
{
    sealed class DefaultAppStarter : IAppStarter
    {
        readonly DefaultAppStatistics _stats;
        readonly DefaultAppConfiguration _conf;
        readonly IAppExitProxy _exitProxy;
        readonly IAppAssemblyProxy _asmProxy;
        readonly Func<string[], IAppContext> _ctxFactory;

        internal DefaultAppStarter() : this(null, null, null)
        {
        }
        internal DefaultAppStarter(IAppAssemblyProxy asmProxy, IAppExitProxy exitProxy, Func<string[], IAppContext> ctxFactory)
        {
            _asmProxy = asmProxy ?? FuncAppAssemblyProxy.Default;
            _exitProxy = exitProxy ?? ActionAppExitProxy.Default;
            _stats = new DefaultAppStatistics(_asmProxy);
            _conf = new DefaultAppConfiguration(_asmProxy, _stats);
            _ctxFactory = ctxFactory ?? ((args) => new DefaultAppContext(_asmProxy, _stats, _conf, args ?? new string[0]));
        }

        public IAppStarter Configure(Action<IAppConfigurer> conf)
        {
            conf(_conf);
            return this;
        }
        public void Start(IAppStartable myApp, params string[] args)
        {
            var ctx = _ctxFactory(args);
            try
            {
                myApp.Start(ctx);
                if (ctx.Statistics.ErrorDetected)
                {
                    _exitProxy.Exit(ctx.Configuration.StatusOnFailure);
                }
                else if (ctx.Statistics.WarningDetected)
                {
                    _exitProxy.Exit(ctx.Configuration.StatusOnFailure - 1);
                }
                else
                {
                    _exitProxy.Exit(ctx.Configuration.StatusOnSuccess);
                }
            }
            catch (Exception ex)
            {
                ctx.Logger.Error(ex, "An error has occurred. And the application has stopped working.");
                _exitProxy.Exit(ctx.Configuration.StatusOnFailure);
            }
        }
        public void Start<T>(params string[] args) where T : IAppStartable, new()
        {
            Start(new T(), args);
        }
        public void Start(Action<IAppContext> myApp, params string[] args)
        {
            Start(new ActionAppStartable(myApp), args);
        }
    }
}
